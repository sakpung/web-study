// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using Leadtools.Medical.WebViewer.ExternalControl;
using Leadtools.Medical.WebViewer.DataContracts;

namespace Leadtools.Medical.WebViewer.ExternalControl
{
   [DataContract]
   public class Permission
   {
      [DataMember]
      public string Name { get; set; }
      [DataMember]
      public string FriendlyName { get; set; }
      [DataMember]
      public string Description { get; set; }
   }
   [DataContract]
   public class Role
   {
      [DataMember]
      public string Name { get; set; }
      [DataMember]
      public List<string> AssignedPermissions { get; set; }
      [DataMember]
      public string Description { get; set; }
   }

   [DataContract]
   class UserCredentials
   {
      [DataMember]
      public string userName = "";
      [DataMember]
      public string password = "";
      [DataMember]
      public string userData = "";

      public string ToJSON()
      {
         return "{\"userName\":\"" + userName + "\", \"password\":\"" + password + "\", \"userData\":\"" + userData + "\"}";
      }
   }

#region utilities
class JsonUtil
{
   static public void WriteJsonParam<T>(T obj, Stream stream, string name)
   {
      DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T), name);
      XmlDictionaryWriter w = JsonReaderWriterFactory.CreateJsonWriter(stream);
      w.WriteStartElement("root");
      w.WriteAttributeString("type", "object");
      serializer.WriteObject(w, obj);
      w.WriteEndElement();
      w.Flush();
   }
   
   public static T ParseJsonResult<T>(WebResponse response)
   {
      Stream responseStream = response.GetResponseStream();

      Int64 nLength = response.ContentLength;
      byte[] buffer = new byte[nLength];

      Int64 nChunk = (1024 > nLength) ? nLength : 1024;
      Int64 nRead = responseStream.Read(buffer, 0, (int)nChunk);
      while (nRead < nLength)
      {
         nChunk = (1024 > (nLength - nRead)) ? (nLength - nRead) : 1024;
         nRead += responseStream.Read(buffer, (int)nRead, (int)nChunk);
      }
            
      string json = Encoding.ASCII.GetString(buffer, 0, buffer.Length);
      
      JavaScriptSerializer ser = new JavaScriptSerializer();      
      T tResult = ser.Deserialize<T>(json);

      return tResult;
   }

   public static T POSTCallJson<T>(string ServiceUrl, string methodname, byte[] parameters)
   {
      WebRequest request = WebRequest.Create(ServiceUrl + "/" + methodname);

      request.Method = "POST";
      request.ContentType = "application/json";

      if (null != parameters)
      {
         Stream requestStream = request.GetRequestStream();
         requestStream.Write(parameters, 0, parameters.Length);
         requestStream.Close();
      }
      else
      {
         request.ContentLength = 0;
      }

      return ParseJsonResult<T>(request.GetResponse());
   }

   public static void POSTCallJson(string ServiceUrl, string methodname, byte[] parameters)
   {
      WebRequest request = WebRequest.Create(ServiceUrl + "/" + methodname);

      request.Method = "POST";
      request.ContentType = "application/json";

      if (null != parameters)
      {
         Stream requestStream = request.GetRequestStream();
         requestStream.Write(parameters, 0, parameters.Length);
         requestStream.Close();
      }
      else
      {
         request.ContentLength = 0;
      }

      request.GetResponse();
   }
}
#endregion


}



 #region data contracts


//[DataContract]
//public class QueryOptions
//{
//   // Patients info
//   [DataMember]
//   internal PatientsQueryOptions PatientsOptions { get; set; }

//   [DataMember]
//   internal StudiesQueryOptions StudiesOptions { get; set; }

//   [DataMember]
//   internal SeriesQueryOptions SeriesOptions { get; set; }

//   [DataMember]
//   internal InstancesQueryOptions InstancesOptions { get; set; }
//}
//[DataContract]
//internal class PatientsQueryOptions
//{
//   [DataMember]
//   public string PatientName { get; set; }
//   [DataMember]
//   public string PatientID { get; set; }
//   [DataMember]
//   public string Sex { get; set; }
//   [DataMember]
//   public string BirthDate { get; set; }
//}
//[DataContract]
//internal class StudiesQueryOptions
//{
//   [DataMember]
//   public string StudyID { get; set; }
//   [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
//   [DataMember]
//   public string[] ModalitiesInStudy { get; set; }
//   [DataMember]
//   public string AccessionNumber { get; set; }
//   [DataMember]
//   public string ReferDoctorName { get; set; }
//   [DataMember]
//   public string StudyDateStart { get; set; }
//   [DataMember]
//   public string StudyDateEnd { get; set; }
//   [DataMember]
//   public string StudyTimeStart { get; set; }
//   [DataMember]
//   public string StudyTimeEnd { get; set; }
//   [DataMember]
//   public string StudyInstanceUID { get; set; }
//}
//[DataContract]
//internal class SeriesQueryOptions
//{
//   [DataMember]
//   public string Modality { get; set; }
//   [DataMember]
//   public string SeriesNumber { get; set; }
//   [DataMember]
//   public string SeriesInstanceUID { get; set; }
//}
//[DataContract]
//internal class InstancesQueryOptions
//{
//   [DataMember]
//   public string InstanceNumber { get; set; }
//   [DataMember]
//   public string SOPInstanceUID { get; set; }
//}
//[DataContract]
//internal class ExtraOptions
//{
//   [DataMember]
//   public string UserData { get; set; }

//   [DataMember]
//   public string UserData2 { get; set; }

//   [DataMember]
//   public string UserData3 { get; set; }
//}
//[DataContract]
//internal class UserPermissions
//{
//   [DataMember]
//   public string User { get; set; }
//   [DataMember]
//   public string PatientId { get; set; }
//}
#endregion


namespace Leadtools.Medical.WebViewer.ExternalControl.Service
{
   internal class ArchiveServiceProxy
   {
 string ___AuthenticationToken = string.Empty;

      public string AuthenticationToken
      {
         get
         {
            return ___AuthenticationToken;
         }
         private set
         {
            ___AuthenticationToken = value;
         }
      }

      private void ValidateToken()
      {
         if (string.IsNullOrEmpty(AuthenticationToken))
         {
            throw new Exception("User not authenticated.");
         }
      }

      public ArchiveServiceProxy(string serviceUrl, string _AuthenticationToken)
      {
         ServiceUrl = serviceUrl;
         AuthenticationToken = _AuthenticationToken;
      }

      public string ServiceUrl { get; set; }

      private static ExtraOptions BuildExtraOptions(int maxQueryResults)
      {
         ExtraOptions extraOptions = new ExtraOptions();
         if (maxQueryResults > 0)
         {
            extraOptions.UserData = maxQueryResults.ToString();
         }
         return extraOptions;
      }

   
       static T PostJson<T>(string url, object args)
      {
         WebRequest request = WebRequest.Create(url);

         request.Method = "POST";

         Stream requestStream = request.GetRequestStream();

         JavaScriptSerializer serializer = new JavaScriptSerializer();

         string jsonMessage = serializer.Serialize(args);

         byte[] jsonEncode = Encoding.UTF8.GetBytes(jsonMessage);

         request.ContentType = "application/json";

         requestStream.Write(jsonEncode, 0, jsonEncode.Length);
         requestStream.Close();

         return JsonUtil.ParseJsonResult<T>(request.GetResponse());
      }

      // maxQueryResults: 0 returns all results
      //                : greater than 0 returns a maximum of maxQueryResults
      public PatientData[] FindPatients(int maxQueryResults, string patientId=null)
      {
         try
         {
            ValidateToken();

            var options = new QueryOptions();
            options.PatientsOptions = new PatientsQueryOptions();
            if (string.IsNullOrEmpty(patientId))
               options.PatientsOptions.PatientName = "*";
            else
               options.PatientsOptions.PatientID = patientId;

            var extraOptions = BuildExtraOptions(maxQueryResults);

            var args = new { authenticationCookie = AuthenticationToken, options = options, extraOptions = extraOptions } ;
            
            var FindPatientsResult = PostJson<IList<PatientData>>( ServiceUrl + "/FindPatients", args);

            return FindPatientsResult.ToArray();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public StudyData[] FindStudies(QueryOptions options, int maxQueryResults)
      {
         try
         {
            ValidateToken();

            Byte[] parameters = null;
            {
               using (MemoryStream ms = new MemoryStream())
               {
                  JsonUtil.WriteJsonParam<string>(AuthenticationToken, ms, "authenticationCookie");

                  JsonUtil.WriteJsonParam<QueryOptions>(options, ms, "options");

                  JsonUtil.WriteJsonParam<ExtraOptions>(BuildExtraOptions(maxQueryResults), ms, "extraOptions");

                  parameters = ms.ToArray();
               }
            }

            IList<StudyData> FindStudiesResult = null;
            FindStudiesResult = JsonUtil.POSTCallJson<IList<StudyData>>(ServiceUrl, "FindStudies", parameters);

            return FindStudiesResult.ToArray();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public SeriesData[] FindSeries(QueryOptions options, int maxQueryResults)
      {
         try
         {
            ValidateToken();

            Byte[] parameters = null;
            {
               using (MemoryStream ms = new MemoryStream())
               {
                  JsonUtil.WriteJsonParam<string>(AuthenticationToken, ms, "authenticationCookie");

                  JsonUtil.WriteJsonParam<QueryOptions>(options, ms, "options");

                  JsonUtil.WriteJsonParam<ExtraOptions>(BuildExtraOptions(maxQueryResults), ms, "extraOptions");

                  parameters = ms.ToArray();
               }
            }

            IList<SeriesData> FindSeriesResult = null;
            FindSeriesResult = JsonUtil.POSTCallJson<IList<SeriesData>>(ServiceUrl, "FindSeries", parameters);

            return FindSeriesResult.ToArray();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public InstanceData[] FindInstances(QueryOptions options, int maxQueryResults)
      {
         try
         {
            ValidateToken();

            Byte[] parameters = null;
            {
               using (MemoryStream ms = new MemoryStream())
               {
                  JsonUtil.WriteJsonParam<string>(AuthenticationToken, ms, "authenticationCookie");

                  JsonUtil.WriteJsonParam<QueryOptions>(options, ms, "options");

                  ExtraOptions extraOptions = BuildExtraOptions(maxQueryResults);
                  extraOptions.UserData3 = "NoSort";

                  JsonUtil.WriteJsonParam<ExtraOptions>(extraOptions, ms, "extraOptions");

                  parameters = ms.ToArray();
               }
            }

            IList<InstanceData> FindInstancesResult = null;
            FindInstancesResult = JsonUtil.POSTCallJson<IList<InstanceData>>(ServiceUrl, "FindInstances", parameters);

            return FindInstancesResult.ToArray();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
   }

   internal class PatientAccessRightsProxy
   {
      public string AuthenticationToken
      {
         get;
         private set;
      }

      private void ValidateToken()
      {
         if (string.IsNullOrEmpty(AuthenticationToken))
         {
            throw new Exception("User not authenticated.");
         }
      }

      public PatientAccessRightsProxy(string serviceUrl, string _AuthenticationToken)
      {
         ServiceUrl = serviceUrl;
         AuthenticationToken = _AuthenticationToken;
      }

      public string ServiceUrl { get; set; }

      public UserPermissions[] GetUserAccess(string username)
      {
         try
         {
            ValidateToken();

            Byte[] parameters = null;
            {
               using (MemoryStream ms = new MemoryStream())
               {
                  JsonUtil.WriteJsonParam<string>(AuthenticationToken, ms, "authenticationCookie");
                  JsonUtil.WriteJsonParam<string>(username, ms, "user");
                  JsonUtil.WriteJsonParam<ExtraOptions>(new ExtraOptions(), ms, "extraOptions");

                  parameters = ms.ToArray();
               }
            }

            IList<UserPermissions> GetUserAccessResult = null;
            GetUserAccessResult = JsonUtil.POSTCallJson<IList<UserPermissions>>(ServiceUrl, "GetUserAccess", parameters);

            return GetUserAccessResult.ToArray();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void GrantUserAccess(UserPermissions up)
      {
         try
         {
            ValidateToken();

            Byte[] parameters = null;
            {
               using (MemoryStream ms = new MemoryStream())
               {
                  JsonUtil.WriteJsonParam<string>(AuthenticationToken, ms, "authenticationCookie");
                  JsonUtil.WriteJsonParam<UserPermissions>(up, ms, "userAccess");
                  JsonUtil.WriteJsonParam<ExtraOptions>(new ExtraOptions(), ms, "extraOptions");

                  parameters = ms.ToArray();
               }
            }

            JsonUtil.POSTCallJson(ServiceUrl, "GrantUserAccess", parameters);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }


      public void DenyUserAccess(UserPermissions up)
      {
         try
         {
            ValidateToken();

            Byte[] parameters = null;
            {
               using (MemoryStream ms = new MemoryStream())
               {
                  JsonUtil.WriteJsonParam<string>(AuthenticationToken, ms, "authenticationCookie");
                  JsonUtil.WriteJsonParam<UserPermissions>(up, ms, "userAccess");
                  JsonUtil.WriteJsonParam<ExtraOptions>(new ExtraOptions(), ms, "extraOptions");

                  parameters = ms.ToArray();
               }
            }

            JsonUtil.POSTCallJson(ServiceUrl, "DenyUserAccess", parameters);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
   }

    public class CustomTuple<T1, T2>
    {
       public T1 Key { get; private set; }
       public T2 Value { get; private set; }
       internal CustomTuple(T1 item1, T2 item2)
       {
          Key = item1;
          Value = item2;
       }
    }
   internal class OptionsServiceProxy
   {

      public OptionsServiceProxy(string serviceUrl, string authenticationToken)
      {
         ServiceUrl = serviceUrl;
         AuthenticationToken = authenticationToken;
      }

      public string ServiceUrl { get; set; }
      public string AuthenticationToken{get;private set;}

      public bool IsAuthenticated()
      {
         return !string.IsNullOrEmpty(AuthenticationToken);
      }
      
      private void ValidateToken()
      {
         if (string.IsNullOrEmpty(AuthenticationToken))
         {
            throw new Exception("User not authenticated.");
         }
      }

      static void PostJson(string url, object args)
      {
         WebRequest request = WebRequest.Create(url);

         request.Method = "POST";

         Stream requestStream = request.GetRequestStream();

         JavaScriptSerializer serializer = new JavaScriptSerializer();

         string jsonMessage = serializer.Serialize(args);

         byte[] jsonEncode = Encoding.UTF8.GetBytes(jsonMessage);

         request.ContentType = "application/json";

         requestStream.Write(jsonEncode, 0, jsonEncode.Length);
         requestStream.Close();

         try
         {

             request.GetResponse();
         }
         catch
         {
            throw;
         }
      }

      public void SetOption(string optionName, string optionValue)
      {
         ValidateToken();

         try
         {
            var args = new { authenticationCookie = AuthenticationToken, optionName = optionName, optionValue = optionValue } ;
            
            PostJson( ServiceUrl + "/SaveUserOption", args);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
      public void SetDefOption(string optionName, string optionValue)
      {
         ValidateToken();

         try
         {
            var options = new List<CustomTuple<string, string>>();
            options.Add(new CustomTuple<string,string>(optionName, optionValue));

            var args = new { authenticationCookie = AuthenticationToken, options = options } ;
            
            PostJson( ServiceUrl + "/SaveDefaultOptions", args);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
   }

   internal class AuthenticationServiceProxy
   {
      public AuthenticationServiceProxy(string serviceUrl)
      {
         ServiceUrl = serviceUrl;
      }

      public AuthenticationServiceProxy(string serviceUrl, string authenticationToken)
      {
         ServiceUrl = serviceUrl;
         AuthenticationToken = authenticationToken;
      }

      public string ServiceUrl { get; set; }
      
      static T ParseJsonResult<T>(WebResponse response)
      {
         Stream responseStream = response.GetResponseStream();

         Int64 nLength = response.ContentLength;
         byte[] buffer = new byte[nLength];

         Int64 nChunk = (1024 > nLength) ? nLength : 1024;
         Int64 nRead = responseStream.Read(buffer, 0, (int)nChunk);
         while (nRead < nLength)
         {
            nChunk = (1024 > (nLength - nRead)) ? (nLength - nRead) : 1024;
            nRead += responseStream.Read(buffer, (int)nRead, (int)nChunk);
         }

         string json = Encoding.ASCII.GetString(buffer);

         JavaScriptSerializer ser = new JavaScriptSerializer();
         T Result = ser.Deserialize<T>(json);

         return Result;
      }
      
      T CallJson<T>(string url)
      {
         WebRequest request = WebRequest.Create(ServiceUrl + url);

         request.Method = "GET";

         request.ContentType = "application/json";

         return ParseJsonResult<T>(request.GetResponse());
      }
      void CallJson(string url)
      {
         WebRequest request = WebRequest.Create(ServiceUrl + url);

         request.Method = "GET";

         request.ContentType = "application/json";

         request.GetResponse();
      }     

      static T PostJson<T>(string url, object args)
      {
         WebRequest request = WebRequest.Create(url);

         request.Method = "POST";

         Stream requestStream = request.GetRequestStream();

         JavaScriptSerializer serializer = new JavaScriptSerializer();

         string jsonMessage = serializer.Serialize(args);

         byte[] jsonEncode = Encoding.UTF8.GetBytes(jsonMessage);

         request.ContentType = "application/json";

         requestStream.Write(jsonEncode, 0, jsonEncode.Length);
         requestStream.Close();

         try
         {

            return ParseJsonResult<T>(request.GetResponse());
         }
         catch
         {
            throw;
         }
      }

      static void PostJson(string url, object args)
      {
         WebRequest request = WebRequest.Create(url);

         request.Method = "POST";

         Stream requestStream = request.GetRequestStream();

         JavaScriptSerializer serializer = new JavaScriptSerializer();

         string jsonMessage = serializer.Serialize(args);

         byte[] jsonEncode = Encoding.UTF8.GetBytes(jsonMessage);

         request.ContentType = "application/json";

         requestStream.Write(jsonEncode, 0, jsonEncode.Length);
         requestStream.Close();

         try
         {

             request.GetResponse();
         }
         catch
         {
            throw;
         }
      }

      public string[] GetAllUsers()
      {
         try
         {
            ValidateToken();

            var Result = CallJson<List<string>> ("/GetAllUsers?auth=" + Uri.EscapeDataString(AuthenticationToken));

            return Result.ToArray();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void DeleteUser(string UserName)
      {
         ValidateToken();

         try
         {
            var args = new { authenticationCookie = AuthenticationToken, userName = UserName, userData = "" } ;
            
            PostJson( ServiceUrl + "/DeleteUser", args);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public bool ResetPassword(string username, string newPassword, string userData)
      {
         ValidateToken();

         try
         {
            var args = new { authenticationCookie = AuthenticationToken, userName = username, newPassword = newPassword, userData = ""} ;
            var Result = PostJson<bool>( ServiceUrl + "/ResetPassword", args);
            return Result;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public bool ChangePassword(string authenticationToken, string username, string oldPassword, string newPassword, string userData)
      {
         ValidateToken();

         try
         {
            var args = new { authenticationCookie = AuthenticationToken, userName = username, oldPassword = oldPassword, newPassword = newPassword, userData = ""} ;
            var Result = PostJson<bool>(ServiceUrl + "/ChangePassword", args);
            return Result;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public bool HasPermission(string username, string permission, string userData)
      {
         try
         {
            var Result = CallJson<bool>("/HasPermission?" + "name=" + Uri.EscapeDataString(username) + "&permit=" + Uri.EscapeDataString(permission));
            return Result;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public string[] GetUserPermissions(string username, string userData)
      {
         try
         {
            var Result = CallJson< List<string>>("/GetUserPermissions?" + "name=" + Uri.EscapeDataString(username));
            return Result.ToArray();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void GrantPermission(string username, string permission, string userData)
      {
         ValidateToken();
         try
         {
            var args = new { authenticationCookie = AuthenticationToken, username = username, permission = permission, userData = "" } ;
            PostJson(ServiceUrl + "/GrantPermission", args ) ;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void DenyPermission(string username, string permission, string userData)
      {
         ValidateToken();
         try
         {
            var args = new { authenticationCookie = AuthenticationToken, username = username, permission = permission, userData = ""} ;
            PostJson( ServiceUrl + "/DenyPermission", args ) ;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public Leadtools.Medical.WebViewer.ExternalControl.Role[] GetRoles()
      {
         try
         {
            var Result = JsonUtil.POSTCallJson < List<Leadtools.Medical.WebViewer.ExternalControl.Role >> (ServiceUrl, "GetRoles", null);

            return Result.ToArray();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public Leadtools.Medical.WebViewer.ExternalControl.Permission[] GetPermissions()
      {
         try
         {
            var Result = JsonUtil.POSTCallJson< List<Leadtools.Medical.WebViewer.ExternalControl.Permission>>(ServiceUrl, "GetPermissions", null);

            return Result.ToArray();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public string[] GetUserRoles(string username, string userData)
      {
         try
         {
            Byte[] parameters = null;
            {
               using (MemoryStream ms = new MemoryStream())
               {
                  JsonUtil.WriteJsonParam<string>(username, ms, "username");
                  JsonUtil.WriteJsonParam<string>(userData, ms, "userData");
                  parameters = ms.ToArray();
               }
            }

            var Result = JsonUtil.POSTCallJson<List<string>>(ServiceUrl, "GetUserRoles", parameters);
            return Result.ToArray();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public string[] GetRolesNames()
      {
         try
         {
            var Result = JsonUtil.POSTCallJson<List<string>>(ServiceUrl, "GetRolesNames", null);

            return Result.ToArray();
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public Leadtools.Medical.WebViewer.ExternalControl.Role GetRole(string roleName)
      {
         try
         {
            Byte[] parameters = null;
            {
               using (MemoryStream ms = new MemoryStream())
               {
                  JsonUtil.WriteJsonParam<string>(roleName, ms, "roleName");
                  parameters = ms.ToArray();
               }
            }

            var Result = JsonUtil.POSTCallJson<Leadtools.Medical.WebViewer.ExternalControl.Role>(ServiceUrl, "GetRole", parameters);
            return Result;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void GrantRole(string username, string role, string userData)
      {
         ValidateToken();
         try
         {
            var args = new { authenticationCookie = AuthenticationToken, username = username, role = role, userData = "" };
            PostJson(ServiceUrl + "/GrantRole", args);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void DenyRole(string username, string role, string userData)
      {
         ValidateToken();
         try
         {
            var args = new { authenticationCookie = AuthenticationToken, username = username, role = role, userData = "" };
            PostJson(ServiceUrl + "/DenyRole", args);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void CreateRole(string roleName)
      {
         ValidateToken();
         try
         {
            Leadtools.Medical.WebViewer.ExternalControl.Role role = new Leadtools.Medical.WebViewer.ExternalControl.Role() { Name = roleName };

            var args = new { authenticationCookie = AuthenticationToken, role = role };
            PostJson(ServiceUrl + "/CreateRole", args);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void ModifyRole(Leadtools.Medical.WebViewer.ExternalControl.Role role)
      {
         ValidateToken();
         try
         {
            var args = new { authenticationCookie = AuthenticationToken, role = role };
            PostJson(ServiceUrl + "/UpdateRolePermissions", args);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void DeleteRole(string role )
      {
         ValidateToken();
         try
         {
            var args = new { authenticationCookie = AuthenticationToken, roleName = role };
            PostJson(ServiceUrl + "/DeleteRole", args);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public void CreateUser(string UserName, string password)
      {
         ValidateToken();

         try
         {
            var args = new { authenticationCookie= AuthenticationToken, userName = UserName, password =password, userData = ""};
            
            PostJson( ServiceUrl + "/CreateUser", args);
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }
      
      public AuthenticationInfo GetAuthenticationInfo(string authenticationCookie, string userData)
      {
         AuthenticationToken = authenticationCookie ;
         
         ValidateToken();
         
         var args = new { authenticationCookie = AuthenticationToken, userData = "" } ;
         
         var result = PostJson< AuthenticationInfo>( ServiceUrl + "/GetAuthenticationInfo", args ) ;
         
         return result;
      }

      public bool IsAuthenticated(string userName, string password, out string authentication)
      {
         authentication = "";

         UserCredentials credentials = new UserCredentials();

         credentials.userName = userName;
         credentials.password = password;

         if (credentials.userName.Contains('\\') && !credentials.userName.Contains("\\\\"))
         {
             credentials.userName = credentials.userName.Replace("\\", "\\\\");
         }

         WebRequest request = WebRequest.Create(ServiceUrl + "/AuthenticateUser");

         request.Method = "POST";

         Stream requestStream = request.GetRequestStream();

         string jsonMessage = credentials.ToJSON();

         byte[] jsonEncode = Encoding.UTF8.GetBytes(jsonMessage);

         request.ContentType = "application/json";

         requestStream.Write(jsonEncode, 0, jsonEncode.Length);
         requestStream.Close();

         try
         {
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            Stream responseStream = response.GetResponseStream();

            if (response.ContentLength > 0)
            {
               byte[] buffer = new byte[response.ContentLength];

               responseStream.Read(buffer, 0, buffer.Length);

               authentication = Encoding.ASCII.GetString(buffer);
               AuthenticationToken = authentication;
               return response.StatusDescription == "OK";
            }

            return false;
         }
         catch (Exception )
         {
            return false;
         }
      }

      public string ValidatePassword(string password, string userData)
      {
         try
         {
            var args = new { password = password, userData = "" };
            var result = PostJson<string>(ServiceUrl + "/ValidatePassword", args);

            return result;
         }
         catch (Exception ex)
         {
            throw ex;
         }        
      }

      public bool IsPasswordExpired(string userName)
      {
         try
         {            
            var Result = CallJson<bool>("/IsPasswordExpired?userName=" + Uri.EscapeDataString(userName));

            return Result;
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public bool IsAuthenticated()
      {
         return !string.IsNullOrEmpty(AuthenticationToken);
      }

      public string AuthenticationToken
      {
         get;
         private set;
      }

      private void ValidateToken()
      {
         if (string.IsNullOrEmpty(AuthenticationToken))
         {
            throw new Exception("User not authenticated.");
         }
      }
   }
   
   internal class AuthenticationInfo
   {
      public AuthenticationInfo(){}

      public string Expires { get; set; }
      
      public ExtraOptions ExtraOptions { get; set; }
      
      public string UserName { get; set; }
   }
}
