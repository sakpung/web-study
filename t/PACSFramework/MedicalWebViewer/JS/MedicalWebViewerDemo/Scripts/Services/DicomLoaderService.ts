// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
class DicomLoaderService {
    static $inject = ['app.config', 'authenticationService', 'eventService', 'objectRetrieveService', 'queryArchiveService', 'seriesManagerService', '$q', 'overlayManagerService', 'optionsService', '$timeout', 'cinePlayerService', 'objectStoreService', 'templateService'];

    private _cellInfo: any;
    private _eventService: EventService;
    private _objectRetrieveService: ObjectRetrieveService;
    private _queryArchiveService: QueryArchiveService;
    private _seriesManagerService: SeriesManagerService;
    private _qService: ng.IQService;
    private _overlayManagerService: OverlayManagerService;
    private _optionsService: OptionsService;
    private _objectStoreService: ObjectStoreService;
    private _timeout: ng.ITimeoutService;
    private _cinePlayerService: CinePlayerService;
    private _templateService: TemplateService;
    private _authenticationService: AuthenticationService;
    private _retrieveLocalUrl: string;

    constructor(config, authenticationService, eventService: EventService, objectRetrieveService: ObjectRetrieveService, queryArchiveService: QueryArchiveService, seriesManagerService: SeriesManagerService,
        $q: ng.IQService, overlayManagerService: OverlayManagerService, optionsService: OptionsService, $timeout: ng.ITimeoutService, cinePlayerService: CinePlayerService, objectStoreService:ObjectStoreService, templateService:TemplateService) {
        this._eventService = eventService;
        this._objectRetrieveService = objectRetrieveService;
        this._queryArchiveService = queryArchiveService;
        this._objectStoreService = objectStoreService;
        this._seriesManagerService = seriesManagerService;
        this._qService = $q;
        this._overlayManagerService = overlayManagerService;
        this._optionsService = optionsService;        
        this._timeout = $timeout;
        this._cinePlayerService = cinePlayerService;
        this._templateService = templateService;
        this._authenticationService = authenticationService;
        this._retrieveLocalUrl = config.urls.serviceUrl + config.urls.objectRetrieveLocalServiceName;

        this._cellInfo = {};

        this._eventService.subscribe(EventNames.OnLoadLayout, this.onLoadLayout.bind(this));
        this._eventService.subscribe(EventNames.OnPresentationInfoLoaded, this.onPresentationInfoLoaded.bind(this));
        this._eventService.subscribe(EventNames.OnInstancesFound, this.onInstancesFound.bind(this));
        this._eventService.subscribe(EventNames.OnDicomJSONRetrieved, this.onDicomJSONRetrieved.bind(this));
        this._eventService.subscribe(EventNames.PresentationStateLoaded, this.onPresentationStateLoaded.bind(this));              
    }

    public loadSeries(cell: lt.Controls.Medical.Cell, stackInstanceUIDs: Array<string>, template: Models.Template, generateMRTI: boolean, mrtiCell?: any, loadSeriesLayout?: boolean) {
        var loader: DicomLoader = this._seriesManagerService.get_seriesLoaderById(cell);

        if (!loader) {
            loader = new DicomLoader(this._retrieveLocalUrl, this._authenticationService, this._objectRetrieveService, this._eventService, this._queryArchiveService, this._qService, this._seriesManagerService, this._objectStoreService);

            this._seriesManagerService.set_seriesLoader(cell, loader);
        }        
        
        loader.loadSeries(cell, stackInstanceUIDs, template, false, mrtiCell, loadSeriesLayout);
    }

    public get_newLoader(): DicomLoader {
        return new DicomLoader(this._retrieveLocalUrl, this._authenticationService, this._objectRetrieveService, this._eventService, this._queryArchiveService, this._qService, this._seriesManagerService, this._objectStoreService);
    }

    private onLoadLayout(event, data) {
        this._seriesManagerService.set_layout(data.args.seriesInstanceUID, data.args.id, data.args.layout, data.args.template);
    }

    private onPresentationInfoLoaded(event, data) {
        this._seriesManagerService.set_presentationInfo(data.args.seriesInstanceUID, data.args.id, data.args.presentationInfo);
    }

    private onInstancesFound(event, data) {
        this._seriesManagerService.set_instances(data.args.seriesInstanceUID, data.args.id, data.args.instances, data.args.stackInstanceUID);
    }

    private onDicomJSONRetrieved(event, data) {
        var cell: lt.Controls.Medical.Cell = this._seriesManagerService.get_seriesCellById(data.args.id);

        if (cell != null) {
            this.LoadImages(data.args.seriesInstanceUID, data.args.id, data.args.metadata, data.args.sopInstanceUID);
        }
    }

    private onPresentationStateLoaded(event, data) {
        this._seriesManagerService.set_annotationIDs(data.args.seriesInstanceUID, data.args.id, data.args.annotations);
        this._eventService.publish(EventNames.AnnotationsLoaded, { seriesInstanceUID: data.args.seriesInstanceUID, id: data.args.id });
    }     

    private getLateralityValue(metadata) {
        var element;

        element = metadata[DicomTag.Laterality];
        if (element && element.Value && element.Value.length > 0) {
            return DicomHelper.GetTagText(element);
        }

        element = metadata[DicomTag.ImageLaterality];
        if (element && element.Value && element.Value.length > 0) {
            return DicomHelper.GetTagText(element);
        }

        element = metadata[DicomTag.FrameLaterality];
        if (element && element.Value && element.Value.length > 0) {
            return DicomHelper.GetTagText(element);
        }
        return "";
    }

    public UpdateCineSettings(cell, metadata) {
        var preferredPlaybackSequencing = DicomHelper.getDicomTagValue(metadata, DicomTag.PreferredPlaybackSequencing);
        if (preferredPlaybackSequencing != undefined) {
            cell.cinePlayer.direction = (preferredPlaybackSequencing == 1) ? lt.Controls.Medical.PlayingDirection.sweep : lt.Controls.Medical.PlayingDirection.forward;
        }

        var recommendedDisplayFrameRate = DicomHelper.getDicomTagValue(metadata, DicomTag.RecommendedDisplayFrameRate);
        var cineRate = DicomHelper.getDicomTagValue(metadata, DicomTag.CineRate);
        if (cineRate == undefined)
            cineRate = recommendedDisplayFrameRate;
        if (cineRate != undefined) {
            if (cineRate == 0)
                cell.cinePlayer.FPS = 30;
            else
                cell.cinePlayer.FPS = parseInt(cineRate);
        }
        else {
            var frameDelay = DicomHelper.getDicomTagValue(metadata, DicomTag.FrameDelay);
            var frameTime = DicomHelper.getDicomTagValue(metadata, DicomTag.FrameTime);
            var imageTriggerDelay = DicomHelper.getDicomTagValue(metadata, DicomTag.ImageTriggerDelay);
            var actualFrameDuration = DicomHelper.getDicomTagValue(metadata, DicomTag.ActualFrameDuration);

            if (frameTime == undefined)
                frameTime = imageTriggerDelay
            if (frameTime == undefined)
                frameTime = frameDelay;
            if (frameTime == undefined)
                frameTime = actualFrameDuration;

            if (frameTime != undefined) {
                frameTime = parseFloat(frameTime);
                cell.cinePlayer.FPS = parseInt((1000 / frameTime).toString());
            }
            else {
                var effectiveDuration = DicomHelper.getDicomTagValue(metadata, DicomTag.EffectiveDuration);
                if (effectiveDuration != undefined) {
                    effectiveDuration = parseFloat(effectiveDuration);
                    cell.cinePlayer.FPS = parseInt(((effectiveDuration * 1000) / cell.frames.count).toString());
                }
            }
        }
                //var startTrim = DicomHelper.getDicomTagValue(metadata, DicomTag.StartTrim);
                //var stopTrim = DicomHelper.getDicomTagValue(metadata, DicomTag.StopTrim);
    }

    private AddTag(text: string, index: number) {
        var newOverlay: lt.Controls.Medical.OverlayText = new lt.Controls.Medical.OverlayText();

        newOverlay.text = text;
        newOverlay.type = lt.Controls.Medical.OverlayTextType.userData;
        newOverlay.positionIndex = index;
        newOverlay.weight = 1;
        newOverlay.alignment = lt.Controls.Medical.OverlayAlignment.topLeft;

        return newOverlay;
    }


    private AddLabels(item, metadata) {
        if (item.forCompare) {
            var patientId = DicomHelper.getPatientName(metadata, DicomTag.PatientName);
            var StudyDescription = DicomHelper.GetTagTextValue(metadata, DicomTag.StudyDescription);
            var StudyDate = DicomHelper.parseDicomDate(DicomHelper.GetTagTextValue(metadata, DicomTag.StudyDate));
            var SeriesDate = DicomHelper.parseDicomDate(DicomHelper.GetTagTextValue(metadata, DicomTag.SeriesDate));
            var SeriesDescription = DicomHelper.GetTagTextValue(metadata, DicomTag.SeriesDescription);

            var cell: lt.Controls.Medical.Cell = item;

            if (cell.labels.count != 0)
                return;

            cell.labels.add(this.AddTag(patientId, 0));

            cell.labels.add(this.AddTag(StudyDescription, 2));
            cell.labels.add(this.AddTag(StudyDate, 3));

            cell.labels.add(this.AddTag(SeriesDescription, 5));
            cell.labels.add(this.AddTag(SeriesDate, 6));

        }
    }


    private updateJSON(__this, cellFrame, metadata, doEvent, template, frameIndex? : number) {
        if (metadata != null) {


            var frame: lt.Controls.Medical.Frame = cellFrame;

            var cell: lt.Controls.Medical.Cell = cellFrame.parentCell;

            var information = DicomHelper.GetDicomImageInformation(metadata, frameIndex);
            __this.AddLabels(cell, metadata);




            __this.UpdateCineSettings(cell, metadata);

            var publish = doEvent || true;

            cellFrame.set_imagePosition(information.position);
            if (information.orientation)
                cellFrame.imageOrientation = information.orientation;
            cellFrame.viewPosition = information.viewPosition;
            cellFrame.set_imageType(information.imageType);
            cellFrame.set_lossyCompression(information.lossyImageCompression);
            cellFrame.metadata = metadata;
            cellFrame.JSON = metadata;
            cellFrame.isWaveForm = information.isWaveForm;
            cellFrame.set_information(information);
            var laterality: string = __this.getLateralityValue(metadata);
            if (laterality != "") {
                cellFrame.laterality = laterality;
            }


            cellFrame.set_rowSpacing(information.rowSpacing);
            cellFrame.set_columnSpacing(information.columnSpacing);
            cellFrame.originalSize = { width: information.get_width(), height: information.get_height() };


            if (template) {
                if (!__this._seriesManagerService.map_frame(cellFrame)) {
                    __this._eventService.publish(EventNames.InstanceOverflow, { instance: (<any>cellFrame).Instance, metadata: (<any>cellFrame).metadata, frame: 0, parentCell: cellFrame.parentCell });
                }
            }
            if (publish) {
                __this._eventService.publish(EventNames.ImageInformationReady, { seriesInstanceUID: cellFrame.Instance.SeriesInstanceUID, frameIndex: cellFrame.FrameIndex });
            }
            __this._eventService.publish(EventNames.LoadedDicomJSON, { seriesInstanceUID: cellFrame.Instance.SeriesInstanceUID, cellFrame: cellFrame });
            return { xmlData: metadata, cellFrame: cellFrame };
        }
    }

    public loadFrameDicomJSON(cellFrame, template: Models.Template, frameIndex? : number, doEvent?: boolean, json?): ng.IPromise<any> {
        var __this = this;
        var __frame = cellFrame;
        var __doEvent = doEvent;
        var __template = template;

        if (json)
            __this.updateJSON(__this, __frame, json, __doEvent, __template, frameIndex);
        else {
            return this._objectRetrieveService.GetDicomJSON(cellFrame.Instance.StudyInstanceUID, cellFrame.Instance.SeriesInstanceUID, cellFrame.Instance.SOPInstanceUID).then(function (data) {

                var metadata = JSON.parse(data.data);

                return __this.updateJSON(__this, __frame, metadata, __doEvent, __template);
            });
        }
    }

    private LoadImages(seriesInstanceUID: string, id: string, metadata, dataSopInstanceUID: string) {
        var instances: Array<any> = this._seriesManagerService.get_instances(seriesInstanceUID, id);
        var framesLength: number = 0;
        var multiFrame: boolean = instances.length == 1;
        var cell: lt.Controls.Medical.Cell = this._seriesManagerService.get_seriesCellById(id);
        var loader: DicomLoader = this._seriesManagerService.get_seriesLoaderById(cell);
        var information;
        var __this = this;
        var presentationInfo = this._seriesManagerService.get_presentationInfo(seriesInstanceUID, id);
        var template: Models.Template = this._seriesManagerService.get_template(seriesInstanceUID, id);

        if (multiFrame) {
            //framesLength = this.getNumberOfFrames(metadata);
            framesLength = instances[0].NumberOfFrames;
        }
        else {
            framesLength = instances.length;
        }        

        var imageDownloaded = function (e, args) {
            if (multiFrame) {
                if (cell.frames.indexOf(args.frame) == 0)
                    __this.loadFrameDicomJSON(args.frame, template, 0, true, metadata);
                    var json = cell.frames.get_item(0).metadata;
                    var frameIndex;
                    for (frameIndex = 1; frameIndex < instance.NumberOfFrames; frameIndex++) {
                        __this.loadFrameDicomJSON(cell.frames.get_item(frameIndex), template, frameIndex, true, metadata);
                    }

                __this._eventService.publish(EventNames.ActiveSeriesChanged, { seriesInstanceUID: seriesInstanceUID, id: cell.divID });
            }
            else
                __this.loadFrameDicomJSON(args.frame, template);

        }

        var progressCompleted = function (e, args) {
            cell.remove_imageDownloaded(imageDownloaded);
            cell.remove_progressCompleted(progressCompleted);
        }
        
        var cellDispose = function (e, args) {
            var cell: lt.Controls.Medical.Cell = e;
            cell.remove_imageDownloaded(imageDownloaded);
            cell.remove_progressCompleted(progressCompleted);
            cell.remove_disposing(cellDispose);
        }
        

        cell.add_imageDownloaded(imageDownloaded);
        cell.add_progressCompleted(progressCompleted);
        cell.add_disposing(cellDispose);

        

        if (lt.LTHelper.device == lt.LTDevice.mobile) {
            if (framesLength >= __this._optionsService.get(OptionNames.LazyLoadingMobileThreshold)) {
                cell.fullDownload = false;
            }
        }
        else {
            if (framesLength >= __this._optionsService.get(OptionNames.LazyLoadingThreshold)) {
                cell.fullDownload = false;
            }
        }

        cell.marginFramesCount = __this._optionsService.get(OptionNames.LazyLoadingBuffer);


        var modality = DicomHelper.GetTagText(metadata[DicomTag.Modality]);



        (<any>cell).length = Math.min(framesLength, cell.get_imageViewer().get_items().count);
        cell.get_progress().set_totalFrames(instances.length);
        cell.studyInstanceUID = DicomHelper.GetTagText(metadata[DicomTag.StudyInstanceUID]);
        for (var instanceIndex = 0; instanceIndex < instances.length; instanceIndex++) {
            var instance = instances[instanceIndex];

            if (instance == null)
                continue;         

            for (var frameIndex = 0; frameIndex < instance.NumberOfFrames; frameIndex++) {
                var cellFrame = this._seriesManagerService.get_cellFrame(seriesInstanceUID, id, instance.SOPInstanceUID, modality != "IO");

                if (cellFrame == undefined) {
                    //
                    // We have a layout but the specified image is not contained in the layout.
                    // Need to add the image to overflow.
                    //
                    this._eventService.publish(EventNames.InstanceOverflow, { instance: instance, xml: metadata, frame: frameIndex, parentCell: cell });                   

                    cellFrame = new lt.Controls.Medical.Frame(cell);
                   
                    //cellFrame.add_imageDrawn(this.OnImageDrawn.bind(this));
                    cell.get_frames().add(cellFrame);
                }                                



                var imageDataReady = function (e) {
                    var cell: lt.Controls.Medical.Cell = cellFrame.parentCell;
                                                       
                    cellFrame.remove_imageDataReady(imageDataReady);

                    __this._eventService.publish(EventNames.ImageDataReady, { cellFrame: cellFrame, id: cell.divID });
                    if (__this._templateService.currentStudyLayout && cellFrame["Instance"]) {
                        if (!angular.isDefined(cell["LoadedPresentationState"])){
                            var seriesInstanceUID = cell.seriesInstanceUID;
                            var sopInstanceUID = cellFrame["Instance"].SOPInstanceUID;
                            var instances: Array<any> = __this._seriesManagerService.get_instances(seriesInstanceUID, cell.divID);

                            var box: Models.ImageBox = null;

                            if (__this._templateService.currentStudyLayout.Boxes) {
                                Utils.findFirst(__this._templateService.currentStudyLayout.Boxes, function (box: Models.ImageBox) {
                                    var sopBox = Utils.findFirst(instances, function (instance) {
                                        return instance.SOPInstanceUID == box.referencedSOPInstanceUID;
                                    });

                                    if (sopBox && box.ReferencedPresentationStateSOP.length > 0)
                                        return true;
                                    return false;
                                });
                            }

                            if (box) {
                                __this._objectRetrieveService.GetPresentationAnnotations(box.ReferencedPresentationStateSOP, '').then(function (result) {
                                    if (result.status == 200) {
                                        if (result.data && result.data.length > 0) {
                                            var xmlAnnotations: Document = $.parseXML(result.data);

                                            __this._seriesManagerService.add_annotations((<lt.Controls.Medical.Frame>cellFrame).parentCell, xmlAnnotations);
                                            cell["LoadedPresentationState"] = true;
                                        }
                                        else {                                            
                                        }                                        
                                    }
                                }, function (error) {                                   
                                });
                            }
                        }
                    }
                }

                cellFrame.add_imageDataReady(imageDataReady);
                cellFrame.set_instanceNumber(instance.InstanceNumber);
                cellFrame.metadata = (instanceIndex == 0) ? metadata : null;
                cellFrame.Instance = instance;
                cellFrame.FrameNumber = frameIndex + 1;
                cellFrame.FrameIndex = frameIndex;
                cellFrame.SeriesInstanceUID = seriesInstanceUID;
                cellFrame.enableDraw = true;
                
                if (instance.SOPInstanceUID == dataSopInstanceUID) {                    
                    if (frameIndex == 0) {                        
                        information = DicomHelper.GetDicomImageInformation(metadata, frameIndex);


                        cellFrame.set_information(information);
                        cellFrame.set_imagePosition(information.position);
                        cellFrame.set_imageType(information.imageType);
                        cellFrame.set_lossyCompression(information.lossyImageCompression);
                        cellFrame.isWaveForm = information.isWaveForm; 

                        loader.SupportWindowLevel = DicomHelper.supportWindowLevel(cell, frameIndex);

                        cellFrame.set_width(information.width);
                        cellFrame.set_height(information.height);

                        cellFrame.set_rowSpacing(information.rowSpacing);
                        cellFrame.set_columnSpacing(information.columnSpacing);
                        cellFrame.originalSize = { width: information.width, height: information.height };

                        cell.set_patientName(DicomHelper.getPatientName(metadata, DicomTag.PatientName));
                        cell.set_seriesNumber(DicomHelper.getDicomTagValue(metadata, DicomTag.SeriesNumber));
                        cell.set_frameOfReferenceUID(information.frameOfReferenceUID);                    

                        this._overlayManagerService.set_cellOverlays(cell, cellFrame.metadata, cellFrame.isWaveForm);

                    }
                    else {
                        information = DicomHelper.GetDicomImageInformation(metadata);                        
                        cellFrame.set_information(information);
                        cellFrame.originalSize = { width: information.get_width(), height: information.get_height() };
                        cellFrame.set_width(information.width);
                        cellFrame.set_height(information.height);
                        cellFrame.isWaveForm = information.isWaveForm; 
                    }                    
                }
                else {
                }                
            }
        }

        var emptyFrames = $.grep(cell.get_frames().toArray(), function (f: any) {
            return !angular.isDefined(f.Instance);
        });

        $.each(emptyFrames, function (index, value: lt.Controls.Medical.Frame) {
            var subCell = value.subCell;

            value.enableDraw = false;
            if (subCell != null) {
                subCell.backColor = __this._optionsService.get(OptionNames.EmptyCellBackgroundColor);
            }
        });

        this._eventService.publish(EventNames.LoadingSeriesFrames, { seriesInstanceUID: seriesInstanceUID, id: id });


        this.updateMPRWithOverlays(cell);
    }

    private updateMPRWithOverlays(cell : lt.Controls.Medical.Cell) {
        if (cell.derivatives.count != 0) {
            var index = 0;
            var length = cell.derivatives.count;

            for (index = 0; index < length; index++) {
                copyOverlays(cell.derivatives.get_item(index), cell);
            }
        }
    }

    private getNumberOfFrames(xmlData): number {
        var numberOfFrames = DicomHelper.getDicomTag(xmlData, DicomTag.NumberOfFrames);

        if (null != numberOfFrames && numberOfFrames.length > 0) {
            return parseInt(numberOfFrames.text());
        }
        else {
            return 1;
        }
    }           
}

services.service('dicomLoaderService', DicomLoaderService);