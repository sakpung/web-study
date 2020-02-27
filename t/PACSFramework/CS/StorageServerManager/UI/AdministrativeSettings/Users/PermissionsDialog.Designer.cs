namespace Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users
{
   partial class PermissionsDialog
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
         this.panel1 = new System.Windows.Forms.Panel();
         this.label3 = new System.Windows.Forms.Label();
         this.button2 = new System.Windows.Forms.Button();
         this.button1 = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this.listViewPermissions = new System.Windows.Forms.ListView();
         this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.label2 = new System.Windows.Forms.Label();
         this.listViewRoles = new System.Windows.Forms.ListView();
         this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.panel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.label3);
         this.panel1.Controls.Add(this.button2);
         this.panel1.Controls.Add(this.button1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel1.Location = new System.Drawing.Point(0, 411);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(451, 49);
         this.panel1.TabIndex = 0;
         // 
         // label3
         // 
         this.label3.ForeColor = System.Drawing.Color.Red;
         this.label3.Location = new System.Drawing.Point(16, 12);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(261, 37);
         this.label3.TabIndex = 2;
         this.label3.Text = "Grayed permissions belong to a role and cannot be modified.";
         // 
         // button2
         // 
         this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button2.Location = new System.Drawing.Point(283, 14);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 1;
         this.button2.Text = "OK";
         this.button2.UseVisualStyleBackColor = true;
         // 
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button1.Location = new System.Drawing.Point(364, 14);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 0;
         this.button1.Text = "Cancel";
         this.button1.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 111);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(124, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Modify User Permissions:";
         // 
         // listViewPermissions
         // 
         this.listViewPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewPermissions.CheckBoxes = true;
         this.listViewPermissions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
         this.listViewPermissions.FullRowSelect = true;
         this.listViewPermissions.Location = new System.Drawing.Point(16, 127);
         this.listViewPermissions.Name = "listViewPermissions";
         this.listViewPermissions.Size = new System.Drawing.Size(423, 278);
         this.listViewPermissions.TabIndex = 2;
         this.listViewPermissions.UseCompatibleStateImageBehavior = false;
         this.listViewPermissions.View = System.Windows.Forms.View.Details;
         this.listViewPermissions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listViewPermissions_ItemCheck);
         this.listViewPermissions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewPermissions_ItemChecked);
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Permission";
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "Description";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 9);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(37, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Roles:";
         // 
         // listViewRoles
         // 
         this.listViewRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.listViewRoles.CheckBoxes = true;
         this.listViewRoles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
         this.listViewRoles.FullRowSelect = true;
         this.listViewRoles.Location = new System.Drawing.Point(16, 25);
         this.listViewRoles.Name = "listViewRoles";
         this.listViewRoles.Size = new System.Drawing.Size(423, 83);
         this.listViewRoles.TabIndex = 4;
         this.listViewRoles.UseCompatibleStateImageBehavior = false;
         this.listViewRoles.View = System.Windows.Forms.View.SmallIcon;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Role";
         this.columnHeader3.Width = 414;
         // 
         // PermissionsDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(451, 460);
         this.Controls.Add(this.listViewRoles);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.listViewPermissions);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.panel1);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PermissionsDialog";
         this.ShowIcon = false;
         this.Text = "Edit Permissions";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PermissionsDialog_FormClosing);
         this.Load += new System.EventHandler(this.PermissionsDialog_Load);
         this.panel1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Button button2;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ListView listViewPermissions;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ListView listViewRoles;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.Label label3;
   }
}