// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************

module CcowWebClientParticipationDemo {

   export interface ILoginEvent {
      onLogIn(user: string): void;
   }

   export class LogInDialog {
      private _ccowApplication: CCOWApplication;
      private _logInDlgView;
      public onUserLogin: (user: string) => void;

      /* Create shortcuts Dialog UI elements */
      private UI = {
         loginDialog: "loginDialog", userSelect: "userSelect", password: "input_password", logIn: "btn_logIn", userFirstTimeLogin: "userFirstTimeLogin"
      };

      public get enableUser(): boolean {
         var userSelect: HTMLSelectElement = <HTMLSelectElement>document.getElementById(this.UI.userSelect);
         return !userSelect.disabled;
      }
      public set enableUser(val: boolean) {
         var userSelect: HTMLSelectElement = <HTMLSelectElement>document.getElementById(this.UI.userSelect);
         var passowrdElement: HTMLInputElement = <HTMLInputElement>document.getElementById(this.UI.password);
         userSelect.disabled = !val;
      }

      public get firstLogin(): boolean {
         return document.getElementById(this.UI.userFirstTimeLogin).style.display == "none";
      }
      public set firstLogin(val: boolean) {
         document.getElementById(this.UI.userFirstTimeLogin).style.display = val ? "inherit" : "none";
      }

      private _username = "";
      public get username(): string {
         return this._username;
      }
      public set username(val: string) {
         this._username = val;
         this.updateUserName(this._username);
      }

      public get password(): string {
         var passowrdElement: HTMLInputElement = <HTMLInputElement>document.getElementById(this.UI.password);
         return passowrdElement.value;
      }
      public set password(val: string) {
         var passowrdElement: HTMLInputElement = <HTMLInputElement>document.getElementById(this.UI.password);
         passowrdElement.value = val;
      }

      constructor(application: CCOWApplication) {
         this._ccowApplication = application;
         this.Init();
         this.loadUsers();
      }

      private Init(): void {
         this._logInDlgView = document.getElementById(this.UI.loginDialog);
         $(document.getElementById(this.UI.logIn)).bind("click", $.proxy(this.onLogin, this));
         $(document.getElementById(this.UI.userSelect)).bind("change", $.proxy(this.onUserSelect, this));
      }

      private loadUsers(): void {
         var userSelect: HTMLSelectElement = <HTMLSelectElement>document.getElementById(this.UI.userSelect);
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
      }

      public show(): void {
         $(this._logInDlgView).modal();
      }
      public hide(): void {
         // enable selecting user
         this.enableUser = true;
         this.firstLogin = false;
         $(this._logInDlgView).modal("hide");
      }

      private authenticate(): boolean {
         var currentUser = this.username;
         var currentPassword = this.password;

         for (var i = 0; i < this._ccowApplication.Users.length; i++) {
            if (this._ccowApplication.Users[i].Username == currentUser && this._ccowApplication.Users[i].Password == currentPassword)
               return true;
         }

         return false;
        }

      private onLogin(): void {
         if (!this.authenticate()) {
            alert("Invalid password for user.");
            return;
         }

         this.hide();

         if (this.onUserLogin != null)
            this.onUserLogin(this.username);
      }


      private onUserSelect(e: Event) {
         this.updateUserInfo();
      }

      private updateUserName(userName: string): void {
         var userSelect: HTMLSelectElement = <HTMLSelectElement>document.getElementById(this.UI.userSelect);
         for (var i = 0; i < this._ccowApplication.Users.length; i++) {
            if (this._ccowApplication.Users[i].Username == userName) {
               userSelect.selectedIndex = i;
               break;
            }
         }

         this.updateUserInfo();
      }

      private updateUserInfo(): void {
         var userSelect: HTMLSelectElement = <HTMLSelectElement>document.getElementById(this.UI.userSelect);
         var password: HTMLInputElement = <HTMLInputElement>document.getElementById(this.UI.password);
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
      }
   }
}
