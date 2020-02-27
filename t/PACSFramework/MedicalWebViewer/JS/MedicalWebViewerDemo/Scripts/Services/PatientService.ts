// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../app.ts" />
/// <reference path="../../lib/LEADTOOLS/jquery/jquery.d.ts" />

class PatientService /*extends ServiceProxy*/ {
    static $inject = ['app.config', 'authenticationService', '$http'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;
    private _patientServiceUrl;


    constructor(config, authenticationService, $http: ng.IHttpService, eventService: EventService) {
        this._http = $http;
        this._authenticationService = authenticationService;
        this._patientServiceUrl = config.urls.serviceUrl + config.urls.patientServiceName;

    }


    // AddPatient
    // : JQueryXHR 
    //{
    //var dataArgs = {
    //    authenticationCookie: this.AuthenticationProxy.GetAuthenticationCookie(),
    //    info: patientInfo,
    //    userData: null
    //};

    //return super.DoPostGeneralCall("AddPatient", dataArgs, errorHandler, successHandler);
    //}

    public AddPatient(patientInfo: PatientInfo)
        : ng.IHttpPromise<any> {
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            info: patientInfo,
            userData: null
        };

        return this._http.post(this._patientServiceUrl + "/AddPatient", JSON.stringify(data));
    }


    public UpdatePatient(patientInfo: PatientInfo)
        : ng.IHttpPromise<any> {

        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            info: patientInfo,
            extraOptions: null
        };

        return this._http.post(this._patientServiceUrl + "/UpdatePatient", JSON.stringify(data));

        // return super.DoPostGeneralCall("UpdatePatient", dataArgs, errorHandler, successHandler);
    }

    public DeletePatient(patientId: string)
        : ng.IHttpPromise<any> {

        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            patientId: patientId,
            extraOptions: null
        };

        return this._http.post(this._patientServiceUrl + "/DeletePatient", JSON.stringify(data));
        // return super.DoPostGeneralCall("DeletePatient", dataArgs, errorHandler, successHandler);
    }
};

class PatientInfo {
    PatientId: string;
    Name: string;
    BirthDate: string;
    Sex: string;
    Comments: string;
    EthnicGroup: string;

    constructor(patientId, name, birthDate, sex, comments, ethnicGroup) {
        this.PatientId = patientId;
        this.Name = name;
        this.BirthDate = birthDate;
        this.Sex = sex;
        this.Comments = comments;
        this.EthnicGroup = ethnicGroup;
    }
}

class PersonName {

    First: string;
    Last: string;
    Middle: string;
    Prefix: string;
    Suffix: string;
    sep: string;

    constructor(...args: any[]) {

        this.First = "";
        this.Last = "";
        this.Middle = "";
        this.Prefix = "";
        this.Suffix = "";

        if (args.length >= 1)
            this.Last = args[0];

        if (args.length >= 2)
            this.First = args[1];

        if (args.length >= 3)
            this.Middle = args[2];

        if (args.length >= 4)
            this.Prefix = args[3];

        if (args.length >= 5)
            this.Suffix = args[4];

        this.sep = "^";
    }

    getDicomName() {
        var dicomName = this.Last.trim() + this.sep + this.First.trim() + this.sep + this.Middle.trim() + this.sep + this.Prefix.trim() + this.sep + this.Suffix.trim();
        return dicomName;
    }

    static getPersonName(dicomName: string) {
        var personName = new PersonName();
        var nameParts = dicomName.split('^');

        if (nameParts.length >= 1)
            personName.Last = nameParts[0];

        if (nameParts.length >= 2)
            personName.First = nameParts[1];

        if (nameParts.length >= 3)
            personName.Middle = nameParts[2];

        if (nameParts.length >= 4)
            personName.Prefix = nameParts[3];

        if (nameParts.length >= 5)
            personName.Suffix = nameParts[4];

        return personName;
    }
}

services.service('patientService', PatientService);