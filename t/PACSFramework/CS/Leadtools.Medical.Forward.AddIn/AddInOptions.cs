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
using Leadtools.Medical.Forwarder.AddIn.Properties;
using System.Reflection;
using Leadtools.Medical.Forwarder.AddIn.Dialogs;
using Leadtools.Medical.Winforms.Forwarder;
using Leadtools.Medical.Winforms;

namespace Leadtools.Medical.Forwarder.AddIn
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
                //using(System.IO.MemoryStream ms = new System.IO.MemoryStream())
                //{
                //    Resources.Forward.ToBitmap().Save(ms, ImageFormat.Png);
                //    ms.Position = 0;
                //    return new Bitmap(ms);
                //}
               return Resources.Forwarding;
            }
        }        

        public string Text
        {
            get
            {
                return "Forwarder";
            }
        }

        public void Configure(IWin32Window Parent, ServerSettings Settings, string ServerDirectory)
        {
           AdvancedSettings settings = AdvancedSettings.Open(ServerDirectory);           
           Type dialogType = settings.GetAddInControlType(ForwardManagerPresenter._addinName, "ForwardConfig");
           IConfigureDialog configure = null;

           if (Settings != null)
           {
              PacsProduct.ServiceName = Settings.ServiceName;
           }

           if (dialogType != null)
           {
              //
              // Load configuration dialog
              //
              configure = Activator.CreateInstance(dialogType) as IConfigureDialog;
           }

           if (configure == null)
           {
              configure = new ForwardConfiguration();
           }

           configure.Initialize(settings, Settings, ServerDirectory);
           configure.ShowDialog(Parent);                
        }
        #endregion        
    }
}
