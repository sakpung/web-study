namespace DocumentConverterDemo
{
   partial class MyOptionsDialog
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
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this._propertyGrid = new System.Windows.Forms.PropertyGrid();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(354, 341);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 7;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _cancelButton
         // 
         this._cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(435, 341);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 8;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _propertyGrid
         // 
         this._propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._propertyGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
         this._propertyGrid.Location = new System.Drawing.Point(13, 13);
         this._propertyGrid.Name = "_propertyGrid";
         this._propertyGrid.Size = new System.Drawing.Size(497, 322);
         this._propertyGrid.TabIndex = 9;
         this._propertyGrid.ToolbarVisible = false;
         // 
         // MyOptionsDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(523, 374);
         this.Controls.Add(this._propertyGrid);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MyOptionsDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Folders";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.PropertyGrid _propertyGrid;
   }
}