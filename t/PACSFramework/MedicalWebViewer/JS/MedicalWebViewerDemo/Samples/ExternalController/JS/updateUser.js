// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************
// updateUser.js

/*jslint bitwise: true */
/*jshint eqnull:true */
/*jslint plusplus: true */
/*jslint white: true */
/*global describe:true*/
/*jslint newcap: true*/
/*jslint nomen: true*/
/*jshint onevar: false */

/*global logger : false */ 
/*global document : false */ 
/*global controller : false */ 
/*global ExternalCommandNames : false */
/*global populateDropDownList : false */
/*global getDropDownSelectedText : false */
/*global CreateUserOptions : false */
/*global confirm : false */


function onGetUsersError(xhr, textStatus, ex) {
    logger.LogMessage("AuthenticationServiceProxy.GetUsers", xhr.statusText);
}

function onGetPermissionsError(xhr, textStatus, ex) {
    logger.LogMessage("AuthenticationServiceProxy.GetPermissions", xhr.statusText);
}

function onGetRolesError(xhr, textStatus, ex) {
    logger.LogMessage("AuthenticationServiceProxy.GetRoles", xhr.statusText);
}

function onGetUserRolesError(xhr, textStatus, ex) {
    logger.LogMessage("AuthenticationServiceProxy.GetUserRoles", xhr.statusText);
}

function onGetUserPermissionsError(xhr, textStatus, ex) {
    logger.LogMessage("AuthenticationServiceProxy.GetUserRoles", xhr.statusText);
}

function onCreateUserExtError(xhr, textStatus, ex) {
    var result = JSON.parse(ex.responseText);
    logger.LogMessage("AuthenticationServiceProxy.CreateUserExt", result);
}

function onUpdateUserError(xhr, textStatus, ex) {
    var result = JSON.parse(ex.responseText);
    logger.LogMessage("ExternalCommandNames.UpdateUser", result);
}

function onDeleteUserError(xhr, textStatus, ex) {
    var result = JSON.parse(ex.responseText);
    logger.LogMessage(ExternalCommandNames.DeleteUser, result.DeleteUserResult);
}

function onChange_updateUserPasswordCheckbox() {
    var checkBox = document.getElementById("idCheckbox_updateUser_password");
    var passwordTextBox = document.getElementById("idText_updateUser_password");
    if (checkBox === null || passwordTextBox === null) {
        return;
    }
    passwordTextBox.disabled = (checkBox.checked !== true);
}


function insertTableCell(tabId, newRow, col, text) {
      // Insert a cell in the row at index 0
    var newCell = newRow.insertCell(col);

    var checkbox = document.createElement("input");
    var label = document.createElement("label");
    var description = document.createTextNode(text);

    checkbox.type = "checkbox";
    checkbox.name = "name";
    checkbox.value = "true";
    checkbox.id = tabId + "_" + text;

    label.appendChild(checkbox);
    label.appendChild(description);

    newCell.appendChild(label);
}

function addTableRow(tabId, tableRef, s) {
    var newRow = tableRef.insertRow(tableRef.rows.length);

    insertTableCell(tabId, newRow, 0, s);   
    return newRow;
}


function populateUsersDropdown(onSuccess) {
    controller.AuthenticationProxy.GetUsers(onGetUsersError, function (result) {

        var sArray = null;
        if (result ) {
            sArray = result;
        }

        if (sArray.length > 0) {
            populateDropDownList("idDropDownList_updateUser_userName", sArray);
        }
        onSuccess();
    });
}

var permissionsArray = new Array();
var rolesArray = new Array();

function populatePermissionsTable(tabId, idPermissionsTable) {
     controller.AuthenticationProxy.GetPermissions(onGetPermissionsError, function (result) {

         var sArray = null;

         if (result ) {
             sArray = result;
         }

          if (sArray.length > 0) {
              permissionsArray = sArray;

            var tableRef = document.getElementById(idPermissionsTable).getElementsByTagName("tbody")[0];
            if (tableRef.children.length <= 0) {
                var newRow;
                for (var i = 0; i < sArray.length; i++) {
                    newRow = addTableRow(tabId, tableRef, sArray[i].Name);
                }
            }
        }
    });
}

function getCheckedArray(tabId, id, allArray) {
    var checkedArray = new Array();
    var tableRef = document.getElementById(id).getElementsByTagName("tbody")[0];
    for (var x = 0; x < allArray.length; x++) {
        var name = allArray[x].Name;
        var checkBox = document.getElementById(tabId + "_" + name);
        if (checkBox.checked) {
            checkedArray.push(name);
        }
    }
    return checkedArray;
}

function populateRolesTable(tabId, idRolesTable) {
    controller.AuthenticationProxy.GetRoles(onGetRolesError, function (result) {

        var sArray = null;

        if (result ) {
            sArray = result;
        }

        if (sArray.length > 0) {
            rolesArray = sArray;

            var tableRef = document.getElementById(idRolesTable).getElementsByTagName("tbody")[0];
            if (tableRef.children.length <= 0) {
                var newRow;
                for (var i = 0; i < sArray.length; i++) {
                    newRow = addTableRow(tabId, tableRef, sArray[i].Name);
                }
            }
        }
    });
}


Array.prototype.contains = function (obj) {
    var i = this.length;
    while (i--) {
        if (this[i] === obj) {
            return true;
        }
    }
    return false;
};

function updatePermissionCheckboxes(tabId, username)  {

    controller.AuthenticationProxy.GetUserPermissions(username, onGetUserPermissionsError, function (result) {

        var sArray = null;

        if (result ) {
            sArray = result;
        }

        for (var x = 0; x <permissionsArray.length; x++) {
            var name = permissionsArray[x].Name;
            var checkBox = document.getElementById(tabId + "_" + name);
            checkBox.checked = sArray.contains(name);
            }
    });
}

function updateRoleCheckboxes(tabId, username)  {
    controller.AuthenticationProxy.GetUserRoles(username, onGetUserRolesError, function (result) {

        var sArray = null;

        if (result ) {
            sArray = result;
        }

        for (var x = 0; x <rolesArray.length; x++) {
            var name = rolesArray[x].Name;
            var checkBox = document.getElementById(tabId + "_" + name);
            checkBox.checked = sArray.contains(name);
            }
    });
}

function updateRolePermissionCheckboxes(tabId) {
    var username = getDropDownSelectedText("idDropDownList_updateUser_userName");
    updatePermissionCheckboxes(tabId, username);
    updateRoleCheckboxes(tabId, username);
}

function onChange_UpdateUser_username() {
    updateRolePermissionCheckboxes("idUpdateUser");
}

function initializeUpdateUser() {
    onChange_updateUserPasswordCheckbox();
    populatePermissionsTable("idUpdateUser", "idTable_updateUser_permissions");
    populateRolesTable("idUpdateUser", "idTable_updateUser_roles");
    populateUsersDropdown(function () {
        updateRolePermissionCheckboxes("idUpdateUser", "idUpdateUser");
    });
}

function onClick_deleteUser() {
    var commandName = ExternalCommandNames.DeleteUser;
    var username = getDropDownSelectedText("idDropDownList_updateUser_userName");
    var adminUsername = document.getElementById("idText_loginLogout_userName").value;

    var confirmMessage = "Delete user: '" + username + "'?";
    var result = confirm(confirmMessage);

    if (result !== true) {
        return;
    }

    if (username === adminUsername) {
        var msg = "Failed to delete user '" + username + "'.  The currently logged in user cannot be deleted.";
        logger.LogMessage(commandName, msg);
        return;
    }

    controller.AuthenticationProxy.DeleteUser(username, onDeleteUserError, function (result) {
        var msg = "User '" + username + "' successfully deleted.";
        logger.LogMessage(commandName, msg);
        initializeUpdateUser();
    });
}

function onClick_updateUser() {
    var username = getDropDownSelectedText("idDropDownList_updateUser_userName");
    var password = document.getElementById("idText_updateUser_password").value;
    var adminUsername = document.getElementById("idText_loginLogout_userName").value;
    var adminPassword = document.getElementById("idText_loginLogout_password").value;

    var permissions =  getCheckedArray("idUpdateUser", "idTable_updateUser_permissions", permissionsArray);
    var roles =  getCheckedArray("idUpdateUser", "idTable_updateUser_roles", rolesArray);
    var options = CreateUserOptions.UpdateUser | CreateUserOptions.UpdatePermissions | CreateUserOptions.UpdateRoles;

    var checkBoxUpdatePassword = document.getElementById("idCheckbox_updateUser_password");
    if (checkBoxUpdatePassword.checked) {
        options |= CreateUserOptions.UpdatePassword;
    }

    controller.AuthenticationProxy.CreateUserExt(
                               username,
                               password,
                               adminUsername,
                               adminPassword,
                                 false,
                              permissions,
                              roles,
                               options,
                               onCreateUserExtError,

                               function (result) {
                                   logger.LogMessage(ExternalCommandNames.UpdateUser, result);
                               });
}



