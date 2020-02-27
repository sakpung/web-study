namespace OcrScreenCaptureDemo
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
         this._splitContainer = new System.Windows.Forms.SplitContainer();
         this.mainPanel = new System.Windows.Forms.Panel();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this._tsCaptureBtn = new System.Windows.Forms.ToolStripSplitButton();
         this.freehandArea = new System.Windows.Forms.ToolStripMenuItem();
         this.rectangleArea = new System.Windows.Forms.ToolStripMenuItem();
         this.windowCapture = new System.Windows.Forms.ToolStripMenuItem();
         this.fullscreenCapture = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this._tsUseHotkey = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this._tsOCROptionsBtn = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this._tsCopyAndSaveDropDown = new System.Windows.Forms.ToolStripDropDownButton();
         this._tsCopyTextBtn = new System.Windows.Forms.ToolStripMenuItem();
         this._tsSaveTextBtn = new System.Windows.Forms.ToolStripMenuItem();
         this._tsCopyImageBtn = new System.Windows.Forms.ToolStripMenuItem();
         this._tsSaveImageBtn = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this._tsDrawingChoice = new System.Windows.Forms.ToolStripDropDownButton();
         this.penToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.highlighterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).BeginInit();
         this._splitContainer.SuspendLayout();
         this.mainPanel.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // _splitContainer
         // 
         this._splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._splitContainer.Location = new System.Drawing.Point(0, 39);
         this._splitContainer.Name = "_splitContainer";
         this._splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
         this._splitContainer.Size = new System.Drawing.Size(827, 487);
         this._splitContainer.SplitterDistance = 233;
         this._splitContainer.TabIndex = 8;
         this._splitContainer.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer_SplitterMoved);
         // 
         // mainPanel
         // 
         this.mainPanel.Controls.Add(this._splitContainer);
         this.mainPanel.Controls.Add(this.toolStrip1);
         this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.mainPanel.Location = new System.Drawing.Point(0, 0);
         this.mainPanel.Name = "mainPanel";
         this.mainPanel.Size = new System.Drawing.Size(827, 526);
         this.mainPanel.TabIndex = 0;
         // 
         // toolStrip1
         // 
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsCaptureBtn,
            this.toolStripSeparator1,
            this._tsUseHotkey,
            this.toolStripSeparator3,
            this._tsOCROptionsBtn,
            this.toolStripSeparator2,
            this._tsCopyAndSaveDropDown,
            this.toolStripSeparator4,
            this._tsDrawingChoice});
         this.toolStrip1.Location = new System.Drawing.Point(0, 0);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(827, 39);
         this.toolStrip1.TabIndex = 0;
         this.toolStrip1.Text = "toolStrip1";
         // 
         // _tsCaptureBtn
         // 
         this._tsCaptureBtn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.freehandArea,
            this.rectangleArea,
            this.windowCapture,
            this.fullscreenCapture});
         this._tsCaptureBtn.Image = global::OcrScreenCaptureDemo.Properties.Resources.OCR_SCREEN32;
         this._tsCaptureBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
         this._tsCaptureBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._tsCaptureBtn.Name = "_tsCaptureBtn";
         this._tsCaptureBtn.Size = new System.Drawing.Size(97, 36);
         this._tsCaptureBtn.Text = "&Capture";
         this._tsCaptureBtn.ButtonClick += new System.EventHandler(this.buttonScreenCapture_Click);
         // 
         // freehandArea
         // 
         this.freehandArea.Name = "freehandArea";
         this.freehandArea.Size = new System.Drawing.Size(164, 22);
         this.freehandArea.Text = "Freehand Area";
         this.freehandArea.Click += new System.EventHandler(this._tsCaptureBtnItem_Clicked);
         // 
         // rectangleArea
         // 
         this.rectangleArea.Name = "rectangleArea";
         this.rectangleArea.Size = new System.Drawing.Size(164, 22);
         this.rectangleArea.Text = "Rectangular Area";
         this.rectangleArea.Click += new System.EventHandler(this._tsCaptureBtnItem_Clicked);
         // 
         // windowCapture
         // 
         this.windowCapture.Name = "windowCapture";
         this.windowCapture.Size = new System.Drawing.Size(164, 22);
         this.windowCapture.Text = "Window";
         this.windowCapture.Click += new System.EventHandler(this._tsCaptureBtnItem_Clicked);
         // 
         // fullscreenCapture
         // 
         this.fullscreenCapture.Name = "fullscreenCapture";
         this.fullscreenCapture.Size = new System.Drawing.Size(164, 22);
         this.fullscreenCapture.Text = "Full-screen";
         this.fullscreenCapture.Click += new System.EventHandler(this._tsCaptureBtnItem_Clicked);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
         // 
         // _tsUseHotkey
         // 
         this._tsUseHotkey.CheckOnClick = true;
         this._tsUseHotkey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this._tsUseHotkey.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._tsUseHotkey.Name = "_tsUseHotkey";
         this._tsUseHotkey.Size = new System.Drawing.Size(97, 36);
         this._tsUseHotkey.Text = "Use &Hotkey(F11)";
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
         // 
         // _tsOCROptionsBtn
         // 
         this._tsOCROptionsBtn.Image = global::OcrScreenCaptureDemo.Properties.Resources.settings;
         this._tsOCROptionsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._tsOCROptionsBtn.Name = "_tsOCROptionsBtn";
         this._tsOCROptionsBtn.Size = new System.Drawing.Size(96, 36);
         this._tsOCROptionsBtn.Text = "&OCR Options";
         this._tsOCROptionsBtn.Click += new System.EventHandler(this.buttonOcrOptions_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
         // 
         // _tsCopyAndSaveDropDown
         // 
         this._tsCopyAndSaveDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this._tsCopyAndSaveDropDown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._tsCopyTextBtn,
            this._tsSaveTextBtn,
            this._tsCopyImageBtn,
            this._tsSaveImageBtn});
         this._tsCopyAndSaveDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._tsCopyAndSaveDropDown.Name = "_tsCopyAndSaveDropDown";
         this._tsCopyAndSaveDropDown.Size = new System.Drawing.Size(98, 36);
         this._tsCopyAndSaveDropDown.Text = "Copy and Save";
         // 
         // _tsCopyTextBtn
         // 
         this._tsCopyTextBtn.Image = global::OcrScreenCaptureDemo.Properties.Resources.copy_text;
         this._tsCopyTextBtn.Name = "_tsCopyTextBtn";
         this._tsCopyTextBtn.Size = new System.Drawing.Size(138, 22);
         this._tsCopyTextBtn.Text = "Copy Text";
         this._tsCopyTextBtn.Click += new System.EventHandler(this.buttonCopyText_Click);
         // 
         // _tsSaveTextBtn
         // 
         this._tsSaveTextBtn.Image = global::OcrScreenCaptureDemo.Properties.Resources.save_text;
         this._tsSaveTextBtn.Name = "_tsSaveTextBtn";
         this._tsSaveTextBtn.Size = new System.Drawing.Size(138, 22);
         this._tsSaveTextBtn.Text = "Save Text";
         this._tsSaveTextBtn.Click += new System.EventHandler(this.buttonSaveText_Click);
         // 
         // _tsCopyImageBtn
         // 
         this._tsCopyImageBtn.Image = global::OcrScreenCaptureDemo.Properties.Resources.copy_image;
         this._tsCopyImageBtn.Name = "_tsCopyImageBtn";
         this._tsCopyImageBtn.Size = new System.Drawing.Size(138, 22);
         this._tsCopyImageBtn.Text = "Copy Image";
         this._tsCopyImageBtn.Click += new System.EventHandler(this.buttonCopyImage_Click);
         // 
         // _tsSaveImageBtn
         // 
         this._tsSaveImageBtn.Image = global::OcrScreenCaptureDemo.Properties.Resources.save_image;
         this._tsSaveImageBtn.Name = "_tsSaveImageBtn";
         this._tsSaveImageBtn.Size = new System.Drawing.Size(138, 22);
         this._tsSaveImageBtn.Text = "Save Image";
         this._tsSaveImageBtn.Click += new System.EventHandler(this.buttonSaveImage_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(6, 39);
         // 
         // _tsDrawingChoice
         // 
         this._tsDrawingChoice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
         this._tsDrawingChoice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.penToolStripMenuItem,
            this.highlighterToolStripMenuItem});
         this._tsDrawingChoice.ImageTransparentColor = System.Drawing.Color.Magenta;
         this._tsDrawingChoice.Name = "_tsDrawingChoice";
         this._tsDrawingChoice.Size = new System.Drawing.Size(102, 36);
         this._tsDrawingChoice.Text = "Draw On Image";
         // 
         // penToolStripMenuItem
         // 
         this.penToolStripMenuItem.Checked = true;
         this.penToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
         this.penToolStripMenuItem.Name = "penToolStripMenuItem";
         this.penToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
         this.penToolStripMenuItem.Text = "&Pen";
         this.penToolStripMenuItem.Click += new System.EventHandler(this._tsDrawingChoice_Click);
         // 
         // highlighterToolStripMenuItem
         // 
         this.highlighterToolStripMenuItem.Name = "highlighterToolStripMenuItem";
         this.highlighterToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
         this.highlighterToolStripMenuItem.Text = "&Highlighter";
         this.highlighterToolStripMenuItem.Click += new System.EventHandler(this._tsDrawingChoice_Click);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(827, 526);
         this.Controls.Add(this.mainPanel);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.KeyPreview = true;
         this.Name = "MainForm";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         ((System.ComponentModel.ISupportInitialize)(this._splitContainer)).EndInit();
         this._splitContainer.ResumeLayout(false);
         this.mainPanel.ResumeLayout(false);
         this.mainPanel.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.SplitContainer _splitContainer;
      private System.Windows.Forms.Panel mainPanel;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripSplitButton _tsCaptureBtn;
      private System.Windows.Forms.ToolStripMenuItem freehandArea;
      private System.Windows.Forms.ToolStripMenuItem rectangleArea;
      private System.Windows.Forms.ToolStripMenuItem windowCapture;
      private System.Windows.Forms.ToolStripMenuItem fullscreenCapture;
      private System.Windows.Forms.ToolStripButton _tsOCROptionsBtn;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripDropDownButton _tsDrawingChoice;
      private System.Windows.Forms.ToolStripMenuItem penToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem highlighterToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripButton _tsUseHotkey;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripDropDownButton _tsCopyAndSaveDropDown;
      private System.Windows.Forms.ToolStripMenuItem _tsCopyTextBtn;
      private System.Windows.Forms.ToolStripMenuItem _tsSaveTextBtn;
      private System.Windows.Forms.ToolStripMenuItem _tsCopyImageBtn;
      private System.Windows.Forms.ToolStripMenuItem _tsSaveImageBtn;
   }
}

