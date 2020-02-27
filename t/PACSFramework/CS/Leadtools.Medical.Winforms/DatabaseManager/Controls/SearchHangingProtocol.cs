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
using Leadtools.Medical.DataAccessLayer;
using Leadtools.Medical.Storage.DataAccessLayer.MatchingParameters;
using Leadtools.Medical.Winforms.Control;
using Leadtools.Dicom.Common.DataTypes;

namespace Leadtools.Medical.Winforms.DatabaseManager.Controls
{
   public partial class SearchHangingProtocol : UserControl, ISearch
   {
      public SearchHangingProtocol()
      {
         InitializeComponent();
      }

      public void EnableItems(bool enable)
      {
         groupBoxHangingProtocol.Enabled = enable;
         groupBoxHangingProtocolDefinitioni.Enabled = enable;
         groupBoxAnatomicRegionSequence.Enabled = enable;
         groupBoxProcedureCodeSequence.Enabled = enable;
         groupBoxReason.Enabled = enable;
      }

      // **************
      // *** Properties
      // **************
      public string HangingProtocolName
      {
         get
         {
            return textBoxName.Text;
         }
      }

      public string Description
      {
         get
         {
            return textBoxDescription.Text;
         }
      }

      public string Level
      {
         get
         {
            return textBoxLevel.Text;
         }
      }

      public string Creator
      {
         get
         {
            return textBoxCreator.Text;
         }
      }

      public bool CreationDateFromChecked
      {
         get
         {
            return checkBoxCreationDateFrom.Checked;
         }
      }

      public bool CreationDateToChecked
      {
         get
         {
            return checkBoxCreationDateTo.Checked;
         }
      }

      public DateTime? CreationDateFrom
      {
         get
         {
            return datePickerCreationDateFrom.Value;
         }
      }

      public DateTime? CreationDateTo
      {
         get
         {
            return datePickerCreationDateTo.Value;
         }
      }

      public int ? Priors
      {
         get
         {
            if (checkBoxPriors.Checked)
            {
               return (int)numericUpDownPriors.Value;
            }
            return null;
         }
      }

      public string Modalities
      {
         get
         {
            return modalitiesControl.Modalities;
         }
      }

      public string StudyDescription
      {
         get
         {
            return textBoxStudyDescription.Text;
         }
      }

      public string Laterality
      {
         get
         {
            return textBoxLaterality.Text;
         }
      }

      public string BodyPartExamined
      {
         get
         {
            return textBoxBodyPartExamined.Text;
         }
      }

      public string ProtocolName
      {
         get
         {
            return textBoxProtocolName.Text;
         }
      }

      public string AnatomicRegionCodeValue
      {
         get
         {
            return textBoxAnatomicRegionCodeValue.Text;
         }
      }

      public string AnatomicRegionCodeMeaning
      {
         get
         {
            return textBoxAnatomicRegionCodeMeaning.Text;
         }
      }

      public string ProcedureCodeValue
      {
         get
         {
            return textBoxProcedureCodeValue.Text;
         }
      }

      public string ProcedureCodeMeaning
      {
         get
         {
            return textBoxProcedureCodeMeaning.Text;
         }
      }

      public string ReasonCodeValue
      {
         get
         {
            return textBoxReasonCodeValue.Text;
         }
      }

      public string ReasonCodeMeaning
      {
         get
         {
            return textBoxReasonCodeMeaning.Text;
         }
      }

      private DicomQueryHangingProtocolParams GetDicomQueryParams()
      {
         DicomQueryHangingProtocolParams q = new DicomQueryHangingProtocolParams();

         // Hanging Protocol
         q.Name = this.HangingProtocolName;
         q.Description = this.Description;
         q.Level = this.Level;
         q.Creator = this.Creator;

         q.CreationDateFromChecked = this.CreationDateFromChecked;
         q.CreationDateToChecked = this.CreationDateToChecked;
         q.CreationDateFrom = this.CreationDateFrom;
         q.CreationDateTo = this.CreationDateTo;

         q.Priors = this.Priors;
         q.Modalities = this.Modalities;
         q.StudyDescription = this.StudyDescription;
         q.Laterality = this.Laterality;
         q.BodyPartExamined = this.BodyPartExamined;
         q.ProtocolName = this.ProtocolName;

         q.AnatomicRegionCodeValue = this.AnatomicRegionCodeValue;
         q.AnatomicRegionCodeMeaning = this.AnatomicRegionCodeMeaning;
         q.ProcedureCodeValue = this.ProcedureCodeValue;
         q.ProcedureCodeMeaning = this.ProcedureCodeMeaning;
         q.ReasonCodeValue = this.ReasonCodeValue;
         q.ReasonCodeMeaning = this.ReasonCodeMeaning;
         return q;
      }

      #region ISearch Members

      public void PrepareSearchDefault(MatchingParameterCollection matchingCollection)
      {
#if (LEADTOOLS_V19_OR_LATER)
         try
         {
            MatchingParameterList matchingList = new MatchingParameterList();
            HangingProtocolEntity hpe = new HangingProtocolEntity();

            HangingProtocolDefinitonSequenceEntity hpdse = new HangingProtocolDefinitonSequenceEntity();

            matchingList.Add(hpe);
            matchingList.Add(hpdse);
            matchingCollection.Add(matchingList);

            DicomQueryHangingProtocolParams q = GetDicomQueryParams();

            hpe.Name = q.Name;
            hpe.Description = q.Description;
            hpe.Level = q.Level;
            hpe.Creator = q.Creator;

            // Creation Date
            if (q.CreationDateFromChecked || q.CreationDateToChecked)
            {
               DateRange studyDateRange = new DateRange();

               if (q.CreationDateFromChecked)
               {
                  studyDateRange.StartDate = q.CreationDateFrom;
               }

               if (q.CreationDateToChecked)
               {
                  studyDateRange.EndDate = q.CreationDateTo;
               }

               hpe.CreationDateTime = studyDateRange;
            }

            hpe.NumberOfPriorsReferenced = q.Priors;

            // Hanging Protocol Definition
            if (!string.IsNullOrEmpty(q.Modalities))
               hpdse.Modality = q.Modalities.Replace(",", "\\");

            hpdse.StudyDescription = q.StudyDescription;
            hpdse.Laterality = q.Laterality;
            hpdse.BodyPartExamined = q.BodyPartExamined;
            hpdse.ProtocolName = q.ProtocolName;


            // Anatomic Region Sequence
            if (!string.IsNullOrEmpty(q.AnatomicRegionCodeValue) || !string.IsNullOrEmpty(q.AnatomicRegionCodeMeaning))
            {
               HangingProtocolAnatomicRegionSequenceEntity anatomicRegion = new HangingProtocolAnatomicRegionSequenceEntity();

               matchingList.Add(anatomicRegion);

               anatomicRegion.CodeValue = q.AnatomicRegionCodeValue;
               anatomicRegion.CodeMeaning = q.AnatomicRegionCodeMeaning;
            }


         }
         catch (Exception exception)
         {
            throw exception;
         }
#endif // #if (LEADTOOLS_V19_OR_LATER)
      }

      public void Clear()
      {
         textBoxName.Text = string.Empty;
         textBoxDescription.Text = string.Empty;
         textBoxLevel.Text = string.Empty;
         textBoxCreator.Text = string.Empty;

         checkBoxCreationDateFrom.Checked = false;
         checkBoxCreationDateTo.Checked = false;

         checkBoxPriors.Checked = false;

         modalitiesControl.Clear();

         textBoxStudyDescription.Text = string.Empty;

         textBoxLaterality.Text = string.Empty;

         textBoxAnatomicRegionCodeValue.Text = string.Empty;
         textBoxAnatomicRegionCodeMeaning.Text = string.Empty;

         textBoxProcedureCodeValue.Text = string.Empty;
         textBoxProcedureCodeMeaning.Text = string.Empty;

         textBoxReasonCodeValue.Text = string.Empty;
         textBoxReasonCodeMeaning.Text = string.Empty;
      }

      public void Initialize()
      {
         checkBoxCreationDateFrom.Checked = false;
         checkBoxCreationDateTo.Checked = false;
         checkBoxPriors.Checked = false;

         datePickerCreationDateFrom.DataBindings.Add("Enabled", checkBoxCreationDateFrom, "Checked");
         datePickerCreationDateTo.DataBindings.Add("Enabled", checkBoxCreationDateTo, "Checked");

         modalitiesControl.Initialize();

         UpdateUI();
      }

      public void UpdateUI()
      {
         checkBoxCreationDateFrom_CheckedChanged(null, null);
         checkBoxCreationDateTo_CheckedChanged(null, null);
         checkBoxPriors_CheckedChanged(null, null);
      }

      public void RegisterEvents()
      {
         checkBoxPriors.CheckedChanged += new EventHandler(checkBoxPriors_CheckedChanged);
         checkBoxCreationDateFrom.CheckedChanged += new EventHandler(checkBoxCreationDateFrom_CheckedChanged);
         checkBoxCreationDateTo.CheckedChanged += new EventHandler(checkBoxCreationDateTo_CheckedChanged);

         modalitiesControl.RegisterEvents();
      }

      void checkBoxCreationDateFrom_CheckedChanged(object sender, EventArgs e)
      {
         datePickerCreationDateFrom.Enabled = checkBoxCreationDateFrom.Checked;
      }

      void checkBoxCreationDateTo_CheckedChanged(object sender, EventArgs e)
      {
         datePickerCreationDateTo.Enabled = checkBoxCreationDateTo.Checked;
      }


      void checkBoxPriors_CheckedChanged(object sender, EventArgs e)
      {
         numericUpDownPriors.Enabled = checkBoxPriors.Checked;
      }

      #endregion
   }

   public class DicomQueryHangingProtocolParams
   {
      public DicomQueryHangingProtocolParams()
      {
      }

      public string Name
      {
         get;
         set;
      }

      public string Description
      {
         get;
         set;
      }

      public string Level
      {
         get;
         set;
      }

      public string Creator
      {
         get;
         set;
      }

      public bool CreationDateFromChecked
       {
         get;set;
      }
      
      public bool CreationDateToChecked
       {
         get;set;
      }

      public DateTime? CreationDateFrom
      {
         get;set;
      }
      
      public DateTime? CreationDateTo
      {
         get;set;
      }

      public int ? Priors
      {
         get;set;
      }

      public string Modalities
      {
         get;set;
      }

      public string StudyDescription
      {
         get;set;
      }

      public string Laterality
      {
         get;set;
      }

      public string BodyPartExamined
      {
         get;set;
      }

      public string ProtocolName
      {
         get;set;
      }

       public string AnatomicRegionCodeValue
      {
         get;set;
      }

      public string AnatomicRegionCodeMeaning
      {
         get;set;
      }

      public string ProcedureCodeValue
      {
         get;set;
      }

      public string ProcedureCodeMeaning
      {
         get;set;
      }

      public string ReasonCodeValue
      {
         get;set;
      }

      public string ReasonCodeMeaning
      {
         get;set;
      }

   }

}
