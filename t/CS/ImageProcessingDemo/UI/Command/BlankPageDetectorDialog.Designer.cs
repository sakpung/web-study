namespace ImageProcessingDemo
{
   partial class BlankPageDetectorDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlankPageDetectorDialog));
         this._gbDetectPage = new System.Windows.Forms.GroupBox();
         this._rdUseInches = new System.Windows.Forms.RadioButton();
         this._chkUseActiveArea = new System.Windows.Forms.CheckBox();
         this._rdUseCentimeters = new System.Windows.Forms.RadioButton();
         this._chkIgnorBleedThrough = new System.Windows.Forms.CheckBox();
         this._rdUsePixels = new System.Windows.Forms.RadioButton();
         this._chkDetectLinedPage = new System.Windows.Forms.CheckBox();
         this._chkDetectNoisyPage = new System.Windows.Forms.CheckBox();
         this._chkDetectTextOnly = new System.Windows.Forms.CheckBox();
         this._chkUseAdvanced = new System.Windows.Forms.CheckBox();
         this._btnok = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbMargins = new System.Windows.Forms.GroupBox();
         this._lblUnits = new System.Windows.Forms.Label();
         this._chkUseDefaultMargin = new System.Windows.Forms.CheckBox();
         this._gbUserMargins = new System.Windows.Forms.GroupBox();
         this._lblUnitBottom = new System.Windows.Forms.Label();
         this._lblUnitRight = new System.Windows.Forms.Label();
         this._lblUnitTop = new System.Windows.Forms.Label();
         this._lblUnitLeft = new System.Windows.Forms.Label();
         this._lblBottom = new System.Windows.Forms.Label();
         this._tbRight = new System.Windows.Forms.TextBox();
         this._lblRight = new System.Windows.Forms.Label();
         this._tbBottom = new System.Windows.Forms.TextBox();
         this._lblTop = new System.Windows.Forms.Label();
         this._tbTop = new System.Windows.Forms.TextBox();
         this._lblLeft = new System.Windows.Forms.Label();
         this._tbLeft = new System.Windows.Forms.TextBox();
         this._gbDetectPage.SuspendLayout();
         this._gbMargins.SuspendLayout();
         this._gbUserMargins.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbDetectPage
         // 
         this._gbDetectPage.Controls.Add(this._rdUseInches);
         this._gbDetectPage.Controls.Add(this._chkUseActiveArea);
         this._gbDetectPage.Controls.Add(this._rdUseCentimeters);
         this._gbDetectPage.Controls.Add(this._chkIgnorBleedThrough);
         this._gbDetectPage.Controls.Add(this._rdUsePixels);
         this._gbDetectPage.Controls.Add(this._chkDetectLinedPage);
         this._gbDetectPage.Controls.Add(this._chkDetectNoisyPage);
         this._gbDetectPage.Controls.Add(this._chkDetectTextOnly);
         this._gbDetectPage.Controls.Add(this._chkUseAdvanced);
         this._gbDetectPage.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbDetectPage, "_gbDetectPage");
         this._gbDetectPage.Name = "_gbDetectPage";
         this._gbDetectPage.TabStop = false;
         // 
         // _rdUseInches
         // 
         resources.ApplyResources(this._rdUseInches, "_rdUseInches");
         this._rdUseInches.Name = "_rdUseInches";
         this._rdUseInches.TabStop = true;
         this._rdUseInches.UseVisualStyleBackColor = true;
         this._rdUseInches.CheckedChanged += new System.EventHandler(this.UnitCheckedChanged);
         // 
         // _chkUseActiveArea
         // 
         resources.ApplyResources(this._chkUseActiveArea, "_chkUseActiveArea");
         this._chkUseActiveArea.Name = "_chkUseActiveArea";
         this._chkUseActiveArea.UseVisualStyleBackColor = true;
         // 
         // _rdUseCentimeters
         // 
         resources.ApplyResources(this._rdUseCentimeters, "_rdUseCentimeters");
         this._rdUseCentimeters.Name = "_rdUseCentimeters";
         this._rdUseCentimeters.TabStop = true;
         this._rdUseCentimeters.UseVisualStyleBackColor = true;
         this._rdUseCentimeters.CheckedChanged += new System.EventHandler(this.UnitCheckedChanged);
         // 
         // _chkIgnorBleedThrough
         // 
         resources.ApplyResources(this._chkIgnorBleedThrough, "_chkIgnorBleedThrough");
         this._chkIgnorBleedThrough.Name = "_chkIgnorBleedThrough";
         this._chkIgnorBleedThrough.UseVisualStyleBackColor = true;
         // 
         // _rdUsePixels
         // 
         resources.ApplyResources(this._rdUsePixels, "_rdUsePixels");
         this._rdUsePixels.Name = "_rdUsePixels";
         this._rdUsePixels.TabStop = true;
         this._rdUsePixels.UseVisualStyleBackColor = true;
         this._rdUsePixels.CheckedChanged += new System.EventHandler(this.UnitCheckedChanged);
         // 
         // _chkDetectLinedPage
         // 
         resources.ApplyResources(this._chkDetectLinedPage, "_chkDetectLinedPage");
         this._chkDetectLinedPage.Name = "_chkDetectLinedPage";
         this._chkDetectLinedPage.UseVisualStyleBackColor = true;
         // 
         // _chkDetectNoisyPage
         // 
         resources.ApplyResources(this._chkDetectNoisyPage, "_chkDetectNoisyPage");
         this._chkDetectNoisyPage.Name = "_chkDetectNoisyPage";
         this._chkDetectNoisyPage.UseVisualStyleBackColor = true;
         // 
         // _chkDetectTextOnly
         // 
         resources.ApplyResources(this._chkDetectTextOnly, "_chkDetectTextOnly");
         this._chkDetectTextOnly.Name = "_chkDetectTextOnly";
         this._chkDetectTextOnly.UseVisualStyleBackColor = true;
         // 
         // _chkUseAdvanced
         // 
         resources.ApplyResources(this._chkUseAdvanced, "_chkUseAdvanced");
         this._chkUseAdvanced.Name = "_chkUseAdvanced";
         this._chkUseAdvanced.UseVisualStyleBackColor = true;
         this._chkUseAdvanced.CheckedChanged += new System.EventHandler(this._chkUseAdvanced_CheckedChanged);
         // 
         // _btnok
         // 
         resources.ApplyResources(this._btnok, "_btnok");
         this._btnok.Name = "_btnok";
         this._btnok.UseVisualStyleBackColor = true;
         this._btnok.Click += new System.EventHandler(this._btnok_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _gbMargins
         // 
         this._gbMargins.Controls.Add(this._lblUnits);
         this._gbMargins.Controls.Add(this._chkUseDefaultMargin);
         this._gbMargins.Controls.Add(this._gbUserMargins);
         this._gbMargins.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbMargins, "_gbMargins");
         this._gbMargins.Name = "_gbMargins";
         this._gbMargins.TabStop = false;
         // 
         // _lblUnits
         // 
         this._lblUnits.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblUnits, "_lblUnits");
         this._lblUnits.Name = "_lblUnits";
         // 
         // _chkUseDefaultMargin
         // 
         resources.ApplyResources(this._chkUseDefaultMargin, "_chkUseDefaultMargin");
         this._chkUseDefaultMargin.Name = "_chkUseDefaultMargin";
         this._chkUseDefaultMargin.UseVisualStyleBackColor = true;
         this._chkUseDefaultMargin.CheckedChanged += new System.EventHandler(this._chkUseDefaultMargin_CheckedChanged);
         // 
         // _gbUserMargins
         // 
         this._gbUserMargins.Controls.Add(this._lblUnitBottom);
         this._gbUserMargins.Controls.Add(this._lblUnitRight);
         this._gbUserMargins.Controls.Add(this._lblUnitTop);
         this._gbUserMargins.Controls.Add(this._lblUnitLeft);
         this._gbUserMargins.Controls.Add(this._lblBottom);
         this._gbUserMargins.Controls.Add(this._tbRight);
         this._gbUserMargins.Controls.Add(this._lblRight);
         this._gbUserMargins.Controls.Add(this._tbBottom);
         this._gbUserMargins.Controls.Add(this._lblTop);
         this._gbUserMargins.Controls.Add(this._tbTop);
         this._gbUserMargins.Controls.Add(this._lblLeft);
         this._gbUserMargins.Controls.Add(this._tbLeft);
         resources.ApplyResources(this._gbUserMargins, "_gbUserMargins");
         this._gbUserMargins.Name = "_gbUserMargins";
         this._gbUserMargins.TabStop = false;
         // 
         // _lblUnitBottom
         // 
         resources.ApplyResources(this._lblUnitBottom, "_lblUnitBottom");
         this._lblUnitBottom.Name = "_lblUnitBottom";
         // 
         // _lblUnitRight
         // 
         resources.ApplyResources(this._lblUnitRight, "_lblUnitRight");
         this._lblUnitRight.Name = "_lblUnitRight";
         // 
         // _lblUnitTop
         // 
         resources.ApplyResources(this._lblUnitTop, "_lblUnitTop");
         this._lblUnitTop.Name = "_lblUnitTop";
         // 
         // _lblUnitLeft
         // 
         resources.ApplyResources(this._lblUnitLeft, "_lblUnitLeft");
         this._lblUnitLeft.Name = "_lblUnitLeft";
         // 
         // _lblBottom
         // 
         resources.ApplyResources(this._lblBottom, "_lblBottom");
         this._lblBottom.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblBottom.Name = "_lblBottom";
         // 
         // _tbRight
         // 
         this._tbRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._tbRight, "_tbRight");
         this._tbRight.Name = "_tbRight";
         this._tbRight.TextChanged += new System.EventHandler(this._tbRight_TextChanged);
         // 
         // _lblRight
         // 
         resources.ApplyResources(this._lblRight, "_lblRight");
         this._lblRight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblRight.Name = "_lblRight";
         // 
         // _tbBottom
         // 
         this._tbBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._tbBottom, "_tbBottom");
         this._tbBottom.Name = "_tbBottom";
         this._tbBottom.TextChanged += new System.EventHandler(this._tbBottom_TextChanged);
         // 
         // _lblTop
         // 
         resources.ApplyResources(this._lblTop, "_lblTop");
         this._lblTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblTop.Name = "_lblTop";
         // 
         // _tbTop
         // 
         this._tbTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._tbTop, "_tbTop");
         this._tbTop.Name = "_tbTop";
         this._tbTop.TextChanged += new System.EventHandler(this._tbTop_TextChanged);
         // 
         // _lblLeft
         // 
         resources.ApplyResources(this._lblLeft, "_lblLeft");
         this._lblLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblLeft.Name = "_lblLeft";
         // 
         // _tbLeft
         // 
         this._tbLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._tbLeft, "_tbLeft");
         this._tbLeft.Name = "_tbLeft";
         this._tbLeft.TextChanged += new System.EventHandler(this._tbLeft_TextChanged);
         // 
         // BlankPageDetectorDialog
         // 
         this.AcceptButton = this._btnok;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gbMargins);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnok);
         this.Controls.Add(this._gbDetectPage);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BlankPageDetectorDialog";
         this.ShowIcon = false;
         this._gbDetectPage.ResumeLayout(false);
         this._gbDetectPage.PerformLayout();
         this._gbMargins.ResumeLayout(false);
         this._gbMargins.PerformLayout();
         this._gbUserMargins.ResumeLayout(false);
         this._gbUserMargins.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbDetectPage;
      private System.Windows.Forms.Button _btnok;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _gbMargins;
      private System.Windows.Forms.GroupBox _gbUserMargins;
      private System.Windows.Forms.TextBox _tbRight;
      private System.Windows.Forms.TextBox _tbBottom;
      private System.Windows.Forms.TextBox _tbTop;
      private System.Windows.Forms.TextBox _tbLeft;
      private System.Windows.Forms.Label _lblBottom;
      private System.Windows.Forms.Label _lblRight;
      private System.Windows.Forms.Label _lblTop;
      private System.Windows.Forms.Label _lblLeft;
      private System.Windows.Forms.CheckBox _chkUseActiveArea;
      private System.Windows.Forms.CheckBox _chkIgnorBleedThrough;
      private System.Windows.Forms.CheckBox _chkDetectLinedPage;
      private System.Windows.Forms.CheckBox _chkDetectNoisyPage;
      private System.Windows.Forms.CheckBox _chkDetectTextOnly;
      private System.Windows.Forms.CheckBox _chkUseAdvanced;
      private System.Windows.Forms.CheckBox _chkUseDefaultMargin;
      private System.Windows.Forms.RadioButton _rdUseInches;
      private System.Windows.Forms.RadioButton _rdUseCentimeters;
      private System.Windows.Forms.RadioButton _rdUsePixels;
      private System.Windows.Forms.Label _lblUnits;
      private System.Windows.Forms.Label _lblUnitBottom;
      private System.Windows.Forms.Label _lblUnitRight;
      private System.Windows.Forms.Label _lblUnitTop;
      private System.Windows.Forms.Label _lblUnitLeft;
   }
}