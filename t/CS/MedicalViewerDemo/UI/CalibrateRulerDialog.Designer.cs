namespace MedicalViewerDemo
{
   partial class CalibrateRulerDialog
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
         this._btnApply = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._chkApplyToAll = new System.Windows.Forms.CheckBox();
         this._cmbUnit = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this._txtDistance = new MedicalViewerDemo.FNumericTextBox();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(156, 110);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(71, 29);
         this._btnApply.TabIndex = 19;
         this._btnApply.Text = "App&ly";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this.applyButton_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(80, 110);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(71, 29);
         this._btnCancel.TabIndex = 18;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(5, 110);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(71, 29);
         this._btnOK.TabIndex = 17;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this.okButton_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._chkApplyToAll);
         this.groupBox1.Controls.Add(this._txtDistance);
         this.groupBox1.Controls.Add(this._cmbUnit);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(6, 7);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(218, 96);
         this.groupBox1.TabIndex = 16;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&Arrow Properties";
         // 
         // _chkApplyToAll
         // 
         this._chkApplyToAll.AutoSize = true;
         this._chkApplyToAll.Location = new System.Drawing.Point(9, 68);
         this._chkApplyToAll.Name = "_chkApplyToAll";
         this._chkApplyToAll.Size = new System.Drawing.Size(121, 17);
         this._chkApplyToAll.TabIndex = 5;
         this._chkApplyToAll.Text = "A&pply to all sub-cells";
         this._chkApplyToAll.UseVisualStyleBackColor = true;
         // 
         // _cmbUnit
         // 
         this._cmbUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbUnit.FormattingEnabled = true;
         this._cmbUnit.Items.AddRange(new object[] {
            "Inches",
            "Feet",
            "Micrometers",
            "Millimeters",
            "Centimeters",
            "Meters"});
         this._cmbUnit.Location = new System.Drawing.Point(111, 27);
         this._cmbUnit.Name = "_cmbUnit";
         this._cmbUnit.Size = new System.Drawing.Size(96, 21);
         this._cmbUnit.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(7, 31);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(49, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "&Distance";
         // 
         // _txtDistance
         // 
         this._txtDistance.Location = new System.Drawing.Point(65, 28);
         this._txtDistance.MaximumAllowed = 100;
         this._txtDistance.MinimumAllowed = 0.1;
         this._txtDistance.Name = "_txtDistance";
         this._txtDistance.Size = new System.Drawing.Size(41, 20);
         this._txtDistance.TabIndex = 4;
         this._txtDistance.Text = "0";
         this._txtDistance.Value = 0;
         // 
         // CalibrateRulerDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(231, 146);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CalibrateRulerDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Calibrate Dialog";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox _cmbUnit;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.CheckBox _chkApplyToAll;
      private FNumericTextBox _txtDistance;
   }
}