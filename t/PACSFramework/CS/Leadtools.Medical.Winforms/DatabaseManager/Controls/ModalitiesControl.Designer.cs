namespace Leadtools.Medical.Winforms.DatabaseManager.Controls
{
   partial class ModalitiesControl
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
         this.checkBoxSelectAllModalities = new System.Windows.Forms.CheckBox();
         this.comboBoxModalities = new Leadtools.Medical.Winforms.Control.CheckedComboBox();
         this.SuspendLayout();
         // 
         // checkBoxSelectAllModalities
         // 
         this.checkBoxSelectAllModalities.AutoSize = true;
         this.checkBoxSelectAllModalities.Location = new System.Drawing.Point(0, 3);
         this.checkBoxSelectAllModalities.Name = "checkBoxSelectAllModalities";
         this.checkBoxSelectAllModalities.Size = new System.Drawing.Size(70, 17);
         this.checkBoxSelectAllModalities.TabIndex = 2;
         this.checkBoxSelectAllModalities.Text = "Select All";
         this.checkBoxSelectAllModalities.UseVisualStyleBackColor = true;
         // 
         // comboBoxModalities
         // 
         this.comboBoxModalities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.comboBoxModalities.ColumnDelimeter = '\0';
         this.comboBoxModalities.DisplayView = Leadtools.Medical.Winforms.Control.CheckedComboBox.View.Columns;
         this.comboBoxModalities.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
         this.comboBoxModalities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxModalities.Location = new System.Drawing.Point(71, 0);
         this.comboBoxModalities.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.comboBoxModalities.Name = "comboBoxModalities";
         this.comboBoxModalities.Size = new System.Drawing.Size(267, 21);
         this.comboBoxModalities.TabIndex = 3;
         // 
         // ModalitiesControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.checkBoxSelectAllModalities);
         this.Controls.Add(this.comboBoxModalities);
         this.Name = "ModalitiesControl";
         this.Size = new System.Drawing.Size(341, 22);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.CheckBox checkBoxSelectAllModalities;
      private Control.CheckedComboBox comboBoxModalities;

   }
}
