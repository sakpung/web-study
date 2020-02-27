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
// [Flags]
var CreateUserOptions;
(function (CreateUserOptions) {
    CreateUserOptions[CreateUserOptions["None"] = 0x00] = "None";
    CreateUserOptions[CreateUserOptions["CreateUser"] = 0x01] = "CreateUser";
    CreateUserOptions[CreateUserOptions["UpdateUser"] = 0x02] = "UpdateUser";
    CreateUserOptions[CreateUserOptions["Login"] = 0x04] = "Login";
    CreateUserOptions[CreateUserOptions["UpdatePassword"] = 0x10] = "UpdatePassword";
    CreateUserOptions[CreateUserOptions["UpdatePermissions"] = 0x20] = "UpdatePermissions";
    CreateUserOptions[CreateUserOptions["UpdateRoles"] = 0x40] = "UpdateRoles";
})(CreateUserOptions || (CreateUserOptions = {}));
;

function isFlagged(flags, flag) {
    return (flags & flag) == flag;
}

var AuthenticationServiceProxy = (function (_super) {
    __extends(AuthenticationServiceProxy, _super);
    function AuthenticationServiceProxy(serviceUrl, authenticationProxy) {
        _super.call(this, serviceUrl, null);
    }
    Object.defineProperty(AuthenticationServiceProxy.prototype, "Username", {
        get: function () {
            return $('#authUser').val();
        },
        enumerable: true,
        configurable: true
    });

    AuthenticationServiceProxy.prototype.SetAuthenticationCookie = function (cookie) {
        this._authentication = cookie;
    };

    AuthenticationServiceProxy.prototype.GetAuthenticationCookie = function () {
        return this._authentication;
    };

    AuthenticationServiceProxy.prototype.AuthenticateUser = function (userName, password, userData, errorHandler, successHandler) {
        var parameters = {
            userName: userName,
            password: password,
            userData: userData
        };

        return this.Login(parameters, function (xhr, status, ex) {
            this._authentication = null;
            errorHandler(xhr, status, ex);
        }, function (authentication) {
            this._authentication = authentication;
            this._Username = userName;
            successHandler(this._authentication);
        });
    };

    AuthenticationServiceProxy.prototype.ValidatePermission = function (permission, errorHandler, successHandler) {
        var dataArgs = {
            authenticationCookie: this._authentication,
            permission: permission
        };

        _super.prototype.DoPostGeneralCall.call(this, "ValidatePermission", dataArgs, errorHandler, successHandler);
    };

    AuthenticationServiceProxy.prototype.Login = function (dataArgs, errorHandler, successHandler) {
        var callUrl = "../login.aspx";

        return $.ajax({
            type: "POST",
            contentType: "application/json",
            url: callUrl,
            data: JSON.stringify(dataArgs),
            error: errorHandler,
            success: successHandler
        });
    };

    AuthenticationServiceProxy.prototype.GetUsers = function (errorHandler, successHandler) {
        var dataArgs = "auth=" + encodeURIComponent(this._authentication);
        return _super.prototype.DoGetGeneralCall.call(this, "GetAllUsers", dataArgs, errorHandler, successHandler, false);
    };

    AuthenticationServiceProxy.prototype.GetPermissions = function (errorHandler, successHandler) {
        var dataArgs = { authenticationCookie: this._authentication };
        return _super.prototype.DoPostGeneralCall.call(this, "GetPermissions", dataArgs, errorHandler, successHandler);
    };

    AuthenticationServiceProxy.prototype.GetRoles = function (errorHandler, successHandler) {
        var dataArgs = { authenticationCookie: this._authentication };
        return _super.prototype.DoPostGeneralCall.call(this, "GetRoles", dataArgs, errorHandler, successHandler);
    };

    AuthenticationServiceProxy.prototype.GetUserRoles = function (userName, errorHandler, successHandler) {
        var dataArgs = { authenticationCookie: this._authentication, username: userName };
        return _super.prototype.DoPostGeneralCall.call(this, "GetUserRoles", dataArgs, errorHandler, successHandler);
    };

    AuthenticationServiceProxy.prototype.GetUserPermissions = function (userName, errorHandler, successHandler) {
        var dataArgs = "name=" + userName;
        return _super.prototype.DoGetGeneralCall.call(this, "GetUserPermissions", dataArgs, errorHandler, successHandler, false);
    };

    AuthenticationServiceProxy.prototype.DeleteUser = function (username, errorHandler, successHandler) {
        var dataArgs = {
            authenticationCookie: this._authentication,
            userName: username,
            userData: null
        };
        return _super.prototype.DoPostGeneralCall.call(this, "DeleteUser", dataArgs, errorHandler, successHandler);
    };

    AuthenticationServiceProxy.prototype.CreateUserExt = function (username, password, adminUsername, adminPassword, isAdmin, permissions, roles, options, errorHandler, successHandler) {
        var dataArgs = {
            authenticationCookie: this._authentication,
            username: username,
            password: password,
            adminUsername: adminUsername,
            adminPassword: adminPassword,
            isAdmin: isAdmin,
            permissions: permissions,
            roles: roles,
            options: options,
            userData: null
        };
        return _super.prototype.DoPostGeneralCall.call(this, "CreateUserExt", dataArgs, errorHandler, successHandler);
    };
    return AuthenticationServiceProxy;
})(ServiceProxy);
;
//# sourceMappingURL=AuthenticationServiceProxy.js.map
