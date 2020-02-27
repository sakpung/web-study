using Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users;
namespace Leadtools.Demos.StorageServer.UI
{
   partial class UsersAccountView
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
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
         this.ContainerGroupBox = new System.Windows.Forms.GroupBox();
         this.UsersDataGridView = new System.Windows.Forms.DataGridView();
         this.UsersToolStrip = new System.Windows.Forms.ToolStrip();
         this.AddUserToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.DeleteUserToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.UsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.UsersSourceDataset = new Leadtools.Demos.StorageServer.UI.AdministrativeSettings.Users.UsersSource();
         this.UserNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.FriendlyNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.NewPasswordDataGridViewButtonColumn = new System.Windows.Forms.DataGridViewLinkColumn();
         this.ExpiresColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Permissions = new System.Windows.Forms.DataGridViewLinkColumn();
         this.ContainerGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
         this.UsersToolStrip.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.UsersSourceDataset)).BeginInit();
         this.SuspendLayout();
         // 
         // ContainerGroupBox
         // 
         this.ContainerGroupBox.Controls.Add(this.UsersDataGridView);
         this.ContainerGroupBox.Controls.Add(this.UsersToolStrip);
         this.ContainerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ContainerGroupBox.ForeColor = System.Drawing.Color.Gold;
         this.ContainerGroupBox.Location = new System.Drawing.Point(0, 0);
         this.ContainerGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.ContainerGroupBox.Name = "ContainerGroupBox";
         this.ContainerGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.ContainerGroupBox.Size = new System.Drawing.Size(725, 465);
         this.ContainerGroupBox.TabIndex = 0;
         this.ContainerGroupBox.TabStop = false;
         this.ContainerGroupBox.Text = "User Accounts";
         // 
         // UsersDataGridView
         // 
         this.UsersDataGridView.AllowUserToAddRows = false;
         dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
         this.UsersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
         this.UsersDataGridView.AutoGenerateColumns = false;
         this.UsersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.UsersDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
         dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
         dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
         dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
         dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.UsersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
         this.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
         this.UsersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserNameDataGridViewTextBoxColumn,
            this.FriendlyNameColumn,
            this.NewPasswordDataGridViewButtonColumn,
            this.ExpiresColumn,
            this.Permissions});
         this.UsersDataGridView.DataSource = this.UsersBindingSource;
         dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
         dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Gold;
         dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
         this.UsersDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
         this.UsersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.UsersDataGridView.EnableHeadersVisualStyles = false;
         this.UsersDataGridView.GridColor = System.Drawing.Color.White;
         this.UsersDataGridView.Location = new System.Drawing.Point(3, 54);
         this.UsersDataGridView.MultiSelect = false;
         this.UsersDataGridView.Name = "UsersDataGridView";
         dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
         dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8F);
         dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightGray;
         dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.UsersDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
         this.UsersDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
         dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
         dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
         dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
         dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
         this.UsersDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
         this.UsersDataGridView.RowTemplate.Height = 26;
         this.UsersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.UsersDataGridView.Size = new System.Drawing.Size(719, 409);
         this.UsersDataGridView.TabIndex = 11;
         // 
         // UsersToolStrip
         // 
         this.UsersToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.UsersToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.UsersToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddUserToolStripButton,
            this.DeleteUserToolStripButton});
         this.UsersToolStrip.Location = new System.Drawing.Point(3, 15);
         this.UsersToolStrip.Name = "UsersToolStrip";
         this.UsersToolStrip.Size = new System.Drawing.Size(719, 39);
         this.UsersToolStrip.Stretch = true;
         this.UsersToolStrip.TabIndex = 10;
         // 
         // AddUserToolStripButton
         // 
         this.AddUserToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.AddUserToolStripButton.Image = global::Leadtools.Demos.StorageServer.Properties.Resources.UserAdd;
         this.AddUserToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.AddUserToolStripButton.Name = "AddUserToolStripButton";
         this.AddUserToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.AddUserToolStripButton.Text = "Add User";
         // 
         // DeleteUserToolStripButton
         // 
         this.DeleteUserToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.DeleteUserToolStripButton.Image = global::Leadtools.Demos.StorageServer.Properties.Resources.UserDelete;
         this.DeleteUserToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.DeleteUserToolStripButton.Name = "DeleteUserToolStripButton";
         this.DeleteUserToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.DeleteUserToolStripButton.Text = "Delete User";
         // 
         // UsersBindingSource
         // 
         this.UsersBindingSource.DataMember = "Users";
         this.UsersBindingSource.DataSource = this.UsersSourceDataset;
         // 
         // UsersSourceDataset
         // 
         this.UsersSourceDataset.DataSetName = "UsersSource";
         this.UsersSourceDataset.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
         // 
         // UserNameDataGridViewTextBoxColumn
         // 
         this.UserNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.UserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
         this.UserNameDataGridViewTextBoxColumn.FillWeight = 127.1574F;
         this.UserNameDataGridViewTextBoxColumn.HeaderText = "Edi Number";
         this.UserNameDataGridViewTextBoxColumn.Name = "UserNameDataGridViewTextBoxColumn";
         this.UserNameDataGridViewTextBoxColumn.ReadOnly = true;
         this.UserNameDataGridViewTextBoxColumn.Width = 86;
         // 
         // FriendlyNameColumn
         // 
         this.FriendlyNameColumn.DataPropertyName = "FriendlyName";
         this.FriendlyNameColumn.HeaderText = "Alias";
         this.FriendlyNameColumn.Name = "FriendlyNameColumn";
         // 
         // NewPasswordDataGridViewButtonColumn
         // 
         this.NewPasswordDataGridViewButtonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
         this.NewPasswordDataGridViewButtonColumn.DataPropertyName = "NewPassword";
         dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
         dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
         dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
         dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
         this.NewPasswordDataGridViewButtonColumn.DefaultCellStyle = dataGridViewCellStyle3;
         this.NewPasswordDataGridViewButtonColumn.HeaderText = "New Password";
         this.NewPasswordDataGridViewButtonColumn.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
         this.NewPasswordDataGridViewButtonColumn.Name = "NewPasswordDataGridViewButtonColumn";
         this.NewPasswordDataGridViewButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         this.NewPasswordDataGridViewButtonColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
         this.NewPasswordDataGridViewButtonColumn.TrackVisitedState = false;
         this.NewPasswordDataGridViewButtonColumn.Width = 102;
         // 
         // ExpiresColumn
         // 
         this.ExpiresColumn.DataPropertyName = "Expires";
         this.ExpiresColumn.HeaderText = "Password Expires";
         this.ExpiresColumn.Name = "ExpiresColumn";
         this.ExpiresColumn.ReadOnly = true;
         // 
         // Permissions
         // 
         this.Permissions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
         this.Permissions.HeaderText = "Permissions";
         this.Permissions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
         this.Permissions.Name = "Permissions";
         this.Permissions.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         this.Permissions.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
         this.Permissions.TrackVisitedState = false;
         this.Permissions.Width = 87;
         // 
         // UsersAccountView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
         this.Controls.Add(this.ContainerGroupBox);
         this.ForeColor = System.Drawing.Color.White;
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "UsersAccountView";
         this.Size = new System.Drawing.Size(725, 465);
         this.ContainerGroupBox.ResumeLayout(false);
         this.ContainerGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).EndInit();
         this.UsersToolStrip.ResumeLayout(false);
         this.UsersToolStrip.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.UsersSourceDataset)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      protected System.Windows.Forms.BindingSource UsersBindingSource;
      protected System.Windows.Forms.GroupBox ContainerGroupBox;
      protected System.Windows.Forms.DataGridView UsersDataGridView;
      protected System.Windows.Forms.ToolStrip UsersToolStrip;
      protected System.Windows.Forms.ToolStripButton AddUserToolStripButton;
      protected System.Windows.Forms.ToolStripButton DeleteUserToolStripButton;
      private UsersSource UsersSourceDataset;
      private System.Windows.Forms.DataGridViewTextBoxColumn UserNameDataGridViewTextBoxColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn FriendlyNameColumn;
      private System.Windows.Forms.DataGridViewLinkColumn NewPasswordDataGridViewButtonColumn;
      private System.Windows.Forms.DataGridViewTextBoxColumn ExpiresColumn;
      private System.Windows.Forms.DataGridViewLinkColumn Permissions;

   }
}
