namespace Leadtools.Medical.Winforms
{
   partial class PatientUpdaterConfigurationView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.tabControlAutoUpdate = new System.Windows.Forms.TabControl();
         this.tabPageAutoUpdateOptions = new System.Windows.Forms.TabPage();
         this.listViewAutoUpdate = new System.Windows.Forms.ListView();
         this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.comboBoxSource = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.tabPageRetry = new System.Windows.Forms.TabPage();
         this.buttonFolder = new System.Windows.Forms.Button();
         this.textBoxDir = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.numericUpDownDays = new System.Windows.Forms.NumericUpDown();
         this.label6 = new System.Windows.Forms.Label();
         this.numericUpDownsSecs = new System.Windows.Forms.NumericUpDown();
         this.label5 = new System.Windows.Forms.Label();
         this.checkBoxRetry = new System.Windows.Forms.CheckBox();
         this.tabPageAutoUpdateMessages = new System.Windows.Forms.TabPage();
         this.listViewPatientUpdaterMessages = new System.Windows.Forms.ListView();
         this.columnHeaderPatientUpdaterMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.labelMessages = new System.Windows.Forms.Label();
         this.tabPageAutoUpdateAdvanced = new System.Windows.Forms.TabPage();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.numericUpDownThreads = new System.Windows.Forms.NumericUpDown();
         this.label4 = new System.Windows.Forms.Label();
         this.textBoxCustomAE = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.checkBoxCustomAE = new System.Windows.Forms.CheckBox();
         this.checkBoxAutoUpdate = new System.Windows.Forms.CheckBox();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.checkBoxReason = new System.Windows.Forms.CheckBox();
         this.checkBoxDescription = new System.Windows.Forms.CheckBox();
         this.checkBoxTime = new System.Windows.Forms.CheckBox();
         this.checkBoxDate = new System.Windows.Forms.CheckBox();
         this.checkBoxTransaction = new System.Windows.Forms.CheckBox();
         this.checkBoxOperator = new System.Windows.Forms.CheckBox();
         this.checkBoxStation = new System.Windows.Forms.CheckBox();
         this.groupBox2.SuspendLayout();
         this.tabControlAutoUpdate.SuspendLayout();
         this.tabPageAutoUpdateOptions.SuspendLayout();
         this.tabPageRetry.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownsSecs)).BeginInit();
         this.tabPageAutoUpdateMessages.SuspendLayout();
         this.tabPageAutoUpdateAdvanced.SuspendLayout();
         this.groupBox3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).BeginInit();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox2
         // 
         this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox2.Controls.Add(this.tabControlAutoUpdate);
         this.groupBox2.Controls.Add(this.checkBoxAutoUpdate);
         this.groupBox2.Location = new System.Drawing.Point(3, 112);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(485, 380);
         this.groupBox2.TabIndex = 3;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Auto Update";
         // 
         // tabControlAutoUpdate
         // 
         this.tabControlAutoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tabControlAutoUpdate.Controls.Add(this.tabPageAutoUpdateOptions);
         this.tabControlAutoUpdate.Controls.Add(this.tabPageRetry);
         this.tabControlAutoUpdate.Controls.Add(this.tabPageAutoUpdateMessages);
         this.tabControlAutoUpdate.Controls.Add(this.tabPageAutoUpdateAdvanced);
         this.tabControlAutoUpdate.Location = new System.Drawing.Point(30, 43);
         this.tabControlAutoUpdate.Name = "tabControlAutoUpdate";
         this.tabControlAutoUpdate.SelectedIndex = 0;
         this.tabControlAutoUpdate.Size = new System.Drawing.Size(449, 331);
         this.tabControlAutoUpdate.TabIndex = 1;
         // 
         // tabPageAutoUpdateOptions
         // 
         this.tabPageAutoUpdateOptions.Controls.Add(this.listViewAutoUpdate);
         this.tabPageAutoUpdateOptions.Controls.Add(this.comboBoxSource);
         this.tabPageAutoUpdateOptions.Controls.Add(this.label2);
         this.tabPageAutoUpdateOptions.Controls.Add(this.label1);
         this.tabPageAutoUpdateOptions.Location = new System.Drawing.Point(4, 22);
         this.tabPageAutoUpdateOptions.Name = "tabPageAutoUpdateOptions";
         this.tabPageAutoUpdateOptions.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageAutoUpdateOptions.Size = new System.Drawing.Size(441, 305);
         this.tabPageAutoUpdateOptions.TabIndex = 0;
         this.tabPageAutoUpdateOptions.Text = "AE Relations";
         this.tabPageAutoUpdateOptions.UseVisualStyleBackColor = true;
         // 
         // listViewAutoUpdate
         // 
         this.listViewAutoUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewAutoUpdate.CheckBoxes = true;
         this.listViewAutoUpdate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
         this.listViewAutoUpdate.Enabled = false;
         this.listViewAutoUpdate.Location = new System.Drawing.Point(7, 61);
         this.listViewAutoUpdate.Name = "listViewAutoUpdate";
         this.listViewAutoUpdate.Size = new System.Drawing.Size(412, 238);
         this.listViewAutoUpdate.TabIndex = 4;
         this.listViewAutoUpdate.UseCompatibleStateImageBehavior = false;
         this.listViewAutoUpdate.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "AE Title";
         this.columnHeader1.Width = 100;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "IP Address";
         this.columnHeader2.Width = 100;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Port";
         this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // comboBoxSource
         // 
         this.comboBoxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxSource.FormattingEnabled = true;
         this.comboBoxSource.Location = new System.Drawing.Point(7, 20);
         this.comboBoxSource.Name = "comboBoxSource";
         this.comboBoxSource.Size = new System.Drawing.Size(412, 21);
         this.comboBoxSource.TabIndex = 2;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(4, 44);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(127, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "AE Titles to Auto Update:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(4, 3);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(100, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "AE Title of Updater:";
         // 
         // tabPageRetry
         // 
         this.tabPageRetry.Controls.Add(this.buttonFolder);
         this.tabPageRetry.Controls.Add(this.textBoxDir);
         this.tabPageRetry.Controls.Add(this.label7);
         this.tabPageRetry.Controls.Add(this.numericUpDownDays);
         this.tabPageRetry.Controls.Add(this.label6);
         this.tabPageRetry.Controls.Add(this.numericUpDownsSecs);
         this.tabPageRetry.Controls.Add(this.label5);
         this.tabPageRetry.Controls.Add(this.checkBoxRetry);
         this.tabPageRetry.Location = new System.Drawing.Point(4, 22);
         this.tabPageRetry.Name = "tabPageRetry";
         this.tabPageRetry.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageRetry.Size = new System.Drawing.Size(441, 305);
         this.tabPageRetry.TabIndex = 2;
         this.tabPageRetry.Text = "Retry";
         this.tabPageRetry.UseVisualStyleBackColor = true;
         // 
         // buttonFolder
         // 
         this.buttonFolder.Image = global::Leadtools.Medical.Winforms.Properties.Resources.folder;
         this.buttonFolder.Location = new System.Drawing.Point(348, 71);
         this.buttonFolder.Name = "buttonFolder";
         this.buttonFolder.Size = new System.Drawing.Size(27, 23);
         this.buttonFolder.TabIndex = 7;
         this.buttonFolder.UseVisualStyleBackColor = true;
         // 
         // textBoxDir
         // 
         this.textBoxDir.Location = new System.Drawing.Point(130, 73);
         this.textBoxDir.Name = "textBoxDir";
         this.textBoxDir.ReadOnly = true;
         this.textBoxDir.Size = new System.Drawing.Size(218, 20);
         this.textBoxDir.TabIndex = 6;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(28, 80);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(51, 13);
         this.label7.TabIndex = 5;
         this.label7.Text = "Retry Dir:";
         // 
         // numericUpDownDays
         // 
         this.numericUpDownDays.Location = new System.Drawing.Point(130, 47);
         this.numericUpDownDays.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
         this.numericUpDownDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownDays.Name = "numericUpDownDays";
         this.numericUpDownDays.Size = new System.Drawing.Size(120, 20);
         this.numericUpDownDays.TabIndex = 4;
         this.numericUpDownDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(28, 54);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(87, 13);
         this.label6.TabIndex = 3;
         this.label6.Text = "Expiration (days):";
         // 
         // numericUpDownsSecs
         // 
         this.numericUpDownsSecs.Location = new System.Drawing.Point(130, 24);
         this.numericUpDownsSecs.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
         this.numericUpDownsSecs.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
         this.numericUpDownsSecs.Name = "numericUpDownsSecs";
         this.numericUpDownsSecs.Size = new System.Drawing.Size(120, 20);
         this.numericUpDownsSecs.TabIndex = 2;
         this.numericUpDownsSecs.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(28, 31);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(66, 13);
         this.label5.TabIndex = 1;
         this.label5.Text = "Retry (secs):";
         // 
         // checkBoxRetry
         // 
         this.checkBoxRetry.AutoSize = true;
         this.checkBoxRetry.Location = new System.Drawing.Point(7, 7);
         this.checkBoxRetry.Name = "checkBoxRetry";
         this.checkBoxRetry.Size = new System.Drawing.Size(87, 17);
         this.checkBoxRetry.TabIndex = 0;
         this.checkBoxRetry.Text = "Enable Retry";
         this.checkBoxRetry.UseVisualStyleBackColor = true;
         // 
         // tabPageAutoUpdateMessages
         // 
         this.tabPageAutoUpdateMessages.Controls.Add(this.listViewPatientUpdaterMessages);
         this.tabPageAutoUpdateMessages.Controls.Add(this.labelMessages);
         this.tabPageAutoUpdateMessages.Location = new System.Drawing.Point(4, 22);
         this.tabPageAutoUpdateMessages.Name = "tabPageAutoUpdateMessages";
         this.tabPageAutoUpdateMessages.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageAutoUpdateMessages.Size = new System.Drawing.Size(441, 305);
         this.tabPageAutoUpdateMessages.TabIndex = 3;
         this.tabPageAutoUpdateMessages.Text = "Messages";
         this.tabPageAutoUpdateMessages.UseVisualStyleBackColor = true;
         // 
         // listViewPatientUpdaterMessages
         // 
         this.listViewPatientUpdaterMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewPatientUpdaterMessages.CheckBoxes = true;
         this.listViewPatientUpdaterMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderPatientUpdaterMessage});
         this.listViewPatientUpdaterMessages.Location = new System.Drawing.Point(6, 33);
         this.listViewPatientUpdaterMessages.Name = "listViewPatientUpdaterMessages";
         this.listViewPatientUpdaterMessages.Size = new System.Drawing.Size(429, 266);
         this.listViewPatientUpdaterMessages.TabIndex = 1;
         this.listViewPatientUpdaterMessages.UseCompatibleStateImageBehavior = false;
         this.listViewPatientUpdaterMessages.View = System.Windows.Forms.View.Details;
         // 
         // columnHeaderPatientUpdaterMessage
         // 
         this.columnHeaderPatientUpdaterMessage.Text = "Message";
         this.columnHeaderPatientUpdaterMessage.Width = 173;
         // 
         // labelMessages
         // 
         this.labelMessages.AutoSize = true;
         this.labelMessages.Location = new System.Drawing.Point(6, 12);
         this.labelMessages.Name = "labelMessages";
         this.labelMessages.Size = new System.Drawing.Size(133, 13);
         this.labelMessages.TabIndex = 0;
         this.labelMessages.Text = "Messages to Auto Update ";
         // 
         // tabPageAutoUpdateAdvanced
         // 
         this.tabPageAutoUpdateAdvanced.Controls.Add(this.groupBox3);
         this.tabPageAutoUpdateAdvanced.Controls.Add(this.textBoxCustomAE);
         this.tabPageAutoUpdateAdvanced.Controls.Add(this.label3);
         this.tabPageAutoUpdateAdvanced.Controls.Add(this.checkBoxCustomAE);
         this.tabPageAutoUpdateAdvanced.Location = new System.Drawing.Point(4, 22);
         this.tabPageAutoUpdateAdvanced.Name = "tabPageAutoUpdateAdvanced";
         this.tabPageAutoUpdateAdvanced.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageAutoUpdateAdvanced.Size = new System.Drawing.Size(441, 305);
         this.tabPageAutoUpdateAdvanced.TabIndex = 1;
         this.tabPageAutoUpdateAdvanced.Text = "Advanced";
         this.tabPageAutoUpdateAdvanced.UseVisualStyleBackColor = true;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.numericUpDownThreads);
         this.groupBox3.Controls.Add(this.label4);
         this.groupBox3.Location = new System.Drawing.Point(7, 61);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(222, 65);
         this.groupBox3.TabIndex = 3;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Auto Update Processing Threads";
         // 
         // numericUpDownThreads
         // 
         this.numericUpDownThreads.Location = new System.Drawing.Point(59, 27);
         this.numericUpDownThreads.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
         this.numericUpDownThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownThreads.Name = "numericUpDownThreads";
         this.numericUpDownThreads.Size = new System.Drawing.Size(120, 20);
         this.numericUpDownThreads.TabIndex = 1;
         this.numericUpDownThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(6, 31);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(47, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Number:";
         // 
         // textBoxCustomAE
         // 
         this.textBoxCustomAE.Location = new System.Drawing.Point(98, 24);
         this.textBoxCustomAE.Name = "textBoxCustomAE";
         this.textBoxCustomAE.Size = new System.Drawing.Size(131, 20);
         this.textBoxCustomAE.TabIndex = 2;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(30, 31);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(62, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "Custom AE:";
         // 
         // checkBoxCustomAE
         // 
         this.checkBoxCustomAE.AutoSize = true;
         this.checkBoxCustomAE.Location = new System.Drawing.Point(7, 7);
         this.checkBoxCustomAE.Name = "checkBoxCustomAE";
         this.checkBoxCustomAE.Size = new System.Drawing.Size(123, 17);
         this.checkBoxCustomAE.TabIndex = 0;
         this.checkBoxCustomAE.Text = "Use Custom AE Title";
         this.checkBoxCustomAE.UseVisualStyleBackColor = true;
         // 
         // checkBoxAutoUpdate
         // 
         this.checkBoxAutoUpdate.AutoSize = true;
         this.checkBoxAutoUpdate.Location = new System.Drawing.Point(7, 20);
         this.checkBoxAutoUpdate.Name = "checkBoxAutoUpdate";
         this.checkBoxAutoUpdate.Size = new System.Drawing.Size(59, 17);
         this.checkBoxAutoUpdate.TabIndex = 0;
         this.checkBoxAutoUpdate.Text = "Enable";
         this.checkBoxAutoUpdate.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.checkBoxReason);
         this.groupBox1.Controls.Add(this.checkBoxDescription);
         this.groupBox1.Controls.Add(this.checkBoxTime);
         this.groupBox1.Controls.Add(this.checkBoxDate);
         this.groupBox1.Controls.Add(this.checkBoxTransaction);
         this.groupBox1.Controls.Add(this.checkBoxOperator);
         this.groupBox1.Controls.Add(this.checkBoxStation);
         this.groupBox1.Location = new System.Drawing.Point(3, 5);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(485, 100);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Request Dataset Validation";
         // 
         // checkBoxReason
         // 
         this.checkBoxReason.AutoSize = true;
         this.checkBoxReason.Location = new System.Drawing.Point(338, 19);
         this.checkBoxReason.Name = "checkBoxReason";
         this.checkBoxReason.Size = new System.Drawing.Size(103, 17);
         this.checkBoxReason.TabIndex = 6;
         this.checkBoxReason.Text = "Require Reason";
         this.checkBoxReason.UseVisualStyleBackColor = true;
         // 
         // checkBoxDescription
         // 
         this.checkBoxDescription.AutoSize = true;
         this.checkBoxDescription.Location = new System.Drawing.Point(165, 65);
         this.checkBoxDescription.Name = "checkBoxDescription";
         this.checkBoxDescription.Size = new System.Drawing.Size(119, 17);
         this.checkBoxDescription.TabIndex = 5;
         this.checkBoxDescription.Text = "Require Description";
         this.checkBoxDescription.UseVisualStyleBackColor = true;
         // 
         // checkBoxTime
         // 
         this.checkBoxTime.AutoSize = true;
         this.checkBoxTime.Location = new System.Drawing.Point(165, 42);
         this.checkBoxTime.Name = "checkBoxTime";
         this.checkBoxTime.Size = new System.Drawing.Size(148, 17);
         this.checkBoxTime.TabIndex = 4;
         this.checkBoxTime.Text = "Require Transaction Time";
         this.checkBoxTime.UseVisualStyleBackColor = true;
         // 
         // checkBoxDate
         // 
         this.checkBoxDate.AutoSize = true;
         this.checkBoxDate.Location = new System.Drawing.Point(165, 19);
         this.checkBoxDate.Name = "checkBoxDate";
         this.checkBoxDate.Size = new System.Drawing.Size(148, 17);
         this.checkBoxDate.TabIndex = 3;
         this.checkBoxDate.Text = "Require Transaction Date";
         this.checkBoxDate.UseVisualStyleBackColor = true;
         // 
         // checkBoxTransaction
         // 
         this.checkBoxTransaction.AutoSize = true;
         this.checkBoxTransaction.Location = new System.Drawing.Point(7, 68);
         this.checkBoxTransaction.Name = "checkBoxTransaction";
         this.checkBoxTransaction.Size = new System.Drawing.Size(144, 17);
         this.checkBoxTransaction.TabIndex = 2;
         this.checkBoxTransaction.Text = "Require Transaction UID";
         this.checkBoxTransaction.UseVisualStyleBackColor = true;
         // 
         // checkBoxOperator
         // 
         this.checkBoxOperator.AutoSize = true;
         this.checkBoxOperator.Location = new System.Drawing.Point(7, 44);
         this.checkBoxOperator.Name = "checkBoxOperator";
         this.checkBoxOperator.Size = new System.Drawing.Size(145, 17);
         this.checkBoxOperator.TabIndex = 1;
         this.checkBoxOperator.Text = "Require Operator\'s Name";
         this.checkBoxOperator.UseVisualStyleBackColor = true;
         // 
         // checkBoxStation
         // 
         this.checkBoxStation.AutoSize = true;
         this.checkBoxStation.Location = new System.Drawing.Point(7, 20);
         this.checkBoxStation.Name = "checkBoxStation";
         this.checkBoxStation.Size = new System.Drawing.Size(130, 17);
         this.checkBoxStation.TabIndex = 0;
         this.checkBoxStation.Text = "Require Station Name";
         this.checkBoxStation.UseVisualStyleBackColor = true;
         // 
         // PatientUpdaterConfigurationView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Name = "PatientUpdaterConfigurationView";
         this.Size = new System.Drawing.Size(494, 495);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.tabControlAutoUpdate.ResumeLayout(false);
         this.tabPageAutoUpdateOptions.ResumeLayout(false);
         this.tabPageAutoUpdateOptions.PerformLayout();
         this.tabPageRetry.ResumeLayout(false);
         this.tabPageRetry.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDays)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownsSecs)).EndInit();
         this.tabPageAutoUpdateMessages.ResumeLayout(false);
         this.tabPageAutoUpdateMessages.PerformLayout();
         this.tabPageAutoUpdateAdvanced.ResumeLayout(false);
         this.tabPageAutoUpdateAdvanced.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TabControl tabControlAutoUpdate;
      private System.Windows.Forms.TabPage tabPageAutoUpdateOptions;
      private System.Windows.Forms.ListView listViewAutoUpdate;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.ComboBox comboBoxSource;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TabPage tabPageRetry;
      private System.Windows.Forms.Button buttonFolder;
      private System.Windows.Forms.TextBox textBoxDir;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.NumericUpDown numericUpDownDays;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.NumericUpDown numericUpDownsSecs;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.CheckBox checkBoxRetry;
      private System.Windows.Forms.TabPage tabPageAutoUpdateAdvanced;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.NumericUpDown numericUpDownThreads;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox textBoxCustomAE;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.CheckBox checkBoxCustomAE;
      private System.Windows.Forms.CheckBox checkBoxAutoUpdate;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckBox checkBoxReason;
      private System.Windows.Forms.CheckBox checkBoxDescription;
      private System.Windows.Forms.CheckBox checkBoxTime;
      private System.Windows.Forms.CheckBox checkBoxDate;
      private System.Windows.Forms.CheckBox checkBoxTransaction;
      private System.Windows.Forms.CheckBox checkBoxOperator;
      private System.Windows.Forms.CheckBox checkBoxStation;
      private System.Windows.Forms.TabPage tabPageAutoUpdateMessages;
      private System.Windows.Forms.ListView listViewPatientUpdaterMessages;
      private System.Windows.Forms.Label labelMessages;
      private System.Windows.Forms.ColumnHeader columnHeaderPatientUpdaterMessage;
   }
}
