namespace OcrMultiThreadingDemo
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
         this._msMain = new System.Windows.Forms.MenuStrip();
         this._miFile = new System.Windows.Forms.ToolStripMenuItem();
         this._miFileExit = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelp = new System.Windows.Forms.ToolStripMenuItem();
         this._miHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
         this._gatherInformationControl = new OcrMultiThreadingDemo.GatherInformationControl();
         this._conversionControl = new OcrMultiThreadingDemo.ConversionControl();
         this._msMain.SuspendLayout();
         this.SuspendLayout();
         // 
         // _msMain
         // 
         this._msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miFile,
            this._miHelp});
         this._msMain.Location = new System.Drawing.Point(0, 0);
         this._msMain.Name = "_msMain";
         this._msMain.Size = new System.Drawing.Size(934, 24);
         this._msMain.TabIndex = 0;
         this._msMain.Text = "_msMain";
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
         // _gatherInformationControl
         // 
         this._gatherInformationControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this._gatherInformationControl.Location = new System.Drawing.Point(0, 24);
         this._gatherInformationControl.Name = "_gatherInformationControl";
         this._gatherInformationControl.Size = new System.Drawing.Size(934, 424);
         this._gatherInformationControl.TabIndex = 1;
         this._gatherInformationControl.StartConversion += new System.EventHandler<OcrMultiThreadingDemo.StartConversionEventArgs>(this._gatherInformationControl_StartConversion);
         // 
         // _conversionControl
         // 
         this._conversionControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this._conversionControl.Location = new System.Drawing.Point(0, 24);
         this._conversionControl.Name = "_conversionControl";
         this._conversionControl.Size = new System.Drawing.Size(934, 424);
         this._conversionControl.TabIndex = 2;
         this._conversionControl.ConversionFinished += new System.EventHandler(this._conversionControl_ConversionFinished);
         this._conversionControl.ConvertMoreFiles += new System.EventHandler(this._conversionControl_ConvertMoreFiles);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(934, 448);
         this.Controls.Add(this._conversionControl);
         this.Controls.Add(this._gatherInformationControl);
         this.Controls.Add(this._msMain);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MainMenuStrip = this._msMain;
         this.Name = "MainForm";
         this.Text = "MainForm";
         this._msMain.ResumeLayout(false);
         this._msMain.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.MenuStrip _msMain;
      private System.Windows.Forms.ToolStripMenuItem _miFile;
      private System.Windows.Forms.ToolStripMenuItem _miFileExit;
      private System.Windows.Forms.ToolStripMenuItem _miHelp;
      private System.Windows.Forms.ToolStripMenuItem _miHelpAbout;
      private GatherInformationControl _gatherInformationControl;
      private ConversionControl _conversionControl;
   }
}

