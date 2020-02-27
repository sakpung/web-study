namespace SpecialEffectsDemo
{
   partial class EffectsDialog
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
      private void InitializeComponent()
      {
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._lblEffectStyle = new System.Windows.Forms.Label();
         this._cmbEffectStyle = new System.Windows.Forms.ComboBox();
         this._gbEffect = new System.Windows.Forms.GroupBox();
         this._lblWand = new System.Windows.Forms.Label();
         this._lblPasses = new System.Windows.Forms.Label();
         this._lblGrain = new System.Windows.Forms.Label();
         this._lblDelay = new System.Windows.Forms.Label();
         this._numWand = new System.Windows.Forms.NumericUpDown();
         this._numPasses = new System.Windows.Forms.NumericUpDown();
         this._numGrain = new System.Windows.Forms.NumericUpDown();
         this._numDelay = new System.Windows.Forms.NumericUpDown();
         this._gbEffect.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numWand)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numPasses)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGrain)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numDelay)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOK.Location = new System.Drawing.Point(116, 129);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 1;
         this._btnOK.Text = "OK\r\n";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(197, 129);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _lblEffectStyle
         // 
         this._lblEffectStyle.AutoSize = true;
         this._lblEffectStyle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblEffectStyle.Location = new System.Drawing.Point(8, 20);
         this._lblEffectStyle.Name = "_lblEffectStyle";
         this._lblEffectStyle.Size = new System.Drawing.Size(67, 13);
         this._lblEffectStyle.TabIndex = 0;
         this._lblEffectStyle.Text = "Effect &Style :";
         // 
         // _cmbEffectStyle
         // 
         this._cmbEffectStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbEffectStyle.FormattingEnabled = true;
         this._cmbEffectStyle.Location = new System.Drawing.Point(79, 16);
         this._cmbEffectStyle.Name = "_cmbEffectStyle";
         this._cmbEffectStyle.Size = new System.Drawing.Size(293, 21);
         this._cmbEffectStyle.TabIndex = 1;
         // 
         // _gbEffect
         // 
         this._gbEffect.Controls.Add(this._lblWand);
         this._gbEffect.Controls.Add(this._lblPasses);
         this._gbEffect.Controls.Add(this._lblGrain);
         this._gbEffect.Controls.Add(this._lblDelay);
         this._gbEffect.Controls.Add(this._numWand);
         this._gbEffect.Controls.Add(this._numPasses);
         this._gbEffect.Controls.Add(this._numGrain);
         this._gbEffect.Controls.Add(this._numDelay);
         this._gbEffect.Controls.Add(this._cmbEffectStyle);
         this._gbEffect.Controls.Add(this._lblEffectStyle);
         this._gbEffect.Location = new System.Drawing.Point(5, 3);
         this._gbEffect.Name = "_gbEffect";
         this._gbEffect.Size = new System.Drawing.Size(378, 115);
         this._gbEffect.TabIndex = 0;
         this._gbEffect.TabStop = false;
         // 
         // _lblWand
         // 
         this._lblWand.AutoSize = true;
         this._lblWand.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblWand.Location = new System.Drawing.Point(241, 84);
         this._lblWand.Name = "_lblWand";
         this._lblWand.Size = new System.Drawing.Size(42, 13);
         this._lblWand.TabIndex = 8;
         this._lblWand.Text = "&Wand :";
         // 
         // _lblPasses
         // 
         this._lblPasses.AutoSize = true;
         this._lblPasses.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblPasses.Location = new System.Drawing.Point(241, 58);
         this._lblPasses.Name = "_lblPasses";
         this._lblPasses.Size = new System.Drawing.Size(47, 13);
         this._lblPasses.TabIndex = 6;
         this._lblPasses.Text = "&Passes :";
         // 
         // _lblGrain
         // 
         this._lblGrain.AutoSize = true;
         this._lblGrain.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblGrain.Location = new System.Drawing.Point(34, 84);
         this._lblGrain.Name = "_lblGrain";
         this._lblGrain.Size = new System.Drawing.Size(38, 13);
         this._lblGrain.TabIndex = 4;
         this._lblGrain.Text = "&Grain :";
         // 
         // _lblDelay
         // 
         this._lblDelay.AutoSize = true;
         this._lblDelay.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblDelay.Location = new System.Drawing.Point(33, 58);
         this._lblDelay.Name = "_lblDelay";
         this._lblDelay.Size = new System.Drawing.Size(40, 13);
         this._lblDelay.TabIndex = 2;
         this._lblDelay.Text = "&Delay :";
         // 
         // _numWand
         // 
         this._numWand.Location = new System.Drawing.Point(294, 82);
         this._numWand.Name = "_numWand";
         this._numWand.Size = new System.Drawing.Size(77, 20);
         this._numWand.TabIndex = 9;
         // 
         // _numPasses
         // 
         this._numPasses.Location = new System.Drawing.Point(294, 56);
         this._numPasses.Name = "_numPasses";
         this._numPasses.Size = new System.Drawing.Size(77, 20);
         this._numPasses.TabIndex = 7;
         // 
         // _numGrain
         // 
         this._numGrain.Location = new System.Drawing.Point(79, 82);
         this._numGrain.Name = "_numGrain";
         this._numGrain.Size = new System.Drawing.Size(77, 20);
         this._numGrain.TabIndex = 5;
         // 
         // _numDelay
         // 
         this._numDelay.Location = new System.Drawing.Point(79, 56);
         this._numDelay.Name = "_numDelay";
         this._numDelay.Size = new System.Drawing.Size(77, 20);
         this._numDelay.TabIndex = 3;
         // 
         // EffectsDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(388, 164);
         this.Controls.Add(this._gbEffect);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EffectsDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Effects Dialog";
         this.Load += new System.EventHandler(this.EffectsDialog_Load);
         this._gbEffect.ResumeLayout(false);
         this._gbEffect.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numWand)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numPasses)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGrain)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numDelay)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblEffectStyle;
      private System.Windows.Forms.ComboBox _cmbEffectStyle;
      private System.Windows.Forms.GroupBox _gbEffect;
      private System.Windows.Forms.NumericUpDown _numDelay;
      private System.Windows.Forms.NumericUpDown _numPasses;
      private System.Windows.Forms.NumericUpDown _numGrain;
      private System.Windows.Forms.NumericUpDown _numWand;
      private System.Windows.Forms.Label _lblWand;
      private System.Windows.Forms.Label _lblPasses;
      private System.Windows.Forms.Label _lblGrain;
      private System.Windows.Forms.Label _lblDelay;
   }
}