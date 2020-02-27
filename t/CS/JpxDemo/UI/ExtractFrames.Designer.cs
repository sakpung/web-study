namespace JPXDemo
{
   partial class ExtractFrames
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
         this._btnExtract = new System.Windows.Forms.Button();
         this._grpFrameIndex = new System.Windows.Forms.GroupBox();
         this._txtToFrame = new System.Windows.Forms.TextBox();
         this._txtFromFrame = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._grpOutputFile.SuspendLayout();
         this._grpInputFile.SuspendLayout();
         this._grpFrameIndex.SuspendLayout();
         this.SuspendLayout();
         // 
         // _grpOutputFile
         // 
         this._grpOutputFile.Controls.Add(this._lblOutputFile);
         this._grpOutputFile.Controls.Add(this._txtOutputFile);
         this._grpOutputFile.Controls.Add(this._btnOutputBrowse);
         this._grpOutputFile.Location = new System.Drawing.Point(5, 83);
         this._grpOutputFile.Name = "_grpOutputFile";
         this._grpOutputFile.Size = new System.Drawing.Size(330, 67);
         this._grpOutputFile.TabIndex = 5;
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
         this._grpInputFile.Location = new System.Drawing.Point(5, 5);
         this._grpInputFile.Name = "_grpInputFile";
         this._grpInputFile.Size = new System.Drawing.Size(330, 72);
         this._grpInputFile.TabIndex = 4;
         this._grpInputFile.TabStop = false;
         this._grpInputFile.Text = "Input File";
         // 
         // _lblJPEG2000
         // 
         this._lblJPEG2000.AutoSize = true;
         this._lblJPEG2000.Location = new System.Drawing.Point(6, 21);
         this._lblJPEG2000.Name = "_lblJPEG2000";
         this._lblJPEG2000.Size = new System.Drawing.Size(104, 13);
         this._lblJPEG2000.TabIndex = 0;
         this._lblJPEG2000.Text = "Select JP2/JPX File:";
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
         // _btnExtract
         // 
         this._btnExtract.Location = new System.Drawing.Point(256, 186);
         this._btnExtract.Name = "_btnExtract";
         this._btnExtract.Size = new System.Drawing.Size(75, 23);
         this._btnExtract.TabIndex = 7;
         this._btnExtract.Text = "&Extract";
         this._btnExtract.UseVisualStyleBackColor = true;
         this._btnExtract.Click += new System.EventHandler(this._btnExtract_Click);
         // 
         // _grpFrameIndex
         // 
         this._grpFrameIndex.Controls.Add(this._txtToFrame);
         this._grpFrameIndex.Controls.Add(this._txtFromFrame);
         this._grpFrameIndex.Controls.Add(this.label2);
         this._grpFrameIndex.Controls.Add(this.label1);
         this._grpFrameIndex.Location = new System.Drawing.Point(5, 156);
         this._grpFrameIndex.Name = "_grpFrameIndex";
         this._grpFrameIndex.Size = new System.Drawing.Size(241, 53);
         this._grpFrameIndex.TabIndex = 6;
         this._grpFrameIndex.TabStop = false;
         this._grpFrameIndex.Text = "Frame Index - 0 based";
         // 
         // _txtToFrame
         // 
         this._txtToFrame.Location = new System.Drawing.Point(174, 23);
         this._txtToFrame.Name = "_txtToFrame";
         this._txtToFrame.Size = new System.Drawing.Size(51, 20);
         this._txtToFrame.TabIndex = 9;
         this._txtToFrame.TextChanged += new System.EventHandler(this._txtFromToFrames_TextChanged);
         // 
         // _txtFromFrame
         // 
         this._txtFromFrame.Location = new System.Drawing.Point(51, 23);
         this._txtFromFrame.Name = "_txtFromFrame";
         this._txtFromFrame.Size = new System.Drawing.Size(51, 20);
         this._txtFromFrame.TabIndex = 8;
         this._txtFromFrame.TextChanged += new System.EventHandler(this._txtFromToFrames_TextChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(148, 25);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(20, 13);
         this.label2.TabIndex = 7;
         this.label2.Text = "To";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(15, 25);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(30, 13);
         this.label1.TabIndex = 6;
         this.label1.Text = "From";
         // 
         // ExtractFrames
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(342, 215);
         this.Controls.Add(this._btnExtract);
         this.Controls.Add(this._grpFrameIndex);
         this.Controls.Add(this._grpOutputFile);
         this.Controls.Add(this._grpInputFile);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ExtractFrames";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Extract Frames";
         this._grpOutputFile.ResumeLayout(false);
         this._grpOutputFile.PerformLayout();
         this._grpInputFile.ResumeLayout(false);
         this._grpInputFile.PerformLayout();
         this._grpFrameIndex.ResumeLayout(false);
         this._grpFrameIndex.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _grpOutputFile;
      private System.Windows.Forms.Label _lblOutputFile;
      private System.Windows.Forms.TextBox _txtOutputFile;
      private System.Windows.Forms.Button _btnOutputBrowse;
      private System.Windows.Forms.GroupBox _grpInputFile;
      private System.Windows.Forms.Label _lblJPEG2000;
      private System.Windows.Forms.TextBox _txtInputFile;
      private System.Windows.Forms.Button _btnInputBrowse;
      private System.Windows.Forms.Button _btnExtract;
      private System.Windows.Forms.GroupBox _grpFrameIndex;
      private System.Windows.Forms.TextBox _txtToFrame;
      private System.Windows.Forms.TextBox _txtFromFrame;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
   }
}