// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

class Button {
    type: string;
    title: string;
    name: string;
    action: string;
    icon: string;
    tooltip: string;
    items: Array<Button>;

    constructor() {
        this.type = '';
        this.title = '';
        this.name = '';
        this.action = '';
        this.icon = '';
        this.tooltip = '';
        this.items = new Array<Button>();
    }
}

directives.directive('toolbar', ['toolbarService', function (toolbarService:ToolbarService) {
return {
        restrict: "E",
        scope: {
            buttons: '=',
            name:'=',
        },
        replace: true,
        link: function (scope, element, attrs, form) {            
            scope.$watch('buttons', function (newValue) {
                var parent = $(element).parent();

                toolbarService.buildToolbar(scope, newValue, parent, attrs.key);               
            });    
        }
    }
}]);