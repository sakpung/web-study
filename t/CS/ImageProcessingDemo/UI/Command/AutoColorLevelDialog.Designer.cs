namespace ImageProcessingDemo
{
   partial class AutoColorLevelDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoColorLevelDialog));
          this._lblBlackClip = new System.Windows.Forms.Label();
          this._tbBlackClip = new System.Windows.Forms.TrackBar();
          this._numBlackClip = new System.Windows.Forms.NumericUpDown();
          this._lblWhiteClip = new System.Windows.Forms.Label();
          this._tbWhiteClip = new System.Windows.Forms.TrackBar();
          this._numWhiteClip = new System.Windows.Forms.NumericUpDown();
          this._lblFlag = new System.Windows.Forms.Label();
          this._cmbFlag = new System.Windows.Forms.ComboBox();
          this._lblType = new System.Windows.Forms.Label();
          this._cmbType = new System.Windows.Forms.ComboBox();
          this._gp1 = new System.Windows.Forms.GroupBox();
          this._gb2 = new System.Windows.Forms.GroupBox();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          ((System.ComponentModel.ISupportInitialize)(this._tbBlackClip)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numBlackClip)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbWhiteClip)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWhiteClip)).BeginInit();
          this._gp1.SuspendLayout();
          this._gb2.SuspendLayout();
          this.SuspendLayout();
          // 
          // _lblBlackClip
          // 
          resources.ApplyResources(this._lblBlackClip, "_lblBlackClip");
          this._lblBlackClip.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblBlackClip.Name = "_lblBlackClip";
          // 
          // _tbBlackClip
          // 
          resources.ApplyResources(this._tbBlackClip, "_tbBlackClip");
          this._tbBlackClip.Maximum = 10000;
          this._tbBlackClip.Name = "_tbBlackClip";
          this._tbBlackClip.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbBlackClip.Scroll += new System.EventHandler(this._tbBlackClip_Scroll);
          // 
          // _numBlackClip
          // 
          resources.ApplyResources(this._numBlackClip, "_numBlackClip");
          this._numBlackClip.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
          this._numBlackClip.Name = "_numBlackClip";
          this._numBlackClip.ValueChanged += new System.EventHandler(this._numBlackClip_ValueChanged);
          this._numBlackClip.Leave += new System.EventHandler(this._numBlackClip_Leave);
          // 
          // _lblWhiteClip
          // 
          resources.ApplyResources(this._lblWhiteClip, "_lblWhiteClip");
          this._lblWhiteClip.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblWhiteClip.Name = "_lblWhiteClip";
          // 
          // _tbWhiteClip
          // 
          resources.ApplyResources(this._tbWhiteClip, "_tbWhiteClip");
          this._tbWhiteClip.Maximum = 10000;
          this._tbWhiteClip.Name = "_tbWhiteClip";
          this._tbWhiteClip.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbWhiteClip.Scroll += new System.EventHandler(this._tbWhiteClip_Scroll);
          // 
          // _numWhiteClip
          // 
          resources.ApplyResources(this._numWhiteClip, "_numWhiteClip");
          this._numWhiteClip.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
          this._numWhiteClip.Name = "_numWhiteClip";
          this._numWhiteClip.ValueChanged += new System.EventHandler(this._numWhiteClip_ValueChanged);
          this._numWhiteClip.Leave += new System.EventHandler(this._numWhiteClip_Leave);
          // 
          // _lblFlag
          // 
          resources.ApplyResources(this._lblFlag, "_lblFlag");
          this._lblFlag.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblFlag.Name = "_lblFlag";
          // 
          // _cmbFlag
          // 
          this._cmbFlag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbFlag, "_cmbFlag");
          this._cmbFlag.FormattingEnabled = true;
          this._cmbFlag.Name = "_cmbFlag";
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
          // _gp1
          // 
          this._gp1.Controls.Add(this._lblWhiteClip);
          this._gp1.Controls.Add(this._cmbType);
          this._gp1.Controls.Add(this._lblBlackClip);
          this._gp1.Controls.Add(this._lblType);
          this._gp1.Controls.Add(this._tbBlackClip);
          this._gp1.Controls.Add(this._cmbFlag);
          this._gp1.Controls.Add(this._numBlackClip);
          this._gp1.Controls.Add(this._lblFlag);
          this._gp1.Controls.Add(this._tbWhiteClip);
          this._gp1.Controls.Add(this._numWhiteClip);
          resources.ApplyResources(this._gp1, "_gp1");
          this._gp1.Name = "_gp1";
          this._gp1.TabStop = false;
          // 
          // _gb2
          // 
          this._gb2.Controls.Add(this._btnCancel);
          this._gb2.Controls.Add(this._btnOk);
          resources.ApplyResources(this._gb2, "_gb2");
          this._gb2.Name = "_gb2";
          this._gb2.TabStop = false;
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _btnOk
          // 
          this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // AutoColorLevelDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._gb2);
          this.Controls.Add(this._gp1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "AutoColorLevelDialog";
          this.ShowIcon = false;
          ((System.ComponentModel.ISupportInitialize)(this._tbBlackClip)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numBlackClip)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbWhiteClip)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWhiteClip)).EndInit();
          this._gp1.ResumeLayout(false);
          this._gp1.PerformLayout();
          this._gb2.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblBlackClip;
      private System.Windows.Forms.NumericUpDown _numBlackClip;
      private System.Windows.Forms.Label _lblWhiteClip;
      private System.Windows.Forms.NumericUpDown _numWhiteClip;
      private System.Windows.Forms.Label _lblFlag;
      private System.Windows.Forms.ComboBox _cmbFlag;
      private System.Windows.Forms.Label _lblType;
      private System.Windows.Forms.ComboBox _cmbType;
      private System.Windows.Forms.GroupBox _gp1;
      private System.Windows.Forms.GroupBox _gb2;
      public System.Windows.Forms.TrackBar _tbBlackClip;
      public System.Windows.Forms.TrackBar _tbWhiteClip;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}