namespace MedicalViewerDemo
{
   partial class StatisticsDialog
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
         this._areaLbl = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this._heightLbl = new System.Windows.Forms.Label();
         this._widthLbl = new System.Windows.Forms.Label();
         this._yLbl = new System.Windows.Forms.Label();
         this._xLbl = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this._hasRegionLbl = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._btnOK = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._areaLbl);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this._heightLbl);
         this.groupBox1.Controls.Add(this._widthLbl);
         this.groupBox1.Controls.Add(this._yLbl);
         this.groupBox1.Controls.Add(this._xLbl);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this._hasRegionLbl);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(7, 5);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(317, 131);
         this.groupBox1.TabIndex = 15;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Current Region Statistics";
         // 
         // _areaLbl
         // 
         this._areaLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._areaLbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
         this._areaLbl.Location = new System.Drawing.Point(100, 91);
         this._areaLbl.Name = "_areaLbl";
         this._areaLbl.Size = new System.Drawing.Size(97, 23);
         this._areaLbl.TabIndex = 8;
         this._areaLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(10, 96);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(70, 13);
         this.label3.TabIndex = 7;
         this.label3.Text = "Region Area:";
         // 
         // _heightLbl
         // 
         this._heightLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._heightLbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
         this._heightLbl.Location = new System.Drawing.Point(262, 53);
         this._heightLbl.Name = "_heightLbl";
         this._heightLbl.Size = new System.Drawing.Size(47, 23);
         this._heightLbl.TabIndex = 6;
         this._heightLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _widthLbl
         // 
         this._widthLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._widthLbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
         this._widthLbl.Location = new System.Drawing.Point(208, 53);
         this._widthLbl.Name = "_widthLbl";
         this._widthLbl.Size = new System.Drawing.Size(47, 23);
         this._widthLbl.TabIndex = 5;
         this._widthLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _yLbl
         // 
         this._yLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._yLbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
         this._yLbl.Location = new System.Drawing.Point(154, 53);
         this._yLbl.Name = "_yLbl";
         this._yLbl.Size = new System.Drawing.Size(47, 23);
         this._yLbl.TabIndex = 4;
         this._yLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _xLbl
         // 
         this._xLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._xLbl.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
         this._xLbl.Location = new System.Drawing.Point(100, 53);
         this._xLbl.Name = "_xLbl";
         this._xLbl.Size = new System.Drawing.Size(47, 23);
         this._xLbl.TabIndex = 3;
         this._xLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(10, 58);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(82, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Region Bounds:";
         // 
         // _hasRegionLbl
         // 
         this._hasRegionLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
         this._hasRegionLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._hasRegionLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._hasRegionLbl.Location = new System.Drawing.Point(100, 15);
         this._hasRegionLbl.Name = "_hasRegionLbl";
         this._hasRegionLbl.Size = new System.Drawing.Size(40, 23);
         this._hasRegionLbl.TabIndex = 1;
         this._hasRegionLbl.Text = "False";
         this._hasRegionLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(10, 20);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(65, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Has Region:";
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnOK.Location = new System.Drawing.Point(132, 142);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(72, 29);
         this._btnOK.TabIndex = 17;
         this._btnOK.Text = "&OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this.okButton_Click);
         // 
         // StatisticsDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnOK;
         this.ClientSize = new System.Drawing.Size(336, 176);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "StatisticsDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Region Statistics";
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Label _areaLbl;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label _heightLbl;
      private System.Windows.Forms.Label _widthLbl;
      private System.Windows.Forms.Label _yLbl;
      private System.Windows.Forms.Label _xLbl;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label _hasRegionLbl;
      private System.Windows.Forms.Label label1;
   }
}