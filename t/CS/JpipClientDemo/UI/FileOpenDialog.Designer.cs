namespace JpipClientDemo
{
   partial class FileOpenDialog
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
         this.rbtnFileName = new System.Windows.Forms.RadioButton();
         this.tbtnEnumerate = new System.Windows.Forms.RadioButton();
         this.txtFileName = new System.Windows.Forms.TextBox();
         this.pnlEnumerateService = new System.Windows.Forms.Panel();
         this.lstFiles = new System.Windows.Forms.ListBox();
         this.btnGetFiles = new System.Windows.Forms.Button();
         this.grpSepa = new System.Windows.Forms.GroupBox();
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.pnlEnumerateService.SuspendLayout();
         this.SuspendLayout();
         // 
         // rbtnFileName
         // 
         this.rbtnFileName.AutoSize = true;
         this.rbtnFileName.Checked = true;
         this.rbtnFileName.Location = new System.Drawing.Point(12, 12);
         this.rbtnFileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.rbtnFileName.Name = "rbtnFileName";
         this.rbtnFileName.Size = new System.Drawing.Size(145, 21);
         this.rbtnFileName.TabIndex = 0;
         this.rbtnFileName.TabStop = true;
         this.rbtnFileName.Text = "Enter image name:";
         this.rbtnFileName.UseVisualStyleBackColor = true;
         this.rbtnFileName.CheckedChanged += new System.EventHandler(this.rbtnFileName_CheckedChanged);
         // 
         // tbtnEnumerate
         // 
         this.tbtnEnumerate.AutoSize = true;
         this.tbtnEnumerate.Location = new System.Drawing.Point(12, 80);
         this.tbtnEnumerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.tbtnEnumerate.Name = "tbtnEnumerate";
         this.tbtnEnumerate.Size = new System.Drawing.Size(327, 21);
         this.tbtnEnumerate.TabIndex = 2;
         this.tbtnEnumerate.TabStop = true;
         this.tbtnEnumerate.Text = "Enumerate images from LEAD JPIP Server Demo";
         this.tbtnEnumerate.UseVisualStyleBackColor = true;
         // 
         // txtFileName
         // 
         this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtFileName.Location = new System.Drawing.Point(30, 39);
         this.txtFileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.txtFileName.Name = "txtFileName";
         this.txtFileName.Size = new System.Drawing.Size(485, 24);
         this.txtFileName.TabIndex = 1;
         this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
         // 
         // pnlEnumerateService
         // 
         this.pnlEnumerateService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.pnlEnumerateService.Controls.Add(this.lstFiles);
         this.pnlEnumerateService.Enabled = false;
         this.pnlEnumerateService.Location = new System.Drawing.Point(30, 105);
         this.pnlEnumerateService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.pnlEnumerateService.Name = "pnlEnumerateService";
         this.pnlEnumerateService.Size = new System.Drawing.Size(486, 318);
         this.pnlEnumerateService.TabIndex = 3;
         // 
         // lstFiles
         // 
         this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.lstFiles.FormattingEnabled = true;
         this.lstFiles.ItemHeight = 16;
         this.lstFiles.Location = new System.Drawing.Point(8, 5);
         this.lstFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.lstFiles.Name = "lstFiles";
         this.lstFiles.Size = new System.Drawing.Size(471, 308);
         this.lstFiles.TabIndex = 5;
         this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
         // 
         // btnGetFiles
         // 
         this.btnGetFiles.Enabled = false;
         this.btnGetFiles.Location = new System.Drawing.Point(345, 76);
         this.btnGetFiles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnGetFiles.Name = "btnGetFiles";
         this.btnGetFiles.Size = new System.Drawing.Size(77, 25);
         this.btnGetFiles.TabIndex = 4;
         this.btnGetFiles.Text = "Get Files";
         this.btnGetFiles.UseVisualStyleBackColor = true;
         this.btnGetFiles.Click += new System.EventHandler(this.btnGetFiles_Click);
         // 
         // grpSepa
         // 
         this.grpSepa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.grpSepa.Location = new System.Drawing.Point(-36, 425);
         this.grpSepa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.grpSepa.Name = "grpSepa";
         this.grpSepa.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.grpSepa.Size = new System.Drawing.Size(567, 2);
         this.grpSepa.TabIndex = 4;
         this.grpSepa.TabStop = false;
         // 
         // btnOK
         // 
         this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Enabled = false;
         this.btnOK.Location = new System.Drawing.Point(341, 434);
         this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 30);
         this.btnOK.TabIndex = 4;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(421, 434);
         this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 30);
         this.btnCancel.TabIndex = 5;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // FileOpenDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(521, 469);
         this.Controls.Add(this.btnOK);
         this.Controls.Add(this.btnGetFiles);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.grpSepa);
         this.Controls.Add(this.pnlEnumerateService);
         this.Controls.Add(this.txtFileName);
         this.Controls.Add(this.tbtnEnumerate);
         this.Controls.Add(this.rbtnFileName);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.MinimizeBox = false;
         this.Name = "FileOpenDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "File Open";
         this.pnlEnumerateService.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.RadioButton rbtnFileName;
      private System.Windows.Forms.RadioButton tbtnEnumerate;
      private System.Windows.Forms.TextBox txtFileName;
      private System.Windows.Forms.Panel pnlEnumerateService;
      private System.Windows.Forms.Button btnGetFiles;
      private System.Windows.Forms.ListBox lstFiles;
      private System.Windows.Forms.GroupBox grpSepa;
      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
   }
}