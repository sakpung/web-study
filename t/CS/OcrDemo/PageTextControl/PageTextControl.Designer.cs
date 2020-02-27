namespace OcrDemo.PageTextControl
{
   partial class PageTextControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._titleLabel = new System.Windows.Forms.Label();
         this._tbPageText = new System.Windows.Forms.RichTextBox();
         this.SuspendLayout();
         // 
         // _titleLabel
         // 
         this._titleLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._titleLabel.Dock = System.Windows.Forms.DockStyle.Top;
         this._titleLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._titleLabel.Location = new System.Drawing.Point(0, 0);
         this._titleLabel.Name = "_titleLabel";
         this._titleLabel.Size = new System.Drawing.Size(395, 18);
         this._titleLabel.TabIndex = 1;
         this._titleLabel.Text = "Page Text";
         this._titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _tbPageText
         // 
         this._tbPageText.BackColor = System.Drawing.Color.White;
         this._tbPageText.BorderStyle = System.Windows.Forms.BorderStyle.None;
         this._tbPageText.Dock = System.Windows.Forms.DockStyle.Fill;
         this._tbPageText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._tbPageText.Location = new System.Drawing.Point(0, 18);
         this._tbPageText.Name = "_tbPageText";
         this._tbPageText.ReadOnly = true;
         this._tbPageText.Size = new System.Drawing.Size(395, 127);
         this._tbPageText.TabIndex = 3;
         this._tbPageText.Text = "";
         // 
         // PageTextControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.Controls.Add(this._tbPageText);
         this.Controls.Add(this._titleLabel);
         this.Name = "PageTextControl";
         this.Size = new System.Drawing.Size(395, 145);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _titleLabel;
      private System.Windows.Forms.RichTextBox _tbPageText;
   }
}
