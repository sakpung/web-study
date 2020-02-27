namespace MedicalViewerDemo
{
   partial class AngleAnnotationDialog
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._lblColor = new System.Windows.Forms.Label();
         this._btnColor = new System.Windows.Forms.Button();
         this._cmbApplyTo = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this._btnApply = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._lblColor);
         this.groupBox1.Controls.Add(this._btnColor);
         this.groupBox1.Controls.Add(this._cmbApplyTo);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(8, 6);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(176, 110);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&Angle Properties";
         // 
         // _lblColor
         // 
         this._lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblColor.Location = new System.Drawing.Point(90, 68);
         this._lblColor.Name = "_lblColor";
         this._lblColor.Size = new System.Drawing.Size(60, 26);
         this._lblColor.TabIndex = 3;
         // 
         // _btnColor
         // 
         this._btnColor.Location = new System.Drawing.Point(19, 68);
         this._btnColor.Name = "_btnColor";
         this._btnColor.Size = new System.Drawing.Size(60, 27);
         this._btnColor.TabIndex = 2;
         this._btnColor.Text = "&Color";
         this._btnColor.UseVisualStyleBackColor = true;
         this._btnColor.Click += new System.EventHandler(this._btnColor_Click);
         // 
         // _cmbApplyTo
         // 
         this._cmbApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbApplyTo.FormattingEnabled = true;
         this._cmbApplyTo.Items.AddRange(new object[] {
            "Selected",
            "All Angles",
            "All Objects"});
         this._cmbApplyTo.Location = new System.Drawing.Point(77, 27);
         this._cmbApplyTo.Name = "_cmbApplyTo";
         this._cmbApplyTo.Size = new System.Drawing.Size(75, 21);
         this._cmbApplyTo.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(22, 30);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(45, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "&Apply to";
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(129, 122);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(57, 29);
         this._btnApply.TabIndex = 11;
         this._btnApply.Text = "App&ly";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(68, 122);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(57, 29);
         this._btnCancel.TabIndex = 10;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(7, 122);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(57, 29);
         this._btnOK.TabIndex = 9;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // AngleAnnotationDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(192, 156);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AngleAnnotationDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Angle Dialog";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox _cmbApplyTo;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnColor;
      private System.Windows.Forms.Label _lblColor;
   }
}