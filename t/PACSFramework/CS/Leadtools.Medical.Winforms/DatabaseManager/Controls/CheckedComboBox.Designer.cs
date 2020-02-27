namespace Leadtools.Medical.Winforms
{
   partial class CheckedComboBox
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
         
         base.Dispose ( disposing ) ;
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.txtCheckedItems = new System.Windows.Forms.TextBox();
         this.btnModalityDropDown = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // txtCheckedItems
         // 
         this.txtCheckedItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.txtCheckedItems.Location = new System.Drawing.Point(0, 0);
         this.txtCheckedItems.Name = "txtCheckedItems";
         this.txtCheckedItems.ReadOnly = true;
         this.txtCheckedItems.Size = new System.Drawing.Size(227, 24);
         this.txtCheckedItems.TabIndex = 3;
         // 
         // btnModalityDropDown
         // 
         this.btnModalityDropDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnModalityDropDown.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
         this.btnModalityDropDown.FlatAppearance.BorderColor = System.Drawing.Color.LightSteelBlue;
         this.btnModalityDropDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
         this.btnModalityDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.btnModalityDropDown.Font = new System.Drawing.Font("Tahoma", 8F);
         this.btnModalityDropDown.ForeColor = System.Drawing.Color.DarkBlue;
         this.btnModalityDropDown.Location = new System.Drawing.Point(229, 0);
         this.btnModalityDropDown.Name = "btnModalityDropDown";
         this.btnModalityDropDown.Size = new System.Drawing.Size(56, 25);
         this.btnModalityDropDown.TabIndex = 2;
         this.btnModalityDropDown.Text = "Select";
         this.btnModalityDropDown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
         this.btnModalityDropDown.UseVisualStyleBackColor = false;
         // 
         // CheckedComboBox
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.txtCheckedItems);
         this.Controls.Add(this.btnModalityDropDown);
         this.Name = "CheckedComboBox";
         this.Size = new System.Drawing.Size(285, 24);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.TextBox txtCheckedItems;
      private System.Windows.Forms.Button btnModalityDropDown;
   }
}
