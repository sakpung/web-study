namespace MedicalViewerDemo
{
   partial class HiliteAnnotationDialog
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
         this._lblColor = new System.Windows.Forms.Label();
         this._btnColor = new System.Windows.Forms.Button();
         this._cmbApplyTo = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._radEdge = new System.Windows.Forms.RadioButton();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnApply = new System.Windows.Forms.Button();
         this._radCenter = new System.Windows.Forms.RadioButton();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _lblColor
         // 
         this._lblColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._lblColor.Location = new System.Drawing.Point(94, 59);
         this._lblColor.Name = "_lblColor";
         this._lblColor.Size = new System.Drawing.Size(67, 31);
         this._lblColor.TabIndex = 3;
         // 
         // _btnColor
         // 
         this._btnColor.Location = new System.Drawing.Point(20, 59);
         this._btnColor.Name = "_btnColor";
         this._btnColor.Size = new System.Drawing.Size(68, 31);
         this._btnColor.TabIndex = 2;
         this._btnColor.Text = "C&olor";
         this._btnColor.UseVisualStyleBackColor = true;
         this._btnColor.Click += new System.EventHandler(this._btnColor_Click);
         // 
         // _cmbApplyTo
         // 
         this._cmbApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbApplyTo.FormattingEnabled = true;
         this._cmbApplyTo.Items.AddRange(new object[] {
            "Selected",
            "All Hilite Objects",
            "All Objects"});
         this._cmbApplyTo.Location = new System.Drawing.Point(73, 21);
         this._cmbApplyTo.Name = "_cmbApplyTo";
         this._cmbApplyTo.Size = new System.Drawing.Size(94, 21);
         this._cmbApplyTo.TabIndex = 1;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(14, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(45, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "&Apply to";
         // 
         // label3
         // 
         this.label3.Location = new System.Drawing.Point(7, 104);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(56, 33);
         this.label3.TabIndex = 4;
         this.label3.Text = "Creation &Method";
         this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(75, 158);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(58, 29);
         this._btnCancel.TabIndex = 14;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _radEdge
         // 
         this._radEdge.AutoSize = true;
         this._radEdge.Checked = true;
         this._radEdge.Location = new System.Drawing.Point(129, 112);
         this._radEdge.Name = "_radEdge";
         this._radEdge.Size = new System.Drawing.Size(50, 17);
         this._radEdge.TabIndex = 6;
         this._radEdge.TabStop = true;
         this._radEdge.Text = "&Edge";
         this._radEdge.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(9, 158);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(58, 29);
         this._btnOK.TabIndex = 13;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(140, 158);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(58, 29);
         this._btnApply.TabIndex = 15;
         this._btnApply.Text = "App&ly";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // _radCenter
         // 
         this._radCenter.AutoSize = true;
         this._radCenter.Location = new System.Drawing.Point(69, 112);
         this._radCenter.Name = "_radCenter";
         this._radCenter.Size = new System.Drawing.Size(56, 17);
         this._radCenter.TabIndex = 5;
         this._radCenter.TabStop = true;
         this._radCenter.Text = "&Center";
         this._radCenter.UseVisualStyleBackColor = true;
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._radEdge);
         this.groupBox1.Controls.Add(this._radCenter);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this._lblColor);
         this.groupBox1.Controls.Add(this._btnColor);
         this.groupBox1.Controls.Add(this._cmbApplyTo);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(9, 3);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(188, 147);
         this.groupBox1.TabIndex = 12;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Cell &properties";
         // 
         // HiliteAnnotationDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(207, 191);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "HiliteAnnotationDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Hilite Dialog";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblColor;
      private System.Windows.Forms.Button _btnColor;
      private System.Windows.Forms.ComboBox _cmbApplyTo;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.RadioButton _radEdge;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.RadioButton _radCenter;
      private System.Windows.Forms.GroupBox groupBox1;

   }
}