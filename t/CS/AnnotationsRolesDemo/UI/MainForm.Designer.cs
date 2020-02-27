namespace AnnotationsRolesDemo
{
   partial class MainForm
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
            CleanUp(disposing);
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this._tbAdminPage = new System.Windows.Forms.TabPage();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this._btnDeleteUser = new System.Windows.Forms.Button();
         this._btnSave = new System.Windows.Forms.Button();
         this._btnLoad = new System.Windows.Forms.Button();
         this._chkLstGroups = new System.Windows.Forms.CheckedListBox();
         this._btnAddUser = new System.Windows.Forms.Button();
         this._lstUsers = new System.Windows.Forms.ListBox();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._btnDeleteGroup = new System.Windows.Forms.Button();
         this._chkLstRoles = new System.Windows.Forms.CheckedListBox();
         this._btnAddGroup = new System.Windows.Forms.Button();
         this._lstGroups = new System.Windows.Forms.ListBox();
         this._tbAnnotationsPage = new System.Windows.Forms.TabPage();
         this.panel1 = new System.Windows.Forms.Panel();
         this._btnLoadAnnotations = new System.Windows.Forms.Button();
         this._btnSaveAnnotations = new System.Windows.Forms.Button();
         this._cmbUsers = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.tabControl1.SuspendLayout();
         this._tbAdminPage.SuspendLayout();
         this.groupBox3.SuspendLayout();
         this.groupBox2.SuspendLayout();
         this._tbAnnotationsPage.SuspendLayout();
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this._tbAdminPage);
         this.tabControl1.Controls.Add(this._tbAnnotationsPage);
         this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tabControl1.Location = new System.Drawing.Point(0, 0);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(850, 521);
         this.tabControl1.TabIndex = 0;
         // 
         // _tbAdminPage
         // 
         this._tbAdminPage.Controls.Add(this.groupBox3);
         this._tbAdminPage.Controls.Add(this.groupBox2);
         this._tbAdminPage.Location = new System.Drawing.Point(4, 22);
         this._tbAdminPage.Name = "_tbAdminPage";
         this._tbAdminPage.Padding = new System.Windows.Forms.Padding(3);
         this._tbAdminPage.Size = new System.Drawing.Size(842, 495);
         this._tbAdminPage.TabIndex = 0;
         this._tbAdminPage.Text = "Administrator";
         this._tbAdminPage.UseVisualStyleBackColor = true;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this._btnDeleteUser);
         this.groupBox3.Controls.Add(this._btnSave);
         this.groupBox3.Controls.Add(this._btnLoad);
         this.groupBox3.Controls.Add(this._chkLstGroups);
         this.groupBox3.Controls.Add(this._btnAddUser);
         this.groupBox3.Controls.Add(this._lstUsers);
         this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox3.Location = new System.Drawing.Point(424, 3);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(415, 489);
         this.groupBox3.TabIndex = 4;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Users";
         // 
         // _btnDeleteUser
         // 
         this._btnDeleteUser.Location = new System.Drawing.Point(87, 198);
         this._btnDeleteUser.Name = "_btnDeleteUser";
         this._btnDeleteUser.Size = new System.Drawing.Size(80, 20);
         this._btnDeleteUser.TabIndex = 9;
         this._btnDeleteUser.Text = "Delete U&ser";
         this._btnDeleteUser.UseVisualStyleBackColor = true;
         this._btnDeleteUser.Click += new System.EventHandler(this._btnDeleteUser_Click);
         // 
         // _btnSave
         // 
         this._btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnSave.Location = new System.Drawing.Point(326, 461);
         this._btnSave.Name = "_btnSave";
         this._btnSave.Size = new System.Drawing.Size(75, 23);
         this._btnSave.TabIndex = 8;
         this._btnSave.Text = "&Save";
         this._btnSave.UseVisualStyleBackColor = true;
         this._btnSave.Click += new System.EventHandler(this._btnSave_Click);
         // 
         // _btnLoad
         // 
         this._btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnLoad.Location = new System.Drawing.Point(245, 461);
         this._btnLoad.Name = "_btnLoad";
         this._btnLoad.Size = new System.Drawing.Size(75, 23);
         this._btnLoad.TabIndex = 7;
         this._btnLoad.Text = "&Load";
         this._btnLoad.UseVisualStyleBackColor = true;
         this._btnLoad.Click += new System.EventHandler(this._btnLoad_Click);
         // 
         // _chkLstGroups
         // 
         this._chkLstGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._chkLstGroups.FormattingEnabled = true;
         this._chkLstGroups.Location = new System.Drawing.Point(14, 229);
         this._chkLstGroups.Name = "_chkLstGroups";
         this._chkLstGroups.Size = new System.Drawing.Size(387, 214);
         this._chkLstGroups.TabIndex = 6;
         // 
         // _btnAddUser
         // 
         this._btnAddUser.Location = new System.Drawing.Point(14, 198);
         this._btnAddUser.Name = "_btnAddUser";
         this._btnAddUser.Size = new System.Drawing.Size(67, 20);
         this._btnAddUser.TabIndex = 5;
         this._btnAddUser.Text = "Add &User";
         this._btnAddUser.UseVisualStyleBackColor = true;
         this._btnAddUser.Click += new System.EventHandler(this._btnAddUser_Click);
         // 
         // _lstUsers
         // 
         this._lstUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._lstUsers.FormattingEnabled = true;
         this._lstUsers.Location = new System.Drawing.Point(14, 19);
         this._lstUsers.Name = "_lstUsers";
         this._lstUsers.Size = new System.Drawing.Size(387, 173);
         this._lstUsers.TabIndex = 4;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this._btnDeleteGroup);
         this.groupBox2.Controls.Add(this._chkLstRoles);
         this.groupBox2.Controls.Add(this._btnAddGroup);
         this.groupBox2.Controls.Add(this._lstGroups);
         this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
         this.groupBox2.Location = new System.Drawing.Point(3, 3);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(421, 489);
         this.groupBox2.TabIndex = 3;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Groups";
         // 
         // _btnDeleteGroup
         // 
         this._btnDeleteGroup.Location = new System.Drawing.Point(129, 198);
         this._btnDeleteGroup.Name = "_btnDeleteGroup";
         this._btnDeleteGroup.Size = new System.Drawing.Size(105, 20);
         this._btnDeleteGroup.TabIndex = 6;
         this._btnDeleteGroup.Text = "Delete G&roup";
         this._btnDeleteGroup.UseVisualStyleBackColor = true;
         this._btnDeleteGroup.Click += new System.EventHandler(this._btnDeleteGroup_Click);
         // 
         // _chkLstRoles
         // 
         this._chkLstRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._chkLstRoles.FormattingEnabled = true;
         this._chkLstRoles.Location = new System.Drawing.Point(10, 229);
         this._chkLstRoles.Name = "_chkLstRoles";
         this._chkLstRoles.Size = new System.Drawing.Size(403, 214);
         this._chkLstRoles.TabIndex = 5;
         // 
         // _btnAddGroup
         // 
         this._btnAddGroup.Location = new System.Drawing.Point(10, 198);
         this._btnAddGroup.Name = "_btnAddGroup";
         this._btnAddGroup.Size = new System.Drawing.Size(67, 20);
         this._btnAddGroup.TabIndex = 4;
         this._btnAddGroup.Text = "Add &Group";
         this._btnAddGroup.UseVisualStyleBackColor = true;
         this._btnAddGroup.Click += new System.EventHandler(this._btnAddGroup_Click);
         // 
         // _lstGroups
         // 
         this._lstGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._lstGroups.FormattingEnabled = true;
         this._lstGroups.Location = new System.Drawing.Point(10, 19);
         this._lstGroups.Name = "_lstGroups";
         this._lstGroups.Size = new System.Drawing.Size(403, 173);
         this._lstGroups.TabIndex = 3;
         // 
         // _tbAnnotationsPage
         // 
         this._tbAnnotationsPage.Controls.Add(this.panel1);
         this._tbAnnotationsPage.Location = new System.Drawing.Point(4, 22);
         this._tbAnnotationsPage.Name = "_tbAnnotationsPage";
         this._tbAnnotationsPage.Padding = new System.Windows.Forms.Padding(3);
         this._tbAnnotationsPage.Size = new System.Drawing.Size(842, 495);
         this._tbAnnotationsPage.TabIndex = 1;
         this._tbAnnotationsPage.Text = "Annotations";
         this._tbAnnotationsPage.UseVisualStyleBackColor = true;
         this._tbAnnotationsPage.Enter += new System.EventHandler(this._tbAnnotationsPage_Enter);
         this._tbAnnotationsPage.DragEnter += new System.Windows.Forms.DragEventHandler(this._tbAnnotationsPage_DragEnter);
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this._btnLoadAnnotations);
         this.panel1.Controls.Add(this._btnSaveAnnotations);
         this.panel1.Controls.Add(this._cmbUsers);
         this.panel1.Controls.Add(this.label1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(3, 3);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(836, 51);
         this.panel1.TabIndex = 0;
         // 
         // _btnLoadAnnotations
         // 
         this._btnLoadAnnotations.Location = new System.Drawing.Point(315, 16);
         this._btnLoadAnnotations.Name = "_btnLoadAnnotations";
         this._btnLoadAnnotations.Size = new System.Drawing.Size(75, 23);
         this._btnLoadAnnotations.TabIndex = 2;
         this._btnLoadAnnotations.Text = "&Load";
         this._btnLoadAnnotations.UseVisualStyleBackColor = true;
         this._btnLoadAnnotations.Click += new System.EventHandler(this._btnLoadAnnotations_Click);
         // 
         // _btnSaveAnnotations
         // 
         this._btnSaveAnnotations.Location = new System.Drawing.Point(224, 16);
         this._btnSaveAnnotations.Name = "_btnSaveAnnotations";
         this._btnSaveAnnotations.Size = new System.Drawing.Size(75, 23);
         this._btnSaveAnnotations.TabIndex = 1;
         this._btnSaveAnnotations.Text = "&Save";
         this._btnSaveAnnotations.UseVisualStyleBackColor = true;
         this._btnSaveAnnotations.Click += new System.EventHandler(this._btnSaveAnnotations_Click);
         // 
         // _cmbUsers
         // 
         this._cmbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbUsers.FormattingEnabled = true;
         this._cmbUsers.Location = new System.Drawing.Point(83, 16);
         this._cmbUsers.Name = "_cmbUsers";
         this._cmbUsers.Size = new System.Drawing.Size(121, 21);
         this._cmbUsers.TabIndex = 1;
         this._cmbUsers.SelectedIndexChanged += new System.EventHandler(this._cmbUsers_SelectedIndexChanged);
         this._cmbUsers.SelectedValueChanged += new System.EventHandler(this._cmbUsers_SelectedValueChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(10, 19);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(67, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Current user:";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(850, 521);
         this.Controls.Add(this.tabControl1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Form1";
         this.tabControl1.ResumeLayout(false);
         this._tbAdminPage.ResumeLayout(false);
         this.groupBox3.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this._tbAnnotationsPage.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage _tbAdminPage;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TabPage _tbAnnotationsPage;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.Button _btnAddUser;
      private System.Windows.Forms.ListBox _lstUsers;
      private System.Windows.Forms.Button _btnAddGroup;
      private System.Windows.Forms.ListBox _lstGroups;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.ComboBox _cmbUsers;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.CheckedListBox _chkLstRoles;
      private System.Windows.Forms.CheckedListBox _chkLstGroups;
      private System.Windows.Forms.Button _btnSave;
      private System.Windows.Forms.Button _btnLoad;
      private System.Windows.Forms.Button _btnDeleteUser;
      private System.Windows.Forms.Button _btnDeleteGroup;
      private System.Windows.Forms.Button _btnSaveAnnotations;
      private System.Windows.Forms.Button _btnLoadAnnotations;
   }
}

