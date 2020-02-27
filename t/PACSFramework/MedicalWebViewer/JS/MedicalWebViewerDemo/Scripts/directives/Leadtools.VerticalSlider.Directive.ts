// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

directives.directive('verticalSlider', ["eventService", "$timeout", function (eventService: EventService,$timeout): ng.IDirective {
    return {
        restrict: 'AE',
        scope: {
            'sliderSteps': "=",
            'sliderPosition': "=",
            'positionChanged': '&'
        },
        link: function (scope : any, elem:ng.IAugmentedJQuery, attr: any) {
            var slider = new InteractiveVerticalSlider($(elem)[0], 1);

            scope.$watch("sliderSteps", function (value) {
                if (angular.isDefined(value)) {
                    slider.updateSteps(value);
                }                
            });

            $(elem).parent().resize(function (e, data) {
                sizeToParent($(elem), $(elem).parent());
            });            

            scope.$watch("sliderPosition", function (value) {
                if (angular.isDefined(value)) {
                    slider.set_currentStep(value);
                }
            });

            function sizeToParent($elem, $parent) {
                var position = $elem.position();

                $elem.height($parent.height() - position.top);
                slider.setupSlider();
            }

            slider.add_stepChanged(OnStepChanged)

            function OnStepChanged(sender, e: StepChangedEventArgs) {
                var position = e.get_newIndex() - 1;

                if (position != scope.sliderPosition) {
                    scope.sliderPosition = position;
                    scope.positionChanged({ position: position });
                }
            }
        }
    };    
}]);