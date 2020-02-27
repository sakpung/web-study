namespace GrayScaleDemo
{
    partial class SetPixelColorDialog
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
            this._gbPoint = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._numY = new System.Windows.Forms.NumericUpDown();
            this._numX = new System.Windows.Forms.NumericUpDown();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._gbGray = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this._numLevel = new System.Windows.Forms.NumericUpDown();
            this._gbRGB = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._numB = new System.Windows.Forms.NumericUpDown();
            this._numG = new System.Windows.Forms.NumericUpDown();
            this._numR = new System.Windows.Forms.NumericUpDown();
            this._gbPoint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numX)).BeginInit();
            this._gbGray.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numLevel)).BeginInit();
            this._gbRGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numR)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbPoint
            // 
            this._gbPoint.Controls.Add(this.label2);
            this._gbPoint.Controls.Add(this.label1);
            this._gbPoint.Controls.Add(this._numY);
            this._gbPoint.Controls.Add(this._numX);
            this._gbPoint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._gbPoint.Location = new System.Drawing.Point(11, 11);
            this._gbPoint.Margin = new System.Windows.Forms.Padding(2);
            this._gbPoint.Name = "_gbPoint";
            this._gbPoint.Padding = new System.Windows.Forms.Padding(2);
            this._gbPoint.Size = new System.Drawing.Size(190, 51);
            this._gbPoint.TabIndex = 13;
            this._gbPoint.TabStop = false;
            this._gbPoint.Text = "Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y =";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X =";
            // 
            // _numY
            // 
            this._numY.Location = new System.Drawing.Point(139, 21);
            this._numY.Name = "_numY";
            this._numY.Size = new System.Drawing.Size(46, 20);
            this._numY.TabIndex = 1;
            // 
            // _numX
            // 
            this._numX.Location = new System.Drawing.Point(46, 21);
            this._numX.Name = "_numX";
            this._numX.Size = new System.Drawing.Size(46, 20);
            this._numX.TabIndex = 0;
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(205, 41);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(68, 22);
            this._btnCancel.TabIndex = 15;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnOk.Location = new System.Drawing.Point(205, 11);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 14;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _gbGray
            // 
            this._gbGray.Controls.Add(this.label6);
            this._gbGray.Controls.Add(this._numLevel);
            this._gbGray.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._gbGray.Location = new System.Drawing.Point(11, 66);
            this._gbGray.Margin = new System.Windows.Forms.Padding(2);
            this._gbGray.Name = "_gbGray";
            this._gbGray.Padding = new System.Windows.Forms.Padding(2);
            this._gbGray.Size = new System.Drawing.Size(190, 68);
            this._gbGray.TabIndex = 16;
            this._gbGray.TabStop = false;
            this._gbGray.Text = "Value";
            this._gbGray.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Level:";
            // 
            // _numLevel
            // 
            this._numLevel.Location = new System.Drawing.Point(35, 42);
            this._numLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numLevel.Name = "_numLevel";
            this._numLevel.Size = new System.Drawing.Size(120, 20);
            this._numLevel.TabIndex = 1;
            // 
            // _gbRGB
            // 
            this._gbRGB.Controls.Add(this.label5);
            this._gbRGB.Controls.Add(this.label4);
            this._gbRGB.Controls.Add(this.label3);
            this._gbRGB.Controls.Add(this._numB);
            this._gbRGB.Controls.Add(this._numG);
            this._gbRGB.Controls.Add(this._numR);
            this._gbRGB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._gbRGB.Location = new System.Drawing.Point(11, 66);
            this._gbRGB.Margin = new System.Windows.Forms.Padding(2);
            this._gbRGB.Name = "_gbRGB";
            this._gbRGB.Padding = new System.Windows.Forms.Padding(2);
            this._gbRGB.Size = new System.Drawing.Size(190, 68);
            this._gbRGB.TabIndex = 17;
            this._gbRGB.TabStop = false;
            this._gbRGB.Text = "RGB";
            this._gbRGB.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "B:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "G:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "R:";
            // 
            // _numB
            // 
            this._numB.Location = new System.Drawing.Point(132, 39);
            this._numB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numB.Name = "_numB";
            this._numB.Size = new System.Drawing.Size(43, 20);
            this._numB.TabIndex = 3;
            // 
            // _numG
            // 
            this._numG.Location = new System.Drawing.Point(78, 39);
            this._numG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numG.Name = "_numG";
            this._numG.Size = new System.Drawing.Size(43, 20);
            this._numG.TabIndex = 2;
            // 
            // _numR
            // 
            this._numR.Location = new System.Drawing.Point(25, 39);
            this._numR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numR.Name = "_numR";
            this._numR.Size = new System.Drawing.Size(43, 20);
            this._numR.TabIndex = 1;
            // 
            // PointDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 153);
            this.Controls.Add(this._gbGray);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._gbPoint);
            this.Controls.Add(this._gbRGB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PointDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Set Pixel Color";
            this.Load += new System.EventHandler(this.PointDialog_Load);
            this._gbPoint.ResumeLayout(false);
            this._gbPoint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numX)).EndInit();
            this._gbGray.ResumeLayout(false);
            this._gbGray.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numLevel)).EndInit();
            this._gbRGB.ResumeLayout(false);
            this._gbRGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbPoint;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown _numY;
        private System.Windows.Forms.NumericUpDown _numX;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.GroupBox _gbGray;
        private System.Windows.Forms.NumericUpDown _numLevel;
        private System.Windows.Forms.GroupBox _gbRGB;
        private System.Windows.Forms.NumericUpDown _numR;
        private System.Windows.Forms.NumericUpDown _numB;
        private System.Windows.Forms.NumericUpDown _numG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}