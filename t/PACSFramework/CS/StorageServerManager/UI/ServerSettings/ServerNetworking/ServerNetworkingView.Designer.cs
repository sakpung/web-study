namespace Leadtools.Demos.StorageServer
{
   partial class ServerNetworkingView
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
         this.groupBox6 = new System.Windows.Forms.GroupBox();
         this.NoDelayCheckBox = new System.Windows.Forms.CheckBox();
         this.SendBufferNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label9 = new System.Windows.Forms.Label();
         this.ReceiveBufferNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.label8 = new System.Windows.Forms.Label();
         this.PDUMaxLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this.PDUMaxLengthCheckBox = new System.Windows.Forms.CheckBox();
         this.groupBox6.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.SendBufferNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.ReceiveBufferNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.PDUMaxLengthNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox6
         // 
         this.groupBox6.Controls.Add(this.NoDelayCheckBox);
         this.groupBox6.Controls.Add(this.SendBufferNumericUpDown);
         this.groupBox6.Controls.Add(this.label9);
         this.groupBox6.Controls.Add(this.ReceiveBufferNumericUpDown);
         this.groupBox6.Controls.Add(this.label8);
         this.groupBox6.Location = new System.Drawing.Point(8, 33);
         this.groupBox6.Name = "groupBox6";
         this.groupBox6.Size = new System.Drawing.Size(203, 109);
         this.groupBox6.TabIndex = 5;
         this.groupBox6.TabStop = false;
         this.groupBox6.Text = "Socket Options:";
         // 
         // NoDelayCheckBox
         // 
         this.NoDelayCheckBox.AutoSize = true;
         this.NoDelayCheckBox.Location = new System.Drawing.Point(12, 81);
         this.NoDelayCheckBox.Name = "NoDelayCheckBox";
         this.NoDelayCheckBox.Size = new System.Drawing.Size(73, 17);
         this.NoDelayCheckBox.TabIndex = 6;
         this.NoDelayCheckBox.Text = "No Delay:";
         this.NoDelayCheckBox.UseVisualStyleBackColor = true;
         // 
         // SendBufferNumericUpDown
         // 
         this.SendBufferNumericUpDown.Location = new System.Drawing.Point(112, 50);
         this.SendBufferNumericUpDown.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
         this.SendBufferNumericUpDown.Name = "SendBufferNumericUpDown";
         this.SendBufferNumericUpDown.Size = new System.Drawing.Size(86, 20);
         this.SendBufferNumericUpDown.TabIndex = 5;
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(9, 50);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(66, 13);
         this.label9.TabIndex = 4;
         this.label9.Text = "Send Buffer:";
         // 
         // ReceiveBufferNumericUpDown
         // 
         this.ReceiveBufferNumericUpDown.Location = new System.Drawing.Point(112, 24);
         this.ReceiveBufferNumericUpDown.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
         this.ReceiveBufferNumericUpDown.Name = "ReceiveBufferNumericUpDown";
         this.ReceiveBufferNumericUpDown.Size = new System.Drawing.Size(86, 20);
         this.ReceiveBufferNumericUpDown.TabIndex = 3;
         // 
         // label8
         // 
         this.label8.AutoSize = true;
         this.label8.Location = new System.Drawing.Point(9, 26);
         this.label8.Name = "label8";
         this.label8.Size = new System.Drawing.Size(81, 13);
         this.label8.TabIndex = 2;
         this.label8.Text = "Receive Buffer:";
         // 
         // PDUMaxLengthNumericUpDown
         // 
         this.PDUMaxLengthNumericUpDown.Location = new System.Drawing.Point(126, 9);
         this.PDUMaxLengthNumericUpDown.Maximum = new decimal(new int[] {
            1048576,
            0,
            0,
            0});
         this.PDUMaxLengthNumericUpDown.Name = "PDUMaxLengthNumericUpDown";
         this.PDUMaxLengthNumericUpDown.Size = new System.Drawing.Size(80, 20);
         this.PDUMaxLengthNumericUpDown.TabIndex = 4;
         // 
         // PDUMaxLengthCheckBox
         // 
         this.PDUMaxLengthCheckBox.AutoSize = true;
         this.PDUMaxLengthCheckBox.Location = new System.Drawing.Point(8, 9);
         this.PDUMaxLengthCheckBox.Name = "PDUMaxLengthCheckBox";
         this.PDUMaxLengthCheckBox.Size = new System.Drawing.Size(111, 17);
         this.PDUMaxLengthCheckBox.TabIndex = 3;
         this.PDUMaxLengthCheckBox.Text = "PDU Max Length:";
         this.PDUMaxLengthCheckBox.UseVisualStyleBackColor = true;
         // 
         // ServerNetworkingView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox6);
         this.Controls.Add(this.PDUMaxLengthNumericUpDown);
         this.Controls.Add(this.PDUMaxLengthCheckBox);
         this.Name = "ServerNetworkingView";
         this.Size = new System.Drawing.Size(217, 148);
         this.groupBox6.ResumeLayout(false);
         this.groupBox6.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.SendBufferNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.ReceiveBufferNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.PDUMaxLengthNumericUpDown)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox6;
      private System.Windows.Forms.CheckBox NoDelayCheckBox;
      private System.Windows.Forms.NumericUpDown SendBufferNumericUpDown;
      private System.Windows.Forms.Label label9;
      private System.Windows.Forms.NumericUpDown ReceiveBufferNumericUpDown;
      private System.Windows.Forms.Label label8;
      private System.Windows.Forms.NumericUpDown PDUMaxLengthNumericUpDown;
      private System.Windows.Forms.CheckBox PDUMaxLengthCheckBox;
   }
}
