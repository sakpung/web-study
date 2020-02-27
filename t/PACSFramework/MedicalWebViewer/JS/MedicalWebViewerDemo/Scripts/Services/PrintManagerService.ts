// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
//module PrintImagesSource {
//    export var AllPatientImages: string = "AllPatientImages";
//    export var LoadedSeries: string = "LoadedSeries";
//    export var CurrentSeries: string = "CurrentSeries";
//    export var SelectedImages: string = "SelectedImages";
//    export var Layout: string = "Layout";
//}

class PrintManagerService {
    static $inject = ['printService', 'seriesManagerService', 'tabService', 'objectRetrieveService'];

    private _printService: PrintService;
    private _seriesManagerService: SeriesManagerService;
    private _objectRetrieveService: ObjectRetrieveService;

    constructor(printService: PrintService, seriesManagerService: SeriesManagerService, tabService: TabService, objectRetrieveService: ObjectRetrieveService) {
        this._printService = printService;
        this._seriesManagerService = seriesManagerService;
        this._objectRetrieveService = objectRetrieveService;
    }

    public Print(printOptions: Models.PrintOptions, source: string): ng.IHttpPromise<any> {

        switch (source) {
            case PrintImagesSource.AllPatientImages:
                var cellFrame = this._seriesManagerService.get_activeCellFrame();
                var patientId = DicomHelper.getDicomTag(cellFrame.DicomData, DicomTag.PatientID).text();

               return this._printService.PrintAllSeries(patientId, printOptions);
           case PrintImagesSource.Layout:
                var seriesInstanceUID = this._seriesManagerService.get_activeSeriesCell().get_seriesInstanceUID();
                var layout = this._seriesManagerService.get_layout(seriesInstanceUID);

              return this._printService.PrintLayout(seriesInstanceUID, layout, printOptions.BurnAnnotations, printOptions.LayoutImageWidth);
           case PrintImagesSource.SelectedImages:
                var cellFrame = this._seriesManagerService.get_activeCellFrame();

              return this._printService.PrintInstances([cellFrame.Instance.SOPInstanceUID], printOptions);
            default:
                var seriesInstanceUID = this._seriesManagerService.get_activeSeriesCell().get_seriesInstanceUID();

               return this._printService.PrintSeries([seriesInstanceUID], printOptions);
        }
    }
}

services.service('printManagerService', PrintManagerService);