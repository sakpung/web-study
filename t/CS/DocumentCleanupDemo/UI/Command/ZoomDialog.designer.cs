namespace DocumentCleanupDemo
{
   partial class ZoomDialog
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
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbOptions = new System.Windows.Forms.GroupBox();
          this._tbZoom = new System.Windows.Forms.TrackBar();
          this._tbPercentage = new System.Windows.Forms.TextBox();
          this._lblZoom = new System.Windows.Forms.Label();
          this._gbOptions.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbZoom)).BeginInit();
          this.SuspendLayout();
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._btnCancel.Location = new System.Drawing.Point(365, 55);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(90, 27);
          this._btnCancel.TabIndex = 2;
          this._btnCancel.Text = "Cancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          // 
          // _btnOk
          // 
          this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
          this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._btnOk.Location = new System.Drawing.Point(365, 18);
          this._btnOk.Name = "_btnOk";
          this._btnOk.Size = new System.Drawing.Size(90, 27);
          this._btnOk.TabIndex = 1;
          this._btnOk.Text = "OK";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(_btnOk_Click); 
          // 
          // _gbOptions
          // 
          this._gbOptions.Controls.Add(this._tbZoom);
          this._gbOptions.Controls.Add(this._tbPercentage);
          this._gbOptions.Controls.Add(this._lblZoom);
          this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._gbOptions.Location = new System.Drawing.Point(6, 0);
          this._gbOptions.Name = "_gbOptions";
          this._gbOptions.Size = new System.Drawing.Size(344, 119);
          this._gbOptions.TabIndex = 0;
          this._gbOptions.TabStop = false;
          // 
          // _tbZoom
          // 
          this._tbZoom.Location = new System.Drawing.Point(14, 54);
          this._tbZoom.Maximum = 30000;
          this._tbZoom.Minimum = 5;
          this._tbZoom.Name = "_tbZoom";
          this._tbZoom.Size = new System.Drawing.Size(317, 56);
          this._tbZoom.TabIndex = 2;
          this._tbZoom.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbZoom.Value = 5;
          this._tbZoom.Scroll += new System.EventHandler(this._tbZoom_Scroll);
          // 
          // _tbPercentage
          // 
          this._tbPercentage.Location = new System.Drawing.Point(110, 17);
          this._tbPercentage.Name = "_tbPercentage";
          this._tbPercentage.Size = new System.Drawing.Size(120, 22);
          this._tbPercentage.TabIndex = 1;
          this._tbPercentage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._tbPercentage_KeyPress);
          this._tbPercentage.TextChanged += new System.EventHandler(this._tbPercentage_TextChanged);
          // 
          // _lblZoom
          // 
          this._lblZoom.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblZoom.Location = new System.Drawing.Point(14, 16);
          this._lblZoom.Name = "_lblZoom";
          this._lblZoom.Size = new System.Drawing.Size(87, 27);
          this._lblZoom.TabIndex = 0;
          this._lblZoom.Text = "&Percentage:";
          this._lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
          // 
          // ZoomDialog
          // 
          this.AcceptButton = this._btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.ClientSize = new System.Drawing.Size(464, 128);
          this.Controls.Add(this._gbOptions);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ZoomDialog";
          this.ShowInTaskbar = false;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Zoom";
          this.Load += new System.EventHandler(this.ZoomDialog_Load);
          this._gbOptions.ResumeLayout(false);
          this._gbOptions.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbZoom)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.TrackBar _tbZoom;
      private System.Windows.Forms.TextBox _tbPercentage;
      private System.Windows.Forms.Label _lblZoom;
   }
}