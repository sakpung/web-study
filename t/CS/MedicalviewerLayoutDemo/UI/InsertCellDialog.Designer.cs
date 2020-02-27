namespace MedicalViewerLayoutDemo
{
   partial class InsertCellDialog
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
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this._btnOK = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this.label1 = new System.Windows.Forms.Label();
          this.ltx = new System.Windows.Forms.NumericUpDown();
          this.lty = new System.Windows.Forms.NumericUpDown();
          this.label2 = new System.Windows.Forms.Label();
          this.label4 = new System.Windows.Forms.Label();
          this.label5 = new System.Windows.Forms.Label();
          this.label3 = new System.Windows.Forms.Label();
          this.label6 = new System.Windows.Forms.Label();
          this.rby = new System.Windows.Forms.NumericUpDown();
          this.rbx = new System.Windows.Forms.NumericUpDown();
          this.groupBox1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.ltx)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.lty)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.rby)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this.rbx)).BeginInit();
          this.SuspendLayout();
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this.label3);
          this.groupBox1.Controls.Add(this.label6);
          this.groupBox1.Controls.Add(this.rby);
          this.groupBox1.Controls.Add(this.rbx);
          this.groupBox1.Controls.Add(this.label5);
          this.groupBox1.Controls.Add(this.label4);
          this.groupBox1.Controls.Add(this.label2);
          this.groupBox1.Controls.Add(this.lty);
          this.groupBox1.Controls.Add(this.ltx);
          this.groupBox1.Controls.Add(this.label1);
          this.groupBox1.Location = new System.Drawing.Point(9, 2);
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.Size = new System.Drawing.Size(151, 173);
          this.groupBox1.TabIndex = 2;
          this.groupBox1.TabStop = false;
          this.groupBox1.Text = "&New Cell Position";
          // 
          // _btnOK
          // 
          this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
          this._btnOK.Location = new System.Drawing.Point(12, 181);
          this._btnOK.Name = "_btnOK";
          this._btnOK.Size = new System.Drawing.Size(71, 29);
          this._btnOK.TabIndex = 0;
          this._btnOK.Text = "&OK";
          this._btnOK.UseVisualStyleBackColor = true;
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnCancel.Location = new System.Drawing.Point(89, 181);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(71, 29);
          this._btnCancel.TabIndex = 1;
          this._btnCancel.Text = "C&anc&el";
          this._btnCancel.UseVisualStyleBackColor = true;
          // 
          // label1
          // 
          this.label1.AutoSize = true;
          this.label1.Location = new System.Drawing.Point(7, 20);
          this.label1.Name = "label1";
          this.label1.Size = new System.Drawing.Size(50, 13);
          this.label1.TabIndex = 0;
          this.label1.Text = "Top Left:";
          // 
          // ltx
          // 
          this.ltx.DecimalPlaces = 2;
          this.ltx.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
          this.ltx.Location = new System.Drawing.Point(46, 36);
          this.ltx.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this.ltx.Name = "ltx";
          this.ltx.Size = new System.Drawing.Size(66, 20);
          this.ltx.TabIndex = 0;
          // 
          // lty
          // 
          this.lty.DecimalPlaces = 2;
          this.lty.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
          this.lty.Location = new System.Drawing.Point(46, 62);
          this.lty.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this.lty.Name = "lty";
          this.lty.Size = new System.Drawing.Size(66, 20);
          this.lty.TabIndex = 1;
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(7, 94);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(71, 13);
          this.label2.TabIndex = 3;
          this.label2.Text = "Right Bottom:";
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(23, 43);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(17, 13);
          this.label4.TabIndex = 8;
          this.label4.Text = "X:";
          // 
          // label5
          // 
          this.label5.AutoSize = true;
          this.label5.Location = new System.Drawing.Point(23, 69);
          this.label5.Name = "label5";
          this.label5.Size = new System.Drawing.Size(17, 13);
          this.label5.TabIndex = 9;
          this.label5.Text = "Y:";
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(23, 142);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(17, 13);
          this.label3.TabIndex = 13;
          this.label3.Text = "Y:";
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(23, 116);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(17, 13);
          this.label6.TabIndex = 12;
          this.label6.Text = "X:";
          // 
          // rby
          // 
          this.rby.DecimalPlaces = 2;
          this.rby.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
          this.rby.Location = new System.Drawing.Point(46, 135);
          this.rby.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this.rby.Name = "rby";
          this.rby.Size = new System.Drawing.Size(66, 20);
          this.rby.TabIndex = 3;
          // 
          // rbx
          // 
          this.rbx.DecimalPlaces = 2;
          this.rbx.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
          this.rbx.Location = new System.Drawing.Point(46, 109);
          this.rbx.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this.rbx.Name = "rbx";
          this.rbx.Size = new System.Drawing.Size(66, 20);
          this.rbx.TabIndex = 2;
          // 
          // InsertCellDialog
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(171, 217);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOK);
          this.Controls.Add(this.groupBox1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "InsertCellDialog";
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
          this.Text = "Insert Cell";
          this.Load += new System.EventHandler(this.InsertCellDialog_Load);
          this.Shown += new System.EventHandler(this.InsertCellDialog_Shown);
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InsertCellDialog_FormClosing);
          this.groupBox1.ResumeLayout(false);
          this.groupBox1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this.ltx)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.lty)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.rby)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this.rbx)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

       private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
       private System.Windows.Forms.Label label1;
       private System.Windows.Forms.Label label3;
       private System.Windows.Forms.Label label6;
       private System.Windows.Forms.NumericUpDown rby;
       private System.Windows.Forms.NumericUpDown rbx;
       private System.Windows.Forms.Label label5;
       private System.Windows.Forms.Label label4;
       private System.Windows.Forms.Label label2;
       private System.Windows.Forms.NumericUpDown lty;
       private System.Windows.Forms.NumericUpDown ltx;
   }
}