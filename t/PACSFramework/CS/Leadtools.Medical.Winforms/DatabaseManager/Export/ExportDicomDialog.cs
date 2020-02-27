// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Leadtools.Medical.OptionsDataAccessLayer;
using Leadtools.Medical.Winforms.Anonymize;
using Leadtools.Medical.Winforms.DatabaseManager.Export;

namespace Leadtools.Medical.Winforms.DatabaseManager
{
   public partial class ExportDicomDialog : Form
   {
      public ExportDicomDialog()
      {
         InitializeComponent();
      }

      public MessageBoxIcon ExportDialogIcon
      {
         set
         {
            switch(value)
            {
               case MessageBoxIcon.None:
                  break;

               case MessageBoxIcon.Information:
                  _pictureBoxIcon.Image = SystemIcons.Information.ToBitmap();
                  break;

               case MessageBoxIcon.Exclamation:
                  _pictureBoxIcon.Image = SystemIcons.Exclamation.ToBitmap();
                  break;
            }
         }
      }

      public event EventHandler<SaveAnonymizeSettingsEventArgs> SaveAnonymizeSettings;

      public bool CanChangeSettings { get; set;}

      private AnonymizeScripts _scripts = null;
      public AnonymizeScripts Scripts
      {
         get { return _scripts; }
         set { _scripts = value; }
      }

      private bool _scriptsChanged = false;
      public bool ScriptsChanged
      {
         get
         {
            return _scriptsChanged;
         }
         set
         {
            _scriptsChanged = value;
         }
      }

      public string ExportFolder
      {
         get { return textBoxExportFolder.Text; }
         set { textBoxExportFolder.Text = value; }
      }

      public bool Overwrite
      {
         get { return checkBoxOverwrite.Checked; }
         set { checkBoxOverwrite.Checked = value; }
      }

      public bool Anonymize
      {
         get { return checkBoxAnonymize.Checked; }
         set { checkBoxAnonymize.Checked = value; }
      }

      public bool CreateDicomDir
      {
         get { return checkBoxCreateDicomDir.Checked; }
         set { checkBoxCreateDicomDir.Checked = value; }
      }

      public string Message
      {
         get { return labelMessage.Text; }
         set { labelMessage.Text = value; }
      }

      private void buttonBrowse_Click(object sender, EventArgs e)
      {
         FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog {SelectedPath = ExportFolder};

         if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
         {
            ExportFolder = folderBrowserDialog.SelectedPath;
         }
      }

      private void ClearWarnings()
      {
         pictureBoxWarning.Image = null;
         labelWarnings.Text = string.Empty;
      }

      private bool ExistsWarnings()
      {
         return !string.IsNullOrEmpty(labelWarnings.Text);
      }

      private void UpdateWarningsIcon()
      {
         pictureBoxWarning.Image = ExistsWarnings() ? SystemIcons.Exclamation.ToBitmap() : null;
      }

      private void UpdateWarnings()
      {
         ClearWarnings();
         bool exists = Directory.Exists(ExportFolder);
         bool isEmpty = !exists;

         if (exists)
         {
#if FOR_DOTNET4
            isEmpty = !Directory.EnumerateFileSystemEntries(ExportFolder).Any();
#else
            string[] files = Directory.GetFiles(ExportFolder);
            isEmpty = (files.Length == 0);
#endif  // #if FOR_DOTNET4

            if (!isEmpty)
            {
               labelWarnings.Text = string.Format("'Export Folder Location' is not empty.");
            }
         }
         else
         {
            labelWarnings.Text = string.Format("'Export Folder Location' does not exist.");
         }
         UpdateWarningsIcon();
      }

      private void UpdateAnonymize()
      {
          comboBoxAnonymizeScripts.Enabled = checkBoxAnonymize.Checked;
          buttonAnonymizeOptions.Enabled = checkBoxAnonymize.Checked && CanChangeSettings;
      }

      private void UpdateUI()
      {
         UpdateWarnings();
         UpdateAnonymize();
      }

      private void UpdateAnonymizeScripts()
      {
         comboBoxAnonymizeScripts.Items.Clear();
         foreach (AnonymizeScript script in _scripts.Scripts)
         {
            comboBoxAnonymizeScripts.Items.Add(script);
         }

         comboBoxAnonymizeScripts.SelectedIndex = comboBoxAnonymizeScripts.FindString(_scripts.ActiveScriptName);
      }

      private void ExportDicomDialog_Load(object sender, EventArgs e)
      {
         UpdateWarnings();
         UpdateAnonymize();
         UpdateAnonymizeScripts();
      }

      private void textBoxExportFolder_TextChanged(object sender, EventArgs e)
      {
         UpdateWarnings();
      }

      private void checkBoxAnonymize_CheckedChanged(object sender, EventArgs e)
      {
         UpdateAnonymize();
      }

      private AnonymizeOptionsDialog _anonymizeOptionsDialog = new AnonymizeOptionsDialog();

      private void buttonAnonymizeOptions_Click(object sender, EventArgs e)
      {
         using (AnonymizeOptionsDialog dlg = new AnonymizeOptionsDialog())
         {
            // AnonymizeOptionsPresenter presenter = new AnonymizeOptionsPresenter();
            using (AnonymizeOptionsView view = new AnonymizeOptionsView())
            {
               view.SaveAnonymizeSettings += view_SaveAnonymizeSettings;
               dlg.Controls["panelAnonymizeOptions"].Controls.Add(view);
               // dlg.Controls.Add(view);
               view.Dock = DockStyle.Fill;
               // presenter.RunView(view);
               view.AnonymizeScripts = _scripts;

               if (DialogResult.OK == dlg.ShowDialog())
               {
                  if (view.IsDirty)
                  {
                     if (SaveAnonymizeSettings != null)
                     {
                        SaveAnonymizeSettingsEventArgs args = new SaveAnonymizeSettingsEventArgs(_scripts);
                        SaveAnonymizeSettings(sender, args);
                     }
                  }
                  if (view.ScriptsModified)
                  {
                     UpdateAnonymizeScripts();
                  }
               }

               view.SaveAnonymizeSettings -= view_SaveAnonymizeSettings;
            }


         }
      }

      void view_SaveAnonymizeSettings(object sender, SaveAnonymizeSettingsEventArgs e)
      {
         ScriptsChanged = true;
         {
            if (SaveAnonymizeSettings != null)
            {
               SaveAnonymizeSettings(sender, e);
            }
         }
      }
   }
}
