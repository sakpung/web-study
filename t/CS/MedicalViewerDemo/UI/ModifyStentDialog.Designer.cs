namespace MedicalViewerDemo
{
    partial class ModifyStent
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
            this._cbFrames = new System.Windows.Forms.CheckedListBox();
            this._btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _cbFrames
            // 
            this._cbFrames.FormattingEnabled = true;
            this._cbFrames.Location = new System.Drawing.Point(12, 12);
            this._cbFrames.Name = "_cbFrames";
            this._cbFrames.Size = new System.Drawing.Size(227, 244);
            this._cbFrames.TabIndex = 0;
            this._cbFrames.SelectedIndexChanged += new System.EventHandler(this._cbFrames_SelectedIndexChanged);
            this._cbFrames.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this._cbFrames_ItemCheck);
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(80, 261);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(91, 23);
            this._btnOk.TabIndex = 1;
            this._btnOk.Text = "Ok";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // ModifyStent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 293);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._cbFrames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(257, 321);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(257, 321);
            this.Name = "ModifyStent";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unselect Stent Frames";
            this.Load += new System.EventHandler(this.ModifyStent_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModifyStent_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox _cbFrames;
        private System.Windows.Forms.Button _btnOk;
    }
}