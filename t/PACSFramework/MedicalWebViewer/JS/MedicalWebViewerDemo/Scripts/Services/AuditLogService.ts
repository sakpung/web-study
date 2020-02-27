// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="AuthenticationService.ts" />

class AuditLogService {
    static $inject = ['app.config', 'authenticationService', '$http','optionsService'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;
    private _optionsService: OptionsService;    
    private _auditLogUrl;   

    constructor(config, authenticationService, $http: ng.IHttpService, optionsService:OptionsService) {
        this._http = $http;
        this._authenticationService = authenticationService;
        this._optionsService = optionsService;        
        this._auditLogUrl = config.urls.serviceUrl + config.urls.auditLogServiceName;        
    }   

    Log(userName: string, workstation: string, date: Date, details: string, userData: string, authenticationCode?:string): ng.IPromise<any> {
        var data = {
            authenticationCookie: authenticationCode || this._authenticationService.authenticationCode,
            user: userName,
            workstation: workstation,
            date: date,
            details: details,
            userData: userData
        }
        
        return this._http.post(this._auditLogUrl + "/Log", JSON.stringify(data, function (key, value) {
            if (key == "date") {
                var date = new Date(value);
                var jsonString = '/Date(' + date.getTime() + '-0800)/';

                return jsonString;
            }
            else
                return value;
        }));
    }

    public log_launch(): ng.IPromise<any> {
        if (this._optionsService.get(OptionNames.EnableAuditLog) && this._optionsService.get(OptionNames.LogUserActivity)) {
            return this.Log("?", "?", new Date(), "Medical Web Viewer Launched", "");
        }
        return null;
    }

    public log_exit() {
        if (this._optionsService.get(OptionNames.EnableAuditLog) && this._optionsService.get(OptionNames.LogUserActivity)) {
            return this.Log("?", "?", new Date(), "Medical Web Viewer Exited", "");
        }
    }

    public log_logOut(authenticationCode:string) {
        if (this._optionsService.get(OptionNames.EnableAuditLog) && this._optionsService.get(OptionNames.LogUserActivity)) {
            return this.Log("?", "?", new Date(), "Medical Web Viewer Exited", "", authenticationCode);
        }
    }

    public log_openPatient(patient) {
        if (this._optionsService.get(OptionNames.EnableAuditLog) && this._optionsService.get(OptionNames.LogUserActivity)) {
            return this.Log("?", "?", new Date(), "Opened Patient: " + patient.ID + ", " + patient.Name, "");
        }
    }

    public log_showSeries(series) {
        if (this._optionsService.get(OptionNames.EnableAuditLog) && this._optionsService.get(OptionNames.LogUserActivity)) {
            var $root = $('<XMLDocument />');

            $root.append
                (
                $('<extra />').append
                    (
                    (
                    $('<uid />').text(series.InstanceUID)
                    )
                    )
                );
            return this.Log("?", "?", new Date(), "View Series: " + series.Description, $root.html());
        }
    }
}

services.service('auditLogService', AuditLogService);