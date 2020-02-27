namespace ImageProcessingDemo
{
   partial class ChangeViewPerspectiveDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeViewPerspectiveDialog));
          this._gbViewPerspective = new System.Windows.Forms.GroupBox();
          this._cmbViewPerspective = new System.Windows.Forms.ComboBox();
          this._btnok = new System.Windows.Forms.Button();
          this._btncancel = new System.Windows.Forms.Button();
          this._gbViewPerspective.SuspendLayout();
          this.SuspendLayout();
          // 
          // _gbViewPerspective
          // 
          this._gbViewPerspective.Controls.Add(this._cmbViewPerspective);
          this._gbViewPerspective.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbViewPerspective, "_gbViewPerspective");
          this._gbViewPerspective.Name = "_gbViewPerspective";
          this._gbViewPerspective.TabStop = false;
          // 
          // _cmbViewPerspective
          // 
          this._cmbViewPerspective.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbViewPerspective.FormattingEnabled = true;
          resources.ApplyResources(this._cmbViewPerspective, "_cmbViewPerspective");
          this._cmbViewPerspective.Name = "_cmbViewPerspective";
          // 
          // _btnok
          // 
          resources.ApplyResources(this._btnok, "_btnok");
          this._btnok.Name = "_btnok";
          this._btnok.UseVisualStyleBackColor = true;
          this._btnok.Click += new System.EventHandler(this._btnok_Click);
          // 
          // _btncancel
          // 
          this._btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btncancel, "_btncancel");
          this._btncancel.Name = "_btncancel";
          this._btncancel.UseVisualStyleBackColor = true;
          this._btncancel.Click += new System.EventHandler(this._btncancel_Click);
          // 
          // ChangeViewPerspectiveDialog
          // 
          this.AcceptButton = this._btnok;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btncancel;
          this.Controls.Add(this._btncancel);
          this.Controls.Add(this._btnok);
          this.Controls.Add(this._gbViewPerspective);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ChangeViewPerspectiveDialog";
          this.ShowIcon = false;
          this._gbViewPerspective.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbViewPerspective;
      private System.Windows.Forms.ComboBox _cmbViewPerspective;
      private System.Windows.Forms.Button _btnok;
      private System.Windows.Forms.Button _btncancel;
   }
}