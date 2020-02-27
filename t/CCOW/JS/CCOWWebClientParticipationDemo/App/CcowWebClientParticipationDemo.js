// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
var CcowWebClientParticipationDemo;
(function (CcowWebClientParticipationDemo) {
    var ContextState;
    (function (ContextState) {
        ContextState[ContextState["Linked"] = 0] = "Linked";
        ContextState[ContextState["Broken"] = 1] = "Broken";
        ContextState[ContextState["Changing"] = 2] = "Changing";
    })(ContextState = CcowWebClientParticipationDemo.ContextState || (CcowWebClientParticipationDemo.ContextState = {}));
    var SurveyResponse;
    (function (SurveyResponse) {
        SurveyResponse[SurveyResponse["Accept"] = 0] = "Accept";
        SurveyResponse[SurveyResponse["Conditional"] = 1] = "Conditional";
        SurveyResponse[SurveyResponse["Busy"] = 2] = "Busy";
    })(SurveyResponse = CcowWebClientParticipationDemo.SurveyResponse || (CcowWebClientParticipationDemo.SurveyResponse = {}));
    var DemoApp = /** @class */ (function () {
        function DemoApp(dashborad, userLink, clr, appIndex) {
            /* Create shortcuts for all ccowWebClientParticipationDemo main page UI elements */
            this.UI = {
                clientServiceErrorDialog: "clientServiceErrorDialog",
                table_patients: "table_patients",
                table_context: "table_context",
                textarea_log: "textarea_log",
                img_status: "img_status",
                span_linktype: "span_linktype",
                span_user: "span_user",
                img_user: "img_user",
                menu_logon: "menu_logon",
                menu_logoff: "menu_logoff",
                menu_logoffAll: "menu_logoffAll",
                menu_suspend: "menu_suspend",
                menu_resume: "menu_resume",
                header_div: "header-div",
                header_demoName: "header-demoName",
                troubleshootingGuide: "troubleshootingGuide",
            };
            this._patientLink = "Link Type: Patient";
            this._userPatientLink = "Link Type: User, Patient";
            this.appScenarioIndex = 3;
            this.applicationName = "CCOW Web Client Participation Demo1";
            this._suffix = "WebClientDemo1";
            this._clientServerUrl = "http://localhost:80/LEADTOOLSContextParticipant/";
            this._loggedIn = false;
            this._newPatientId = "";
            this._newUser = "";
            this._updateContext = true;
            this._logOff = false;
            this._appOnlyLogin = false;
            this._currentUser = "";
            this._dashboard = false;
            //
            // Determines if the application is started as a user link participant.  If this is true the application
            // syncs with user and patient link.  If false it is only a patient linked application.
            //
            this._userLink = false;
            this.loggingIn = false;
            this._plugin = new lt.Ccow.ClientParticipantPlugin();
            this._dashboard = dashborad;
            this._userLink = userLink;
            this.appScenarioIndex = appIndex + 2;
            this.applicationName = "CCOW Web Client Participation Demo{0}".format(appIndex);
            this._suffix = "WebClientDemo{0}".format(appIndex);
            document.getElementById(this.UI.header_div).style.backgroundColor = clr;
            document.getElementById(this.UI.header_demoName).textContent = this.applicationName;
            this.InitUI();
        }
        DemoApp.prototype.showMessage = function (errMsg) {
            if (errMsg != null) {
                if (typeof errMsg == "string" || errMsg instanceof String) {
                    if (errMsg.length > 0)
                        alert(errMsg);
                }
                else if (errMsg instanceof Error && typeof errMsg.message != "undefined") {
                    if (errMsg.message.length > 0)
                        alert(errMsg);
                }
                else {
                    alert(errMsg);
                }
            }
        };
        DemoApp.prototype.showStartServiceError = function () {
            if (lt.LTHelper.browser == lt.LTBrowser.edge) {
                document.getElementById(this.UI.troubleshootingGuide).style.visibility = "visible";
            }
            $(document.getElementById(this.UI.clientServiceErrorDialog)).modal();
        };
        DemoApp.prototype.isClientServiceRunning = function () {
            var d = $.Deferred();
            // Check if the service is running
            var clientUtils = new lt.Ccow.ClientUtils(new lt.Ccow.CcowService(this._clientServerUrl));
            var pingPromise = clientUtils.ping();
            pingPromise.done(function () {
                d.resolve();
            });
            pingPromise.fail(function () {
                d.reject();
            });
            return d.promise();
        };
        DemoApp.prototype.startPlugin = function () {
            var _this = this;
            var d = $.Deferred();
            var demoApp = this;
            var count = 20;
            this.isClientServiceRunning()
                .done(function () {
                d.resolve();
                return d;
            })
                .fail(function (jqXHR, textStatus, errorThrown) {
                // Show loading dialog
                _this._loadingDlg.setDescription("Starting Web Client Participant Service");
                _this._loadingDlg.show();
                // try to run the service
                try {
                    demoApp._plugin.start(null);
                }
                catch (e) {
                    // Do nothing
                }
                var interval = setInterval(function () {
                    count = count - 1;
                    // check if the service is ready
                    demoApp.isClientServiceRunning()
                        .done(function () {
                        // If the service is ready, hide the loading dialog and Init demo UI
                        clearInterval(interval);
                        demoApp._loadingDlg.hide();
                        d.resolve();
                    })
                        .fail(function (jqXHR, textStatus, errorThrown) {
                        if (count == 0) {
                            clearInterval(interval);
                            demoApp._loadingDlg.hide();
                            demoApp.showStartServiceError();
                            d.reject();
                        }
                    });
                }, 500);
            });
            return d.promise();
        };
        DemoApp.prototype.closePlugIn = function () {
            if (this._plugin != null) {
                try {
                    this._plugin.stop();
                }
                catch (e) { }
            }
        };
        DemoApp.prototype.run = function () {
            var _this = this;
            // Check if the browser supports web sockets
            if ((typeof WebSocket) == "undefined") {
                this.showMessage("WebSocket is not supported by this browser!");
                return;
            }
            this.startPlugin()
                .done(function () {
                _this.Init();
            });
        };
        DemoApp.prototype.onClose = function () {
            var _this = this;
            if (this._context != null) {
                if (this._context.joined) {
                    this._context.leave(function () {
                    }, function (error) {
                        _this.showMessage(error);
                    });
                }
            }
        };
        DemoApp.prototype.Init = function () {
            var _this = this;
            try {
                this._activeScenario = CcowWebClientParticipationDemo.ActiveScenario.load("Scenarios/P1_Default.xml");
                if (this._activeScenario != null && this._activeScenario.Scenario != undefined && this._activeScenario.Scenario.Applications.length > this.appScenarioIndex) {
                    this._ccowApplication = this._activeScenario.Scenario.Applications[this.appScenarioIndex];
                }
                this.setCCowIcon(ContextState.Broken);
                CcowWebClientParticipationDemo.ClientContext.create(this.applicationName, this, this._clientServerUrl, function (result) {
                    _this._context = result;
                    _this._context.join(_this.applicationName, true, function () {
                        var failedVerify = false;
                        _this.setCCowIcon(ContextState.Linked);
                        _this.showContext();
                        try {
                            if (_this._dashboard) {
                                _this._context.secureBindCheck(function (failedVerify) {
                                    _this.doDashboard(true, failedVerify);
                                }, function (error) {
                                    _this.showMessage(error);
                                });
                            }
                            else {
                                _this.doApplicationLogin();
                            }
                        }
                        catch (ex) {
                            _this.showMessage(ex);
                        }
                    }, function (error) {
                        _this.showMessage(error);
                    });
                }, function (error) {
                    _this.showMessage("Please make sure that the \"CCOWServerDemo\" is running.\n" + error);
                });
            }
            catch (e) {
                this.showMessage(e);
            }
        };
        DemoApp.prototype.onLogIn = function (user) {
            var _this = this;
            this.setUserInfo(user);
            this._loggedIn = true;
            try {
                if (this._loggedIn) {
                    this._appOnlyLogin = true;
                    var filter = [];
                    filter.push("Patient");
                    this._context.setFilter(filter);
                    this.setLinkDisplay(this._patientLink);
                    this.showContext();
                }
                if (this._context.joined) {
                    this.initializePatients();
                    this._context.lastCoupon(function (res) {
                        if (res != 0) {
                            _this.checkPatient(res, false, function (result) {
                                _this._newPatientId = result;
                                _this.selectNewPatient();
                            });
                        }
                    }, function (error) {
                        _this.showMessage(error);
                    });
                }
            }
            catch (e) {
                this._loadingDlg.hide();
                this.showMessage(e);
            }
            if (this.getUserLink())
                this.setLinkDisplay(this._userPatientLink);
            else
                this.setLinkDisplay(this._patientLink);
        };
        DemoApp.prototype.doDashboard = function (showInfo, failedVerify) {
            var _this = this;
            this._loadingDlg.hide();
            if (this.getUserLink()) {
                this._context.isUserContextSet(function (result) {
                    if (!result) {
                        _this.showMessage("This application cannot continue.  The application was launched from the CCOW Dashboard and requires that a user be set in the context.");
                        _this.onClose();
                        return;
                    }
                    else {
                        //
                        // The user context is set, therefore we need to check to see if we can logon this specific user
                        //
                        _this._context.getCurrentUser(function (user) {
                            if (user != null && user.length > 0) {
                                _this.logInApplication(user);
                                _this.setLinkDisplay(_this._userPatientLink);
                            }
                            ;
                        }, function (error) {
                            _this.showMessage(error);
                        });
                    }
                }, function (error) {
                    _this.showMessage(error);
                });
            }
            else {
                if (showInfo) {
                    if (!failedVerify) {
                        this.showMessage("This application was launched from the dashboard without user link enabled. " +
                            "However, you will be required to log into the application.  The login " +
                            "dialog will appear when this message box is closed.  Once logged in the application " +
                            " will be patient linked only.");
                    }
                    else {
                        this.showMessage("This application failed to securely bind with the context manager. " +
                            "However, you will be required to log into the application.  The login " +
                            "dialog will appear when this message box is closed.  Once logged in the application " +
                            " will be patient linked only.");
                    }
                }
                this.doApplicationLogin();
                if (this._loggedIn) {
                    //
                    // Only be notified of patient context changes
                    //
                    this._appOnlyLogin = true;
                    var filter = [];
                    filter.push("Patient");
                    this._context.setFilter(filter);
                    this.setLinkDisplay(this._patientLink);
                }
            }
            if (this._context.joined) {
                this.initializePatients();
                this._context.lastCoupon(function (res) {
                    if (res != 0) {
                        _this.checkPatient(res, false, function (result) {
                            _this._newPatientId = result;
                            _this.selectNewPatient();
                        });
                    }
                }, function (error) {
                    _this.showMessage(error);
                });
            }
        };
        DemoApp.prototype.doApplicationLogin = function () {
            var _this = this;
            var dlgLogin = new CcowWebClientParticipationDemo.LogInDialog(this._ccowApplication);
            dlgLogin.onUserLogin = function (user) { _this.onLogIn(user); };
            dlgLogin.show();
        };
        DemoApp.prototype.logInApplication = function (user) {
            var _this = this;
            if (this.loggingIn)
                return;
            try {
                this.loggingIn = true;
                this._context.getAuthenticationData(user, function (authData) {
                    //
                    // If we do not have any authentication data then we need to display a dialog and
                    // let the user log into this application. Once successfully logged in the user auth
                    // data (password) will be added to the authentication repository.
                    //
                    if (authData == null || authData.length < 1) {
                        _this._loadingDlg.hide();
                        var dlgLogin = new CcowWebClientParticipationDemo.LogInDialog(_this._ccowApplication);
                        dlgLogin.username = user;
                        dlgLogin.enableUser = false;
                        dlgLogin.firstLogin = true;
                        dlgLogin.onUserLogin = function (user) {
                            _this._context.setAuthenticationData(user, dlgLogin.password, function () {
                                _this._loggedIn = true;
                                _this.setUserInfo(user);
                            }, function (error) {
                                _this.showMessage(error);
                            });
                        };
                        dlgLogin.show();
                    }
                    else {
                        _this.setUserInfo(user);
                        _this._loggedIn = true;
                    }
                }, function (error) {
                    _this.showMessage(error);
                });
            }
            finally {
                this.loggingIn = false;
            }
        };
        DemoApp.prototype.initializePatients = function () {
            var patientsTable = document.getElementById(this.UI.table_patients);
            for (var i = patientsTable.rows.length - 1; i >= 1; i--)
                patientsTable.deleteRow(i);
            if (this._ccowApplication != null) {
                for (var i = 0; i < this._ccowApplication.Patients.length; i++) {
                    this.addPatient(this._ccowApplication.Patients[i], i + 1);
                }
                this.enablePatientTable(true);
            }
        };
        DemoApp.prototype.addPatient = function (patient, index) {
            var patientsTable = document.getElementById(this.UI.table_patients);
            var row = patientsTable.insertRow(index);
            row.insertCell(0).innerHTML = patient.Id;
            row.insertCell(1).innerHTML = patient.Name;
            row.insertCell(2).innerHTML = patient.BirthDate;
            row.insertCell(3).innerHTML = patient.Sex;
        };
        DemoApp.prototype.enablePatientTable = function (enable) {
            var _this = this;
            var patientsTable = document.getElementById(this.UI.table_patients);
            var index = -1;
            for (var i = 0; i < patientsTable.rows.length; i++) {
                var row = patientsTable.rows[i];
                row.onclick = enable ? (function (ev) { return _this.patients_SelectedIndexChanged(ev.currentTarget); }) : null;
            }
        };
        DemoApp.prototype.setUserInfo = function (user) {
            this._currentUser = user;
            var spanUser = document.getElementById(this.UI.span_user);
            var imgUser = document.getElementById(this.UI.img_user);
            spanUser.textContent = user;
            if (user == null || user.length < 1) {
                this._loggedIn = false;
                imgUser.style.visibility = "collapse";
            }
            else {
                imgUser.style.visibility = "visible";
            }
        };
        DemoApp.prototype.selectTableRow = function (row, select) {
            row.bgColor = select ? "gray" : "white";
        };
        DemoApp.prototype.isTableRowSelected = function (row) {
            return row.bgColor == "gray";
        };
        DemoApp.prototype.patients_SelectedIndexChanged = function (row) {
            var _this = this;
            if (this.isTableRowSelected(row))
                return;
            try {
                var patientsTable = document.getElementById(this.UI.table_patients);
                var index = -1;
                for (var i = 0; i < patientsTable.rows.length; i++) {
                    if (row == patientsTable.rows[i]) {
                        index = i - 1;
                    }
                    this.selectTableRow(patientsTable.rows[i], false);
                }
                this.selectTableRow(row, true);
                if (index >= 0 && this._updateContext && this._context.joined) {
                    var patient = this._ccowApplication.Patients[index];
                    var patientSubject = new lt.Ccow.Subject();
                    patientSubject.name = "Patient";
                    var item = new lt.Ccow.ContextItem("Patient.Id.MRN." + this.getSuffix());
                    if (patient != null)
                        item.value = patient.Id;
                    patientSubject.items.add(item);
                    this._context.setSubject(patientSubject, function () {
                        _this.showContext();
                    }, function (error) {
                        _this.showMessage(error);
                    });
                }
                else {
                    if (!this._context.joined) {
                        this.log("Not a member of the context");
                        this.log("    Patient context not switched");
                    }
                }
            }
            catch (ex) {
                this.showMessage(ex);
            }
        };
        DemoApp.prototype.setCCowIcon = function (state) {
            var image = document.getElementById(this.UI.img_status);
            switch (state) {
                case ContextState.Broken:
                    image.src = "Images/broken48.png";
                    break;
                case ContextState.Changing:
                    image.src = "Images/changing48.png";
                    break;
                case ContextState.Linked:
                    image.src = "Images/link48.png";
                    break;
            }
        };
        DemoApp.prototype.log = function (str) {
            var obj = [];
            for (var _i = 1; _i < arguments.length; _i++) {
                obj[_i - 1] = arguments[_i];
            }
            var textarea = document.getElementById(this.UI.textarea_log);
            var txt = str.format(obj);
            if (obj.length > 1) {
                for (var i = 1; i < obj.length; i++)
                    txt = txt.replace("{{0}}".format(i.toString()), obj[i].toString());
            }
            textarea.textContent += txt;
            textarea.textContent += "\n";
            textarea.scrollTop = textarea.scrollHeight;
        };
        DemoApp.prototype.onContextTerminated = function () {
            this.log("=> Context Terminated");
        };
        DemoApp.prototype.onContextChangesAccepted = function (coupon) {
            var _this = this;
            this.log("=> Context Changes Accepted");
            if (this._logOff) {
                this.logOffUser();
            }
            else if (this._newUser != null && this._newUser.length > 0 && this.getUserLink()) {
                this.logInApplication(this._newUser);
            }
            if (!this.loggingIn) {
                this.checkPatient(coupon, true, function (result) {
                    _this._newPatientId = result;
                    _this.selectNewPatient();
                    _this.showContext();
                });
            }
        };
        DemoApp.prototype.onContextChangesCanceled = function (coupon) {
            this.log("=> Context Changes Canceled");
            this._newPatientId = "";
            this._newUser = "";
        };
        DemoApp.prototype.onContextChangesPending = function (contextCoupon) {
            var _this = this;
            this.log("=> Context Changes Pending");
            this._context.isSetting("user", "logon", contextCoupon, function (result) {
                if (result)
                    _this.checkUser(contextCoupon);
            }, function (error) {
                _this.showMessage(error);
            });
            this.checkPatient(contextCoupon, true, function (result) {
                _this._newPatientId = result;
            });
        };
        DemoApp.prototype.joinedContext = function (context) {
            this.log("=> Successfully Joined Context");
            this.log("     Participant Coupon: " + this._context.participantCoupon.toString());
        };
        DemoApp.prototype.leftContext = function (context) {
            this.setCCowIcon(ContextState.Broken);
        };
        DemoApp.prototype.pinged = function (context) {
            this.log("=> Received Ping");
        };
        DemoApp.prototype.getSuffix = function () {
            return this._suffix;
        };
        DemoApp.prototype.getUserLink = function () {
            return this._userLink;
        };
        DemoApp.prototype.setUserLink = function (useLink) {
            this._userLink = useLink;
        };
        DemoApp.prototype.checkUser = function (contextCoupon) {
            var _this = this;
            var item = new lt.Ccow.ContextItem("User.Id.logon." + this.getSuffix());
            this._context.getItemValue(item, false, contextCoupon, function (temp) {
                _this._newUser = "";
                //
                // Check to see if we are removing the user
                //
                if (temp.length == 0 && _this._loggedIn) {
                    _this._logOff = true;
                }
                else {
                    //
                    // A new user has been logged in
                    //
                    if (_this._currentUser.toLowerCase() != temp.toLowerCase()) {
                        _this._newUser = temp;
                    }
                }
            }, function (error) {
                _this.showMessage(error);
            });
        };
        DemoApp.prototype.checkPatient = function (contextCoupon, onlyChanges, success) {
            var _this = this;
            var item = new lt.Ccow.ContextItem("Patient.Id.MRN." + this.getSuffix());
            this._context.getItemValue(item, onlyChanges, contextCoupon, function (temp) {
                _this._newPatientId = "";
                for (var i = 0; i < _this._ccowApplication.Patients.length; i++) {
                    if (_this._ccowApplication.Patients[i].Id.toLowerCase() == temp.toLowerCase()) {
                        _this._newPatientId = temp;
                        success(_this._newPatientId);
                        break;
                    }
                }
            }, function (error) {
                _this.showMessage(error);
            });
        };
        DemoApp.prototype.logOffUser = function () {
            if (this._logOff) {
                this.setUserInfo("");
                this._logOff = false;
            }
        };
        DemoApp.prototype.selectNewPatient = function () {
            var patientsTable = document.getElementById(this.UI.table_patients);
            this._updateContext = false;
            try {
                if (this._newPatientId == "") {
                    for (var i = 0; i < patientsTable.rows.length; i++)
                        this.selectTableRow(patientsTable.rows[i], false);
                }
                else {
                    for (var i = 0; i < patientsTable.rows.length; i++)
                        this.selectTableRow(patientsTable.rows[i], false);
                    for (var i = 0; i < patientsTable.rows.length; i++) {
                        var patient = this._ccowApplication.Patients[i];
                        if (patient.Id.toLowerCase() == this._newPatientId.toLowerCase()) {
                            this.selectTableRow(patientsTable.rows[i + 1], true);
                            break;
                        }
                    }
                }
            }
            finally {
                this._updateContext = true;
            }
        };
        DemoApp.prototype.showContext = function () {
            var _this = this;
            this.clearContext();
            this._context.getCurrentContext(function (context) {
                var contextTable = document.getElementById(_this.UI.table_context);
                var rowConter = 0;
                for (var i = 0; i < context.length; i += 2) {
                    var row = contextTable.insertRow(rowConter);
                    row.insertCell(0).innerHTML = context[i];
                    row.insertCell(1).innerHTML = context[i + 1];
                    rowConter++;
                }
                ;
            }, function (error) {
                _this.showMessage(error);
            });
        };
        DemoApp.prototype.clearContext = function () {
            var contextTable = document.getElementById(this.UI.table_context);
            for (var i = contextTable.rows.length - 1; i >= 0; i--)
                contextTable.deleteRow(i);
        };
        DemoApp.prototype.setLinkDisplay = function (linkInfo) {
            var linkDisplay = document.getElementById(this.UI.span_linktype);
            linkDisplay.textContent = linkInfo;
        };
        DemoApp.prototype.InitUI = function () {
            // Bind events to UI elements
            $(document.getElementById(this.UI.menu_logon)).bind("click", $.proxy(this.onLogOnClicked, this));
            $(document.getElementById(this.UI.menu_logoff)).bind("click", $.proxy(this.onLogOffClicked, this));
            $(document.getElementById(this.UI.menu_logoffAll)).bind("click", $.proxy(this.onLogOffAllClicked, this));
            $(document.getElementById(this.UI.menu_suspend)).bind("click", $.proxy(this.onSuspendClicked, this));
            $(document.getElementById(this.UI.menu_resume)).bind("click", $.proxy(this.onResumeClicked, this));
            this.InitDialogs();
        };
        DemoApp.prototype.onLogOn = function () {
            var _this = this;
            if (!this._loggedIn) {
                try {
                    var failedVerify = false;
                    if (!this._context.joined) {
                        this._context.join(this.applicationName, true, function () {
                            _this.setCCowIcon(ContextState.Linked);
                            try {
                                _this._context.secureBindCheck(function (failedVerify) {
                                }, function (error) {
                                    _this.showMessage(error);
                                });
                            }
                            catch (ex) {
                                _this.showMessage(ex);
                            }
                        }, function (error) {
                            _this.showMessage(error);
                        });
                    }
                    this.doApplicationLogin();
                }
                catch (ex) {
                    this.showMessage(ex);
                }
            }
            else {
                this.showMessage("A user is currently logged into the application. This menu option will become available once the current user logs out.");
            }
        };
        DemoApp.prototype.onLogOnClicked = function () {
            var _this = this;
            this.isClientServiceRunning()
                .done(function () {
                _this.onLogOn();
            })
                .fail(function (jqXHR, textStatus, errorThrown) {
                _this.startPlugin()
                    .done(function () {
                    _this.onLogOn();
                });
            });
        };
        DemoApp.prototype.onLogOffClicked = function () {
            var _this = this;
            this._context.leave(function () {
                _this.setUserInfo("");
                _this.clearContext();
                _this._loggedIn = false;
                _this.setLinkDisplay("");
            }, function (error) {
                _this.showMessage(error);
            });
        };
        DemoApp.prototype.onLogOffAllClicked = function () {
            var _this = this;
            if (!this._context.joined) {
                this.showMessage("This application is currently not joined to the context.  The Log-Off All option " +
                    "is not available. If you would like to enable the Log-Off All option close and restart this " +
                    "application with sign on from the CCOW dashboard with the SSO option checked.");
                return;
            }
            try {
                if (!this._appOnlyLogin) {
                    var userSubject = new lt.Ccow.Subject();
                    userSubject.name = "User";
                    var item = new lt.Ccow.ContextItem("User.Id.logon." + this.getSuffix());
                    item.value = "";
                    userSubject.items.add(item);
                    this._context.setSubject(userSubject, function () {
                        _this.setUserInfo("");
                        _this._loggedIn = false;
                        _this.showContext();
                    }, function (error) {
                        _this.showMessage(error);
                    });
                }
                else {
                    this.showMessage("This application is currently only logged into this application.  The Log-Off All option " +
                        "is not available. If you would like to enable the Log-Off All option close and restart this " +
                        "application with sign on from the CCOW dashboard.");
                }
            }
            catch (err) {
                //
                // Check to see if the Context Manager server has terminated.
                //
                if (err.message.indexOf("The RPC server is unavailable") != -1) {
                    this.showMessage("Context Manager Server has terminated.  Application can no longer access the context.  The application will restart and try to rejoin the context.");
                    this.onClose();
                    location.reload(true);
                }
                else {
                    this.showMessage(err);
                }
            }
        };
        DemoApp.prototype.onSuspendClicked = function () {
            var _this = this;
            try {
                if (!this._context.suspended) {
                    this._context.suspend(function () {
                    }, function (error) {
                        _this.showMessage(error);
                    });
                    if (this._context.suspended) {
                        this.setCCowIcon(ContextState.Broken);
                        var patientsTable = document.getElementById(this.UI.table_patients);
                        this.enablePatientTable(false);
                    }
                }
                else {
                    this.showMessage("This application has already suspended it's participation.  Please resume before trying to suspend.");
                }
            }
            catch (ex) {
                this.showMessage(ex);
            }
        };
        DemoApp.prototype.onResumeClicked = function () {
            var _this = this;
            if (this._context.suspended) {
                this._context.resume(true, function () {
                    if (!_this._context.suspended) {
                        _this.setCCowIcon(ContextState.Linked);
                        var patientsTable = document.getElementById(_this.UI.table_patients);
                        _this.enablePatientTable(true);
                        _this.showContext();
                        _this._context.lastCoupon(function (res) {
                            _this.checkPatient(res, false, function (result) {
                                _this._newPatientId = result;
                                _this.selectNewPatient();
                            });
                        }, function (error) {
                            _this.showMessage(error);
                        });
                        if (_this.getUserLink()) {
                            _this._context.getCurrentUser(function (user) {
                                _this.setUserInfo(user);
                            }, function (error) {
                                _this.showMessage(error);
                            });
                        }
                    }
                }, function (error) {
                    _this.showMessage(error);
                });
            }
            else {
                this.showMessage("This application has not suspended it's participation.  Please suspend this application before trying to resume.");
            }
        };
        DemoApp.prototype.InitDialogs = function () {
            // Init loading dialog 
            this._loadingDlg = new CcowWebClientParticipationDemo.LoadingDialog();
            // Init document info dialog
            this._aboutDlg = new CcowWebClientParticipationDemo.AboutDlg();
        };
        DemoApp.prototype.onAbout = function () {
            this._aboutDlg.Show();
        };
        return DemoApp;
    }());
    CcowWebClientParticipationDemo.DemoApp = DemoApp;
})(CcowWebClientParticipationDemo || (CcowWebClientParticipationDemo = {}));
var _app = null;
window.onload = function () {
    var userLink = false;
    var dashboard = false;
    var color = "darkblue";
    var appIndex = 1;
    var serach = window.location.search;
    if (serach != null && serach.length > 0) {
        var parameters = serach.split("&");
        for (var i = 0; i < parameters.length; i++) {
            var str = parameters[i].toLowerCase();
            var index = -1;
            if ((index = str.indexOf("userlink=")) != -1) {
                userLink = str.substring(index + "userlink=".length) == "true";
            }
            else if ((index = str.indexOf("dashboard=")) != -1) {
                dashboard = str.substring(index + "dashboard=".length) == "true";
            }
            else if ((index = str.indexOf("color=")) != -1) {
                color = str.substring(index + "color=".length).toLowerCase();
            }
            else if ((index = str.indexOf("index=")) != -1) {
                appIndex = +str.substring(index + "index=".length);
            }
        }
    }
    _app = new CcowWebClientParticipationDemo.DemoApp(dashboard, userLink, color, appIndex);
    _app.run();
};
window.onbeforeunload = function () {
    if (_app != null)
        _app.onClose();
};
//# sourceMappingURL=CcowWebClientParticipationDemo.js.map