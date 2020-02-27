namespace SpecialEffectsDemo
{
   partial class TextDialog
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
         if(disposing && (components != null))
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
         this._lblTextStyle = new System.Windows.Forms.Label();
         this._tbText = new System.Windows.Forms.TextBox();
         this._lblText = new System.Windows.Forms.Label();
         this._cmbTextStyle = new System.Windows.Forms.ComboBox();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._btnBorderColor = new System.Windows.Forms.Button();
         this._lblBorderColor = new System.Windows.Forms.Label();
         this._btnTextColor = new System.Windows.Forms.Button();
         this._lblTextColor = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _lblTextStyle
         // 
         this._lblTextStyle.AutoSize = true;
         this._lblTextStyle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblTextStyle.Location = new System.Drawing.Point(8, 56);
         this._lblTextStyle.Name = "_lblTextStyle";
         this._lblTextStyle.Size = new System.Drawing.Size(60, 13);
         this._lblTextStyle.TabIndex = 2;
         this._lblTextStyle.Text = "Text Style :";
         // 
         // _tbText
         // 
         this._tbText.Location = new System.Drawing.Point(72, 18);
         this._tbText.Name = "_tbText";
         this._tbText.Size = new System.Drawing.Size(237, 20);
         this._tbText.TabIndex = 1;
         this._tbText.Text = "LEADTOOLS";
         // 
         // _lblText
         // 
         this._lblText.AutoSize = true;
         this._lblText.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblText.Location = new System.Drawing.Point(8, 25);
         this._lblText.Name = "_lblText";
         this._lblText.Size = new System.Drawing.Size(34, 13);
         this._lblText.TabIndex = 0;
         this._lblText.Text = "Text :";
         // 
         // _cmbTextStyle
         // 
         this._cmbTextStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbTextStyle.FormattingEnabled = true;
         this._cmbTextStyle.Location = new System.Drawing.Point(72, 51);
         this._cmbTextStyle.Name = "_cmbTextStyle";
         this._cmbTextStyle.Size = new System.Drawing.Size(238, 21);
         this._cmbTextStyle.TabIndex = 3;
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._btnBorderColor);
         this._gbOptions.Controls.Add(this._lblBorderColor);
         this._gbOptions.Controls.Add(this._btnTextColor);
         this._gbOptions.Controls.Add(this._lblTextColor);
         this._gbOptions.Controls.Add(this._lblTextStyle);
         this._gbOptions.Controls.Add(this._tbText);
         this._gbOptions.Controls.Add(this._lblText);
         this._gbOptions.Controls.Add(this._cmbTextStyle);
         this._gbOptions.Location = new System.Drawing.Point(5, 2);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Size = new System.Drawing.Size(319, 161);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         // 
         // _btnBorderColor
         // 
         this._btnBorderColor.ForeColor = System.Drawing.SystemColors.ControlText;
         this._btnBorderColor.Location = new System.Drawing.Point(72, 120);
         this._btnBorderColor.Name = "_btnBorderColor";
         this._btnBorderColor.Size = new System.Drawing.Size(75, 23);
         this._btnBorderColor.TabIndex = 7;
         this._btnBorderColor.Text = "\r\n";
         this._btnBorderColor.UseVisualStyleBackColor = false;
         this._btnBorderColor.Click += new System.EventHandler(this._btnBorderColor_Click);
         // 
         // _lblBorderColor
         // 
         this._lblBorderColor.AutoSize = true;
         this._lblBorderColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblBorderColor.Location = new System.Drawing.Point(8, 125);
         this._lblBorderColor.Name = "_lblBorderColor";
         this._lblBorderColor.Size = new System.Drawing.Size(71, 13);
         this._lblBorderColor.TabIndex = 6;
         this._lblBorderColor.Text = "Border Color :";
         // 
         // _btnTextColor
         // 
         this._btnTextColor.ForeColor = System.Drawing.Color.Black;
         this._btnTextColor.Location = new System.Drawing.Point(72, 87);
         this._btnTextColor.Name = "_btnTextColor";
         this._btnTextColor.Size = new System.Drawing.Size(75, 23);
         this._btnTextColor.TabIndex = 5;
         this._btnTextColor.UseVisualStyleBackColor = false;
         this._btnTextColor.Click += new System.EventHandler(this._btnTextColor_Click);
         // 
         // _lblTextColor
         // 
         this._lblTextColor.AutoSize = true;
         this._lblTextColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblTextColor.Location = new System.Drawing.Point(8, 92);
         this._lblTextColor.Name = "_lblTextColor";
         this._lblTextColor.Size = new System.Drawing.Size(58, 13);
         this._lblTextColor.TabIndex = 4;
         this._lblTextColor.Text = "Text Color:";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(168, 171);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOK.Location = new System.Drawing.Point(87, 171);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 1;
         this._btnOK.Text = "OK\r\n";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // TextDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(330, 202);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "TextDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Text Dialog";
         this.Load += new System.EventHandler(this.NewTextDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this._gbOptions.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblTextStyle;
      private System.Windows.Forms.TextBox _tbText;
      private System.Windows.Forms.Label _lblText;
      private System.Windows.Forms.ComboBox _cmbTextStyle;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnBorderColor;
      private System.Windows.Forms.Label _lblBorderColor;
      private System.Windows.Forms.Button _btnTextColor;
      private System.Windows.Forms.Label _lblTextColor;
   }
}