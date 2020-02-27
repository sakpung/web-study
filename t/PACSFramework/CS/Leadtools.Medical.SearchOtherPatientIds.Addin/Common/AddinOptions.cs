// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.SearchOtherPatientId.Addin.Dialogs;
using Leadtools.Medical.SearchOtherPatientIds.Addin.Properties;

namespace Leadtools.Medical.SearchOtherPatientId.Addin.Common
{
   public class AddinOptions: MarshalByRefObject,IAddInOptions
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
                  _image = new AddInImage(Resources.SearchOtherPatientId);
               }
               return _image;
            }
        }        

        public string Text
        {
            get
            {
                return "Other Patient IDs";
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
