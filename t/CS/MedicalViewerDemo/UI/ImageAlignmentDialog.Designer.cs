namespace MedicalViewerDemo
{
    partial class ImageAlignmentDialog
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
            this._btnReset = new System.Windows.Forms.Button();
            this._bntCancel = new System.Windows.Forms.Button();
            this._cbTransformation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _btnApply
            // 
            this._btnApply.Enabled = false;
            this._btnApply.Location = new System.Drawing.Point(27, 76);
            this._btnApply.Name = "_btnApply";
            this._btnApply.Size = new System.Drawing.Size(75, 23);
            this._btnApply.TabIndex = 0;
            this._btnApply.Text = "Apply";
            this._btnApply.UseVisualStyleBackColor = true;
            this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
            // 
            // _btnReset
            // 
            this._btnReset.Location = new System.Drawing.Point(128, 76);
            this._btnReset.Name = "_btnReset";
            this._btnReset.Size = new System.Drawing.Size(75, 23);
            this._btnReset.TabIndex = 1;
            this._btnReset.Text = "Reset";
            this._btnReset.UseVisualStyleBackColor = true;
            this._btnReset.Click += new System.EventHandler(this._btnReset_Click);
            // 
            // _bntCancel
            // 
            this._bntCancel.Location = new System.Drawing.Point(228, 76);
            this._bntCancel.Name = "_bntCancel";
            this._bntCancel.Size = new System.Drawing.Size(75, 23);
            this._bntCancel.TabIndex = 2;
            this._bntCancel.Text = "Cancel";
            this._bntCancel.UseVisualStyleBackColor = true;
            this._bntCancel.Click += new System.EventHandler(this._bntCancel_Click);
            // 
            // _cbTransformation
            // 
            this._cbTransformation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cbTransformation.FormattingEnabled = true;
            this._cbTransformation.Items.AddRange(new object[] {
            "Unknown ",
            "XY      ",
            "RSXY    ",
            "Affine6 ",
            "Perspective"});
            this._cbTransformation.Location = new System.Drawing.Point(169, 27);
            this._cbTransformation.Name = "_cbTransformation";
            this._cbTransformation.Size = new System.Drawing.Size(121, 21);
            this._cbTransformation.TabIndex = 3;
            this._cbTransformation.SelectedIndexChanged += new System.EventHandler(this._cbTransformation_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Transformation Type";
            // 
            // ImageAlignmentDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 111);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._cbTransformation);
            this.Controls.Add(this._bntCancel);
            this.Controls.Add(this._btnReset);
            this.Controls.Add(this._btnApply);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageAlignmentDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Alignment";
            this.Load += new System.EventHandler(this.ImageAlignmentDialog_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImageAlignmentDialog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnApply;
        private System.Windows.Forms.Button _btnReset;
        private System.Windows.Forms.Button _bntCancel;
        private System.Windows.Forms.ComboBox _cbTransformation;
        private System.Windows.Forms.Label label1;
    }
}