namespace MedicalViewerDemo
{
   partial class RepositionCellDialog
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.cellIndexlabel = new System.Windows.Forms.Label();
         this._chkShift = new System.Windows.Forms.RadioButton();
         this._chkSwap = new System.Windows.Forms.RadioButton();
         this._txtTargetIndex = new MedicalViewerDemo.NumericTextBox();
         this._txtCellIndex = new MedicalViewerDemo.NumericTextBox();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(85, 149);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(71, 29);
         this._btnCancel.TabIndex = 7;
         this._btnCancel.Text = "C&anc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(5, 149);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(71, 29);
         this._btnOK.TabIndex = 6;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this._txtTargetIndex);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this._txtCellIndex);
         this.groupBox1.Controls.Add(this.cellIndexlabel);
         this.groupBox1.Controls.Add(this._chkShift);
         this.groupBox1.Controls.Add(this._chkSwap);
         this.groupBox1.Location = new System.Drawing.Point(6, 6);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(151, 138);
         this.groupBox1.TabIndex = 5;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&New Cell Position";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Enabled = false;
         this.label2.Location = new System.Drawing.Point(17, 91);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(43, 13);
         this.label2.TabIndex = 6;
         this.label2.Text = "&Method";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 53);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(67, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "&Target Index";
         // 
         // cellIndexlabel
         // 
         this.cellIndexlabel.AutoSize = true;
         this.cellIndexlabel.Location = new System.Drawing.Point(17, 27);
         this.cellIndexlabel.Name = "cellIndexlabel";
         this.cellIndexlabel.Size = new System.Drawing.Size(53, 13);
         this.cellIndexlabel.TabIndex = 2;
         this.cellIndexlabel.Text = "&Cell Index";
         // 
         // _chkShift
         // 
         this._chkShift.AutoSize = true;
         this._chkShift.Location = new System.Drawing.Point(78, 111);
         this._chkShift.Name = "_chkShift";
         this._chkShift.Size = new System.Drawing.Size(46, 17);
         this._chkShift.TabIndex = 1;
         this._chkShift.TabStop = true;
         this._chkShift.Text = "&Shift";
         this._chkShift.UseVisualStyleBackColor = true;
         // 
         // _chkSwap
         // 
         this._chkSwap.AutoSize = true;
         this._chkSwap.Checked = true;
         this._chkSwap.Location = new System.Drawing.Point(78, 89);
         this._chkSwap.Name = "_chkSwap";
         this._chkSwap.Size = new System.Drawing.Size(52, 17);
         this._chkSwap.TabIndex = 0;
         this._chkSwap.TabStop = true;
         this._chkSwap.Text = "&Swap";
         this._chkSwap.UseVisualStyleBackColor = true;
         // 
         // _txtTargetIndex
         // 
         this._txtTargetIndex.Location = new System.Drawing.Point(78, 50);
         this._txtTargetIndex.MaximumAllowed = 1000;
         this._txtTargetIndex.MinimumAllowed = 0;
         this._txtTargetIndex.Name = "_txtTargetIndex";
         this._txtTargetIndex.Size = new System.Drawing.Size(53, 20);
         this._txtTargetIndex.TabIndex = 5;
         this._txtTargetIndex.Text = "0";
         this._txtTargetIndex.Value = 0;
         // 
         // _txtCellIndex
         // 
         this._txtCellIndex.Location = new System.Drawing.Point(78, 24);
         this._txtCellIndex.MaximumAllowed = 1000;
         this._txtCellIndex.MinimumAllowed = 0;
         this._txtCellIndex.Name = "_txtCellIndex";
         this._txtCellIndex.Size = new System.Drawing.Size(53, 20);
         this._txtCellIndex.TabIndex = 3;
         this._txtCellIndex.Text = "0";
         this._txtCellIndex.Value = 0;
         // 
         // RepositionCellDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(164, 184);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "RepositionCellDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Reposition Cell";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label2;
      private MedicalViewerDemo.NumericTextBox _txtTargetIndex;
      private System.Windows.Forms.Label label1;
      private MedicalViewerDemo.NumericTextBox _txtCellIndex;
      private System.Windows.Forms.Label cellIndexlabel;
      private System.Windows.Forms.RadioButton _chkShift;
      private System.Windows.Forms.RadioButton _chkSwap;

   }
}