namespace Leadtools.Demos.StorageServer.UI
{
   partial class RolesView
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.comboBoxRoles = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.listViewPermissions = new System.Windows.Forms.ListView();
         this.buttonAdd = new System.Windows.Forms.Button();
         this.buttonDelete = new System.Windows.Forms.Button();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.buttonDelete);
         this.groupBox1.Controls.Add(this.buttonAdd);
         this.groupBox1.Controls.Add(this.listViewPermissions);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.comboBoxRoles);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox1.Size = new System.Drawing.Size(514, 537);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Roles";
         // 
         // comboBoxRoles
         // 
         this.comboBoxRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxRoles.FormattingEnabled = true;
         this.comboBoxRoles.Location = new System.Drawing.Point(10, 44);
         this.comboBoxRoles.Name = "comboBoxRoles";
         this.comboBoxRoles.Size = new System.Drawing.Size(221, 21);
         this.comboBoxRoles.TabIndex = 0;
         this.comboBoxRoles.SelectionChangeCommitted += new System.EventHandler(this.comboBoxRoles_SelectionChangeCommitted);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(7, 28);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(32, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Role:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(7, 73);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(65, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Permissions:";
         // 
         // listViewPermissions
         // 
         this.listViewPermissions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)));
         this.listViewPermissions.CheckBoxes = true;
         this.listViewPermissions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
         this.listViewPermissions.FullRowSelect = true;
         this.listViewPermissions.Location = new System.Drawing.Point(10, 89);
         this.listViewPermissions.MultiSelect = false;
         this.listViewPermissions.Name = "listViewPermissions";
         this.listViewPermissions.Size = new System.Drawing.Size(284, 443);
         this.listViewPermissions.TabIndex = 3;
         this.listViewPermissions.UseCompatibleStateImageBehavior = false;
         this.listViewPermissions.View = System.Windows.Forms.View.Details;
         this.listViewPermissions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewPermissions_ItemChecked);
         // 
         // buttonAdd
         // 
         this.buttonAdd.Image = global::Leadtools.Demos.StorageServer.Properties.Resources.Add_16x16;
         this.buttonAdd.Location = new System.Drawing.Point(231, 42);
         this.buttonAdd.Name = "buttonAdd";
         this.buttonAdd.Size = new System.Drawing.Size(32, 23);
         this.buttonAdd.TabIndex = 4;
         this.buttonAdd.UseVisualStyleBackColor = true;
         this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
         // 
         // buttonDelete
         // 
         this.buttonDelete.Image = global::Leadtools.Demos.StorageServer.Properties.Resources.Remove_16x16;
         this.buttonDelete.Location = new System.Drawing.Point(262, 42);
         this.buttonDelete.Name = "buttonDelete";
         this.buttonDelete.Size = new System.Drawing.Size(32, 23);
         this.buttonDelete.TabIndex = 5;
         this.buttonDelete.UseVisualStyleBackColor = true;
         this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "Permission";
         // 
         // RolesView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox1);
         this.Name = "RolesView";
         this.Size = new System.Drawing.Size(514, 537);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ListView listViewPermissions;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox comboBoxRoles;
      private System.Windows.Forms.Button buttonDelete;
      private System.Windows.Forms.Button buttonAdd;
      private System.Windows.Forms.ColumnHeader columnHeader1;
   }
}
