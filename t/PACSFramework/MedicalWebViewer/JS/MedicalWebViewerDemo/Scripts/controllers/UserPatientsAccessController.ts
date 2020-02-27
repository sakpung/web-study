// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IUserPatientsAccessScope extends ng.IScope {
        gridapi: any;
        gridOptions: any;
        patients: Array<any>;
        users: Array<any>;
        user: any;

        close();
        userChanged(user: any);
        applyPermissions();
    }

    export class UserPatientsAccessController {
        static $inject = ['$rootScope', '$scope', 'patientAccessRightsService', 'optionsService', 'queryArchiveService', 'authenticationService', 'users', '$modalInstance', 'dialogs', '$translate', 'uiGridConstants', 'blockUI'];

        private _patientAccessRightsService: PatientAccessRightsService;
        private _authenticationService: AuthenticationService;
        private grantedPermissions: Array<string>;
        private rolePatients: Array<string>;
        private scope: IUserPatientsAccessScope;
        private _dialogs;
        private _saveSuccessMsg: string;
        private _saveFailureMsg: string;
        private _notificationTitle: string;
        private _uiGridConstants;
        private _patientsBock;

        constructor($rootScope, $scope: IUserPatientsAccessScope, patientAccessRightsService: PatientAccessRightsService, optionsService: OptionsService, queryArchiveService: QueryArchiveService, authenticationService: AuthenticationService, users: Array<any>, $modalInstance, dialogs, $translate, uiGridConstants, blockUI) {
            var dateFormat = optionsService.get(OptionNames.DateFormat);
            var timeFormat = optionsService.get(OptionNames.TimeFormat);
            var __this = this;
            var enableSelectionTemplate = '<div class="ui-grid-cell-contents" ng-class="{\'em\':row.enableSelection===false && row.grid.appScope.user.name!=null}" title="TOOLTIP">{{COL_FIELD CUSTOM_FILTERS}}</div>';

            $scope.gridapi = null;
            $scope.users = users;
            $scope.user = { name: null };

            this.scope = $scope;
            this._patientAccessRightsService = patientAccessRightsService;
            this._authenticationService = authenticationService;
            this._dialogs = dialogs;
            this.rolePatients = [];
            this._uiGridConstants = uiGridConstants;
            this._patientsBock = blockUI.instances.get('patientsBlockUI');

            $scope.gridOptions = {
                appScopeProvider: $scope,
                enableSorting: true,
                enableRowSelection: true,
                showFooter: true,
                modifierKeysToMultiSelect: false,
                paginationPageSizes: [25, 50, 75],
                paginationPageSize: 25,
                enableFiltering: true,   
                enableHorizontalScrollbar: uiGridConstants.scrollbars.NEVER,             
                onRegisterApi: function (gridApi) {
                    $scope.gridapi = gridApi;
                    gridApi.pagination.on.paginationChanged($scope, __this.paginationChanged.bind(__this));
                    gridApi.selection.on.rowSelectionChanged($scope, __this.rowSelectionChange.bind(__this));   
                    gridApi.selection.on.rowSelectionChangedBatch($scope, __this.rowSelectionChangedBatch.bind(__this));
                    __this.makeReadOnly();                 
                },
                columnDefs: [
                    { name: "Id", field: "ID", enableHiding: false, cellTemplate: enableSelectionTemplate },
                    { name: "Name", field: "Name", enableHiding: false, cellTemplate: enableSelectionTemplate },
                    { name: "Sex", field: "Sex", enableHiding: false, enableFiltering: false, cellTemplate: enableSelectionTemplate },
                    { name: "Birth Date", field: "BirthDate", enableHiding: false, enableFiltering: false, cellTemplate: enableSelectionTemplate },
                ],
                data: 'patients'
            };

            queryArchiveService.FindPatients(null).success(function (patients) {
                $scope.patients = patients;
            });

            $scope.close = function () {
                $modalInstance.close();
            }

            $scope.userChanged = this.userChanged.bind(this);
            $scope.applyPermissions = this.applyPermissions.bind(this);

            $translate('NOTIFY_PERMISSIONS_SAVED').then(function (translation) {
                this._saveSuccessMsg = translation;
            }.bind(this));

            $translate('NOTIFY_PERMISSIONS_FAILED').then(function (translation) {
                this._saveFailureMsg = translation;
            }.bind(this));

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
               this._notificationTitle = translation;
            }.bind(this));
        }

        private userChanged(user) {
            var __this = this;

            this.scope.gridapi.selection.clearSelectedRows();
            if (user != null) {
                this._authenticationService.isAdmin(user).success(function (result) {
                    this.rolePatients = [];

                    if (!result) {
                        __this._authenticationService.getUserRoles(user).success(function (userRoles) {
                            if (userRoles.length > 0) {
                                __this._patientAccessRightsService.GetRolesAccess(userRoles).then(function (data) {
                                    var length = data.data.length;

                                    for (var i = 0; i < length; i++) {
                                        var patientId = data.data[i].PatientId;

                                        if (__this.rolePatients.indexOf(patientId) == -1)
                                            __this.rolePatients.push(patientId);
                                    }
                                    __this.getPermissions(user);
                                }, function (reason) {
                                        __this.getPermissions(user);
                                    });
                            }
                            else
                                __this.getPermissions(user);
                        })
                            .error(function () {
                                __this.getPermissions(user);
                            });
                    }
                    else
                        __this.makeReadOnly();
                });
            }
            else {
                this.makeReadOnly();
            }
        }

        private getPermissions(user: string) {
            this._patientAccessRightsService.GetUserAccess(user).then(function (result) {
                this.grantedPermissions = [];
                for (var i = 0; i < result.data.length; i++) {
                    this.grantedPermissions.push(result.data[i].PatientId);
                }
                this.updateSelection();
                this.updatePermissions();
            }.bind(this),
                function (e) {
                });
        }

        private applyPermissions() {
            this._patientAccessRightsService.GrantUserPatients(this.scope.user.name, this.grantedPermissions).then(function (data) { 
                this._dialogs.notify(this._notificationTitle, this._saveSuccessMsg);              
            }.bind(this), function (error) {
                this._dialogs.error(this._saveFailureMsg + ": " + error);
            }.bind(this));           
        }

        private updatePermissions() {
            var rows: Array<any> = this.scope.gridapi.grid.rows;

            angular.forEach(rows, function (value, key) {
                var entity = value.entity;
                var permissions: Array<string> = $.grep(this.grantedPermissions, function (e: string, index) {
                    return e == entity.ID;
                });

                if (permissions.length > 0) {
                    this.scope.gridapi.selection.selectRow(entity);
                }
            }, this);
        }

        private paginationChanged(currentPage: number, pageSize: number) {
            this.updateSelection();
            this.updatePermissions();
        }        

        private rowSelectionChange(row, event) {            
            if (!angular.isDefined(event)) {
                //
                // event happen through programmatic access
                //
                return;
            }
            
            if (row.isSelected)
                this.addPermission(this.scope.user.name, row.entity.ID);
            else
                this.removePermission(this.scope.user.name, row.entity.ID);
        }

        private rowSelectionChangedBatch(rows: Array<any>, event) {
            var length = rows.length;

            for (var i = 0; i < length; i++) {
                if (rows[i].isSelected)
                    this.addPermission(this.scope.user.name, rows[i].entity.ID);
                else
                    this.removePermission(this.scope.user.name, rows[i].entity.ID);
            }
        }

        private updateSelection() {
            var rows: Array<any> = this.scope.gridapi.core.getVisibleRows(this.scope.gridapi.grid);

            angular.forEach(rows, function (row, key) {
                var contains: boolean = this.rolePatients.indexOf(row.entity.ID) != -1;


                row.isSelected = contains;
                row.enableSelection = !contains;                
            }, this);                        
        }

        private makeReadOnly(isAdmin?:boolean) {
            var rows: Array<any> = this.scope.gridapi.core.getVisibleRows(this.scope.gridapi.grid);

            isAdmin = isAdmin || false;
            if (rows.length == 0 || isAdmin) {  
                setTimeout(function () {
                    this.makeReadOnly();
                }.bind(this), 250);              
            }
            else {
                angular.forEach(rows, function (row, key) {
                    row.isSelected = false;
                    row.enableSelection = false;
                }, this);
            }
        }

        private addPermission(user: string, patientId: string) {
            var permissions: Array<string> = $.grep(this.grantedPermissions, function (e: string, index) {
                return e == patientId;
            });

            if (permissions.length == 0) {                
                this.grantedPermissions.push(patientId);
            }
        }

        private removePermission(user: string, patientId: string) {
            var permissions: Array<string> = $.grep(this.grantedPermissions, function (e: string, index) {
                return e == patientId;
            });

            if (permissions.length == 1) {
                var index = this.grantedPermissions.indexOf(permissions[0]);

                this.grantedPermissions.splice(index, 1);
            }
        }
    }
} 