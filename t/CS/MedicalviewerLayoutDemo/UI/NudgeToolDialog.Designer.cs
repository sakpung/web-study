namespace MedicalViewerLayoutDemo
{
   partial class NudgeToolDialog
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
         this.label8 = new System.Windows.Forms.Label();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this._rdoBackSlash = new System.Windows.Forms.RadioButton();
         this._rdoSlash = new System.Windows.Forms.RadioButton();
         this._rdoEllipse = new System.Windows.Forms.RadioButton();
         this._rdoRectangle = new System.Windows.Forms.RadioButton();
         this._txtHeight = new MedicalViewerLayoutDemo.NumericTextBox();
         this._txtWidth = new MedicalViewerLayoutDemo.NumericTextBox();
         this.label7 = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox3.SuspendLayout();
         this.SuspendLayout();
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(9, 165);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(38, 13);
         this.label8.TabIndex = 13;
         this.label8.Text = "&Height";
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this._rdoBackSlash);
         this.groupBox3.Controls.Add(this._rdoSlash);
         this.groupBox3.Controls.Add(this._rdoEllipse);
         this.groupBox3.Controls.Add(this._rdoRectangle);
         this.groupBox3.Controls.Add(this._txtHeight);
         this.groupBox3.Controls.Add(this.label8);
         this.groupBox3.Controls.Add(this._txtWidth);
         this.groupBox3.Controls.Add(this.label7);
         this.groupBox3.Location = new System.Drawing.Point(12, 12);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(152, 200);
         this.groupBox3.TabIndex = 17;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "&Nudge tool brush properties";
         // 
         // _rdoBackSlash
         // 
         this._rdoBackSlash.AutoSize = true;
         this._rdoBackSlash.Location = new System.Drawing.Point(18, 93);
         this._rdoBackSlash.Name = "_rdoBackSlash";
         this._rdoBackSlash.Size = new System.Drawing.Size(77, 17);
         this._rdoBackSlash.TabIndex = 18;
         this._rdoBackSlash.TabStop = true;
         this._rdoBackSlash.Text = "&Back slash";
         this._rdoBackSlash.UseVisualStyleBackColor = true;
         // 
         // _rdoSlash
         // 
         this._rdoSlash.AutoSize = true;
         this._rdoSlash.Location = new System.Drawing.Point(18, 70);
         this._rdoSlash.Name = "_rdoSlash";
         this._rdoSlash.Size = new System.Drawing.Size(51, 17);
         this._rdoSlash.TabIndex = 17;
         this._rdoSlash.TabStop = true;
         this._rdoSlash.Text = "&Slash";
         this._rdoSlash.UseVisualStyleBackColor = true;
         // 
         // _rdoEllipse
         // 
         this._rdoEllipse.AutoSize = true;
         this._rdoEllipse.Location = new System.Drawing.Point(18, 47);
         this._rdoEllipse.Name = "_rdoEllipse";
         this._rdoEllipse.Size = new System.Drawing.Size(55, 17);
         this._rdoEllipse.TabIndex = 16;
         this._rdoEllipse.TabStop = true;
         this._rdoEllipse.Text = "&Ellipse";
         this._rdoEllipse.UseVisualStyleBackColor = true;
         // 
         // _rdoRectangle
         // 
         this._rdoRectangle.AutoSize = true;
         this._rdoRectangle.Location = new System.Drawing.Point(18, 24);
         this._rdoRectangle.Name = "_rdoRectangle";
         this._rdoRectangle.Size = new System.Drawing.Size(74, 17);
         this._rdoRectangle.TabIndex = 15;
         this._rdoRectangle.TabStop = true;
         this._rdoRectangle.Text = "&Rectangle";
         this._rdoRectangle.UseVisualStyleBackColor = true;
         // 
         // _txtHeight
         // 
         this._txtHeight.Location = new System.Drawing.Point(56, 162);
         this._txtHeight.MaximumAllowed = 100;
         this._txtHeight.MinimumAllowed = 0;
         this._txtHeight.Name = "_txtHeight";
         this._txtHeight.Size = new System.Drawing.Size(41, 20);
         this._txtHeight.TabIndex = 14;
         this._txtHeight.Text = "0";
         this._txtHeight.Value = 0;
         // 
         // _txtWidth
         // 
         this._txtWidth.Location = new System.Drawing.Point(56, 127);
         this._txtWidth.MaximumAllowed = 100;
         this._txtWidth.MinimumAllowed = 0;
         this._txtWidth.Name = "_txtWidth";
         this._txtWidth.Size = new System.Drawing.Size(41, 20);
         this._txtWidth.TabIndex = 10;
         this._txtWidth.Text = "0";
         this._txtWidth.Value = 0;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(10, 130);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(35, 13);
         this.label7.TabIndex = 4;
         this.label7.Text = "&Width";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(92, 220);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(70, 29);
         this._btnCancel.TabIndex = 19;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnOK.Location = new System.Drawing.Point(12, 220);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(70, 29);
         this._btnOK.TabIndex = 18;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // NudgeToolDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(175, 259);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "NudgeToolDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Stack Dialog";
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private NumericTextBox _txtHeight;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.GroupBox groupBox3;
      private NumericTextBox _txtWidth;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.RadioButton _rdoBackSlash;
      private System.Windows.Forms.RadioButton _rdoSlash;
      private System.Windows.Forms.RadioButton _rdoEllipse;
      private System.Windows.Forms.RadioButton _rdoRectangle;
   }
}