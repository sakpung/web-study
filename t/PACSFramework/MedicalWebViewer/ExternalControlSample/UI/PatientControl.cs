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
using Leadtools.Medical.WebViewer.ExternalControl;
using Leadtools.Dicom.Common.DataTypes;

namespace ExternalControlSample
{
   public partial class PatientControl : UserControl
   {
      public PatientControl()
      {
         InitializeComponent();

         comboBoxPatientId.Left = textBoxPatientId.Left;
         comboBoxPatientId.Top  = textBoxPatientId.Top;
         comboBoxPatientId.Width = textBoxPatientId.Width;
         comboBoxPatientId.Height = textBoxPatientId.Height;

         // UpdateUI();
      }

      private ListView _listViewPatient = null;

      PatientControlType _controlType = PatientControlType.Add;

      [Description("Add or Update"),Category("Behavior")] 
      public PatientControlType ControlType
      {
         get
         {
            return _controlType;
         }
         set
         {
            _controlType = value;
            UpdateUI();
         }
      }

      public ComboBox ComboBoxPatientId
      {
         get
         {
            return comboBoxPatientId;
         }
      }

      void UpdateUI()
      {
         switch (_controlType)
         {
            case PatientControlType.Add:
            comboBoxPatientId.Visible = false;
            textBoxPatientId.Visible = true;
               break;

            case PatientControlType.Update:
            comboBoxPatientId.Visible = true;
            textBoxPatientId.Visible = false;
               break;
         }
      }


      //private void InitializeSamplePatientInfo(ListView listViewPatient)
      //{
      //   foreach (PatientInfo p in patients)
      //   {
      //      ListViewItem lvi = listViewPatient.Items.Add(p.PatientId);
      //      PersonName pn = new PersonName(p.Name);

      //      // Name
      //      lvi.SubItems.Add(pn.Family);
      //      lvi.SubItems.Add(pn.Given);
      //      lvi.SubItems.Add(pn.Middle);
      //      lvi.SubItems.Add(pn.Prefix);
      //      lvi.SubItems.Add(pn.Suffix);

      //      lvi.SubItems.Add(p.BirthDate);
      //      lvi.SubItems.Add(p.Sex);
      //      lvi.SubItems.Add(p.EthnicGroup);
      //      lvi.SubItems.Add(p.Comments);
      //   }
      //   listViewPatient.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
      //   listViewPatient.Items[0].Selected = true;
      //   UpdatePatient();
      //}

      public void Initialize(ListView listViewPatient)
      {
         _listViewPatient = listViewPatient;
         // InitializeSamplePatientInfo(listViewPatient);
         comboBoxSex.Items.Add("M");
         comboBoxSex.Items.Add("F");
         comboBoxSex.Items.Add("O");
         comboBoxSex.SelectedIndex = 2;
      }

      private void PatientControl_Load(object sender, EventArgs e)
      {

      }

      public void UpdatePatient(PatientInfo info)
      {
         if ((info != null) && !string.IsNullOrEmpty(info.PatientId))
         {
            textBoxPatientId.Text = info.PatientId;

            PersonName pn = new PersonName(info.Name);

            textBoxLast.Text = pn.Family;
            textBoxFirst.Text = pn.Given;
            textBoxMiddle.Text = pn.Middle;
            textBoxPrefix.Text = pn.Prefix;
            textBoxSuffix.Text = pn.Suffix;

            dateTimePickerBirthDate.Text = info.BirthDate;

            if (!comboBoxSex.Items.Contains(info.Sex))
            {
               comboBoxSex.Items.Add(info.Sex);
            }
            comboBoxSex.Text = info.Sex;
            textBoxEthnicGroup.Text = info.EthnicGroup;
            textBoxComments.Text = info.Comments;
         }
         else
         {
            textBoxLast.Text = string.Empty;
            textBoxFirst.Text = string.Empty;
            textBoxMiddle.Text = string.Empty;
            textBoxPrefix.Text = string.Empty;
            textBoxSuffix.Text = string.Empty;
            textBoxEthnicGroup.Text = string.Empty;
            textBoxComments.Text = string.Empty;

            int index = comboBoxSex.FindString(_blank);
            if (index >= 0)
            {
               comboBoxSex.SelectedIndex = index;
            }
            else
            {
               comboBoxSex.Text = "O";
            }
            dateTimePickerBirthDate.Value = DateTime.Now;
         }
      }

      public void UpdatePatient()
      {
         if (_listViewPatient == null)
            return;

         if (_listViewPatient.SelectedItems.Count <= 0)
            return;

         ListViewItem lvi = _listViewPatient.SelectedItems[0];
         if (lvi != null)
         {
            textBoxPatientId.Text = lvi.SubItems[0].Text;

            // PersonName pn = new PersonName(lvi.SubItems[1].Text);

            textBoxLast.Text = lvi.SubItems[1].Text;
            textBoxFirst.Text = lvi.SubItems[2].Text;
            textBoxMiddle.Text = lvi.SubItems[3].Text;
            textBoxPrefix.Text = lvi.SubItems[4].Text;
            textBoxSuffix.Text = lvi.SubItems[5].Text;

            dateTimePickerBirthDate.Text = lvi.SubItems[6].Text;
            comboBoxSex.Text = lvi.SubItems[7].Text;
            textBoxEthnicGroup.Text = lvi.SubItems[8].Text;
            textBoxComments.Text = lvi.SubItems[9].Text;
         }
      }

      private void listViewSamplePatientInfo_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdatePatient();
      }

      private string GetPatientName()
      {
         PersonName p = new PersonName();
         p.Family = textBoxLast.Text;
         p.Given = textBoxFirst.Text;
         p.Middle = textBoxMiddle.Text;
         p.Prefix = textBoxPrefix.Text;
         p.Suffix = textBoxSuffix.Text;
         return p.ToString();
      }

      public PatientInfo GetPatientInfo()
      { 
         PatientInfo p = new PatientInfo();

         p.PatientId = textBoxPatientId.Text;
         p.Name = GetPatientName();
         p.BirthDate = dateTimePickerBirthDate.Text;
         p.Sex = comboBoxSex.Text;
         p.EthnicGroup = textBoxEthnicGroup.Text;
         p.Comments = textBoxComments.Text;

         return p;
      }

      public TextBox TextBoxPatientId
      {
         get
         {
            return this.textBoxPatientId;
         }
      }

      private void dateTimePickerBirthDate_EnabledChanged(object sender, EventArgs e)
      {
         if (dateTimePickerBirthDate.Enabled)
         {
            dateTimePickerBirthDate.Format = DateTimePickerFormat.Long;
         }
         else
         {
            dateTimePickerBirthDate.Format = DateTimePickerFormat.Custom;
            dateTimePickerBirthDate.CustomFormat = " ";
         }
      }

      private const string _blank = " ";
      private void comboBoxSex_EnabledChanged(object sender, EventArgs e)
      {
         if (comboBoxSex.Enabled)
         {
            if (comboBoxSex.Items.Contains(_blank))
            {
               comboBoxSex.Items.Remove(_blank);
            }
         }
         else
         {
            if (!comboBoxSex.Items.Contains(_blank))
            {
               comboBoxSex.Items.Add(_blank);
            }
            int index = comboBoxSex.FindString(_blank);
            comboBoxSex.SelectedIndex = index;
         }
      }

      private void comboBoxSex_SelectedIndexChanged(object sender, EventArgs e)
      {
         // Console.WriteLine("comboBoxSex.SelectedIndex " + comboBoxSex.SelectedIndex.ToString());
      }
   }

   public enum PatientControlType
   {
      Add,
      Update
   }
}
