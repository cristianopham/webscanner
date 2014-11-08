$(document).ready(function() {
	load_all_wikiml();

	load_current();	

	$('.btn-more-info').click(function() {
		$(this).next().toggle(200);
	});

	var name;
	$('.btn-vuls').click(function() {
		$('.info-block').hide();
		name = $(this).val();
		$('.info-block').each(function() {
			vul_name = $(this).find('.vul_name').html();

			if(name === vul_name) {
				//alert("ds");
				$(this).show();
				$("html, body").animate({ scrollTop: 0 }, 400);
			}
		});
	});
});

function load_all_wikiml() {
	$('.blockquote_main').each(function() {
		html_new = $(this).html();
		//alert(html_new);
		//decoded_data = html_entity_decode(html_new);
		decoded_data = html_new.replaceAll("&lt;pre&gt;", "<pre>");
		decoded_data = decoded_data.replaceAll("&lt;/pre&gt;", "</pre>");
		//alert(decoded_data);


		//change wiki format
		decoded_data = wiky.process(decoded_data, {});

		//alert(decoded_data);
		this.innerHTML = decoded_data;

	});
}

String.prototype.replaceAll = function(target, replacement) {
	return this.split(target).join(replacement);
};

function html_entity_decode(str){
	/*Firefox (and IE if the string contains no elements surrounded by angle brackets )*/
	try{
	var ta=document.createElement("textarea");
	ta.innerHTML=str;
	return ta.value;
	}catch(e){};
	/*Internet Explorer*/
	try{
	var d=document.createElement("div");
	d.innerHTML=str.replace(/</g,"&lt;").replace(/>/g,"&gt;");
	if(typeof d.innerText!="undefined")return d.innerText;/*Sadly this strips tags as well*/
	}catch(e){}
}

function html_entity_decode(str)
{
    if(str) // check str is empty or not.
        return $("<textarea />").html(str).text();
    else
        return '';
}

function load_current() {
	curr_link = decodeURI(window.location.href);
	temp = curr_link.split("#");
	name = (temp[1]) ? temp[1] : "";
	//alert(name);

	name = name.replace(/[^A-Z0-9]+/ig, "_");
	$('.info-block').each(function() {
		vul_name = $(this).find('.vul_name').html();
		vul_name = vul_name.replace(/[^A-Z0-9]+/ig, "_");
		if(name === vul_name) {
		//alert("ds");
			$(this).show();
			$("html, body").animate({ scrollTop: 0 }, 400);
		}
	});
}