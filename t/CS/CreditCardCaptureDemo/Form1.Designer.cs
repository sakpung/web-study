namespace CreditCardCapture
{
   partial class Form1
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this._components = new System.ComponentModel.Container();
         this._statusStrip = new System.Windows.Forms.StatusStrip();
         this._toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
         this._statusStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // _statusStrip
         // 
         this._statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripStatusLabel});
         this._statusStrip.Location = new System.Drawing.Point(0, 435);
         this._statusStrip.Name = "_statusStrip";
         this._statusStrip.Size = new System.Drawing.Size(657, 22);
         this._statusStrip.TabIndex = 0;
         this._statusStrip.Text = "statusStrip1";
         this._statusStrip.SizingGrip = false;
         // 
         // _toolStripStatusLabel
         // 
         this._toolStripStatusLabel.Name = "_toolStripStatusLabel";
         this._toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
         // 
         // _mainMenu
         // 
         this._mainMenu = new System.Windows.Forms.MainMenu(this._components);
         this._fileMenu = new System.Windows.Forms.MenuItem("File");
         this._fileExit = new System.Windows.Forms.MenuItem("&Exit");
         this._fileExit.Click += FileExit_Click;
         this._fileMenu.MenuItems.Add(this._fileExit);
         this._optionsMenu = new System.Windows.Forms.MenuItem("&Options");
         this._optionsMenuVideoDevice = new System.Windows.Forms.MenuItem("Video &Devices");
         this._optionsMenu.MenuItems.Add(this._optionsMenuVideoDevice);
         this._optionsMenu.MenuItems.Add("-");
         this._captureOptions = new System.Windows.Forms.MenuItem("&Capture Options");
         this._captureOptions.Enabled = false;
         this._captureOptions.Click += CaptureOptions_Click;
         this._optionsMenu.MenuItems.Add(this._captureOptions);
         this._miHelp = new System.Windows.Forms.MenuItem();
         this._miHelp.Text = "Help";
         this._miHelpAbout = new System.Windows.Forms.MenuItem();
         this._miHelpAbout.Text = "About...";
         this._miHelp.MenuItems.Add(this._miHelpAbout);
         this._miHelpAbout.Click += new System.EventHandler(this._miHelpAbout_Click);
         this._optionsMenuVideoDeviceNone = new System.Windows.Forms.MenuItem("None");
         this._optionsMenuVideoDeviceNone.Checked = true;
         this._optionsMenuVideoDevice.MenuItems.Add(this._optionsMenuVideoDeviceNone);
         this._optionsMenuVideoDeviceNone.Click += new System.EventHandler(VideoDevice_Click);
         this._mainMenu.MenuItems.Add(this._fileMenu);
         this._mainMenu.MenuItems.Add(this._optionsMenu);
         this._mainMenu.MenuItems.Add(this._miHelp);
         // 
         // Form1
         // 
         this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint | System.Windows.Forms.ControlStyles.UserPaint | System.Windows.Forms.ControlStyles.ResizeRedraw | System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MinimizeBox = false;
         this.MaximizeBox = false;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(657, 457);
         this.Controls.Add(this._statusStrip);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Menu = this._mainMenu;
         this.Name = "MainForm";
         this.Text = "C# Credit Card Capture Demo";
         this.Paint += new System.Windows.Forms.PaintEventHandler(Form1_Paint);
         this.FormClosing += Form1_FormClosing;
         this._statusStrip.ResumeLayout(false);
         this._statusStrip.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();
      }

      #endregion

      private System.Windows.Forms.StatusStrip _statusStrip;
      private System.Windows.Forms.ToolStripStatusLabel _toolStripStatusLabel;
      private System.ComponentModel.Container _components;
      private System.Windows.Forms.MainMenu _mainMenu;
      private System.Windows.Forms.MenuItem _fileMenu;
      private System.Windows.Forms.MenuItem _fileExit;
      private System.Windows.Forms.MenuItem _optionsMenu;
      private System.Windows.Forms.MenuItem _optionsMenuVideoDevice;
      private System.Windows.Forms.MenuItem _optionsMenuVideoDeviceNone;
      private System.Windows.Forms.MenuItem _miHelp;
      private System.Windows.Forms.MenuItem _miHelpAbout;
      private System.Windows.Forms.MenuItem _captureOptions;
   }
}

