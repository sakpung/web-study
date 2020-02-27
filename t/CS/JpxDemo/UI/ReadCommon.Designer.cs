namespace JPXDemo
{
   partial class ReadCommon
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadCommon));
         this._grpData = new System.Windows.Forms.GroupBox();
         this._lblSecond = new System.Windows.Forms.Label();
         this._txtSecond = new System.Windows.Forms.TextBox();
         this._btnSecondBrowse = new System.Windows.Forms.Button();
         this._grpFile = new System.Windows.Forms.GroupBox();
         this._lblJPEG2000 = new System.Windows.Forms.Label();
         this._txtJPEG2000 = new System.Windows.Forms.TextBox();
         this._btnJPEG2000Browse = new System.Windows.Forms.Button();
         this._grpBoxIndex = new System.Windows.Forms.GroupBox();
         this._nudBoxIndex = new System.Windows.Forms.NumericUpDown();
         this._btnRead = new System.Windows.Forms.Button();
         this._grpFilterType = new System.Windows.Forms.GroupBox();
         this._txtFilterType = new System.Windows.Forms.TextBox();
         this._grpData.SuspendLayout();
         this._grpFile.SuspendLayout();
         this._grpBoxIndex.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._nudBoxIndex)).BeginInit();
         this._grpFilterType.SuspendLayout();
         this.SuspendLayout();
         // 
         // _grpData
         // 
         this._grpData.Controls.Add(this._lblSecond);
         this._grpData.Controls.Add(this._txtSecond);
         this._grpData.Controls.Add(this._btnSecondBrowse);
         this._grpData.Location = new System.Drawing.Point(3, 79);
         this._grpData.Name = "_grpData";
         this._grpData.Size = new System.Drawing.Size(330, 67);
         this._grpData.TabIndex = 1;
         this._grpData.TabStop = false;
         this._grpData.Text = "Data";
         // 
         // _lblSecond
         // 
         this._lblSecond.AutoSize = true;
         this._lblSecond.Location = new System.Drawing.Point(6, 18);
         this._lblSecond.Name = "_lblSecond";
         this._lblSecond.Size = new System.Drawing.Size(35, 13);
         this._lblSecond.TabIndex = 0;
         this._lblSecond.Text = "label1";
         // 
         // _txtSecond
         // 
         this._txtSecond.Location = new System.Drawing.Point(9, 36);
         this._txtSecond.Name = "_txtSecond";
         this._txtSecond.Size = new System.Drawing.Size(232, 20);
         this._txtSecond.TabIndex = 1;
         // 
         // _btnSecondBrowse
         // 
         this._btnSecondBrowse.Location = new System.Drawing.Point(251, 34);
         this._btnSecondBrowse.Name = "_btnSecondBrowse";
         this._btnSecondBrowse.Size = new System.Drawing.Size(75, 23);
         this._btnSecondBrowse.TabIndex = 2;
         this._btnSecondBrowse.Text = "Browse";
         this._btnSecondBrowse.UseVisualStyleBackColor = true;
         this._btnSecondBrowse.Click += new System.EventHandler(this._btnSecondBrowse_Click);
         // 
         // _grpFile
         // 
         this._grpFile.Controls.Add(this._lblJPEG2000);
         this._grpFile.Controls.Add(this._txtJPEG2000);
         this._grpFile.Controls.Add(this._btnJPEG2000Browse);
         this._grpFile.Location = new System.Drawing.Point(3, 1);
         this._grpFile.Name = "_grpFile";
         this._grpFile.Size = new System.Drawing.Size(330, 72);
         this._grpFile.TabIndex = 0;
         this._grpFile.TabStop = false;
         this._grpFile.Text = "File";
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
         // _txtJPEG2000
         // 
         this._txtJPEG2000.Location = new System.Drawing.Point(13, 39);
         this._txtJPEG2000.Name = "_txtJPEG2000";
         this._txtJPEG2000.Size = new System.Drawing.Size(232, 20);
         this._txtJPEG2000.TabIndex = 1;
         // 
         // _btnJPEG2000Browse
         // 
         this._btnJPEG2000Browse.Location = new System.Drawing.Point(251, 37);
         this._btnJPEG2000Browse.Name = "_btnJPEG2000Browse";
         this._btnJPEG2000Browse.Size = new System.Drawing.Size(75, 23);
         this._btnJPEG2000Browse.TabIndex = 2;
         this._btnJPEG2000Browse.Text = "Browse";
         this._btnJPEG2000Browse.UseVisualStyleBackColor = true;
         this._btnJPEG2000Browse.Click += new System.EventHandler(this._btnJPEG2000Browse_Click);
         // 
         // _grpBoxIndex
         // 
         this._grpBoxIndex.Controls.Add(this._nudBoxIndex);
         this._grpBoxIndex.Location = new System.Drawing.Point(3, 203);
         this._grpBoxIndex.Name = "_grpBoxIndex";
         this._grpBoxIndex.Size = new System.Drawing.Size(241, 67);
         this._grpBoxIndex.TabIndex = 3;
         this._grpBoxIndex.TabStop = false;
         this._grpBoxIndex.Text = "Box Index - 0 based";
         // 
         // _nudBoxIndex
         // 
         this._nudBoxIndex.Location = new System.Drawing.Point(62, 30);
         this._nudBoxIndex.Name = "_nudBoxIndex";
         this._nudBoxIndex.Size = new System.Drawing.Size(117, 20);
         this._nudBoxIndex.TabIndex = 0;
         // 
         // _btnRead
         // 
         this._btnRead.Location = new System.Drawing.Point(254, 233);
         this._btnRead.Name = "_btnRead";
         this._btnRead.Size = new System.Drawing.Size(75, 23);
         this._btnRead.TabIndex = 4;
         this._btnRead.Text = "&Read";
         this._btnRead.UseVisualStyleBackColor = true;
         this._btnRead.Click += new System.EventHandler(this._btnRead_Click);
         // 
         // _grpFilterType
         // 
         this._grpFilterType.Controls.Add(this._txtFilterType);
         this._grpFilterType.Location = new System.Drawing.Point(3, 150);
         this._grpFilterType.Name = "_grpFilterType";
         this._grpFilterType.Size = new System.Drawing.Size(330, 48);
         this._grpFilterType.TabIndex = 2;
         this._grpFilterType.TabStop = false;
         this._grpFilterType.Text = "Filter Type";
         // 
         // _txtFilterType
         // 
         this._txtFilterType.Location = new System.Drawing.Point(40, 18);
         this._txtFilterType.Name = "_txtFilterType";
         this._txtFilterType.ReadOnly = true;
         this._txtFilterType.Size = new System.Drawing.Size(250, 20);
         this._txtFilterType.TabIndex = 0;
         // 
         // ReadCommon
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(339, 281);
         this.Controls.Add(this._grpFilterType);
         this.Controls.Add(this._btnRead);
         this.Controls.Add(this._grpBoxIndex);
         this.Controls.Add(this._grpData);
         this.Controls.Add(this._grpFile);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ReadCommon";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Read Common";
         this._grpData.ResumeLayout(false);
         this._grpData.PerformLayout();
         this._grpFile.ResumeLayout(false);
         this._grpFile.PerformLayout();
         this._grpBoxIndex.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._nudBoxIndex)).EndInit();
         this._grpFilterType.ResumeLayout(false);
         this._grpFilterType.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _grpData;
      private System.Windows.Forms.Label _lblSecond;
      private System.Windows.Forms.TextBox _txtSecond;
      private System.Windows.Forms.Button _btnSecondBrowse;
      private System.Windows.Forms.GroupBox _grpFile;
      private System.Windows.Forms.Label _lblJPEG2000;
      private System.Windows.Forms.TextBox _txtJPEG2000;
      private System.Windows.Forms.Button _btnJPEG2000Browse;
      private System.Windows.Forms.GroupBox _grpBoxIndex;
      private System.Windows.Forms.Button _btnRead;
      private System.Windows.Forms.NumericUpDown _nudBoxIndex;
      private System.Windows.Forms.GroupBox _grpFilterType;
      private System.Windows.Forms.TextBox _txtFilterType;
   }
}