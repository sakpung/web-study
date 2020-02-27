// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSCustomizingWorklistDAL.MyClientSession;
using Leadtools.Dicom;
using Leadtools.Dicom.Scp.Command;
using Leadtools.Medical.DataAccessLayer;
using System.Threading;
using Leadtools.Medical.Worklist.DataAccessLayer;
using CSCustomizingWorklistDAL.DataTypes;
using Leadtools.Demos;

namespace CSCustomizingWorklistDAL.UI
{
   public partial class DICOMQuery : UserControl
   {
      List <DatabaseDicomTags> _source ;
      List <DatabaseDicomTags> _additionalDisplay ;
      string _iodPath ;
      public DICOMQuery()
      {
         InitializeComponent();
      }

      public void SetSource ( List <DatabaseDicomTags> source, string iodPath )
      {
         _source            = source ;
         _additionalDisplay = new List<DatabaseDicomTags> ( ) ;
         _iodPath           = iodPath ;
         
         _additionalDisplay.Add ( new DatabaseDicomTags ( "", "Patient Name", DicomTag.PatientName ) ) ;
         _additionalDisplay.Add ( new DatabaseDicomTags ( "", "Admission ID", DicomTag.AdmissionID ) ) ;
         _additionalDisplay.Add ( new DatabaseDicomTags ( "", "Accesion Number", DicomTag.AccessionNumber ) ) ;
         _additionalDisplay.Add ( new DatabaseDicomTags ( "", "Modality", DicomTag.Modality ) ) ;
         _additionalDisplay.Add ( new DatabaseDicomTags ( "", "Requested Procedure ID", DicomTag.RequestedProcedureID ) ) ;
         _additionalDisplay.Add ( new DatabaseDicomTags ( "", "Scheduled Station AE Title", DicomTag.ScheduledStationAETitle ) ) ;
         _additionalDisplay.Add ( new DatabaseDicomTags ( "", "Scheduled Procedure Step Description", DicomTag.ScheduledProcedureStepDescription ) ) ;
         
         QueryButton.Click += new EventHandler ( QueryButton_Click ) ;
      }
      
      void QueryButton_Click ( object sender, EventArgs e )
      {
         try
         {
            DemoClientSession clientSession = new DemoClientSession ( ) ;
            DicomDataSet requestDS ;
            
            
            requestDS = GetQueryDataSet ( ) ;
            MWLCFindCommand command = new MWLCFindCommand ( clientSession, requestDS, DataAccessServices.GetDataAccessService <IWorklistDataAccessAgent> ( ) ) ;
            AutoResetEvent resetEvent = new AutoResetEvent ( false ) ;
            command.MWLConfiguration.ModalityWorklistIODPath = _iodPath ;
            
            command.Execute ( resetEvent ) ;
            
            resetEvent.WaitOne ( ) ;
            
            InitializeWorklistView ( ) ;
            
            if ( clientSession.Status == DicomCommandStatusType.Success )
            {
               foreach ( DicomDataSet response in clientSession.ResponseDS ) 
               {
                  FillWorklistItem ( response ) ;
               }
            }
            else
            {
               Messager.ShowError ( this, "Failed to Query.\n" + clientSession.StatusMessage ) ;
            }
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void FillWorklistItem ( DicomDataSet response )
      {
         try
         {
            ListViewItem item    = null ;
            DicomElement element = null ;
            
            
            foreach ( DatabaseDicomTags dbTag in _additionalDisplay ) 
            {
               element = response.FindFirstElement ( null, dbTag.DicomTag, false ) ;
               
               if ( item == null ) 
               {
                  item = new ListViewItem ( ) ;
                  
                  item.UseItemStyleForSubItems = false ;
                  
                  if ( null != element ) 
                  {
                     item.Text = response.GetConvertValue ( element ) ;
                  }
               }
               else
               {
                  string subItemValue = string.Empty ;
                  
                  if ( null != element ) 
                  {
                     subItemValue = response.GetConvertValue ( element ) ;
                  }
                  
                  item.SubItems.Add ( subItemValue );
               }
            }


            if (IsDatabaseUpdated())
            {
               foreach (DatabaseDicomTags dbTag in _source)
               {
                  element = response.FindFirstElement(null, dbTag.DicomTag, false);

                  string subItemValue = string.Empty;

                  if (null != element)
                  {
                     subItemValue = response.GetConvertValue(element);
                  }

                  ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem(item,
                                                                                            subItemValue,
                                                                                            Color.Red,
                                                                                            Color.Blue,
                                                                                            Font);
                  item.SubItems.Add(subItem);
               }
            }
            
            WorklistItemsListView.Items.Add ( item ) ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void InitializeWorklistView ( )
      {
         WorklistItemsListView.Clear ( ) ;
         
         foreach ( DatabaseDicomTags dbTag in _additionalDisplay ) 
         {
            WorklistItemsListView.Columns.Add ( dbTag.ColumnName ) ;
         }

         if (IsDatabaseUpdated())
         {
            foreach (DatabaseDicomTags dbTag in _source)
            {
               WorklistItemsListView.Columns.Add(dbTag.ColumnName);
            }
         }
      }

      private bool IsDatabaseUpdated()
      {
         Form1 form1 = this.Parent as Form1;
         bool ret =  (form1 != null && form1.DatabaseLayer.IsDatabaseUpdated());
         return ret;
      }
      
      private DicomDataSet GetQueryDataSet ( ) 
      {
         try
         {
            DicomDataSet requestDataset ;
            
            
            requestDataset = new DicomDataSet ( ) ;
            
            requestDataset.Initialize ( DicomClassType.ModalityWorklist, DicomDataSetInitializeFlags.None ) ;

            if (IsDatabaseUpdated())
            {
               //make sure we request all the new tags
               foreach (DatabaseDicomTags dbTag in _source)
               {
                  requestDataset.InsertElementAndSetValue(dbTag.DicomTag, string.Empty);
               }
            }
            
            return requestDataset ;
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false, exception.Message ) ;
                           
            throw ;
         }
      }
   }
}
