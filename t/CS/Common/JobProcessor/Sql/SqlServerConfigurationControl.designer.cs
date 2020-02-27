namespace Leadtools.Common.JobProcessor
{
   partial class SqlServerConfigurationControl
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlServerConfigurationControl));
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.labelSqlNote = new System.Windows.Forms.Label();
         this.userInfoPanel = new System.Windows.Forms.Panel();
         this.passwordTextBox = new System.Windows.Forms.TextBox();
         this.userNameTextBox = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.sqlAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
         this.windowsAuthenticationRadioButton = new System.Windows.Forms.RadioButton();
         this.label2 = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.refreshServersButton = new System.Windows.Forms.Button();
         this.serverNameCoboBox = new System.Windows.Forms.ComboBox();
         this.panel2 = new System.Windows.Forms.Panel();
         this.checkBoxOverwrite = new System.Windows.Forms.CheckBox();
         this.serverDatabaseComboBox = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.groupBox1.SuspendLayout();
         this.userInfoPanel.SuspendLayout();
         this.panel1.SuspendLayout();
         this.panel2.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.labelSqlNote);
         this.groupBox1.Controls.Add(this.userInfoPanel);
         this.groupBox1.Controls.Add(this.sqlAuthenticationRadioButton);
         this.groupBox1.Controls.Add(this.windowsAuthenticationRadioButton);
         this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.groupBox1.Location = new System.Drawing.Point(0, 64);
         this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.groupBox1.Size = new System.Drawing.Size(488, 191);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Log On to the server:";
         // 
         // labelSqlNote
         // 
         this.labelSqlNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.labelSqlNote.ForeColor = System.Drawing.Color.Red;
         this.labelSqlNote.Location = new System.Drawing.Point(14, 124);
         this.labelSqlNote.Name = "labelSqlNote";
         this.labelSqlNote.Size = new System.Drawing.Size(465, 57);
         this.labelSqlNote.TabIndex = 3;
         this.labelSqlNote.Text = resources.GetString("labelSqlNote.Text");
         // 
         // userInfoPanel
         // 
         this.userInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.userInfoPanel.Controls.Add(this.passwordTextBox);
         this.userInfoPanel.Controls.Add(this.userNameTextBox);
         this.userInfoPanel.Controls.Add(this.label4);
         this.userInfoPanel.Controls.Add(this.label3);
         this.userInfoPanel.Location = new System.Drawing.Point(18, 65);
         this.userInfoPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.userInfoPanel.Name = "userInfoPanel";
         this.userInfoPanel.Size = new System.Drawing.Size(461, 50);
         this.userInfoPanel.TabIndex = 2;
         // 
         // passwordTextBox
         // 
         this.passwordTextBox.Location = new System.Drawing.Point(73, 28);
         this.passwordTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.passwordTextBox.Name = "passwordTextBox";
         this.passwordTextBox.PasswordChar = '*';
         this.passwordTextBox.Size = new System.Drawing.Size(298, 20);
         this.passwordTextBox.TabIndex = 1;
         // 
         // userNameTextBox
         // 
         this.userNameTextBox.Location = new System.Drawing.Point(73, 2);
         this.userNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.userNameTextBox.Name = "userNameTextBox";
         this.userNameTextBox.Size = new System.Drawing.Size(298, 20);
         this.userNameTextBox.TabIndex = 0;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(3, 31);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(56, 13);
         this.label4.TabIndex = 3;
         this.label4.Text = "&Password:";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(3, 5);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(61, 13);
         this.label3.TabIndex = 1;
         this.label3.Text = "&User name:";
         // 
         // sqlAuthenticationRadioButton
         // 
         this.sqlAuthenticationRadioButton.AutoSize = true;
         this.sqlAuthenticationRadioButton.Location = new System.Drawing.Point(5, 47);
         this.sqlAuthenticationRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.sqlAuthenticationRadioButton.Name = "sqlAuthenticationRadioButton";
         this.sqlAuthenticationRadioButton.Size = new System.Drawing.Size(173, 17);
         this.sqlAuthenticationRadioButton.TabIndex = 1;
         this.sqlAuthenticationRadioButton.TabStop = true;
         this.sqlAuthenticationRadioButton.Text = "Use S&QL Server Authentication";
         this.sqlAuthenticationRadioButton.UseVisualStyleBackColor = true;
         // 
         // windowsAuthenticationRadioButton
         // 
         this.windowsAuthenticationRadioButton.AutoSize = true;
         this.windowsAuthenticationRadioButton.Checked = true;
         this.windowsAuthenticationRadioButton.Location = new System.Drawing.Point(5, 25);
         this.windowsAuthenticationRadioButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.windowsAuthenticationRadioButton.Name = "windowsAuthenticationRadioButton";
         this.windowsAuthenticationRadioButton.Size = new System.Drawing.Size(165, 17);
         this.windowsAuthenticationRadioButton.TabIndex = 0;
         this.windowsAuthenticationRadioButton.TabStop = true;
         this.windowsAuthenticationRadioButton.Text = "Use &Windows Authentication ";
         this.windowsAuthenticationRadioButton.UseVisualStyleBackColor = true;
         this.windowsAuthenticationRadioButton.CheckedChanged += new System.EventHandler(this.windowsAuthenticationRadioButton_CheckedChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(7, 11);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(70, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "S&erver name:";
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this.refreshServersButton);
         this.panel1.Controls.Add(this.serverNameCoboBox);
         this.panel1.Controls.Add(this.label2);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(488, 64);
         this.panel1.TabIndex = 0;
         // 
         // refreshServersButton
         // 
         this.refreshServersButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.refreshServersButton.Location = new System.Drawing.Point(398, 28);
         this.refreshServersButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.refreshServersButton.Name = "refreshServersButton";
         this.refreshServersButton.Size = new System.Drawing.Size(81, 29);
         this.refreshServersButton.TabIndex = 1;
         this.refreshServersButton.Text = "&Refresh";
         this.refreshServersButton.UseVisualStyleBackColor = true;
         // 
         // serverNameCoboBox
         // 
         this.serverNameCoboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.serverNameCoboBox.FormattingEnabled = true;
         this.serverNameCoboBox.Location = new System.Drawing.Point(5, 33);
         this.serverNameCoboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.serverNameCoboBox.Name = "serverNameCoboBox";
         this.serverNameCoboBox.Size = new System.Drawing.Size(390, 21);
         this.serverNameCoboBox.TabIndex = 0;
         // 
         // panel2
         // 
         this.panel2.Controls.Add(this.checkBoxOverwrite);
         this.panel2.Controls.Add(this.serverDatabaseComboBox);
         this.panel2.Controls.Add(this.label1);
         this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
         this.panel2.Location = new System.Drawing.Point(0, 255);
         this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.panel2.Name = "panel2";
         this.panel2.Size = new System.Drawing.Size(488, 74);
         this.panel2.TabIndex = 3;
         // 
         // checkBoxOverwrite
         // 
         this.checkBoxOverwrite.AutoSize = true;
         this.checkBoxOverwrite.Location = new System.Drawing.Point(10, 46);
         this.checkBoxOverwrite.Name = "checkBoxOverwrite";
         this.checkBoxOverwrite.Size = new System.Drawing.Size(120, 17);
         this.checkBoxOverwrite.TabIndex = 1;
         this.checkBoxOverwrite.Text = "Overwrite Database";
         this.checkBoxOverwrite.UseVisualStyleBackColor = true;
         // 
         // serverDatabaseComboBox
         // 
         this.serverDatabaseComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.serverDatabaseComboBox.FormattingEnabled = true;
         this.serverDatabaseComboBox.Location = new System.Drawing.Point(10, 20);
         this.serverDatabaseComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.serverDatabaseComboBox.Name = "serverDatabaseComboBox";
         this.serverDatabaseComboBox.Size = new System.Drawing.Size(388, 21);
         this.serverDatabaseComboBox.TabIndex = 0;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(8, 3);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(164, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "&Select or enter a &database name:";
         // 
         // SqlServerConfigurationControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.panel2);
         this.Controls.Add(this.panel1);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "SqlServerConfigurationControl";
         this.Size = new System.Drawing.Size(488, 329);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.userInfoPanel.ResumeLayout(false);
         this.userInfoPanel.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         this.panel2.ResumeLayout(false);
         this.panel2.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.RadioButton sqlAuthenticationRadioButton;
      private System.Windows.Forms.RadioButton windowsAuthenticationRadioButton;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Panel userInfoPanel;
      private System.Windows.Forms.TextBox passwordTextBox;
      private System.Windows.Forms.TextBox userNameTextBox;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Panel panel2;
      private System.Windows.Forms.ComboBox serverDatabaseComboBox;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button refreshServersButton;
      private System.Windows.Forms.ComboBox serverNameCoboBox;
      private System.Windows.Forms.CheckBox checkBoxOverwrite;
      private System.Windows.Forms.Label labelSqlNote;
   }
}
