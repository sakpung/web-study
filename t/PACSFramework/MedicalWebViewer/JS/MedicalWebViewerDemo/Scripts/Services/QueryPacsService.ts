// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="AuthenticationService.ts" />

class QueryPacsService {
    static $inject = ['app.config','authenticationService', '$http', 'eventService', 'optionsService'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;    
    private _queryPacsUrl;
    private _remoteConfig: Models.RemoteConfig;
    private _server: Models.PACSConnection;    
    
    public get remoteConnections(): Array<Models.RemoteConnection> {
        return this._remoteConfig.servers;
    }

    public get pacsConnections(): Array<Models.PACSConnection> {
        var result: Array<Models.PACSConnection> = new Array<Models.PACSConnection>();

        for (var index = 0; index < this._remoteConfig.servers.length; index++) {
            if (this._remoteConfig.servers[index].type == 'pacs') {
                result.push(this._remoteConfig.servers[index] as Models.PACSConnection);
            }
        }

        return result;
    }

    public get clientAETitle(): string {
        return this._remoteConfig.client;
    }

    public get wadoConnections(): Array<Models.WadoConnection> {
        var result: Array<Models.WadoConnection> = new Array<Models.WadoConnection>();

        for (var index = 0; index < this._remoteConfig.servers.length; index++) {
            if (this._remoteConfig.servers[index].type == 'wado') {
                result.push(this._remoteConfig.servers[index] as Models.WadoConnection);
            }
        }

        return result;
    }

    public get server(): Models.PACSConnection {
        return this._server;
    }

    constructor(config, authenticationService, $http: ng.IHttpService, eventService: EventService, optionsService: OptionsService) {
        
        this._http = $http;
        this._authenticationService = authenticationService;        
        this._queryPacsUrl = config.urls.serviceUrl + config.urls.queryPacsServiceName;              

        this.ReadRemoteConfigs(optionsService);
    }

    private ReadRemoteConfigs(optionsService: OptionsService) : void {
        this._remoteConfig = Models.RemoteConfig.Factory(optionsService.get(OptionNames.RemoteConfig));
    }

    public FindPatients(server: Models.PACSConnection, clientAETitle: string, queryParams: Models.QueryOptions): ng.IHttpPromise<any> {        
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            server: server,
            client: { AETitle: clientAETitle },
            options: queryParams
        };

        return this._http.post(this._queryPacsUrl + "/FindPatients", JSON.stringify(data));
    }
    
    public FindStudies(server:Models.PACSConnection, clientAETitle: string, queryParams: Models.QueryOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            server: server,
            client: { AETitle: clientAETitle },
            options: queryParams
        };

        this._server = server;
        return this._http.post(this._queryPacsUrl + "/FindStudies", JSON.stringify(data));
    }

    public FindSeries(server: Models.PACSConnection, clientAETitle: string, queryParams: Models.QueryOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            server: server,
            client: { AETitle: clientAETitle },
            options: queryParams
        };

        this._server = server;
        return this._http.post(this._queryPacsUrl + "/FindSeries", JSON.stringify(data));
    }

    public FindPresentationState(referencedSeries:string): ng.IHttpPromise<any> {
        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&series=" + referencedSeries;        

        return this._http.get(this._queryPacsUrl + "/FindPresentationState?" + parameter);
    }

    public FindInstances(queryParams: Models.QueryOptions): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            options: queryParams
        };

        return this._http.post(this._queryPacsUrl + "/FindInstances", JSON.stringify(data));
    }

    public ElectStudyTimeLineInstances(queryParams: Models.QueryOptions, userData?: any): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            options: queryParams,
            userData: userData || null
        };        

        return this._http.post(this._queryPacsUrl + "/ElectStudyTimeLineInstances", JSON.stringify(data));
    } 
    
    public VerifyConnection(server: Models.PACSConnection, clientAETitle: string): ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            server: server,
            client: { AETitle: clientAETitle },
            options: null
        };
        
        return this._http.post(this._queryPacsUrl + "/VerifyConnection", JSON.stringify(data));
    }
    
    public GetConnectionInfo(): ng.IHttpPromise<any> {
        return this._http.get(this._queryPacsUrl + "/GetConnectionInfo");

    }
}

services.service('queryPacsService', QueryPacsService);