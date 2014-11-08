<?php

/**
 * This class looks for XSS vulnerabilities of the form:
 *   String foo = request.getParameter("foo");
 *   String foo = request.getRequestURI();
 *   String foo = request.getQueryString();
 *   ...
 *   <%= foo %>
 * @extends Plugin
 * @package Yasca
 */
class Plugin_injection_xss_jsp extends Plugin {
    public $valid_file_types = array("jsp", "java");
    
    function execute() {
		$SOURCE=0; // constants for indexing xss_array
		$SINK=1;
		$xss_array=array(); //Array to store the sources/sinks of the XSS problems
		$line_numbers=array();
		
		$count = count($this->file_contents);
										   
        for ($i=0; $i<$count; $i++) {

           if (preg_match('/([a-zA-Z0-9\_]+)\s*\=\s*request\.(getParameter\(\s*\"(.*)\"\s*\)|getRequestURI\(\s*\)|getQueryString\(\s*\))/', $this->file_contents[$i], $matches)) {
                $variable_name = $matches[1];
                $parameter_name = $matches[2];
                
                for ($j=$i+1; $j<$count; $j++) {
                    if (preg_match('/((\<\%\s*=\s*' . $variable_name . '\s*\%\>)|(out.print\s*[^;]*' . $variable_name . '[)+;\s]+))/', $this->file_contents[$j])) {
						if ( !isset($xss_array[$variable_name][$SOURCE]) )
						{
							$xss_array[$variable_name][$SOURCE]="";
							$xss_array[$variable_name][$SINK]="";
						}
						if (!stristr( $xss_array[$variable_name][$SINK], "".($j+1) ) )
						{
							$xss_array[$variable_name][$SINK]=$xss_array[$variable_name][$SINK]." ".($j+1);
						}
						if (!stristr( $xss_array[$variable_name][$SOURCE], "".($i+1) ) )
						{
							$xss_array[$variable_name][$SOURCE]=$xss_array[$variable_name][$SOURCE]." ".($i+1);
						}
						$line_numbers[$variable_name]=$j+1;
                        continue;
                    }
                }
            }
        }

		foreach( $xss_array as $key=>$value)
		{
			
			$result = new Result();
			$result->plugin_name = "Cross-Site Scripting via Request() in JSP"; 
			$result->line_number = $line_numbers[$key];
			$result->severity = 1;
			$result->category = "XSS Problems (Source/Sink in Description)";
			$result->category_link = "http://www.owasp.org/index.php/XSS";
			$result->description = <<<END
			<p>
			Source lines are: $value[0]<br/>
			Sink lines are: $value[1]<p>
			Cross-Site Scripting (XSS) vulnerabilities can be exploited by an attacker to 
			impersonate or perform actions on behalf of legitimate users.
        
			This particular issue is caused by the use of <b>request.Item(String)</b> within
			JSP code. For instance, consider the following snippet: <p/><code>

			String s = request.getParameter("body"); -- This is considered the source<br/>
			...<br/>
			out.println(s); --This is considered the sink<br/>
			</code><p/>
        
			The attacker could exploit this vulnerability by directing a victim to visit a URL
			with specially crafted JavaScript to perform actions on the site on behalf of the 
			attacker, or to simply steal the session cookie. <p>
			A solution to this problem would be to filter out bad characters such as '&lt;'  or '&gt;' at the source  
			or use HtmlEncoding at the sink.
			</p>
			<p>
				<h4>References</h4>
				<ul>
					<li><a href="http://www.owasp.org/index.php/XSS">http://www.owasp.org/index.php/XSS</a></li>
					<li><a href="http://www.ibm.com/developerworks/tivoli/library/s-csscript/">Cross-site Scripting article from IBM</a></li>
				</ul>
			</p>
END;
			array_push($this->result_list, $result);                
		}
    }
}
?>
