// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/datejs.d.ts" />

module Controllers {
    export interface IBrightnessContrastControllerScope extends ng.IScope {  
        frame: any;
        ipVals: any;
        slider: any;
        ipApi: any;
        
        change();    
        ok();
        cancel();                  
    }

    export class BrightnessContrastController {
        static $inject = ['$scope', '$modalInstance', 'optionsService', 'eventService', 'seriesManagerService'];       

        constructor($scope: IBrightnessContrastControllerScope, $modalInstance, optionsService: OptionsService, eventService: EventService, seriesManagerService:SeriesManagerService) {                                    
            $scope.ipVals = {
                contrast: 0,
                brightness:0
            };

            function apply() {
                var args = new Array();

                args["contrast"] = $scope.ipVals.contrast * 10;
                args["brightness"] = $scope.ipVals.brightness * 10;
                args["intensity"] = 0;

                $scope.ipApi.applyIPCommand("ContrastBrightnessIntensity", args);
            }
                        
            $scope.slider = {
                'options': {                    
                    stop: function (event, ui) {
                        apply();
                    }
                }
            }            

            $scope.frame = seriesManagerService.get_activeCellFrame();
            $scope.ipApi = {};

            $scope.change = function () {
                apply();
            }
                
            $scope.ok = function () {                
                $modalInstance.close($scope.ipVals);
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };                                   
        }        
    }
}