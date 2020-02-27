namespace Leadtools.Annotations.WinForms
{
   partial class MediaForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MediaForm));
         this.mediaWebBrowser = new System.Windows.Forms.WebBrowser();
         this.SuspendLayout();
         // 
         // mediaWebBrowser
         // 
         this.mediaWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
         this.mediaWebBrowser.Location = new System.Drawing.Point(0, 0);
         this.mediaWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
         this.mediaWebBrowser.Name = "mediaWebBrowser";
         this.mediaWebBrowser.ScrollBarsEnabled = false;
         this.mediaWebBrowser.Size = new System.Drawing.Size(619, 366);
         this.mediaWebBrowser.TabIndex = 0;
         this.mediaWebBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.mediaWebBrowser_DocumentCompleted);
         // 
         // MediaForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.ClientSize = new System.Drawing.Size(619, 366);
         this.Controls.Add(this.mediaWebBrowser);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MediaForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Media Form";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.WebBrowser mediaWebBrowser;


   }
}