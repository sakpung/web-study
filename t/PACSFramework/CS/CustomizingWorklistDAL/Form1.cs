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
using CSCustomizingWorklistDAL.DataTypes;
using Leadtools.Dicom;
using Leadtools;
using CSCustomizingWorklistDAL.MyClientSession;
using System.Threading;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Dicom.Scp.Command;
using Leadtools.Medical.Worklist.DataAccessLayer;
using System.IO;
using Leadtools.Demos;

namespace CSCustomizingWorklistDAL
{
   public partial class Form1 : Form
   {
      DatabaseLayer _databaseLayer;
      WorklistDataSource       _source ;
      IWorklistDataAccessAgent _worklistAgent ;
      string                   _iodPath ;

      public DatabaseLayer DatabaseLayer
      {
         get { return _databaseLayer; }
      }
      
      public Form1 ( )
      {
         InitializeComponent ( ) ;
         
         Messager.Caption = this.Text ;
         
         if ( !DatabaseLayer.IsDataAccessSettingsValid ( ) )
         {
            MessageBox.Show ( "Database settings is not valid. Please run the PACS Database Configuration Demo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error ) ;
            
            return ;
         }
         
         _source        = new WorklistDataSource ( ) ;
         _databaseLayer = new DatabaseLayer ( _source ) ;
         _iodPath       = Application.StartupPath ;
         
         _iodPath = Path.Combine ( _iodPath, "CustomMWLIOD.xml" ) ;
         
         using ( Stream iodStream = MWLCFindCommand.DefualtMWLIOD )  
         {
            using ( FileStream customIODStream = new FileStream ( _iodPath, FileMode.Create ) )
            {
               CopyTo ( iodStream, customIODStream ) ;
            }
         }

         _source.DatabaseTags.Add(new DatabaseDicomTags("Visit", "ServiceEpisodeDescription", DicomTag.ServiceEpisodeDescription));
         _source.DatabaseTags.Add(new DatabaseDicomTags("ScheduledProcedureStep", "CommentsOnTheScheduledProcedureStep", DicomTag.CommentsOnTheScheduledProcedureStep));
         _source.DatabaseTags.Add(new DatabaseDicomTags("Patient", "SmokingStatus", DicomTag.SmokingStatus));
         
         _worklistAgent  = _databaseLayer.GetWorklistDataAgent ( ) ;
         
         DataAccessServices.RegisterDataAccessService <IWorklistDataAccessAgent> ( _worklistAgent ) ;
         
         databaseStatus1.ConnectionString = _databaseLayer.ConnectionString ;
         databaseStatus1.ProviderName     = _databaseLayer.Provider ;
         
         dicomTags1.SetSource      ( _source.DatabaseTags ) ;
         worklistUpdate1.SetSource ( _source.DatabaseTags ) ;
         dicomQuery1.SetSource     ( _source.DatabaseTags, _iodPath ) ;

         if (_databaseLayer.IsDatabaseUpdated())
         {
            try
            {
               WorklistIODUpdater.UpdateIOD(_source.DatabaseTags, _iodPath);
            }
            catch (Exception exception)
            {
               Messager.ShowError(this, "Error Updating the Modality Work-list IOD document.\n" + exception);
            }
         }
         
         UpdateDatabaseButton.Click += new EventHandler(UpdateDatabaseButton_Click);
      }

      void UpdateDatabaseButton_Click(object sender, EventArgs e)
      {
         try
         {
            if (_databaseLayer.IsDatabaseUpdated())
            {
               Messager.ShowInformation(this, "Database has already been updated.");
            }
            else
            // Add the tags to _source, only if they have not already been added
            {
               try
               {
                  WorklistIODUpdater.UpdateIOD(_source.DatabaseTags, _iodPath);
               }
               catch (Exception exception)
               {
                  Messager.ShowError(this, "Error Updating the Modality Work-list IOD document.\n" + exception);
               }

               _databaseLayer.UpdateDatabase();
               Messager.ShowInformation(this, "Database updated successfully.");
            }
            
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }
      
      private static void CopyTo ( Stream src, Stream dest )
      {
         if (src == null)
         {
            throw new System.ArgumentNullException("src");
         }
         
         if (dest == null)
         {      
            throw new System.ArgumentNullException ( "dest" ) ;
         }

         System.Diagnostics.Debug.Assert(src.CanRead, "src.CanRead");
         System.Diagnostics.Debug.Assert(dest.CanWrite, "dest.CanWrite");

         int readCount;
         var buffer = new byte[8192];
         while ((readCount = src.Read(buffer, 0, buffer.Length)) != 0)
         {
            dest.Write(buffer, 0, readCount);
         }
      }

   }
}
