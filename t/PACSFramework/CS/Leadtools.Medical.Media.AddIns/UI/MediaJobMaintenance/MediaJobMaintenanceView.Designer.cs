namespace Leadtools.Medical.Media.AddIns.UI
{
   partial class MediaJobMaintenanceView
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
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.SaveButton = new System.Windows.Forms.Button();
         this.CompletedComboBox = new System.Windows.Forms.ComboBox();
         this.CompletedNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label5 = new System.Windows.Forms.Label();
         this.FailedComboBox = new System.Windows.Forms.ComboBox();
         this.FailedNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label4 = new System.Windows.Forms.Label();
         this.ProcessingComboBox = new System.Windows.Forms.ComboBox();
         this.ProcessingNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label3 = new System.Windows.Forms.Label();
         this.PendingComboBox = new System.Windows.Forms.ComboBox();
         this.PendingNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label2 = new System.Windows.Forms.Label();
         this.IdleComboBox = new System.Windows.Forms.ComboBox();
         this.IdleNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         this.EnableMaintainanceCheckBox = new System.Windows.Forms.CheckBox();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.CompletedNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.FailedNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ProcessingNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.PendingNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.IdleNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.SaveButton);
         this.groupBox1.Controls.Add(this.CompletedComboBox);
         this.groupBox1.Controls.Add(this.CompletedNumericUpDown);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this.FailedComboBox);
         this.groupBox1.Controls.Add(this.FailedNumericUpDown);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this.ProcessingComboBox);
         this.groupBox1.Controls.Add(this.ProcessingNumericUpDown);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this.PendingComboBox);
         this.groupBox1.Controls.Add(this.PendingNumericUpDown);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.IdleComboBox);
         this.groupBox1.Controls.Add(this.IdleNumericUpDown);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.EnableMaintainanceCheckBox);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox1.Location = new System.Drawing.Point(0, 0);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(325, 216);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Media Jobs Maintenance";
         // 
         // SaveButton
         // 
         this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.SaveButton.Location = new System.Drawing.Point(243, 183);
         this.SaveButton.Name = "SaveButton";
         this.SaveButton.Size = new System.Drawing.Size(75, 23);
         this.SaveButton.TabIndex = 16;
         this.SaveButton.Text = "Save";
         this.SaveButton.UseVisualStyleBackColor = true;
         // 
         // CompletedComboBox
         // 
         this.CompletedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.CompletedComboBox.FormattingEnabled = true;
         this.CompletedComboBox.Location = new System.Drawing.Point(231, 152);
         this.CompletedComboBox.Name = "CompletedComboBox";
         this.CompletedComboBox.Size = new System.Drawing.Size(87, 21);
         this.CompletedComboBox.TabIndex = 15;
         // 
         // CompletedNumericUpDown
         // 
         this.CompletedNumericUpDown.Location = new System.Drawing.Point(175, 154);
         this.CompletedNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.CompletedNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.CompletedNumericUpDown.Name = "CompletedNumericUpDown";
         this.CompletedNumericUpDown.Size = new System.Drawing.Size(50, 20);
         this.CompletedNumericUpDown.TabIndex = 14;
         this.CompletedNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(6, 156);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(157, 13);
         this.label5.TabIndex = 13;
         this.label5.Text = "Keep Completed Media Jobs for";
         // 
         // FailedComboBox
         // 
         this.FailedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.FailedComboBox.FormattingEnabled = true;
         this.FailedComboBox.Location = new System.Drawing.Point(231, 125);
         this.FailedComboBox.Name = "FailedComboBox";
         this.FailedComboBox.Size = new System.Drawing.Size(87, 21);
         this.FailedComboBox.TabIndex = 12;
         // 
         // FailedNumericUpDown
         // 
         this.FailedNumericUpDown.Location = new System.Drawing.Point(175, 127);
         this.FailedNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.FailedNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.FailedNumericUpDown.Name = "FailedNumericUpDown";
         this.FailedNumericUpDown.Size = new System.Drawing.Size(50, 20);
         this.FailedNumericUpDown.TabIndex = 11;
         this.FailedNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(6, 129);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(135, 13);
         this.label4.TabIndex = 10;
         this.label4.Text = "Keep Failed Media Jobs for";
         // 
         // ProcessingComboBox
         // 
         this.ProcessingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.ProcessingComboBox.FormattingEnabled = true;
         this.ProcessingComboBox.Location = new System.Drawing.Point(231, 98);
         this.ProcessingComboBox.Name = "ProcessingComboBox";
         this.ProcessingComboBox.Size = new System.Drawing.Size(87, 21);
         this.ProcessingComboBox.TabIndex = 9;
         // 
         // ProcessingNumericUpDown
         // 
         this.ProcessingNumericUpDown.Location = new System.Drawing.Point(175, 100);
         this.ProcessingNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.ProcessingNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.ProcessingNumericUpDown.Name = "ProcessingNumericUpDown";
         this.ProcessingNumericUpDown.Size = new System.Drawing.Size(50, 20);
         this.ProcessingNumericUpDown.TabIndex = 8;
         this.ProcessingNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(6, 102);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(159, 13);
         this.label3.TabIndex = 7;
         this.label3.Text = "Keep Processing Media Jobs for";
         // 
         // PendingComboBox
         // 
         this.PendingComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.PendingComboBox.FormattingEnabled = true;
         this.PendingComboBox.Location = new System.Drawing.Point(231, 71);
         this.PendingComboBox.Name = "PendingComboBox";
         this.PendingComboBox.Size = new System.Drawing.Size(87, 21);
         this.PendingComboBox.TabIndex = 6;
         // 
         // PendingNumericUpDown
         // 
         this.PendingNumericUpDown.Location = new System.Drawing.Point(175, 73);
         this.PendingNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.PendingNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.PendingNumericUpDown.Name = "PendingNumericUpDown";
         this.PendingNumericUpDown.Size = new System.Drawing.Size(50, 20);
         this.PendingNumericUpDown.TabIndex = 5;
         this.PendingNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(6, 75);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(146, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Keep Pending Media Jobs for";
         // 
         // IdleComboBox
         // 
         this.IdleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.IdleComboBox.FormattingEnabled = true;
         this.IdleComboBox.Location = new System.Drawing.Point(231, 44);
         this.IdleComboBox.Name = "IdleComboBox";
         this.IdleComboBox.Size = new System.Drawing.Size(87, 21);
         this.IdleComboBox.TabIndex = 3;
         // 
         // IdleNumericUpDown
         // 
         this.IdleNumericUpDown.Location = new System.Drawing.Point(175, 46);
         this.IdleNumericUpDown.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.IdleNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.IdleNumericUpDown.Name = "IdleNumericUpDown";
         this.IdleNumericUpDown.Size = new System.Drawing.Size(50, 20);
         this.IdleNumericUpDown.TabIndex = 2;
         this.IdleNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 48);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(124, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "Keep Idle Media Jobs for";
         // 
         // EnableMaintainanceCheckBox
         // 
         this.EnableMaintainanceCheckBox.AutoSize = true;
         this.EnableMaintainanceCheckBox.Location = new System.Drawing.Point(9, 22);
         this.EnableMaintainanceCheckBox.Name = "EnableMaintainanceCheckBox";
         this.EnableMaintainanceCheckBox.Size = new System.Drawing.Size(184, 17);
         this.EnableMaintainanceCheckBox.TabIndex = 0;
         this.EnableMaintainanceCheckBox.Text = "Enable Media Jobs Maintenance ";
         this.EnableMaintainanceCheckBox.UseVisualStyleBackColor = true;
         // 
         // MediaJobMaintenanceView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox1);
         this.Name = "MediaJobMaintenanceView";
         this.Size = new System.Drawing.Size(325, 216);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.CompletedNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.FailedNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ProcessingNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.PendingNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.IdleNumericUpDown)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckBox EnableMaintainanceCheckBox;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.NumericUpDown IdleNumericUpDown;
      private System.Windows.Forms.ComboBox IdleComboBox;
      private System.Windows.Forms.ComboBox FailedComboBox;
      private System.Windows.Forms.NumericUpDown FailedNumericUpDown;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.ComboBox ProcessingComboBox;
      private System.Windows.Forms.NumericUpDown ProcessingNumericUpDown;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox PendingComboBox;
      private System.Windows.Forms.NumericUpDown PendingNumericUpDown;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ComboBox CompletedComboBox;
      private System.Windows.Forms.NumericUpDown CompletedNumericUpDown;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Button SaveButton;
   }
}
