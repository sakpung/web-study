namespace ImageProcessingDemo
{
   partial class DiscreteFourierTransformDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscreteFourierTransformDialog));
          this._gpTransformation = new System.Windows.Forms.GroupBox();
          this._rbInverseDiscreteFourierTransform = new System.Windows.Forms.RadioButton();
          this._rbDiscreteFourierTransform = new System.Windows.Forms.RadioButton();
          this._gbChannel = new System.Windows.Forms.GroupBox();
          this._rbGray = new System.Windows.Forms.RadioButton();
          this._rbBlue = new System.Windows.Forms.RadioButton();
          this._rbGreen = new System.Windows.Forms.RadioButton();
          this._rbRed = new System.Windows.Forms.RadioButton();
          this._gbFrequency = new System.Windows.Forms.GroupBox();
          this._rbBoth = new System.Windows.Forms.RadioButton();
          this._rbPhase = new System.Windows.Forms.RadioButton();
          this._rbMagnitude = new System.Windows.Forms.RadioButton();
          this._gbClipping = new System.Windows.Forms.GroupBox();
          this._rbScale = new System.Windows.Forms.RadioButton();
          this._rbClip = new System.Windows.Forms.RadioButton();
          this._gbHarmonics = new System.Windows.Forms.GroupBox();
          this._rbRange = new System.Windows.Forms.RadioButton();
          this._rbAll = new System.Windows.Forms.RadioButton();
          this._gbXHarmonics = new System.Windows.Forms.GroupBox();
          this._rbOutsideX = new System.Windows.Forms.RadioButton();
          this._rbInsideX = new System.Windows.Forms.RadioButton();
          this._gbYHarmonics = new System.Windows.Forms.GroupBox();
          this._rbOutsideY = new System.Windows.Forms.RadioButton();
          this._rbInsideY = new System.Windows.Forms.RadioButton();
          this._gbData = new System.Windows.Forms.GroupBox();
          this._rbDPhase = new System.Windows.Forms.RadioButton();
          this._rbDMagnitude = new System.Windows.Forms.RadioButton();
          this._gbPlotting = new System.Windows.Forms.GroupBox();
          this._rbLogarithm = new System.Windows.Forms.RadioButton();
          this._rbNormal = new System.Windows.Forms.RadioButton();
          this._gbRange = new System.Windows.Forms.GroupBox();
          this._numHeight = new System.Windows.Forms.NumericUpDown();
          this._numWidth = new System.Windows.Forms.NumericUpDown();
          this._numY = new System.Windows.Forms.NumericUpDown();
          this._numX = new System.Windows.Forms.NumericUpDown();
          this._lblHeight = new System.Windows.Forms.Label();
          this._lblWidth = new System.Windows.Forms.Label();
          this._lblY = new System.Windows.Forms.Label();
          this._lblX = new System.Windows.Forms.Label();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gpTransformation.SuspendLayout();
          this._gbChannel.SuspendLayout();
          this._gbFrequency.SuspendLayout();
          this._gbClipping.SuspendLayout();
          this._gbHarmonics.SuspendLayout();
          this._gbXHarmonics.SuspendLayout();
          this._gbYHarmonics.SuspendLayout();
          this._gbData.SuspendLayout();
          this._gbPlotting.SuspendLayout();
          this._gbRange.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numY)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numX)).BeginInit();
          this.SuspendLayout();
          // 
          // _gpTransformation
          // 
          this._gpTransformation.Controls.Add(this._rbInverseDiscreteFourierTransform);
          this._gpTransformation.Controls.Add(this._rbDiscreteFourierTransform);
          this._gpTransformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gpTransformation, "_gpTransformation");
          this._gpTransformation.Name = "_gpTransformation";
          this._gpTransformation.TabStop = false;
          // 
          // _rbInverseDiscreteFourierTransform
          // 
          resources.ApplyResources(this._rbInverseDiscreteFourierTransform, "_rbInverseDiscreteFourierTransform");
          this._rbInverseDiscreteFourierTransform.Name = "_rbInverseDiscreteFourierTransform";
          this._rbInverseDiscreteFourierTransform.TabStop = true;
          this._rbInverseDiscreteFourierTransform.UseVisualStyleBackColor = true;
          // 
          // _rbDiscreteFourierTransform
          // 
          resources.ApplyResources(this._rbDiscreteFourierTransform, "_rbDiscreteFourierTransform");
          this._rbDiscreteFourierTransform.Name = "_rbDiscreteFourierTransform";
          this._rbDiscreteFourierTransform.TabStop = true;
          this._rbDiscreteFourierTransform.UseVisualStyleBackColor = true;
          // 
          // _gbChannel
          // 
          this._gbChannel.Controls.Add(this._rbGray);
          this._gbChannel.Controls.Add(this._rbBlue);
          this._gbChannel.Controls.Add(this._rbGreen);
          this._gbChannel.Controls.Add(this._rbRed);
          this._gbChannel.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbChannel, "_gbChannel");
          this._gbChannel.Name = "_gbChannel";
          this._gbChannel.TabStop = false;
          // 
          // _rbGray
          // 
          resources.ApplyResources(this._rbGray, "_rbGray");
          this._rbGray.Name = "_rbGray";
          this._rbGray.TabStop = true;
          this._rbGray.UseVisualStyleBackColor = true;
          // 
          // _rbBlue
          // 
          resources.ApplyResources(this._rbBlue, "_rbBlue");
          this._rbBlue.Name = "_rbBlue";
          this._rbBlue.TabStop = true;
          this._rbBlue.UseVisualStyleBackColor = true;
          // 
          // _rbGreen
          // 
          resources.ApplyResources(this._rbGreen, "_rbGreen");
          this._rbGreen.Name = "_rbGreen";
          this._rbGreen.TabStop = true;
          this._rbGreen.UseVisualStyleBackColor = true;
          // 
          // _rbRed
          // 
          resources.ApplyResources(this._rbRed, "_rbRed");
          this._rbRed.Name = "_rbRed";
          this._rbRed.TabStop = true;
          this._rbRed.UseVisualStyleBackColor = true;
          // 
          // _gbFrequency
          // 
          this._gbFrequency.Controls.Add(this._rbBoth);
          this._gbFrequency.Controls.Add(this._rbPhase);
          this._gbFrequency.Controls.Add(this._rbMagnitude);
          this._gbFrequency.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbFrequency, "_gbFrequency");
          this._gbFrequency.Name = "_gbFrequency";
          this._gbFrequency.TabStop = false;
          // 
          // _rbBoth
          // 
          resources.ApplyResources(this._rbBoth, "_rbBoth");
          this._rbBoth.Name = "_rbBoth";
          this._rbBoth.TabStop = true;
          this._rbBoth.UseVisualStyleBackColor = true;
          // 
          // _rbPhase
          // 
          resources.ApplyResources(this._rbPhase, "_rbPhase");
          this._rbPhase.Name = "_rbPhase";
          this._rbPhase.TabStop = true;
          this._rbPhase.UseVisualStyleBackColor = true;
          // 
          // _rbMagnitude
          // 
          resources.ApplyResources(this._rbMagnitude, "_rbMagnitude");
          this._rbMagnitude.Name = "_rbMagnitude";
          this._rbMagnitude.TabStop = true;
          this._rbMagnitude.UseVisualStyleBackColor = true;
          // 
          // _gbClipping
          // 
          this._gbClipping.Controls.Add(this._rbScale);
          this._gbClipping.Controls.Add(this._rbClip);
          this._gbClipping.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbClipping, "_gbClipping");
          this._gbClipping.Name = "_gbClipping";
          this._gbClipping.TabStop = false;
          // 
          // _rbScale
          // 
          resources.ApplyResources(this._rbScale, "_rbScale");
          this._rbScale.Name = "_rbScale";
          this._rbScale.TabStop = true;
          this._rbScale.UseVisualStyleBackColor = true;
          // 
          // _rbClip
          // 
          resources.ApplyResources(this._rbClip, "_rbClip");
          this._rbClip.Name = "_rbClip";
          this._rbClip.TabStop = true;
          this._rbClip.UseVisualStyleBackColor = true;
          // 
          // _gbHarmonics
          // 
          this._gbHarmonics.Controls.Add(this._rbRange);
          this._gbHarmonics.Controls.Add(this._rbAll);
          this._gbHarmonics.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbHarmonics, "_gbHarmonics");
          this._gbHarmonics.Name = "_gbHarmonics";
          this._gbHarmonics.TabStop = false;
          // 
          // _rbRange
          // 
          resources.ApplyResources(this._rbRange, "_rbRange");
          this._rbRange.Name = "_rbRange";
          this._rbRange.TabStop = true;
          this._rbRange.UseVisualStyleBackColor = true;
          // 
          // _rbAll
          // 
          resources.ApplyResources(this._rbAll, "_rbAll");
          this._rbAll.Name = "_rbAll";
          this._rbAll.TabStop = true;
          this._rbAll.UseVisualStyleBackColor = true;
          // 
          // _gbXHarmonics
          // 
          this._gbXHarmonics.Controls.Add(this._rbOutsideX);
          this._gbXHarmonics.Controls.Add(this._rbInsideX);
          this._gbXHarmonics.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbXHarmonics, "_gbXHarmonics");
          this._gbXHarmonics.Name = "_gbXHarmonics";
          this._gbXHarmonics.TabStop = false;
          // 
          // _rbOutsideX
          // 
          resources.ApplyResources(this._rbOutsideX, "_rbOutsideX");
          this._rbOutsideX.Name = "_rbOutsideX";
          this._rbOutsideX.TabStop = true;
          this._rbOutsideX.UseVisualStyleBackColor = true;
          // 
          // _rbInsideX
          // 
          resources.ApplyResources(this._rbInsideX, "_rbInsideX");
          this._rbInsideX.Name = "_rbInsideX";
          this._rbInsideX.TabStop = true;
          this._rbInsideX.UseVisualStyleBackColor = true;
          // 
          // _gbYHarmonics
          // 
          this._gbYHarmonics.Controls.Add(this._rbOutsideY);
          this._gbYHarmonics.Controls.Add(this._rbInsideY);
          this._gbYHarmonics.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbYHarmonics, "_gbYHarmonics");
          this._gbYHarmonics.Name = "_gbYHarmonics";
          this._gbYHarmonics.TabStop = false;
          // 
          // _rbOutsideY
          // 
          resources.ApplyResources(this._rbOutsideY, "_rbOutsideY");
          this._rbOutsideY.Name = "_rbOutsideY";
          this._rbOutsideY.TabStop = true;
          this._rbOutsideY.UseVisualStyleBackColor = true;
          // 
          // _rbInsideY
          // 
          resources.ApplyResources(this._rbInsideY, "_rbInsideY");
          this._rbInsideY.Name = "_rbInsideY";
          this._rbInsideY.TabStop = true;
          this._rbInsideY.UseVisualStyleBackColor = true;
          // 
          // _gbData
          // 
          this._gbData.Controls.Add(this._rbDPhase);
          this._gbData.Controls.Add(this._rbDMagnitude);
          this._gbData.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbData, "_gbData");
          this._gbData.Name = "_gbData";
          this._gbData.TabStop = false;
          // 
          // _rbDPhase
          // 
          resources.ApplyResources(this._rbDPhase, "_rbDPhase");
          this._rbDPhase.Name = "_rbDPhase";
          this._rbDPhase.TabStop = true;
          this._rbDPhase.UseVisualStyleBackColor = true;
          // 
          // _rbDMagnitude
          // 
          resources.ApplyResources(this._rbDMagnitude, "_rbDMagnitude");
          this._rbDMagnitude.Name = "_rbDMagnitude";
          this._rbDMagnitude.TabStop = true;
          this._rbDMagnitude.UseVisualStyleBackColor = true;
          // 
          // _gbPlotting
          // 
          this._gbPlotting.Controls.Add(this._rbLogarithm);
          this._gbPlotting.Controls.Add(this._rbNormal);
          this._gbPlotting.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbPlotting, "_gbPlotting");
          this._gbPlotting.Name = "_gbPlotting";
          this._gbPlotting.TabStop = false;
          // 
          // _rbLogarithm
          // 
          resources.ApplyResources(this._rbLogarithm, "_rbLogarithm");
          this._rbLogarithm.Name = "_rbLogarithm";
          this._rbLogarithm.TabStop = true;
          this._rbLogarithm.UseVisualStyleBackColor = true;
          // 
          // _rbNormal
          // 
          resources.ApplyResources(this._rbNormal, "_rbNormal");
          this._rbNormal.Name = "_rbNormal";
          this._rbNormal.TabStop = true;
          this._rbNormal.UseVisualStyleBackColor = true;
          // 
          // _gbRange
          // 
          this._gbRange.Controls.Add(this._numHeight);
          this._gbRange.Controls.Add(this._numWidth);
          this._gbRange.Controls.Add(this._numY);
          this._gbRange.Controls.Add(this._numX);
          this._gbRange.Controls.Add(this._lblHeight);
          this._gbRange.Controls.Add(this._lblWidth);
          this._gbRange.Controls.Add(this._lblY);
          this._gbRange.Controls.Add(this._lblX);
          this._gbRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbRange, "_gbRange");
          this._gbRange.Name = "_gbRange";
          this._gbRange.TabStop = false;
          // 
          // _numHeight
          // 
          resources.ApplyResources(this._numHeight, "_numHeight");
          this._numHeight.Name = "_numHeight";
          this._numHeight.Leave += new System.EventHandler(this._numHeight_Leave);
          // 
          // _numWidth
          // 
          resources.ApplyResources(this._numWidth, "_numWidth");
          this._numWidth.Name = "_numWidth";
          this._numWidth.Leave += new System.EventHandler(this._numWidth_Leave);
          // 
          // _numY
          // 
          resources.ApplyResources(this._numY, "_numY");
          this._numY.Name = "_numY";
          this._numY.Leave += new System.EventHandler(this._numY_Leave);
          // 
          // _numX
          // 
          resources.ApplyResources(this._numX, "_numX");
          this._numX.Name = "_numX";
          this._numX.Leave += new System.EventHandler(this._numX_Leave);
          // 
          // _lblHeight
          // 
          resources.ApplyResources(this._lblHeight, "_lblHeight");
          this._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblHeight.Name = "_lblHeight";
          // 
          // _lblWidth
          // 
          resources.ApplyResources(this._lblWidth, "_lblWidth");
          this._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblWidth.Name = "_lblWidth";
          // 
          // _lblY
          // 
          resources.ApplyResources(this._lblY, "_lblY");
          this._lblY.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblY.Name = "_lblY";
          // 
          // _lblX
          // 
          resources.ApplyResources(this._lblX, "_lblX");
          this._lblX.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblX.Name = "_lblX";
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _btnOk
          // 
          this._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // DiscreteFourierTransformDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbRange);
          this.Controls.Add(this._gbPlotting);
          this.Controls.Add(this._gbData);
          this.Controls.Add(this._gbYHarmonics);
          this.Controls.Add(this._gbXHarmonics);
          this.Controls.Add(this._gbHarmonics);
          this.Controls.Add(this._gbClipping);
          this.Controls.Add(this._gbFrequency);
          this.Controls.Add(this._gbChannel);
          this.Controls.Add(this._gpTransformation);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "DiscreteFourierTransformDialog";
          this.ShowIcon = false;
          this._gpTransformation.ResumeLayout(false);
          this._gpTransformation.PerformLayout();
          this._gbChannel.ResumeLayout(false);
          this._gbChannel.PerformLayout();
          this._gbFrequency.ResumeLayout(false);
          this._gbFrequency.PerformLayout();
          this._gbClipping.ResumeLayout(false);
          this._gbClipping.PerformLayout();
          this._gbHarmonics.ResumeLayout(false);
          this._gbHarmonics.PerformLayout();
          this._gbXHarmonics.ResumeLayout(false);
          this._gbXHarmonics.PerformLayout();
          this._gbYHarmonics.ResumeLayout(false);
          this._gbYHarmonics.PerformLayout();
          this._gbData.ResumeLayout(false);
          this._gbData.PerformLayout();
          this._gbPlotting.ResumeLayout(false);
          this._gbPlotting.PerformLayout();
          this._gbRange.ResumeLayout(false);
          this._gbRange.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numY)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numX)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gpTransformation;
      private System.Windows.Forms.RadioButton _rbInverseDiscreteFourierTransform;
      private System.Windows.Forms.RadioButton _rbDiscreteFourierTransform;
      private System.Windows.Forms.GroupBox _gbChannel;
      private System.Windows.Forms.RadioButton _rbGray;
      private System.Windows.Forms.RadioButton _rbBlue;
      private System.Windows.Forms.RadioButton _rbGreen;
      private System.Windows.Forms.RadioButton _rbRed;
      private System.Windows.Forms.GroupBox _gbFrequency;
      private System.Windows.Forms.RadioButton _rbBoth;
      private System.Windows.Forms.RadioButton _rbPhase;
      private System.Windows.Forms.RadioButton _rbMagnitude;
      private System.Windows.Forms.GroupBox _gbClipping;
      private System.Windows.Forms.RadioButton _rbScale;
      private System.Windows.Forms.RadioButton _rbClip;
      private System.Windows.Forms.GroupBox _gbHarmonics;
      private System.Windows.Forms.RadioButton _rbRange;
      private System.Windows.Forms.RadioButton _rbAll;
      private System.Windows.Forms.GroupBox _gbXHarmonics;
      private System.Windows.Forms.RadioButton _rbOutsideX;
      private System.Windows.Forms.RadioButton _rbInsideX;
      private System.Windows.Forms.GroupBox _gbYHarmonics;
      private System.Windows.Forms.RadioButton _rbOutsideY;
      private System.Windows.Forms.RadioButton _rbInsideY;
      private System.Windows.Forms.GroupBox _gbData;
      private System.Windows.Forms.RadioButton _rbDPhase;
      private System.Windows.Forms.RadioButton _rbDMagnitude;
      private System.Windows.Forms.GroupBox _gbPlotting;
      private System.Windows.Forms.RadioButton _rbLogarithm;
      private System.Windows.Forms.RadioButton _rbNormal;
      private System.Windows.Forms.GroupBox _gbRange;
      private System.Windows.Forms.NumericUpDown _numHeight;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.NumericUpDown _numY;
      private System.Windows.Forms.NumericUpDown _numX;
      private System.Windows.Forms.Label _lblHeight;
      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.Label _lblY;
      private System.Windows.Forms.Label _lblX;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;


   }
}