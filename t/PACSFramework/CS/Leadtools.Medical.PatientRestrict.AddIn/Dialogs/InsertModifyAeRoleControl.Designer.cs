namespace Leadtools.Medical.PatientRestrict.AddIn.Dialogs
{
   partial class InsertModifyAeRoleControl
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
         this.groupBoxClient = new System.Windows.Forms.GroupBox();
         this.comboBoxAeTitle = new System.Windows.Forms.ComboBox();
         this.labelRoleCombo = new System.Windows.Forms.Label();
         this.comboBoxRole = new System.Windows.Forms.ComboBox();
         this.labelAeTitle = new System.Windows.Forms.Label();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.groupBoxClient.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBoxClient
         // 
         this.groupBoxClient.Controls.Add(this.comboBoxAeTitle);
         this.groupBoxClient.Controls.Add(this.labelRoleCombo);
         this.groupBoxClient.Controls.Add(this.comboBoxRole);
         this.groupBoxClient.Controls.Add(this.labelAeTitle);
         this.groupBoxClient.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBoxClient.Location = new System.Drawing.Point(0, 0);
         this.groupBoxClient.Name = "groupBoxClient";
         this.groupBoxClient.Size = new System.Drawing.Size(448, 100);
         this.groupBoxClient.TabIndex = 0;
         this.groupBoxClient.TabStop = false;
         this.groupBoxClient.Text = "AE Title Role Information";
         // 
         // comboBoxAeTitle
         // 
         this.comboBoxAeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBoxAeTitle.FormattingEnabled = true;
         this.comboBoxAeTitle.Location = new System.Drawing.Point(73, 21);
         this.comboBoxAeTitle.Name = "comboBoxAeTitle";
         this.comboBoxAeTitle.Size = new System.Drawing.Size(332, 21);
         this.comboBoxAeTitle.TabIndex = 0;
         // 
         // labelRoleCombo
         // 
         this.labelRoleCombo.AutoSize = true;
         this.labelRoleCombo.Location = new System.Drawing.Point(33, 52);
         this.labelRoleCombo.Name = "labelRoleCombo";
         this.labelRoleCombo.Size = new System.Drawing.Size(32, 13);
         this.labelRoleCombo.TabIndex = 2;
         this.labelRoleCombo.Text = "Role:";
         // 
         // comboBoxRole
         // 
         this.comboBoxRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBoxRole.FormattingEnabled = true;
         this.comboBoxRole.Location = new System.Drawing.Point(73, 48);
         this.comboBoxRole.Name = "comboBoxRole";
         this.comboBoxRole.Size = new System.Drawing.Size(332, 21);
         this.comboBoxRole.TabIndex = 3;
         // 
         // labelAeTitle
         // 
         this.labelAeTitle.AutoSize = true;
         this.labelAeTitle.Location = new System.Drawing.Point(18, 25);
         this.labelAeTitle.Name = "labelAeTitle";
         this.labelAeTitle.Size = new System.Drawing.Size(47, 13);
         this.labelAeTitle.TabIndex = 0;
         this.labelAeTitle.Text = "AE Title:";
         // 
         // errorProvider
         // 
         this.errorProvider.ContainerControl = this;
         // 
         // InsertModifyAeRoleControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBoxClient);
         this.MinimumSize = new System.Drawing.Size(430, 100);
         this.Name = "InsertModifyAeRoleControl";
         this.Size = new System.Drawing.Size(448, 100);
         this.Load += new System.EventHandler(this.InsertModifyAeRoleControl_Load);
         this.groupBoxClient.ResumeLayout(false);
         this.groupBoxClient.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBoxClient;
      private System.Windows.Forms.Label labelAeTitle;
      private System.Windows.Forms.ErrorProvider errorProvider;
      private System.Windows.Forms.Label labelRoleCombo;
      private System.Windows.Forms.ComboBox comboBoxRole;
      private System.Windows.Forms.ComboBox comboBoxAeTitle;
   }
}
