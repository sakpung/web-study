// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Common;
using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Leadtools.AddIn.Security
{
    [Serializable]
    public class AddInOptions : MarshalByRefObject, IAddInOptions
    {
       [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]

       private static extern IntPtr SetWindowLongPtr(HandleRef hWnd, int nIndex, HandleRef data);
       const int GWLP_HWNDPARENT = -8;

        #region IAddInOptions Members

        public AddInImage Image
        {
            get
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    Properties.Resources.security.ToBitmap().Save(ms, ImageFormat.Png);
                    ms.Position = 0;
                    return new Bitmap(ms);
                }
            }
        }

        public string Text
        {
            get
            {
                return "Security";
            }
        }

        public void Configure(IWin32Window Parent, ServerSettings Settings, string ServerDirectory)
        {
            ConfigureDialog configure = new ConfigureDialog();
            SecurityOptions options = null;
            string optionsFile = DicomSecurity.GetOptionsFile(ServerDirectory);


            DicomSecurity.InitializeSecurity(ServerDirectory, Settings.AETitle);
            try
            {
                options = AddInUtils.DeserializeFile<SecurityOptions>(optionsFile);
            }
            catch
            {
                options = new SecurityOptions();
            }

            configure.Text = Settings.AETitle + " Security Options";
            configure.propertyGridOptions.SelectedObject = options;
            // SetupOwnerWindow(new HandleRef(this, Parent.Handle), new HandleRef(this, configure.Handle));
            if (configure.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    AddInUtils.Serialize<SecurityOptions>(options, optionsFile);
                }
                catch { }
            }
        }

        #endregion

        public static void SetupOwnerWindow(HandleRef hwndOwner, HandleRef hwndOwned)
        {
           IntPtr result = IntPtr.Zero;
           result = SetWindowLongPtr(hwndOwned, GWLP_HWNDPARENT, hwndOwner);
           if (result == IntPtr.Zero)
           {
              int err = Marshal.GetLastWin32Error();

              if (err != 0)
                 throw new InvalidOperationException
                     ("Failed to establish owner-owned relation.");
           }
        }
    }
}
