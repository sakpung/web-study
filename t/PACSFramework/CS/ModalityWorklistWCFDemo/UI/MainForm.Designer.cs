namespace ModalityWorklistWCFDemo.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.wizardSheet = new Leadtools.Wizard.WizardSheet();
            this.SuspendLayout();
            // 
            // wizardSheet
            // 
            this.wizardSheet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardSheet.Font = new System.Drawing.Font("Arial", 8F);
            this.wizardSheet.Location = new System.Drawing.Point(0, 0);
            this.wizardSheet.Name = "wizardSheet";
            this.wizardSheet.Option1Caption = "Option1";
            this.wizardSheet.Size = new System.Drawing.Size(567, 436);
            this.wizardSheet.TabIndex = 0;
            this.wizardSheet.WizardFinished += new System.ComponentModel.CancelEventHandler(this.wizardSheet_WizardFinished);
            this.wizardSheet.About += new System.EventHandler(this.wizardSheet_About);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 436);
            this.Controls.Add(this.wizardSheet);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Leadtools.Wizard.WizardSheet wizardSheet;
    }
}