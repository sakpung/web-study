// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../Scripts/models/Tab.ts" />

module TabDataKeys {       
    export var Linked: string = "Linked";
    export var TagToggle: string = "TagToggle";      
    export var ViewController: string = "ViewController";
    export var PatientId: string = "PatientId"; 
    export var CompareInstances: string = "CompareInstances";   
    export var AnnotationVisiblity: string = "AnnotationVisiblity";
    export var LaunchingStudy: string = "LaunchingStudy";
    export var searchViewerController : string = "SearchViewerController";
};

class TabService {
    private _tabs: Array<Models.Tab>;
    private _activeTab: number = -1;    
    private _tabDictionary: Dictionary;

    public get activeTab(): number {
        return this._activeTab;
    }

    public get tabs(): Array<Models.Tab> {
        return this._tabs;
    }

    public set activeTab(index: number) {
        var tab: Models.Tab = this._tabs[index];

        if (tab != null) {
            tab.active = true;
            this._activeTab = index;
        }
    }

    public get selectedTab(): Models.Tab {
        if (this.activeTab != -1) {
            return this.get_allTabs()[this._activeTab];
        }
    }

    constructor() {
        this._tabs = new Array<Models.Tab>();
        this._activeTab = 0;        
        this._tabDictionary = new Dictionary();
    }

    public add_tab(id: string, title: string, template: string, controller, type?: number): Models.Tab {
        var tab: Models.Tab = new Models.Tab(id);
        var tabType = type || TabTypes.None;

        tab.title = title;
        tab.templateUrl = template;
        tab.controller = controller;
        tab.type = tabType;
        tab.itemCount = 0;
        tab.showStudyTimeLine = false;
        this._tabDictionary.setData(tab.id, new Dictionary());        
        this._tabs.push(tab);
        this.set_tabData(id, TabDataKeys.TagToggle, true);        

        return tab;
    }

    public find_tab(id: string) {
        var foundTab: Models.Tab;

        $.each(this._tabs, function (index, tab) {
            if (tab.id == id) {
                foundTab = tab;
                return false;
            }
        });
        return foundTab;
    }

    public select_tab(id: string) {
        var tab: Models.Tab = this.find_tab(id);

        if (tab != null) {
            tab.active = true;
            this._activeTab = this._tabs.indexOf(tab);
        }
    }

    public get_allTabs(): Array<Models.Tab> {
        return this._tabs;
    }

    public delete_tab(id: string) {
        var tab: Models.Tab = this.find_tab(id);

        if (tab != null) {
            var index = this._tabs.indexOf(tab);

            this._tabs.splice(index, 1);
            this._tabDictionary.removeData(id);
        }
    }

    public find_tabsByType(type: number): Array<Models.Tab> {
        var tabs: Array<Models.Tab> = new Array<Models.Tab>();

        $.each(this._tabs, function (index, tab: Models.Tab) {
            if (tab.type == type) {
                tabs.push(tab);
            }
        });

        return tabs;
    }    

    public set_tabData(id: string, key: string, data: any) {
        var tab: Models.Tab = this.find_tab(id);

        if (tab != null) {
            var tabData: Dictionary = this._tabDictionary.getData(id);

            if (tabData)
                tabData.setData(key, data);
        }
    }

    public get_tabData(id: string, key: string) {
        var tab: Models.Tab = this.find_tab(id);

        if (tab != null) {
            var tabData: Dictionary = this._tabDictionary.getData(id);

            if (tabData)
                return tabData.getData(key);
        }
        return undefined;
    }

    public findTabByKey(key: string, value: any) {
        var keyTab: Models.Tab = null;
        var __this = this;

        $.each(this._tabs, function (index, tab: Models.Tab) {
            var tabData: Dictionary = __this._tabDictionary.getData(tab.id);

            if (tabData) {
                if (tabData.getData(key) == value) {
                    keyTab = tab;
                    return false;
                }
            }
        });
        return keyTab;
    }

    public getActiveViewer() {
        if (this.activeTab != -1) {
            var tab: Models.Tab = this.get_allTabs()[this.activeTab];
            var controller = this.get_tabData(tab.id, TabDataKeys.ViewController);

            if (controller) {
                return controller.getViewer();
            }
        }
        return undefined;
    }

    public getWindowLayout() {
        if (this.activeTab != -1) {
            var tab: Models.Tab = this.get_allTabs()[this.activeTab];
            var controller = this.get_tabData(tab.id, TabDataKeys.ViewController);

            
            if (controller) {
                var viewer: lt.Controls.Medical.MedicalViewer = controller.getViewer();
                var viewerElement = document.getElementById(viewer.divId);
                if (viewerElement.parentElement != null) {
                    if (viewerElement.parentElement.parentElement != null) {
                        return viewerElement.parentElement.parentElement.parentElement;
                    }
                }
            }
            else
                return undefined;
        }
        return undefined;
    }
}

services.service('tabService', TabService);