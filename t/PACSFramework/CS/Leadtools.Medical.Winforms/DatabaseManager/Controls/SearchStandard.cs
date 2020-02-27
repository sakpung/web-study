// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Leadtools.Medical.Winforms.Control;
using Leadtools.Medical.Storage.DataAccessLayer;
using Leadtools.Demos;
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.Medical.Winforms.DatabaseManager.Controls
{
   public partial class SearchStandard : UserControl, ISearch
   {
      public SearchStandard()
      {
         InitializeComponent();
      }


      // Patient
      public PersonNameComponent PatientName
      {
         get
         {
            PersonNameComponent pn = new PersonNameComponent();
            pn.FamilyName = this.txtPatientLastName.Text;
            pn.GivenName = this.txtPatientGivenName.Text;
            //pn.MiddleName;
            //pn.NamePrefix;
            //pn.NameSuffix;
            return pn;
         }
      }

      public string PatientId
      {
         get { return txtPatientId.Text; }
      }

      // Modalities
      public string Modalities
      {
         get
         {
            return this.modalitiesControl.Modalities;
         }
      }

      // Studies
      public string StudyId
      {
         get
         {
            return txtStudiesId.Text;
         }
      }

      public string AccessionNumber
      {
         get { return txtAccessionNumber.Text; }
      }

      public PersonNameComponent ReferringPhysiciansName
      {
         get
         {
            PersonNameComponent pn = new PersonNameComponent();
            pn.FamilyName = this.txtRefDrLastName.Text;
            pn.GivenName = this.txtRefDrGivenName.Text;
            //pn.MiddleName;
            //pn.NamePrefix;
            //pn.NameSuffix;
            return pn;
         }
      }

      public bool StudyFromChecked
      {
         get
         {
            return chkStudyFrom.Checked;
         }
      }

      public bool StudyToChecked
      {
         get
         {
            return chkstudyTo.Checked;
         }
      }

      public DateTime? StudyFromDate
      {
         get
         {
            return dtpkStudyFrom.Value;
         }
      }

      public DateTime? StudyToDate
      {
         get
         {
            return dtpkStudyTo.Value;
         }
      }

      // Storage Date

      public bool StorageDateChecked
      {
         get
         {
            return StorageDateCheckBox.Checked;
         }
      }

      public DateRangeFilter GetStorageDateRangeFilter()
      {
         return StorageDateRangeFilter;
      }


      // 
      public string SeriesDescription
      {
         get
         {
            return SeriesDescriptionTextBox.Text;
         }
      }





      public void Initialize()
      {
         dtpkStudyFrom.DataBindings.Add("Enabled", chkStudyFrom, "Checked");
         dtpkStudyTo.DataBindings.Add("Enabled", chkstudyTo, "Checked");

         modalitiesControl.Initialize();

         StorageDateRangeFilter.Enabled = StorageDateCheckBox.Checked;
         StorageDateRangeFilter.DateControlFormat = DateTimePickerFormat.Short;
      }


      public void RegisterEvents()
      {
         StorageDateCheckBox.CheckedChanged += new EventHandler(StorageDateCheckBox_CheckedChanged);
         modalitiesControl.RegisterEvents();
      }

      void StorageDateCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         try
         {
            StorageDateRangeFilter.Enabled = StorageDateCheckBox.Checked;
         }
         catch (Exception exception)
         {
            Messager.ShowError(this, exception);
         }
      }

      //private void chkSelectAll_CheckStateChanged(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      modalitiesCheckedComboBox.CheckChanged -= new EventHandler(CheckedList_ItemChecked);

      //      if ((chkSelectAll.Checked) && (chkSelectAll.CheckState == CheckState.Checked))
      //      {
      //         modalitiesCheckedComboBox.CheckAllItems();
      //      }
      //      else if ((!chkSelectAll.Checked) && (chkSelectAll.CheckState == CheckState.Unchecked))
      //      {
      //         modalitiesCheckedComboBox.ClearCheckedItems();
      //      }

      //      modalitiesCheckedComboBox.CheckChanged += new EventHandler(CheckedList_ItemChecked);
      //   }
      //   catch (Exception exception)
      //   {
      //      System.Diagnostics.Debug.Assert(false, exception.Message);
      //   }
      //}

      //private void CheckedList_ItemChecked(object sender, EventArgs e)
      //{
      //   try
      //   {
      //      int checkedItemCount;


      //      chkSelectAll.CheckStateChanged -= new EventHandler(chkSelectAll_CheckStateChanged);

      //      checkedItemCount = modalitiesCheckedComboBox.GetCheckedItemsCount();

      //      if (checkedItemCount == modalitiesCheckedComboBox.Items.Count)
      //      {
      //         chkSelectAll.Checked = true;
      //         chkSelectAll.CheckState = CheckState.Checked;
      //      }
      //      else if (checkedItemCount == 0)
      //      {
      //         chkSelectAll.Checked = false;
      //         chkSelectAll.CheckState = CheckState.Unchecked;
      //      }
      //      else
      //      {
      //         chkSelectAll.Checked = true;
      //         chkSelectAll.CheckState = CheckState.Indeterminate;
      //      }

      //      chkSelectAll.CheckStateChanged += new EventHandler(chkSelectAll_CheckStateChanged);
      //   }
      //   catch (Exception exception)
      //   {
      //      System.Diagnostics.Debug.Assert(false, exception.Message);
      //   }

      //}

      public void EnableItems(bool enable)
      {
         // Patient 
         groupBox1.Enabled = enable;

         // Modalities
         grpModalities.Enabled = enable;

         // Studies
         groupBox2.Enabled = enable;

         // Storage Date
         StorageDateCheckBox.Enabled = enable;
         groupBox3.Enabled = enable;

         // Series Description
         panel1.Enabled = enable;
         grpSeries.Enabled = enable;
      }

      //private void InitModalities()
      //{
      //   CheckedComboBox.FillModalities(modalitiesCheckedComboBox);
      //}

      public void Clear()
      {

         txtPatientLastName.Text = string.Empty;
         txtPatientGivenName.Text = string.Empty;
         txtPatientId.Text = string.Empty;
         txtAccessionNumber.Text = string.Empty;
         txtRefDrGivenName.Text = string.Empty;
         txtRefDrLastName.Text = string.Empty;
         txtStudiesId.Text = string.Empty;

         chkStudyFrom.Checked = false;
         chkstudyTo.Checked = false;

         StorageDateCheckBox.Checked = false;

         modalitiesControl.Clear();

      }

      public DicomQueryParams GetDicomQueryParams()
      {
         DicomQueryParams q = new DicomQueryParams();

         // Patient
         q.PatientName = this.PatientName;
         q.PatientId = this.PatientId;

         // Modalities
         q.Modalities = this.Modalities;

         // Studies
         q.StudyId = this.StudyId;
         q.AccessionNumber = this.AccessionNumber;
         q.ReferringPhysiciansName = this.ReferringPhysiciansName;

         q.StudyFromChecked = this.StudyFromChecked;
         q.StudyToChecked = this.StudyToChecked;
         q.StudyFromDate = this.StudyFromDate;
         q.StudyToDate = this.StudyToDate;


         // Storage Date
         q.StorageDateChecked = this.StorageDateChecked;
         q.StorageDateRange = this.StorageDateRangeFilter;

         // 
         q.SeriesDescription = this.SeriesDescription;

#if (LEADTOOLS_V19_OR_LATER_STORE_AE_TITLE) || (LEADTOOLS_V19_OR_LATER_MEDICAL_EXTERNAL_STORE) || (LEADTOOLS_V18_OR_LATER)
         q.StoreAeTitle = this.StoreAETitleTextBox.Text.Trim();
         q.RetrieveAeTitle = this.RetrieveAETitleTextBox.Text.Trim();
#endif

         return q;
      }

      public static DateTime SubtractMonths 
      ( 
         DateTime CurrentDateTime,
         int nMonths
      )
      {
         try
         {
            DateTime resultDateTime = CurrentDateTime ;
         
            for ( int nSubMonths = nMonths; nSubMonths > 0 ; nSubMonths-- ) 
            {
               TimeSpan SubtactionTimeSpan = new TimeSpan ( resultDateTime.Day, 
                                                   resultDateTime.Hour, 
                                                   resultDateTime.Minute, 
                                                   resultDateTime.Second, 
                                                   resultDateTime.Millisecond ) ;
               
               resultDateTime = resultDateTime.Subtract ( SubtactionTimeSpan ) ; 
            }
            
            
            return resultDateTime.Subtract ( new TimeSpan ( resultDateTime.Day - CurrentDateTime.Day, 
                                                            resultDateTime.Hour, 
                                                            resultDateTime.Minute, 
                                                            resultDateTime.Second, 
                                                            resultDateTime.Millisecond ) ) ;
         }
         catch ( Exception exception )
         {
            System.Diagnostics.Debug.Assert ( false ) ;
            
            throw exception ;
         }
      }

      public void PrepareSearchDefault(MatchingParameterCollection matchingCollection)
      {
         try
         {
            // matchingCollection = new MatchingParameterCollection ( ) ;
            MatchingParameterList matchingList = new MatchingParameterList();
            Patient patient = new Patient();
            Study study = new Study();
            Series series = new Series();


            matchingList.Add(patient);
            matchingList.Add(study);
            matchingList.Add(series);

            matchingCollection.Add(matchingList);

            DicomQueryParams q = GetDicomQueryParams();
            study.AccessionNumber = q.AccessionNumber;// txtAccessionNumber.Text ;
            patient.PatientID = q.PatientId;

            if (!string.IsNullOrEmpty(q.PatientName.FamilyName))
               patient.FamilyName = q.PatientName.FamilyName.TrimEnd('*') + "*";

            if (!string.IsNullOrEmpty(q.PatientName.GivenName))
               patient.GivenName = q.PatientName.GivenName.TrimEnd('*') + "*";

            if (!string.IsNullOrEmpty(q.Modalities))
               series.Modality = q.Modalities.Replace(",", "\\");

            if (!string.IsNullOrEmpty(q.SeriesDescription))
               series.SeriesDescription = q.SeriesDescription.TrimEnd('*') + "*";

            if (!string.IsNullOrEmpty(q.ReferringPhysiciansName.FamilyName))
               study.ReferDrFamilyName = q.ReferringPhysiciansName.FamilyName.TrimEnd('*') + "*"; ;

            if (!string.IsNullOrEmpty(q.ReferringPhysiciansName.GivenName))
               study.ReferDrGivenName = q.ReferringPhysiciansName.GivenName.TrimEnd('*') + "*"; ;

            if (q.StudyFromChecked || q.StudyToChecked)
            {
               DateRange studyDateRange;


               studyDateRange = new DateRange();

               if (q.StudyFromChecked)
               {
                  studyDateRange.StartDate = q.StudyFromDate;
               }

               if (q.StudyToChecked)
               {
                  studyDateRange.EndDate = q.StudyToDate;
               }

               study.StudyDate = studyDateRange;
            }

            Instance instance = null;
            if (StorageDateCheckBox.Checked)
            {
               DateRange dateRange;
               string startDate;
               string endDate;


               instance = new Instance();
               dateRange = new DateRange();
               startDate = StorageDateRangeFilter.DateRangeFrom;
               endDate = StorageDateRangeFilter.DateRangeTo;

               if (StorageDateRangeFilter.SelectedDateFilter == DateRangeFilter.RangeFilterType.DateRange)
               {
                  if (!string.IsNullOrEmpty(startDate))
                  {
                     dateRange.StartDate = DateTime.Parse(startDate);
                  }

                  if (!string.IsNullOrEmpty(endDate))
                  {
                     dateRange.EndDate = DateTime.Parse(endDate);
                  }
               }
               else if (StorageDateRangeFilter.SelectedDateFilter == DateRangeFilter.RangeFilterType.Months)
               {
                  DateTime lastMonthsDate;


                  lastMonthsDate = SubtractMonths(DateTime.Now,
                                                    Convert.ToInt32(StorageDateRangeFilter.LastMonths));

                  dateRange.StartDate = lastMonthsDate;
                  dateRange.EndDate = DateTime.Now;
               }
               else
               {
                  TimeSpan subtractionDays;

                  subtractionDays = new TimeSpan(Convert.ToInt32(StorageDateRangeFilter.LastDays),
                                                   DateTime.Now.Hour,
                                                   DateTime.Now.Minute,
                                                   DateTime.Now.Second,
                                                   DateTime.Now.Millisecond);

                  dateRange.StartDate = DateTime.Now.Subtract(subtractionDays);
                  dateRange.EndDate = DateTime.Now;
               }

               instance.ReceiveDate = dateRange;

               matchingList.Add(instance);
            }

            if (!string.IsNullOrEmpty(q.RetrieveAeTitle) || !string.IsNullOrEmpty(q.StoreAeTitle))
            {
               if (instance == null)
               {
                  instance = new Instance();
                  matchingList.Add(instance);

               }
               instance.RetrieveAETitle = q.RetrieveAeTitle;
               instance.StoreAETitle = q.StoreAeTitle;
            }

            study.StudyID = q.StudyId;
         }
         catch (Exception exception)
         {
            throw exception;
         }
      }
   }
}
