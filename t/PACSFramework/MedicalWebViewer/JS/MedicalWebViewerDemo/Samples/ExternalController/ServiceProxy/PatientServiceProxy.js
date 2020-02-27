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
var PatientServiceProxy = (function (_super) {
    __extends(PatientServiceProxy, _super);
    function PatientServiceProxy() {
        _super.apply(this, arguments);
    }
    PatientServiceProxy.prototype.AddPatient = function (patientInfo, errorHandler, successHandler) {
        var dataArgs = {
            authenticationCookie: this.AuthenticationProxy.GetAuthenticationCookie(),
            info: patientInfo,
            userData: null
        };

        return _super.prototype.DoPostGeneralCall.call(this, "AddPatient", dataArgs, errorHandler, successHandler);
    };

    PatientServiceProxy.prototype.UpdatePatient = function (patientInfo, errorHandler, successHandler) {
        var dataArgs = {
            authenticationCookie: this.AuthenticationProxy.GetAuthenticationCookie(),
            info: patientInfo,
            extraOptions: null
        };

        return _super.prototype.DoPostGeneralCall.call(this, "UpdatePatient", dataArgs, errorHandler, successHandler);
    };

    PatientServiceProxy.prototype.DeletePatient = function (patientId, errorHandler, successHandler) {
        var dataArgs = {
            authenticationCookie: this.AuthenticationProxy.GetAuthenticationCookie(),
            patientId: patientId,
            extraOptions: null
        };

        return _super.prototype.DoPostGeneralCall.call(this, "DeletePatient", dataArgs, errorHandler, successHandler);
    };
    return PatientServiceProxy;
})(ServiceProxy);
;

var PatientInfo = (function () {
    function PatientInfo(patientId, name, birthDate, sex, comments, ethnicGroup) {
        this.PatientId = patientId;
        this.Name = name;
        this.BirthDate = birthDate;
        this.Sex = sex;
        this.Comments = comments;
        this.EthnicGroup = ethnicGroup;
    }
    return PatientInfo;
})();

var PersonName = (function () {
    function PersonName() {
        var args = [];
        for (var _i = 0; _i < (arguments.length - 0); _i++) {
            args[_i] = arguments[_i + 0];
        }
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
    PersonName.prototype.getDicomName = function () {
        var dicomName = this.Last.trim() + this.sep + this.First.trim() + this.sep + this.Middle.trim() + this.sep + this.Prefix.trim() + this.sep + this.Suffix.trim();
        return dicomName;
    };

    PersonName.getPersonName = function (dicomName) {
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
    };
    return PersonName;
})();
//# sourceMappingURL=PatientServiceProxy.js.map
