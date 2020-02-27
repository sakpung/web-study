// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
/// <reference path="../lib/LEADTOOLS/jquery/jquery.d.ts" />
/// <reference path="../lib/angular/angular.d.ts" />
/// <reference path="../lib/angular/angular-route.d.ts" />
// <reference path="../Scripts/Controllers/MedicalWebViewerController.ts" />
// <reference path="../Scripts/Controllers/LoginController.ts" />
// <reference path="../Scripts/ExternalCommand/SharedPropertiesService.ts" />
// <reference path="../Scripts/services/OptionsService.ts" />
// <reference path="../Scripts/services/ToolbarService.ts" />
// <reference path="../Scripts/controllers/MedicalWebViewerController.ts" />
// <reference path="../Scripts/externalCommand/SharedPropertiesService.ts" />
// <reference path="../Scripts/services/AuditLogService.ts" />
// <reference path="../Scripts/controllers/TemplateEditorController.ts" />

declare var agGrid;

agGrid.initialiseAgGridWithAngular1(angular);

//
// Register all of the required modules for the application.
//
var app = angular.module("MedicalWebViewer", ['controllers', 'services', 'directives', 'filters', 'ui.bootstrap', 'ngAnimate', 'ngRoute', 'angular-loading-bar',
   'ngIdle', 'blockUI', 'colorpicker.module', 'dialogs.main', 'ngSanitize', 'pascalprecht.translate', 'commangular', 'cfp.hotkeys', 'ui.slider',
   'ui.grid', 'ui.grid.selection', 'ui.grid.expandable', 'ui.grid.autoResize', 'ui.grid.pinning', 'ui.grid.autoResize', 'ui.grid.pagination', 'agGrid',
   'ngFileUpload', 'ui.codemirror', 'angularNumberPicker', 'multiStepForm', 'isteven-multi-select', 'ngPatternRestrict']);
var controllers = angular.module('controllers', []);
var services = angular.module('services', []);
var directives = angular.module('directives', []);
var filters = angular.module('filters', []);
var providers = angular.module('providers', []);
var commangularProvider;
var _jsFileCorePath = "Scripts/LEADTOOLS/Leadtools.ImageProcessing.Core.js";
var _jsFileCoreColorPath = "Scripts/LEADTOOLS/Leadtools.ImageProcessing.Color.js";

app.config(
   ["app.config", "$routeProvider", "$locationProvider", "cfpLoadingBarProvider", "$idleProvider", "blockUIConfigProvider", "dialogsProvider", "$translateProvider", "$commangularProvider", "$httpProvider", "$keepaliveProvider", "$controllerProvider", 
      function (config, $routeProvider: ng.route.IRouteProvider, $locationProvider: ng.ILocationProvider, cfpLoadingBarProvider, $idleProvider, blockUIConfigProvider, dialogsProvider, $translateProvider, $commangularProvider, $httpProvider: ng.IHttpProvider, $keepaliveProvider, $controllerProvider) {
         cfpLoadingBarProvider.includeSpinner = false;
         commangularProvider = $commangularProvider;

         $controllerProvider.allowGlobals();
         $httpProvider.interceptors.push('authInterceptor');
         
         function initIdleProvider(optionsService: OptionsService, $idle, $keepalive) {
            var enableIdleTimer = optionsService.get(OptionNames.EnableIdleTimeout);

            //
            // This initialize the idle timer. Idle timer provide by:
            // http://hackedbychinese.github.io/ng-idle/
            //
            if (enableIdleTimer) {
               $idleProvider.idleDuration(optionsService.get(OptionNames.IdleTimeout));
               $idleProvider.warningDuration(optionsService.get(OptionNames.IdleWarningDuration));
               $idle.watch();
            }

            $keepaliveProvider.http('HeartBeat.html');
            $keepalive.start();

            if (config.runAsEval) {
               lt.RasterSupport.setLicenseUri("https://demo.leadtools.com/licenses/v200/LEADTOOLSEVAL.txt", "EVAL", () => {
                  if (!lt.RasterSupport.kernelExpired) {
                     lt.LTHelper.log("LEADTOOLS client license set successfully");
                  } else {
                     var msg = "No LEADTOOLS License\n\nYour license file is missing, invalid or expired. LEADTOOLS will not function. Please contact LEAD Sales for information on obtaining a valid license.";
                     alert(msg);
                  }
               });
            } else {
               lt.RasterSupport.setLicenseUri(null, null, () => {
                  if (!lt.RasterSupport.kernelExpired) {
                     lt.LTHelper.log("License was set successfully");
                  } else {
                     var msg = "No license was found!\n\nYour license file is missing, invalid or expired. This web application will not function.";
                     alert(msg);
                     $.removeCookie("User", { path: '/' });
                     $.removeCookie("Pass", { path: '/' });  
                     window.location.reload();
                  }
               });
            }
         }

         //
         // Register the toolbar commands.
         //
         function registerCommands(toolbarService: ToolbarService) {
            if (commangularProvider) {
               var commands: Array<string> = toolbarService.getCommands();

               //
               // Register commands provided by the toolbar.json that is stored in the options table
               //
               angular.forEach(commands, function (value: string, key) {
                  commangularProvider.mapTo(value)
                     .asSequence()
                     .add(value);
               });
            }

            function registerCommand(action: string) {
               commangularProvider.mapTo(action)
                  .asSequence()
                  .add(action);
            }

            //
            // Register any additional commands that will be used but not provided by the toolbar json
            //
            registerCommand('Compare');
            registerCommand('OnNewTemplate');
            registerCommand('OnCopyTemplate');
            registerCommand('OnSaveTemplate');
            registerCommand('OnRenameTemplate');
            registerCommand('OnDeleteTemplate');
            registerCommand('OnConfigureGrid');
            registerCommand('OnToggleGrid');
            registerCommand('OnToggleSnapToGrid');
            registerCommand('OnSelectBox');
            registerCommand('OnDrawBox');
            registerCommand('OnDeleteBox');
            registerCommand('OnExportTemplates');
            registerCommand('OnImportTemplates');
            registerCommand('OnAlignLeft');
            registerCommand('OnAlignRight');
            registerCommand('OnAlignCenter');
            registerCommand('OnAlignTop');
            registerCommand('OnAlignBottom');
            registerCommand('OnAlignMiddle');
            registerCommand('OnMakeSameWidth');
            registerCommand('OnMakeSameHeight');
            registerCommand('OnMakeSameSize');
            registerCommand('OnReturnToViewer');
         }

         //
         // Configures the routes for this application
         // https://code.angularjs.org/1.3.9/docs/api/ngRoute/provider/$routeProvider
         //
         $routeProvider.when('/', <ng.route.IRoute>{ // default route.
            templateUrl: 'views/medicalviewer.html',
            controller: Controllers.MedicalWebViewerController,
            caseInsensitiveMatch: true,
            resolve: {
               getOptions: ["$q", "sharedPropertiesService", "optionsService", "$http", "$idle", "toolbarService", "auditLogService", "$keepalive", function ($q: ng.IQService, sharedPropertiesService: SharedPropertiesService, optionsService: OptionsService, $http: ng.IHttpService, $idle, toolbarService, auditLogService: AuditLogService, $keepalive) {
                  var deferred: ng.IDeferred<{}> = $q.defer();

                  //
                  // Get the user options
                  //
                  optionsService.GetUserOptions(function (options) {
                     initIdleProvider(optionsService, $idle, $keepalive);
                     registerCommands(toolbarService);
                     auditLogService.log_launch();
                     deferred.resolve(options);
                  }, function (data, status, headers, config) {
                     initIdleProvider(optionsService, $idle, $keepalive);
                     deferred.resolve(null);
                  });
                  return deferred.promise;
               }]
            }
         })
            .when('/login', <ng.route.IRoute>{
               templateUrl: 'views/login.html',
               caseInsensitiveMatch: true,
               controller: Controllers.LoginController,
               resolve: {
                  getOptions: ["$q", "sharedPropertiesService", "optionsService", "$http", "$idle", "toolbarService", "auditLogService", "$keepalive", function ($q: ng.IQService, sharedPropertiesService: SharedPropertiesService, optionsService: OptionsService, $http: ng.IHttpService, $idle, toolbarService, auditLogService: AuditLogService, $keepalive) {
                     var deferred: ng.IDeferred<{}> = $q.defer();

                     //
                     // Get the user options - only sign-in required options - no auth cookie yet
                     //
                     optionsService.GetUserOptions(function (options) {
                        deferred.resolve(options);
                     }, function (data, status, headers, config) {
                        deferred.resolve(null);
                     });
                     return deferred.promise;
                  }],

                  loggedIn: ["$q", "authenticationService", "eventService", function ($q: ng.IQService, authenticationService: AuthenticationService, eventService: EventService) {
                     LogUtils.DebugLog("--- $routeProvider [/login]");

                     if (!authenticationService.isAuthenticated()) {
                        var deferred = $q.defer();
                        var user: string = $.cookie("User");
                        var pass: string = $.cookie("Pass");
                        var token = sessionStorage.getItem('AuthCode');

                        //
                        // If the authentication was unsuccessful the application will remain on the login screen
                        //
                        eventService.subscribe("AuthenticationService/AuthenticationFailed", function (event, message) {
                           deferred.resolve(false);
                        });

                        //
                        // If authentication was successful that application will continue.
                        //
                        eventService.subscribe("AuthenticationService/AuthenticationSuccess", function (event, data) {
                           deferred.resolve(true);
                        });

                        if (token != null && token.length > 0) {
                           sessionStorage.removeItem('AuthCode');
                           authenticationService.getAuthenticationInfo(token, "").success(function (authenticationInfoResult) {
                              var result = authenticationInfoResult;

                              //
                              // This is only possible if the user has selected the Remember Me option on the login screen
                              //
                              authenticationService.autologin(result.UserName, token);
                              return deferred.promise;
                           }).error(function (error) {
                              LogUtils.DebugLog("getAuthenticationInfo error");
                           });
                        }
                        else {
                           if ((user && user.length > 0) && (pass && pass.length > 0)) {
                              authenticationService.login(user, pass, false);
                              return deferred.promise;
                           }
                        }
                     }
                  }]
               }
            })
            .when('/login/autologin/:externalControlPort/:token*', <ng.route.IRoute>{
               templateUrl: 'views/login.html',
               caseInsensitiveMatch: true,
               controller: Controllers.LoginController,
               resolve: {
                  loggedIn: ["$q", "authenticationService", "eventService", "sharedPropertiesService", "$route", function ($q: ng.IQService, authenticationService: AuthenticationService, eventService: EventService, sharedPropertiesService: SharedPropertiesService, $route) {

                     LogUtils.DebugLog("--- $routeProvider [/login/autologin]");
                     if (!authenticationService.isAuthenticated()) {
                        var deferred = $q.defer();
                        var user: string = $.cookie("User");
                        var pass: string = $.cookie("Pass");


                        eventService.subscribe("AuthenticationService/AuthenticationFailed", function (event, message) {
                           sharedPropertiesService.SetExternalControlMode(false);
                           deferred.resolve(false);
                        });

                        eventService.subscribe("AuthenticationService/AuthenticationSuccess", function (event, data) {
                           sharedPropertiesService.SetExternalControlMode(true);
                           deferred.resolve(true);
                        });

                        LogUtils.DebugLog("   calling getAuthenticationInfo: ");
                        LogUtils.DebugLog("   $route.current.params.token: " + $route.current.params.token);
                        var myAuthenticationInfoResult;

                        authenticationService.getAuthenticationInfo($route.current.params.token, "").success(function (authenticationInfoResult) {
                           myAuthenticationInfoResult = authenticationInfoResult;
                           sharedPropertiesService.SetToken($route.current.params.token);

                           var externalControlPort: number = Number($route.current.params.externalControlPort)
                           sharedPropertiesService.SetPort(externalControlPort);
                           sharedPropertiesService.SetPolling(externalControlPort != 0);


                           authenticationService.autologin(myAuthenticationInfoResult.UserName, $route.current.params.token);
                           return deferred.promise;
                        }).error(function (error) {
                           LogUtils.DebugLog("getAuthenticationInfo error");
                        });
                     }
                  }]
               }
            })
            .when('/login/automate/:token*', <ng.route.IRoute>{

               templateUrl: 'views/login.html',
               caseInsensitiveMatch: true,
               controller: Controllers.LoginController,
               resolve: {
                  loggedIn: ["$q", "authenticationService", "eventService", "sharedPropertiesService", "$route", function ($q: ng.IQService, authenticationService: AuthenticationService, eventService: EventService, sharedPropertiesService: SharedPropertiesService, $route) {

                     LogUtils.DebugLog("--- $routeProvider [/automate]");
                     if (!authenticationService.isAuthenticated()) {
                        var deferred = $q.defer();

                        eventService.subscribe("AuthenticationService/AuthenticationFailed", function (event, message) {
                           sharedPropertiesService.SetAutoMode(false);
                           deferred.resolve(false);
                        });

                        eventService.subscribe("AuthenticationService/AuthenticationSuccess", function (event, data) {
                           sharedPropertiesService.SetAutoMode(true);
                           deferred.resolve(true);
                        });

                        LogUtils.DebugLog("   calling getAuthenticationInfo: ");
                        LogUtils.DebugLog("   $route.current.params.token: " + $route.current.params.token);
                        var myAuthenticationInfoResult;

                        authenticationService.getAuthenticationInfo($route.current.params.token, "").success(function (authenticationInfoResult) {
                           myAuthenticationInfoResult = authenticationInfoResult;
                           sharedPropertiesService.SetToken($route.current.params.token);
                           sharedPropertiesService.SetPolling(true);

                           authenticationService.autologin(myAuthenticationInfoResult.UserName, $route.current.params.token);
                           return deferred.promise;
                        }).error(function (error) {
                           LogUtils.DebugLog("getAuthenticationInfo error");
                        });
                     }
                  }]
               }
            })
            .when('/login/auto/:protocol/:token*', <ng.route.IRoute>{

               templateUrl: 'views/login.html',
               caseInsensitiveMatch: true,
               controller: Controllers.LoginController,
               resolve: {
                  loggedIn: ["$q", "authenticationService", "eventService", "sharedPropertiesService", "$route", function ($q: ng.IQService, authenticationService: AuthenticationService, eventService: EventService, sharedPropertiesService: SharedPropertiesService, $route) {

                     LogUtils.DebugLog("--- $routeProvider [/automate-v2.0]");
                     if (!authenticationService.isAuthenticated()) {
                        var deferred = $q.defer();

                        eventService.subscribe("AuthenticationService/AuthenticationFailed", function (event, message) {
                           sharedPropertiesService.SetAutoMode(false);
                           deferred.resolve(false);
                        });

                        eventService.subscribe("AuthenticationService/AuthenticationSuccess", function (event, data) {
                           sharedPropertiesService.SetAutoMode(true);
                           deferred.resolve(true);
                        });

                        LogUtils.DebugLog("   calling tempAuthenticate: ");
                        LogUtils.DebugLog("   $route.current.params.protocol: " + $route.current.params.protocol);
                        LogUtils.DebugLog("   $route.current.params.token: " + $route.current.params.token);
                        var myAuthenticationInfoResult;

                        authenticationService.tempAuthenticate($route.current.params.token, $route.current.params.protocol).success(function (authenticationInfoResult) {
                           myAuthenticationInfoResult = authenticationInfoResult;
                           sharedPropertiesService.SetToken(authenticationInfoResult.Cookie);
                           sharedPropertiesService.SetPolling(true);
                           authenticationService.autologin(myAuthenticationInfoResult.UserName, authenticationInfoResult.Cookie);
                           return deferred.promise;
                        })
                           .error(function (error) {
                              LogUtils.DebugLog("tempAuthenticate error");

                              if (error)
                                 if (error.Message)
                                    alert(error.Message);
                                 else
                                    alert(error);
                           });
                     }
                  }]
               }
            })
            .when('/login/implicit/:protocol/:token*', <ng.route.IRoute>{

               templateUrl: 'views/login.html',
               caseInsensitiveMatch: true,
               controller: Controllers.LoginController,
               resolve: {
                  loggedIn: ["$q", "authenticationService", "eventService", "sharedPropertiesService", "$route", function ($q: ng.IQService, authenticationService: AuthenticationService, eventService: EventService, sharedPropertiesService: SharedPropertiesService, $route) {

                     LogUtils.DebugLog("--- $routeProvider [/automate-v2.0]");
                     if (!authenticationService.isAuthenticated()) {
                        var deferred = $q.defer();

                        eventService.subscribe("AuthenticationService/AuthenticationFailed", function (event, message) {
                           sharedPropertiesService.SetAutoMode(false);
                           deferred.resolve(false);
                        });

                        eventService.subscribe("AuthenticationService/AuthenticationSuccess", function (event, data) {
                           sharedPropertiesService.SetAutoMode(true);
                           deferred.resolve(true);
                        });

                        LogUtils.DebugLog("   calling implicitAuthenticate: ");
                        LogUtils.DebugLog("   $route.current.params.protocol: " + $route.current.params.protocol);
                        LogUtils.DebugLog("   $route.current.params.token: " + $route.current.params.token);
                        var myAuthenticationInfoResult;

                        authenticationService.implicitAuthenticate($route.current.params.token, $route.current.params.protocol).success(function (authenticationInfoResult) {
                           myAuthenticationInfoResult = authenticationInfoResult;
                           sharedPropertiesService.SetToken(authenticationInfoResult.Cookie);
                           authenticationService.autologin(myAuthenticationInfoResult.UserName, authenticationInfoResult.Cookie);
                           return deferred.promise;
                        })
                           .error(function (error) {
                              LogUtils.DebugLog("implicitAuthenticate error");

                              if (error)
                                 if (error.Message)
                                    alert(error.Message);
                                 else
                                    alert(error);

                              sharedPropertiesService.SetAutoMode(false);
                              deferred.resolve(false);
                              $.removeCookie("User", { path: '/' });
                              $.removeCookie("Pass", { path: '/' });
                              sessionStorage.removeItem('AuthCode');
                              window.location.href = window.location.href.split("/#")[0];
                           });
                     }
                  }]
               }
            })
            .when('/templateEditor', { // redirect to the template editor
               templateUrl: 'views/TemplateEditorView.html',
               controller: Controllers.TemplateEditorController,
               caseInsensitiveMatch: true,
               resolve: {
                  templates: ["$q", "templateService", "optionsService", function ($q, templateService, optionsService) {
                     var deferred = $q.defer();

                     templateService.GetAllTemplates().success(function (data) {
                        deferred.resolve(data);
                     }).error(function () {
                        deferred.resolve(null);
                     });
                     return deferred.promise;
                  }]
               }
            })
            .otherwise({
               //retirectTo: '/' 
               redirectTo: function (params, currentPath) {
                  var newPath: string = '/login'
                  LogUtils.DebugLog("--- $routeProvider [otherwise]: " + currentPath + "--> " + newPath);
                  return newPath;
               }
            });

         // $locationProvider.html5Mode(true).hashPrefix('!');
         blockUIConfigProvider.autoBlock(false);
         blockUIConfigProvider.delay(0);
         blockUIConfigProvider.message('Please wait...');

         dialogsProvider.useBackdrop('static');
         dialogsProvider.useEscClose(false);
         dialogsProvider.useCopy(false);
         dialogsProvider.setSize('sm');

         $translateProvider.useStaticFilesLoader({
            prefix: 'languages/',
            suffix: '.json'
         });

         $translateProvider.preferredLanguage('en-US');
      }]);

app.factory('safeApply', [function ($rootScope) {
   return function ($scope, fn) {
      var phase = $scope.$root.$$phase;

      if (phase == '$apply' || phase == '$digest') {
         if (fn) {
            $scope.$eval(fn);
         }
      } else {
         if (fn) {
            $scope.$apply(fn);
         } else {
            $scope.$apply();
         }
      }
   }
}])

//
// Create an interceptor that will test to see if the user's session has expired.  If it has the user will be automatically
// logged out of the application
// https://docs.angularjs.org/api/ng/service/$http
//
app.factory('authInterceptor', ['$q', '$injector', function ($q, $injector) {
   var authInterceptor = {
      response: function (response) {
         if (response.headers()['content-type'] === "application/xml; charset=utf-8") {
            if (response.data.FaultType && response.data.Message) {
               if (response.data.FaultType === 'ServiceAuthenticationException' && response.data.Message === 'Timed-out') {
                  var authenticationService: AuthenticationService = $injector.get('authenticationService');

                  alert("Your session with the server has been timed-out.");
                  authenticationService.logout();
               }
            }
         }
         return response;
      }
   };

   return authInterceptor;
}]);

app.factory('dataCache', function () {
   var cache: any = {};

   cache.data = {};

   cache.add = function (key: string, data: any) {
      cache[key] = data;
   };

   return cache;
});

function addPreload(fileName) {
   var fileref = document.createElement("link");

   fileref.setAttribute("rel", "preload");
   fileref.setAttribute("as", "style");
   fileref.setAttribute("href", fileName);

   if (typeof fileref != "undefined") {
      document.getElementsByTagName("head")[0].appendChild(fileref);
   }
}

function addCss(fileName) {
   var fileref = document.createElement("link");

   fileref.setAttribute("rel", "stylesheet");
   fileref.setAttribute("type", "text/css");
   fileref.setAttribute("href", fileName);

   if (typeof fileref != "undefined") {
      document.getElementsByTagName("head")[0].appendChild(fileref);
   }
}

function loadCss() {
   if (lt.LTHelper.device == lt.LTDevice.mobile) {
      addCss("css/m.toolbar.css");
      addPreload("css/toolbarSVG.css");
      addCss("css/toolbarSVG.css");
      addCss("css/m.app.css");
   }
   else {
      addCss("css/toolbar.css");
      addPreload("css/toolbarSVG.css");
      addCss("css/toolbarSVG.css");
   }

   if (lt.LTHelper.device == lt.LTDevice.tablet) {
      var style = document.createElement('style')

      style.type = 'text/css'
      style.innerHTML = '.ui-jqgrid tr.jqgrow td {height: 55px;}';
      document.getElementsByTagName('head')[0].appendChild(style);
   }
}

app.run(['$rootScope', '$location', 'authenticationService', 'sharedPropertiesService', '$window', 'app.config', 'dialogs', 'optionsService', '$templateCache', function ($rootScope, $location: ng.ILocationService,
   authenticationService: AuthenticationService, sharedPropertiesService: SharedPropertiesService, $window, config, dialogs, optionsService: OptionsService, $templateCache: ng.ITemplateCacheService) {
   var mainView = document.getElementById('mainView');


   var currentTheme = window.localStorage.getItem("leadmedicalwebviewertheme");
   switch (currentTheme) {
      case "dark":

         var themeCSSElement = <HTMLLinkElement>document.getElementById('theme_css');
         themeCSSElement.href = 'css/darktheme.css';
         //element.checked = true;
         break;
      case "light":
         var themeCSSElement = <HTMLLinkElement>document.getElementById('theme_css');
         themeCSSElement.href = 'css/theme-light.css';

         //element.checked = false;
         break;
      default:

         var themeCSSElement = <HTMLLinkElement>document.getElementById('theme_css');
         themeCSSElement.href = 'css/darktheme.css';
      //element.checked = !element.checked;

   }

   $rootScope.Title = config.title;
   $rootScope.windowDimensions = { width: $window.outerWidth, height: $window.outerHeight };
   angular.element($window).bind('resize', function () {
      mainView.style.height = window.innerHeight + "px";
      $rootScope.windowDimensions = { width: $window.outerWidth, height: $window.outerHeight };
      $rootScope.$apply('windowDimensions');
   });

   loadCss();

   mainView.style.height = window.innerHeight + "px";

   $rootScope.$on('$locationChangeStart', function (event: ng.IAngularEvent, next: string, current: string) {
      LogUtils.DebugLog("*** $locationChangeStart: " + "next: " + next + ",  current: " + current);
      var pathLogin = "/login";
      var currentPath: string = $location.path();
      var pathContainsLogin: boolean = (currentPath.indexOf(pathLogin) > -1);

      if (!authenticationService.isAuthenticated() && !pathContainsLogin) {
         LogUtils.DebugLog("*** changing $location.path()-->" + pathLogin);
         $location.path(pathLogin);
      }
      else {
         if (authenticationService.isAuthenticated()) {
            if (next.indexOf(pathLogin) != -1 && $rootScope.previousPath == "/") {
               if (!confirm("Navigating back will automatically log you out.  Would you like to continue?")) {
                  event.preventDefault();
               }
               else {
                  authenticationService.logout();
               }
            }
         }
      }
   });

   $rootScope.$on('$locationChangeSuccess', function (event: ng.IAngularEvent) {
      $rootScope.previousPath = $location.path();
   });

   $rootScope.$on('$viewContentLoaded', function () {
      var tabView = document.getElementById('ltTabWrapper');

      if (tabView) {
         tabView.style.width = '100%';
      }
   });

   // 
   // This is a fix for typeahead not working correctly in angular 1.3.  Fix from 
   // http://stackoverflow.com/questions/25180433/angular-bootstrap-typeahead-doesnt-respond-to-clicks-or-arrow-keys
   //
   $templateCache.put("template/typeahead/typeahead-popup.html",
      "<ul class=\"dropdown-menu\" ng-show=\"isOpen()\" ng-style=\"{top: position.top+'px', left: position.left+'px'}\" style=\"display: block;\" role=\"listbox\" aria-hidden=\"{{!isOpen()}}\">\n" +
      "    <li ng-repeat=\"match in matches track by $index\" ng-class=\"{active: isActive($index) }\" ng-mouseenter=\"selectActive($index)\" ng-click=\"selectMatch($index)\" role=\"option\" id=\"{{match.id}}\">\n" +
      "        <div typeahead-match index=\"$index\" match=\"match\" query=\"query\" template-url=\"templateUrl\"></div>\n" +
      "    </li>\n" +
      "</ul>");

   $templateCache.put("ui-grid/expandableTopRowHeader", "<div />");
}]);