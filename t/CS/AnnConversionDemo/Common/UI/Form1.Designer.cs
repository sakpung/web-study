namespace AnnConversionDemo
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
         this._lblSourceDirectory = new System.Windows.Forms.Label();
         this._txtSourceDirectory = new System.Windows.Forms.TextBox();
         this._btnBrowseSource = new System.Windows.Forms.Button();
         this._btnBrowseDestination = new System.Windows.Forms.Button();
         this._txtDestinationDirectory = new System.Windows.Forms.TextBox();
         this._lblDestinationDirectory = new System.Windows.Forms.Label();
         this._btnStart = new System.Windows.Forms.Button();
         this._btnExportResults = new System.Windows.Forms.Button();
         this._lvResults = new System.Windows.Forms.ListView();
         this._chSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._chDestination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._chPage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this._chResult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _lblSourceDirectory
         // 
         this._lblSourceDirectory.AutoSize = true;
         this._lblSourceDirectory.Location = new System.Drawing.Point(21, 30);
         this._lblSourceDirectory.Name = "_lblSourceDirectory";
         this._lblSourceDirectory.Size = new System.Drawing.Size(89, 13);
         this._lblSourceDirectory.TabIndex = 0;
         this._lblSourceDirectory.Text = "Source Directory:";
         // 
         // _txtSourceDirectory
         // 
         this._txtSourceDirectory.Location = new System.Drawing.Point(141, 23);
         this._txtSourceDirectory.Name = "_txtSourceDirectory";
         this._txtSourceDirectory.Size = new System.Drawing.Size(315, 20);
         this._txtSourceDirectory.TabIndex = 1;
         this._txtSourceDirectory.TextChanged += new System.EventHandler(this._txt_TextChanged);
         // 
         // _btnBrowseSource
         // 
         this._btnBrowseSource.Location = new System.Drawing.Point(472, 22);
         this._btnBrowseSource.Name = "_btnBrowseSource";
         this._btnBrowseSource.Size = new System.Drawing.Size(34, 20);
         this._btnBrowseSource.TabIndex = 2;
         this._btnBrowseSource.Text = "...";
         this._btnBrowseSource.UseVisualStyleBackColor = true;
         this._btnBrowseSource.Click += new System.EventHandler(this._btnBrowseSource_Click);
         // 
         // _btnBrowseDestination
         // 
         this._btnBrowseDestination.Location = new System.Drawing.Point(472, 56);
         this._btnBrowseDestination.Name = "_btnBrowseDestination";
         this._btnBrowseDestination.Size = new System.Drawing.Size(34, 20);
         this._btnBrowseDestination.TabIndex = 5;
         this._btnBrowseDestination.Text = "...";
         this._btnBrowseDestination.UseVisualStyleBackColor = true;
         this._btnBrowseDestination.Click += new System.EventHandler(this._btnBrowseDestination_Click);
         // 
         // _txtDestinationDirectory
         // 
         this._txtDestinationDirectory.Location = new System.Drawing.Point(141, 57);
         this._txtDestinationDirectory.Name = "_txtDestinationDirectory";
         this._txtDestinationDirectory.Size = new System.Drawing.Size(315, 20);
         this._txtDestinationDirectory.TabIndex = 4;
         this._txtDestinationDirectory.TextChanged += new System.EventHandler(this._txt_TextChanged);
         // 
         // _lblDestinationDirectory
         // 
         this._lblDestinationDirectory.AutoSize = true;
         this._lblDestinationDirectory.Location = new System.Drawing.Point(21, 64);
         this._lblDestinationDirectory.Name = "_lblDestinationDirectory";
         this._lblDestinationDirectory.Size = new System.Drawing.Size(108, 13);
         this._lblDestinationDirectory.TabIndex = 3;
         this._lblDestinationDirectory.Text = "Destination Directory:";
         // 
         // _btnStart
         // 
         this._btnStart.Location = new System.Drawing.Point(140, 100);
         this._btnStart.Name = "_btnStart";
         this._btnStart.Size = new System.Drawing.Size(159, 27);
         this._btnStart.TabIndex = 8;
         this._btnStart.Text = "Start Conversion";
         this._btnStart.UseVisualStyleBackColor = true;
         this._btnStart.Click += new System.EventHandler(this._btnStart_Click);
         // 
         // _btnExportResults
         // 
         this._btnExportResults.Location = new System.Drawing.Point(200, 334);
         this._btnExportResults.Name = "_btnExportResults";
         this._btnExportResults.Size = new System.Drawing.Size(101, 27);
         this._btnExportResults.TabIndex = 10;
         this._btnExportResults.Text = "Export Results";
         this._btnExportResults.UseVisualStyleBackColor = true;
         this._btnExportResults.Click += new System.EventHandler(this._btnExportResults_Click);
         // 
         // _lvResults
         // 
         this._lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._chSource,
            this._chDestination,
            this._chPage,
            this._chResult});
         this._lvResults.FullRowSelect = true;
         this._lvResults.GridLines = true;
         this._lvResults.Location = new System.Drawing.Point(12, 19);
         this._lvResults.Name = "_lvResults";
         this._lvResults.Size = new System.Drawing.Size(461, 309);
         this._lvResults.TabIndex = 11;
         this._lvResults.UseCompatibleStateImageBehavior = false;
         this._lvResults.View = System.Windows.Forms.View.Details;
         // 
         // _chSource
         // 
         this._chSource.Text = "Source";
         this._chSource.Width = 101;
         // 
         // _chDestination
         // 
         this._chDestination.Text = "Destination";
         this._chDestination.Width = 153;
         // 
         // _chPage
         // 
         this._chPage.Text = "Page";
         this._chPage.Width = 66;
         // 
         // _chResult
         // 
         this._chResult.Text = "Result";
         this._chResult.Width = 92;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._lvResults);
         this.groupBox1.Controls.Add(this._btnExportResults);
         this.groupBox1.Location = new System.Drawing.Point(20, 140);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(485, 369);
         this.groupBox1.TabIndex = 12;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Results:";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(517, 521);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnStart);
         this.Controls.Add(this._btnBrowseDestination);
         this.Controls.Add(this._txtDestinationDirectory);
         this.Controls.Add(this._lblDestinationDirectory);
         this.Controls.Add(this._btnBrowseSource);
         this.Controls.Add(this._txtSourceDirectory);
         this.Controls.Add(this._lblSourceDirectory);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Annotations Conversion Demo";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblSourceDirectory;
      private System.Windows.Forms.TextBox _txtSourceDirectory;
      private System.Windows.Forms.Button _btnBrowseSource;
      private System.Windows.Forms.Button _btnBrowseDestination;
      private System.Windows.Forms.TextBox _txtDestinationDirectory;
      private System.Windows.Forms.Label _lblDestinationDirectory;
      private System.Windows.Forms.Button _btnStart;
      private System.Windows.Forms.Button _btnExportResults;
      private System.Windows.Forms.ListView _lvResults;
      private System.Windows.Forms.ColumnHeader _chSource;
      private System.Windows.Forms.ColumnHeader _chDestination;
      private System.Windows.Forms.ColumnHeader _chPage;
      private System.Windows.Forms.ColumnHeader _chResult;
      private System.Windows.Forms.GroupBox groupBox1;

   }
}