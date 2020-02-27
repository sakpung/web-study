namespace Leadtools.Demos.StorageServer.UI
{
   partial class ServerOptionsView
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
         this.groupBoxTimeout = new System.Windows.Forms.GroupBox();
         this.AddinsTimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label12 = new System.Windows.Forms.Label();
         this.ReconnectTimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label11 = new System.Windows.Forms.Label();
         this.ClientTimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label10 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.AllowAnonCheckBox = new System.Windows.Forms.CheckBox();
         this.AllowMultipleCheckBox = new System.Windows.Forms.CheckBox();
         this.MaxClientsNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.BrowseTempButton = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.TempFolderTextBox = new System.Windows.Forms.TextBox();
         this.groupBoxRelationalQueries = new System.Windows.Forms.GroupBox();
         this.rbRelationalQueriesAlways = new System.Windows.Forms.RadioButton();
         this.rbRelationalQueriesNegotiate = new System.Windows.Forms.RadioButton();
         this.rbRelationalQueriesNever = new System.Windows.Forms.RadioButton();
         this.AllowAnonymousCMoveCheckBox = new System.Windows.Forms.CheckBox();
         this.AnonymousClientPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.AnonymousClientPortLabel = new System.Windows.Forms.Label();
         this.groupAssociation = new System.Windows.Forms.GroupBox();
         this.groupBoxRoleSelect = new System.Windows.Forms.GroupBox();
         this.groupBoxProviderRole = new System.Windows.Forms.GroupBox();
         this.radioButtonProviderRoleTurnDown = new System.Windows.Forms.RadioButton();
         this.radioButtonProviderRoleAccept = new System.Windows.Forms.RadioButton();
         this.groupBoxUserRole = new System.Windows.Forms.GroupBox();
         this.radioButtonUserRoleTurnDown = new System.Windows.Forms.RadioButton();
         this.radioButtonUserRoleAccept = new System.Windows.Forms.RadioButton();
         this.checkBoxEnableDefaultRoleSelection = new System.Windows.Forms.CheckBox();
         this.groupBoxConnections = new System.Windows.Forms.GroupBox();
         this.UseTlsSecurityCheckBox = new System.Windows.Forms.CheckBox();
         this.groupBoxTimeout.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.AddinsTimeoutNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ReconnectTimeoutNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ClientTimeoutNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.MaxClientsNumericUpDown)).BeginInit();
         this.groupBoxRelationalQueries.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.AnonymousClientPortNumericUpDown)).BeginInit();
         this.groupAssociation.SuspendLayout();
         this.groupBoxRoleSelect.SuspendLayout();
         this.groupBoxProviderRole.SuspendLayout();
         this.groupBoxUserRole.SuspendLayout();
         this.groupBoxConnections.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBoxTimeout
         // 
         this.groupBoxTimeout.Controls.Add(this.AddinsTimeoutNumericUpDown);
         this.groupBoxTimeout.Controls.Add(this.label12);
         this.groupBoxTimeout.Controls.Add(this.ReconnectTimeoutNumericUpDown);
         this.groupBoxTimeout.Controls.Add(this.label11);
         this.groupBoxTimeout.Controls.Add(this.ClientTimeoutNumericUpDown);
         this.groupBoxTimeout.Controls.Add(this.label10);
         this.groupBoxTimeout.Location = new System.Drawing.Point(227, 3);
         this.groupBoxTimeout.Name = "groupBoxTimeout";
         this.groupBoxTimeout.Size = new System.Drawing.Size(206, 157);
         this.groupBoxTimeout.TabIndex = 7;
         this.groupBoxTimeout.TabStop = false;
         this.groupBoxTimeout.Text = "Timeout (Seconds):";
         // 
         // AddinsTimeoutNumericUpDown
         // 
         this.AddinsTimeoutNumericUpDown.Location = new System.Drawing.Point(142, 39);
         this.AddinsTimeoutNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
         this.AddinsTimeoutNumericUpDown.Name = "AddinsTimeoutNumericUpDown";
         this.AddinsTimeoutNumericUpDown.Size = new System.Drawing.Size(57, 20);
         this.AddinsTimeoutNumericUpDown.TabIndex = 3;
         // 
         // label12
         // 
         this.label12.AutoSize = true;
         this.label12.Location = new System.Drawing.Point(20, 43);
         this.label12.Name = "label12";
         this.label12.Size = new System.Drawing.Size(108, 13);
         this.label12.TabIndex = 2;
         this.label12.Text = "Message Processing:";
         // 
         // ReconnectTimeoutNumericUpDown
         // 
         this.ReconnectTimeoutNumericUpDown.Location = new System.Drawing.Point(142, 62);
         this.ReconnectTimeoutNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
         this.ReconnectTimeoutNumericUpDown.Name = "ReconnectTimeoutNumericUpDown";
         this.ReconnectTimeoutNumericUpDown.Size = new System.Drawing.Size(57, 20);
         this.ReconnectTimeoutNumericUpDown.TabIndex = 5;
         // 
         // label11
         // 
         this.label11.AutoSize = true;
         this.label11.Location = new System.Drawing.Point(20, 66);
         this.label11.Name = "label11";
         this.label11.Size = new System.Drawing.Size(105, 13);
         this.label11.TabIndex = 4;
         this.label11.Text = "Store sub-operation :";
         // 
         // ClientTimeoutNumericUpDown
         // 
         this.ClientTimeoutNumericUpDown.Location = new System.Drawing.Point(142, 16);
         this.ClientTimeoutNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
         this.ClientTimeoutNumericUpDown.Name = "ClientTimeoutNumericUpDown";
         this.ClientTimeoutNumericUpDown.Size = new System.Drawing.Size(57, 20);
         this.ClientTimeoutNumericUpDown.TabIndex = 1;
         // 
         // label10
         // 
         this.label10.AutoSize = true;
         this.label10.Location = new System.Drawing.Point(20, 20);
         this.label10.Name = "label10";
         this.label10.Size = new System.Drawing.Size(56, 13);
         this.label10.TabIndex = 0;
         this.label10.Text = "Client Idle:";
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(8, 129);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(67, 13);
         this.label6.TabIndex = 5;
         this.label6.Text = "Max. Clients:";
         // 
         // AllowAnonCheckBox
         // 
         this.AllowAnonCheckBox.AutoSize = true;
         this.AllowAnonCheckBox.Location = new System.Drawing.Point(10, 18);
         this.AllowAnonCheckBox.Name = "AllowAnonCheckBox";
         this.AllowAnonCheckBox.Size = new System.Drawing.Size(171, 17);
         this.AllowAnonCheckBox.TabIndex = 0;
         this.AllowAnonCheckBox.Text = "Allow Anonymous Connections";
         this.AllowAnonCheckBox.UseVisualStyleBackColor = true;
         // 
         // AllowMultipleCheckBox
         // 
         this.AllowMultipleCheckBox.AutoSize = true;
         this.AllowMultipleCheckBox.Location = new System.Drawing.Point(10, 83);
         this.AllowMultipleCheckBox.Name = "AllowMultipleCheckBox";
         this.AllowMultipleCheckBox.Size = new System.Drawing.Size(181, 17);
         this.AllowMultipleCheckBox.TabIndex = 4;
         this.AllowMultipleCheckBox.Text = "Allow Client Multiple Connections";
         this.AllowMultipleCheckBox.UseVisualStyleBackColor = true;
         // 
         // MaxClientsNumericUpDown
         // 
         this.MaxClientsNumericUpDown.Location = new System.Drawing.Point(81, 127);
         this.MaxClientsNumericUpDown.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
         this.MaxClientsNumericUpDown.Name = "MaxClientsNumericUpDown";
         this.MaxClientsNumericUpDown.Size = new System.Drawing.Size(57, 20);
         this.MaxClientsNumericUpDown.TabIndex = 6;
         // 
         // BrowseTempButton
         // 
         this.BrowseTempButton.Location = new System.Drawing.Point(354, 418);
         this.BrowseTempButton.Name = "BrowseTempButton";
         this.BrowseTempButton.Size = new System.Drawing.Size(75, 23);
         this.BrowseTempButton.TabIndex = 11;
         this.BrowseTempButton.Text = "Browse...";
         this.BrowseTempButton.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(9, 403);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(105, 13);
         this.label1.TabIndex = 9;
         this.label1.Text = "Temporary Directory:";
         // 
         // TempFolderTextBox
         // 
         this.TempFolderTextBox.Location = new System.Drawing.Point(8, 419);
         this.TempFolderTextBox.Name = "TempFolderTextBox";
         this.TempFolderTextBox.Size = new System.Drawing.Size(344, 20);
         this.TempFolderTextBox.TabIndex = 10;
         this.TempFolderTextBox.Leave += new System.EventHandler(this.TempFolderTextBox_Leave);
         // 
         // groupBoxRelationalQueries
         // 
         this.groupBoxRelationalQueries.Controls.Add(this.rbRelationalQueriesAlways);
         this.groupBoxRelationalQueries.Controls.Add(this.rbRelationalQueriesNegotiate);
         this.groupBoxRelationalQueries.Controls.Add(this.rbRelationalQueriesNever);
         this.groupBoxRelationalQueries.Location = new System.Drawing.Point(9, 19);
         this.groupBoxRelationalQueries.Name = "groupBoxRelationalQueries";
         this.groupBoxRelationalQueries.Size = new System.Drawing.Size(197, 92);
         this.groupBoxRelationalQueries.TabIndex = 0;
         this.groupBoxRelationalQueries.TabStop = false;
         this.groupBoxRelationalQueries.Text = "Relational Queries";
         // 
         // rbRelationalQueriesAlways
         // 
         this.rbRelationalQueriesAlways.AutoSize = true;
         this.rbRelationalQueriesAlways.Location = new System.Drawing.Point(7, 63);
         this.rbRelationalQueriesAlways.Name = "rbRelationalQueriesAlways";
         this.rbRelationalQueriesAlways.Size = new System.Drawing.Size(58, 17);
         this.rbRelationalQueriesAlways.TabIndex = 2;
         this.rbRelationalQueriesAlways.TabStop = true;
         this.rbRelationalQueriesAlways.Text = "Always";
         this.rbRelationalQueriesAlways.UseVisualStyleBackColor = true;
         // 
         // rbRelationalQueriesNegotiate
         // 
         this.rbRelationalQueriesNegotiate.AutoSize = true;
         this.rbRelationalQueriesNegotiate.Location = new System.Drawing.Point(7, 40);
         this.rbRelationalQueriesNegotiate.Name = "rbRelationalQueriesNegotiate";
         this.rbRelationalQueriesNegotiate.Size = new System.Drawing.Size(173, 17);
         this.rbRelationalQueriesNegotiate.TabIndex = 1;
         this.rbRelationalQueriesNegotiate.TabStop = true;
         this.rbRelationalQueriesNegotiate.Text = "Support - Extended Negotiation";
         this.rbRelationalQueriesNegotiate.UseVisualStyleBackColor = true;
         // 
         // rbRelationalQueriesNever
         // 
         this.rbRelationalQueriesNever.AutoSize = true;
         this.rbRelationalQueriesNever.Location = new System.Drawing.Point(7, 17);
         this.rbRelationalQueriesNever.Name = "rbRelationalQueriesNever";
         this.rbRelationalQueriesNever.Size = new System.Drawing.Size(99, 17);
         this.rbRelationalQueriesNever.TabIndex = 0;
         this.rbRelationalQueriesNever.TabStop = true;
         this.rbRelationalQueriesNever.Text = "Do Not Support";
         this.rbRelationalQueriesNever.UseVisualStyleBackColor = true;
         // 
         // AllowAnonymousCMoveCheckBox
         // 
         this.AllowAnonymousCMoveCheckBox.AutoSize = true;
         this.AllowAnonymousCMoveCheckBox.Location = new System.Drawing.Point(10, 41);
         this.AllowAnonymousCMoveCheckBox.Name = "AllowAnonymousCMoveCheckBox";
         this.AllowAnonymousCMoveCheckBox.Size = new System.Drawing.Size(149, 17);
         this.AllowAnonymousCMoveCheckBox.TabIndex = 1;
         this.AllowAnonymousCMoveCheckBox.Text = "Allow Anonymous C-Move";
         this.AllowAnonymousCMoveCheckBox.UseVisualStyleBackColor = true;
         // 
         // AnonymousClientPortNumericUpDown
         // 
         this.AnonymousClientPortNumericUpDown.Location = new System.Drawing.Point(149, 61);
         this.AnonymousClientPortNumericUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
         this.AnonymousClientPortNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.AnonymousClientPortNumericUpDown.Name = "AnonymousClientPortNumericUpDown";
         this.AnonymousClientPortNumericUpDown.Size = new System.Drawing.Size(57, 20);
         this.AnonymousClientPortNumericUpDown.TabIndex = 3;
         this.AnonymousClientPortNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // AnonymousClientPortLabel
         // 
         this.AnonymousClientPortLabel.AutoSize = true;
         this.AnonymousClientPortLabel.Location = new System.Drawing.Point(27, 63);
         this.AnonymousClientPortLabel.Name = "AnonymousClientPortLabel";
         this.AnonymousClientPortLabel.Size = new System.Drawing.Size(116, 13);
         this.AnonymousClientPortLabel.TabIndex = 2;
         this.AnonymousClientPortLabel.Text = "Anonymous Client Port:";
         // 
         // groupAssociation
         // 
         this.groupAssociation.Controls.Add(this.groupBoxRoleSelect);
         this.groupAssociation.Controls.Add(this.groupBoxRelationalQueries);
         this.groupAssociation.Location = new System.Drawing.Point(3, 166);
         this.groupAssociation.Name = "groupAssociation";
         this.groupAssociation.Size = new System.Drawing.Size(430, 234);
         this.groupAssociation.TabIndex = 8;
         this.groupAssociation.TabStop = false;
         this.groupAssociation.Text = "Association";
         // 
         // groupBoxRoleSelect
         // 
         this.groupBoxRoleSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxRoleSelect.Controls.Add(this.groupBoxProviderRole);
         this.groupBoxRoleSelect.Controls.Add(this.groupBoxUserRole);
         this.groupBoxRoleSelect.Controls.Add(this.checkBoxEnableDefaultRoleSelection);
         this.groupBoxRoleSelect.Location = new System.Drawing.Point(10, 135);
         this.groupBoxRoleSelect.Name = "groupBoxRoleSelect";
         this.groupBoxRoleSelect.Size = new System.Drawing.Size(414, 88);
         this.groupBoxRoleSelect.TabIndex = 9;
         this.groupBoxRoleSelect.TabStop = false;
         this.groupBoxRoleSelect.Text = "       Enable Role Selection Negotiation (DIMSE Services)";
         // 
         // groupBoxProviderRole
         // 
         this.groupBoxProviderRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxProviderRole.Controls.Add(this.radioButtonProviderRoleTurnDown);
         this.groupBoxProviderRole.Controls.Add(this.radioButtonProviderRoleAccept);
         this.groupBoxProviderRole.Location = new System.Drawing.Point(175, 22);
         this.groupBoxProviderRole.Name = "groupBoxProviderRole";
         this.groupBoxProviderRole.Size = new System.Drawing.Size(233, 57);
         this.groupBoxProviderRole.TabIndex = 8;
         this.groupBoxProviderRole.TabStop = false;
         this.groupBoxProviderRole.Text = "Provider Role (SCP) Proposal";
         // 
         // radioButtonProviderRoleTurnDown
         // 
         this.radioButtonProviderRoleTurnDown.AutoSize = true;
         this.radioButtonProviderRoleTurnDown.Location = new System.Drawing.Point(16, 36);
         this.radioButtonProviderRoleTurnDown.Name = "radioButtonProviderRoleTurnDown";
         this.radioButtonProviderRoleTurnDown.Size = new System.Drawing.Size(93, 17);
         this.radioButtonProviderRoleTurnDown.TabIndex = 8;
         this.radioButtonProviderRoleTurnDown.TabStop = true;
         this.radioButtonProviderRoleTurnDown.Text = "Turn Down (0)";
         this.radioButtonProviderRoleTurnDown.UseVisualStyleBackColor = true;
         // 
         // radioButtonProviderRoleAccept
         // 
         this.radioButtonProviderRoleAccept.AutoSize = true;
         this.radioButtonProviderRoleAccept.Location = new System.Drawing.Point(16, 16);
         this.radioButtonProviderRoleAccept.Name = "radioButtonProviderRoleAccept";
         this.radioButtonProviderRoleAccept.Size = new System.Drawing.Size(74, 17);
         this.radioButtonProviderRoleAccept.TabIndex = 7;
         this.radioButtonProviderRoleAccept.TabStop = true;
         this.radioButtonProviderRoleAccept.Text = "Accept (1)";
         this.radioButtonProviderRoleAccept.UseVisualStyleBackColor = true;
         // 
         // groupBoxUserRole
         // 
         this.groupBoxUserRole.Controls.Add(this.radioButtonUserRoleTurnDown);
         this.groupBoxUserRole.Controls.Add(this.radioButtonUserRoleAccept);
         this.groupBoxUserRole.Location = new System.Drawing.Point(17, 22);
         this.groupBoxUserRole.Name = "groupBoxUserRole";
         this.groupBoxUserRole.Size = new System.Drawing.Size(146, 57);
         this.groupBoxUserRole.TabIndex = 7;
         this.groupBoxUserRole.TabStop = false;
         this.groupBoxUserRole.Text = "User Role (SCU) Proposal";
         // 
         // radioButtonUserRoleTurnDown
         // 
         this.radioButtonUserRoleTurnDown.AutoSize = true;
         this.radioButtonUserRoleTurnDown.Location = new System.Drawing.Point(15, 36);
         this.radioButtonUserRoleTurnDown.Name = "radioButtonUserRoleTurnDown";
         this.radioButtonUserRoleTurnDown.Size = new System.Drawing.Size(93, 17);
         this.radioButtonUserRoleTurnDown.TabIndex = 6;
         this.radioButtonUserRoleTurnDown.TabStop = true;
         this.radioButtonUserRoleTurnDown.Text = "Turn Down (0)";
         this.radioButtonUserRoleTurnDown.UseVisualStyleBackColor = true;
         // 
         // radioButtonUserRoleAccept
         // 
         this.radioButtonUserRoleAccept.AutoSize = true;
         this.radioButtonUserRoleAccept.Location = new System.Drawing.Point(15, 16);
         this.radioButtonUserRoleAccept.Name = "radioButtonUserRoleAccept";
         this.radioButtonUserRoleAccept.Size = new System.Drawing.Size(74, 17);
         this.radioButtonUserRoleAccept.TabIndex = 5;
         this.radioButtonUserRoleAccept.TabStop = true;
         this.radioButtonUserRoleAccept.Text = "Accept (1)";
         this.radioButtonUserRoleAccept.UseVisualStyleBackColor = true;
         // 
         // checkBoxEnableDefaultRoleSelection
         // 
         this.checkBoxEnableDefaultRoleSelection.AutoSize = true;
         this.checkBoxEnableDefaultRoleSelection.Location = new System.Drawing.Point(7, 0);
         this.checkBoxEnableDefaultRoleSelection.Name = "checkBoxEnableDefaultRoleSelection";
         this.checkBoxEnableDefaultRoleSelection.Size = new System.Drawing.Size(15, 14);
         this.checkBoxEnableDefaultRoleSelection.TabIndex = 0;
         this.checkBoxEnableDefaultRoleSelection.UseVisualStyleBackColor = true;
         // 
         // groupBoxConnections
         // 
         this.groupBoxConnections.Controls.Add(this.UseTlsSecurityCheckBox);
         this.groupBoxConnections.Controls.Add(this.AnonymousClientPortLabel);
         this.groupBoxConnections.Controls.Add(this.MaxClientsNumericUpDown);
         this.groupBoxConnections.Controls.Add(this.AllowMultipleCheckBox);
         this.groupBoxConnections.Controls.Add(this.AnonymousClientPortNumericUpDown);
         this.groupBoxConnections.Controls.Add(this.AllowAnonCheckBox);
         this.groupBoxConnections.Controls.Add(this.AllowAnonymousCMoveCheckBox);
         this.groupBoxConnections.Controls.Add(this.label6);
         this.groupBoxConnections.Location = new System.Drawing.Point(3, 3);
         this.groupBoxConnections.Name = "groupBoxConnections";
         this.groupBoxConnections.Size = new System.Drawing.Size(218, 157);
         this.groupBoxConnections.TabIndex = 12;
         this.groupBoxConnections.TabStop = false;
         this.groupBoxConnections.Text = "Connections";
         // 
         // UseTlsSecurityCheckBox
         // 
         this.UseTlsSecurityCheckBox.AutoSize = true;
         this.UseTlsSecurityCheckBox.Location = new System.Drawing.Point(10, 106);
         this.UseTlsSecurityCheckBox.Name = "UseTlsSecurityCheckBox";
         this.UseTlsSecurityCheckBox.Size = new System.Drawing.Size(109, 17);
         this.UseTlsSecurityCheckBox.TabIndex = 7;
         this.UseTlsSecurityCheckBox.Text = "Secure (Use TLS Security)";
         this.UseTlsSecurityCheckBox.UseVisualStyleBackColor = true;
         // 
         // ServerOptionsView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBoxConnections);
         this.Controls.Add(this.groupAssociation);
         this.Controls.Add(this.TempFolderTextBox);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.BrowseTempButton);
         this.Controls.Add(this.groupBoxTimeout);
         this.Name = "ServerOptionsView";
         this.Size = new System.Drawing.Size(439, 448);
         this.groupBoxTimeout.ResumeLayout(false);
         this.groupBoxTimeout.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.AddinsTimeoutNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ReconnectTimeoutNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ClientTimeoutNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.MaxClientsNumericUpDown)).EndInit();
         this.groupBoxRelationalQueries.ResumeLayout(false);
         this.groupBoxRelationalQueries.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.AnonymousClientPortNumericUpDown)).EndInit();
         this.groupAssociation.ResumeLayout(false);
         this.groupBoxRoleSelect.ResumeLayout(false);
         this.groupBoxRoleSelect.PerformLayout();
         this.groupBoxProviderRole.ResumeLayout(false);
         this.groupBoxProviderRole.PerformLayout();
         this.groupBoxUserRole.ResumeLayout(false);
         this.groupBoxUserRole.PerformLayout();
         this.groupBoxConnections.ResumeLayout(false);
         this.groupBoxConnections.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBoxTimeout;
      private System.Windows.Forms.NumericUpDown AddinsTimeoutNumericUpDown;
      private System.Windows.Forms.Label label12;
      private System.Windows.Forms.NumericUpDown ReconnectTimeoutNumericUpDown;
      private System.Windows.Forms.Label label11;
      private System.Windows.Forms.NumericUpDown ClientTimeoutNumericUpDown;
      private System.Windows.Forms.Label label10;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.CheckBox AllowAnonCheckBox;
      private System.Windows.Forms.CheckBox AllowMultipleCheckBox;
      private System.Windows.Forms.NumericUpDown MaxClientsNumericUpDown;
      private System.Windows.Forms.Button BrowseTempButton;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox TempFolderTextBox;
      private System.Windows.Forms.GroupBox groupBoxRelationalQueries;
      private System.Windows.Forms.RadioButton rbRelationalQueriesAlways;
      private System.Windows.Forms.RadioButton rbRelationalQueriesNegotiate;
      private System.Windows.Forms.RadioButton rbRelationalQueriesNever;
      private System.Windows.Forms.CheckBox AllowAnonymousCMoveCheckBox;
      private System.Windows.Forms.NumericUpDown AnonymousClientPortNumericUpDown;
      private System.Windows.Forms.Label AnonymousClientPortLabel;
      private System.Windows.Forms.GroupBox groupAssociation;
      private System.Windows.Forms.GroupBox groupBoxConnections;
      private System.Windows.Forms.GroupBox groupBoxRoleSelect;
      private System.Windows.Forms.GroupBox groupBoxProviderRole;
      private System.Windows.Forms.RadioButton radioButtonProviderRoleTurnDown;
      private System.Windows.Forms.RadioButton radioButtonProviderRoleAccept;
      private System.Windows.Forms.GroupBox groupBoxUserRole;
      private System.Windows.Forms.RadioButton radioButtonUserRoleTurnDown;
      private System.Windows.Forms.RadioButton radioButtonUserRoleAccept;
      private System.Windows.Forms.CheckBox checkBoxEnableDefaultRoleSelection;
      private System.Windows.Forms.CheckBox UseTlsSecurityCheckBox;
   }
}
