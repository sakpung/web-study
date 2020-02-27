// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Leadtools.Medical.DataAccessLayer ;
using Leadtools.Medical.Winforms.Control ;
using Leadtools.Demos;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Medical.Winforms.DatabaseManager.Controls;

namespace Leadtools.Medical.Winforms
{
   partial class DicomQuery : Leadtools.Medical.Workstation.UI.AutoHidePanel
   {
      public DicomQuery()
      {
         InitializeComponent();
         searchStandard.Initialize();
#if (LEADTOOLS_V19_OR_LATER)
         searchHangingProtocol.Initialize();
#endif
         RegisterEvents();
      }

     public void SetSearch(DicomInformationView view)
      {
         switch (view)
         {
            case DicomInformationView.PatientLevel:
            case DicomInformationView.StudiesLevel:
            case DicomInformationView.SeriesLevel:
            case DicomInformationView.ImagesLevel:
               if (searchStandard.Visible == false)
               {
                  searchStandard.Visible = true;
                  searchHangingProtocol.Visible = false;
               }
               break;

            case DicomInformationView.HangingProtocol:
            case DicomInformationView.HangingProtocolDefinition:
               if (searchHangingProtocol.Visible == false)
               {
                  searchHangingProtocol.Visible = true;
                  searchStandard.Visible = false;
               }
               break;
         }
      }

     private ISearch ActiveSearch
     {
        get
        {
         if (searchHangingProtocol.Visible)
         {
            return searchHangingProtocol;
         }
         
         {
            return searchStandard;
         }
        }
     }
   
      
      public PrepareSearchDelegate PrepareSearch;
         
     

      void btnCancel_Click(object sender, EventArgs e)
      {
         try
         {
            OnCancelSearch ( ) ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void RegisterEvents()
      {
         btnSearch.Click += new EventHandler(btnSearch_Click);
         btnClear.Click += new EventHandler(btnClear_Click);
         btnCancel.Click += new EventHandler(btnCancel_Click);

         searchStandard.RegisterEvents();
         searchHangingProtocol.RegisterEvents();
      }
      
      public void EnableItems(bool enable, bool enableCancel)
      {
         btnSearch.Enabled = enable;
         btnClear.Enabled = enable;
         btnCancel.Enabled = enable;

         searchStandard.EnableItems(enable);
         searchHangingProtocol.EnableItems(enable);

         btnCancel.Enabled = enableCancel;
      }
      

      void btnSearch_Click(object sender, EventArgs e)
      {
         try
         {
            MatchingParameterCollection mp = new MatchingParameterCollection();
            if (PrepareSearch == null)
            {
               ActiveSearch.PrepareSearchDefault(mp);
            }
            else
            {
               PrepareSearch(mp);
            }
            OnApplySearch(mp);
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
         finally
         {
            this.Cursor = Cursors.Default;
         }
      }
      
      void btnClear_Click(object sender, EventArgs e)
      {
         try
         {
            ActiveSearch.Clear();
            
            OnClearSearch ( ) ;
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ; 
         }
      }
      
      private void OnApplySearch ( MatchingParameterCollection query ) 
      {
         if ( null != PerformSearch )
         {
            PerformSearch ( this, new ApplySearchEventArgs ( query ) ) ;
         }
      }

      private void OnCancelSearch ( ) 
      {
         if ( null != CancelSearch ) 
         {
            CancelSearch ( this, new EventArgs ( ) ) ;
         }
      }
      
      private void OnClearSearch ( ) 
      {
         if ( null != ClearSearch ) 
         {
            ClearSearch ( this, new EventArgs ( ) ) ;
         }
      }
     
      
     
      
      public event EventHandler <ApplySearchEventArgs> PerformSearch ;
      public event EventHandler                        CancelSearch ;
      public event EventHandler                        ClearSearch ;

      public DicomQueryParams GetDicomQueryParams()
      {
         return searchStandard.GetDicomQueryParams();
      }

   }
   
      public class DicomQueryParams
   {
      public DicomQueryParams()
      {
      }
      
        // Patient
      public PersonNameComponent PatientName
      {
         get;set;
      }

      public string PatientId
      {
         get;set;
      }
      
      // Modalities
      public string Modalities
      {
         get;set;
      }
      
      // Studies
      public string StudyId
      {
         get;set;
      }
      
      public string AccessionNumber
      {
         get;set;
      }
      
      public PersonNameComponent ReferringPhysiciansName
      {
         get;set;
      }
      
      public bool StudyFromChecked
       {
         get;set;
      }
      
      public bool StudyToChecked
       {
         get;set;
      }

      public DateTime? StudyFromDate
      {
         get;set;
      }
      
      public DateTime? StudyToDate
      {
         get;set;
      }
      
      // Storage Date
      public bool StorageDateChecked
      {
         get;set;
      }
      
      public DateRangeFilter StorageDateRange
      {
         get;
         set;
      }
      
      // 
      public string SeriesDescription
      {
         get;set;
      }

#if (LEADTOOLS_V19_OR_LATER_STORE_AE_TITLE) || (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V18_OR_LATER)
      public string StoreAeTitle
      {
         get;
         set;
      }
      
      public string RetrieveAeTitle
      {
         get;
         set;
      }
#endif
   }
   
   public delegate void PrepareSearchDelegate(MatchingParameterCollection matchingCollection);


   
   class ApplySearchEventArgs : EventArgs
   {
      public ApplySearchEventArgs ( MatchingParameterCollection query )
      {
         QueryParams = query ;
      }
      
      public MatchingParameterCollection QueryParams
      {
         get
         {
            return _query ;
         }
         
         private set
         {
            _query = value ;
         }
      }
      
      private MatchingParameterCollection _query ;
   }
}
