// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="AuthenticationService.ts" />

class TemplateService {
    static $inject = ['app.config','authenticationService', '$http'];

    private _http: ng.IHttpService;
    private _authenticationService: AuthenticationService;    
    private _templateServiceUrl:string;
    
    private _currentStudyLayout: Models.StudyLayout;    

    public get currentStudyLayout(): Models.StudyLayout {
        return this._currentStudyLayout;
    }

    public set currentStudyLayout(value: Models.StudyLayout) {
        this._currentStudyLayout = value;
    }

    private _currentHangingProtocol: Models.HangingProtocol;

    public get currentHangingProtocol(): Models.HangingProtocol {
        return this._currentHangingProtocol;
    }

    public set currentHangingProtocol(value: Models.HangingProtocol) {
        this._currentHangingProtocol = value;
    }
   
    constructor(config, authenticationService: AuthenticationService, $http: ng.IHttpService) {        
        this._http = $http;
        this._authenticationService = authenticationService;        
        this._templateServiceUrl = config.urls.serviceUrl + config.urls.templateServiceName;                      
        this._currentStudyLayout = null;                  
    }    

    public GetAnatomicDescriptions(userData?:any): ng.IHttpPromise<any> {
        return this._http.get(this._templateServiceUrl + "/GetAnatomicDescriptions?" + "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&data=" + JSON.stringify(userData));

    }

    public GetAllTemplates(userData?: any): ng.IHttpPromise<any> {
        return this._http.get(this._templateServiceUrl + "/GetAllTemplates?" + "auth=" + encodeURIComponent(this._authenticationService.authenticationCode) + "&data=" + JSON.stringify(userData) + "&r=" + Date.now());

    }

    public AddTemplate(template: Models.Template): ng.IHttpPromise<any> { 
        var templateCopy = angular.copy(template);               
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            template: templateCopy,
            userData: null
        };                  
                  
        return this._http.post(this._templateServiceUrl + "/AddTemplate", JSON.stringify(data, this.templateReplacer));
    } 
    
    public UpdateTemplate(template: Models.Template): ng.IHttpPromise<any> {
        var templateCopy = angular.copy(template);
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            template: templateCopy,
            userData: null
        };

        return this._http.post(this._templateServiceUrl + "/UpdateTemplate", JSON.stringify(data, this.templateReplacer));
    } 

    public DeleteTemplate(templateId:string): ng.IHttpPromise<any> {       
        var data = {
            authenticationCookie: this._authenticationService.authenticationCode,
            templateId: templateId,
            userData: null
        };

        return this._http.post(this._templateServiceUrl + "/DeleteTemplate", JSON.stringify(data, this.templateReplacer));
    } 

    public ExportAllTemplates() {
        var url: string = this._templateServiceUrl + "/ExportAllTemplates?" + "auth=" + encodeURIComponent(this._authenticationService.authenticationCode);

        OpenUrl(url, true);
    }

    public ImportTemplates(Upload, file) {
        return Upload.upload(
            {
                url: this._templateServiceUrl + "/ImportTemplates",
                file: file,
                fields: {
                    'auth': this._authenticationService.authenticationCode
                },
            });            
    }

    private templateReplacer(key: string, value: any) {
        if (key.toLowerCase().indexOf('create') >= 0 || key.toLowerCase().indexOf('date') >= 0){
            if (typeof value == 'string') {
                var date: any = new Date(value);

                if (date != 'Invalid Date') {
                    return (<Date>date).toUTCString();
                }
            }
        }

        if (value instanceof lt.LeadPointD) {
            var x: number = Utils.roundNumber(value.x, 7);
            var y: number = Utils.roundNumber(value.y, 7);

            //
            // lt.LeadPointD is serializing as {_x, _y}.  Need to change to {x, y}.
            //
            return { x: x, y: y };
        }
        return value;
    }    
}

services.service('templateService', TemplateService);