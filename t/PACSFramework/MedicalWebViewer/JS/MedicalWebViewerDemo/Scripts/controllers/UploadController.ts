// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IUploadControllerScope extends ng.IScope { 
        file:string      
        uploadFile(element: any);
        ok();
    }

    export class UploadController {
        static $inject = ['$scope', '$modalInstance', 'Upload', 'templateService', 'eventService', '$translate', 'dialogs'];

        private _Upload: any;
        private _templateService: TemplateService;
        private _eventService: EventService;
        private _dialogs: any;

        private notifyTitle: string = 'Notification';
        private errorTitle: string = 'Error';
        private successMessage: string = 'Templates successfully imported'; 

        constructor($scope: IUploadControllerScope, $modalInstance, Upload, templateService: TemplateService, eventService: EventService, $translate, dialogs) {  
            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                this.notifyTitle = translation;
            }.bind(this));

            $translate('DIALOGS_ERROR').then(function (translation) {
                this.errorTitle = translation;
            }.bind(this));

            $translate('DIALOGS_TEMPLATES_IMPORTED').then(function (translation) {
                this.successMessage = translation;
            }.bind(this));

            $scope.file = '';
            $scope.uploadFile = this.uploadFile.bind(this);                                

            $scope.ok = function () {
                $modalInstance.close();
            } 

            this._Upload = Upload; 
            this._templateService = templateService;
            this._eventService = eventService;    
            this._dialogs = dialogs;              
        }

        public uploadFile(file) {
            var __this = this;
             
            this._templateService.ImportTemplates(this._Upload, file)
                .success(function (data: Models.Template[], status, headers, config) {
                    if (data.length == 1 && data[0].Id == 'GetImportTemplatesError_0F649AC6-0D07-49EA-906C-413256B8A43E') {
                        var errorString: string = "Import Failed: " + data[0].Name;
                        __this._dialogs.error(__this.errorTitle, errorString);
                    }
                    else {
                        __this._eventService.publish(EventNames.TemplatesImported, { templates: data });
                        __this._dialogs.notify(__this.notifyTitle, __this.successMessage);
                    }
                })
                .error(function (data, status, headers, config, aaa, bbb, ccc, ddd) {                    
                    __this._dialogs.error(__this.errorTitle, data);          
                });                                   
        }
    }
} 