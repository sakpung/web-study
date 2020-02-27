namespace ImageProcessingDemo
{
   partial class GrayScaleToMultitoneDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrayScaleToMultitoneDialog));
          this._gbInk = new System.Windows.Forms.GroupBox();
          this._lblColor4 = new System.Windows.Forms.Label();
          this._lblColor3 = new System.Windows.Forms.Label();
          this._lblColor2 = new System.Windows.Forms.Label();
          this._lblColor1 = new System.Windows.Forms.Label();
          this._cmbChannels = new System.Windows.Forms.ComboBox();
          this._lblChannels = new System.Windows.Forms.Label();
          this._lblType = new System.Windows.Forms.Label();
          this._cmbType = new System.Windows.Forms.ComboBox();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbInk.SuspendLayout();
          this.SuspendLayout();
          // 
          // _gbInk
          // 
          this._gbInk.Controls.Add(this._lblColor4);
          this._gbInk.Controls.Add(this._lblColor3);
          this._gbInk.Controls.Add(this._lblColor2);
          this._gbInk.Controls.Add(this._lblColor1);
          this._gbInk.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbInk, "_gbInk");
          this._gbInk.Name = "_gbInk";
          this._gbInk.TabStop = false;
          // 
          // _lblColor4
          // 
          this._lblColor4.BackColor = System.Drawing.Color.White;
          this._lblColor4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          resources.ApplyResources(this._lblColor4, "_lblColor4");
          this._lblColor4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
          this._lblColor4.Name = "_lblColor4";
          this._lblColor4.MouseClick += new System.Windows.Forms.MouseEventHandler(this._lblColor4_MouseClick);
          // 
          // _lblColor3
          // 
          this._lblColor3.BackColor = System.Drawing.Color.White;
          this._lblColor3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          resources.ApplyResources(this._lblColor3, "_lblColor3");
          this._lblColor3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
          this._lblColor3.Name = "_lblColor3";
          this._lblColor3.MouseClick += new System.Windows.Forms.MouseEventHandler(this._lblColor3_MouseClick);
          // 
          // _lblColor2
          // 
          this._lblColor2.BackColor = System.Drawing.Color.White;
          this._lblColor2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          resources.ApplyResources(this._lblColor2, "_lblColor2");
          this._lblColor2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
          this._lblColor2.Name = "_lblColor2";
          this._lblColor2.MouseClick += new System.Windows.Forms.MouseEventHandler(this._lblColor2_MouseClick);
          // 
          // _lblColor1
          // 
          this._lblColor1.BackColor = System.Drawing.Color.Black;
          this._lblColor1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          this._lblColor1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
          resources.ApplyResources(this._lblColor1, "_lblColor1");
          this._lblColor1.Name = "_lblColor1";
          this._lblColor1.MouseClick += new System.Windows.Forms.MouseEventHandler(this._lblColor1_MouseClick);
          // 
          // _cmbChannels
          // 
          this._cmbChannels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbChannels, "_cmbChannels");
          this._cmbChannels.FormattingEnabled = true;
          this._cmbChannels.Name = "_cmbChannels";
          this._cmbChannels.SelectedIndexChanged += new System.EventHandler(this._cmbChannels_SelectedIndexChanged);
          // 
          // _lblChannels
          // 
          resources.ApplyResources(this._lblChannels, "_lblChannels");
          this._lblChannels.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblChannels.Name = "_lblChannels";
          // 
          // _lblType
          // 
          resources.ApplyResources(this._lblType, "_lblType");
          this._lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblType.Name = "_lblType";
          // 
          // _cmbType
          // 
          this._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbType, "_cmbType");
          this._cmbType.FormattingEnabled = true;
          this._cmbType.Name = "_cmbType";
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _btnOk
          // 
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // GrayScaleToMultitoneDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._cmbType);
          this.Controls.Add(this._lblType);
          this.Controls.Add(this._lblChannels);
          this.Controls.Add(this._cmbChannels);
          this.Controls.Add(this._gbInk);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "GrayScaleToMultitoneDialog";
          this.ShowIcon = false;
          this._gbInk.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbInk;
      private System.Windows.Forms.Label _lblColor4;
      private System.Windows.Forms.Label _lblColor3;
      private System.Windows.Forms.Label _lblColor2;
      private System.Windows.Forms.Label _lblColor1;
      private System.Windows.Forms.ComboBox _cmbChannels;
      private System.Windows.Forms.Label _lblChannels;
      private System.Windows.Forms.Label _lblType;
      private System.Windows.Forms.ComboBox _cmbType;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}