namespace CSBankCheckReader.UI
{
   partial class ProcessDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessDialog));
         this._progressBar = new System.Windows.Forms.ProgressBar();
         this.label1 = new System.Windows.Forms.Label();
         this._lableStatus = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this._labelField = new System.Windows.Forms.Label();
         this._buttonCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _progressBar
         // 
         this._progressBar.Location = new System.Drawing.Point(12, 124);
         this._progressBar.Name = "_progressBar";
         this._progressBar.Size = new System.Drawing.Size(412, 23);
         this._progressBar.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(38, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Status";
         // 
         // _lableStatus
         // 
         this._lableStatus.AutoSize = true;
         this._lableStatus.Location = new System.Drawing.Point(57, 13);
         this._lableStatus.Name = "_lableStatus";
         this._lableStatus.Size = new System.Drawing.Size(0, 13);
         this._lableStatus.TabIndex = 2;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(13, 84);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(29, 13);
         this.label3.TabIndex = 3;
         this.label3.Text = "Field";
         // 
         // _labelField
         // 
         this._labelField.AutoSize = true;
         this._labelField.Location = new System.Drawing.Point(57, 84);
         this._labelField.Name = "_labelField";
         this._labelField.Size = new System.Drawing.Size(0, 13);
         this._labelField.TabIndex = 4;
         // 
         // _buttonCancel
         // 
         this._buttonCancel.Location = new System.Drawing.Point(169, 164);
         this._buttonCancel.Name = "_buttonCancel";
         this._buttonCancel.Size = new System.Drawing.Size(99, 23);
         this._buttonCancel.TabIndex = 5;
         this._buttonCancel.Text = "Cancel";
         this._buttonCancel.UseVisualStyleBackColor = true;
         this._buttonCancel.Click += new System.EventHandler(this._buttonCancel_Click);
         // 
         // ProcessDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(436, 208);
         this.ControlBox = false;
         this.Controls.Add(this._buttonCancel);
         this.Controls.Add(this._labelField);
         this.Controls.Add(this.label3);
         this.Controls.Add(this._lableStatus);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._progressBar);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ProcessDialog";
         this.Text = "Process";
         this.TopMost = true;
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ProgressBar _progressBar;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label _lableStatus;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label _labelField;
      private System.Windows.Forms.Button _buttonCancel;
   }
}