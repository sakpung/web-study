namespace AnimationDemo
{
   partial class FrameSettings
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
         this._chkWaitForUserInput = new System.Windows.Forms.CheckBox();
         this._lblDelay = new System.Windows.Forms.Label();
         this._tbDelay = new System.Windows.Forms.TextBox();
         this._chkApplyToAll = new System.Windows.Forms.CheckBox();
         this._tbLeft = new System.Windows.Forms.TextBox();
         this._lblLeft = new System.Windows.Forms.Label();
         this._tbTop = new System.Windows.Forms.TextBox();
         this._lblTop = new System.Windows.Forms.Label();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._cmbDisposalMethod = new System.Windows.Forms.ComboBox();
         this._lblDisposalMethod = new System.Windows.Forms.Label();
         this._chkTransparentColor = new System.Windows.Forms.CheckBox();
         this._btnChooseColor = new System.Windows.Forms.Button();
         this._pnlColor = new System.Windows.Forms.Panel();
         this.SuspendLayout();
         // 
         // _chkWaitForUserInput
         // 
         this._chkWaitForUserInput.AutoSize = true;
         this._chkWaitForUserInput.Location = new System.Drawing.Point(12, 48);
         this._chkWaitForUserInput.Name = "_chkWaitForUserInput";
         this._chkWaitForUserInput.Size = new System.Drawing.Size(118, 17);
         this._chkWaitForUserInput.TabIndex = 0;
         this._chkWaitForUserInput.Text = "&Wait For User Input";
         this._chkWaitForUserInput.UseVisualStyleBackColor = true;
         // 
         // _lblDelay
         // 
         this._lblDelay.AutoSize = true;
         this._lblDelay.Location = new System.Drawing.Point(9, 79);
         this._lblDelay.Name = "_lblDelay";
         this._lblDelay.Size = new System.Drawing.Size(62, 13);
         this._lblDelay.TabIndex = 1;
         this._lblDelay.Text = "&Delay (ms) :";
         this._lblDelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _tbDelay
         // 
         this._tbDelay.Location = new System.Drawing.Point(77, 76);
         this._tbDelay.Name = "_tbDelay";
         this._tbDelay.Size = new System.Drawing.Size(62, 20);
         this._tbDelay.TabIndex = 2;
         this._tbDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbDelay_KeyPress);
         // 
         // _chkApplyToAll
         // 
         this._chkApplyToAll.AutoSize = true;
         this._chkApplyToAll.Location = new System.Drawing.Point(207, 75);
         this._chkApplyToAll.Name = "_chkApplyToAll";
         this._chkApplyToAll.Size = new System.Drawing.Size(82, 17);
         this._chkApplyToAll.TabIndex = 3;
         this._chkApplyToAll.Text = "&Apply To All";
         this._chkApplyToAll.UseVisualStyleBackColor = true;
         // 
         // _tbLeft
         // 
         this._tbLeft.Location = new System.Drawing.Point(46, 143);
         this._tbLeft.Name = "_tbLeft";
         this._tbLeft.Size = new System.Drawing.Size(62, 20);
         this._tbLeft.TabIndex = 5;
         this._tbLeft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbLeft_KeyPress);
         // 
         // _lblLeft
         // 
         this._lblLeft.AutoSize = true;
         this._lblLeft.Location = new System.Drawing.Point(9, 145);
         this._lblLeft.Name = "_lblLeft";
         this._lblLeft.Size = new System.Drawing.Size(31, 13);
         this._lblLeft.TabIndex = 4;
         this._lblLeft.Text = "&Left :";
         // 
         // _tbTop
         // 
         this._tbTop.Location = new System.Drawing.Point(184, 143);
         this._tbTop.Name = "_tbTop";
         this._tbTop.Size = new System.Drawing.Size(62, 20);
         this._tbTop.TabIndex = 7;
         this._tbTop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbTop_KeyPress);
         // 
         // _lblTop
         // 
         this._lblTop.AutoSize = true;
         this._lblTop.Location = new System.Drawing.Point(146, 146);
         this._lblTop.Name = "_lblTop";
         this._lblTop.Size = new System.Drawing.Size(32, 13);
         this._lblTop.TabIndex = 6;
         this._lblTop.Text = "&Top :";
         // 
         // _btnOK
         // 
         this._btnOK.AccessibleDescription = "";
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(66, 183);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 8;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(152, 183);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 9;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _cmbDisposalMethod
         // 
         this._cmbDisposalMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbDisposalMethod.FormattingEnabled = true;
         this._cmbDisposalMethod.Location = new System.Drawing.Point(125, 106);
         this._cmbDisposalMethod.Name = "_cmbDisposalMethod";
         this._cmbDisposalMethod.Size = new System.Drawing.Size(121, 21);
         this._cmbDisposalMethod.TabIndex = 10;
         // 
         // _lblDisposalMethod
         // 
         this._lblDisposalMethod.Location = new System.Drawing.Point(9, 114);
         this._lblDisposalMethod.Name = "_lblDisposalMethod";
         this._lblDisposalMethod.Size = new System.Drawing.Size(92, 13);
         this._lblDisposalMethod.TabIndex = 11;
         this._lblDisposalMethod.Text = "Disposal &Method :";
         this._lblDisposalMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _chkTransparentColor
         // 
         this._chkTransparentColor.AutoSize = true;
         this._chkTransparentColor.Location = new System.Drawing.Point(12, 13);
         this._chkTransparentColor.Name = "_chkTransparentColor";
         this._chkTransparentColor.Size = new System.Drawing.Size(110, 17);
         this._chkTransparentColor.TabIndex = 12;
         this._chkTransparentColor.Text = "&Transparent Color";
         this._chkTransparentColor.UseVisualStyleBackColor = true;
         // 
         // _btnChooseColor
         // 
         this._btnChooseColor.Location = new System.Drawing.Point(194, 13);
         this._btnChooseColor.Name = "_btnChooseColor";
         this._btnChooseColor.Size = new System.Drawing.Size(95, 21);
         this._btnChooseColor.TabIndex = 14;
         this._btnChooseColor.Text = "&Choose Color >>";
         this._btnChooseColor.UseVisualStyleBackColor = true;
         this._btnChooseColor.Click += new System.EventHandler(this._btnChooseColor_Click);
         // 
         // _pnlColor
         // 
         this._pnlColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._pnlColor.Location = new System.Drawing.Point(122, 13);
         this._pnlColor.Name = "_pnlColor";
         this._pnlColor.Size = new System.Drawing.Size(62, 21);
         this._pnlColor.TabIndex = 15;
         // 
         // FrameSettings
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(293, 218);
         this.Controls.Add(this._pnlColor);
         this.Controls.Add(this._btnChooseColor);
         this.Controls.Add(this._chkTransparentColor);
         this.Controls.Add(this._lblDisposalMethod);
         this.Controls.Add(this._cmbDisposalMethod);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._tbTop);
         this.Controls.Add(this._lblTop);
         this.Controls.Add(this._tbLeft);
         this.Controls.Add(this._lblLeft);
         this.Controls.Add(this._chkApplyToAll);
         this.Controls.Add(this._tbDelay);
         this.Controls.Add(this._lblDelay);
         this.Controls.Add(this._chkWaitForUserInput);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrameSettings";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Frame Settings";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox _chkWaitForUserInput;
      private System.Windows.Forms.Label _lblDelay;
      private System.Windows.Forms.TextBox _tbDelay;
      private System.Windows.Forms.CheckBox _chkApplyToAll;
      private System.Windows.Forms.TextBox _tbLeft;
      private System.Windows.Forms.Label _lblLeft;
      private System.Windows.Forms.TextBox _tbTop;
      private System.Windows.Forms.Label _lblTop;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.ComboBox _cmbDisposalMethod;
      private System.Windows.Forms.Label _lblDisposalMethod;
      private System.Windows.Forms.CheckBox _chkTransparentColor;
      private System.Windows.Forms.Button _btnChooseColor;
      private System.Windows.Forms.Panel _pnlColor;
   }
}