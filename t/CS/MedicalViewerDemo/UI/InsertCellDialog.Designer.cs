namespace MedicalViewerDemo
{
   partial class InsertCellDialog
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
         this._chkAppend = new System.Windows.Forms.RadioButton();
         this._chkInsert = new System.Windows.Forms.RadioButton();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._txtCellIndex = new MedicalViewerDemo.NumericTextBox();
         this._lblCellIndex = new System.Windows.Forms.Label();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _chkAppend
         // 
         this._chkAppend.AutoSize = true;
         this._chkAppend.Location = new System.Drawing.Point(20, 25);
         this._chkAppend.Name = "_chkAppend";
         this._chkAppend.Size = new System.Drawing.Size(104, 17);
         this._chkAppend.TabIndex = 0;
         this._chkAppend.TabStop = true;
         this._chkAppend.Text = "&Append new cell";
         this._chkAppend.UseVisualStyleBackColor = true;
         // 
         // _chkInsert
         // 
         this._chkInsert.AutoSize = true;
         this._chkInsert.Location = new System.Drawing.Point(20, 54);
         this._chkInsert.Name = "_chkInsert";
         this._chkInsert.Size = new System.Drawing.Size(93, 17);
         this._chkInsert.TabIndex = 1;
         this._chkInsert.TabStop = true;
         this._chkInsert.Text = "&Insert new cell";
         this._chkInsert.UseVisualStyleBackColor = true;
         this._chkInsert.CheckedChanged += new System.EventHandler(this.insertNewCellRadio_CheckedChanged);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._txtCellIndex);
         this.groupBox1.Controls.Add(this._lblCellIndex);
         this.groupBox1.Controls.Add(this._chkInsert);
         this.groupBox1.Controls.Add(this._chkAppend);
         this.groupBox1.Location = new System.Drawing.Point(9, 2);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(151, 121);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&New Cell Position";
         // 
         // _txtCellIndex
         // 
         this._txtCellIndex.Enabled = false;
         this._txtCellIndex.Location = new System.Drawing.Point(74, 90);
         this._txtCellIndex.MaximumAllowed = 1000;
         this._txtCellIndex.MinimumAllowed = -1000;
         this._txtCellIndex.Name = "_txtCellIndex";
         this._txtCellIndex.Size = new System.Drawing.Size(53, 20);
         this._txtCellIndex.TabIndex = 3;
         this._txtCellIndex.Value = 0;
         // 
         // _lblCellIndex
         // 
         this._lblCellIndex.AutoSize = true;
         this._lblCellIndex.Enabled = false;
         this._lblCellIndex.Location = new System.Drawing.Point(15, 93);
         this._lblCellIndex.Name = "_lblCellIndex";
         this._lblCellIndex.Size = new System.Drawing.Size(53, 13);
         this._lblCellIndex.TabIndex = 2;
         this._lblCellIndex.Text = "&Cell Index";
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(9, 129);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(71, 29);
         this._btnOK.TabIndex = 3;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this.okButton_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(89, 129);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(71, 29);
         this._btnCancel.TabIndex = 4;
         this._btnCancel.Text = "C&anc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // InsertCellDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(169, 166);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "InsertCellDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Insert Cell";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.RadioButton _chkAppend;
      private System.Windows.Forms.RadioButton _chkInsert;
      private System.Windows.Forms.GroupBox groupBox1;
      private NumericTextBox _txtCellIndex;
      private System.Windows.Forms.Label _lblCellIndex;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
   }
}