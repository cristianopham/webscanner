$(document).ready(function() {
	$('.btn-category').click(function() {
		$(this).next().toggle(200);
	});	

	$('#search_input').keypress(function(e) {
		if (e.which == 13) {
			search_result($('#search_input').val());
		}
	});

	$('#search_btn').click(function() {
		search_result($('#search_input').val());
	});

	$('.sort-by-severity').click(function() {
		sort_elems("severity", "asc");
		$('.sort-by').removeClass("active");
		$('.sort-by-severity').addClass("active");
	});

	$('.sort-by-plugin').click(function() {
		sort_elems("plugin_name", "asc");
		$('.sort-by').removeClass("active");
		$('.sort-by-plugin').addClass("active");
	});

	$('.sort-by-reliability').click(function() {
		sort_elems("reliability", "asc");
		$('.sort-by').removeClass("active");
		$('.sort-by-reliability').addClass("active");
	});

	$('.sort-by-file_name').click(function() {
		sort_elems("file_name", "asc");
		$('.sort-by').removeClass("active");
		$('.sort-by-file_name').addClass("active");
	});

	init_all_plugins();
});

function init_all_plugins() {
	arr = [];
	$('.plugin_name').each(function() {
		plugin_name = $(this).html();
		//alert(plugin_name);
		if(arr.indexOf( plugin_name, arr ) == -1) {
			arr.push(plugin_name);
		}
	});

	p_template = $('#left_plugin_template').html();
	//alert(p_template);
	list_plugins = "";

	for(i=0; i<arr.length; i+=1) {
		t_template = p_template.replace("{{plugin}}", arr[i]);
		list_plugins = list_plugins + t_template;
	}
	//alert(list_plugins);

	$('#left_plugin_list').append(list_plugins);

	$('.btn-plugin').click(function() {
		search = $(this).html();
		if(search == "All Plugins") search = "";
		//alert(search);
		search_result(search);
	});
}

function sort_elems(sort_attr, sort_option) {
	// get array of elements
	var myArray = $(".result-block");

	// sort based on timestamp attribute
	myArray.sort(function (a, b) {
		    
	    // convert to integers from strings
	    //a = parseInt($(a).data(sort_attr), 10);
	    //b = parseInt($(b).data(sort_attr), 10);
	    a = $(a).data(sort_attr) + "";
	    a = a.toLowerCase();
	    b = $(b).data(sort_attr) + "";
	    b = b.toLowerCase();

	    if(sort_option == "asc") {
		    // compare
		    if(a > b) {
		        return 1;
		    } else if(a < b) {
		        return -1;
		    } else {
		        return 0;
		    }
		}
		else if(sort_option == "desc") {
		    // compare
		    if(a < b) {
		        return 1;
		    } else if(a > b) {
		        return -1;
		    } else {
		        return 0;
		    }				
		}
	});

	// put sorted results back on page
	$("#results").append(myArray);
}

function search_result(keyword) {
	total = 0;
	var myArray = $(".result-block");

	myArray.each(function() {
		//alert($(this).text());
		content = $(this).text();
		if(content.toLowerCase().indexOf(keyword.toLowerCase()) >= 0) {
			$(this).show();
			total += 1;
		}
		else {
			$(this).hide();
		}
	});

	$('#total_vuls').html(total);
}




