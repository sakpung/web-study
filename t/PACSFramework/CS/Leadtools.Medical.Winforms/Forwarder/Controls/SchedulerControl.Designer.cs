namespace Leadtools.Medical.Winforms.Forwarder.Controls
{
   partial class SchedulerControl
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
         this.components = new System.ComponentModel.Container();
         this.label1 = new System.Windows.Forms.Label();
         this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
         this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.comboBoxInterval = new System.Windows.Forms.ComboBox();
         this.numericUpDownInterval = new System.Windows.Forms.NumericUpDown();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
         this.dateTimePickerEndTime = new System.Windows.Forms.DateTimePicker();
         this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(10, 17);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(32, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Start:";
         // 
         // dateTimePickerStartDate
         // 
         this.dateTimePickerStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerStartDate.Location = new System.Drawing.Point(45, 13);
         this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
         this.dateTimePickerStartDate.Size = new System.Drawing.Size(97, 20);
         this.dateTimePickerStartDate.TabIndex = 1;
         // 
         // dateTimePickerEndDate
         // 
         this.dateTimePickerEndDate.Checked = false;
         this.dateTimePickerEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
         this.dateTimePickerEndDate.Location = new System.Drawing.Point(45, 45);
         this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
         this.dateTimePickerEndDate.ShowCheckBox = true;
         this.dateTimePickerEndDate.Size = new System.Drawing.Size(97, 20);
         this.dateTimePickerEndDate.TabIndex = 4;
         this.dateTimePickerEndDate.ValueChanged += new System.EventHandler(this.dateTimePickerEndDate_ValueChanged);
         this.dateTimePickerEndDate.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePickerEndDate_Validating);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.comboBoxInterval);
         this.groupBox1.Controls.Add(this.numericUpDownInterval);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Location = new System.Drawing.Point(13, 74);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(255, 58);
         this.groupBox1.TabIndex = 6;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Repeat ";
         // 
         // comboBoxInterval
         // 
         this.comboBoxInterval.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxInterval.FormattingEnabled = true;
         this.comboBoxInterval.Location = new System.Drawing.Point(129, 25);
         this.comboBoxInterval.Name = "comboBoxInterval";
         this.comboBoxInterval.Size = new System.Drawing.Size(97, 21);
         this.comboBoxInterval.TabIndex = 2;
         this.comboBoxInterval.SelectionChangeCommitted += new System.EventHandler(this.comboBoxName_SelectionChangeCommitted);
         // 
         // numericUpDownInterval
         // 
         this.numericUpDownInterval.DecimalPlaces = 1;
         this.numericUpDownInterval.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
         this.numericUpDownInterval.Location = new System.Drawing.Point(62, 25);
         this.numericUpDownInterval.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
         this.numericUpDownInterval.Name = "numericUpDownInterval";
         this.numericUpDownInterval.Size = new System.Drawing.Size(61, 20);
         this.numericUpDownInterval.TabIndex = 1;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(19, 29);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(37, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "Every:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(10, 49);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(29, 13);
         this.label3.TabIndex = 3;
         this.label3.Text = "End:";
         // 
         // dateTimePickerStartTime
         // 
         this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
         this.dateTimePickerStartTime.Location = new System.Drawing.Point(171, 13);
         this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
         this.dateTimePickerStartTime.ShowUpDown = true;
         this.dateTimePickerStartTime.Size = new System.Drawing.Size(97, 20);
         this.dateTimePickerStartTime.TabIndex = 2;
         // 
         // dateTimePickerEndTime
         // 
         this.dateTimePickerEndTime.Checked = false;
         this.dateTimePickerEndTime.Enabled = false;
         this.dateTimePickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
         this.dateTimePickerEndTime.Location = new System.Drawing.Point(171, 45);
         this.dateTimePickerEndTime.Name = "dateTimePickerEndTime";
         this.dateTimePickerEndTime.ShowUpDown = true;
         this.dateTimePickerEndTime.Size = new System.Drawing.Size(97, 20);
         this.dateTimePickerEndTime.TabIndex = 5;
         this.dateTimePickerEndTime.Validating += new System.ComponentModel.CancelEventHandler(this.dateTimePickerEndTime_Validating);
         // 
         // errorProvider
         // 
         this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
         this.errorProvider.ContainerControl = this;
         // 
         // SchedulerControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.dateTimePickerEndTime);
         this.Controls.Add(this.dateTimePickerEndDate);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.dateTimePickerStartTime);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.dateTimePickerStartDate);
         this.Controls.Add(this.groupBox1);
         this.Name = "SchedulerControl";
         this.Size = new System.Drawing.Size(346, 145);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownInterval)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
      private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox comboBoxInterval;
      private System.Windows.Forms.NumericUpDown numericUpDownInterval;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
      private System.Windows.Forms.DateTimePicker dateTimePickerEndTime;
      private System.Windows.Forms.ErrorProvider errorProvider;

   }
}
