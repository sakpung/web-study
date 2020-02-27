namespace ImageProcessingDemo
{
   partial class FastFourierTransformDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FastFourierTransformDialog));
         this._gbOperationChannel = new System.Windows.Forms.GroupBox();
         this._rbGray = new System.Windows.Forms.RadioButton();
         this._rbRed = new System.Windows.Forms.RadioButton();
         this._rbGreen = new System.Windows.Forms.RadioButton();
         this._rbBlue = new System.Windows.Forms.RadioButton();
         this._gbFrequencyDataType = new System.Windows.Forms.GroupBox();
         this._rbBoth = new System.Windows.Forms.RadioButton();
         this._rbPhase = new System.Windows.Forms.RadioButton();
         this._rbMagnitude = new System.Windows.Forms.RadioButton();
         this._gbClippingType = new System.Windows.Forms.GroupBox();
         this._rbScale = new System.Windows.Forms.RadioButton();
         this._rbClip = new System.Windows.Forms.RadioButton();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbXFilter = new System.Windows.Forms.GroupBox();
         this._rbNoneX = new System.Windows.Forms.RadioButton();
         this._rbOutsideX = new System.Windows.Forms.RadioButton();
         this._rbInsideX = new System.Windows.Forms.RadioButton();
         this._gbYFilter = new System.Windows.Forms.GroupBox();
         this._rbNoneY = new System.Windows.Forms.RadioButton();
         this._rbInsideY = new System.Windows.Forms.RadioButton();
         this._rbOutsideY = new System.Windows.Forms.RadioButton();
         this._gbOperationChannel.SuspendLayout();
         this._gbFrequencyDataType.SuspendLayout();
         this._gbClippingType.SuspendLayout();
         this._gbXFilter.SuspendLayout();
         this._gbYFilter.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbOperationChannel
         // 
         this._gbOperationChannel.Controls.Add(this._rbGray);
         this._gbOperationChannel.Controls.Add(this._rbRed);
         this._gbOperationChannel.Controls.Add(this._rbGreen);
         this._gbOperationChannel.Controls.Add(this._rbBlue);
         this._gbOperationChannel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOperationChannel, "_gbOperationChannel");
         this._gbOperationChannel.Name = "_gbOperationChannel";
         this._gbOperationChannel.TabStop = false;
         // 
         // _rbGray
         // 
         resources.ApplyResources(this._rbGray, "_rbGray");
         this._rbGray.Name = "_rbGray";
         this._rbGray.TabStop = true;
         this._rbGray.UseVisualStyleBackColor = true;
         // 
         // _rbRed
         // 
         resources.ApplyResources(this._rbRed, "_rbRed");
         this._rbRed.Name = "_rbRed";
         this._rbRed.TabStop = true;
         this._rbRed.UseVisualStyleBackColor = true;
         // 
         // _rbGreen
         // 
         resources.ApplyResources(this._rbGreen, "_rbGreen");
         this._rbGreen.Name = "_rbGreen";
         this._rbGreen.TabStop = true;
         this._rbGreen.UseVisualStyleBackColor = true;
         // 
         // _rbBlue
         // 
         resources.ApplyResources(this._rbBlue, "_rbBlue");
         this._rbBlue.Name = "_rbBlue";
         this._rbBlue.TabStop = true;
         this._rbBlue.UseVisualStyleBackColor = true;
         // 
         // _gbFrequencyDataType
         // 
         this._gbFrequencyDataType.Controls.Add(this._rbBoth);
         this._gbFrequencyDataType.Controls.Add(this._rbPhase);
         this._gbFrequencyDataType.Controls.Add(this._rbMagnitude);
         this._gbFrequencyDataType.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbFrequencyDataType, "_gbFrequencyDataType");
         this._gbFrequencyDataType.Name = "_gbFrequencyDataType";
         this._gbFrequencyDataType.TabStop = false;
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
         // _gbClippingType
         // 
         this._gbClippingType.Controls.Add(this._rbScale);
         this._gbClippingType.Controls.Add(this._rbClip);
         this._gbClippingType.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbClippingType, "_gbClippingType");
         this._gbClippingType.Name = "_gbClippingType";
         this._gbClippingType.TabStop = false;
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
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click_1);
         // 
         // _gbXFilter
         // 
         this._gbXFilter.Controls.Add(this._rbNoneX);
         this._gbXFilter.Controls.Add(this._rbOutsideX);
         this._gbXFilter.Controls.Add(this._rbInsideX);
         this._gbXFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbXFilter, "_gbXFilter");
         this._gbXFilter.Name = "_gbXFilter";
         this._gbXFilter.TabStop = false;
         // 
         // _rbNoneX
         // 
         resources.ApplyResources(this._rbNoneX, "_rbNoneX");
         this._rbNoneX.Name = "_rbNoneX";
         this._rbNoneX.TabStop = true;
         this._rbNoneX.UseVisualStyleBackColor = true;
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
         // _gbYFilter
         // 
         this._gbYFilter.Controls.Add(this._rbNoneY);
         this._gbYFilter.Controls.Add(this._rbInsideY);
         this._gbYFilter.Controls.Add(this._rbOutsideY);
         this._gbYFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbYFilter, "_gbYFilter");
         this._gbYFilter.Name = "_gbYFilter";
         this._gbYFilter.TabStop = false;
         // 
         // _rbNoneY
         // 
         resources.ApplyResources(this._rbNoneY, "_rbNoneY");
         this._rbNoneY.Name = "_rbNoneY";
         this._rbNoneY.TabStop = true;
         this._rbNoneY.UseVisualStyleBackColor = true;
         // 
         // _rbInsideY
         // 
         resources.ApplyResources(this._rbInsideY, "_rbInsideY");
         this._rbInsideY.Name = "_rbInsideY";
         this._rbInsideY.TabStop = true;
         this._rbInsideY.UseVisualStyleBackColor = true;
         // 
         // _rbOutsideY
         // 
         resources.ApplyResources(this._rbOutsideY, "_rbOutsideY");
         this._rbOutsideY.Name = "_rbOutsideY";
         this._rbOutsideY.TabStop = true;
         this._rbOutsideY.UseVisualStyleBackColor = true;
         // 
         // FastFourierTransformDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gbYFilter);
         this.Controls.Add(this._gbXFilter);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbClippingType);
         this.Controls.Add(this._gbFrequencyDataType);
         this.Controls.Add(this._gbOperationChannel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "FastFourierTransformDialog";
         this.ShowIcon = false;
         this._gbOperationChannel.ResumeLayout(false);
         this._gbOperationChannel.PerformLayout();
         this._gbFrequencyDataType.ResumeLayout(false);
         this._gbFrequencyDataType.PerformLayout();
         this._gbClippingType.ResumeLayout(false);
         this._gbClippingType.PerformLayout();
         this._gbXFilter.ResumeLayout(false);
         this._gbXFilter.PerformLayout();
         this._gbYFilter.ResumeLayout(false);
         this._gbYFilter.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOperationChannel;
      private System.Windows.Forms.GroupBox _gbFrequencyDataType;
      private System.Windows.Forms.RadioButton _rbGray;
      private System.Windows.Forms.RadioButton _rbRed;
      private System.Windows.Forms.RadioButton _rbGreen;
      private System.Windows.Forms.RadioButton _rbBlue;
      private System.Windows.Forms.RadioButton _rbBoth;
      private System.Windows.Forms.RadioButton _rbPhase;
      private System.Windows.Forms.RadioButton _rbMagnitude;
      private System.Windows.Forms.GroupBox _gbClippingType;
      private System.Windows.Forms.RadioButton _rbScale;
      private System.Windows.Forms.RadioButton _rbClip;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbXFilter;
      private System.Windows.Forms.RadioButton _rbNoneX;
      private System.Windows.Forms.RadioButton _rbOutsideX;
      private System.Windows.Forms.RadioButton _rbInsideX;
      private System.Windows.Forms.GroupBox _gbYFilter;
      private System.Windows.Forms.RadioButton _rbNoneY;
      private System.Windows.Forms.RadioButton _rbInsideY;
      private System.Windows.Forms.RadioButton _rbOutsideY;
   }
}