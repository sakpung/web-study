namespace DocumentCleanupDemo
{
   partial class SmoothTextDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmoothTextDialog));
          this._gb1 = new System.Windows.Forms.GroupBox();
          this._rbShort = new System.Windows.Forms.RadioButton();
          this._rbLong = new System.Windows.Forms.RadioButton();
          this._tbLength = new System.Windows.Forms.TextBox();
          this._lblBumpNickLength = new System.Windows.Forms.Label();
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._gb1.SuspendLayout();
          this.SuspendLayout();
          // 
          // _gb1
          // 
          this._gb1.Controls.Add(this._rbShort);
          this._gb1.Controls.Add(this._rbLong);
          this._gb1.Controls.Add(this._tbLength);
          this._gb1.Controls.Add(this._lblBumpNickLength);
          this._gb1.Location = new System.Drawing.Point(12, 12);
          this._gb1.Name = "_gb1";
          this._gb1.Size = new System.Drawing.Size(213, 105);
          this._gb1.TabIndex = 0;
          this._gb1.TabStop = false;
          this._gb1.Text = "Smooth Options";
          // 
          // _rbShort
          // 
          this._rbShort.AutoSize = true;
          this._rbShort.Location = new System.Drawing.Point(22, 75);
          this._rbShort.Name = "_rbShort";
          this._rbShort.Size = new System.Drawing.Size(147, 17);
          this._rbShort.TabIndex = 3;
          this._rbShort.TabStop = true;
          this._rbShort.Text = "Favor Short Bumps/Nicks";
          this._rbShort.UseVisualStyleBackColor = true;
          // 
          // _rbLong
          // 
          this._rbLong.AutoSize = true;
          this._rbLong.Location = new System.Drawing.Point(22, 52);
          this._rbLong.Name = "_rbLong";
          this._rbLong.Size = new System.Drawing.Size(146, 17);
          this._rbLong.TabIndex = 2;
          this._rbLong.TabStop = true;
          this._rbLong.Text = "Favor Long Bumps/Nicks";
          this._rbLong.UseVisualStyleBackColor = true;
          // 
          // _tbLength
          // 
          this._tbLength.Location = new System.Drawing.Point(122, 21);
          this._tbLength.MaxLength = 5;
          this._tbLength.Name = "_tbLength";
          this._tbLength.Size = new System.Drawing.Size(76, 20);
          this._tbLength.TabIndex = 1;
          this._tbLength.TextChanged += new System.EventHandler(this._tbLength_TextChanged);
          // 
          // _lblBumpNickLength
          // 
          this._lblBumpNickLength.AutoSize = true;
          this._lblBumpNickLength.Location = new System.Drawing.Point(19, 28);
          this._lblBumpNickLength.Name = "_lblBumpNickLength";
          this._lblBumpNickLength.Size = new System.Drawing.Size(97, 13);
          this._lblBumpNickLength.TabIndex = 0;
          this._lblBumpNickLength.Text = "Bump/Nick Length";
          // 
          // _btnOk
          // 
          this._btnOk.Location = new System.Drawing.Point(231, 12);
          this._btnOk.Name = "_btnOk";
          this._btnOk.Size = new System.Drawing.Size(75, 23);
          this._btnOk.TabIndex = 1;
          this._btnOk.Text = "OK";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnCancel.Location = new System.Drawing.Point(231, 41);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(75, 23);
          this._btnCancel.TabIndex = 2;
          this._btnCancel.Text = "Cancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // SmoothTextDialog
          // 
          this.AcceptButton = this._btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.ClientSize = new System.Drawing.Size(315, 128);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gb1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "SmoothTextDialog";
          this.Text = "Smooth Text ";
          this._gb1.ResumeLayout(false);
          this._gb1.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gb1;
      private System.Windows.Forms.RadioButton _rbShort;
      private System.Windows.Forms.RadioButton _rbLong;
      private System.Windows.Forms.TextBox _tbLength;
      private System.Windows.Forms.Label _lblBumpNickLength;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}