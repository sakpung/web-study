namespace MedicalViewerDemo
{
   partial class NudgeShrinkToolDialog
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
         this._rdoNudgeBackSlash = new System.Windows.Forms.RadioButton();
         this._rdoNudgeSlash = new System.Windows.Forms.RadioButton();
         this._rdoNudgeEllipse = new System.Windows.Forms.RadioButton();
         this._rdoNudgeRectangle = new System.Windows.Forms.RadioButton();
         this._txtNudgeHeight = new MedicalViewerDemo.NumericTextBox();
         this._txtNudgeWidth = new MedicalViewerDemo.NumericTextBox();
         this.label7 = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._rdoShrinkBackSlash = new System.Windows.Forms.RadioButton();
         this._rdoShrinkSlash = new System.Windows.Forms.RadioButton();
         this._rdoShrinkEllipse = new System.Windows.Forms.RadioButton();
         this._rdoShrinkRectangle = new System.Windows.Forms.RadioButton();
         this._txtShrinkHeight = new MedicalViewerDemo.NumericTextBox();
         this.label1 = new System.Windows.Forms.Label();
         this._txtShrinkWidth = new MedicalViewerDemo.NumericTextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.groupBox3.SuspendLayout();
         this.groupBox1.SuspendLayout();
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
         this.groupBox3.Controls.Add(this._rdoNudgeBackSlash);
         this.groupBox3.Controls.Add(this._rdoNudgeSlash);
         this.groupBox3.Controls.Add(this._rdoNudgeEllipse);
         this.groupBox3.Controls.Add(this._rdoNudgeRectangle);
         this.groupBox3.Controls.Add(this._txtNudgeHeight);
         this.groupBox3.Controls.Add(this.label8);
         this.groupBox3.Controls.Add(this._txtNudgeWidth);
         this.groupBox3.Controls.Add(this.label7);
         this.groupBox3.Location = new System.Drawing.Point(12, 12);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(152, 200);
         this.groupBox3.TabIndex = 17;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "&Nudge tool brush properties";
         // 
         // _rdoNudgeBackSlash
         // 
         this._rdoNudgeBackSlash.AutoSize = true;
         this._rdoNudgeBackSlash.Location = new System.Drawing.Point(18, 93);
         this._rdoNudgeBackSlash.Name = "_rdoNudgeBackSlash";
         this._rdoNudgeBackSlash.Size = new System.Drawing.Size(74, 17);
         this._rdoNudgeBackSlash.TabIndex = 18;
         this._rdoNudgeBackSlash.TabStop = true;
         this._rdoNudgeBackSlash.Text = "&Back slash";
         this._rdoNudgeBackSlash.UseVisualStyleBackColor = true;
         // 
         // _rdoNudgeSlash
         // 
         this._rdoNudgeSlash.AutoSize = true;
         this._rdoNudgeSlash.Location = new System.Drawing.Point(18, 70);
         this._rdoNudgeSlash.Name = "_rdoNudgeSlash";
         this._rdoNudgeSlash.Size = new System.Drawing.Size(50, 17);
         this._rdoNudgeSlash.TabIndex = 17;
         this._rdoNudgeSlash.TabStop = true;
         this._rdoNudgeSlash.Text = "&Slash";
         this._rdoNudgeSlash.UseVisualStyleBackColor = true;
         // 
         // _rdoNudgeEllipse
         // 
         this._rdoNudgeEllipse.AutoSize = true;
         this._rdoNudgeEllipse.Location = new System.Drawing.Point(18, 47);
         this._rdoNudgeEllipse.Name = "_rdoNudgeEllipse";
         this._rdoNudgeEllipse.Size = new System.Drawing.Size(54, 17);
         this._rdoNudgeEllipse.TabIndex = 16;
         this._rdoNudgeEllipse.TabStop = true;
         this._rdoNudgeEllipse.Text = "&Ellipse";
         this._rdoNudgeEllipse.UseVisualStyleBackColor = true;
         // 
         // _rdoNudgeRectangle
         // 
         this._rdoNudgeRectangle.AutoSize = true;
         this._rdoNudgeRectangle.Location = new System.Drawing.Point(18, 24);
         this._rdoNudgeRectangle.Name = "_rdoNudgeRectangle";
         this._rdoNudgeRectangle.Size = new System.Drawing.Size(73, 17);
         this._rdoNudgeRectangle.TabIndex = 15;
         this._rdoNudgeRectangle.TabStop = true;
         this._rdoNudgeRectangle.Text = "&Rectangle";
         this._rdoNudgeRectangle.UseVisualStyleBackColor = true;
         // 
         // _txtNudgeHeight
         // 
         this._txtNudgeHeight.Location = new System.Drawing.Point(56, 162);
         this._txtNudgeHeight.MaximumAllowed = 100;
         this._txtNudgeHeight.MinimumAllowed = 0;
         this._txtNudgeHeight.Name = "_txtNudgeHeight";
         this._txtNudgeHeight.Size = new System.Drawing.Size(41, 20);
         this._txtNudgeHeight.TabIndex = 14;
         this._txtNudgeHeight.Text = "0";
         this._txtNudgeHeight.Value = 0;
         // 
         // _txtNudgeWidth
         // 
         this._txtNudgeWidth.Location = new System.Drawing.Point(56, 127);
         this._txtNudgeWidth.MaximumAllowed = 100;
         this._txtNudgeWidth.MinimumAllowed = 0;
         this._txtNudgeWidth.Name = "_txtNudgeWidth";
         this._txtNudgeWidth.Size = new System.Drawing.Size(41, 20);
         this._txtNudgeWidth.TabIndex = 10;
         this._txtNudgeWidth.Text = "0";
         this._txtNudgeWidth.Value = 0;
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
         this._btnCancel.Location = new System.Drawing.Point(176, 220);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(70, 29);
         this._btnCancel.TabIndex = 19;
         this._btnCancel.Text = "Canc&el";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnOK.Location = new System.Drawing.Point(94, 220);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(70, 29);
         this._btnOK.TabIndex = 18;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._rdoShrinkBackSlash);
         this.groupBox1.Controls.Add(this._rdoShrinkSlash);
         this.groupBox1.Controls.Add(this._rdoShrinkEllipse);
         this.groupBox1.Controls.Add(this._rdoShrinkRectangle);
         this.groupBox1.Controls.Add(this._txtShrinkHeight);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this._txtShrinkWidth);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Location = new System.Drawing.Point(176, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(152, 200);
         this.groupBox1.TabIndex = 19;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&Shrink tool brush properties";
         // 
         // _rdoShrinkBackSlash
         // 
         this._rdoShrinkBackSlash.AutoSize = true;
         this._rdoShrinkBackSlash.Location = new System.Drawing.Point(18, 93);
         this._rdoShrinkBackSlash.Name = "_rdoShrinkBackSlash";
         this._rdoShrinkBackSlash.Size = new System.Drawing.Size(74, 17);
         this._rdoShrinkBackSlash.TabIndex = 18;
         this._rdoShrinkBackSlash.TabStop = true;
         this._rdoShrinkBackSlash.Text = "&Back slash";
         this._rdoShrinkBackSlash.UseVisualStyleBackColor = true;
         // 
         // _rdoShrinkSlash
         // 
         this._rdoShrinkSlash.AutoSize = true;
         this._rdoShrinkSlash.Location = new System.Drawing.Point(18, 70);
         this._rdoShrinkSlash.Name = "_rdoShrinkSlash";
         this._rdoShrinkSlash.Size = new System.Drawing.Size(50, 17);
         this._rdoShrinkSlash.TabIndex = 17;
         this._rdoShrinkSlash.TabStop = true;
         this._rdoShrinkSlash.Text = "&Slash";
         this._rdoShrinkSlash.UseVisualStyleBackColor = true;
         // 
         // _rdoShrinkEllipse
         // 
         this._rdoShrinkEllipse.AutoSize = true;
         this._rdoShrinkEllipse.Location = new System.Drawing.Point(18, 47);
         this._rdoShrinkEllipse.Name = "_rdoShrinkEllipse";
         this._rdoShrinkEllipse.Size = new System.Drawing.Size(54, 17);
         this._rdoShrinkEllipse.TabIndex = 16;
         this._rdoShrinkEllipse.TabStop = true;
         this._rdoShrinkEllipse.Text = "&Ellipse";
         this._rdoShrinkEllipse.UseVisualStyleBackColor = true;
         // 
         // _rdoShrinkRectangle
         // 
         this._rdoShrinkRectangle.AutoSize = true;
         this._rdoShrinkRectangle.Location = new System.Drawing.Point(18, 24);
         this._rdoShrinkRectangle.Name = "_rdoShrinkRectangle";
         this._rdoShrinkRectangle.Size = new System.Drawing.Size(73, 17);
         this._rdoShrinkRectangle.TabIndex = 15;
         this._rdoShrinkRectangle.TabStop = true;
         this._rdoShrinkRectangle.Text = "&Rectangle";
         this._rdoShrinkRectangle.UseVisualStyleBackColor = true;
         // 
         // _txtShrinkHeight
         // 
         this._txtShrinkHeight.Location = new System.Drawing.Point(56, 162);
         this._txtShrinkHeight.MaximumAllowed = 100;
         this._txtShrinkHeight.MinimumAllowed = 0;
         this._txtShrinkHeight.Name = "_txtShrinkHeight";
         this._txtShrinkHeight.Size = new System.Drawing.Size(41, 20);
         this._txtShrinkHeight.TabIndex = 14;
         this._txtShrinkHeight.Text = "0";
         this._txtShrinkHeight.Value = 0;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(9, 165);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(38, 13);
         this.label1.TabIndex = 13;
         this.label1.Text = "&Height";
         // 
         // _txtShrinkWidth
         // 
         this._txtShrinkWidth.Location = new System.Drawing.Point(56, 127);
         this._txtShrinkWidth.MaximumAllowed = 100;
         this._txtShrinkWidth.MinimumAllowed = 0;
         this._txtShrinkWidth.Name = "_txtShrinkWidth";
         this._txtShrinkWidth.Size = new System.Drawing.Size(41, 20);
         this._txtShrinkWidth.TabIndex = 10;
         this._txtShrinkWidth.Text = "0";
         this._txtShrinkWidth.Value = 0;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(10, 130);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(35, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "&Width";
         // 
         // NudgeShrinkToolDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(340, 259);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.groupBox3);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "NudgeShrinkToolDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Nudge Tool Dialog";
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private NumericTextBox _txtNudgeHeight;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.GroupBox groupBox3;
      private NumericTextBox _txtNudgeWidth;
      private System.Windows.Forms.Label label7;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.RadioButton _rdoNudgeBackSlash;
      private System.Windows.Forms.RadioButton _rdoNudgeSlash;
      private System.Windows.Forms.RadioButton _rdoNudgeEllipse;
      private System.Windows.Forms.RadioButton _rdoNudgeRectangle;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.RadioButton _rdoShrinkBackSlash;
      private System.Windows.Forms.RadioButton _rdoShrinkSlash;
      private System.Windows.Forms.RadioButton _rdoShrinkEllipse;
      private System.Windows.Forms.RadioButton _rdoShrinkRectangle;
      private NumericTextBox _txtShrinkHeight;
      private System.Windows.Forms.Label label1;
      private NumericTextBox _txtShrinkWidth;
      private System.Windows.Forms.Label label2;
   }
}