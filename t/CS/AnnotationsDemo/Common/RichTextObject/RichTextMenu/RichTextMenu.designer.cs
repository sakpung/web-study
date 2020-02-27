namespace Leadtools.Annotations
{
   partial class RichTextMenu
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RichTextMenu));
         this._tbRtf = new Leadtools.Annotations.ToolStripEx();
         this._cmbFont = new System.Windows.Forms.ToolStripComboBox();
         this._cmbFontSize = new System.Windows.Forms.ToolStripComboBox();
         this._btnBold = new System.Windows.Forms.ToolStripButton();
         this._btnItalic = new System.Windows.Forms.ToolStripButton();
         this._btnUnderline = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._btnTextColor = new System.Windows.Forms.ToolStripSplitButton();
         this._btnBackgroundColor = new System.Windows.Forms.ToolStripSplitButton();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._btnBullets = new System.Windows.Forms.ToolStripButton();
         this._btnNumbers = new System.Windows.Forms.ToolStripButton();
         this._btnIncreaseIdent = new System.Windows.Forms.ToolStripButton();
         this._btnDecreaseIdent = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this._btnLeft = new System.Windows.Forms.ToolStripButton();
         this._btnCenter = new System.Windows.Forms.ToolStripButton();
         this._btnRight = new System.Windows.Forms.ToolStripButton();
         this._miRtf = new System.Windows.Forms.MenuStrip();
         this._miRtfFile = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFileOpen = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFileSave = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFilePrint = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFileExit = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfEdit = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfEditUndo = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfEditSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._miRtfEditCut = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfEditCopy = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfEditPaste = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfEditDelete = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFormat = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFormatFont = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFormatSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._miRtfFormatBackgroundColor = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFormatTextColor = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFormatSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._miRtfFormatBullets = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFormatNumbering = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFormatSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._miRtfFormatDecreaseIndent = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFormatIncreaseIndent = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFormatSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this._miRtfFormatLeft = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFormatCenter = new System.Windows.Forms.ToolStripMenuItem();
         this._miRtfFormatRight = new System.Windows.Forms.ToolStripMenuItem();
         this._tbRtf.SuspendLayout();
         this._miRtf.SuspendLayout();
         this.SuspendLayout();
         // 
         // _tbRtf
         // 
         this._tbRtf.ClickThrough = true;
         this._tbRtf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._cmbFont,
            this._cmbFontSize,
            this._btnBold,
            this._btnItalic,
            this._btnUnderline,
            this.toolStripSeparator2,
            this._btnTextColor,
            this._btnBackgroundColor,
            this.toolStripSeparator3,
            this._btnBullets,
            this._btnNumbers,
            this._btnIncreaseIdent,
            this._btnDecreaseIdent,
            this.toolStripSeparator4,
            this._btnLeft,
            this._btnCenter,
            this._btnRight});
         this._tbRtf.Location = new System.Drawing.Point(0, 24);
         this._tbRtf.Name = "_tbRtf";
         this._tbRtf.Size = new System.Drawing.Size(608, 25);
         this._tbRtf.TabIndex = 0;
         this._tbRtf.Text = "_tbRtf";
         // 
         // _cmbFont
         // 
         this._cmbFont.Name = "_cmbFont";
         this._cmbFont.Size = new System.Drawing.Size(200, 25);
         this._cmbFont.SelectedIndexChanged += new System.EventHandler(this._cmbFont_SelectedIndexChanged);
         // 
         // _cmbFontSize
         // 
         this._cmbFontSize.Name = "_cmbFontSize";
         this._cmbFontSize.Size = new System.Drawing.Size(75, 25);
         this._cmbFontSize.SelectedIndexChanged += new System.EventHandler(this._cmbFontSize_SelectedIndexChanged);
         // 
         // _btnBold
         // 
         this._btnBold.CheckOnClick = true;
         this._btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnBold.Image = ((System.Drawing.Image)(resources.GetObject("_btnBold.Image")));
         this._btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnBold.Name = "_btnBold";
         this._btnBold.Size = new System.Drawing.Size(23, 22);
         this._btnBold.Text = "toolStripButton5";
         this._btnBold.Click += new System.EventHandler(this._btnBold_Click);
         // 
         // _btnItalic
         // 
         this._btnItalic.CheckOnClick = true;
         this._btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnItalic.Image = ((System.Drawing.Image)(resources.GetObject("_btnItalic.Image")));
         this._btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnItalic.Name = "_btnItalic";
         this._btnItalic.Size = new System.Drawing.Size(23, 22);
         this._btnItalic.Text = "toolStripButton6";
         this._btnItalic.Click += new System.EventHandler(this._btnItalic_Click);
         // 
         // _btnUnderline
         // 
         this._btnUnderline.CheckOnClick = true;
         this._btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("_btnUnderline.Image")));
         this._btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnUnderline.Name = "_btnUnderline";
         this._btnUnderline.Size = new System.Drawing.Size(23, 22);
         this._btnUnderline.Text = "toolStripButton4";
         this._btnUnderline.Click += new System.EventHandler(this._btnUnderline_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
         // 
         // _btnTextColor
         // 
         this._btnTextColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnTextColor.Image = ((System.Drawing.Image)(resources.GetObject("_btnTextColor.Image")));
         this._btnTextColor.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnTextColor.Name = "_btnTextColor";
         this._btnTextColor.Size = new System.Drawing.Size(32, 22);
         this._btnTextColor.Text = "toolStripSplitButton1";
         this._btnTextColor.DropDownOpening += new System.EventHandler(this._btnTextColor_DropDownOpening);
         // 
         // _btnBackgroundColor
         // 
         this._btnBackgroundColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnBackgroundColor.Image = ((System.Drawing.Image)(resources.GetObject("_btnBackgroundColor.Image")));
         this._btnBackgroundColor.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnBackgroundColor.Name = "_btnBackgroundColor";
         this._btnBackgroundColor.Size = new System.Drawing.Size(32, 22);
         this._btnBackgroundColor.Text = "toolStripSplitButton2";
         this._btnBackgroundColor.DropDownOpening += new System.EventHandler(this._btnBackgroundColor_DropDownOpening);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
         // 
         // _btnBullets
         // 
         this._btnBullets.CheckOnClick = true;
         this._btnBullets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnBullets.Image = ((System.Drawing.Image)(resources.GetObject("_btnBullets.Image")));
         this._btnBullets.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnBullets.Name = "_btnBullets";
         this._btnBullets.Size = new System.Drawing.Size(23, 22);
         this._btnBullets.Text = "toolStripButton7";
         this._btnBullets.Click += new System.EventHandler(this._btnBullets_Click);
         // 
         // _btnNumbers
         // 
         this._btnNumbers.CheckOnClick = true;
         this._btnNumbers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnNumbers.Image = ((System.Drawing.Image)(resources.GetObject("_btnNumbers.Image")));
         this._btnNumbers.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnNumbers.Name = "_btnNumbers";
         this._btnNumbers.Size = new System.Drawing.Size(23, 22);
         this._btnNumbers.Text = "toolStripButton8";
         this._btnNumbers.Click += new System.EventHandler(this._btnNumbers_Click);
         // 
         // _btnIncreaseIdent
         // 
         this._btnIncreaseIdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnIncreaseIdent.Image = ((System.Drawing.Image)(resources.GetObject("_btnIncreaseIdent.Image")));
         this._btnIncreaseIdent.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnIncreaseIdent.Name = "_btnIncreaseIdent";
         this._btnIncreaseIdent.Size = new System.Drawing.Size(23, 22);
         this._btnIncreaseIdent.Text = "toolStripButton9";
         this._btnIncreaseIdent.Click += new System.EventHandler(this._btnIncreaseIdent_Click);
         // 
         // _btnDecreaseIdent
         // 
         this._btnDecreaseIdent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnDecreaseIdent.Image = ((System.Drawing.Image)(resources.GetObject("_btnDecreaseIdent.Image")));
         this._btnDecreaseIdent.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnDecreaseIdent.Name = "_btnDecreaseIdent";
         this._btnDecreaseIdent.Size = new System.Drawing.Size(23, 22);
         this._btnDecreaseIdent.Text = "toolStripButton10";
         this._btnDecreaseIdent.Click += new System.EventHandler(this._btnDecreaseIdent_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
         // 
         // _btnLeft
         // 
         this._btnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("_btnLeft.Image")));
         this._btnLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnLeft.Name = "_btnLeft";
         this._btnLeft.Size = new System.Drawing.Size(23, 22);
         this._btnLeft.Text = "toolStripButton1";
         this._btnLeft.Click += new System.EventHandler(this._btnLeft_Click);
         // 
         // _btnCenter
         // 
         this._btnCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnCenter.Image = ((System.Drawing.Image)(resources.GetObject("_btnCenter.Image")));
         this._btnCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnCenter.Name = "_btnCenter";
         this._btnCenter.Size = new System.Drawing.Size(23, 22);
         this._btnCenter.Text = "toolStripButton1";
         this._btnCenter.Click += new System.EventHandler(this._btnCenter_Click);
         // 
         // _btnRight
         // 
         this._btnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this._btnRight.Image = ((System.Drawing.Image)(resources.GetObject("_btnRight.Image")));
         this._btnRight.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._btnRight.Name = "_btnRight";
         this._btnRight.Size = new System.Drawing.Size(23, 22);
         this._btnRight.Text = "toolStripButton1";
         this._btnRight.Click += new System.EventHandler(this._btnRight_Click);
         // 
         // _miRtf
         // 
         this._miRtf.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRtfFile,
            this._miRtfEdit,
            this._miRtfFormat});
         this._miRtf.Location = new System.Drawing.Point(0, 0);
         this._miRtf.Name = "_miRtf";
         this._miRtf.Size = new System.Drawing.Size(608, 24);
         this._miRtf.TabIndex = 1;
         this._miRtf.Text = "menuStrip1";
         // 
         // _miRtfFile
         // 
         this._miRtfFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRtfFileOpen,
            this._miRtfFileSave,
            this._miRtfFilePrint,
            this._miRtfFileExit});
         this._miRtfFile.Name = "_miRtfFile";
         this._miRtfFile.Size = new System.Drawing.Size(37, 20);
         this._miRtfFile.Text = "&File";
         // 
         // _miRtfFileOpen
         // 
         this._miRtfFileOpen.Name = "_miRtfFileOpen";
         this._miRtfFileOpen.Size = new System.Drawing.Size(124, 22);
         this._miRtfFileOpen.Text = "&Open";
         this._miRtfFileOpen.Click += new System.EventHandler(this._miRtfFileOpen_Click);
         // 
         // _miRtfFileSave
         // 
         this._miRtfFileSave.Name = "_miRtfFileSave";
         this._miRtfFileSave.Size = new System.Drawing.Size(124, 22);
         this._miRtfFileSave.Text = "&Save as ...";
         this._miRtfFileSave.Click += new System.EventHandler(this._miRtfFileSave_Click);
         // 
         // _miRtfFilePrint
         // 
         this._miRtfFilePrint.Name = "_miRtfFilePrint";
         this._miRtfFilePrint.Size = new System.Drawing.Size(124, 22);
         this._miRtfFilePrint.Text = "&Print...";
         this._miRtfFilePrint.Click += new System.EventHandler(this._miRtfFilePrint_Click);
         // 
         // _miRtfFileExit
         // 
         this._miRtfFileExit.Name = "_miRtfFileExit";
         this._miRtfFileExit.Size = new System.Drawing.Size(124, 22);
         this._miRtfFileExit.Text = "E&xit";
         this._miRtfFileExit.Click += new System.EventHandler(this._miRtfFileExit_Click);
         // 
         // _miRtfEdit
         // 
         this._miRtfEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRtfEditUndo,
            this._miRtfEditSeparator1,
            this._miRtfEditCut,
            this._miRtfEditCopy,
            this._miRtfEditPaste,
            this._miRtfEditDelete,
            this._miRtfEditSelectAll});
         this._miRtfEdit.Name = "_miRtfEdit";
         this._miRtfEdit.Size = new System.Drawing.Size(39, 20);
         this._miRtfEdit.Text = "&Edit";
         this._miRtfEdit.Click += new System.EventHandler(this._miRtfEdit_Click);
         // 
         // _miRtfEditUndo
         // 
         this._miRtfEditUndo.Name = "_miRtfEditUndo";
         this._miRtfEditUndo.Size = new System.Drawing.Size(152, 22);
         this._miRtfEditUndo.Text = "&Undo";
         this._miRtfEditUndo.Click += new System.EventHandler(this._miRtfEditUndo_Click);
         // 
         // _miRtfEditSeparator1
         // 
         this._miRtfEditSeparator1.Name = "_miRtfEditSeparator1";
         this._miRtfEditSeparator1.Size = new System.Drawing.Size(149, 6);
         // 
         // _miRtfEditCut
         // 
         this._miRtfEditCut.Name = "_miRtfEditCut";
         this._miRtfEditCut.Size = new System.Drawing.Size(152, 22);
         this._miRtfEditCut.Text = "Cu&t";
         this._miRtfEditCut.Click += new System.EventHandler(this._miRtfEditCut_Click);
         // 
         // _miRtfEditCopy
         // 
         this._miRtfEditCopy.Name = "_miRtfEditCopy";
         this._miRtfEditCopy.Size = new System.Drawing.Size(152, 22);
         this._miRtfEditCopy.Text = "&Copy";
         this._miRtfEditCopy.Click += new System.EventHandler(this._miRtfEditCopy_Click);
         // 
         // _miRtfEditPaste
         // 
         this._miRtfEditPaste.Name = "_miRtfEditPaste";
         this._miRtfEditPaste.Size = new System.Drawing.Size(152, 22);
         this._miRtfEditPaste.Text = "&Paste";
         this._miRtfEditPaste.Click += new System.EventHandler(this._miRtfEditPaste_Click);
         // 
         // _miRtfEditDelete
         // 
         this._miRtfEditDelete.Name = "_miRtfEditDelete";
         this._miRtfEditDelete.Size = new System.Drawing.Size(152, 22);
         this._miRtfEditDelete.Text = "&Delete";
         this._miRtfEditDelete.Click += new System.EventHandler(this._miRtfEditDelete_Click);
         // 
         // _miRtfEditSelectAll
         // 
         this._miRtfEditSelectAll.Name = "_miRtfEditSelectAll";
         this._miRtfEditSelectAll.Size = new System.Drawing.Size(152, 22);
         this._miRtfEditSelectAll.Text = "Select &All";
         this._miRtfEditSelectAll.Click += new System.EventHandler(this._miRtfEditSelectAll_Click);
         // 
         // _miRtfFormat
         // 
         this._miRtfFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miRtfFormatFont,
            this._miRtfFormatSeparator1,
            this._miRtfFormatBackgroundColor,
            this._miRtfFormatTextColor,
            this._miRtfFormatSeparator2,
            this._miRtfFormatBullets,
            this._miRtfFormatNumbering,
            this._miRtfFormatSeparator3,
            this._miRtfFormatDecreaseIndent,
            this._miRtfFormatIncreaseIndent,
            this._miRtfFormatSeparator4,
            this._miRtfFormatLeft,
            this._miRtfFormatCenter,
            this._miRtfFormatRight});
         this._miRtfFormat.Name = "_miRtfFormat";
         this._miRtfFormat.Size = new System.Drawing.Size(57, 20);
         this._miRtfFormat.Text = "F&ormat";
         // 
         // _miRtfFormatFont
         // 
         this._miRtfFormatFont.Name = "_miRtfFormatFont";
         this._miRtfFormatFont.Size = new System.Drawing.Size(170, 22);
         this._miRtfFormatFont.Text = "&Font...";
         this._miRtfFormatFont.Click += new System.EventHandler(this._miRtfFormatFont_Click);
         // 
         // _miRtfFormatSeparator1
         // 
         this._miRtfFormatSeparator1.Name = "_miRtfFormatSeparator1";
         this._miRtfFormatSeparator1.Size = new System.Drawing.Size(167, 6);
         // 
         // _miRtfFormatBackgroundColor
         // 
         this._miRtfFormatBackgroundColor.Name = "_miRtfFormatBackgroundColor";
         this._miRtfFormatBackgroundColor.Size = new System.Drawing.Size(170, 22);
         this._miRtfFormatBackgroundColor.Text = "&Background Color";
         this._miRtfFormatBackgroundColor.DropDownOpening += new System.EventHandler(this._miRtfFormatBackgroundColor_DropDownOpening);
         // 
         // _miRtfFormatTextColor
         // 
         this._miRtfFormatTextColor.Name = "_miRtfFormatTextColor";
         this._miRtfFormatTextColor.Size = new System.Drawing.Size(170, 22);
         this._miRtfFormatTextColor.Text = "&Text Color";
         this._miRtfFormatTextColor.DropDownOpening += new System.EventHandler(this._miRtfFormatTextColor_DropDownOpening);
         // 
         // _miRtfFormatSeparator2
         // 
         this._miRtfFormatSeparator2.Name = "_miRtfFormatSeparator2";
         this._miRtfFormatSeparator2.Size = new System.Drawing.Size(167, 6);
         // 
         // _miRtfFormatBullets
         // 
         this._miRtfFormatBullets.Name = "_miRtfFormatBullets";
         this._miRtfFormatBullets.Size = new System.Drawing.Size(170, 22);
         this._miRtfFormatBullets.Text = "Bullet&s";
         this._miRtfFormatBullets.Click += new System.EventHandler(this._miRtfFormatBullets_Click);
         // 
         // _miRtfFormatNumbering
         // 
         this._miRtfFormatNumbering.Name = "_miRtfFormatNumbering";
         this._miRtfFormatNumbering.Size = new System.Drawing.Size(170, 22);
         this._miRtfFormatNumbering.Text = "&Numbering";
         this._miRtfFormatNumbering.Click += new System.EventHandler(this._miRtfFormatNumbering_Click);
         // 
         // _miRtfFormatSeparator3
         // 
         this._miRtfFormatSeparator3.Name = "_miRtfFormatSeparator3";
         this._miRtfFormatSeparator3.Size = new System.Drawing.Size(167, 6);
         // 
         // _miRtfFormatDecreaseIndent
         // 
         this._miRtfFormatDecreaseIndent.Name = "_miRtfFormatDecreaseIndent";
         this._miRtfFormatDecreaseIndent.Size = new System.Drawing.Size(170, 22);
         this._miRtfFormatDecreaseIndent.Text = "&Decrease Indent";
         this._miRtfFormatDecreaseIndent.Click += new System.EventHandler(this._miRtfFormatDecreaseIndent_Click);
         // 
         // _miRtfFormatIncreaseIndent
         // 
         this._miRtfFormatIncreaseIndent.Name = "_miRtfFormatIncreaseIndent";
         this._miRtfFormatIncreaseIndent.Size = new System.Drawing.Size(170, 22);
         this._miRtfFormatIncreaseIndent.Text = "&Increase Indent";
         this._miRtfFormatIncreaseIndent.Click += new System.EventHandler(this._miRtfFormatIncreaseIndent_Click);
         // 
         // _miRtfFormatSeparator4
         // 
         this._miRtfFormatSeparator4.Name = "_miRtfFormatSeparator4";
         this._miRtfFormatSeparator4.Size = new System.Drawing.Size(167, 6);
         // 
         // _miRtfFormatLeft
         // 
         this._miRtfFormatLeft.Name = "_miRtfFormatLeft";
         this._miRtfFormatLeft.Size = new System.Drawing.Size(170, 22);
         this._miRtfFormatLeft.Text = "&Left";
         this._miRtfFormatLeft.Click += new System.EventHandler(this._miRtfFormatLeft_Click);
         // 
         // _miRtfFormatCenter
         // 
         this._miRtfFormatCenter.Name = "_miRtfFormatCenter";
         this._miRtfFormatCenter.Size = new System.Drawing.Size(170, 22);
         this._miRtfFormatCenter.Text = "&Center";
         this._miRtfFormatCenter.Click += new System.EventHandler(this._miRtfFormatCenter_Click);
         // 
         // _miRtfFormatRight
         // 
         this._miRtfFormatRight.Name = "_miRtfFormatRight";
         this._miRtfFormatRight.Size = new System.Drawing.Size(170, 22);
         this._miRtfFormatRight.Text = "&Right";
         this._miRtfFormatRight.Click += new System.EventHandler(this._miRtfFormatRight_Click);
         // 
         // RichTextMenu
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(608, 51);
         this.Controls.Add(this._tbRtf);
         this.Controls.Add(this._miRtf);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MainMenuStrip = this._miRtf;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "RichTextMenu";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
         this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
         this.Text = "RichTextMenu";
         this._tbRtf.ResumeLayout(false);
         this._tbRtf.PerformLayout();
         this._miRtf.ResumeLayout(false);
         this._miRtf.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private ToolStripEx _tbRtf;
      private System.Windows.Forms.ToolStripComboBox _cmbFont;
      private System.Windows.Forms.ToolStripComboBox _cmbFontSize;
      private System.Windows.Forms.ToolStripSplitButton _btnTextColor;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton _btnBold;
      private System.Windows.Forms.ToolStripButton _btnItalic;
      private System.Windows.Forms.ToolStripButton _btnUnderline;
      private System.Windows.Forms.ToolStripSplitButton _btnBackgroundColor;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton _btnBullets;
      private System.Windows.Forms.ToolStripButton _btnNumbers;
      private System.Windows.Forms.ToolStripButton _btnIncreaseIdent;
      private System.Windows.Forms.ToolStripButton _btnDecreaseIdent;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.MenuStrip _miRtf;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFile;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFileOpen;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFileSave;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFilePrint;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFileExit;
      private System.Windows.Forms.ToolStripMenuItem _miRtfEdit;
      private System.Windows.Forms.ToolStripMenuItem _miRtfEditUndo;
      private System.Windows.Forms.ToolStripMenuItem _miRtfEditCut;
      private System.Windows.Forms.ToolStripMenuItem _miRtfEditCopy;
      private System.Windows.Forms.ToolStripMenuItem _miRtfEditPaste;
      private System.Windows.Forms.ToolStripMenuItem _miRtfEditDelete;
      private System.Windows.Forms.ToolStripMenuItem _miRtfEditSelectAll;
      private System.Windows.Forms.ToolStripSeparator _miRtfEditSeparator1;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFormat;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFormatFont;
      private System.Windows.Forms.ToolStripSeparator _miRtfFormatSeparator1;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFormatBackgroundColor;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFormatTextColor;
      private System.Windows.Forms.ToolStripSeparator _miRtfFormatSeparator2;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFormatBullets;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFormatNumbering;
      private System.Windows.Forms.ToolStripSeparator _miRtfFormatSeparator3;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFormatDecreaseIndent;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFormatIncreaseIndent;
      private System.Windows.Forms.ToolStripSeparator _miRtfFormatSeparator4;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFormatLeft;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFormatCenter;
      private System.Windows.Forms.ToolStripMenuItem _miRtfFormatRight;
      private System.Windows.Forms.ToolStripButton _btnLeft;
      private System.Windows.Forms.ToolStripButton _btnCenter;
      private System.Windows.Forms.ToolStripButton _btnRight;
   }
}
