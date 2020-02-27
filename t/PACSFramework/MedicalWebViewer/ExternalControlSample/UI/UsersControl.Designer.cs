namespace ExternalControlSample.UI
{
   partial class UsersControl
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
         this.labelUsername = new System.Windows.Forms.Label();
         this.labelUserPassword = new System.Windows.Forms.Label();
         this.textBoxUsername = new System.Windows.Forms.TextBox();
         this.textBoxUserPassword = new System.Windows.Forms.TextBox();
         this.checkedListBoxPermissions = new System.Windows.Forms.CheckedListBox();
         this.labelPermissions = new System.Windows.Forms.Label();
         this.checkedListBoxRoles = new System.Windows.Forms.CheckedListBox();
         this.labelRoles = new System.Windows.Forms.Label();
         this.comboBoxUserName = new System.Windows.Forms.ComboBox();
         this.checkBoxUserPassword = new System.Windows.Forms.CheckBox();
         this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.toolStripMenuItemUncheckAll = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItemCheckAll = new System.Windows.Forms.ToolStripMenuItem();
         this.contextMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // labelUsername
         // 
         this.labelUsername.AutoSize = true;
         this.labelUsername.Location = new System.Drawing.Point(0, 2);
         this.labelUsername.Name = "labelUsername";
         this.labelUsername.Size = new System.Drawing.Size(63, 13);
         this.labelUsername.TabIndex = 10;
         this.labelUsername.Text = "User Name:";
         // 
         // labelUserPassword
         // 
         this.labelUserPassword.AutoSize = true;
         this.labelUserPassword.Location = new System.Drawing.Point(0, 50);
         this.labelUserPassword.Name = "labelUserPassword";
         this.labelUserPassword.Size = new System.Drawing.Size(56, 13);
         this.labelUserPassword.TabIndex = 11;
         this.labelUserPassword.Text = "Password:";
         // 
         // textBoxUsername
         // 
         this.textBoxUsername.Location = new System.Drawing.Point(4, 21);
         this.textBoxUsername.Name = "textBoxUsername";
         this.textBoxUsername.Size = new System.Drawing.Size(276, 20);
         this.textBoxUsername.TabIndex = 12;
         // 
         // textBoxUserPassword
         // 
         this.textBoxUserPassword.Location = new System.Drawing.Point(4, 69);
         this.textBoxUserPassword.Name = "textBoxUserPassword";
         this.textBoxUserPassword.Size = new System.Drawing.Size(276, 20);
         this.textBoxUserPassword.TabIndex = 13;
         // 
         // checkedListBoxPermissions
         // 
         this.checkedListBoxPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
         this.checkedListBoxPermissions.ContextMenuStrip = this.contextMenuStrip;
         this.checkedListBoxPermissions.FormattingEnabled = true;
         this.checkedListBoxPermissions.Location = new System.Drawing.Point(4, 121);
         this.checkedListBoxPermissions.Name = "checkedListBoxPermissions";
         this.checkedListBoxPermissions.Size = new System.Drawing.Size(276, 214);
         this.checkedListBoxPermissions.TabIndex = 14;
         // 
         // labelPermissions
         // 
         this.labelPermissions.AutoSize = true;
         this.labelPermissions.Location = new System.Drawing.Point(1, 101);
         this.labelPermissions.Name = "labelPermissions";
         this.labelPermissions.Size = new System.Drawing.Size(62, 13);
         this.labelPermissions.TabIndex = 15;
         this.labelPermissions.Text = "Permissions";
         // 
         // checkedListBoxRoles
         // 
         this.checkedListBoxRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.checkedListBoxRoles.ContextMenuStrip = this.contextMenuStrip;
         this.checkedListBoxRoles.FormattingEnabled = true;
         this.checkedListBoxRoles.Location = new System.Drawing.Point(292, 121);
         this.checkedListBoxRoles.Name = "checkedListBoxRoles";
         this.checkedListBoxRoles.Size = new System.Drawing.Size(276, 214);
         this.checkedListBoxRoles.TabIndex = 16;
         // 
         // labelRoles
         // 
         this.labelRoles.AutoSize = true;
         this.labelRoles.Location = new System.Drawing.Point(289, 101);
         this.labelRoles.Name = "labelRoles";
         this.labelRoles.Size = new System.Drawing.Size(34, 13);
         this.labelRoles.TabIndex = 17;
         this.labelRoles.Text = "Roles";
         // 
         // comboBoxUserName
         // 
         this.comboBoxUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxUserName.FormattingEnabled = true;
         this.comboBoxUserName.Location = new System.Drawing.Point(329, 3);
         this.comboBoxUserName.Name = "comboBoxUserName";
         this.comboBoxUserName.Size = new System.Drawing.Size(121, 21);
         this.comboBoxUserName.TabIndex = 18;
         this.comboBoxUserName.VisibleChanged += new System.EventHandler(this.comboBoxUserName_VisibleChanged);
         // 
         // checkBoxUserPassword
         // 
         this.checkBoxUserPassword.AutoSize = true;
         this.checkBoxUserPassword.Location = new System.Drawing.Point(329, 51);
         this.checkBoxUserPassword.Name = "checkBoxUserPassword";
         this.checkBoxUserPassword.Size = new System.Drawing.Size(75, 17);
         this.checkBoxUserPassword.TabIndex = 19;
         this.checkBoxUserPassword.Text = "Password:";
         this.checkBoxUserPassword.UseVisualStyleBackColor = true;
         this.checkBoxUserPassword.CheckedChanged += new System.EventHandler(this.checkBoxUserPassword_CheckedChanged);
         // 
         // contextMenuStrip
         // 
         this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCheckAll,
            this.toolStripMenuItemUncheckAll});
         this.contextMenuStrip.Name = "contextMenuStrip";
         this.contextMenuStrip.Size = new System.Drawing.Size(138, 48);
         // 
         // toolStripMenuItemUncheckAll
         // 
         this.toolStripMenuItemUncheckAll.Name = "toolStripMenuItemUncheckAll";
         this.toolStripMenuItemUncheckAll.Size = new System.Drawing.Size(152, 22);
         this.toolStripMenuItemUncheckAll.Text = "Uncheck All";
         this.toolStripMenuItemUncheckAll.Click += new System.EventHandler(this.toolStripMenuItemUncheckAll_Click);
         // 
         // toolStripMenuItemCheckAll
         // 
         this.toolStripMenuItemCheckAll.Name = "toolStripMenuItemCheckAll";
         this.toolStripMenuItemCheckAll.Size = new System.Drawing.Size(152, 22);
         this.toolStripMenuItemCheckAll.Text = "Check All";
         this.toolStripMenuItemCheckAll.Click += new System.EventHandler(this.toolStripMenuItemCheckAll_Click);
         // 
         // UsersControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.checkBoxUserPassword);
         this.Controls.Add(this.comboBoxUserName);
         this.Controls.Add(this.labelRoles);
         this.Controls.Add(this.checkedListBoxRoles);
         this.Controls.Add(this.labelPermissions);
         this.Controls.Add(this.checkedListBoxPermissions);
         this.Controls.Add(this.textBoxUserPassword);
         this.Controls.Add(this.textBoxUsername);
         this.Controls.Add(this.labelUserPassword);
         this.Controls.Add(this.labelUsername);
         this.Name = "UsersControl";
         this.Size = new System.Drawing.Size(576, 343);
         this.contextMenuStrip.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label labelUsername;
      private System.Windows.Forms.Label labelUserPassword;
      private System.Windows.Forms.TextBox textBoxUsername;
      private System.Windows.Forms.TextBox textBoxUserPassword;
      private System.Windows.Forms.CheckedListBox checkedListBoxPermissions;
      private System.Windows.Forms.Label labelPermissions;
      private System.Windows.Forms.CheckedListBox checkedListBoxRoles;
      private System.Windows.Forms.Label labelRoles;
      private System.Windows.Forms.ComboBox comboBoxUserName;
      private System.Windows.Forms.CheckBox checkBoxUserPassword;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCheckAll;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemUncheckAll;


   }
}
