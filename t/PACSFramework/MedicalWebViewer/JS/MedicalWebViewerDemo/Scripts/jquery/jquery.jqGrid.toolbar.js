$.fn.extend({
	/*
	*  
	* The toolbar has the following properties
	*   id of top toolbar: t_<tablename>
	*   id of bottom toolbar: tb_<tablename>
	*   class of toolbar: ui-userdata
	* elem is the toolbar name to which button needs to be added. This can be 
	*       #t_tablename - if button needs to be added to the top toolbar
	*       #tb_tablename - if button needs to be added to the bottom toolbar
	*/
	toolbarButtonAdd: function (elem, p) {
		p = $.extend({
			caption: "newButton",
			title: '',
			buttonicon: 'ui-icon-newwin',
			onClickButton: null,
			position: "last"
		}, p || {});
		var $elem = $(elem);
		var tableString = "<div class='btn-toolbar'>";
		
		//console.log("In toolbar button add method");
		/* 
		* Step 1: check whether a table is already added. If not add
		* Step 2: If there is no table already added then add a table
		* Step 3: Make the element ready for addition to the table 
		* Step 4: Check the position and corresponding add the element
		* Step 5: Add other properties 
		*/
		//step 1 
		return this.each(function () {
			if (!this.grid) { return; }
			if (elem.indexOf("#") != 0) {
				elem = "#" + elem;
			}
			//step 2
			if ($(elem).children('div').length === 0) {
				$(elem).append(tableString);
			}
			//step 3								
			var findnav = $(elem).children('div');
			var button = $('<a type="button" class="btn btn-default btn-sm"></a>').click(function (e) {
			    if ($.isFunction(p.onClickButton))
			    {
			        p.onClickButton();
			    }
			    return false;
			});;
			var icon = null;

			if (p.buttonicon) {
			    icon = $("<span style='vertical-align:middle' class='" + p.buttonicon + "'></span>");
			}

			if (p.id) {
			    $(button).attr("id", p.id);
			}

			if (p.align) {
			    $(button).addClass(p.align);
			}
            
			if (typeof p.enabled != 'undefined') {
			    if (p.enabled == false) {
			        $(button).attr('disabled', 'disabled');			        
			    }
			    else
			        $(button).removeAttr('disabled');
			}
			
			if (icon)
			    button.append(icon);
			findnav.append(button);
		});
	},
	toolbarLabelAdd: function (elem, p) {
		p = $.extend({
			caption: "newLabel",
			title: '',
			id: '',
			position: "last"
		}, p || {});
		var $elem = $(elem);
		var $elem = $(elem);
		var tableString = "<div class='btn-toolbar'>";
		/* 
		* Step 1: check whether a table is already added. If not add
		* Step 2: If there is no table already added then add a table
		* Step 3: Make the element ready for addition to the table 
		* Step 4: Check the position and corresponding add the element
		* Step 5: Add other properties 
		*/
		//step 1 
		return this.each(function () {
		    if (!this.grid) { return; }
		    if (elem.indexOf("#") != 0) {
		        elem = "#" + elem;
		    }
		    //step 2
		    if ($(elem).children('div').length === 0) {
		        $(elem).append(tableString);
		    }
		    //step 3								
		    var findnav = $(elem).children('div');
		    var label = null;

		    if (p.caption) {
		        label = $("<span style='vertical-align:middle' class='label label-default'>" + p.caption + "</span>");
		    }

		    if (p.id && label) {
		        $(label).attr("id", p.id);
		    }		    

		    if (label) {
		        findnav.append(label);
		    }
		});
	},

	toolbarAncherAdd: function (elem, p) {
		p = $.extend({
			caption: "newButton",
			title: '',
			id: '',
			buttonicon: '',
			buttonclass: '',
			onClickButton: null,
			position: "last"
		}, p || {});
		var $elem = $(elem);
		var tableString = "<table style='float:left;table-layout:auto;' cellspacing=\"0\" cellpadding=\"0\" border=\"0\" class='ui-toolbar-table'>";
		tableString += "<tbody> <tr></tr></table>";
		/* 
		* Step 1: check whether a table is already added. If not add
		* Step 2: If there is no table already added then add a table
		* Step 3: Make the element ready for addition to the table 
		* Step 4: Check the position and corresponding add the element
		* Step 5: Add other properties 
		*/
		//step 1 
		return this.each(function () {
			if (!this.grid) { return; }
			if (elem.indexOf("#") != 0) {
				elem = "#" + elem;
			}
			//step 2
			if ($(elem).children('table').length === 0) {
				$(elem).append(tableString);
			}
			//step 3
			var tbd = $("<td style=\"padding-left:1px;padding-right:1px\"></td>"),
				iconClass = p.buttonicon.length === 0 ? "" : "<span class='ui-icon " + p.buttonicon + "'></span>";
			$(tbd).addClass('ui-toolbar-button ui-corner-all').append("<a class='ui-toolbar-a " + p.buttonClass + "'>" + iconClass + "<span>" + p.caption + "</span>" + "</a>").attr("title", p.title || "")
			.click(function (e) {
				if ($.isFunction(p.onClickButton)) { p.onClickButton(); }
				return false;
			});
			if (p.id) { $(tbd).attr("id", p.id); }
			if (p.align) { $(elem).attr("align", p.align); }
			var findnav = $(elem).children('table');
			if (p.position === 'first') {
				if ($(findnav).find('td').length === 0) {
					$("tr", findnav).append(tbd);
				} else {
					$("tr td:eq(0)", findnav).before(tbd);
				}
			} else {
				//console.log("not first");
				$("tr", findnav).append(tbd);
			}
		});
	},
});