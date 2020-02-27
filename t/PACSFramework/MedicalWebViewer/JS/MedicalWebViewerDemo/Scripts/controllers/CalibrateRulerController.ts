// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface ICalibrateRulerControllerScope extends ng.IScope {
        calibration: any;

        ok();
        cancel();
        isValid(): boolean;      
    }

    export class CalibrateRulerController {
        static $inject = ['$scope', '$modalInstance'];        

        constructor($scope: ICalibrateRulerControllerScope, $modalInstance) {
            $scope.calibration = {};
            $scope.calibration.length = null;
            $scope.calibration.unit = 6;
            $scope.calibration.applyToAll = false;

            $scope.isValid = function () {
                return $scope.calibration.length != null && $scope.calibration.length.length > 0;
            }
                                               
            $scope.ok = function () {
                $modalInstance.close($scope.calibration);
            }           

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }
        }
    }
}