// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************

class PatientAccessRightsService {
    static $inject = ['app.config', 'authenticationService', '$http'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;    
    private _patientAccessRightsUrl;   

    constructor(config, authenticationService, $http: ng.IHttpService) {
        this._http = $http;
        this._authenticationService = authenticationService;        
        this._patientAccessRightsUrl = config.urls.serviceUrl + config.urls.patientAccessRightsServiceName;        
    }       

    public GetUserAccess(user: string, extraOptions?:any): ng.IPromise<any> {        
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            user: user,
            extraOptions: extraOptions
        };

        return this._http.post(this._patientAccessRightsUrl + "/GetUserAccess", JSON.stringify(data));
    }

    public GrantUserPatients(user: string, patientIds: Array<string>, extraOptions?: any): ng.IPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            user: user,
            patientIds: patientIds,
            extraOptions: extraOptions
        };

        return this._http.post(this._patientAccessRightsUrl + "/GrantUserPatients", JSON.stringify(data));
    }

    public GetRoleAccess(role: string, extraOptions?: any): ng.IPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            role: role,
            extraOptions: extraOptions
        };

        return this._http.post(this._patientAccessRightsUrl + "/GetRoleAccess", JSON.stringify(data));
    }
    
    public GrantRolePatients(role:string, patientIds: Array<string>, extraOptions?: any): ng.IPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            role: role,
            patientIds: patientIds,
            extraOptions: extraOptions
        };

        return this._http.post(this._patientAccessRightsUrl + "/GrantRolePatients", JSON.stringify(data));
    } 
    
    public GetRolesAccess(roles: Array<string>, extraOptions?: any): ng.IPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            roles: roles,            
            extraOptions: extraOptions
        };

        return this._http.post(this._patientAccessRightsUrl + "/GetRolesAccess", JSON.stringify(data));
    }    
}

services.service('patientAccessRightsService', PatientAccessRightsService);