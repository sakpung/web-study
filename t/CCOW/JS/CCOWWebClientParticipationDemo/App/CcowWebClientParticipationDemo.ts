// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************


module CcowWebClientParticipationDemo {
   export enum ContextState {
      Linked,
      Broken,
      Changing
   }

   export enum SurveyResponse {
      Accept,
      Conditional,
      Busy
   }

   export class DemoApp implements IContextClientApp {
      private _plugin: lt.Ccow.ClientParticipantPlugin;

      private _loadingDlg: LoadingDialog;
      private _aboutDlg: AboutDlg;

      private _currentDocumentUrl: string;
      private _tempUrl: string;

      /* Create shortcuts for all ccowWebClientParticipationDemo main page UI elements */
      private UI = {
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

      private _patientLink = "Link Type: Patient";
      private _userPatientLink = "Link Type: User, Patient";

      private _activeScenario: ActiveScenario;
      private _ccowApplication: CCOWApplication;
      private _context: ClientContext;

      public appScenarioIndex: number = 3;
      public applicationName: string = "CCOW Web Client Participation Demo1";
      private _suffix: string = "WebClientDemo1";
      private _clientServerUrl: string = "http://localhost:80/LEADTOOLSContextParticipant/";

      private _loggedIn = false;
      private _newPatientId = "";
      private _newUser = "";
      private _updateContext = true;
      private _logOff = false;
      private _appOnlyLogin = false;
      private _currentUser = "";

      private _dashboard: boolean = false;

      //
      // Determines if the application is started as a user link participant.  If this is true the application
      // syncs with user and patient link.  If false it is only a patient linked application.
      //
      private _userLink: boolean = false;

      constructor(dashborad: boolean, userLink: boolean, clr: string, appIndex: number) {
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

      private showMessage(errMsg): void {
         if (errMsg != null) {
            if (typeof errMsg == "string" || errMsg instanceof String) {
               if (errMsg.length > 0)
                  alert(errMsg);
            } else if (errMsg instanceof Error && typeof errMsg.message != "undefined") {
               if (errMsg.message.length > 0)
                  alert(errMsg);
            } else {
               alert(errMsg);
            }
         }
      }

      public showStartServiceError(): void {
         if (lt.LTHelper.browser == lt.LTBrowser.edge) {
            document.getElementById(this.UI.troubleshootingGuide).style.visibility = "visible";
         }

         $(document.getElementById(this.UI.clientServiceErrorDialog)).modal();
      }

      private isClientServiceRunning(): JQueryPromise<void> {
         var d: JQueryDeferred<void> = $.Deferred<void>();

         // Check if the service is running
         var clientUtils: lt.Ccow.ClientUtils = new lt.Ccow.ClientUtils(new lt.Ccow.CcowService(this._clientServerUrl));
         var pingPromise = clientUtils.ping();

         pingPromise.done((): void => {
            d.resolve();
         });

         pingPromise.fail((): void => {
            d.reject();
         });

         return d.promise();
      }

      private startPlugin(): JQueryPromise<void> {
         var d: JQueryDeferred<void> = $.Deferred<void>();

         var demoApp = this;
         var count = 20;
         this.isClientServiceRunning()
            .done(() => {
               d.resolve();

               return d;
            })
            .fail((jqXHR: JQueryXHR, textStatus: string, errorThrown: string) => {
               // Show loading dialog
               this._loadingDlg.setDescription("Starting Web Client Participant Service");
               this._loadingDlg.show();

               // try to run the service
               try {
                  demoApp._plugin.start(null);
               } catch (e) {
                  // Do nothing
               }

               var interval = setInterval(function () {
                  count = count - 1;
                  // check if the service is ready
                  demoApp.isClientServiceRunning()
                     .done(() => {
                        // If the service is ready, hide the loading dialog and Init demo UI
                        clearInterval(interval);
                        demoApp._loadingDlg.hide();
                        d.resolve();
                     })
                     .fail((jqXHR: JQueryXHR, textStatus: string, errorThrown: string) => {
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
      }

      private closePlugIn() {
         if (this._plugin != null) {
            try {
               this._plugin.stop();
            } catch (e) { }
         }
      }

      public run(): void {
         // Check if the browser supports web sockets
         if ((typeof WebSocket) == "undefined") {
            this.showMessage("WebSocket is not supported by this browser!");
            return;
         }

         this.startPlugin()
            .done(() => {
               this.Init();
            });
      }

      public onClose(): void {
         if (this._context != null) {
            if (this._context.joined) {
               this._context.leave(() => {
               }, (error) => {
                  this.showMessage(error);
               });
            }
         }
      }

      private Init(): void {
         try {
            this._activeScenario = ActiveScenario.load("Scenarios/P1_Default.xml");
            if (this._activeScenario != null && this._activeScenario.Scenario != undefined && this._activeScenario.Scenario.Applications.length > this.appScenarioIndex) {
               this._ccowApplication = this._activeScenario.Scenario.Applications[this.appScenarioIndex];
            }

            this.setCCowIcon(ContextState.Broken);
            ClientContext.create(this.applicationName, this, this._clientServerUrl, (result) => {
               this._context = result;

               this._context.join(this.applicationName, true, () => {
                  var failedVerify = false;

                  this.setCCowIcon(ContextState.Linked);
                  this.showContext();

                  try {
                     if (this._dashboard) {
                        this._context.secureBindCheck((failedVerify) => {
                           this.doDashboard(true, failedVerify);
                        }, (error) => {
                           this.showMessage(error);
                        });
                     }
                     else {
                        this.doApplicationLogin();
                     }
                  }

                  catch (ex) {
                     this.showMessage(ex);
                  }
               }, (error) => {
                  this.showMessage(error);
               });
            }, (error) => {
               this.showMessage("Please make sure that the \"CCOWServerDemo\" is running.\n" + error);
            });
         }
         catch (e) {
            this.showMessage(e);
         }
      }

      private onLogIn(user: string): void {
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
               this._context.lastCoupon((res) => {
                  if (res != 0) {
                     this.checkPatient(res, false, (result) => {
                        this._newPatientId = result;
                        this.selectNewPatient();
                     });
                  }
               }, (error) => {
                  this.showMessage(error);
               });
            }
         } catch (e) {
            this._loadingDlg.hide();
            this.showMessage(e);
         }

         if (this.getUserLink())
            this.setLinkDisplay(this._userPatientLink);
         else
            this.setLinkDisplay(this._patientLink);
      }

      private doDashboard(showInfo: boolean, failedVerify: boolean): void {
         this._loadingDlg.hide();
         if (this.getUserLink()) {
            this._context.isUserContextSet((result) => {
               if (!result) {
                  this.showMessage("This application cannot continue.  The application was launched from the CCOW Dashboard and requires that a user be set in the context.");
                  this.onClose();
                  return;
               }
               else {
                  //
                  // The user context is set, therefore we need to check to see if we can logon this specific user
                  //
                  this._context.getCurrentUser((user) => {
                     if (user != null && user.length > 0) {
                        this.logInApplication(user);
                        this.setLinkDisplay(this._userPatientLink);
                     };
                  }, (error) => {
                     this.showMessage(error);
                  });

               }
            }, (error) => {
               this.showMessage(error);
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
            this._context.lastCoupon((res) => {
               if (res != 0) {
                  this.checkPatient(res, false, (result) => {
                     this._newPatientId = result;
                     this.selectNewPatient();
                  });
               }
            }, (error) => {
               this.showMessage(error);
            });
         }
      }

      private doApplicationLogin(): void {
         var dlgLogin = new LogInDialog(this._ccowApplication);
         dlgLogin.onUserLogin = (user) => { this.onLogIn(user); };
         dlgLogin.show();
      }

      private loggingIn = false;
      private logInApplication(user: string): void {
         if (this.loggingIn)
            return;

         try {
            this.loggingIn = true;
            this._context.getAuthenticationData(user, (authData) => {
               //
               // If we do not have any authentication data then we need to display a dialog and
               // let the user log into this application. Once successfully logged in the user auth
               // data (password) will be added to the authentication repository.
               //
               if (authData == null || authData.length < 1) {
                  this._loadingDlg.hide();
                  var dlgLogin = new LogInDialog(this._ccowApplication);
                  dlgLogin.username = user;
                  dlgLogin.enableUser = false;
                  dlgLogin.firstLogin = true;
                  dlgLogin.onUserLogin = (user) => {
                     this._context.setAuthenticationData(user, dlgLogin.password, () => {
                        this._loggedIn = true;
                        this.setUserInfo(user);
                     }, (error) => {
                        this.showMessage(error);
                     });
                  };
                  dlgLogin.show();
               }
               else {
                  this.setUserInfo(user);
                  this._loggedIn = true;
               }
            }, (error) => {
               this.showMessage(error);
            });
         }
         finally {
            this.loggingIn = false;
         }
      }

      private initializePatients(): void {
         var patientsTable: HTMLTableElement = <HTMLTableElement>document.getElementById(this.UI.table_patients);
         for (var i = patientsTable.rows.length - 1; i >= 1; i--)
            patientsTable.deleteRow(i);

         if (this._ccowApplication != null) {
            for (var i = 0; i < this._ccowApplication.Patients.length; i++) {
               this.addPatient(this._ccowApplication.Patients[i], i + 1);
            }

            this.enablePatientTable(true);
         }
      }

      private addPatient(patient: Patient, index: number): void {
         var patientsTable: HTMLTableElement = <HTMLTableElement>document.getElementById(this.UI.table_patients);
         var row = <HTMLTableRowElement>patientsTable.insertRow(index);
         row.insertCell(0).innerHTML = patient.Id;
         row.insertCell(1).innerHTML = patient.Name;
         row.insertCell(2).innerHTML = patient.BirthDate;
         row.insertCell(3).innerHTML = patient.Sex;
      }

      enablePatientTable(enable: boolean): void {
         var patientsTable: HTMLTableElement = <HTMLTableElement>document.getElementById(this.UI.table_patients);
         var index = -1;
         for (var i = 0; i < patientsTable.rows.length; i++) {
            var row = <HTMLTableRowElement>patientsTable.rows[i];
            row.onclick = enable ? ((ev: MouseEvent) => this.patients_SelectedIndexChanged(<HTMLTableRowElement>ev.currentTarget)) : null;
         }
      }

      private setUserInfo(user: string): void {
         this._currentUser = user;
         var spanUser = <HTMLSpanElement>document.getElementById(this.UI.span_user);
         var imgUser = <HTMLImageElement>document.getElementById(this.UI.img_user);
         spanUser.textContent = user;
         if (user == null || user.length < 1) {
            this._loggedIn = false;
            imgUser.style.visibility = "collapse";
         }
         else {
            imgUser.style.visibility = "visible";
         }
      }

      private selectTableRow(row: Element, select: boolean) {
         (<HTMLTableRowElement>row).bgColor = select ? "gray" : "white";
      }

      private isTableRowSelected(row: Element): boolean {
         return (<HTMLTableRowElement>row).bgColor == "gray";
      }

      private patients_SelectedIndexChanged(row: HTMLTableRowElement): void {
         if (this.isTableRowSelected(row))
            return;

         try {
            var patientsTable: HTMLTableElement = <HTMLTableElement>document.getElementById(this.UI.table_patients);
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

               if (patient != null) item.value = patient.Id;
               patientSubject.items.add(item);
               this._context.setSubject(patientSubject, () => {
                  this.showContext();
               }, (error) => {
                  this.showMessage(error);
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
      }

      private setCCowIcon(state: ContextState): void {
         var image = <HTMLImageElement>document.getElementById(this.UI.img_status);
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
      }

      public log(str: string, ...obj: Object[]): void {
         var textarea = <HTMLTextAreaElement>document.getElementById(this.UI.textarea_log);
         var txt = str.format(obj);
         if (obj.length > 1) {
            for (var i = 1; i < obj.length; i++)
               txt = txt.replace("{{0}}".format(i.toString()), obj[i].toString());
         }
         textarea.textContent += txt;
         textarea.textContent += "\n";
         textarea.scrollTop = textarea.scrollHeight;
      }

      public onContextTerminated(): void {
         this.log("=> Context Terminated");
      }
      public onContextChangesAccepted(coupon: number): void {
         this.log("=> Context Changes Accepted");
         if (this._logOff) {
            this.logOffUser();
         }
         else if (this._newUser != null && this._newUser.length > 0 && this.getUserLink()) {
            this.logInApplication(this._newUser);
         }

         if (!this.loggingIn) {
            this.checkPatient(coupon, true, (result) => {
               this._newPatientId = result;
               this.selectNewPatient();
               this.showContext();
            });
         }
      }
      public onContextChangesCanceled(coupon: number): void {
         this.log("=> Context Changes Canceled");
         this._newPatientId = "";
         this._newUser = "";
      }
      public onContextChangesPending(contextCoupon: number): void {
         this.log("=> Context Changes Pending");
         this._context.isSetting("user", "logon", contextCoupon, (result) => {
            if (result)
               this.checkUser(contextCoupon);
         }, (error) => {
            this.showMessage(error);
         });
         this.checkPatient(contextCoupon, true, (result) => {
            this._newPatientId = result;
         });

      }
      public joinedContext(context: ClientContext): void {
         this.log("=> Successfully Joined Context");
         this.log("     Participant Coupon: " + this._context.participantCoupon.toString());
      }
      public leftContext(context: ClientContext): void {
         this.setCCowIcon(ContextState.Broken);
      }
      public pinged(context: ClientContext): void {
         this.log("=> Received Ping");
      }
      public getSuffix(): string {
         return this._suffix;
      }
      public getUserLink(): boolean {
         return this._userLink;
      }
      public setUserLink(useLink: boolean): void {
         this._userLink = useLink;
      }

      public checkUser(contextCoupon: number): void {
         var item = new lt.Ccow.ContextItem("User.Id.logon." + this.getSuffix());

         this._context.getItemValue(item, false, contextCoupon, (temp) => {
            this._newUser = "";
            //
            // Check to see if we are removing the user
            //
            if (temp.length == 0 && this._loggedIn) {
               this._logOff = true;
            }
            else {
               //
               // A new user has been logged in
               //
               if (this._currentUser.toLowerCase() != temp.toLowerCase()) {
                  this._newUser = temp;
               }
            }
         }, (error) => {
            this.showMessage(error);
         });
      }

      private checkPatient(contextCoupon: number, onlyChanges: boolean, success: { (result): void }): void {
         var item = new lt.Ccow.ContextItem("Patient.Id.MRN." + this.getSuffix());
         this._context.getItemValue(item, onlyChanges, contextCoupon, (temp) => {
            this._newPatientId = "";
            for (var i = 0; i < this._ccowApplication.Patients.length; i++) {
               if (this._ccowApplication.Patients[i].Id.toLowerCase() == temp.toLowerCase()) {
                  this._newPatientId = temp;
                  success(this._newPatientId);
                  break;
               }
            }
         }, (error) => {
            this.showMessage(error);
         });
      }

      private logOffUser(): void {
         if (this._logOff) {
            this.setUserInfo("");
            this._logOff = false;
         }
      }

      private selectNewPatient(): void {
         var patientsTable: HTMLTableElement = <HTMLTableElement>document.getElementById(this.UI.table_patients);
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
      }

      public showContext(): void {
         this.clearContext();
         this._context.getCurrentContext((context) => {
            var contextTable = <HTMLTableElement>document.getElementById(this.UI.table_context);
            var rowConter = 0;
            for (var i = 0; i < context.length; i += 2) {
               var row = <HTMLTableRowElement>contextTable.insertRow(rowConter);
               row.insertCell(0).innerHTML = context[i];
               row.insertCell(1).innerHTML = context[i + 1];
               rowConter++;
            };
         }, (error) => {
            this.showMessage(error);
         });
      }

      public clearContext(): void {
         var contextTable = <HTMLTableElement>document.getElementById(this.UI.table_context);
         for (var i = contextTable.rows.length - 1; i >= 0; i--)
            contextTable.deleteRow(i);
      }

      private setLinkDisplay(linkInfo: string): void {
         var linkDisplay = <HTMLSpanElement>document.getElementById(this.UI.span_linktype);
         linkDisplay.textContent = linkInfo;
      }

      private InitUI(): void {

         // Bind events to UI elements
         $(document.getElementById(this.UI.menu_logon)).bind("click", $.proxy(this.onLogOnClicked, this));
         $(document.getElementById(this.UI.menu_logoff)).bind("click", $.proxy(this.onLogOffClicked, this));
         $(document.getElementById(this.UI.menu_logoffAll)).bind("click", $.proxy(this.onLogOffAllClicked, this));
         $(document.getElementById(this.UI.menu_suspend)).bind("click", $.proxy(this.onSuspendClicked, this));
         $(document.getElementById(this.UI.menu_resume)).bind("click", $.proxy(this.onResumeClicked, this));
         this.InitDialogs();
      }

      private onLogOn(): void {
         if (!this._loggedIn) {
            try {
               var failedVerify = false;

               if (!this._context.joined) {
                  this._context.join(this.applicationName, true, () => {
                     this.setCCowIcon(ContextState.Linked);
                     try {
                        this._context.secureBindCheck((failedVerify) => {
                        }, (error) => {
                           this.showMessage(error);
                        });
                     }
                     catch (ex) {
                        this.showMessage(ex);
                     }
                  }, (error) => {
                     this.showMessage(error);
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
      }
      private onLogOnClicked(): void {
         this.isClientServiceRunning()
            .done(() => {
               this.onLogOn();
            })
            .fail((jqXHR: JQueryXHR, textStatus: string, errorThrown: string) => {
               this.startPlugin()
                  .done(() => {
                     this.onLogOn();
                  });
            });
      }

      private onLogOffClicked(): void {
         this._context.leave(() => {
            this.setUserInfo("");
            this.clearContext();
            this._loggedIn = false;
            this.setLinkDisplay("");
         }, (error) => {
            this.showMessage(error);
         });

      }

      private onLogOffAllClicked(): void {
         if (!this._context.joined) {
            this.showMessage("This application is currently not joined to the context.  The Log-Off All option " +
               "is not available. If you would like to enable the Log-Off All option close and restart this " +
               "application with sign on from the CCOW dashboard with the SSO option checked.");
            return;
         }

         try {
            if (!this._appOnlyLogin) {
               var userSubject: lt.Ccow.Subject = new lt.Ccow.Subject();
               userSubject.name = "User";

               var item: lt.Ccow.ContextItem = new lt.Ccow.ContextItem("User.Id.logon." + this.getSuffix());
               item.value = "";

               userSubject.items.add(item);
               this._context.setSubject(userSubject, () => {
                  this.setUserInfo("");
                  this._loggedIn = false;
                  this.showContext();
               }, (error) => {
                  this.showMessage(error);
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
      }

      private onSuspendClicked(): void {
         try {
            if (!this._context.suspended) {
               this._context.suspend(() => {

               }, (error) => {
                  this.showMessage(error);
               });
               if (this._context.suspended) {
                  this.setCCowIcon(ContextState.Broken);
                  var patientsTable: HTMLTableElement = <HTMLTableElement>document.getElementById(this.UI.table_patients);
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
      }

      private onResumeClicked(): void {
         if (this._context.suspended) {
            this._context.resume(true, () => {
               if (!this._context.suspended) {
                  this.setCCowIcon(ContextState.Linked);
                  var patientsTable: HTMLTableElement = <HTMLTableElement>document.getElementById(this.UI.table_patients);
                  this.enablePatientTable(true);
                  this.showContext();
                  this._context.lastCoupon((res) => {
                     this.checkPatient(res, false, (result) => {
                        this._newPatientId = result;
                        this.selectNewPatient();
                     });
                  }, (error) => {
                     this.showMessage(error);
                  });
                  if (this.getUserLink()) {
                     this._context.getCurrentUser((user) => {
                        this.setUserInfo(user);
                     }, (error) => {
                        this.showMessage(error);
                     });
                  }
               }
            }, (error) => {
               this.showMessage(error);
            });
         }
         else {
            this.showMessage("This application has not suspended it's participation.  Please suspend this application before trying to resume.");
         }
      }

      private InitDialogs(): void {
         // Init loading dialog 
         this._loadingDlg = new LoadingDialog();

         // Init document info dialog
         this._aboutDlg = new AboutDlg();
      }

      private onAbout() {
         this._aboutDlg.Show();
      }
   }

}

var _app: CcowWebClientParticipationDemo.DemoApp = null;
window.onload = () => {
   var userLink = false;
   var dashboard = false;
   var color = "darkblue";
   var appIndex = 1;
   var serach: string = window.location.search;
   if (serach != null && serach.length > 0) {
      var parameters: string[] = serach.split("&");
      for (var i = 0; i < parameters.length; i++) {
         var str: string = parameters[i].toLowerCase();
         var index: number = -1;
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