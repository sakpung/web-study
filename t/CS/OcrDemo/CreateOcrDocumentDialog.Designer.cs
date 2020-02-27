namespace OcrDemo
{
   partial class CreateOcrDocumentDialog
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
         this.label1 = new System.Windows.Forms.Label();
         this._lblOcrDocumentFile = new System.Windows.Forms.Label();
         this._cmbDocumentMode = new System.Windows.Forms.ComboBox();
         this._tbOcrDocumentFile = new System.Windows.Forms.TextBox();
         this._btnBrowse = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._lblHints = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(12, 19);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(129, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Document creation mode:";
         // 
         // _lblOcrDocumentFile
         // 
         this._lblOcrDocumentFile.AutoSize = true;
         this._lblOcrDocumentFile.Location = new System.Drawing.Point(12, 47);
         this._lblOcrDocumentFile.Name = "_lblOcrDocumentFile";
         this._lblOcrDocumentFile.Size = new System.Drawing.Size(104, 13);
         this._lblOcrDocumentFile.TabIndex = 1;
         this._lblOcrDocumentFile.Text = "OCR Document File:";
         // 
         // _cmbDocumentMode
         // 
         this._cmbDocumentMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbDocumentMode.FormattingEnabled = true;
         this._cmbDocumentMode.Items.AddRange(new object[] {
            "File",
            "Memory"});
         this._cmbDocumentMode.Location = new System.Drawing.Point(148, 16);
         this._cmbDocumentMode.Name = "_cmbDocumentMode";
         this._cmbDocumentMode.Size = new System.Drawing.Size(177, 21);
         this._cmbDocumentMode.TabIndex = 2;
         this._cmbDocumentMode.SelectedIndexChanged += new System.EventHandler(this._cmbDocumentMode_SelectedIndexChanged);
         // 
         // _tbOcrDocumentFile
         // 
         this._tbOcrDocumentFile.Location = new System.Drawing.Point(148, 44);
         this._tbOcrDocumentFile.Name = "_tbOcrDocumentFile";
         this._tbOcrDocumentFile.Size = new System.Drawing.Size(249, 20);
         this._tbOcrDocumentFile.TabIndex = 3;
         // 
         // _btnBrowse
         // 
         this._btnBrowse.Location = new System.Drawing.Point(403, 42);
         this._btnBrowse.Name = "_btnBrowse";
         this._btnBrowse.Size = new System.Drawing.Size(38, 23);
         this._btnBrowse.TabIndex = 4;
         this._btnBrowse.Text = "&...";
         this._btnBrowse.UseVisualStyleBackColor = true;
         this._btnBrowse.Click += new System.EventHandler(this._btnBrowse_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._lblHints);
         this.groupBox1.Location = new System.Drawing.Point(15, 81);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(426, 133);
         this.groupBox1.TabIndex = 5;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Hints";
         // 
         // _lblHints
         // 
         this._lblHints.Location = new System.Drawing.Point(16, 25);
         this._lblHints.Name = "_lblHints";
         this._lblHints.Size = new System.Drawing.Size(395, 95);
         this._lblHints.TabIndex = 0;
         this._lblHints.Text = "Document creation mode hints";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(367, 220);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 6;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(286, 220);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 7;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         // 
         // CreateOcrDocumentDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(454, 253);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnBrowse);
         this.Controls.Add(this._tbOcrDocumentFile);
         this.Controls.Add(this._cmbDocumentMode);
         this.Controls.Add(this._lblOcrDocumentFile);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "CreateOcrDocumentDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Create OCR Document";
         this.Load += new System.EventHandler(this.CreateOcrDocumentDialog_Load);
         this.groupBox1.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label _lblOcrDocumentFile;
      private System.Windows.Forms.ComboBox _cmbDocumentMode;
      private System.Windows.Forms.TextBox _tbOcrDocumentFile;
      private System.Windows.Forms.Button _btnBrowse;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label _lblHints;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
   }
}