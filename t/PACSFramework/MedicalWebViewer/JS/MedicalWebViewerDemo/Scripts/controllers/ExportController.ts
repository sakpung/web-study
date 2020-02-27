// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IExportControllerScope extends ng.IScope {        
        printOptions: Models.PrintOptions;
        exportOptions: Models.ExportOptions;
        exportFormats: Array<Models.ExportImageFormat>;
        selectedFormat: Models.ExportImageFormat;
        exportSources: Array<ExportSource>;
        source: any;

        ok();
        cancel();
        passwordValid(): boolean;     
    }

    export class ExportSource {
        public value:string;
        public displayName:string;
        public selectable: boolean; 

        public constructor(value: string, displayName: string) {
            this.value = value;
            this.displayName = displayName;
            this.selectable = true;
        }
    }

    declare var html2canvas;

    export class ExportController {
        static $inject = ['$scope', 'optionsService', '$modalInstance','hasLayout'];

        private _overlayManagerService: OverlayManagerService;

        constructor($scope: IExportControllerScope, optionsService:OptionsService, $modalInstance, hasLayout:boolean) {                                               
            $scope.exportFormats = new Array<Models.ExportImageFormat>(); 
            $scope.exportFormats.push(new Models.ExportImageFormat("BMP", "Bmp", true, false));
            $scope.exportFormats.push(new Models.ExportImageFormat("JPG", "Jpeg", true, false, true));
            $scope.exportFormats.push(new Models.ExportImageFormat("JPG Lossless", "JpegLossy", true, true));
            $scope.exportFormats.push(new Models.ExportImageFormat("PNG", "Png", true, false));
            $scope.exportFormats.push(new Models.ExportImageFormat("TIF", "Tif", true, true));
            $scope.exportFormats.push(new Models.ExportImageFormat("CMP", "Cmp", true, false, true));
            $scope.exportFormats.push(new Models.ExportImageFormat("PDF", "PDF", false, false, false, true, true));
            $scope.exportFormats.push(new Models.ExportImageFormat("DICOM", "DicomGray", false, true));
            $scope.exportFormats.push(new Models.ExportImageFormat("DICOM Zip", "DicomZip", false, true)); 

            $scope.exportOptions = new Models.ExportOptions();
            $scope.source = {};
            $scope.source.selectedFormat = $scope.exportFormats[3];            

            $scope.exportSources = new Array<ExportSource>();            
            $scope.exportSources.push(new ExportSource("PrintCurrentView", "Print Current View"));                          
            $scope.exportSources.push(new ExportSource("AllPatientImages", "All Patient Images"));                          
            $scope.exportSources.push(new ExportSource("CurrentSeries", "Current Series"));                          
            $scope.exportSources.push(new ExportSource("SelectedImages", "Selected Images"));                          
            $scope.exportSources.push(new ExportSource("Layout", "Current Series Layout")); 

            // selected images only work when you have a layout attached with the series.
            if (!hasLayout) {
                $scope.exportSources[3].selectable = false;
            }


            $scope.source.value = $scope.exportSources[0].value;  

            $scope.passwordValid = function () { 
                return $scope.exportOptions.DczPassword && $scope.exportOptions.DczPassword.length > 0;          
            }

            $scope.ok = function () {
                $scope.exportOptions.FileFormat = $scope.source.selectedFormat.Format == "JpegLossy" ? "Jpg Lossless" : $scope.source.selectedFormat.Format;
                $scope.exportOptions.LayoutImageWidth = 0;            
                $modalInstance.close({ options: $scope.exportOptions, source: $scope.source.value });
            }

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };            
        }       
    }
}