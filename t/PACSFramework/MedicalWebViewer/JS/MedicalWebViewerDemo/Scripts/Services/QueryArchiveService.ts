// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="AuthenticationService.ts" />

class QueryArchiveService {
    static $inject = ['app.config','authenticationService', '$http'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;
    private _queryLocalUrl;   
    private _threedLocalUrl;   

    constructor(config, authenticationService, $http: ng.IHttpService, eventService:EventService) {
        this._http = $http;
        this._authenticationService = authenticationService;
        this._queryLocalUrl = config.urls.serviceUrl + config.urls.queryLocalServiceName;              
        if (config.urls.threeDserviceUrl) {
            this._threedLocalUrl = config.urls.threeDserviceUrl + config.urls.threeDServiceName;
        }
        else {
            this._threedLocalUrl = config.urls.serviceUrl + config.urls.threeDServiceName;
        }
    }

    public FindPatients(queryParams: Models.QueryOptions, maxQueryResults?: string): ng.IHttpPromise<any> {
        var max: string = maxQueryResults || '0';
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            options: queryParams,
            extraOptions: { UserData: parseInt(max) }
        };

        return this._http.post(this._queryLocalUrl + "/FindPatients", JSON.stringify(data));
    }

    public UploadDicomImage(buffer, start): ng.IHttpPromise<any> {


        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            dicomData: buffer,
            createFile: start
        };
        return this._http.post(this._queryLocalUrl + "/UploadDicomImage", JSON.stringify(data));
    }

    public FindStudies(queryParams: Models.QueryOptions, maxQueryResults?: string): ng.IHttpPromise<any> {
        var max: string = maxQueryResults || '0';
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            options: queryParams,
            extraOptions: { UserData: parseInt(max) }          
        };

        return this._http.post(this._queryLocalUrl + "/FindStudies", JSON.stringify(data));
    }

    private isDate(key: string): boolean {
        if (key.toLowerCase().indexOf("date") != -1)
            return true;

        if (key.toLowerCase().indexOf("time") != -1)
            return true;

        return false;
    }

    public FindSeries(queryParams: Models.QueryOptions, maxQueryResults?: string): ng.IHttpPromise<any> {
        var max:string = maxQueryResults || '0';
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            options: queryParams,
            extraOptions: { UserData: parseInt(max) }
        };

        var _this = this;

        return this._http.post(this._queryLocalUrl + "/FindSeries", JSON.stringify(data, function (key, value) {            
            if (typeof value == 'string' && _this.isDate(key)) {
                var date:any = new Date(value);

                if (date != 'Invalid Date') {                    
                    return (<Date>date).toUTCString();
                }       
            }
            return value;
        }));
    }

    public FindPresentationState(referencedSeries:string): ng.IHttpPromise<any> {
        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&series=" + referencedSeries;        

        return this._http.get(this._queryLocalUrl + "/FindPresentationState?" + parameter);
    }

    public KeepAlive(id): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            id : id
        };

        return this._http.post(this._threedLocalUrl + "/KeepAlive", JSON.stringify(data));
    }

    public Start3DObject(queryParams: Models.QueryOptions, id, renderingMethod, stackInstanceUID?): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            options: queryParams,
            id: id,
            renderingType: renderingMethod,
            extraOptions: { UserData2: stackInstanceUID }
        };

        return this._http.post(this._threedLocalUrl + "/Create3DObject", JSON.stringify(data));
    }


    public CheckProgress(id): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            id : id
        };

        return this._http.post(this._threedLocalUrl + "/CheckProgress", JSON.stringify(data));
    }

    public Get3DSettings(settings, id): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            id: id,
            options: settings,
        };

        return this._http.post(this._threedLocalUrl + "/Get3DSettings", JSON.stringify(data));
    }

    public Update3DSettings(settings, id): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            id: id,
            options: settings,
        };

        return this._http.post(this._threedLocalUrl + "/Update3DSettings", JSON.stringify(data));
    }


    public Get3DImage() {
        return this._threedLocalUrl + "/Get3DImage?auth=" + encodeURIComponent(this._authenticationService.authenticationCode);
    }

    public GetPanoramic3DImage() {
        return this._threedLocalUrl + "/GetPanoramicImage?auth=" + encodeURIComponent(this._authenticationService.authenticationCode);
    }

    public Close3DImage(id) {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            id : id,
        };
        return this._http.post(this._threedLocalUrl + "/End3DObject", JSON.stringify(data));
    }

    public FindInstances(queryParams: Models.QueryOptions, stackInstanceUID?): ng.IHttpPromise<any> {
       var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            options: queryParams,
            extraOptions: { UserData2: stackInstanceUID }
        };

        return this._http.post(this._queryLocalUrl + "/FindInstances", JSON.stringify(data));
    }

    public ElectStudyTimeLineInstances(queryParams: Models.QueryOptions, userData?: any): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            options: queryParams,
            userData: userData || null
        };        

        return this._http.post(this._queryLocalUrl + "/ElectStudyTimeLineInstances", JSON.stringify(data));
    }

    public FindHangingProtocols(studyInstanceUID:string, userData?): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            studyInstanceUID: studyInstanceUID,
            userData: userData || null
        };

        return this._http.post(this._queryLocalUrl + "/FindHangingProtocols", JSON.stringify(data));
    }

    public AutoComplete(key: string, term: string): ng.IHttpPromise<any> {
        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&key=" + key + "&term=" + term;;
        var __this = this;

        return this._http.get(this._queryLocalUrl + "/AutoComplete?" + parameter, { cache: false });
    }
}

services.service('queryArchiveService', QueryArchiveService);