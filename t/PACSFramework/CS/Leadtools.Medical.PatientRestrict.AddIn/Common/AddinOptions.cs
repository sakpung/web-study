// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************

using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Medical.PatientRestrict.AddIn.Dialogs;
using Leadtools.Medical.PatientRestrict.AddIn.Properties;
using System;
using System.Windows.Forms;

namespace Leadtools.Medical.PatientRestrict.AddIn.Common
{
   public class AddinOptions : MarshalByRefObject, IAddInOptions
   {
      private AddInImage _image;

      public AddinOptions()
      {
         _image = null;
      }

      #region IAddInOptions Members

      //
      // Icons should be converted to png
      //
      public AddInImage Image
      {
         get
         {
            if (_image == null)
            {
               _image = new AddInImage(Resources.PatientId_30);
            }
            return _image;
         }
      }

      public string Text
      {
         get
         {
            return "Patient Restrict";
         }
      }

      public void Configure(IWin32Window Parent, ServerSettings Settings, string ServerDirectory)
      {
         AdvancedSettings settings = AdvancedSettings.Open(ServerDirectory);
         IConfigureDialog configure = new AddinConfiguration();
         configure.Initialize(settings, Settings, ServerDirectory);
         configure.ShowDialog(Parent);
      }
      #endregion
   }
}
