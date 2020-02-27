namespace GrayScaleDemo
{
    partial class WindowLevelDialog
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
            this._gbOptions = new System.Windows.Forms.GroupBox();
            this._lblEnd = new System.Windows.Forms.Label();
            this._lblStart = new System.Windows.Forms.Label();
            this._numWidth = new System.Windows.Forms.NumericUpDown();
            this._numLevel = new System.Windows.Forms.NumericUpDown();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbOptions
            // 
            this._gbOptions.Controls.Add(this._lblEnd);
            this._gbOptions.Controls.Add(this._lblStart);
            this._gbOptions.Controls.Add(this._numWidth);
            this._gbOptions.Controls.Add(this._numLevel);
            this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._gbOptions.Location = new System.Drawing.Point(6, 4);
            this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
            this._gbOptions.Name = "_gbOptions";
            this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
            this._gbOptions.Size = new System.Drawing.Size(190, 91);
            this._gbOptions.TabIndex = 9;
            this._gbOptions.TabStop = false;
            this._gbOptions.Text = "W/L Values ";
            // 
            // _lblEnd
            // 
            this._lblEnd.AutoSize = true;
            this._lblEnd.Location = new System.Drawing.Point(17, 61);
            this._lblEnd.Name = "_lblEnd";
            this._lblEnd.Size = new System.Drawing.Size(35, 13);
            this._lblEnd.TabIndex = 3;
            this._lblEnd.Text = "Width";
            // 
            // _lblStart
            // 
            this._lblStart.AutoSize = true;
            this._lblStart.Location = new System.Drawing.Point(17, 32);
            this._lblStart.Name = "_lblStart";
            this._lblStart.Size = new System.Drawing.Size(33, 13);
            this._lblStart.TabIndex = 2;
            this._lblStart.Text = "Level";
            // 
            // _numWidth
            // 
            this._numWidth.Location = new System.Drawing.Point(70, 59);
            this._numWidth.Margin = new System.Windows.Forms.Padding(2);
            this._numWidth.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numWidth.Name = "_numWidth";
            this._numWidth.Size = new System.Drawing.Size(116, 20);
            this._numWidth.TabIndex = 1;
            // 
            // _numLevel
            // 
            this._numLevel.Location = new System.Drawing.Point(70, 30);
            this._numLevel.Margin = new System.Windows.Forms.Padding(2);
            this._numLevel.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this._numLevel.Name = "_numLevel";
            this._numLevel.Size = new System.Drawing.Size(116, 20);
            this._numLevel.TabIndex = 0;
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(200, 51);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(68, 22);
            this._btnCancel.TabIndex = 11;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnOk.Location = new System.Drawing.Point(200, 21);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 10;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // WindowLevelDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 98);
            this.Controls.Add(this._gbOptions);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WindowLevelDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Window Level";
            this.Load += new System.EventHandler(this.WindowLevelDialog_Load);
            this._gbOptions.ResumeLayout(false);
            this._gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox _gbOptions;
        private System.Windows.Forms.Label _lblEnd;
        private System.Windows.Forms.Label _lblStart;
        private System.Windows.Forms.NumericUpDown _numWidth;
        private System.Windows.Forms.NumericUpDown _numLevel;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;

    }
}