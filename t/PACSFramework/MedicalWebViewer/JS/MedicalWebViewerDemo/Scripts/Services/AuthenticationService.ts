// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/LEADTOOLS/jquery/jquery.d.ts" />
/// <reference path="../../lib/LEADTOOLS/jquery/jquery.cookie.d.ts" />
/// <reference path="../app.ts" />
/// <reference path="OptionsService.ts" />
/// <reference path="../Utils.ts" />

module PermissionNames {
    export var CanChangeServerSettings: string = "CanChangeServerSettings";
    export var CanDeleteFromDatabase: string = "CanDeleteFromDatabase";
    export var CanEmptyDatabase: string = "CanEmptyDatabase";
    export var CanCalibrateMonitor: string = "CanCalibrateMonitor";
    export var CanDeleteAnnotations: string = "CanDeleteAnnotations";
    export var CanDeleteDownloadInfo: string = "CanDeleteDownloadInfo";
    export var CanDownloadImages: string = "CanDownloadImages";
    export var CanManageAccessRight: string = "CanManageAccessRight";
    export var CanManageRoles: string = "CanManageRoles";
    export var CanManageUsers: string = "CanManageUsers";
    export var CanQuery: string = "CanQuery";
    export var CanQueryPACS: string = "CanQueryPACS";
    export var CanRetrieve: string = "CanRetrieve";
    export var CanStore: string = "CanStore";
    export var CanStoreAnnotations: string = "CanStoreAnnotations";
    export var CanViewAnnotations: string = "CanViewAnnotations";    
    export var CanExport: string = "CanExport";
    export var CanManageRemotePACS: string = "CanManageRemotePACS";
    export var CanEditTemplates: string = "CanEditTemplates";
    export var CanDeleteTemplates: string = "CanDeleteTemplates";
    export var CanModifyBuiltInTemplates: string = "CanModifyBuiltInTemplates"; 
    export var CanAddTemplates: string = "CanAddTemplates";
    export var CanViewTemplates: string = "CanViewTemplates";
    export var CanImportTemplates: string = "CanImportTemplates";
    export var CanExportTemplates: string = "CanExportTemplates";
    export var CanSaveStructuredDisplay: string = "CanSaveStructuredDisplay";
    export var CanSaveHangingProtocol: string = "CanSaveHangingProtocol";
    export var CanDeleteCache: string = "CanDeleteCache";

}


class UserCredentials {
    private _userName: string;
    private _password: string;
    private _userData: string;

    get userName(): string {
        return this._userName;
    }

    set userName(value: string) {
        this._userName = value;
    }

    get password(): string {
        return this._password;
    }

    set password(value: string) {
        this._password = value;
    }

    get userData(): string {
        return this._userData;
    }

    set userData(value: string) {
        this._userData = value;
    }    
}

class CookieOptions implements JQueryCookieOptions {
    expires: any;
    path: string;
    domain: string;
    secure: boolean;
}

class AuthenticationService {
    static $inject = ['app.config', '$http', '$location', 'eventService','$window'];

    private _httpService: ng.IHttpService;
    private _eventService: EventService;
    private _locationService: ng.ILocationService;    
    private _authUrl: string;
    private _permissions; 
    private _window: ng.IWindowService;   

    public get permissions() {
        return this._permissions;
    }

    constructor(config, $http: ng.IHttpService, $location: ng.ILocationService, eventService: EventService,$window:ng.IWindowService) {
        this._httpService = $http;
        this._eventService = eventService;
        this._locationService = $location;
        this._window = $window;        

        this.authenticationCode = "";
        this.authenticationMessage = "";
        this._authUrl = config.urls.serviceUrl + config.urls.authenticationServiceName;
        this._permissions = {};
    }

    isAuthenticated(): boolean {
        return this.authenticationCode.length > 0;
    }

    private _authenticationMessage: string;

    get authenticationMessage(): string {
        return this._authenticationMessage;
    }

    set authenticationMessage(value: string) {        
        this._authenticationMessage = value;
    }

    private _authenticationCode: string;

    get authenticationCode(): string {
        return this._authenticationCode;
    }

    set authenticationCode(value: string) {
        this._authenticationCode = value;
    }

    private _user: string;

    get user(): string {
        return this._user;
    }  

    refreshPermissions() {
        var d = $.Deferred();
        var __this = this;
        var username: string = __this.user;

        __this._permissions.isAdmin = false;
        __this._permissions = {};

        __this.getUserPermissions(username).error(function (e, x) {
            __this.authenticationMessage = e.Message;
            __this._eventService.publish("AuthenticationService/AuthenticationFailed", e.Message);
            d.resolve("refreshPermissions_fail");
        }).success(function (permissions) {
            var length = permissions.length;

            for (var i = 0; i < length; i++) {
                var permission = permissions[i];
                var index = permission.indexOf(".");

                if (index != -1) {
                    permission = permission.substr(index + 1);
                }
                __this._permissions[permission] = true;
            }

            __this.isAdmin(username).error(function () {
                __this._permissions.isAdmin = false;
            }).success(function (result) {
                __this._permissions.isAdmin = result;

            });
            d.resolve("refreshPermissions_success");
        });

        return d.promise();
    }

    login(username: string, password: string, rememberMe: boolean) {        
        var __this = this;

        if (!username)
            username = "";
        if (!password)
            password = "";
        return this._httpService.post(this._authUrl + "/AuthenticateUser", { userName: username, password: password, userData: '' })
            .error(function (e, status) { 
                var message = "";

                if ((typeof e === 'string') && e.length == 0) {
                    message = __this.authenticationMessage = "HTTP Error (" + status + "): " + Utils.get_httpStatusText(status);
                }
                else {
                    if (e) {
                        if (e.hasOwnProperty('ExceptionMessage')) {
                            message = __this.authenticationMessage = e.ExceptionMessage;
                        }
                        else
                        if (e.hasOwnProperty('Message')) {
                            message = __this.authenticationMessage = e.Message;
                        }
                        else {
                            // this is not an exception, this is a whole HTML page, so we are opening a new window to display it.
                            var newtab : Window = window.open("", "_blank");
                            if (newtab) {
                                newtab.focus();
                                newtab.document.write(e);
                                newtab.focus();
                            }

                            message = "Error";
                        }
                    }
                    else {
                        message = 'Web service is down';
                    }

                }
                __this._eventService.publish("AuthenticationService/AuthenticationFailed", message);
            })
           .then(function (data) {
              if (data.status != HttpStatus.OK) {

                  if(data.statusText)
                     __this.authenticationMessage = data.statusText;
                  else
                     __this.authenticationMessage = "Unknown error: " + data.status;

                 __this._eventService.publish("AuthenticationService/AuthenticationFailed", data.statusText);
              }
              else if (data.data.Message) {
                 __this.authenticationMessage = data.data.Message;
                 __this._eventService.publish("AuthenticationService/AuthenticationFailed", data.data.Message);
              }
                else {
                    if (rememberMe) {
                        var date = new Date();
                        var options = new CookieOptions();

                        date.setMonth(date.getMonth() + 1);
                        options.expires = date;
                        options.path = "/";
                        $.cookie("User", username, options);
                        $.cookie("Pass", password, options);
                    }
                    __this._user = username;
                    __this.authenticationCode = data.data.toString();
                    __this._permissions.isAdmin = false;
                    __this.getUserPermissions(username).error(function (e, x) {
                        __this.authenticationMessage = e.Message;
                        __this._eventService.publish("AuthenticationService/AuthenticationFailed", e.Message);
                    }).success(function (permissions) {
                        var length = permissions.length;

                        for (var i = 0; i < length; i++) {
                            var permission = permissions[i];
                            var index = permission.indexOf(".");

                            if (index != -1) {
                                permission = permission.substr(index + 1);
                            }
                            __this._permissions[permission] = true;
                        }

                        __this.isAdmin(username).error(function () {
                            __this._permissions.isAdmin = false;
                        }).success(function (result) {
                            __this._permissions.isAdmin = result;
                                __this._eventService.publish("AuthenticationService/AuthenticationSuccess", data);
                                __this._locationService.path("/");
                            });
                        });                    
                }
            })                 
    }

    autologin(username: string, authenticationToken: string) {
        var __this = this;

        __this._user = username;
        __this.authenticationCode = authenticationToken;
        __this._permissions.isAdmin = false;

        __this.getUserPermissions(username).error(function (e, x) {
            __this.authenticationMessage = e.Message;
            __this._eventService.publish("AuthenticationService/AuthenticationFailed", e.Message);
        }).success(function (permissions) {
                var length = permissions.length;

                for (var i = 0; i < length; i++) {
                    var permission = permissions[i];
                    var index = permission.indexOf(".");

                    if (index != -1) {
                        permission = permission.substr(index + 1);
                    }
                    __this._permissions[permission] = true;
                }

                __this.isAdmin(username).error(function () {
                    __this._permissions.isAdmin = false;
                }).success(function (result) {
                        __this._permissions.isAdmin = result;
                        __this._eventService.publish("AuthenticationService/AuthenticationSuccess", null /*data*/);
                        __this._locationService.path("/");
                    });
            })
    }

   public getAuthenticationInfo(authenticationCookie: string, userData:string): ng.IHttpPromise<any> {
        var parameters = {
            authenticationCookie: authenticationCookie,
            calibration: userData
        };

        return this._httpService.post(this._authUrl + "/GetAuthenticationInfo", JSON.stringify(parameters));
    }

	public tempAuthenticate(cookie: string, protocol: string): ng.IHttpPromise<any> {
        var parameters = {
            cookie: cookie,
            protocol: protocol
        };

        return this._httpService.post(this._authUrl + "/tempAuthenticate", JSON.stringify(parameters));
    }

    public implicitAuthenticate(cookie: string, protocol: string): ng.IHttpPromise<any> {
        var parameters = {
            cookie: cookie,
            protocol: protocol
        };

        return this._httpService.post(this._authUrl + "/ImplicitAuthenticate", JSON.stringify(parameters));
    }

    public logout() {
        var user = this.user;
        var code = this._authenticationCode;

        $.removeCookie("User", { path: '/' } );
        $.removeCookie("Pass", { path: '/' } );  
        
        this._user = "";
        this._authenticationCode = "";
        this._eventService.publish(EventNames.Logout, { user: user, authenticationCode: code });
        //this._locationService.path("/login"); 
        this._window.location.reload();     
    }

    public logoutError(err: string) {
        var user = this.user;
        var code = this._authenticationCode;

        $.removeCookie("User", { path: '/' } );
        $.removeCookie("Pass", { path: '/' } );  
        
        this._user = "";
        this._authenticationCode = "";
        this._eventService.publish(EventNames.Logout, { user: user, authenticationCode: code });
        //this._locationService.path("/login"); 
        this._window.location.reload();     
        if(err){
         alert(err);
         }
    }

    public getUserPermissions(userName): ng.IHttpPromise<any> {
        return this._httpService.get(this._authUrl + "/GetUserPermissions?"+ "name=" + userName + "&rnd=" + new Date().getTime());
    }

    public isAdmin(userName): ng.IHttpPromise<any> {
        var dataArgs = "auth=" + encodeURIComponent(this._authenticationCode) + "&userName=" + userName;

        return this._httpService.get(this._authUrl + "/IsAdmin?" + dataArgs + "&r=" + Date.now());
    }

    public getRolesNames(): ng.IHttpPromise<any> {
        return this._httpService.post(this._authUrl + "/GetRolesNames",null);
    }

    public hasPermission(permission: string): boolean {
        if (this._permissions) {
            return this.permissions[permission] || this.permissions.isAdmin;
        }
        return false;
    }

    public createUser(username: string, password: string, userType?: string): ng.IHttpPromise<any> {
        var dataArgs = {
            authenticationCookie: this._authenticationCode,
            userName: username,
            password: password,
            userType: userType
        };

        return this._httpService.post(this._authUrl + "/CreateUser", JSON.stringify(dataArgs));
    }

    public createRole(role: string, description?:string): ng.IHttpPromise<any> {
        var Role = {
            AssignedPermissions: null,
            Description: description,
            Name: role,
        };
        var dataArgs = {
            authenticationCookie: this._authenticationCode,
            role: Role
        };
 
        return this._httpService.post(this._authUrl + "/CreateRole", JSON.stringify(dataArgs));
    }

    public getRoles(): ng.IHttpPromise<any> {
        var dataArgs = {
            authenticationCookie: this._authenticationCode
        };

        return this._httpService.post(this._authUrl + "/GetRoles", JSON.stringify(dataArgs));
    }

    public deleteRole(role: string): ng.IHttpPromise<any>  {
        var dataArgs = {
            authenticationCookie: this._authenticationCode,
            roleName: role
        };

        return this._httpService.post(this._authUrl + "/DeleteRole", JSON.stringify(dataArgs));
    }

    public getPermissions(): ng.IHttpPromise<any>  {
        var dataArgs = {
            authenticationCookie: this._authenticationCode
        };

        return this._httpService.post(this._authUrl + "/GetPermissions", JSON.stringify(dataArgs));
    }

    public updateRolePermissions(role: string, permissions: Array<string>): ng.IHttpPromise<any>  {
        var Role = {
            AssignedPermissions: permissions,
            Description: null,
            Name: role
        };
        var dataArgs = {
            authenticationCookie: this._authenticationCode,
            role: Role
        };

        return this._httpService.post(this._authUrl + "/UpdateRolePermissions", JSON.stringify(dataArgs));
    }

    public getAllUsers(): ng.IHttpPromise<any> {
        var dataArgs = "auth=" + encodeURIComponent(this._authenticationCode) + "&rnd=" + new Date().getTime();

        return this._httpService.get(this._authUrl + "/GetAllUsers?" + dataArgs);
    }

    public deleteUser(username: string, userdata?: any): ng.IHttpPromise<any> {
        var dataArgs = {
            authenticationCookie: this._authenticationCode,
            userName: username,
            userData: userdata
        };

        return this._httpService.post(this._authUrl + "/DeleteUser", JSON.stringify(dataArgs));
    }

    public resetPassword(username: string, password: string, userdata?: any): ng.IHttpPromise<any>  {
        var dataArgs = {
            authenticationCookie: this._authenticationCode,
            userName: username,
            newPassword: password,
            userData: userdata
        };

        return this._httpService.post(this._authUrl + "/ResetPassword", JSON.stringify(dataArgs));
    }

    public resetCurrentPassword(curPassword: string, password: string): ng.IHttpPromise<any>  {
        var dataArgs = {
            authenticationCookie: this._authenticationCode,
            userName: "",
            oldPassword: curPassword,
            newPassword: password
        };

        return this._httpService.post(this._authUrl + "/ChangePassword", JSON.stringify(dataArgs));
    }

    public validatePassword(password: string, userdata?: any): ng.IHttpPromise<any>  {
        var dataArgs = {
            password: password,
            userData: userdata
        };

        return this._httpService.post(this._authUrl + "/ValidatePassword", JSON.stringify(dataArgs));
    }  

    public getUserRoles(username: string, userdata?: any): ng.IHttpPromise<any> {
        var dataArgs = {
            username: username,
            userData: userdata
        };

        return this._httpService.post(this._authUrl + "/GetUserRoles" + "?rnd=" + new Date().getTime(), JSON.stringify(dataArgs));
    }  

    public grantRole(username: string, role: string, userdata?: any): ng.IHttpPromise<any> {
        var dataArgs = {
            authenticationCookie: this._authenticationCode,
            username: username,
            role: role,
            userData: userdata
        };

        return this._httpService.post(this._authUrl + "/GrantRole", JSON.stringify(dataArgs));
    }

    public denyRole(username: string, role: string, userdata?: any): ng.IHttpPromise<any> {
        var dataArgs = {
            authenticationCookie: this._authenticationCode,
            username: username,
            role: role,
            userData: userdata
        };

        return this._httpService.post(this._authUrl + "/DenyRole", JSON.stringify(dataArgs));
    }

    public grantPermission(username: string, permission: string, userdata?: any): ng.IHttpPromise<any> {
        var dataArgs = {
            authenticationCookie: this._authenticationCode,
            username: username,
            permission: permission,
            userData: userdata
        };

        return this._httpService.post(this._authUrl + "/GrantPermission", JSON.stringify(dataArgs));
    }

    public denyPermission(username: string, permission: string, userdata?: any): ng.IHttpPromise<any> {
        var dataArgs = {
            authenticationCookie: this._authenticationCode,
            username: username,
            permission: permission,
            userData: userdata
        };

        return this._httpService.post(this._authUrl + "/DenyPermission", JSON.stringify(dataArgs));
    }
}

services.service('authenticationService', AuthenticationService);