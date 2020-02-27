namespace ImageProcessingDemo
{
   partial class RemapIntensityDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemapIntensityDialog));
          this._cmbChannel = new System.Windows.Forms.ComboBox();
          this._lblChannel = new System.Windows.Forms.Label();
          this._lblGraph = new System.Windows.Forms.Label();
          this._gbIntensity = new System.Windows.Forms.GroupBox();
          this._lblY = new System.Windows.Forms.Label();
          this._lblYVal = new System.Windows.Forms.Label();
          this._lblXVal = new System.Windows.Forms.Label();
          this._lblX = new System.Windows.Forms.Label();
          this._numEnd = new System.Windows.Forms.NumericUpDown();
          this._numStart = new System.Windows.Forms.NumericUpDown();
          this._lblEnd = new System.Windows.Forms.Label();
          this._lblStart = new System.Windows.Forms.Label();
          this._lblMapping = new System.Windows.Forms.Label();
          this._cmbMapping = new System.Windows.Forms.ComboBox();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbIntensity.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numEnd)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numStart)).BeginInit();
          this.SuspendLayout();
          // 
          // _cmbChannel
          // 
          this._cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbChannel, "_cmbChannel");
          this._cmbChannel.FormattingEnabled = true;
          this._cmbChannel.Name = "_cmbChannel";
          // 
          // _lblChannel
          // 
          resources.ApplyResources(this._lblChannel, "_lblChannel");
          this._lblChannel.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblChannel.Name = "_lblChannel";
          // 
          // _lblGraph
          // 
          this._lblGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this._lblGraph.Cursor = System.Windows.Forms.Cursors.Cross;
          resources.ApplyResources(this._lblGraph, "_lblGraph");
          this._lblGraph.Name = "_lblGraph";
          this._lblGraph.Paint += new System.Windows.Forms.PaintEventHandler(this._lblGraph_Paint);
          this._lblGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this._lblGraph_MouseMove);
          // 
          // _gbIntensity
          // 
          this._gbIntensity.Controls.Add(this._lblY);
          this._gbIntensity.Controls.Add(this._lblYVal);
          this._gbIntensity.Controls.Add(this._lblXVal);
          this._gbIntensity.Controls.Add(this._lblX);
          this._gbIntensity.Controls.Add(this._numEnd);
          this._gbIntensity.Controls.Add(this._numStart);
          this._gbIntensity.Controls.Add(this._lblEnd);
          this._gbIntensity.Controls.Add(this._lblStart);
          this._gbIntensity.Controls.Add(this._lblMapping);
          this._gbIntensity.Controls.Add(this._cmbMapping);
          this._gbIntensity.Controls.Add(this._lblGraph);
          this._gbIntensity.Controls.Add(this._lblChannel);
          this._gbIntensity.Controls.Add(this._cmbChannel);
          this._gbIntensity.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbIntensity, "_gbIntensity");
          this._gbIntensity.Name = "_gbIntensity";
          this._gbIntensity.TabStop = false;
          // 
          // _lblY
          // 
          resources.ApplyResources(this._lblY, "_lblY");
          this._lblY.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblY.Name = "_lblY";
          // 
          // _lblYVal
          // 
          resources.ApplyResources(this._lblYVal, "_lblYVal");
          this._lblYVal.Name = "_lblYVal";
          // 
          // _lblXVal
          // 
          resources.ApplyResources(this._lblXVal, "_lblXVal");
          this._lblXVal.Name = "_lblXVal";
          // 
          // _lblX
          // 
          this._lblX.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblX, "_lblX");
          this._lblX.Name = "_lblX";
          // 
          // _numEnd
          // 
          resources.ApplyResources(this._numEnd, "_numEnd");
          this._numEnd.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
          this._numEnd.Name = "_numEnd";
          this._numEnd.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
          this._numEnd.ValueChanged += new System.EventHandler(this._numEnd_ValueChanged);
          this._numEnd.Leave += new System.EventHandler(this._numEnd_Leave);
          // 
          // _numStart
          // 
          resources.ApplyResources(this._numStart, "_numStart");
          this._numStart.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
          this._numStart.Name = "_numStart";
          this._numStart.ValueChanged += new System.EventHandler(this._numStart_ValueChanged);
          this._numStart.Leave += new System.EventHandler(this._numStart_Leave);
          // 
          // _lblEnd
          // 
          resources.ApplyResources(this._lblEnd, "_lblEnd");
          this._lblEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblEnd.Name = "_lblEnd";
          // 
          // _lblStart
          // 
          resources.ApplyResources(this._lblStart, "_lblStart");
          this._lblStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblStart.Name = "_lblStart";
          // 
          // _lblMapping
          // 
          resources.ApplyResources(this._lblMapping, "_lblMapping");
          this._lblMapping.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblMapping.Name = "_lblMapping";
          // 
          // _cmbMapping
          // 
          this._cmbMapping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbMapping, "_cmbMapping");
          this._cmbMapping.FormattingEnabled = true;
          this._cmbMapping.Name = "_cmbMapping";
          this._cmbMapping.SelectedIndexChanged += new System.EventHandler(this._cmbMapping_SelectedIndexChanged);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _btnOk
          // 
          this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // RemapIntensityDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbIntensity);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "RemapIntensityDialog";
          this.ShowIcon = false;
          this._gbIntensity.ResumeLayout(false);
          this._gbIntensity.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numEnd)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numStart)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ComboBox _cmbChannel;
      private System.Windows.Forms.Label _lblChannel;
      private System.Windows.Forms.Label _lblGraph;
      private System.Windows.Forms.GroupBox _gbIntensity;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.NumericUpDown _numEnd;
      private System.Windows.Forms.NumericUpDown _numStart;
      private System.Windows.Forms.Label _lblEnd;
      private System.Windows.Forms.Label _lblStart;
      private System.Windows.Forms.Label _lblMapping;
      private System.Windows.Forms.ComboBox _cmbMapping;
      private System.Windows.Forms.Label _lblY;
      private System.Windows.Forms.Label _lblYVal;
      private System.Windows.Forms.Label _lblXVal;
      private System.Windows.Forms.Label _lblX;
   }
}