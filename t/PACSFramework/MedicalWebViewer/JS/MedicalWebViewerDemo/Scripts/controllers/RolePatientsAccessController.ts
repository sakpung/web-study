// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IRolePatientsAccessScope extends ng.IScope {
        gridapi: any;
        gridOptions: any;
        patients: Array<any>;
        roles: Array<any>;
        role: any;

        close();
        roleChanged(user: any);
        applyPermissions();
    }

    export class RolePatientsAccessController {
        static $inject = ['$rootScope', '$scope', 'patientAccessRightsService', 'optionsService', 'queryArchiveService', 'authenticationService', 'roles', '$modalInstance', 'dialogs', '$translate','uiGridConstants'];

        private patientAccessRightsService: PatientAccessRightsService;
        private grantedPermissions: Array<string>;
        private scope: IRolePatientsAccessScope;
        private _dialogs;
        private _saveSuccessMsg: string;
        private _saveFailureMsg: string;
        private _notificationTitle: string;

        constructor($rootScope, $scope: IRolePatientsAccessScope, patientAccessRightsService: PatientAccessRightsService, optionsService: OptionsService, queryArchiveService: QueryArchiveService, authenticationService: AuthenticationService, roles: Array<any>, $modalInstance, dialogs, $translate, uiGridConstants) {
            var dateFormat = optionsService.get(OptionNames.DateFormat);
            var timeFormat = optionsService.get(OptionNames.TimeFormat);
            var __this = this;

            $scope.gridapi = null;
            $scope.roles = roles;
            $scope.role = {name: null};

            this.scope = $scope;
            this.patientAccessRightsService = patientAccessRightsService;
            this._dialogs = dialogs;

            $scope.gridOptions = {
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
                    __this.makeReadOnly(true);                    
                },
                columnDefs: [
                    { name: "Id", field: "ID", enableHiding: false },
                    { name: "Name", field: "Name", enableHiding: false },
                    { name: "Sex", field: "Sex", enableHiding: false, enableFiltering: false },
                    { name: "Birth Date", field: "BirthDate", enableHiding: false, enableFiltering: false },
                ],
                data: 'patients'
            };

            queryArchiveService.FindPatients(null).success(function (patients) {
                $scope.patients = patients;
            });

            $scope.close = function () {
                $modalInstance.close();
            }

            $scope.roleChanged = this.roleChanged.bind(this);
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

        private roleChanged(role) {
            this.scope.gridapi.selection.clearSelectedRows();
            if (role != null) {
                this.makeReadOnly(false);
                this.patientAccessRightsService.GetRoleAccess(role).then(function (result) {
                    this.grantedPermissions = [];
                    for (var i = 0; i < result.data.length; i++) {
                        this.grantedPermissions.push(result.data[i].PatientId);
                    }
                    this.updatePermissions();
                }.bind(this),
                    function (e) {
                    });
            }
            else {
                this.makeReadOnly(true);
            }            
        }

        private applyPermissions() {
            this.patientAccessRightsService.GrantRolePatients(this.scope.role.name, this.grantedPermissions).then(function (data) { 
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
                this.addPermission(this.scope.role.name, row.entity.ID);
            else
                this.removePermission(this.scope.role.name, row.entity.ID);
        }

        private rowSelectionChangedBatch(rows: Array<any>, event) {
            var length = rows.length;

            for (var i = 0; i < length; i++) {
                if (rows[i].isSelected)
                    this.addPermission(this.scope.role.name, rows[i].entity.ID);
                else
                    this.removePermission(this.scope.role.name, rows[i].entity.ID);
            }
        }

        private addPermission(role: string, patientId: string) {
            var permissions: Array<string> = $.grep(this.grantedPermissions, function (e: string, index) {
                return e == patientId;
            });

            if (permissions.length == 0) {               
                this.grantedPermissions.push(patientId);
            }
        }

        private removePermission(role: string, patientId: string) {
            var permissions: Array<string> = $.grep(this.grantedPermissions, function (e: string, index) {
                return e == patientId;
            });

            if (permissions.length == 1) {
                var index = this.grantedPermissions.indexOf(permissions[0]);

                this.grantedPermissions.splice(index, 1);
            }
        }

        private makeReadOnly(readonly:boolean) {
            var rows: Array<any> = this.scope.gridapi.core.getVisibleRows(this.scope.gridapi.grid);

            if (rows.length == 0) {
                setTimeout(function () {
                    this.makeReadOnly(readonly);
                }.bind(this), 250);
            }
            else {
                angular.forEach(rows, function (row, key) {
                    row.isSelected = false;
                    row.enableSelection = !readonly;
                }, this);
            }
        }
    }
} 