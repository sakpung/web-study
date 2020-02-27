// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
declare var commangular;

commangular.command('OnNewTemplate', ['templateEditorService', function (templateEditorService:TemplateEditorService) {
	return {
        execute: function () { 
            templateEditorService.templateEditController.onNewTemplate();                             
        }
    }
}]);

commangular.command('OnCopyTemplate', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
    return {
        execute: function () {
            templateEditorService.templateEditController.onCopyTemplate();
        }
    }
}]);

commangular.command('OnSaveTemplate', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.saveTemplate();
        }
    }
}]);

commangular.command('OnRenameTemplate', ['templateEditorService', '$modal', function (templateEditorService: TemplateEditorService, $modal){
	return {
        execute: function () {
            var modalInstance = $modal.open({
                templateUrl: 'views/dialogs/Prompt.html',
                controller: Controllers.PromptController,
                backdrop: 'static',
                resolve: {
                    label: function () {
                        return "Rename Template";
                    },
                    text: function () {
                        return templateEditorService.templateEditController.currentTemplateName;
                    }
                }
            });

            modalInstance.result.then(function (newName) {
                templateEditorService.templateEditController.renameTemplate(newName);
            });
        }
    }
}]);

commangular.command('OnDeleteBox', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onDeleteSelectedFrames();
        }
    }
}]);

commangular.command('OnDeleteTemplate', ['templateEditorService', 'templateService', '$translate', 'dialogs', function (templateEditorService: TemplateEditorService, templateService: TemplateService, $translate, dialogs) {
    return {
        execute: function () {
            var id: string = templateEditorService.templateEditController.currentTemplateId;
            var notifyTitle: string = 'Notification';
            var errorTitle: string = 'Error';
            var confirmation: string = 'Confirmation';
            var confirmationMessage: string = 'This will delete the selected template.\nAre you sure?';
            var successMessage: string = 'Current template successfully deleted';

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                notifyTitle = translation;
            }.bind(this));

            $translate('DIALOGS_ERROR').then(function (translation) {
                errorTitle = translation;
            }.bind(this));

            $translate('DIALOGS_TEMPLATE_DELETE').then(function (translation) {
                successMessage = translation;
            }.bind(this));

            $translate('DIALOGS_CONFIRMATION_TITLE').then(function (translation) {
                confirmation = translation;
            }.bind(this));

            $translate('DIALOGS_TEMPLATE_DELETE_CONFIRMATION').then(function (translation) {
                confirmationMessage = translation;
            }.bind(this));

            var dlg = dialogs.confirm(confirmation, confirmationMessage);

            dlg.result.then(function (btn) {
                templateService.DeleteTemplate(id).success(function () {
                    templateEditorService.templateEditController.deleteCurrentTemplate();
                    dialogs.notify(notifyTitle, successMessage);
                }).error(function (error) {
                    dialogs.error(notifyTitle, error);
                });
            });
        }
    }
}]);

commangular.command('OnSelectBox', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onSelect();
        }
    }
}]);

commangular.command('OnDrawBox', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onDraw();
        }
    }
}]);

commangular.command('OnExportTemplates', ['templateService', function (templateService: TemplateService) {
	return {
        execute: function () {
            templateService.ExportAllTemplates();
        }
    }
}]);

commangular.command('OnImportTemplates', ['templateEditorService', '$modal', function (templateEditorService: TemplateEditorService, $modal) {
	return {
        execute: function () {
            var modalInstance = $modal.open({
                templateUrl: 'views/dialogs/Upload.html',
                controller: Controllers.UploadController,
                backdrop: 'static'                
            });           
        }
    }
}]);

commangular.command('OnAlignLeft', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onAlignLeft();
        }
    }
}]);

commangular.command('OnAlignRight', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onAlignRight();
        }
    }
}]);

commangular.command('OnAlignCenter', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onAlignCenter();
        }
    }
}]);

commangular.command('OnAlignTop', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onAlignTop();
        }
    }
}]);

commangular.command('OnAlignBottom', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onAlignBottom();
        }
    }
}]);

commangular.command('OnAlignMiddle', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onAlignMiddle();
        }
    }
}]);

commangular.command('OnMakeSameWidth', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onMakeSameWidth();
        }
    }
}]);

commangular.command('OnMakeSameHeight', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onMakeSameHeight();
        }
    }
}]);

commangular.command('OnMakeSameSize', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onMakeSameSize();
        }
    }
}]);

commangular.command('OnConfigureGrid', ['templateEditorService', '$modal', 'optionsService', 'authenticationService', function (templateEditorService: TemplateEditorService, $modal, optionsService:OptionsService, authenticationService:AuthenticationService) {
    return {
        execute: function () {            
            var modalInstance = $modal.open({
                templateUrl: 'views/dialogs/GridSettings.html',
                controller: Controllers.GridSettingsController,
                backdrop: 'static',
                resolve: {
                    label: function () {
                        return {
                            spacing: "Line Spacing",
                            length: "Grid Length"
                        };
                    },
                    spacing: function () {
                        var spacing = optionsService.get(OptionNames.GridSpacing); 

                        if (!spacing)
                            spacing = templateEditorService.templateEditController.get_GetLineSpacing();

                        return spacing;
                    },
                    length: function () {
                        var length = optionsService.get(OptionNames.GridLength);

                        if (!length)
                            length = templateEditorService.templateEditController.get_GridLength();

                        return length;
                    },
                    title: function() {
                        return "Grid Settings";
                    }
                }
            });

            modalInstance.result.then(function (settings) {    
                var value = optionsService.get(OptionNames.GridSpacing); 
                var length = optionsService.get(OptionNames.GridLength);            

                if (value != settings.spacing) {
                    templateEditorService.templateEditController.set_LineSpacing(settings.spacing);
                    optionsService.saveUserOption(OptionNames.GridSpacing, settings.spacing).success(function () {
                        optionsService.set(OptionNames.GridSpacing, settings.spacing);
                    }).
                    error(function (error, status) {
                    });
                }

                if (length != settings.length) {
                    templateEditorService.templateEditController.set_GridLength(settings.length);
                    optionsService.saveUserOption(OptionNames.GridLength, settings.length).success(function () {
                        optionsService.set(OptionNames.GridLength, settings.length);
                    }).
                    error(function (error, status) {
                    });
                }
            });
        }
    }
}]);

commangular.command('OnToggleGrid', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onToggleGrid()
        }
    }
}]);

commangular.command('OnToggleSnapToGrid', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
	return {
        execute: function () {
            templateEditorService.templateEditController.onToggleSnapToGrid();
        }
    }
}]);

commangular.command('OnReturnToViewer', ['templateEditorService', function (templateEditorService: TemplateEditorService) {
    return {
        execute: function () {
            templateEditorService.templateEditController.onReturnToViewer();
        }
    }
}]);


