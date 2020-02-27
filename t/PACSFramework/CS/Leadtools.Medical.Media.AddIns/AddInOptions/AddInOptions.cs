// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Interfaces ;
using Leadtools.Dicom.AddIn.Configuration ;
using Leadtools.Dicom.Scp.Command;
using Leadtools.Medical.Media.AddIns.UI;
using Leadtools.Demos;


namespace Leadtools.Medical.Media.AddIns
{
   public class MediaCreationAddInOptions : MarshalByRefObject,IAddInOptions
   {
      #region IAddInOptions Members

      public void Configure 
      ( 
         System.Windows.Forms.IWin32Window Parent, 
         Leadtools.Dicom.AddIn.Common.ServerSettings Settings, 
         string ServerDirectory
      )
      {
#if LEADTOOLS_V19_OR_LATER
         // do nothing
         if (RasterSupport.KernelExpired)
         {
            Leadtools.Demos.Support.SetLicense();
         }
#elif LEADTOOLS_V175_OR_LATER
         Leadtools.Demos.Support.SetLicense();
#else
         Leadtools.Demos.Support.Unlock ( false ) ;
#endif
         Leadtools.Dicom.DicomEngine.Startup ( ) ;
         
         Messager.Caption = Text ;
         
         AddInsSession.SetLoadSettings ( ServerDirectory, Settings.AETitle ) ;
         
         AddInsSession.ConfigureSettings ( Settings ) ;
         
         AddInsSession.RegisterServices ( Settings.ServiceName ) ;
         
         try
         {
            new ShellController ( ).Run ( ) ;
         }
         finally
         {
            Leadtools.Dicom.DicomEngine.Shutdown ( ) ;
         }
      }

      public AddInImage Image
      {
         get 
         { 
            using ( System.IO.MemoryStream ms = new System.IO.MemoryStream ( ) )
            {
               Leadtools.Medical.Media.AddIns.Properties.Resources.BurnConfig.ToBitmap ( ).Save ( ms, ImageFormat.Png ) ;
               
               ms.Position = 0;
                  
               return new Bitmap(ms);
            }
         }
      }

      public string Text
      {
         get 
         { 
            return "Media Creation Configuration" ; 
         }
      }

      #endregion
   }
}
