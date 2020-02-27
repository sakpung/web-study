namespace Leadtools.Medical.Winforms
{
   partial class UsersAccounts
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
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
         System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersAccounts));
         this.UsersBindingSource = new System.Windows.Forms.BindingSource(this.components);
         this.UsersSourceDataset = new Leadtools.Medical.Winforms.UsersSource();
         this.ContainerGroupBox = new System.Windows.Forms.GroupBox();
         this.UsersDataGridView = new System.Windows.Forms.DataGridView();
         this.UserNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.AdministratorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
         this.NewPasswordDataGridViewButtonColumn = new System.Windows.Forms.DataGridViewLinkColumn();
         this.BottomPanel = new System.Windows.Forms.Panel();
         this.SeparatorSeparator = new System.Windows.Forms.GroupBox();
         this.SaveChangesButton = new System.Windows.Forms.Button();
         this.UsersToolStrip = new System.Windows.Forms.ToolStrip();
         this.AddUserToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.DeleteUserToolStripButton = new System.Windows.Forms.ToolStripButton();
         ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.UsersSourceDataset)).BeginInit();
         this.ContainerGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
         this.BottomPanel.SuspendLayout();
         this.UsersToolStrip.SuspendLayout();
         this.SuspendLayout();
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
         // ContainerGroupBox
         // 
         this.ContainerGroupBox.Controls.Add(this.UsersDataGridView);
         this.ContainerGroupBox.Controls.Add(this.BottomPanel);
         this.ContainerGroupBox.Controls.Add(this.UsersToolStrip);
         this.ContainerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ContainerGroupBox.ForeColor = System.Drawing.Color.Gold;
         this.ContainerGroupBox.Location = new System.Drawing.Point(0, 0);
         this.ContainerGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.ContainerGroupBox.Name = "ContainerGroupBox";
         this.ContainerGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.ContainerGroupBox.Size = new System.Drawing.Size(569, 465);
         this.ContainerGroupBox.TabIndex = 0;
         this.ContainerGroupBox.TabStop = false;
         this.ContainerGroupBox.Text = "User Accounts";
         // 
         // UsersDataGridView
         // 
         this.UsersDataGridView.AllowUserToAddRows = false;
         dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
         this.UsersDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
         this.UsersDataGridView.AutoGenerateColumns = false;
         this.UsersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
         this.UsersDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
         dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke;
         dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8F);
         dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightGray;
         dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.UsersDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
         this.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
         this.UsersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserNameDataGridViewTextBoxColumn,
            this.AdministratorDataGridViewCheckBoxColumn,
            this.NewPasswordDataGridViewButtonColumn});
         this.UsersDataGridView.DataSource = this.UsersBindingSource;
         dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
         dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Gold;
         dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
         dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
         this.UsersDataGridView.DefaultCellStyle = dataGridViewCellStyle10;
         this.UsersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.UsersDataGridView.EnableHeadersVisualStyles = false;
         this.UsersDataGridView.GridColor = System.Drawing.Color.White;
         this.UsersDataGridView.Location = new System.Drawing.Point(3, 54);
         this.UsersDataGridView.MultiSelect = false;
         this.UsersDataGridView.Name = "UsersDataGridView";
         dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
         dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
         dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8F);
         dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
         dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.LightGray;
         dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
         dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
         this.UsersDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
         this.UsersDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
         dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
         dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
         dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
         dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
         this.UsersDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
         this.UsersDataGridView.RowTemplate.Height = 26;
         this.UsersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.UsersDataGridView.Size = new System.Drawing.Size(563, 343);
         this.UsersDataGridView.TabIndex = 11;
         // 
         // UserNameDataGridViewTextBoxColumn
         // 
         this.UserNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
         this.UserNameDataGridViewTextBoxColumn.FillWeight = 127.1574F;
         this.UserNameDataGridViewTextBoxColumn.HeaderText = "User Name";
         this.UserNameDataGridViewTextBoxColumn.Name = "UserNameDataGridViewTextBoxColumn";
         this.UserNameDataGridViewTextBoxColumn.ReadOnly = true;
         // 
         // AdministratorDataGridViewCheckBoxColumn
         // 
         this.AdministratorDataGridViewCheckBoxColumn.DataPropertyName = "IsAdmin";
         this.AdministratorDataGridViewCheckBoxColumn.HeaderText = "Administrator";
         this.AdministratorDataGridViewCheckBoxColumn.Name = "AdministratorDataGridViewCheckBoxColumn";
         // 
         // NewPasswordDataGridViewButtonColumn
         // 
         this.NewPasswordDataGridViewButtonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
         this.NewPasswordDataGridViewButtonColumn.DataPropertyName = "NewPassword";
         dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
         dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
         dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DarkGray;
         dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
         this.NewPasswordDataGridViewButtonColumn.DefaultCellStyle = dataGridViewCellStyle9;
         this.NewPasswordDataGridViewButtonColumn.HeaderText = "New Password";
         this.NewPasswordDataGridViewButtonColumn.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
         this.NewPasswordDataGridViewButtonColumn.Name = "NewPasswordDataGridViewButtonColumn";
         this.NewPasswordDataGridViewButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         this.NewPasswordDataGridViewButtonColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
         this.NewPasswordDataGridViewButtonColumn.TrackVisitedState = false;
         this.NewPasswordDataGridViewButtonColumn.Width = 102;
         // 
         // BottomPanel
         // 
         this.BottomPanel.Controls.Add(this.SeparatorSeparator);
         this.BottomPanel.Controls.Add(this.SaveChangesButton);
         this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.BottomPanel.Location = new System.Drawing.Point(3, 397);
         this.BottomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.BottomPanel.Name = "BottomPanel";
         this.BottomPanel.Size = new System.Drawing.Size(563, 66);
         this.BottomPanel.TabIndex = 12;
         // 
         // SeparatorSeparator
         // 
         this.SeparatorSeparator.Dock = System.Windows.Forms.DockStyle.Top;
         this.SeparatorSeparator.Location = new System.Drawing.Point(0, 0);
         this.SeparatorSeparator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.SeparatorSeparator.Name = "SeparatorSeparator";
         this.SeparatorSeparator.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.SeparatorSeparator.Size = new System.Drawing.Size(563, 2);
         this.SeparatorSeparator.TabIndex = 5;
         this.SeparatorSeparator.TabStop = false;
         // 
         // SaveChangesButton
         // 
         this.SaveChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.SaveChangesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
         this.SaveChangesButton.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
         this.SaveChangesButton.ForeColor = System.Drawing.Color.White;
         this.SaveChangesButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveChangesButton.Image")));
         this.SaveChangesButton.Location = new System.Drawing.Point(500, 3);
         this.SaveChangesButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.SaveChangesButton.Name = "SaveChangesButton";
         this.SaveChangesButton.Size = new System.Drawing.Size(58, 58);
         this.SaveChangesButton.TabIndex = 4;
         this.SaveChangesButton.UseVisualStyleBackColor = false;
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
         this.UsersToolStrip.Size = new System.Drawing.Size(563, 39);
         this.UsersToolStrip.Stretch = true;
         this.UsersToolStrip.TabIndex = 10;
         // 
         // AddUserToolStripButton
         // 
         this.AddUserToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.AddUserToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("AddUserToolStripButton.Image")));
         this.AddUserToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.AddUserToolStripButton.Name = "AddUserToolStripButton";
         this.AddUserToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.AddUserToolStripButton.Text = "Add User";
         // 
         // DeleteUserToolStripButton
         // 
         this.DeleteUserToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.DeleteUserToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteUserToolStripButton.Image")));
         this.DeleteUserToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.DeleteUserToolStripButton.Name = "DeleteUserToolStripButton";
         this.DeleteUserToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.DeleteUserToolStripButton.Text = "Delete User";
         // 
         // UsersAccounts
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
         this.Controls.Add(this.ContainerGroupBox);
         this.ForeColor = System.Drawing.Color.White;
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "UsersAccounts";
         this.Size = new System.Drawing.Size(569, 465);
         ((System.ComponentModel.ISupportInitialize)(this.UsersBindingSource)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.UsersSourceDataset)).EndInit();
         this.ContainerGroupBox.ResumeLayout(false);
         this.ContainerGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).EndInit();
         this.BottomPanel.ResumeLayout(false);
         this.UsersToolStrip.ResumeLayout(false);
         this.UsersToolStrip.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      protected System.Windows.Forms.BindingSource UsersBindingSource;
      protected System.Windows.Forms.GroupBox ContainerGroupBox;
      protected System.Windows.Forms.DataGridView UsersDataGridView;
      protected System.Windows.Forms.ToolStrip UsersToolStrip;
      protected System.Windows.Forms.ToolStripButton AddUserToolStripButton;
      protected System.Windows.Forms.ToolStripButton DeleteUserToolStripButton;
      protected System.Windows.Forms.Panel BottomPanel;
      protected System.Windows.Forms.GroupBox SeparatorSeparator;
      protected System.Windows.Forms.Button SaveChangesButton;
      protected System.Windows.Forms.DataGridViewTextBoxColumn UserNameDataGridViewTextBoxColumn;
      protected System.Windows.Forms.DataGridViewCheckBoxColumn AdministratorDataGridViewCheckBoxColumn;
      protected System.Windows.Forms.DataGridViewLinkColumn NewPasswordDataGridViewButtonColumn;
      private Leadtools.Medical.Winforms.UsersSource UsersSourceDataset;

   }
}
