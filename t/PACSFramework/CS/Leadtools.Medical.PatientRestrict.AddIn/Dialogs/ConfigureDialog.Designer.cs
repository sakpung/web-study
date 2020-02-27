namespace Leadtools.Medical.PatientRestrict.AddIn.Dialogs
{
   partial class ConfigureDialog
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
         this.groupBoxClients = new System.Windows.Forms.GroupBox();
         this.groupBoxSearch = new System.Windows.Forms.GroupBox();
         this.buttonSearchClear = new System.Windows.Forms.Button();
         this.labelAlias = new System.Windows.Forms.Label();
         this.labelAeTitle = new System.Windows.Forms.Label();
         this.textBoxRole = new System.Windows.Forms.TextBox();
         this.textBoxAeTitle = new System.Windows.Forms.TextBox();
         this.paginationControl1 = new Leadtools.Medical.Winforms.PaginationControl();
         this.clientToolStrip = new System.Windows.Forms.ToolStrip();
         this.AddClientToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.ModifyClientToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.DeleteClienteToolStripButton = new System.Windows.Forms.ToolStripButton();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.ColumnAeTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.ColumnRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.checkBoxEnablePatientRestrict = new System.Windows.Forms.CheckBox();
         this.helpProvider1 = new System.Windows.Forms.HelpProvider();
         this.buttonApply = new System.Windows.Forms.Button();
         this.groupBoxClients.SuspendLayout();
         this.groupBoxSearch.SuspendLayout();
         this.clientToolStrip.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(453, 507);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 3;
         this.buttonCancel.Text = "&Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(370, 507);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 2;
         this.buttonOK.Text = "&OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
         // 
         // groupBoxClients
         // 
         this.groupBoxClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxClients.Controls.Add(this.groupBoxSearch);
         this.groupBoxClients.Controls.Add(this.paginationControl1);
         this.groupBoxClients.Controls.Add(this.clientToolStrip);
         this.groupBoxClients.Controls.Add(this.dataGridView1);
         this.groupBoxClients.Location = new System.Drawing.Point(12, 36);
         this.groupBoxClients.Name = "groupBoxClients";
         this.groupBoxClients.Size = new System.Drawing.Size(600, 460);
         this.groupBoxClients.TabIndex = 1;
         this.groupBoxClients.TabStop = false;
         // 
         // groupBoxSearch
         // 
         this.groupBoxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBoxSearch.Controls.Add(this.buttonSearchClear);
         this.groupBoxSearch.Controls.Add(this.labelAlias);
         this.groupBoxSearch.Controls.Add(this.labelAeTitle);
         this.groupBoxSearch.Controls.Add(this.textBoxRole);
         this.groupBoxSearch.Controls.Add(this.textBoxAeTitle);
         this.groupBoxSearch.Location = new System.Drawing.Point(15, 380);
         this.groupBoxSearch.Name = "groupBoxSearch";
         this.groupBoxSearch.Size = new System.Drawing.Size(568, 67);
         this.groupBoxSearch.TabIndex = 3;
         this.groupBoxSearch.TabStop = false;
         this.groupBoxSearch.Text = "Search Filter";
         // 
         // buttonSearchClear
         // 
         this.buttonSearchClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.buttonSearchClear.BackgroundImage = global::Leadtools.Medical.PatientRestrict.AddIn.Properties.Resources.Remove;
         this.buttonSearchClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this.buttonSearchClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
         this.buttonSearchClear.Location = new System.Drawing.Point(295, 29);
         this.buttonSearchClear.Name = "buttonSearchClear";
         this.buttonSearchClear.Size = new System.Drawing.Size(68, 24);
         this.buttonSearchClear.TabIndex = 25;
         this.buttonSearchClear.Text = "Clear";
         this.buttonSearchClear.UseVisualStyleBackColor = true;
         // 
         // labelAlias
         // 
         this.labelAlias.AutoSize = true;
         this.labelAlias.Location = new System.Drawing.Point(143, 14);
         this.labelAlias.Name = "labelAlias";
         this.labelAlias.Size = new System.Drawing.Size(32, 13);
         this.labelAlias.TabIndex = 2;
         this.labelAlias.Text = "Role:";
         // 
         // labelAeTitle
         // 
         this.labelAeTitle.AutoSize = true;
         this.labelAeTitle.Location = new System.Drawing.Point(6, 14);
         this.labelAeTitle.Name = "labelAeTitle";
         this.labelAeTitle.Size = new System.Drawing.Size(47, 13);
         this.labelAeTitle.TabIndex = 0;
         this.labelAeTitle.Text = "AE Title:";
         // 
         // textBoxRole
         // 
         this.textBoxRole.Location = new System.Drawing.Point(143, 31);
         this.textBoxRole.Name = "textBoxRole";
         this.textBoxRole.Size = new System.Drawing.Size(146, 20);
         this.textBoxRole.TabIndex = 3;
         // 
         // textBoxAeTitle
         // 
         this.textBoxAeTitle.Location = new System.Drawing.Point(6, 31);
         this.textBoxAeTitle.Name = "textBoxAeTitle";
         this.textBoxAeTitle.Size = new System.Drawing.Size(131, 20);
         this.textBoxAeTitle.TabIndex = 1;
         // 
         // paginationControl1
         // 
         this.paginationControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.paginationControl1.Location = new System.Drawing.Point(15, 345);
         this.paginationControl1.MaxPageNumber = 5000;
         this.paginationControl1.MaxPageSize = 10000;
         this.paginationControl1.MinPageNumber = 10;
         this.paginationControl1.MinPageSize = 1;
         this.paginationControl1.Name = "paginationControl1";
         this.paginationControl1.PageNumber = 10;
         this.paginationControl1.PageNumberIncrement = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.paginationControl1.PageSize = 5;
         this.paginationControl1.PageSizeLabel = "Page Size:";
         this.paginationControl1.PageSizeReadOnly = true;
         this.paginationControl1.Size = new System.Drawing.Size(567, 33);
         this.paginationControl1.Status = "0 / 0";
         this.paginationControl1.TabIndex = 2;
         // 
         // clientToolStrip
         // 
         this.clientToolStrip.Dock = System.Windows.Forms.DockStyle.None;
         this.clientToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
         this.clientToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.clientToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddClientToolStripButton,
            this.ModifyClientToolStripButton,
            this.DeleteClienteToolStripButton});
         this.clientToolStrip.Location = new System.Drawing.Point(15, 21);
         this.clientToolStrip.Name = "clientToolStrip";
         this.clientToolStrip.Size = new System.Drawing.Size(111, 39);
         this.clientToolStrip.Stretch = true;
         this.clientToolStrip.TabIndex = 0;
         // 
         // AddClientToolStripButton
         // 
         this.AddClientToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.AddClientToolStripButton.Image = global::Leadtools.Medical.PatientRestrict.AddIn.Properties.Resources.ClientAdd;
         this.AddClientToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.AddClientToolStripButton.Name = "AddClientToolStripButton";
         this.AddClientToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.AddClientToolStripButton.Text = "Add AE Role";
         // 
         // ModifyClientToolStripButton
         // 
         this.ModifyClientToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.ModifyClientToolStripButton.Image = global::Leadtools.Medical.PatientRestrict.AddIn.Properties.Resources.ClientEdit;
         this.ModifyClientToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.ModifyClientToolStripButton.Name = "ModifyClientToolStripButton";
         this.ModifyClientToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.ModifyClientToolStripButton.Text = "Modify AE Role";
         // 
         // DeleteClienteToolStripButton
         // 
         this.DeleteClienteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.DeleteClienteToolStripButton.Image = global::Leadtools.Medical.PatientRestrict.AddIn.Properties.Resources.ClientDelete;
         this.DeleteClienteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.DeleteClienteToolStripButton.Name = "DeleteClienteToolStripButton";
         this.DeleteClienteToolStripButton.Size = new System.Drawing.Size(36, 36);
         this.DeleteClienteToolStripButton.Text = "Delete AE Role(s)";
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.AllowUserToResizeRows = false;
         this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAeTitle,
            this.ColumnRole});
         this.dataGridView1.Location = new System.Drawing.Point(15, 63);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.RowHeadersVisible = false;
         this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.dataGridView1.Size = new System.Drawing.Size(567, 275);
         this.dataGridView1.TabIndex = 1;
         // 
         // ColumnAeTitle
         // 
         this.ColumnAeTitle.HeaderText = "AE Title";
         this.ColumnAeTitle.MinimumWidth = 100;
         this.ColumnAeTitle.Name = "ColumnAeTitle";
         this.ColumnAeTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         // 
         // ColumnRole
         // 
         this.ColumnRole.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
         this.ColumnRole.HeaderText = "Role";
         this.ColumnRole.MinimumWidth = 100;
         this.ColumnRole.Name = "ColumnRole";
         this.ColumnRole.Resizable = System.Windows.Forms.DataGridViewTriState.True;
         // 
         // checkBoxEnablePatientRestrict
         // 
         this.checkBoxEnablePatientRestrict.AutoSize = true;
         this.checkBoxEnablePatientRestrict.Location = new System.Drawing.Point(12, 12);
         this.checkBoxEnablePatientRestrict.Name = "checkBoxEnablePatientRestrict";
         this.checkBoxEnablePatientRestrict.Size = new System.Drawing.Size(134, 17);
         this.checkBoxEnablePatientRestrict.TabIndex = 0;
         this.checkBoxEnablePatientRestrict.Text = "Enable Patient Restrict";
         this.checkBoxEnablePatientRestrict.TextAlign = System.Drawing.ContentAlignment.TopLeft;
         this.checkBoxEnablePatientRestrict.UseVisualStyleBackColor = true;
         // 
         // buttonApply
         // 
         this.buttonApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonApply.Location = new System.Drawing.Point(536, 507);
         this.buttonApply.Name = "buttonApply";
         this.buttonApply.Size = new System.Drawing.Size(75, 23);
         this.buttonApply.TabIndex = 4;
         this.buttonApply.Text = "&Apply";
         this.buttonApply.UseVisualStyleBackColor = true;
         this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
         // 
         // ConfigureDialog
         // 
         this.AcceptButton = this.buttonOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.buttonCancel;
         this.ClientSize = new System.Drawing.Size(632, 552);
         this.Controls.Add(this.buttonApply);
         this.Controls.Add(this.checkBoxEnablePatientRestrict);
         this.Controls.Add(this.groupBoxClients);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonOK);
         this.HelpButton = true;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.MinimumSize = new System.Drawing.Size(648, 400);
         this.Name = "ConfigureDialog";
         this.helpProvider1.SetShowHelp(this, true);
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Patient Restrict Configuration";
         this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ConfigureDialog_HelpButtonClicked);
         this.Load += new System.EventHandler(this.ConfigureDialog_Load);
         this.groupBoxClients.ResumeLayout(false);
         this.groupBoxClients.PerformLayout();
         this.groupBoxSearch.ResumeLayout(false);
         this.groupBoxSearch.PerformLayout();
         this.clientToolStrip.ResumeLayout(false);
         this.clientToolStrip.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Button buttonOK;
      private System.Windows.Forms.GroupBox groupBoxClients;
      private System.Windows.Forms.GroupBox groupBoxSearch;
      private System.Windows.Forms.Button buttonSearchClear;
      private System.Windows.Forms.Label labelAlias;
      private System.Windows.Forms.Label labelAeTitle;
      private System.Windows.Forms.TextBox textBoxRole;
      private System.Windows.Forms.TextBox textBoxAeTitle;
      private Winforms.PaginationControl paginationControl1;
      public System.Windows.Forms.ToolStrip clientToolStrip;
      public System.Windows.Forms.ToolStripButton AddClientToolStripButton;
      public System.Windows.Forms.ToolStripButton ModifyClientToolStripButton;
      public System.Windows.Forms.ToolStripButton DeleteClienteToolStripButton;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.CheckBox checkBoxEnablePatientRestrict;
      private System.Windows.Forms.HelpProvider helpProvider1;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAeTitle;
      private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRole;
      private System.Windows.Forms.Button buttonApply;
   }
}