// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.DicomDemos;
using System.IO;
using Leadtools.Medical.Winforms.Anonymize;

namespace Leadtools.Medical.Winforms.DatabaseManager.Export
{
   [Serializable]
   public class ExportOptions
   {
      public const string OptionsKey = "ExportOptions";

      public ExportOptions()
      {
         OverwriteExisting = true;
         CreateDicomDirectory = true;
         Anonmyize = true;
         string commonDocumentsFolder = DicomDemoSettingsManager.GetFolderPath();
         ExportFolder = Path.Combine(commonDocumentsFolder, "Export"); 
      }
      public bool OverwriteExisting { get; set; }
      public bool CreateDicomDirectory { get; set; }
      public bool Anonmyize { get; set; }
      public string ExportFolder { get; set; }
   }

   public class SaveAnonymizeSettingsEventArgs : EventArgs
   {
      public SaveAnonymizeSettingsEventArgs()
      {
         Scripts = null;
         Handled = false;
      }

      public SaveAnonymizeSettingsEventArgs(AnonymizeScripts scripts)
      {
         Scripts = scripts;
         Handled = false;
      }
      public AnonymizeScripts Scripts { get; set;}
      public bool Handled { get; set;}
   }
}
