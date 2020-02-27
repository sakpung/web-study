namespace Leadtools.AddIn.Security
{
    partial class ConfigureDialog
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
           System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureDialog));
           this.button1 = new System.Windows.Forms.Button();
           this.button2 = new System.Windows.Forms.Button();
           this.propertyGridOptions = new System.Windows.Forms.PropertyGrid();
           this.SuspendLayout();
           // 
           // button1
           // 
           this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
           this.button1.Location = new System.Drawing.Point(403, 419);
           this.button1.Name = "button1";
           this.button1.Size = new System.Drawing.Size(75, 23);
           this.button1.TabIndex = 0;
           this.button1.Text = "OK";
           this.button1.UseVisualStyleBackColor = true;
           // 
           // button2
           // 
           this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
           this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
           this.button2.Location = new System.Drawing.Point(486, 419);
           this.button2.Name = "button2";
           this.button2.Size = new System.Drawing.Size(75, 23);
           this.button2.TabIndex = 1;
           this.button2.Text = "Cancel";
           this.button2.UseVisualStyleBackColor = true;
           // 
           // propertyGridOptions
           // 
           this.propertyGridOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                       | System.Windows.Forms.AnchorStyles.Right)));
           this.propertyGridOptions.Location = new System.Drawing.Point(13, 13);
           this.propertyGridOptions.Name = "propertyGridOptions";
           this.propertyGridOptions.Size = new System.Drawing.Size(548, 400);
           this.propertyGridOptions.TabIndex = 2;
           // 
           // ConfigureDialog
           // 
           this.ClientSize = new System.Drawing.Size(573, 454);
           this.Controls.Add(this.propertyGridOptions);
           this.Controls.Add(this.button2);
           this.Controls.Add(this.button1);
           this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
           this.MinimizeBox = false;
           this.Name = "ConfigureDialog";
           this.ShowInTaskbar = false;
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.PropertyGrid propertyGridOptions;
    }
}