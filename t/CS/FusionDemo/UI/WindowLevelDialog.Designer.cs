namespace FusionDemo.UI
{
   partial class WindowLevelDialog
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
         this._btnOk = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._ = new System.Windows.Forms.Label();
         this._lblStart = new System.Windows.Forms.Label();
         this._numWidth = new System.Windows.Forms.NumericUpDown();
         this._numLevel = new System.Windows.Forms.NumericUpDown();
         this._btnCancel = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLevel)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Location = new System.Drawing.Point(225, 40);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 0;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._);
         this.groupBox1.Controls.Add(this._lblStart);
         this.groupBox1.Controls.Add(this._numWidth);
         this.groupBox1.Controls.Add(this._numLevel);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(200, 120);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "W/L Values";
         // 
         // _
         // 
         this._.AutoSize = true;
         this._.Location = new System.Drawing.Point(19, 75);
         this._.Name = "_";
         this._.Size = new System.Drawing.Size(35, 13);
         this._.TabIndex = 3;
         this._.Text = "Width";
         // 
         // _lblStart
         // 
         this._lblStart.AutoSize = true;
         this._lblStart.Location = new System.Drawing.Point(19, 33);
         this._lblStart.Name = "_lblStart";
         this._lblStart.Size = new System.Drawing.Size(33, 13);
         this._lblStart.TabIndex = 2;
         this._lblStart.Text = "Level";
         // 
         // _numWidth
         // 
         this._numWidth.Location = new System.Drawing.Point(74, 73);
         this._numWidth.Name = "_numWidth";
         this._numWidth.Size = new System.Drawing.Size(120, 20);
         this._numWidth.TabIndex = 1;
         // 
         // _numLevel
         // 
         this._numLevel.Location = new System.Drawing.Point(74, 31);
         this._numLevel.Name = "_numLevel";
         this._numLevel.Size = new System.Drawing.Size(120, 20);
         this._numLevel.TabIndex = 0;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(225, 69);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // WindowLevelDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(329, 153);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "WindowLevelDialog";
         this.Text = "Window Level Dialog";
         this.Load += new System.EventHandler(this.WindowLevelDialog_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLevel)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label _;
      private System.Windows.Forms.Label _lblStart;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.NumericUpDown _numLevel;
      private System.Windows.Forms.Button _btnCancel;
   }
}