// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.
// All Rights Reserved.
// *************************************************************

// adduser.js

/*jslint white: true */

/*global rolesArray : false */ 
/*global populatePermissionsTable : false */ 
/*global populateRolesTable : false */ 
/*global permissionsArray : false */ 
/*global onCreateUserExtError : false */ 
/*global logger : false */ 
/*global getCheckedArray : false */ 
/*global document : false */ 
/*global CreateUserOptions : false */ 
/*global ExternalCommandNames : false */ 
/*global controller : false */ 


function initializeAddUser() {
    populatePermissionsTable("idAddUser", "idTable_addUser_permissions");
    populateRolesTable("idAddUser", 'idTable_addUser_roles');
}

function onClick_addUser() {
    var commandName = ExternalCommandNames.AddUser,
        username = document.getElementById("idText_addUser_userName").value,
        password = document.getElementById("idText_addUser_password").value,
        adminUsername = document.getElementById("idText_loginLogout_userName").value,
        adminPassword = document.getElementById("idText_loginLogout_password").value,

        permissions =  getCheckedArray('idAddUser', 'idTable_addUser_permissions', permissionsArray),
        roles =  getCheckedArray('idAddUser', 'idTable_addUser_roles', rolesArray),
        options = CreateUserOptions.CreateUser; 

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
                                   logger.LogMessage(commandName, result);

                               }); 
}


