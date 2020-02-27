namespace SpecialEffectsDemo
{
   partial class ShapeDialog
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
         this._gbShape = new System.Windows.Forms.GroupBox();
         this._cmbShapeStyle = new System.Windows.Forms.ComboBox();
         this._btnBackColor = new System.Windows.Forms.Button();
         this._lblBackColor = new System.Windows.Forms.Label();
         this._btnForeColor = new System.Windows.Forms.Button();
         this._lblForeColor = new System.Windows.Forms.Label();
         this._lblFillStyle = new System.Windows.Forms.Label();
         this._lblShapeStyle = new System.Windows.Forms.Label();
         this._cmbFillStyle = new System.Windows.Forms.ComboBox();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOK = new System.Windows.Forms.Button();
         this._gbShape.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbShape
         // 
         this._gbShape.Controls.Add(this._cmbShapeStyle);
         this._gbShape.Controls.Add(this._btnBackColor);
         this._gbShape.Controls.Add(this._lblBackColor);
         this._gbShape.Controls.Add(this._btnForeColor);
         this._gbShape.Controls.Add(this._lblForeColor);
         this._gbShape.Controls.Add(this._lblFillStyle);
         this._gbShape.Controls.Add(this._lblShapeStyle);
         this._gbShape.Controls.Add(this._cmbFillStyle);
         this._gbShape.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbShape.Location = new System.Drawing.Point(6, 1);
         this._gbShape.Name = "_gbShape";
         this._gbShape.Size = new System.Drawing.Size(319, 161);
         this._gbShape.TabIndex = 0;
         this._gbShape.TabStop = false;
         // 
         // _cmbShapeStyle
         // 
         this._cmbShapeStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbShapeStyle.FormattingEnabled = true;
         this._cmbShapeStyle.Location = new System.Drawing.Point(84, 22);
         this._cmbShapeStyle.Name = "_cmbShapeStyle";
         this._cmbShapeStyle.Size = new System.Drawing.Size(224, 21);
         this._cmbShapeStyle.TabIndex = 1;
         // 
         // _btnBackColor
         // 
         this._btnBackColor.ForeColor = System.Drawing.SystemColors.ControlText;
         this._btnBackColor.Location = new System.Drawing.Point(84, 121);
         this._btnBackColor.Name = "_btnBackColor";
         this._btnBackColor.Size = new System.Drawing.Size(75, 23);
         this._btnBackColor.TabIndex = 7;
         this._btnBackColor.Text = "\r\n";
         this._btnBackColor.UseVisualStyleBackColor = false;
         this._btnBackColor.Click += new System.EventHandler(this._btnBackColor_Click);
         // 
         // _lblBackColor
         // 
         this._lblBackColor.AutoSize = true;
         this._lblBackColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblBackColor.Location = new System.Drawing.Point(8, 125);
         this._lblBackColor.Name = "_lblBackColor";
         this._lblBackColor.Size = new System.Drawing.Size(65, 13);
         this._lblBackColor.TabIndex = 6;
         this._lblBackColor.Text = "Back Color :";
         // 
         // _btnForeColor
         // 
         this._btnForeColor.ForeColor = System.Drawing.Color.Black;
         this._btnForeColor.Location = new System.Drawing.Point(84, 87);
         this._btnForeColor.Name = "_btnForeColor";
         this._btnForeColor.Size = new System.Drawing.Size(75, 23);
         this._btnForeColor.TabIndex = 5;
         this._btnForeColor.UseVisualStyleBackColor = false;
         this._btnForeColor.Click += new System.EventHandler(this._btnForeColor_Click);
         // 
         // _lblForeColor
         // 
         this._lblForeColor.AutoSize = true;
         this._lblForeColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblForeColor.Location = new System.Drawing.Point(8, 92);
         this._lblForeColor.Name = "_lblForeColor";
         this._lblForeColor.Size = new System.Drawing.Size(58, 13);
         this._lblForeColor.TabIndex = 4;
         this._lblForeColor.Text = "Fore Color:";
         // 
         // _lblFillStyle
         // 
         this._lblFillStyle.AutoSize = true;
         this._lblFillStyle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblFillStyle.Location = new System.Drawing.Point(8, 56);
         this._lblFillStyle.Name = "_lblFillStyle";
         this._lblFillStyle.Size = new System.Drawing.Size(51, 13);
         this._lblFillStyle.TabIndex = 2;
         this._lblFillStyle.Text = "Fill Style :";
         // 
         // _lblShapeStyle
         // 
         this._lblShapeStyle.AutoSize = true;
         this._lblShapeStyle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblShapeStyle.Location = new System.Drawing.Point(8, 25);
         this._lblShapeStyle.Name = "_lblShapeStyle";
         this._lblShapeStyle.Size = new System.Drawing.Size(70, 13);
         this._lblShapeStyle.TabIndex = 0;
         this._lblShapeStyle.Text = "Shape Style :";
         // 
         // _cmbFillStyle
         // 
         this._cmbFillStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbFillStyle.FormattingEnabled = true;
         this._cmbFillStyle.Location = new System.Drawing.Point(84, 51);
         this._cmbFillStyle.Name = "_cmbFillStyle";
         this._cmbFillStyle.Size = new System.Drawing.Size(224, 21);
         this._cmbFillStyle.TabIndex = 3;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(169, 170);
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
         this._btnOK.Location = new System.Drawing.Point(88, 170);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 1;
         this._btnOK.Text = "OK\r\n";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // ShapeDialog
         // 
         this.AcceptButton = this._btnOK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(331, 201);
         this.Controls.Add(this._gbShape);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ShapeDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Shape Dialog";
         this.Load += new System.EventHandler(this.ShapeDialog_Load);
         this._gbShape.ResumeLayout(false);
         this._gbShape.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbShape;
      private System.Windows.Forms.Button _btnBackColor;
      private System.Windows.Forms.Label _lblBackColor;
      private System.Windows.Forms.Button _btnForeColor;
      private System.Windows.Forms.Label _lblForeColor;
      private System.Windows.Forms.Label _lblFillStyle;
      private System.Windows.Forms.Label _lblShapeStyle;
      private System.Windows.Forms.ComboBox _cmbFillStyle;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.ComboBox _cmbShapeStyle;

   }
}