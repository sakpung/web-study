namespace PrintToPACSDemo
{
   partial class WiaPropertiesErrorsForm
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
         this._btnOk = new System.Windows.Forms.Button();
         this._btnClear = new System.Windows.Forms.Button();
         this._lvErrors = new System.Windows.Forms.ListView();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnOk.Location = new System.Drawing.Point(484, 349);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 2;
         this._btnOk.Text = "&OK";
         this._btnOk.UseVisualStyleBackColor = true;
         // 
         // _btnClear
         // 
         this._btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnClear.Location = new System.Drawing.Point(403, 349);
         this._btnClear.Name = "_btnClear";
         this._btnClear.Size = new System.Drawing.Size(75, 23);
         this._btnClear.TabIndex = 1;
         this._btnClear.Text = "&Clear";
         this._btnClear.UseVisualStyleBackColor = true;
         this._btnClear.Click += new System.EventHandler(this._btnClear_Click);
         // 
         // _lvErrors
         // 
         this._lvErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._lvErrors.FullRowSelect = true;
         this._lvErrors.GridLines = true;
         this._lvErrors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
         this._lvErrors.Location = new System.Drawing.Point(12, 12);
         this._lvErrors.Name = "_lvErrors";
         this._lvErrors.Size = new System.Drawing.Size(547, 331);
         this._lvErrors.TabIndex = 0;
         this._lvErrors.UseCompatibleStateImageBehavior = false;
         this._lvErrors.View = System.Windows.Forms.View.Details;
         // 
         // WiaPropertiesErrorsForm
         // 
         this.AcceptButton = this._btnOk;
         this.CancelButton = this._btnOk;
         this.ClientSize = new System.Drawing.Size(572, 382);
         this.Controls.Add(this._lvErrors);
         this.Controls.Add(this._btnClear);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "WiaPropertiesErrorsForm";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "WIA Supported Formats";
         this.Load += new System.EventHandler(this.WiaPropertiesErrorsForm_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnClear;
      private System.Windows.Forms.ListView _lvErrors;


   }
}