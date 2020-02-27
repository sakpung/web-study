// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/datejs.d.ts" />

module Controllers {
    export interface IHSLControllerScope extends ng.IScope {  
        frame: any;
        ipVals: any;
        slider: any;
        ipApi: any;
            
        change();
        ok();
        cancel();                  
    }

    export class HSLController {
        static $inject = ['$scope', '$modalInstance', 'optionsService', 'eventService', 'seriesManagerService'];       

        constructor($scope: IHSLControllerScope, $modalInstance, optionsService: OptionsService, eventService: EventService, seriesManagerService:SeriesManagerService) {                                    
            $scope.ipVals = {
                hue: 0,
                saturation: 0,
                lightness: 0
            };

            function stop(event, ui) {
                var args = new Array();

                args["hue"] = $scope.ipVals.hue * 100;
                args["saturation"] = $scope.ipVals.saturation * 10;
                args["intensity"] = $scope.ipVals.lightness * 10;

                $scope.ipApi.applyIPCommand("ChangeHueSaturationIntensity", args);
            }

            function change(event, ui) {
                var args = new Array();

                args["hue"] = $scope.ipVals.hue * 100;
                args["saturation"] = $scope.ipVals.saturation * 10;
                args["intensity"] = $scope.ipVals.lightness * 10;

                $scope.ipApi.applyIPCommand("ChangeHueSaturationIntensity", args);
            }
                        
            $scope.slider = {
                'options': {                    
                    stop: stop                    
                },
                'hueOptions': {
                    stop: stop,
                    min: -180,
                    max: 180
                }            
            }            

            $scope.frame = seriesManagerService.get_activeCellFrame();
            $scope.ipApi = {};
                
            $scope.ok = function () {                
                $modalInstance.close($scope.ipVals);
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }; 

            $scope.change = function () {
                change(null,null);
            }                                  
        }        
    }
}