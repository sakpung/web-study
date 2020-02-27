// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Leadtools.Dicom.AddIn.Interfaces;
using System.Windows.Forms;
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.Winforms;
using Leadtools.Medical.Logging.Addins.UI;
using Leadtools.Dicom.AddIn.Configuration;

namespace Leadtools.Medical.Logging.Addins.AddInOptions
{
   public class MedicalLoggingAddInOptions : MarshalByRefObject,IAddInOptions
   {
      #region IAddInOptions Members

      public void Configure
      (
         IWin32Window Parent, 
         ServerSettings Settings, 
         string ServerDirectory
      )
      {
         using ( LoggingModuleConfigurationManager configManager = new LoggingModuleConfigurationManager ( false ) )
         {
            configManager.Load ( ServerDirectory ) ;
            
            LoggingState state = configManager.GetLoggingState ( ) ;
            
            EventLogOptions mainLoggingUI = new EventLogOptions ( ) ;
            
            EventLogConfigurationPresenter presenter = new EventLogConfigurationPresenter ( ) ;
            
            presenter.RunView ( mainLoggingUI.EventLogConfigurationView, state ) ;
            
            if ( mainLoggingUI.ShowDialog ( ) == DialogResult.OK ) 
            {
               presenter.UpdateState ( ) ;
               
               configManager.SetLoggingState ( state ) ;
               
               configManager.Save ( ) ;
            }
            else
            {
               presenter.ResetView ( ) ;
            }
         }
         
      }

      public AddInImage Image
      {
         get { return null; }
      }

      public string Text
      {
         get { return "Logging Options" ; }
      }

      #endregion
   }
}
