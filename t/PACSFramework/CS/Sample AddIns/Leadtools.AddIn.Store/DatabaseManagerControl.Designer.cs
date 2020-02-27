namespace Leadtools.AddIn.Store
{
   partial class DatabaseManagerControl
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
         this._splitContainer1 = new System.Windows.Forms.SplitContainer();
         this._listViewDatabase = new System.Windows.Forms.ListView();
         this._columnHeaderPatientId = new System.Windows.Forms.ColumnHeader();
         this._columnHeaderPatientName = new System.Windows.Forms.ColumnHeader();
         this._columnHeaderStudyId = new System.Windows.Forms.ColumnHeader();
         this._columnHeaderSeriesNumber = new System.Windows.Forms.ColumnHeader();
         this._columnHeaderModality = new System.Windows.Forms.ColumnHeader();
         this._columnHeaderInstanceNumber = new System.Windows.Forms.ColumnHeader();
         this._columnHeaderTransferSyntax = new System.Windows.Forms.ColumnHeader();
         this._columnHeaderSopClassUid = new System.Windows.Forms.ColumnHeader();
         this._columnHeaderReferencedFile = new System.Windows.Forms.ColumnHeader();
         this._buttonRefresh = new System.Windows.Forms.Button();
         this._buttonCancel = new System.Windows.Forms.Button();
         this._buttonRemoveAll = new System.Windows.Forms.Button();
         this._buttonRemove = new System.Windows.Forms.Button();
         this._buttonImport = new System.Windows.Forms.Button();
         this._splitContainer1.Panel1.SuspendLayout();
         this._splitContainer1.Panel2.SuspendLayout();
         this._splitContainer1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _splitContainer1
         // 
         this._splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer1.Location = new System.Drawing.Point(0, 0);
         this._splitContainer1.Name = "_splitContainer1";
         this._splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
         // 
         // _splitContainer1.Panel1
         // 
         this._splitContainer1.Panel1.Controls.Add(this._listViewDatabase);
         // 
         // _splitContainer1.Panel2
         // 
         this._splitContainer1.Panel2.Controls.Add(this._buttonRefresh);
         this._splitContainer1.Panel2.Controls.Add(this._buttonCancel);
         this._splitContainer1.Panel2.Controls.Add(this._buttonRemoveAll);
         this._splitContainer1.Panel2.Controls.Add(this._buttonRemove);
         this._splitContainer1.Panel2.Controls.Add(this._buttonImport);
         this._splitContainer1.Panel2.Resize += new System.EventHandler(this._splitContainer1_Panel2_Resize);
         this._splitContainer1.Size = new System.Drawing.Size(644, 259);
         this._splitContainer1.SplitterDistance = 214;
         this._splitContainer1.TabIndex = 0;
         // 
         // _listViewDatabase
         // 
         this._listViewDatabase.CheckBoxes = true;
         this._listViewDatabase.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this._columnHeaderPatientId,
            this._columnHeaderPatientName,
            this._columnHeaderStudyId,
            this._columnHeaderSeriesNumber,
            this._columnHeaderModality,
            this._columnHeaderInstanceNumber,
            this._columnHeaderTransferSyntax,
            this._columnHeaderSopClassUid,
            this._columnHeaderReferencedFile});
         this._listViewDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
         this._listViewDatabase.FullRowSelect = true;
         this._listViewDatabase.GridLines = true;
         this._listViewDatabase.HideSelection = false;
         this._listViewDatabase.Location = new System.Drawing.Point(0, 0);
         this._listViewDatabase.Name = "_listViewDatabase";
         this._listViewDatabase.Size = new System.Drawing.Size(644, 214);
         this._listViewDatabase.TabIndex = 5;
         this._listViewDatabase.UseCompatibleStateImageBehavior = false;
         this._listViewDatabase.View = System.Windows.Forms.View.Details;
         this._listViewDatabase.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this._listViewDatabase_ItemChecked);
         // 
         // _columnHeaderPatientId
         // 
         this._columnHeaderPatientId.Text = "Patient ID";
         // 
         // _columnHeaderPatientName
         // 
         this._columnHeaderPatientName.Text = "Patient Name";
         // 
         // _columnHeaderStudyId
         // 
         this._columnHeaderStudyId.Text = "Study ID";
         // 
         // _columnHeaderSeriesNumber
         // 
         this._columnHeaderSeriesNumber.Text = "Series #";
         // 
         // _columnHeaderModality
         // 
         this._columnHeaderModality.Text = "Modality";
         // 
         // _columnHeaderInstanceNumber
         // 
         this._columnHeaderInstanceNumber.Text = "Instance #";
         // 
         // _columnHeaderTransferSyntax
         // 
         this._columnHeaderTransferSyntax.Text = "Transfer Syntax";
         // 
         // _columnHeaderSopClassUid
         // 
         this._columnHeaderSopClassUid.Text = "SOP Class UID";
         // 
         // _columnHeaderReferencedFile
         // 
         this._columnHeaderReferencedFile.Text = "Referenced File";
         // 
         // _buttonRefresh
         // 
         this._buttonRefresh.Location = new System.Drawing.Point(297, 8);
         this._buttonRefresh.Name = "_buttonRefresh";
         this._buttonRefresh.Size = new System.Drawing.Size(81, 23);
         this._buttonRefresh.TabIndex = 4;
         this._buttonRefresh.Text = "Re&fresh";
         this._buttonRefresh.UseVisualStyleBackColor = true;
         this._buttonRefresh.Click += new System.EventHandler(this._buttonRefresh_Click);
         // 
         // _buttonCancel
         // 
         this._buttonCancel.Location = new System.Drawing.Point(395, 8);
         this._buttonCancel.Name = "_buttonCancel";
         this._buttonCancel.Size = new System.Drawing.Size(81, 23);
         this._buttonCancel.TabIndex = 3;
         this._buttonCancel.Text = "Cancel";
         this._buttonCancel.UseVisualStyleBackColor = true;
         this._buttonCancel.Click += new System.EventHandler(this._buttonCancel_Click);
         // 
         // _buttonRemoveAll
         // 
         this._buttonRemoveAll.Location = new System.Drawing.Point(199, 8);
         this._buttonRemoveAll.Name = "_buttonRemoveAll";
         this._buttonRemoveAll.Size = new System.Drawing.Size(81, 23);
         this._buttonRemoveAll.TabIndex = 2;
         this._buttonRemoveAll.Text = "Remove &All...";
         this._buttonRemoveAll.UseVisualStyleBackColor = true;
         this._buttonRemoveAll.Click += new System.EventHandler(this._buttonRemoveAll_Click);
         // 
         // _buttonRemove
         // 
         this._buttonRemove.Location = new System.Drawing.Point(101, 8);
         this._buttonRemove.Name = "_buttonRemove";
         this._buttonRemove.Size = new System.Drawing.Size(81, 23);
         this._buttonRemove.TabIndex = 1;
         this._buttonRemove.Text = "&Remove...";
         this._buttonRemove.UseVisualStyleBackColor = true;
         this._buttonRemove.Click += new System.EventHandler(this._buttonRemove_Click);
         // 
         // _buttonImport
         // 
         this._buttonImport.Location = new System.Drawing.Point(3, 8);
         this._buttonImport.Name = "_buttonImport";
         this._buttonImport.Size = new System.Drawing.Size(81, 23);
         this._buttonImport.TabIndex = 0;
         this._buttonImport.Text = "&Import...";
         this._buttonImport.UseVisualStyleBackColor = true;
         this._buttonImport.Click += new System.EventHandler(this._buttonImport_Click);
         // 
         // DatabaseManagerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._splitContainer1);
         this.Name = "DatabaseManagerControl";
         this.Size = new System.Drawing.Size(644, 259);
         this.Load += new System.EventHandler(this.DatabaseManagerControl_Load);
         this._splitContainer1.Panel1.ResumeLayout(false);
         this._splitContainer1.Panel2.ResumeLayout(false);
         this._splitContainer1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer _splitContainer1;
      private System.Windows.Forms.ListView _listViewDatabase;
      private System.Windows.Forms.ColumnHeader _columnHeaderPatientId;
      private System.Windows.Forms.ColumnHeader _columnHeaderPatientName;
      private System.Windows.Forms.ColumnHeader _columnHeaderStudyId;
      private System.Windows.Forms.ColumnHeader _columnHeaderSeriesNumber;
      private System.Windows.Forms.ColumnHeader _columnHeaderModality;
      private System.Windows.Forms.ColumnHeader _columnHeaderInstanceNumber;
      private System.Windows.Forms.ColumnHeader _columnHeaderTransferSyntax;
      private System.Windows.Forms.ColumnHeader _columnHeaderSopClassUid;
      private System.Windows.Forms.Button _buttonRemoveAll;
      private System.Windows.Forms.Button _buttonRemove;
      private System.Windows.Forms.Button _buttonImport;
      private System.Windows.Forms.Button _buttonCancel;
      private System.Windows.Forms.ColumnHeader _columnHeaderReferencedFile;
      private System.Windows.Forms.Button _buttonRefresh;

   }
}
