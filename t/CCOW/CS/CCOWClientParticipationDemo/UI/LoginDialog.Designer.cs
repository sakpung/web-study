namespace CCOWClientParticipationDemo.UI
{
    partial class LoginDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginDialog));
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.comboBoxUsername = new System.Windows.Forms.ComboBox();
            this.panel1 = new Leadtools.Demos.LoginHeaderPanel();
            this.labelAppName = new System.Windows.Forms.Label();
            this.labelFirstLogin = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(102, 168);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.ReadOnly = true;
            this.textBoxPassword.Size = new System.Drawing.Size(209, 20);
            this.textBoxPassword.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "User name:";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(236, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(155, 204);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // comboBoxUsername
            // 
            this.comboBoxUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUsername.FormattingEnabled = true;
            this.comboBoxUsername.Location = new System.Drawing.Point(102, 127);
            this.comboBoxUsername.Name = "comboBoxUsername";
            this.comboBoxUsername.Size = new System.Drawing.Size(209, 21);
            this.comboBoxUsername.TabIndex = 0;
            this.comboBoxUsername.SelectedIndexChanged += new System.EventHandler(this.comboBoxUsername_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelAppName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 51);
            this.panel1.TabIndex = 13;
            // 
            // labelAppName
            // 
            this.labelAppName.BackColor = System.Drawing.Color.Transparent;
            this.labelAppName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAppName.ForeColor = System.Drawing.SystemColors.Control;
            this.labelAppName.Location = new System.Drawing.Point(0, 0);
            this.labelAppName.Name = "labelAppName";
            this.labelAppName.Size = new System.Drawing.Size(323, 51);
            this.labelAppName.TabIndex = 0;
            this.labelAppName.Text = "This is an application specific login dialog.  The user should use the applicatio" +
                "n specific logon name.";
            this.labelAppName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFirstLogin
            // 
            this.labelFirstLogin.ForeColor = System.Drawing.Color.Red;
            this.labelFirstLogin.Location = new System.Drawing.Point(4, 55);
            this.labelFirstLogin.Name = "labelFirstLogin";
            this.labelFirstLogin.Size = new System.Drawing.Size(319, 69);
            this.labelFirstLogin.TabIndex = 14;
            this.labelFirstLogin.Text = resources.GetString("labelFirstLogin.Text");
            this.labelFirstLogin.Visible = false;
            // 
            // LoginDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 237);
            this.Controls.Add(this.labelFirstLogin);
            this.Controls.Add(this.comboBoxUsername);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login To CCOW Desktop";
            this.Load += new System.EventHandler(this.LoginDialog_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginDialog_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Leadtools.Demos.LoginHeaderPanel panel1;
        private System.Windows.Forms.Label labelAppName;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.ComboBox comboBoxUsername;
        private System.Windows.Forms.Label labelFirstLogin;



    }
}