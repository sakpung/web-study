// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
var CcowWebClientParticipationDemo;
(function (CcowWebClientParticipationDemo) {
    var ClientContext = /** @class */ (function () {
        function ClientContext() {
            this._participantCoupon = -1000;
            this._access = [];
            this._app = null;
            this._passcode = "E9CA399D-F0EF-4DAE-BEB3-8737862513CE";
            this._appName = "";
            this._publicKey = "";
            this._keySigniture = "";
            this._suspended = false;
        }
        Object.defineProperty(ClientContext.prototype, "participantCoupon", {
            get: function () {
                return this._participantCoupon;
            },
            set: function (value) {
                this._participantCoupon;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(ClientContext.prototype, "passcode", {
            get: function () {
                return this._passcode;
            },
            set: function (value) {
                this._passcode;
            },
            enumerable: true,
            configurable: true
        });
        ClientContext.prototype.showMessage = function (errMsg) {
            if (errMsg.message.length > 0)
                alert(errMsg);
        };
        ClientContext.prototype.publicKey = function (success, fail) {
            if (this._publicKey.length < 1) {
                var getEncodedPublicKeyPromise = this._ccowClientUtils.getEncodedPublicKey(this._appName);
                getEncodedPublicKeyPromise.done(function (result) {
                    success(result);
                });
                getEncodedPublicKeyPromise.fail(function (jqXHR, statusText, errorThrown) {
                    fail(errorThrown);
                });
            }
        };
        Object.defineProperty(ClientContext.prototype, "joined", {
            get: function () {
                return this._participantCoupon != -1000;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(ClientContext.prototype, "suspended", {
            get: function () {
                return this._suspended;
            },
            enumerable: true,
            configurable: true
        });
        ClientContext.prototype.lastCoupon = function (success, fail) {
            if (this._contextManager == null)
                success(0);
            var getMostRecentContextCouponPromise = this._contextManager.getMostRecentContextCoupon();
            getMostRecentContextCouponPromise.done(function (result) {
                success(result);
            });
            getMostRecentContextCouponPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.onTerminated = function () {
            this._app.onContextTerminated();
        };
        ClientContext.prototype.onChangesAccepted = function (coupon) {
            this._app.onContextChangesAccepted(coupon);
        };
        ClientContext.prototype.onChangesCanceled = function (coupon) {
            this._app.onContextChangesCanceled(coupon);
        };
        ClientContext.prototype.onChangesPending = function (contextCoupon) {
            this._app.onContextChangesPending(contextCoupon);
        };
        ClientContext.create = function (applicationName, app, clientServerUrl, success, fail) {
            var ret = new ClientContext();
            ret._clientServerUrl = clientServerUrl;
            var contextManagementRegistry = new lt.Ccow.ContextManagementRegistry(new lt.Ccow.CcowContextManagmentService());
            var locatePromise = contextManagementRegistry.locate("CCOW.ContextManager", "1.5", null, ret._clientServerUrl);
            locatePromise.done(function (result) {
                var registryData = result;
                ret._ccowClientUtils = new lt.Ccow.ClientUtils(new lt.Ccow.CcowService(ret._clientServerUrl));
                ret._ccowService = new lt.Ccow.CcowService(registryData.componentUrl, registryData.componentParameters);
                ret._contextManager = new lt.Ccow.ContextManager(ret._ccowService);
                ret._app = app;
                ret._appName = applicationName;
                ret._clientUrl = "{0}id={1}/".format(ret._clientServerUrl, ret._appName);
                success(ret);
            });
            locatePromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.join = function (applicationName, survey, success, fail) {
            var _this = this;
            this._ccowClientContext = new lt.Ccow.ClientContext(new lt.Ccow.CcowService(this._clientServerUrl), this._appName);
            this._ccowClientContext.contextChangesPending = function (sender, e) { return _this.onChangesPending(e.contextCoupon); };
            this._ccowClientContext.contextChangesCanceled = function (sender, e) { return _this.onChangesCanceled(e.contextCoupon); };
            this._ccowClientContext.contextChangesAccepted = function (sender, e) { return _this.onChangesAccepted(e.contextCoupon); };
            this._ccowClientContext.commonContextTerminated = function (sender, e) { return _this.onTerminated(); };
            this._ccowClientContext.error = function (sender, e) { return _this.showMessage(e.error); };
            var joinCommonContextPromise = this._contextManager.joinCommonContext(applicationName, this._clientUrl, survey, true);
            joinCommonContextPromise.done(function (result) {
                _this._participantCoupon = result;
                _this._app.joinedContext(_this);
                success();
            });
            joinCommonContextPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.leave = function (success, fail) {
            var _this = this;
            if (this._participantCoupon != -1000) {
                var leaveCommonContextPromise = this._contextManager.leaveCommonContext(this._participantCoupon);
                leaveCommonContextPromise.done(function (result) {
                    _this._participantCoupon = -1000;
                    _this._app.leftContext(_this);
                    success();
                });
                leaveCommonContextPromise.fail(function (jqXHR, statusText, errorThrown) {
                    fail(errorThrown);
                });
            }
            this._ccowClientContext.dispose();
        };
        ClientContext.prototype.suspend = function (success, fail) {
            var _this = this;
            this._app.log("=> SuspendParticipation({0})", this._participantCoupon);
            var suspendParticipationPromise = this._contextManager.suspendParticipation(this._participantCoupon);
            suspendParticipationPromise.done(function (result) {
                _this._suspended = true;
                success();
            });
            suspendParticipationPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.resume = function (wait, success, fail) {
            var _this = this;
            this._app.log("=> ResumeParticipation({0},{1})", this._participantCoupon, wait);
            var resumeParticipationPromise = this._contextManager.resumeParticipation(this._participantCoupon, wait);
            resumeParticipationPromise.done(function (result) {
                _this._suspended = false;
                success();
            });
            resumeParticipationPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.isSecurityAny = function (s) {
            if (this._access.length == 0)
                return false;
            var index = this._access.indexOf(s.name);
            if (index != -1) {
                return this._access[index + 1].toLowerCase() == "any";
            }
            return false;
        };
        ClientContext.prototype.setSecure = function (s, success, fail) {
            var _this = this;
            try {
                var secure = new lt.Ccow.SecureContextData(this._ccowService);
                var v = [];
                var names = s.toItemNameArray();
                var values = s.toItemValueArray();
                var decision = "accept", appSignature = "";
                var transaction;
                var disconnect = false;
                this._app.log("=> StartContextChanges({0}) (Secure)", this._participantCoupon);
                var startContextChangesPromise = this._contextManager.startContextChanges(this._participantCoupon);
                startContextChangesPromise.done(function (result) {
                    transaction = result;
                    _this._app.log("     Received transaction coupon: {0}", transaction);
                    for (var i = 0; i < names.length; i++) {
                        v.push(values[i].toString());
                    }
                    appSignature = _this._participantCoupon.toString() + names.join("") +
                        v.join("") + transaction.toString();
                    _this.createSignature(appSignature, function (result) {
                        appSignature = result;
                        _this._app.log("=> SetItemValues([{0}],[{1}],{2},{3},{4})", _this._participantCoupon, names.join(","), values.join(","), transaction, appSignature);
                        var setItemValuesPromise = secure.setItemValues(_this._participantCoupon, names, values, transaction, appSignature);
                        setItemValuesPromise.done(function (result) {
                            _this._app.log("=> EndContextChanges({0},ref noContinue) (Secure)", transaction);
                            var endContextChangesPromise = _this._contextManager.endContextChanges(transaction);
                            endContextChangesPromise.done(function (result) {
                                var endContextChangesData = result;
                                _this._app.log("=> PublishChangesDecision({0},{1})", transaction, decision);
                                var publishChangesDecisionPromise = _this._contextManager.publishChangesDecision(transaction, decision);
                                publishChangesDecisionPromise.done(function (result) {
                                    var listeners = result;
                                    if (decision.toLowerCase() == "accept") {
                                        for (var i = 0; i < listeners.length; i++) {
                                            new lt.Ccow.CcowService(listeners[i]).send("contextChangeCoupon={0}".format(transaction));
                                        }
                                    }
                                    if (disconnect) {
                                        _this.leave(function () {
                                            success();
                                        }, function (error) {
                                            fail(error);
                                        });
                                    }
                                    else
                                        success();
                                });
                                publishChangesDecisionPromise.fail(function (jqXHR, statusText, errorThrown) {
                                    fail(errorThrown);
                                });
                            });
                            endContextChangesPromise.fail(function (jqXHR, statusText, errorThrown) {
                                fail(errorThrown);
                            });
                        });
                        setItemValuesPromise.fail(function (jqXHR, statusText, errorThrown) {
                            fail(errorThrown);
                        });
                    }, function (error) {
                        fail(error);
                    });
                });
                startContextChangesPromise.fail(function (jqXHR, statusText, errorThrown) {
                    fail(errorThrown);
                });
            }
            catch (e) {
                this.showMessage(e);
            }
        };
        ClientContext.prototype.convert = function (o) {
            return o != null ? o.toString() : "";
        };
        ClientContext.prototype.setSubject = function (subject, success, fail) {
            var _this = this;
            if (!this.isSecurityAny(subject)) {
                this.setSecure(subject, function () {
                    success();
                    return;
                }, function (error) {
                    _this.showMessage(error);
                });
            }
            try {
                var data = new lt.Ccow.ContextData(this._ccowService);
                var endData;
                var decision = "accept";
                var disconnect = false;
                var transaction;
                this._app.log("=> StartContextChanges({0})", this._participantCoupon);
                var startContextChangesPromise = this._contextManager.startContextChanges(this._participantCoupon);
                startContextChangesPromise.done(function (result) {
                    transaction = result;
                    _this._app.log("     Received transaction coupon: {0}", transaction);
                    _this._app.log("=> SetItemValues([{0}],[{1}],{2},{3})", _this._participantCoupon, subject.toItemNameArray().join(","), subject.toItemValueArray().join(","), transaction);
                    var setItemValuesPromise = data.setItemValues(_this._participantCoupon, subject.toItemNameArray(), subject.toItemValueArray(), transaction);
                    setItemValuesPromise.done(function (result) {
                        _this._app.log("=> EndContextChanges({0},ref noContinue)", transaction);
                        var endContextChangesPromise = _this._contextManager.endContextChanges(transaction);
                        endContextChangesPromise.done(function (result) {
                            endData = result;
                            _this._app.log("=> PublishChangesDecision({0},{1})", transaction, decision);
                            var listeners;
                            var publishChangesDecisionPromise = _this._contextManager.publishChangesDecision(transaction, decision);
                            publishChangesDecisionPromise.done(function (result) {
                                listeners = result;
                                if (decision.toLowerCase() == "accept") {
                                    for (var i = 0; i < listeners.length; i++) {
                                        new lt.Ccow.CcowService(listeners[i]).send("contextChangeCoupon={0}".format(transaction));
                                    }
                                }
                                if (disconnect) {
                                    _this.leave(function () {
                                        success();
                                    }, function (error) {
                                        fail(error);
                                    });
                                }
                                else
                                    success();
                            });
                            publishChangesDecisionPromise.fail(function (jqXHR, statusText, errorThrown) {
                                fail(errorThrown);
                            });
                        });
                        endContextChangesPromise.fail(function (jqXHR, statusText, errorThrown) {
                            fail(errorThrown);
                        });
                    });
                    setItemValuesPromise.fail(function (jqXHR, statusText, errorThrown) {
                        fail(errorThrown);
                    });
                });
                startContextChangesPromise.fail(function (jqXHR, statusText, errorThrown) {
                    fail(errorThrown);
                });
            }
            catch (e) {
                throw e;
            }
        };
        ClientContext.prototype.isUserContextSet = function (success, fail) {
            var _this = this;
            var getMostRecentContextCouponPromise = this._contextManager.getMostRecentContextCoupon();
            getMostRecentContextCouponPromise.done(function (result) {
                var mostRecentCoupon = result;
                var res = false;
                if (mostRecentCoupon != 0) {
                    var item = new lt.Ccow.ContextItem("User.id.logon." + _this._app.getSuffix());
                    _this.getItemValue(item, false, mostRecentCoupon, function (user) {
                        res = !(user == null || user.length < 1);
                        success(res);
                    }, function (error) {
                        _this.showMessage(error);
                    });
                }
                else
                    success(res);
            });
            getMostRecentContextCouponPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.isUserLoggedIn = function (success, fail) {
            var data = new lt.Ccow.ContextData(this._ccowService);
            var currentUser = false;
            var contextData = [];
            contextData.push("User.Id.Logon");
            var getItemValuesPromise = data.getItemValues(contextData, false, -100);
            getItemValuesPromise.done(function (result) {
                contextData = result;
                success();
            });
            getItemValuesPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
            return currentUser;
        };
        ClientContext.prototype.getAuthenticationData = function (user, success, fail) {
            var _this = this;
            var data = "";
            var authenticationRepository = new lt.Ccow.AuthenticationRepository(this._ccowService);
            var coupon;
            var connectPromise = authenticationRepository.connect(this._appName);
            connectPromise.done(function (result) {
                coupon = result;
                if (coupon != 0) {
                    try {
                        _this.secureBind(coupon, function () {
                            var signature = "";
                            signature = coupon.toString() + user;
                            _this.createSignature(signature, function (result) {
                                signature = result;
                                var getAuthenticationDataPromise = authenticationRepository.getAuthenticationData(coupon, user, "", signature);
                                getAuthenticationDataPromise.done(function (result) {
                                    data = result.repositorySignature;
                                    success(data);
                                });
                                getAuthenticationDataPromise.fail(function (jqXHR, statusText, errorThrown) {
                                    fail(errorThrown);
                                });
                            }, function (error) {
                                fail(error);
                            });
                        }, function (error) {
                            _this.showMessage(error);
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
            connectPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.setAuthenticationData = function (user, password, success, fail) {
            var _this = this;
            var authenticationRepository = new lt.Ccow.AuthenticationRepository(this._ccowService);
            var coupon;
            var connectPromise = authenticationRepository.connect(this._appName);
            connectPromise.done(function (result) {
                coupon = result;
                if (coupon != 0) {
                    try {
                        _this.secureBind(coupon, function () {
                            var signature = "";
                            signature = coupon.toString() + user + password;
                            _this.createSignature(signature, function (result) {
                                signature = result;
                                var setAuthenticationDataPromise = authenticationRepository.setAuthenticationData(coupon, user, "", password, signature);
                                setAuthenticationDataPromise.done(function (result) {
                                    success();
                                });
                                setAuthenticationDataPromise.fail(function (jqXHR, statusText, errorThrown) {
                                    fail(errorThrown);
                                });
                            }, function (error) {
                                fail(error);
                            });
                        }, function (error) {
                            _this.showMessage(error);
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
            connectPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.secureBind = function (coupon, success, fail) {
            var _this = this;
            var securingBinding = new lt.Ccow.SecureBinding(this._ccowService);
            this._app.log("=> InitializeBinding({0},{1},{2}) (Authentication Repository)", coupon, lt.Ccow.Constants.webPassCodeNames, lt.Ccow.Constants.webPassCodeValues);
            var initializeBindingPromise = securingBinding.initializeBinding(coupon, lt.Ccow.Constants.webPassCodeNames, lt.Ccow.Constants.webPassCodeValues);
            initializeBindingPromise.done(function (result) {
                var initializeBindingData = result;
                _this._app.log("=> Verify mac. Returned Public Key: {0}", initializeBindingData.binderPublicKey);
                var getEncodedHashKeyPromise = _this._ccowClientUtils.getEncodedHashKey(initializeBindingData.binderPublicKey + _this.passcode);
                getEncodedHashKeyPromise.done(function (result) {
                    var hash = result;
                    if (initializeBindingData.mac.toLowerCase() != hash.toLowerCase()) {
                        _this._app.log("     Failed to verify authentication repository.");
                        return;
                    }
                    //
                    // Create participant hash and finalize binding
                    //
                    var getEncodedHashKeyInPromise = _this._ccowClientUtils.getEncodedHashKey(_this.publicKey + _this.passcode);
                    getEncodedHashKeyInPromise.done(function (result) {
                        hash = result;
                        _this._app.log("=> FinalizeBinding({0},{1},{2}) (Authentication Repository)", coupon, _this.publicKey, hash.toLowerCase());
                        _this.publicKey(function (res) {
                            _this._publicKey = res;
                            securingBinding.finalizeBinding(coupon, _this._publicKey, hash.toLowerCase());
                            success();
                        }, function (error) {
                            fail(error);
                        });
                    });
                    getEncodedHashKeyInPromise.fail(function (jqXHR, statusText, errorThrown) {
                        fail(errorThrown);
                    });
                });
                getEncodedHashKeyPromise.fail(function (jqXHR, statusText, errorThrown) {
                    fail(errorThrown);
                });
            });
            initializeBindingPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.secureBindCheck = function (success, fail) {
            var _this = this;
            var securingBinding = new lt.Ccow.SecureBinding(this._ccowService);
            var hash = "";
            this._app.log("=> InitializeBinding({0},{1},{2}) (Context Manager)", this._participantCoupon, lt.Ccow.Constants.webPassCodeNames, lt.Ccow.Constants.webPassCodeValues);
            var initializeBindingPromise = securingBinding.initializeBinding(this._participantCoupon, lt.Ccow.Constants.webPassCodeNames, lt.Ccow.Constants.webPassCodeValues);
            initializeBindingPromise.done(function (result) {
                var data = result;
                _this._app.log("=> Verify mac. Returned Public Key: {0}", data.binderPublicKey);
                var getEncodedHashKeyPromise = _this._ccowClientUtils.getEncodedHashKey(data.binderPublicKey + _this.passcode);
                getEncodedHashKeyPromise.done(function (result) {
                    hash = result;
                    var failedVerify = false;
                    if (data.mac.toLowerCase() != hash.toLowerCase()) {
                        _this._app.log("     Failed to verify context manager");
                        _this._app.setUserLink(false);
                        failedVerify = true;
                        success(failedVerify);
                        return;
                    }
                    //
                    // Create participant hash and finalize binding
                    //
                    var getEncodedHashKeyInPromise = _this._ccowClientUtils.getEncodedHashKey(_this.publicKey + _this.passcode);
                    getEncodedHashKeyInPromise.done(function (result) {
                        hash = result;
                        _this._app.log("=> FinalizeBinding({0},{1},{2}) (Authentication Repository)", _this._participantCoupon, _this.publicKey, hash.toLowerCase());
                        _this.publicKey(function (res) {
                            _this._publicKey = res;
                            var finalizeBindingPromise = securingBinding.finalizeBinding(_this._participantCoupon, _this._publicKey, hash.toLowerCase());
                            finalizeBindingPromise.done(function (result) {
                                var access = result;
                                if (access != null) {
                                    for (var i = 0; i < access.length; i += 2) {
                                        _this._app.log("     {0}\t{1}", access[i], access[i + 1]);
                                        _this._access.push(access[i]);
                                        _this._access.push(access[i + 1]);
                                    }
                                }
                                success(failedVerify);
                            });
                            finalizeBindingPromise.fail(function (jqXHR, statusText, errorThrown) {
                                fail(errorThrown);
                            });
                        }, function (error) {
                            fail(error);
                        });
                    });
                    getEncodedHashKeyInPromise.fail(function (jqXHR, statusText, errorThrown) {
                        fail(errorThrown);
                    });
                });
                getEncodedHashKeyPromise.fail(function (jqXHR, statusText, errorThrown) {
                    fail(errorThrown);
                });
            });
            initializeBindingPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.isSetting = function (subject, name, coupon, success, fail) {
            var contextData = new lt.Ccow.ContextData(this._ccowService);
            var data = [];
            var getItemNamesPromise = contextData.getItemNames(coupon);
            getItemNamesPromise.done(function (result) {
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
            getItemNamesPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.getCurrentUser = function (success, fail) {
            var _this = this;
            var user = "";
            var contextData = new lt.Ccow.ContextData(this._ccowService);
            var getMostRecentContextCouponPromise = this._contextManager.getMostRecentContextCoupon();
            getMostRecentContextCouponPromise.done(function (result) {
                var mostRecentCoupon = result;
                var data = [];
                var getItemNamesPromise = contextData.getItemNames(mostRecentCoupon);
                getItemNamesPromise.done(function (result) {
                    data = result;
                    if (data != null && data.length > 0) {
                        for (var i = 0; i < data.length; i++) {
                            var item = new lt.Ccow.ContextItem(data[i]);
                            if (item.suffix.toLowerCase() == _this._app.getSuffix().toLowerCase() && item.subject.toLowerCase() == "user" &&
                                item.name.toLowerCase() == "logon" && item.role.toLowerCase() == "id") {
                                data = [];
                                data.push(item.toString());
                                break;
                            }
                        }
                        if (data != null) {
                            var getItemValuesPromise = contextData.getItemValues(data, false, mostRecentCoupon);
                            getItemValuesPromise.done(function (result) {
                                data = result;
                                if (data != null) {
                                    if (data.length == 2)
                                        user = data[1].toString();
                                }
                                success(user);
                            });
                            getItemValuesPromise.fail(function (jqXHR, statusText, errorThrown) {
                                fail(errorThrown);
                            });
                        }
                    }
                });
                getItemNamesPromise.fail(function (jqXHR, statusText, errorThrown) {
                    fail(errorThrown);
                });
            });
            getMostRecentContextCouponPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.getItemValue = function (item, onlyChanges, coupon, success, fail) {
            var contextData = new lt.Ccow.ContextData(this._ccowService);
            var s = new lt.Ccow.Subject();
            s.name = item.subject;
            var data = null;
            s.items.add(item);
            var getItemValuesPromise = contextData.getItemValues(s.toItemNameArray(), onlyChanges, coupon);
            getItemValuesPromise.done(function (result) {
                data = result;
                var res = "";
                if (data != null) {
                    if (data.length >= 2)
                        res = data[1].toString();
                }
                success(res);
            });
            getItemValuesPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.setFilter = function (filters) {
            var contextFilter = new lt.Ccow.ContextFilter(this._ccowService);
            contextFilter.setSubjectsOfInterest(this._participantCoupon, filters);
        };
        ClientContext.prototype.getCurrentContext = function (success, fail) {
            var _this = this;
            var data = new lt.Ccow.ContextData(this._ccowService);
            var context = [];
            var getMostRecentContextCouponPromise = this._contextManager.getMostRecentContextCoupon();
            getMostRecentContextCouponPromise.done(function (result) {
                var mostRecentCoupon = result;
                if (mostRecentCoupon != 0) {
                    _this._app.log("=> GetItemNames({0})", mostRecentCoupon);
                    var contextData = [];
                    var getItemNamesPromise = data.getItemNames(mostRecentCoupon);
                    getItemNamesPromise.done(function (result) {
                        contextData = result;
                        if (contextData != null && contextData.length > 0) {
                            _this._app.log("     Available Item Names");
                            for (var i = 0; i < contextData.length; i++) {
                                _this._app.log("          " + contextData[i]);
                            }
                            _this._app.log("=> GetItemValues([{0}],false,{1})", contextData.join(","), mostRecentCoupon);
                            var getItemValuesPromise = data.getItemValues(contextData, false, mostRecentCoupon);
                            getItemValuesPromise.done(function (result) {
                                contextData = result;
                                for (var i = 0; i < contextData.length; i += 2) {
                                    context.push(contextData[i], contextData[i + 1]);
                                    _this._app.log("          {0} ({1})", contextData[i], contextData[i + 1]);
                                }
                                success(context);
                            });
                            getItemValuesPromise.fail(function (jqXHR, statusText, errorThrown) {
                                fail(errorThrown);
                            });
                        }
                    });
                    getItemNamesPromise.fail(function (jqXHR, statusText, errorThrown) {
                        fail(errorThrown);
                    });
                }
            });
            getMostRecentContextCouponPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.createSignature = function (messageDigest, success, fail) {
            var getEncodedSignKeyPromise = this._ccowClientUtils.getEncodedSignKey(this._appName, messageDigest);
            getEncodedSignKeyPromise.done(function (result) {
                success(result);
            });
            getEncodedSignKeyPromise.fail(function (jqXHR, statusText, errorThrown) {
                fail(errorThrown);
            });
        };
        ClientContext.prototype.commonContextTerminated = function () {
            this.onTerminated();
        };
        ClientContext.prototype.contextChangesAccepted = function (contextCoupon) {
            this.onChangesAccepted(contextCoupon);
        };
        ClientContext.prototype.contextChangesCanceled = function (contextCoupon) {
            this.onChangesCanceled(contextCoupon);
        };
        ClientContext.prototype.contextChangesPending = function (contextCoupon) {
            return this.onChangesPending(contextCoupon);
        };
        ClientContext.prototype.ping = function () {
            this._app.pinged(this);
        };
        return ClientContext;
    }());
    CcowWebClientParticipationDemo.ClientContext = ClientContext;
})(CcowWebClientParticipationDemo || (CcowWebClientParticipationDemo = {}));
//# sourceMappingURL=ClientContext.js.map