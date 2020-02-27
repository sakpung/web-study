// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
var CcowWebClientParticipationDemo;
(function (CcowWebClientParticipationDemo) {
    var LogInDialog = /** @class */ (function () {
        function LogInDialog(application) {
            /* Create shortcuts Dialog UI elements */
            this.UI = {
                loginDialog: "loginDialog", userSelect: "userSelect", password: "input_password", logIn: "btn_logIn", userFirstTimeLogin: "userFirstTimeLogin"
            };
            this._username = "";
            this._ccowApplication = application;
            this.Init();
            this.loadUsers();
        }
        Object.defineProperty(LogInDialog.prototype, "enableUser", {
            get: function () {
                var userSelect = document.getElementById(this.UI.userSelect);
                return !userSelect.disabled;
            },
            set: function (val) {
                var userSelect = document.getElementById(this.UI.userSelect);
                var passowrdElement = document.getElementById(this.UI.password);
                userSelect.disabled = !val;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(LogInDialog.prototype, "firstLogin", {
            get: function () {
                return document.getElementById(this.UI.userFirstTimeLogin).style.display == "none";
            },
            set: function (val) {
                document.getElementById(this.UI.userFirstTimeLogin).style.display = val ? "inherit" : "none";
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(LogInDialog.prototype, "username", {
            get: function () {
                return this._username;
            },
            set: function (val) {
                this._username = val;
                this.updateUserName(this._username);
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(LogInDialog.prototype, "password", {
            get: function () {
                var passowrdElement = document.getElementById(this.UI.password);
                return passowrdElement.value;
            },
            set: function (val) {
                var passowrdElement = document.getElementById(this.UI.password);
                passowrdElement.value = val;
            },
            enumerable: true,
            configurable: true
        });
        LogInDialog.prototype.Init = function () {
            this._logInDlgView = document.getElementById(this.UI.loginDialog);
            $(document.getElementById(this.UI.logIn)).bind("click", $.proxy(this.onLogin, this));
            $(document.getElementById(this.UI.userSelect)).bind("change", $.proxy(this.onUserSelect, this));
        };
        LogInDialog.prototype.loadUsers = function () {
            var userSelect = document.getElementById(this.UI.userSelect);
            $(userSelect).children().remove();
            userSelect.selectedIndex = -1;
            for (var i = 0; i < this._ccowApplication.Users.length; i++) {
                var option = document.createElement("option");
                option.appendChild(document.createTextNode(this._ccowApplication.Users[i].Username));
                userSelect.add(option);
                if (this._ccowApplication.Users[i].Username == this._username)
                    userSelect.selectedIndex = i;
            }
            this.onUserSelect(null);
        };
        LogInDialog.prototype.show = function () {
            $(this._logInDlgView).modal();
        };
        LogInDialog.prototype.hide = function () {
            // enable selecting user
            this.enableUser = true;
            this.firstLogin = false;
            $(this._logInDlgView).modal("hide");
        };
        LogInDialog.prototype.authenticate = function () {
            var currentUser = this.username;
            var currentPassword = this.password;
            for (var i = 0; i < this._ccowApplication.Users.length; i++) {
                if (this._ccowApplication.Users[i].Username == currentUser && this._ccowApplication.Users[i].Password == currentPassword)
                    return true;
            }
            return false;
        };
        LogInDialog.prototype.onLogin = function () {
            if (!this.authenticate()) {
                alert("Invalid password for user.");
                return;
            }
            this.hide();
            if (this.onUserLogin != null)
                this.onUserLogin(this.username);
        };
        LogInDialog.prototype.onUserSelect = function (e) {
            this.updateUserInfo();
        };
        LogInDialog.prototype.updateUserName = function (userName) {
            var userSelect = document.getElementById(this.UI.userSelect);
            for (var i = 0; i < this._ccowApplication.Users.length; i++) {
                if (this._ccowApplication.Users[i].Username == userName) {
                    userSelect.selectedIndex = i;
                    break;
                }
            }
            this.updateUserInfo();
        };
        LogInDialog.prototype.updateUserInfo = function () {
            var userSelect = document.getElementById(this.UI.userSelect);
            var password = document.getElementById(this.UI.password);
            var user = this._ccowApplication.Users[userSelect.selectedIndex];
            if (user != null) {
                this._username = user.Username;
                if (!user.DomainLogin) {
                    password.value = user.Password;
                }
                else {
                    password.value = "";
                }
            }
        };
        return LogInDialog;
    }());
    CcowWebClientParticipationDemo.LogInDialog = LogInDialog;
})(CcowWebClientParticipationDemo || (CcowWebClientParticipationDemo = {}));
//# sourceMappingURL=LoginDialog.js.map