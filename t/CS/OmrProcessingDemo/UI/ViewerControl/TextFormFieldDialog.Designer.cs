namespace OmrProcessingDemo.UI
{
   partial class OcrFieldDialog
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
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.lblName = new System.Windows.Forms.Label();
         this.txtName = new System.Windows.Forms.TextBox();
         this.grpTextType = new System.Windows.Forms.GroupBox();
         this.rdbtnData = new System.Windows.Forms.RadioButton();
         this.rdbtnNumerical = new System.Windows.Forms.RadioButton();
         this.rdbtnCharacter = new System.Windows.Forms.RadioButton();
         this.chkEnableOCR = new System.Windows.Forms.CheckBox();
         this.grpTextType.SuspendLayout();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.btnOK.Location = new System.Drawing.Point(125, 141);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 0;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(206, 141);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // lblName
         // 
         this.lblName.AutoSize = true;
         this.lblName.Location = new System.Drawing.Point(12, 9);
         this.lblName.Name = "lblName";
         this.lblName.Size = new System.Drawing.Size(38, 13);
         this.lblName.TabIndex = 2;
         this.lblName.Text = "Name:";
         // 
         // txtName
         // 
         this.txtName.Location = new System.Drawing.Point(56, 6);
         this.txtName.Name = "txtName";
         this.txtName.Size = new System.Drawing.Size(225, 20);
         this.txtName.TabIndex = 3;
         // 
         // grpTextType
         // 
         this.grpTextType.Controls.Add(this.rdbtnData);
         this.grpTextType.Controls.Add(this.rdbtnNumerical);
         this.grpTextType.Controls.Add(this.rdbtnCharacter);
         this.grpTextType.Location = new System.Drawing.Point(12, 32);
         this.grpTextType.Name = "grpTextType";
         this.grpTextType.Size = new System.Drawing.Size(101, 100);
         this.grpTextType.TabIndex = 4;
         this.grpTextType.TabStop = false;
         this.grpTextType.Text = "Text Type";
         // 
         // rdbtnData
         // 
         this.rdbtnData.AutoSize = true;
         this.rdbtnData.Location = new System.Drawing.Point(6, 65);
         this.rdbtnData.Name = "rdbtnData";
         this.rdbtnData.Size = new System.Drawing.Size(48, 17);
         this.rdbtnData.TabIndex = 2;
         this.rdbtnData.TabStop = true;
         this.rdbtnData.Text = "Data";
         this.rdbtnData.UseVisualStyleBackColor = true;
         this.rdbtnData.CheckedChanged += new System.EventHandler(this.rdBtnTextType_CheckChanged);
         // 
         // rdbtnNumerical
         // 
         this.rdbtnNumerical.AutoSize = true;
         this.rdbtnNumerical.Location = new System.Drawing.Point(6, 42);
         this.rdbtnNumerical.Name = "rdbtnNumerical";
         this.rdbtnNumerical.Size = new System.Drawing.Size(72, 17);
         this.rdbtnNumerical.TabIndex = 1;
         this.rdbtnNumerical.TabStop = true;
         this.rdbtnNumerical.Text = "Numerical";
         this.rdbtnNumerical.UseVisualStyleBackColor = true;
         this.rdbtnNumerical.CheckedChanged += new System.EventHandler(this.rdBtnTextType_CheckChanged);
         // 
         // rdbtnCharacter
         // 
         this.rdbtnCharacter.AutoSize = true;
         this.rdbtnCharacter.Location = new System.Drawing.Point(6, 19);
         this.rdbtnCharacter.Name = "rdbtnCharacter";
         this.rdbtnCharacter.Size = new System.Drawing.Size(71, 17);
         this.rdbtnCharacter.TabIndex = 0;
         this.rdbtnCharacter.TabStop = true;
         this.rdbtnCharacter.Text = "Character";
         this.rdbtnCharacter.UseVisualStyleBackColor = true;
         this.rdbtnCharacter.CheckedChanged += new System.EventHandler(this.rdBtnTextType_CheckChanged);
         // 
         // chkEnableOCR
         // 
         this.chkEnableOCR.AutoSize = true;
         this.chkEnableOCR.Location = new System.Drawing.Point(125, 52);
         this.chkEnableOCR.Name = "chkEnableOCR";
         this.chkEnableOCR.Size = new System.Drawing.Size(85, 17);
         this.chkEnableOCR.TabIndex = 5;
         this.chkEnableOCR.Text = "Enable OCR";
         this.chkEnableOCR.UseVisualStyleBackColor = true;
         this.chkEnableOCR.CheckedChanged += new System.EventHandler(this.chkEnableOCR_CheckedChanged);
         // 
         // OcrFieldDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(296, 181);
         this.Controls.Add(this.chkEnableOCR);
         this.Controls.Add(this.grpTextType);
         this.Controls.Add(this.txtName);
         this.Controls.Add(this.lblName);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OcrFieldDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "TextField";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OcrFieldDialog_FormClosing);
         this.grpTextType.ResumeLayout(false);
         this.grpTextType.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.Label lblName;
      private System.Windows.Forms.TextBox txtName;
      private System.Windows.Forms.GroupBox grpTextType;
      private System.Windows.Forms.RadioButton rdbtnData;
      private System.Windows.Forms.RadioButton rdbtnNumerical;
      private System.Windows.Forms.RadioButton rdbtnCharacter;
      private System.Windows.Forms.CheckBox chkEnableOCR;
   }
}