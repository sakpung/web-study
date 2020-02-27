namespace OcrZonesRubberBandDemo
{
   partial class SetResolution
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
         this._gbSetRes = new System.Windows.Forms.GroupBox();
         this._txtYRes = new System.Windows.Forms.TextBox();
         this._lblYRes = new System.Windows.Forms.Label();
         this._txtXRes = new System.Windows.Forms.TextBox();
         this._lblXRes = new System.Windows.Forms.Label();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbSetRes.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbSetRes
         // 
         this._gbSetRes.Controls.Add(this._txtYRes);
         this._gbSetRes.Controls.Add(this._lblYRes);
         this._gbSetRes.Controls.Add(this._txtXRes);
         this._gbSetRes.Controls.Add(this._lblXRes);
         this._gbSetRes.Location = new System.Drawing.Point(12, 12);
         this._gbSetRes.Name = "_gbSetRes";
         this._gbSetRes.Size = new System.Drawing.Size(200, 78);
         this._gbSetRes.TabIndex = 0;
         this._gbSetRes.TabStop = false;
         // 
         // _txtYRes
         // 
         this._txtYRes.Location = new System.Drawing.Point(82, 43);
         this._txtYRes.Name = "_txtYRes";
         this._txtYRes.Size = new System.Drawing.Size(100, 20);
         this._txtYRes.TabIndex = 4;
         this._txtYRes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtYRes_KeyPress);
         this._txtYRes.TextChanged += new System.EventHandler(this._txtYRes_TextChanged);
         // 
         // _lblYRes
         // 
         this._lblYRes.AutoSize = true;
         this._lblYRes.Location = new System.Drawing.Point(6, 43);
         this._lblYRes.Name = "_lblYRes";
         this._lblYRes.Size = new System.Drawing.Size(70, 13);
         this._lblYRes.TabIndex = 4;
         this._lblYRes.Text = "Y Resolution:";
         // 
         // _txtXRes
         // 
         this._txtXRes.Location = new System.Drawing.Point(82, 14);
         this._txtXRes.Name = "_txtXRes";
         this._txtXRes.Size = new System.Drawing.Size(100, 20);
         this._txtXRes.TabIndex = 3;
         this._txtXRes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtXRes_KeyPress);
         this._txtXRes.TextChanged += new System.EventHandler(this._txtXRes_TextChanged);
         // 
         // _lblXRes
         // 
         this._lblXRes.AutoSize = true;
         this._lblXRes.Location = new System.Drawing.Point(6, 19);
         this._lblXRes.Name = "_lblXRes";
         this._lblXRes.Size = new System.Drawing.Size(70, 13);
         this._lblXRes.TabIndex = 3;
         this._lblXRes.Text = "X Resolution:";
         // 
         // _btnOk
         // 
         this._btnOk.Location = new System.Drawing.Point(218, 26);
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
         this._btnCancel.Location = new System.Drawing.Point(218, 50);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // SetResolution
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(303, 107);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbSetRes);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SetResolution";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Load Resolution";
         this.Load += new System.EventHandler(this.SetResolution_Load);
         this._gbSetRes.ResumeLayout(false);
         this._gbSetRes.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbSetRes;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblYRes;
      private System.Windows.Forms.Label _lblXRes;
      private System.Windows.Forms.TextBox _txtYRes;
      private System.Windows.Forms.TextBox _txtXRes;
   }
}