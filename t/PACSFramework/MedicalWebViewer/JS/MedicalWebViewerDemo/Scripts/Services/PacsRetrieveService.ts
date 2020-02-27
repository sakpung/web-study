// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="AuthenticationService.ts" />

module DownloadStatus {
    export var Idle: number = 0;
    export var Started: number = 1;
    export var Completed: number = 2;
    export var Error: number = 3;
    export var Aborted: number = 4;
    export var All: number = 5;
}

class PacsRetrieveService {
    static $inject = ['app.config', 'authenticationService', '$http'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;
    private _retrievePacsUrl;

    constructor(config, authenticationService, $http: ng.IHttpService, eventService: EventService) {
        this._http = $http;
        this._authenticationService = authenticationService;
        this._retrievePacsUrl = config.urls.serviceUrl + config.urls.pacsRetrieveServiceName;
    }

    public loadQueue(): ng.IHttpPromise<any> {
        return this.GetDownloadInfos(null, null, null, null, null, null, DownloadStatus.All, null);
    }  

    public GetDownloadInfos(server:Models.PACSConnection, client, patientID:string, studyInstanceUID:string, seriesInstanceUID:string, sopInstanceUID:string, status:number, extraOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            server: server,
            client: client,
            patientID: patientID,
            studyInstanceUID: studyInstanceUID,
            seriesInstanceUID: seriesInstanceUID,
            sopInstanceUID: sopInstanceUID,
            status: status,
            extraOptions: extraOptions           
        }

        return this._http.post(this._retrievePacsUrl + "/GetDownloadInfos", JSON.stringify(data));
    }

    public DownloadImages(server: Models.PACSConnection, client: string, patientID: string, studyInstanceUID: string, seriesInstanceUID: string, sopInstanceUID: string, extraOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            server: server,
            client: client,
            studyInstanceUID: studyInstanceUID,
            seriesInstanceUID: seriesInstanceUID,
            sopInstanceUID: sopInstanceUID,
            extraOptions: extraOptions
        };

        return this._http.post(this._retrievePacsUrl + "/DownloadImages", JSON.stringify(data));
    }

    public DeleteDownloadInfos(jobIds: Array<number>): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            jobIds: jobIds,
            extraOptions: null
        };

        return this._http.post(this._retrievePacsUrl + "/DeleteDownloadInfos", JSON.stringify(data));
    }

    public UpdateDownloadInfoStatus(job: Models.DownloadInfo): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            info: job,
            extraOptions: null
        };

        return this._http.post(this._retrievePacsUrl + "/UpdateDownloadInfoStatus", JSON.stringify(data));
    }
}

services.service('pacsRetrieveService', PacsRetrieveService);