namespace Leadtools.Medical.Winforms.ClientManager
{
    partial class AssociationDialog
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
            this.labelAssociation = new System.Windows.Forms.Label();
            this.textBoxAssociation = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelAssociation
            // 
            this.labelAssociation.AutoSize = true;
            this.labelAssociation.Location = new System.Drawing.Point(13, 13);
            this.labelAssociation.Name = "labelAssociation";
            this.labelAssociation.Size = new System.Drawing.Size(64, 13);
            this.labelAssociation.TabIndex = 0;
            this.labelAssociation.Text = "Association:";
            // 
            // textBoxAssociation
            // 
            this.textBoxAssociation.Location = new System.Drawing.Point(16, 29);
            this.textBoxAssociation.Multiline = true;
            this.textBoxAssociation.Name = "textBoxAssociation";
            this.textBoxAssociation.ReadOnly = true;
            this.textBoxAssociation.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxAssociation.Size = new System.Drawing.Size(502, 329);
            this.textBoxAssociation.TabIndex = 1;
            this.textBoxAssociation.WordWrap = false;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(443, 373);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // AssociationDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOK;
            this.ClientSize = new System.Drawing.Size(530, 408);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxAssociation);
            this.Controls.Add(this.labelAssociation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssociationDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AssociationDialog";
            this.Load += new System.EventHandler(this.AssociationDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAssociation;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelAssociation;
    }
}