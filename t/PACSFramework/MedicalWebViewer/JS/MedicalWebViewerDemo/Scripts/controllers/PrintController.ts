// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IPrintControllerScope extends ng.IScope {        
        exportOptions: Models.ExportOptions;
        selectedFormat: Models.ExportImageFormat;
        source: any;

        ok();
        cancel();
        passwordValid(): boolean;     
    }

    export class PrintController {
        static $inject = ['$scope', 'optionsService', '$modalInstance'];

        private _overlayManagerService: OverlayManagerService;

        constructor($scope: IPrintControllerScope, optionsService:OptionsService, $modalInstance) {                                               
            $scope.exportOptions = new Models.ExportOptions();    
            $scope.source = {};           
           $scope.source.value = "SelectedImages";                           

            $scope.ok = function () {                   
                $scope.exportOptions.LayoutImageWidth = 0;            
                $modalInstance.close({ options: $scope.exportOptions, source: $scope.source.value });
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };            
        }       
    }
}