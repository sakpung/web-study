namespace JPXDemo
{
   partial class FragmentJPX
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
         this._grpOutputFile = new System.Windows.Forms.GroupBox();
         this._lblOutputFile = new System.Windows.Forms.Label();
         this._txtOutputFile = new System.Windows.Forms.TextBox();
         this._btnOutputBrowse = new System.Windows.Forms.Button();
         this._grpInputFile = new System.Windows.Forms.GroupBox();
         this._lblJPEG2000 = new System.Windows.Forms.Label();
         this._txtInputFile = new System.Windows.Forms.TextBox();
         this._btnInputBrowse = new System.Windows.Forms.Button();
         this._grpCodeStreams = new System.Windows.Forms.GroupBox();
         this._lblCodeStreamsFiles = new System.Windows.Forms.Label();
         this._txtCodeStreamsFiles = new System.Windows.Forms.TextBox();
         this._btnCodeStreamsFiles = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._grpOutputFile.SuspendLayout();
         this._grpInputFile.SuspendLayout();
         this._grpCodeStreams.SuspendLayout();
         this.SuspendLayout();
         // 
         // _grpOutputFile
         // 
         this._grpOutputFile.Controls.Add(this._lblOutputFile);
         this._grpOutputFile.Controls.Add(this._txtOutputFile);
         this._grpOutputFile.Controls.Add(this._btnOutputBrowse);
         this._grpOutputFile.Location = new System.Drawing.Point(2, 80);
         this._grpOutputFile.Name = "_grpOutputFile";
         this._grpOutputFile.Size = new System.Drawing.Size(330, 67);
         this._grpOutputFile.TabIndex = 3;
         this._grpOutputFile.TabStop = false;
         this._grpOutputFile.Text = "Output File";
         // 
         // _lblOutputFile
         // 
         this._lblOutputFile.AutoSize = true;
         this._lblOutputFile.Location = new System.Drawing.Point(6, 18);
         this._lblOutputFile.Name = "_lblOutputFile";
         this._lblOutputFile.Size = new System.Drawing.Size(118, 13);
         this._lblOutputFile.TabIndex = 0;
         this._lblOutputFile.Text = "Output JPEG 2000 File:";
         // 
         // _txtOutputFile
         // 
         this._txtOutputFile.Location = new System.Drawing.Point(9, 36);
         this._txtOutputFile.Name = "_txtOutputFile";
         this._txtOutputFile.Size = new System.Drawing.Size(232, 20);
         this._txtOutputFile.TabIndex = 1;
         // 
         // _btnOutputBrowse
         // 
         this._btnOutputBrowse.Location = new System.Drawing.Point(251, 34);
         this._btnOutputBrowse.Name = "_btnOutputBrowse";
         this._btnOutputBrowse.Size = new System.Drawing.Size(75, 23);
         this._btnOutputBrowse.TabIndex = 2;
         this._btnOutputBrowse.Text = "Browse";
         this._btnOutputBrowse.UseVisualStyleBackColor = true;
         this._btnOutputBrowse.Click += new System.EventHandler(this._btnOutputBrowse_Click);
         // 
         // _grpInputFile
         // 
         this._grpInputFile.Controls.Add(this._lblJPEG2000);
         this._grpInputFile.Controls.Add(this._txtInputFile);
         this._grpInputFile.Controls.Add(this._btnInputBrowse);
         this._grpInputFile.Location = new System.Drawing.Point(2, 2);
         this._grpInputFile.Name = "_grpInputFile";
         this._grpInputFile.Size = new System.Drawing.Size(330, 72);
         this._grpInputFile.TabIndex = 2;
         this._grpInputFile.TabStop = false;
         this._grpInputFile.Text = "Input File";
         // 
         // _lblJPEG2000
         // 
         this._lblJPEG2000.AutoSize = true;
         this._lblJPEG2000.Location = new System.Drawing.Point(6, 21);
         this._lblJPEG2000.Name = "_lblJPEG2000";
         this._lblJPEG2000.Size = new System.Drawing.Size(116, 13);
         this._lblJPEG2000.TabIndex = 0;
         this._lblJPEG2000.Text = "Select JPEG 2000 File:";
         // 
         // _txtInputFile
         // 
         this._txtInputFile.Location = new System.Drawing.Point(13, 39);
         this._txtInputFile.Name = "_txtInputFile";
         this._txtInputFile.Size = new System.Drawing.Size(232, 20);
         this._txtInputFile.TabIndex = 1;
         // 
         // _btnInputBrowse
         // 
         this._btnInputBrowse.Location = new System.Drawing.Point(251, 37);
         this._btnInputBrowse.Name = "_btnInputBrowse";
         this._btnInputBrowse.Size = new System.Drawing.Size(75, 23);
         this._btnInputBrowse.TabIndex = 2;
         this._btnInputBrowse.Text = "Browse";
         this._btnInputBrowse.UseVisualStyleBackColor = true;
         this._btnInputBrowse.Click += new System.EventHandler(this._btnInputBrowse_Click);
         // 
         // _grpCodeStreams
         // 
         this._grpCodeStreams.Controls.Add(this._lblCodeStreamsFiles);
         this._grpCodeStreams.Controls.Add(this._txtCodeStreamsFiles);
         this._grpCodeStreams.Controls.Add(this._btnCodeStreamsFiles);
         this._grpCodeStreams.Location = new System.Drawing.Point(2, 153);
         this._grpCodeStreams.Name = "_grpCodeStreams";
         this._grpCodeStreams.Size = new System.Drawing.Size(330, 67);
         this._grpCodeStreams.TabIndex = 4;
         this._grpCodeStreams.TabStop = false;
         this._grpCodeStreams.Text = "Code Streams";
         // 
         // _lblCodeStreamsFiles
         // 
         this._lblCodeStreamsFiles.AutoSize = true;
         this._lblCodeStreamsFiles.Location = new System.Drawing.Point(6, 18);
         this._lblCodeStreamsFiles.Name = "_lblCodeStreamsFiles";
         this._lblCodeStreamsFiles.Size = new System.Drawing.Size(97, 13);
         this._lblCodeStreamsFiles.TabIndex = 0;
         this._lblCodeStreamsFiles.Text = "Code Streams Files";
         // 
         // _txtCodeStreamsFiles
         // 
         this._txtCodeStreamsFiles.Location = new System.Drawing.Point(9, 36);
         this._txtCodeStreamsFiles.Name = "_txtCodeStreamsFiles";
         this._txtCodeStreamsFiles.Size = new System.Drawing.Size(232, 20);
         this._txtCodeStreamsFiles.TabIndex = 1;
         // 
         // _btnCodeStreamsFiles
         // 
         this._btnCodeStreamsFiles.Location = new System.Drawing.Point(251, 34);
         this._btnCodeStreamsFiles.Name = "_btnCodeStreamsFiles";
         this._btnCodeStreamsFiles.Size = new System.Drawing.Size(75, 23);
         this._btnCodeStreamsFiles.TabIndex = 2;
         this._btnCodeStreamsFiles.Text = "Browse";
         this._btnCodeStreamsFiles.UseVisualStyleBackColor = true;
         this._btnCodeStreamsFiles.Click += new System.EventHandler(this._btnCodeStreamsFiles_Click);
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(90, 226);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 5;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(171, 226);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 6;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // FragmentJPX
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(337, 254);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._grpCodeStreams);
         this.Controls.Add(this._grpOutputFile);
         this.Controls.Add(this._grpInputFile);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FragmentJPX";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Fragment JPX";
         this._grpOutputFile.ResumeLayout(false);
         this._grpOutputFile.PerformLayout();
         this._grpInputFile.ResumeLayout(false);
         this._grpInputFile.PerformLayout();
         this._grpCodeStreams.ResumeLayout(false);
         this._grpCodeStreams.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _grpOutputFile;
      private System.Windows.Forms.GroupBox _grpCodeStreams;
      private System.Windows.Forms.Label _lblCodeStreamsFiles;
      private System.Windows.Forms.TextBox _txtCodeStreamsFiles;
      private System.Windows.Forms.Button _btnCodeStreamsFiles;
      private System.Windows.Forms.Label _lblOutputFile;
      private System.Windows.Forms.TextBox _txtOutputFile;
      private System.Windows.Forms.Button _btnOutputBrowse;
      private System.Windows.Forms.GroupBox _grpInputFile;
      private System.Windows.Forms.Label _lblJPEG2000;
      private System.Windows.Forms.TextBox _txtInputFile;
      private System.Windows.Forms.Button _btnInputBrowse;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}