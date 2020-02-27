namespace Leadtools.Medical.Winforms
{
   partial class PresentationContextDialog
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.buttonCancel = new System.Windows.Forms.Button();
         this.buttonOK = new System.Windows.Forms.Button();
         this.listViewTransferSyntax = new System.Windows.Forms.ListView();
         this.columnHeaderTransferSyntaxUid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeaderTransferSyntaxDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.labelName = new System.Windows.Forms.Label();
         this.labelUid = new System.Windows.Forms.Label();
         this.textBoxName = new System.Windows.Forms.TextBox();
         this.textBoxUid = new System.Windows.Forms.TextBox();
         this.labelTransferSyntax = new System.Windows.Forms.Label();
         this.groupBoxRoleSelect = new System.Windows.Forms.GroupBox();
         this.checkBoxEnableRoleSelect = new System.Windows.Forms.CheckBox();
         this.groupBoxUserRole = new System.Windows.Forms.GroupBox();
         this.radioButtonUserRoleTurnDown = new System.Windows.Forms.RadioButton();
         this.radioButtonUserRoleAccept = new System.Windows.Forms.RadioButton();
         this.groupBoxProviderRole = new System.Windows.Forms.GroupBox();
         this.radioButtonProviderRoleTurnDown = new System.Windows.Forms.RadioButton();
         this.radioButtonProviderRoleAccept = new System.Windows.Forms.RadioButton();
         this.groupBoxRoleSelect.SuspendLayout();
         this.groupBoxUserRole.SuspendLayout();
         this.groupBoxProviderRole.SuspendLayout();
         this.SuspendLayout();
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(384, 476);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(77, 23);
         this.buttonCancel.TabIndex = 0;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.Location = new System.Drawing.Point(301, 476);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(77, 23);
         this.buttonOK.TabIndex = 1;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // listViewTransferSyntax
         // 
         this.listViewTransferSyntax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewTransferSyntax.CheckBoxes = true;
         this.listViewTransferSyntax.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTransferSyntaxUid,
            this.columnHeaderTransferSyntaxDescription});
         this.listViewTransferSyntax.FullRowSelect = true;
         this.listViewTransferSyntax.Location = new System.Drawing.Point(16, 189);
         this.listViewTransferSyntax.Name = "listViewTransferSyntax";
         this.listViewTransferSyntax.Size = new System.Drawing.Size(445, 279);
         this.listViewTransferSyntax.TabIndex = 2;
         this.listViewTransferSyntax.UseCompatibleStateImageBehavior = false;
         this.listViewTransferSyntax.View = System.Windows.Forms.View.Details;
         // 
         // columnHeaderTransferSyntaxUid
         // 
         this.columnHeaderTransferSyntaxUid.Text = "UID";
         // 
         // columnHeaderTransferSyntaxDescription
         // 
         this.columnHeaderTransferSyntaxDescription.Text = "Description";
         // 
         // labelName
         // 
         this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelName.AutoSize = true;
         this.labelName.Location = new System.Drawing.Point(8, 16);
         this.labelName.Name = "labelName";
         this.labelName.Size = new System.Drawing.Size(38, 13);
         this.labelName.TabIndex = 3;
         this.labelName.Text = "Name:";
         // 
         // labelUid
         // 
         this.labelUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelUid.AutoSize = true;
         this.labelUid.Location = new System.Drawing.Point(8, 40);
         this.labelUid.Name = "labelUid";
         this.labelUid.Size = new System.Drawing.Size(29, 13);
         this.labelUid.TabIndex = 4;
         this.labelUid.Text = "UID:";
         // 
         // textBoxName
         // 
         this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxName.Location = new System.Drawing.Point(48, 12);
         this.textBoxName.Name = "textBoxName";
         this.textBoxName.ReadOnly = true;
         this.textBoxName.Size = new System.Drawing.Size(413, 20);
         this.textBoxName.TabIndex = 5;
         // 
         // textBoxUid
         // 
         this.textBoxUid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textBoxUid.Location = new System.Drawing.Point(48, 36);
         this.textBoxUid.Name = "textBoxUid";
         this.textBoxUid.ReadOnly = true;
         this.textBoxUid.Size = new System.Drawing.Size(413, 20);
         this.textBoxUid.TabIndex = 6;
         // 
         // labelTransferSyntax
         // 
         this.labelTransferSyntax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.labelTransferSyntax.AutoSize = true;
         this.labelTransferSyntax.Location = new System.Drawing.Point(8, 173);
         this.labelTransferSyntax.Name = "labelTransferSyntax";
         this.labelTransferSyntax.Size = new System.Drawing.Size(147, 13);
         this.labelTransferSyntax.TabIndex = 7;
         this.labelTransferSyntax.Text = "Supported Transfer Syntaxes:";
         // 
         // groupBoxRoleSelect
         // 
         this.groupBoxRoleSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxRoleSelect.Controls.Add(this.groupBoxProviderRole);
         this.groupBoxRoleSelect.Controls.Add(this.groupBoxUserRole);
         this.groupBoxRoleSelect.Controls.Add(this.checkBoxEnableRoleSelect);
         this.groupBoxRoleSelect.Location = new System.Drawing.Point(16, 70);
         this.groupBoxRoleSelect.Name = "groupBoxRoleSelect";
         this.groupBoxRoleSelect.Size = new System.Drawing.Size(445, 88);
         this.groupBoxRoleSelect.TabIndex = 8;
         this.groupBoxRoleSelect.TabStop = false;
         this.groupBoxRoleSelect.Text = "       Enable Role Selection Negotiation";
         // 
         // checkBoxEnableRoleSelect
         // 
         this.checkBoxEnableRoleSelect.AutoSize = true;
         this.checkBoxEnableRoleSelect.Location = new System.Drawing.Point(12, 1);
         this.checkBoxEnableRoleSelect.Name = "checkBoxEnableRoleSelect";
         this.checkBoxEnableRoleSelect.Size = new System.Drawing.Size(15, 14);
         this.checkBoxEnableRoleSelect.TabIndex = 0;
         this.checkBoxEnableRoleSelect.UseVisualStyleBackColor = true;
         // 
         // groupBoxUserRole
         // 
         this.groupBoxUserRole.Controls.Add(this.radioButtonUserRoleTurnDown);
         this.groupBoxUserRole.Controls.Add(this.radioButtonUserRoleAccept);
         this.groupBoxUserRole.Location = new System.Drawing.Point(12, 25);
         this.groupBoxUserRole.Name = "groupBoxUserRole";
         this.groupBoxUserRole.Size = new System.Drawing.Size(167, 57);
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
         // groupBoxProviderRole
         // 
         this.groupBoxProviderRole.Controls.Add(this.radioButtonProviderRoleTurnDown);
         this.groupBoxProviderRole.Controls.Add(this.radioButtonProviderRoleAccept);
         this.groupBoxProviderRole.Location = new System.Drawing.Point(193, 25);
         this.groupBoxProviderRole.Name = "groupBoxProviderRole";
         this.groupBoxProviderRole.Size = new System.Drawing.Size(167, 57);
         this.groupBoxProviderRole.TabIndex = 8;
         this.groupBoxProviderRole.TabStop = false;
         this.groupBoxProviderRole.Text = "Provider Role (SCP) Proposal";
         // 
         // radioButtonProviderRoleTurnDown
         // 
         this.radioButtonProviderRoleTurnDown.AutoSize = true;
         this.radioButtonProviderRoleTurnDown.Location = new System.Drawing.Point(16, 38);
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
         this.radioButtonProviderRoleAccept.Location = new System.Drawing.Point(16, 18);
         this.radioButtonProviderRoleAccept.Name = "radioButtonProviderRoleAccept";
         this.radioButtonProviderRoleAccept.Size = new System.Drawing.Size(74, 17);
         this.radioButtonProviderRoleAccept.TabIndex = 7;
         this.radioButtonProviderRoleAccept.TabStop = true;
         this.radioButtonProviderRoleAccept.Text = "Accept (1)";
         this.radioButtonProviderRoleAccept.UseVisualStyleBackColor = true;
         // 
         // PresentationContextDialog
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(466, 500);
         this.Controls.Add(this.groupBoxRoleSelect);
         this.Controls.Add(this.labelTransferSyntax);
         this.Controls.Add(this.textBoxUid);
         this.Controls.Add(this.textBoxName);
         this.Controls.Add(this.labelUid);
         this.Controls.Add(this.labelName);
         this.Controls.Add(this.listViewTransferSyntax);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.buttonCancel);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PresentationContextDialog";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "IOD Properties";
         this.Load += new System.EventHandler(this.PresentationContext_Load);
         this.groupBoxRoleSelect.ResumeLayout(false);
         this.groupBoxRoleSelect.PerformLayout();
         this.groupBoxUserRole.ResumeLayout(false);
         this.groupBoxUserRole.PerformLayout();
         this.groupBoxProviderRole.ResumeLayout(false);
         this.groupBoxProviderRole.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.ListView listViewTransferSyntax;
      private System.Windows.Forms.Label labelName;
      private System.Windows.Forms.Label labelUid;
      private System.Windows.Forms.TextBox textBoxName;
      private System.Windows.Forms.TextBox textBoxUid;
      private System.Windows.Forms.Label labelTransferSyntax;
      private System.Windows.Forms.ColumnHeader columnHeaderTransferSyntaxUid;
      private System.Windows.Forms.ColumnHeader columnHeaderTransferSyntaxDescription;
      private System.Windows.Forms.GroupBox groupBoxRoleSelect;
      private System.Windows.Forms.CheckBox checkBoxEnableRoleSelect;
      private System.Windows.Forms.GroupBox groupBoxProviderRole;
      private System.Windows.Forms.RadioButton radioButtonProviderRoleTurnDown;
      private System.Windows.Forms.RadioButton radioButtonProviderRoleAccept;
      private System.Windows.Forms.GroupBox groupBoxUserRole;
      private System.Windows.Forms.RadioButton radioButtonUserRoleTurnDown;
      private System.Windows.Forms.RadioButton radioButtonUserRoleAccept;
   }
}