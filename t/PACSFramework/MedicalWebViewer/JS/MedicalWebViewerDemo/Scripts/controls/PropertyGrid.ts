// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/LEADTOOLS/jquery/jquery.d.ts" />
/// <reference path="../../lib/LEADTOOLS/jquery/jqueryui.d.ts" />

class PropertyGridItem {
    public groupName: string = "";
    public rowType: string = "";
    public cssName: string = "";
    public dropFields: string = "";
    public isSubGroup: string = "";
    public value: any = null;
    public propertyName: string = "";
    public enabled:boolean = true;
}

class Group {
    private _groupName: string;

    public get GroupName(): string {
        return this._groupName;
    }

    public set GroupName(value) {
        this._groupName = value;
    }

    private _outputDiv;

    public get OutputDiv(): string {
        return this._outputDiv;
    }

    public set OutputDiv(value) {
        this._outputDiv = value;
    }

    private _subGroup;

    public get SubGroup(): string {
        return this._subGroup;
    }

    public set SubGroup(value) {
        this._subGroup = value;
    }

    private _Items = new Array();

    public get Items(): Array<any> {
        return this._Items;
    }

    private _SubGroups = new Array();

    public get SubGroups(): Array<any> {
        return this._SubGroups;
    }

    constructor(groupName, id, subgroup) {
        this._groupName = groupName;
        if (subgroup) {
            this._outputDiv = 'pg1_subgroup_' + id;
        }
        else {
            this._outputDiv = 'pg1_group_' + id;
        }
    }
};

class ClassItem {
    private _cssId;

    public get CssId(): string {
        return this._cssId;
    }

    public set CssId(value) {
        this._cssId = value;
    }

    private _outputDiv;

    public get OutputDiv(): string {
        return this._outputDiv;
    }

    public set OutputDiv(value) {
        this._outputDiv = value;
    }

    private _Type;

    public get Type(): string {
        return this._Type;
    }

    public set Type(value) {
        this._Type = value;
    }

    private _value;

    public get Value(): any {
        return this._value;
    }

    public set Value(value) {
        this._value = value;
    }

    private _DropFields;

    public get DropFields(): string {
        return this._DropFields;
    }

    public set DropFields(value) {
        this._DropFields = value;
    }

    private _propertyName;

    public get PropertyName(): any {
        return this._propertyName;
    }

    public set PropertyName(value) {
        this._propertyName = value;
    }

    private _enabled: boolean;

    public get Enabled(): boolean {
        return this._enabled;
    }

    public set Enabled(value:boolean) {
        this._enabled = value;
    }


    constructor(cssName, rowType, drpFields, id, value, propertyName, propertiesLookup: Array<any>, enabled) {
        this._cssId = cssName;
        this._outputDiv = 'pg1_item_' + id;
        this._Type = rowType;
        this._DropFields = drpFields;
        this._value = value;
        this.PropertyName = propertyName;
        this.Enabled = enabled;

        propertiesLookup[propertiesLookup.length] = [cssName, this._outputDiv, rowType];
    }
};

class PropertyGrid {
    private _OutputDivId: string;
    private _DefaultSizeType: string;
    private _Properties = new Array();
    private _PropertiesLookup = new Array();

    private groupCount: number = 0;
    private subGroupCount: number = 0;
    private cssItem: number = 0;

    constructor(outputDiv, sizeType) {
        this._OutputDivId = outputDiv;
        this._DefaultSizeType = sizeType;
    }

    public get GroupCount(): number {
        return this._Properties.length;
    }

    public PropertyChanged: (name, value) => void;
    public PropertyClicked: (name, value) => void;

    public addProperty(groupName: string, rowType: string, cssName: string, drpFields: string, isSubGroup: string, value: any, propertyName, enabled: boolean, clickHandler?: string) {
        //create css property
        //first check if groupName exists
        var foundGroup = false;

        for (var i = 0; i < this._Properties.length; i++) {
            if (this._Properties[i].GroupName == groupName) {
                //found group - check if its going to be a sub group or a item within group?
                if (isSubGroup) {
                    //sub group - search the inner subgroups loop
                    var foundSubGroup = false;
                    for (var x = 0; x < this._Properties[i].SubGroups.length; x++) {
                        if (this._Properties[i].SubGroups[x].GroupName == isSubGroup) {
                            //sub group found add item
                            foundSubGroup = true;
                            this._Properties[i].SubGroups[x].Items[this._Properties[i].SubGroups[x].Items.length] = new ClassItem(cssName, rowType, drpFields, this.cssItem, value, propertyName, this._PropertiesLookup, enabled);
                            this.cssItem++;
                        }
                    }

                    if (!foundSubGroup) {
                        //create sub group
                        this._Properties[i].SubGroups[this._Properties[i].SubGroups.length] = new Group(isSubGroup, this.subGroupCount, true);
                        this._Properties[i].SubGroups[this._Properties[i].SubGroups.length - 1].Items[this._Properties[i].SubGroups[this._Properties[i].SubGroups.length - 1].Items.length] = new ClassItem(cssName, rowType, drpFields, this.cssItem, value, propertyName, this._PropertiesLookup, enabled);
                        this.cssItem++;
                        this.subGroupCount++;
                    }
                }
                else {
                    //item within group
                    this._Properties[i].Items[this._Properties[i].Items.length] = new ClassItem(cssName, rowType, drpFields, this.cssItem, value, propertyName, this._PropertiesLookup, enabled);
                    this.cssItem++;
                }
                foundGroup = true;
            }
        }

        if (!foundGroup) {
            //create new group with item
            this._Properties[this._Properties.length] = new Group(groupName, this.groupCount, false);
            this._Properties[this._Properties.length - 1].Items[this._Properties[this._Properties.length - 1].Items.length] = new ClassItem(cssName, rowType, drpFields, this.cssItem, value, propertyName, this._PropertiesLookup, enabled);
            this.groupCount++;
            this.cssItem++;
        }
    }

    public updateStyle(cssName, newStyle) {
        //clean object up if dirty
        cssName = cssName.replace(/^\s*|\s*$/g, '');
        cssName = cssName.toLowerCase();

        var propLookup = "";
        for (var i = 0; i < this._PropertiesLookup.length; i++) {
            if (this._PropertiesLookup[i][0] == cssName) {
                propLookup = this._PropertiesLookup[i][1];
                (<any>document.getElementById(propLookup)).value = newStyle;
                //check for col or drop type
                if (this._PropertiesLookup[i][2] == "color") {
                    var colorPalette = document.getElementById("color" + this._PropertiesLookup[i][1]);
                    if (colorPalette != null) {
                        try {
                            document.getElementById("color" + this._PropertiesLookup[i][1]).style.backgroundColor = newStyle;
                        } catch (e) { }
                    }
                }
                //make section visible
                var e: any = document.getElementById(propLookup).parentNode.parentNode.parentNode;

                if (e.id.indexOf("subgroup") != -1) {
                    //item is in a subgroup sp show this and its parent 
                    e.style.display = "block";
                    var groupId = (<any>document.getElementById(propLookup).parentNode.parentNode.parentNode).id;
                    groupId = groupId.replace('child', '');
                    e.style.display = "block";
                    var subGroupId = e.id;
                    subGroupId = subGroupId.replace('child', '');
                    $("#image" + groupId).removeClass('bkExpand').addClass('bkMinimise');
                    $("#image" + subGroupId).removeClass('bkExpand');
                    $("#image" + subGroupId).removeClass('bkExpandSub').addClass('bkMinimiseSub');
                }
                else {
                    var groupId = e.id;

                    groupId = groupId.replace('child', '');
                    e.style.display = "block";
                    $("#image" + groupId).removeClass('bkExpand').addClass('bkMinimise');
                }
            }
        }
    }

    public selectStyle(cssName) {
        for (var i = 0; i < this._PropertiesLookup.length; i++) {
            if (this._PropertiesLookup[i][0] == cssName) {
                var propLookup = this._PropertiesLookup[i][1];

                return (<any>document.getElementById(propLookup)).value;
            }
        }
        return null;
    }

    public clearGrid() {
        $('#propertyGridContainer').remove();
        this._Properties.length = 0;
    }

    public renderGrid() {
        //creates the html output from Properties Object
        var htmlOut = "<div id=\"propertyGridContainer\">";
        var __this = this;

        try {
            for (var i = 0; i < this._Properties.length; i++) {
                var item: any = this._Properties[i];

                htmlOut += "<div id=\"" + item.OutputDiv + "\" class=\"pgGroup\"><div id=\"image" + item.OutputDiv + "\" class=\"pgGroupShrink \">&nbsp;</div><div class=\"pgGroupText\">" + item.GroupName + "</div></div>";
                //render group items
                htmlOut += "<div id=\"child" + item.OutputDiv + "\">";
                for (var x = 0; x < item.Items.length; x++) {
                    htmlOut += __this.RenderGridInput(item.Items[x].Type, item.Items[x].OutputDiv, item.Items[x].CssId, item.Items[x].DropFields, item.Items[x].Value, item.Items[x].PropertyName, item.Items[x].Enabled, item.Items[x].Enabled);
                }
                //check for subgroups
                if (item.SubGroups.length > 0) {
                    for (var ii = 0; ii < item.SubGroups.length; ii++) {
                        htmlOut += "<div id=\"" + item.SubGroups[ii].OutputDiv + "\" class=\"pgSubGroup\"><div id=\"image" + item.SubGroups[ii].OutputDiv + "\" class=\"pgSubGroupShrink \">&nbsp;</div><div class=\"pgSubGroupText\">" + item.SubGroups[ii].GroupName + "</div></div>";
                        //render sub group items
                        htmlOut += "<div id=\"child" + item.SubGroups[ii].OutputDiv + "\">";
                        for (var xx = 0; xx < item.SubGroups[ii].Items.length; xx++) {
                            htmlOut += __this.RenderGridInput(item.SubGroups[xx].Items[xx].Type, item.SubGroups[ii].Items[xx].OutputDiv, item.SubGroups[ii].Items[xx].CssId, item.SubGroups[ii].Items[xx].DropFields, item.Value, item.PropertyName);
                        }
                        htmlOut += "</div>";
                    }
                }
                htmlOut += "</div>";
            }
        } catch (e) { alert(e); }
        document.getElementById(this._OutputDivId).innerHTML = htmlOut + "</div>";

        var __this = this;

        $("input[id^=pg1_]").change(function (e) {
            var propertyName = $(e.currentTarget).data("propname");

            if (__this.PropertyChanged) {
                __this.PropertyChanged(propertyName, $(e.currentTarget).val());
            }
        });

        $("button[id^=pg1_]").click(function (e) {
            var propertyName = $(e.currentTarget).data("propname");

            if (__this.PropertyClicked) {
                __this.PropertyClicked(propertyName, $(e.currentTarget).val());
            }
        });

        (<any>$('.pgInputColor')).colorpicker({
            format: 'hex',
            horizontal: true,
        });

        (<any>$('.pgInputColor')).colorpicker().on('changeColor', function (ev) {
            var id = $(ev.currentTarget).attr('id');
            var colorSpan = $('#' + 'color' + id);
            var propertyName = colorSpan.data("propname");
            var color = ev.color.toHex();

            colorSpan.css('background-color', color);
            if (__this.PropertyChanged)
                __this.PropertyChanged(propertyName, color);
        });

        $("select[id^=pg1_]").change(function (e) {
            var propertyName = $(e.currentTarget).data("propname");

            if (__this.PropertyChanged) {
                __this.PropertyChanged(propertyName, $(e.currentTarget).val());
            }
        });

        $("input[class*='pgInputNum']").keydown(function (e) {
            var key = e.which || e.keyCode;

            if (!e.shiftKey && !e.altKey && !e.ctrlKey &&
                // numbers   
                key >= 48 && key <= 57 ||
                // Numeric keypad
                key >= 96 && key <= 105 ||
                // comma, period and minus, . on keypad
                key == 190 || key == 188 || key == 109 || key == 110 ||
                // Backspace and Tab and Enter
                key == 8 || key == 9 || key == 13 ||
                // Home and End
                key == 35 || key == 36 ||
                // left and right arrows
                key == 37 || key == 39 ||
                // Del and Ins
                key == 46 || key == 45)
                return true;

            return false;
        });
    }

    private splitCamelCaseToString(s) {
        return s.split(/(?=[A-Z])/).join(' ');
    }

    private RenderGridInput(type, outputDivId, cssId, fields, value, propertyName, enabled?: boolean, clickHandler?: string) {
        var displayName = this.splitCamelCaseToString(propertyName);

        switch (type) {
            case 'input':
                return "<div id=\"hold" + outputDivId + "\" class=\"pgGroupItem\"><div class=\"pgGroupItemText\">" + displayName + "</div><div class=\"pgInputHolder\"><input id=\"" + outputDivId + "\" class=\"pgInput\" data-propname='" + propertyName + "' value='" + value + "'" + this.getDisabled(enabled) + "\"></input></div></div>";
            case 'color':
                return "<div id=\"hold" + outputDivId + "\" class=\"pgGroupItem\"><div class=\"pgGroupItemText\">" + displayName + "</div><div class=\"pgInputHolder\"><input id=\"" + outputDivId + "\" class=\"pgInputColor\"" + "' value='" + value + "'></input><span data-propname='" + propertyName + "' id=\"color" + outputDivId + "\" class=\"pgBtnColor\" style='background-color:" + value + "'><i></i></span></div></div>";
            case 'dialog':
                return "<div id=\"hold" + outputDivId + "\" class=\"pgGroupItem\"><div class=\"pgGroupItemText\">" + displayName + "</div><div class=\"pgInputHolder\"><input id=\"" + outputDivId + "\" class=\"pgInputDialog\" data-propname='" + propertyName + "' value='" + value + "'" + this.getDisabled(false) + "\"></input><button id=\"" + outputDivId + "\" data-propname='" + propertyName + "' class=\"pgDialog\">&hellip;</button></div></div></div>";
           
            case 'num':
                return "<div id=\"hold" + outputDivId + "\" class=\"pgGroupItem\"><div class=\"pgGroupItemText\">" + displayName + "</div><div class=\"pgInputHolder\"><input data-propname='" + propertyName + this.getDisabled(enabled) + "' id=\"" + outputDivId + "\" class=\"pgInputNum\"" + this.getDisabled(enabled) + " value='" + value + "'\" type='number'></input></div></div>";
            case 'drop':
                return "<div id=\"hold" + outputDivId + "\" class=\"pgGroupItem\"><div class=\"pgGroupItemText\">" + displayName + "</div><div class=\"pgInputHolder\"><select id=\"" + outputDivId + "\" class=\"pgInputDrop\"><option value='none'" + this.getDisabled(enabled) + ">none</option><option value='solid'>solid</option><option value='ridge'>ridge</option><option value='dashed'>dashed</option><option value='dotted'>dotted</option><option value='double'>double</option><option value='groove'>groove</option><option value='inset'>inset</option></select></div></div>";
            case 'cdrop':
                //custom drop
                var dropHtml = "<div id=\"hold" + outputDivId + "\" class=\"pgGroupItem\"><div class=\"pgGroupItemText\">" + displayName + "</div><div class=\"pgInputHolder\"><select id=\"" + outputDivId + "\" class=\"pgInputDrop\" data-propname='" + propertyName + "'" + this.getDisabled(enabled) + ">";
                var items = fields.split('|');

                for (var i = 0; i < items.length; i++) {
                    if (angular.isDefined(value) && items[i].toString() === value.toString())
                        dropHtml += "<option value=\"" + items[i] + "\" selected>" + items[i] + "</option>";
                    else
                        dropHtml += "<option value=\"" + items[i] + "\">" + items[i] + "</option>";
                }
                dropHtml += "</select></div></div>";
                return dropHtml;
            default:
                return "<div id=\"hold" + outputDivId + "\" class=\"pgGroupItem\"><div class=\"pgGroupItemText\">" + displayName + "</div><div class=\"pgInputHolder\"><input id=\"" + outputDivId + "\" class=\"pgInput\"" + this.getDisabled(enabled) + "></input></div></div>";
        }
    }

   public getDisabled(enabled:boolean){
        if (enabled)
            return "";
        return " disabled ";
    }

    public clearValues() {
        for (var i = 0; i < this._PropertiesLookup.length; i++) {
            var propLookup = this._PropertiesLookup[i][1];
            var item: any = document.getElementById(propLookup);

            item.Value = '';
        }
    }

    public emptyGrid() {
        this._Properties = new Array();
        this._PropertiesLookup = new Array();
        this.groupCount = 0;
        this.subGroupCount = 0;
        this.cssItem = 0;
    }

    public hideItems() {
        //hide groups and sub groups
        $("div[id*=childpg1_group_]").css('display', 'none');
        $("div[id*=childpg1_subgroup_]").css('display', 'none');
        $("div[id*=imagepg1_group_]").removeClass('bkMinimise').addClass('bkExpand');
        $("div[id*=imagepg1_subgroup_]").removeClass('bkMinimiseSub').addClass('bkExpandSub');
    }

    public expand(id, sub) {
        if (document.getElementById('child' + id).style.display == "" || document.getElementById('child' + id).style.display == "block") {
            //MAKE SMALL
            document.getElementById('child' + id).style.display = "none";
            if (sub == 'true') {
                $("#image" + id).removeClass('bkMinimiseSub').addClass('bkExpandSub');
            }
            else {
                $("#image" + id).removeClass('bkMinimise').addClass('bkExpand');
            }
        }
        else {
            //SHOW
            document.getElementById('child' + id).style.display = "block";
            if (sub == 'true') {
                $("#image" + id).removeClass('bkExpandSub').addClass('bkMinimiseSub');
            }
            else {
                $("#image" + id).removeClass('bkExpand').addClass('bkMinimise');
            }
        }
    }

    private AttachColorPicker(propertyName, outputDivId: string) {
        var div: any = $("#color" + outputDivId);
        var __this = this;

        div.colorpicker({
            onSubmit: function (hsb, hex, rgb, el) {
                var divE: any = $(el);

                divE.css("backgroundColor", "#" + hex);
                divE.ColorPickerHide();

                if (__this.PropertyChanged)
                    __this.PropertyChanged(propertyName, "#" + hex);
            },
            onChange: function (hsb, hex, rgb) {
                div.css('backgroundColor', '#' + hex);
                $("input[id='" + outputDivId + "']").val('#' + hex);
            },
            onBeforeShow: function () {
                var color = $("input[id='" + outputDivId + "']").val();
                var thisE: any = $(this);

                thisE.ColorPickerSetColor($("input[id='" + outputDivId + "']").val());
            }
        });
    }

    public retrieveCSSName() {
        return this._PropertiesLookup;
    }
};