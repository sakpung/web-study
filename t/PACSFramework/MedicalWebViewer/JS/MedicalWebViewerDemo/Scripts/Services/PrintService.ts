// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="AuthenticationService.ts" />

class PrintService {
    static $inject = ['app.config', 'authenticationService', '$http'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;
    private printUrl;

    constructor(config, authenticationService, $http: ng.IHttpService, eventService: EventService) {
        this._http = $http;
        this._authenticationService = authenticationService;
        this.printUrl = config.urls.serviceUrl + config.urls.exportServiceName;
    }

    public PrintAllSeries(patientID: string, options: Models.PrintOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            patientID: patientID,
            options: options            
        };

        return this._http.post(this.printUrl + "/PrintAllSeries", JSON.stringify(data));
    } 

    public PrintSeries(seriesInstanceUIDs: Array<string>, options: Models.PrintOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            seriesInstanceUIDs: seriesInstanceUIDs,
            options: options,
        }

        return this._http.post(this.printUrl + "/PrintSeries", JSON.stringify(data));
    }  
       
    public PrintInstances(instanceUIDS: Array<string>, options: Models.PrintOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            instanceUIDs: instanceUIDS,
            options: options,
        }

        return this._http.post(this.printUrl + "/PrintInstances", JSON.stringify(data));
    }
    
   public PrintLayout(seriesInstanceUID, layout: Models.Layout, options: Models.PrintOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            seriesInstanceUID: seriesInstanceUID,
            layout: layout,
            options: options
        }

        return this._http.post(this.printUrl + "/PrintLayout", JSON.stringify(data));
    }  
}

services.service('printService', PrintService);