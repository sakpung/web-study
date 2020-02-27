namespace GrayScaleDemo
{
   partial class ViewerForm
   {

      private System.ComponentModel.IContainer components = null;

      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewerForm));
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this._lblBPP = new System.Windows.Forms.ToolStripStatusLabel();
         this._lblSigned = new System.Windows.Forms.ToolStripStatusLabel();
         this._lblImageSize = new System.Windows.Forms.ToolStripStatusLabel();
         this._lblWidth = new System.Windows.Forms.ToolStripStatusLabel();
         this._lblLevel = new System.Windows.Forms.ToolStripStatusLabel();
         this._lblX = new System.Windows.Forms.ToolStripStatusLabel();
         this._lblY = new System.Windows.Forms.ToolStripStatusLabel();
         this._lblRGB = new System.Windows.Forms.ToolStripStatusLabel();
         this._lblPaletteValue = new System.Windows.Forms.ToolStripStatusLabel();
         this.statusStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // statusStrip1
         // 
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._lblBPP,
            this._lblSigned,
            this._lblImageSize,
            this._lblWidth,
            this._lblLevel,
            this._lblX,
            this._lblY,
            this._lblRGB,
            this._lblPaletteValue});
         this.statusStrip1.Location = new System.Drawing.Point(0, 369);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(451, 22);
         this.statusStrip1.TabIndex = 0;
         this.statusStrip1.Text = "statusStrip1";
         // 
         // _lblBPP
         // 
         this._lblBPP.Name = "_lblBPP";
         this._lblBPP.Size = new System.Drawing.Size(28, 17);
         this._lblBPP.Text = "BPP";
         // 
         // _lblSigned
         // 
         this._lblSigned.Name = "_lblSigned";
         this._lblSigned.Size = new System.Drawing.Size(43, 17);
         this._lblSigned.Text = "Signed";
         // 
         // _lblImageSize
         // 
         this._lblImageSize.Name = "_lblImageSize";
         this._lblImageSize.Size = new System.Drawing.Size(26, 17);
         this._lblImageSize.Text = "size";
         // 
         // _lblWidth
         // 
         this._lblWidth.Name = "_lblWidth";
         this._lblWidth.Size = new System.Drawing.Size(37, 17);
         this._lblWidth.Text = "width";
         // 
         // _lblLevel
         // 
         this._lblLevel.Name = "_lblLevel";
         this._lblLevel.Size = new System.Drawing.Size(31, 17);
         this._lblLevel.Text = "level";
         // 
         // _lblX
         // 
         this._lblX.Name = "_lblX";
         this._lblX.Size = new System.Drawing.Size(14, 17);
         this._lblX.Text = "X";
         // 
         // _lblY
         // 
         this._lblY.Name = "_lblY";
         this._lblY.Size = new System.Drawing.Size(14, 17);
         this._lblY.Text = "Y";
         // 
         // _lblRGB
         // 
         this._lblRGB.Name = "_lblRGB";
         this._lblRGB.Size = new System.Drawing.Size(29, 17);
         this._lblRGB.Text = "RGB";
         // 
         // _lblPaletteValue
         // 
         this._lblPaletteValue.Name = "_lblPaletteValue";
         this._lblPaletteValue.Size = new System.Drawing.Size(43, 17);
         this._lblPaletteValue.Text = "Palette";
         // 
         // ViewerForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(451, 391);
         this.Controls.Add(this.statusStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "ViewerForm";
         this.Text = "ViewerForm";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ViewerForm_FormClosing);
         this.SizeChanged += new System.EventHandler(this.ViewerForm_SizeChanged);
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel _lblWidth;
      private System.Windows.Forms.ToolStripStatusLabel _lblLevel;
      private System.Windows.Forms.ToolStripStatusLabel _lblX;
      private System.Windows.Forms.ToolStripStatusLabel _lblY;
      private System.Windows.Forms.ToolStripStatusLabel _lblRGB;
      private System.Windows.Forms.ToolStripStatusLabel _lblPaletteValue;
      private System.Windows.Forms.ToolStripStatusLabel _lblBPP;
      private System.Windows.Forms.ToolStripStatusLabel _lblImageSize;
      private System.Windows.Forms.ToolStripStatusLabel _lblSigned;
   }
}