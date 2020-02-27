// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom;
using Leadtools.Dicom.AddIn.Configuration;
using Leadtools.Medical.AutoCopy.AddIn.Properties;
using System.Reflection;
using Leadtools.Medical.AutoCopy.AddIn.Dialogs;

namespace Leadtools.Medical.AutoCopy.AddIn
{
    [Serializable]
    public class AddInOptions : MarshalByRefObject,IAddInOptions
    {
        public AddInOptions()
        {
        }

        #region IAddInOptions Members

        //
        // Icons should be converted to png
        //
        public AddInImage Image
        {
            get 
            {
               return new AddInImage(Resources.AutoCopy);
            }
        }        

        public string Text
        {
            get
            {
                return "Auto Copy";
            }
        }

        public void Configure(IWin32Window Parent, ServerSettings Settings, string ServerDirectory)
        {
           AdvancedSettings settings = AdvancedSettings.Open(ServerDirectory);
           string name = Assembly.GetExecutingAssembly().GetName().Name;
           Type dialogType = settings.GetAddInControlType(name, "AutoUpdateConfig");
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
              configure = new AutoCopyConfiguration();
           }

           configure.Initialize(settings, Settings, ServerDirectory);
           configure.ShowDialog(Parent);                
        }
        #endregion        
    }
}
