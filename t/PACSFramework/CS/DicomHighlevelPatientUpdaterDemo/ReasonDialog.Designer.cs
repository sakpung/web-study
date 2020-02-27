namespace DicomDemo
{
    partial class ReasonDialog
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReasonDialog));
           this.textBoxReason = new System.Windows.Forms.TextBox();
           this.label11 = new System.Windows.Forms.Label();
           this.ReasonCancelButton = new System.Windows.Forms.Button();
           this.OkButton = new System.Windows.Forms.Button();
           this.SuspendLayout();
           // 
           // textBoxReason
           // 
           this.textBoxReason.Location = new System.Drawing.Point(12, 27);
           this.textBoxReason.Multiline = true;
           this.textBoxReason.Name = "textBoxReason";
           this.textBoxReason.Size = new System.Drawing.Size(474, 136);
           this.textBoxReason.TabIndex = 31;
           this.textBoxReason.TextChanged += new System.EventHandler(this.textBoxReason_TextChanged);
           // 
           // label11
           // 
           this.label11.Location = new System.Drawing.Point(12, 11);
           this.label11.Name = "label11";
           this.label11.Size = new System.Drawing.Size(168, 16);
           this.label11.TabIndex = 30;
           this.label11.Text = "Reason:";
           // 
           // ReasonCancelButton
           // 
           this.ReasonCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.ReasonCancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
           this.ReasonCancelButton.Location = new System.Drawing.Point(342, 179);
           this.ReasonCancelButton.Name = "ReasonCancelButton";
           this.ReasonCancelButton.Size = new System.Drawing.Size(144, 39);
           this.ReasonCancelButton.TabIndex = 32;
           this.ReasonCancelButton.Text = "Cancel";
           this.ReasonCancelButton.UseVisualStyleBackColor = true;
           // 
           // OkButton
           // 
           this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.OkButton.Enabled = false;
           this.OkButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
           this.OkButton.Location = new System.Drawing.Point(192, 179);
           this.OkButton.Name = "OkButton";
           this.OkButton.Size = new System.Drawing.Size(144, 39);
           this.OkButton.TabIndex = 33;
           this.OkButton.Text = "OK";
           this.OkButton.UseVisualStyleBackColor = true;
           // 
           // ReasonDialog
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(498, 226);
           this.Controls.Add(this.OkButton);
           this.Controls.Add(this.ReasonCancelButton);
           this.Controls.Add(this.textBoxReason);
           this.Controls.Add(this.label11);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "ReasonDialog";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Reason For Requested Procedure";
           this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReasonDialog_FormClosing);
           this.ResumeLayout(false);
           this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxReason;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button ReasonCancelButton;
        private System.Windows.Forms.Button OkButton;
    }
}