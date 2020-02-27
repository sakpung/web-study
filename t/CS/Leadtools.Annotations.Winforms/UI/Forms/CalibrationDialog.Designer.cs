namespace Leadtools.Annotations.WinForms
{
   partial class CalibrationDialog
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
         this._comboMesurementUnit = new System.Windows.Forms.ComboBox();
         this._btnOk = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this._txtRulerLength = new System.Windows.Forms.TextBox();
         this._btnCancel = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._cboxApplyToAllRulers = new System.Windows.Forms.CheckBox();
         this._lblApplyToAllRulers = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _comboMesurementUnit
         // 
         this._comboMesurementUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._comboMesurementUnit.FormattingEnabled = true;
         this._comboMesurementUnit.Items.AddRange(new object[] {
            "Unit",
            "Display",
            "Document",
            "SmartEnglish",
            "SmartMetric",
            "Inch",
            "Millimeter",
            "Point",
            "Feet",
            "Yard",
            "Micrometer",
            "Centimeter",
            "Meter",
            "Twip"});
         this._comboMesurementUnit.Location = new System.Drawing.Point(127, 49);
         this._comboMesurementUnit.Name = "_comboMesurementUnit";
         this._comboMesurementUnit.Size = new System.Drawing.Size(95, 21);
         this._comboMesurementUnit.TabIndex = 5;
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(73, 115);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(58, 23);
         this._btnOk.TabIndex = 10;
         this._btnOk.Text = "Ok";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(11, 52);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(102, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Measurement Unit  :";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(11, 26);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(101, 13);
         this.label3.TabIndex = 8;
         this.label3.Text = "Ruler Length          :";
         // 
         // _txtRulerLength
         // 
         this._txtRulerLength.Location = new System.Drawing.Point(127, 19);
         this._txtRulerLength.Name = "_txtRulerLength";
         this._txtRulerLength.Size = new System.Drawing.Size(95, 20);
         this._txtRulerLength.TabIndex = 11;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(137, 115);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(58, 23);
         this._btnCancel.TabIndex = 13;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._lblApplyToAllRulers);
         this.groupBox1.Controls.Add(this._cboxApplyToAllRulers);
         this.groupBox1.Controls.Add(this._txtRulerLength);
         this.groupBox1.Controls.Add(this._comboMesurementUnit);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Location = new System.Drawing.Point(12, 3);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(250, 103);
         this.groupBox1.TabIndex = 14;
         this.groupBox1.TabStop = false;
         // 
         // _cboxApplyToAllRulers
         // 
         this._cboxApplyToAllRulers.AutoSize = true;
         this._cboxApplyToAllRulers.Checked = true;
         this._cboxApplyToAllRulers.CheckState = System.Windows.Forms.CheckState.Checked;
         this._cboxApplyToAllRulers.Location = new System.Drawing.Point(127, 77);
         this._cboxApplyToAllRulers.Name = "_cboxApplyToAllRulers";
         this._cboxApplyToAllRulers.Size = new System.Drawing.Size(15, 14);
         this._cboxApplyToAllRulers.TabIndex = 12;
         this._cboxApplyToAllRulers.UseVisualStyleBackColor = true;
         this._cboxApplyToAllRulers.Visible = false;
         // 
         // _lblApplyToAllRulers
         // 
         this._lblApplyToAllRulers.AutoSize = true;
         this._lblApplyToAllRulers.Location = new System.Drawing.Point(11, 77);
         this._lblApplyToAllRulers.Name = "_lblApplyToAllRulers";
         this._lblApplyToAllRulers.Size = new System.Drawing.Size(101, 13);
         this._lblApplyToAllRulers.TabIndex = 13;
         this._lblApplyToAllRulers.Text = "Apply to all rulers    :";
         this._lblApplyToAllRulers.Visible = false;
         // 
         // CalibrationDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(274, 150);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CalibrationDialog";
         this.ShowIcon = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Calibrate Ruler";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ComboBox _comboMesurementUnit;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.TextBox _txtRulerLength;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label _lblApplyToAllRulers;
      private System.Windows.Forms.CheckBox _cboxApplyToAllRulers;

   }
}