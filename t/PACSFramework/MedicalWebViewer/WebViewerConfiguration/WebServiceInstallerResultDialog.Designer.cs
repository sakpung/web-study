namespace WebViewerConfiguration
{
   partial class WebServiceInstallerResultDialog
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
         this.linkLabel = new System.Windows.Forms.LinkLabel();
         this.labelResult = new System.Windows.Forms.Label();
         this.buttonOK = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // linkLabel
         // 
         this.linkLabel.AutoSize = true;
         this.linkLabel.Location = new System.Drawing.Point(26, 149);
         this.linkLabel.Name = "linkLabel";
         this.linkLabel.Size = new System.Drawing.Size(55, 13);
         this.linkLabel.TabIndex = 0;
         this.linkLabel.TabStop = true;
         this.linkLabel.Text = "linkLabel1";
         this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
         // 
         // labelResult
         // 
         this.labelResult.AutoSize = true;
         this.labelResult.Location = new System.Drawing.Point(26, 22);
         this.labelResult.Name = "labelResult";
         this.labelResult.Size = new System.Drawing.Size(59, 13);
         this.labelResult.TabIndex = 1;
         this.labelResult.Text = "labelResult";
         // 
         // buttonOK
         // 
         this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonOK.Location = new System.Drawing.Point(512, 174);
         this.buttonOK.Name = "buttonOK";
         this.buttonOK.Size = new System.Drawing.Size(75, 23);
         this.buttonOK.TabIndex = 2;
         this.buttonOK.Text = "OK";
         this.buttonOK.UseVisualStyleBackColor = true;
         // 
         // WebServiceInstallerResultDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(599, 209);
         this.Controls.Add(this.buttonOK);
         this.Controls.Add(this.labelResult);
         this.Controls.Add(this.linkLabel);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "WebServiceInstallerResultDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Create Web Service Installer";
         this.Load += new System.EventHandler(this.WebServiceInstallerResultDialog_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.LinkLabel linkLabel;
      private System.Windows.Forms.Label labelResult;
      private System.Windows.Forms.Button buttonOK;
   }
}