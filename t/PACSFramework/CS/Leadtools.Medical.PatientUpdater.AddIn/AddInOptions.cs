// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Common;
using System.Drawing;
using Leadtools.Medical.PatientUpdater.AddIn.Properties;
using System.Drawing.Imaging;
using Leadtools.Dicom.AddIn.Configuration;
using System.Reflection;
using Leadtools.Medical.PatientUpdater.AddIn.Dialogs;

namespace Leadtools.Medical.PatientUpdater.AddIn
{
   [Serializable]
   public class AddInOptions : MarshalByRefObject, IAddInOptions
   {
      #region IAddInOptions Members

      public void Configure(IWin32Window Parent, ServerSettings Settings, string ServerDirectory)
      {
         AdvancedSettings settings = AdvancedSettings.Open(ServerDirectory);
         string name = Assembly.GetExecutingAssembly().GetName().Name;
         Type dialogType = settings.GetAddInControlType(name, "PatientUpdaterConfig");
         IConfigureDialog configure = null;

         if (dialogType != null)
         {
            //
            // Load configuration dialog
            //
            configure = Activator.CreateInstance(dialogType) as IConfigureDialog;
         }

         if (configure == null)
         {
            configure = new PatientUpdaterConfiguration();
         }         

         configure.Initialize(settings, Settings, ServerDirectory);
         configure.ShowDialog(Parent);         
      }

      public AddInImage Image
      {
         get 
         {
            return new AddInImage(Resources.PatientUpdater);
         }
      }

      public string Text
      {
         get 
         {
            return "Patient Updater";
         }
      }

      #endregion
   }
}
