// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../../lib/angular/angular.d.ts" />

module Controllers {
   export interface ILoginControllerScope extends ng.IScope {
      authenticationMessage: string;
      Copyright: string;
      Username: string;
      Password: string;
      RememberMe: boolean;
      Invalid: boolean;

      submit: Function;
      submitted: boolean;
      showMessage: boolean;
      oktaIsEnabled: boolean;
      oktaHelpIsEnabled: boolean;
      loginOkta: Function;
      loginOktaHelp: Function;
      shibbolethIsEnabled: boolean;
      loginShibboleth: Function;
      loginShibbolethHelp: Function;
   }

   export class LoginController {

      static $inject = ['$scope', 'app.config', 'authenticationService', '$location', 'eventService', 'optionsService'];

      auth: AuthenticationService;
      _scope: ILoginControllerScope;

      constructor($scope: ILoginControllerScope, config, authenticationService: AuthenticationService, $location: ng.ILocationService, eventService: EventService, optionsService: OptionsService) {
         var __this = this;

         this._scope = $scope;
         $scope.Copyright = config.copyright;
         $scope.authenticationMessage = "";
         $scope.Invalid = false;
         $scope.RememberMe = false;
         $scope.Username = config.defaultUserName;
         $scope.Password = config.defaultPassword;
         this.auth = authenticationService;

         $scope.submit = function () {
            __this.auth.login($scope.Username, $scope.Password, $scope.RememberMe);
         }

         $scope.loginOkta = function () {
            window.location.replace(config.urls.idpServiceUrl + "Account/LoginOkta");
         }
         $scope.loginShibboleth = function () {
            window.location.replace(config.urls.idpServiceUrl + "Account/LoginShibboleth");
         }

         $scope.loginOktaHelp = function () {
            window.location.href = config.urls.oktaHelpUrl;
         }

         if (typeof config.urls.oktaHelpUrl != 'undefined' && config.urls.oktaHelpUrl) {
            $scope.oktaHelpIsEnabled = true;
         }

         $scope.loginShibbolethHelp = function () {
            window.location.href = config.urls.loginShibbolethHelpUrl;
         }

         $scope.oktaIsEnabled = optionsService.get(OptionNames.EnableOkta);
         $scope.shibbolethIsEnabled = optionsService.get(OptionNames.EnableShibboleth);

         eventService.subscribe("AuthenticationService/AuthenticationFailed", function (event, message) {
            $scope.authenticationMessage = message.args;
            $scope.Invalid = true;
         });
      }

      public init(_optionsService: OptionsService) {
         this._scope.oktaIsEnabled = _optionsService.get(OptionNames.EnableOkta);
         this._scope.shibbolethIsEnabled = _optionsService.get(OptionNames.EnableShibboleth);
      }
   }
}