namespace AAMVAWriteDemo
{
   partial class WriteBarcodeForm
   {

      private System.Windows.Forms.MainMenu _mmMain;
      private System.Windows.Forms.MenuItem _miFile;
      private System.Windows.Forms.MenuItem _miFileOpen;
      private System.Windows.Forms.MenuItem _miFileExit;
      private System.Windows.Forms.MenuItem _miFileSep1;
      private System.Windows.Forms.MenuItem _miFileSave;

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
         this.components = new System.ComponentModel.Container();
         this._mmMain = new System.Windows.Forms.MainMenu(this.components);
         this._miFile = new System.Windows.Forms.MenuItem();
         this._miFileOpen = new System.Windows.Forms.MenuItem();
         this._miFileSave = new System.Windows.Forms.MenuItem();
         this._miFileSep1 = new System.Windows.Forms.MenuItem();
         this._miFileExit = new System.Windows.Forms.MenuItem();
         this.menuItem1 = new System.Windows.Forms.MenuItem();
         this._miWriteOptions = new System.Windows.Forms.MenuItem();
         this.SuspendLayout();
         // 
         // _mmMain
         // 
         this._mmMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFile,
            this.menuItem1});
         // 
         // _miFile
         // 
         this._miFile.Index = 0;
         this._miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miFileOpen,
            this._miFileSave,
            this._miFileSep1,
            this._miFileExit});
         this._miFile.Text = "&File";
         // 
         // _miFileOpen
         // 
         this._miFileOpen.Index = 0;
         this._miFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
         this._miFileOpen.Text = "&Open...";
         this._miFileOpen.Click += new System.EventHandler(this._miFileOpen_Click);
         // 
         // _miFileSave
         // 
         this._miFileSave.Index = 1;
         this._miFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
         this._miFileSave.Text = "&Save...";
         this._miFileSave.Click += new System.EventHandler(this._miFileSave_Click);
         // 
         // _miFileSep1
         // 
         this._miFileSep1.Index = 2;
         this._miFileSep1.Text = "-";
         // 
         // _miFileExit
         // 
         this._miFileExit.Index = 3;
         this._miFileExit.Text = "E&xit";
         this._miFileExit.Click += new System.EventHandler(this._miFileExit_Click);
         // 
         // menuItem1
         // 
         this.menuItem1.Index = 1;
         this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this._miWriteOptions});
         this.menuItem1.Text = "Options";
         // 
         // _miWriteOptions
         // 
         this._miWriteOptions.Index = 0;
         this._miWriteOptions.Text = "Write Options...";
         this._miWriteOptions.Click += new System.EventHandler(this._miWriteOptions_Click);
         // 
         // WriteBarcodeForm
         // 
         this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
         this.ClientSize = new System.Drawing.Size(1084, 740);
         this.Menu = this._mmMain;
         this.Name = "WriteBarcodeForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Text = "Write AAMVA Barcode - Double Click to Write Barcode to Image";
         this.Load += new System.EventHandler(this.WriteBarcodeForm_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.MenuItem menuItem1;
      private System.Windows.Forms.MenuItem _miWriteOptions;
   }
}