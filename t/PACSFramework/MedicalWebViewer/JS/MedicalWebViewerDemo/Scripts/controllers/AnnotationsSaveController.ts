// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

module Controllers {
    export interface IAnnotationsSaveControllerScope extends ng.IScope {
        info: any;

        ok();
        cancel();        
    }

    export class AnnotationsSaveController {

        static $inject = ['$scope', '$modalInstance'];

        constructor($scope: IAnnotationsSaveControllerScope, $modalInstance) {  
            $scope.info = {};
            $scope.info.description = "";            

            $scope.ok = function () {
                $modalInstance.close($scope.info.description);
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }
        }                        
    }
}