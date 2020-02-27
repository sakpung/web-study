namespace OmrProcessingDemo.ViewerControl
{
   partial class OptionsDialog
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
         this.btnOK = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.chkAutoEstimate = new System.Windows.Forms.CheckBox();
         this.chkAutosave = new System.Windows.Forms.CheckBox();
         this.nudAutosave = new System.Windows.Forms.NumericUpDown();
         this.lblAutoSaveMinutes = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.nudAutosave)).BeginInit();
         this.SuspendLayout();
         // 
         // btnOK
         // 
         this.btnOK.Location = new System.Drawing.Point(162, 125);
         this.btnOK.Name = "btnOK";
         this.btnOK.Size = new System.Drawing.Size(75, 23);
         this.btnOK.TabIndex = 0;
         this.btnOK.Text = "OK";
         this.btnOK.UseVisualStyleBackColor = true;
         this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
         // 
         // btnCancel
         // 
         this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.btnCancel.Location = new System.Drawing.Point(243, 125);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(75, 23);
         this.btnCancel.TabIndex = 1;
         this.btnCancel.Text = "Cancel";
         this.btnCancel.UseVisualStyleBackColor = true;
         // 
         // chkAutoEstimate
         // 
         this.chkAutoEstimate.AutoSize = true;
         this.chkAutoEstimate.Location = new System.Drawing.Point(12, 12);
         this.chkAutoEstimate.Name = "chkAutoEstimate";
         this.chkAutoEstimate.Size = new System.Drawing.Size(238, 17);
         this.chkAutoEstimate.TabIndex = 2;
         this.chkAutoEstimate.Text = "&Automatically Estimate Missing OMR Bubbles";
         this.chkAutoEstimate.UseVisualStyleBackColor = true;
         // 
         // chkAutosave
         // 
         this.chkAutosave.AutoSize = true;
         this.chkAutosave.Location = new System.Drawing.Point(12, 48);
         this.chkAutosave.Name = "chkAutosave";
         this.chkAutosave.Size = new System.Drawing.Size(165, 17);
         this.chkAutosave.TabIndex = 3;
         this.chkAutosave.Text = "Auto-&Save recovery file every";
         this.chkAutosave.UseVisualStyleBackColor = true;
         this.chkAutosave.CheckedChanged += new System.EventHandler(this.chkAutosave_CheckedChanged);
         // 
         // nudAutosave
         // 
         this.nudAutosave.Location = new System.Drawing.Point(173, 45);
         this.nudAutosave.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.nudAutosave.Name = "nudAutosave";
         this.nudAutosave.Size = new System.Drawing.Size(43, 20);
         this.nudAutosave.TabIndex = 4;
         this.nudAutosave.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // lblAutoSaveMinutes
         // 
         this.lblAutoSaveMinutes.AutoSize = true;
         this.lblAutoSaveMinutes.Location = new System.Drawing.Point(222, 49);
         this.lblAutoSaveMinutes.Name = "lblAutoSaveMinutes";
         this.lblAutoSaveMinutes.Size = new System.Drawing.Size(43, 13);
         this.lblAutoSaveMinutes.TabIndex = 5;
         this.lblAutoSaveMinutes.Text = "minutes";
         // 
         // OptionsDialog
         // 
         this.AcceptButton = this.btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.btnCancel;
         this.ClientSize = new System.Drawing.Size(330, 160);
         this.Controls.Add(this.lblAutoSaveMinutes);
         this.Controls.Add(this.nudAutosave);
         this.Controls.Add(this.chkAutosave);
         this.Controls.Add(this.chkAutoEstimate);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OptionsDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Options";
         ((System.ComponentModel.ISupportInitialize)(this.nudAutosave)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button btnOK;
      private System.Windows.Forms.Button btnCancel;
      private System.Windows.Forms.CheckBox chkAutoEstimate;
      private System.Windows.Forms.CheckBox chkAutosave;
      private System.Windows.Forms.NumericUpDown nudAutosave;
      private System.Windows.Forms.Label lblAutoSaveMinutes;
   }
}