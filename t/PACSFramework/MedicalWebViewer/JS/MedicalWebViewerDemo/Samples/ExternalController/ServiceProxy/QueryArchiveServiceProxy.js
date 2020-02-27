// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../../lib/jquery/jquery.d.ts" />
/// <reference path="ServiceProxy.ts" />
var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var QueryArchiveServiceProxy = (function (_super) {
    __extends(QueryArchiveServiceProxy, _super);
    function QueryArchiveServiceProxy() {
        _super.apply(this, arguments);
    }
    QueryArchiveServiceProxy.prototype.FindPatients = function (queryParams, errorHandler, successHandler) {
        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        return _super.prototype.DoJsonCall.call(this, "FindPatients", queryParams, errorHandler, successHandler);
    };

    QueryArchiveServiceProxy.prototype.FindPatientsMax = function (queryParams, maxQueryResults, errorHandler, successHandler) {
        var extraOptions = {};
        extraOptions.UserData = JSON.stringify(maxQueryResults);

        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        queryParams.extraOptions = extraOptions;

        return _super.prototype.DoJsonCall.call(this, "FindPatients", queryParams, errorHandler, successHandler);
    };

    QueryArchiveServiceProxy.prototype.FindStudies = function (queryParams, errorHandler, successHandler) {
        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        return _super.prototype.DoJsonCall.call(this, "FindStudies", queryParams, errorHandler, successHandler);
    };

    QueryArchiveServiceProxy.prototype.FindStudiesMax = function (queryParams, maxQueryResults, errorHandler, successHandler) {
        var extraOptions = {};
        extraOptions.UserData = JSON.stringify(maxQueryResults);

        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        queryParams.extraOptions = extraOptions;

        return _super.prototype.DoJsonCall.call(this, "FindStudies", queryParams, errorHandler, successHandler);
    };

    QueryArchiveServiceProxy.prototype.FindSeries = function (queryParams, errorHandler, successHandler) {
        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        return _super.prototype.DoJsonCall.call(this, "FindSeries", queryParams, errorHandler, successHandler);
    };

    QueryArchiveServiceProxy.prototype.FindSeriesMax = function (queryParams, maxQueryResults, errorHandler, successHandler) {
        var extraOptions = {};
        extraOptions.UserData = JSON.stringify(maxQueryResults);

        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        queryParams.extraOptions = extraOptions;

        return _super.prototype.DoJsonCall.call(this, "FindSeries", queryParams, errorHandler, successHandler);
    };

    QueryArchiveServiceProxy.prototype.FindInstances = function (queryParams, errorHandler, successHandler) {
        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        return _super.prototype.DoJsonCall.call(this, "FindInstances", queryParams, errorHandler, successHandler);
    };

    QueryArchiveServiceProxy.prototype.FindInstancesMax = function (queryParams, maxQueryResults, errorHandler, successHandler) {
        var extraOptions = {};
        extraOptions.UserData = JSON.stringify(maxQueryResults);

        queryParams.authenticationCookie = this.AuthenticationProxy.GetAuthenticationCookie();
        queryParams.extraOptions = extraOptions;

        return _super.prototype.DoJsonCall.call(this, "FindInstances", queryParams, errorHandler, successHandler);
    };

    QueryArchiveServiceProxy.prototype.FindPresentationState = function (referencedSeries, errorHandler, successHandler) {
        var parameter = "auth=" + encodeURIComponent(this.AuthenticationProxy.GetAuthenticationCookie()) + "&series=" + referencedSeries;

        return _super.prototype.DoGetGeneralCall.call(this, "FindPresentationState", parameter, errorHandler, successHandler);
    };

    QueryArchiveServiceProxy.prototype.ElectStudyTimeLineInstances = function (queryParams, errorHandler, successHandler, userdata) {
        return _super.prototype.DoJsonCallUserData.call(this, "ElectStudyTimeLineInstances", queryParams, errorHandler, successHandler, userdata);
    };

    QueryArchiveServiceProxy.prototype.GetDicom = function (queryParams, errorHandler, successHandler) {
        return _super.prototype.DoPostXmlCall.call(this, "GetDicom", queryParams, errorHandler, successHandler);
    };

    QueryArchiveServiceProxy.prototype.AutoComplete = function (key, term, errorHandler, successHandler) {
        var parameter = "auth=" + encodeURIComponent(this.AuthenticationProxy.GetAuthenticationCookie()) + "&key=" + key + "&term=" + term;

        return _super.prototype.DoGetGeneralCall.call(this, "AutoComplete", parameter, errorHandler, successHandler);
    };
    return QueryArchiveServiceProxy;
})(ServiceProxy);
;
//# sourceMappingURL=QueryArchiveServiceProxy.js.map
