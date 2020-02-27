namespace CCOWDashboard
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
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.showDetailedHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.label1 = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.comboBoxScenarios = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.buttonLaunchParticipant1 = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.linkLabelWebWarning = new System.Windows.Forms.LinkLabel();
         this.labelWebWarning = new System.Windows.Forms.Label();
         this.panelWebParticipant1 = new System.Windows.Forms.Panel();
         this.checkBoxWebSSO1 = new System.Windows.Forms.CheckBox();
         this.buttonLaunchWebParticipant1 = new System.Windows.Forms.Button();
         this.panelWebParticipant2 = new System.Windows.Forms.Panel();
         this.checkBoxWebSSO2 = new System.Windows.Forms.CheckBox();
         this.buttonLaunchWebParticipant2 = new System.Windows.Forms.Button();
         this.panelParticipant3 = new System.Windows.Forms.Panel();
         this.checkBoxSSO3 = new System.Windows.Forms.CheckBox();
         this.buttonLaunchParticipant3 = new System.Windows.Forms.Button();
         this.panelParticipant2 = new System.Windows.Forms.Panel();
         this.checkBoxSSO2 = new System.Windows.Forms.CheckBox();
         this.buttonLaunchParticipant2 = new System.Windows.Forms.Button();
         this.panelParticipant1 = new System.Windows.Forms.Panel();
         this.checkBoxSSO1 = new System.Windows.Forms.CheckBox();
         this.label3 = new System.Windows.Forms.Label();
         this.menuStrip1.SuspendLayout();
         this.panel1.SuspendLayout();
         this.groupBox1.SuspendLayout();
         this.panelWebParticipant1.SuspendLayout();
         this.panelWebParticipant2.SuspendLayout();
         this.panelParticipant3.SuspendLayout();
         this.panelParticipant2.SuspendLayout();
         this.panelParticipant1.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(548, 24);
         this.menuStrip1.TabIndex = 20;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         // 
         // exitToolStripMenuItem
         // 
         this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
         this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
         this.exitToolStripMenuItem.Text = "&Exit";
         this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
         // 
         // helpToolStripMenuItem
         // 
         this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailedHelpToolStripMenuItem,
            this.aboutToolStripMenuItem1});
         this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
         this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
         this.helpToolStripMenuItem.Text = "&Help";
         // 
         // showDetailedHelpToolStripMenuItem
         // 
         this.showDetailedHelpToolStripMenuItem.Name = "showDetailedHelpToolStripMenuItem";
         this.showDetailedHelpToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
         this.showDetailedHelpToolStripMenuItem.Text = "Show Detailed Help...";
         this.showDetailedHelpToolStripMenuItem.Click += new System.EventHandler(this.showDetailedHelpToolStripMenuItem_Click);
         // 
         // aboutToolStripMenuItem1
         // 
         this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
         this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
         this.aboutToolStripMenuItem1.Text = "About...";
         this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
         // 
         // label1
         // 
         this.label1.Dock = System.Windows.Forms.DockStyle.Top;
         this.label1.Location = new System.Drawing.Point(0, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(548, 103);
         this.label1.TabIndex = 21;
         this.label1.Text = resources.GetString("label1.Text");
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.comboBoxScenarios);
         this.panel1.Controls.Add(this.label2);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(0, 127);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(548, 35);
         this.panel1.TabIndex = 22;
         // 
         // comboBoxScenarios
         // 
         this.comboBoxScenarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxScenarios.FormattingEnabled = true;
         this.comboBoxScenarios.Location = new System.Drawing.Point(86, 8);
         this.comboBoxScenarios.Name = "comboBoxScenarios";
         this.comboBoxScenarios.Size = new System.Drawing.Size(456, 21);
         this.comboBoxScenarios.TabIndex = 1;
         this.comboBoxScenarios.SelectedIndexChanged += new System.EventHandler(this.comboBoxScenarios_SelectedIndexChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label2.Location = new System.Drawing.Point(4, 16);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(76, 13);
         this.label2.TabIndex = 0;
         this.label2.Text = "1. Scenario:";
         // 
         // buttonLaunchParticipant1
         // 
         this.buttonLaunchParticipant1.BackColor = System.Drawing.Color.Transparent;
         this.buttonLaunchParticipant1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonLaunchParticipant1.ForeColor = System.Drawing.SystemColors.ControlText;
         this.buttonLaunchParticipant1.Location = new System.Drawing.Point(2, 4);
         this.buttonLaunchParticipant1.Name = "buttonLaunchParticipant1";
         this.buttonLaunchParticipant1.Size = new System.Drawing.Size(150, 22);
         this.buttonLaunchParticipant1.TabIndex = 3;
         this.buttonLaunchParticipant1.Text = "Participant Demo 1";
         this.buttonLaunchParticipant1.UseVisualStyleBackColor = false;
         this.buttonLaunchParticipant1.Click += new System.EventHandler(this.buttonLaunchParticipant1_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.linkLabelWebWarning);
         this.groupBox1.Controls.Add(this.labelWebWarning);
         this.groupBox1.Controls.Add(this.panelWebParticipant1);
         this.groupBox1.Controls.Add(this.panelWebParticipant2);
         this.groupBox1.Controls.Add(this.panelParticipant3);
         this.groupBox1.Controls.Add(this.panelParticipant2);
         this.groupBox1.Controls.Add(this.panelParticipant1);
         this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.groupBox1.Location = new System.Drawing.Point(3, 243);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(532, 175);
         this.groupBox1.TabIndex = 26;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "2. Launch Participant Demo";
         // 
         // linkLabelWebWarning
         // 
         this.linkLabelWebWarning.AutoSize = true;
         this.linkLabelWebWarning.LinkArea = new System.Windows.Forms.LinkArea(33, 10);
         this.linkLabelWebWarning.Location = new System.Drawing.Point(14, 156);
         this.linkLabelWebWarning.Name = "linkLabelWebWarning";
         this.linkLabelWebWarning.Size = new System.Drawing.Size(387, 17);
         this.linkLabelWebWarning.TabIndex = 11;
         this.linkLabelWebWarning.TabStop = true;
         this.linkLabelWebWarning.Text = "Failed to reach Web Client Demo, Click here to run the Configuration tool.";
         this.linkLabelWebWarning.UseCompatibleTextRendering = true;
         this.linkLabelWebWarning.Visible = false;
         // 
         // labelWebWarning
         // 
         this.labelWebWarning.AutoSize = true;
         this.labelWebWarning.Location = new System.Drawing.Point(11, 156);
         this.labelWebWarning.Name = "labelWebWarning";
         this.labelWebWarning.Size = new System.Drawing.Size(424, 13);
         this.labelWebWarning.TabIndex = 10;
         this.labelWebWarning.Text = "Run CCOW Dashboard as Administrator to enable Web Paricipant Demos.";
         this.labelWebWarning.Visible = false;
         // 
         // panelWebParticipant1
         // 
         this.panelWebParticipant1.BackColor = System.Drawing.Color.DarkBlue;
         this.panelWebParticipant1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panelWebParticipant1.Controls.Add(this.checkBoxWebSSO1);
         this.panelWebParticipant1.Controls.Add(this.buttonLaunchWebParticipant1);
         this.panelWebParticipant1.ForeColor = System.Drawing.Color.Red;
         this.panelWebParticipant1.Location = new System.Drawing.Point(83, 90);
         this.panelWebParticipant1.Name = "panelWebParticipant1";
         this.panelWebParticipant1.Size = new System.Drawing.Size(161, 58);
         this.panelWebParticipant1.TabIndex = 8;
         // 
         // checkBoxWebSSO1
         // 
         this.checkBoxWebSSO1.AutoSize = true;
         this.checkBoxWebSSO1.BackColor = System.Drawing.Color.Transparent;
         this.checkBoxWebSSO1.ForeColor = System.Drawing.SystemColors.Control;
         this.checkBoxWebSSO1.Location = new System.Drawing.Point(3, 32);
         this.checkBoxWebSSO1.Name = "checkBoxWebSSO1";
         this.checkBoxWebSSO1.Size = new System.Drawing.Size(127, 17);
         this.checkBoxWebSSO1.TabIndex = 5;
         this.checkBoxWebSSO1.Text = "Launch With SSO";
         this.checkBoxWebSSO1.UseVisualStyleBackColor = false;
         // 
         // buttonLaunchWebParticipant1
         // 
         this.buttonLaunchWebParticipant1.BackColor = System.Drawing.Color.Transparent;
         this.buttonLaunchWebParticipant1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonLaunchWebParticipant1.ForeColor = System.Drawing.SystemColors.ControlText;
         this.buttonLaunchWebParticipant1.Location = new System.Drawing.Point(2, 4);
         this.buttonLaunchWebParticipant1.Name = "buttonLaunchWebParticipant1";
         this.buttonLaunchWebParticipant1.Size = new System.Drawing.Size(154, 22);
         this.buttonLaunchWebParticipant1.TabIndex = 3;
         this.buttonLaunchWebParticipant1.Text = "Web Participant Demo 1";
         this.buttonLaunchWebParticipant1.UseVisualStyleBackColor = false;
         // 
         // panelWebParticipant2
         // 
         this.panelWebParticipant2.BackColor = System.Drawing.Color.Purple;
         this.panelWebParticipant2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panelWebParticipant2.Controls.Add(this.checkBoxWebSSO2);
         this.panelWebParticipant2.Controls.Add(this.buttonLaunchWebParticipant2);
         this.panelWebParticipant2.ForeColor = System.Drawing.Color.Red;
         this.panelWebParticipant2.Location = new System.Drawing.Point(275, 90);
         this.panelWebParticipant2.Name = "panelWebParticipant2";
         this.panelWebParticipant2.Size = new System.Drawing.Size(161, 58);
         this.panelWebParticipant2.TabIndex = 9;
         // 
         // checkBoxWebSSO2
         // 
         this.checkBoxWebSSO2.AutoSize = true;
         this.checkBoxWebSSO2.BackColor = System.Drawing.Color.Transparent;
         this.checkBoxWebSSO2.ForeColor = System.Drawing.SystemColors.Control;
         this.checkBoxWebSSO2.Location = new System.Drawing.Point(3, 32);
         this.checkBoxWebSSO2.Name = "checkBoxWebSSO2";
         this.checkBoxWebSSO2.Size = new System.Drawing.Size(127, 17);
         this.checkBoxWebSSO2.TabIndex = 5;
         this.checkBoxWebSSO2.Text = "Launch With SSO";
         this.checkBoxWebSSO2.UseVisualStyleBackColor = false;
         // 
         // buttonLaunchWebParticipant2
         // 
         this.buttonLaunchWebParticipant2.BackColor = System.Drawing.Color.Transparent;
         this.buttonLaunchWebParticipant2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonLaunchWebParticipant2.ForeColor = System.Drawing.SystemColors.ControlText;
         this.buttonLaunchWebParticipant2.Location = new System.Drawing.Point(2, 4);
         this.buttonLaunchWebParticipant2.Name = "buttonLaunchWebParticipant2";
         this.buttonLaunchWebParticipant2.Size = new System.Drawing.Size(154, 22);
         this.buttonLaunchWebParticipant2.TabIndex = 3;
         this.buttonLaunchWebParticipant2.Text = "Web Participant Demo 2";
         this.buttonLaunchWebParticipant2.UseVisualStyleBackColor = false;
         // 
         // panelParticipant3
         // 
         this.panelParticipant3.BackColor = System.Drawing.Color.Blue;
         this.panelParticipant3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panelParticipant3.Controls.Add(this.checkBoxSSO3);
         this.panelParticipant3.Controls.Add(this.buttonLaunchParticipant3);
         this.panelParticipant3.ForeColor = System.Drawing.Color.Red;
         this.panelParticipant3.Location = new System.Drawing.Point(370, 15);
         this.panelParticipant3.Name = "panelParticipant3";
         this.panelParticipant3.Size = new System.Drawing.Size(156, 58);
         this.panelParticipant3.TabIndex = 8;
         // 
         // checkBoxSSO3
         // 
         this.checkBoxSSO3.AutoSize = true;
         this.checkBoxSSO3.BackColor = System.Drawing.Color.Transparent;
         this.checkBoxSSO3.Checked = true;
         this.checkBoxSSO3.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBoxSSO3.ForeColor = System.Drawing.SystemColors.Control;
         this.checkBoxSSO3.Location = new System.Drawing.Point(2, 32);
         this.checkBoxSSO3.Name = "checkBoxSSO3";
         this.checkBoxSSO3.Size = new System.Drawing.Size(127, 17);
         this.checkBoxSSO3.TabIndex = 5;
         this.checkBoxSSO3.Text = "Launch With SSO";
         this.checkBoxSSO3.UseVisualStyleBackColor = false;
         // 
         // buttonLaunchParticipant3
         // 
         this.buttonLaunchParticipant3.BackColor = System.Drawing.Color.Transparent;
         this.buttonLaunchParticipant3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonLaunchParticipant3.ForeColor = System.Drawing.SystemColors.ControlText;
         this.buttonLaunchParticipant3.Location = new System.Drawing.Point(2, 4);
         this.buttonLaunchParticipant3.Name = "buttonLaunchParticipant3";
         this.buttonLaunchParticipant3.Size = new System.Drawing.Size(150, 22);
         this.buttonLaunchParticipant3.TabIndex = 3;
         this.buttonLaunchParticipant3.Text = "Participant Demo 3";
         this.buttonLaunchParticipant3.UseVisualStyleBackColor = false;
         this.buttonLaunchParticipant3.Click += new System.EventHandler(this.buttonLaunchParticipant3_Click);
         // 
         // panelParticipant2
         // 
         this.panelParticipant2.BackColor = System.Drawing.Color.Green;
         this.panelParticipant2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panelParticipant2.Controls.Add(this.checkBoxSSO2);
         this.panelParticipant2.Controls.Add(this.buttonLaunchParticipant2);
         this.panelParticipant2.ForeColor = System.Drawing.Color.Red;
         this.panelParticipant2.Location = new System.Drawing.Point(188, 15);
         this.panelParticipant2.Name = "panelParticipant2";
         this.panelParticipant2.Size = new System.Drawing.Size(156, 58);
         this.panelParticipant2.TabIndex = 7;
         // 
         // checkBoxSSO2
         // 
         this.checkBoxSSO2.AutoSize = true;
         this.checkBoxSSO2.BackColor = System.Drawing.Color.Transparent;
         this.checkBoxSSO2.Checked = true;
         this.checkBoxSSO2.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBoxSSO2.ForeColor = System.Drawing.SystemColors.Control;
         this.checkBoxSSO2.Location = new System.Drawing.Point(3, 32);
         this.checkBoxSSO2.Name = "checkBoxSSO2";
         this.checkBoxSSO2.Size = new System.Drawing.Size(127, 17);
         this.checkBoxSSO2.TabIndex = 5;
         this.checkBoxSSO2.Text = "Launch With SSO";
         this.checkBoxSSO2.UseVisualStyleBackColor = false;
         // 
         // buttonLaunchParticipant2
         // 
         this.buttonLaunchParticipant2.BackColor = System.Drawing.Color.Transparent;
         this.buttonLaunchParticipant2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.buttonLaunchParticipant2.ForeColor = System.Drawing.SystemColors.ControlText;
         this.buttonLaunchParticipant2.Location = new System.Drawing.Point(2, 4);
         this.buttonLaunchParticipant2.Name = "buttonLaunchParticipant2";
         this.buttonLaunchParticipant2.Size = new System.Drawing.Size(150, 22);
         this.buttonLaunchParticipant2.TabIndex = 3;
         this.buttonLaunchParticipant2.Text = "Participant Demo 2";
         this.buttonLaunchParticipant2.UseVisualStyleBackColor = false;
         this.buttonLaunchParticipant2.Click += new System.EventHandler(this.buttonLaunchParticipant2_Click);
         // 
         // panelParticipant1
         // 
         this.panelParticipant1.BackColor = System.Drawing.Color.Red;
         this.panelParticipant1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panelParticipant1.Controls.Add(this.checkBoxSSO1);
         this.panelParticipant1.Controls.Add(this.buttonLaunchParticipant1);
         this.panelParticipant1.ForeColor = System.Drawing.Color.Red;
         this.panelParticipant1.Location = new System.Drawing.Point(6, 15);
         this.panelParticipant1.Name = "panelParticipant1";
         this.panelParticipant1.Size = new System.Drawing.Size(156, 58);
         this.panelParticipant1.TabIndex = 6;
         // 
         // checkBoxSSO1
         // 
         this.checkBoxSSO1.AutoSize = true;
         this.checkBoxSSO1.BackColor = System.Drawing.Color.Transparent;
         this.checkBoxSSO1.Checked = true;
         this.checkBoxSSO1.CheckState = System.Windows.Forms.CheckState.Checked;
         this.checkBoxSSO1.ForeColor = System.Drawing.SystemColors.Control;
         this.checkBoxSSO1.Location = new System.Drawing.Point(4, 33);
         this.checkBoxSSO1.Name = "checkBoxSSO1";
         this.checkBoxSSO1.Size = new System.Drawing.Size(127, 17);
         this.checkBoxSSO1.TabIndex = 4;
         this.checkBoxSSO1.Text = "Launch With SSO";
         this.checkBoxSSO1.UseVisualStyleBackColor = false;
         // 
         // label3
         // 
         this.label3.Dock = System.Windows.Forms.DockStyle.Top;
         this.label3.Location = new System.Drawing.Point(0, 162);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(548, 74);
         this.label3.TabIndex = 23;
         this.label3.Text = resources.GetString("label3.Text");
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(548, 425);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.menuStrip1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.panelWebParticipant1.ResumeLayout(false);
         this.panelWebParticipant1.PerformLayout();
         this.panelWebParticipant2.ResumeLayout(false);
         this.panelWebParticipant2.PerformLayout();
         this.panelParticipant3.ResumeLayout(false);
         this.panelParticipant3.PerformLayout();
         this.panelParticipant2.ResumeLayout(false);
         this.panelParticipant2.PerformLayout();
         this.panelParticipant1.ResumeLayout(false);
         this.panelParticipant1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxScenarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLaunchParticipant1;
        private System.Windows.Forms.Panel panelParticipant1;
        private System.Windows.Forms.Panel panelParticipant3;
        private System.Windows.Forms.Button buttonLaunchParticipant3;
        private System.Windows.Forms.Panel panelParticipant2;
        private System.Windows.Forms.Button buttonLaunchParticipant2;
        private System.Windows.Forms.CheckBox checkBoxSSO1;
        private System.Windows.Forms.CheckBox checkBoxSSO2;
        private System.Windows.Forms.CheckBox checkBoxSSO3;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDetailedHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.Panel panelWebParticipant1;
        private System.Windows.Forms.CheckBox checkBoxWebSSO1;
        private System.Windows.Forms.Button buttonLaunchWebParticipant1;
        private System.Windows.Forms.Panel panelWebParticipant2;
        private System.Windows.Forms.CheckBox checkBoxWebSSO2;
        private System.Windows.Forms.Button buttonLaunchWebParticipant2;
        private System.Windows.Forms.Label labelWebWarning;
        private System.Windows.Forms.LinkLabel linkLabelWebWarning;
    }
}