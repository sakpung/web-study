// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="AuthenticationService.ts" />

class ExportService {
    static $inject = ['app.config', 'authenticationService', '$http'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;
    private exportUrl;

    constructor(config, authenticationService, $http: ng.IHttpService, eventService: EventService) {
        this._http = $http;
        this._authenticationService = authenticationService;
        this.exportUrl = config.urls.serviceUrl + config.urls.exportServiceName;
    }

    public ExportAllSeries(patientID: string, options: Models.ExportOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            patientID: patientID,
            options: options            
        };

        return this._http.post(this.exportUrl + "/ExportAllSeries", JSON.stringify(data));
    } 

    public ExportSeries(seriesInstanceUIDs: Array<string>, options: Models.ExportOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            seriesInstanceUIDs: seriesInstanceUIDs,
            options: options,
        }

        return this._http.post(this.exportUrl + "/ExportSeries", JSON.stringify(data));
    }  
    
    public ExportInstances(instanceUIDS: Array<string>, options: Models.ExportOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            instanceUIDs: instanceUIDS,
            options: options,
        }

        return this._http.post(this.exportUrl + "/ExportInstances", JSON.stringify(data));
    }
    
    public ExportLayout(seriesInstanceUID, layout, annotationFileName: string, burnAnnotations:boolean, compression:number, width:number): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            seriesInstanceUID: seriesInstanceUID,
            layout: layout,
            compression: compression,
            width: width,
            annotationFileName: annotationFileName
        }

        return this._http.post(this.exportUrl + "/ExportLayout", JSON.stringify(data));
    }  

    public GetInstanceLocalPathName(instanceUID): ng.IHttpPromise<any> {
       var data = {
           authenticationCookie: this._authenticationService.authenticationCode,
           instanceUID: instanceUID
        }

        return this._http.post(this.exportUrl + "/GetInstanceLocalPathName", JSON.stringify(data));
    }  
}

services.service('exportService', ExportService);