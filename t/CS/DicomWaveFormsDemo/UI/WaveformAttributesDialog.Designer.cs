namespace DicomDemo
{
    partial class WaveformAttributesDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtWaveformPaddingValue = new System.Windows.Forms.TextBox();
            this.txtSampleInterpretation = new System.Windows.Forms.TextBox();
            this.txtNumberOfWaveformSamples = new System.Windows.Forms.TextBox();
            this.txtWaveformBitsAllocated = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumberOfChannels = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSamplingFrequency = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvChannelAttributes = new System.Windows.Forms.ListView();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtWaveformPaddingValue);
            this.groupBox1.Controls.Add(this.txtSampleInterpretation);
            this.groupBox1.Controls.Add(this.txtNumberOfWaveformSamples);
            this.groupBox1.Controls.Add(this.txtWaveformBitsAllocated);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNumberOfChannels);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSamplingFrequency);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(726, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Waveform Attributes";
            // 
            // txtWaveformPaddingValue
            // 
            this.txtWaveformPaddingValue.Location = new System.Drawing.Point(643, 45);
            this.txtWaveformPaddingValue.Name = "txtWaveformPaddingValue";
            this.txtWaveformPaddingValue.ReadOnly = true;
            this.txtWaveformPaddingValue.Size = new System.Drawing.Size(74, 20);
            this.txtWaveformPaddingValue.TabIndex = 11;
            // 
            // txtSampleInterpretation
            // 
            this.txtSampleInterpretation.Location = new System.Drawing.Point(119, 45);
            this.txtSampleInterpretation.Name = "txtSampleInterpretation";
            this.txtSampleInterpretation.ReadOnly = true;
            this.txtSampleInterpretation.Size = new System.Drawing.Size(152, 20);
            this.txtSampleInterpretation.TabIndex = 7;
            // 
            // txtNumberOfWaveformSamples
            // 
            this.txtNumberOfWaveformSamples.Location = new System.Drawing.Point(643, 19);
            this.txtNumberOfWaveformSamples.Name = "txtNumberOfWaveformSamples";
            this.txtNumberOfWaveformSamples.ReadOnly = true;
            this.txtNumberOfWaveformSamples.Size = new System.Drawing.Size(74, 20);
            this.txtNumberOfWaveformSamples.TabIndex = 10;
            // 
            // txtWaveformBitsAllocated
            // 
            this.txtWaveformBitsAllocated.Location = new System.Drawing.Point(406, 45);
            this.txtWaveformBitsAllocated.Name = "txtWaveformBitsAllocated";
            this.txtWaveformBitsAllocated.ReadOnly = true;
            this.txtWaveformBitsAllocated.Size = new System.Drawing.Size(74, 20);
            this.txtWaveformBitsAllocated.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(486, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Waveform Padding Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(486, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Number of Waveform Samples";
            // 
            // txtNumberOfChannels
            // 
            this.txtNumberOfChannels.Location = new System.Drawing.Point(119, 19);
            this.txtNumberOfChannels.Name = "txtNumberOfChannels";
            this.txtNumberOfChannels.ReadOnly = true;
            this.txtNumberOfChannels.Size = new System.Drawing.Size(152, 20);
            this.txtNumberOfChannels.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sample Interpretation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Channels";
            // 
            // txtSamplingFrequency
            // 
            this.txtSamplingFrequency.Location = new System.Drawing.Point(406, 19);
            this.txtSamplingFrequency.Name = "txtSamplingFrequency";
            this.txtSamplingFrequency.ReadOnly = true;
            this.txtSamplingFrequency.Size = new System.Drawing.Size(74, 20);
            this.txtSamplingFrequency.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Sampling Frequency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Waveform Bits Allocated";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvChannelAttributes);
            this.groupBox2.Location = new System.Drawing.Point(12, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(726, 230);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Channel Attributes";
            // 
            // lvChannelAttributes
            // 
            this.lvChannelAttributes.Location = new System.Drawing.Point(9, 19);
            this.lvChannelAttributes.Name = "lvChannelAttributes";
            this.lvChannelAttributes.Size = new System.Drawing.Size(708, 205);
            this.lvChannelAttributes.TabIndex = 0;
            this.lvChannelAttributes.UseCompatibleStateImageBehavior = false;
            this.lvChannelAttributes.View = System.Windows.Forms.View.Details;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(340, 331);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // WaveformAttributesDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(750, 365);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WaveformAttributesDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Waveform Info";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtWaveformPaddingValue;
        private System.Windows.Forms.TextBox txtNumberOfWaveformSamples;
        private System.Windows.Forms.TextBox txtWaveformBitsAllocated;
        private System.Windows.Forms.TextBox txtSamplingFrequency;
        private System.Windows.Forms.TextBox txtSampleInterpretation;
        private System.Windows.Forms.TextBox txtNumberOfChannels;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvChannelAttributes;
    }
}