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
using Leadtools.Dicom.Scu;
using DicomDemo.Dicom;
using Leadtools.Dicom.Scu.Queries;
using DicomDemo.Utils;
using Microsoft.WindowsAPICodePack.Dialogs;
using Leadtools.Dicom;
using System.Threading;
using Leadtools.Dicom.Common;
using Leadtools.Dicom.Common.DataTypes;

namespace DicomDemo
{
   public partial class EditPatientDialog : Form
   {
      private NActionScu _naction = null;
      private QueryRetrieveScu _find = null;
      private DicomScp _scp;
      private FocusManager _FocusManager;
      private Patient _Patient = null;

      ErrorProvider errorProvider;

      public Patient Patient
      {
         get { return _Patient; }
         set { _Patient = value; }
      }

      private ActionType _Action = ActionType.None;

      public ActionType Action
      {
         get { return _Action; }
         set { _Action = value; }
      }

      public EditPatientDialog(NActionScu naction, QueryRetrieveScu find, DicomScp scp, Patient patient)
      {
         InitializeComponent();
         _Patient = patient;
         _naction = naction;
         _find = find;
         _scp = scp;

         errorProvider = new ErrorProvider(this);
         errorProvider.SetIconAlignment(textBoxLastname, ErrorIconAlignment.TopLeft);
         errorProvider.SetIconAlignment(textBoxId, ErrorIconAlignment.TopLeft);
      }

      private void EditPatientDialog_Load(object sender, EventArgs e)
      {
         SetPatientInfo();
         SetMode(false);
         _FocusManager = new FocusManager(textBoxId, textBoxLastname, textBoxFirstname, comboBoxSex, dateTimePickerBirth);
         VerifyPatientSettings();

         textBoxId.TextChanged += TextBoxId_TextChanged;
         textBoxOtherPid.TextChanged += TextBoxOtherPid_TextChanged;
         textBoxLastname.TextChanged += TextBoxLastname_TextChanged;
         textBoxFirstname.TextChanged += TextBoxFirstname_TextChanged;

         textBoxId.KeyPress += textBoxId_KeyPress;
         textBoxLastname.KeyPress += UpperCase_KeyPress;
         textBoxFirstname.KeyPress += UpperCase_KeyPress;

         radioButtonMerge.CheckedChanged += RadioButtonMerge_CheckedChanged;
      }

      private void RadioButtonMerge_CheckedChanged(object sender, EventArgs e)
      {
         bool isError = VerifyPatientSettings();
         SetMode(isError);
      }

      private void TextBoxId_TextChanged(object sender, EventArgs e)
      {
         VerifyPatientSettings();
      }

      private void TextBoxOtherPid_TextChanged(object sender, EventArgs e)
      {
         VerifyPatientSettings();
      }

      private void TextBoxFirstname_TextChanged(object sender, EventArgs e)
      {
         VerifyPatientSettings();
      }

      private void TextBoxLastname_TextChanged(object sender, EventArgs e)
      {
         VerifyPatientSettings();
      }

      private void SetPatientInfo()
      {
         PatientId.Text = _Patient.Id;
         LastName.Text = _Patient.Name.Family;
         FirstName.Text = _Patient.Name.Given;
         Sex.Text = _Patient.Sex;
         DateOfBirth.Text = Program.DateString(_Patient.BirthDate);

         textBoxId.Text = _Patient.Id;
         textBoxLastname.Text = _Patient.Name.Family;
         textBoxFirstname.Text = _Patient.Name.Given;
         comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(_Patient.Sex);
         if (_Patient.BirthDate.HasValue)
         {
            dateTimePickerBirth.Value = _Patient.BirthDate.Value;
            dateTimePickerBirth.Checked = true;
         }
         else
            dateTimePickerBirth.Checked = false;

         if (Program.OtherPID.ContainsKey(_Patient.Id))
         {
            OtherPatientIds.Text = Program.OtherPID[_Patient.Id];
            textBoxOtherPid.Text = Program.OtherPID[_Patient.Id];
         }
         else
         {
            OtherPatientIds.Text = string.Empty;
            textBoxOtherPid.Text = string.Empty;
         }

         radioButtonChange.Checked = true;
      }

      private void SetMode(bool isError)
      {
         if (radioButtonChange.Checked)
         {
            textBoxId.Width = textBoxLastname.Width;
         }
         else
         {
            textBoxId.Width = Convert.ToInt32(textBoxLastname.Width * .65);
            TextBoxId_TextChanged(null, EventArgs.Empty);
         }

         SearchButton.Visible = radioButtonMerge.Checked;
         textBoxOtherPid.Enabled = radioButtonChange.Checked;
         textBoxLastname.Enabled = radioButtonChange.Checked;
         textBoxFirstname.Enabled = radioButtonChange.Checked;
         comboBoxSex.Enabled = radioButtonChange.Checked;
         dateTimePickerBirth.Enabled = radioButtonChange.Checked;

         ActionButton.Text = radioButtonChange.Checked ? "Change" : "Merge";
         ActionButton.Enabled = !isError && radioButtonChange.Checked;
      }


      private void ActionButton_Click(object sender, EventArgs e)
      {
         if (radioButtonChange.Checked)
            ChangePatient();
         else
            MergePatient();
      }

      bool VerifyPatientSettings()
      {
         errorProvider.Clear();

         string errorString = string.Empty;
         Control control = null;

         // (0010:0020) PatientID
         if (string.IsNullOrEmpty(errorString))
         {
            string patientId = textBoxId.Text.Trim();
            if (patientId.Contains("\\"))
            {
               errorString = "Patient ID cannot contain the '\' character.";
               control = textBoxId;
            }
            else if (patientId.Length > 64)
            {
               errorString = string.Format("Patient ID cannot exceed 64 characters in length");
               control = textBoxId;
            }
            else if (patientId.Length == 0)
            {
               errorString = string.Format("Patient ID must contain a value");
               control = textBoxId;
            }
         }

         if (radioButtonChange.Checked)
         {
            // (0010:0010) PatientName
            if (string.IsNullOrEmpty(errorString))
            {
               string familyName = textBoxLastname.Text.Trim();
               string givenName = textBoxFirstname.Text.Trim();

               if (familyName.Length > 64)
               {
                  errorString = string.Format("Last name cannot exceed 64 characters in length: {0}", familyName);
                  control = textBoxLastname;
               }
               else if (givenName.Length > 64)
               {
                  errorString = string.Format("First name cannot exceed 64 characters in length: {0}", givenName);
                  control = textBoxFirstname;
               }
               else
               {
                  PersonName personName = new PersonName();
                  personName.Family = textBoxLastname.Text.Trim();
                  personName.Given = textBoxFirstname.Text.Trim();

                  string patientName = personName.FullDicomEncoded;
                  if (patientName.Length > 64)
                  {
                     errorString = string.Format("Full patient name {{LastName}}^{{FirstName}} cannot exceed 64 characters in length: {0}", patientName);
                     control = textBoxLastname;
                  }
                  else if (patientName.Length == 0)
                  {
                     errorString = string.Format("Full patient name {{LastName}}^{{FirstName}} must contain a value");
                     control = textBoxLastname;
                  }
               }
            }
         }

         if (control != null)
         {
            errorProvider.SetIconAlignment(control, ErrorIconAlignment.TopLeft);
            errorProvider.SetError(control, errorString);
         }

         bool isError = !string.IsNullOrEmpty(errorString);

         ActionButton.Enabled = !isError && radioButtonChange.Checked;
         CopyButton.Enabled = !isError && (textBoxId.Text.Length > 0) && (textBoxId.Text != _Patient.Id) && !radioButtonMerge.Checked;
         SearchButton.Enabled = !isError && (textBoxId.Text.Length > 0) && (textBoxId.Text != _Patient.Id) && radioButtonMerge.Checked;


         return isError;
      }

      private void ChangePatient()
      {
         //
         // If the patient ID has changed then we need to see if a patient with that id already exists
         //
         if (_Patient.Id != textBoxId.Text)
         {
            PatientRootQueryPatient query = new PatientRootQueryPatient();
            List<Patient> patients = new List<Patient>();

            query.PatientQuery.PatientId = textBoxId.Text;
            try
            {
               _find.Find<PatientRootQueryPatient, Patient>(_scp, query, (patient, ds) => patients.Add(patient));
               if (patients.Count > 0)
               {
                  TaskDialogResult result = TaskDialogResult.Yes;

                  result = TaskDialogHelper.ShowMessageBox(this, "Patient Id Already Exits", "Would you like to merge with existing patient?",
                                                           "The patient id already exisits.", "Existing Patient: " + patients[0].Name.Full,
                                                           TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No, TaskDialogStandardIcon.Error, TaskDialogStandardIcon.Warning);

                  if (result == TaskDialogResult.Yes)
                  {
                     radioButtonMerge.Checked = true;
                     textBoxLastname.Text = patients[0].Name.Family;
                     textBoxFirstname.Text = patients[0].Name.Given;
                     comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(patients[0].Sex);
                     if (patients[0].BirthDate.HasValue)
                     {
                        dateTimePickerBirth.Value = patients[0].BirthDate.Value;
                        dateTimePickerBirth.Checked = true;
                     }
                     else
                        dateTimePickerBirth.Checked = false;
                     MergePatient();
                     return;
                  }
                  else
                  {
                     textBoxId.Text = _Patient.Id;
                     return;
                  }
               }
            }
            catch (Exception e)
            {
               ApplicationUtils.ShowException(this, e);
               return;
            }
         }

         bool isError = VerifyPatientSettings();
         if (isError)
         {
            return;
         }

         ReasonDialog dlgReason = new ReasonDialog("Input Reason For Changing Patient");

         if (dlgReason.ShowDialog(this) == DialogResult.OK)
         {
            ChangePatient change = new ChangePatient();
            DicomCommandStatusType status = DicomCommandStatusType.Success;

            change.OriginalPatientId = _Patient.Id.Replace(@"\", @"\\").Replace("'", @"''");
            change.Operator = Environment.UserName != string.Empty ? Environment.UserName : Environment.MachineName;
            change.PatientId = textBoxId.Text.Replace(@"\", @"\\").Replace("'", @"''");
            change.Reason = dlgReason.Reason;
            change.Description = "Change Patient";
            change.Name.Given = textBoxFirstname.Text.Replace(@"\", @"\\").Replace("'", @"''");
            change.Name.Family = textBoxLastname.Text.Replace(@"\", @"\\").Replace("'", @"''");
            change.Sex = comboBoxSex.Text;
            if (dateTimePickerBirth.Checked)
               change.Birthdate = dateTimePickerBirth.Value;
            else
               change.Birthdate = null;

#if (LEADTOOLS_V19_OR_LATER)
            if (textBoxOtherPid.Text.Length > 0)
            {
               change.OtherPatientIdsSequence = new List<Leadtools.Dicom.Common.DataTypes.PatientUpdater.OtherPatientID>();
               string textBoxStringOtherPid = textBoxOtherPid.Text.Replace("'", @"''");

               if (!string.IsNullOrEmpty(textBoxStringOtherPid))
               {
                  char[] delimiterChars = { '\\' };
                  string[] otherPatientIds = textBoxStringOtherPid.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                  foreach (string otherPatientId in otherPatientIds)
                  {
                     Leadtools.Dicom.Common.DataTypes.PatientUpdater.OtherPatientID opid = new Leadtools.Dicom.Common.DataTypes.PatientUpdater.OtherPatientID();
                     opid.PatientId = otherPatientId;
                     opid.TypeOfPatientId = "TEXT";
                     change.OtherPatientIdsSequence.Add(opid);
                  }
               }

            }
#endif

            status = _naction.SendNActionRequest<ChangePatient>(_scp, change, NActionScu.ChangePatient,
                                                                NActionScu.PatientUpdateInstance);
            if (status == DicomCommandStatusType.Success)
            {
               _Patient.Id = textBoxId.Text;
               _Patient.Name.Given = textBoxFirstname.Text;
               _Patient.Name.Family = textBoxLastname.Text;
               _Patient.Sex = comboBoxSex.Text;
               if (dateTimePickerBirth.Checked)
                  _Patient.BirthDate = dateTimePickerBirth.Value;
               else
                  _Patient.BirthDate = null;
               Action = ActionType.Change;
               TaskDialogHelper.ShowMessageBox(this, "Patient Changed", "The patient has been successfully changed.", string.Empty,
                                           string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
               DialogResult = DialogResult.OK;

               if (change.OriginalPatientId != _Patient.Id)
               {
                  if (Program.OtherPID.ContainsKey(change.OriginalPatientId))
                     Program.OtherPID.Remove(change.OriginalPatientId);
               }

               Program.OtherPID[_Patient.Id] = textBoxOtherPid.Text;
            }
            else
            {
               string message = "The patient was not changed.\r\nError - " + _naction.GetErrorMessage();

               if (status == DicomCommandStatusType.MissingAttribute)
                  message = "The patient was not changed.\r\nPatient not found on server.";

               TaskDialogHelper.ShowMessageBox(this, "Change Patient Error", "The patient was not changed.", message,
                                           string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
            }
         }
      }

      private void MergePatient()
      {
         ReasonDialog dlgReason = new ReasonDialog("Input Reason For Merging Patient");

         if (dlgReason.ShowDialog(this) == DialogResult.OK)
         {
            MergePatient merge = new MergePatient();
            DicomCommandStatusType status = DicomCommandStatusType.Success;
            ProgressDialog progress = new ProgressDialog();

            merge.PatientId = textBoxId.Text;
            merge.Operator = Environment.UserName != string.Empty ? Environment.UserName : Environment.MachineName;
            merge.Reason = dlgReason.Reason;
            merge.Description = "Merge Patient";
            merge.PatientToMerge.Add(new MergePatientSequence(_Patient.Id));

            Thread thread = new Thread(() =>
                {
                   try
                   {
                      status = _naction.SendNActionRequest<MergePatient>(_scp, merge, NActionScu.MergePatient,
                                                                     NActionScu.PatientUpdateInstance);
                   }
                   catch (Exception e)
                   {
                      ApplicationUtils.ShowException(this, e);
                      status = DicomCommandStatusType.Failure;
                   }
                });

            progress.ActionThread = thread;
            progress.Title = "Merging Patient: " + _Patient.Name.Full;
            progress.ProgressInfo = "Performing patient merge.";
            progress.ShowDialog(this);
            if (status == DicomCommandStatusType.Success)
            {
               Action = ActionType.Merge;
               TaskDialogHelper.ShowMessageBox(this, "Patient Merge", "The patient has been successfully merged.", GetMergeInfo(),
                                           string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
               DialogResult = DialogResult.OK;
            }
            else
            {
               string message = "The patient has not been merged.\r\nError - ";
               string footer = string.Empty;

               if (status == DicomCommandStatusType.Reserved2)
                  message += "Missing Files";
               else
                  message += _naction.GetErrorMessage();

               if (status == DicomCommandStatusType.MissingAttribute)
                  message = "The patient has not been merged.\r\nPatient not found on server.";
               else if (status == DicomCommandStatusType.Reserved2)
                  footer = "Contact system administrator for help in resolving this issue.";

               TaskDialogHelper.ShowMessageBox(this, "Merge Patient Error", "The patient has not been merged.", message,
                                           footer, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
            }
         }
      }

      private void CopyPatient()
      {
         //
         // If the patient ID has changed then we need to see if a patient with that id already exists
         //
         if (_Patient.Id != textBoxId.Text)
         {
            PatientRootQueryPatient query = new PatientRootQueryPatient();
            List<Patient> patients = new List<Patient>();

            query.PatientQuery.PatientId = textBoxId.Text;
            try
            {
               _find.Find<PatientRootQueryPatient, Patient>(_scp, query, (patient, ds) => patients.Add(patient));
               if (patients.Count > 0)
               {
                  TaskDialogResult result = TaskDialogResult.Yes;

                  result = TaskDialogHelper.ShowMessageBox(this, "Patient Id Already Exits", "Would you like to merge with existing patient?",
                                                           "The patient id already exisits.", "Existing Patient: " + patients[0].Name.Full,
                                                           TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No, TaskDialogStandardIcon.Error, TaskDialogStandardIcon.Warning);

                  if (result == TaskDialogResult.Yes)
                  {
                     radioButtonMerge.Checked = true;
                     textBoxLastname.Text = patients[0].Name.Family;
                     textBoxFirstname.Text = patients[0].Name.Given;
                     if (string.IsNullOrEmpty(patients[0].Sex))
                        comboBoxSex.Text = string.Empty;
                     else
                        comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(patients[0].Sex);
                     if (patients[0].BirthDate.HasValue)
                     {
                        dateTimePickerBirth.Value = patients[0].BirthDate.Value;
                        dateTimePickerBirth.Checked = true;
                     }
                     else
                        dateTimePickerBirth.Checked = false;
                  }
                  else
                  {
                     textBoxId.Text = _Patient.Id;
                     return;
                  }
               }
            }
            catch (Exception e)
            {
               ApplicationUtils.ShowException(this, e);
               return;
            }
         }

         ReasonDialog dlgReason = new ReasonDialog("Input Reason For Copying Patient");

         if (dlgReason.ShowDialog(this) == DialogResult.OK)
         {
            CopyPatient change = new CopyPatient();
            DicomCommandStatusType status = DicomCommandStatusType.Success;

            change.OriginalPatientId = _Patient.Id.Replace(@"\", @"\\").Replace("'", @"''");
            change.Operator = Environment.UserName != string.Empty ? Environment.UserName : Environment.MachineName;
            change.PatientId = textBoxId.Text.Replace(@"\", @"\\").Replace("'", @"''");
            change.Reason = dlgReason.Reason;
            change.Description = "Copy Patient";
            change.Name.Given = textBoxFirstname.Text.Replace(@"\", @"\\").Replace("'", @"''");
            change.Name.Family = textBoxLastname.Text.Replace(@"\", @"\\").Replace("'", @"''");
            change.Sex = comboBoxSex.Text;
            if (dateTimePickerBirth.Checked)
               change.Birthdate = dateTimePickerBirth.Value;
            else
               change.Birthdate = null;

#if (LEADTOOLS_V19_OR_LATER)
            if (textBoxOtherPid.Text.Length > 0)
            {
               Leadtools.Dicom.Common.DataTypes.PatientUpdater.OtherPatientID opid = new Leadtools.Dicom.Common.DataTypes.PatientUpdater.OtherPatientID();

               change.OtherPatientIdsSequence = new List<Leadtools.Dicom.Common.DataTypes.PatientUpdater.OtherPatientID>();
               opid.PatientId = textBoxOtherPid.Text.Replace(@"\", @"\\").Replace("'", @"''");
               opid.TypeOfPatientId = "TEXT";
               change.OtherPatientIdsSequence.Add(opid);
            }
#endif

            status = _naction.SendNActionRequest<CopyPatient>(_scp, change, NActionScu.CopyPatient, NActionScu.PatientUpdateInstance);
            if (status == DicomCommandStatusType.Success)
            {
               //_Patient.Id = textBoxId.Text;
               //_Patient.Name.Given = textBoxFirstname.Text;
               //_Patient.Name.Family = textBoxLastname.Text;
               //_Patient.Sex = comboBoxSex.Text;
               //if (dateTimePickerBirth.Checked)
               //    _Patient.BirthDate = dateTimePickerBirth.Value;
               //else
               //    _Patient.BirthDate = null;
               Action = ActionType.CopyPatient;
               TaskDialogHelper.ShowMessageBox(this, "Patient Copied", "The patient has been successfully copied.", string.Empty,
                                           string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
               DialogResult = DialogResult.OK;
            }
            else
            {
               TaskDialogHelper.ShowMessageBox(this, "Copy Error", "The patient has not been successfully copied.", string.Empty,
                                           "Error - " + _naction.GetErrorMessage(), TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
            }
         }
      }

      private string GetMergeInfo()
      {
         string info = string.Empty;

         info = string.Format("Patient {0} ({1}) has been merged with patient {2}({3})",
                              _Patient.Name.Full, _Patient.Id, textBoxFirstname.Text + " " + textBoxLastname.Text,
                              textBoxId.Text);
         return info;
      }

      private void SearchButton_Click(object sender, EventArgs e)
      {
         Patient patient = DicomUtils.FindPatient(this, _find, _scp, textBoxId.Text);

         if (patient != null)
         {
            textBoxLastname.Text = patient.Name.Family;
            textBoxFirstname.Text = patient.Name.Given;
            comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(patient.Sex);
            if (patient.BirthDate.HasValue)
            {
               dateTimePickerBirth.Value = patient.BirthDate.Value;
               dateTimePickerBirth.Checked = true;
            }

            if (Program.OtherPID.ContainsKey(patient.Id))
            {
               textBoxOtherPid.Text = Program.OtherPID[patient.Id];
            }
            else
            {
               OtherPatientIds.Text = string.Empty;
               textBoxOtherPid.Text = string.Empty;
            }
         }
         else
         {
            TaskDialogHelper.ShowMessageBox(this, "Patient Search", "Patient with specified id was not found.", string.Empty,
                                           string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
         }
         ActionButton.Enabled = patient != null;
      }

      private void EditPatientDialog_Shown(object sender, EventArgs e)
      {
         textBoxId.Focus();
         helpOtherPaitientIds.Visible = false;
      }

      private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == '*')
            e.Handled = true;
      }

      private void UpperCase_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (char.IsLetter(e.KeyChar))
            e.KeyChar = char.ToUpper(e.KeyChar);
      }


      private void CopyButton_Click(object sender, EventArgs e)
      {
         CopyPatient();
      }

      private void textBoxOtherPid_Enter(object sender, EventArgs e)
      {
         helpOtherPaitientIds.Visible = true;
      }

      private void textBoxOtherPid_Leave(object sender, EventArgs e)
      {
         helpOtherPaitientIds.Visible = false;
      }
   }
}
