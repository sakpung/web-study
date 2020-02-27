namespace PDFDocumentDemo
{
   partial class SignatureValidationStatusDialog
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
         this._closeButton = new System.Windows.Forms.Button();
         this._signaturePropertiesButton = new System.Windows.Forms.Button();
         this._infoLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _closeButton
         // 
         this._closeButton.Location = new System.Drawing.Point(461, 90);
         this._closeButton.Name = "_closeButton";
         this._closeButton.Size = new System.Drawing.Size(75, 23);
         this._closeButton.TabIndex = 0;
         this._closeButton.Text = "&Close";
         this._closeButton.UseVisualStyleBackColor = true;
         this._closeButton.Click += new System.EventHandler(this._closeButton_Click);
         // 
         // _signaturePropertiesButton
         // 
         this._signaturePropertiesButton.Location = new System.Drawing.Point(264, 90);
         this._signaturePropertiesButton.Name = "_signaturePropertiesButton";
         this._signaturePropertiesButton.Size = new System.Drawing.Size(191, 23);
         this._signaturePropertiesButton.TabIndex = 1;
         this._signaturePropertiesButton.Text = "&Signature Properties...";
         this._signaturePropertiesButton.UseVisualStyleBackColor = true;
         this._signaturePropertiesButton.Click += new System.EventHandler(this._signatureDetailsButton_Click);
         // 
         // _infoLabel
         // 
         this._infoLabel.AutoSize = true;
         this._infoLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._infoLabel.Location = new System.Drawing.Point(12, 9);
         this._infoLabel.Name = "_infoLabel";
         this._infoLabel.Size = new System.Drawing.Size(425, 48);
         this._infoLabel.TabIndex = 2;
         this._infoLabel.Text = "Signature validity is {0}. \r\n\r\n- The Document has not been modified since this si" +
    "gnature was applied. ";
         // 
         // SignatureValidationStatusDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(544, 121);
         this.ControlBox = false;
         this.Controls.Add(this._infoLabel);
         this.Controls.Add(this._signaturePropertiesButton);
         this.Controls.Add(this._closeButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Name = "SignatureValidationStatusDialog";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Signature Validation Status";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _closeButton;
      private System.Windows.Forms.Button _signaturePropertiesButton;
      private System.Windows.Forms.Label _infoLabel;
   }
}