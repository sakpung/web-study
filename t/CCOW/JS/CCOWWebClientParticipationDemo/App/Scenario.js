// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var CcowWebClientParticipationDemo;
(function (CcowWebClientParticipationDemo) {
    var ActiveScenario = /** @class */ (function () {
        function ActiveScenario() {
        }
        ActiveScenario.deserialize = function (input) {
            var activeScenario = new ActiveScenario();
            activeScenario.Scenario = Scenario.deserialize(input.Scenario);
            return activeScenario;
        };
        ActiveScenario.load = function (url) {
            var xmlhttp = new XMLHttpRequest();
            xmlhttp.open("GET", url, false);
            xmlhttp.setRequestHeader("Access-Control-Allow-Origin", "*");
            xmlhttp.send();
            var xmlDoc = xmlhttp.responseXML;
            return this.deserialize(this.deserializeXml(xmlDoc));
        };
        ActiveScenario.isContentArray = function (xml) {
            for (var i = 0; i < xml.childNodes.length; i++) {
                var item = xml.childNodes.item(i);
                if (item.nodeType == Node.TEXT_NODE)
                    continue;
                for (var j = i + 1; j < xml.childNodes.length; j++) {
                    var item2 = xml.childNodes.item(j);
                    if (item2.nodeType == Node.TEXT_NODE)
                        continue;
                    if (item.nodeName == item2.nodeName) {
                        return true;
                    }
                }
            }
            return false;
        };
        ActiveScenario.deserializeXml = function (xml) {
            var obj = {};
            if (xml.hasChildNodes()) {
                var parentNodeName = xml.nodeName;
                for (var i = 0; i < xml.childNodes.length; i++) {
                    var item = xml.childNodes.item(i);
                    if (item.nodeType == Node.TEXT_NODE)
                        continue;
                    var isContetArray = this.isContentArray(item);
                    var nodeName = item.nodeName;
                    if (obj[nodeName] == undefined) {
                        if (item.childNodes.length == 1) {
                            obj[nodeName] = item.firstChild.textContent;
                        }
                        else {
                            if (isContetArray) {
                                obj[nodeName] = [];
                                for (var j = 0; j < item.childNodes.length; j++) {
                                    var childItem = item.childNodes.item(j);
                                    if (childItem.nodeType == 3)
                                        continue;
                                    obj[nodeName].push(this.deserializeXml(childItem));
                                }
                            }
                            else {
                                obj[nodeName] = this.deserializeXml(item);
                            }
                        }
                    }
                }
            }
            return obj;
        };
        return ActiveScenario;
    }());
    CcowWebClientParticipationDemo.ActiveScenario = ActiveScenario;
    var Scenario = /** @class */ (function () {
        function Scenario() {
        }
        Scenario.prototype.toString = function () {
            if (this.Description.length > 0)
                return this.Description;
            return "No Description Provided";
        };
        Scenario.deserialize = function (input) {
            var scenario = new Scenario();
            scenario.Description = input.Description.toString();
            scenario.MasterUserIndex = [];
            for (var i = 0; i < input.MasterUserIndex.length; i++) {
                var masterUser = MasterUser.deserialize(input.MasterUserIndex[i]);
                scenario.MasterUserIndex.push(masterUser);
            }
            scenario.MasterPatientIndex = [];
            for (var i = 0; i < input.MasterPatientIndex.length; i++) {
                var masterPatient = MasterPatient.deserialize(input.MasterPatientIndex[i]);
                scenario.MasterPatientIndex.push(masterPatient);
            }
            scenario.Applications = [];
            for (var i = 0; i < input.Applications.length; i++) {
                var application = CCOWApplication.deserialize(input.Applications[i]);
                scenario.Applications.push(application);
            }
            return scenario;
        };
        return Scenario;
    }());
    CcowWebClientParticipationDemo.Scenario = Scenario;
    var User = /** @class */ (function () {
        function User() {
        }
        User.prototype.User = function () {
            this.DomainLogin = false;
        };
        User.prototype.toString = function () {
            if (this.Username.length > 0)
                return this.Username;
            return "";
        };
        User.deserialize = function (input) {
            var user = new User();
            user.Name = input.Name;
            user.Username = input.Username;
            user.Password = input.Password;
            user.DomainLogin = input.DomainLogin.toString() == "true";
            user.Domain = input.Domain;
            return user;
        };
        return User;
    }());
    CcowWebClientParticipationDemo.User = User;
    var MasterUser = /** @class */ (function (_super) {
        __extends(MasterUser, _super);
        function MasterUser() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        MasterUser.prototype.toString = function () {
            if (this.Username.length > 0)
                return this.Username;
            return "";
        };
        MasterUser.deserialize = function (input) {
            var masterUser = new MasterUser();
            masterUser.Name = input.Name;
            masterUser.Username = input.Username;
            masterUser.Password = input.Password;
            masterUser.DomainLogin = input.DomainLogin;
            masterUser.Domain = input.Domain;
            masterUser.ApplicationUsers = [];
            for (var i = 0; i < input.ApplicationUsers.length; i++) {
                var appUser = ApplicationUser.deserialize(input.ApplicationUsers[i]);
                masterUser.ApplicationUsers.push(appUser);
            }
            return masterUser;
        };
        return MasterUser;
    }(User));
    CcowWebClientParticipationDemo.MasterUser = MasterUser;
    var ApplicationUser = /** @class */ (function () {
        function ApplicationUser() {
        }
        ApplicationUser.deserialize = function (input) {
            var appUser = new ApplicationUser();
            appUser.LogonName = input.LogonName;
            appUser.ApplicationName = input.ApplicationName;
            return appUser;
        };
        return ApplicationUser;
    }());
    CcowWebClientParticipationDemo.ApplicationUser = ApplicationUser;
    var Patient = /** @class */ (function () {
        function Patient() {
        }
        Patient.prototype.toString = function () {
            return this.Name;
        };
        Patient.deserialize = function (input) {
            var patient = new Patient();
            patient.Id = input.Id;
            patient.Name = input.Name;
            patient.BirthDate = input.BirthDate;
            patient.Sex = input.Sex;
            return patient;
        };
        return Patient;
    }());
    CcowWebClientParticipationDemo.Patient = Patient;
    var MasterPatient = /** @class */ (function (_super) {
        __extends(MasterPatient, _super);
        function MasterPatient() {
            return _super !== null && _super.apply(this, arguments) || this;
        }
        MasterPatient.deserialize = function (input) {
            var masterPatient = new MasterPatient();
            masterPatient.Id = input.Id;
            masterPatient.Name = input.Name;
            masterPatient.BirthDate = input.BirthDate;
            masterPatient.Sex = input.Sex;
            masterPatient.ApplicationPatients = [];
            for (var i = 0; i < input.ApplicationPatients.length; i++) {
                var appUser = ApplicationPatient.deserialize(input.ApplicationPatients[i]);
                masterPatient.ApplicationPatients.push(appUser);
            }
            return masterPatient;
        };
        return MasterPatient;
    }(Patient));
    CcowWebClientParticipationDemo.MasterPatient = MasterPatient;
    var ApplicationPatient = /** @class */ (function () {
        function ApplicationPatient() {
        }
        ApplicationPatient.deserialize = function (input) {
            var applicationPatient = new ApplicationPatient();
            applicationPatient.ApplicationName = input.ApplicationName;
            applicationPatient.PatientId = input.PatientId;
            return applicationPatient;
        };
        return ApplicationPatient;
    }());
    CcowWebClientParticipationDemo.ApplicationPatient = ApplicationPatient;
    var CCOWApplication = /** @class */ (function () {
        function CCOWApplication() {
        }
        CCOWApplication.deserialize = function (input) {
            var app = new CCOWApplication();
            app.Name = input.Name;
            app.Suffix = input.Suffix;
            app.Users = [];
            for (var i = 0; i < input.Users.length; i++) {
                var user = User.deserialize(input.Users[i]);
                app.Users.push(user);
            }
            app.Patients = [];
            for (var i = 0; i < input.Patients.length; i++) {
                var patient = Patient.deserialize(input.Patients[i]);
                app.Patients.push(patient);
            }
            return app;
        };
        return CCOWApplication;
    }());
    CcowWebClientParticipationDemo.CCOWApplication = CCOWApplication;
})(CcowWebClientParticipationDemo || (CcowWebClientParticipationDemo = {}));
//# sourceMappingURL=Scenario.js.map