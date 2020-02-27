namespace JPXDemo
{
   partial class ReadGML
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReadGML));
         this._grpFile = new System.Windows.Forms.GroupBox();
         this._lblJPEG2000 = new System.Windows.Forms.Label();
         this._txtJPEG2000 = new System.Windows.Forms.TextBox();
         this._btnJPEG2000Browse = new System.Windows.Forms.Button();
         this._btnRead = new System.Windows.Forms.Button();
         this._grpFile.SuspendLayout();
         this.SuspendLayout();
         // 
         // _grpFile
         // 
         this._grpFile.Controls.Add(this._lblJPEG2000);
         this._grpFile.Controls.Add(this._txtJPEG2000);
         this._grpFile.Controls.Add(this._btnJPEG2000Browse);
         this._grpFile.Location = new System.Drawing.Point(5, 5);
         this._grpFile.Name = "_grpFile";
         this._grpFile.Size = new System.Drawing.Size(330, 72);
         this._grpFile.TabIndex = 1;
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
         // _btnRead
         // 
         this._btnRead.Location = new System.Drawing.Point(134, 83);
         this._btnRead.Name = "_btnRead";
         this._btnRead.Size = new System.Drawing.Size(75, 23);
         this._btnRead.TabIndex = 2;
         this._btnRead.Text = "&Read";
         this._btnRead.UseVisualStyleBackColor = true;
         this._btnRead.Click += new System.EventHandler(this._btnRead_Click);
         // 
         // ReadGML
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(343, 110);
         this.Controls.Add(this._btnRead);
         this.Controls.Add(this._grpFile);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ReadGML";
         this.ShowInTaskbar = false;
         this.Text = "Read GML Data";
         this._grpFile.ResumeLayout(false);
         this._grpFile.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _grpFile;
      private System.Windows.Forms.Label _lblJPEG2000;
      private System.Windows.Forms.TextBox _txtJPEG2000;
      private System.Windows.Forms.Button _btnJPEG2000Browse;
      private System.Windows.Forms.Button _btnRead;
   }
}