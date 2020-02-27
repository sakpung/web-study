namespace WebViewerConfiguration
{
   partial class WebServiceInstallerDialog
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
         this.buttonCreateInstaller = new System.Windows.Forms.Button();
         this.buttonBrowse = new System.Windows.Forms.Button();
         this.textboxZipInstallerPath = new System.Windows.Forms.TextBox();
         this.buttonCancel = new System.Windows.Forms.Button();
         this.labelInstallerLocation = new System.Windows.Forms.Label();
         this.labelResult = new System.Windows.Forms.Label();
         this.linkLabelRunCSStorageServerManagerDemo = new System.Windows.Forms.LinkLabel();
         this.linkLabelInstructionsNetworkPath = new System.Windows.Forms.LinkLabel();
         this.linkLabelCreateInstaller = new System.Windows.Forms.LinkLabel();
         this.SuspendLayout();
         // 
         // buttonCreateInstaller
         // 
         this.buttonCreateInstaller.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCreateInstaller.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.buttonCreateInstaller.Location = new System.Drawing.Point(416, 236);
         this.buttonCreateInstaller.Name = "buttonCreateInstaller";
         this.buttonCreateInstaller.Size = new System.Drawing.Size(90, 23);
         this.buttonCreateInstaller.TabIndex = 4;
         this.buttonCreateInstaller.Text = "Create Installer";
         this.buttonCreateInstaller.UseVisualStyleBackColor = true;
         // 
         // buttonBrowse
         // 
         this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonBrowse.Location = new System.Drawing.Point(555, 205);
         this.buttonBrowse.Name = "buttonBrowse";
         this.buttonBrowse.Size = new System.Drawing.Size(31, 23);
         this.buttonBrowse.TabIndex = 8;
         this.buttonBrowse.Text = "...";
         this.buttonBrowse.UseVisualStyleBackColor = true;
         this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
         // 
         // textboxZipInstallerPath
         // 
         this.textboxZipInstallerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.textboxZipInstallerPath.Location = new System.Drawing.Point(12, 206);
         this.textboxZipInstallerPath.Name = "textboxZipInstallerPath";
         this.textboxZipInstallerPath.Size = new System.Drawing.Size(534, 20);
         this.textboxZipInstallerPath.TabIndex = 7;
         // 
         // buttonCancel
         // 
         this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.buttonCancel.Location = new System.Drawing.Point(511, 236);
         this.buttonCancel.Name = "buttonCancel";
         this.buttonCancel.Size = new System.Drawing.Size(75, 23);
         this.buttonCancel.TabIndex = 9;
         this.buttonCancel.Text = "Cancel";
         this.buttonCancel.UseVisualStyleBackColor = true;
         // 
         // labelInstallerLocation
         // 
         this.labelInstallerLocation.AutoSize = true;
         this.labelInstallerLocation.Location = new System.Drawing.Point(12, 185);
         this.labelInstallerLocation.Name = "labelInstallerLocation";
         this.labelInstallerLocation.Size = new System.Drawing.Size(87, 13);
         this.labelInstallerLocation.TabIndex = 10;
         this.labelInstallerLocation.Text = "Installer Location";
         // 
         // labelResult
         // 
         this.labelResult.AutoSize = true;
         this.labelResult.Location = new System.Drawing.Point(9, 12);
         this.labelResult.Name = "labelResult";
         this.labelResult.Size = new System.Drawing.Size(59, 13);
         this.labelResult.TabIndex = 11;
         this.labelResult.Text = "labelResult";
         // 
         // linkLabelRunCSStorageServerManagerDemo
         // 
         this.linkLabelRunCSStorageServerManagerDemo.AutoSize = true;
         this.linkLabelRunCSStorageServerManagerDemo.Location = new System.Drawing.Point(22, 51);
         this.linkLabelRunCSStorageServerManagerDemo.Name = "linkLabelRunCSStorageServerManagerDemo";
         this.linkLabelRunCSStorageServerManagerDemo.Size = new System.Drawing.Size(206, 13);
         this.linkLabelRunCSStorageServerManagerDemo.TabIndex = 12;
         this.linkLabelRunCSStorageServerManagerDemo.TabStop = true;
         this.linkLabelRunCSStorageServerManagerDemo.Text = "Run \'CSStorageServerManagerDemo.exe\'";
         // 
         // linkLabelInstructionsNetworkPath
         // 
         this.linkLabelInstructionsNetworkPath.AutoSize = true;
         this.linkLabelInstructionsNetworkPath.Location = new System.Drawing.Point(22, 76);
         this.linkLabelInstructionsNetworkPath.Name = "linkLabelInstructionsNetworkPath";
         this.linkLabelInstructionsNetworkPath.Size = new System.Drawing.Size(227, 13);
         this.linkLabelInstructionsNetworkPath.TabIndex = 13;
         this.linkLabelInstructionsNetworkPath.TabStop = true;
         this.linkLabelInstructionsNetworkPath.Text = "Instructions: Set File settings to a network path";
         // 
         // linkLabelCreateInstaller
         // 
         this.linkLabelCreateInstaller.AutoSize = true;
         this.linkLabelCreateInstaller.Location = new System.Drawing.Point(46, 90);
         this.linkLabelCreateInstaller.Name = "linkLabelCreateInstaller";
         this.linkLabelCreateInstaller.Size = new System.Drawing.Size(81, 13);
         this.linkLabelCreateInstaller.TabIndex = 14;
         this.linkLabelCreateInstaller.TabStop = true;
         this.linkLabelCreateInstaller.Text = "\'Create Installer\'";
         // 
         // WebServiceInstallerDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(598, 267);
         this.Controls.Add(this.buttonCancel);
         this.Controls.Add(this.buttonCreateInstaller);
         this.Controls.Add(this.linkLabelCreateInstaller);
         this.Controls.Add(this.linkLabelInstructionsNetworkPath);
         this.Controls.Add(this.linkLabelRunCSStorageServerManagerDemo);
         this.Controls.Add(this.labelResult);
         this.Controls.Add(this.labelInstallerLocation);
         this.Controls.Add(this.buttonBrowse);
         this.Controls.Add(this.textboxZipInstallerPath);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "WebServiceInstallerDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Create Web Service Installer";
         this.Load += new System.EventHandler(this.WebServiceInstallerDialog_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.Button buttonCreateInstaller;
      private System.Windows.Forms.Button buttonBrowse;
      private System.Windows.Forms.TextBox textboxZipInstallerPath;
      private System.Windows.Forms.Button buttonCancel;
      private System.Windows.Forms.Label labelInstallerLocation;
      private System.Windows.Forms.Label labelResult;
      private System.Windows.Forms.LinkLabel linkLabelRunCSStorageServerManagerDemo;
      private System.Windows.Forms.LinkLabel linkLabelInstructionsNetworkPath;
      private System.Windows.Forms.LinkLabel linkLabelCreateInstaller;
   }
}