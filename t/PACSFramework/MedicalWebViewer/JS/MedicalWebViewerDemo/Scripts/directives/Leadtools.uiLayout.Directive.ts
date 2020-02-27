// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

class LayoutOptions implements JQueryLayoutOptions {
    north: any;
    east: any;
    south: any;
    west: any;  
    applyDefaultStyles: boolean; 
    default: any; 
}

directives.directive('layout', ["eventService","$compile","$timeout", function (eventService: EventService,$compile,$timeout): ng.IDirective {
        return {
            restrict: 'A', 
            scope: {               
                layoutConfig: "=",                
                hideNorth: "=",
                hideSouth: "=",
                hideEast: "=",
                hideWest: "=",
                eastWest: "=", // auto hide east/west depending on which pane has children
                api: "="
            },           
            link: function (scope : any, elem, attr: any) {
            var previousState = {};
            var setState = true;
                            
            scope.$watch('layoutConfig', function (value) {
                var onOpen = value.onopen;
                var onClose = value.onclose;
                var onHide = value.onhide;
                var onShow = value.onshow;

                if (!value.onresize)
                    value.onresize = onresize;                                               

                value.onopen = function (pane: string, item, state) {
                    if (setState) {
                        previousState[pane] = false;
                    }
                    else
                        setState = true;
                    if (onOpen)
                        onOpen(pane);
                }

                value.onclose = function (pane: string, item, state) {
                    if (setState) {
                        previousState[pane] = true;
                    }
                    else
                        setState = true;
                    if (onClose)
                        onClose();
                }

                value.onhide = function (pane: string, item, state) {
                    if (setState) {
                        previousState[pane] = true;
                    }
                    else
                        setState = true;
                    if (onHide)
                        onHide();
                }

                value.onshow = function (pane: string, item, state) {
                    if (setState) {
                        previousState[pane] = false;
                    }
                    else
                        setState = true;
                    if (onShow)
                        onShow();
                }
                
                $(elem).layout(value);                
                $(window).resize(function () {
                    resizeLayout();
                    $timeout(function () {
                        resizeLayout();
                    }, 250);
                });

                scope.api = scope.api || {};
                scope.api.get_state = function(pane:string) {
                    switch (pane.toLowerCase()) {
                        case "north":
                            return $(elem).layout().state.north;                            
                        case "south":
                            return $(elem).layout().state.south;
                        case "east":
                            return $(elem).layout().state.east;
                        case "west":
                            return $(elem).layout().state.west;
                    }
                    return undefined;
                }
                
                scope.api.has_children = function (pane: string) {
                    var layout:JQueryLayout = $(elem).layout();

                    switch (pane.toLowerCase()) {
                        case "north":
                            return $(layout.panes.north[0].childNodes).length > 0;
                        case "south":
                            return $(layout.panes.south[0].childNodes).length > 0;
                        case "east":
                            return $(layout.panes.east[0].childNodes).length > 0;
                        case "west":
                            return $(layout.panes.west[0].childNodes).length > 0;
                    }
                    return undefined;
                }
                
                scope.api.switchPanes = function (pane1: string, pane2: string, buttonid: string,height?:boolean) {
                    var layout = $(elem).layout();
                    var state = layout.state;
                    var openPane: string = null;
                    var closePane: string = null;
                    var button = $("#" + buttonid);
                    var span = button.find('span:first-child');
                    var destination;
                    var source;   
                    var size: number;                     

                    //
                    // get source size and resize destination
                    //
                    if (!state[pane1].isHidden) {
                        openPane = pane2;
                        closePane = pane1;
                        size = height ? state[pane1].layoutHeight : state[pane1].layoutWidth;
                        destination = layout.panes[pane2];
                        source = $(layout.panes[pane1][0].childNodes);

                        span.removeClass("fa fa-angle-right");
                        span.addClass("fa fa-angle-left");
                    }
                    else {
                        openPane = pane1;
                        closePane = pane2;
                        size = height ? state[pane2].layoutHeight : state[pane2].layoutWidth;
                        destination = layout.panes[pane1];
                        source = $(layout.panes[pane2][0].childNodes);

                        span.removeClass("fa fa-angle-left");
                        span.addClass("fa fa-angle-right");
                    }

                    if (openPane != null) {
                        layout.hide(closePane);
                        source.appendTo(destination);
                        layout.sizePane(openPane, size);
                        layout.open(openPane)                                                                        
                        resizeLayout();
                    }
        
                } 

                scope.api.togglePane = function (pane1: string, pane2: string) {
                    var layout:JQueryLayout = $(elem).layout();
                    var state = layout.state;

                    if (!state[pane1].isHidden) {
                        layout.toggle(pane1);
                    }
                    else
                        layout.toggle(pane2);
                } 

                scope.api.openPane = function (pane: string) {
                    var layout: JQueryLayout = $(elem).layout();
                    var state = layout.state;

                    if (state[pane].isHidden || state[pane].isClosed) {
                        (<any>layout).open(pane, false, false, true);
                        resizeLayout();
                    }
                }

                scope.api.closePane = function (pane: string) {
                    var layout: JQueryLayout = $(elem).layout();
                    var state = layout.state;

                    if (!state[pane].isClosed) {
                        layout.close(pane);
                        resizeLayout();
                    }
                }

                scope.api.refresh = function () {
                    resizeLayout();
                    $timeout(function () {
                        resizeLayout();
                    }, 200);
                }   

                resizeLayout();               

                function onresize(name, element, state, options, layoutName) {
                    if (name == "north") {
                        eventService.publish(EventNames.NorthPaneResized, { state: state, options: options, element: element });
                    }
                    else if (name == "south") {
                        eventService.publish(EventNames.SouthPaneResized, { state: state, options: options, element: element });
                    }
                    else if (name == "east") {
                        eventService.publish(EventNames.EastPaneResized, { state: state, options: options, element: element });
                    }
                    else if (name == "west") {                        
                        eventService.publish(EventNames.WestPaneResized, { state: state, options: options, element: element });
                    }
                    else {
                        eventService.publish(EventNames.CenterPaneResized, { state: state, options: options, element: element });
                    }
                }

                function resizeLayout() {
                    var position = $(elem).position();
                    var padding = $(elem).css('padding-top');
                    var innerheight = $(elem).innerHeight();
                    var innerWidth = $(elem).innerWidth();

                    //if(innerheight != (Math.ceil($(window).innerHeight() - (position.top + 1)))) {
                    $(elem).innerHeight($(window).height() - (position.top + 1));
                    //}

                    //if (innerWidth != (Math.ceil($(window).innerWidth() - position.left))) {
                    $(elem).innerWidth($(window).innerWidth() - position.left - 1);
                    //}

                    $(elem).layout().resizeAll();
                }

                scope.$watch(function () {
                    return $(elem).is(":visible");
                }, function (value) {
                    if (value) {                            
                            $timeout(function () {
                                resizeLayout();                                
                            }, 700);
                        }
                    });

                scope.$watch("hideNorth", function (newValue) {
                    if (angular.isDefined(newValue)) {
                        if (newValue)
                            $(elem).layout().close('north');
                        else
                            $(elem).layout().open('north');
                    }
                });

                scope.$watch("hideSouth", function (newValue) {
                    if (angular.isDefined(newValue)) {
                        if (newValue)
                            $(elem).layout().close('south');
                        else
                            $(elem).layout().open('south');
                    }
                });

                scope.$watch("hideEast", function (newValue) {
                    if (angular.isDefined(newValue)) {
                        if (newValue)
                            $(elem).layout().close('east');
                        else
                            $(elem).layout().open('east');
                    }
                });

                scope.$watch("hideWest", function (newValue) {
                    if (angular.isDefined(newValue)) {
                        if (newValue)
                            $(elem).layout().close('west');
                        else
                            $(elem).layout().open('west');
                    }
                });

                scope.$watch("eastWest", function (newValue) {
                    if (angular.isDefined(newValue)) {
                        var west = scope.api.has_children('west') ? true : false;
                        var pane: string = west ? 'west' : 'east';
                                                
                        if (newValue) {
                            if (!scope.api.get_state(pane).isClosed) {
                                setState = false;
                                $(elem).layout().close(pane);
                            }
                        }                   
                        else {
                            if (!angular.isDefined(previousState[pane]) || !previousState[pane]) {
                                if (scope.api.get_state(pane).isClosed) {
                                    setState = false;
                                    $(elem).layout().open(pane);
                                }                                
                            }                            
                        }                        
                    }
                });                
            });
        }
    }
}]);