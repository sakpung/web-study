namespace GrayScaleDemo
{
   partial class SRADFilterDialog
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
         this.label4 = new System.Windows.Forms.Label();
         this._numIterations = new System.Windows.Forms.NumericUpDown();
         this.label1 = new System.Windows.Forms.Label();
         this._numLambda = new System.Windows.Forms.NumericUpDown();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numIterations)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLambda)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this._numIterations);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this._numLambda);
         this.groupBox1.Location = new System.Drawing.Point(16, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(271, 83);
         this.groupBox1.TabIndex = 5;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Parameters";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(31, 26);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(50, 13);
         this.label4.TabIndex = 10;
         this.label4.Text = "Iterations";
         // 
         // _numIterations
         // 
         this._numIterations.Location = new System.Drawing.Point(119, 19);
         this._numIterations.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
         this._numIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numIterations.Name = "_numIterations";
         this._numIterations.Size = new System.Drawing.Size(120, 20);
         this._numIterations.TabIndex = 9;
         this._numIterations.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(31, 53);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(45, 13);
         this.label1.TabIndex = 6;
         this.label1.Text = "Lambda";
         // 
         // _numLambda
         // 
         this._numLambda.Location = new System.Drawing.Point(119, 46);
         this._numLambda.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numLambda.Name = "_numLambda";
         this._numLambda.Size = new System.Drawing.Size(120, 20);
         this._numLambda.TabIndex = 3;
         this._numLambda.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(154, 110);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 4;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(73, 110);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 3;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // SRADFilterDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(303, 149);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SRADFilterDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "SRAD Anistropic";
         this.Load += new System.EventHandler(this.SRADFilterDialog_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numIterations)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLambda)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.NumericUpDown _numIterations;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.NumericUpDown _numLambda;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
   }
}