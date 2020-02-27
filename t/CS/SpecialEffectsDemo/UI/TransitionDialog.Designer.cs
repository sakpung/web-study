namespace SpecialEffectsDemo
{
   partial class TransitionDialog
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._gbTransition = new System.Windows.Forms.GroupBox();
         this._lblWand = new System.Windows.Forms.Label();
         this._lblPasses = new System.Windows.Forms.Label();
         this._lblGrain = new System.Windows.Forms.Label();
         this._lblDelay = new System.Windows.Forms.Label();
         this._numWand = new System.Windows.Forms.NumericUpDown();
         this._numPasses = new System.Windows.Forms.NumericUpDown();
         this._numGrain = new System.Windows.Forms.NumericUpDown();
         this._numDelay = new System.Windows.Forms.NumericUpDown();
         this._btnEffect = new System.Windows.Forms.Button();
         this._btnBackColor = new System.Windows.Forms.Button();
         this._lblBackColor = new System.Windows.Forms.Label();
         this._btnForeColor = new System.Windows.Forms.Button();
         this._lblForeColor = new System.Windows.Forms.Label();
         this._cmbTransitionStyle = new System.Windows.Forms.ComboBox();
         this._lblEffectStyle = new System.Windows.Forms.Label();
         this._gbTransition.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numWand)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numPasses)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGrain)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numDelay)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(149, 217);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOK.Location = new System.Drawing.Point(68, 217);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 1;
         this._btnOK.Text = "OK\r\n";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _gbTransition
         // 
         this._gbTransition.Controls.Add(this._lblWand);
         this._gbTransition.Controls.Add(this._lblPasses);
         this._gbTransition.Controls.Add(this._lblGrain);
         this._gbTransition.Controls.Add(this._lblDelay);
         this._gbTransition.Controls.Add(this._numWand);
         this._gbTransition.Controls.Add(this._numPasses);
         this._gbTransition.Controls.Add(this._numGrain);
         this._gbTransition.Controls.Add(this._numDelay);
         this._gbTransition.Controls.Add(this._btnEffect);
         this._gbTransition.Controls.Add(this._btnBackColor);
         this._gbTransition.Controls.Add(this._lblBackColor);
         this._gbTransition.Controls.Add(this._btnForeColor);
         this._gbTransition.Controls.Add(this._lblForeColor);
         this._gbTransition.Controls.Add(this._cmbTransitionStyle);
         this._gbTransition.Controls.Add(this._lblEffectStyle);
         this._gbTransition.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbTransition.Location = new System.Drawing.Point(6, 1);
         this._gbTransition.Name = "_gbTransition";
         this._gbTransition.Size = new System.Drawing.Size(299, 205);
         this._gbTransition.TabIndex = 0;
         this._gbTransition.TabStop = false;
         // 
         // _lblWand
         // 
         this._lblWand.AutoSize = true;
         this._lblWand.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblWand.Location = new System.Drawing.Point(182, 174);
         this._lblWand.Name = "_lblWand";
         this._lblWand.Size = new System.Drawing.Size(42, 13);
         this._lblWand.TabIndex = 13;
         this._lblWand.Text = "&Wand :";
         // 
         // _lblPasses
         // 
         this._lblPasses.AutoSize = true;
         this._lblPasses.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblPasses.Location = new System.Drawing.Point(182, 148);
         this._lblPasses.Name = "_lblPasses";
         this._lblPasses.Size = new System.Drawing.Size(47, 13);
         this._lblPasses.TabIndex = 11;
         this._lblPasses.Text = "&Passes :";
         // 
         // _lblGrain
         // 
         this._lblGrain.AutoSize = true;
         this._lblGrain.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblGrain.Location = new System.Drawing.Point(11, 174);
         this._lblGrain.Name = "_lblGrain";
         this._lblGrain.Size = new System.Drawing.Size(38, 13);
         this._lblGrain.TabIndex = 9;
         this._lblGrain.Text = "&Grain :";
         // 
         // _lblDelay
         // 
         this._lblDelay.AutoSize = true;
         this._lblDelay.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblDelay.Location = new System.Drawing.Point(10, 148);
         this._lblDelay.Name = "_lblDelay";
         this._lblDelay.Size = new System.Drawing.Size(40, 13);
         this._lblDelay.TabIndex = 7;
         this._lblDelay.Text = "&Delay :";
         // 
         // _numWand
         // 
         this._numWand.Location = new System.Drawing.Point(236, 172);
         this._numWand.Name = "_numWand";
         this._numWand.Size = new System.Drawing.Size(50, 20);
         this._numWand.TabIndex = 14;
         // 
         // _numPasses
         // 
         this._numPasses.Location = new System.Drawing.Point(236, 146);
         this._numPasses.Name = "_numPasses";
         this._numPasses.Size = new System.Drawing.Size(50, 20);
         this._numPasses.TabIndex = 12;
         // 
         // _numGrain
         // 
         this._numGrain.Location = new System.Drawing.Point(71, 172);
         this._numGrain.Name = "_numGrain";
         this._numGrain.Size = new System.Drawing.Size(50, 20);
         this._numGrain.TabIndex = 10;
         // 
         // _numDelay
         // 
         this._numDelay.Location = new System.Drawing.Point(71, 146);
         this._numDelay.Name = "_numDelay";
         this._numDelay.Size = new System.Drawing.Size(50, 20);
         this._numDelay.TabIndex = 8;
         // 
         // _btnEffect
         // 
         this._btnEffect.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnEffect.Location = new System.Drawing.Point(195, 76);
         this._btnEffect.Name = "_btnEffect";
         this._btnEffect.Size = new System.Drawing.Size(91, 23);
         this._btnEffect.TabIndex = 6;
         this._btnEffect.Text = "&Effect...";
         this._btnEffect.UseVisualStyleBackColor = true;
         this._btnEffect.Click += new System.EventHandler(this._btnEffect_Click);
         // 
         // _btnBackColor
         // 
         this._btnBackColor.ForeColor = System.Drawing.SystemColors.ControlText;
         this._btnBackColor.Location = new System.Drawing.Point(72, 107);
         this._btnBackColor.Name = "_btnBackColor";
         this._btnBackColor.Size = new System.Drawing.Size(75, 23);
         this._btnBackColor.TabIndex = 5;
         this._btnBackColor.Text = "\r\n";
         this._btnBackColor.UseVisualStyleBackColor = false;
         this._btnBackColor.Click += new System.EventHandler(this._btnBackColor_Click);
         // 
         // _lblBackColor
         // 
         this._lblBackColor.AutoSize = true;
         this._lblBackColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblBackColor.Location = new System.Drawing.Point(8, 112);
         this._lblBackColor.Name = "_lblBackColor";
         this._lblBackColor.Size = new System.Drawing.Size(65, 13);
         this._lblBackColor.TabIndex = 4;
         this._lblBackColor.Text = "&Back Color :";
         // 
         // _btnForeColor
         // 
         this._btnForeColor.ForeColor = System.Drawing.Color.Black;
         this._btnForeColor.Location = new System.Drawing.Point(72, 74);
         this._btnForeColor.Name = "_btnForeColor";
         this._btnForeColor.Size = new System.Drawing.Size(75, 23);
         this._btnForeColor.TabIndex = 3;
         this._btnForeColor.UseVisualStyleBackColor = false;
         this._btnForeColor.Click += new System.EventHandler(this._btnForeColor_Click);
         // 
         // _lblForeColor
         // 
         this._lblForeColor.AutoSize = true;
         this._lblForeColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblForeColor.Location = new System.Drawing.Point(8, 79);
         this._lblForeColor.Name = "_lblForeColor";
         this._lblForeColor.Size = new System.Drawing.Size(61, 13);
         this._lblForeColor.TabIndex = 2;
         this._lblForeColor.Text = "&Fore Color :";
         // 
         // _cmbTransitionStyle
         // 
         this._cmbTransitionStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbTransitionStyle.FormattingEnabled = true;
         this._cmbTransitionStyle.Location = new System.Drawing.Point(5, 32);
         this._cmbTransitionStyle.Name = "_cmbTransitionStyle";
         this._cmbTransitionStyle.Size = new System.Drawing.Size(281, 21);
         this._cmbTransitionStyle.TabIndex = 1;
         // 
         // _lblEffectStyle
         // 
         this._lblEffectStyle.AutoSize = true;
         this._lblEffectStyle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblEffectStyle.Location = new System.Drawing.Point(5, 16);
         this._lblEffectStyle.Name = "_lblEffectStyle";
         this._lblEffectStyle.Size = new System.Drawing.Size(100, 13);
         this._lblEffectStyle.TabIndex = 0;
         this._lblEffectStyle.Text = "Transition Fill &Style :";
         // 
         // TransitionDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(311, 250);
         this.Controls.Add(this._gbTransition);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "TransitionDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Transition Dialog";
         this.Load += new System.EventHandler(this.TransitionDialog_Load);
         this._gbTransition.ResumeLayout(false);
         this._gbTransition.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numWand)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numPasses)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGrain)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numDelay)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.GroupBox _gbTransition;
      private System.Windows.Forms.ComboBox _cmbTransitionStyle;
      private System.Windows.Forms.Label _lblEffectStyle;
      private System.Windows.Forms.Button _btnBackColor;
      private System.Windows.Forms.Label _lblBackColor;
      private System.Windows.Forms.Button _btnForeColor;
      private System.Windows.Forms.Label _lblForeColor;
      private System.Windows.Forms.Button _btnEffect;
      private System.Windows.Forms.Label _lblWand;
      private System.Windows.Forms.Label _lblPasses;
      private System.Windows.Forms.Label _lblGrain;
      private System.Windows.Forms.Label _lblDelay;
      private System.Windows.Forms.NumericUpDown _numWand;
      private System.Windows.Forms.NumericUpDown _numPasses;
      private System.Windows.Forms.NumericUpDown _numGrain;
      private System.Windows.Forms.NumericUpDown _numDelay;

   }
}