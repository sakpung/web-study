namespace Leadtools.Medical.Winforms.DatabaseManager
{
   partial class DatabaseManagerOptionsView
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
         this.groupBoxTitle = new System.Windows.Forms.GroupBox();
         this.gbPaginationOptions = new System.Windows.Forms.GroupBox();
         this.numericUpDownPageSize = new System.Windows.Forms.NumericUpDown();
         this.gbPaginationButtons = new System.Windows.Forms.GroupBox();
         this.rbPaginationAlways = new System.Windows.Forms.RadioButton();
         this.rbPaginationWhenNecessary = new System.Windows.Forms.RadioButton();
         this.rbPaginationNever = new System.Windows.Forms.RadioButton();
         this.labelPageSize = new System.Windows.Forms.Label();
         this.groupBoxTitle.SuspendLayout();
         this.gbPaginationOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPageSize)).BeginInit();
         this.gbPaginationButtons.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBoxTitle
         // 
         this.groupBoxTitle.Controls.Add(this.gbPaginationOptions);
         this.groupBoxTitle.Location = new System.Drawing.Point(3, 3);
         this.groupBoxTitle.Name = "groupBoxTitle";
         this.groupBoxTitle.Size = new System.Drawing.Size(366, 213);
         this.groupBoxTitle.TabIndex = 1;
         this.groupBoxTitle.TabStop = false;
         this.groupBoxTitle.Text = "Database Manager Options";
         // 
         // gbPaginationOptions
         // 
         this.gbPaginationOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.gbPaginationOptions.Controls.Add(this.numericUpDownPageSize);
         this.gbPaginationOptions.Controls.Add(this.gbPaginationButtons);
         this.gbPaginationOptions.Controls.Add(this.labelPageSize);
         this.gbPaginationOptions.Location = new System.Drawing.Point(14, 21);
         this.gbPaginationOptions.Name = "gbPaginationOptions";
         this.gbPaginationOptions.Size = new System.Drawing.Size(338, 171);
         this.gbPaginationOptions.TabIndex = 1;
         this.gbPaginationOptions.TabStop = false;
         this.gbPaginationOptions.Text = "Pagination Options";
         // 
         // numericUpDownPageSize
         // 
         this.numericUpDownPageSize.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.numericUpDownPageSize.Location = new System.Drawing.Point(133, 21);
         this.numericUpDownPageSize.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
         this.numericUpDownPageSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.numericUpDownPageSize.Name = "numericUpDownPageSize";
         this.numericUpDownPageSize.Size = new System.Drawing.Size(79, 20);
         this.numericUpDownPageSize.TabIndex = 4;
         this.numericUpDownPageSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // gbPaginationButtons
         // 
         this.gbPaginationButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.gbPaginationButtons.Controls.Add(this.rbPaginationAlways);
         this.gbPaginationButtons.Controls.Add(this.rbPaginationWhenNecessary);
         this.gbPaginationButtons.Controls.Add(this.rbPaginationNever);
         this.gbPaginationButtons.Location = new System.Drawing.Point(10, 58);
         this.gbPaginationButtons.Name = "gbPaginationButtons";
         this.gbPaginationButtons.Size = new System.Drawing.Size(312, 98);
         this.gbPaginationButtons.TabIndex = 3;
         this.gbPaginationButtons.TabStop = false;
         this.gbPaginationButtons.Text = "Pagination Buttons";
         // 
         // rbPaginationAlways
         // 
         this.rbPaginationAlways.AutoSize = true;
         this.rbPaginationAlways.Location = new System.Drawing.Point(14, 69);
         this.rbPaginationAlways.Name = "rbPaginationAlways";
         this.rbPaginationAlways.Size = new System.Drawing.Size(88, 17);
         this.rbPaginationAlways.TabIndex = 8;
         this.rbPaginationAlways.TabStop = true;
         this.rbPaginationAlways.Text = "Always Show";
         this.rbPaginationAlways.UseVisualStyleBackColor = true;
         // 
         // rbPaginationWhenNecessary
         // 
         this.rbPaginationWhenNecessary.AutoSize = true;
         this.rbPaginationWhenNecessary.Location = new System.Drawing.Point(14, 45);
         this.rbPaginationWhenNecessary.Name = "rbPaginationWhenNecessary";
         this.rbPaginationWhenNecessary.Size = new System.Drawing.Size(137, 17);
         this.rbPaginationWhenNecessary.TabIndex = 7;
         this.rbPaginationWhenNecessary.TabStop = true;
         this.rbPaginationWhenNecessary.Text = "Show When Necessary";
         this.rbPaginationWhenNecessary.UseVisualStyleBackColor = true;
         // 
         // rbPaginationNever
         // 
         this.rbPaginationNever.AutoSize = true;
         this.rbPaginationNever.Location = new System.Drawing.Point(14, 21);
         this.rbPaginationNever.Name = "rbPaginationNever";
         this.rbPaginationNever.Size = new System.Drawing.Size(84, 17);
         this.rbPaginationNever.TabIndex = 6;
         this.rbPaginationNever.TabStop = true;
         this.rbPaginationNever.Text = "Never Show";
         this.rbPaginationNever.UseVisualStyleBackColor = true;
         // 
         // labelPageSize
         // 
         this.labelPageSize.AutoSize = true;
         this.labelPageSize.Location = new System.Drawing.Point(10, 25);
         this.labelPageSize.Name = "labelPageSize";
         this.labelPageSize.Size = new System.Drawing.Size(116, 13);
         this.labelPageSize.TabIndex = 1;
         this.labelPageSize.Text = "Image Level Page Size";
         // 
         // DatabaseManagerOptionsView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBoxTitle);
         this.Name = "DatabaseManagerOptionsView";
         this.Size = new System.Drawing.Size(373, 221);
         this.groupBoxTitle.ResumeLayout(false);
         this.gbPaginationOptions.ResumeLayout(false);
         this.gbPaginationOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPageSize)).EndInit();
         this.gbPaginationButtons.ResumeLayout(false);
         this.gbPaginationButtons.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBoxTitle;
      private System.Windows.Forms.GroupBox gbPaginationOptions;
      private System.Windows.Forms.NumericUpDown numericUpDownPageSize;
      private System.Windows.Forms.GroupBox gbPaginationButtons;
      private System.Windows.Forms.RadioButton rbPaginationAlways;
      private System.Windows.Forms.RadioButton rbPaginationWhenNecessary;
      private System.Windows.Forms.RadioButton rbPaginationNever;
      private System.Windows.Forms.Label labelPageSize;
   }
}
