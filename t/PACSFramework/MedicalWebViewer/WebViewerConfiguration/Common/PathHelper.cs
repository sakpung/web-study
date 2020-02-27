// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Demos;
using System.IO;
using System.Configuration;
using System.Reflection;

namespace WebViewerConfiguration
{
   class PathHelper
   {
      /// <summary>
      /// Gets a value whether we should use installation structure for running EXE and creating pathes
      /// </summary>
      /// <returns></returns>
      public static bool UseLeadPath ( ) 
      {
         string useLeadString = ConfigurationManager.AppSettings[ "UseLeadPath" ] ;
         bool useLeadPath = true ;
         
         if ( bool.TryParse ( useLeadString, out useLeadPath ) )
         {
            return useLeadPath;
         }
         else
         {
            return false ;
         }
      }

      public static bool UseMedicorPath()
      {
         string useMedicorString = ConfigurationManager.AppSettings["UseMedicorPath"];
         bool useMedicorPath = true;

         if (bool.TryParse(useMedicorString, out useMedicorPath))
         {
            return useMedicorPath;
         }
         else
         {
            return false;
         }
      }

        public static bool UseExternalWebServicePath()
        {
            string useString = ConfigurationManager.AppSettings["UseExternalWebServicePath"];
            bool usePath = true;

            if (bool.TryParse(useString, out usePath))
            {
                return usePath;
            }
            else
            {
                return false;
            }
        }

      public static bool UseNugetPathAndAspServiceIncluded()
      {
         string pacsFolder = PathHelper.GetNugetPath();
         string aspPath = Path.Combine(pacsFolder, @"MedicalWebViewer\Leadtools.Medical.WebViewer.ASP");
         return Directory.Exists(aspPath);
      }

        public static bool UseNugetPath()
      {
#if USES_NUGET
         return true;
#else
         string useNugetString = ConfigurationManager.AppSettings["UseNugetPath"];
         bool useNugetPath = true;

         if (bool.TryParse(useNugetString, out useNugetPath))
         {
            return useNugetPath;
         }
         else
         {
            return false;
         }
#endif
      }

      private static string _nugetExamplesPath = string.Empty;
      private static string GetNugetPath()
      {
         if (!string.IsNullOrEmpty(_nugetExamplesPath))
         {
            return _nugetExamplesPath;
         }
         string exeFolder = Assembly.GetExecutingAssembly().Location.ToLower();
         string parent = Directory.GetParent(exeFolder).FullName;
         string prevParent = parent;

         string[] folderNames = parent.Split(new char[] { '/', '\\' }, StringSplitOptions.RemoveEmptyEntries);
         string pacsFrameWorkFolderName = string.Empty;
         foreach (string s in folderNames)
         {
            if (s.Contains("pacsframework"))
            {
               pacsFrameWorkFolderName = s;
            }
         }

         while (!parent.EndsWith(pacsFrameWorkFolderName))
         {
            prevParent = parent;
            parent = Directory.GetParent(parent).FullName;
         }
         System.Diagnostics.Debug.Assert(parent.EndsWith(pacsFrameWorkFolderName));
         return parent;
      }

      /// <summary>
      /// Returns the path to the WCF service web.config
      /// </summary>
      /// <returns></returns>
      public static string GetWcfServiceConfigPath ( ) 
      {
         if (UseExternalWebServicePath())
         {
            string path =  Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Leadtools.Medical.WebViewer.WCF"), @"web.config");
            return path;
         }
         else if (UseNugetPath())
         {
            string baseLocation = GetNugetPath();
            baseLocation = Path.Combine(baseLocation, @"MedicalWebViewer\Leadtools.Medical.WebViewer.WCF");
            baseLocation = Path.Combine(baseLocation, @"web.config");
            return baseLocation ;
         }
         else if ( UseLeadPath ( ) )
         {
            //if LEAD path use our directory structure otherwise use Medicor
            string baseLocation = DemosGlobal.InstallLocation;
            baseLocation = Path.Combine(baseLocation, @"Examples\DotNet\PACSFramework\MedicalWebViewer\Leadtools.Medical.WebViewer.WCF");
            baseLocation = Path.Combine(baseLocation, @"web.config");
            return baseLocation;
         }
         else if (UseMedicorPath())
         {
            return Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"MedicalViewerServiceWcf"), @"web.config");
         }
         else
         {
            return Path.Combine ( Path.Combine ( Path.GetDirectoryName ( Assembly.GetExecutingAssembly ( ).Location ), @"MedicalViewerServiceWcf20" ), @"web.config" ) ;
         }
      }

      public static string GetAspServiceConfigPath()
      {
         if (UseExternalWebServicePath())
         {
            string path = Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Leadtools.Medical.WebViewer.ASP\Leadtools.Medical.WebViewer"), @"web.config");
            return path;
         }
         else if (UseNugetPath())
         {
            string baseLocation = GetNugetPath();
            baseLocation = Path.Combine(baseLocation, @"MedicalWebViewer\Leadtools.Medical.WebViewer.ASP\Leadtools.Medical.WebViewer");
            baseLocation = Path.Combine(baseLocation, @"web.config");
            return baseLocation;
         }
         else if (UseLeadPath())
         {
         //if LEAD path use our directory structure other wise use Medicor
            string baseLocation = DemosGlobal.InstallLocation;
            baseLocation = Path.Combine(baseLocation, @"Examples\DotNet\PACSFramework\MedicalWebViewer\Leadtools.Medical.WebViewer.ASP\Leadtools.Medical.WebViewer");
            baseLocation = Path.Combine(baseLocation, @"web.config");
            return baseLocation;
         }
         else if (UseMedicorPath())
         {
            return Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"MedicalViewerServiceAsp"), @"web.config");
         }
         else
         {
            return Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"MedicalViewerServiceAsp20"), @"web.config");
         }
      }

      public static string GetDICOMwebServiceConfigPath()
      {
         if (UseMedicorPath())
         {
            return Path.Combine(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"DICOMweb"), @"web.config");
         }
         else
         {
            return null;
         }
      }
      

      public static string GetThisExeName()
      {
         return Path.GetFileName(Assembly.GetExecutingAssembly().Location);
      }

      public static string GetExePath()
      {
         return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      }
   }
}
