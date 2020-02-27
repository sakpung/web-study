namespace HL7Messaging
{
   partial class MainView
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
         this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.addMWLItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.updatePatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.sendMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.comboBox1 = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
         this.menuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // openFileDialog1
         // 
         this.openFileDialog1.Filter = "HL7 files|*.hl7|Text files|*.txt|All files (*.*)|*.*";
         this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(818, 24);
         this.menuStrip1.TabIndex = 4;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
         this.fileToolStripMenuItem.Text = "&File";
         // 
         // newToolStripMenuItem
         // 
         this.newToolStripMenuItem.Name = "newToolStripMenuItem";
         this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.newToolStripMenuItem.Text = "&New...";
         this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
         // 
         // loadToolStripMenuItem
         // 
         this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
         this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.loadToolStripMenuItem.Text = "&Load...";
         this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
         // 
         // saveToolStripMenuItem
         // 
         this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
         this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
         this.saveToolStripMenuItem.Text = "&Save...";
         this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
         // 
         // toolsToolStripMenuItem
         // 
         this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMWLItemToolStripMenuItem,
            this.updatePatientToolStripMenuItem,
            this.sendMessageToolStripMenuItem});
         this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
         this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
         this.toolsToolStripMenuItem.Text = "&Tools";
         // 
         // addMWLItemToolStripMenuItem
         // 
         this.addMWLItemToolStripMenuItem.Name = "addMWLItemToolStripMenuItem";
         this.addMWLItemToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
         this.addMWLItemToolStripMenuItem.Text = "Add M&WL Item";
         this.addMWLItemToolStripMenuItem.Click += new System.EventHandler(this.addMWLItemToolStripMenuItem_Click);
         // 
         // updatePatientToolStripMenuItem
         // 
         this.updatePatientToolStripMenuItem.Name = "updatePatientToolStripMenuItem";
         this.updatePatientToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
         this.updatePatientToolStripMenuItem.Text = "&Update Patient";
         this.updatePatientToolStripMenuItem.Click += new System.EventHandler(this.updatePatientToolStripMenuItem_Click);
         // 
         // sendMessageToolStripMenuItem
         // 
         this.sendMessageToolStripMenuItem.Name = "sendMessageToolStripMenuItem";
         this.sendMessageToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
         this.sendMessageToolStripMenuItem.Text = "&Send Message";
         this.sendMessageToolStripMenuItem.Click += new System.EventHandler(this.sendMessageToolStripMenuItem_Click);
         // 
         // comboBox1
         // 
         this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox1.FormattingEnabled = true;
         this.comboBox1.Items.AddRange(new object[] {
            "Contents",
            "Contents + Empty Fields",
            "Schema",
            "All"});
         this.comboBox1.Location = new System.Drawing.Point(56, 42);
         this.comboBox1.Name = "comboBox1";
         this.comboBox1.Size = new System.Drawing.Size(151, 21);
         this.comboBox1.TabIndex = 7;
         this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 45);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(37, 13);
         this.label2.TabIndex = 6;
         this.label2.Text = "Show:";
         // 
         // propertyGrid1
         // 
         this.propertyGrid1.Location = new System.Drawing.Point(13, 72);
         this.propertyGrid1.Name = "propertyGrid1";
         this.propertyGrid1.Size = new System.Drawing.Size(792, 594);
         this.propertyGrid1.TabIndex = 9;
         // 
         // textBox1
         // 
         this.textBox1.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.textBox1.Location = new System.Drawing.Point(13, 676);
         this.textBox1.Multiline = true;
         this.textBox1.Name = "textBox1";
         this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
         this.textBox1.Size = new System.Drawing.Size(792, 158);
         this.textBox1.TabIndex = 10;
         this.textBox1.WordWrap = false;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(13, 841);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(72, 23);
         this.button1.TabIndex = 11;
         this.button1.Text = "&Parse";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // saveFileDialog1
         // 
         this.saveFileDialog1.DefaultExt = "hl7";
         this.saveFileDialog1.Filter = "HL7 files|*.hl7|Text files|*.txt";
         // 
         // MainView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(818, 871);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.propertyGrid1);
         this.Controls.Add(this.comboBox1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.menuStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "MainView";
         this.Text = "HL7 Messaging";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainView_FormClosing);
         this.Load += new System.EventHandler(this.MainView_Load);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
      private System.Windows.Forms.ComboBox comboBox1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.PropertyGrid propertyGrid1;
      private System.Windows.Forms.TextBox textBox1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem addMWLItemToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem updatePatientToolStripMenuItem;
      private System.Windows.Forms.SaveFileDialog saveFileDialog1;
      private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem sendMessageToolStripMenuItem;
   }
}

