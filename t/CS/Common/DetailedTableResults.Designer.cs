namespace FormsDemo
{
   partial class DetailedTableResults
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailedTableResults));
         this._btnOk = new System.Windows.Forms.Button();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.panel1 = new System.Windows.Forms.Panel();
         this._tableResults = new System.Windows.Forms.DataGridView();
         this.tableLayoutPanel1.SuspendLayout();
         this.panel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tableResults)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnOk
         // 
         this._btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.Location = new System.Drawing.Point(334, 6);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(52, 23);
         this._btnOk.TabIndex = 0;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 1;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this._tableResults, 0, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(725, 568);
         this.tableLayoutPanel1.TabIndex = 1;
         // 
         // panel1
         // 
         this.panel1.Controls.Add(this._btnOk);
         this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel1.Location = new System.Drawing.Point(3, 532);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(719, 33);
         this.panel1.TabIndex = 1;
         // 
         // _tableResults
         // 
         this._tableResults.AllowUserToAddRows = false;
         this._tableResults.AllowUserToDeleteRows = false;
         this._tableResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
         this._tableResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this._tableResults.Dock = System.Windows.Forms.DockStyle.Fill;
         this._tableResults.Location = new System.Drawing.Point(3, 3);
         this._tableResults.Name = "_tableResults";
         this._tableResults.ReadOnly = true;
         this._tableResults.Size = new System.Drawing.Size(719, 523);
         this._tableResults.TabIndex = 2;
         this._tableResults.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._tableResults_MouseDoubleClick);
         // 
         // DetailedTableResults
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(725, 568);
         this.Controls.Add(this.tableLayoutPanel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "DetailedTableResults";
         this.Text = "Detailed Table Results";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.panel1.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._tableResults)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Panel panel1;
      private System.Windows.Forms.DataGridView _tableResults;

   }
}