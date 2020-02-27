// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Demos ;
using Leadtools.Medical.Winforms ;
using Leadtools.Medical.Storage.AddIns.Configuration;
using Leadtools.Dicom.AddIn;

#if (LEADTOOLS_V19_OR_LATER)
using Leadtools.Medical.Winforms.Anonymize;
using Leadtools.Medical.Winforms.DatabaseManager;
#endif 

namespace Leadtools.Medical.Storage.AddIns.Controls
{
   public partial class StorageDatabaseManagerDialog : Form
   {
      public StorageDatabaseManagerDialog()
      {
         InitializeComponent();
         
         databaseManager1.AETitle = AETitle ;
         databaseManager1.ConfigureStoreCommand += new EventHandler<StoreCommandEventArgs> ( databaseManager1_ConfigureStoreCommand ) ;
         
         this.FormClosing += new FormClosingEventHandler(StorageDatabaseManagerDialog_FormClosing);
         Leadtools.Demos.Messager.Caption = this.Text ;
      }

      void databaseManager1_ConfigureStoreCommand(object sender, StoreCommandEventArgs e)
      {
         if ( null != AddInsSettings ) 
         {
            StoreCommandInitializationService.ConfigureCStoreCommand ( e.Command, AddInsSettings.StoreAddIn ) ;
            StoreCommandInitializationService.ConfigureInstanceCStoreCommand ( e.Command, AddInsSettings.StoreAddIn ) ;
         }
      }
      
      public string ImplementationClassUID 
      { 
         get 
         {
            return databaseManager1.ImplementationClassUID ; 
         }
         
         set
         {
            databaseManager1.ImplementationClassUID = value ;
         }
      }
      
      public string AETitle
      {
         get
         {
            return databaseManager1.AETitle ;
         }
         
         set
         {
            databaseManager1.AETitle = value ;
         }
      }

      public StorageAddInsConfiguration AddInsSettings 
      {
         get
         {
            return addInsSettings ;
         }
         
         set
         {
            addInsSettings = value ;
            
            if ( null != addInsSettings ) 
            {
               databaseManager1.DeleteAnnotationsOnImageDelete = addInsSettings.StoreAddIn.DeleteAnnotationsOnImageDelete ;
               databaseManager1.DeleteFilesOnDatabaseDelete = addInsSettings.StoreAddIn.DeleteFiles;
               databaseManager1.BackupFilesOnDatabaseDelete = addInsSettings.StoreAddIn.BackupFilesOnDelete;
               databaseManager1.BackupFilesOnDeleteFolder = addInsSettings.StoreAddIn.DeleteBackupLocation;
            }
         }
      }

      private void addDICOMFileToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if ( !databaseManager1.IsWorking )
            {
               databaseManager1.PerformAddDicomFiles ( ) ;
            }
         }
         catch ( Exception exception  )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void addDICOMDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if ( !databaseManager1.IsWorking ) 
            {
               databaseManager1.PerformAddDicomDirectory ( ) ;
            }
         }
         catch ( Exception exception  )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void fileToolStripMenuItem_DropDownOpening ( object sender, EventArgs e )
      {
         try
         {
            addDICOMDirectoryToolStripMenuItem.Enabled = !databaseManager1.IsWorking ;
            addDICOMFileToolStripMenuItem.Enabled      = !databaseManager1.IsWorking ;
         }
         catch ( Exception ) 
         {}
      }

      private void optionsToolStripMenuItem_Click ( object sender, EventArgs e )
      {
         StorageModuleConfigurationManager configurationManager ;
         AddInsConfigurationDialog addinsConfiguration ;
         StorageSettingsPresenter  storageSettingsPresenter ;
         StorageClassesPresenter   storageClassesPresenter ;
         
         if ( ServiceLocator.IsRegistered <StorageModuleConfigurationManager> ( ) )
         {
            configurationManager = ServiceLocator.Retrieve <StorageModuleConfigurationManager> ( ) ;
         }
         else
         {
            return ;
         }
         
         addinsConfiguration      = new AddInsConfigurationDialog ( ) ;
         storageSettingsPresenter = new StorageSettingsPresenter ( configurationManager ) ;
         storageClassesPresenter  = new StorageClassesPresenter ( ) ;

#if (LEADTOOLS_V19_OR_LATER)
         DatabaseManagerOptionsPresenter databaseManagerOptionsPresenter = new DatabaseManagerOptionsPresenter();
         databaseManagerOptionsPresenter.RunView(addinsConfiguration.AddInsConfiguration.DatabaseManagerOptionsView);

         AnonymizeOptionsPresenter anonymizePresenter = new AnonymizeOptionsPresenter();
         anonymizePresenter.RunView(addinsConfiguration.AddInsConfiguration.AnonymizeOptionsView);
#endif // #if (LEADTOOLS_V19_OR_LATER)
         
         storageSettingsPresenter.RunViews ( addinsConfiguration.AddInsConfiguration.StorageOptionsView,
                                             addinsConfiguration.AddInsConfiguration.QueryOptionsView,
                                             false ) ;
         
         
         storageClassesPresenter.RunView ( addinsConfiguration.AddInsConfiguration.StorageClassesTabControl ) ;
         
         addinsConfiguration.CanViewIodClasses = storageClassesPresenter.IsOptionsAgentRegistered();
         
         if ( DialogResult.OK == addinsConfiguration.ShowDialog ( this ) )
         {
            storageSettingsPresenter.UpdateState();
            
            // Fix for 11446IDT -- StorageAddin for the CSLeadtools.Server.Manager.exe is not persisting IOD values for the LEADTOOLS Storage Server service
            storageClassesPresenter.UpdateSettings();
            
            databaseManager1.DeleteAnnotationsOnImageDelete = addInsSettings.StoreAddIn.DeleteAnnotationsOnImageDelete ;

            AddInsSettings = storageSettingsPresenter.Settings ;

#if (LEADTOOLS_V19_OR_LATER)
            databaseManagerOptionsPresenter.SaveOptions();
            DatabaseManagerOptionsAppliedEventArgs args = new DatabaseManagerOptionsAppliedEventArgs();
            EventBroker.Instance.PublishEvent <DatabaseManagerOptionsAppliedEventArgs> ( this, args) ;
            anonymizePresenter.UpdateSettings();
#endif // #if (LEADTOOLS_V19_OR_LATER)
        
            storageSettingsPresenter.SaveSettings ( ) ;
         }
         else
         {
            storageSettingsPresenter.ResetView ( ) ;
         }
      }

      public event EventHandler SaveSettings ;
      
      private void OnSaveSettings(StorageDatabaseManagerDialog storageDatabaseManagerDialog, EventArgs eventArgs)
      {
         try
         {
            if ( null != SaveSettings ) 
            {
               SaveSettings ( storageDatabaseManagerDialog, eventArgs ) ;
            }
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }
      
      private StorageAddInsConfiguration addInsSettings ;

      void  StorageDatabaseManagerDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         try
         {
            if ( e.CloseReason != CloseReason.WindowsShutDown &&
                 databaseManager1.IsWorking ) 
            {
               Messager.ShowWarning ( this, OperationRunningMessage ) ;
               
               e.Cancel = true ;
            }
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
         }
      }

      private void exitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         try
         {
            if ( databaseManager1.IsWorking ) 
            {
               Messager.ShowWarning ( this, OperationRunningMessage ) ;
            }
            else
            {
               this.Close ( ) ;
            }
         }
         catch ( Exception ) 
         {}
      }
      
      private const string OperationRunningMessage = "An operation is currently in progress. Wait for the operation to finish or cancel." ;
      
   }
}
