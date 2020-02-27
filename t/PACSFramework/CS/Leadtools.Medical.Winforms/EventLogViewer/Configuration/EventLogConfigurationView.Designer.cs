using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leadtools.Medical.Winforms
{
   public partial class EventLogConfigurationView
   {
      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;
      
      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }
      
      private void InitializeComponent()
      {
         this.EnableLoggingCheckBox = new System.Windows.Forms.CheckBox();
         this.EventFilterGroupBox = new System.Windows.Forms.GroupBox();
         this.groupBoxDicom = new System.Windows.Forms.GroupBox();
         this.DicomMessagesCheckbox = new System.Windows.Forms.CheckBox();
         this.BrowseDataSetDirectoryButton = new System.Windows.Forms.Button();
         this.DataSetDirectoryTextBox = new System.Windows.Forms.TextBox();
         this.LogDSCheckBox = new System.Windows.Forms.CheckBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.AuditCheckBox = new System.Windows.Forms.CheckBox();
         this.ErrorCheckBox = new System.Windows.Forms.CheckBox();
         this.DebugCheckBox = new System.Windows.Forms.CheckBox();
         this.WarningsCheckBox = new System.Windows.Forms.CheckBox();
         this.InformationCheckBox = new System.Windows.Forms.CheckBox();
         this.AutoSaveLogGroupBox = new System.Windows.Forms.GroupBox();
         this.DeleteSavedLogCheckBox = new System.Windows.Forms.CheckBox();
         this.BrowseAutoSaveButton = new System.Windows.Forms.Button();
         this.AuoSaveDirectoryTextBox = new System.Windows.Forms.TextBox();
         this.AutoSaveTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.AutoSaveDaysNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         this.EnableAutoSaveLogCheckBox = new System.Windows.Forms.CheckBox();
         this.EnableThreadingCheckBox = new System.Windows.Forms.CheckBox();
         this.EventFilterGroupBox.SuspendLayout();
         this.groupBoxDicom.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this.AutoSaveLogGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.AutoSaveDaysNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // EnableLoggingCheckBox
         // 
         this.EnableLoggingCheckBox.AutoSize = true;
         this.EnableLoggingCheckBox.Location = new System.Drawing.Point(6, 3);
         this.EnableLoggingCheckBox.Name = "EnableLoggingCheckBox";
         this.EnableLoggingCheckBox.Size = new System.Drawing.Size(100, 17);
         this.EnableLoggingCheckBox.TabIndex = 0;
         this.EnableLoggingCheckBox.Text = "Enable Logging";
         this.EnableLoggingCheckBox.UseVisualStyleBackColor = true;
         // 
         // EventFilterGroupBox
         // 
         this.EventFilterGroupBox.Controls.Add(this.groupBoxDicom);
         this.EventFilterGroupBox.Controls.Add(this.groupBox2);
         this.EventFilterGroupBox.Location = new System.Drawing.Point(6, 26);
         this.EventFilterGroupBox.Name = "EventFilterGroupBox";
         this.EventFilterGroupBox.Size = new System.Drawing.Size(349, 205);
         this.EventFilterGroupBox.TabIndex = 2;
         this.EventFilterGroupBox.TabStop = false;
         this.EventFilterGroupBox.Text = "Filter";
         // 
         // groupBoxDicom
         // 
         this.groupBoxDicom.Controls.Add(this.DicomMessagesCheckbox);
         this.groupBoxDicom.Controls.Add(this.BrowseDataSetDirectoryButton);
         this.groupBoxDicom.Controls.Add(this.DataSetDirectoryTextBox);
         this.groupBoxDicom.Controls.Add(this.LogDSCheckBox);
         this.groupBoxDicom.Location = new System.Drawing.Point(6, 96);
         this.groupBoxDicom.Name = "groupBoxDicom";
         this.groupBoxDicom.Size = new System.Drawing.Size(337, 103);
         this.groupBoxDicom.TabIndex = 1;
         this.groupBoxDicom.TabStop = false;
         // 
         // DicomMessagesCheckbox
         // 
         this.DicomMessagesCheckbox.AutoSize = true;
         this.DicomMessagesCheckbox.Location = new System.Drawing.Point(10, -1);
         this.DicomMessagesCheckbox.Name = "DicomMessagesCheckbox";
         this.DicomMessagesCheckbox.Size = new System.Drawing.Size(112, 17);
         this.DicomMessagesCheckbox.TabIndex = 0;
         this.DicomMessagesCheckbox.Text = "DICOM Messages";
         this.DicomMessagesCheckbox.UseVisualStyleBackColor = true;
         // 
         // BrowseDataSetDirectoryButton
         // 
         this.BrowseDataSetDirectoryButton.Location = new System.Drawing.Point(29, 70);
         this.BrowseDataSetDirectoryButton.Name = "BrowseDataSetDirectoryButton";
         this.BrowseDataSetDirectoryButton.Size = new System.Drawing.Size(124, 23);
         this.BrowseDataSetDirectoryButton.TabIndex = 3;
         this.BrowseDataSetDirectoryButton.Text = "Browse Directory...";
         this.BrowseDataSetDirectoryButton.UseVisualStyleBackColor = true;
         // 
         // DataSetDirectoryTextBox
         // 
         this.DataSetDirectoryTextBox.Location = new System.Drawing.Point(30, 44);
         this.DataSetDirectoryTextBox.Name = "DataSetDirectoryTextBox";
         this.DataSetDirectoryTextBox.Size = new System.Drawing.Size(300, 20);
         this.DataSetDirectoryTextBox.TabIndex = 2;
         // 
         // LogDSCheckBox
         // 
         this.LogDSCheckBox.AutoSize = true;
         this.LogDSCheckBox.Location = new System.Drawing.Point(30, 23);
         this.LogDSCheckBox.Name = "LogDSCheckBox";
         this.LogDSCheckBox.Size = new System.Drawing.Size(124, 17);
         this.LogDSCheckBox.TabIndex = 1;
         this.LogDSCheckBox.Text = "Log DICOM DataSet";
         this.LogDSCheckBox.UseVisualStyleBackColor = true;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.AuditCheckBox);
         this.groupBox2.Controls.Add(this.ErrorCheckBox);
         this.groupBox2.Controls.Add(this.DebugCheckBox);
         this.groupBox2.Controls.Add(this.WarningsCheckBox);
         this.groupBox2.Controls.Add(this.InformationCheckBox);
         this.groupBox2.Location = new System.Drawing.Point(6, 19);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(337, 70);
         this.groupBox2.TabIndex = 0;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Type:";
         // 
         // AuditCheckBox
         // 
         this.AuditCheckBox.AutoSize = true;
         this.AuditCheckBox.Location = new System.Drawing.Point(201, 20);
         this.AuditCheckBox.Name = "AuditCheckBox";
         this.AuditCheckBox.Size = new System.Drawing.Size(50, 17);
         this.AuditCheckBox.TabIndex = 4;
         this.AuditCheckBox.Text = "Audit";
         this.AuditCheckBox.UseVisualStyleBackColor = true;
         // 
         // ErrorCheckBox
         // 
         this.ErrorCheckBox.AutoSize = true;
         this.ErrorCheckBox.Location = new System.Drawing.Point(128, 45);
         this.ErrorCheckBox.Name = "ErrorCheckBox";
         this.ErrorCheckBox.Size = new System.Drawing.Size(53, 17);
         this.ErrorCheckBox.TabIndex = 3;
         this.ErrorCheckBox.Text = "Errors";
         this.ErrorCheckBox.UseVisualStyleBackColor = true;
         // 
         // DebugCheckBox
         // 
         this.DebugCheckBox.AutoSize = true;
         this.DebugCheckBox.Location = new System.Drawing.Point(128, 20);
         this.DebugCheckBox.Name = "DebugCheckBox";
         this.DebugCheckBox.Size = new System.Drawing.Size(58, 17);
         this.DebugCheckBox.TabIndex = 2;
         this.DebugCheckBox.Text = "Debug";
         this.DebugCheckBox.UseVisualStyleBackColor = true;
         // 
         // WarningsCheckBox
         // 
         this.WarningsCheckBox.AutoSize = true;
         this.WarningsCheckBox.Location = new System.Drawing.Point(10, 45);
         this.WarningsCheckBox.Name = "WarningsCheckBox";
         this.WarningsCheckBox.Size = new System.Drawing.Size(71, 17);
         this.WarningsCheckBox.TabIndex = 1;
         this.WarningsCheckBox.Text = "Warnings";
         this.WarningsCheckBox.UseVisualStyleBackColor = true;
         // 
         // InformationCheckBox
         // 
         this.InformationCheckBox.AutoSize = true;
         this.InformationCheckBox.Location = new System.Drawing.Point(10, 20);
         this.InformationCheckBox.Name = "InformationCheckBox";
         this.InformationCheckBox.Size = new System.Drawing.Size(78, 17);
         this.InformationCheckBox.TabIndex = 0;
         this.InformationCheckBox.Text = "Information";
         this.InformationCheckBox.UseVisualStyleBackColor = true;
         // 
         // AutoSaveLogGroupBox
         // 
         this.AutoSaveLogGroupBox.Controls.Add(this.DeleteSavedLogCheckBox);
         this.AutoSaveLogGroupBox.Controls.Add(this.BrowseAutoSaveButton);
         this.AutoSaveLogGroupBox.Controls.Add(this.AuoSaveDirectoryTextBox);
         this.AutoSaveLogGroupBox.Controls.Add(this.AutoSaveTimeDateTimePicker);
         this.AutoSaveLogGroupBox.Controls.Add(this.label3);
         this.AutoSaveLogGroupBox.Controls.Add(this.label2);
         this.AutoSaveLogGroupBox.Controls.Add(this.AutoSaveDaysNumericUpDown);
         this.AutoSaveLogGroupBox.Controls.Add(this.label1);
         this.AutoSaveLogGroupBox.Location = new System.Drawing.Point(6, 237);
         this.AutoSaveLogGroupBox.Name = "AutoSaveLogGroupBox";
         this.AutoSaveLogGroupBox.Size = new System.Drawing.Size(349, 142);
         this.AutoSaveLogGroupBox.TabIndex = 4;
         this.AutoSaveLogGroupBox.TabStop = false;
         // 
         // DeleteSavedLogCheckBox
         // 
         this.DeleteSavedLogCheckBox.AutoSize = true;
         this.DeleteSavedLogCheckBox.Location = new System.Drawing.Point(136, 113);
         this.DeleteSavedLogCheckBox.Name = "DeleteSavedLogCheckBox";
         this.DeleteSavedLogCheckBox.Size = new System.Drawing.Size(106, 17);
         this.DeleteSavedLogCheckBox.TabIndex = 7;
         this.DeleteSavedLogCheckBox.Text = "Delete saved log";
         this.DeleteSavedLogCheckBox.UseVisualStyleBackColor = true;
         // 
         // BrowseAutoSaveButton
         // 
         this.BrowseAutoSaveButton.Location = new System.Drawing.Point(6, 109);
         this.BrowseAutoSaveButton.Name = "BrowseAutoSaveButton";
         this.BrowseAutoSaveButton.Size = new System.Drawing.Size(124, 23);
         this.BrowseAutoSaveButton.TabIndex = 6;
         this.BrowseAutoSaveButton.Text = "Browse Directory...";
         this.BrowseAutoSaveButton.UseVisualStyleBackColor = true;
         // 
         // AuoSaveDirectoryTextBox
         // 
         this.AuoSaveDirectoryTextBox.Location = new System.Drawing.Point(6, 83);
         this.AuoSaveDirectoryTextBox.Name = "AuoSaveDirectoryTextBox";
         this.AuoSaveDirectoryTextBox.Size = new System.Drawing.Size(337, 20);
         this.AuoSaveDirectoryTextBox.TabIndex = 5;
         // 
         // AutoSaveTimeDateTimePicker
         // 
         this.AutoSaveTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
         this.AutoSaveTimeDateTimePicker.Location = new System.Drawing.Point(49, 57);
         this.AutoSaveTimeDateTimePicker.Name = "AutoSaveTimeDateTimePicker";
         this.AutoSaveTimeDateTimePicker.ShowUpDown = true;
         this.AutoSaveTimeDateTimePicker.Size = new System.Drawing.Size(85, 20);
         this.AutoSaveTimeDateTimePicker.TabIndex = 4;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(8, 56);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(20, 13);
         this.label3.TabIndex = 3;
         this.label3.Text = "At:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(105, 32);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(35, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "day(s)";
         // 
         // AutoSaveDaysNumericUpDown
         // 
         this.AutoSaveDaysNumericUpDown.Location = new System.Drawing.Point(49, 30);
         this.AutoSaveDaysNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.AutoSaveDaysNumericUpDown.Name = "AutoSaveDaysNumericUpDown";
         this.AutoSaveDaysNumericUpDown.Size = new System.Drawing.Size(50, 20);
         this.AutoSaveDaysNumericUpDown.TabIndex = 1;
         this.AutoSaveDaysNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(8, 30);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(34, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Every";
         // 
         // EnableAutoSaveLogCheckBox
         // 
         this.EnableAutoSaveLogCheckBox.AutoSize = true;
         this.EnableAutoSaveLogCheckBox.Location = new System.Drawing.Point(12, 234);
         this.EnableAutoSaveLogCheckBox.Name = "EnableAutoSaveLogCheckBox";
         this.EnableAutoSaveLogCheckBox.Size = new System.Drawing.Size(133, 17);
         this.EnableAutoSaveLogCheckBox.TabIndex = 3;
         this.EnableAutoSaveLogCheckBox.Text = "Enable Auto Save Log";
         this.EnableAutoSaveLogCheckBox.UseVisualStyleBackColor = true;
         // 
         // EnableThreadingCheckBox
         // 
         this.EnableThreadingCheckBox.AutoSize = true;
         this.EnableThreadingCheckBox.Location = new System.Drawing.Point(245, 3);
         this.EnableThreadingCheckBox.Name = "EnableThreadingCheckBox";
         this.EnableThreadingCheckBox.Size = new System.Drawing.Size(110, 17);
         this.EnableThreadingCheckBox.TabIndex = 1;
         this.EnableThreadingCheckBox.Text = "Enable Threading";
         this.EnableThreadingCheckBox.UseVisualStyleBackColor = true;
         // 
         // EventLogConfigurationView
         // 
         this.Controls.Add(this.EnableThreadingCheckBox);
         this.Controls.Add(this.EnableAutoSaveLogCheckBox);
         this.Controls.Add(this.AutoSaveLogGroupBox);
         this.Controls.Add(this.EnableLoggingCheckBox);
         this.Controls.Add(this.EventFilterGroupBox);
         this.Name = "EventLogConfigurationView";
         this.Size = new System.Drawing.Size(361, 399);
         this.VisibleChanged += new System.EventHandler(this.EventLogConfigurationView_VisibleChanged);
         this.EventFilterGroupBox.ResumeLayout(false);
         this.groupBoxDicom.ResumeLayout(false);
         this.groupBoxDicom.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.AutoSaveLogGroupBox.ResumeLayout(false);
         this.AutoSaveLogGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.AutoSaveDaysNumericUpDown)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      private System.Windows.Forms.CheckBox EnableLoggingCheckBox;
      private System.Windows.Forms.GroupBox EventFilterGroupBox;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.CheckBox ErrorCheckBox;
      private System.Windows.Forms.CheckBox DebugCheckBox;
      private System.Windows.Forms.CheckBox WarningsCheckBox;
      private System.Windows.Forms.CheckBox InformationCheckBox;
      private System.Windows.Forms.GroupBox AutoSaveLogGroupBox;
      private System.Windows.Forms.NumericUpDown AutoSaveDaysNumericUpDown;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.DateTimePicker AutoSaveTimeDateTimePicker;
      private System.Windows.Forms.Button BrowseAutoSaveButton;
      private System.Windows.Forms.TextBox AuoSaveDirectoryTextBox;
      private System.Windows.Forms.CheckBox DeleteSavedLogCheckBox;
      private System.Windows.Forms.CheckBox EnableAutoSaveLogCheckBox;
      private System.Windows.Forms.CheckBox AuditCheckBox;
      private System.Windows.Forms.CheckBox EnableThreadingCheckBox;
      private System.Windows.Forms.GroupBox groupBoxDicom;
      private System.Windows.Forms.Button BrowseDataSetDirectoryButton;
      private System.Windows.Forms.TextBox DataSetDirectoryTextBox;
      private System.Windows.Forms.CheckBox LogDSCheckBox;
      private System.Windows.Forms.CheckBox DicomMessagesCheckbox;
   }
}
