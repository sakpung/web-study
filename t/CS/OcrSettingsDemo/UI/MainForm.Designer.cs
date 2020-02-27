using Leadtools.Demos;

namespace OcrSettingsDemo
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
         if(disposing && (components != null))
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
         this._miFile = new System.Windows.Forms.ToolStripMenuItem();
         this._miFileExit = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._gbSettings = new System.Windows.Forms.GroupBox();
         this._lblMessage1 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._lblMessage2 = new System.Windows.Forms.Label();
         this._ocrEngineSettings = new Leadtools.Demos.OcrEngineSettingsControl();
         this.menuStrip1.SuspendLayout();
         this._gbSettings.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFile,
            this._miHelp});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(613, 24);
         this.menuStrip1.TabIndex = 0;
         this.menuStrip1.Text = "_msMain";
         // 
         // _miFile
         // 
         this._miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFileExit});
         this._miFile.Name = "_miFile";
         this._miFile.Size = new System.Drawing.Size(37, 20);
         this._miFile.Text = "&File";
         // 
         // _miFileExit
         // 
         this._miFileExit.Name = "_miFileExit";
         this._miFileExit.Size = new System.Drawing.Size(92, 22);
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // _miHelp
         // 
         this._miHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miHelpAbout});
         this._miHelp.Name = "_miHelp";
         this._miHelp.Size = new System.Drawing.Size(44, 20);
         this._miHelp.Text = "&Help";
         // 
         // _miHelpAbout
         // 
         this._miHelpAbout.Name = "_miHelpAbout";
         this._miHelpAbout.Size = new System.Drawing.Size(116, 22);
         this._miHelpAbout.Text = "&About...";
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         // 
         // _gbSettings
         // 
         this._gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._gbSettings.Controls.Add(this._ocrEngineSettings);
         this._gbSettings.Location = new System.Drawing.Point(15, 80);
         this._gbSettings.Name = "_gbSettings";
         this._gbSettings.Size = new System.Drawing.Size(586, 297);
         this._gbSettings.TabIndex = 5;
         this._gbSettings.TabStop = false;
         this._gbSettings.Text = "Engine Settings:";
         // 
         // _lblMessage1
         // 
         this._lblMessage1.AutoSize = true;
         this._lblMessage1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this._lblMessage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._lblMessage1.ForeColor = System.Drawing.Color.Blue;
         this._lblMessage1.Location = new System.Drawing.Point(48, 37);
         this._lblMessage1.Margin = new System.Windows.Forms.Padding(0);
         this._lblMessage1.Name = "_lblMessage1";
         this._lblMessage1.Size = new System.Drawing.Size(549, 13);
         this._lblMessage1.TabIndex = 6;
         this._lblMessage1.Text = "This demo shows how to browse, read and write the values of the specific settings" +
    " for a LEADTOOLS OCR engine.";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label1.ForeColor = System.Drawing.Color.Blue;
         this.label1.Location = new System.Drawing.Point(12, 37);
         this.label1.Margin = new System.Windows.Forms.Padding(0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(38, 13);
         this.label1.TabIndex = 7;
         this.label1.Text = "Note:";
         // 
         // _lblMessage2
         // 
         this._lblMessage2.AutoSize = true;
         this._lblMessage2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this._lblMessage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._lblMessage2.ForeColor = System.Drawing.Color.Blue;
         this._lblMessage2.Location = new System.Drawing.Point(48, 54);
         this._lblMessage2.Margin = new System.Windows.Forms.Padding(0);
         this._lblMessage2.Name = "_lblMessage2";
         this._lblMessage2.Size = new System.Drawing.Size(529, 13);
         this._lblMessage2.TabIndex = 8;
         this._lblMessage2.Text = "To see how these setting effects the OCR engine, run the OcrMainDemo and click th" +
    "e Engine->Settings menu.";
         // 
         // _ocrEngineSettings
         // 
         this._ocrEngineSettings.Location = new System.Drawing.Point(37, 19);
         this._ocrEngineSettings.Name = "_ocrEngineSettings";
         this._ocrEngineSettings.Size = new System.Drawing.Size(510, 266);
         this._ocrEngineSettings.TabIndex = 0;
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(613, 389);
         this.Controls.Add(this._lblMessage2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._lblMessage1);
         this.Controls.Add(this._gbSettings);
         this.Controls.Add(this.menuStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this._gbSettings.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem _miFile;
      private System.Windows.Forms.ToolStripMenuItem _miFileExit;
      private System.Windows.Forms.ToolStripMenuItem _miHelp;
      private System.Windows.Forms.ToolStripMenuItem _miHelpAbout;
      private System.Windows.Forms.GroupBox _gbSettings;
      private System.Windows.Forms.Label _lblMessage1;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label _lblMessage2;
      private OcrEngineSettingsControl _ocrEngineSettings;
   }
}

