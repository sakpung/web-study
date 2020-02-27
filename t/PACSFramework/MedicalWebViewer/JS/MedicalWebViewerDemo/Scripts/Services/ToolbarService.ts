// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
class ToolbarService {
    static $inject = ['optionsService', '$commangular', 'hotkeys', 'eventService'];
    static isNativeMobile: boolean = false;

    private _optionsService: OptionsService;
    private _commangular: any;
    private _toolbars: Array<Models.Toolbar>;
    private _disabledToolbarItems: Array<string>;
    private _oldCSS: any;
    private _hotkeys: any;
    private _eventService: EventService;
    private _dentalMode: boolean;


    private filterToolbar(item) {

    if (ToolbarService.isNativeMobile && (item.id === "PopupCapture" || item.id === "WaveformBasicAudio"))
        return false;

    if (this._dentalMode) {
        if (item.id === "LayoutCompose")
            return false;
        if (item.id === "HangingProtocol")
            return false;
        if (item.id === "SaveStructuredDisplay")
            return false;
        if (item.id === "DeleteStudyStructuredDisplay")
            return false;
        if (item.id === "StudyLayout")
            return false;
        return true;
    }
    else
        return true;
}



    constructor(optionsService: OptionsService, $commangular,hotkeys,eventService:EventService) {
        this._optionsService = optionsService;
        this._disabledToolbarItems = new Array<string>();
        this._commangular = $commangular;
        this._oldCSS = {};
        this._hotkeys = hotkeys;
        this._eventService = eventService;
    }

    load(): Array<Models.Toolbar> {
        return null;
    }

    getToolbars(): Array<Models.Toolbar> {
        if (this._toolbars == null) {
            var names: Array<string> = JSON.parse(this._optionsService.get(OptionNames.Toolbars));

            if (names.length == 0) {
                names = new Array<string>();
                names.push('main');
            }

            this._toolbars = new Array<Models.Toolbar>();
            for (var i = 0; i < names.length; i++) {
                var name: string = "Toolbar_" + names[i];

                this._dentalMode = this._optionsService.get(OptionNames.DentalMode);


                var toolbarString: string = this._optionsService.get(name).replace(/(\r\n|\n|\r|\t)/gm, "");
                var toolbar: Models.Toolbar = JSON.parse(toolbarString.trim());

                //disabled items
                toolbar.items = toolbar.items.filter(this.filterToolbar);

                this._toolbars.push(toolbar);
            }            
        }

        return this._toolbars;
    }

    getDisabledItems(name: string): Array<string> {
        try {
            var items: Array<string> = JSON.parse(this._optionsService.get("DisabledToolbarItems_" + name));
        }
        catch (e) {
            items = new Array<string>();
        }

        return items;
    }

    public isEnabled(name) {
        var item = $("#" + name);

        if (item.length > 0 && jQuery.hasData(item[0])) {
            return !jQuery.data(item[0], "isDisabled")();
        }
        return false;
    }

    public switchIcon(oldIcon, newIcon) {
        this.switchItem(oldIcon, newIcon);
    }

    public enable(name, check?: Function) {
        var enable = true;

        if (check != undefined && this.isFunction(check))
            enable = check();

        if (name instanceof Array) {
            for (var i = 0; i < name.length; i++) {
                if (enable)
                    this.enableItem(name[i]);
                else
                    this.disableItem(name[i]);
            }
        }
        else {
            if (enable)
                this.enableItem(name);
            else
                this.disableItem(name);
        }
    }



    public hilightBorder(name, width, color) {
        var item = $();

        if (name instanceof Array) {
            for (var i = 0; i < name.length; i++) {
                item = $("#" + name[i]);

                this.hilightItem(<any>name, item, width, color);
            }
        }
        else {
            item = $("#" + name);

            this.hilightItem(name, item, width, color);
        }
    }

    public unhilightBorder(name) {
        var item = $();

        if (name instanceof Array) {
            for (var i = 0; i < name.length; i++) {
                item = $("#" + name[i]);

                this.unhilightItem(<any>name, item);
            }
        }
        else {
            item = $("#" + name);

            this.unhilightItem(name, item);
        }
    }

    public press(id: string) {
        var iconId: string = "#" + id + "_icon";  
        var originalId = $(iconId).attr('original-id');      

        $(iconId).removeClass(originalId);
        $(iconId).addClass(originalId+"Pressed");
    }

    public unpress(id: string) {
        var iconId: string = "#" + id + "_icon";
        var originalId = $(iconId).attr('original-id');

        $(iconId).removeClass(originalId+"Pressed");
        $(iconId).addClass(originalId);
    }

    public updateClass(id: string, trueClass, falseClass, check: Function) {
        var classBool:boolean = check();
        var iconId: string = "#" + id + "_icon";

        if (classBool) {
            $(iconId).removeClass(falseClass); 
            $(iconId).addClass(trueClass);
        }
        else {            
            $(iconId).removeClass(trueClass);           
            $(iconId).addClass(falseClass);
        }
    }

    private hilightItem(name: string, item: JQuery, width, color) {
        this.saveCss(name, item);
        item.css("border", width);
        item.css("border-style", "solid");
        item.css("border-color", color);
    }

    private saveCss(name, item: JQuery) {
        if (typeof this._oldCSS[name] == 'undefined')
            this._oldCSS[name] = {};

        this._oldCSS[name].border = item.css("border");
        this._oldCSS[name].borderStyle = item.css("border-style");
        this._oldCSS[name].borderColor = item.css("border-color");
    }

    private unhilightItem(name: string, item: JQuery) {
        if (typeof this._oldCSS[name] != 'undefined') {
            item.css("border", this._oldCSS[name].border);
            item.css("border-style", this._oldCSS[name].borderStyle);
            item.css("border-color", this._oldCSS[name].borderColor);
        }
    }

    public disable(name) {
        if (name instanceof Array) {
            for (var i = 0; i < name.length; i++) {
                this.disableItem(name[i]);
            }
        }
        else {
            this.disableItem(name);
        }
    }

    public hide(name) {
        if (name instanceof Array) {
            for (var i = 0; i < name.length; i++) {
                var item = $("#" + name[i]);

                item.hide();
            }
        }
        else {
            var item = $("#" + name);

            item.hide();
        }
    }

    public show(name) {
        if (name instanceof Array) {
            for (var i = 0; i < name.length; i++) {
                var item = $("#" + name[i]);

                item.show();
            }
        }
        else {
            var item = $("#" + name);

            item.show();
        }
    }

    private disableItem(name: string) {
        var item = $("#" + name);

        if (item.length > 0 && jQuery.hasData(item[0])) {
            if (!jQuery.data(item[0], "isDisabled")()) {
                jQuery.data(item[0], "disable")();
            }
        }
    }

    private isFunction(object) {
        return typeof (object) === 'function';
    }       

    private enableItem(name: string) {
        var item = $("#" + name);

        if (item.length > 0 && jQuery.hasData(item[0])) {
            if (jQuery.data(item[0], "isDisabled")()) {
                jQuery.data(item[0], "enable")();
            }
        }
    }

    private switchItem(name: string, newName: string) {
        var item = $("#" + name);

        if (item.length > 0 && jQuery.hasData(item[0])) {
            if (jQuery.data(item[0], "isDisabled")()) {
                jQuery.data(item[0], "enable")();
            }
        }
    }
                                                                     

    private loadDefault(toolbars: Array<Models.Toolbar>) {
        var toolbar = new Models.Toolbar();

        toolbar.name = "Main";
        toolbars.push(toolbar);

        this.addToolbarButton(toolbar, "PanZoom", "", "toolBarItem Pan");
        this.addToolbarButton(toolbar, "Zoom", "", "toolBarItem Zoom");
        this.addToolbarButton(toolbar, "Magnify", "", "toolBarItem Magnify");
        this.addToolbarButton(toolbar, "WindowLevel", "", "toolBarItem WindowLevel");
        //
        // Window Level goes here
        //
        this.addToolbarButton(toolbar, "Stack", "", "toolBarItem Stack");
        this.addToolbarButton(toolbar, "Reload", "", "toolBarItem Reload");
        this.addToolbarButton(toolbar, "RotateClock", "", "toolBarItem RotateClock");
        this.addToolbarButton(toolbar, "RotateCounterClock", "", "toolBarItem RotateCounterClock");
        this.addToolbarButton(toolbar, "Flip", "", "toolBarItem Flip");
        this.addToolbarButton(toolbar, "Reverse", "", "toolBarItem Reverse");
        this.addToolbarButton(toolbar, "FitImage", "", "toolBarItem FitImage");
        this.addToolbarButton(toolbar, "OneToOne", "", "toolBarItem OneToOne");
        this.addToolbarButton(toolbar, "TrueSizeDisplay", "", "toolBarItem TrueSizeDisplay");
    }

    private addToolbarButton(toolbar: Models.Toolbar, action: string, title: string, cssClass?: string) {
        var item = new Models.ToolbarButton();

        item.action = action;
        item.tooltip = title;
        item.cssIconClass = cssClass || "";
        toolbar.items.push(item);
    }

    private processItem(button: Models.ToolbarItem, parent, buttonKey) {
        var __this = this;

        if ($.inArray(button.id, this._disabledToolbarItems) == -1) {
            if (button.items && button.items.length > 0) {
                if (button.type == "group") {
                    var group = $('<div class="btn-group" style="float: none !important"></div>');

                    $(parent).append(group);
                    parent = group;
                }
                else {
                    parent = __this.addDropDown(parent, button,buttonKey);
                }

                var firstInMenu = true;
                var noItemDivider = false;
                angular.forEach(button.items, function (value, key) {
                    if ($.inArray(value.id, __this._disabledToolbarItems) == -1) {

                        if (value.type != 'seperator') {
                            if (firstInMenu) {
                                parent.append('<li class="menuBar"></li>');
                                firstInMenu = false;
                            }
                            else {
                                if (!noItemDivider) {
                                    parent.append('<li class="itemDivider"></li>');
                                }
                                noItemDivider = false;
                            } 

                            __this.addOption(parent, value, buttonKey);
                        }
                        else {
                            __this.addOption(parent, value, buttonKey);
                            noItemDivider = true;
                        }
                    }
                });
            }
            else {
                if (button.type == "button") {
                    __this.addButton(parent, button, buttonKey);
                }
                else if (button.type == "seperator") {
                    __this.addSeperator(parent, button, buttonKey);
                }
            }
        }
    }

    private addShortcut(button: Models.ToolbarItem) {
        var __this = this;

        if (button.shortcut && button.shortcut.length) {
            this._hotkeys.add({
                combo: button.shortcut,
                description: button.tooltip,
                callback: function () {
                    __this.runCommand(button.action, button.id);
                }
            });
        }
    }

    private addButton(parent, button: Models.ToolbarItem, buttonKey:string) {
        //var navbutton: any = $('<button class="btn btn-default toolbar-button" style="margin:0px; padding:0px">' + '' + '</button>');
        var navbutton: any = $('<button onfocus="blur();" class="btn btn-default toolbar-button">' + '' + '</button>');
        navbutton.tabStop = false;
        var id = button.id + buttonKey;

        navbutton.attr('id', id);
        navbutton.attr('type', 'button');
        navbutton.attr('data-toggle', 'button');        

        if (button.tooltip && button.tooltip.length > 0) {
            navbutton.attr('title', button.tooltip);
            navbutton.attr('data-container', 'body');
        }

        if (button.cssIconClass) {
            var icon = $("<div class='toolBarItem " + button.cssIconClass + "'> </div>");

            icon.attr('id', id + "_icon");
            icon.attr('original-id', button.id);
            navbutton.append(icon);
        }

        if (button.cssIconClass) {
            var icon = $("<i class='toolBarItemText'>" + button.caption + "</i>");
            navbutton.append(icon);
        }


        $.data(navbutton[0], "enable", function () {
            var menuIcon = "#" + id + "_icon";

            navbutton.removeAttr('disabled');
            navbutton.removeClass('btn-disabled');
            $(menuIcon).removeClass("Disabled" + button.cssIconClass);
            $(menuIcon).addClass(button.cssIconClass);
        });

        $.data(navbutton[0], "disable", function () {
            var menuIcon = "#" + id + "_icon";

            navbutton.attr('disabled', 'disabled');
            navbutton.addClass('btn-disabled');
            $(menuIcon).removeClass(button.cssIconClass);
            $(menuIcon).addClass("Disabled" + button.cssIconClass);
        });

        $.data(navbutton[0], "isDisabled", function () {
            return (navbutton.attr('disabled') != undefined);
        });

        var __this = this;

        this.addShortcut(button);

        if (button.action != null) {
            navbutton.on("click", function (e) {
                __this.runCommand(button.action, id);
            });
        }

        $(parent).append(navbutton);

        if (angular.isDefined(button['visible']) && Utils.toBoolean(button.visible,true) == false) {
            this.hide(id);
        }

        if (angular.isDefined(button['disabled']) && Utils.toBoolean(button.disabled, false) == true) {
            this.disable(id);
        }
    }

    private addSeperator(parent, button: Models.ToolbarItem, buttonKey: string) {
        var span: any = $('<span style="width:3px"></span>');

        $(parent).append(span);
    }

    private addDropDown(parent, button: Models.ToolbarItem, buttonKey:string) {
        var group = $('<div class="btn-group " style="float: none !important"></div>');
        var ul = $('<ul class="dropdown-menu"></ul>');
        var dropDown: JQuery = $('<button class="btn btn-default dropdown-toggle toolbar-button" data-toggle="dropdown"></button>');
        var btn: JQuery = $('<button onfocus="blur();" class="btn btn-default toolbar-button">' + '' + '</button>');
        var dropDownIcon;
        var __this = this;
        var id = button.id + buttonKey;

        if (button.cssIconClass) {
            dropDownIcon = $("<i class='toolBarItem " + button.cssIconClass + "'> </i>");

            btn.append(dropDownIcon);
        }

        var iconText;
        if (button.cssIconClass) {
            iconText = $("<i class='toolBarItemText'>" + button.caption + "</i>");
            btn.append(iconText);
        }

        btn.attr('id', id + "_dropdown");
        btn.attr('type', "button");
        btn.data('action', button.action);
        btn.attr('title', button.tooltip);
        btn.attr('data-container', 'body');
        btn.attr('original-id', button.id);
        
        btn.on("click", function () {
            var currentAction = btn.data('action');

            if (currentAction && currentAction.length > 0) {
                __this.runCommand(<any>currentAction,id);
            }
        });

        dropDown.attr('id', id);

        $.data(dropDown[0], "enable", function () {
            btn.removeAttr('disabled');
            dropDown.removeAttr('disabled');
        });

        $.data(dropDown[0], "disable", function () {
            dropDown.attr('disabled', 'disabled');
            btn.attr('disabled', 'disabled');
        });

        $.data(dropDown[0], "isDisabled", function () {
            return (dropDown.attr('disabled') != undefined);
        });

        $.data(ul[0], "dropdown", id + "_dropdown");
        $.data(ul[0], "dropDownIcon", dropDownIcon);
        $.data(ul[0], "iconName", button.cssIconClass);
        $.data(ul[0], "iconText", iconText);
        

        group.append(btn)
        dropDown.append('<span class="caret"></span>');
        group.append(dropDown);
        group.append(ul);
        parent.append(group);

        return ul;
    }

    private addOption(parent, button: Models.ToolbarItem, buttonKey:string) {
        if (button.type == 'seperator') {
            parent.append('<li class="divider"></li>');
        }
        else {
            var id = button.id + buttonKey;
            var li = $('<li></li>');
            var anchor = $('<a href="javascript:void(0)" target="_self">' + '' + '</a>');

            if (button.cssIconClass) {
                var menuIcon = $("<i class='toolBarItemOption " + button.cssIconClass + "' style='height: 30px; width: 30px;'></i>" + "<i class='menuItemText' >" + button.tooltip + "</i>");
                menuIcon.attr("id", id + "_icon");
                menuIcon.attr('original-id', button.id);
                anchor.append(menuIcon);
            }

            anchor.attr('id', id);
            anchor.attr('type', 'button');            
            if (button.tooltip && button.tooltip.length > 0) {
                anchor.attr('title', button.tooltip);
                anchor.attr('data-container', 'body');                
            }

            $.data(anchor[0], "enable", function () {
                var menuIcon = "#" + id + "_icon";                

                anchor.removeAttr('disabled');                 
                $(menuIcon).removeClass("Disabled" + button.cssIconClass);
                $(menuIcon).addClass(button.cssIconClass);

                if ($.hasData(parent[0])) {
                    var iconName = $.data(parent[0], "iconName");

                    if (iconName == ("Disabled" + button.cssIconClass)) {
                        var dropDown = $("#" + $.data(parent[0], "dropdown"));
                        var iconName = $.data(parent[0], "iconName");
                        var currentIcon = $.data(parent[0], "dropDownIcon");

                        __this.setIcon(button.cssIconClass, iconName, currentIcon, parent);
                        if (dropDown.length > 0) {
                            dropDown.removeAttr('disabled');
                        }
                    }
                }
            });


            $.data(anchor[0], "switch", function () {
                var menuIcon = "#" + id + "_icon";

                anchor.attr('disabled', 'disabled');
                $(menuIcon).removeClass(button.cssIconClass);
                $(menuIcon).addClass("Disabled" + button.cssIconClass);

                if ($.hasData(parent[0])) {
                    var iconName = $.data(parent[0], "iconName");

                    if (iconName == button.cssIconClass) {
                        var dropDown = $("#" + $.data(parent[0], "dropdown"));
                        var iconName = $.data(parent[0], "iconName");
                        var currentIcon = $.data(parent[0], "dropDownIcon");

                        __this.setIcon("Disabled" + button.cssIconClass, iconName, currentIcon, parent);
                        if (dropDown.length > 0) {
                            dropDown.attr('disabled', 'disabled');
                        }
                    }
                }
            });

            $.data(anchor[0], "disable", function () {
                var menuIcon = "#" + id + "_icon";                

                anchor.attr('disabled', 'disabled');               
                $(menuIcon).removeClass(button.cssIconClass);
                $(menuIcon).addClass("Disabled" + button.cssIconClass);

                if ($.hasData(parent[0])) {
                    var iconName = $.data(parent[0], "iconName");

                    if (iconName == button.cssIconClass) {
                        var dropDown = $("#" + $.data(parent[0], "dropdown"));
                        var iconName = $.data(parent[0], "iconName");                                                
                        var currentIcon = $.data(parent[0], "dropDownIcon");

                        __this.setIcon("Disabled" + button.cssIconClass, iconName, currentIcon, parent);
                        if (dropDown.length > 0) {
                            dropDown.attr('disabled', 'disabled');
                        }
                    }
                }
            });

            $.data(anchor[0], "isDisabled", function () {
                return (anchor.attr('disabled') != undefined);
            });

            li.append(anchor);
            parent.append(li);

            var __this = this;

            if (button.action != null) {
                anchor.on("click", function () {
                    var name = $(this).attr('id');

                    if ($.hasData(parent[0])) {
                        var dropDown = $("#" + $.data(parent[0], "dropdown"));

                        if (dropDown.length > 0) {
                            var currentIcon = $.data(parent[0], "dropDownIcon");
                            var iconText = $.data(parent[0], "iconText");
                            

                            if (currentIcon && currentIcon.length > 0) {
                                var iconName = $.data(parent[0], "iconName");
                                var enabled = __this.isEnabled(button.id + buttonKey);
                                var newIconName: string = enabled ? button.cssIconClass : "Disabled" + button.cssIconClass;
                                iconText[0].innerText = button.caption;

                                __this.setIcon(newIconName, iconName, currentIcon, parent);

                                //dropDown.children[1].outerText = newCaption;
                                if (!enabled) {
                                    dropDown.attr('disabled', 'disabled');   
                                }
                                else {
                                    dropDown.removeAttr('disabled');
                                }
                                dropDown.data('action', button.action);
                                dropDown.attr('title', button.tooltip);
                            }                            
                        }
                    }
                    __this.runCommand(button.action,id);
                });
            }
        }
    }

    private setIcon(newIcon: string, icon:string, currentIcon: any, parent: any) { 
        if (icon && icon.length > 0)
            currentIcon.removeClass(icon);
        currentIcon.addClass(newIcon);
        $.data(parent[0], "iconName", newIcon);       
    }

    private runCommand(command: string,buttonId:string) {
        var btnCommand = commangularProvider.findCommand(command);

        if (btnCommand && btnCommand.descriptors && btnCommand.descriptors.length >= 1) {
            if (btnCommand.descriptors[0].command != undefined) {
                this._commangular.dispatch(command, { buttonId: buttonId });
            }
        }
    }

    buildToolbar(scope, buttons: Array<Models.ToolbarItem>, parent, buttonKey?:string) {
        var __this = this;

        buttonKey = buttonKey || '';
        this._disabledToolbarItems = this.getDisabledItems(scope.name);
        angular.forEach(buttons, function (value, key) {
            __this.processItem(value, parent, buttonKey);
        });
        this._eventService.publish(EventNames.ToolbarCreated, buttonKey);
        
    }

    public getCommands(): Array<string> {
        var commands: Array<string> = new Array<string>();

        this.traverse(this.getToolbars()[0].items, commands);
        return commands;
    }

    private traverse(buttons: Array<Models.ToolbarItem>, commands: Array<string>) {
        var __this = this;

        angular.forEach(buttons, function (value: Models.ToolbarItem, key) {
            if (value.action) {
                commands.push(value.action);
            }

            if (value.items && value.items.length > 0) {
                __this.traverse(value.items, commands);
            }
        });
    }
}

services.service('toolbarService', ToolbarService);