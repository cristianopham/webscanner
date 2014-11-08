<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">

<html>
<head>
  <meta charset="utf-8" />
  <title>Result Viewer - VulScannner</title>
  <meta name="viewport" content="width=device-width, initial-scale=1.0" />
  <meta name="description" content="" />
  <meta name="author" content="" />

	<!--link rel="stylesheet/less" href="less/bootstrap.less" type="text/css" /-->
	<!--link rel="stylesheet/less" href="less/responsive.less" type="text/css" /-->
	<!--script src="js/less-1.3.3.min.js"></script-->
	<!--append ‘#!watch’ to the browser URL, then refresh the page. -->
	
	<link href="css/bootstrap.min.css" rel="stylesheet" />
	<link href="css/style.css" rel="stylesheet" />

  <!-- HTML5 shim, for IE6-8 support of HTML5 elements -->
  <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
  <![endif]-->

  <!-- Fav and touch icons -->
  <link rel="apple-touch-icon-precomposed" sizes="144x144" href="img/apple-touch-icon-144-precomposed.png" />
  <link rel="apple-touch-icon-precomposed" sizes="114x114" href="img/apple-touch-icon-114-precomposed.png" />
  <link rel="apple-touch-icon-precomposed" sizes="72x72" href="img/apple-touch-icon-72-precomposed.png" />
  <link rel="apple-touch-icon-precomposed" href="img/apple-touch-icon-57-precomposed.png" />
  <link rel="shortcut icon" href="img/favicon.png" />
  
	<script type="text/javascript" src="js/jquery.min.js"></script>
	<script type="text/javascript" src="js/bootstrap.min.js"></script>
	<script type="text/javascript" src="js/scripts.js"></script>
</head>

<body>
<div class="container">
	<div class="row clearfix">
		<div class="col-md-12 column">
			<nav class="navbar navbar-default navbar-fixed-top" role="navigation">
				<div class="navbar-header">
					 <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1"> <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button> <a class="navbar-brand" href="#">VulScanner</a>
				</div>
				
				<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
					<ul class="nav navbar-nav">
						<li class="sort-by-plugin sort-by active">
							<a href="#">Sort By Plugin</a>
						</li>
						<li class="sort-by-file_name sort-by">
							<a href="#">Sort By File Name</a>
						</li>
						<li class="sort-by-severity sort-by">
							<a href="#">Sort By Severity</a>
						</li>
						<li class="sort-by-reliability sort-by">
							<a href="#">Sort By Reliability</a>
						</li>
					</ul>
					<div class="navbar-form navbar-left">
						<div class="form-group">
						<input class="form-control" type="text" id="search_input" />
						</div> <button style="margin-left:6px" type="button" class="btn btn-default" id="search_btn">Search</button>
					</div>
					<ul class="nav navbar-nav navbar-right">
						<!--
						<li>
							<a href="#">About</a>
						</li>
						-->
					</ul>

				</div>
				
			</nav>
		</div>
	</div>
	<div class="row clearfix" style="margin-top:80px"></div>
	<div class="row clearfix">
		<div id="left_plugin_template" style="display:none">
			<button type="button" class="btn btn-default full-btn btn-plugin">{{plugin}}</button>
		</div>
		<div class="col-md-3 column" id="left_plugin_list">
			<h3 style="margin-top:0px">Plugins: </h3>
			<button type="button" class="btn btn-default full-btn btn-plugin">All Plugins</button>
		</div>
		<div class="col-md-9 column" id="results">
			<h3 style="margin-top:0px">Total: <span id="total_vuls"><xsl:value-of select="count(Result/vuls/vul)"/></span></h3>
			<xsl:for-each select="Result/vuls/vul">
			<div class="row result-block" data-severity="{severity}" data-plugin_name="{plugin_name}" data-reliability="{reliability}" data-file_name="{file_name}">
				<button type="button" class="btn btn-default full-btn btn-category"><xsl:value-of select="category"/></button>
				<div class="blockquote_main">
					<div class="row">
						<div class="col-md-12 column">
							<b>Plugin: <span class="plugin_name not-bold"><xsl:value-of select="plugin_name"/></span></b>
							<br />
							<b>File name: <span class="file_name not-bold"><xsl:value-of select="file_name"/></span></b>
							<br />
							<b>Url: <span class="url not-bold"><xsl:value-of select="url"/></span></b>
						</div>
					</div>
					<div class="row">
						<div class="col-md-4 column">
							<b>Severity: </b><span class="severity"><xsl:value-of select="severity"/></span>
						</div>
						<div class="col-md-4 column">
							<b>Reliability: </b><span class="reliability"><xsl:value-of select="reliability"/></span>
						</div>
						<div class="col-md-4 column">
							<b>Param: </b><span class="param"><xsl:value-of select="param"/></span>
						</div>
					</div>
					<div class="row">
						<div class="col-md-12 column">
							<b>Category Link: </b><a target="_blank" href="{category_link}"><span class="category_link"><xsl:value-of select="category_link"/></span></a>
							<br />
							<b>Source Line Number: <span class="line_number"><xsl:value-of select="line_number"/></span></b>
							<pre><span class="source"><xsl:value-of select="source"/></span></pre>
						</div>					
					</div>
				</div>
			</div>
			 </xsl:for-each>

		</div>
	</div>
</div>
<script>

</script>
</body>
</html>

</xsl:template>
</xsl:stylesheet> 
