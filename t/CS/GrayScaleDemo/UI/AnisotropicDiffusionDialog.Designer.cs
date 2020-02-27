namespace GrayScaleDemo
{
    partial class AnisotropicDiffusionDialog
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
            this._lblIterations = new System.Windows.Forms.Label();
            this._lblSmoothing = new System.Windows.Forms.Label();
            this._lblTimeStep = new System.Windows.Forms.Label();
            this._lblMinVariation = new System.Windows.Forms.Label();
            this._lblMaxVariation = new System.Windows.Forms.Label();
            this._lblEdgeHeight = new System.Windows.Forms.Label();
            this._lblUpdate = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._numUpdate = new System.Windows.Forms.NumericUpDown();
            this._numEdgeHeight = new System.Windows.Forms.NumericUpDown();
            this._numMaxVariation = new System.Windows.Forms.NumericUpDown();
            this._numMinVariation = new System.Windows.Forms.NumericUpDown();
            this._numTimeStep = new System.Windows.Forms.NumericUpDown();
            this._numSmoothing = new System.Windows.Forms.NumericUpDown();
            this._numIterations = new System.Windows.Forms.NumericUpDown();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numEdgeHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numMaxVariation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numMinVariation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numTimeStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSmoothing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // _lblIterations
            // 
            this._lblIterations.AutoSize = true;
            this._lblIterations.Location = new System.Drawing.Point(16, 25);
            this._lblIterations.Name = "_lblIterations";
            this._lblIterations.Size = new System.Drawing.Size(56, 13);
            this._lblIterations.TabIndex = 0;
            this._lblIterations.Text = "Iterations :";
            // 
            // _lblSmoothing
            // 
            this._lblSmoothing.AutoSize = true;
            this._lblSmoothing.Location = new System.Drawing.Point(16, 55);
            this._lblSmoothing.Name = "_lblSmoothing";
            this._lblSmoothing.Size = new System.Drawing.Size(63, 13);
            this._lblSmoothing.TabIndex = 1;
            this._lblSmoothing.Text = "Smoothing :";
            // 
            // _lblTimeStep
            // 
            this._lblTimeStep.AutoSize = true;
            this._lblTimeStep.Location = new System.Drawing.Point(16, 85);
            this._lblTimeStep.Name = "_lblTimeStep";
            this._lblTimeStep.Size = new System.Drawing.Size(58, 13);
            this._lblTimeStep.TabIndex = 2;
            this._lblTimeStep.Text = "TimeStep :";
            // 
            // _lblMinVariation
            // 
            this._lblMinVariation.AutoSize = true;
            this._lblMinVariation.Location = new System.Drawing.Point(16, 115);
            this._lblMinVariation.Name = "_lblMinVariation";
            this._lblMinVariation.Size = new System.Drawing.Size(71, 13);
            this._lblMinVariation.TabIndex = 3;
            this._lblMinVariation.Text = "MinVariation :";
            // 
            // _lblMaxVariation
            // 
            this._lblMaxVariation.AutoSize = true;
            this._lblMaxVariation.Location = new System.Drawing.Point(16, 145);
            this._lblMaxVariation.Name = "_lblMaxVariation";
            this._lblMaxVariation.Size = new System.Drawing.Size(74, 13);
            this._lblMaxVariation.TabIndex = 4;
            this._lblMaxVariation.Text = "MaxVariation :";
            // 
            // _lblEdgeHeight
            // 
            this._lblEdgeHeight.AutoSize = true;
            this._lblEdgeHeight.Location = new System.Drawing.Point(16, 175);
            this._lblEdgeHeight.Name = "_lblEdgeHeight";
            this._lblEdgeHeight.Size = new System.Drawing.Size(69, 13);
            this._lblEdgeHeight.TabIndex = 5;
            this._lblEdgeHeight.Text = "EdgeHeight :";
            // 
            // _lblUpdate
            // 
            this._lblUpdate.AutoSize = true;
            this._lblUpdate.Location = new System.Drawing.Point(16, 205);
            this._lblUpdate.Name = "_lblUpdate";
            this._lblUpdate.Size = new System.Drawing.Size(48, 13);
            this._lblUpdate.TabIndex = 6;
            this._lblUpdate.Text = "Update :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._numUpdate);
            this.groupBox1.Controls.Add(this._numEdgeHeight);
            this.groupBox1.Controls.Add(this._numMaxVariation);
            this.groupBox1.Controls.Add(this._numMinVariation);
            this.groupBox1.Controls.Add(this._numTimeStep);
            this.groupBox1.Controls.Add(this._numSmoothing);
            this.groupBox1.Controls.Add(this._numIterations);
            this.groupBox1.Controls.Add(this._lblUpdate);
            this.groupBox1.Controls.Add(this._lblEdgeHeight);
            this.groupBox1.Controls.Add(this._lblMaxVariation);
            this.groupBox1.Controls.Add(this._lblMinVariation);
            this.groupBox1.Controls.Add(this._lblTimeStep);
            this.groupBox1.Controls.Add(this._lblSmoothing);
            this.groupBox1.Controls.Add(this._lblIterations);
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 246);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // _numUpdate
            // 
            this._numUpdate.Location = new System.Drawing.Point(100, 203);
            this._numUpdate.Margin = new System.Windows.Forms.Padding(2);
            this._numUpdate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numUpdate.Name = "_numUpdate";
            this._numUpdate.Size = new System.Drawing.Size(116, 20);
            this._numUpdate.TabIndex = 13;
            this._numUpdate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _numEdgeHeight
            // 
            this._numEdgeHeight.Location = new System.Drawing.Point(100, 173);
            this._numEdgeHeight.Margin = new System.Windows.Forms.Padding(2);
            this._numEdgeHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numEdgeHeight.Name = "_numEdgeHeight";
            this._numEdgeHeight.Size = new System.Drawing.Size(116, 20);
            this._numEdgeHeight.TabIndex = 12;
            this._numEdgeHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // _numMaxVariation
            // 
            this._numMaxVariation.DecimalPlaces = 2;
            this._numMaxVariation.Location = new System.Drawing.Point(100, 143);
            this._numMaxVariation.Margin = new System.Windows.Forms.Padding(2);
            this._numMaxVariation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this._numMaxVariation.Name = "_numMaxVariation";
            this._numMaxVariation.Size = new System.Drawing.Size(116, 20);
            this._numMaxVariation.TabIndex = 11;
            this._numMaxVariation.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // _numMinVariation
            // 
            this._numMinVariation.DecimalPlaces = 2;
            this._numMinVariation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this._numMinVariation.Location = new System.Drawing.Point(100, 113);
            this._numMinVariation.Margin = new System.Windows.Forms.Padding(2);
            this._numMinVariation.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this._numMinVariation.Name = "_numMinVariation";
            this._numMinVariation.Size = new System.Drawing.Size(116, 20);
            this._numMinVariation.TabIndex = 10;
            this._numMinVariation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _numTimeStep
            // 
            this._numTimeStep.DecimalPlaces = 2;
            this._numTimeStep.Location = new System.Drawing.Point(100, 83);
            this._numTimeStep.Margin = new System.Windows.Forms.Padding(2);
            this._numTimeStep.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this._numTimeStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._numTimeStep.Name = "_numTimeStep";
            this._numTimeStep.Size = new System.Drawing.Size(116, 20);
            this._numTimeStep.TabIndex = 9;
            this._numTimeStep.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // _numSmoothing
            // 
            this._numSmoothing.Location = new System.Drawing.Point(100, 53);
            this._numSmoothing.Margin = new System.Windows.Forms.Padding(2);
            this._numSmoothing.Name = "_numSmoothing";
            this._numSmoothing.Size = new System.Drawing.Size(116, 20);
            this._numSmoothing.TabIndex = 8;
            this._numSmoothing.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // _numIterations
            // 
            this._numIterations.Location = new System.Drawing.Point(100, 23);
            this._numIterations.Margin = new System.Windows.Forms.Padding(2);
            this._numIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numIterations.Name = "_numIterations";
            this._numIterations.Size = new System.Drawing.Size(116, 20);
            this._numIterations.TabIndex = 7;
            this._numIterations.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numIterations.ValueChanged += new System.EventHandler(this._numIterations_ValueChanged);
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(134, 260);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(68, 22);
            this._btnCancel.TabIndex = 13;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnOk.Location = new System.Drawing.Point(53, 260);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 12;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // AnisotropicDiffusionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 295);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AnisotropicDiffusionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Anisotropic Diffusion";
            this.Load += new System.EventHandler(this.AnisotropicDiffusionDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numEdgeHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numMaxVariation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numMinVariation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numTimeStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numSmoothing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numIterations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lblIterations;
        private System.Windows.Forms.Label _lblSmoothing;
        private System.Windows.Forms.Label _lblTimeStep;
        private System.Windows.Forms.Label _lblMinVariation;
        private System.Windows.Forms.Label _lblMaxVariation;
        private System.Windows.Forms.Label _lblEdgeHeight;
        private System.Windows.Forms.Label _lblUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.NumericUpDown _numIterations;
        private System.Windows.Forms.NumericUpDown _numUpdate;
        private System.Windows.Forms.NumericUpDown _numEdgeHeight;
        private System.Windows.Forms.NumericUpDown _numMaxVariation;
        private System.Windows.Forms.NumericUpDown _numMinVariation;
        private System.Windows.Forms.NumericUpDown _numTimeStep;
        private System.Windows.Forms.NumericUpDown _numSmoothing;

    }
}