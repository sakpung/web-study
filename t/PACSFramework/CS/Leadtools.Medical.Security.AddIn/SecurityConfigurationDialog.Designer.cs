namespace Leadtools.Medical.Security.AddIn
{
   partial class SecurityConfigurationDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecurityConfigurationDialog));
         this.securityOptionsView1 = new Leadtools.Medical.Winforms.SecurityOptions.SecurityOptionsView();
         this.buttonSave = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // securityOptionsView1
         // 
         this.securityOptionsView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.securityOptionsView1.Certificate = "";
         this.securityOptionsView1.CertificateAuthority = "";
         this.securityOptionsView1.CertificateType = Leadtools.Dicom.DicomTlsCertificateType.Pem;
         this.securityOptionsView1.CipherSuites = ((Leadtools.DicomDemos.CipherSuiteItems)(resources.GetObject("securityOptionsView1.CipherSuites")));
         this.securityOptionsView1.Location = new System.Drawing.Point(0, 0);
         this.securityOptionsView1.MaximumVerificationDepth = 0;
         this.securityOptionsView1.Name = "securityOptionsView1";
         this.securityOptionsView1.PrivateKey = "";
         this.securityOptionsView1.PrivateKeyPassword = "";
         this.securityOptionsView1.ShowPrivateKeyPassword = false;
         this.securityOptionsView1.Size = new System.Drawing.Size(683, 485);
         this.securityOptionsView1.TabIndex = 0;
         this.securityOptionsView1.VerificationFlags = Leadtools.Dicom.DicomOpenSslVerificationFlags.None;
         // 
         // buttonSave
         // 
         this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonSave.Location = new System.Drawing.Point(596, 491);
         this.buttonSave.Name = "buttonSave";
         this.buttonSave.Size = new System.Drawing.Size(75, 23);
         this.buttonSave.TabIndex = 1;
         this.buttonSave.Text = "Save";
         this.buttonSave.UseVisualStyleBackColor = true;
         this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
         // 
         // SecurityConfigurationDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(683, 522);
         this.Controls.Add(this.buttonSave);
         this.Controls.Add(this.securityOptionsView1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "SecurityConfigurationDialog";
         this.Text = "DICOM Security Configuration";
         this.ResumeLayout(false);

      }

      #endregion

      private Winforms.SecurityOptions.SecurityOptionsView securityOptionsView1;
      private System.Windows.Forms.Button buttonSave;
   }
}