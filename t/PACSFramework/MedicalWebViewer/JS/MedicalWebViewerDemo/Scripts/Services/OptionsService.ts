// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/LEADTOOLS/jquery/jquery.d.ts" />
/// <reference path="../../Scripts/Utils.ts" />
/// <reference path="AuthenticationService.ts" />

module OptionNames {
    export var CaptureInfoTextRectFillColor: string = "CaptureInfoTextRectFillColor";
    export var CaptureInfoTextColor: string = "CaptureInfoTextColor";
    export var EmptyCellBackgroundColor: string = "EmptyCellBackgroundColor";
    export var ShowPacsQuery: string = "ShowPacsQuery";
    export var BlockWhileLoading: string = "BlockWhileLoading";
    export var EnablePatientIdAutoComplete: string = "EnablePatientIdAutoComplete";
    export var EnablePatientNameAutoComplete: string = "EnablePatientNameAutoComplete";
    export var Toolbar: string = "Toolbar";
    export var DisabledToolbarItems: string = "DisabledToolbarItems";
    export var DateFormat: string = "DateFormat";
    export var TimeFormat: string = "TimeFormat";
    export var SeriesThumbnailWidth: string = "SeriesThumbnailWidth";
    export var SeriesThumbnailHeight: string = "SeriesThumbnailHeight";
    export var ShowSearchThumbnails: string = "ShowSearchThumbnails";
    export var DerivedSeriesDescriptionText: string = "DerivedSeriesDescriptionText";
    export var Derived3DSeriesDescriptionText: string = "Derived3DSeriesDescriptionText";
    export var DerivedPanoramicSeriesDescriptionText: string = "DerivedPanoramicSeriesDescriptionText";
    export var EnableSeriesNumberEdit: string = "EnableSeriesNumberEdit";
    export var EnableProtocolNameEdit: string = "EnableProtocolNameEdit";
    export var EnableAuditLog: string = "EnableAuditLog";
    export var LogUserActivity: string = "LogUserActivity";
    export var LogUserSecurity: string = "LogUserSecurity";
    export var LogSettingChanges: string = "LogSettingChanges";
    export var LogSecuritySettingChanges: string = "LogSecuritySettingChanges";
    export var PatientIdMask: string = "PatientIdMask";
    export var IssuerOfPatientID: string = "IssuerOfPatientID";
    export var AutoStartCapture: string = "AutoStartCapture";
    export var ConfirmWorklistSelection: string = "ConfirmWorklistSelection";
    export var AllowOnlyWorklistQuery: string = "AllowOnlyWorklistQuery";
    export var EnableModalityWorklistQuery: string = "EnableModalityWorklistQuery";
    export var TimelinePosition: string = "TimelinePosition";
    export var SelectedBorderColor: string = "SelectedBorderColor";
    export var UnSelectedBorderColor: string = "UnSelectedBorderColor";
    export var SelectedSubCellBorderColor: string = "SelectedSubCellBorderColor";
    export var DentalMode: string = "DentalMode";
    export var SinglePatientMode: string = "SinglePatientMode";
    export var EnableIdleTimeout: string = "EnableIdleTimeout";
    export var IdleTimeout: string = "IdleTimeout";
    export var IdleWarningDuration: string = "IdleWarningDuration";
    export var SingleSeriesMode: string = "SingleSeriesMode";
    export var ShowFrameBorder: string = "ShowFrameBorder";
    export var OverlaySettings: string = "OverlaySettings";
    export var Toolbars: string = "Toolbars";
    export var AnnotationStrokeColor: string = "AnnotationStrokeColor";
    export var AnnotationTextColor: string = "AnnotationTextColor";
    export var AnnotationHiliteColor: string = "AnnotationHiliteColor";
    export var DefaultSeriesRowCount: string = "DefaultSeriesRowCount";
    export var DefaultSeriesColumnCount: string = "DefaultSeriesColumnCount";
    export var HideOverlays: string = "HideOverlays";
    export var RemoteConfig: string = "RemoteConfig";        
    export var MaxStudyResults: string = "MaxStudyResults";
    export var MaxSeriesResults: string = "MaxSeriesResults";
    export var MaxPatientResults: string = "MaxPatientResults";
    export var SearchOtherPatientIds: string = "SearchOtherPatientIds";
    export var EnablePatientRestriction: string = "EnablePatientRestriction";
    export var TemplateBorderColor: string = "TemplateBorderColor";
    export var TemplateBackgroundColor: string = "TemplateBackgroundColor";
    export var TemplateBorderSize: string = "TemplateBorderSize";
    export var TemplateBoundsNotification: string = "TemplateBoundsNotification";
    export var TemplateForeColor: string = "TemplateForeColor";
    export var DefaultScript: string = "DefaultScript";
    export var GridSpacing: string = "GridSpacing";
    export var GridLength: string = "GridLength";
    export var SnapToGrid: string = "SnapToGrid";
    export var ShowGrid: string = "ShowGrid";
    export var CustomStudyLayout: string = "CustomStudyLayout";
    export var AutoLoadHangingProtocol: string = "AutoLoadHangingProtocol";
    export var LazyLoadingThreshold: string = "LazyLoadingThreshold";
    export var LazyLoadingMobileThreshold: string = "LazyLoadingMobileThreshold";
    export var LazyLoadingBuffer: string = "LazyLoadingBuffer";
    export var HideCustomLayouts: string = "HideCustomLayouts";

    export var ShowStudyTimeLine: string = "ShowStudyTimeLine";
    export var LinkImages: string = "LinkImages";
    export var SplitSeries: string = "SplitSeries";
    export var StackSingleFrames: string = "StackSingleFrames";
    export var UseMedicoreLogo: string = "UseMedicoreLogo";

    export var MPRRenderSide: string = "MprRenderSide";
    export var RenderingMethod: string = "RenderingMethod";

    export var CaptureSize: string = "CaptureSize";
    export var CaptureLayout: string = "CaptureLayout";


    export var EnableOkta: string = "EnableOktaSignIn";
    export var EnableShibboleth: string = "EnableShibbolethSignIn";
    
    export var EnableCaching: string = "EnableCaching";
}

class OptionsService {
    static $inject = ['app.config', 'authenticationService', '$http', '$location', 'eventService'];

    private _httpService: ng.IHttpService;
    private _eventService: EventService;
    private _authenticationService: AuthenticationService;
    private _optionsServiceUrl: string;
    private _objectDictionary;

    constructor(config, authService:AuthenticationService, $http: ng.IHttpService, $location: ng.ILocationService, eventService: EventService) {
        this._httpService = $http;
        this._eventService = eventService; 
        this._authenticationService = authService;
        this._optionsServiceUrl = config.urls.serviceUrl + config.urls.optionsServiceName;

        this.InitializeOptions();            
    }

    private InitializeOptions() {
        this._objectDictionary = {};
        this.set(OptionNames.CaptureInfoTextColor, "#000000");
        this.set(OptionNames.CaptureInfoTextRectFillColor, "#DCDCDC");
        this.set(OptionNames.EmptyCellBackgroundColor, "#0F0F0F");
        this.set(OptionNames.DerivedSeriesDescriptionText, "(D)");
        this.set(OptionNames.DerivedPanoramicSeriesDescriptionText, "(Derived Panoramic)");
        this.set(OptionNames.Derived3DSeriesDescriptionText, "(Derived 3D)");
        this.set(OptionNames.ShowSearchThumbnails, false);
        this.set(OptionNames.SeriesThumbnailWidth, "50");
        this.set(OptionNames.SeriesThumbnailHeight, "50");
        this.set(OptionNames.EnableAuditLog, false);
        this.set(OptionNames.LogUserActivity, false);
        this.set(OptionNames.LogUserSecurity, false);
        this.set(OptionNames.LogSettingChanges, false);
        this.set(OptionNames.LogSecuritySettingChanges, false);
        this.set(OptionNames.PatientIdMask, "");
        this.set(OptionNames.IssuerOfPatientID, "");
        this.set(OptionNames.AutoStartCapture, true);
        this.set(OptionNames.ConfirmWorklistSelection, false);
        this.set(OptionNames.AllowOnlyWorklistQuery, false);
        this.set(OptionNames.EnableModalityWorklistQuery, false);
        this.set(OptionNames.TimelinePosition, "left");
        this.set(OptionNames.SelectedBorderColor, "#FF0000");   
        this.set(OptionNames.UnSelectedBorderColor, "#000000");
        this.set(OptionNames.SelectedSubCellBorderColor, "#000000");
        this.set(OptionNames.DentalMode, false);   
        this.set(OptionNames.SinglePatientMode, false);
        this.set(OptionNames.EnableIdleTimeout, true);
        this.set(OptionNames.IdleTimeout, 30);
        this.set(OptionNames.IdleWarningDuration, 30);
        this.set(OptionNames.SingleSeriesMode, false);
        this.set(OptionNames.ShowFrameBorder, true);
        this.set(OptionNames.AnnotationStrokeColor, "#FF0000");
        this.set(OptionNames.AnnotationTextColor, "#FF0000");
        this.set(OptionNames.AnnotationHiliteColor, "#FF0000");
        this.set(OptionNames.DefaultSeriesRowCount, 2);
        this.set(OptionNames.DefaultSeriesColumnCount, 2);   
        this.set(OptionNames.DateFormat, "MM/d/yyyy");     
        this.set(OptionNames.TimeFormat, " hh:mm:ss tt");
        this.set(OptionNames.RemoteConfig, "");        
        this.set(OptionNames.MaxStudyResults, 0);
        this.set(OptionNames.MaxSeriesResults, 0);
        this.set(OptionNames.MaxPatientResults, 0);
        this.set(OptionNames.SearchOtherPatientIds, false);
        this.set(OptionNames.EnablePatientRestriction, false);
        this.set(OptionNames.TemplateBackgroundColor, "#000000");
        this.set(OptionNames.TemplateBorderColor, "#FF0000");
        this.set(OptionNames.TemplateBorderSize, 2);
        this.set(OptionNames.TemplateBoundsNotification, true);
        this.set(OptionNames.TemplateForeColor, "#FFFFFF");
        this.set(OptionNames.DefaultScript, "true;");
        this.set(OptionNames.LazyLoadingThreshold, 100);
        this.set(OptionNames.LazyLoadingMobileThreshold, 25);
        this.set(OptionNames.LazyLoadingBuffer, 5);

        this.set(OptionNames.StackSingleFrames, true);
        this.set(OptionNames.ShowStudyTimeLine, false);
        this.set(OptionNames.LinkImages, true);

        this.set(OptionNames.MPRRenderSide, "Server Side")
        this.set(OptionNames.RenderingMethod, "Hardware Software");

        this.set(OptionNames.EnableOkta, false);
        this.set(OptionNames.EnableShibboleth, false);

        this.set(OptionNames.EnableCaching, false);

        this.set(OptionNames.CaptureSize, 1024);
        this.set(OptionNames.CaptureLayout, true);
    }

    public set(key: string, val: any) {
        this._objectDictionary[key] = val;
    }

    public get(key: string) {
        return this._objectDictionary[key];
    }

    public has(key: string) {
        return this._objectDictionary.hasOwnProperty(key);
    }

    public should(key: string) {
        return this.has(key) && this.get(key) == true;
    }

    public GetUserOptions(success: Function, error: Function): ng.IHttpPromise<any> {

      var currentTheme = window.localStorage.getItem("leadmedicalwebviewertheme");
      switch (currentTheme) {
         case "dark":
            
            var themeCSSElement = <HTMLLinkElement>document.getElementById('theme_css');
            themeCSSElement.href = 'css/darktheme.css';
            //element.checked = true;
            break;
         case "light":
            var themeCSSElement = <HTMLLinkElement>document.getElementById('theme_css');
            themeCSSElement.href = 'css/theme-light.css';
            
            //element.checked = false;
            break;
         default:
            
            var themeCSSElement = <HTMLLinkElement>document.getElementById('theme_css');
            themeCSSElement.href = 'css/darktheme.css';
         //element.checked = !element.checked;

      }

        var parameter = "auth=" + encodeURIComponent(this._authenticationService.authenticationCode);
        var __this = this;

        return this._httpService.get(this._optionsServiceUrl + "/GetUserOptions?" + parameter + "&r=" + Date.now()).success(function (options) {            
            //
            // Create properties with the option names
            //
           $.each(options, function (key, value) {
              if (value.Key) {//old wcf service
                 __this._objectDictionary[value.Key] = Utils.toBoolean(value.Value, value.Value);
              }
              else {
                 __this._objectDictionary[key] = Utils.toBoolean(value, value);
              }
            });
            
           //#Shibboleth : always disable shibboleth, remove this line to enable functionality
           __this.set(OptionNames.EnableShibboleth, false);
            
           if (__this._authenticationService.user) {
              __this._authenticationService.getUserRoles(__this._authenticationService.user).success(function (result) {
                 var role = result[0];

                 var toolbarName: string = "main";

                 __this.getRoleOption(role, OptionNames.Toolbar + "_" + toolbarName).success(function (data: string) {
                    if (data && data.length > 0) {
                       //data = data.replace(/(\r\n|\n|\r|\t|\\)/gm, "");
                       //items = JSON.parse(data).items;
                       var key = OptionNames.Toolbar + "_" + toolbarName;
                       __this._objectDictionary[key] = Utils.toBoolean(key, data);


                       __this.getRoleOption(role, OptionNames.DisabledToolbarItems + "_" + toolbarName).success(function (disabledItems) {

                          if (disabledItems && disabledItems.length > 0) {
                             //disabledItems = disabledItems.replace(/(\r\n|\n|\r|\t|\\)/gm, "");
                             //items = JSON.parse(data).items;

                             var key = OptionNames.DisabledToolbarItems + "_" + toolbarName;

                             __this._objectDictionary[key] = Utils.toBoolean(key, disabledItems);
                             success(options);
                          }
                          else {
                             success(options);
                          }

                       }).error(function (data, status, headers, config) { error(data, status, headers, config); });

                    }
                    else {
                       success(options);
                    }
                 }).error(function (data, status, headers, config) { error(data, status, headers, config); });
              }).error(function (data, status, headers, config) { error(data, status, headers, config); });
           }
           else {
              success(options);
           }
        }).error(function (data, status, headers, config) { error(data, status, headers, config); });
   };

    private dictionaryToWCFArray(obj) {
        var data = [];
        for (var key in obj) {
            data.push({ Key: key, Value: obj[key] });
        }

        return data;
    }

    public saveDefaultOptions(defaultOptions): ng.IHttpPromise<any> {
        var data = this.dictionaryToWCFArray(defaultOptions);
        var postData = {
            authenticationCookie: this._authenticationService.authenticationCode,
            options: data
        };

        return this._httpService.post(this._optionsServiceUrl + "/SaveDefaultOptions", JSON.stringify(postData));
    }

    public saveRoleOptions(role: string, options): ng.IHttpPromise<any> {
        var data = this.dictionaryToWCFArray(options);
        var postData = {
            authenticationCookie: this._authenticationService.authenticationCode,
            role: role,
            options: data
        };

        return this._httpService.post(this._optionsServiceUrl + "/SaveRoleOptions", JSON.stringify(postData));
    }

    public getRoleOption(role: string, option: string): ng.IHttpPromise<any> {
        var postData = {
            authenticationCookie: this._authenticationService.authenticationCode,
            role: role,
            optionName: option
        };

        return this._httpService.post(this._optionsServiceUrl + "/GetRoleOption", JSON.stringify(postData));
    }

    public saveUserOption(name: string, value: any): ng.IHttpPromise<any> {
        var postData = {
            authenticationCookie: this._authenticationService.authenticationCode,
            optionName: name,
            optionValue: value
        };

        return this._httpService.post(this._optionsServiceUrl + "/SaveUserOption", JSON.stringify(postData));
    }
} 

services.service('optionsService', OptionsService);