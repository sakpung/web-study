// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

directives.directive('resizeToParent', function () {   
  return {
        restrict: 'A',
        link: function (scope, elem, attr) {
            var parent: JQuery = $(elem).parent();

            function resize() {
                $(elem).width(parent.innerWidth());
                $(elem).height(parent.innerHeight());
            }
           
            if (parent != null) {
                parent.resize(function (event) {                   
                    resize();
                });
            }  
            
            $(window).bind('orientationchange', function () {
                if (parent != null) {
                    resize();
                }
            });         
        }
    }
});

directives.directive('resizeWidthToParent', function ($timeout:ng.ITimeoutService) {   
  return {
        restrict: 'A',
        link: function (scope, elem, attr) {
            var parent: JQuery = $(elem).parent();           

            function resize() {
                $timeout(function () {
                    $(elem).width(parent.innerWidth());
                }, 250);
            }

            if (parent != null) {
                parent.resize(function (event) {  
                    resize();
                });
            }

            $(window).bind('orientationchange', function () {                
                if (parent != null) {
                    resize();
                }               
            });
        }
    }
});