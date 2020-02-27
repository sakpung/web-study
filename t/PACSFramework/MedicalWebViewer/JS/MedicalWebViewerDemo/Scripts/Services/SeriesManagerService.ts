// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
declare var Interpreter: any;

class SeriesManagerService {
    static $inject = ['eventService', 'optionsService', 'dialogs', '$translate', '$modal'];

    private _series: any;
    private _activeCell:lt.Controls.Medical.Cell;
    private _eventService: EventService;
    private _optionsService: OptionsService;
    private _stroke: lt.Annotations.Engine.AnnBrush;
    private _textColor: lt.Annotations.Engine.AnnBrush;
    private _hilightColor: lt.Annotations.Engine.AnnBrush;
    private _dialogs: any;  
    private _errorTitle: string;  
    private _notifyTitle: string;
    private _annotations: string;
    private _loaded: string;
    private _modal: any;
    private _currentLoadingSeries: any;
    private _currentPatientSeries: Array<any>;
    private _overflowImages;
    private _showStudyTimeLine;
    private _structuredDisplayList;
    private _currentStructuredDisplay;
    private _cleanupSeries: boolean ;


    public get cleanupSeries() : boolean {
        return this._cleanupSeries;
    }

    public set cleanupSeries(value : boolean) {
        this._cleanupSeries = value;
    }

    public get activeSeriesInstanceUID(): string {
        var cell: lt.Controls.Medical.Cell = this.get_activeCell();

        return cell?cell.seriesInstanceUID:'';
    }

    public get currentStructuredDisplay(): any {
        return this._currentStructuredDisplay;
    }

    public set currentStructuredDisplay(value: any) {

        this._currentStructuredDisplay = value;
    }

    public get structuredDisplayList(): any {
        return this._structuredDisplayList;
    }

    public set structuredDisplayList(value: any) {
        this._structuredDisplayList = value;
    }

    public get currentLoadingSeries(): any {
        return this._currentLoadingSeries;
    }

    public set currentLoadingSeries(value: any) {
        this._currentLoadingSeries = value;
    }

    public get currentPatientSeries(): Array<any> {
        return this._currentPatientSeries;
    }

    public set currentPatientSeries(value: Array<any>) {
        this._currentPatientSeries = value;
    }

    constructor(eventService: EventService, optionsService: OptionsService, dialogs, $translate, $modal) {
        var __this = this;

        this._series = {};
        this._eventService = eventService;
        this._optionsService = optionsService;
        this._dialogs = dialogs;  
        this._modal = $modal;      

        this._overflowImages = [];
        this._cleanupSeries = false;

        eventService.subscribe(EventNames.LoadingSeriesFrames, $.proxy(this.OnLoadSeriesFrames, this));

        $translate('ANNOTATIONS').then(function (translation) {
            __this._annotations = translation;
        });

        $translate('LOADED').then(function (translation) {
            __this._loaded = translation;
        });

        $translate('DIALOGS_NOTIFICATION').then(function (translation) {
            __this._notifyTitle = translation;
        });  

        $translate('DIALOGS_ERROR').then(function (translation) {
            __this._errorTitle = translation;
        });
    }   

    public get_allSeries(): Array<string> {
        var series: Array<string> = new Array<string>();

        for (var key in this._series) {
            if (this._series.hasOwnProperty(key)) {
                series.push(key);
            }
        }

        return series;
    }    


    public get_metaData(): any {
        var cell : any = this.get_activeCell();
        if (cell instanceof lt.Controls.Medical.Cell3D) {

            var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;
            return cell3D.JSON;
        }

        else {
            var frame = this.get_activeCellFrame();
            return frame.metadata;
        }

    }




    public get_seriesTab(seriesInstanceUID: string): Models.Tab {
        if (this._series[seriesInstanceUID]) {
            return this._series[seriesInstanceUID].tab;
        }
        return null;
    }

    public set_seriesTab(seriesInstanceUID: string, tab: Models.Tab) {
        if (!this._series[seriesInstanceUID]) {
            this._series[seriesInstanceUID] = {};
        }
        this._series[seriesInstanceUID].tab = tab;
    }

    public add_seriesCell(cell:lt.Controls.Medical.Cell) {
        var seriesInstanceUID = cell.get_seriesInstanceUID();        

        if (!this._series[seriesInstanceUID]) {
            this._series[seriesInstanceUID] = {};                       
        }

        if (!this._series[seriesInstanceUID].cells) {
            this._series[seriesInstanceUID].cells = new Array<lt.Controls.Medical.Cell>(); 
        }

        this._series[seriesInstanceUID].cells.push(cell);        
    }    

    public dispose_seriesCell(seriesInstanceUID: string) {
        if (this._series[seriesInstanceUID]) {
            if (this._series[seriesInstanceUID].cells) {
                angular.forEach(this._series[seriesInstanceUID].cells, function (cell, index) {
                    cell.dispose();
                });
            }
            this._series[seriesInstanceUID] = null;
            delete this._series[seriesInstanceUID];
            if (angular.isDefined(this._overflowImages[seriesInstanceUID])) {
                delete this._overflowImages[seriesInstanceUID];
            }
        }
    }

    public remove_UnusedSeries() {

        if (!this._series)
            return;

        var _this = this;

        Object.keys(this._series).forEach(function (key) {

            if (!_this._series[key].cells || _this._series[key].cells.length == 0 ) {

                _this._series[key] = null;
                delete _this._series[key];
            }

        });
    }


    public remove_seriesCell(seriesInstanceUID: string) {

        var dentalMode: boolean = this._optionsService.get(OptionNames.DentalMode);

        if (dentalMode) {
            if (this._series[seriesInstanceUID]) {
                if (this._series[seriesInstanceUID].cells) {
                    angular.forEach(this._series[seriesInstanceUID].cells, function (cell, index) {
                        cell.dispose();
                    });
                }
                //this._series[seriesInstanceUID] = null;
                //delete this._series[seriesInstanceUID];


                this._series[seriesInstanceUID].cells = null;
                this._series[seriesInstanceUID].instances = null;
                this._series[seriesInstanceUID].loaders = null;

                if (angular.isDefined(this._overflowImages[seriesInstanceUID])) {
                    delete this._overflowImages[seriesInstanceUID];
                }
            }
        }
        else {
            if (this._series[seriesInstanceUID]) {

                //this._series[seriesInstanceUID] = null;
                //delete this._series[seriesInstanceUID];

                this._series[seriesInstanceUID].cells = null;
                this._series[seriesInstanceUID].instances = null;
                this._series[seriesInstanceUID].loaders = null;


                if (angular.isDefined(this._overflowImages[seriesInstanceUID])) {
                    delete this._overflowImages[seriesInstanceUID];
                }
            }
        }
    }

    public remove_cell(cell) {
        if (this._series[cell.seriesInstanceUID]) {
            if (this._series[cell.seriesInstanceUID].cells) {
                var index: number = this._series[cell.seriesInstanceUID].cells.indexOf(cell);

                if (index != -1) {
                    this._series[cell.seriesInstanceUID].cells.splice(index, 1);
                }
            }
        }
    }

    public set_ShowStudyTimeLine(value : boolean) {
        this._showStudyTimeLine = value;
    }

    public get_ShowStudyTimeLine() : boolean {
        return this._showStudyTimeLine;
    }


    public get_activeItem(): lt.Controls.Medical.LayoutManagerItem {
        return <any>this._activeCell;
    }



    public set_activeCell(id: string) {
        if (id == null) {
            this._activeCell = null;
        }
        else {
            var cell = this.get_seriesCellById(id);

            this._activeCell = cell;
            if (cell != null) {
                cell.get_viewer().layout.selectedItems.clear();
                cell.set_selected(true);
            }
        }
    }

    public get_activeCell():lt.Controls.Medical.Cell {        
        return this._activeCell;
    }   

    public get_anyCell(): lt.Controls.Medical.Cell {

        for (var key in this._series) {
            if (this._series.hasOwnProperty(key)) {
                if (this._series[key].cells) {
                    var length: number = this._series[key].cells.length;

                    if(length>0) {
                        var cell: lt.Controls.Medical.Cell = this._series[key].cells[0];
                        return cell;
                    }
                }
            }
        }
        return null;
    }  

    public get_seriesCellById(id: string): lt.Controls.Medical.Cell {
        
        for (var key in this._series) {
            if (this._series.hasOwnProperty(key)) {
                if (this._series[key].cells) {
                    var length: number = this._series[key].cells.length;

                    for (var index = 0; index < length; index++) {
                        var cell: lt.Controls.Medical.Cell = this._series[key].cells[index];

                        if (cell.get_divID() == id) {
                            return cell;
                        }
                    }
                }         
            }
        }        
        return null;
    }    

    public set_seriesLoader(cell: lt.Controls.Medical.Cell, loader: DicomLoader) {
        var seriesInstanceUID: string = cell.get_seriesInstanceUID();

        if (this._series[seriesInstanceUID]) {
            if (!this._series[seriesInstanceUID].loaders) {
                this._series[seriesInstanceUID].loaders = {};
            }
            this._series[seriesInstanceUID].loaders[cell.get_divID()] = loader;
        }
    }

    public get_seriesLoaderById(cell: lt.Controls.Medical.Cell) {
        if (cell!=null && this._series[cell.get_seriesInstanceUID()]) {
            if (this._series[cell.get_seriesInstanceUID()].loaders) {
                var loaders = this._series[cell.get_seriesInstanceUID()].loaders;                

                for (var key in loaders) {
                    if (loaders.hasOwnProperty(key)) {
                        if(key == cell.divID) {
                            return loaders[key];
                        }
                    }
                }
            }
        }       
        return null;
    }

    public set_seriesInfo(seriesInstanceUID: string, info) {
        if (this._series[seriesInstanceUID]) {
            this._series[seriesInstanceUID].info = info;
        }
    }

    public get_seriesInfo(seriesInstanceUID) {
        if (this._series[seriesInstanceUID]) {
            return this._series[seriesInstanceUID].info;
        }
        return null;
    }

    public set_layout(seriesInstanceUID: string, id:string, layout, template:Models.Template) {
        if (this._series[seriesInstanceUID]) {
            if (!this._series[seriesInstanceUID].layouts) {
                this._series[seriesInstanceUID].layouts = {};
            }

            if (!this._series[seriesInstanceUID].templates) {
                this._series[seriesInstanceUID].templates = {};
            }

            if (layout && layout.Boxes.length > 0) {
                this._series[seriesInstanceUID].layouts[id] = layout;                
            }
            
            if (template) {
                this._series[seriesInstanceUID].templates[id] = template;
            }            
        }
    }

    public get_layout(seriesInstanceUID: string, id:string) {
        if (this._series[seriesInstanceUID]) {
            if (this._series[seriesInstanceUID].layouts) {
                if (this._series[seriesInstanceUID].layouts[id]) {
                    return this._series[seriesInstanceUID].layouts[id];
                }
            }            
        }
        return null;
    }

    public get_template(seriesInstanceUID: string, id:string):Models.Template {
        if (this._series[seriesInstanceUID]) {
            if (this._series[seriesInstanceUID].templates) {
                return this._series[seriesInstanceUID].templates[id];
            }            
        }
        return null;
    }

    public set_presentationInfo(seriesInstanceUID: string, id:string, presentationInfo) {
        if (this._series[seriesInstanceUID]) {
            if (!this._series[seriesInstanceUID].presentationInfo) {
                this._series[seriesInstanceUID].presentationInfo = {};
            }

            this._series[seriesInstanceUID].presentationInfo[id] = presentationInfo;
            if (this._series[seriesInstanceUID].instances && this._series[seriesInstanceUID].instances[id]) {
                this.sortImageInformation(seriesInstanceUID, id, this._series[seriesInstanceUID].presentationInfo[id]);
            }
        }
    }

    public get_presentationInfo(seriesInstanceUID: string, id:string) {
        if (this._series[seriesInstanceUID]) {
            if (this._series[seriesInstanceUID].presentationInfo && this._series[seriesInstanceUID].presentationInfo[id]) {
                return this._series[seriesInstanceUID].presentationInfo[id];
            }
        }
        return null;
    }

    public set_instances(seriesInstanceUID: string, id: string, instances: Array<any>, stackInstanceUID) {
        if (this._series[seriesInstanceUID]) {
            if (!this._series[seriesInstanceUID].instances) {
                this._series[seriesInstanceUID].instances = {};
            }

            this._series[seriesInstanceUID].instances[id] = instances;
            {                
                var template:Models.Template = this._series[seriesInstanceUID].templates[id];

                //this.sortImageInformation(seriesInstanceUID, id, this._series[seriesInstanceUID].presentationInfo[id]);

                var cell: lt.Controls.Medical.Cell = this.get_seriesCellById(id);             
                (<any>cell).stackInstanceUID = stackInstanceUID;
                if (template && template.Frames.length > 0) {
                                                     
                   
                    Utils.createViewerLayout(cell, template);                   
                }
                else {
                    var medicalViewer = cell.viewer;
                    if (!(<any>medicalViewer).HangingProtocolEnabled) {

                    var layout = this._series[seriesInstanceUID].layouts[id];

                    if (layout) {
                        if (!this._series[seriesInstanceUID].sopMappings) {
                            this._series[seriesInstanceUID].sopMappings = {};
                        }
                        this._series[seriesInstanceUID].sopMappings[id] = this.buildLayoutMappings(layout);
                        this.map_Frames(seriesInstanceUID, id, layout);
                        this.setCustomLayout(this.get_seriesCellById(id), layout);
                    }
                }
            }
        }
    }
    }

    public get_instances(seriesInstanceUID: string, id:string): Array<any> {
        if (this._series[seriesInstanceUID]) {
            if (this._series[seriesInstanceUID].instances && this._series[seriesInstanceUID].instances[id]) {
                return this._series[seriesInstanceUID].instances[id];
            }
        }
        return new Array<any>();
    }

    public set_sopMappings(seriesInstanceUID: string, id: string, mappings, layout) {
        if (!this._series[seriesInstanceUID].sopMappings) {
            this._series[seriesInstanceUID].sopMappings = {};
        }

        this._series[seriesInstanceUID].sopMappings[id] = mappings;
        this.map_Frames(seriesInstanceUID, id, layout);
    }

    public get_sopMappings(seriesInstanceUID: string, id:string) {
        if (this._series[seriesInstanceUID]) {
            if (this._series[seriesInstanceUID].sopMappings && this._series[seriesInstanceUID].sopMappings[id]) {
                return this._series[seriesInstanceUID].sopMappings[id];
            }
        }
        return null;
    }

    public delete_sopMappings(seriesInstanceUID) {
        if (this._series[seriesInstanceUID]) {
            delete this._series[seriesInstanceUID].sopMappings;
        }        
    }

    public get_cellFrame(seriesInstanceUID: string, id:string, sopInstanceUID: string, getNew?:boolean) {
        if (this._series[seriesInstanceUID]) {
            var sopMappings = this.get_sopMappings(seriesInstanceUID, id);
            var cell: lt.Controls.Medical.Cell = this.get_seriesCellById(id);

            getNew = getNew || false;
            if (sopMappings == null) {
                var cellFrame = new lt.Controls.Medical.Frame(cell);

                cell.get_frames().add(cellFrame);
                return cellFrame;
            }
            else if (sopInstanceUID in sopMappings) {
                return cell.get_frames().get_item(sopMappings[sopInstanceUID]);
            }
            else if (getNew) {
                var cellFrame = new lt.Controls.Medical.Frame(cell);

                cell.get_frames().add(cellFrame);
                return cellFrame;
            }
        }
        return null;
    }    

    public get_cellFrameByIndex(seriesInstanceUID: string, id:string, frameIndex: number) {
        if (this._series[seriesInstanceUID]) {
            var cell: lt.Controls.Medical.Cell = this.get_seriesCellById(id);
            var frames: lt.LeadCollection = cell.get_frames();

            return frames.item(frameIndex);
        }
        return undefined;
    }         

    public get_activeSubCellIndex(cell: lt.Controls.Medical.Cell): number {
        if (this._series[cell.seriesInstanceUID]) {
            var index = -1;            
            var items = cell.get_selectedItems();

            if (items.get_count() > 0)
                index = cell.get_imageViewer().get_items().indexOf(items.get_item(0));

            if (index < 0)
                index = 0;

            return index;
        }
        return -1;
    }

    public get_viewerCount(seriesInstanceUID: string, id:string): number {
        if (this._series[seriesInstanceUID]) {
            var cell: lt.Controls.Medical.Cell = this.get_seriesCellById(id);

            return cell.get_imageViewer().get_items().get_count();
        }
        return -1;
    }    

    public get_activeViewer() {
        var cell = this.get_activeCell();

        if (cell) {
            var items = cell.get_selectedItems();

            if (items.get_count() > 0) {
                return items.get_item(0);
            }
        }
        return null;
    }


    public get_activeItemForCell(cell) {
        if (cell) {
            var items = cell.get_selectedItems();

            if (items.get_count() > 0) {
                return items.get_item(0);
            }
        }
        return null;
    }

    public get_activeCellFrame() {
        var cell = this.get_activeCell();

        if (cell instanceof lt.Controls.Medical.Cell3D) {
            cell = (<lt.Controls.Medical.Cell3D>cell).referenceCell;
        }

        if (cell) {
            var index = this.get_activeSubCellIndex(cell);

            var subCell: lt.Controls.Medical.SubCell = <lt.Controls.Medical.SubCell>(cell.imageViewer.items.get_item(index));

            return <any>(subCell.attachedFrame);
        }
        return null;
    }

    public set_annotationIDs(seriesInstanceUID: string, id:string, annotationIds: Array<any>) {
        if (this._series[seriesInstanceUID]) {
            if (!this._series[seriesInstanceUID].annotations) {
                this._series[seriesInstanceUID].annotations = {}
            }            
            this._series[seriesInstanceUID].annotations[id] = annotationIds;
        }
    }

    public get_annotationIDs(seriesInstanceUID: string, id:string): Array<any> {
        if (this._series[seriesInstanceUID] && angular.isDefined(this._series[seriesInstanceUID].annotations)) {
            return this._series[seriesInstanceUID].annotations[id];
        }
        return new Array<any>();
    }

    public remove_annotationID(seriesInstanceUID:string, id:string, annotationId:string) {
        if (this._series[seriesInstanceUID]) {
            if (this._series[seriesInstanceUID].annotations) {
                var item = $.grep(this._series[seriesInstanceUID].annotations[id], function (annotation: any, index: number) { return annotation.SOPInstanceUID == annotationId });

                if (item.length > 0) {
                    var index = this._series[seriesInstanceUID].annotations[id].indexOf(item[0]);

                    this._series[seriesInstanceUID].annotations[id].splice(index, 1);
                }
            }
        }
    }

    public get_maxAllowedStackIndex(cell:lt.Controls.Medical.Cell): number {                
        if (cell) {
            if (cell instanceof lt.Controls.Medical.Cell3D)
                return 1;
            
            if (!cell.frames)
                return 1;

            var items: lt.LeadCollection = cell.get_imageViewer().get_items();

            if (items.count == 1) {
                return Math.max(1, cell.get_frames().get_count() - cell.get_imageViewer().get_items().get_count() + 1);
            }
            else {
                var selectedItem = cell.get_selectedItem();

                return Math.max(1, cell.get_frames().get_count() - cell.get_imageViewer().get_items().get_count() + 1);
            }                            
        }
        return -1;
    }

    public add_annotationID(seriesInstanceUID: string, id: string, annotationId:any) {
        if (this._series[seriesInstanceUID]) {
            if (!this._series[seriesInstanceUID].annotations) {
                this._series[seriesInstanceUID].annotations = new Array<any>();
            }
            this._series[seriesInstanceUID].annotations[id].push(annotationId);
        }        
    }

    public add_annotations(cell: lt.Controls.Medical.Cell, annotations:Document) {
        if (this._series[cell.seriesInstanceUID]) {
            try {                
                var length = cell.get_frames().get_count();
                var codecs: lt.Annotations.Engine.AnnCodecs = new lt.Annotations.Engine.AnnCodecs();
                var sopInstanceIndexMap = {};
                var baseIndex = 0;
                var frames = cell.get_frames();
                var annInfo = codecs.getInfoFromXmlDocument(annotations);
                var pages = annInfo.get_pages();
                var pagesCount = pages.length;

                while (baseIndex < length) {
                    var sopInstanceUID = frames.item(baseIndex).Instance.SOPInstanceUID;

                    if (sopInstanceIndexMap[sopInstanceUID] == undefined) {
                        sopInstanceIndexMap[sopInstanceUID] = baseIndex;
                    }
                    baseIndex++;
                }

                while (pagesCount--) {
                    var loadContainer: lt.Annotations.Engine.AnnContainer = codecs.loadFromXmlDocument(annotations, pages[pagesCount]);

                    if (loadContainer) {

                        // We want the RotateCenter to be automatically recalculated.
                        // It rotate center is empty (x = Nan, y = Nan), it is automatically recalculated.
                        // But in the deserialization, the NaN is converted to 0 so the RotateCenter is set to (0,0)
                        // The workaround is to just automatically set the  RoateCenter to be (x = Nan, y = Nan)
                        var children = loadContainer.get_children();
                        if (children) {
                            var children_count = children.get_count();
                            for (var i = 0; i < children_count; i++) {
                                var child = children.get_item(i);
                                if (child)
                                    child.set_rotateCenter(lt.LeadPointD.empty);
                            }
                        }

                        var annData = JSON.parse(loadContainer.get_userData());
                        var sopInstance = annData.ReferencedImageSequence.ReferencedSopInstanceUid;
                        var refFrames = annData.ReferencedImageSequence.ReferencedFrameNumber;
                        var framesCount = refFrames.length;
                        var automation = cell.get_automation();

                        for (var index = 0; index < framesCount; index++) {

                            var srcChildren: lt.Annotations.Engine.AnnObjectCollection = loadContainer.get_children();
                            if (srcChildren.count == 0)
                                continue;

                            var frameIndex = sopInstanceIndexMap[sopInstance] + refFrames[index] - 1;                           
                            var frame: lt.Controls.Medical.Frame = cell.get_frames().get_item(frameIndex);
                            var container: lt.Annotations.Engine.AnnContainer = frame.container;
                            var destChildren = container.get_children();

                            var childrenCount = srcChildren.get_count();
                            
                            for (var i = 0; i < childrenCount; i++) {
                                var child = srcChildren.get_item(i);
                                destChildren.add(child);
                            }
                            
                            container.mapper.calibrate(lt.LeadLengthD.create(1), lt.Annotations.Engine.AnnUnit.unit, lt.LeadLengthD.create(loadContainer.mapper.calibrationScale), lt.Annotations.Engine.AnnUnit.unit);

                            automation.set_active(true);
                            automation.invalidate(lt.LeadRectD.empty);
                        }
                    }

                    automation.get_automationControl().automationInvalidate(lt.LeadRectD.empty);

                }
            }
            catch (er) {
                this._dialogs.error(this._errorTitle, "Invalid annotations data: " + er);
            }
        }        
    }

    public capture_currentFrame(burnAnnotations?: boolean) {
        var burn = burnAnnotations || false;
        var canvas:HTMLCanvasElement = this.cloneCanvas();  
        var canvasData;

        if (burn) {
            this.burnAnnotations(canvas);
        }

        canvasData = canvas.toDataURL("image/png");
        return canvasData;      
    }

    public get_cellAnnotations(cell: lt.Controls.Medical.Cell): string {
        if (this._series[cell.seriesInstanceUID]) {            
            var frames: lt.LeadCollection = cell.get_frames();
            var codecs: lt.Annotations.Engine.AnnCodecs = new lt.Annotations.Engine.AnnCodecs();
            var length = frames.count;
            var annotationsData = "";
            var automation: lt.Annotations.Automation.AnnAutomation = cell.get_automation();

            while (length--) {
                var frame = frames.item(length);                
                var container: lt.Annotations.Engine.AnnContainer = frame.get_container();

                if (automation != null) {
                    var instance = frame.Instance;

                    if (angular.isDefined(container) && container.children.count > 0) {
                        var userData: Models.AnnUserData = new Models.AnnUserData();
                        var refSop: Models.SopInstanceReference = new Models.SopInstanceReference();

                        refSop.ReferencedSopClassUid = instance.SOPClassUID;
                        refSop.ReferencedSopInstanceUid = instance.SOPInstanceUID;
                        refSop.ReferencedFrameNumber.push(frame.FrameNumber);

                        userData.ImageSize = this.getImageSize(frame);
                        userData.ReferencedImageSequence = refSop;
                        container.userData = JSON.stringify(userData);
                        annotationsData = codecs.save(container, lt.Annotations.Engine.AnnFormat.annotations, annotationsData, length + 1);
                    }
                }
            }
            return annotationsData;
        }
        return "";
    }

    public enumerateFrames(cell: lt.Controls.Medical.Cell, frameFunction: Function, cell3DFunction? : Function) {
        if (this._series[cell.seriesInstanceUID] && frameFunction) {            
            var viewer = cell.viewer;
            var frames;
            var length;

            var cellIndex = 0;
            var cellCount = viewer.layout.items.count;

            for (cellIndex = 0; cellIndex < cellCount; cellIndex++) {
                cell = viewer.layout.items.get_item(cellIndex);
                if (cell instanceof lt.Controls.Medical.Cell3D) {
                    if (cell3DFunction)
                        cell3DFunction(cell);
                    continue;
                }
                frames = cell.get_frames();
                length = frames.count;
                if (!cell.tickBoxes[0].checked && !cell.selected)
                    continue;
                for (var index = 0; index < length; index++) {
                    try {
                        frameFunction(frames.item(index), index);
                    }
                    catch (err) {
                    }
                }
            }
        }
    }    

    public withinVisibleRange(cell:lt.Controls.Medical.Cell, frameIndex: number): boolean {
        if (this._series[cell.seriesInstanceUID]) {            
            var cellFrame = null;

            if (frameIndex < 0 || frameIndex >= cell.frames.count) {
                return false;
            }

            cellFrame = cell.frames.item(frameIndex);
            return cell.withinVisibleRange(frameIndex);
            
        }
        return false;
    }    

    public isImageDataAvailable(cell:lt.Controls.Medical.Cell, frameIndex: number): boolean {
        if (this._series[cell.seriesInstanceUID]) {            
            var frames: lt.LeadCollection = cell.frames;
            var cellFrame = null;

            if (frameIndex < 0 || frameIndex >= frames.count) {
                return false;
            }

            cellFrame = frames.item(frameIndex);
            return cellFrame.get_isPNGDataReady();
        }
        return false;
    }

    public isDataReady(cell:lt.Controls.Medical.Cell, frameIndex: number): boolean {
        if (this._series[cell.seriesInstanceUID]) {
            // the data is always ready for the 3D since it's done on the server
            if (cell instanceof lt.Controls.Medical.Cell3D)
                return true;

            var frames: lt.LeadCollection = cell.frames;

            if (!frames)
                return false;
            
            var cellFrame = null;

            if (frameIndex < 0 || frameIndex >= frames.count) {
                return false;
            }

            cellFrame = frames.item(frameIndex);
            return cellFrame.get_isDataReady();
        }
        return false;
    }

    public deleteSelectedAnnotations() {
        var cell = this.get_activeCell();

        if (cell) {
            var automation: lt.Annotations.Automation.AnnAutomation = cell.get_automation();

            if (automation != null && automation.canDeleteObjects)
            {
                if (automation.currentEditObject != null)
                    automation.deleteSelectedObjects();
                else
                    alert('no annotation found to delete');
            }
            else
                alert('no annotation found to delete');
        }
    }

    public clearAnnotations() {
        var cell = this.get_activeCell();

        if (cell) {
            var cell = this.get_activeCell();
            var automation: lt.Annotations.Automation.AnnAutomation = cell.get_automation();
            var frame: lt.Controls.Medical.Frame = this.get_activeCellFrame();
            var children = frame.get_container().get_children();
            var count = children.count;

            if (count == 0) {
                alert('no annotation found');
            }
            else {
                children.clear();
                automation.invalidate(lt.LeadRectD.empty);
            }
        }
    }

    public clearAllAnnotations() {
        var cell = this.get_activeCell();

        if (cell) {
            var length = cell.get_frames().get_count();            
            var automation: lt.Annotations.Automation.AnnAutomation = cell.get_automation();
            var annFound = false;
            for (var index = 0; index < length; index++) { 
                var frame: lt.Controls.Medical.Frame = cell.get_frames().item(index);               
                var children = frame.get_container().get_children();
                var count = children.count;

                if (count != 0) {
                    annFound = true;
                    children.clear();
                }
            }

            if (!annFound) {
                alert('no annotations found');
            }
            else
                automation.invalidate(lt.LeadRectD.empty);
        }
    }

    private buildLayoutMappings(layout) {
        var map = new AssociativeArray();
        var length = layout.Boxes ? layout.Boxes.length : 0;

        for (var index = 0; index < length; index++) {
            var box = layout.Boxes[index];
            var referencedSopInstanceUID = box.referencedSOPInstanceUID && box.referencedSOPInstanceUID.length > 0 ? box.referencedSOPInstanceUID[0] : "DUMMY_ID_" + index;

            map[referencedSopInstanceUID] = index;
        }

        return map;
    }

    public map_Frames(seriesInstanceUID: string, id:string, layout: any) {
        var sopMappings = this.get_sopMappings(seriesInstanceUID, id);

        if (sopMappings) {
            var frameMapping = null;            
            var cell = this.get_seriesCellById(id);
            var sopLength = sopMappings.Size();
            var boxLength = layout.Boxes.length;
            var unmappedFrames: Array<number> = new Array<number>();
            var mappedFrames: Array<number> = new Array<number>();

            for (var i = 0; i < boxLength; i++) {
                var box = layout.Boxes[i];
                var referencedSopInstanceUID = box.referencedSOPInstanceUID && box.referencedSOPInstanceUID ? box.referencedSOPInstanceUID[0] : null;

                if (angular.isDefined(sopMappings[referencedSopInstanceUID])) {
                    if (frameMapping == null) {
                        frameMapping = {};
                    }
                    frameMapping[i] = sopMappings[referencedSopInstanceUID];
                    //frameMapping[sopMappings[referencedSopInstanceUID]] = i;
                    mappedFrames.push(sopMappings[referencedSopInstanceUID]);
                }
                else {
                    unmappedFrames.push(i);
                }          
            } 

            //
            // Find all frames not mapped
            //   
            if (frameMapping!=null && unmappedFrames.length > 0) {
                for (var i = 0; i < boxLength; i++) {                                       
                    if (unmappedFrames.indexOf(i) != -1) {
                        for (var j = 0; j < boxLength; j++) {                            
                            if (!angular.isDefined(frameMapping[j])) {
                                frameMapping[j] = i;
                                break;
                            }
                        }
                    }                  
                }                
            }                            
        }
    }

    private sortImageInformation(seriesInstanceUID: string, id: string, presentationInfo) {        
        var findIndex = 0;
        var frame = new Models.FramePresentationInfo();
        var framesLength = 0;
        var lastIndex = 0;
        var cell = this.get_seriesCellById(id);

        if (cell != null) {
            var instanceLength = this._series[seriesInstanceUID].instances[id].length;
            var instanceCounter = 0;

            if (!this._series[seriesInstanceUID].imagesInformation) {
                this._series[seriesInstanceUID].imagesInformation = {};
            }

            this._series[seriesInstanceUID].imagesInformation[id] = [];

            for (; instanceCounter < instanceLength; instanceCounter++) {
                var index = 0;
                var instance = this._series[seriesInstanceUID].instances[id][instanceCounter];
               
                if (instance != null) {
                    findIndex = this.findSOP(presentationInfo, instance.SOPInstanceUID);                    
                    framesLength = presentationInfo[findIndex].PagesPresentationInfo.length;

                    for (; index < framesLength; index++) {
                        this._series[seriesInstanceUID].imagesInformation[id][index + lastIndex] = DicomHelper.PreparePresentationInformation(presentationInfo[findIndex], index);
                    }
                    lastIndex += framesLength;
                }
            }
        }
    }

    public setCustomLayout(cell:lt.Controls.Medical.Cell, layout:Models.Layout) {
        var length: number = layout.Boxes.length;
        var imageViewer = cell.get_imageViewer();
        var medicalViewer = cell.viewer;
        var numInstances: number;
        var instances: Array<any> = this.get_instances(cell.get_seriesInstanceUID(), cell.get_divID());              
       
        imageViewer.beginUpdate();
        cell.set_arrangement(1);
        imageViewer.items.clear();
        cell.updateSubCellCount(length);
        (<any>cell).templateId = layout.TemplateId;
        numInstances = length;        
        for (var index: number = 0; index < length; index++) {           
            var box:Models.ImageBox = layout.Boxes[index];
            var item: lt.Controls.Medical.SubCell = <lt.Controls.Medical.SubCell>(imageViewer.get_items().get_item(index));
            var bounds = Utils.createLeadRect(box.Position.leftTop.x, box.Position.leftTop.y, box.Position.rightBottom.x, box.Position.rightBottom.y);

            if (!bounds.isEmpty) {
                var cellFrame = new lt.Controls.Medical.Frame(cell);
                var subCell: lt.Controls.Medical.SubCell = item; 
                //var viewer: lt.Controls.ImageViewer;

                item.set_bounds(bounds);
                cell.get_frames().add(cellFrame);
                //subCell = cellFrame.get_subCell();
                if (subCell != null) {
                    subCell.backColor = this._optionsService.get(OptionNames.EmptyCellBackgroundColor);
                }
            }
        }
        cell.onSizeChanged();
        imageViewer.endUpdate();
    }

    public set_framesMapping(cell: lt.Controls.Medical.Cell, frames: Array<Models.Frame>) {               
        var framesMapping: any = null;        
        var cellFrames: Array<lt.Controls.Medical.Frame> = cell.frames.toArray();
        var imageViewer: lt.Controls.ImageViewer = cell.imageViewer;
        var length = imageViewer.items.count;         

        for (var index = 0; index < length; index++) {            
            var subCell: lt.Controls.Medical.SubCell = <lt.Controls.Medical.SubCell>(imageViewer.items.item(index));

            if ((<any>subCell).templateFrame) {
                var cellFrame:lt.Controls.Medical.Frame = Utils.findFirst(cellFrames, function (cellFrame: lt.Controls.Medical.Frame) {
                    return !(<any>subCell).isMapped && Utils.isInstanceInFrame((<any>subCell).templateFrame, cellFrame);
                });

                if (framesMapping == null)
                    framesMapping = {};

                if (cellFrame) {
                    var frameIndex = cellFrames.indexOf(cellFrame);
                                        
                    framesMapping[index] = cell.frames.indexOf(cellFrame);                     
                    cellFrames.splice(frameIndex, 1);                    
                    (<any>subCell).isMapped = true;
                }
                else {
                    framesMapping[index] = -1;                    
                }
            }
        }
               
        (<any>cell).set_framesMappingIndex(framesMapping);
        return cellFrames;
    } 
    
    public map_frame(cellFrame: lt.Controls.Medical.Frame): boolean {
        var mapped: boolean;
        var cell: lt.Controls.Medical.Cell = cellFrame.parentCell;
        var imageViewer: lt.Controls.ImageViewer = cell.imageViewer;
        var length = imageViewer.items.count;
        var framesMapping: any = cell.framesMappingIndex; 

        for (var index = 0; index < length; index++) {
            var subCell: lt.Controls.Medical.SubCell = <lt.Controls.Medical.SubCell>(imageViewer.items.item(index));

            mapped = !(<any>subCell).isMapped && Utils.isInstanceInFrame((<any>subCell).templateFrame, cellFrame);
            if (mapped) {                                
                break;
            }
        }

        if (mapped) {           
            (<any>subCell).isMapped = true;
            subCell.set_attachedFrame(cellFrame);           
        }

        return mapped;
    }   

    public addPostRender(viewer: lt.Controls.ImageViewer, cell: lt.Controls.Medical.Cell) {
        viewer.add_postRenderItem(function (sender, e: lt.Controls.ImageViewerRenderEventArgs) {            
            if (e.part == lt.Controls.ImageViewerItemPart.item) {
                var context: CanvasRenderingContext2D = e.context;
                var item:lt.Controls.Medical.SubCell = <lt.Controls.Medical.SubCell>e.item;
                var bounds: lt.LeadRectD;
                var transform;
                var index: number = cell.frames.indexOf(item.attachedFrame);                
                var text: string;
                var viewerIndex = cell.get_derivatives().indexOf(viewer);

                context.save();
                bounds = viewer.getItemBounds(item, lt.Controls.ImageViewerItemPart.content);                               

                if (angular.isDefined(item.attachedFrame)) {
                    var instance = (<any>item.attachedFrame).Instance;

                    text = instance.SOPInstanceUID;
                    text = text.substr(text.length - 6, 5) + ': ' + instance.InstanceNumber;
                }
                else {
                    text = index.toString();
                }

                text = '(' + index.toString() + ') ' + text;

                context.font = "12px serif";
                context.fillStyle = 'red';
                context.textBaseline = "top";
                context.fillText(text, bounds.left, bounds.top, bounds.width);                
                context.restore();
            }
        });
    }

    public add_seriesOverflow(data) {
        var seriesInstanceUID = data.instance.SeriesInstanceUID;

        if (!angular.isDefined(this._overflowImages[seriesInstanceUID])) {
            this._overflowImages[seriesInstanceUID] = [];
        }

        if (!angular.isDefined(this._overflowImages[seriesInstanceUID].metadata)) {
            this._overflowImages[seriesInstanceUID].metadata = data.metadata;
        }

        this._overflowImages[seriesInstanceUID].push(data);
    }    

    public get_seriesOverflow(seriesInstanceUID: string): Array<any> {
        if (angular.isDefined(this._overflowImages[seriesInstanceUID])) {
            return this._overflowImages[seriesInstanceUID];
        }
        return [];
    }

    public get_seriesOverflowJSON(seriesInstanceUID: string) {
        if (angular.isDefined(this._overflowImages[seriesInstanceUID]) && angular.isDefined(this._overflowImages[seriesInstanceUID].metadata)) {
            return this._overflowImages[seriesInstanceUID].metadata;
        }
        return null;
    }

    public clear_seriesOverflow(seriesInstanceUID: string) {
        if (angular.isDefined(this._overflowImages[seriesInstanceUID])) {
            delete this._overflowImages[seriesInstanceUID].metadata;
            this._overflowImages[seriesInstanceUID] = [];
        }
    }

    private findSOP(presentationInfo, sopInstanceUID) {
        var index = 0;
        var findIndex = 0;
        var length = presentationInfo.length;

        for (; index < length; index++) {
            if (presentationInfo[index].SOPInstanceUID == sopInstanceUID)
                return index;
        }

        return -1;
    }

    private OnLoadSeriesFrames(event, data) {
        var cell = this.get_seriesCellById(data.args.id);

        if (cell) {
            var automation: lt.Annotations.Automation.AnnAutomation = cell.get_automation();            
            var __this = this;

            if (automation) { 
                automation.add_editText(function (sender, e) {
                    __this.automation_editText(sender, e, cell);
                });

                automation.add_currentDesignerChanged(function (sender, e) {
                    __this.automation_CurrentDesignerChanged(sender, e, cell);
                });

                automation.add_draw(function (sender, e) {
                    __this.automation_AnnotationDraw(sender, e);
                });

                __this.setDefaults(automation.get_manager());
                __this.setThumbPreferences(automation.get_manager().get_renderingEngine().get_renderers());
            }
        }
    }    

    private automation_editText(sender, e: lt.Annotations.Engine.AnnEditTextEventArgs, cell: lt.Controls.Medical.Cell) {    
        if (lt.LTHelper.device == lt.LTDevice.tablet || lt.LTHelper.device == lt.LTDevice.mobile) {
            var modalInstance = this._modal.open({
                templateUrl: 'views/dialogs/Prompt.html',
                controller: Controllers.PromptController,
                backdrop: 'static',
                resolve: {
                    label: function () {
                        return "Text";
                    },
                    text: function () {
                        return e.get_textObject().get_text();
                    }
                }
            });

            modalInstance.result.then(function (text) {
                var automation: lt.Annotations.Automation.AnnAutomation = cell.get_automation();

                e.get_textObject().set_text(text);
                automation.get_automationControl().automationInvalidate(lt.LeadRectD.empty);
            });
        }
        else {
            var textElement: HTMLTextAreaElement = <HTMLTextAreaElement>document.createElement("textArea");
            var viewer = cell.get_imageViewer();
            var automation:lt.Annotations.Automation.AnnAutomation = cell.get_automation();
            var parent = viewer.get_mainDiv().parentNode;
            var __this = this;

            textElement.id = 'textObject';
            textElement.style.left = e.get_bounds().get_left() + 'px';
            textElement.style.top = e.get_bounds().get_top() + 'px';
            textElement.style.position = 'absolute';
            textElement.style.zIndex = '100';
            textElement.style.height = e.get_bounds().get_height() + 'px';
            textElement.style.width = e.get_bounds().get_width() + 'px';
            (<any>textElement).userData = e.get_textObject();
            textElement.value = e.get_textObject().get_text();
            textElement.style.color = (<lt.Annotations.Engine.AnnSolidColorBrush> e.get_textObject().get_textForeground()).get_color();
            textElement.style.fontFamily = e.get_textObject().get_font().get_fontFamilyName();
            textElement.style.fontSize = e.get_textObject().get_font().get_fontSize() + 'pt';
            textElement.wrap = "off";        
            parent.appendChild(textElement);
            //automation.automationControl.automationLostFocus.invoke(this, lt.LeadEventArgs.empty);
            textElement.focus();
            textElement.addEventListener("focusout", function () {
                var parent = viewer.get_mainDiv().parentNode;
                var child: HTMLTextAreaElement = <HTMLTextAreaElement> document.getElementById('textObject');
                if (child) {
                    __this.automation_GotFocus(sender, e, cell, textElement.id);
                }
            });

            this.moveCaretToEnd(textElement);
            window.setTimeout(function () {
                __this.moveCaretToEnd(textElement);
            }, 1);
        }
    }

    private moveCaretToEnd(element: HTMLTextAreaElement): void {
        if (typeof element.selectionStart == "number") {
            element.selectionStart = element.selectionEnd = element.value.length;
        } else if (typeof (element["createTextRange"]) != "undefined") {
            element.focus();
            var range: any = element["createTextRange"];
            range.collapse(false);
            range.select();
        }
    }

    private automation_GotFocus(sender, e, cell,id) {
        var viewer = cell.get_imageViewer();
        var automation:lt.Annotations.Automation.AnnAutomation = cell.get_automation();
        var parent = viewer.get_foreCanvas().parentNode;
        var child: any = document.getElementById(id);

        if (child) {
            child.userData.set_text(child.value);
            parent.removeChild(child);
            automation.get_automationControl().automationInvalidate(lt.LeadRectD.empty);            
        }
    }

    private automation_CurrentDesignerChanged(sender, e, cell) {
        var automation: lt.Annotations.Automation.AnnAutomation = sender;
        
        this._eventService.publish(EventNames.CurrentDesignerChanged, { seriesInstanceUID: cell.get_seriesInstanceUID, automation: automation, selectedObject: automation.get_currentEditObject() });
        automation.get_automationControl().automationInvalidate(lt.LeadRectD.empty);
    }

    private automation_AnnotationDraw(sender, e: lt.Annotations.Engine.AnnDrawDesignerEventArgs) {
        if (e.operationStatus == lt.Annotations.Engine.AnnDesignerOperationStatus.start) {
            if (!this._stroke) {
                this._stroke = lt.Annotations.Engine.AnnSolidColorBrush.create(this._optionsService.get(OptionNames.AnnotationStrokeColor));
            }

            e.object.stroke.stroke = this._stroke;

            if (e.object['tickMarksStroke']) {
                e.object['tickMarksStroke'].stroke = this._stroke;
            }

            if (e.object['textForeground']) {
                if (!this._textColor) {
                    this._textColor = lt.Annotations.Engine.AnnSolidColorBrush.create(this._optionsService.get(OptionNames.AnnotationTextColor));
                }       
                                           
                e.object['textForeground'] = this._textColor;
            }

            if (e.object['hiliteColor']) {
                if (!this._hilightColor) {
                    this._hilightColor = this._optionsService.get(OptionNames.AnnotationHiliteColor); 
                }

                e.object['hiliteColor'] = this._hilightColor;
            }
        }
    }

    private setDefaults(manager: lt.Annotations.Automation.AnnAutomationManager) {
        var result: Array<any> = $.grep(Array<any>(manager.objects.toArray()), function (item: lt.Annotations.Engine.AnnObject) { return item.id == lt.Annotations.Engine.AnnObject.rulerObjectId });

        if (result.length > 0) {
            var rulerObject: lt.Annotations.Engine.AnnPolyRulerObject = result[0].objectTemplate;

            rulerObject.set_measurementUnit(lt.Annotations.Engine.AnnUnit.millimeter);
        }
    }

    private setThumbPreferences(renderers) {
        var bigThumbSize = 72 * 2;
        var smallThumbSize = 72;
        var locationThumbStyle = new lt.Annotations.Rendering.AnnRectangleThumbStyle();
        var rotateCenterThumbStyle = new lt.Annotations.Rendering.AnnEllipseThumbStyle();
        var rotateGripperThumbStyle = new lt.Annotations.Rendering.AnnEllipseThumbStyle();

        if (lt.LTHelper.device == lt.LTDevice.desktop) {
            locationThumbStyle.set_size(lt.LeadSizeD.create(smallThumbSize, smallThumbSize));
        } else {
            locationThumbStyle.set_size(lt.LeadSizeD.create(bigThumbSize, bigThumbSize));
        }

        locationThumbStyle.set_stroke(lt.Annotations.Engine.AnnStroke.create(lt.Annotations.Engine.AnnSolidColorBrush.create('black'), lt.LeadLengthD.create(1)));
        locationThumbStyle.set_fill(lt.Annotations.Engine.AnnSolidColorBrush.create('rgba(173, 216, 230, .4)'));        
        rotateCenterThumbStyle.set_size(lt.LeadSizeD.create(smallThumbSize * 0.75, smallThumbSize * 0.75));
        rotateCenterThumbStyle.set_stroke(lt.Annotations.Engine.AnnStroke.create(lt.Annotations.Engine.AnnSolidColorBrush.create('black'), lt.LeadLengthD.create(1)));
        rotateCenterThumbStyle.set_fill(lt.Annotations.Engine.AnnSolidColorBrush.create('rgba(144, 238, 144, .4)'));       
        rotateGripperThumbStyle.set_size(lt.LeadSizeD.create(bigThumbSize * 0.75, bigThumbSize * 0.75));
        rotateGripperThumbStyle.set_stroke(lt.Annotations.Engine.AnnStroke.create(lt.Annotations.Engine.AnnSolidColorBrush.create('black'), lt.LeadLengthD.create(1)));
        rotateGripperThumbStyle.set_fill(lt.Annotations.Engine.AnnSolidColorBrush.create('rgba(144, 238, 144, .4)'));
        for (var $key2 in renderers) {
            var item = { key: $key2, value: renderers[$key2] };
            var renderer = item.value;
            renderer.set_locationsThumbStyle(locationThumbStyle);
            renderer.set_rotateCenterThumbStyle(rotateCenterThumbStyle);
            renderer.set_rotateGripperThumbStyle(rotateGripperThumbStyle);
        }
    }

    private cloneCanvas(overlayCanvas?) {

        var rect: lt.LeadRectD;
        var canvas; 
        var cell = this.get_activeCell();
        if (cell instanceof lt.Controls.Medical.Cell3D) {
            var cell3D: lt.Controls.Medical.Cell3D = <lt.Controls.Medical.Cell3D>cell;
            canvas = cell3D.image;
            rect = lt.LeadRectD.create(0, 0, cell3D.image.naturalWidth, cell3D.image.naturalHeight);
        }
        else {
            var viewer = cell.get_imageViewer();
            var activeItem: lt.Controls.Medical.MRTISubCell = <lt.Controls.Medical.MRTISubCell>viewer.get_activeItem();
            canvas = activeItem.getForground();
            rect = viewer.getItemViewBounds(activeItem, lt.Controls.ImageViewerItemPart.view, true);
        }

        var clonedCanvas: HTMLCanvasElement = document.createElement('canvas');
        clonedCanvas.width = rect.width;
        clonedCanvas.height = rect.height;
        clonedCanvas.style.left = '0px';
        clonedCanvas.style.top = '0px';
        clonedCanvas.style.width = rect.width + 'px';
        clonedCanvas.style.height = rect.height + 'px';

        //blit
        var context = clonedCanvas.getContext('2d');
        context.fillStyle = '#0';
        context.fillRect(0, 0, rect.width, rect.height);
        context.drawImage(canvas, rect.left, rect.top, rect.width, rect.height, 0, 0, rect.width, rect.height);
        if (overlayCanvas)
            context.drawImage(overlayCanvas, 0, 0);

        return clonedCanvas;
    }

    private burnAnnotations(canvas: HTMLCanvasElement) {
        var automation: lt.Annotations.Automation.AnnAutomation = this.get_activeCell().get_automation();        
        if (!automation)
            return;
        var engine: lt.Annotations.Rendering.AnnHtml5RenderingEngine = new lt.Annotations.Rendering.AnnHtml5RenderingEngine();

        engine.attach(automation.get_activeContainer(), canvas.getContext('2d'));
        engine.burn();       
    }
     
    private getImageSize(cellFrame : lt.Controls.Medical.Frame) {
        var originalSize = cellFrame.mrtiInfo.fullSize;

        return { Width: originalSize.width, Height:  originalSize.height };
    }
}

services.service('seriesManagerService', SeriesManagerService);