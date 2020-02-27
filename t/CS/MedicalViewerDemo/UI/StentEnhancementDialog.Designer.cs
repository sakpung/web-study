namespace MedicalViewerDemo
{
    partial class StentEnhancementDialog
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
            this._btnApply = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._stentProgressBar = new System.Windows.Forms.ProgressBar();
            this._btnReset = new System.Windows.Forms.Button();
            this._btnResetAvg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnApply
            // 
            this._btnApply.Location = new System.Drawing.Point(22, 79);
            this._btnApply.Name = "_btnApply";
            this._btnApply.Size = new System.Drawing.Size(75, 23);
            this._btnApply.TabIndex = 0;
            this._btnApply.Text = "Apply";
            this._btnApply.UseVisualStyleBackColor = true;
            this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(292, 79);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(75, 23);
            this._btnOk.TabIndex = 1;
            this._btnOk.Text = "Ok";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _stentProgressBar
            // 
            this._stentProgressBar.Location = new System.Drawing.Point(22, 31);
            this._stentProgressBar.Name = "_stentProgressBar";
            this._stentProgressBar.Size = new System.Drawing.Size(345, 23);
            this._stentProgressBar.TabIndex = 3;
            // 
            // _btnReset
            // 
            this._btnReset.Enabled = false;
            this._btnReset.Location = new System.Drawing.Point(103, 79);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(90, 23);
            this._btnReset.TabIndex = 4;
            this._btnReset.Text = "Reset Region";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
            // 
            // _btnResetAvg
            // 
            this._btnResetAvg.Enabled = false;
            this._btnResetAvg.Location = new System.Drawing.Point(199, 79);
            this._btnResetAvg.Name = "_btnResetAvg";
            this._btnResetAvg.Size = new System.Drawing.Size(87, 23);
            this._btnResetAvg.TabIndex = 5;
            this._btnResetAvg.Text = "Reset Avg";
            this._btnResetAvg.UseVisualStyleBackColor = true;
            this._btnResetAvg.Click += new System.EventHandler(this._btnResetAvg_Click);
            // 
            // StentEnhancementDialog
            // 
            this.AcceptButton = this._btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 114);
            this.Controls.Add(this._btnResetAvg);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._stentProgressBar);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._btnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StentEnhancementDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stent Enhancement Dialog";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StentEnhancementDialog_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnApply;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.ProgressBar _stentProgressBar;
        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.Button _btnResetAvg;
    }
}