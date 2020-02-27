namespace ImageProcessingDemo
{
   partial class ImpressionistDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImpressionistDialog));
          this._gbHorizontal = new System.Windows.Forms.GroupBox();
          this._txbHorizontal = new System.Windows.Forms.TextBox();
          this._tbHorizontal = new System.Windows.Forms.TrackBar();
          this._gbVertical = new System.Windows.Forms.GroupBox();
          this._txbVertical = new System.Windows.Forms.TextBox();
          this._tbVertical = new System.Windows.Forms.TrackBar();
          this._btnok = new System.Windows.Forms.Button();
          this._btncancel = new System.Windows.Forms.Button();
          this._gbHorizontal.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbHorizontal)).BeginInit();
          this._gbVertical.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbVertical)).BeginInit();
          this.SuspendLayout();
          // 
          // _gbHorizontal
          // 
          this._gbHorizontal.Controls.Add(this._txbHorizontal);
          this._gbHorizontal.Controls.Add(this._tbHorizontal);
          this._gbHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbHorizontal, "_gbHorizontal");
          this._gbHorizontal.Name = "_gbHorizontal";
          this._gbHorizontal.TabStop = false;
          // 
          // _txbHorizontal
          // 
          this._txbHorizontal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._txbHorizontal, "_txbHorizontal");
          this._txbHorizontal.Name = "_txbHorizontal";
          this._txbHorizontal.TextChanged += new System.EventHandler(this._txbHorizontal_TextChanged);
          // 
          // _tbHorizontal
          // 
          resources.ApplyResources(this._tbHorizontal, "_tbHorizontal");
          this._tbHorizontal.Name = "_tbHorizontal";
          this._tbHorizontal.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbHorizontal.Scroll += new System.EventHandler(this._tbHorizontal_Scroll);
          // 
          // _gbVertical
          // 
          this._gbVertical.Controls.Add(this._txbVertical);
          this._gbVertical.Controls.Add(this._tbVertical);
          this._gbVertical.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbVertical, "_gbVertical");
          this._gbVertical.Name = "_gbVertical";
          this._gbVertical.TabStop = false;
          // 
          // _txbVertical
          // 
          this._txbVertical.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._txbVertical, "_txbVertical");
          this._txbVertical.Name = "_txbVertical";
          this._txbVertical.TextChanged += new System.EventHandler(this._txbVertical_TextChanged);
          // 
          // _tbVertical
          // 
          resources.ApplyResources(this._tbVertical, "_tbVertical");
          this._tbVertical.Name = "_tbVertical";
          this._tbVertical.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbVertical.Scroll += new System.EventHandler(this._tbVertical_Scroll);
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
          // ImpressionistDialog
          // 
          this.AcceptButton = this._btnok;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btncancel;
          this.Controls.Add(this._btncancel);
          this.Controls.Add(this._btnok);
          this.Controls.Add(this._gbVertical);
          this.Controls.Add(this._gbHorizontal);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ImpressionistDialog";
          this.ShowIcon = false;
          this._gbHorizontal.ResumeLayout(false);
          this._gbHorizontal.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbHorizontal)).EndInit();
          this._gbVertical.ResumeLayout(false);
          this._gbVertical.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbVertical)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbHorizontal;
      private System.Windows.Forms.TextBox _txbHorizontal;
      private System.Windows.Forms.GroupBox _gbVertical;
      private System.Windows.Forms.TextBox _txbVertical;
      private System.Windows.Forms.Button _btnok;
      private System.Windows.Forms.Button _btncancel;
      public System.Windows.Forms.TrackBar _tbHorizontal;
      public System.Windows.Forms.TrackBar _tbVertical;
   }
}