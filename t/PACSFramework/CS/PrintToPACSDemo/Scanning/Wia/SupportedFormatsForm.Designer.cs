namespace PrintToPACSDemo
{
   partial class SupportedFormatsForm
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
         this._btnCLose = new System.Windows.Forms.Button();
         this._lvFormats = new System.Windows.Forms.ListView();
         this.SuspendLayout();
         // 
         // _btnCLose
         // 
         this._btnCLose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCLose.Location = new System.Drawing.Point(362, 196);
         this._btnCLose.Name = "_btnCLose";
         this._btnCLose.Size = new System.Drawing.Size(75, 23);
         this._btnCLose.TabIndex = 1;
         this._btnCLose.Text = "&Close";
         this._btnCLose.UseVisualStyleBackColor = true;
         // 
         // _lvFormats
         // 
         this._lvFormats.FullRowSelect = true;
         this._lvFormats.GridLines = true;
         this._lvFormats.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this._lvFormats.Location = new System.Drawing.Point(12, 12);
         this._lvFormats.Name = "_lvFormats";
         this._lvFormats.Size = new System.Drawing.Size(425, 178);
         this._lvFormats.TabIndex = 0;
         this._lvFormats.UseCompatibleStateImageBehavior = false;
         this._lvFormats.View = System.Windows.Forms.View.Details;
         // 
         // SupportedFormatsForm
         // 
         this.AcceptButton = this._btnCLose;
         this.CancelButton = this._btnCLose;
         this.ClientSize = new System.Drawing.Size(449, 230);
         this.Controls.Add(this._btnCLose);
         this.Controls.Add(this._lvFormats);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "SupportedFormatsForm";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "WIA Supported Formats";
         this.Load += new System.EventHandler(this.SupportedFormatsForm_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCLose;
      private System.Windows.Forms.ListView _lvFormats;
   }
}