namespace OcrMultiThreadingDemo
{
   partial class ConversionControl
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
         if(disposing && (components != null))
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
         this._pbProgress = new System.Windows.Forms.ProgressBar();
         this._lblSuccess = new System.Windows.Forms.Label();
         this._lbSuccess = new System.Windows.Forms.ListBox();
         this._lbError = new System.Windows.Forms.ListBox();
         this._lblError = new System.Windows.Forms.Label();
         this._lblInformation = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnConvertMoreFiles = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _pbProgress
         // 
         this._pbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._pbProgress.Location = new System.Drawing.Point(16, 49);
         this._pbProgress.Name = "_pbProgress";
         this._pbProgress.Size = new System.Drawing.Size(718, 23);
         this._pbProgress.TabIndex = 1;
         // 
         // _lblSuccess
         // 
         this._lblSuccess.AutoSize = true;
         this._lblSuccess.Location = new System.Drawing.Point(16, 97);
         this._lblSuccess.Name = "_lblSuccess";
         this._lblSuccess.Size = new System.Drawing.Size(175, 13);
         this._lblSuccess.TabIndex = 3;
         this._lblSuccess.Text = "Documents converted successfully:";
         // 
         // _lbSuccess
         // 
         this._lbSuccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._lbSuccess.FormattingEnabled = true;
         this._lbSuccess.HorizontalScrollbar = true;
         this._lbSuccess.Location = new System.Drawing.Point(19, 114);
         this._lbSuccess.Name = "_lbSuccess";
         this._lbSuccess.Size = new System.Drawing.Size(798, 95);
         this._lbSuccess.TabIndex = 4;
         // 
         // _lbError
         // 
         this._lbError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._lbError.FormattingEnabled = true;
         this._lbError.HorizontalScrollbar = true;
         this._lbError.Location = new System.Drawing.Point(19, 254);
         this._lbError.Name = "_lbError";
         this._lbError.Size = new System.Drawing.Size(798, 95);
         this._lbError.TabIndex = 6;
         // 
         // _lblError
         // 
         this._lblError.AutoSize = true;
         this._lblError.Location = new System.Drawing.Point(16, 237);
         this._lblError.Name = "_lblError";
         this._lblError.Size = new System.Drawing.Size(37, 13);
         this._lblError.TabIndex = 5;
         this._lblError.Text = "Errors:";
         // 
         // _lblInformation
         // 
         this._lblInformation.AutoSize = true;
         this._lblInformation.Location = new System.Drawing.Point(16, 22);
         this._lblInformation.Name = "_lblInformation";
         this._lblInformation.Size = new System.Drawing.Size(250, 13);
         this._lblInformation.TabIndex = 0;
         this._lblInformation.Text = "Total number of documents, total number of threads";
         // 
         // _btnCancel
         // 
         this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this._btnCancel.Location = new System.Drawing.Point(740, 49);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnConvertMoreFiles
         // 
         this._btnConvertMoreFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this._btnConvertMoreFiles.Location = new System.Drawing.Point(19, 366);
         this._btnConvertMoreFiles.Name = "_btnConvertMoreFiles";
         this._btnConvertMoreFiles.Size = new System.Drawing.Size(158, 23);
         this._btnConvertMoreFiles.TabIndex = 7;
         this._btnConvertMoreFiles.Text = "Convert more files";
         this._btnConvertMoreFiles.UseVisualStyleBackColor = true;
         this._btnConvertMoreFiles.Click += new System.EventHandler(this._btnConvertMoreFiles_Click);
         // 
         // ConversionControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._btnConvertMoreFiles);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._lblInformation);
         this.Controls.Add(this._lbError);
         this.Controls.Add(this._lblError);
         this.Controls.Add(this._lbSuccess);
         this.Controls.Add(this._lblSuccess);
         this.Controls.Add(this._pbProgress);
         this.Name = "ConversionControl";
         this.Size = new System.Drawing.Size(833, 404);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ProgressBar _pbProgress;
      private System.Windows.Forms.Label _lblSuccess;
      private System.Windows.Forms.ListBox _lbSuccess;
      private System.Windows.Forms.ListBox _lbError;
      private System.Windows.Forms.Label _lblError;
      private System.Windows.Forms.Label _lblInformation;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnConvertMoreFiles;
   }
}
