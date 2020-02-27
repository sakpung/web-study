namespace MedicalViewerLayoutDemo
{
    partial class OverlapDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxCells = new System.Windows.Forms.ListBox();
            this.buttonMoveDown = new System.Windows.Forms.Button();
            this.buttonMoveUp = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cells:";
            // 
            // listBoxCells
            // 
            this.listBoxCells.FormattingEnabled = true;
            this.listBoxCells.Location = new System.Drawing.Point(16, 30);
            this.listBoxCells.Name = "listBoxCells";
            this.listBoxCells.Size = new System.Drawing.Size(244, 277);
            this.listBoxCells.TabIndex = 1;
            this.listBoxCells.SelectedIndexChanged += new System.EventHandler(this.listBoxCells_SelectedIndexChanged);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Enabled = false;
            this.buttonMoveDown.Image = global::MedicalViewerLayoutDemo.Properties.Resources.arrow_down;
            this.buttonMoveDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMoveDown.Location = new System.Drawing.Point(267, 60);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveDown.TabIndex = 3;
            this.buttonMoveDown.Text = "Down";
            this.buttonMoveDown.UseVisualStyleBackColor = true;
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Enabled = false;
            this.buttonMoveUp.Image = global::MedicalViewerLayoutDemo.Properties.Resources.arrow_up;
            this.buttonMoveUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMoveUp.Location = new System.Drawing.Point(267, 30);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveUp.TabIndex = 2;
            this.buttonMoveUp.Text = "Up";
            this.buttonMoveUp.UseVisualStyleBackColor = true;
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // button3
            // 
            this.button3.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button3.Location = new System.Drawing.Point(266, 254);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "OK";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button4.Location = new System.Drawing.Point(267, 283);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Cancel";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // OverlapDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 318);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonMoveDown);
            this.Controls.Add(this.buttonMoveUp);
            this.Controls.Add(this.listBoxCells);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OverlapDialog";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Overlap Priority";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OverlapDialog_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxCells;
        private System.Windows.Forms.Button buttonMoveUp;
        private System.Windows.Forms.Button buttonMoveDown;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}