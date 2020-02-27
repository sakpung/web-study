// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************

module CcowWebClientParticipationDemo {
   export class ClientContext {
      private _ccowClientContext: lt.Ccow.ClientContext;
      private _ccowClientUtils: lt.Ccow.ClientUtils;
      private _participantCoupon: number = -1000;
      private _access: string[] = [];
      private _app: IContextClientApp = null;
      private _passcode: string = "E9CA399D-F0EF-4DAE-BEB3-8737862513CE";
      private _appName = "";
      private _publicKey = "";
      private _keySigniture = "";
      private _clientServerUrl;
      private _clientUrl;

      private _ccowService: lt.Ccow.CcowService;

      private _contextManager: lt.Ccow.ContextManager;

      get participantCoupon(): number {
         return this._participantCoupon;
      }
      set participantCoupon(value: number) {
         this._participantCoupon;
      }

      get passcode(): string {
         return this._passcode;
      }
      set passcode(value: string) {
         this._passcode;
      }

      private showMessage(errMsg): void {
         if (errMsg.message.length > 0)
            alert(errMsg);
      }

      private publicKey(success: { (result): void }, fail: { (error): void }): void {
         if (this._publicKey.length < 1) {
            var getEncodedPublicKeyPromise = this._ccowClientUtils.getEncodedPublicKey(this._appName);

            getEncodedPublicKeyPromise.done((result): void => {
               success(result);
            });

            getEncodedPublicKeyPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
               fail(errorThrown);
            });
         }
      }

      get joined(): boolean {
         return this._participantCoupon != -1000;
      }

      private _suspended: boolean = false;
      get suspended(): boolean {
         return this._suspended;
      }

      public lastCoupon(success: { (result): void }, fail: { (error): void }): void {
         if (this._contextManager == null)
            success(0);

         var getMostRecentContextCouponPromise = this._contextManager.getMostRecentContextCoupon();

         getMostRecentContextCouponPromise.done((result): void => {
            success(result);
         });

         getMostRecentContextCouponPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      private onTerminated() {
         this._app.onContextTerminated();
      }

      private onChangesAccepted(coupon: number) {
         this._app.onContextChangesAccepted(coupon);
      }

      private onChangesCanceled(coupon: number) {
         this._app.onContextChangesCanceled(coupon);
      }

      private onChangesPending(contextCoupon: number): void {
         this._app.onContextChangesPending(contextCoupon);
      }

      public static create(applicationName: string, app: IContextClientApp, clientServerUrl: string, success: { (clientContext): void }, fail: { (error): void }): void {
         var ret = new ClientContext();

         ret._clientServerUrl = clientServerUrl;
         var contextManagementRegistry: lt.Ccow.ContextManagementRegistry = new lt.Ccow.ContextManagementRegistry(new lt.Ccow.CcowContextManagmentService());

         var locatePromise = contextManagementRegistry.locate("CCOW.ContextManager", "1.5", null, ret._clientServerUrl);
         locatePromise.done((result): void => {
            var registryData: lt.Ccow.LocateData = result;
            ret._ccowClientUtils = new lt.Ccow.ClientUtils(new lt.Ccow.CcowService(ret._clientServerUrl));

            ret._ccowService = new lt.Ccow.CcowService(registryData.componentUrl, registryData.componentParameters);

            ret._contextManager = new lt.Ccow.ContextManager(ret._ccowService);

            ret._app = app;
            ret._appName = applicationName;

            ret._clientUrl = "{0}id={1}/".format(ret._clientServerUrl, ret._appName);

            success(ret);
         });

         locatePromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      public join(applicationName: string, survey: boolean, success: { (): void }, fail: { (error): void }) {
         this._ccowClientContext = new lt.Ccow.ClientContext(new lt.Ccow.CcowService(this._clientServerUrl), this._appName);
         this._ccowClientContext.contextChangesPending = (sender, e) => this.onChangesPending(e.contextCoupon);
         this._ccowClientContext.contextChangesCanceled = (sender, e) => this.onChangesCanceled(e.contextCoupon);
         this._ccowClientContext.contextChangesAccepted = (sender, e) => this.onChangesAccepted(e.contextCoupon);
         this._ccowClientContext.commonContextTerminated = (sender, e) => this.onTerminated();
         this._ccowClientContext.error = (sender, e) => this.showMessage(e.error);

         var joinCommonContextPromise = this._contextManager.joinCommonContext(applicationName, this._clientUrl, survey, true);

         joinCommonContextPromise.done((result): void => {
            this._participantCoupon = result;
            this._app.joinedContext(this);
            success();
         });

         joinCommonContextPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      public leave(success: { (): void }, fail: { (error): void }) {
         if (this._participantCoupon != -1000) {
            var leaveCommonContextPromise = this._contextManager.leaveCommonContext(this._participantCoupon);

            leaveCommonContextPromise.done((result): void => {
               this._participantCoupon = -1000;
               this._app.leftContext(this);
               success();
            });

            leaveCommonContextPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
               fail(errorThrown);
            });
         }

         this._ccowClientContext.dispose();
      }

      public suspend(success: { (): void }, fail: { (error): void }) {
         this._app.log("=> SuspendParticipation({0})", this._participantCoupon);
         var suspendParticipationPromise = this._contextManager.suspendParticipation(this._participantCoupon);

         suspendParticipationPromise.done((result): void => {
            this._suspended = true;
            success();
         });

         suspendParticipationPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      public resume(wait: boolean, success: { (): void }, fail: { (error): void }) {
         this._app.log("=> ResumeParticipation({0},{1})", this._participantCoupon, wait);
         var resumeParticipationPromise = this._contextManager.resumeParticipation(this._participantCoupon, wait);

         resumeParticipationPromise.done((result): void => {
            this._suspended = false;
            success();
         });

         resumeParticipationPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      private isSecurityAny(s: lt.Ccow.Subject): boolean {
         if (this._access.length == 0)
            return false;

         var index = this._access.indexOf(s.name);

         if (index != -1) {
            return this._access[index + 1].toLowerCase() == "any";
         }

         return false;
      }

      public setSecure(s: lt.Ccow.Subject, success: { (): void }, fail: { (error): void }) {
         try {
            var secure: lt.Ccow.SecureContextData = new lt.Ccow.SecureContextData(this._ccowService);
            var v = [];
            var names = s.toItemNameArray();
            var values = s.toItemValueArray();
            var decision = "accept", appSignature = "";
            var transaction;
            var disconnect = false;

            this._app.log("=> StartContextChanges({0}) (Secure)", this._participantCoupon);
            var startContextChangesPromise = this._contextManager.startContextChanges(this._participantCoupon);
            startContextChangesPromise.done((result): void => {
               transaction = result;
               this._app.log("     Received transaction coupon: {0}", transaction);
               for (var i = 0; i < names.length; i++) {
                  v.push(values[i].toString());
               }

               appSignature = this._participantCoupon.toString() + names.join("") +
               v.join("") + transaction.toString();
               this.createSignature(appSignature, (result) => {
                  appSignature = result;
                  this._app.log("=> SetItemValues([{0}],[{1}],{2},{3},{4})", this._participantCoupon, names.join(","),
                     values.join(","), transaction, appSignature);

                  var setItemValuesPromise = secure.setItemValues(this._participantCoupon, names, values, transaction, appSignature);

                  setItemValuesPromise.done((result): void => {
                     this._app.log("=> EndContextChanges({0},ref noContinue) (Secure)", transaction);

                     var endContextChangesPromise = this._contextManager.endContextChanges(transaction);

                     endContextChangesPromise.done((result): void => {
                        var endContextChangesData = result;
                        this._app.log("=> PublishChangesDecision({0},{1})", transaction, decision);
                        var publishChangesDecisionPromise = this._contextManager.publishChangesDecision(transaction, decision);

                        publishChangesDecisionPromise.done((result): void => {
                           var listeners = result;
                           if (decision.toLowerCase() == "accept") {
                              for (var i = 0; i < listeners.length; i++) {
                                 new lt.Ccow.CcowService(listeners[i]).send("contextChangeCoupon={0}".format(transaction));
                              }
                           }
                           if (disconnect) {
                              this.leave(() => {
                                 success();
                              }, (error) => {
                                 fail(error);
                              });
                           }
                           else
                              success();
                        });

                        publishChangesDecisionPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                           fail(errorThrown);
                        });
                     });
                     endContextChangesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                        fail(errorThrown);
                     });
                  });
                  setItemValuesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                     fail(errorThrown);
                  });
               }, (error) => {
                  fail(error);
               });
            });
            startContextChangesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
               fail(errorThrown);
            });
         }
         catch (e) {
            this.showMessage(e);
         }
      }

      public convert(o: Object): string {
         return o != null ? o.toString() : "";
      }

      public setSubject(subject: lt.Ccow.Subject, success: { (): void }, fail: { (error): void }) {
         if (!this.isSecurityAny(subject)) {
            this.setSecure(subject, () => {
               success();
               return;
            }, (error) => {
               this.showMessage(error);
            });
         }

         try {
            var data: lt.Ccow.ContextData = new lt.Ccow.ContextData(this._ccowService);
            var endData;
            var decision = "accept";
            var disconnect = false;
            var transaction;

            this._app.log("=> StartContextChanges({0})", this._participantCoupon);
            var startContextChangesPromise = this._contextManager.startContextChanges(this._participantCoupon);

            startContextChangesPromise.done((result): void => {
               transaction = result;
               this._app.log("     Received transaction coupon: {0}", transaction);
               this._app.log("=> SetItemValues([{0}],[{1}],{2},{3})", this._participantCoupon, subject.toItemNameArray().join(","),
                  subject.toItemValueArray().join(","), transaction);


               var setItemValuesPromise = data.setItemValues(this._participantCoupon, subject.toItemNameArray(), subject.toItemValueArray(), transaction);

               setItemValuesPromise.done((result): void => {
                  this._app.log("=> EndContextChanges({0},ref noContinue)", transaction);
                  var endContextChangesPromise = this._contextManager.endContextChanges(transaction);

                  endContextChangesPromise.done((result): void => {
                     endData = result;
                     this._app.log("=> PublishChangesDecision({0},{1})", transaction, decision);
                     var listeners;
                     var publishChangesDecisionPromise = this._contextManager.publishChangesDecision(transaction, decision);

                     publishChangesDecisionPromise.done((result): void => {
                        listeners = result;
                        if (decision.toLowerCase() == "accept") {
                           for (var i = 0; i < listeners.length; i++) {
                              new lt.Ccow.CcowService(listeners[i]).send("contextChangeCoupon={0}".format(transaction));
                           }
                        }
                        if (disconnect) {
                           this.leave(() => {
                              success();
                           }, (error) => {
                              fail(error);
                           });
                        }
                        else
                           success();
                     });

                     publishChangesDecisionPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                        fail(errorThrown);
                     });

                  });
                  endContextChangesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                     fail(errorThrown);
                  });

               });

               setItemValuesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                  fail(errorThrown);
               });

            });
            startContextChangesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
               fail(errorThrown);
            });
         }
         catch (e) {
            throw e;
         }
      }

      public isUserContextSet(success: { (data): void }, fail: { (error): void }): void {
         var getMostRecentContextCouponPromise = this._contextManager.getMostRecentContextCoupon();

         getMostRecentContextCouponPromise.done((result): void => {
            var mostRecentCoupon = result;
            var res: boolean = false;
            if (mostRecentCoupon != 0) {
               var item = new lt.Ccow.ContextItem("User.id.logon." + this._app.getSuffix());
               this.getItemValue(item, false, mostRecentCoupon, (user) => {
                  res = !(user == null || user.length < 1);
                  success(res);
               }, (error) => {
                  this.showMessage(error);
               });
            }
            else
               success(res);
         });

         getMostRecentContextCouponPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      public isUserLoggedIn(success: { (): void }, fail: { (error): void }): boolean {
         var data: lt.Ccow.ContextData = new lt.Ccow.ContextData(this._ccowService);
         var currentUser = false;
         var contextData = [];
         contextData.push("User.Id.Logon");

         var getItemValuesPromise = data.getItemValues(contextData, false, -100);

         getItemValuesPromise.done((result): void => {
            contextData = result;
            success();
         });

         getItemValuesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });

         return currentUser;
      }


      public getAuthenticationData(user: string, success: { (data): void }, fail: { (error): void }): void {
         var data = "";
         var authenticationRepository: lt.Ccow.AuthenticationRepository = new lt.Ccow.AuthenticationRepository(this._ccowService);
         var coupon;

         var connectPromise = authenticationRepository.connect(this._appName);

         connectPromise.done((result): void => {
            coupon = result;

            if (coupon != 0) {
               try {
                  this.secureBind(coupon, () => {
                     var signature = "";
                     signature = coupon.toString() + user;
                     this.createSignature(signature, (result) => {
                        signature = result;
                        var getAuthenticationDataPromise = authenticationRepository.getAuthenticationData(coupon, user, "", signature);

                        getAuthenticationDataPromise.done((result): void => {
                           data = result.repositorySignature;
                           success(data);
                        });

                        getAuthenticationDataPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                           fail(errorThrown);
                        });
                     }, (error) => {
                        fail(error);
                     });
                  }, (error) => {
                     this.showMessage(error);
                  });
               }
               catch (e) {
                  if (e.message.indexOf("LogonNotFound") == -1)
                     throw e;
               }
               finally {
                  authenticationRepository.disconnect(coupon);
               }
            }
         });

         connectPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      public setAuthenticationData(user: string, password: string, success: { (): void }, fail: { (error): void }): void {
         var authenticationRepository: lt.Ccow.AuthenticationRepository = new lt.Ccow.AuthenticationRepository(this._ccowService);
         var coupon;

         var connectPromise = authenticationRepository.connect(this._appName);

         connectPromise.done((result): void => {
            coupon = result;
            if (coupon != 0) {
               try {
                  this.secureBind(coupon, () => {
                     var signature = "";
                     signature = coupon.toString() + user + password;
                     this.createSignature(signature, (result) => {
                        signature = result;
                        var setAuthenticationDataPromise = authenticationRepository.setAuthenticationData(coupon, user, "", password, signature);

                        setAuthenticationDataPromise.done((result): void => {
                           success();
                        });

                        setAuthenticationDataPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                           fail(errorThrown);
                        });
                     }, (error) => {
                        fail(error);
                     });
                  }, (error) => {
                     this.showMessage(error);
                  });
               }
               catch (e) {
                  if (e.message.indexOf("LogonNotFound") == -1)
                     throw e;
               }
               finally {
                  authenticationRepository.disconnect(coupon);
               }
            }
         });

         connectPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      private secureBind(coupon: number, success: { (): void }, fail: { (error): void }): void {
         var securingBinding: lt.Ccow.SecureBinding = new lt.Ccow.SecureBinding(this._ccowService);
         this._app.log("=> InitializeBinding({0},{1},{2}) (Authentication Repository)", coupon, lt.Ccow.Constants.webPassCodeNames, lt.Ccow.Constants.webPassCodeValues);

         var initializeBindingPromise = securingBinding.initializeBinding(coupon, lt.Ccow.Constants.webPassCodeNames, lt.Ccow.Constants.webPassCodeValues);

         initializeBindingPromise.done((result): void => {
            var initializeBindingData = result;
            this._app.log("=> Verify mac. Returned Public Key: {0}", initializeBindingData.binderPublicKey);

            var getEncodedHashKeyPromise = this._ccowClientUtils.getEncodedHashKey(initializeBindingData.binderPublicKey + this.passcode);

            getEncodedHashKeyPromise.done((result): void => {
               var hash = result;
               if (initializeBindingData.mac.toLowerCase() != hash.toLowerCase()) {
                  this._app.log("     Failed to verify authentication repository.");
                  return;
               }

               //
               // Create participant hash and finalize binding
               //

               var getEncodedHashKeyInPromise = this._ccowClientUtils.getEncodedHashKey(this.publicKey + this.passcode);

               getEncodedHashKeyInPromise.done((result): void => {
                  hash = result;
                  this._app.log("=> FinalizeBinding({0},{1},{2}) (Authentication Repository)", coupon, this.publicKey, hash.toLowerCase());
                  this.publicKey((res) => {
                     this._publicKey = res;
                     securingBinding.finalizeBinding(coupon, this._publicKey, hash.toLowerCase());
                     success();
                  }, (error) => {
                     fail(error);
                  });
               });
               getEncodedHashKeyInPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                  fail(errorThrown);
               });
            });
            getEncodedHashKeyPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
               fail(errorThrown);
            });
         });

         initializeBindingPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      public secureBindCheck(success: { (failedVerify): void }, fail: { (error): void }): void {
         var securingBinding: lt.Ccow.SecureBinding = new lt.Ccow.SecureBinding(this._ccowService);
         var hash = "";


         this._app.log("=> InitializeBinding({0},{1},{2}) (Context Manager)", this._participantCoupon, lt.Ccow.Constants.webPassCodeNames, lt.Ccow.Constants.webPassCodeValues);

         var initializeBindingPromise = securingBinding.initializeBinding(this._participantCoupon, lt.Ccow.Constants.webPassCodeNames, lt.Ccow.Constants.webPassCodeValues);

         initializeBindingPromise.done((result): void => {
            var data = result;
            this._app.log("=> Verify mac. Returned Public Key: {0}", data.binderPublicKey);

            var getEncodedHashKeyPromise = this._ccowClientUtils.getEncodedHashKey(data.binderPublicKey + this.passcode);

            getEncodedHashKeyPromise.done((result): void => {
               hash = result;
               var failedVerify = false;
               if (data.mac.toLowerCase() != hash.toLowerCase()) {
                  this._app.log("     Failed to verify context manager");
                  this._app.setUserLink(false);
                  failedVerify = true;
                  success(failedVerify);
                  return;
               }

               //
               // Create participant hash and finalize binding
               //

               var getEncodedHashKeyInPromise = this._ccowClientUtils.getEncodedHashKey(this.publicKey + this.passcode);

               getEncodedHashKeyInPromise.done((result): void => {
                  hash = result;
                  this._app.log("=> FinalizeBinding({0},{1},{2}) (Authentication Repository)", this._participantCoupon, this.publicKey, hash.toLowerCase());
                  this.publicKey((res) => {
                     this._publicKey = res;

                     var finalizeBindingPromise = securingBinding.finalizeBinding(this._participantCoupon, this._publicKey, hash.toLowerCase());

                     finalizeBindingPromise.done((result): void => {
                        var access = result;
                        if (access != null) {
                           for (var i = 0; i < access.length; i += 2) {
                              this._app.log("     {0}\t{1}", access[i], access[i + 1]);
                              this._access.push(access[i]);
                              this._access.push(access[i + 1]);
                           }
                        }
                        success(failedVerify);
                     });
                     finalizeBindingPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                        fail(errorThrown);
                     });
                  }, (error) => {
                     fail(error);
                  });
               });
               getEncodedHashKeyInPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                  fail(errorThrown);
               });
            });
            getEncodedHashKeyPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
               fail(errorThrown);
            });
         });
         initializeBindingPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      public isSetting(subject: string, name: string, coupon: number, success: { (result): void }, fail: { (error): void }): void {
         var contextData: lt.Ccow.ContextData = new lt.Ccow.ContextData(this._ccowService);
         var data = [];
         var getItemNamesPromise = contextData.getItemNames(coupon);

         getItemNamesPromise.done((result): void => {
            data = result;
            if (data != null && data.length > 0) {
               for (var i = 0; i < data.length; i++) {
                  var item = new lt.Ccow.ContextItem(data[i]);

                  if (item.subject.toLowerCase() == subject.toLowerCase() && item.name.toLowerCase() == name.toLowerCase()) {
                     success(true);
                  }
               }
            }
            success(false);
         });

         getItemNamesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      public getCurrentUser(success: { (user): void }, fail: { (error): void }): void {
         var user = "";
         var contextData: lt.Ccow.ContextData = new lt.Ccow.ContextData(this._ccowService);
         var getMostRecentContextCouponPromise = this._contextManager.getMostRecentContextCoupon();

         getMostRecentContextCouponPromise.done((result): void => {
            var mostRecentCoupon = result;
            var data = [];

            var getItemNamesPromise = contextData.getItemNames(mostRecentCoupon);

            getItemNamesPromise.done((result): void => {
               data = result;
               if (data != null && data.length > 0) {

                  for (var i = 0; i < data.length; i++) {
                     var item = new lt.Ccow.ContextItem(data[i]);

                     if (item.suffix.toLowerCase() == this._app.getSuffix().toLowerCase() && item.subject.toLowerCase() == "user" &&
                        item.name.toLowerCase() == "logon" && item.role.toLowerCase() == "id") {
                        data = [];
                        data.push(item.toString());
                        break;
                     }
                  }

                  if (data != null) {
                     var getItemValuesPromise = contextData.getItemValues(data, false, mostRecentCoupon);

                     getItemValuesPromise.done((result): void => {
                        data = result;
                        if (data != null) {
                           if (data.length == 2)
                              user = data[1].toString();
                        }
                        success(user);

                     });

                     getItemValuesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                        fail(errorThrown);
                     });
                  }
               }
            });

            getItemNamesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
               fail(errorThrown);
            });
         });

         getMostRecentContextCouponPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      public getItemValue(item: lt.Ccow.ContextItem, onlyChanges: boolean, coupon: number, success: { (context): void }, fail: { (error): void }): void {
         var contextData: lt.Ccow.ContextData = new lt.Ccow.ContextData(this._ccowService);
         var s = new lt.Ccow.Subject();
         s.name = item.subject;
         var data = null;

         s.items.add(item);

         var getItemValuesPromise = contextData.getItemValues(s.toItemNameArray(), onlyChanges, coupon);

         getItemValuesPromise.done((result): void => {
            data = result;
            var res: string = "";
            if (data != null) {
               if (data.length >= 2)
                  res = data[1].toString();
            }
            success(res);
         });
         getItemValuesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      public setFilter(filters: string[]): void {
         var contextFilter: lt.Ccow.ContextFilter = new lt.Ccow.ContextFilter(this._ccowService);
         contextFilter.setSubjectsOfInterest(this._participantCoupon, filters);
      }

      public getCurrentContext(success: { (context): void }, fail: { (error): void }): void {
         var data: lt.Ccow.ContextData = new lt.Ccow.ContextData(this._ccowService);
         var context = [];

         var getMostRecentContextCouponPromise = this._contextManager.getMostRecentContextCoupon();

         getMostRecentContextCouponPromise.done((result): void => {
            var mostRecentCoupon = result;
            if (mostRecentCoupon != 0) {
               this._app.log("=> GetItemNames({0})", mostRecentCoupon);
               var contextData = [];

               var getItemNamesPromise = data.getItemNames(mostRecentCoupon);

               getItemNamesPromise.done((result): void => {
                  contextData = result;
                  if (contextData != null && contextData.length > 0) {
                     this._app.log("     Available Item Names");
                     for (var i = 0; i < contextData.length; i++) {
                        this._app.log("          " + contextData[i]);
                     }

                     this._app.log("=> GetItemValues([{0}],false,{1})", contextData.join(","), mostRecentCoupon);

                     var getItemValuesPromise = data.getItemValues(contextData, false, mostRecentCoupon);

                     getItemValuesPromise.done((result): void => {
                        contextData = result;
                        for (var i = 0; i < contextData.length; i += 2) {
                           context.push(contextData[i], contextData[i + 1]);
                           this._app.log("          {0} ({1})", contextData[i], contextData[i + 1]);
                        }
                        success(context);
                     });

                     getItemValuesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                        fail(errorThrown);
                     });
                  }
               });
               getItemNamesPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
                  fail(errorThrown);
               });
            }
         });
         getMostRecentContextCouponPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });
      }

      private createSignature(messageDigest: string, success: { (result): void }, fail: { (error): void }): void {
         var getEncodedSignKeyPromise = this._ccowClientUtils.getEncodedSignKey(this._appName, messageDigest);

         getEncodedSignKeyPromise.done((result): void => {
            success(result);
         });

         getEncodedSignKeyPromise.fail((jqXHR: JQueryXHR, statusText: string, errorThrown: string): void => {
            fail(errorThrown);
         });

      }

      public commonContextTerminated(): void {
         this.onTerminated();
      }

      public contextChangesAccepted(contextCoupon: number): void {
         this.onChangesAccepted(contextCoupon);
      }


      public contextChangesCanceled(contextCoupon: number): void {
         this.onChangesCanceled(contextCoupon);
      }

      public contextChangesPending(contextCoupon: number): void {
         return this.onChangesPending(contextCoupon);
      }

      public ping(): void {
         this._app.pinged(this);
      }
   }
}