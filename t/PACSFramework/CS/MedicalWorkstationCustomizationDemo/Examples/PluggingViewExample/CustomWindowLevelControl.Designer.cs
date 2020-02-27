namespace Leadtools.Demos.Workstation.Customized
{
   partial class CustomWindowLevelControl
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
         OnDeactivated ( ) ;
         
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
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.WindowWidthNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.WindowCenterNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label3 = new System.Windows.Forms.Label();
         this.PresetComboBox = new System.Windows.Forms.ComboBox();
         this.AutoWindowLevelButton = new System.Windows.Forms.Button();
         this.CloseButton = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.WindowWidthNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.WindowCenterNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 15);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(80, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Window Width:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(3, 41);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(83, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Window Center:";
         // 
         // WindowWidthNumericUpDown
         // 
         this.WindowWidthNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.WindowWidthNumericUpDown.Location = new System.Drawing.Point(89, 13);
         this.WindowWidthNumericUpDown.Name = "WindowWidthNumericUpDown";
         this.WindowWidthNumericUpDown.Size = new System.Drawing.Size(120, 20);
         this.WindowWidthNumericUpDown.TabIndex = 2;
         // 
         // WindowCenterNumericUpDown
         // 
         this.WindowCenterNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.WindowCenterNumericUpDown.Location = new System.Drawing.Point(89, 39);
         this.WindowCenterNumericUpDown.Name = "WindowCenterNumericUpDown";
         this.WindowCenterNumericUpDown.Size = new System.Drawing.Size(120, 20);
         this.WindowCenterNumericUpDown.TabIndex = 3;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 67);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(40, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Preset:";
         // 
         // PresetComboBox
         // 
         this.PresetComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.PresetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.PresetComboBox.FormattingEnabled = true;
         this.PresetComboBox.Location = new System.Drawing.Point(89, 67);
         this.PresetComboBox.Name = "PresetComboBox";
         this.PresetComboBox.Size = new System.Drawing.Size(121, 21);
         this.PresetComboBox.TabIndex = 5;
         // 
         // AutoWindowLevelButton
         // 
         this.AutoWindowLevelButton.Location = new System.Drawing.Point(6, 99);
         this.AutoWindowLevelButton.Name = "AutoWindowLevelButton";
         this.AutoWindowLevelButton.Size = new System.Drawing.Size(75, 23);
         this.AutoWindowLevelButton.TabIndex = 6;
         this.AutoWindowLevelButton.Text = "Auto";
         this.AutoWindowLevelButton.UseVisualStyleBackColor = true;
         // 
         // CloseButton
         // 
         this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.CloseButton.Location = new System.Drawing.Point(134, 99);
         this.CloseButton.Name = "CloseButton";
         this.CloseButton.Size = new System.Drawing.Size(75, 23);
         this.CloseButton.TabIndex = 7;
         this.CloseButton.Text = "Close";
         this.CloseButton.UseVisualStyleBackColor = true;
         // 
         // CustomWindowLevelControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.Controls.Add(this.CloseButton);
         this.Controls.Add(this.AutoWindowLevelButton);
         this.Controls.Add(this.PresetComboBox);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.WindowCenterNumericUpDown);
         this.Controls.Add(this.WindowWidthNumericUpDown);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.ForeColor = System.Drawing.Color.Black;
         this.Name = "CustomWindowLevelControl";
         this.Size = new System.Drawing.Size(217, 133);
         ((System.ComponentModel.ISupportInitialize)(this.WindowWidthNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.WindowCenterNumericUpDown)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.NumericUpDown WindowWidthNumericUpDown;
      private System.Windows.Forms.NumericUpDown WindowCenterNumericUpDown;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox PresetComboBox;
      private System.Windows.Forms.Button AutoWindowLevelButton;
      private System.Windows.Forms.Button CloseButton;
   }
}
