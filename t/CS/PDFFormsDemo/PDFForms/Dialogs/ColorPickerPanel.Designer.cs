namespace PDFFormsDemo
{
   partial class ColorPickerPanel
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
         this._openButton = new System.Windows.Forms.Button();
         this._colorPanel = new System.Windows.Forms.Panel();
         this._colorPickerDialog = new System.Windows.Forms.ColorDialog();
         this.SuspendLayout();
         // 
         // _openButton
         // 
         this._openButton.Dock = System.Windows.Forms.DockStyle.Right;
         this._openButton.Location = new System.Drawing.Point(35, 0);
         this._openButton.Name = "_openButton";
         this._openButton.Size = new System.Drawing.Size(35, 25);
         this._openButton.TabIndex = 0;
         this._openButton.Text = "...";
         this._openButton.UseVisualStyleBackColor = true;
         this._openButton.Click += new System.EventHandler(this._openButton_Click);
         // 
         // _colorPanel
         // 
         this._colorPanel.BackColor = System.Drawing.Color.Black;
         this._colorPanel.Dock = System.Windows.Forms.DockStyle.Left;
         this._colorPanel.Location = new System.Drawing.Point(0, 0);
         this._colorPanel.Name = "_colorPanel";
         this._colorPanel.Size = new System.Drawing.Size(30, 25);
         this._colorPanel.TabIndex = 1;
         // 
         // ColorPickerPanel
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._colorPanel);
         this.Controls.Add(this._openButton);
         this.Name = "ColorPickerPanel";
         this.Size = new System.Drawing.Size(70, 25);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _openButton;
      private System.Windows.Forms.Panel _colorPanel;
      private System.Windows.Forms.ColorDialog _colorPickerDialog;
   }
}
