namespace PrintToPACSDemo
{
   partial class FrmRecognize
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
         this._lblPage = new System.Windows.Forms.Label();
         this._lblText = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _lblPage
         // 
         this._lblPage.AutoSize = true;
         this._lblPage.Location = new System.Drawing.Point(102, 63);
         this._lblPage.Name = "_lblPage";
         this._lblPage.Size = new System.Drawing.Size(0, 13);
         this._lblPage.TabIndex = 0;
         // 
         // _lblText
         // 
         this._lblText.AutoSize = true;
         this._lblText.Location = new System.Drawing.Point(12, 15);
         this._lblText.Name = "_lblText";
         this._lblText.Size = new System.Drawing.Size(126, 13);
         this._lblText.TabIndex = 1;
         this._lblText.Text = "Recognizing Please Wait";
         // 
         // FrmRecognize
         // 
         this.ClientSize = new System.Drawing.Size(251, 117);
         this.ControlBox = false;
         this.Controls.Add(this._lblText);
         this.Controls.Add(this._lblPage);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FrmRecognize";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Recognizing Please Wait...";
         this.TopMost = true;
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblPage;
      private System.Windows.Forms.Label _lblText;
   }
}