// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {

    export interface IConfirmDialogControllerScope extends ng.IScope {
        header: string;
        msg: string;
        icon: string;

        yes();
        no();
        cancel();
    }

    export class ConfirmDialogControllerScope {        
        static $inject = ["$scope", "$modalInstance", "$translate", 'data'];

        constructor($scope: IConfirmDialogControllerScope, $modalInstance, $translate, data) {
            $scope.header = (angular.isDefined(data.header)) ? data.header : $translate.instant('DIALOGS_NOTIFICATION');
            $scope.msg = (angular.isDefined(data.msg)) ? data.msg : $translate.instant('DIALOGS_NOTIFICATION_MSG');
            $scope.icon = (angular.isDefined(data.icon)) ? data.icon : 'fa fa-info';

            $scope.no = function () {
                $modalInstance.close('no');
            }; // end close

            $scope.yes = function () {
                $modalInstance.close('yes');
            }; // end yes

            $scope.cancel = () => {
                $modalInstance.dismiss("cancel");
            };
        }
    }
}