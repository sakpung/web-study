using DicomDemo.Utils;
namespace DicomDemo
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
         this.PatientIdLabel = new System.Windows.Forms.Label();
         this.textBoxPatientId = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.textBoxPatientName = new System.Windows.Forms.TextBox();
         this.SearchButton = new System.Windows.Forms.Button();
         this.SearchGroupBox = new System.Windows.Forms.GroupBox();
         this.DeleteSeriesButton = new System.Windows.Forms.Button();
         this.EditSeriesButton = new System.Windows.Forms.Button();
         this.DeletePatientButton = new System.Windows.Forms.Button();
         this.EditPatientButton = new System.Windows.Forms.Button();
         this.listViewSeries = new DicomDemo.MainForm.CustomSelectListView();
         this.SeriesDescriptionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.SeriesDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.SeriesTimeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.SeriesModalityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.StudyInstanceColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.SeriesLabel = new System.Windows.Forms.Label();
         this.listViewPatients = new DicomDemo.MainForm.CustomSelectListView();
         this.PatientNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.PatientIdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.SexColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.BirthColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.PatientLabel = new System.Windows.Forms.Label();
         this.menuStripMain = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.hToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.SearchForGroupBox = new System.Windows.Forms.GroupBox();
         this.SearchGroupBox.SuspendLayout();
         this.menuStripMain.SuspendLayout();
         this.SearchForGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // PatientIdLabel
         // 
         resources.ApplyResources(this.PatientIdLabel, "PatientIdLabel");
         this.PatientIdLabel.ForeColor = System.Drawing.SystemColors.ControlText;
         this.PatientIdLabel.Name = "PatientIdLabel";
         // 
         // textBoxPatientId
         // 
         resources.ApplyResources(this.textBoxPatientId, "textBoxPatientId");
         this.textBoxPatientId.Name = "textBoxPatientId";
         this.textBoxPatientId.TextChanged += new System.EventHandler(this.Search_Changed);
         this.textBoxPatientId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
         this.label1.Name = "label1";
         // 
         // textBoxPatientName
         // 
         resources.ApplyResources(this.textBoxPatientName, "textBoxPatientName");
         this.textBoxPatientName.Name = "textBoxPatientName";
         this.textBoxPatientName.TextChanged += new System.EventHandler(this.Search_Changed);
         this.textBoxPatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_KeyDown);
         this.textBoxPatientName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPatientName_KeyPress);
         // 
         // SearchButton
         // 
         resources.ApplyResources(this.SearchButton, "SearchButton");
         this.SearchButton.Name = "SearchButton";
         this.SearchButton.UseVisualStyleBackColor = true;
         this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
         // 
         // SearchGroupBox
         // 
         resources.ApplyResources(this.SearchGroupBox, "SearchGroupBox");
         this.SearchGroupBox.Controls.Add(this.DeleteSeriesButton);
         this.SearchGroupBox.Controls.Add(this.EditSeriesButton);
         this.SearchGroupBox.Controls.Add(this.DeletePatientButton);
         this.SearchGroupBox.Controls.Add(this.EditPatientButton);
         this.SearchGroupBox.Controls.Add(this.listViewSeries);
         this.SearchGroupBox.Controls.Add(this.SeriesLabel);
         this.SearchGroupBox.Controls.Add(this.listViewPatients);
         this.SearchGroupBox.Controls.Add(this.PatientLabel);
         this.SearchGroupBox.ForeColor = System.Drawing.Color.Blue;
         this.SearchGroupBox.Name = "SearchGroupBox";
         this.SearchGroupBox.TabStop = false;
         // 
         // DeleteSeriesButton
         // 
         resources.ApplyResources(this.DeleteSeriesButton, "DeleteSeriesButton");
         this.DeleteSeriesButton.ForeColor = System.Drawing.SystemColors.ControlText;
         this.DeleteSeriesButton.Name = "DeleteSeriesButton";
         this.DeleteSeriesButton.UseVisualStyleBackColor = true;
         this.DeleteSeriesButton.Click += new System.EventHandler(this.DeleteSeriesButton_Click);
         // 
         // EditSeriesButton
         // 
         resources.ApplyResources(this.EditSeriesButton, "EditSeriesButton");
         this.EditSeriesButton.ForeColor = System.Drawing.SystemColors.ControlText;
         this.EditSeriesButton.Name = "EditSeriesButton";
         this.EditSeriesButton.UseVisualStyleBackColor = true;
         this.EditSeriesButton.Click += new System.EventHandler(this.EditSeriesButton_Click);
         // 
         // DeletePatientButton
         // 
         resources.ApplyResources(this.DeletePatientButton, "DeletePatientButton");
         this.DeletePatientButton.ForeColor = System.Drawing.SystemColors.ControlText;
         this.DeletePatientButton.Name = "DeletePatientButton";
         this.DeletePatientButton.UseVisualStyleBackColor = true;
         this.DeletePatientButton.Click += new System.EventHandler(this.DeletePatientButton_Click);
         // 
         // EditPatientButton
         // 
         resources.ApplyResources(this.EditPatientButton, "EditPatientButton");
         this.EditPatientButton.ForeColor = System.Drawing.SystemColors.ControlText;
         this.EditPatientButton.Name = "EditPatientButton";
         this.EditPatientButton.UseVisualStyleBackColor = true;
         this.EditPatientButton.Click += new System.EventHandler(this.EditPatientButton_Click);
         // 
         // listViewSeries
         // 
         resources.ApplyResources(this.listViewSeries, "listViewSeries");
         this.listViewSeries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SeriesDescriptionColumn,
            this.SeriesDateColumn,
            this.SeriesTimeColumn,
            this.SeriesModalityColumn,
            this.StudyInstanceColumn});
         this.listViewSeries.FullRowSelect = true;
         this.listViewSeries.GridLines = true;
         this.listViewSeries.HideSelection = false;
         this.listViewSeries.MultiSelect = false;
         this.listViewSeries.Name = "listViewSeries";
         this.listViewSeries.UseCompatibleStateImageBehavior = false;
         this.listViewSeries.View = System.Windows.Forms.View.Details;
         this.listViewSeries.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewSeries_ColumnClick);
         this.listViewSeries.SelectedIndexChanged += new System.EventHandler(this.listViewSeries_SelectedIndexChanged);
         // 
         // SeriesDescriptionColumn
         // 
         resources.ApplyResources(this.SeriesDescriptionColumn, "SeriesDescriptionColumn");
         // 
         // SeriesDateColumn
         // 
         resources.ApplyResources(this.SeriesDateColumn, "SeriesDateColumn");
         // 
         // SeriesTimeColumn
         // 
         resources.ApplyResources(this.SeriesTimeColumn, "SeriesTimeColumn");
         // 
         // SeriesModalityColumn
         // 
         resources.ApplyResources(this.SeriesModalityColumn, "SeriesModalityColumn");
         // 
         // StudyInstanceColumn
         // 
         resources.ApplyResources(this.StudyInstanceColumn, "StudyInstanceColumn");
         // 
         // SeriesLabel
         // 
         resources.ApplyResources(this.SeriesLabel, "SeriesLabel");
         this.SeriesLabel.ForeColor = System.Drawing.SystemColors.ControlText;
         this.SeriesLabel.Name = "SeriesLabel";
         // 
         // listViewPatients
         // 
         this.listViewPatients.Activation = System.Windows.Forms.ItemActivation.OneClick;
         resources.ApplyResources(this.listViewPatients, "listViewPatients");
         this.listViewPatients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PatientNameColumn,
            this.PatientIdColumn,
            this.SexColumn,
            this.BirthColumn});
         this.listViewPatients.FullRowSelect = true;
         this.listViewPatients.GridLines = true;
         this.listViewPatients.HideSelection = false;
         this.listViewPatients.MultiSelect = false;
         this.listViewPatients.Name = "listViewPatients";
         this.listViewPatients.UseCompatibleStateImageBehavior = false;
         this.listViewPatients.View = System.Windows.Forms.View.Details;
         this.listViewPatients.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewPatients_ColumnClick);
         this.listViewPatients.SelectedIndexChanged += new System.EventHandler(this.listViewPatients_SelectedIndexChanged);
         this.listViewPatients.Enter += new System.EventHandler(this.listViewPatients_Enter);
         // 
         // PatientNameColumn
         // 
         resources.ApplyResources(this.PatientNameColumn, "PatientNameColumn");
         // 
         // PatientIdColumn
         // 
         resources.ApplyResources(this.PatientIdColumn, "PatientIdColumn");
         // 
         // SexColumn
         // 
         resources.ApplyResources(this.SexColumn, "SexColumn");
         // 
         // BirthColumn
         // 
         resources.ApplyResources(this.BirthColumn, "BirthColumn");
         // 
         // PatientLabel
         // 
         resources.ApplyResources(this.PatientLabel, "PatientLabel");
         this.PatientLabel.ForeColor = System.Drawing.SystemColors.ControlText;
         this.PatientLabel.Name = "PatientLabel";
         // 
         // menuStripMain
         // 
         this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.hToolStripMenuItem});
         resources.ApplyResources(this.menuStripMain, "menuStripMain");
         this.menuStripMain.Name = "menuStripMain";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
         this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
         // 
         // toolStripMenuItem1
         // 
         this.toolStripMenuItem1.Name = "toolStripMenuItem1";
         resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitButton_Click);
         // 
         // hToolStripMenuItem
         // 
         this.hToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
         this.hToolStripMenuItem.Name = "hToolStripMenuItem";
         resources.ApplyResources(this.hToolStripMenuItem, "hToolStripMenuItem");
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
         // 
         // SearchForGroupBox
         // 
         resources.ApplyResources(this.SearchForGroupBox, "SearchForGroupBox");
         this.SearchForGroupBox.Controls.Add(this.PatientIdLabel);
         this.SearchForGroupBox.Controls.Add(this.label1);
         this.SearchForGroupBox.Controls.Add(this.textBoxPatientId);
         this.SearchForGroupBox.Controls.Add(this.textBoxPatientName);
         this.SearchForGroupBox.ForeColor = System.Drawing.Color.Blue;
         this.SearchForGroupBox.Name = "SearchForGroupBox";
         this.SearchForGroupBox.TabStop = false;
         // 
         // MainForm
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.SearchForGroupBox);
         this.Controls.Add(this.SearchGroupBox);
         this.Controls.Add(this.SearchButton);
         this.Controls.Add(this.menuStripMain);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
         this.MainMenuStrip = this.menuStripMain;
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.Shown += new System.EventHandler(this.MainForm_Shown);
         this.SearchGroupBox.ResumeLayout(false);
         this.SearchGroupBox.PerformLayout();
         this.menuStripMain.ResumeLayout(false);
         this.menuStripMain.PerformLayout();
         this.SearchForGroupBox.ResumeLayout(false);
         this.SearchForGroupBox.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PatientIdLabel;
        private System.Windows.Forms.TextBox textBoxPatientId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPatientName;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.GroupBox SearchGroupBox;
        private CustomSelectListView listViewSeries;
        private System.Windows.Forms.Label SeriesLabel;
        private CustomSelectListView listViewPatients;
        private System.Windows.Forms.Label PatientLabel;
        private System.Windows.Forms.Button DeleteSeriesButton;
        private System.Windows.Forms.Button EditSeriesButton;
        private System.Windows.Forms.Button DeletePatientButton;
        private System.Windows.Forms.Button EditPatientButton;
        private System.Windows.Forms.ColumnHeader PatientIdColumn;
        private System.Windows.Forms.ColumnHeader PatientNameColumn;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ColumnHeader SexColumn;
        private System.Windows.Forms.ColumnHeader BirthColumn;
        private System.Windows.Forms.ColumnHeader SeriesDescriptionColumn;
        private System.Windows.Forms.ColumnHeader SeriesDateColumn;
        private System.Windows.Forms.ColumnHeader SeriesModalityColumn;
        private System.Windows.Forms.GroupBox SearchForGroupBox;
        private System.Windows.Forms.ColumnHeader StudyInstanceColumn;
        private System.Windows.Forms.ColumnHeader SeriesTimeColumn;
        private System.Windows.Forms.ToolStripMenuItem hToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

