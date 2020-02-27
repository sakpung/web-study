// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System ;
using System.Collections.Generic ;
using System.Threading ;
using System.ComponentModel ;
using System.Text ;
using System.IO ;
using System.Data ;
using Leadtools.Medical.Storage.DataAccessLayer ;
using Leadtools.Medical.Workstation.DataAccessLayer;
using Leadtools.Medical.DataAccessLayer;


namespace Leadtools.Medical.Winforms
{
   class EmptyDatabaseBackgroundWorker : BackgroundWorker
   {
      public EmptyDatabaseBackgroundWorker ( IStorageDataAccessAgent dataAccessAgent ) 
      {
         base.WorkerReportsProgress      = false ;
         base.WorkerSupportsCancellation = false ;
         
         _dataAccessAgent = dataAccessAgent ;
      }

      protected override void OnDoWork ( DoWorkEventArgs e )
      {
         MatchingParameterCollection mpc = new MatchingParameterCollection();
         DataSet images = _dataAccessAgent.QueryCompositeInstances ( mpc ) ;
         DataTable imageDataTable = images.Tables[DataTableHelper.InstanceTableName];

         _dataAccessAgent.DeleteInstance ( mpc ) ;
#if (LEADTOOLS_V19_OR_LATER)
         if (_dataAccessAgent3 != null && _dataAccessAgent3.HangingProtocolSupported)
         {
            try
            {
               DataSet hangingProtocolDataSet = _dataAccessAgent3.QueryHangingProtocol(mpc);
               DataTable hangingProtocolDataTable = hangingProtocolDataSet.Tables[DataTableHelper.HangingProtocolTableName];
               imageDataTable.Merge(hangingProtocolDataTable);

               _dataAccessAgent3.DeleteHangingProtocol(mpc);
            }
            catch (Exception)
            {
            }
         }
#endif

         e.Result = imageDataTable;
      }
      
      private IStorageDataAccessAgent _dataAccessAgent ;
#if (LEADTOOLS_V19_OR_LATER)   
      private IStorageDataAccessAgent3 _dataAccessAgent3
      {
         get
         {
            return _dataAccessAgent as IStorageDataAccessAgent3;
         }
      }
#endif

   }
}
