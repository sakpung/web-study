namespace Leadtools.Demos
{
   partial class PaintPropertiesDialog
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
      private void InitializeComponent( )
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaintPropertiesDialog));
         this._cbFastPaint = new System.Windows.Forms.CheckBox();
         this._btnApply = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._cbHalftonePrint = new System.Windows.Forms.CheckBox();
         this._cbIndexedPaint = new System.Windows.Forms.CheckBox();
         this._cbPaintScaling = new System.Windows.Forms.ComboBox();
         this._lblPaintScaling = new System.Windows.Forms.Label();
         this._cbBitonalScaling = new System.Windows.Forms.ComboBox();
         this._cbDithering = new System.Windows.Forms.ComboBox();
         this._lblDithering = new System.Windows.Forms.Label();
         this._lblBitonalScaling = new System.Windows.Forms.Label();
         this._cbPalette = new System.Windows.Forms.ComboBox();
         this._lblPalette = new System.Windows.Forms.Label();
         this._cbOperation = new System.Windows.Forms.ComboBox();
         this._lblOperation = new System.Windows.Forms.Label();
         this._cbEngine = new System.Windows.Forms.ComboBox();
         this._lblEngine = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _cbFastPaint
         // 
         resources.ApplyResources(this._cbFastPaint, "_cbFastPaint");
         this._cbFastPaint.Name = "_cbFastPaint";
         this._cbFastPaint.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
         // 
         // _btnApply
         // 
         resources.ApplyResources(this._btnApply, "_btnApply");
         this._btnApply.Name = "_btnApply";
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._cbFastPaint);
         this._gbOptions.Controls.Add(this._cbHalftonePrint);
         this._gbOptions.Controls.Add(this._cbIndexedPaint);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _cbHalftonePrint
         // 
         resources.ApplyResources(this._cbHalftonePrint, "_cbHalftonePrint");
         this._cbHalftonePrint.Name = "_cbHalftonePrint";
         this._cbHalftonePrint.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
         // 
         // _cbIndexedPaint
         // 
         resources.ApplyResources(this._cbIndexedPaint, "_cbIndexedPaint");
         this._cbIndexedPaint.Name = "_cbIndexedPaint";
         this._cbIndexedPaint.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
         // 
         // _cbPaintScaling
         // 
         this._cbPaintScaling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cbPaintScaling, "_cbPaintScaling");
         this._cbPaintScaling.Name = "_cbPaintScaling";
         this._cbPaintScaling.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
         // 
         // _lblPaintScaling
         // 
         this._lblPaintScaling.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblPaintScaling, "_lblPaintScaling");
         this._lblPaintScaling.Name = "_lblPaintScaling";
         // 
         // _cbBitonalScaling
         // 
         this._cbBitonalScaling.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cbBitonalScaling, "_cbBitonalScaling");
         this._cbBitonalScaling.Name = "_cbBitonalScaling";
         this._cbBitonalScaling.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
         // 
         // _cbDithering
         // 
         this._cbDithering.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cbDithering, "_cbDithering");
         this._cbDithering.Name = "_cbDithering";
         this._cbDithering.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
         // 
         // _lblDithering
         // 
         this._lblDithering.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblDithering, "_lblDithering");
         this._lblDithering.Name = "_lblDithering";
         // 
         // _lblBitonalScaling
         // 
         this._lblBitonalScaling.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblBitonalScaling, "_lblBitonalScaling");
         this._lblBitonalScaling.Name = "_lblBitonalScaling";
         // 
         // _cbPalette
         // 
         this._cbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cbPalette, "_cbPalette");
         this._cbPalette.Name = "_cbPalette";
         this._cbPalette.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
         // 
         // _lblPalette
         // 
         this._lblPalette.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblPalette, "_lblPalette");
         this._lblPalette.Name = "_lblPalette";
         // 
         // _cbOperation
         // 
         this._cbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cbOperation, "_cbOperation");
         this._cbOperation.Name = "_cbOperation";
         this._cbOperation.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
         // 
         // _lblOperation
         // 
         this._lblOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblOperation, "_lblOperation");
         this._lblOperation.Name = "_lblOperation";
         // 
         // _cbEngine
         // 
         this._cbEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cbEngine, "_cbEngine");
         this._cbEngine.Name = "_cbEngine";
         this._cbEngine.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
         // 
         // _lblEngine
         // 
         this._lblEngine.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblEngine, "_lblEngine");
         this._lblEngine.Name = "_lblEngine";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // PaintPropertiesDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._cbPaintScaling);
         this.Controls.Add(this._lblPaintScaling);
         this.Controls.Add(this._cbBitonalScaling);
         this.Controls.Add(this._cbDithering);
         this.Controls.Add(this._lblDithering);
         this.Controls.Add(this._lblBitonalScaling);
         this.Controls.Add(this._cbPalette);
         this.Controls.Add(this._lblPalette);
         this.Controls.Add(this._cbOperation);
         this.Controls.Add(this._lblOperation);
         this.Controls.Add(this._cbEngine);
         this.Controls.Add(this._lblEngine);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PaintPropertiesDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.PaintPropertiesDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.CheckBox _cbFastPaint;
      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.CheckBox _cbHalftonePrint;
      private System.Windows.Forms.CheckBox _cbIndexedPaint;
      private System.Windows.Forms.ComboBox _cbPaintScaling;
      private System.Windows.Forms.Label _lblPaintScaling;
      private System.Windows.Forms.ComboBox _cbBitonalScaling;
      private System.Windows.Forms.ComboBox _cbDithering;
      private System.Windows.Forms.Label _lblDithering;
      private System.Windows.Forms.Label _lblBitonalScaling;
      private System.Windows.Forms.ComboBox _cbPalette;
      private System.Windows.Forms.Label _lblPalette;
      private System.Windows.Forms.ComboBox _cbOperation;
      private System.Windows.Forms.Label _lblOperation;
      private System.Windows.Forms.ComboBox _cbEngine;
      private System.Windows.Forms.Label _lblEngine;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}