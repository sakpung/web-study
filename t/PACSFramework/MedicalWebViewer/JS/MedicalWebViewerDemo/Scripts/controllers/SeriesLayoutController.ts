// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface ISeriesLayoutControllerScope extends ng.IScope {
        layout: any;       
        

        isFormValid(): boolean;

        isRowValid(): boolean;
        getIsRowValidError(): string;

        isColumnValid(): boolean;
        getIsColumnValidError(): string;

        ok();
        cancel();
    }

    export class SeriesLayoutController {
        static $inject = ['$scope', 'optionsService', '$modalInstance', 'layout', 'templateService', 'dialogs', '$translate', 'authenticationService'];

        private _overlayManagerService: OverlayManagerService;  

        private _notificationTitle: string = 'Notify';  
        private _errorMessage: string = 'Error getting template list'; 

        private _$scope: ISeriesLayoutControllerScope;

        constructor($scope: ISeriesLayoutControllerScope, optionsService: OptionsService, $modalInstance, layout, templateService: TemplateService, dialogs, $translate, authenticationService: AuthenticationService) {
            this._$scope = $scope;

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                this._notificationTitle = translation;
            }.bind(this));

            $translate('DIALOGS_TEMPLATE_ERROR_GET').then(function (translation) {
                this._errorMessage = translation;
            }.bind(this));

            $scope.ok = function () {
                $modalInstance.close($scope.layout);
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };

            $scope.isRowValid = this.isRowValid.bind(this);
            $scope.getIsRowValidError = this.getIsRowValidError.bind(this);

            $scope.isColumnValid = this.isColumnValid.bind(this);
            $scope.getIsColumnValidError = this.getIsColumnValidError.bind(this);


            $scope.isFormValid = this.isFormValid.bind(this);


            $scope.layout = {
                rows: layout.rows,
                columns: layout.columns,
                custom: null
            };

        }


        public isRowValid(): boolean {

            var errorMessage: string = this.getIsRowValidError();
            return (errorMessage == "");
        } 

        public getIsRowValidError(): string {

            if (!this._$scope.layout)
                return "";

            if (!$.isNumeric(this._$scope.layout.rows)) {
                return "Must be numeric";
            }

            if (this._$scope.layout.rows <= 0) {
                return "Must be greater than 0";
            }

            return "";
        }


        public isColumnValid(): boolean {

            var errorMessage: string = this.getIsColumnValidError();
            return (errorMessage == "");
        }

        public getIsColumnValidError(): string {

            if (!this._$scope.layout)
                return "";

            if (!$.isNumeric(this._$scope.layout.columns)) {
                return "Must be numeric";
            }

            if (this._$scope.layout.columns <= 0) {
                return "Must be greater than 0";
            }

            return "";
        }

        public isFormValid() : boolean {
            return this.isRowValid() && this.isColumnValid();
        }
    }
}