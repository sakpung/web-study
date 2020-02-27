// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="AuthenticationService.ts" />

class ObjectStoreService {
    static $inject = ['app.config', 'authenticationService', '$http'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;
    private _storeLocalUrl;

    constructor(config, authenticationService, $http: ng.IHttpService, eventService: EventService) {
        this._http = $http;
        this._authenticationService = authenticationService;
        this._storeLocalUrl = config.urls.serviceUrl + config.urls.objectStoreLocalServiceName;
    }


    public UploadDicomImage(buffer, uploadStatus, uploadedFileName): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            dicomData: buffer,
            status: uploadStatus,
            fileName: uploadedFileName
        };

        return this._http.post(this._storeLocalUrl + "/UploadDicomImage", JSON.stringify(data));
    }
    public StoreSecondaryCapture(encodedCapture, originalSOPId: string, seriesNumber, seriesDescription: string, protocolName: string): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            EncodedCapture: encodedCapture,
            OriginalSOPInstance: originalSOPId,
            SeriesNumber: seriesNumber,
            SeriesDescription: seriesDescription,
            ProtocolName: protocolName
        };

        return this._http.post(this._storeLocalUrl + "/StoreSecondaryCapture", JSON.stringify(data));
    } 
    
    public DeleteAnnotations(sopInstanceUID: string, userdata?): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            sopInstanceUID: sopInstanceUID,
            userData: userdata || null
        };

        return this._http.post(this._storeLocalUrl + "/DeletePresentationState", JSON.stringify(data));
    }

    public StoreAnnotations(seriesInstanceUID: string, annotationData: string, description: string, userdata?: any): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            seriesInstanceUID: seriesInstanceUID,
            annotationData: annotationData,
            description: description,
            userData: userdata || null
        };

        return this._http.post(this._storeLocalUrl + "/StoreAnnotations", JSON.stringify(data));
    }


    public StoreStudyLayout(studyInstanceUID: string, studyLayout: Models.StudyLayout, userdata?: any): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            studyInstanceUID: studyInstanceUID,
            studyLayout: studyLayout,           
            userData: userdata || null
        };

        return this._http.post(this._storeLocalUrl + "/StoreStudyLayout", JSON.stringify(data, function (key: string, value: any) {
            if (value instanceof lt.LeadPointD) {
                var x: number = Utils.roundNumber(value.x, 7);
                var y: number = Utils.roundNumber(value.y, 7);

                //
                // lt.LeadPointD is serializing as {_x, _y}.  Need to change to {x, y}.
                //
                return { x: x, y: y };
            }            
            return value;
        }));
    }    

    public DeleteStudyLayout(studyInstanceUID: string, userdata?: any): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            studyInstanceUID: studyInstanceUID,           
            userData: userdata || null
        };

        return this._http.post(this._storeLocalUrl + "/DeleteStudyLayout", JSON.stringify(data));
    }

    public StoreHangingProtocol(hangingProtocol: Models.HangingProtocol, userdata?: any): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,            
            hangingProtocol: hangingProtocol,
            userData: userdata || null
        };

        return this._http.post(this._storeLocalUrl + "/StoreHangingProtocol", JSON.stringify(data, function (key: string, value: any) {
            if (value instanceof lt.LeadPointD) {
                var x: number = Utils.roundNumber(value.x, 7);
                var y: number = Utils.roundNumber(value.y, 7);

                //
                // lt.LeadPointD is serializing as {_x, _y}.  Need to change to {x, y}.
                //
                return { x: x, y: y };
            }
            else if (key == 'WCFHangingProtocolCreationDateTime') {
                var date: any = new Date(value);

                if (date != 'Invalid Date') {
                    return (<Date>date).toUTCString();
                }
            }
            return value;
        }));
    }

    
}

services.service('objectStoreService', ObjectStoreService);