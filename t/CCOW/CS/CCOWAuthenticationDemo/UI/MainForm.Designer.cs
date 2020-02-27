namespace CCOWAuthenticationDemo
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
            this.labelAppName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelCurrentUser = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.buttonLogon = new System.Windows.Forms.Button();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.loginHeaderPanel1 = new Leadtools.Demos.LoginHeaderPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxCcowStatus = new System.Windows.Forms.PictureBox();
            this.loginHeaderPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCcowStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // labelAppName
            // 
            this.labelAppName.BackColor = System.Drawing.Color.Transparent;
            this.labelAppName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppName.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAppName.Location = new System.Drawing.Point(0, 0);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(428, 168);
            this.labelAppName.TabIndex = 21;
            this.labelAppName.Text = "ClientDemo";
            this.labelAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 168);
            this.label1.TabIndex = 22;
            this.label1.Text = "ClientDemo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(428, 168);
            this.label2.TabIndex = 23;
            this.label2.Text = "ClientDemo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Current User:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Full Name:";
            // 
            // labelCurrentUser
            // 
            this.labelCurrentUser.AutoSize = true;
            this.labelCurrentUser.Location = new System.Drawing.Point(89, 55);
            this.labelCurrentUser.Name = "labelCurrentUser";
            this.labelCurrentUser.Size = new System.Drawing.Size(69, 13);
            this.labelCurrentUser.TabIndex = 27;
            this.labelCurrentUser.Text = "Current User:";
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(89, 82);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(69, 13);
            this.labelFullName.TabIndex = 28;
            this.labelFullName.Text = "Current User:";
            // 
            // buttonLogon
            // 
            this.buttonLogon.Location = new System.Drawing.Point(338, 129);
            this.buttonLogon.Name = "buttonLogon";
            this.buttonLogon.Size = new System.Drawing.Size(75, 23);
            this.buttonLogon.TabIndex = 29;
            this.buttonLogon.Text = "Logon";
            this.buttonLogon.UseVisualStyleBackColor = true;
            this.buttonLogon.Click += new System.EventHandler(this.buttonLogon_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(4, 129);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(75, 23);
            this.buttonAbout.TabIndex = 30;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // loginHeaderPanel1
            // 
            this.loginHeaderPanel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.loginHeaderPanel1.Controls.Add(this.label5);
            this.loginHeaderPanel1.Controls.Add(this.pictureBoxCcowStatus);
            this.loginHeaderPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.loginHeaderPanel1.Location = new System.Drawing.Point(0, 0);
            this.loginHeaderPanel1.Name = "loginHeaderPanel1";
            this.loginHeaderPanel1.Size = new System.Drawing.Size(428, 42);
            this.loginHeaderPanel1.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 42);
            this.label5.TabIndex = 1;
            this.label5.Text = "CCOW Single Sign On";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxCcowStatus
            // 
            this.pictureBoxCcowStatus.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxCcowStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxCcowStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBoxCcowStatus.Image = global::CCOWAuthenticationDemo.Properties.Resources.Broken;
            this.pictureBoxCcowStatus.Location = new System.Drawing.Point(378, 0);
            this.pictureBoxCcowStatus.Name = "pictureBoxCcowStatus";
            this.pictureBoxCcowStatus.Size = new System.Drawing.Size(50, 42);
            this.pictureBoxCcowStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxCcowStatus.TabIndex = 0;
            this.pictureBoxCcowStatus.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 168);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.buttonLogon);
            this.Controls.Add(this.labelFullName);
            this.Controls.Add(this.labelCurrentUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.loginHeaderPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelAppName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.loginHeaderPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCcowStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Leadtools.Demos.LoginHeaderPanel loginHeaderPanel1;
        private System.Windows.Forms.PictureBox pictureBoxCcowStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCurrentUser;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Button buttonLogon;
        private System.Windows.Forms.Button buttonAbout;
    }
}