// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="AuthenticationService.ts" />

class ObjectRetrieveService {
    static $inject = ['app.config', 'authenticationService', '$http'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;
    private _retrieveLocalUrl;
    private _threedLocalUrl;

    constructor(config, authenticationService, $http: ng.IHttpService, eventService: EventService) {
        this._http = $http;
        this._authenticationService = authenticationService;
        this._retrieveLocalUrl = config.urls.serviceUrl + config.urls.objectRetrieveLocalServiceName;
        if (config.urls.threeDserviceUrl) {
            this._threedLocalUrl = config.urls.threeDserviceUrl + config.urls.threeDServiceName;
        }
        else {
            this._threedLocalUrl = config.urls.serviceUrl + config.urls.threeDServiceName;
        }
    }

    public GetImageUrl(frame, maxWidth: number, maxHeight: number): string {        
        var maxSize = "";

        if (maxWidth && maxHeight) {
            maxSize = '&cx=' + maxWidth + '&cy=' + maxHeight;
        }

        return this._retrieveLocalUrl + '/GetImage?auth=' + encodeURIComponent(this._authenticationService.authenticationCode) + '&instance=' + frame.Instance.SOPInstanceUID + '&frame=' + frame.FrameNumber + '&bp=0&qf=0&mime=image/jpeg' + maxSize;
    }

    public GetDicomImageDataAsPngURL(studyInstanceUID, seriesInstanceUID, sopInstanceUID, frameNumber, userData, functions?) {
        var data = userData;
        var parameter:string; 
        var callUrl: string;

        data.functions = functions || null;
        parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&study=" + studyInstanceUID + "&series=" + seriesInstanceUID + "&instance=" + sopInstanceUID + "&frame=" + frameNumber + "&data=" + JSON.stringify(data);
        callUrl = this._retrieveLocalUrl + "/GetDicomImageDataAsPNG" + "?" + parameter;

        return callUrl;
    }

    public GetMPRFrame(id, mprType, index) {
        return this._threedLocalUrl + "/GetMPRImage?" + "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&id=" + id + "&mprType=" + mprType + "&index=" + index;
    }




    public GetImageUrlPreprocessed(frame, maxWidth, maxHeight, functions, random?:boolean): string {        
        var data: any = {};
        var maxSize = "";
        var addRandom: string = "";

        if (maxWidth && maxHeight) {
            maxSize = '&cx=' + maxWidth + '&cy=' + maxHeight;
        }

        if (random) {
            addRandom = '&r=' + Date.now();
        }

        data.width = 0;
        data.height = 0;
        data.functions = functions;

        return this._retrieveLocalUrl + '/GetImage?auth=' + encodeURIComponent(this._authenticationService.authenticationCode) + '&instance=' + frame.Instance.SOPInstanceUID + '&frame=' + frame.FrameNumber + maxSize + "&data=" + JSON.stringify(data) + addRandom;
    }

    public GetSeriesLayout(seriesInstanceUID: string, userData): ng.IHttpPromise<any> {
        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&seriesinstanceUID=" + seriesInstanceUID + "&data=" + userData + '&r=' + Date.now();

        return this._http.get(this._retrieveLocalUrl + "/GetSeriesLayout?" + parameter);
    }

    public GetPatientStructuredDisplay(patientID: string, userData?): ng.IHttpPromise<any> {

        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&patientID=" + patientID + "&data=" + userData + '&r=' + Date.now();

        return this._http.get(this._retrieveLocalUrl + "/GetPatientStructuredDisplay?" + parameter);
    }

    public GetStudyLayout(studyInstanceUID: string, userData?): ng.IHttpPromise<any> {
        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&studyInstanceUID=" + studyInstanceUID + "&data=" + userData + '&r=' + Date.now();

        return this._http.get(this._retrieveLocalUrl + "/GetStudyLayout?" + parameter);
    }

    public GetPresentationInfo(seriesInstanceUID: string): ng.IHttpPromise<any> {
        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&series=" + seriesInstanceUID;

        return this._http.get(this._retrieveLocalUrl + "/GetPresentationInfo?" + parameter);
    }    

    public GetDicomJSON(studyInstanceUID: string, seriesInstanceUID: string, sopInstanceUID: string): ng.IHttpPromise<any> {
        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&study=" + studyInstanceUID + "&series=" + seriesInstanceUID + "&instance=" + sopInstanceUID;

       return this._http.get(this._retrieveLocalUrl + "/GetDicomJSON?" + parameter, { headers: { 'Content-Type': 'application/json'} });
    }    

    public UploadAnnotations(annotationData): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            data: annotationData
        };
        
        return this._http.post(this._retrieveLocalUrl + "/UploadAnnotations", JSON.stringify(data));
    }

    public DownloadImageUrl(frame, annFileName: string, maxWidth, maxHeight, xDpi, yDpi, userData): string {
        var q = "&bp=0&qf=0";
        var maxSize = "";

        if (maxWidth && maxHeight) {
            maxSize = '&cx=' + maxWidth + '&cy=' + maxHeight;
        }
        else {
            maxSize = '&cx=0&cy=0';
        }

        userData = userData == undefined ? "" : userData;
        return this._retrieveLocalUrl + '/DownloadImage?auth=' + encodeURIComponent(this._authenticationService.authenticationCode) + '&instance=' + frame.Instance.SOPInstanceUID + '&frame=' + frame.FrameNumber + q + maxSize + '&annotationFileName=' + encodeURIComponent(annFileName) + '&xDpi=' + xDpi + '&yDpi=' + yDpi + '&data=' + userData;
    }

    public GetPresentationAnnotations(sopInstanceUID: string, userData): ng.IHttpPromise<any> {
        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&instance=" + sopInstanceUID + "&data=" + userData;

        return this._http.get(this._retrieveLocalUrl + "/GetPresentationAnnotations?" + parameter, { headers: { 'Content-Type': 'application/xml' } });
    }

    public GetAudioGroupsCount(sopInstanceUID: string): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            sopInstanceUID: sopInstanceUID
        };

        return this._http.post(this._retrieveLocalUrl + "/GetAudioGroupsCount", JSON.stringify(data));
    }

    public GetSeriesStacks(seriesInstanceUID: string, userData?): ng.IHttpPromise<any> {
        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&seriesinstanceUID=" + seriesInstanceUID + "&data=" + userData;

        return this._http.get(this._retrieveLocalUrl + "/GetSeriesStacks?" + parameter);
    }

    public GetHangingProtocol(sopInstanceUID: string, userData?): ng.IHttpPromise<Models.HangingProtocol> {
        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&instance=" + sopInstanceUID + "&data=" + userData + '&r=' + Date.now();

        return this._http.get(this._retrieveLocalUrl + "/GetHangingProtocol?" + parameter);
    }

    public GetHangingProtocolInstances(sopInstanceUID: string, patientId: string, studyInstanceUID: string, studyDateMostRecent: string, userData?): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            hangingProtocolSOP: sopInstanceUID,
            patientID: patientId,
            studyInstanceUID: studyInstanceUID, 
            studyDateMostRecent: studyDateMostRecent,          
            userData: userData
        };

        return this._http.post(this._retrieveLocalUrl + "/GetHangingProtocolInstances", JSON.stringify(data));
    }

    public BuildAudioUrl(sopInstanceUID: string, groupIndex, mime:string): string {       
        return this._retrieveLocalUrl + '/GetAudio?auth=' + encodeURIComponent(this._authenticationService.authenticationCode) + '&instance=' + sopInstanceUID + '&group=' + groupIndex + '&mime=' + encodeURIComponent(mime);
    }

    public ClearCache(): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode
        };

        return this._http.post(this._retrieveLocalUrl + "/ClearCache", JSON.stringify(data));
    }
}

services.service('objectRetrieveService', ObjectRetrieveService);