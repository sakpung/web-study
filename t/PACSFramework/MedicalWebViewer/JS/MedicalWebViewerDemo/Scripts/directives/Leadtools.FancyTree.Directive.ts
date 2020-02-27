// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

directives.directive('ltFancyTree', ['$rootScope', function ($root) {
    return {
        restrict: 'A',        
        scope: {
            config: '=', 
            data: '=',
            disabledItems: '=',
            select: '&',
            activate: '&',
            deactivate: '&',
            api: '=',           
        },
        link: function (scope, element, attrs, $rootScope) {                                                

            scope.$watch('config', function (value) {     
                $(element).parent().height($root.windowDimensions.height * .25); 

                value.select = function (event, data) {
                    scope.select({ event: event, data: data });
                }

                value.activate = function (event, data) {
                    scope.activate({ event: event, data: data });
                }

                value.deactivate = function (event, data) {
                    scope.deactivate({ event: event, data: data });
                }
                                                                                                
                element.fancytree(value);                                 
            }); 

            scope.api = scope.api || {};            
            scope.api.addNode = function (parentNode, item) {
                if (parentNode == null) {
                    parentNode = element.fancytree("getRootNode");
                }
                return parentNode.addChildren({
                    title: item.id,
                    tooltip: item.tooltip,
                    data: item,
                    folder: item.items && item.items.length > 0
                });
            }

            scope.api.visit = function (visitFunction) {
                element.fancytree('getTree').visit(visitFunction);
            }

            scope.api.activateNode = function (node) {
                if (node != null) {
                    node.setActive();
                    node.setFocus(true);
                    node.scrollIntoView();
                }
            }

            scope.api.clear = function () {
                var rootnode = element.fancytree("getRootNode");

                rootnode.removeChildren();
            } 
            
            scope.api.addData = function (parent, item) {
                var childNode;

                if (parent == null) {
                    parent = element.fancytree("getRootNode");
                }
                childNode = parent.addChildren({
                    title: item.id,
                    tooltip: item.tooltip,
                    data: item,
                    folder: item.items && item.items.length > 0,
                    selected: scope.disabledItems.indexOf(item.id) == -1,
                });

                angular.forEach(item.items, function (child, key) {
                    scope.api.addData(childNode, child);
                });
            } 

            scope.api.setDisabledItems = function (disabledItems) {
                element.fancytree('getTree').visit(function (node) {
                    var item = node.data;

                    node.setSelected(disabledItems.indexOf(item.id) == -1);
                });
            }  
            
            scope.api.clearActive = function () {
                element.fancytree('getTree').visit(function (node) {
                    var item = node.data;

                    node.setActive(false);
                });
            }                                

            scope.$watch('data', function (value) {
                if (value) {
                    var rootNode = element.fancytree("getRootNode");

                    for(var i = 0; i < value.length;i++){
                        scope.api.addData(rootNode, value[i]);
                    }; 
                    scope.api.clearActive();                   
                }
            }); 

            scope.$watch(function () {
                return $root.windowDimensions.height;
            }, function (newValue, oldValue) {
                if (newValue != oldValue) {
                    $(element).parent().height(newValue * .25);
                }
            });                                                        
        }
    }
}]); 