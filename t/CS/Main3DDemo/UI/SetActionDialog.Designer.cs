namespace Main3DDemo
{
   partial class SetActionDialog
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
         this._cmbMouseButton = new System.Windows.Forms.ComboBox();
         this._cmbApplyTo = new System.Windows.Forms.ComboBox();
         this._cmbApplyingMethod = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._btnApply = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _cmbMouseButton
         // 
         this._cmbMouseButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbMouseButton.FormattingEnabled = true;
         this._cmbMouseButton.Items.AddRange(new object[] {
            "None",
            "Left Button",
            "Right Button",
            "Middle Button"});
         this._cmbMouseButton.Location = new System.Drawing.Point(104, 19);
         this._cmbMouseButton.Name = "_cmbMouseButton";
         this._cmbMouseButton.Size = new System.Drawing.Size(92, 21);
         this._cmbMouseButton.TabIndex = 0;
         this._cmbMouseButton.SelectedIndexChanged += new System.EventHandler(this._cmbMouseButton_SelectedIndexChanged);
         // 
         // _cmbApplyTo
         // 
         this._cmbApplyTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbApplyTo.FormattingEnabled = true;
         this._cmbApplyTo.Items.AddRange(new object[] {
            "Active Cell"});
         this._cmbApplyTo.Location = new System.Drawing.Point(78, 60);
         this._cmbApplyTo.Name = "_cmbApplyTo";
         this._cmbApplyTo.Size = new System.Drawing.Size(118, 21);
         this._cmbApplyTo.TabIndex = 1;
         this._cmbApplyTo.SelectedIndexChanged += new System.EventHandler(this._cmbApplyTo_SelectedIndexChanged);
         // 
         // _cmbApplyingMethod
         // 
         this._cmbApplyingMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbApplyingMethod.FormattingEnabled = true;
         this._cmbApplyingMethod.Items.AddRange(new object[] {
            "RealTime"});
         this._cmbApplyingMethod.Location = new System.Drawing.Point(107, 101);
         this._cmbApplyingMethod.Name = "_cmbApplyingMethod";
         this._cmbApplyingMethod.Size = new System.Drawing.Size(89, 21);
         this._cmbApplyingMethod.TabIndex = 2;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(14, 23);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(72, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "&Mouse button";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(14, 64);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(45, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "&Apply to";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(14, 105);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(85, 13);
         this.label3.TabIndex = 5;
         this.label3.Text = "A&pplying method";
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this._cmbApplyingMethod);
         this.groupBox1.Controls.Add(this._cmbApplyTo);
         this.groupBox1.Controls.Add(this._cmbMouseButton);
         this.groupBox1.Location = new System.Drawing.Point(11, 5);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(210, 137);
         this.groupBox1.TabIndex = 6;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Prope&rties";
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(158, 149);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(64, 29);
         this._btnApply.TabIndex = 17;
         this._btnApply.Text = "App&ly";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(83, 149);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(64, 29);
         this._btnCancel.TabIndex = 16;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(11, 149);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(64, 29);
         this._btnOK.TabIndex = 15;
         this._btnOK.Text = "O&K";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // SetActionDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(230, 185);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SetActionDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Set Action";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ComboBox _cmbMouseButton;
      private System.Windows.Forms.ComboBox _cmbApplyTo;
      private System.Windows.Forms.ComboBox _cmbApplyingMethod;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
   }
}