// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />


directives.directive('scroller', ["$timeout", function ($timeout:ng.ITimeoutService) {   
 return {
        restrict: "A",
        scope: false,
        link: function (scope: ng.IScope, element: ng.IAugmentedJQuery, attributes: ng.IAttributes) {
            var $element: JQuery = $(element).addClass("scroll-parent");
            var leftDiv = document.createElement("div");
            leftDiv.id = 'scrollLeft_toolbar_button';
            var $left = $(leftDiv).addClass("scroll-button scroll-button-left");
            var $right = $(document.createElement("div")).addClass("scroll-button scroll-button-right");
            var $body = $(document.createElement("div")).addClass("scroll-body");



            var scrollArea : any = document.createElement("div");
            scrollArea.id = 'scrollArea';
            var $scrollAreaBody = $(scrollArea).addClass("toolbarbodyArea");

            $body.append($scrollAreaBody);

            var InnerScroll: any = document.createElement("div");
            InnerScroll.id = 'scrollInner';
            var $bodyInner = $(InnerScroll).addClass("scroll-body-inner");
            var $children = $element.children();
            var disabled = false;
            var disabledClass = "scroll-button-disabled";

            InnerScroll.left = 0;
            InnerScroll.setLeft = function (value) {
                InnerScroll.style.left = value + "px";
                InnerScroll.left = value;
            }

            InnerScroll.getLeft = function () {
                return InnerScroll.left;
            }

            $left.append($(document.createElement("span")).addClass("fa fa-angle-double-left"));
            $right.append($(document.createElement("span")).addClass("fa fa-angle-double-right"));            
            $right.css('float', 'right');  
            $right.css('z-index', '3000');
            $body.css('position', 'absolute');          
            $scrollAreaBody.append($bodyInner);
            $children.detach();
            $bodyInner.append($children);
            $bodyInner.css("left", "0px");
            $bodyInner.css("overflow", "visible");
            $bodyInner.css("display", "inline");
            $bodyInner.css("white-space", "nowrap");  
            $bodyInner.css("position", "relative");           
            $body.css("overflow", "visible");
            $left.css("z-index", 1000);            
            $element.append($left).append($body).append($right);            

            $element.resize(function () {                   
                $timeout(function () {
                    var innerWidth = $bodyInner.width();
                    var outerWidth = $body.parent().width();

                    if (innerWidth > outerWidth) {
                        disabled = false;
                        $left.removeClass(disabledClass);
                        $right.removeClass(disabledClass);
                    }
                    else {
                        disabled = true;
                        $left.addClass(disabledClass);
                        $right.addClass(disabledClass);
                    }

                    if ($bodyInner.position().left != 0) {
                        $bodyInner.css({
                            left: InnerScroll.left + "px"
                        });
                    }
                }, 850);
            });

            var watchFunc = function () {
                var innerWidth = $bodyInner.width();
                var outerWidth = $body.parent().width();
                
                return (innerWidth > outerWidth);
            };            
            

            $left.on('click touchstart', function (event) {
                var current: number;
                var half: number;
                var newLeft: number;
               
                if (disabled || $left.hasClass(disabledClass))
                    return;

                event.stopPropagation();
                event.preventDefault();                               
                current = parseInt($bodyInner.css("left"));
                half = Math.floor($body.parent().width() / 2);
                newLeft = Math.min(InnerScroll.left, current + half);                
                $bodyInner.css({
                    left: newLeft + "px"
                });

                if (newLeft == 0) {
                    if (!$left.hasClass(disabledClass)) {
                        $left.addClass(disabledClass);
                    }

                    if ($right.hasClass(disabledClass)) {
                        $right.removeClass(disabledClass);
                    }
                }
                else {
                    if ($right.hasClass(disabledClass)) {
                        $right.removeClass(disabledClass);
                    }
                }     
            });

            $right.on('click touchstart', function (event:Event) {
                var current: number;
                var half: number;
                var newLeft: number;
                var max: number;
                var width = 0;                
                var lastChild = $bodyInner.children().last();
                var lastWidth:number;

                if (disabled || $right.hasClass(disabledClass))
                    return;

                if (lastChild[0].hasChildNodes) {
                    lastWidth = 0;
                    lastChild.children().width(function (i, w) {
                        lastWidth += w;
                    });                                                       
                }
                else {
                    lastWidth = lastChild.outerWidth(true);
                }

                if (lt.LTHelper.OS == lt.LTOS.iOS && lt.LTHelper.device == lt.LTDevice.mobile) {
                    lastWidth += 10;
                }

                if (!lastChild.hasClass('btn-group')) {
                    lastWidth += lastWidth;
                }

                event.stopPropagation();
                event.preventDefault();
                width = lastChild.position().left + lastWidth;
                current = parseInt($bodyInner.css("left"));
                half = Math.floor($body.parent().outerWidth(true) / 2);
                max = Math.floor($body.parent().outerWidth(true) - width);
                newLeft = Math.max(max, (current - (half + lastWidth)));              
                $bodyInner.css({
                    left: newLeft + "px"
                }); 

                if (newLeft == max) {
                    if (!$right.hasClass(disabledClass)) {
                        $right.addClass(disabledClass);
                    }

                    if ($left.hasClass(disabledClass)) {
                        $left.removeClass(disabledClass);
                    }
                }
                else {
                    if ($left.hasClass(disabledClass)) {
                        $left.removeClass(disabledClass);
                    }
                }              
            });


            scope.$watch(watchFunc, (isLarger) => {
                if (isLarger) {
                    disabled = false;
                    $left.removeClass(disabledClass);                    
                    $right.removeClass(disabledClass);                    
                }
                else {
                    disabled = true;
                    $left.addClass(disabledClass);                    
                    $right.addClass(disabledClass);                    

                    if ($bodyInner.position().left != 0) {
                        $bodyInner.css({
                            left: InnerScroll.left + "px"
                        });
                    }
                }
            });
        }
    }
}]);

directives.directive('verticalScroller', function ($timeout: ng.ITimeoutService) {   
 return {
        restrict: "A",
        scope: false,
        link: function (scope: ng.IScope, element: ng.IAugmentedJQuery, attributes: ng.IAttributes) {
            var $element: JQuery = $(element).addClass("scroll-parent-vertical");
            var $top = $(document.createElement("div")).addClass("scroll-button-vertical scroll-button-up");
            var $right = $(document.createElement("div")).addClass("scroll-button-vertical scroll-button-down");
            var $body = $(document.createElement("div")).addClass("scroll-body-vertical");
            var InnerScroll : any = document.createElement("div");
            var $bodyInner = $(InnerScroll).addClass("scroll-body-inner");
            var $children = $element.children();
            var disabled = false;
            var disabledClass = "scroll-button-disabled";

            $top.append($(document.createElement("span")).addClass("fa fa-angle-double-up"));
            $right.append($(document.createElement("span")).addClass("fa fa-angle-double-down"));
            $right.css('position', 'fixed');
            $right.css('bottom', '0');
            $right.css('z-index', '3000');
            $body.css('position', 'absolute');
            $body.append($bodyInner);
            $children.detach();
            $bodyInner.append($children);
            $bodyInner.css("top", "0px");
            $bodyInner.css("overflow", "visible");
            $bodyInner.css("display", "inline");
            $bodyInner.css("white-space", "nowrap");
            $bodyInner.css("position", "relative");

            InnerScroll.setLeft = function (value) {
                InnerScroll.style.left = value + "px";
                InnerScroll.left = value;
            }
            $body.css("overflow", "visible");
            $top.css("z-index", 1000);
            $element.append($top).append($body).append($right);

            $element.resize(function () {
                $timeout(function () {
                    var innerHeight = $bodyInner.height();
                    var outerHeight = $body.parent().height();

                    if (innerHeight > outerHeight) {
                        disabled = false;
                        $top.removeClass(disabledClass);
                        $right.removeClass(disabledClass);
                    }
                    else {
                        disabled = true;
                        $top.addClass(disabledClass);
                        $right.addClass(disabledClass);
                    }

                    if ($bodyInner.position().top != 0) {
                        $bodyInner.css({
                            top: "0px"
                        });
                    }
                }, 850);
            });

            var watchFunc = function () {
                var innerHeight = $bodyInner.height();
                var outerHeight = $body.parent().height();

                return (innerHeight > outerHeight);
            };


            $top.on('click touchstart', function (event) {
                var current: number;
                var half: number;
                var newLeft: number;

                if (disabled || $top.hasClass(disabledClass))
                    return;

                event.stopPropagation();
                event.preventDefault();
                current = parseInt($bodyInner.css("left"));
                half = Math.floor($body.parent().width() / 2);
                newLeft = Math.min(InnerScroll.left, current + half);
                $bodyInner.css({
                    left: newLeft + "px"
                });

                if (newLeft == 0) {
                    if (!$top.hasClass(disabledClass)) {
                        $top.addClass(disabledClass);
                    }

                    if ($right.hasClass(disabledClass)) {
                        $right.removeClass(disabledClass);
                    }
                }
                else {
                    if ($right.hasClass(disabledClass)) {
                        $right.removeClass(disabledClass);
                    }
                }
            });

            $right.on('click touchstart', function (event: Event) {
                var current: number;
                var half: number;
                var newLeft: number;
                var max: number;
                var width = 0;
                var lastChild = $bodyInner.children().last();
                var lastWidth: number;

                if (disabled || $right.hasClass(disabledClass))
                    return;

                if (lastChild[0].hasChildNodes) {
                    lastWidth = 0;
                    lastChild.children().width(function (i, w) {
                        lastWidth += w;
                    });
                }
                else {
                    lastWidth = lastChild.outerWidth(true);
                }

                if (lt.LTHelper.OS == lt.LTOS.iOS && lt.LTHelper.device == lt.LTDevice.mobile) {
                    lastWidth += 10;
                }

                event.stopPropagation();
                event.preventDefault();
                width = lastChild.position().left + lastWidth;
                current = parseInt($bodyInner.css("left"));
                half = Math.floor($body.parent().outerWidth(true) / 2);
                max = Math.floor($body.parent().outerWidth(true) - width);
                newLeft = Math.min(InnerScroll.left, Math.max(max, (current - half)));
                $bodyInner.css({
                    left: newLeft + "px"
                });

                if (newLeft == max) {
                    if (!$right.hasClass(disabledClass)) {
                        $right.addClass(disabledClass);
                    }

                    if ($top.hasClass(disabledClass)) {
                        $top.removeClass(disabledClass);
                    }
                }
                else {
                    if ($top.hasClass(disabledClass)) {
                        $top.removeClass(disabledClass);
                    }
                }
            });


            scope.$watch(watchFunc, (isLarger) => {
                if (isLarger) {
                    disabled = false;
                    $top.removeClass(disabledClass);
                    $right.removeClass(disabledClass);
                }
                else {
                    disabled = true;
                    $top.addClass(disabledClass);
                    $right.addClass(disabledClass);

                    if ($bodyInner.position().left != 0) {
                        $bodyInner.css({
                            left: InnerScroll.left +" px"
                        });
                    }
                }
            });
        }
    }
});