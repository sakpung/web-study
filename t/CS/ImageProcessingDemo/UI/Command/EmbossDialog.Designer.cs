namespace ImageProcessingDemo
{
   partial class EmbossDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmbossDialog));
          this._tbDepth = new System.Windows.Forms.TrackBar();
          this._lblDepth = new System.Windows.Forms.Label();
          this._txbDepth = new System.Windows.Forms.TextBox();
          this._gbDepth = new System.Windows.Forms.GroupBox();
          this._lblDirection = new System.Windows.Forms.Label();
          this._cmbDirection = new System.Windows.Forms.ComboBox();
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          ((System.ComponentModel.ISupportInitialize)(this._tbDepth)).BeginInit();
          this._gbDepth.SuspendLayout();
          this.SuspendLayout();
          // 
          // _tbDepth
          // 
          resources.ApplyResources(this._tbDepth, "_tbDepth");
          this._tbDepth.Maximum = 1000;
          this._tbDepth.Name = "_tbDepth";
          this._tbDepth.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbDepth.Scroll += new System.EventHandler(this._tbDepth_Scroll);
          // 
          // _lblDepth
          // 
          resources.ApplyResources(this._lblDepth, "_lblDepth");
          this._lblDepth.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblDepth.Name = "_lblDepth";
          // 
          // _txbDepth
          // 
          this._txbDepth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._txbDepth, "_txbDepth");
          this._txbDepth.Name = "_txbDepth";
          this._txbDepth.TextChanged += new System.EventHandler(this._txbDepth_TextChanged);
          // 
          // _gbDepth
          // 
          this._gbDepth.Controls.Add(this._lblDirection);
          this._gbDepth.Controls.Add(this._cmbDirection);
          this._gbDepth.Controls.Add(this._tbDepth);
          this._gbDepth.Controls.Add(this._txbDepth);
          this._gbDepth.Controls.Add(this._lblDepth);
          this._gbDepth.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbDepth, "_gbDepth");
          this._gbDepth.Name = "_gbDepth";
          this._gbDepth.TabStop = false;
          // 
          // _lblDirection
          // 
          resources.ApplyResources(this._lblDirection, "_lblDirection");
          this._lblDirection.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblDirection.Name = "_lblDirection";
          // 
          // _cmbDirection
          // 
          this._cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbDirection, "_cmbDirection");
          this._cmbDirection.FormattingEnabled = true;
          this._cmbDirection.Name = "_cmbDirection";
          // 
          // _btnOk
          // 
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // EmbossDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbDepth);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "EmbossDialog";
          this.ShowIcon = false;
          ((System.ComponentModel.ISupportInitialize)(this._tbDepth)).EndInit();
          this._gbDepth.ResumeLayout(false);
          this._gbDepth.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      public System.Windows.Forms.TrackBar _tbDepth;
      private System.Windows.Forms.Label _lblDepth;
      private System.Windows.Forms.TextBox _txbDepth;
      private System.Windows.Forms.GroupBox _gbDepth;
      private System.Windows.Forms.Label _lblDirection;
      private System.Windows.Forms.ComboBox _cmbDirection;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;

   }
}