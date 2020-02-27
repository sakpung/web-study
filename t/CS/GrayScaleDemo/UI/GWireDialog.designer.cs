namespace GrayScaleDemo
{
    partial class GWireDialog 
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
            this._btnOk = new System.Windows.Forms.Button();
            this._numExternal = new System.Windows.Forms.NumericUpDown();
            this._bntApply = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._numExternal)).BeginInit();
            this.SuspendLayout();
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(236, 61);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 0;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _numExternal
            // 
            this._numExternal.Location = new System.Drawing.Point(191, 17);
            this._numExternal.Name = "_numExternal";
            this._numExternal.Size = new System.Drawing.Size(120, 20);
            this._numExternal.TabIndex = 3;
            this._numExternal.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // _bntApply
            // 
            this._bntApply.Location = new System.Drawing.Point(38, 61);
            this._bntApply.Name = "_bntApply";
            this._bntApply.Size = new System.Drawing.Size(75, 23);
            this._bntApply.TabIndex = 4;
            this._bntApply.Text = "Apply";
            this._bntApply.UseVisualStyleBackColor = true;
            this._bntApply.Click += new System.EventHandler(this._bntApply_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "External Energy";
            // 
            // GWireDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 98);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._bntApply);
            this.Controls.Add(this._numExternal);
            this.Controls.Add(this._btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GWireDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "G-Wire Tool";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GWireDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._numExternal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.NumericUpDown _numExternal;
        private System.Windows.Forms.Button _bntApply;
        private System.Windows.Forms.Label label2;
    }
}