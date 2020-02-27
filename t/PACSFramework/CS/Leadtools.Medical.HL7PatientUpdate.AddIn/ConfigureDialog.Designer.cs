namespace Leadtools.Medical.HL7PatientUpdate.AddIn
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
         this.button2 = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.checkBox1 = new System.Windows.Forms.CheckBox();
         this.textBox2 = new System.Windows.Forms.TextBox();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // button2
         // 
         this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button2.Location = new System.Drawing.Point(204, 156);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(75, 23);
         this.button2.TabIndex = 1;
         this.button2.Text = "O&K";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.checkBox1);
         this.groupBox1.Controls.Add(this.textBox2);
         this.groupBox1.Controls.Add(this.textBox1);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(348, 130);
         this.groupBox1.TabIndex = 5;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "HL7 Server";
         // 
         // checkBox1
         // 
         this.checkBox1.AutoSize = true;
         this.checkBox1.Location = new System.Drawing.Point(80, 97);
         this.checkBox1.Name = "checkBox1";
         this.checkBox1.Size = new System.Drawing.Size(167, 17);
         this.checkBox1.TabIndex = 9;
         this.checkBox1.Text = "&Start HL7 server automatically";
         this.checkBox1.UseVisualStyleBackColor = true;
         // 
         // textBox2
         // 
         this.textBox2.Location = new System.Drawing.Point(80, 58);
         this.textBox2.Name = "textBox2";
         this.textBox2.Size = new System.Drawing.Size(189, 20);
         this.textBox2.TabIndex = 8;
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(80, 26);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(189, 20);
         this.textBox1.TabIndex = 7;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(17, 61);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(29, 13);
         this.label2.TabIndex = 5;
         this.label2.Text = "Port:";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(17, 29);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(60, 13);
         this.label1.TabIndex = 6;
         this.label1.Text = "IP address:";
         // 
         // button1
         // 
         this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button1.Location = new System.Drawing.Point(285, 156);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 1;
         this.button1.Text = "&Cancel";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // ConfigureDialog
         // 
         this.ClientSize = new System.Drawing.Size(371, 191);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.button2);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MinimizeBox = false;
         this.Name = "ConfigureDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Load += new System.EventHandler(this.ConfigureDialog_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
    }
}