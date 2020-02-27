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

namespace Leadtools.Medical.HL7PatientUpdate.AddIn
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
                   Properties.Resources.modality_list_hl7_48.ToBitmap().Save(ms, ImageFormat.Png);
                    ms.Position = 0;
                    return new Bitmap(ms);
                }
            }
        }

        public string Text
        {
            get
            {
               return "HL7 Patient Update";
            }
        }

        public void Configure(IWin32Window Parent, ServerSettings Settings, string ServerDirectory)
        {
            ConfigureDialog configure = new ConfigureDialog();
            
            string optionsFile = HL7ServerPatientUpdate.GetOptionsFile(ServerDirectory);
            HL7ServerPatientUpdate.InitializeOptions(ServerDirectory, Settings.AETitle);
            
            configure.Text = Settings.AETitle + " HL7 Server Options";
            //configure.propertyGridOptions.SelectedObject = options;
            // SetupOwnerWindow(new HandleRef(this, Parent.Handle), new HandleRef(this, configure.Handle));
            if (configure.ShowDialog() == DialogResult.OK)
            {
                try
                {
                   AddInUtils.Serialize<HL7Options>(HL7ServerPatientUpdate.HL7Options, optionsFile);
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
