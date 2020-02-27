// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Description;
using System.Diagnostics;
using Leadtools.Medical.WebViewer.ExternalControl.Service;
using System.Web;
using System.Threading;
using Leadtools.Wcf;
using System.Runtime.Serialization;
using Leadtools.Medical.WebViewer.DataContracts;
using Leadtools.Demos;
using System.Runtime.Serialization.Json;

namespace Leadtools.Medical.WebViewer.ExternalControl
{

   internal sealed class ControllerCommandNames
   {
      public static readonly string LogOut = "LogOut";
      public static readonly string Close = "Close";
      public static readonly string FindPatient = "FindPatient";
      public static readonly string GetCurrentPatient = "GetCurrentPatient";
      public static readonly string ShowPatient = "ShowPatient";
      public static readonly string ShowStudy = "ShowStudy";
      public static readonly string ShowSeries = "ShowSeries";
      public static readonly string ShowInstance = "ShowInstance";
      public static readonly string UpdatePatient = "UpdatePatient";
      public static readonly string AddPatient = "AddPatient";
      public static readonly string DeletePatient = "DeletePatient";
      public static readonly string SearchImage = "SearchImage";
      public static readonly string GetImage = "GetImage";
      public static readonly string EndAssociation = "EndAssociation";
   }

   internal sealed class ControllerReturnType
   {
      public static readonly string GenericActionStatus = "GenericActionStatus";
   }

   internal sealed class GenericActionStatus
   {
      public static readonly string Success = "Success";
      public static readonly string Failure = "Failure";
      public static readonly string Ok = "OK";
   }

   internal sealed class WebViewerAuthenticationInfo
   {
      public bool IsLoggedIn { get; private set; }
      public String Token { get; private set; }
      public String UserName { get; private set; }
      public String Expires { get; private set; }
      public ExtraOptions ExtraOptions { get; private set; }


      public WebViewerAuthenticationInfo()
      {
         this.IsLoggedIn = false;
         this.UserName = String.Empty;
         this.Token = String.Empty;
         this.Expires = string.Empty;
         this.ExtraOptions = null;
      }

      public WebViewerAuthenticationInfo(Leadtools.Medical.WebViewer.ExternalControl.Service.AuthenticationInfo info, String token)
      {
         this.IsLoggedIn = true;
         this.UserName = info.UserName;
         this.Expires = info.Expires;
         this.ExtraOptions = info.ExtraOptions;
         this.Token = token;
      }
   }

   public enum MedicalWebViewerBrowser
   {
      Default,
      InternetExplorer,
      GoogleChrome,
      Firefox,
      Opera,
      Edge,
      User
   }

   public enum ControllerReturnCode : long
   {
      InvalidViewerUrl = -7,
      InvalidServiceUrl = -6,
      UnknownError = -5,
      AlreadyInitialized = -4,
      TimedOut = -3,
      AuthenticationFailure = -2,
      NotProperlyInitiated = -1,
      Failure = 0,
      Success = 1,
      Undefined = 2,
   }

   public enum FindPatientOptions : long
   {
      All = 0,
      WithInstances = 1,
   }


   [Flags]
   public enum CreateUserOptions : long
   {
      None = 0x00,
      CreateUser = 0x01,
      UpdateUser = 0x02,
      Login = 0x04,
      UpdatePassword = 0x10,
      UpdatePermissions = 0x20,
      UpdateRoles = 0x40,
   }

   [DataContract]
   class AuthenticationErrorObject
   {
      [DataMember]
      public string Detail { get; set; }
      [DataMember]
      public string FaultType { get; set; }
      [DataMember]
      public string Message { get; set; }
   }

   public class MedicalWebViewerExternalController
   {
      bool _aspService = false;
      bool _started = false;
      ServiceHost _serviceHost;
      Uri _webViewerURL = null;
      string _webViewerDomain = String.Empty;
      String _browserApplicationName = String.Empty;
      String _newWindowArgs = String.Empty;
      MedicalWebViewerBrowser _selectedBrowser = MedicalWebViewerBrowser.Default;
      WebViewerAuthenticationInfo _authenticationInfo = new WebViewerAuthenticationInfo();
      private Process _browserProcess;

      private int _externalControlPort;

      private ControllerReturnCode _lastPropertyCallReturnCode;
      internal ControllerReturnCode LastPropertyCallReturnCode { get { return _lastPropertyCallReturnCode; } }

      internal static MedicalWebViewerExternalController CurrentInstance { get; set; }


      readonly System.Timers.Timer _heartBeatTimer = new System.Timers.Timer(2000);

      private const int DEFAULT_TIMEOUT = 5; //seconds
      private TimeSpan _timeoutTimeSpan;
      private int _timeout;
      public int Timeout
      {
         get
         {
            return _timeout;
         }
         set
         {
            _timeout = value;
            _timeoutTimeSpan = new TimeSpan(0, 0, _timeout);
         }
      }

      public bool AspService
      {
         get { return _aspService; }
         set { _aspService = value; }
      }

      public event EventHandler<HeartBeatEventArgs> HeartBeatEvent;
      public event EventHandler<LogoutEventArgs> LogoutEvent;


      private string _serviceRoot;

      public string ServiceRoot
      {
         get { return _serviceRoot; }
         set { _serviceRoot = value; }
      }

      public bool IsStarted
      {
         get { return _started; }
      }

      public bool IsLoggedIn
      {
         get
         {
            if (_authenticationInfo == null)
               return false;

            return _authenticationInfo.IsLoggedIn;
         }
      }

      public Action<string, MedicalWebViewerExternalController> UserWebBrowser { get; set; }

      private void SetUpHeartBeatTimer()
      {
         _heartBeatTimer.Elapsed += new System.Timers.ElapsedEventHandler(_heartBeatTimer_Elapsed);
      }

      private int _lastHeartBeatCount = 0;
      private int _currentHeartBeatCount = 0;
      void _heartBeatTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
      {
         if (_currentHeartBeatCount < 5)
         {
            return;
         }

         if (_lastHeartBeatCount == _currentHeartBeatCount)
         {
            // _browserProcess_Exited(this, null);
         }
         _lastHeartBeatCount = _currentHeartBeatCount;
      }

      private MedicalWebViewerExternalController()
      {
         SetUpHeartBeatTimer();
      }

      public MedicalWebViewerExternalController(string webViewerURL)
      {
         SetUpHeartBeatTimer();
         this.Timeout = DEFAULT_TIMEOUT;
         setViewerURL(webViewerURL);
      }

      public event EventHandler<EventArgs> BrowserClosed;

      void _browserProcess_Exited(object sender, EventArgs e)
      {
         if (BrowserClosed != null)
         {
            _authenticationInfo = new WebViewerAuthenticationInfo();
            // Shutdown();
            BrowserClosed(sender, new EventArgs());
         }
      }


      public string ViewerURL
      {
         get
         {
            return _webViewerURL.OriginalString;
         }
         set
         {
            //if (IsLocalAndInvalid(value))
            //{
            //    throw new Exception(string.Format("'ViewerURL' is not a valid virtual directory: '{0}'", value));
            //}

            _lastPropertyCallReturnCode = setViewerURL(value);
         }
      }

      private const string localHostPrefix = @"http://localhost/";

      private static bool IsLocalAndInvalid(string value)
      {
         bool ret = false;
         string url = value.Trim();
         if (url.ToLower().StartsWith(localHostPrefix))
         {
            string virtualDirectory = url.Substring(localHostPrefix.Length);
            if (virtualDirectory.EndsWith("/"))
               virtualDirectory = virtualDirectory.Substring(0, virtualDirectory.Length - 1);
            try
            {
               IISTools.VirtualDirectory serviceVirtualDir = IISTools.VirtualDirectory.Find(Environment.MachineName, virtualDirectory);
               if (null == serviceVirtualDir)
               {
                  ret = true;
               }
            }
            catch { }//access might be denied
         }
         return ret;
      }

      string _serviceURL = string.Empty;
      public string ServiceURL
      {
         get
         {
            return _serviceURL;
         }
         set
         {
            //if (IsLocalAndInvalid(value))
            //{
            //    throw new Exception(string.Format("'ServiceURL' is not a valid virtual directory: '{0}'", value));
            //}
            _serviceURL = value;
         }
      }

      private ControllerReturnCode setViewerURL(string webViewerURL)
      {
         string url = webViewerURL;
         if (!webViewerURL.EndsWith("/"))
         {
            url += "/";
         }

         if (!webViewerURL.StartsWith("http://") && !webViewerURL.StartsWith("https://"))
         {
            url = url.Insert(0, "http://");
         }

         try
         {
            _webViewerURL = new Uri(url);
            _webViewerDomain = _webViewerURL.GetLeftPart(UriPartial.Authority);
            return ControllerReturnCode.Success;
         }
         catch
         {
            return ControllerReturnCode.Failure;
         }
      }

      private static string Combine(string uri1, string uri2)
      {
         uri1 = uri1.TrimEnd('/');
         uri2 = uri2.TrimStart('/');
         return string.Format("{0}/{1}", uri1, uri2);
      }

      private string AuthenticationServiceUrl
      {
         get
         {
            bool ret = IsLocalAndInvalid(_serviceURL);
            if (ret)
            {
               return string.Empty;
            }
            if (AspService)
               return Combine(_serviceURL, "api/auth");
            else
               return Combine(_serviceURL, "AuthenticationService.svc");
         }
      }

      private string OptionsServiceUrl
      {
         get
         {
            bool ret = IsLocalAndInvalid(_serviceURL);
            if (ret)
            {
               return string.Empty;
            }
            if (AspService)
               return Combine(_serviceURL, "api/options");
            else
               return Combine(_serviceURL, "OptionsService.svc");
         }
      }

      private string ArchiveServiceUrl
      {
         get
         {
            bool ret = IsLocalAndInvalid(_serviceURL);
            if (ret)
            {
               return string.Empty;
            }
            if (AspService)
               return Combine(_serviceURL, "api/query");
            else
               return Combine(_serviceURL, "ObjectQueryService.svc");

         }
      }

      private AuthenticationServiceProxy GetAuthenticationServiceProxy()
      {
         string authenticationServiceUrl = AuthenticationServiceUrl;
         if (string.IsNullOrEmpty(authenticationServiceUrl))
         {
            return null;
         }
         return new AuthenticationServiceProxy(AuthenticationServiceUrl);
      }

      private AuthenticationServiceProxy GetAuthenticationServiceProxy(string authenticationToken)
      {
         string authenticationServiceUrl = AuthenticationServiceUrl;
         if (string.IsNullOrEmpty(authenticationServiceUrl))
         {
            return null;
         }
         return new AuthenticationServiceProxy(authenticationServiceUrl, authenticationToken);
      }

      private OptionsServiceProxy GetOptionsServiceProxy(string authenticationToken)
      {
         string optionsServiceUrl = OptionsServiceUrl;
         if (string.IsNullOrEmpty(optionsServiceUrl))
         {
            return null;
         }
         return new OptionsServiceProxy(optionsServiceUrl, authenticationToken);
      }

      private ArchiveServiceProxy GetArchiveServiceProxy(string authenticationToken)
      {
         string archiveServiceUrl = ArchiveServiceUrl;
         if (string.IsNullOrEmpty(archiveServiceUrl))
         {
            return null;
         }

         return new ArchiveServiceProxy(ArchiveServiceUrl, authenticationToken);
      }

      private static AuthenticationErrorObject GetAuthenticationErrorObject(string authenticationToken)
      {
         AuthenticationErrorObject ret = null;

         try
         {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(AuthenticationErrorObject));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(authenticationToken));
            ret = (AuthenticationErrorObject)ser.ReadObject(stream);
         }
         catch (Exception)
         {
            ret = null;
         }

         return ret;
      }

      #region PublicAPI

      // Set the browser in which the viewer will launch when UserLogin() is called.
      #region SetBrowser

      public MedicalWebViewerBrowser SelectedBrowser
      {
         get
         {
            return _selectedBrowser;
         }
         set
         {
            switch (value)
            {
               case MedicalWebViewerBrowser.InternetExplorer:
                  {
                     _browserApplicationName = "iexplore.exe";
                     _newWindowArgs = "";
                  }
                  break;
               case MedicalWebViewerBrowser.Edge:
                  {
                     _browserApplicationName = @"shell:Appsfolder\Microsoft.MicrosoftEdge_8wekyb3d8bbwe!MicrosoftEdge";
                     _newWindowArgs = "";
                  }
                  break;
               case MedicalWebViewerBrowser.GoogleChrome:
                  {
                     _browserApplicationName = "chrome.exe";
                     _newWindowArgs = " --new-window";
                  }
                  break;
               case MedicalWebViewerBrowser.Firefox:
                  {
                     _browserApplicationName = "firefox.exe";
                     _newWindowArgs = " -new-window";
                  }
                  break;
               case MedicalWebViewerBrowser.Opera:
                  {
                     _browserApplicationName = "opera.exe";
                     _newWindowArgs = String.Empty;
                  }
                  break;
               default:
                  {
                     _browserApplicationName = String.Empty;
                  }
                  break;
            }
            _selectedBrowser = value;
         }
      }
      #endregion

      // Initialize and start the ExternalCommandQueueService. 
      #region InitApplication
      public ControllerReturnCode InitApplication(out string applicationName, out string version, int externalControlPort)
      {
         ClearFailureMessage();
         applicationName = "";
         version = "";
         _externalControlPort = externalControlPort;

         if (_webViewerURL != null)
         {
            applicationName = _webViewerURL.OriginalString;
#if LTV20_CONFIG
            version = "20.0";
#elif LTV19_CONFIG
            version = "19.0";
#else
             version = "18.0";
#endif
         }
         else
         {
            return ControllerReturnCode.Failure;
         }


         if (_started)
            return ControllerReturnCode.AlreadyInitialized;

         ControllerReturnCode ret = ControllerReturnCode.Success;
         try
         {
            Uri localAddress = new Uri("http://localhost:" + _externalControlPort + "/ExternalCommandQueueService/");
            _serviceHost = new WebServiceHost(typeof(ExternalCommandQueueService));
            WebHttpBinding binding = new WebHttpBinding();
            ServiceEndpoint endpoint = _serviceHost.AddServiceEndpoint(typeof(IExternalCommandQueueService), binding, localAddress);
            CorsSupportBehavior corsSupport = new CorsSupportBehavior();
            WebHttpBehavior httpBehavior = new WebHttpBehavior();
            endpoint.Behaviors.Add(corsSupport);
            endpoint.Behaviors.Add(httpBehavior);
            CurrentInstance = this;
            _serviceHost.Open();
            _started = true;
         }
         catch (Exception ex)
         {
            ret = ControllerReturnCode.Failure;
            FailureMessage = ex.Message;
         }


         return ret;
      }
      #endregion

      // Log in and launch the viewer.
      #region UserLogin
      public ControllerReturnCode UserLogin(string username,
                                            string password)
      {
         ClearFailureMessage();

         if (IsLocalAndInvalid(ViewerURL))
         {
            FailureMessage = string.Format("The 'WebViewerURL' property is set to a virtual directory does not exist: '{0}'", _webViewerURL);
            return ControllerReturnCode.InvalidViewerUrl;
         }

         try
         {
            AssertStarted();
         }
         catch
         {
            return ControllerReturnCode.NotProperlyInitiated;
         }
         AuthenticationServiceProxy authenticationService = GetAuthenticationServiceProxy();
         if (authenticationService == null)
         {
            FailureMessage = string.Format("The 'ServiceURL' property is set to a virtual directory does not exist: '{0}'", _serviceURL);
            return ControllerReturnCode.InvalidServiceUrl;
         }

         string authenticationToken = String.Empty;
         if (authenticationService.IsAuthenticated(username, password, out authenticationToken))
         {

            AuthenticationErrorObject authenticationError = GetAuthenticationErrorObject(authenticationToken);
            if (authenticationError == null)
            {

               Leadtools.Medical.WebViewer.ExternalControl.Service.AuthenticationInfo info = authenticationService.GetAuthenticationInfo(authenticationToken, String.Empty);
               _authenticationInfo = new WebViewerAuthenticationInfo(info, authenticationToken);
               ExternalCommandQueueService.CurrentInstance.SetWebtViewerAuthenticationInfo(_authenticationInfo);

               ExternalCommandQueueService.CurrentInstance.HeartBeatEvent += new EventHandler<HeartBeatEventArgs>(CurrentInstance_HeartBeatEvent);
               ExternalCommandQueueService.CurrentInstance.LogoutEvent += new EventHandler<LogoutEventArgs>(CurrentInstance_LogoutEvent);
               //Console.WriteLine("Authentication Successful: " + _authenticationInfo.ToString());
               return StartApplication();
            }
            else
            {
               FailureMessage = authenticationError.Message;
            }
         }
         _authenticationInfo = new WebViewerAuthenticationInfo();
         //Console.WriteLine("Authentication Failed");
         return ControllerReturnCode.AuthenticationFailure;
      }

      public ControllerReturnCode SetUserOption(string name, string value)
      {
         if (string.IsNullOrEmpty(name))
         {
            FailureMessage = @"Option name can't be null";
            return ControllerReturnCode.Failure;
         }

         try
         {
            AssertStarted();
            AssertLoggedIn();

            OptionsServiceProxy optionsService = GetOptionsServiceProxy(_authenticationInfo.Token);
            optionsService.SetOption(name, value);

            return ControllerReturnCode.Success;
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }
      }

      public ControllerReturnCode SetDefOption(string name, string value)
      {
         if (string.IsNullOrEmpty(name))
         {
            FailureMessage = @"Option name can't be null";
            return ControllerReturnCode.Failure;
         }

         try
         {
            AssertStarted();
            AssertLoggedIn();

            OptionsServiceProxy optionsService = GetOptionsServiceProxy(_authenticationInfo.Token);
            optionsService.SetDefOption(name, value);

            return ControllerReturnCode.Success;
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }
      }

      void CurrentInstance_LogoutEvent(object sender, LogoutEventArgs e)
      {
         _authenticationInfo = new WebViewerAuthenticationInfo();
         if (this.LogoutEvent != null)
         {
            LogoutEvent(sender, e);
         }
      }

      void CurrentInstance_HeartBeatEvent(object sender, HeartBeatEventArgs e)
      {
         _currentHeartBeatCount = e.Count;
         if (this.HeartBeatEvent != null)
         {
            HeartBeatEvent(sender, e);
         }
      }
      #endregion

      // Log out of the viewer. 
      #region UserLogout
      public ControllerReturnCode UserLogout()
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.LogOut);
         _authenticationInfo = new WebViewerAuthenticationInfo();
         return ControllerReturnCode.Success;
      }
      #endregion

      // Find a patient by PatientID. Provides the patient's first and last name.
      #region FindPatient
      // Find a patient by patientID.  Pass 'null' to get all patients

      public ControllerReturnCode FindPatient(string patientID, FindPatientOptions options, List<PatientInfo> patients)
      {
         ClearFailureMessage();
         return FindPatient(patientID, options, patients, 0);
      }

      public ControllerReturnCode FindPatient(string patientID, FindPatientOptions options, List<PatientInfo> patients, int maxQueryResults)
      {
         ClearFailureMessage();
         if (string.IsNullOrEmpty(patientID))
         {
            return FindAllPatients(patients, maxQueryResults);
         }

         if (patients == null)
         {
            FailureMessage = string.Format(ErrorStrings.InvalidParameter, "'patients' cannot be null");
            return ControllerReturnCode.Failure;
         }
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         AutoResetEvent resetEvent = new AutoResetEvent(false);
         ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.FindPatient, new string[] { patientID, options.ToString() }, resetEvent);

         PatientInfo info = new PatientInfo();
         ControllerReturnCode ret = WaitForGenericResponse(info, resetEvent);
         if (ret == ControllerReturnCode.Success)
         {
            patients.Add(info);
         }
         return ret;
      }
      #endregion

      private ControllerReturnCode FindAllPatients(List<PatientInfo> patients, int maxQueryResults)
      {
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         if (patients == null)
         {
            FailureMessage = "Invalid Parameter: 'patients' cannot be null";
            return ControllerReturnCode.Failure;
         }

         ArchiveServiceProxy archiveService = GetArchiveServiceProxy(_authenticationInfo.Token);
         PatientData[] allPatients = archiveService.FindPatients(maxQueryResults);

         patients.Clear();
         foreach (PatientData p in allPatients)
         {
            PatientInfo info = new PatientInfo(p.ID, p.Name, p.BirthDate, p.Sex, string.Empty, p.Comments);
            patients.Add(info);
         }
         return ControllerReturnCode.Success;
      }

      public ControllerReturnCode FindStudies(string patientId, List<StudyInfo> studies)
      {
         return FindStudies(patientId, studies, 0);
      }

      public ControllerReturnCode FindStudies(string patientId, List<StudyInfo> studies, int maxQueryResults)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         if (studies == null)
         {
            FailureMessage = "Invalid Parameter: 'studies' cannot be null";
            return ControllerReturnCode.Failure;
         }

         ArchiveServiceProxy archiveService = GetArchiveServiceProxy(_authenticationInfo.Token);

         QueryOptions options = new QueryOptions();
         options.PatientsOptions = new PatientsQueryOptions();
         options.PatientsOptions.PatientID = patientId;

         options.StudiesOptions = new StudiesQueryOptions();


         StudyData[] allStudies = archiveService.FindStudies(options, maxQueryResults);

         studies.Clear();
         foreach (StudyData p in allStudies)
         {
            StudyInfo info = new StudyInfo(p.InstanceUID, p.Date, p.AccessionNumber, p.Id, p.ReferringPhysiciansName, p.Description);
            studies.Add(info);
         }
         return ControllerReturnCode.Success;
      }


      public ControllerReturnCode FindSeries(string patientId, string studyInstanceUid, List<SeriesInfo> series)
      {
         return FindSeries(patientId, studyInstanceUid, series, 0);
      }

      public ControllerReturnCode FindSeries(string patientId, string studyInstanceUid, List<SeriesInfo> series, int maxQueryResults)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         if (series == null)
         {
            FailureMessage = "Invalid Parameter: 'series' cannot be null";
            return ControllerReturnCode.Failure;
         }

         ArchiveServiceProxy archiveService = GetArchiveServiceProxy(_authenticationInfo.Token);

         QueryOptions options = new QueryOptions();
         options.PatientsOptions = new PatientsQueryOptions();
         options.PatientsOptions.PatientID = patientId;

         options.StudiesOptions = new StudiesQueryOptions();
         options.StudiesOptions.StudyInstanceUID = studyInstanceUid;

         options.SeriesOptions = new SeriesQueryOptions();


         SeriesData[] allSeries = archiveService.FindSeries(options, maxQueryResults);

         series.Clear();
         foreach (SeriesData p in allSeries)
         {
            SeriesInfo info = new SeriesInfo(p.InstanceUID, p.Modality, p.Number, p.Date, p.Description);
            series.Add(info);
         }
         return ControllerReturnCode.Success;
      }

      public ControllerReturnCode FindInstances(string patientId, string studyInstanceUid, string seriesInstanceUid, List<InstanceInfo> instances)
      {
         return FindInstances(patientId, studyInstanceUid, seriesInstanceUid, instances, 0);
      }

      public ControllerReturnCode FindInstances(string patientId, string studyInstanceUid, string seriesInstanceUid, List<InstanceInfo> instances, int maxQueryResults)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         if (instances == null)
         {
            FailureMessage = "Invalid Parameter: 'instances' cannot be null";
            return ControllerReturnCode.Failure;
         }

         ArchiveServiceProxy archiveService = GetArchiveServiceProxy(_authenticationInfo.Token);

         QueryOptions options = new QueryOptions();
         options.PatientsOptions = new PatientsQueryOptions();
         options.PatientsOptions.PatientID = patientId;

         options.StudiesOptions = new StudiesQueryOptions();
         options.StudiesOptions.StudyInstanceUID = studyInstanceUid;

         options.SeriesOptions = new SeriesQueryOptions();
         options.SeriesOptions.SeriesInstanceUID = seriesInstanceUid;


         Leadtools.Medical.WebViewer.DataContracts.InstanceData[] allInstances = archiveService.FindInstances(options, maxQueryResults);

         instances.Clear();
         foreach (Leadtools.Medical.WebViewer.DataContracts.InstanceData p in allInstances)
         {
            if (null != p)
            {
               InstanceInfo info = new InstanceInfo(p.SOPInstanceUID, p.InstanceNumber, p.SOPClassUID);
               instances.Add(info);
            }
         }
         return ControllerReturnCode.Success;
      }

      private string _failureMessage = string.Empty;

      public string FailureMessage
      {
         get { return _failureMessage; }
         set { _failureMessage = value; }
      }

      private void ClearFailureMessage()
      {
         _failureMessage = string.Empty;
      }

      #region UpdatePatient
      public ControllerReturnCode UpdatePatient(PatientInfo info)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         AutoResetEvent resetEvent = new AutoResetEvent(false);
         List<string> args = new List<string>();
         args.Add(info.PatientId);
         args.Add(info.Name);
         args.Add(info.Sex);
         args.Add(info.BirthDate);
         args.Add(info.EthnicGroup);
         args.Add(info.Comments);
         ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.UpdatePatient, args.ToArray(), resetEvent);
         return WaitForGenericResponse(resetEvent);
      }
      #endregion

      #region AddPatient
      public ControllerReturnCode AddPatient(PatientInfo info)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         AutoResetEvent resetEvent = new AutoResetEvent(false);
         ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.AddPatient,
                                                                    new string[] { info.PatientId,
                                                                                   info.Name,
                                                                                   info.Sex,
                                                                                   info.BirthDate,
                                                                                   info.EthnicGroup,
                                                                                   info.Comments
                                                                                   },
                                                                    resetEvent);

         return WaitForGenericResponse(resetEvent);

      }

      public ControllerReturnCode GetCurrentPatient(out PatientInfo info)
      {
         ClearFailureMessage();
         info = new PatientInfo();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         AutoResetEvent resetEvent = new AutoResetEvent(false);
         ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.GetCurrentPatient,
                                                                     null,
                                                                    resetEvent);

         return WaitForGenericResponse(info, resetEvent);

      }

      private ControllerReturnCode WaitForGenericResponse(AutoResetEvent resetEvent)
      {
         return WaitForGenericResponse(new Object(), resetEvent);
      }

      private ControllerReturnCode WaitForGenericResponse<T>(T myObject, AutoResetEvent resetEvent)
      {
         try
         {
            if (resetEvent.WaitOne(_timeoutTimeSpan))
            {
               Dictionary<string, string> response = ExternalCommandQueueService.CurrentInstance.GetLastResponse();

               if (myObject != null)
               {
                  Utilities.PopulateFromDictionary(myObject, response);
               }

               string value = string.Empty;
               if (response.TryGetValue(ControllerReturnType.GenericActionStatus, out value))
               {
                  ControllerReturnCode ret = value.ToControllerReturnCode();
                  switch (ret)
                  {
                     case ControllerReturnCode.Success:
                        return ControllerReturnCode.Success;

                     case ControllerReturnCode.Undefined:
                     default:
                        {
                           FailureMessage = value;
                           return ControllerReturnCode.Failure;
                        }
                  }
               }
               return ControllerReturnCode.Success;
            }
            else
            {
               return ControllerReturnCode.TimedOut;
            }
         }
         catch
         {
            return ControllerReturnCode.Failure;
         }
      }

      private ControllerReturnCode WaitForCommandRetrieval(AutoResetEvent resetEvent)
      {
         try
         {
            if (resetEvent.WaitOne(_timeoutTimeSpan))
            {
               return ControllerReturnCode.Success;
            }
            else
            {
               return ControllerReturnCode.TimedOut;
            }
         }
         catch
         {
            //Console.WriteLine(ex.Message);
            return ControllerReturnCode.UnknownError;
         }
      }
      #endregion

      // Specify a patient by PatientID and display available studies/series in the viewer.
      #region ShowPatient

      public void WaitForIdle()
      {
         while(!ExternalCommandQueueService.CurrentInstance.IsIdle(1000))
         {
            Thread.Sleep(100);
         }
      }

      public ControllerReturnCode PatientAvailable(string patientId)
      {
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         ArchiveServiceProxy archiveService = GetArchiveServiceProxy(_authenticationInfo.Token);
         var results = archiveService.FindPatients(1, patientId);
         
         if (results != null && results.Length > 0)
         {
            return ControllerReturnCode.Success;
         }
         else
         {
            return ControllerReturnCode.Failure;
         }
      }

      public ControllerReturnCode ShowPatient(string patientID, string style="")
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }
         AutoResetEvent resetEvent = new AutoResetEvent(false);
         if(string.IsNullOrEmpty(style))
            ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.ShowPatient, new string[] { patientID }, resetEvent);
         else
            ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.ShowPatient, new string[] { patientID, style }, resetEvent);

         return WaitForGenericResponse(resetEvent);
      }
      #endregion

      #region ShowStudy
      public ControllerReturnCode ShowStudy(string studyInstanceUid)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }
         AutoResetEvent resetEvent = new AutoResetEvent(false);
         ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.ShowStudy, new string[] { studyInstanceUid }, resetEvent);

         return WaitForGenericResponse(resetEvent);
      }
      #endregion

      #region DeletePatient
      public ControllerReturnCode DeletePatient(string patientId)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         AutoResetEvent resetEvent = new AutoResetEvent(false);
         ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.DeletePatient, new string[] { patientId }, resetEvent);
         return WaitForGenericResponse(resetEvent);
      }
      #endregion


      #region ShowSeries
      public ControllerReturnCode ShowSeries(string seriesInstanceUid)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }
         AutoResetEvent resetEvent = new AutoResetEvent(false);
         ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.ShowSeries, new string[] { seriesInstanceUid }, resetEvent);

         return WaitForGenericResponse(resetEvent);
      }
      #endregion

      #region ShowInstance
      public ControllerReturnCode ShowInstance(string sopInstanceUid)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }
         AutoResetEvent resetEvent = new AutoResetEvent(false);
         ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.ShowInstance, new string[] { sopInstanceUid }, resetEvent);

         return WaitForGenericResponse(resetEvent);
      }
      #endregion

      // Close the browser tab with the viewer. NOTE: For close to work in Firefox, closing windows from javascript must be enabled in the browser: about:config -> dom.allow_scripts_to_close_windows = true;
      #region CloseApplication
      public ControllerReturnCode CloseApplication()
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            // AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }
         _authenticationInfo = new WebViewerAuthenticationInfo();
         AutoResetEvent resetEvent = new AutoResetEvent(false);
         ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.Close, null, resetEvent, true);
         return WaitForCommandRetrieval(resetEvent);
      }
      #endregion

      #region GetImage
      public string GetImage(string sopInstanceUID)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return string.Empty;
         }

         AutoResetEvent resetEvent = new AutoResetEvent(false);
         ExternalCommandQueueService.CurrentInstance.EnqueueCommand(ControllerCommandNames.GetImage, new string[] { sopInstanceUID }, resetEvent);
         try
         {
            if (resetEvent.WaitOne(_timeoutTimeSpan))
            {
               Dictionary<string, string> response = ExternalCommandQueueService.CurrentInstance.GetLastResponse();
               return response["ImageURL"];
            }
            else
            {
               return string.Empty;
            }
         }
         catch
         {
            //Console.WriteLine(ex.Message);
            return string.Empty;
         }
      }
      #endregion

      // Shut down the ExternalCommandQueueService.
      #region ShutDown
      public ControllerReturnCode Shutdown()
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
         }
         catch
         {
            return ControllerReturnCode.Failure;
         }

         if (_authenticationInfo.IsLoggedIn)
         {
            UserLogout();
         }
         ExternalCommandQueueService.CurrentInstance.EndAssociation();
         _serviceHost.Close();
         _started = false;
         return ControllerReturnCode.Success;
      }
      #endregion

      #endregion

      #region PrivateMethods

      private string GetBrowserName()
      {
         string browserName = "Default Browser";
         switch (SelectedBrowser)
         {
            case MedicalWebViewerBrowser.Firefox:
               browserName = "Firefox";
               break;

            case MedicalWebViewerBrowser.GoogleChrome:
               browserName = "Chrome";
               break;

            case MedicalWebViewerBrowser.InternetExplorer:
               browserName = "Internet Explorer";
               break;

            case MedicalWebViewerBrowser.Edge:
               browserName = "Edge";
               break;

            case MedicalWebViewerBrowser.Opera:
               browserName = "Opera";
               break;
         }
         return browserName;
      }

      // Launches the viewer in a browser. 
      #region StartApplication
      private ControllerReturnCode StartApplication()
      {
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch
         {
            return ControllerReturnCode.NotProperlyInitiated;
         }

#if !LEADTOOLS_V19_OR_LATER
         // The AutoLogin.aspx page will redirect to the Viewer with some added URL parameters which tell the viewer to run in
         // ExternalControlMode. 
         string requestURL = _webViewerURL +
             "AutoLogin.aspx?token=" + HttpUtility.UrlEncode(_authenticationInfo.Token) +
             "&externalControlPort=" + _externalControlPort.ToString();
#else
         string requestURL = string.Format("{0}{1}/{2}/{3}",
            _webViewerURL.ToString(),
            "#/login/autologin",
            _externalControlPort.ToString(),
            HttpUtility.UrlEncode(_authenticationInfo.Token)
            );
#endif

         string arguments = String.Format("{0} {1}", _newWindowArgs, requestURL);

         if (_selectedBrowser == MedicalWebViewerBrowser.User)
         {
            if (null == UserWebBrowser)
            {
               FailureMessage = "User browser is not defined.";
               return ControllerReturnCode.Failure;
            }
            UserWebBrowser(requestURL, this);
            _browserProcess = null;
         }
         else if (_selectedBrowser == MedicalWebViewerBrowser.Default)
         {
            _browserProcess = Process.Start(requestURL);
         }
         else
         {
            _browserProcess = new Process();
            _browserProcess.StartInfo.FileName = _browserApplicationName;
            _browserProcess.StartInfo.Arguments = arguments;

            try
            {
               _browserProcess.Start();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
               string s = ex.Message.ToLower();
               if (s.Contains("system cannot find the file specified"))
               {
                  string browserName = GetBrowserName();
                  FailureMessage = string.Format("'{0}' browser could not be located.", browserName);
                  return ControllerReturnCode.Failure;
               }
            }
         }

         if (null != _browserProcess)
         {
            _browserProcess.EnableRaisingEvents = true;
         }

         if (_selectedBrowser == MedicalWebViewerBrowser.InternetExplorer)
         {
            _browserProcess.Exited += new EventHandler(_browserProcess_Exited);
         }
         else
         {
            // Firefox, Chrome
            // _heartBeatTimer.Start();
         }
         return ControllerReturnCode.Success;
      }
      #endregion

      private void AssertStarted()
      {
         if (!_started)
            throw new Exception("Startup must be called before using the MedicalWebViewerExternalController");
      }

      private void AssertLoggedIn()
      {
         if (!_authenticationInfo.IsLoggedIn)
            throw new Exception("User must be logged in to perform this action");
      }
      #endregion


      public ControllerReturnCode GetRoles(List<Role> roleList)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         if (roleList == null)
         {
            FailureMessage = string.Format(ErrorStrings.InvalidParameter, "'roleList' cannot be null");
            return ControllerReturnCode.Failure;
         }

         AuthenticationServiceProxy authenticationService = GetAuthenticationServiceProxy(_authenticationInfo.Token);
         if (authenticationService == null)
         {
            return ControllerReturnCode.AuthenticationFailure;
         }


         Role[] roles = authenticationService.GetRoles();
         if (roles != null)
         {
            foreach (Role r in roles)
            {
               roleList.Add(r);
            }
         }
         return ControllerReturnCode.Success;
      }

      public ControllerReturnCode GetPermissions(List<Permission> permissionList)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         if (permissionList == null)
         {
            FailureMessage = string.Format(ErrorStrings.InvalidParameter, "'permissionList' cannot be null");
            return ControllerReturnCode.Failure;
         }

         AuthenticationServiceProxy authenticationService = GetAuthenticationServiceProxy(_authenticationInfo.Token);
         if (authenticationService == null)
         {
            return ControllerReturnCode.AuthenticationFailure;
         }


         Permission[] permissions = authenticationService.GetPermissions();
         if (permissions != null)
         {
            foreach (Permission p in permissions)
            {
               permissionList.Add(p);
            }
         }
         return ControllerReturnCode.Success;
      }

      public ControllerReturnCode GetUsers(List<string> userList)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         if (userList == null)
         {
            FailureMessage = string.Format(ErrorStrings.InvalidParameter, "'userList' cannot be null");
            return ControllerReturnCode.Failure;
         }

         AuthenticationServiceProxy authenticationService = GetAuthenticationServiceProxy(_authenticationInfo.Token);
         if (authenticationService == null)
         {
            return ControllerReturnCode.AuthenticationFailure;
         }

         try
         {
            string[] users = authenticationService.GetAllUsers();
            if (users != null)
            {
               foreach (string s in users)
               {
                  userList.Add(s);
               }
            }
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }
         return ControllerReturnCode.Success;
      }

      public ControllerReturnCode GetUserPermissions(string userName, List<string> userPermissions)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         if (userPermissions == null)
         {
            FailureMessage = string.Format(ErrorStrings.InvalidParameter, "'userPermissions' cannot be null");
            return ControllerReturnCode.Failure;
         }

         AuthenticationServiceProxy authenticationService = GetAuthenticationServiceProxy(_authenticationInfo.Token);
         if (authenticationService == null)
         {
            return ControllerReturnCode.AuthenticationFailure;
         }


         string[] permissions = authenticationService.GetUserPermissions(userName, string.Empty);
         if (permissions != null)
         {
            foreach (string s in permissions)
            {
               userPermissions.Add(s);
            }
         }
         return ControllerReturnCode.Success;
      }

      public ControllerReturnCode GetUserRoles(string userName, List<string> userRoles)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
            AssertLoggedIn();
         }
         catch (Exception ex)
         {
            FailureMessage = ex.Message;
            return ControllerReturnCode.Failure;
         }

         if (userRoles == null)
         {
            FailureMessage = string.Format(ErrorStrings.InvalidParameter, "'userRoles' cannot be null");
            return ControllerReturnCode.Failure;
         }

         AuthenticationServiceProxy authenticationService = GetAuthenticationServiceProxy(_authenticationInfo.Token);
         if (authenticationService == null)
         {
            return ControllerReturnCode.AuthenticationFailure;
         }


         string[] roles = authenticationService.GetUserRoles(userName, string.Empty);
         if (roles != null)
         {
            foreach (string s in roles)
            {
               userRoles.Add(s);
            }
         }
         return ControllerReturnCode.Success;
      }

      private const string _adminRoleName = "Administrators";
      private const string _adminPermissionName = "Admin";

      #region DeleteUser
      public ControllerReturnCode DeleteUser(string username)
      {
         ClearFailureMessage();
         try
         {
            AssertStarted();
         }
         catch
         {
            return ControllerReturnCode.NotProperlyInitiated;
         }
         AuthenticationServiceProxy authenticationService = GetAuthenticationServiceProxy(_authenticationInfo.Token);

         authenticationService.DeleteUser(username);

         return ControllerReturnCode.Success;
      }

      #endregion

      #region CreateUser
      public ControllerReturnCode CreateUser(
                                    string username,
                                    string password,
                                    string adminUsername,
                                    string adminPassword,
                                    bool isAdmin,
                                    string[] permissions,
                                    string[] roles,
                                    CreateUserOptions options
                                    )
      {
         ClearFailureMessage();
         username = username.Trim();
         password = password.Trim();

         // If only logging in (not updating or creating), then call UserLogin
         if (options == CreateUserOptions.Login)
         {
            return UserLogin(username, password);
         }

         try
         {
            AssertStarted();
         }
         catch
         {
            return ControllerReturnCode.NotProperlyInitiated;
         }

         List<string> permissionsList = new List<string>(permissions);
         if (!permissions.Contains(_adminPermissionName))
         {
            if (isAdmin || roles.Contains(_adminRoleName))
            {
               permissionsList.Add(_adminPermissionName);
            }
         }

         AuthenticationServiceProxy authenticationService = GetAuthenticationServiceProxy();

         // Verify that adminUsername and adminPassword are valid
         string authenticationToken = String.Empty;
         bool adminValid = authenticationService.IsAuthenticated(adminUsername, adminPassword, out authenticationToken);
         if (adminValid == false)
         {
            FailureMessage = ErrorStrings.AdminUsernamePasswordInvalid;
            return ControllerReturnCode.AuthenticationFailure;
         }

         string[] userList = new string[] { };
         if (options.IsFlagged(CreateUserOptions.CreateUser) || options.IsFlagged(CreateUserOptions.UpdateUser))
         {
            userList = authenticationService.GetAllUsers();
         }

         bool userExists = userList.Contains(username);
         bool passwordUpdated = false;


         // 
         if (options.IsFlagged(CreateUserOptions.CreateUser))
         {
            if (!userExists)
            {
               authenticationService.CreateUser(username, password);
               passwordUpdated = true;
               userExists = true;
            }
            else
            {
               // user already exists
               if (!options.IsFlagged(CreateUserOptions.UpdateUser))
               {
                  FailureMessage = string.Format(ErrorStrings.UserAlreadyExists, username);
                  return ControllerReturnCode.Failure;
               }
            }
         }

         if (options.IsFlagged(CreateUserOptions.CreateUser | CreateUserOptions.UpdateUser | CreateUserOptions.UpdateRoles | CreateUserOptions.UpdatePermissions | CreateUserOptions.UpdatePassword))
         {
            if (userExists == false)
            {
               FailureMessage = string.Format(ErrorStrings.UserDoesNotExist, username);
               return ControllerReturnCode.Failure;
            }
         }

         if (options.IsFlagged(CreateUserOptions.CreateUser | CreateUserOptions.UpdatePassword))
         {
            if (passwordUpdated == false)
            {
               authenticationService.ResetPassword(username, password, string.Empty);
            }
         }

         if (options.IsFlagged(CreateUserOptions.CreateUser | CreateUserOptions.UpdatePermissions))
         {
            Permission[] allPermissions = authenticationService.GetPermissions();
            foreach (Permission p in allPermissions)
            {
               if (!permissionsList.Contains(p.Name))
               {
                  authenticationService.DenyPermission(username, p.Name, string.Empty);
               }
            }

            foreach (string permission in permissionsList)
            {
               authenticationService.GrantPermission(username, permission, string.Empty);
            }
         }

         if (options.IsFlagged(CreateUserOptions.CreateUser | CreateUserOptions.UpdateRoles))
         {
            Role[] allRoles = authenticationService.GetRoles();
            List<string> rolesList = new List<string>(roles);


            foreach (Role r in allRoles)
            {
               if (!rolesList.Contains(r.Name))
               {
                  authenticationService.DenyRole(username, r.Name, string.Empty);
               }
            }

            foreach (string role in roles)
            {
               authenticationService.GrantRole(username, role, string.Empty);
            }
         }


         // After creating/updating the user, now login if necessary
         if (options.IsFlagged(CreateUserOptions.Login))
         {
            return UserLogin(username, password);
         }

         return ControllerReturnCode.Success;
      }
      #endregion

   }

}
