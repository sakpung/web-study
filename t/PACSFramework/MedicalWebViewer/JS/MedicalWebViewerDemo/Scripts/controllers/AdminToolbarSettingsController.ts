// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
module Controllers {
    export interface IAdminToolbarSettingsScope extends ng.IScope {
        config: any;
        toolbars: Array<Models.Toolbar>;
        selectedToolbar: Models.Toolbar;
        overlay: any;
        options: any;
        activeNode: any;
        treeApi: any;
        buttons: Array<Models.ToolbarItem>;
        disabledItems: Array<string>;
        roles: Array<string>;
        role: any;
        data: any;

        close();
        isUserData(type: number): boolean;
        itemDeactivated(event, data);
        itemActivated(event, data);
        addToolbarItem();
        addRootToolbarItem();
        deleteToolbarItem();
        editToolbarItem();
        hasActiveItem(): boolean;
        save();
        roleChanged();
    }

    export class AdminToolbarSettingsController {
        static $inject = ['$scope', '$modalInstance', 'toolbarService', '$modal', 'authenticationService', 'optionsService', 'dialogs', '$translate'];

        private _overlayManagerService: OverlayManagerService;
        private _roleToolbars: any = {};
        private _previousRole: string = '';
        private _optionsService: OptionsService;
        private _toolbarService: ToolbarService;
        private _optionsSuccessMsg: string;
        private _optionsFailureMsg: string;
        private _notificationTitle: string;
        private _hasSaved: boolean;

        constructor($scope: IAdminToolbarSettingsScope, $modalInstance, toolbarService: ToolbarService, $modal, authenticationService: AuthenticationService, optionsService: OptionsService, dialogs, $translate) {
            var __this = this;

            this._previousRole = '';
            this._roleToolbars = {};
            this._optionsService = optionsService;
            this._toolbarService = toolbarService;
            this._hasSaved = false;

            $scope.toolbars = new Array<Models.Toolbar>();
            $scope.config = {
                extensions: ['table'],
                selectMode: 3,
                autoActivate: false,
                autoSetHeight: false,
                keyboard: true,
                autoScroll: true,
                table: { indentation: 20, nodeColumnIdx: 1, checkboxColumnIdx: 0 },
                checkbox: true,
                icons: false,
                renderColumns: function (event, data) {
                    var tbItem: Models.ToolbarItem = data.node.data;
                    var $tdList = $(data.node.tr).find(">td");

                    var itemSize = (lt.LTHelper.device == lt.LTDevice.desktop) ? 50 : 25;
                    if (tbItem.cssIconClass && !data.node.hasChildren()) {
                        var html = "<div class='" + tbItem.cssIconClass + "' style='width: " + itemSize + "px; height: " + itemSize + "px;vertical-align:middle;margin-left;auto;margin-right:auto'></div>";

                        $tdList.eq(2).html(html);
                    }
                }
            };

            $scope.toolbars = toolbarService.getToolbars();
            $scope.selectedToolbar = $scope.toolbars[0];
            $scope.buttons = $scope.toolbars[0].items;
            $scope.activeNode = null;
            $scope.treeApi = {};
            $scope.disabledItems = toolbarService.getDisabledItems($scope.selectedToolbar.name);
            $scope.roles = new Array<string>();
            $scope.role = {  };

            $scope.close = function () {
                $modalInstance.close(__this._hasSaved);
            }

            $scope.itemDeactivated = function (event, data) {
                $scope.activeNode = null;
            };

            $scope.itemActivated = function (event, data) {
                $scope.activeNode = data.node;
            };

            $scope.deleteToolbarItem = function () {
                $scope.activeNode.remove();
            }

            $scope.save = function () {
                var disabledItems: Array<string> = new Array<string>();
                var toolbar: Array<Models.ToolbarItem> = new Array<Models.ToolbarItem>();
                var disabledName: string = "DisabledToolbarItems_" + $scope.selectedToolbar.name;
                var toolbarName: string = "Toolbar_" + $scope.selectedToolbar.name;
                var data = {};

                __this.getToolbarInfo($scope, disabledItems, toolbar);
                data[disabledName] = JSON.stringify(disabledItems);
                data[toolbarName] = JSON.stringify({ name: $scope.selectedToolbar.name, items: toolbar });
                if ($scope.role.name == null) {
                    optionsService.saveDefaultOptions(data).success(function () {
                        __this._hasSaved = true;
                        dialogs.notify(__this._notificationTitle, __this._optionsSuccessMsg);
                    }).error(function (e, status) {
                        dialogs.error(__this._optionsFailureMsg + ": " + status);
                        });
                }
                else {
                    optionsService.saveRoleOptions($scope.role.name, data).success(function () {
                        __this._hasSaved = true;
                        dialogs.notify(__this._notificationTitle, __this._optionsSuccessMsg);
                    }).error(function (e,status) {
                        dialogs.error(__this._optionsFailureMsg + ": " + status);
                        });
                }
            }

            $scope.roleChanged = function () {
                var role: string = __this._previousRole == null || __this._previousRole == "" ? "default" : __this._previousRole;
                var disabledItems: Array<string> = new Array<string>();
                var toolbar: Array<Models.ToolbarItem> = new Array<Models.ToolbarItem>();

                if (!__this._roleToolbars[$scope.selectedToolbar.name]) {
                    __this._roleToolbars[$scope.selectedToolbar.name] = {};
                }

                if (!__this._roleToolbars[$scope.selectedToolbar.name][role]) {
                    __this._roleToolbars[$scope.selectedToolbar.name][role] = {}
                }
                __this.getToolbarInfo($scope, disabledItems, toolbar);
                __this._roleToolbars[$scope.selectedToolbar.name][role].disabledItems = disabledItems;
                __this._roleToolbars[$scope.selectedToolbar.name][role].items = toolbar;

                $scope.treeApi.clear();
                __this.loadRoleToolbar($scope, $scope.role.name);
                __this._previousRole = $scope.role.name;
            }

            $scope.addToolbarItem = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/AddToolbarItem.html',
                    controller: AddToolbarItemController,
                    backdrop: 'static',
                    resolve: {
                        item: function () {
                            return undefined;
                        }
                    }
                });

                modalInstance.result.then(function (item: Models.ToolbarItem) {
                    var node = null;

                    node = $scope.treeApi.addNode($scope.activeNode, item);
                    if (node != null) {
                        $scope.treeApi.activateNode(node);
                    }
                });
            }

            $scope.addRootToolbarItem = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/AddToolbarItem.html',
                    controller: AddToolbarItemController,
                    backdrop: 'static',
                    resolve: {
                        item: function () {
                            return undefined;
                        }
                    }
                });

                modalInstance.result.then(function (item: Models.ToolbarItem) {
                    var node = null;

                    node = $scope.treeApi.addNode(null, item);
                    if (node != null) {
                        $scope.treeApi.activateNode(node);
                    }
                });
            }

            $scope.editToolbarItem = function () {
                var modalInstance = $modal.open({
                    templateUrl: 'views/dialogs/AddToolbarItem.html',
                    controller: AddToolbarItemController,
                    backdrop: 'static',
                    resolve: {
                        item: function () {
                            return $scope.activeNode.data;
                        }
                    }
                });

                modalInstance.result.then(function (item: Models.ToolbarItem) {
                    var node = $scope.activeNode;

                    node.setTitle(item.id);
                    node.tooltip = item.tooltip;
                });
            }

            authenticationService.getRolesNames().success(function (roles) {
                $scope.roles = roles;
                $scope.role.name = roles[0];

            }).error(function (error) {
            });

            $translate('DIALOGS_TOOLBAR_SAVED').then(function (translation) {
                __this._optionsSuccessMsg = translation;
            });

            $translate('DIALOGS_TOOLBAR_SAVED_FAILURE').then(function (translation) {
                __this._optionsFailureMsg = translation;
            });

            $translate('DIALOGS_NOTIFICATION').then(function (translation) {
                __this._notificationTitle = translation;
            });
        }

        private getToolbarInfo(scope: IAdminToolbarSettingsScope, disabledItems: Array<string>, toolbar: Array<Models.ToolbarItem>) {
            scope.treeApi.visit(function (node) {
                if (!node.selected && node.hasChildren()) {
                    var disable = true;

                    node.visit(function (node) {
                        if (node.selected) {
                            disable = false;
                            return false;
                        }
                        return true;
                    });

                    if (disable) {
                        disabledItems.push(node.data.id);
                    }
                }
                else if (!node.selected) {
                    disabledItems.push(node.data.id);
                }

                if (node.parent == undefined || node.parent.title == 'root') {
                    toolbar.push(node.data);
                    if (node.data.items) {
                        node.data.items.clear();
                    }
                }
                else {
                    var result = $.grep(toolbar, function (item) { return item.id == node.parent.data.id });

                    if (result.length == 1) {
                        result[0].items.push(node.data);
                        if (node.data.items) {
                            node.data.items.clear();
                        }
                    }
                }
            });
        }

        private loadRoleToolbar(scope: IAdminToolbarSettingsScope, role: string) {
            var __this = this;

            role = role == null || role == "" ? "default" : role;
            /*if (this._roleToolbars[scope.selectedToolbar.name] && this._roleToolbars[scope.selectedToolbar.name][role]) {
                var items: Array<Models.ToolbarItem> = this._roleToolbars[scope.selectedToolbar.name][role].items;
                var disabledItems: Array<string> = this._roleToolbars[scope.selectedToolbar.name][role].disabledItems;

                if (items) {
                    for (var i = 0; i < items.length; i++) {
                        scope.treeApi.addData(null, items[i]);
                    };
                }
                scope.treeApi.setDisabledItems(disabledItems);
            }
            else */{
                if (role == "default") {
                    var items: Array<Models.ToolbarItem> = __this._toolbarService.getToolbars()[0].items;
                    var disabledItems: Array<string> = __this._toolbarService.getDisabledItems(scope.selectedToolbar.name);

                    if (items) {
                        for (var i = 0; i < items.length; i++) {
                            scope.treeApi.addData(null, items[i]);
                        };
                    }
                    scope.treeApi.setDisabledItems(disabledItems);
                }
                else {
                    var toolbarName: string = scope.selectedToolbar.name;

                    this._optionsService.getRoleOption(role, OptionNames.Toolbar + "_" + toolbarName).success(function (data: string) {
                        __this._optionsService.getRoleOption(role, OptionNames.DisabledToolbarItems + "_" + toolbarName).success(function (disabledItems) {
                            var items: Array<Models.ToolbarItem> = null;

                            if (data && data.length > 0) {
                                data = data.replace(/(\r\n|\n|\r|\t|\\)/gm, "");
                                items = JSON.parse(data).items;
                            }
                            else {
                                items = __this._toolbarService.getToolbars()[0].items;
                            }

                            if (items) {
                                for (var i = 0; i < items.length; i++) {
                                    scope.treeApi.addData(null, items[i]);
                                };
                            }
                            scope.treeApi.setDisabledItems(disabledItems);
                        }).error(function (error) {
                            });
                    }).error(function (error) {
                        });
                }
            }
        }
    }
}