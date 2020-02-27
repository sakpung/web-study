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
using Leadtools.Dicom.AddIn.Configuration ;
using Leadtools.Dicom.AddIn.Interfaces ;
using Leadtools.Dicom.AddIn.Common ;
using Leadtools.Medical.Storage.AddIns.Controls ;
using Leadtools.Medical.Storage.AddIns.Configuration ;
using Leadtools.Dicom.Scp.Command;
using System.IO;
using Leadtools.Medical.Winforms;
// using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Dicom.AddIn;

namespace Leadtools.Medical.Storage.AddIns
{
   public class StorageAddInOptions : MarshalByRefObject,IAddInOptions
   {
      #region IAddInOptions Members

      public void Configure
      (
         IWin32Window Parent, 
         ServerSettings Settings, 
         string ServerDirectory
      )
      {
         StorageDatabaseManagerDialog configurationDialog ;
         StorageAddInsConfiguration   storageSettings;
         

#if LEADTOOLS_V19_OR_LATER
         if (RasterSupport.KernelExpired)
         {
            Leadtools.Demos.Support.SetLicense();
         }
#elif LEADTOOLS_V175_OR_LATER
         Leadtools.Demos.Support.SetLicense();
#else
         Leadtools.Demos.Support.Unlock ( false ) ;
#endif
         AddInsSession session = new AddInsSession ( ) ;
         
         session.LoadSession ( ServerDirectory, Settings.ServiceName, false ) ;
         session.AddServices ( ) ;
         
         if ( ServiceLocator.IsRegistered <StorageModuleConfigurationManager> ( ) )
         {
            StorageModuleConfigurationManager configManager ;
            
            
            configManager = ServiceLocator.Retrieve <StorageModuleConfigurationManager> ( ) ;
            
            storageSettings = configManager.GetStorageAddInsSettings ( ) ;
            
            using ( configurationDialog = new StorageDatabaseManagerDialog ( ) )
            {
               Leadtools.Demos.Messager.Caption = Text ;
               
               configurationDialog.AddInsSettings              = storageSettings ;
               configurationDialog.ImplementationClassUID      = Settings.ImplementationClass ;
               
               configurationDialog.ShowDialog ( ) ;
            }
            
            configManager.Dispose ( ) ;
         }
      }

      public AddInImage Image
      {
         get 
         { 
            using ( System.IO.MemoryStream ms = new System.IO.MemoryStream ( ) )
            {
               Leadtools.Medical.Storage.AddIns.Properties.Resources.datamanager1.Save(ms, ImageFormat.Png) ; 
               
               ms.Position = 0;
                  
               return new Bitmap(ms);
            }
         }
      }

      public string Text
      {
         get 
         { 
            return "Query/Retrieve, Store Configuration" ;
         }
      }

      #endregion
   }
}
