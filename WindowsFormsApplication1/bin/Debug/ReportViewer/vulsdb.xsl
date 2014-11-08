<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">

<html>
<head>
  <meta charset="utf-8" />
  <title>Database - VulScannner</title>
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
	<script type="text/javascript" src="js/script_db.js"></script>
	<script type="text/javascript" src="js/wiky.js"></script>
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
							<a href="#">Vul Scanner DB</a>
						</li>
					</ul>
					<!--
					<div class="navbar-form navbar-left">
						<div class="form-group">
						<input class="form-control" type="text" id="search_input" />
						</div> <button style="margin-left:6px" type="button" class="btn btn-default" id="search_btn">Search</button>
					</div>
					-->
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
			<h3 style="margin-top:0px">Vulnerabilities: </h3>
			<xsl:for-each select="vulcategories/vul">
			<input type="button" class="btn btn-default full-btn btn-vuls" value="{name}" />
			</xsl:for-each>
		</div>
		<div class="col-md-9 column" id="results">
			<xsl:for-each select="vulcategories/vul">
			<div class="row info-block div_hide">
				<h3 style="text-align:center" class="vul_name"><xsl:value-of select="name"/></h3>
				<h4>Description: </h4>
				<div class="vul_description blockquote_main div_show"><xsl:value-of select="description"/></div>
				<h4>Environment: </h4>
				<div class="vul_environment blockquote_main div_show"><xsl:value-of select="environment"/></div>
				<h4>Vulnerability Info:</h4>
				<button type="button" class="btn btn-default full-btn btn-more-info">Example</button>
				<div class="row vul_example blockquote_main"><xsl:value-of select="example"/></div>
				<button type="button" class="btn btn-default full-btn btn-more-info">Determination</button>
				<div class="row vul_determination blockquote_main"><xsl:value-of select="determination"/></div>
				<button type="button" class="btn btn-default full-btn btn-more-info">Protection</button>
				<div class="row vul_protection blockquote_main"><xsl:value-of select="protection"/></div>
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
