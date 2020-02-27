namespace DocumentWritersDemo
{
   partial class InsertBookmarkForm
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
         this._tbY = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this._tbX = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this._cbPageNumber = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this._tbName = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this.panel1 = new System.Windows.Forms.Panel();
         this.label7 = new System.Windows.Forms.Label();
         this.label6 = new System.Windows.Forms.Label();
         this.label5 = new System.Windows.Forms.Label();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.groupBox1.SuspendLayout();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox1
         // 
         this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.groupBox1.Controls.Add(this._tbY);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this._tbX);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this._cbPageNumber);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Controls.Add(this._tbName);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Location = new System.Drawing.Point(12, 96);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(342, 138);
         this.groupBox1.TabIndex = 0;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Bookmark Properties";
         // 
         // _tbY
         // 
         this._tbY.Location = new System.Drawing.Point(87, 101);
         this._tbY.Name = "_tbY";
         this._tbY.Size = new System.Drawing.Size(79, 20);
         this._tbY.TabIndex = 7;
         this._tbY.TextChanged += new System.EventHandler(this._tbY_TextChanged);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(6, 104);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(57, 13);
         this.label4.TabIndex = 6;
         this.label4.Text = "Position Y:";
         // 
         // _tbX
         // 
         this._tbX.Location = new System.Drawing.Point(87, 75);
         this._tbX.Name = "_tbX";
         this._tbX.Size = new System.Drawing.Size(79, 20);
         this._tbX.TabIndex = 5;
         this._tbX.TextChanged += new System.EventHandler(this._tbX_TextChanged);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(6, 78);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(57, 13);
         this.label3.TabIndex = 4;
         this.label3.Text = "Position X:";
         // 
         // _cbPageNumber
         // 
         this._cbPageNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbPageNumber.FormattingEnabled = true;
         this._cbPageNumber.Location = new System.Drawing.Point(87, 48);
         this._cbPageNumber.Name = "_cbPageNumber";
         this._cbPageNumber.Size = new System.Drawing.Size(79, 21);
         this._cbPageNumber.TabIndex = 3;
         this._cbPageNumber.SelectedIndexChanged += new System.EventHandler(this._cbPageNumber_SelectedIndexChanged);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(6, 51);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(75, 13);
         this.label2.TabIndex = 2;
         this.label2.Text = "Page Number:";
         // 
         // _tbName
         // 
         this._tbName.Location = new System.Drawing.Point(87, 22);
         this._tbName.Name = "_tbName";
         this._tbName.Size = new System.Drawing.Size(249, 20);
         this._tbName.TabIndex = 1;
         this._tbName.TextChanged += new System.EventHandler(this._tbName_TextChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 25);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(38, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Name:";
         // 
         // _btnCancel
         // 
         this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(279, 240);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 1;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnOk
         // 
         this._btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Location = new System.Drawing.Point(198, 240);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(75, 23);
         this._btnOk.TabIndex = 2;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // panel1
         // 
         this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
         this.panel1.Controls.Add(this.label7);
         this.panel1.Controls.Add(this.label6);
         this.panel1.Controls.Add(this.label5);
         this.panel1.Controls.Add(this.pictureBox1);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(366, 90);
         this.panel1.TabIndex = 3;
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label7.ForeColor = System.Drawing.Color.Red;
         this.label7.Location = new System.Drawing.Point(96, 70);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(253, 13);
         this.label7.TabIndex = 3;
         this.label7.Text = "Bookmarks are ONLY available when saving to PDF.";
         // 
         // label6
         // 
         this.label6.Location = new System.Drawing.Point(96, 29);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(265, 41);
         this.label6.TabIndex = 2;
         this.label6.Text = "You can specify the bookmark X and Y coordinates by going back to the image and c" +
             "lick where you wish the bookmark to point at.";
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.label5.Location = new System.Drawing.Point(96, 12);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(175, 13);
         this.label5.TabIndex = 1;
         this.label5.Text = "Inserting bookmarks into PDF";
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = global::DocumentWritersDemo.Properties.Resources.Bookmark;
         this.pictureBox1.Location = new System.Drawing.Point(12, 12);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(64, 64);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
         this.pictureBox1.TabIndex = 0;
         this.pictureBox1.TabStop = false;
         // 
         // InsertBookmarkForm
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(366, 275);
         this.Controls.Add(this.panel1);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this.groupBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "InsertBookmarkForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Insert Bookmark";
         this.Load += new System.EventHandler(this.InsertBookmarkForm_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.panel1.ResumeLayout(false);
         this.panel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.TextBox _tbName;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ComboBox _cbPageNumber;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.Label label6;
      private System.Windows.Forms.TextBox _tbY;
      private System.Windows.Forms.TextBox _tbX;
      private System.Windows.Forms.Label label7;
   }
}