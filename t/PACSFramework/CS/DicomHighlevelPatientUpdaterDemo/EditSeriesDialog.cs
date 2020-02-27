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
using Leadtools.Dicom;
using DicomDemo.Utils;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Threading;
using Leadtools.Dicom.Scu.Queries;
using DicomDemo.Properties;
using System.Configuration;

namespace DicomDemo
{
   public partial class EditSeriesDialog : Form
   {
      private NActionScu _naction = null;
      private DicomScp _scp = null;
      private QueryRetrieveScu _find = null;
      private FocusManager _FocusManager;

      private PatientUpdaterSeries _Series = null;

#if LEADTOOLS_V19_OR_LATER
      //         ChangeStudy _Study = null;
#else
        private Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangeStudy _Study = null;
#endif

      public PatientUpdaterSeries Series
      {
         get { return _Series; }
      }

      private ActionType _Action = ActionType.None;

      public ActionType Action
      {
         get { return _Action; }
      }

      private Patient _Patient = null;

      public Patient Patient
      {
         get { return _Patient; }
      }

      private string _StudyInstanceUID = string.Empty;

      public string StudyInstanceUID
      {
         get { return _StudyInstanceUID; }
      }

      public EditSeriesDialog(NActionScu naction, QueryRetrieveScu find, DicomScp scp, string studyInstanceUID,
                              PatientUpdaterSeries series, Patient patient)
      {
         InitializeComponent();
         _Series = series;
         _Patient = patient;
         _naction = naction;
         _scp = scp;
         _find = find;
         _StudyInstanceUID = studyInstanceUID;
         InitializeModalities();
         try
         {
            radioButtonMoveSeriesToExistingPatient.Visible = ConfigurationManager.AppSettings["AllowSeriesMove"] == null ? false : bool.Parse(ConfigurationManager.AppSettings["AllowSeriesMove"]);
         }
         catch
         {
            radioButtonMoveSeriesToExistingPatient.Visible = false;
         }
      }

      private void InitializeModalities()
      {
         string[] modalities = Settings.Default.Modalities.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

         comboBoxModality.Items.AddRange(modalities);
      }

      private void SetPatientInfo()
      {
         PatientId.Text = _Patient.Id;
         LastName.Text = _Patient.Name.Family;
         FirstName.Text = _Patient.Name.Given;
         Sex.Text = _Patient.Sex;
         DateOfBirth.Text = Program.DateString(_Patient.BirthDate);

         textBoxId.Text = _Patient.Id;

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

         textBoxLastname.Text = _Patient.Name.Family;
         textBoxFirstname.Text = _Patient.Name.Given;
         if (string.IsNullOrEmpty(_Patient.Sex))
            comboBoxSex.Text = string.Empty;
         else
            comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(_Patient.Sex);
         if (_Patient.BirthDate.HasValue)
         {
            dateTimePickerBirth.Value = _Patient.BirthDate.Value;
            dateTimePickerBirth.Checked = true;
         }
         else
            dateTimePickerBirth.Checked = false;
      }

      private void SetSeriesInfo()
      {
         SeriesDate.Text = Program.DateString(_Series.Date);
         SeriesTime.Text = _Series.Time.HasValue ? _Series.Time.Value.ToString("h:mm:ss.ff") : string.Empty;
         SeriesDescription.Text = _Series.Description;
         SeriesModality.Text = _Series.Modality;

         if (_Series.Date.HasValue)
         {
            dateTimePickerSeriesDate.Value = _Series.Date.Value;
            dateTimePickerSeriesDate.Checked = true;
         }
         else
            dateTimePickerSeriesDate.Checked = false;

         if (_Series.Time.HasValue)
         {
            dateTimePickerSeriesTime.Value = _Series.Time.Value;
            dateTimePickerSeriesTime.Checked = true;
         }
         else
            dateTimePickerSeriesTime.Checked = false;

         textBoxDescription.Text = _Series.Description;
         comboBoxModality.Text = _Series.Modality;
      }

      private void SetStudyInfo()
      {
         txtDescription.Text = _Series.Study.Description;
         txtID.Text = _Series.Study.Id;
         txtAccession.Text = _Series.Study.AccessionNumber;
         txtUID.Text = _Series.Study.InstanceUID;
         txtUID.ReadOnly = true;

         if (_Series.Study.Date.HasValue)
         {
            dateTimePickerStudyDate.Value = _Series.Study.Date.Value;
            dateTimePickerStudyDate.Checked = true;
         }
         else
            dateTimePickerSeriesDate.Checked = false;
      }

      private void SetMode()
      {
         // Change Series Info
         if (radioButtonChangeSeries.Checked)
         {
            textBoxId.Width = textBoxLastname.Width;
            ActionButton.Enabled = true;
         }
         else
         {
            textBoxId.Width = Convert.ToInt32(textBoxLastname.Width - 100);
            if (radioButtonMoveStudyToExistingPatient.Checked || radioButtonMoveSeriesToExistingPatient.Checked || radioButtonMoveStudyToNewPatient.Checked)
            {
               textBoxId_TextChanged(null, EventArgs.Empty);
               ActionButton.Enabled = false;
            }
         }

         // bool existingPatient = radioButtonMoveStudyToExistingPatient.Checked | radioButtonMoveSeriesToExistingPatient.Checked;

         textBoxId.Enabled = !radioButtonChangeSeries.Checked;

         SearchButton.Visible             = !radioButtonChangeSeries.Checked;
         textBoxOtherPid.Enabled          = radioButtonMoveStudyToNewPatient.Checked;
         textBoxLastname.Enabled          = radioButtonMoveStudyToNewPatient.Checked;
         textBoxFirstname.Enabled         = radioButtonMoveStudyToNewPatient.Checked;
         comboBoxSex.Enabled              = radioButtonMoveStudyToNewPatient.Checked;
         dateTimePickerBirth.Enabled      = radioButtonMoveStudyToNewPatient.Checked;

         dateTimePickerSeriesDate.Enabled = radioButtonChangeSeries.Checked;
         dateTimePickerSeriesTime.Enabled = radioButtonChangeSeries.Checked;
         textBoxDescription.Enabled       = radioButtonChangeSeries.Checked;
         comboBoxModality.Enabled         = radioButtonChangeSeries.Checked;

         ActionButton.Text = radioButtonChangeSeries.Checked ? "Change" : "Move";
         CopyButton.Enabled = (textBoxId.Text.Length > 0) && 
                              (textBoxId.Text != _Patient.Id) && 
                              !radioButtonChangeSeries.Checked && 
                              !radioButtonMoveSeriesToExistingPatient.Checked;
      }

      private void EditSeriesDialog_Load(object sender, EventArgs e)
      {
         SetPatientInfo();
         SetSeriesInfo();
         SetStudyInfo();
         SetMode();
         _FocusManager = new FocusManager(textBoxId, textBoxLastname, textBoxFirstname, comboBoxSex, dateTimePickerBirth,
                                          dateTimePickerSeriesDate, dateTimePickerSeriesTime, textBoxDescription, comboBoxModality);

         this.radioButtonChangeSeries.CheckedChanged += new System.EventHandler(ModeChanged);
         this.radioButtonMoveStudyToNewPatient.CheckedChanged += new System.EventHandler(ModeChanged);
         this.radioButtonMoveSeriesToExistingPatient.CheckedChanged += new System.EventHandler(ModeChanged);
         this.radioButtonMoveStudyToExistingPatient.CheckedChanged += new System.EventHandler(ModeChanged);

      }

      private void ModeChanged(object sender, EventArgs e)
      {
         // Want to call SetMode only once when the radio buttons change
         RadioButton radioButton = sender as RadioButton;
         if (radioButton != null && radioButton.Checked)
         {
            SetMode();
         }
      }

      private void ActionButton_Click(object sender, EventArgs e)
      {
         if (radioButtonChangeSeries.Checked)          // Change Series Info
            ChangeSeries();
         else if (radioButtonMoveStudyToExistingPatient.Checked)      // Move study to existing patient
            MergeStudy();
         else if (radioButtonMoveSeriesToExistingPatient.Checked) // Move series to existing patient
            MoveSeries();
         else
            MoveToNewPatient();                  // Move Study to new Patient
      }

      /* 
       * Example for deleting a study
       * 
       *private void DeleteStudy()
       {
           ReasonDialog dlgReason = new ReasonDialog("Input Reason For Deleting Study");

           if (dlgReason.ShowDialog(this) == DialogResult.OK)
           {
              Leadtools.Dicom.Common.DataTypes.PatientUpdater.DeleteStudy deleteStudy = new Leadtools.Dicom.Common.DataTypes.PatientUpdater.DeleteStudy();
               DicomCommandStatusType status = DicomCommandStatusType.Success;
               ProgressDialog progress = new ProgressDialog();

               deleteStudy.StudyInstanceUID = _StudyInstanceUID;
               deleteStudy.Operator = Environment.UserName != string.Empty ? Environment.UserName : Environment.MachineName;
               deleteStudy.Reason = dlgReason.Reason;
               deleteStudy.Description = "Delete Study";                                

               Thread thread = new Thread(() =>
                   {
                       try
                       {
                          status = _naction.SendNActionRequest<Leadtools.Dicom.Common.DataTypes.PatientUpdater.DeleteStudy>(_scp, deleteStudy, 
                             Leadtools.Dicom.Common.DataTypes.PatientUpdater.PatientUpdaterConstants.Action.DeleteStudy,
                                                                       NActionScu.PatientUpdateInstance);
                       }
                       catch (Exception e)
                       {
                           ApplicationUtils.ShowException(this, e);
                           status = DicomCommandStatusType.Failure;
                       }
                   });

               progress.ActionThread = thread;
               progress.Title = "Deleting Study";
               progress.ProgressInfo = "Performing study delete.";                
               progress.ShowDialog(this);
               if (status == DicomCommandStatusType.Success)
               {                     
                   _Action = ActionType.Change;
                   TaskDialogHelper.ShowMessageBox(this, "Study Deleted", "The study has been successfully deleted.", string.Empty,
                                                   string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                                   null);
                   DialogResult = DialogResult.OK;
               }
               else
               {
                  string message = "The study was not deleted.\r\nError - " + _naction.GetErrorMessage();

                   if (status == DicomCommandStatusType.MissingAttribute)
                       message = "The study was not deleted.\r\nStudy not found on server.";

                   TaskDialogHelper.ShowMessageBox(this, "Delete Study Error", "The study was not deleted.", message,
                                               string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                               null);
               }
           }
       }*/


      //Example for changing study information

      private void ChangeStudy()
      {
         ReasonDialog dlgReason = new ReasonDialog("Input Reason For Changing Study");

         if (dlgReason.ShowDialog(this) == DialogResult.OK)
         {
#if LEADTOOLS_V19_OR_LATER
            ChangeStudy change = new ChangeStudy();
#else
                 Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangeStudy change = new Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangeStudy();
#endif
            DicomCommandStatusType status = DicomCommandStatusType.Success;
            ProgressDialog progress = new ProgressDialog();
            change.StudyID = txtID.Text;
            change.AccessionNumber = txtAccession.Text;
            change.Description = "Change Study";
            change.StudyDescription = txtDescription.Text;

            if (dateTimePickerStudyDate.Checked)
               change.StudyDate = dateTimePickerStudyDate.Value;
            else
               change.StudyDate = null;

            change.StudyInstanceUID = _StudyInstanceUID;
            change.Operator = Environment.UserName != string.Empty ? Environment.UserName : Environment.MachineName;
            change.Reason = dlgReason.Reason;

            Thread thread = new Thread(() =>
                {
                   try
                   {
#if LEADTOOLS_V19_OR_LATER
                           status = _naction.SendNActionRequest<ChangeStudy>(_scp, change, NActionScu.ChangeStudy,
                                                                       NActionScu.PatientUpdateInstance);
#else
                             status = _naction.SendNActionRequest<Leadtools.Dicom.Common.DataTypes.PatientUpdater.ChangeStudy>(_scp, change, NActionScu.ChangeStudy,
                                                                         NActionScu.PatientUpdateInstance);
#endif
                        }
                   catch (Exception e)
                   {
                      ApplicationUtils.ShowException(this, e);
                      status = DicomCommandStatusType.Failure;
                   }
                });

            progress.ActionThread = thread;
            progress.Title = "Changing Study";
            progress.ProgressInfo = "Performing study change.";
            progress.ShowDialog(this);
            if (status == DicomCommandStatusType.Success)
            {
               _Action = ActionType.Change;
               TaskDialogHelper.ShowMessageBox(this, "Study Changed", "The study has been successfully changed.", string.Empty,
                                               string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                               null);
               DialogResult = DialogResult.OK;
            }
            else
            {
               string message = "The study was not changed.\r\nError - " + _naction.GetErrorMessage();

               if (status == DicomCommandStatusType.MissingAttribute)
                  message = "The study was not changed.\r\nStudy not found on server.";

               TaskDialogHelper.ShowMessageBox(this, "Change Study Error", "The study was not changed.", message,
                                           string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
            }
         }
      }

      private void ChangeSeries()
      {
         ReasonDialog dlgReason = new ReasonDialog("Input Reason For Changing Series");

         if (dlgReason.ShowDialog(this) == DialogResult.OK)
         {
            ChangeSeries change = new ChangeSeries();
            DicomCommandStatusType status = DicomCommandStatusType.Success;
            ProgressDialog progress = new ProgressDialog();

            change.SeriesInstanceUID = _Series.InstanceUID;
            change.Operator = Environment.UserName != string.Empty ? Environment.UserName : Environment.MachineName;
            change.Reason = dlgReason.Reason;
            change.Description = "Change Series";
            change.Modality = comboBoxModality.Text;
            change.SeriesDescription = textBoxDescription.Text.Replace(@"\", @"\\").Replace("'", @"''");
            if (dateTimePickerSeriesDate.Checked)
               change.SeriesDate = dateTimePickerSeriesDate.Value;
            else
               change.SeriesDate = null;

            if (dateTimePickerSeriesTime.Checked)
            {
               change.SeriesTime = dateTimePickerSeriesTime.Value;
            }
            else
               change.SeriesTime = null;

            Thread thread = new Thread(() =>
                {
                   try
                   {
                      status = _naction.SendNActionRequest<ChangeSeries>(_scp, change, NActionScu.ChangeSeries,
                                                                      NActionScu.PatientUpdateInstance);
                   }
                   catch (Exception e)
                   {
                      ApplicationUtils.ShowException(this, e);
                      status = DicomCommandStatusType.Failure;
                   }
                });

            progress.ActionThread = thread;
            progress.Title = "Changing Series";
            progress.ProgressInfo = "Performing series change.";
            progress.ShowDialog(this);
            if (status == DicomCommandStatusType.Success)
            {
               _Series.Modality = comboBoxModality.Text;
               _Series.Description = textBoxDescription.Text;
               if (dateTimePickerSeriesDate.Checked)
                  _Series.Date = change.SeriesDate;
               else
                  _Series.Date = null;

               if (dateTimePickerSeriesTime.Checked)
                  _Series.Time = change.SeriesTime;
               else
                  _Series.Time = null;

               _Action = ActionType.Change;
               TaskDialogHelper.ShowMessageBox(this, "Series Changed", "The series has been successfully changed.", string.Empty,
                                               string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                               null);
               DialogResult = DialogResult.OK;
            }
            else
            {
               string message = "The series was not changed.\r\nError - " + _naction.GetErrorMessage();

               if (status == DicomCommandStatusType.MissingAttribute)
                  message = "The series was not changed.\r\nSeries not found on server.";

               TaskDialogHelper.ShowMessageBox(this, "Change Series Error", "The series was not changed.", message,
                                           string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
            }
         }
      }

      private void MergeStudy()
      {
         ReasonDialog dlgReason = new ReasonDialog("Input Reason For Merging Study");

         if (dlgReason.ShowDialog(this) == DialogResult.OK)
         {
            MergeStudy merge = new MergeStudy();
            DicomCommandStatusType status = DicomCommandStatusType.Success;
            ProgressDialog progress = new ProgressDialog();

            merge.PatientId = textBoxId.Text.Replace(@"\", @"\\").Replace("'", @"''");
            merge.PatientToMerge.Add(new MergePatientSequence(_Patient.Id));
            merge.StudyInstanceUID = _StudyInstanceUID;
            merge.Reason = dlgReason.Reason;
            merge.Operator = Environment.UserName != string.Empty ? Environment.UserName : Environment.MachineName;
            merge.Description = "Merge Study";

            Thread thread = new Thread(() =>
                {
                   try
                   {
                      status = _naction.SendNActionRequest<MergeStudy>(_scp, merge, NActionScu.MergeStudy,
                                                                   NActionScu.PatientUpdateInstance);
                   }
                   catch (Exception e)
                   {
                      ApplicationUtils.ShowException(this, e);
                      status = DicomCommandStatusType.Failure;
                   }
                });

            progress.ActionThread = thread;
            progress.Title = "Merging Study";
            progress.ProgressInfo = "Performing study merge to patient: " + textBoxFirstname.Text + " " + textBoxLastname.Text + ".";
            progress.ShowDialog(this);

            if (status == DicomCommandStatusType.Success)
            {
               _Action = ActionType.Merge;
               TaskDialogHelper.ShowMessageBox(this, "Study Merge", "The study has been successfully merged.", GetMergeInfo(),
                                               string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                               null);
               DialogResult = DialogResult.OK;
            }
            else
            {
               string message = "The study was not merged.\r\nError - " + _naction.GetErrorMessage();

               if (status == DicomCommandStatusType.MissingAttribute)
                  message = "The study was not merged.\r\nStudy not found on server.";

               TaskDialogHelper.ShowMessageBox(this, "Merge Study Error", "The study was not merged.", message,
                                           string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
            }
         }
      }

      private void MoveSeries()
      {
         ReasonDialog dlgReason = new ReasonDialog("Input Reason For Moving Series");

         if (dlgReason.ShowDialog(this) == DialogResult.OK)
         {
            MoveSeries move = new MoveSeries();
            DicomCommandStatusType status = DicomCommandStatusType.Success;
            ProgressDialog progress = new ProgressDialog();

            move.PatientId = textBoxId.Text.Replace(@"\", @"\\").Replace("'", @"''");
            move.PatientToMerge.Add(new MergePatientSequence(_Patient.Id));
            move.SeriesInstanceUID = _Series.InstanceUID;
            move.Reason = dlgReason.Reason;
            move.Operator = Environment.UserName != string.Empty ? Environment.UserName : Environment.MachineName;
            move.Description = "Move Series";

            Thread thread = new Thread(() =>
            {
               try
               {
                  status = _naction.SendNActionRequest<MoveSeries>(_scp, move, NActionScu.MoveSeries,
                                                           NActionScu.PatientUpdateInstance);
               }
               catch (Exception e)
               {
                  ApplicationUtils.ShowException(this, e);
                  status = DicomCommandStatusType.Failure;
               }
            });

            progress.ActionThread = thread;
            progress.Title = "Moving Series";
            progress.ProgressInfo = "Performing series move to patient: " + textBoxFirstname.Text + " " + textBoxLastname.Text + ".";
            progress.ShowDialog(this);

            if (status == DicomCommandStatusType.Success)
            {
               _Action = ActionType.Merge;
               TaskDialogHelper.ShowMessageBox(this, "Move Series", "The series has been successfully move.", GetMergeInfo(),
                                               string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                               null);
               DialogResult = DialogResult.OK;
            }
            else
            {
               string message = "The series was not move.\r\nError - " + _naction.GetErrorMessage();

               if (status == DicomCommandStatusType.MissingAttribute)
                  message = "The series was not move.\r\nSeries not found on server.";

               TaskDialogHelper.ShowMessageBox(this, "Move Series Error", "The series was not moved.", message,
                                           string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
            }
         }
      }

      private void MoveToNewPatient()
      {
         ReasonDialog dlgReason = new ReasonDialog("Input Reason For Moving Study To New Patient");

         if (dlgReason.ShowDialog(this) == DialogResult.OK)
         {
            MoveToNewPatient move = new MoveToNewPatient();
            DicomCommandStatusType status = DicomCommandStatusType.Success;
            ProgressDialog progress = new ProgressDialog();

            move.PatientId = textBoxId.Text.Replace(@"\", @"\\").Replace("'", @"''");

#if (LEADTOOLS_V19_OR_LATER)
            if (textBoxOtherPid.Text.Length > 0)
            {
               move.OtherPatientIds = new List<string>();
               string textBoxStringOtherPid = textBoxOtherPid.Text.Replace("'", @"''");

               if (!string.IsNullOrEmpty(textBoxStringOtherPid))
               {
                  char[] delimiterChars = { '\\' };
                  string[] otherPatientIds = textBoxStringOtherPid.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

                  foreach (string otherPatientId in otherPatientIds)
                  {
                     move.OtherPatientIds.Add(otherPatientId);
                  }
               }

            }
#endif

            move.Name.Given = textBoxFirstname.Text.Replace(@"\", @"\\").Replace("'", @"''");
            move.Name.Family = textBoxLastname.Text.Replace(@"\", @"\\").Replace("'", @"''");
            move.Sex = comboBoxSex.Text;
            move.PatientToMerge.Add(new MergePatientSequence(_Patient.Id));
            if (dateTimePickerBirth.Checked)
               move.Birthdate = dateTimePickerBirth.Value;
            else
               move.Birthdate = null;
            move.StudyInstanceUID = _StudyInstanceUID;
            move.Reason = dlgReason.Reason;
            move.Operator = Environment.UserName != string.Empty ? Environment.UserName : Environment.MachineName;
            move.Description = "Move Study To New Patient";

            Thread thread = new Thread(() =>
            {
               try
               {
                  status = _naction.SendNActionRequest<MoveToNewPatient>(_scp, move, NActionScu.MoveStudyToNewPatient,
                                                               NActionScu.PatientUpdateInstance);
               }
               catch (Exception e)
               {
                  ApplicationUtils.ShowException(this, e);
                  status = DicomCommandStatusType.Failure;
               }
            });

            progress.ActionThread = thread;
            progress.Title = "Moving Study To New Patient";
            progress.ProgressInfo = "Performing study move to patient: " + textBoxFirstname.Text + " " + textBoxLastname.Text + ".";
            progress.ShowDialog(this);

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
               _Action = ActionType.Move;
               TaskDialogHelper.ShowMessageBox(this, "Study Moved To New Patient", "The study has been successfully moved.", string.Empty,
                                               string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                               null);
               DialogResult = DialogResult.OK;
            }
            else
            {
               string message = "The series was not moved.\r\nError - " + _naction.GetErrorMessage();

               if (status == DicomCommandStatusType.MissingAttribute)
                  message = "The series was not moved.\r\nSeries not found on server.";

               TaskDialogHelper.ShowMessageBox(this, "Move Series Error", "The series was not moved.", message,
                                           string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
            }
         }
      }

      private void CopyStudy()
      {
         ReasonDialog dlgReason = new ReasonDialog("Input Reason For Copying Study");

         if (dlgReason.ShowDialog(this) == DialogResult.OK)
         {
            CopyStudy move = new CopyStudy();
            DicomCommandStatusType status = DicomCommandStatusType.Success;
            ProgressDialog progress = new ProgressDialog();

            move.PatientId = textBoxId.Text.Replace(@"\", @"\\").Replace("'", @"''");
            move.OtherPatientIDs = textBoxOtherPid.Text;
            move.Name.Given = textBoxFirstname.Text.Replace(@"\", @"\\").Replace("'", @"''");
            move.Name.Family = textBoxLastname.Text.Replace(@"\", @"\\").Replace("'", @"''");
            move.Sex = comboBoxSex.Text;
            move.PatientToMerge.Add(new MergePatientSequence(_Patient.Id));
            if (dateTimePickerBirth.Checked)
               move.Birthdate = dateTimePickerBirth.Value;
            else
               move.Birthdate = null;
            move.StudyInstanceUID = _StudyInstanceUID;
            move.Reason = dlgReason.Reason;
            move.Operator = Environment.UserName != string.Empty ? Environment.UserName : Environment.MachineName;
            move.Description = "Copy Study";

            Thread thread = new Thread(() =>
            {
               try
               {
                  status = _naction.SendNActionRequest<CopyStudy>(_scp, move, NActionScu.CopyStudy,
                                                               NActionScu.PatientUpdateInstance);
               }
               catch (Exception e)
               {
                  ApplicationUtils.ShowException(this, e);
                  status = DicomCommandStatusType.Failure;
               }
            });

            progress.ActionThread = thread;
            progress.Title = "Copying Study";
            progress.ProgressInfo = "Performing study copy: " + textBoxFirstname.Text + " " + textBoxLastname.Text + ".";
            progress.ShowDialog(this);

            if (status == DicomCommandStatusType.Success)
            {
               _Action = ActionType.CopyStudy;
               TaskDialogHelper.ShowMessageBox(this, "Study Copied", "The study has been successfully copied.", string.Empty,
                                               string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                               null);
               DialogResult = DialogResult.OK;
            }
            else
            {
               string message = "The series was not copied.\r\nError - " + _naction.GetErrorMessage();

               if (status == DicomCommandStatusType.MissingAttribute)
                  message = "The series was not copied.\r\nSeries not found on server.";

               TaskDialogHelper.ShowMessageBox(this, "Copy Series Error", "The series was not copied.", message,
                                           string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                           null);
            }
         }
      }

      private string GetMergeInfo()
      {
         string info = string.Empty;

         info = string.Format("The study has been moved to patient {0}({1})",
                              textBoxFirstname.Text + " " + textBoxLastname.Text, textBoxId.Text);
         return info;
      }

      private void SearchButton_Click(object sender, EventArgs e)
      {
         Patient patient = DicomUtils.FindPatient(this, _find, _scp, textBoxId.Text);

         if (!radioButtonMoveStudyToNewPatient.Checked)
         {
            if (patient != null)
            {
               textBoxLastname.Text = patient.Name.Family;
               textBoxFirstname.Text = patient.Name.Given;
               if (Program.OtherPID.ContainsKey(patient.Id))
               {
                  textBoxOtherPid.Text = Program.OtherPID[patient.Id];
               }
               else
               {
                  textBoxOtherPid.Text = string.Empty;
               }
               if (string.IsNullOrEmpty(patient.Sex))
                  comboBoxSex.Text = string.Empty;
               else
                  comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(patient.Sex);
               if (patient.BirthDate.HasValue)
               {
                  dateTimePickerBirth.Value = patient.BirthDate.Value;
                  dateTimePickerBirth.Checked = true;
               }
               else
                  dateTimePickerBirth.Checked = false;
            }
            else
            {
               TaskDialogHelper.ShowMessageBox(this, "Patient Search", "Patient with specified id was not found.", string.Empty,
                                              string.Empty, TaskDialogStandardButtons.Close, TaskDialogStandardIcon.Information,
                                              null);
            }
            ActionButton.Enabled = patient != null;
         }
         else
         {
            if (patient != null)
            {
               TaskDialogResult result = TaskDialogResult.Yes;

               result = TaskDialogHelper.ShowMessageBox(this, "Patient Id Already Exits", "Would you like to merge the study with existing patient?",
                                                        "The patient id already exisits.", "Existing Patient: " + patient.Name.Full,
                                                        TaskDialogStandardButtons.Yes | TaskDialogStandardButtons.No, TaskDialogStandardIcon.Error, TaskDialogStandardIcon.Warning);
               if (result == TaskDialogResult.Yes)
               {
                  radioButtonMoveStudyToExistingPatient.Checked = true;
                  textBoxLastname.Text = patient.Name.Family;
                  textBoxFirstname.Text = patient.Name.Given;
                  if (string.IsNullOrEmpty(patient.Sex))
                     comboBoxSex.Text = string.Empty;
                  else
                     comboBoxSex.SelectedIndex = comboBoxSex.FindStringExact(patient.Sex);
                  if (patient.BirthDate.HasValue)
                  {
                     dateTimePickerBirth.Value = patient.BirthDate.Value;
                     dateTimePickerBirth.Checked = true;
                  }
                  else
                     dateTimePickerBirth.Checked = false;
                  ActionButton.Enabled = true;
               }
               else
                  ActionButton.Enabled = false;
            }
            else
               ActionButton.Enabled = true;
         }

         CopyButton.Enabled = ActionButton.Enabled && !radioButtonMoveSeriesToExistingPatient.Checked;
      }

      private void textBoxId_TextChanged(object sender, EventArgs e)
      {
         if (radioButtonMoveStudyToExistingPatient.Checked || radioButtonMoveStudyToNewPatient.Checked | radioButtonMoveSeriesToExistingPatient.Checked)
         {
            SearchButton.Enabled = textBoxId.Text.Length > 0 && textBoxId.Text != _Patient.Id;
            ActionButton.Enabled = false;
         }
      }

      private void EditSeriesDialog_Shown(object sender, EventArgs e)
      {
         dateTimePickerSeriesDate.Focus();
      }

      private void comboBoxModality_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (Char.IsLetterOrDigit(e.KeyChar))
         {
            e.Handled = comboBoxModality.Text.Length == 16;
            if (!e.Handled)
            {
               e.KeyChar = char.ToUpper(e.KeyChar);
            }
         }
      }

      private void Uppercase_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (char.IsLetter(e.KeyChar))
            e.KeyChar = char.ToUpper(e.KeyChar);
      }

      private void textBoxId_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == '*')
            e.Handled = true;
      }

      private void CopyButton_Click(object sender, EventArgs e)
      {
         CopyStudy();
      }

      private void btnStudy_Click(object sender, EventArgs e)
      {
         ChangeStudy();
      }

      private void dateTimePickerSeriesTime_ValueChanged(object sender, EventArgs e)
      {
         if (dateTimePickerSeriesTime.Checked && !dateTimePickerSeriesDate.Checked)
            dateTimePickerSeriesDate.Checked = true;
      }

      private void dateTimePickerSeriesDate_ValueChanged(object sender, EventArgs e)
      {
         if (!dateTimePickerSeriesDate.Checked)
            dateTimePickerSeriesTime.Checked = false;
      }

   }
}
