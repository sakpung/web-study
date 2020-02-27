// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
class MonitorCalibrationService {
    static $inject = ['app.config', 'authenticationService', '$http'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;
    private _monitorCalibrationUrl;

    constructor(config, authenticationService, $http: ng.IHttpService, eventService: EventService) {
        this._http = $http;
        this._authenticationService = authenticationService;
        this._monitorCalibrationUrl = config.urls.serviceUrl + config.urls.monitorCalibrationServiceName;
    }

    public GetCalibrations(): ng.IHttpPromise<any> {
        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + '&cache=' + new Date().toString();

        return this._http.get(this._monitorCalibrationUrl + "/GetCalibrations?" + parameter, { cache: false });
    }

    public AddCalibration(calibration): ng.IHttpPromise<any> {
        var parameters = {
            authenticationCookie: this._authenticationService.authenticationCode,
            calibration: calibration
        };

        return this._http.post(this._monitorCalibrationUrl + "/AddCalibration", JSON.stringify(parameters));
    }
}

services.service('monitorCalibrationService', MonitorCalibrationService);