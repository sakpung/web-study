namespace RasterizeDocumentDemo.UserControls
{
   partial class XpsOptionsControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._generalXpsLoadOptionsGroupBox = new System.Windows.Forms.GroupBox();
         this._xpsOptionsNote = new System.Windows.Forms.Label();
         this._generalXpsLoadOptionsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _generalXpsLoadOptionsGroupBox
         // 
         this._generalXpsLoadOptionsGroupBox.Controls.Add(this._xpsOptionsNote);
         this._generalXpsLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._generalXpsLoadOptionsGroupBox.Location = new System.Drawing.Point(0, 0);
         this._generalXpsLoadOptionsGroupBox.Name = "_generalXpsLoadOptionsGroupBox";
         this._generalXpsLoadOptionsGroupBox.Size = new System.Drawing.Size(500, 230);
         this._generalXpsLoadOptionsGroupBox.TabIndex = 0;
         this._generalXpsLoadOptionsGroupBox.TabStop = false;
         this._generalXpsLoadOptionsGroupBox.Text = "General Open XML Paper Specification (XPS) load options:";
         // 
         // _xpsOptionsNote
         // 
         this._xpsOptionsNote.AutoSize = true;
         this._xpsOptionsNote.Location = new System.Drawing.Point(13, 35);
         this._xpsOptionsNote.Name = "_xpsOptionsNote";
         this._xpsOptionsNote.Size = new System.Drawing.Size(161, 13);
         this._xpsOptionsNote.TabIndex = 0;
         this._xpsOptionsNote.Text = "XPS codecs has no load options";
         // 
         // XpsOptionsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._generalXpsLoadOptionsGroupBox);
         this.Name = "XpsOptionsControl";
         this.Size = new System.Drawing.Size(500, 230);
         this._generalXpsLoadOptionsGroupBox.ResumeLayout(false);
         this._generalXpsLoadOptionsGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _generalXpsLoadOptionsGroupBox;
      private System.Windows.Forms.Label _xpsOptionsNote;
   }
}
