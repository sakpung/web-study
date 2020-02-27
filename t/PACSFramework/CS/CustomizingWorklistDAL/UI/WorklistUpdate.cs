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
using CSCustomizingWorklistDAL.DataTypes;
using Leadtools.Medical.Worklist.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Worklist.DataAccessLayer.BusinessEntity;
using Leadtools.Demos;

namespace CSCustomizingWorklistDAL.UI
{
   public partial class WorklistUpdate : UserControl
   {
      List<DatabaseDicomTags> _source ;
      MWLDataset _queryResult ;
      
      
      public WorklistUpdate()
      {
         InitializeComponent();
         
         _queryResult = null ;
      }
      
      public void SetSource ( List<DatabaseDicomTags> source ) 
      {
         _source = source ;
         
         QueryButton.Click  += new EventHandler ( QueryButton_Click ) ;
         UpdateButton.Click += new EventHandler ( UpdateButton_Click ) ;
      }

      void UpdateButton_Click ( object sender, EventArgs e )
      {
         try
         {
            if ( null != _queryResult ) 
            {
               IWorklistDataAccessAgent worklistAgent ;
               
               
               worklistAgent = DataAccessServices.GetDataAccessService <IWorklistDataAccessAgent> ( ) ;
               
               worklistAgent.UpdateMWL ( _queryResult ) ;
            }
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      void QueryButton_Click ( object sender, EventArgs e )
      {
         try
         {
            IWorklistDataAccessAgent worklistAgent ;
            
            
            worklistAgent = DataAccessServices.GetDataAccessService <IWorklistDataAccessAgent> ( ) ;
            
            _queryResult = worklistAgent.FindPatientInformation ( new MatchingParameterCollection ( ) ) ;
            List<string> tables = new List<string> ( ) ;
            
            tableLayoutPanel1.Controls.Clear ( ) ;
            
            foreach ( DatabaseDicomTags dbTag in _source ) 
            {
               if ( tables.Contains ( dbTag.TableName ) )
               {
                  continue ;
               }
               
               DataGridView queryResultsDataGridView = new DataGridView ( ) ;
               queryResultsDataGridView.AllowUserToAddRows = false;

               queryResultsDataGridView.ColumnAdded += new DataGridViewColumnEventHandler(queryResultsDataGridView_ColumnAdded);
               
               queryResultsDataGridView.DataSource = _queryResult ;
               queryResultsDataGridView.DataMember = dbTag.TableName ;
               queryResultsDataGridView.Dock       = DockStyle.Fill ;
               
               queryResultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize ;
               
               tables.Add ( dbTag.TableName ) ;
               
               tableLayoutPanel1.Controls.Add ( queryResultsDataGridView ) ;
            }
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      void queryResultsDataGridView_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
      {
         DataGridView gridView = (DataGridView) sender ;

         DataSet source   = (DataSet) gridView.DataSource ;
         string tableName = gridView.DataMember ;
         
         
         if ( source.Tables [ tableName ].PrimaryKey.Contains ( source.Tables [ tableName ].Columns [ e.Column.DataPropertyName ] ) )
         {
            e.Column.ReadOnly = true ;
         }
         else
         {
            foreach ( DataRelation relation in source.Tables [ tableName ].ParentRelations )
            {
               foreach ( DataColumn column in relation.ChildColumns )
               {
                  if ( source.Tables [ tableName ].Columns [ e.Column.DataPropertyName ] == column )
                  {
                     e.Column.ReadOnly = true ;
                     
                     break ;
                  }
               }
               
               if ( e.Column.ReadOnly )
               {
                  break ;
               }
            }
         }
         
         foreach ( DatabaseDicomTags dbTag in _source ) 
         {
            if ( e.Column.DataPropertyName == dbTag.ColumnName )
            {
               e.Column.CellTemplate.Style.BackColor = Color.Blue ;
               e.Column.CellTemplate.Style.ForeColor = Color.Red ;
               
               break ;
            }
         }
      }
   }
}
