namespace Leadtools.Annotations.WinForms
{
   partial class AnnotationObjectEditNoteForm
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
         this._noteTextBox = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // _noteTextBox
         // 
         this._noteTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._noteTextBox.Location = new System.Drawing.Point(0, 0);
         this._noteTextBox.Multiline = true;
         this._noteTextBox.Name = "_noteTextBox";
         this._noteTextBox.Size = new System.Drawing.Size(146, 83);
         this._noteTextBox.TabIndex = 0;
         // 
         // AnnotationObjectEditNoteForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(146, 83);
         this.Controls.Add(this._noteTextBox);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AnnotationObjectEditNoteForm";
         this.Text = "Form1";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox _noteTextBox;
   }
}