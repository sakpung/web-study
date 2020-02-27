/// <reference path="../../../lib/jquery/jquery.d.ts" />
/// <reference path="ServiceProxy.ts" />

// [Flags]
   enum CreateUserOptions
   {
    None = 0x00,
    CreateUser = 0x01,
    UpdateUser = 0x02,
    Login = 0x04,
    UpdatePassword = 0x10,
    UpdatePermissions = 0x20,
    UpdateRoles = 0x40,
   };

   function isFlagged(flags, flag)
   {
       return (flags & flag) == flag;
   }


class AuthenticationServiceProxy extends ServiceProxy{
    private _authentication;
    private _Username: string;

    public get Username(): string {
        return $('#authUser').val();    
    }

    constructor(serviceUrl: string, authenticationProxy)
    {
        super(serviceUrl,null);        
    }

    public SetAuthenticationCookie(cookie) {
      this._authentication = cookie;
   }

    public GetAuthenticationCookie() {
      return this._authentication;
   } 

    public AuthenticateUser(userName, password, userData, errorHandler, successHandler) {
      var parameters = { userName: userName,
         password: password,
         userData: userData
      };
      return this.Login(parameters,
      function (xhr, status, ex) { this._authentication = null; errorHandler(xhr, status, ex); },
          function (authentication) {
              this._authentication = authentication;
              this._Username = userName;
              successHandler(this._authentication);
          });
   }

    public ValidatePermission(permission, errorHandler, successHandler) {
      var dataArgs = { authenticationCookie: this._authentication,
         permission: permission
      };
      
      super.DoPostGeneralCall("ValidatePermission", dataArgs, errorHandler, successHandler)
   }

    private Login( dataArgs, errorHandler, successHandler) {
      var callUrl = "../login.aspx"
     
      return $.ajax({
         type: "POST",
         contentType: "application/json",
         url: callUrl,
         data: JSON.stringify(dataArgs),
         error: errorHandler,
         success: successHandler
      });
   }

    public GetUsers(errorHandler, successHandler): JQueryXHR {

        var dataArgs = "auth=" + encodeURIComponent(this._authentication);
        return super.DoGetGeneralCall("GetAllUsers", dataArgs, errorHandler, successHandler, false);
    }

    public GetPermissions(errorHandler, successHandler): JQueryXHR {

        var dataArgs = { authenticationCookie: this._authentication };
        return super.DoPostGeneralCall("GetPermissions", dataArgs, errorHandler, successHandler);
    }

    public GetRoles(errorHandler, successHandler): JQueryXHR {

        var dataArgs = { authenticationCookie: this._authentication };
        return super.DoPostGeneralCall("GetRoles", dataArgs, errorHandler, successHandler);
    }

    public GetUserRoles(userName, errorHandler, successHandler): JQueryXHR {

        var dataArgs = { authenticationCookie: this._authentication, username: userName };
        return super.DoPostGeneralCall("GetUserRoles", dataArgs, errorHandler, successHandler);
    }

    public GetUserPermissions(userName, errorHandler, successHandler): JQueryXHR {

        var dataArgs = "name=" + userName;
        return super.DoGetGeneralCall("GetUserPermissions", dataArgs, errorHandler, successHandler, false);
    }

    public DeleteUser(
        username: string,
        errorHandler,
        successHandler
        ) {

        var dataArgs = {
            authenticationCookie: this._authentication,
            userName: username,
            userData: null
        };
        return super.DoPostGeneralCall("DeleteUser", dataArgs, errorHandler, successHandler);
    }

    public CreateUserExt(
        username: string,
        password: string,
        adminUsername: string,
        adminPassword: string,
        isAdmin: boolean,
        permissions: string[],
        roles: string[],
        options: CreateUserOptions,
        errorHandler,
        successHandler
        ) {

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
            return super.DoPostGeneralCall("CreateUserExt", dataArgs, errorHandler, successHandler);
    }
};