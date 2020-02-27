namespace PrintToPACSDemo
{
   partial class AcquireSourceForm
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
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._lbAcquireSources = new System.Windows.Forms.ListBox();
         this.SuspendLayout();
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(12, 88);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 2;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(94, 88);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 3;
         this._btnCancel.Text = "&Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _lbAcquireSources
         // 
         this._lbAcquireSources.FormattingEnabled = true;
         this._lbAcquireSources.Location = new System.Drawing.Point(12, 12);
         this._lbAcquireSources.Name = "_lbAcquireSources";
         this._lbAcquireSources.Size = new System.Drawing.Size(157, 69);
         this._lbAcquireSources.TabIndex = 1;
         this._lbAcquireSources.DoubleClick += new System.EventHandler(this._lbAcquireSources_DoubleClick);
         // 
         // AcquireSourceForm
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(181, 123);
         this.Controls.Add(this._lbAcquireSources);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "AcquireSourceForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Acquire Sources";
         this.Load += new System.EventHandler(this.AcquireSourceForm_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.ListBox _lbAcquireSources;
   }
}