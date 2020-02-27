// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/LEADTOOLS/Leadtools.Controls.Medical.d.ts" />

module Models {
    export class DerivedInfo {
        private _number: string;

        public get number(): string {
            return this._number;
        }

        public set number(value: string) {
            this._number = value;
        }

        private _description: string;

        public get description(): string {
            return this._description;
        }

        public set description(value: string) {
            this._description = value;
        }

        private _protocolName: string;

        public get protocolName(): string {
            return this._protocolName;
        }

        public set protocolName(value: string) {
            this._protocolName = value;
        }

        constructor() {
            this.number = "";
            this.description = "";
            this.protocolName = "";
        }
    }

   export class PrintOptions {
      public BurnAnnotations : boolean;
      public IncludeOverflowImages : boolean;
      public LayoutImageWidth: number;
      public WhiteBackground: boolean;
      public PatientInfo: boolean;
      public PageWidth: number;
      public PageHeight: number;
      public ReduceGrayscaleTo8BitsSelected: boolean;
      public AnnotationsFileName: string;

      constructor() {
         this.BurnAnnotations = false;
         this.IncludeOverflowImages = false;
         this.LayoutImageWidth = 150;
         this.WhiteBackground = true;
         this.PatientInfo = true;
         this.PageWidth = 0;
         this.PageHeight = 0;
         this.ReduceGrayscaleTo8BitsSelected = false;
         this.AnnotationsFileName = "";
      }
   }

    export class ImageBox {       
      constructor(referencedSOPInstanceUID?: string, left?: number, top?: number, right?: number, bottom?: number) {
          this.referencedSOPInstanceUID = new Array<string>();

          if (referencedSOPInstanceUID != null && referencedSOPInstanceUID.length > 0) {
              this.referencedSOPInstanceUID.push(referencedSOPInstanceUID);
          }

          if (left!=undefined && top!=undefined && right!=undefined && bottom!=undefined) {
              this.Position = new Models.FramePosition(lt.LeadPointD.create(left, top), lt.LeadPointD.create(right, bottom));
          }

          this.RowPosition = -1;
          this.ColumnPosition = -1;
          this.ImageBoxNumber = -1;
          this.NumberOfRows = -1;
          this.NumberOfColumns = -1;
          this.ImageBoxLayoutType = ImageBoxLayoutType.Single;
          this.HorizontalJustification = FrameHorizontalJustification.Center;
          this.VerticalJustification = FrameVerticalJustification.Center;
          this.WindowCenter = -1;
          this.WindowWidth = -1;
          this.ReferencedPresentationStateSOP = "";       
          this.ImageBoxTileHorizontalDimension = 1; 
          this.ImageBoxTileVerticalDimension = 1;
      }

      public referencedSOPInstanceUID: Array<string> = null;
      public Position: FramePosition;      
      public RowPosition: number;
      public ColumnPosition: number; 
      public ImageBoxNumber: number;  
      public NumberOfRows: number;
      public NumberOfColumns: number;
      public ImageBoxLayoutType: ImageBoxLayoutType;      
      public HorizontalJustification: FrameHorizontalJustification;
      public VerticalJustification: FrameVerticalJustification;   
      public FirstFrame: FirstFrame;   
      public WindowWidth: number;
      public WindowCenter: number;    
      public ReferencedPresentationStateSOP: string; 
      public ImageBoxTileHorizontalDimension: number;
      public ImageBoxTileVerticalDimension: number;
      public ImageBoxScrollDirection: ScrollDirection;
      public ImageBoxSmallScrollType: ScrollType; 
      public ImageBoxSmallScrollAmount: number;
      public ImageBoxLargeScrollType: ScrollType;
      public ImageBoxLargeScrollAmount: number; 
        
      public RecommendedDisplayFrameRate: number;   
      public PreferredPlaybackSequencing: number;
   };
    
   export enum PlaybackSequencing {
       // Hanging Protocol Defined
       Looping      = 0,        // Looping (1,2,...,n,1,2,...,n,1,2,...,n,...)
       Sweeping     = 1,        // Sweeping (1,2,...n,n-1,...2,1,2,...n,...)
       Stop         = 2,        // Stop (1,2,...,n)

       // Non-hanging Protocol Defined
       SweepingStop = 3,        // (1,2,...n,n-1,...2,1)
       Backward     = 4,        // (n, n-1, ..., 2, 1, n, n-1, ..., 2, 1)
       BackwardStop = 5,        // (n, n-1, ..., 2, 1)
       Shuffle      = 6,        // Random Continuous
       ShuffleStop  = 7         // Random one time through
   }

   export class SeriesInfo {
       public StudyInstanceUID: string;
       public SeriesInstanceUID: string;              
       public ImageBoxNumber: number;
       public AnnotationData: string;

       constructor() {           
           this.StudyInstanceUID = "";
           this.SeriesInstanceUID = "";
           this.ImageBoxNumber = -1;
           this.AnnotationData = "";          
       }
   }

   export class FirstFrame {
       public SOPClassUID: string;
       public SOPInstanceUID: string;
       public FrameNumber: number;

       constructor() {
           this.SOPClassUID = "";
           this.SOPInstanceUID = "";           
           this.FrameNumber = -1;
       }
   }

   export class Layout {
      constructor() {
          this.Boxes = new Array<ImageBox>();         
          this.TemplateId = "";
      }

      Boxes: Array<ImageBox>;
       TemplateId: string;
   }

   export class StudyLayout {
       public Rows: number;
       public Columns: number;
       public Series: Array<SeriesInfo>;
       public Boxes: Array<ImageBox>;
       public OtherStudies: Array<OtherStudies>;

       constructor() {
           this.Rows = -1;
           this.Columns = -1;
           this.Series = new Array<SeriesInfo>();
           this.Boxes = new Array<ImageBox>();
           this.OtherStudies = new Array<OtherStudies>();
       }

       public SeriesExists(seriesInfo: SeriesInfo) : boolean {
           if (this.Series == null)
               return false; 

           for (var i = 0; i < this.Series.length; i++) {
               if (this.Series[i].SeriesInstanceUID == seriesInfo.SeriesInstanceUID && this.Series[i].StudyInstanceUID == seriesInfo.StudyInstanceUID)
                   return true;
           }
           return false;
       }

       public SeriesPush(seriesInfo: SeriesInfo) {
           if (this.Series != null) {
               if (this.SeriesExists(seriesInfo) == false) {
                   this.Series.push(seriesInfo);
               }
           }
       }
   }

   export class OtherStudies {
       public StudyInstanceUID: string;   
       public Series: Array<SeriesInfo>;

       constructor() {
           this.StudyInstanceUID = '';
           this.Series = new Array<SeriesInfo>();
       }
   }

    export class ExportOptions {
        public BurnAnnotations: boolean;
        public CreateDICOMDIR: boolean;
        public ImageCompression: number;
        public IncludeOverflowImages: boolean;
        public LayoutImageWidth: number;
        public FileFormat: string;
        public ReduceGrayscaleTo8BitsSelected: boolean;
        public Anonymize: boolean;
        public DczPassword: string;
        public IncludeViewer: boolean;
        public WhiteBackground: boolean;
        public PatientInfo: boolean;

        public exportOptions

        constructor() {
            this.BurnAnnotations = false;
            this.CreateDICOMDIR = false;
            this.ImageCompression = 1;
            this.IncludeOverflowImages = false;
            this.LayoutImageWidth = 150;
            this.FileFormat = "BMP";
            this.ReduceGrayscaleTo8BitsSelected = false;
            this.Anonymize = false;
            this.DczPassword = "";
            this.IncludeViewer = false;
            this.WhiteBackground = true;
            this.PatientInfo = true;
        }
    }
   
    export class ExportImageFormat {

        private _WhiteBackground: boolean;

        public get WhiteBackground(): boolean {
            return this._WhiteBackground;
        }

        public set WhiteBackground(value: boolean) {
            if (this._WhiteBackground != value) {
                this._WhiteBackground = value;
            }
        }

        private _PrintPatientInfo: boolean;

        public get PrintPatientInfo(): boolean {
            return this._PrintPatientInfo;
        }

        public set PrintPatientInfo(value: boolean) {
            if (this._PrintPatientInfo != value) {
                this._PrintPatientInfo = value;
            }
        }




        private _CanCompress: boolean;

        public get CanCompress(): boolean {
            return this._CanCompress;
        }

        public set CanCompress(value: boolean) {
            if (this._CanCompress != value) {
                this._CanCompress = value;
            }
        }

        private _CanReduceBitdepth: boolean;

        public get CanReduceBitdepth(): boolean {
            return this._CanReduceBitdepth;
        }

        public set CanReduceBitdepth(value: boolean) {
            if (this._CanReduceBitdepth != value) {
                this._CanReduceBitdepth = value;
            }
        }

        private _CanPreserveBitdepth: boolean;

        public get CanPreserveBitdepth(): boolean {
            return this._CanPreserveBitdepth;
        }

        public set CanPreserveBitdepth(value: boolean) {
            if (this._CanPreserveBitdepth != value) {
                this._CanPreserveBitdepth = value;
            }
        }

        private _DisplayName: string;

        public get DisplayName(): string {
            return this._DisplayName;
        }

        public set DisplayName(value: string) {
            if (this._DisplayName != value) {
                this._DisplayName = value;
            }
        }

        private _Format: string;

        public get Format(): string {
            return this._Format;
        }

        public set Format(value: string) {
            if (this._Format != value) {
                this._Format = value;
            }
        }

        constructor(displayName: string, format: string, canReduceBitdepth: boolean, canPreserveBitdepth: boolean, canCompress?: boolean, canWhiteBackground?: boolean, canPrintPatientInfo?:boolean) {
            canCompress = canCompress || false;

            this._DisplayName = displayName;
            this._Format = format;
            this._CanReduceBitdepth = canReduceBitdepth;
            this._CanPreserveBitdepth = canPreserveBitdepth;
            this._CanCompress = canCompress;
            this._WhiteBackground = canWhiteBackground;
            this._PrintPatientInfo = canPrintPatientInfo;
        }
    }

    export class AnnUserData {
        public ReferencedImageSequence: SopInstanceReference;
        public ImageSize;

        constructor() {
            this.ReferencedImageSequence = null;;
            this.ImageSize = {};
        }
    }

    export class SopInstanceReference {
        public ReferencedSopClassUid;
        public ReferencedSopInstanceUid;
        public ReferencedFrameNumber;

        constructor() {
            this.ReferencedSopClassUid = "";
            this.ReferencedSopInstanceUid = "";
            this.ReferencedFrameNumber = new Array<any>();
        }
    }

    export abstract class RemoteConnection {
        public type: string;
        public id: string;
        public isDefault: boolean;
        public name: string;
        
        constructor() {
            this.type = this.getType();
            this.id = UUID.generate();
            this.isDefault = false;
            this.name = '';
        }

        public abstract getName(): string;
        public abstract getType(): string;
    }

    export class PACSConnection extends RemoteConnection {
        
        public AETitle: string;
        public IPAddress: string;
        public Port: number;          

        constructor() {
            super();
            
            this.AETitle = '';
            this.IPAddress = '';
            this.Port = 0;
        }

        public getType(): string {
            return 'pacs';
        }

        public getName(): string {
            return this.AETitle;
        }

        public static Factory(obj: any): PACSConnection {

            var result: PACSConnection = new PACSConnection ();

            result.AETitle = obj.AETitle;
            result.IPAddress = obj.IPAddress;
            result.Port = obj.Port;
            result.id = obj.id;
            result.name = obj.AETitle;

            return result;
        }
    }

    export class WadoConnection extends RemoteConnection {

        public title: string;
        public dicomWebRoot: string;
        public wado: string;
        public qido: string;
        public rs: string;
        public stow: string;
        public stowMaxFiles: number;
        public stowMaxFileSize: number;
        
        constructor() {
            super();
            
            this.dicomWebRoot = '';
            this.wado = '';
            this.qido = 'qido-rs';
            this.rs = 'wado-rs';
            this.stow = 'stow-rs';
            this.stowMaxFiles = 0;
            this.stowMaxFileSize = 0;
            this.title = '';
        }

        public getType(): string {
            return 'wado';
        }

        public getName(): string {
            return this.title;
        }

        public static Factory(obj: any): WadoConnection {

            var result: WadoConnection = new WadoConnection();

            result.dicomWebRoot = obj.dicomWebRoot;
            result.wado = obj.wado;
            result.qido = obj.qido;
            result.rs = obj.rs;
            result.stow = obj.stow;
            result.stowMaxFiles = obj.stowMaxFiles;
            result.stowMaxFileSize = obj.stowMaxFileSize;
            result.title = obj.title;
            result.id = obj.id;
            result.name = obj.title;

            return result;
        }
    }

    export class RemoteConfig {
        public client: string;
        public servers: Array<RemoteConnection>;
                        
        constructor() {
            this.client= '';
            this.servers = new Array<RemoteConnection>();
        }

        public static Factory(json: string): RemoteConfig {
            var obj: RemoteConfig = new RemoteConfig();

            if (json && json.length > 0) {
                var temp = JSON.parse(json);

                obj.client = temp.client;

                for (var index = 0; index < temp.servers.length; index++) {
                    if (temp.servers[index].type === 'pacs') {
                        obj.servers.push(PACSConnection.Factory(temp.servers[index]));
                    }
                    else if (temp.servers[index].type === 'wado') {
                        obj.servers.push(WadoConnection.Factory(temp.servers[index]));
                    }
                    else {
                        console.error('unsupported object for remote connection');
                    }
                }
            }

            return obj;
        }
    }

    export class DownloadInfo {        
        public Id: string;
        public Server: PACSConnection;
        public Client: any;
        public PatientID: string;
        public StudyInstanceUID: string;
        public SeriesInstanceUID: string;
        public SOPInstanceUID: string;
        public Status: number;
        public ErrorMessage: string;
        public UserData: string;
        public Open: boolean;

        constructor() {
            this.Id = '';
            this.Server = null;
            this.Client = null;
            this.PatientID = '';
            this.StudyInstanceUID = '';
            this.SeriesInstanceUID = '';
            this.SOPInstanceUID = '';
            this.Status = DownloadStatus.Idle;
            this.ErrorMessage = '';
            this.UserData = '';
            this.Open = false;
        }
    }

    export class SeriesExtraInformation {
        public PatientId: string;
        public PatientName: string;
        public StudyDescription: string;
        public SeriesNumber: string;
        public SeriesDescription: string;
        public Modality: string;

        constructor() {
            this.PatientId = "";
            this.PatientName = "";
            this.StudyDescription = "";
            this.SeriesNumber = "";
            this.SeriesDescription = "";
            this.Modality = "";
        }
    }

    export class Role {
        public AssignedPermissions: Array<string>;
        public Description: string;
        public Name: string;

        constructor() {
            this.AssignedPermissions = new Array<string>();
            this.Description = "";
            this.Name = "";
        }
    }

    export class Permission {
        public Description: string;
        public FriendlyName: string;
        public Name: string;

        constructor() {
            this.Description = "";
            this.FriendlyName = "";
            this.Name = "";
        }
    }

    export class Box {
        public left: number;
        public top: number;
        public right: number;
        public bottom: number;

        constructor(left: number, top: number, right: number, bottom: number) {
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
        }
    }

    export class StudyLayoutOption {
        public name: string;
        public friendlyName: string;
        public icon: string;
        public boxes: Array<Box>;

        constructor(name: string, friendlyName: string, icon: string) {
            this.name = name;
            this.friendlyName = friendlyName;
            this.icon = icon;
            this.boxes = new Array<Box>();
        }
    } 

    export class PrintViewOptions {
        private _BurnAnnotations: boolean;

        public get BurnAnnotations(): boolean {
            return this._BurnAnnotations;
        }

        private _LayoutImageWidth: number;

        public get LayoutImageWidth(): number {
            return this._LayoutImageWidth;
        }

        public set LayoutImageWidth(value: number) {
            this._LayoutImageWidth = value;
        }

        private _Boxes: Array<ImageBox>;
        public get Boxes(): Array<ImageBox> {
            return this._Boxes;
        }

        constructor() {
            this._Boxes = new Array<ImageBox>();
            this._LayoutImageWidth = 1024;
        }
    } 

    export class UserPatientPermission {
        public User: string;
        public PatientId: string;

        constructor(user?: string, patientId?: string) {
            this.User = user;
            this.PatientId = patientId;
        }
    }  

    export class RolePatientPermission {
        public Role: string;
        public PatientId: string;

        constructor(role?: string, patientId?: string) {
            this.Role = role;
            this.PatientId = patientId;
        }
    }

    export class MRTIStatus {
        public static get COMPLETE(): number { return 0; }
        public static get PARTIAL(): number { return 1; }
        public static get NONE(): number { return 2; }
    }

    export enum ImageBoxLayoutType {
        Tiled,
        Stack,
        Cine,
        Processed,
        Single,
    }

    export enum ValueRepresentation {
        AE   ,    // Application Entity
        AS   ,    // Age String
        AT   ,    // Attribute Tag
        CS   ,    // Code String
        DA   ,    // Date
        DS   ,    // Decimal String
        DT   ,    // Date Time
        FD   ,    // Floating Point Double
        FL   ,    // Floating Point Single
        IS   ,    // Integer String
        LO   ,    // Long String
        LT   ,    // Long Text
        OB   ,    // Other Byte String
        OW   ,    // Other Word String
        PN   ,    // Person Name
        SH   ,    // Short String
        SL   ,    // Signed Long
        SQ   ,    // Sequence of Items
        SS   ,    // Signed Short
        ST   ,    // Short Text
        TM   ,    // Time
        UI   ,    // Unique Identifier
        UL   ,    // Unsigned Long
        UN   ,    // Unknown
        US   ,    // Unsigned Short
        UT   ,    // Unlimited Text
        OF   ,    // Other Float Strings
        UR   ,    // Universal Resource Identifier or Universal Resource Locator(URI/URL)
        UC   ,    // Unlimited Characters
        OD        // Other Double String
    }

    export class HangingProtocol {

        // ************************************************
        // *** Module Hanging Protocol Definition
        // ************************************************
        public HangingProtocolName: string;                                         // Mandatory
        public HangingProtocolDescription: string;                                  // Mandatory
        public HangingProtocolLevel: HangingProtocolLevel;                          // Mandatory
        public HangingProtocolCreator: string;                                      // Mandatory
        public WCFHangingProtocolCreationDateTime: Date;                            // Mandatory
        public HangingProtocolDefinitionSequence: Array<HangingProtocolDefinition>; // Mandatory
        public NumberOfPriorsReferenced: number;                                    // Mandatory
        public ImageSetsSequence: Array<ImageSet>;                                  // Mandatory
        public HangingProtocolUserIdentificationCodeSequence: Array<HangingProtocolUserIdentificationCode>; // Mandatory
        public HangingProtocolUserGroupName: string;                                // Optional
        // Source Hanging Protocol Sequence                                         // Optional                      
        
        // ************************************************
        // *** Module Hanging Protocol Environment
        // ************************************************
        public NumberOfScreens: number;                                             // Mandatory
        public NominalScreenDefinitionSequence: Array<NominalScreenDefinition>;     // Mandatory

        // ************************************************
        // *** Module Hanging Protocol Display
        // ************************************************
        public DisplaySets: Array<DisplaySet>;                                      // Mandatory
        public PartialDataDisplayHandling: PartialDataDisplayHandling;              // Mandatory
        public SynchronizedScrollingSequence: Array<SynchronizedScrolling>;         // Optional
        public NavigationIndicatorSequence: Array<NavigationIndicator>;             // Optional

        // ************************************************
        // *** LEAD Specific
        // ************************************************
        public Rows: number;
        public Columns: number;

        public deleteSimilarFilterOperations(inputFilterOperation: FilterOperation) {
            var filterOperationValues = new Array<String>();
            var displaySetCount: number = this.DisplaySets.length

            for (var d = displaySetCount-1; d >=0; d--) {
                var displaySet = this.DisplaySets[d];
                var filterOperationLength: number = displaySet.FilterOperationsSequence.length;
                for (var f = filterOperationLength - 1; f >=0; f--) {
                    var filterOperation: FilterOperation = displaySet.FilterOperationsSequence[f];
                    if (filterOperation.isFilterOperationsEqual(inputFilterOperation)) {
                    // if (filterOperation.WCFSelectorAttribute == inputFilterOperation.WCFSelectorAttribute) {
                        displaySet.FilterOperationsSequence.splice(f, 1);
                    }
                }
            }
        }

        public cloneFilterOperation(inputFilterOperation: FilterOperation) {
            var displaySetCount: number = this.DisplaySets.length
            for (var d = 0; d < displaySetCount; d++) {
                var displaySet = this.DisplaySets[d];

                var exists: boolean = displaySet.existsFilterOperation(inputFilterOperation);
                if (exists == false) {

                    // clone the filter operation
                    var newFilterOperation : FilterOperation = Utils.clone(inputFilterOperation);

                    var dicom = displaySet['metadata'];

                    var dicomPrevious = null;

                    var result = null;
                    var index: number = 0;  // This needs to change as SelectorSeqencePointerItems (i.e. 1\2\1 );
                    var dicomTags = inputFilterOperation.WCFSelectorSequencePointer.split("\\");
                    var SelectorSeqencePointerItemsArray = inputFilterOperation.WCFSelectorSequencePointerItems.split("\\");

                    for (var i = 0; i < dicomTags.length; i++) {
                        var dicomTag: string = dicomTags[i].replace(":", "");     
                        if (dicom.hasOwnProperty(dicomTag)) {
                            result = dicom[dicomTag];
                            dicomPrevious = dicom;

                            index = parseInt(SelectorSeqencePointerItemsArray[i]) - 1;
                            dicom = DicomHelper.get_TagValue(dicom, dicomTag, index);
                        }

                        // var dicomTagValue: string = DicomHelper.cloneDicomTagValue(displaySet['metadata'], dicomTag);
                    }

                    var dicomTagValue: string = "";

                    if (result.vr == 'PN') {
                        dicomTagValue = DicomHelper.getPatientNameFromTag(result);
                    }

                    else if (result.vr != 'SQ') {
                        var value: string = DicomHelper.getConvertValue(result);

                        //if (result.vr == 'DA') {
                        //    if (value) {
                        //        var DateJS: IDateJS = <any>(new Date(DicomHelper.parseDicomDate(value)));

                        //        value = DateJS.toString(this._dateFormat);
                        //    }
                        //}

                        //if (result.vr == 'TM') {
                        //    if (value) {
                        //        var DateJS: IDateJS = (<any>Date).today().at(DicomHelper.parseDicomTime(value));

                        //        value = DateJS.toString(this._timeFormat);
                        //    }
                        //}

                        dicomTagValue = value;
                    }
                    else {
                        if (result.Value && result.Value.length > 0) {
                            var lastIndex: number = dicomTags.length - 1;
                            var lastDicomTag: string = dicomTags[lastIndex].replace(":", "");

                            var lastSelectorItemIndex: number = SelectorSeqencePointerItemsArray.length - 1;
                            var lastSelectorItemString: string = null;
                            if (lastSelectorItemIndex >= 0) {
                                lastSelectorItemString = SelectorSeqencePointerItemsArray[lastSelectorItemIndex];
                            }

                            var codeSequenceList = DicomHelper.getCodeSequenceList(dicomPrevious, lastDicomTag, lastSelectorItemString);

                            if (codeSequenceList.length > 0) {
                                newFilterOperation.SelectorCodeSequenceValue = codeSequenceList;
                                var codeSequence: Models.CodeSequence = codeSequenceList[0];
                                dicomTagValue = codeSequence.toFullString();
                            }
                            else {
                                newFilterOperation = null;
                            }
                        }
                    } 

                    if (newFilterOperation != null) {
                        newFilterOperation.SelectorValue = dicomTagValue;
                        displaySet.FilterOperationsSequence.push(newFilterOperation);
                    }
                }
            }
        }

        public mergeFilterOperationValues(inputFilterOperation: FilterOperation) {
            var filterOperationValues = new Array<String>();
            var displaySetCount: number = this.DisplaySets.length

            for (var d = 0; d < displaySetCount; d++) {
                var displaySet = this.DisplaySets[d];
                var filterOperationLength: number = displaySet.FilterOperationsSequence.length;
                for (var f = 0; f < filterOperationLength; f++) {
                    var filterOperation: FilterOperation = displaySet.FilterOperationsSequence[f];
                    if (filterOperation.WCFSelectorAttribute == inputFilterOperation.WCFSelectorAttribute) {
                        if (filterOperationValues.indexOf(filterOperation.SelectorValue) == -1) {
                            filterOperationValues.push(filterOperation.SelectorValue);
                        }
                    }
                }
            }

            var newSelectorValue: string = filterOperationValues.join("\\");

            for (var d = 0; d < displaySetCount; d++) {
                var displaySet = this.DisplaySets[d];
                var filterOperationLength: number = displaySet.FilterOperationsSequence.length;
                for (var f = 0; f < filterOperationLength; f++) {
                    var filterOperation: FilterOperation = displaySet.FilterOperationsSequence[f];
                    if (filterOperation.WCFSelectorAttribute == inputFilterOperation.WCFSelectorAttribute) {
                        filterOperation.SelectorValue = newSelectorValue;
                    }
                }
            }
        }

        public getNextImageSetNumber(): number {
            var nextImageSetNumber: number = 0;

            for (var i = 0; i < this.ImageSetsSequence.length; i++) {
                this.ImageSetsSequence[i].TimeBasedImageSetsSequence.forEach(function (element) {
                    if (nextImageSetNumber < element.ImageSetNumber) {
                        nextImageSetNumber = element.ImageSetNumber;
                    }
                });
            }
            return nextImageSetNumber + 1;
        }

        public getNumberOfPriorsReferenced(): number {
            var numberOfPriorsReferenced: number = 0;

            for (var i = 0; i < this.ImageSetsSequence.length; i++) {
                numberOfPriorsReferenced += this.ImageSetsSequence[i].TimeBasedImageSetsSequence.length - 1;
            }
            return numberOfPriorsReferenced;
        }

        public updateImageSetSelectorValues() : void {
        }

        public getTimeBasedImageSetLabel(imageSetNumber: number): string {
            var imageSetLabel: string = "";
            for (var i = 0; i < this.ImageSetsSequence.length; i++) {
                this.ImageSetsSequence[i].TimeBasedImageSetsSequence.forEach(function (element) {
                    if (imageSetNumber == element.ImageSetNumber) {
                        imageSetLabel = element.ImageSetLabel;
                    }
                });
            }
            return imageSetLabel;
        }

        private getCellMprTypeName(mprType: InitialViewDirection): string {
            var ret: string = "";

            switch (mprType) {
                case InitialViewDirection.Axial:
                    ret = "Axial";
                    break;

                case InitialViewDirection.Sagittal:
                    ret = "Sagittal";
                    break;

                case InitialViewDirection.Coronal:
                    ret = "Coronal";
                    break;

                case InitialViewDirection.None:
                    ret = "";
                    break;
            }
            return ret;
        }

        public updateDisplaySetCombinedName() {
            for (var i = 0; i < this.DisplaySets.length; i++) {
                var displaySet: Models.DisplaySet = this.DisplaySets[i];

                if (displaySet.ReformattingOperationInitialViewDirection != null) {
                    // displaySet["CombinedName"] = displaySet.DisplaySetLabel + " - " + this.getTimeBasedImageSetLabel(displaySet.ImageSetNumber); //imageSet.Name;
                    var mprTypeName: string = this.getCellMprTypeName(displaySet.ReformattingOperationInitialViewDirection);

                    displaySet["CombinedName"] = displaySet.DisplaySetLabel + " (MPR Reformatted " + mprTypeName + ") - " + this.getTimeBasedImageSetLabel(displaySet.ImageSetNumber); //+ imageSet.Name;
                }
                else {
                    displaySet["CombinedName"] = displaySet.DisplaySetLabel + " - " + this.getTimeBasedImageSetLabel(displaySet.ImageSetNumber); //imageSet.Name;
                }
            }
        }

        public sortFilterOperations() {
            var count: number = this.DisplaySets.length;
            for (var i = 0; i < count; i++) {
                this.DisplaySets[i].sortFilterOperations();
            }
        }

        constructor() {
            // Module Hanging Protocol Definition
            this.HangingProtocolName = "";
            this.HangingProtocolDescription = "";
            this.HangingProtocolLevel = HangingProtocolLevel.Site;
            this.HangingProtocolCreator = "";
            this.WCFHangingProtocolCreationDateTime = new Date();
            this.HangingProtocolDefinitionSequence = new Array<HangingProtocolDefinition>();
            this.NumberOfPriorsReferenced = 0;
            this.ImageSetsSequence = new Array<ImageSet>();
            this.HangingProtocolUserIdentificationCodeSequence = new Array<Models.HangingProtocolUserIdentificationCode>();
            this.HangingProtocolUserGroupName = null;

            // Module Hanging Protocol Environment
            this.NumberOfScreens = 1;
            this.NominalScreenDefinitionSequence = new Array<NominalScreenDefinition>();

            // Module Hanging Protocol Display
            this.DisplaySets = new Array<DisplaySet>();
            this.PartialDataDisplayHandling = PartialDataDisplayHandling.MaintainLayout;
            this.SynchronizedScrollingSequence = null;
            this.NavigationIndicatorSequence = null;

            // LEAD Specific
            this.Rows = -1;
            this.Columns = -1;
        }
    }

    export class HangingProtocolDefinition {
        public StudyDescription: string;
        public Modality: string;
        public AnatomicRegionSequence: Array<CodeSequence>;
        public Laterality: Laterality;
        public ProcedureCodeSequence: Array<CodeSequence>;
        public ReasonForRequestedProcedureCodeSequence: Array<CodeSequence>;
        public BodyPartExamined: string;
        public ProtocolName: string;
        public RequestedProcedureCodeSequence: Array<CodeSequence>;
        public ScheduledProtocolCodeSequence: Array<CodeSequence>;

        constructor() {
            this.StudyDescription = "";
            this.AnatomicRegionSequence = new Array<CodeSequence>();
            this.ProcedureCodeSequence = new Array<CodeSequence>();
            this.ReasonForRequestedProcedureCodeSequence = new Array<CodeSequence>();
            this.Laterality = null;
            this.BodyPartExamined = "";
            this.ProtocolName = "";
            this.RequestedProcedureCodeSequence = null;
            this.ScheduledProtocolCodeSequence = null;
        }
    }

    export class ImageSet {
        public ImageSetSelectorSequence: Array<ImageSetSelector>;
        public TimeBasedImageSetsSequence: Array<TimeBasedImageSet>;
        public Name: string;

        public Key: string;

        // Returns 0 if there is no TimeBasedImageSet with that date
        // Otherwise, returns the ImageSetNumber of the TimeBasedImageSet that was found
        public FindTimeBasedImageSetNumber(date: IDateJS): number {
            if (this.TimeBasedImageSetsSequence == null)
                return 0;

            for (var i = 0; i < this.TimeBasedImageSetsSequence.length; i++) {
                if (this.TimeBasedImageSetsSequence[i].StudyDateTime.equals(date))
                    return this.TimeBasedImageSetsSequence[i].ImageSetNumber;
            }
            return 0;
        }

        public AddTimeBasedImageSet(studyDateTime: IDateJS, imageSetNumber : number): number {
            var timeBasedImageSet: TimeBasedImageSet = new TimeBasedImageSet(imageSetNumber);
            timeBasedImageSet.StudyDateTime = studyDateTime;
            this.TimeBasedImageSetsSequence.push(timeBasedImageSet);
            return imageSetNumber;
        }

        private splitCamelCaseToString(s) {
            return s.split(/(?=[A-Z])/).join(' ');
        }


        public UpdateImageSelectorItem(metadata: any, dicomTag: string, imageSetSelectorName : string): void { 
            var tagValue: string = DicomHelper.getDicomTagValue(metadata, dicomTag);

            if (tagValue != null && tagValue.length != 0) {
                tagValue = tagValue.trim();
                var imageSetSelector: ImageSetSelector = null;
                this.ImageSetSelectorSequence.forEach((x: ImageSetSelector) => {
                    if (x.SelectorName === imageSetSelectorName)
                        imageSetSelector = x;
                });

                if (imageSetSelector == null) {
                    imageSetSelector = new Models.ImageSetSelector();

                    imageSetSelector.ImageSetSelectorUsageFlag = Models.ImageSetSelectorUsage.Match;
                    imageSetSelector.WCFSelectorAttribute = Utils.insert(dicomTag, 4, ":");
                    imageSetSelector.SelectorValueNumber = 1;
                    imageSetSelector.SelectorValue = tagValue;
                    imageSetSelector.SelectorName = imageSetSelectorName;
                    this.ImageSetSelectorSequence.push(imageSetSelector);
                }
                else {
                    var selectorValues: Array<string> = imageSetSelector.SelectorValue.split('\\');
                    var exists: boolean = false;
                    for (var i = 0; i < selectorValues.length; i++) {
                        if (selectorValues[i] == tagValue) {
                            exists = true;
                            break;
                        }
                    }
                    if (!exists) {
                        imageSetSelector.SelectorValue = imageSetSelector.SelectorValue + '\\' + tagValue;
                    }
                }
            }
        }

        constructor() {
            this.ImageSetSelectorSequence = new Array<ImageSetSelector>();
            this.TimeBasedImageSetsSequence = new Array<TimeBasedImageSet>();
            this.Name = '';
        }
    }

    export class ImageSetSelector {
        public ImageSetSelectorUsageFlag: ImageSetSelectorUsage;
        public WCFSelectorAttribute: string;
        public SelectorValueNumber: number;
        public SelectorValue: string;
        public SelectorName: string;
        public WCFSelectorSequencePointer: string;
        public SelectorAttributeVr: string;
        public SelectorCodeSequenceValue: Array<Models.CodeSequence>;

        constructor() {
            this.ImageSetSelectorUsageFlag = ImageSetSelectorUsage.Match;
            this.WCFSelectorAttribute = '';
            this.SelectorValueNumber = 0;         
            this.SelectorValue = '';
            this.SelectorName = '';
            this.WCFSelectorSequencePointer = '';
            this.SelectorAttributeVr = '';
            this.SelectorCodeSequenceValue = new Array<Models.CodeSequence>();
        }
    }

    export class TimeBasedImageSet {
        public ImageSetNumber: number;
        public ImageSetSelectorCategory: ImageSetSelectorCategory;
        public RelativeTime: Array<number>;
        public RelativeTimeUnits: RelativeTimeUnits;
        public AbstractPriorValue: Array<number>;
        public ImageSetLabel: string;

        public StudyDateTime: IDateJS; 

        constructor(imageSetNumber : number) {
            this.RelativeTime = new Array<number>();
            this.AbstractPriorValue = new Array<number>();
            this.ImageSetNumber = imageSetNumber;
        }
    }

    export class DisplaySet {
        public DisplaySetNumber: number;
        public DisplaySetLabel: string;
        public DisplaySetPresentationGroup: number;
        public ImageSetNumber: number;
        public Boxes: Array<Models.ImageBox>;
        public FilterOperationsSequence: Array<FilterOperation>;
        public SortingOperationsSequence: Array<SortingOperations>;
        // Blending Operation Type
        public ReformattingOperationType: ReformattingOperationType;
        public ReformattingThickness: number;
        public ReformattingInterval: number;
        public ReformattingOperationInitialViewDirection: InitialViewDirection;
        // 3D Rendering Type
        public DisplaySetPatientOrientation: Array<string>;
        public DisplaySetHorizontalJustification: FrameHorizontalJustification;
        public DisplaySetVerticalJustification: FrameVerticalJustification;
        public VoiType: VoiType;
        // Pseudo-Color Type
        // Pseudo-Color Palette Instance Reference Sequence
        public ShowGrayscaleInverted : boolean;
        public ShowImageTrueSizeFlag: boolean;
        public ShowGraphicAnnotationFlag: boolean;
        public ShowPatientDemographicsFlag: boolean;
        // Show Acquisition Techniques Flag
        // Display Set Presentation Group Description
         

        public existsFilterOperation(testFilterOperation : FilterOperation): boolean {
            var exists: boolean = false;
            var count: number = this.FilterOperationsSequence.length;
            for (var i = 0; i < count; i++) {
                var filterOperation: FilterOperation = this.FilterOperationsSequence[i];
                exists = filterOperation.isFilterOperationsEqual(testFilterOperation);
                if (exists) {
                    break;
                }
            }
            return exists;
        }

        private dynamicSort(property) {
            var sortOrder = 1;
            if (property[0] === "-") {
                sortOrder = -1;
                property = property.substr(1);
            }
            return function (a, b) {
                var result = (a[property] < b[property]) ? -1 : (a[property] > b[property]) ? 1 : 0;
                return result * sortOrder;
            }
        }

        private filterOperationCompare(a: FilterOperation, b: FilterOperation) {
            return a.WCFSelectorAttribute.localeCompare(b.WCFSelectorAttribute);
        }

        public sortFilterOperations(): void {
            this.FilterOperationsSequence.sort(this.filterOperationCompare);
        }

        constructor() {
            this.Boxes = new Array<Models.ImageBox>();
            this.DisplaySetHorizontalJustification = Models.FrameHorizontalJustification.Center;
            this.DisplaySetVerticalJustification = Models.FrameVerticalJustification.Center;
            this.FilterOperationsSequence = new Array<FilterOperation>();
            this.DisplaySetPatientOrientation = new Array<string>(2);
        }
    }

    export class HangingProtocolUserIdentificationCode {

        // Code Value (Conditional)
        public CodeValue: string;

        // Coding Scheme Designator (Conditional)
        public CodeSchemeDesignator: string;

        // Coding Scheme Version  (Conditional)
        public CodingSchemeVersion: string;

        // Code Meaning (Mandatory)
        public CodeMeaning: string;

        // Long Code Value (Conditional)
        public LongCodeValue: string;

        // URN Code Value
        public URNCodeValue: string;

        // Equivalent Code Sequence (Optional)
        // xxx

        // Context Identifier (Optional)
        public ContextIdentifier: string;

        // Context UID (Optional)
        public ContextUID: string;

        // Mapping Resource (Conditional)
        public MappingResource: string;

        // Mapping Resource UID (Optional)
        public MappingResourceUID: string;

        // Context Group Version (Conditional)
        public ContextGroupVersion: string;

        // Context Group Extension Flag (Optional)
        public ContextGroupExtensionFlag: string;

        // Context Group Local Version (Conditional)
        public ContextGroupLocalVersion: string;

        // Context Group Extension Creator UID (Conditional)
        public ContextGroupExtensionCreatorUID: string;

        constructor() {
        }

    }

    export class NominalScreenDefinition {
        public NumberOfVerticalPixels: number;
        public NumberOfHorizontalPixels: number;
        public DisplayEnvironmentSpatialPosition: Array<number>;
        public ScreenMinimumGrayscaleBitDepth: number;
        public ScreenMinimumColorBitDepth: number;
        public ApplicationMaximumRepaintTime: number;

        constructor() {
        }
    }

    export class SynchronizedScrolling {
        public DisplaySetScrollingGroup: Array<number>;

        constructor() {
            this.DisplaySetScrollingGroup = new Array<number>();
        }
    }

    export class NavigationIndicator {
        public NavigationDisplaySet: number;
        public ReferenceDisplaySets: Array<number>;
    }

    export class ValueRange {
        public ValueMinimum: number;
        public ValueMaximum: number;

        constructor() {
        this.ValueMinimum = 0;
        this.ValueMaximum = 0;
        }

    }
    export class FilterOperation {
        public FilterByCategory: string;        
        public WCFSelectorAttribute: string;
        public SelectorAttributeVr: string;
        public SelectorValueNumber: number;
        public SelectorValue: string;
        public SelectorName: string;
        public FilterByOperator: FilterByOperator; 
        public WCFSelectorSequencePointer: string;
        public WCFSelectorSequencePointerItems: string;
        public SelectorCodeSequenceValue: Array<Models.CodeSequence>;
        
        // public ImagePlaneSelectorValue: string;
        // public ImagePlaneChecked: boolean;
        public ImageSetSelectorUsageFlag: ImageSetSelectorUsage; 

        public isFilterOperationsEqual(f1: FilterOperation): boolean {
            var isSame: boolean = false;

            isSame =
            (this.WCFSelectorAttribute == f1.WCFSelectorAttribute) &&
            (this.WCFSelectorSequencePointer == f1.WCFSelectorSequencePointer) &&
            (this.WCFSelectorSequencePointerItems == f1.WCFSelectorSequencePointerItems);

            return isSame;
        }

        constructor() {
            this.ImageSetSelectorUsageFlag = ImageSetSelectorUsage.Match;
            this.SelectorValue = "";
            this.SelectorValueNumber = 0;
            this.SelectorName = "";
            this.WCFSelectorAttribute = "";
        }
    }

    export class SortingOperations {
        public SelectorAttribute: number;
        public SelectorValueNumber: number; 
        public SortByCategory: SortByCategory;
        public SortingDirection: SortingDirection;

        public Convert(sortingOperation: lt.Controls.Medical.SortingOperation) {
            if (Utils.isValidNumber(sortingOperation.selectorAttribute)) {
                this.SelectorAttribute = sortingOperation.selectorAttribute; //Utils.longToDicomTag(sortingOperation.selectorAttribute);
                this.SelectorValueNumber = 1;
            }

            switch (sortingOperation.sortByCategory) {
                case lt.Controls.Medical.SortType.byAxis:
                    this.SortByCategory = SortByCategory.AlongAxis;
                    break;
                case lt.Controls.Medical.SortType.byAcquisitionTime:
                    this.SortByCategory = SortByCategory.ByAcquireTime;
                    break;
            }

            switch (sortingOperation.order) {
                case lt.Controls.Medical.SortOrder.ascending:
                    this.SortingDirection = SortingDirection.Increasing;
                    break;
                case lt.Controls.Medical.SortOrder.descending:
                    this.SortingDirection = SortingDirection.Decreasing;
                    break; 
            }
        }
    }

    export class HangingProtocolQuery {
        public Name: string;
        public Description: string;
        public Creator: string;
        public HangingProtocolDefinitionSequence: Array<HangingProtocolDefinition>;

        constructor() {
            this.Name = '';
            this.Description = '';
            this.Creator = '';
            this.HangingProtocolDefinitionSequence = new Array<HangingProtocolDefinition>();
        }
    }

    export class HangingProtocolQueryResult {
        public Name: string;
        public SOPInstanceUID: string;
        public Level: Models.HangingProtocolLevel;

        constructor() {
            this.Name = '';
            this.SOPInstanceUID = '';
            this.Level = null;
        }
    }

    export class DicomData {
        public name: string;
        public tag: string;
        public value: string;
        public vr: string;

        constructor(name: string, tag: string) {
            this.name = name;
            this.tag = tag;
            this.value = '';
            this.vr = '';
        }
    }

    export class DicomTagRow {
        public children: Array<DicomTagRow>;
        public group: boolean;
        public expanded: boolean;
        public data: DicomData;

        constructor(data: DicomData) {
            this.children = new Array<DicomTagRow>();
            this.group = false;
            this.expanded = true;
            this.data = data;
        }
    }

    export enum HangingProtocolLevel {
        Manufacturer,
        Site,
        UserGroup,
        SingleUser
    }

    export enum ImageSetSelectorUsage {
        Match,
        NoMatch
    }

    export enum ImageSetSelectorCategory {
        RelativeTime,
        AbstractPrior
    }

    export enum RelativeTimeUnits {
        Seconds,
        Minutes,
        Hours,
        Days,
        Weeks,
        Months,
        Years
    }

    export enum AttributePresence {
        Present,
        NotPresent
    }

    export enum FilterByOperator {
        RangeInclusive,
        RangeExclusive,
        GreaterOrEqual,
        LessOrEqual,
        GreaterThan,
        LessThan,
        MemberOf,
        NotMemberOf
    }

    export enum InitialViewDirection {
        None = -1,
        Axial,
        Sagittal,
        Coronal
    }

    export enum ReformattingOperationType {
        Mpr,
        ThreeDRendering,
        Slab
    }

    export enum ScrollDirection {
        None = 0,
        Vertical = 1,
        Horizontal = 2
    }

    export enum ScrollType {
        None,
        Page,
        RowColumn,
        Image
    }

    export enum SortByCategory {
        AlongAxis,
        ByAcquireTime
    }

    export enum SortingDirection {
        Increasing,
        Decreasing
    }

    export enum PartialDataDisplayHandling {
       Undefined,
       MaintainLayout,
       AdaptLayout
    }

    export enum VoiType {
        // Hanging Protocol defined
        Undefined = 0,
        Lung = 1,
        Mediastinum = 2,
        AbdoPelvis = 3,
        Liver = 4,
        SoftTissue = 5,
        Bone = 6,
        Brain = 7,
        PostFossa = 8, 

        // Demo Specific
        BrainT1 = 9,
        BrainT2 = 10,
        SagT2 = 11,
        HeadNeck = 12, 
        Spine = 13,
        AbdomenPelvisT1 = 14,
        AbdomenPelvisT2 = 15,
        LowContrast = 16,
        MediumContrast = 17, 
        HighContrast = 18
    }

    export namespace VoiType {
        export function fromString(s: string): VoiType {
            if (s == "LUNG")
                return VoiType.Lung;
            if (s == "Mediastinum")
                return VoiType.Mediastinum;
            if (s == "AbdoPelvis")
                return VoiType.AbdoPelvis;
            if (s == "Liver")
                return VoiType.Liver;
            if (s == "SoftTissue")
                return VoiType.SoftTissue;
            if (s == "Bone")
                return VoiType.Bone;
            if (s == "Brain")
                return VoiType.Brain;
            if (s == "PostFossa")
                return VoiType.PostFossa;
            //if (s == "XXXXX")
            //    return VoiType.Xxxx;

            return VoiType.Undefined;
        }
    }

    // Used in the Hanging Protocol 'Level' dropdown
    export class DropDownItem {
        public name: string;
        public id: number;

        constructor(id: number, name: string) {
            this.name = name;
            this.id = id;
        }
    }







    export class Settings3DOptions {
        public volumeType: string;
        public lowResQuality: number;
        public highResQuality: number;
        public isoThreshold: number;
        public showCrossLines: boolean;
        public showClippingFrame: boolean;
        public showVolumeBorder: boolean;
        public showRotationCube: boolean;
        public projectionMethod: number;
        public resizeFactor: number;

        public Settings3DOptions

        constructor() {
            this.volumeType = 'Volume';
            this.lowResQuality = 0.5;
            this.isoThreshold = 50;
            this.showCrossLines = false;
            this.showClippingFrame = false;
            this.showVolumeBorder = true;
            this.showRotationCube = true;
            this.projectionMethod = 1;
            this.resizeFactor = 1;
            this.highResQuality = 1.2;
        }
    }




}
