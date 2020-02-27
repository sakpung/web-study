// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;

namespace Leadtools.Medical.WebViewer.JobsCleanupAddin
{
   public class JobsCleanupConfiguration : MarshalByRefObject, IAddInOptions
   {
      ConfigurationDialog _configForm ;

      public void Configure(System.Windows.Forms.IWin32Window Parent, Dicom.AddIn.Common.ServerSettings Settings, string ServerDirectory)
      {
         try
         {
            JobsCleanupConfigurationViewProxy _CleanupProxy = new JobsCleanupConfigurationViewProxy(ServerDirectory, Settings.ServiceName);

            _configForm = new ConfigurationDialog();
            _configForm.CleanupProxy = _CleanupProxy;
            _configForm.ShowDialog(Parent);
         }
         catch (System.Exception ex)
         {         	
         }
      }

      public AddInImage Image
      {
         get { return null; }
      }

      public string Text
      {
         get { return "Web Viewer Cleanup Service" ; }
      }
   }
}
