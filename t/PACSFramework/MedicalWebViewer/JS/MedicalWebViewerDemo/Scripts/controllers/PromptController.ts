// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IPromptControllerScope extends ng.IScope {
        data: any;
        label: string;

        cancel();
        ok();
    }

    export class PromptController {
        static $inject = ['$scope', '$modalInstance','label','text'];

        constructor($scope: IPromptControllerScope, $modalInstance, label, text) {  

            $scope.label = label;
            $scope.data = {}
            $scope.data.text = text;
                     
            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            }

            $scope.ok = function () {
                $modalInstance.close($scope.data.text);
            }                    
        }
    }
} 