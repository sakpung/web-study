// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Threading;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

using Leadtools;
using Leadtools.Demos;
using Leadtools.Dicom;
using System.Net;
using System.Text;
using System.Security.Permissions;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.Linq;

#if USE_WINDOWS_API_CODE_PACK
using Microsoft.WindowsAPICodePack.Dialogs;
#endif

#if FROM_LEADTOOLS_MEDICAL_WEBVIEWER_IMAGEDOWNLOADADDIN
namespace Leadtools.DicomDemos.From.Medical.WebViewer.ImageDownLoadAddin
#else
namespace Leadtools.DicomDemos
#endif
{
   [StructLayout(LayoutKind.Sequential)]
   public struct POINT
   {
      public int X;
      public int Y;

      public POINT(int x, int y)
      {
         this.X = x;
         this.Y = y;
      }

      public static implicit operator System.Drawing.Point(POINT p)
      {
         return new System.Drawing.Point(p.X, p.Y);
      }

      public static implicit operator POINT(System.Drawing.Point p)
      {
         return new POINT(p.X, p.Y);
      }
   }

   [StructLayout(LayoutKind.Sequential)]
   public struct MSG
   {
      public IntPtr hwnd;
      public uint message;
      public IntPtr wParam;
      public IntPtr lParam;
      public uint time;
      public POINT pt;
   }

   public enum WaitReturn
   {
      Complete,
      Timeout,
   }

   /// <summary>
   /// Summary description for Scu.
   /// </summary>
   public class Utils
   {
      [DllImport("user32.dll")]
      [return: MarshalAs(UnmanagedType.Bool)]
      static extern bool PeekMessage(out MSG lpMsg, HandleRef hWnd,
                                     uint wMsgFilterMin, uint wMsgFilterMax,
                                     uint wRemoveMsg);

      [DllImport("user32.dll")]
      static extern bool TranslateMessage([In] ref MSG lpMsg);
      [DllImport("user32.dll")]
      static extern IntPtr DispatchMessage([In] ref MSG lpmsg);

      const uint PM_REMOVE = 1;

      public static WaitReturn WaitForComplete(double mill, WaitHandle wh)
      {
         TimeSpan goal = new TimeSpan(DateTime.Now.AddMilliseconds(mill).Ticks);
         MSG msg = new MSG();
         HandleRef h = new HandleRef(null, IntPtr.Zero);

         do
         {
            if (PeekMessage(out msg, h, 0, 0, PM_REMOVE))
            {
               TranslateMessage(ref msg);
               DispatchMessage(ref msg);
            }

            if (wh.WaitOne(new TimeSpan(1), false))
            {
               return WaitReturn.Complete;
            }

            if (goal.CompareTo(new TimeSpan(DateTime.Now.Ticks)) < 0)
            {
               return WaitReturn.Timeout;
            }

         } while (true);
      }

      public static WaitReturn WaitForComplete(double mill, WaitHandle completeHandle, WaitHandle resetTimeoutHandle)
      {
         TimeSpan goal = new TimeSpan(DateTime.Now.AddMilliseconds(mill).Ticks);
         MSG msg = new MSG();
         HandleRef h = new HandleRef(null, IntPtr.Zero);

         WaitHandle[] waitHandles = new WaitHandle[2] { resetTimeoutHandle, completeHandle };

         do
         {
            if (PeekMessage(out msg, h, 0, 0, PM_REMOVE))
            {
               TranslateMessage(ref msg);
               DispatchMessage(ref msg);
            }

            int index = WaitHandle.WaitAny(waitHandles, new TimeSpan(1), false);

            if (index == WaitHandle.WaitTimeout)
            {
               if (goal.CompareTo(new TimeSpan(DateTime.Now.Ticks)) < 0)
               {
                  return WaitReturn.Timeout;
               }
            }

            else
            {
               Debug.Assert(index == 0 || index == 1);
               AutoResetEvent autoEvent = waitHandles[index] as AutoResetEvent;
               if (autoEvent == completeHandle)
               {
                  return WaitReturn.Complete;
               }
               else if (autoEvent == resetTimeoutHandle)
               {
                  Console.WriteLine("Reset Timer");
                  goal = new TimeSpan(DateTime.Now.AddMilliseconds(mill).Ticks);
               }
            }



         } while (true);
      }

      public static void EngineStartup()
      {
         DicomEngine.Startup();
      }

      public static void EngineShutdown()
      {
         DicomEngine.Shutdown();
      }

      public static void DicomNetStartup()
      {
         DicomNet.Startup();
      }

      public static void DicomNetShutdown()
      {
         DicomNet.Shutdown();
      }

      /// <summary>
      /// Helper method to get string value from a DICOM dataset.
      /// </summary>
      /// <param name="dcm">The DICOM dataset.</param>
      /// <param name="tag">Dicom tag.</param>
      /// <returns>String value of the specified DICOM tag.</returns>
      public static string GetStringValue(DicomDataSet dcm, long tag, bool tree)
      {
         DicomElement element;

         element = dcm.FindFirstElement(null, tag, tree);
         if (element != null)
         {
            if (dcm.GetElementValueCount(element) > 0)
            {
               return dcm.GetConvertValue(element);
            }
         }

         return "";
      }

      public static string GetStringValue(DicomDataSet dcm, long tag)
      {
         return GetStringValue(dcm, tag, true);
      }

#if (LTV15_CONFIG)
      public static string GetStringValue(DicomDataSet dcm, DicomTagType tag, bool tree)
      {
         return GetStringValue(dcm, (long)tag, tree);
      }

      public static string GetStringValue(DicomDataSet dcm, DicomTagType tag)
      {
      return GetStringValue(dcm,(long)tag);
      }
#endif

      public static StringCollection GetStringValues(DicomDataSet dcm, long tag)
      {
         DicomElement element;
         StringCollection sc = new StringCollection();

         element = dcm.FindFirstElement(null, tag, true);
         if (element != null)
         {
            if (dcm.GetElementValueCount(element) > 0)
            {
               string s = dcm.GetConvertValue(element);
               string[] items = s.Split('\\');

               foreach (string value in items)
               {
                  sc.Add(value);
               }
            }
         }

         return sc;
      }

#if (LTV15_CONFIG)
      public static StringCollection GetStringValues(DicomDataSet dcm, DicomTagType tag)
      {
         return GetStringValues(dcm, (long)tag);
      }
#endif

      public static byte[] GetBinaryValues(DicomDataSet dcm, long tag)
      {
         DicomElement element;

         element = dcm.FindFirstElement(null, tag, true);
         if (element != null)
         {
            if (element.Length > 0)
            {
               return dcm.GetBinaryValue(element, (int)element.Length);
            }
         }

         return null;
      }


#if (LTV15_CONFIG)
      public static byte[] GetBinaryValues(DicomDataSet dcm, DicomTagType tag)
      {
         return GetBinaryValues(dcm, (long)tag);
      }
#endif

      public static bool IsTagPresent(DicomDataSet dcm, long tag)
      {
         DicomElement element;

         element = dcm.FindFirstElement(null, tag, true);
         return (element != null);
      }

#if (LTV15_CONFIG)
      public static bool IsTagPresent(DicomDataSet dcm, DicomTagType tag)
      {
         return IsTagPresent(dcm, (long)tag);
      }
#endif

      public static bool IsAscii(string value)
      {
         return Encoding.UTF8.GetByteCount(value) == value.Length;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="dcm"></param>
      /// <param name="tag"></param>
      /// <param name="tagValue"></param>
      /// <returns></returns>
      public static DicomExceptionCode SetTag(DicomDataSet dcm, long tag, object tagValue, bool tree)
      {
         DicomExceptionCode ret = DicomExceptionCode.Success;
         DicomElement element;

         if (tagValue == null)
            return DicomExceptionCode.Parameter;

         element = dcm.FindFirstElement(null, tag, tree);
         if (element == null)
         {
            element = dcm.InsertElement(null, false, tag, DicomVRType.UN, false, 0);
         }

         if (element == null)
            return DicomExceptionCode.Parameter;

         try
         {
            string s = tagValue.ToString();
            if (IsAscii(s))
               dcm.SetConvertValue(element, s, 1);
            else
               dcm.SetStringValue(element, s, DicomCharacterSetType.UnicodeInUtf8);
         }
         catch (DicomException de)
         {
            ret = de.Code;
         }

         return ret;
      }

      public static DicomExceptionCode SetTag(DicomDataSet dcm, long tag, object tagValue)
      {
         return SetTag(dcm, tag, tagValue, true);
      }

#if (LTV15_CONFIG)
      public static void SetTag(DicomDataSet dcm, DicomTagType seq,DicomTagType tag, object tagValue)
      {
         SetTag(dcm, (long)seq,(long)tag, tagValue);
      }
#endif

      public static void SetTag(DicomDataSet dcm, long Sequence, long Tag, object TagValue)
      {
         DicomElement seqElement = dcm.FindFirstElement(null, Sequence, true);
         DicomElement seqItem = null;
         DicomElement item = null;

         if (seqElement == null)
         {
            seqElement = dcm.InsertElement(null, false, Tag, DicomVRType.SQ, true, -1);
         }

         seqItem = dcm.GetChildElement(seqElement, false);
         if (seqItem == null)
         {
#if (LTV15_CONFIG)
              seqItem = dcm.InsertElement(seqElement, true, DicomTagType.SequenceDelimitationItem, DicomVRType.SQ, true, -1);
#else
            seqItem = dcm.InsertElement(seqElement, true, DicomTag.SequenceDelimitationItem, DicomVRType.SQ, true, -1);
#endif
         }

         item = dcm.GetChildElement(seqItem, true);
         while (item != null)
         {
#if (LTV15_CONFIG)
              if ((long)item.Tag == Tag)
                  break;
#else
            if (item.Tag == Tag)
               break;
#endif

            item = dcm.GetNextElement(item, true, true);
         }

         if (item == null)
         {
            item = dcm.InsertElement(seqItem, true, Tag, DicomVRType.UN, false, -1);
         }
         dcm.SetConvertValue(item, TagValue.ToString(), 1);
      }


#if (LTV15_CONFIG)
      public static DicomExceptionCode SetTag(DicomDataSet dcm, DicomTagType tag, object tagValue)
      {
         return SetTag(dcm, (long)tag, tagValue);
      }

      public static DicomExceptionCode SetTag(DicomDataSet dcm, DicomTagType tag, object tagValue, bool tree)
      {
          return SetTag(dcm, (long)tag, tagValue, tree);
      }

#endif

      public static DicomExceptionCode SetTag(DicomDataSet dcm, long tag, byte[] tagValue)
      {
         DicomExceptionCode ret = DicomExceptionCode.Success;
         DicomElement element;

         if (tagValue == null)
            return DicomExceptionCode.Parameter;

         element = dcm.FindFirstElement(null, tag, true);
         if (element == null)
         {
            element = dcm.InsertElement(null, false, tag, DicomVRType.UN, false, 0);
         }

         dcm.SetBinaryValue(element, tagValue, tagValue.Length);

         return ret;
      }

      public static void CreateTag(DicomDataSet dcm, long tag)
      {
         DicomElement element = dcm.FindFirstElement(null, tag, true);
         if (element == null)
         {
            element = dcm.InsertElement(null, false, tag, DicomVRType.UN, false, 0);
         }
      }

#if (LTV15_CONFIG)
      public static DicomExceptionCode InsertKeyElement(DicomDataSet dcmRsp, DicomDataSet dcmReq, DicomTagType tag)
      {
         return InsertKeyElement(dcmRsp, dcmReq, (long)tag);
      }
#endif

      public static DicomExceptionCode InsertKeyElement(DicomDataSet dcmRsp, DicomDataSet dcmReq, long tag)
      {
         DicomExceptionCode ret = DicomExceptionCode.Success;
         DicomElement element;

         try
         {
            element = dcmReq.FindFirstElement(null, tag, true);
            if (element != null)
            {
               dcmRsp.InsertElement(null, false, tag, DicomVRType.UN, false, 0);
            }
         }
         catch (DicomException de)
         {
            ret = de.Code;
         }

         return ret;
      }


#if (LTV15_CONFIG)
       public static DicomExceptionCode SetKeyElement(DicomDataSet dcmRsp, DicomTagType tag, object tagValue)
       {
           return SetKeyElement(dcmRsp, (long)tag, tagValue);
       }

       public static DicomExceptionCode SetKeyElement(DicomDataSet dcmRsp, DicomTagType tag, object tagValue, bool tree)
       {
           return SetKeyElement(dcmRsp, (long)tag, tagValue, tree);
       }
#endif

      public static DicomExceptionCode SetKeyElement(DicomDataSet dcmRsp, long tag, object tagValue, bool tree)
      {
         DicomExceptionCode ret = DicomExceptionCode.Success;
         DicomElement element;

         if (tagValue == null)
            return DicomExceptionCode.Parameter;

         try
         {
            element = dcmRsp.FindFirstElement(null, tag, tree);
            if (element != null)
            {
               string s = tagValue.ToString();
               if (IsAscii(s))
                  dcmRsp.SetConvertValue(element, s, 1);
               else
                  dcmRsp.SetStringValue(element, s, DicomCharacterSetType.UnicodeInUtf8);
            }
         }
         catch (DicomException de)
         {
            ret = de.Code;
         }

         return ret;
      }

      public static DicomExceptionCode SetKeyElement(DicomDataSet dcmRsp, long tag, object tagValue)
      {
         return SetKeyElement(dcmRsp, tag, tagValue, true);
      }

      public static UInt16 GetGroup(long tag)
      {
         return ((UInt16)(tag >> 16));
      }

      public static int GetElement(long tag)
      {
         return ((UInt16)(tag & 0xFFFF));
      }


      private static string TrimLeadingZeros(string s)
      {
         s = s.TrimStart('0');
         if (s.Length == 0)
            s = "0";
         return s;
      }

      private static string TrimLeadingZerosAllComponents(string uid)
      {
         string[] sArray = uid.Split(new char[] { '.' });
         List<string> sList = new List<string>();
         foreach (string s in sArray)
         {
            string sFixed = TrimLeadingZeros(s);
            sList.Add(sFixed);
         }
         return String.Join(".", sList);
      }

      // Creates a properly formatted Dicom Unique Identifier (VR type of UI) value

      private static String _prevTime;
      private static String _leadRoot = null;
      private static Object _lock = new object();
      private static int _count = 0;
      private const int _maxCount = int.MaxValue;

      // UID is comprised of the following components
      // {LEAD Root}.{ProcessID}.{date}.{time}.{fraction seconds}.{counter}
      // {18 +      1 + 10 +    1 + 8 +1 + 6+ 1 + 7              + 10}
      // Total max length is 63 characters
      public static string GenerateDicomUniqueIdentifier()
      {
         try
         {
            lock (_lock)
            {
               // yyyy     four digit year
               // MM       month from 01 to 12
               // dd       01 to 31
               // HH       hours using a 24-hour clock form 00 to 23
               // mm       minute 00 to 59
               // ss       second 00 to 59
               // fffffff  ten millionths of a second
               const string dateFormatString = "yyyyMMdd.HHmmss.fffffff";

               string sUidRet = "";
               if (_leadRoot == null)
               {
                  StringBuilder sb = new StringBuilder();

                  sb.Append("1.2.840.114257.1.1");

                  // Process Id
                  sb.AppendFormat(".{0}", (uint)Process.GetCurrentProcess().Id);

                  _leadRoot = sb.ToString();

                  _prevTime = DateTime.UtcNow.ToString(dateFormatString);
               }

               StringBuilder uid = new StringBuilder();
               uid.Append(_leadRoot);

               String time = DateTime.UtcNow.ToString(dateFormatString);
               if (time.Equals(_prevTime))
               {
                  if (_count == _maxCount)
                     throw new Exception("GenerateDicomUniqueIdentifier error -- max count reached.");

                  _count++;
               }
               else
               {
                  _count = 1;
                  _prevTime = time;
               }

               uid.AppendFormat(".{0}.{1}", time, _count);

               sUidRet = uid.ToString();

               // Remove leading zeros from all components, unless 0 is the only digit
               sUidRet = TrimLeadingZerosAllComponents(sUidRet);

               // This should not happen
               if (sUidRet.Length > 64)
                  sUidRet = sUidRet.Substring(0, 64);

               return sUidRet;
            }
         }
         catch (Exception ex)
         {
            throw ex;
         }
      }

      public static bool IsLocalIPAddress(string hostNameOrAddress)
      {
         if (hostNameOrAddress.ToLower() == Dns.GetHostName().ToLower())
         {
            return true;
         }
         else
         {
            IPAddress serviceAddress;

            if (IPAddress.TryParse(hostNameOrAddress, out serviceAddress))
            {
               if (IPAddress.IsLoopback(serviceAddress))
               {
                  return true;
               }
               else
               {
                  IPAddress[] localAddresses;


                  localAddresses = Dns.GetHostAddresses(Dns.GetHostName());

                  foreach (IPAddress localAddress in localAddresses)
                  {
                     if (localAddress.Equals(serviceAddress))
                     {
                        return true;
                     }
                  }
               }
            }
         }

         return false;
      }


      public static System.Net.IPAddress ResolveIPAddress(string hostNameOrAddress)
      {
         IPAddress[] addresses;
         addresses = Dns.GetHostAddresses(hostNameOrAddress.Trim());
         if (addresses == null || addresses.Length == 0)
         {
            throw new ArgumentException("Invalid hostNameOrAddress parameter.");
         }
         else
         {
            foreach (IPAddress address in addresses)
            {
               if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork ||
                  address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
               {
                  return address;
               }
            }
            throw new ArgumentException("Could not resolve a valid host Address. Address must conform to IPv4 or IPv6.");
         }
      }

#if LEADTOOLS_V175_OR_LATER

      // Returns string.empty if valid
      // Otherwise, returns an error message
      public static bool IsValidHostnameOrAddress(string hostNameOrAddress, out string error)
      {
         bool isValid = true;
         error = string.Empty;

         if ((hostNameOrAddress == null) || (string.IsNullOrEmpty(hostNameOrAddress.Trim())))
         {
            error = "Host address must be non-empty";
            return false;
         }
         try
         {
            Utils.ResolveIPAddress(hostNameOrAddress);
         }
         catch (Exception exception)
         {
            error = exception.Message;
            isValid = false;
         }
         return isValid;
      }

      public static bool IsValidApplicationEntity(string aeTitle, out string error)
      {
         error = string.Empty;

         if (aeTitle == null)
         {
            error = "Application Entity must not be empty";
            return false;
         }

         aeTitle = aeTitle.Trim();
         if (string.IsNullOrEmpty(aeTitle))
         {
            error = "Application Entity must not be empty";
            return false;
         }

         if (aeTitle.Length > 16)
         {
            error = "Application Entity must contain 16 characters or less.";
            return false;
         }

         if (aeTitle.Contains("\\"))
         {
            error = "Application Entity must not contain the '\\' character";
            return false;
         }

         return true;
      }
#endif // LEADTOOLS_V175_OR_LATER



      public static bool VerifyOpensslVersion(Form owner)
      {
         bool isValid = true;
         DicomOpenSslVersion version = DicomNet.GetOpenSslVersion();
         if (version.IsAvailable == false)
         {
            ShowMessageBoxWithHyperlinks(owner, version.DownloadMessage, "Download OpenSSL");
            isValid = false;
         }
         return isValid;
      }

      public static void ShowMessageBoxWithHyperlinks(Form owner, string message, string caption)
      {
         bool successfulMessageBox = false;
#if USE_WINDOWS_API_CODE_PACK
         try
         {
            ShowTaskDialogWithHyperlinks(owner, message, caption);
            successfulMessageBox = true;
         }
         catch (Exception)
         {

         }
#endif // #if USE_WINDOWS_API_CODE_PACK
         if (!successfulMessageBox)
         {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
      }

#if USE_WINDOWS_API_CODE_PACK
      public static void ShowTaskDialogWithHyperlinks(Form owner, string message, string caption)
      {
         // If TaskDialog() throws exception:
         //   TaskDialog feature needs to load version 6 of comctl32.dll but a different version is current loaded in memory
         // then add this line of code in the Main() of your application
         //   Application.EnableVisualStyles();

         TaskDialog taskDialog = new TaskDialog();

         if (owner != null)
         {
            taskDialog.OwnerWindowHandle = owner.Handle;
         }

         taskDialog.HyperlinkClick += TaskDialog_HyperlinkClick;
         taskDialog.Opened += TaskDialog_Opened;
         taskDialog.HyperlinksEnabled = true;

         taskDialog.Caption = caption;

         taskDialog.StartupLocation = TaskDialogStartupLocation.CenterOwner;

         taskDialog.InstructionText = caption;

         string[] strings = message.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

         foreach (string s in strings)
         {
            if (s.ToLower().StartsWith("http"))
            {
               string newString = string.Format("<A HREF=\"{0}\">{0} </A>", s);
               message = message.Replace(s, newString);
            }
         }

         taskDialog.Text = message;
         taskDialog.Show();
      }

      private static void TaskDialog_Opened(object sender, EventArgs e)
      {
         TaskDialog taskDialog = sender as TaskDialog;
         if (taskDialog != null)
         {
            taskDialog.Icon = TaskDialogStandardIcon.Information;
            taskDialog.InstructionText = taskDialog.InstructionText;
         }
      }

      private static void TaskDialog_HyperlinkClick(object sender, TaskDialogHyperlinkClickedEventArgs e)
      {
         if (!string.IsNullOrEmpty(e.LinkText))
         {
            Process.Start(e.LinkText);
         }
      }
#endif //    #if USE_WINDOWS_API_CODE_PACK
   }

   [Serializable]
   public class DicomAE
   {
      public DicomAE()
      {
         _sAE = string.Empty;
         _sIP = string.Empty;
         _port = 0;
         _timeout = 0;
         _useTls = false;
      }

      public DicomAE(string sAE, string sIP, int port, int timeout, bool useTls)
      {
         _sAE = sAE;
         _sIP = sIP;
         _port = port;
         _timeout = timeout;
         _useTls = useTls;
      }

      public override string ToString()
      {
         string name = _sAE;
         if (_useTls)
         {
            name = name + "  (Secure)";
         }
         return name; 
      }

      public string AE
      {
         get
         {
            return _sAE;
         }

         set
         {
            _sAE = value;
         }
      }

      public string IPAddress
      {
         get
         {
            return _sIP;
         }

         set
         {
            _sIP = value;
         }
      }

      public int Port
      {
         get
         {
            return _port;
         }

         set
         {
            _port = value;
         }
      }

      public int Timeout
      {
         get
         {
            return _timeout;
         }

         set
         {
            _timeout = value;
         }
      }

      public bool UseTls
      {
         get
         {
            return _useTls;
         }

         set
         {
            _useTls = value;
         }
      }



      private string _sAE;
      private string _sIP;
      private int _port;
      private int _timeout;
      private bool _useTls;
   }


   public class DicomDemoSettingsManager
   {
      public static string GlobalPacsConfigFilename
      {
         get
         {
            return "GlobalPacs.config";
         }
      }

      public static string GlobalPacsConfigFullFileName
      {
         get
         {
            return Path.Combine(Application.StartupPath, GlobalPacsConfigFilename);
         }
      }

#if LEADTOOLS_V175_OR_LATER
      public static System.Configuration.Configuration GetGlobalPacsConfiguration()
      {
         ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
         configFile.ExeConfigFilename = DicomDemoSettingsManager.GlobalPacsConfigFullFileName;
         configFile.MachineConfigFilename = DicomDemoSettingsManager.GlobalPacsConfigFullFileName;
         System.Configuration.Configuration mappedConfiguration = ConfigurationManager.OpenMappedMachineConfiguration(configFile);
         return mappedConfiguration;

      }

      public static System.Configuration.Configuration GetGlobalPacsAddinsConfiguration(string ServiceDirectory)
      {
         string addInsConfigFile = Path.Combine(ServiceDirectory, @"..\\" + GlobalPacsConfigFilename);
         ExeConfigurationFileMap addInsConfigFileMap = new ExeConfigurationFileMap();
         addInsConfigFileMap.MachineConfigFilename = addInsConfigFile;
         addInsConfigFileMap.ExeConfigFilename = addInsConfigFile;
         System.Configuration.Configuration configuration = ConfigurationManager.OpenMappedMachineConfiguration(addInsConfigFileMap);
         return configuration;
      }
#endif

      public const string StorageDataAccessConfiguration = "storageDataAccessConfiguration175";
      public const string LoggingDataAccessConfiguration = "loggingDataAccessConfiguration175";
      public const string MediaCreationDataAccessConfiguration = "mediaCreationDataAccessConfiguration175";
      public const string UserManagementConfigurationSample = "userManagementConfigurationSample175";
      public const string WorkListDataAccessConfiguration = "workListDataAccessConfiguration175";
      public const string WorkstationDataAccessConfiguration = "workstationDataAccessConfiguration175";
      public const string OptionsConfiguration = "optionsConfiguration175";
      public const string AeManagementConfiguration = "aeManagementConfiguration175";
      public const string AePermissionManagementConfiguration = "aePermissionManagementConfiguration175";
      public const string PermissionManagementConfiguration = "permissionManagementConfiguration175";
      public const string ForwardConfiguration = "forwardConfiguration175";
      public const string DownloadJobsConfiguration = "DownloadJobsConfiguration175";
      public const string PatientRightsConfiguration = "patientRightsConfiguration175";
      public const string ExternalStoreConfiguration = "externalStoreConfiguration175";
      public const string ExportLayoutConfiguration = "exportLayoutConfiguration20";


      public const string ProductNameStorageServer = "StorageServer";

      public const string ProductNameDemoServer = "DemoServer";

      public const string ProductNameWorkstation = "Workstation";

      public const string ProductNamePatientUpdater = "PatientUpdater";

      public const string ProductNameMedicalViewer = "MedicalViewer";

      public const string ProductDentalApp = "DentalClient";

      public const string ProductNameGateway = "Gateway";

      public static void RunPacsConfigDemo()
      {
         string caption = "Note";
         string message = "Please run the PACSConfigDemo to configure this and other PACS Framework demos.\n\nWould you like to run the PACSConfigDemo now?";

         DialogResult dr = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
         if (DialogResult.Yes == dr)
         {
            string pacsConfigDemoFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSPacsConfigDemo_Original.exe");

            if (!File.Exists(pacsConfigDemoFileName))
            {
               pacsConfigDemoFileName = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CSPacsConfigDemo.exe");
            }

            if (File.Exists(pacsConfigDemoFileName))
            {
               Process pacConfigProcess = new Process();
               pacConfigProcess.StartInfo.FileName = pacsConfigDemoFileName;

               pacConfigProcess.Start();
               pacConfigProcess.WaitForExit();
            }
            else
            {
               MessageBox.Show("Could not find the CSPacsConfigDemo.", "Warning", MessageBoxButtons.OK);
            }
         }
      }

      public static void SaveSettings(string demoName, DicomDemoSettings settings)
      {
         try
         {
            string filename = GetSettingsFilename(demoName);
            XmlSerializer xs = new XmlSerializer(typeof(DicomDemoSettings));

            using (TextWriter xmlTextWriter = new StreamWriter(filename))
            {
               xs.Serialize(xmlTextWriter, settings);
               xmlTextWriter.Close();
            }
         }
         catch (Exception)
         {
            throw;
         }
      }

      public static DicomDemoSettings LoadSettings(string demoName)
      {
         bool settingsLoaded = false;

         XmlSerializer SerializerObj = new XmlSerializer(typeof(DicomDemoSettings));
         string filename = GetSettingsFilename(demoName);

         if (File.Exists(filename))
         {
            DicomDemoSettings settings = null;

            try
            {
               // Create a new file stream for reading the XML file
               using (TextReader ReadFileStream = new StreamReader(filename))
               {
                  // Load the object saved above by using the Deserialize function
                  settings = (DicomDemoSettings)SerializerObj.Deserialize(ReadFileStream);

                  // Cleanup
                  ReadFileStream.Close();
                  settingsLoaded = true;
               }
            }
            catch (Exception)
            {
               settingsLoaded = false;
            }
            if (settingsLoaded)
            {
               SerializerObj = null;

               if (settings != null && settings.CipherSuites.ItemList.Count == 0)
               {
                  settings.CipherSuites.ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256));
                  settings.CipherSuites.ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384));
                  settings.CipherSuites.ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256));
                  settings.CipherSuites.ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384));
               }

               return settings;
            }
         }
         return null;
      }


      [DllImport("shfolder.dll", CharSet = CharSet.Auto)]
      private static extern int SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder lpszPath);

      private const int CommonDocumentsFolder = 0x2e;

      public static string GetFolderPath()
      {
         StringBuilder lpszPath = new StringBuilder(260);
         // CommonDocuments is the folder than any Vista user (including 'guest') has read/write access
         SHGetFolderPath(IntPtr.Zero, (int)CommonDocumentsFolder, IntPtr.Zero, 0, lpszPath);
         string path = lpszPath.ToString();
         new FileIOPermission(FileIOPermissionAccess.PathDiscovery, path).Demand();
         return path;
      }

      public enum InstallPlatform
      {
         win32 = 0,
         x64 = 1
      };

      public static string GetSettingsFilename(string demo, InstallPlatform platform)
      {
         string commonFolder = GetFolderPath();
         string sPlatform = "32";

         if (platform == InstallPlatform.x64)
         {
            sPlatform = "64";
         }
         else
         {
            sPlatform = "32";
         }

         string ext = Path.GetExtension(demo);
         string name = Path.GetFileNameWithoutExtension(demo);
#if (LTV20_CONFIG)
         string settingsFilename = string.Format("{0}\\{1}{2}{3}_20.xml", commonFolder, name, sPlatform, ext);
#elif (LTV19_CONFIG)
         string settingsFilename = string.Format("{0}\\{1}{2}{3}_19.xml", commonFolder, name, sPlatform, ext);
#elif (LTV18_CONFIG)
         string settingsFilename = string.Format("{0}\\{1}{2}{3}_18.xml", commonFolder, name, sPlatform, ext);
#elif (LTV175_CONFIG)
         string settingsFilename = string.Format("{0}\\{1}{2}{3}_175.xml", commonFolder, name, sPlatform, ext);
#else
         string settingsFilename = string.Format("{0}\\{1}{2}{3}_17.xml", commonFolder, name, sPlatform, ext);
#endif
         return settingsFilename;
      }

      public static string GetSettingsFilename(string demo)
      {
         string commonFolder = GetFolderPath();
         if (Is64Process())
         {
            return GetSettingsFilename(demo, InstallPlatform.x64);
         }
         else
         {
            return GetSettingsFilename(demo, InstallPlatform.win32);
         }
      }

      public static bool Is64Process()
      {
         return IntPtr.Size == 8;
      }

      public static string GetCertificateAuthorityFullPath()
      {
         string fileCertificateAuthority = Application.StartupPath + "\\ca.pem";
         if (!File.Exists(fileCertificateAuthority))
         {
            fileCertificateAuthority = string.Empty;
         }
         return fileCertificateAuthority;
      }

      public static string GetClientCertificateFullPath()
      {
         string fileClientCertificate = Application.StartupPath + "\\client.pem";
         if (!File.Exists(fileClientCertificate))
         {
            fileClientCertificate = string.Empty;
         }
         return fileClientCertificate;
      }

      public static string GetClientCertificatePassword()
      {
         string password = string.Empty;
         string fileClientCertificate = GetClientCertificateFullPath();
         if (!string.IsNullOrEmpty(fileClientCertificate))
            password = "test";
         return password;
      }
   }

   public enum DicomRetrieveMode
   {
      CMove = 0,
      CGet = 1,
   }

   [Serializable]
   public class CipherSuiteItem
   {
      public bool IsChecked { get; set; }
      public DicomTlsCipherSuiteType Cipher;

      public CipherSuiteItem()
      {
         IsChecked = false;
         Cipher = DicomTlsCipherSuiteType.None;
      }

      public CipherSuiteItem(bool isChecked, DicomTlsCipherSuiteType cipher)
      {
         IsChecked = isChecked;
         Cipher = cipher;
      }

      public CipherSuiteItem(bool isChecked, string cipher)
      {
         IsChecked = isChecked;
         Cipher = CipherStringToType(cipher);
      }

      public bool IsEqual(CipherSuiteItem i)
      {
        bool isEqual = true;

        if (isEqual)
         {
            isEqual = (i.IsChecked == IsChecked);
         }
        if (isEqual)
         {
            isEqual = (i.Cipher == Cipher);
         }
        return isEqual;
      }

      public string Serialize()
      {
         return string.Format("{0},{1}", this.Cipher.ToString(), this.IsChecked.ToString());
      }

      internal static T MyParseEnum<T>(string value)
      {
         return (T)Enum.Parse(typeof(T), value, true);
      }

      public static CipherSuiteItem Deserialize(string s)
      {
         CipherSuiteItem item = null;
         string []itemStrings = s.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries);
         if (itemStrings.Length == 2)
         {
            bool isChecked = Convert.ToBoolean(itemStrings[1]);
            DicomTlsCipherSuiteType cipherSuiteType = MyParseEnum<DicomTlsCipherSuiteType>(itemStrings[0]);
            item = new CipherSuiteItem(isChecked, cipherSuiteType);
         }
         return item;
      }

      public override string ToString()
      {
         return CipherTypeToString(Cipher);
      }

      public bool IsTls_1_2
      {
         get
         {
            bool isTls_1_2 =
               (Cipher == DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256) ||
               (Cipher == DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256) ||
               (Cipher == DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384) ||
               (Cipher == DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384);
            return isTls_1_2;
         }
      }

      DicomTlsCipherSuiteType CipherStringToType(string cipherString)
      {
         DicomTlsCipherSuiteType cipherResult = DicomTlsCipherSuiteType.None;

         if (string.Compare(cipherString, "TLS_RSA_WITH_AES_128_CBC_SHA") == 0)
            cipherResult = DicomTlsCipherSuiteType.RsaWithAes128CbcSha;
         else if (string.Compare(cipherString, "TLS_RSA_WITH_3DES_EDE_CBC_SHA") == 0)
            cipherResult = DicomTlsCipherSuiteType.RsaWith3DesEdeCbcSha;
         else if (string.Compare(cipherString, "TLS_DHE_RSA_WITH_AES_128_GCM_SHA256") == 0)
            cipherResult = DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256;
         else if (string.Compare(cipherString, "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256") == 0)
            cipherResult = DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256;
         else if (string.Compare(cipherString, "TLS_DHE_RSA_WITH_AES_256_GCM_SHA384") == 0)
            cipherResult = DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384;
         else if (string.Compare(cipherString, "TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384") == 0)
            cipherResult = DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384;

         if (cipherResult == DicomTlsCipherSuiteType.None)
         {
            Debug.Assert(cipherResult != DicomTlsCipherSuiteType.None);
         }
         return cipherResult;
      }

      string CipherTypeToString(DicomTlsCipherSuiteType cipherType)
      {
         string cipherString = string.Empty;

         switch (cipherType)
         {
            case DicomTlsCipherSuiteType.RsaWithAes128CbcSha:
               cipherString = "TLS_RSA_WITH_AES_128_CBC_SHA";
               break;

            case DicomTlsCipherSuiteType.RsaWith3DesEdeCbcSha:
               cipherString = "TLS_RSA_WITH_3DES_EDE_CBC_SHA";
               break;

            case DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256:
               cipherString = "TLS_DHE_RSA_WITH_AES_128_GCM_SHA256";
               break;

            case DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256:
               cipherString = "TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256";
               break;

            case DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384:
               cipherString = "TLS_DHE_RSA_WITH_AES_256_GCM_SHA384";
               break;

            case DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384:
               cipherString = "TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384";
               break;
         }

         return cipherString;
      }
   }

   [Serializable]
   public class CipherSuiteItems
   {
      List<CipherSuiteItem> _cipherSuiteItemList = new List<CipherSuiteItem>();

      public CipherSuiteItems()
      {
      }

      public static CipherSuiteItems Deserialize(string s)
      {
         CipherSuiteItems items = new CipherSuiteItems();
         items.Clear();

         string []cipherStringList = s.Split( new char[]{';' }, StringSplitOptions.RemoveEmptyEntries); 
         foreach(string cipherString in cipherStringList)
         {
            CipherSuiteItem item = CipherSuiteItem.Deserialize(cipherString);
            items.ItemList.Add(item);
         }

         return items;
      }

      public string Serialize()
      {
         string returnString = string.Empty;
         foreach (CipherSuiteItem item in ItemList)
         {
            returnString = returnString + ";"  + item.Serialize();
         }

         if (returnString.Length > 0)
         {
            returnString = returnString.Substring(1);
         }

         return returnString;
      }

      public static string Serialize(CipherSuiteItems cipherSuiteItems)
      {
         XmlSerializer xmlSerializer = new XmlSerializer(typeof(CipherSuiteItems));
         using (StringWriter textWriter = new StringWriter())
         {
            xmlSerializer.Serialize(textWriter, cipherSuiteItems);
            return textWriter.ToString();
         }
      }

      public bool IsEqual(CipherSuiteItems c)
      {
         bool isEqual = true;
         if (isEqual)
         {
            isEqual = (c.ItemList.Count == ItemList.Count);
         }

         if (isEqual)
         {
            for (int i = 0; i<c.ItemList.Count; i++)
            {
               CipherSuiteItem item1 = c.ItemList[i] as CipherSuiteItem;
               CipherSuiteItem item2 = ItemList[i] as CipherSuiteItem;
               if (item1 != null && item2 != null)
               {
                  isEqual = isEqual && item1.IsEqual(item2);
               }

            }
         }

         return isEqual;
      }

      public void Clear()
      {
         _cipherSuiteItemList.Clear();
      }

      public void Default()
      {
         Clear();
         ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256));
         ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384));
         ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256));
         ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384));
      }

      public List<CipherSuiteItem> ItemList
      {
         get
         {
            return _cipherSuiteItemList;
         }
      }

      public bool Contains(string cipherSuiteName)
      {
         foreach (CipherSuiteItem cipherSuiteItem in _cipherSuiteItemList)
         {
            if (cipherSuiteItem.ToString() == cipherSuiteName)
               return true;
         }
         return false;
      }

      public bool AddOldCipherSuites()
      {
         bool changed = false;
         bool onlyTLS12CipherSuites = true;
         foreach (CipherSuiteItem cipherSuiteItem in _cipherSuiteItemList)
         {
            if (cipherSuiteItem.IsTls_1_2 == false)
               onlyTLS12CipherSuites = false;
         }

         if (onlyTLS12CipherSuites)
         {
            _cipherSuiteItemList.Add(new CipherSuiteItem(false, DicomTlsCipherSuiteType.RsaWithAes128CbcSha));
            _cipherSuiteItemList.Add(new CipherSuiteItem(false, DicomTlsCipherSuiteType.RsaWith3DesEdeCbcSha));
            changed = true;
         }
         return changed;
      }

      public bool RemoveOldCipherSuites()
      {
         bool changed = false;
         int cipherSuiteItemCount = _cipherSuiteItemList.Count;
         for (int i = cipherSuiteItemCount - 1; i >= 0; i--)
         {
            if (_cipherSuiteItemList[i].IsTls_1_2 == false)
            {
               _cipherSuiteItemList.RemoveAt(i);
               changed = true;
            }
         }
         return changed;
      }

      public bool ContainsOldCipherSuites()
      {
         bool containsOldCipherSuites = false;
         for (int i = 0; i < _cipherSuiteItemList.Count; i++)
         {
            if (_cipherSuiteItemList[i].IsTls_1_2 == false)
            {
               containsOldCipherSuites = true;
               break;
            }
         }
         return containsOldCipherSuites;
      }
   }

   public class ClientPortSecurityTypeItem
   {
      public ClientPortUsageType ClientSecurity { get; set; }
      public string Description { get; set; }
      public ClientPortSecurityTypeItem(ClientPortUsageType clientSecurity, string description)
      {
         ClientSecurity = clientSecurity;
         Description = description;
      }

      public override string ToString()
      {
         return Description;
      }
   }

   [Serializable]
   public class DicomDemoSettings : IWorkstationSettings
   {
      public DicomDemoSettings()
      {
         ServerList = new List<DicomAE>();
         FileList = new List<string>();
         ClientAe = new DicomAE();
         _logLowLevel = false;
         _groupLengthDataElements = false;
         _showHelpOnStart = true;
         _isPreconfigured = false;
         _firstRun = true;
         _compression = 0;
         _broadQuery = false;
         _excludeList = new List<long>();
         _storageClassList = new List<string>();
         _dicomRetrieveMode = DicomRetrieveMode.CMove;
         _storageCommitResultsOnSameAssociation = true;

         _clientSecurity = ClientPortUsageType.Unsecure;

         _cipherSuiteItems = new CipherSuiteItems();
         _cipherSuiteItems.ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.EcdheRsaWithAes128GcmSha256));
         _cipherSuiteItems.ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.EcdheRsaWithAes256GcmSha384));
         _cipherSuiteItems.ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.DheRsaWithAes128GcmSha256));
         _cipherSuiteItems.ItemList.Add(new CipherSuiteItem(true, DicomTlsCipherSuiteType.DheRsaWithAes256GcmSha384));
      }

      private CipherSuiteItems _cipherSuiteItems;
      private List<DicomAE> _serverArrayList;
      private List<string> _fileArrayList;
      private DicomAE _clientAe;
      private string _defaultStore;
      private string _defaultImageQuery;
      private string _defaultMwlQuery;
      private string _defaultMpps;
      private string _clientCertificate;
      private string _certificateAuthority;
      private ClientPortUsageType _clientSecurity;
      private string _clientPrivateKey;
      private string _clientPrivateKeyPassword;
      private string _workstationServer;
      private string _highLevelStorageServer;
      private bool _logLowLevel;
      private bool _groupLengthDataElements;
      private bool _showHelpOnStart;
      private bool _isPreconfigured;
      private bool _firstRun;
      private int _compression;
      private string _dataPath;
      private bool _broadQuery;
      private List<long> _excludeList;
      private string _temporaryDirectory;
      private string _implementationClass;
      private string _protocolVersion;
      private string _implementationVersionName;
      private List<string> _storageClassList;
      private DicomRetrieveMode _dicomRetrieveMode;
      private bool _disableLogging = false;
      private bool _storageCommitResultsOnSameAssociation;

      public DicomAE GetServer(string sa)
      {
         DicomAE ret = null;
         foreach (DicomAE ae in _serverArrayList)
         {
            if (string.Compare(ae.AE, sa, true) == 0)
               ret = ae;
         }
         return ret;
      }

      public string GetServerAe(string sa)
      {
         DicomAE ae = GetServer(sa);
         if (ae != null)
            return ae.AE;
         else
            return string.Empty;
      }

      public int GetServerPort(string sa)
      {
         DicomAE ae = GetServer(sa);
         if (ae != null)
            return ae.Port;
         else
            return 0;
      }

      //[XmlElement("servers")]
      public List<DicomAE> ServerList
      {
         get
         {
            return _serverArrayList;
         }

         set
         {
            _serverArrayList = value;
         }
      }

      public CipherSuiteItems CipherSuites
      {
         get
         {
            return _cipherSuiteItems;
         }
         set
         {
            _cipherSuiteItems = value;
         }
      }

      public List<string> FileList
      {
         get
         {
            return _fileArrayList;
         }

         set
         {
            _fileArrayList = value;
         }
      }

      public DicomAE ClientAe
      {
         get { return _clientAe; }
         set { _clientAe = value; }
      }

      public string DefaultStore
      {
         get { return _defaultStore; }
         set { _defaultStore = value; }
      }


      public string DefaultImageQuery
      {
         get { return _defaultImageQuery; }
         set { _defaultImageQuery = value; }
      }


      public string DefaultMwlQuery
      {
         get { return _defaultMwlQuery; }
         set { _defaultMwlQuery = value; }
      }

      public string DefaultMpps
      {
         get { return _defaultMpps; }
         set { _defaultMpps = value; }
      }

      public string CertificateAuthority
      {
         get { return _certificateAuthority;}
         set {_certificateAuthority = value; }
      }

      public string ClientCertificate
      {
         get { return _clientCertificate; }
         set { _clientCertificate = value; }
      }

      public ClientPortUsageType ClientPortSecurityUsage
      {
         get { return _clientSecurity; }
         set { _clientSecurity = value; }
      }

      public string ClientPrivateKey
      {
         get { return _clientPrivateKey; }
         set { _clientPrivateKey = value; }
      }

      public string ClientPrivateKeyPassword
      {
         get { return _clientPrivateKeyPassword; }
         set { _clientPrivateKeyPassword = value; }
      }

      public string WorkstationServer
      {
         get { return _workstationServer; }
         set { _workstationServer = value; }
      }

      public string HighLevelStorageServer
      {
         get { return _highLevelStorageServer; }
         set { _highLevelStorageServer = value; }
      }

      public bool LogLowLevel
      {
         get { return _logLowLevel; }
         set { _logLowLevel = value; }
      }

      public bool GroupLengthDataElements
      {
         get { return _groupLengthDataElements; }
         set { _groupLengthDataElements = value; }
      }

      public bool ShowHelpOnStart
      {
         get { return _showHelpOnStart; }
         set { _showHelpOnStart = value; }
      }

      public bool IsPreconfigured
      {
         get { return _isPreconfigured; }
         set { _isPreconfigured = value; }
      }

      public int Compression
      {
         get { return _compression; }
         set { _compression = value; }
      }

      public bool FirstRun
      {
         get { return _firstRun; }
         set { _firstRun = value; }
      }

      public string DataPath
      {
         get { return _dataPath; }
         set { _dataPath = value; }
      }

      public bool BroadQuery
      {
         get { return _broadQuery; }
         set { _broadQuery = value; }
      }

      public List<long> ExcludeList
      {
         get { return _excludeList; }
         set { _excludeList = value; }
      }

      public List<string> StorageClassList
      {
         get { return _storageClassList; }
         set { _storageClassList = value; }
      }

      public string TemporaryDirectory
      {
         get { return _temporaryDirectory; }
         set { _temporaryDirectory = value; }
      }

      public string ImplementationClass
      {
         get { return _implementationClass; }
         set { _implementationClass = value; }
      }

      public string ProtocolVersion
      {
         get { return _protocolVersion; }
         set { _protocolVersion = value; }
      }

      public string ImplementationVersionName
      {
         get { return _implementationVersionName; }
         set { _implementationVersionName = value; }
      }

      private bool _ViewerBeforeSend = false;

      public bool ViewerBeforeSend
      {
         get { return _ViewerBeforeSend; }
         set { _ViewerBeforeSend = value; }
      }

      public DicomRetrieveMode DicomImageRetrieveMethod
      {
         get { return _dicomRetrieveMode; }
         set { _dicomRetrieveMode = value; }
      }

      public bool DisableLogging
      {
         get
         {
            return _disableLogging;
         }
         set
         {
            _disableLogging = value;
         }
      }

      public bool StorageCommitResultsOnSameAssociation
      {
         get
         {
            return _storageCommitResultsOnSameAssociation;
         }
         set
         {
            _storageCommitResultsOnSameAssociation = value;
         }
      }
   }

   public interface IWorkstationSettings
   {
      List<DicomAE> ServerList
      {
         get;
         set;
      }

      DicomAE ClientAe
      {
         get;
         set;
      }

      string WorkstationServer
      {
         get;
         set;
      }

      string DefaultImageQuery
      {
         get;
         set;
      }

      string DefaultStore
      {
         get;
         set;
      }

      DicomAE GetServer(string serverName);
   }

   public class Templates
   {
      public const string MWLFind = @"<?xml version=""1.0"" encoding=""utf-8""?>
<!--LEAD Technologies, Inc. DICOM XML format-->
<dataset IgnoreBinaryData=""false"" IgnoreAllData=""false"" EncodeBinaryBase64=""true"" EncodeBinaryBinHex=""false"" TagWithCommas=""false"" TrimWhiteSpace=""false"">
<element tag=""00020002"" vr=""UI"" vm=""1"" len=""22"" name=""MediaStorageSOPClassUID"">1.2.840.10008.5.1.4.31</element>
                                   <element tag=""00020010"" vr=""UI"" vm=""1"" len=""20"" name=""TransferSyntaxUID"">1.2.840.10008.1.2.1</element>
                                   <element tag=""00080005"" vr=""CS"" vm=""0"" len=""0"" name=""SpecificCharacterSet"" />
                                   <element tag=""00080050"" vr=""SH"" vm=""0"" len=""0"" name=""AccessionNumber"" />
                                   <element tag=""00080080"" vr=""LO"" vm=""0"" len=""0"" name=""InstitutionName"" />
                                   <element tag=""00080081"" vr=""ST"" vm=""0"" len=""0"" name=""InstitutionAddress"" />
                                   <element tag=""00080090"" vr=""PN"" vm=""0"" len=""0"" name=""ReferringPhysicianName"" />
                                   <!-- <element tag=""00081110"" vr=""SQ"" vm=""0"" len=""-1"" name=""ReferencedStudySequence"" /> -->
                                   <element tag=""00081120"" vr=""SQ"" vm=""0"" len=""-1"" name=""ReferencedPatientSequence"">
                                     <element tag=""FFFEE000"" vr=""OB"" vm=""0"" len=""-1"" name=""Item"">
                                       <element tag=""00081150"" vr=""UI"" vm=""0"" len=""0"" name=""ReferencedSOPClassUID"" />
                                       <element tag=""00081155"" vr=""UI"" vm=""0"" len=""0"" name=""ReferencedSOPInstanceUID"" />
                                     </element>
                                   </element>
                                   <element tag=""00100010"" vr=""PN"" vm=""0"" len=""0"" name=""PatientName"" />
                                   <element tag=""00100020"" vr=""LO"" vm=""0"" len=""0"" name=""PatientID"" />
                                   <element tag=""00100030"" vr=""DA"" vm=""0"" len=""0"" name=""PatientBirthDate"" />
                                   <element tag=""00100040"" vr=""CS"" vm=""0"" len=""0"" name=""PatientSex"" />
                                   <element tag=""00101000"" vr=""LO"" vm=""0"" len=""0"" name=""OtherPatientIDs"" />
                                   <element tag=""00101001"" vr=""PN"" vm=""0"" len=""0"" name=""OtherPatientNames"" />
                                   <element tag=""00101030"" vr=""DS"" vm=""0"" len=""0"" name=""PatientWeight"" />
                                   <element tag=""00101040"" vr=""LO"" vm=""0"" len=""0"" name=""PatientAddress"" />
                                   <element tag=""00102000"" vr=""LO"" vm=""0"" len=""0"" name=""MedicalAlerts"" />
                                   <element tag=""00102110"" vr=""LO"" vm=""0"" len=""0"" name=""Allergies"" />
                                   <element tag=""001021B0"" vr=""LT"" vm=""0"" len=""0"" name=""AdditionalPatientHistory"" />
                                   <element tag=""001021C0"" vr=""US"" vm=""0"" len=""0"" name=""PregnancyStatus"" />
                                   <element tag=""00104000"" vr=""LT"" vm=""0"" len=""0"" name=""PatientComments"" />
                                   <element tag=""0020000D"" vr=""UI"" vm=""0"" len=""0"" name=""StudyInstanceUID"" />
                                   <element tag=""00321032"" vr=""PN"" vm=""0"" len=""0"" name=""RequestingPhysician"" />
                                   <element tag=""00321033"" vr=""LO"" vm=""0"" len=""0"" name=""RequestingService"" />
                                   <element tag=""00321060"" vr=""LO"" vm=""0"" len=""0"" name=""RequestedProcedureDescription"" />
                                   <element tag=""00321064"" vr=""SQ"" vm=""0"" len=""-1"" name=""RequestedProcedureCodeSequence"">
                                     <element tag=""FFFEE000"" vr=""OB"" vm=""0"" len=""-1"" name=""Item"" />
                                   </element>
                                   <element tag=""00380010"" vr=""LO"" vm=""0"" len=""0"" name=""AdmissionID"" />
                                   <element tag=""00380050"" vr=""LO"" vm=""0"" len=""0"" name=""SpecialNeeds"" />
                                   <element tag=""00380300"" vr=""LO"" vm=""0"" len=""0"" name=""CurrentPatientLocation"" />
                                   <element tag=""00380500"" vr=""LO"" vm=""0"" len=""0"" name=""PatientState"" />
                                   <element tag=""00400100"" vr=""SQ"" vm=""0"" len=""-1"" name=""ScheduledProcedureStepSequence"">
                                     <element tag=""FFFEE000"" vr=""OB"" vm=""0"" len=""-1"" name=""Item"">
                                       <element tag=""00080060"" vr=""CS"" vm=""0"" len=""0"" name=""Modality"" />
                                       <element tag=""00321070"" vr=""LO"" vm=""0"" len=""0"" name=""RequestedContrastAgent"" />
                                       <element tag=""00400001"" vr=""AE"" vm=""0"" len=""0"" name=""ScheduledStationAETitle"" />
                                       <element tag=""00400002"" vr=""DA"" vm=""0"" len=""0"" name=""ScheduledProcedureStepStartDate"" />
                                       <element tag=""00400003"" vr=""TM"" vm=""0"" len=""0"" name=""ScheduledProcedureStepStartTime"" />
                                       <element tag=""00400006"" vr=""PN"" vm=""0"" len=""0"" name=""ScheduledPerformingPhysicianName"" />
                                       <element tag=""00400007"" vr=""LO"" vm=""0"" len=""0"" name=""ScheduledProcedureStepDescription"" />
                                       <element tag=""00400008"" vr=""SQ"" vm=""0"" len=""-1"" name=""ScheduledProtocolCodeSequence"">
                                         <element tag=""FFFEE000"" vr=""OB"" vm=""0"" len=""-1"" name=""Item"" />
                                       </element>
                                       <element tag=""00400009"" vr=""SH"" vm=""0"" len=""0"" name=""ScheduledProcedureStepID"" />
                                       <element tag=""00400010"" vr=""SH"" vm=""0"" len=""0"" name=""ScheduledStationName"" />
                                       <element tag=""00400011"" vr=""SH"" vm=""0"" len=""0"" name=""ScheduledProcedureStepLocation"" />
                                       <element tag=""00400012"" vr=""LO"" vm=""0"" len=""0"" name=""PreMedication"" />
                                       <element tag=""00400020"" vr=""CS"" vm=""0"" len=""0"" name=""ScheduledProcedureStepStatus"" />
                                       <element tag=""00400400"" vr=""LT"" vm=""0"" len=""0"" name=""CommentsOnTheScheduledProcedureStep"" />
                                     </element>
                                   </element>
                                   <element tag=""00401001"" vr=""SH"" vm=""0"" len=""0"" name=""RequestedProcedureID"" />
                                   <element tag=""00401002"" vr=""LO"" vm=""0"" len=""0"" name=""ReasonForTheRequestedProcedure"" />
                                   <element tag=""00401003"" vr=""SH"" vm=""0"" len=""0"" name=""RequestedProcedurePriority"" />
                                   <element tag=""00401010"" vr=""PN"" vm=""0"" len=""0"" name=""NamesOfIntendedRecipientsOfResults"" />
                                   <element tag=""00402001"" vr=""LO"" vm=""0"" len=""0"" name=""ReasonForTheImagingServiceRequest"" />
                                   <element tag=""00402016"" vr=""LO"" vm=""0"" len=""0"" name=""PlacerOrderNumberImagingServiceRequest"" />
                                   <element tag=""00402017"" vr=""LO"" vm=""0"" len=""0"" name=""FillerOrderNumberImagingServiceRequest"" />
                                   <element tag=""00402400"" vr=""LT"" vm=""0"" len=""0"" name=""ImagingServiceRequestComments"" />
                                   <element tag=""00403001"" vr=""LO"" vm=""0"" len=""0"" name=""ConfidentialityConstraintOnPatientDataDescription"" />
</dataset>";
   }

   [Serializable]
   public class StorageServerInformation
   {
      public StorageServerInformation()
         : this(null, null, null)
      { }
      public StorageServerInformation(DicomAE server, string serviceName, string machineName)
      {
         DicomServer = server;
         ServiceName = serviceName;
         MachineName = machineName;
      }

      public DicomAE DicomServer { get; set; }
      public string ServiceName { get; set; }
      public string MachineName { get; set; }
   }

   public static class Extensions
   {
      // converts an enum value to an integer
      public static int ToInt(this Enum enumValue)
      {
         return (int)((object)enumValue);
      }

      // returns true if the flags 'field' has the flag 'value' set
      public static bool IsFlagged(this Enum field, Enum value)
      {
         return (field.ToInt() & value.ToInt()) == value.ToInt();
      }
   }

   public static class SecurityExtensions
   {
      public enum MoveDirection { Up = -1, Down = 1 };

      public static void MoveListViewItems(this ListView myListView, MoveDirection direction)
      {
         bool valid = myListView.SelectedItems.Count > 0 &&
                     ((direction == MoveDirection.Down && (myListView.SelectedItems[myListView.SelectedItems.Count - 1].Index < myListView.Items.Count - 1))
                     || (direction == MoveDirection.Up && (myListView.SelectedItems[0].Index > 0)));

         if (valid)
         {
            bool start = true;
            int firstIndex = 0;
            List<ListViewItem> items = new List<ListViewItem>();

            foreach (ListViewItem i in myListView.SelectedItems)
            {
               if (start)
               {
                  firstIndex = i.Index;
                  start = false;
               }
               items.Add(i);
            }

            myListView.BeginUpdate();
            foreach (ListViewItem i in myListView.SelectedItems) i.Remove();

            // insert
            if (direction == MoveDirection.Up)
            {
               int insertTo = firstIndex - 1;
               foreach (ListViewItem i in items)
               {
                  ListViewItem item = myListView.Items.Insert(insertTo, i);
                  item.Selected = true;
                  insertTo++;
               }
            }
            else
            {
               int insertTo = firstIndex + 1;
               foreach (ListViewItem i in items)
               {
                  myListView.Items.Insert(insertTo, i);
                  insertTo++;
               }
            }
            myListView.EndUpdate();
         }
         myListView.Focus();
      }


      public static void InitializeCipherListView(this ListView listView, CipherSuiteItems cipherSuites, ImageList imageListCiphers)
      {

         listView.View = View.Details;
         listView.CheckBoxes = true;
         listView.MultiSelect = true;
         listView.HideSelection = false;
         listView.SmallImageList = imageListCiphers;

         listView.Columns.Add("Cipher", 300);
         listView.Columns.Add("TLS Version", 80);

         UpdateCipherSuitesListView(listView, cipherSuites);
      }

      public static void ListViewToCipherSuites(this ListView listView, CipherSuiteItems cipherSuites, bool initializing)
      {
         if (initializing)
            return;

         cipherSuites.Clear();
         foreach (ListViewItem listViewItem in listView.Items)
         {
            CipherSuiteItem cipherSuiteItem = new CipherSuiteItem(listViewItem.Checked, listViewItem.Text);
            cipherSuites.ItemList.Add(cipherSuiteItem);
         }
      }

      public static void UpdateCipherSuitesListView(this ListView listView, CipherSuiteItems cipherSuites)
      {
         if (listView.Items.Count == 0)
         {
            foreach (CipherSuiteItem cipherSuiteItem in cipherSuites.ItemList)
            {
               ListViewItem item = listView.Items.Add(cipherSuiteItem.ToString(), cipherSuiteItem.IsTls_1_2 ? 2 : 1);
               item.SubItems.Add(cipherSuiteItem.IsTls_1_2 ? "1.2" : "1.0");
               item.Checked = cipherSuiteItem.IsChecked;
            }
         }
         else
         {
            int addCount = cipherSuites.ItemList.Count - listView.Items.Count;
            if (addCount > 0)
            {
               for (int i = 0; i < addCount; i++)
               {
                  CipherSuiteItem cipherSuiteItem = cipherSuites.ItemList[listView.Items.Count];
                  ListViewItem item = listView.Items.Add(cipherSuiteItem.ToString(), cipherSuiteItem.IsTls_1_2 ? 2 : 1);
                  item.SubItems.Add(cipherSuiteItem.IsTls_1_2 ? "1.2" : "1.0");
                  item.Checked = cipherSuiteItem.IsChecked;
               }
            }
            else if (addCount < 0)
            {
               foreach (ListViewItem listViewItem in listView.Items)
               {
                  if (!cipherSuites.Contains(listViewItem.Text))
                  {
                     listView.Items.Remove(listViewItem);
                  }
               }

            }
         }
      }
   }
}
