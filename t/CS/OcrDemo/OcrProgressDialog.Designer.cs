namespace OcrDemo
{
   partial class OcrProgressDialog
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
         if(disposing && (components != null))
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
         this._cancelButton = new System.Windows.Forms.Button();
         this._descriptionLabel = new System.Windows.Forms.Label();
         this._progressBar = new System.Windows.Forms.ProgressBar();
         this._panel = new System.Windows.Forms.Panel();
         this._panel.SuspendLayout();
         this.SuspendLayout();
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(172, 76);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 2;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
         // 
         // _descriptionLabel
         // 
         this._descriptionLabel.Location = new System.Drawing.Point(26, 21);
         this._descriptionLabel.Name = "_descriptionLabel";
         this._descriptionLabel.Size = new System.Drawing.Size(367, 23);
         this._descriptionLabel.TabIndex = 0;
         this._descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _progressBar
         // 
         this._progressBar.Location = new System.Drawing.Point(27, 47);
         this._progressBar.MarqueeAnimationSpeed = 50;
         this._progressBar.Name = "_progressBar";
         this._progressBar.Size = new System.Drawing.Size(364, 23);
         this._progressBar.TabIndex = 1;
         // 
         // _panel
         // 
         this._panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._panel.Controls.Add(this._descriptionLabel);
         this._panel.Controls.Add(this._progressBar);
         this._panel.Controls.Add(this._cancelButton);
         this._panel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._panel.Location = new System.Drawing.Point(0, 0);
         this._panel.Name = "_panel";
         this._panel.Size = new System.Drawing.Size(420, 118);
         this._panel.TabIndex = 3;
         // 
         // OcrProgressDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(420, 118);
         this.Controls.Add(this._panel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OcrProgressDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "OcrProgressDialog";
         this._panel.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Label _descriptionLabel;
      private System.Windows.Forms.ProgressBar _progressBar;
      private System.Windows.Forms.Panel _panel;
   }
}