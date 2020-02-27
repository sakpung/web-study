namespace Leadtools.Medical.Winforms
{
   partial class AutoCopyView
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.tabControl1 = new System.Windows.Forms.TabControl();
         this.tabPageRelation = new System.Windows.Forms.TabPage();
         this.listViewAutoCopy = new System.Windows.Forms.ListView();
         this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
         this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.comboBoxSource = new System.Windows.Forms.ComboBox();
         this.tabPageAdvanced = new System.Windows.Forms.TabPage();
         this.groupBox3 = new System.Windows.Forms.GroupBox();
         this.numericUpDownThreads = new System.Windows.Forms.NumericUpDown();
         this.label4 = new System.Windows.Forms.Label();
         this.textBoxCustomAE = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.checkBoxCustomAE = new System.Windows.Forms.CheckBox();
         this.checkBoxAutoCopy = new System.Windows.Forms.CheckBox();
         this.groupBox2.SuspendLayout();
         this.tabControl1.SuspendLayout();
         this.tabPageRelation.SuspendLayout();
         this.tabPageAdvanced.SuspendLayout();
         this.groupBox3.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).BeginInit();
         this.SuspendLayout();
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.tabControl1);
         this.groupBox2.Controls.Add(this.checkBoxAutoCopy);
         this.groupBox2.Location = new System.Drawing.Point(3, 3);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(485, 343);
         this.groupBox2.TabIndex = 2;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "Auto Copy";
         // 
         // tabControl1
         // 
         this.tabControl1.Controls.Add(this.tabPageRelation);
         this.tabControl1.Controls.Add(this.tabPageAdvanced);
         this.tabControl1.Location = new System.Drawing.Point(26, 44);
         this.tabControl1.Name = "tabControl1";
         this.tabControl1.SelectedIndex = 0;
         this.tabControl1.Size = new System.Drawing.Size(439, 293);
         this.tabControl1.TabIndex = 1;
         // 
         // tabPageRelation
         // 
         this.tabPageRelation.Controls.Add(this.listViewAutoCopy);
         this.tabPageRelation.Controls.Add(this.label1);
         this.tabPageRelation.Controls.Add(this.label2);
         this.tabPageRelation.Controls.Add(this.comboBoxSource);
         this.tabPageRelation.Location = new System.Drawing.Point(4, 22);
         this.tabPageRelation.Name = "tabPageRelation";
         this.tabPageRelation.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageRelation.Size = new System.Drawing.Size(431, 267);
         this.tabPageRelation.TabIndex = 0;
         this.tabPageRelation.Text = "AE Relation";
         this.tabPageRelation.UseVisualStyleBackColor = true;
         // 
         // listViewAutoCopy
         // 
         this.listViewAutoCopy.CheckBoxes = true;
         this.listViewAutoCopy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
         this.listViewAutoCopy.Enabled = false;
         this.listViewAutoCopy.Location = new System.Drawing.Point(9, 61);
         this.listViewAutoCopy.Name = "listViewAutoCopy";
         this.listViewAutoCopy.Size = new System.Drawing.Size(412, 200);
         this.listViewAutoCopy.TabIndex = 4;
         this.listViewAutoCopy.UseCompatibleStateImageBehavior = false;
         this.listViewAutoCopy.View = System.Windows.Forms.View.Details;
         // 
         // columnHeader1
         // 
         this.columnHeader1.Text = "AE Title";
         this.columnHeader1.Width = 100;
         // 
         // columnHeader2
         // 
         this.columnHeader2.Text = "IP Address";
         this.columnHeader2.Width = 100;
         // 
         // columnHeader3
         // 
         this.columnHeader3.Text = "Port";
         this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(6, 3);
         this.label1.Name = "label1";
         this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
         this.label1.Size = new System.Drawing.Size(86, 13);
         this.label1.TabIndex = 1;
         this.label1.Text = "When moved to:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(6, 44);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(182, 13);
         this.label2.TabIndex = 3;
         this.label2.Text = "Automatically Copy To (Dicom Store):";
         // 
         // comboBoxSource
         // 
         this.comboBoxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBoxSource.FormattingEnabled = true;
         this.comboBoxSource.Location = new System.Drawing.Point(9, 20);
         this.comboBoxSource.Name = "comboBoxSource";
         this.comboBoxSource.Size = new System.Drawing.Size(412, 21);
         this.comboBoxSource.TabIndex = 2;
         // 
         // tabPageAdvanced
         // 
         this.tabPageAdvanced.Controls.Add(this.groupBox3);
         this.tabPageAdvanced.Controls.Add(this.textBoxCustomAE);
         this.tabPageAdvanced.Controls.Add(this.label3);
         this.tabPageAdvanced.Controls.Add(this.checkBoxCustomAE);
         this.tabPageAdvanced.Location = new System.Drawing.Point(4, 22);
         this.tabPageAdvanced.Name = "tabPageAdvanced";
         this.tabPageAdvanced.Padding = new System.Windows.Forms.Padding(3);
         this.tabPageAdvanced.Size = new System.Drawing.Size(431, 267);
         this.tabPageAdvanced.TabIndex = 1;
         this.tabPageAdvanced.Text = "Advanced";
         this.tabPageAdvanced.UseVisualStyleBackColor = true;
         // 
         // groupBox3
         // 
         this.groupBox3.Controls.Add(this.numericUpDownThreads);
         this.groupBox3.Controls.Add(this.label4);
         this.groupBox3.Location = new System.Drawing.Point(6, 69);
         this.groupBox3.Name = "groupBox3";
         this.groupBox3.Size = new System.Drawing.Size(222, 65);
         this.groupBox3.TabIndex = 7;
         this.groupBox3.TabStop = false;
         this.groupBox3.Text = "Auto Copy Processing Threads";
         // 
         // numericUpDownThreads
         // 
         this.numericUpDownThreads.Location = new System.Drawing.Point(59, 24);
         this.numericUpDownThreads.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
         this.numericUpDownThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this.numericUpDownThreads.Name = "numericUpDownThreads";
         this.numericUpDownThreads.Size = new System.Drawing.Size(120, 20);
         this.numericUpDownThreads.TabIndex = 1;
         this.numericUpDownThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(6, 31);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(47, 13);
         this.label4.TabIndex = 0;
         this.label4.Text = "Number:";
         // 
         // textBoxCustomAE
         // 
         this.textBoxCustomAE.Location = new System.Drawing.Point(97, 23);
         this.textBoxCustomAE.Name = "textBoxCustomAE";
         this.textBoxCustomAE.Size = new System.Drawing.Size(131, 20);
         this.textBoxCustomAE.TabIndex = 6;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(29, 30);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(62, 13);
         this.label3.TabIndex = 5;
         this.label3.Text = "Custom AE:";
         // 
         // checkBoxCustomAE
         // 
         this.checkBoxCustomAE.AutoSize = true;
         this.checkBoxCustomAE.Location = new System.Drawing.Point(6, 6);
         this.checkBoxCustomAE.Name = "checkBoxCustomAE";
         this.checkBoxCustomAE.Size = new System.Drawing.Size(123, 17);
         this.checkBoxCustomAE.TabIndex = 4;
         this.checkBoxCustomAE.Text = "Use Custom AE Title";
         this.checkBoxCustomAE.UseVisualStyleBackColor = true;
         // 
         // checkBoxAutoCopy
         // 
         this.checkBoxAutoCopy.AutoSize = true;
         this.checkBoxAutoCopy.Location = new System.Drawing.Point(7, 20);
         this.checkBoxAutoCopy.Name = "checkBoxAutoCopy";
         this.checkBoxAutoCopy.Size = new System.Drawing.Size(59, 17);
         this.checkBoxAutoCopy.TabIndex = 0;
         this.checkBoxAutoCopy.Text = "Enable";
         this.checkBoxAutoCopy.UseVisualStyleBackColor = true;
         // 
         // AutoCopyView
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox2);
         this.Name = "AutoCopyView";
         this.Size = new System.Drawing.Size(490, 349);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         this.tabControl1.ResumeLayout(false);
         this.tabPageRelation.ResumeLayout(false);
         this.tabPageRelation.PerformLayout();
         this.tabPageAdvanced.ResumeLayout(false);
         this.tabPageAdvanced.PerformLayout();
         this.groupBox3.ResumeLayout(false);
         this.groupBox3.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThreads)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.TabControl tabControl1;
      private System.Windows.Forms.TabPage tabPageRelation;
      private System.Windows.Forms.ListView listViewAutoCopy;
      private System.Windows.Forms.ColumnHeader columnHeader1;
      private System.Windows.Forms.ColumnHeader columnHeader2;
      private System.Windows.Forms.ColumnHeader columnHeader3;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.ComboBox comboBoxSource;
      private System.Windows.Forms.TabPage tabPageAdvanced;
      private System.Windows.Forms.GroupBox groupBox3;
      private System.Windows.Forms.NumericUpDown numericUpDownThreads;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox textBoxCustomAE;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.CheckBox checkBoxCustomAE;
      private System.Windows.Forms.CheckBox checkBoxAutoCopy;
   }
}
