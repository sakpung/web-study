namespace GrayScaleDemo
{
    partial class MeanShiftDialog
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
            this._gbMeanShift = new System.Windows.Forms.GroupBox();
            this._numColorDistance = new System.Windows.Forms.NumericUpDown();
            this._numRadius = new System.Windows.Forms.NumericUpDown();
            this._lblColorDistance = new System.Windows.Forms.Label();
            this._lblRadius = new System.Windows.Forms.Label();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._gbMeanShift.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numColorDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbMeanShift
            // 
            this._gbMeanShift.Controls.Add(this._numColorDistance);
            this._gbMeanShift.Controls.Add(this._numRadius);
            this._gbMeanShift.Controls.Add(this._lblColorDistance);
            this._gbMeanShift.Controls.Add(this._lblRadius);
            this._gbMeanShift.Location = new System.Drawing.Point(6, 1);
            this._gbMeanShift.Name = "_gbMeanShift";
            this._gbMeanShift.Size = new System.Drawing.Size(210, 97);
            this._gbMeanShift.TabIndex = 0;
            this._gbMeanShift.TabStop = false;
            // 
            // _numColorDistance
            // 
            this._numColorDistance.Location = new System.Drawing.Point(107, 55);
            this._numColorDistance.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numColorDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numColorDistance.Name = "_numColorDistance";
            this._numColorDistance.Size = new System.Drawing.Size(91, 20);
            this._numColorDistance.TabIndex = 3;
            this._numColorDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _numRadius
            // 
            this._numRadius.Location = new System.Drawing.Point(107, 19);
            this._numRadius.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this._numRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numRadius.Name = "_numRadius";
            this._numRadius.Size = new System.Drawing.Size(91, 20);
            this._numRadius.TabIndex = 2;
            this._numRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _lblColorDistance
            // 
            this._lblColorDistance.AutoSize = true;
            this._lblColorDistance.Location = new System.Drawing.Point(22, 57);
            this._lblColorDistance.Name = "_lblColorDistance";
            this._lblColorDistance.Size = new System.Drawing.Size(79, 13);
            this._lblColorDistance.TabIndex = 1;
            this._lblColorDistance.Text = "ColorDistance :";
            // 
            // _lblRadius
            // 
            this._lblRadius.AutoSize = true;
            this._lblRadius.Location = new System.Drawing.Point(17, 20);
            this._lblRadius.Name = "_lblRadius";
            this._lblRadius.Size = new System.Drawing.Size(46, 13);
            this._lblRadius.TabIndex = 0;
            this._lblRadius.Text = "Radius :";
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(120, 103);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(68, 22);
            this._btnCancel.TabIndex = 15;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnOk.Location = new System.Drawing.Point(35, 103);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 14;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // MeanShiftDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 135);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._gbMeanShift);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MeanShiftDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mean Shift";
            this.Load += new System.EventHandler(this.MeanShiftDialog_Load);
            this._gbMeanShift.ResumeLayout(false);
            this._gbMeanShift.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numColorDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numRadius)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbMeanShift;
        private System.Windows.Forms.NumericUpDown _numColorDistance;
        private System.Windows.Forms.NumericUpDown _numRadius;
        private System.Windows.Forms.Label _lblColorDistance;
        private System.Windows.Forms.Label _lblRadius;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
    }
}