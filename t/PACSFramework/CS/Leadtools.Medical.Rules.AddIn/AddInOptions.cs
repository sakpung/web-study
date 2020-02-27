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
using System.Reflection;
using Leadtools.Medical.Rules.AddIn.Dialogs;
using Leadtools.Medical.Rules.AddIn.Properties;

namespace Leadtools.Medical.Rules.AddIn
{
    [Serializable]
    public class AddInOptions : MarshalByRefObject,IAddInOptions
    {
       private AddInImage _Image = null;

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
               if (_Image == null)
                  _Image = new AddInImage(Resources.Rules);
               return _Image;
            }
        }        

        public string Text
        {
            get
            {
                return "Rules";
            }
        }

        public void Configure(IWin32Window Parent, ServerSettings Settings, string ServerDirectory)
        {
           AdvancedSettings settings = AdvancedSettings.Open(ServerDirectory);
           string name = Assembly.GetExecutingAssembly().GetName().Name;
           Type dialogType = settings.GetAddInControlType(name, "RulesProcessorConfig");
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
              configure = new ProcessorConfiguration();
           }

           configure.Initialize(settings, Settings, ServerDirectory);
           configure.ShowDialog(Parent);                
        }
        #endregion        
    }
}
