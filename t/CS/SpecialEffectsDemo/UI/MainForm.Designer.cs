namespace SpecialEffectsDemo
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this._btnEffect = new System.Windows.Forms.Button();
         this._btnShape = new System.Windows.Forms.Button();
         this._btnTransition = new System.Windows.Forms.Button();
         this._btnShow = new System.Windows.Forms.Button();
         this._btnText = new System.Windows.Forms.Button();
         this._ckShowTransition = new System.Windows.Forms.CheckBox();
         this._ckShowShape = new System.Windows.Forms.CheckBox();
         this._ckShowText = new System.Windows.Forms.CheckBox();
         this._pnlOptions = new System.Windows.Forms.Panel();
         this._pnlViewer = new System.Windows.Forms.Panel();
         this._pnlOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnEffect
         // 
         this._btnEffect.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnEffect.Location = new System.Drawing.Point(9, 12);
         this._btnEffect.Name = "_btnEffect";
         this._btnEffect.Size = new System.Drawing.Size(90, 23);
         this._btnEffect.TabIndex = 1;
         this._btnEffect.Text = "&Effect";
         this._btnEffect.UseVisualStyleBackColor = true;
         this._btnEffect.Click += new System.EventHandler(this._btnEffect_Click);
         // 
         // _btnShape
         // 
         this._btnShape.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnShape.Location = new System.Drawing.Point(9, 92);
         this._btnShape.Name = "_btnShape";
         this._btnShape.Size = new System.Drawing.Size(90, 23);
         this._btnShape.TabIndex = 2;
         this._btnShape.Text = "&Shape";
         this._btnShape.UseVisualStyleBackColor = true;
         this._btnShape.Click += new System.EventHandler(this._btnShape_Click);
         // 
         // _btnTransition
         // 
         this._btnTransition.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnTransition.Location = new System.Drawing.Point(9, 52);
         this._btnTransition.Name = "_btnTransition";
         this._btnTransition.Size = new System.Drawing.Size(90, 23);
         this._btnTransition.TabIndex = 3;
         this._btnTransition.Text = "&Transition";
         this._btnTransition.UseVisualStyleBackColor = true;
         this._btnTransition.Click += new System.EventHandler(this._btnTransition_Click);
         // 
         // _btnShow
         // 
         this._btnShow.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnShow.Location = new System.Drawing.Point(9, 172);
         this._btnShow.Name = "_btnShow";
         this._btnShow.Size = new System.Drawing.Size(90, 23);
         this._btnShow.TabIndex = 4;
         this._btnShow.Text = "Sho&w";
         this._btnShow.UseVisualStyleBackColor = true;
         this._btnShow.Click += new System.EventHandler(this._btnShow_Click);
         // 
         // _btnText
         // 
         this._btnText.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnText.Location = new System.Drawing.Point(9, 132);
         this._btnText.Name = "_btnText";
         this._btnText.Size = new System.Drawing.Size(90, 23);
         this._btnText.TabIndex = 5;
         this._btnText.Text = "Te&xt";
         this._btnText.UseVisualStyleBackColor = true;
         this._btnText.Click += new System.EventHandler(this._btnText_Click);
         // 
         // _ckShowTransition
         // 
         this._ckShowTransition.AutoSize = true;
         this._ckShowTransition.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._ckShowTransition.Location = new System.Drawing.Point(9, 367);
         this._ckShowTransition.Name = "_ckShowTransition";
         this._ckShowTransition.Size = new System.Drawing.Size(108, 18);
         this._ckShowTransition.TabIndex = 6;
         this._ckShowTransition.Text = "Show Transition";
         this._ckShowTransition.UseVisualStyleBackColor = true;
         // 
         // _ckShowShape
         // 
         this._ckShowShape.AutoSize = true;
         this._ckShowShape.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._ckShowShape.Location = new System.Drawing.Point(9, 384);
         this._ckShowShape.Name = "_ckShowShape";
         this._ckShowShape.Size = new System.Drawing.Size(93, 31);
         this._ckShowShape.TabIndex = 7;
         this._ckShowShape.Text = "Show Shape\r\n";
         this._ckShowShape.UseVisualStyleBackColor = true;
         // 
         // _ckShowText
         // 
         this._ckShowText.AutoSize = true;
         this._ckShowText.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._ckShowText.Location = new System.Drawing.Point(9, 413);
         this._ckShowText.Name = "_ckShowText";
         this._ckShowText.Size = new System.Drawing.Size(83, 18);
         this._ckShowText.TabIndex = 8;
         this._ckShowText.Text = "Show Text";
         this._ckShowText.UseVisualStyleBackColor = true;
         // 
         // _pnlOptions
         // 
         this._pnlOptions.Controls.Add(this._btnEffect);
         this._pnlOptions.Controls.Add(this._ckShowText);
         this._pnlOptions.Controls.Add(this._btnShape);
         this._pnlOptions.Controls.Add(this._ckShowShape);
         this._pnlOptions.Controls.Add(this._btnTransition);
         this._pnlOptions.Controls.Add(this._ckShowTransition);
         this._pnlOptions.Controls.Add(this._btnShow);
         this._pnlOptions.Controls.Add(this._btnText);
         this._pnlOptions.Dock = System.Windows.Forms.DockStyle.Right;
         this._pnlOptions.Location = new System.Drawing.Point(770, 0);
         this._pnlOptions.Name = "_pnlOptions";
         this._pnlOptions.Size = new System.Drawing.Size(109, 440);
         this._pnlOptions.TabIndex = 9;
         // 
         // _pnlViewer
         // 
         this._pnlViewer.Dock = System.Windows.Forms.DockStyle.Fill;
         this._pnlViewer.Location = new System.Drawing.Point(0, 0);
         this._pnlViewer.Name = "_pnlViewer";
         this._pnlViewer.Size = new System.Drawing.Size(770, 440);
         this._pnlViewer.TabIndex = 10;
         this._pnlViewer.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlViewer_Paint);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(879, 440);
         this.Controls.Add(this._pnlViewer);
         this.Controls.Add(this._pnlOptions);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MaximizeBox = false;
         this.Name = "MainForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "MainForm";
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this._pnlOptions.ResumeLayout(false);
         this._pnlOptions.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnEffect;
      private System.Windows.Forms.Button _btnShape;
      private System.Windows.Forms.Button _btnTransition;
      private System.Windows.Forms.Button _btnShow;
      private System.Windows.Forms.Button _btnText;
      private System.Windows.Forms.CheckBox _ckShowTransition;
      private System.Windows.Forms.CheckBox _ckShowShape;
      private System.Windows.Forms.CheckBox _ckShowText;
      private System.Windows.Forms.Panel _pnlOptions;
      private System.Windows.Forms.Panel _pnlViewer;
   }
}

