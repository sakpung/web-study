// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Leadtools.AddIn.Store.Properties;
using Leadtools.Dicom.AddIn.Interfaces;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Dicom.AddIn;
using Leadtools.Dicom;
using Leadtools.Demos;
using System.Runtime.InteropServices;

namespace Leadtools.AddIn.Store
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
               Resources.datamanager.ToBitmap().Save(ms, ImageFormat.Png);
               ms.Position = 0;
               return new Bitmap(ms);
            }
         }
      }

      public string Text
      {
         get
         {
            return "Database Manager";
         }
      }

      public void Configure(IWin32Window Parent, ServerSettings Settings, string ServiceDirectory)
      {
#if LEADTOOLS_V19_OR_LATER
         // do nothing
#elif LEADTOOLS_V175_OR_LATER
         Support.SetLicense();
#else
         Support.Unlock(false);
#endif
         DicomEngine.Startup();

         ConfigureDialog configure = new ConfigureDialog();
         Module.SetServerInfo(ServiceDirectory);
         configure.Text = Settings.AETitle + " Database Manager";
         //SetupOwnerWindow(new HandleRef(this,Parent.Handle), new HandleRef(this,configure.Handle));
         configure.ShowDialog();
         DicomEngine.Shutdown();
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
