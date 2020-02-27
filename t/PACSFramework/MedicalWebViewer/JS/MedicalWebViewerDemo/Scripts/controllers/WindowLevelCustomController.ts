// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IWindowLevelCustomControllerScope extends ng.IScope {
        settings: any;
                
        ok();
        cancel();
        reset();
        apply();
    }

    export class WindowLevelCustomController {
        static $inject = ['$scope', 'optionsService', '$modalInstance', 'settings', 'currentFrame', 'seriesService'];

        private _overlayManagerService: OverlayManagerService;        

        constructor($scope: IWindowLevelCustomControllerScope, optionsService: OptionsService, $modalInstance, settings, currentFrame, seriesService) {
            var index;            
            
            $scope.settings = angular.copy(settings);            

            $scope.ok = function () {
                $modalInstance.close($scope.settings);
            }

            $scope.apply = function () {
                var cell: lt.Controls.Medical.Cell = seriesService.get_activeCell();

                if (cell instanceof lt.Controls.Medical.Cell3D) {
                    var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;
                    cell3D.information.windowWidth = $scope.settings.width;
                    cell3D.information.windowCenter = $scope.settings.center;
                    cell3D.updateWindowLevelValues();

                }
                else {
                    var linked = cell.get_linked();
                    if (linked) {
                        seriesService.enumerateFrames(cell, function (frame, index) {
                            if (seriesService.withinVisibleRange(cell, index)) {
                                frame.setWindowLevel($scope.settings.width, $scope.settings.center);
                            }
                        });
                    }
                    else {
                        currentFrame.setWindowLevel($scope.settings.width, $scope.settings.center);
                    }
                }

            }


            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };

            $scope.reset = function () {
                $scope.settings.width = settings.originalWindowLevelWidth;
                $scope.settings.center = settings.originalWindowLevelCenter;
            }
        }        
    }
}