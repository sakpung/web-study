namespace Leadtools.Demos.StorageServer.UI
{
   partial class GeneralSettingsView
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralSettingsView));
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.IpTypePanel = new System.Windows.Forms.Panel();
         this.IpBothCheckBox = new System.Windows.Forms.RadioButton();
         this.IpV6CheckBox = new System.Windows.Forms.RadioButton();
         this.IpV4CheckBox = new System.Windows.Forms.RadioButton();
         this.label14 = new System.Windows.Forms.Label();
         this.ImplementationVersionTextBox = new System.Windows.Forms.TextBox();
         this.label13 = new System.Windows.Forms.Label();
         this.ImplementationClassTextBox = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.AeTitleTextBox = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.PortNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.IpAddressComboBox = new System.Windows.Forms.ComboBox();
         this.label3 = new System.Windows.Forms.Label();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.StartModeComboBox = new System.Windows.Forms.ComboBox();
         this.label7 = new System.Windows.Forms.Label();
         this.ServiceDescriptionTextBox = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.ServiceDisplayNameTextBox = new System.Windows.Forms.TextBox();
         this.TestServiceButton = new System.Windows.Forms.Button();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.AddServerToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.DeleteServerToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.AETitleErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.GarbageCollectServiceButton = new System.Windows.Forms.Button();
         this.groupBoxDiagnostics = new System.Windows.Forms.GroupBox();
         this.ForceTerminationsServiceButton = new System.Windows.Forms.Button();
         this.groupBox3.SuspendLayout();
         this.IpTypePanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.PortNumericUpDown)).BeginInit();
         this.groupBox2.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.AETitleErrorProvider)).BeginInit();
         this.groupBoxDiagnostics.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.IpTypePanel);
         this.groupBox3.Controls.Add(this.label14);
         this.groupBox3.Controls.Add(this.ImplementationVersionTextBox);
         this.groupBox3.Controls.Add(this.label13);
         this.groupBox3.Controls.Add(this.ImplementationClassTextBox);
         this.groupBox3.Controls.Add(this.label1);
         this.groupBox3.Controls.Add(this.AeTitleTextBox);
         this.groupBox3.Controls.Add(this.label2);
         this.groupBox3.Controls.Add(this.PortNumericUpDown);
         this.groupBox3.Controls.Add(this.IpAddressComboBox);
         this.groupBox3.Controls.Add(this.label3);
         this.groupBox3.Location = new System.Drawing.Point(3, 46);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(319, 226);
         this.groupBox3.TabIndex = 28;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "DICOM Server:";
         // 
         // IpTypePanel
         // 
         this.IpTypePanel.Controls.Add(this.IpBothCheckBox);
         this.IpTypePanel.Controls.Add(this.IpV6CheckBox);
         this.IpTypePanel.Controls.Add(this.IpV4CheckBox);
         this.IpTypePanel.Location = new System.Drawing.Point(106, 69);
         this.IpTypePanel.Name = "IpTypePanel";
         this.IpTypePanel.Size = new System.Drawing.Size(197, 26);
         this.IpTypePanel.TabIndex = 27;
         // 
         // IpBothCheckBox
         // 
         this.IpBothCheckBox.AutoSize = true;
         this.IpBothCheckBox.Location = new System.Drawing.Point(112, 3);
         this.IpBothCheckBox.Name = "IpBothCheckBox";
         this.IpBothCheckBox.Size = new System.Drawing.Size(47, 17);
         this.IpBothCheckBox.TabIndex = 2;
         this.IpBothCheckBox.Text = "Both";
         this.IpBothCheckBox.UseVisualStyleBackColor = true;
         // 
         // IpV6CheckBox
         // 
         this.IpV6CheckBox.AutoSize = true;
         this.IpV6CheckBox.Location = new System.Drawing.Point(58, 3);
         this.IpV6CheckBox.Name = "IpV6CheckBox";
         this.IpV6CheckBox.Size = new System.Drawing.Size(47, 17);
         this.IpV6CheckBox.TabIndex = 1;
         this.IpV6CheckBox.Text = "IPv6";
         this.IpV6CheckBox.UseVisualStyleBackColor = true;
         // 
         // IpV4CheckBox
         // 
         this.IpV4CheckBox.AutoSize = true;
         this.IpV4CheckBox.Location = new System.Drawing.Point(4, 3);
         this.IpV4CheckBox.Name = "IpV4CheckBox";
         this.IpV4CheckBox.Size = new System.Drawing.Size(47, 17);
         this.IpV4CheckBox.TabIndex = 0;
         this.IpV4CheckBox.Text = "IPv4";
         this.IpV4CheckBox.UseVisualStyleBackColor = true;
         // 
         // label14
         // 
         this.label14.AutoSize = true;
         this.label14.Location = new System.Drawing.Point(15, 180);
         this.label14.Name = "label14";
         this.label14.Size = new System.Drawing.Size(150, 13);
         this.label14.TabIndex = 25;
         this.label14.Text = "&Implementation Version Name:";
         // 
         // ImplementationVersionTextBox
         // 
         this.ImplementationVersionTextBox.Location = new System.Drawing.Point(18, 200);
         this.ImplementationVersionTextBox.Name = "ImplementationVersionTextBox";
         this.ImplementationVersionTextBox.Size = new System.Drawing.Size(207, 20);
         this.ImplementationVersionTextBox.TabIndex = 26;
         // 
         // label13
         // 
         this.label13.AutoSize = true;
         this.label13.Location = new System.Drawing.Point(15, 129);
         this.label13.Name = "label13";
         this.label13.Size = new System.Drawing.Size(131, 13);
         this.label13.TabIndex = 23;
         this.label13.Text = "&Implementation Class UID:";
         // 
         // ImplementationClassTextBox
         // 
         this.ImplementationClassTextBox.Location = new System.Drawing.Point(18, 151);
         this.ImplementationClassTextBox.Name = "ImplementationClassTextBox";
         this.ImplementationClassTextBox.Size = new System.Drawing.Size(207, 20);
         this.ImplementationClassTextBox.TabIndex = 24;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 20);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(47, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "&AE Title:";
         // 
         // AeTitleTextBox
         // 
         this.AeTitleTextBox.Location = new System.Drawing.Point(106, 17);
         this.AeTitleTextBox.Name = "AeTitleTextBox";
         this.AeTitleTextBox.Size = new System.Drawing.Size(197, 20);
         this.AeTitleTextBox.TabIndex = 2;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(12, 103);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(29, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Port:";
         // 
         // PortNumericUpDown
         // 
         this.PortNumericUpDown.Location = new System.Drawing.Point(106, 101);
         this.PortNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
         this.PortNumericUpDown.Name = "PortNumericUpDown";
         this.PortNumericUpDown.Size = new System.Drawing.Size(57, 20);
         this.PortNumericUpDown.TabIndex = 4;
         // 
         // IpAddressComboBox
         // 
         this.IpAddressComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.IpAddressComboBox.FormattingEnabled = true;
         this.IpAddressComboBox.Location = new System.Drawing.Point(106, 44);
         this.IpAddressComboBox.Name = "IpAddressComboBox";
         this.IpAddressComboBox.Size = new System.Drawing.Size(197, 21);
         this.IpAddressComboBox.TabIndex = 14;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(12, 47);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(61, 13);
         this.label3.TabIndex = 5;
         this.label3.Text = "IP Address:";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.StartModeComboBox);
         this.groupBox2.Controls.Add(this.label7);
         this.groupBox2.Controls.Add(this.ServiceDescriptionTextBox);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Controls.Add(this.label4);
         this.groupBox2.Controls.Add(this.ServiceDisplayNameTextBox);
         this.groupBox2.Location = new System.Drawing.Point(328, 46);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(314, 226);
         this.groupBox2.TabIndex = 27;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Windows Service:";
         // 
         // StartModeComboBox
         // 
         this.StartModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.StartModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.StartModeComboBox.FormattingEnabled = true;
         this.StartModeComboBox.Location = new System.Drawing.Point(96, 130);
         this.StartModeComboBox.Name = "StartModeComboBox";
         this.StartModeComboBox.Size = new System.Drawing.Size(207, 21);
         this.StartModeComboBox.TabIndex = 25;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(18, 133);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(62, 13);
         this.label7.TabIndex = 24;
         this.label7.Text = "Start Mode:";
         // 
         // ServiceDescriptionTextBox
         // 
         this.ServiceDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.ServiceDescriptionTextBox.Location = new System.Drawing.Point(18, 69);
         this.ServiceDescriptionTextBox.Multiline = true;
         this.ServiceDescriptionTextBox.Name = "ServiceDescriptionTextBox";
         this.ServiceDescriptionTextBox.Size = new System.Drawing.Size(285, 52);
         this.ServiceDescriptionTextBox.TabIndex = 23;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(15, 53);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(63, 13);
         this.label5.TabIndex = 20;
         this.label5.Text = "Description:";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(15, 23);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(75, 13);
         this.label4.TabIndex = 21;
         this.label4.Text = "&Display Name:";
         // 
         // ServiceDisplayNameTextBox
         // 
         this.ServiceDisplayNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.ServiceDisplayNameTextBox.Location = new System.Drawing.Point(96, 20);
         this.ServiceDisplayNameTextBox.Name = "ServiceDisplayNameTextBox";
         this.ServiceDisplayNameTextBox.Size = new System.Drawing.Size(207, 20);
         this.ServiceDisplayNameTextBox.TabIndex = 22;
         // 
         // TestServiceButton
         // 
         this.TestServiceButton.Location = new System.Drawing.Point(18, 18);
         this.TestServiceButton.Name = "TestServiceButton";
         this.TestServiceButton.Size = new System.Drawing.Size(122, 23);
         this.TestServiceButton.TabIndex = 26;
         this.TestServiceButton.Text = "Test DICOM Server";
         this.TestServiceButton.UseVisualStyleBackColor = true;
         // 
         // toolStrip1
         // 
         this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddServerToolStripButton,
            this.DeleteServerToolStripButton});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(651, 39);
         this.toolStrip1.TabIndex = 29;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // AddServerToolStripButton
         // 
         this.AddServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.AddServerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddServerToolStripButton.Image")));
         this.AddServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.AddServerToolStripButton.Name = "AddServerToolStripButton";
         this.AddServerToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.AddServerToolStripButton.Text = "Add Server";
         this.AddServerToolStripButton.ToolTipText = "Add Server";
         // 
         // DeleteServerToolStripButton
         // 
         this.DeleteServerToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.DeleteServerToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteServerToolStripButton.Image")));
         this.DeleteServerToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.DeleteServerToolStripButton.Name = "DeleteServerToolStripButton";
         this.DeleteServerToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.DeleteServerToolStripButton.Text = "Delete Server";
         this.DeleteServerToolStripButton.ToolTipText = "Delete Server";
         // 
         // AETitleErrorProvider
         // 
         this.AETitleErrorProvider.ContainerControl = this;
         // 
         // GarbageCollectServiceButton
         // 
         this.GarbageCollectServiceButton.Location = new System.Drawing.Point(18, 47);
         this.GarbageCollectServiceButton.Name = "GarbageCollectServiceButton";
         this.GarbageCollectServiceButton.Size = new System.Drawing.Size(122, 23);
         this.GarbageCollectServiceButton.TabIndex = 27;
         this.GarbageCollectServiceButton.Text = "Reclaim Memory";
         this.GarbageCollectServiceButton.UseVisualStyleBackColor = true;
         // 
         // groupBoxDiagnostics
         // 
         this.groupBoxDiagnostics.Controls.Add(this.ForceTerminationsServiceButton);
         this.groupBoxDiagnostics.Controls.Add(this.TestServiceButton);
         this.groupBoxDiagnostics.Controls.Add(this.GarbageCollectServiceButton);
         this.groupBoxDiagnostics.Location = new System.Drawing.Point(0, 275);
         this.groupBoxDiagnostics.Name = "groupBoxDiagnostics";
         this.groupBoxDiagnostics.Size = new System.Drawing.Size(322, 108);
         this.groupBoxDiagnostics.TabIndex = 30;
         this.groupBoxDiagnostics.TabStop = false;
         this.groupBoxDiagnostics.Text = "DICOM Server Diagnostics";
         // 
         // ForceTerminationsServiceButton
         // 
         this.ForceTerminationsServiceButton.Location = new System.Drawing.Point(18, 76);
         this.ForceTerminationsServiceButton.Name = "ForceTerminationsServiceButton";
         this.ForceTerminationsServiceButton.Size = new System.Drawing.Size(122, 23);
         this.ForceTerminationsServiceButton.TabIndex = 28;
         this.ForceTerminationsServiceButton.Text = "Force Termination";
         this.ForceTerminationsServiceButton.UseVisualStyleBackColor = true;
         // 
         // GeneralSettingsView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBoxDiagnostics);
         this.Controls.Add(this.toolStrip1);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this.groupBox2);
         this.MinimumSize = new System.Drawing.Size(651, 277);
         this.Name = "GeneralSettingsView";
         this.Size = new System.Drawing.Size(651, 383);
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.IpTypePanel.ResumeLayout(false);
         this.IpTypePanel.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.PortNumericUpDown)).EndInit();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.AETitleErrorProvider)).EndInit();
         this.groupBoxDiagnostics.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox AeTitleTextBox;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.NumericUpDown PortNumericUpDown;
      private System.Windows.Forms.ComboBox IpAddressComboBox;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.ComboBox StartModeComboBox;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.TextBox ServiceDescriptionTextBox;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox ServiceDisplayNameTextBox;
      private System.Windows.Forms.Label label14;
      private System.Windows.Forms.TextBox ImplementationVersionTextBox;
      private System.Windows.Forms.Label label13;
      private System.Windows.Forms.TextBox ImplementationClassTextBox;
      private System.Windows.Forms.ToolStrip toolStrip1;
      public System.Windows.Forms.ToolStripButton AddServerToolStripButton;
      public System.Windows.Forms.ToolStripButton DeleteServerToolStripButton;
      private System.Windows.Forms.ErrorProvider AETitleErrorProvider;
      private System.Windows.Forms.Panel IpTypePanel;
      private System.Windows.Forms.RadioButton IpBothCheckBox;
      private System.Windows.Forms.RadioButton IpV6CheckBox;
      private System.Windows.Forms.RadioButton IpV4CheckBox;
      private System.Windows.Forms.Button TestServiceButton;
      private System.Windows.Forms.GroupBox groupBoxDiagnostics;
      private System.Windows.Forms.Button ForceTerminationsServiceButton;
      private System.Windows.Forms.Button GarbageCollectServiceButton;

   }
}
