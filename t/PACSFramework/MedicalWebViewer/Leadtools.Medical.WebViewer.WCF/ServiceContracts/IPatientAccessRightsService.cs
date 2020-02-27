// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Leadtools.Medical.WebViewer.DataContracts;
using System.ServiceModel.Web;

namespace Leadtools.Medical.WebViewer.ServiceContracts
{
   /// <summary>
   /// The service contract for the patient Access rights service
   /// </summary>
   [ServiceContract]
   public interface IPatientAccessRightsService
   {
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
#if LEADTOOLS_V19_OR_LATER
      void GrantUserPatients( string authenticationCookie,  string user, List<string> patientIds, ExtraOptions extraOptions) ;
#endif
      void GrantUserAccess ( string authenticationCookie,  UserPermissions userAccess, ExtraOptions extraOptions ) ;

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void DenyUserAccess ( string authenticationCookie, UserPermissions userAccess, ExtraOptions extraOptions ) ;

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
#if LEADTOOLS_V19_OR_LATER
      void GrantRolePatients(string authenticationCookie, string role, List<string> patientIds, ExtraOptions extraOptions);
#endif
      void GrantRoleAccess ( string authenticationCookie, RolePermissions roleAccess, ExtraOptions extraOptions ) ;


      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      void DenyRoleAccess ( string authenticationCookie, RolePermissions roleAccess, ExtraOptions extraOptions ) ;

      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      UserPermissions[]  GetUserAccess ( string authenticationCookie, string user, ExtraOptions extraOptions ) ;
      
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      RolePermissions[] GetRoleAccess ( string authenticationCookie, string role, ExtraOptions extraOptions ) ;

#if LEADTOOLS_V19_OR_LATER
      [OperationContract]
      [WebInvokeAttribute(Method = "POST", BodyStyle = WebMessageBodyStyle.WrappedRequest, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
      RolePermissions[] GetRolesAccess(string authenticationCookie, List<string> roles, ExtraOptions extraOptions);
#endif  
   }
}
