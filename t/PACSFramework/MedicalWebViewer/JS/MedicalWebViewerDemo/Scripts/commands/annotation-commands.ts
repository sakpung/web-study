// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
declare var commangular;

commangular.command('OnAnnotationSelect', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnSelect);
        }
    }
}]);



function SetOrientation(seriesManagerService, face) {
    var cell = seriesManagerService.get_activeCell();
    var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;

    cell3D.orientation = face;
}


commangular.command('OnHeadOrientation', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            SetOrientation(seriesManagerService, lt.Controls.Medical.OrientationFace.superior);
        }
    }
}]);

commangular.command('OnFeetOrientation', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            SetOrientation(seriesManagerService, lt.Controls.Medical.OrientationFace.inferior);
        }
    }
}]);

commangular.command('OnLeftOrientation', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            SetOrientation(seriesManagerService, lt.Controls.Medical.OrientationFace.left);
        }
    }
}]);

commangular.command('OnRightOrientation', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            SetOrientation(seriesManagerService, lt.Controls.Medical.OrientationFace.right);
        }
    }
}]);

commangular.command('OnAnteriorOrientation', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            SetOrientation(seriesManagerService, lt.Controls.Medical.OrientationFace.anterior);
        }
    }
}]);

commangular.command('OnPosteriorOrientation', ['seriesManagerService', function (seriesManagerService: SeriesManagerService) {
    return {
        execute: function () {
            SetOrientation(seriesManagerService, lt.Controls.Medical.OrientationFace.posterior);
        }
    }
}]);








commangular.command('OnAnnotationArrow', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnPointer);
        }
    }
}]);

commangular.command('OnAnnotationPoint', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnPoint);
        }
    }
}]);

commangular.command('OnAnnotationRectangle', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnRectangle);
        }
    }
}]);

commangular.command('OnAnnotationTextPointer', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnTextPointer);
        }
    }
}]);

commangular.command('OnAnnotationEllipse', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnEllipse);
        }
    }
}]);

commangular.command('OnAnnotationCurve', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnCurve);
        }
    }
}]);

commangular.command('OnAnnotationLine', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnLine);
        }
    }
}]);

commangular.command('OnAnnotationFreehand', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnFreeHand);
        }
    }
}]);

commangular.command('OnAnnotationPolyline', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnPolyline);
        }
    }
}]);

commangular.command('OnAnnotationPolygon', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnPolygon);
        }
    }
}]);

commangular.command('OnAnnotationText', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnText);
        }
    }
}]);

commangular.command('OnAnnotationNote', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnNote);
        }
    }
}]);

commangular.command('OnAnnotationHighlight', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnHighlight);
        }
    }
}]);

commangular.command('OnAnnotationRuler', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {            
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnRuler);
        }
    }
}]);

commangular.command('OnAnnotationPolyRuler', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnPolyRuler);
        }
    }
}]);

commangular.command('OnAnnotationProtractor', ['toolbarService', 'tabService', 'buttonId', function (toolbarService: ToolbarService, tabService: TabService, buttonId: string) {
    return {
        execute: function () {
            setAnnTool(toolbarService, tabService, buttonId, MedicalViewerAction.AnnProtractor);
        }
    }
}]);

commangular.command('OnAnnotationShowHide', ['seriesManagerService', 'toolbarService', '$commangular', 'authenticationService', 'tabService',
    function (seriesManagerService: SeriesManagerService, toolbarService: ToolbarService, $commangular, authenticationService: AuthenticationService, tabService:TabService) {
    return {
            execute: function () {
                //var visibility = seriesManagerService.toggleAnnotationVisiblity();
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];                                
                var visibility = tabService.get_tabData(tab.id, TabDataKeys.AnnotationVisiblity);

                if (angular.isUndefined(visibility)) {
                    visibility = true;
                }

                visibility = !visibility;

                enumerateCell(tabService, function (cell: lt.Controls.Medical.Cell) {                    
                    var automation: lt.Annotations.Automation.AnnAutomation = cell.get_automation();  

                    automation.get_activeContainer().set_isVisible(visibility);   
                    automation.get_automationControl().automationInvalidate(lt.LeadRectD.empty);               
                });

                //
                // update the current mode by disabling the automation as an interactive mode.
                //
                if (!visibility) {
                    $commangular.dispatch('Pan', { buttonId: 'Pan'+ tab.id });
                }                

                toolbarService.enable(['Select' + tab.id, 'Arrow' + tab.id, 'Ellipse' + tab.id, 'Highlight' + tab.id, 'Rectangle' + tab.id, 'Text' + tab.id,
                    'Ruler' + tab.id, 'PolyRuler' + tab.id, 'Protractor' + tab.id, 'Curve' + tab.id, 'Line' + tab.id, 'Freehand' + tab.id, 'Point' + tab.id,
                    'Polyline' + tab.id, 'Polygon' + tab.id, 'Note' + tab.id, 'DeleteAnnotations' + tab.id, 'ClearAnnotations' + tab.id,
                    'ClearAllAnnotations' + tab.id], function () {
                        return visibility;
                    }); 

                toolbarService.enable('CalibrateRuler' + tab.id, function () {
                    var cell:lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();
                    var automation: lt.Annotations.Automation.AnnAutomation = cell.get_automation();
                    var container: lt.Annotations.Engine.AnnContainer = automation.activeContainer;  
                                

                    return visibility && (automation.currentDesigner != null && container.selectionObject.selectedObjects.count == 1 && container.selectionObject.selectedObjects.item(0) instanceof lt.Annotations.Engine.AnnPolyRulerObject);
                });

                toolbarService.enable('SaveAnn'+tab.id, function () {
                    return visibility && authenticationService.hasPermission(PermissionNames.CanStoreAnnotations);
                });

                toolbarService.enable('LoadAnn'+tab.id, function () {
                    var cell:lt.Controls.Medical.Cell = seriesManagerService.get_activeCell();

                    return visibility && authenticationService.hasPermission(PermissionNames.CanViewAnnotations) &&
                        seriesManagerService.get_annotationIDs(cell.seriesInstanceUID, cell.divID).length > 0;
                });

                tabService.set_tabData(tab.id, TabDataKeys.AnnotationVisiblity, visibility);
            }
        }
}]);

commangular.command('OnDeleteAnnotation', ['seriesManagerService', 'toolbarService', 'authenticationService', 'tabService', function (seriesManagerService: SeriesManagerService,
    toolbarService: ToolbarService, authenticationService: AuthenticationService, tabService:TabService) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

                seriesManagerService.deleteSelectedAnnotations();
        }
    }
}]);

commangular.command('OnClearAnnotation', ['seriesManagerService', 'toolbarService', 'authenticationService', 'tabService', function (seriesManagerService: SeriesManagerService,
    toolbarService: ToolbarService, authenticationService: AuthenticationService, tabService:TabService) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

            if (toolbarService.isEnabled("ClearAnnotations"+tab.id)) {
                seriesManagerService.clearAnnotations();
                if (toolbarService.isEnabled("CalibrateRuler" + tab.id)) {
                    toolbarService.disable("CalibrateRuler" + tab.id);
                }
            }
        }
    }
}]);

commangular.command('OnClearAllAnnotation', ['seriesManagerService', 'toolbarService', 'tabService', function (seriesManagerService: SeriesManagerService,
    toolbarService: ToolbarService, tabService: TabService) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

            if (toolbarService.isEnabled("ClearAllAnnotations" + tab.id)) {
                seriesManagerService.clearAllAnnotations();
                if (toolbarService.isEnabled("CalibrateRuler" + tab.id)) {
                    toolbarService.disable("CalibrateRuler" + tab.id);
                }
            }
        }
    }
}]);

commangular.command('OnLoadAnnotations', ['seriesManagerService', 'toolbarService', '$modal', 'eventService', 'objectRetrieveService', '$translate', 'dialogs', 'tabService', 
    function (seriesManagerService: SeriesManagerService,
        toolbarService: ToolbarService, $modal, eventService: EventService, objectRetrieveService: ObjectRetrieveService, $translate, dialogs, tabService:TabService) {   
    return {
        execute: function () {
                var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

                if (toolbarService.isEnabled("LoadAnn" + tab.id)) {
                    var cell = seriesManagerService.get_activeCell();
                    var annotations = seriesManagerService.get_annotationIDs(cell.seriesInstanceUID, cell.divID);

                    var frame = seriesManagerService.get_activeCellFrame();
                    var children = frame.get_container().get_children();
                    var count = children.count;
                    var _container = frame.get_container();
                    var notifyTitle = "";
                    var no;
                    var ann;
                    var found;

                    $translate('DIALOGS_NOTIFY').then(function (translation) {
                        notifyTitle = translation;
                    });

                    $translate('NO').then(function (translation) {
                        no = translation;
                    });

                    $translate('ANNOTATIONS').then(function (translation) {
                        ann = translation.toLowerCase();
                    });

                    $translate('FOUND').then(function (translation) {
                        found = translation;
                    });

                    var modalInstance = $modal.open({
                        templateUrl: 'views/dialogs/Annotations.html',
                        controller: Controllers.AnnotationsController,
                        backdrop: 'static',
                        resolve: {
                            annotations: function () {
                                return annotations;
                            },
                            seriesInstanceUID: function () {
                                return cell.seriesInstanceUID;
                            }
                        }
                    });

                    var userData : any =
                    {
                        SourceDpiX: _container.mapper.sourceDpiX,
                        SourceDpiY: _container.mapper.sourceDpiY,
                        TargetDpiX: _container.mapper.targetDpiX,
                        TargetDpiY: _container.mapper.targetDpiY

                    };
                    userData = JSON.stringify(userData);


                    modalInstance.result.then(function (sopInstanceUID: string) {
                        objectRetrieveService.GetPresentationAnnotations(sopInstanceUID, userData).then(function (result) {
                            if (result.status == 200) {
                                if (result.data && result.data.length > 0) {
                                    var xmlAnnotations: Document = $.parseXML(result.data);

                                    seriesManagerService.add_annotations(cell, xmlAnnotations);
                                }
                                else {
                                    dialogs.notify(notifyTitle, no + " " + ann + " " + found);
                                }
                            }
                        }, function (error) {
                                $translate('DIALOGS_ERROR').then(function (translation) {
                                    dialogs.error(translation, error);
                                });
                            });
                    }).finally(function (result) {
                        var annotations = seriesManagerService.get_annotationIDs(cell.seriesInstanceUID, cell.divID);

                        toolbarService.enable("LoadAnn" + tab.id, function () {
                            return angular.isDefined(annotations) && annotations.length > 0;
                        });
                        });
                }
            }
        }
}]);

commangular.command('OnSaveAnnotations', ['seriesManagerService', 'toolbarService', 'objectStoreService', 'authenticationService', '$modal', '$translate', 'dialogs', 'tabService','optionsService',
    function (seriesManagerService: SeriesManagerService, toolbarService: ToolbarService, objectStoreService: ObjectStoreService,
        authenticationService: AuthenticationService, $modal, $translate, dialogs, tabService:TabService, optionsService:OptionsService) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];
            var _container: lt.Annotations.Engine.AnnContainer;

            if (toolbarService.isEnabled("SaveAnn" + tab.id)) {
                var cell = seriesManagerService.get_activeCell();

                var length = cell.get_frames().get_count();
                var annFound = false;
                for (var index = 0; index < length; index++) {
                    var frame: lt.Controls.Medical.Frame = cell.get_frames().item(index);
                    var children = frame.get_container().get_children();
                    var count = children.count;
                    _container = frame.get_container();
                    


                    if (count != 0) {
                        annFound = true;
                    }
                }

                if (!annFound) {
                    alert( 'no annotation found to save');
                    return;
                }

                if (cell) {
                    var seriesInstanceUID: string = cell.get_seriesInstanceUID();
                    var annotationsData: string = seriesManagerService.get_cellAnnotations(cell);
                    var annotationsSaved: string = "";
                    var notifyTitle: string = "";
                    var errorTitle: string = "Error";

                    $translate('ANNOTATIONS_SAVED').then(function (translation) {
                        annotationsSaved = translation.toLowerCase();
                    });

                    $translate('DIALOGS_NOTIFY').then(function (translation) {
                        notifyTitle = translation;
                    });

                    $translate('DIALOGS_ERROR').then(function (translation) {
                        errorTitle = translation;
                    });

                    if (annotationsData.length > 0) {
                        var modalInstance = $modal.open({
                            templateUrl: 'views/dialogs/AnnotationsSave.html',
                            controller: Controllers.AnnotationsSaveController,
                            backdrop: 'static'
                        });


                        var userData : any =
                        {
                            SourceDpiX: _container.mapper.sourceDpiX,
                            SourceDpiY: _container.mapper.sourceDpiY,
                            TargetDpiX: _container.mapper.targetDpiX,
                            TargetDpiY: _container.mapper.targetDpiY

                        };

                        userData = JSON.stringify(userData);

                        modalInstance.result.then(function (description: string) {
                            objectStoreService.StoreAnnotations(seriesInstanceUID, annotationsData, description, userData).then(function (result) {
                                if (angular.isDefined(result.data) && angular.isDefined(result.data.Message)) {
                                    dialogs.error(errorTitle, result.data.Message);
                                }
                                else {
                                var dentalMode: boolean = optionsService.get(OptionNames.DentalMode);

                                seriesManagerService.add_annotationID(seriesInstanceUID, cell.divID, result.data);
                                if (dentalMode) {
                                    toolbarService.hilightBorder("LoadAnn" + tab.id, "1px", "#ff0000")
                                }
                                toolbarService.enable('LoadAnn' + tab.id, function () {
                                    return authenticationService.hasPermission(PermissionNames.CanViewAnnotations);
                                });
                                toolbarService.enable("SaveAnn" + tab.id, function () {
                                    return authenticationService.hasPermission(PermissionNames.CanStoreAnnotations);
                                });
                                dialogs.notify(notifyTitle, annotationsSaved);
                                }
                            },
                                function (error) {
                                    var message:any = "";

                                    if (angular.isDefined(error.status)) {
                                        message = Utils.get_httpStatusText(error.status);
                                    }
                                    else {
                                        message = error;
                                    }

                                    $translate('DIALOGS_ERROR').then(function (translation) {
                                        dialogs.error(translation, message);
                                    });
                                });
                        });
                    }
                }
            }
        }
    }
}]);

commangular.command('OnCalibrateRuler', ['seriesManagerService', 'toolbarService', 'tabService','$modal', function (seriesManagerService: SeriesManagerService,
    toolbarService: ToolbarService, tabService: TabService, $modal) {
    return {
        execute: function () {
            var tab: Models.Tab = tabService.get_allTabs()[tabService.activeTab];

            if (toolbarService.isEnabled("CalibrateRuler" + tab.id)) {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/CalibrateRuler.html',
                    controller: Controllers.CalibrateRulerController,
                    backdrop: 'static'
                });

                modalInstance.result.then(function (calibration) {
                    if (isNaN(calibration.length)) {
                        alert('Invalid Length');
                    }
                    else {
                        var cell = seriesManagerService.get_activeCell();
                        var automation = cell.get_automation();                        
                        var annObject: lt.Annotations.Engine.AnnPolyRulerObject = <lt.Annotations.Engine.AnnPolyRulerObject>automation.get_currentEditObject();
                        var unit: number = parseInt(calibration.unit, 10); 

                        if (!calibration.applyToAll) {
                            var container: lt.Annotations.Engine.AnnContainer = automation.get_containers().item(seriesManagerService.get_activeSubCellIndex(cell));                            

                            container.get_mapper().calibrate(annObject.getRulerLength(1), 0, lt.LeadLengthD.create(calibration.length), unit);
                            annObject.measurementUnit = unit;
                        }
                        else {
                            var length = cell.get_frames().count; 

                            while (length--) {
                                var container: lt.Annotations.Engine.AnnContainer = automation.get_containers().item(length);                               

                                container.get_mapper().calibrate(annObject.getRulerLength(1), 0, lt.LeadLengthD.create(calibration.length), unit);  
                                container.children.toArray().forEach(function (item: lt.Annotations.Engine.AnnObject, index: number) {
                                    if (item instanceof lt.Annotations.Engine.AnnPolyRulerObject) {
                                        (<lt.Annotations.Engine.AnnPolyRulerObject>item).measurementUnit = unit;
                                    }
                                });                                                                                                                            
                            }
                        }
                    }
                    
                    automation.get_automationControl().automationInvalidate(lt.LeadRectD.empty);
                });
            }
        }
    }
}]);

function setAnnTool(toolbarService: ToolbarService, tabService: TabService, buttonId: string, tool: number) {
    if (toolbarService.isEnabled(buttonId)) {
        SetCurrentInteractiveMode(toolbarService, tabService, tool, buttonId,false); 
        enumerateCell(tabService, function (cell:lt.Controls.Medical.Cell) {
            //var command = cell.getCommand(MedicalViewerAction.Offset2);

            //if (command != null && command.isStarted) {
            //    cell.stopCommand(MedicalViewerAction.Offset2);
            //}
            CommandManager.RunCommand(cell, tool, buttonId);
            //cell.runCommand(tool);                        
        });
    }
}