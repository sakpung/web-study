// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
class DicomLoader {
    private _objectRetrieveService: ObjectRetrieveService;
    private _queryArchiveService: QueryArchiveService;
    private _objectStoreService: ObjectStoreService;
    private _eventService: EventService;
    private _qService: ng.IQService;
    private _seriesManagerService: SeriesManagerService;
    private _authenticationService: AuthenticationService;

    public SupportWindowLevel: boolean;
    private _retrieveLocalUrl: string;

   static $inject = ["retrieveLocalUrl", "authenticationService", "objectRetrieveService", "eventService", "queryArchiveService", "$q", "seriesManagerService", "objectStoreService"];
    constructor(retrieveLocalUrl: string, authenticationService: AuthenticationService, objectRetrieveService: ObjectRetrieveService, eventService: EventService, queryArchiveService: QueryArchiveService, $q: ng.IQService, seriesManagerService: SeriesManagerService, objectStoreService:ObjectStoreService) {
        this._objectRetrieveService = objectRetrieveService;
        this._queryArchiveService = queryArchiveService;
        this._objectStoreService = objectStoreService;
        this._eventService = eventService;
        this._qService = $q;
        this._seriesManagerService = seriesManagerService;
        this._retrieveLocalUrl = retrieveLocalUrl;
        this._authenticationService = authenticationService;
    }

    public loadSeries(cell: lt.Controls.Medical.Cell, stackInstanceUIDs: Array<string>, template: Models.Template, generateMRTI:boolean, mrtiCell?, loadLayout?: boolean) {
        var self = this;
        var seriesInstanceUID: string = cell.get_seriesInstanceUID();
        var id: string = cell.divID;

        //if (loadLayout) {

        //    return this.loadLayout(seriesInstanceUID, id, template)
        //        .then(function () {
        //            self._eventService.publish(EventNames.MrtiInfoReady, { seriesInstanceUID: seriesInstanceUID });
        //            self.getInfo(seriesInstanceUID, id, stackInstanceUIDs, null);
        //        }.bind(this));
        //}
        //else {
            self._eventService.publish(EventNames.OnLoadLayout, { layout: "", seriesInstanceUID: seriesInstanceUID, id: id, template: "" });
            self._eventService.publish(EventNames.MrtiInfoReady, { seriesInstanceUID: seriesInstanceUID });
            self.getInfo(seriesInstanceUID, id, stackInstanceUIDs, null);
        
        //}
    }  
    
    private getInfo(seriesInstanceUID: string, id: string, stackInstanceUIDs: Array<string>, presentationInfo: any) {        
        
        this.findSeriesInstances(seriesInstanceUID, id, stackInstanceUIDs)
            .then(function (result) {
                this.getDicomJSON(result, id).then(function (data) {
                    this.setImageInformation(presentationInfo, seriesInstanceUID, id);
                    this.loadPresentationState(data, id, stackInstanceUIDs);
                }.bind(this));
            }.bind(this));
    } 

    private setImageInformation(presentationInfo, seriesInstanceUID, id: string) {
        var cell: lt.Controls.Medical.Cell = this._seriesManagerService.get_seriesCellById(id);

        if (cell != null && cell.frames.count > 0) {
            var instances: Array<any> = this._seriesManagerService.get_instances(cell.seriesInstanceUID, id);
            var __this = this;
            var frameArray: Array<lt.Controls.Medical.Frame> = cell.frames.toArray();

            if (instances) {
                var instanceLength: number = instances.length;
                var lastIndex = 0;
                var numFrames = instances[0].NumberOfFrames;

                for (var instanceCounter = 0; instanceCounter < instanceLength; instanceCounter++) {
                    var instance = instances[instanceCounter];

                    if (instance != null && instance.Pages != null && instance.Pages.length>0) {
                        var framesLength = instance.Pages.length;
                        var currentPageInfo;
                        var pageInfo = instance.Pages[0];
                        for (var index = 0; index < framesLength; index++) {
                            if ((index + lastIndex) < cell.frames.count) {
                                var cellFrame: lt.Controls.Medical.Frame;

                                if (numFrames == 1) {
                                   cellFrame = Utils.findFirst(frameArray, function (frame: lt.Controls.Medical.Frame) {
                                        var cellFrameInstance = (<any>frame).Instance;

                                        if (cellFrameInstance) {
                                            return cellFrameInstance.SOPInstanceUID == instance.SOPInstanceUID;
                                        }

                                        return false;
                                    });
                                }
                                else {  
                                    cellFrame = cell.frames.item(index + lastIndex);                                 
                                }

                                currentPageInfo = instance.Pages[index];
                                if (currentPageInfo != null) {

                                    if (pageInfo.TileSize.width != 0)
                                        pageInfo = currentPageInfo;
                                }

                                var supportWindowLevel = pageInfo.SupportWindowLevel;

                                if (pageInfo.ImagePositionPatientArray != null) {
                                    cellFrame.set_imagePosition(pageInfo.ImagePositionPatientArray);
                                }

                                if (pageInfo.ImageOrientationPatientArray != null) {
                                    cellFrame.set_imageOrientation(pageInfo.ImageOrientationPatientArray);
                                }

                                if (pageInfo.PatientOrientation != null) {
                                    cellFrame.set_patientProjection(pageInfo.PatientOrientation);
                                }

                                if (pageInfo.PixelSpacingPatientArray != null && pageInfo.PixelSpacingPatientArray.length == 2) {
                                    cellFrame.set_rowSpacing(parseFloat(pageInfo.PixelSpacingPatientArray[1]));
                                    cellFrame.set_columnSpacing(parseFloat(pageInfo.PixelSpacingPatientArray[0]));
                                }

                                {
                                    var mrtiInfo: lt.Controls.Medical.MRTIImage = new lt.Controls.Medical.MRTIImage();

                                    mrtiInfo.imageUri = this._retrieveLocalUrl + '/GetImageTile?auth=' + encodeURIComponent(this._authenticationService.authenticationCode) + '&instance=' + instance.SOPInstanceUID;
                                    
                                    mrtiInfo.imageName = pageInfo.ImageName;
                                    mrtiInfo.mimeType = pageInfo.MimeType;

                                    mrtiInfo.fullDpi = lt.LeadSizeD.create(150, 150);
                                    mrtiInfo.tileSize = lt.LeadSizeD.create(pageInfo.TileSize.width, pageInfo.TileSize.height);
                                    mrtiInfo.frameIndex = index;
                                    mrtiInfo.supportWindowLevel = supportWindowLevel && !cellFrame.isWaveForm;

                                    mrtiInfo.resolutions = [];
                                    for (var i = 0; i < pageInfo.Resolutions.length; i++) {
                                        mrtiInfo.resolutions[i] = lt.LeadSizeD.create(pageInfo.Resolutions[i].width, pageInfo.Resolutions[i].height);
                                    }

                                    cellFrame.set_width(mrtiInfo.resolutions[0].width);
                                    cellFrame.set_height(mrtiInfo.resolutions[0].height);
                                    mrtiInfo.fullSize = lt.LeadSizeD.create(cellFrame.get_width(), cellFrame.get_height());

                                        
                                    cellFrame.mrtiInfo = mrtiInfo;
                                }
                            }

                        }
                        lastIndex += framesLength;
                    }
                }
            }
            else {
                setTimeout($.proxy(function () {
                    __this.setImageInformation(presentationInfo, seriesInstanceUID, id);
                }, this), 350);
            }
        }
    } 

    public getSeriesStacks(seriesIntanceUID: string): ng.IPromise<any> {
        var __this = this;

        return this._objectRetrieveService.GetSeriesStacks(seriesIntanceUID).then(function (data) {
            if (data.data != null) {
                return { stacks: data.data };
            }
        });
    }

    public loadFrameDicomJSON(cellFrame, doEvent?: boolean): ng.IPromise<any> {
        var __this = this;

        return this._objectRetrieveService.GetDicomJSON(cellFrame.Instance.StudyInstanceUID, cellFrame.Instance.SeriesInstanceUID, cellFrame.Instance.SOPInstanceUID).then(function (data) {
            if (data.data != null) {
                var metadata = JSON.parse(data.data);
                var information = DicomHelper.GetDicomImageInformation(metadata);
                var publish = doEvent || true;

                cellFrame.set_information(information);
                cellFrame.set_imagePosition(information.position);
                if (information.orientation)
                cellFrame.set_imageOrientation(information.orientation);
                cellFrame.set_imageType(information.imageType);
                cellFrame.set_lossyCompression(information.lossyImageCompression);
                cellFrame.metadata = metadata;
                cellFrame.JSON = metadata;
                cellFrame.isWaveForm = information.isWaveForm; 

                cellFrame.set_width(information.get_width());
                cellFrame.set_height(information.get_height());

                cellFrame.set_rowSpacing(information.rowSpacing);
                cellFrame.set_columnSpacing(information.columnSpacing);
                cellFrame.originalSize = { width: information.get_width(), height: information.get_height() };

                if (publish) {
                    __this._eventService.publish(EventNames.ImageInformationReady, { seriesInstanceUID: cellFrame.Instance.SeriesInstanceUID, frameIndex: cellFrame.FrameIndex });
                }
                __this._eventService.publish(EventNames.LoadedDicomJSON, { seriesInstanceUID: cellFrame.Instance.SeriesInstanceUID, cellFrame: cellFrame });
                return { xmlData: data, cellFrame: cellFrame };
            }
        });
    }

    public loadLayout(seriesInstanceUID: string, id: string, template:Models.Template): ng.IPromise<any> {
        var __this = this;

        return this._objectRetrieveService.GetSeriesLayout(seriesInstanceUID, '')
            .then(function (layout) {
                __this._eventService.publish(EventNames.OnLoadLayout, { layout: layout.data, seriesInstanceUID: seriesInstanceUID, id: id, template: template });
                return { seriesInstanceUID: seriesInstanceUID, layout: layout.data };
            });
    }
    
    private loadPresentationInfo(seriesInstanceUID: string, id: string, stackInstanceUIDs?: Array<string>): ng.IPromise<any> {
        var __this = this;
       
        return this._objectRetrieveService.GetPresentationInfo(seriesInstanceUID).then(function (data) {
            var presentationInfo: Array<any> = data.data;
            
            if (stackInstanceUIDs && stackInstanceUIDs.length > 0) {
                presentationInfo = $.grep(presentationInfo, function (item: any, index: number) {
                    return stackInstanceUIDs.indexOf(item.SOPInstanceUID) >= 0;
                });
            }

            __this._eventService.publish(EventNames.OnPresentationInfoLoaded, { seriesInstanceUID: seriesInstanceUID, presentationInfo: presentationInfo, id: id });
            return { seriesInstanceUID: seriesInstanceUID, presentationInfo: presentationInfo, id: id };
        });
    }

    private loadPresentationState(result, id: string, stackInstanceUIDs?: Array<string>): ng.IPromise<any> {
        var __this = this;

        return this._queryArchiveService.FindPresentationState(result.seriesInstanceUID).then(function (data) {
            var annotations: Array<any> = data.data;

            if (stackInstanceUIDs && stackInstanceUIDs.length > 0) {
                annotations = $.grep(annotations, function (item: any, index: number) {
                    var sops: Array<string> = $.grep(item.ReferencedSOPInstanceUIDs, function (item: any, index: number) {
                        return stackInstanceUIDs.indexOf(item) >= 0;
                    });

                    return sops.length > 0;                    
                });
            }
            __this._eventService.publish(EventNames.PresentationStateLoaded, { seriesInstanceUID: result.seriesInstanceUID, annotations: annotations, id:id });
        });
    }

    private findSeriesInstances(seriesInstanceUID: string, id: string, stackInstanceUIDs?: Array<string>): ng.IPromise<any> {
        var __this = this;
        var query: Models.QueryOptions = new Models.QueryOptions();
        var stackInstanceUID = angular.isDefined(stackInstanceUIDs) && (stackInstanceUIDs != null) && stackInstanceUIDs.length > 0 ? stackInstanceUIDs[0] : '';

        query.SeriesOptions.SeriesInstanceUID = seriesInstanceUID;
        return this._queryArchiveService.FindInstances(query, stackInstanceUID).then(function (data) {
            var instances: Array<any> = data.data;
            var presentationInfo = __this._seriesManagerService.get_presentationInfo(seriesInstanceUID, id);

            /*if (stackInstanceUIDs && stackInstanceUIDs.length > 0) {
                instances = $.grep(instances, function (item: any, index: number) {
                    if (item != null)
                    return stackInstanceUIDs.indexOf(item.SOPInstanceUID) >= 0;
                    else
                        return false;
                });
            }*/

            if (stackInstanceUIDs && stackInstanceUIDs.length > 0) {
                var index = 0;
                var length = stackInstanceUIDs.length;
                var output: any = [];
                var itemIndex;
                var j;

                for (index = 0; index < length; index++) {

                    for (j = 0; j < instances.length; j++) {
                        if (instances[j] != null) {
                            if (stackInstanceUIDs[index] == instances[j].SOPInstanceUID) {
                                output.add(instances[j]);
                                break;
                            }
                        }
                    }
                }

                instances = output;
            }

            __this._eventService.publish(EventNames.OnInstancesFound, { seriesInstanceUID: seriesInstanceUID, instances: instances, id: id, stackInstanceUID: stackInstanceUID });


            return { seriesInstanceUID: seriesInstanceUID, instances: instances, id: id };
        });
    }   

    private getDicomJSON(result, id: string): ng.IPromise<any> {
        var instance = result.instances[0];
        var __this = this;

        return this._objectRetrieveService.GetDicomJSON(instance.StudyInstanceUID, instance.SeriesInstanceUID, instance.SOPInstanceUID)
            .then(function (data) {
                var metadata = JSON.parse(data.data);

                __this._eventService.publish(EventNames.OnDicomJSONRetrieved, {
                    seriesInstanceUID: result.seriesInstanceUID,
                    instances: result.instances,
                    metadata: metadata,
                    id: id,
                    sopInstanceUID: instance.SOPInstanceUID
                });
                __this._eventService.publish(EventNames.LoadedDicomJSON, { seriesInstanceUID: result.seriesInstanceUID, cellFrame: null, id: id });
                return { seriesInstanceUID: result.seriesInstanceUID, instances: result.instances, metadata: metadata };
            });
    }

    private sortInstances(instance1, instance2) {
        return parseInt(instance1.InstanceNumber) - parseInt(instance2.InstanceNumber);
    }

    private getDataSize(dicomData): lt.LeadSizeD {
        var imageWidthTag = DicomHelper.getDicomTag(dicomData, DicomTag.Columns);
        var imageHeightTag = DicomHelper.getDicomTag(dicomData, DicomTag.Rows);
        var width;
        var height;
        var maxSize = Utils.isTabletOrMobile() ? 256 : 512;

        if (imageWidthTag != null && imageWidthTag.length > 0) {
            width = parseInt(DicomHelper.GetTagText(imageWidthTag[0]), 10);
        }
        else {
            width = 512;
        }

        if (imageHeightTag != null && imageHeightTag.length) {
            height = parseInt(DicomHelper.GetTagText(imageHeightTag[0]), 10);
        }
        else {
            height = 512;
        }

        var newWidth = width;
        var newHeight = height;

        if (Math.max(width, height) < maxSize)
            return lt.LeadSizeD.create(newWidth, height);

        if (width > height) {
            newWidth = maxSize;
            newHeight = height * maxSize / width;
        }
        else {
            newHeight = maxSize;
            newWidth = width * maxSize / height;
        }

        return lt.LeadSizeD.create(parseInt(newWidth), parseInt(newHeight));
    }
}