namespace GrayScaleDemo
{
    partial class Result
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
            this._lblResult = new System.Windows.Forms.Label();
            this._btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _lblResult
            // 
            this._lblResult.Location = new System.Drawing.Point(33, 9);
            this._lblResult.Name = "_lblResult";
            this._lblResult.Size = new System.Drawing.Size(97, 19);
            this._lblResult.TabIndex = 0;
            this._lblResult.Text = "label1";
            // 
            // _btnOk
            // 
            this._btnOk.Location = new System.Drawing.Point(56, 37);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(53, 27);
            this._btnOk.TabIndex = 1;
            this._btnOk.Text = "OK";
            this._btnOk.UseVisualStyleBackColor = true;
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(162, 68);
            this.Controls.Add(this._btnOk);
            this.Controls.Add(this._lblResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Result";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Result";
            this.Load += new System.EventHandler(this.Result_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _lblResult;
        private System.Windows.Forms.Button _btnOk;
    }
}