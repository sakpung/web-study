namespace Leadtools.Medical.Winforms
{
   partial class PaginationControl
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
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaginationControl));
         this.lblPageSize = new System.Windows.Forms.Label();
         this.updownPageNumber = new System.Windows.Forms.NumericUpDown();
         this.btnGotoPage = new System.Windows.Forms.Button();
         this.btnFirst = new System.Windows.Forms.Button();
         this.btnPrevious = new System.Windows.Forms.Button();
         this.btnNext = new System.Windows.Forms.Button();
         this.btnLast = new System.Windows.Forms.Button();
         this.lblStatus = new System.Windows.Forms.Label();
         this.toolTipPagination = new System.Windows.Forms.ToolTip(this.components);
         this.numericUpDownPageSize = new System.Windows.Forms.NumericUpDown();
         ((System.ComponentModel.ISupportInitialize)(this.updownPageNumber)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPageSize)).BeginInit();
         this.SuspendLayout();
         // 
         // lblPageSize
         // 
         this.lblPageSize.Location = new System.Drawing.Point(371, 11);
         this.lblPageSize.Name = "lblPageSize";
         this.lblPageSize.Size = new System.Drawing.Size(133, 13);
         this.lblPageSize.TabIndex = 7;
         this.lblPageSize.Text = "Page Size:";
         this.lblPageSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // updownPageNumber
         // 
         this.updownPageNumber.Enabled = false;
         this.updownPageNumber.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.updownPageNumber.Location = new System.Drawing.Point(310, 7);
         this.updownPageNumber.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
         this.updownPageNumber.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this.updownPageNumber.Name = "updownPageNumber";
         this.updownPageNumber.Size = new System.Drawing.Size(55, 20);
         this.updownPageNumber.TabIndex = 6;
         this.updownPageNumber.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // btnGotoPage
         // 
         this.btnGotoPage.Enabled = false;
         this.btnGotoPage.Location = new System.Drawing.Point(223, 6);
         this.btnGotoPage.Name = "btnGotoPage";
         this.btnGotoPage.Size = new System.Drawing.Size(80, 23);
         this.btnGotoPage.TabIndex = 5;
         this.btnGotoPage.Text = "Go to Page";
         this.toolTipPagination.SetToolTip(this.btnGotoPage, "Go to Page");
         this.btnGotoPage.UseVisualStyleBackColor = true;
         this.btnGotoPage.Click += new System.EventHandler(this.btnGotoPage_Click);
         // 
         // btnFirst
         // 
         this.btnFirst.Enabled = false;
         this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
         this.btnFirst.Location = new System.Drawing.Point(16, 6);
         this.btnFirst.Name = "btnFirst";
         this.btnFirst.Size = new System.Drawing.Size(25, 23);
         this.btnFirst.TabIndex = 0;
         this.toolTipPagination.SetToolTip(this.btnFirst, "First Page");
         this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
         // 
         // btnPrevious
         // 
         this.btnPrevious.Enabled = false;
         this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
         this.btnPrevious.Location = new System.Drawing.Point(40, 6);
         this.btnPrevious.Name = "btnPrevious";
         this.btnPrevious.Size = new System.Drawing.Size(25, 23);
         this.btnPrevious.TabIndex = 1;
         this.toolTipPagination.SetToolTip(this.btnPrevious, "Previous Page");
         this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
         // 
         // btnNext
         // 
         this.btnNext.Enabled = false;
         this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
         this.btnNext.Location = new System.Drawing.Point(152, 6);
         this.btnNext.Name = "btnNext";
         this.btnNext.Size = new System.Drawing.Size(25, 23);
         this.btnNext.TabIndex = 3;
         this.toolTipPagination.SetToolTip(this.btnNext, "Next Page");
         this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
         // 
         // btnLast
         // 
         this.btnLast.Enabled = false;
         this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
         this.btnLast.Location = new System.Drawing.Point(176, 6);
         this.btnLast.Name = "btnLast";
         this.btnLast.Size = new System.Drawing.Size(25, 23);
         this.btnLast.TabIndex = 4;
         this.toolTipPagination.SetToolTip(this.btnLast, "Last Page");
         this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
         // 
         // lblStatus
         // 
         this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.lblStatus.Enabled = false;
         this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.lblStatus.Location = new System.Drawing.Point(65, 7);
         this.lblStatus.Name = "lblStatus";
         this.lblStatus.Size = new System.Drawing.Size(85, 20);
         this.lblStatus.TabIndex = 2;
         this.lblStatus.Text = "0 / 0";
         this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // numericUpDownPageSize
         // 
         this.numericUpDownPageSize.Location = new System.Drawing.Point(510, 7);
         this.numericUpDownPageSize.Name = "numericUpDownPageSize";
         this.numericUpDownPageSize.Size = new System.Drawing.Size(57, 20);
         this.numericUpDownPageSize.TabIndex = 9;
         // 
         // PaginationControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.numericUpDownPageSize);
         this.Controls.Add(this.updownPageNumber);
         this.Controls.Add(this.btnGotoPage);
         this.Controls.Add(this.lblPageSize);
         this.Controls.Add(this.lblStatus);
         this.Controls.Add(this.btnLast);
         this.Controls.Add(this.btnNext);
         this.Controls.Add(this.btnPrevious);
         this.Controls.Add(this.btnFirst);
         this.Name = "PaginationControl";
         this.Size = new System.Drawing.Size(581, 33);
         ((System.ComponentModel.ISupportInitialize)(this.updownPageNumber)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPageSize)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label lblPageSize;
      private System.Windows.Forms.NumericUpDown updownPageNumber;
      private System.Windows.Forms.Button btnGotoPage;
      private System.Windows.Forms.Button btnFirst;
      private System.Windows.Forms.Button btnPrevious;
      private System.Windows.Forms.Button btnNext;
      private System.Windows.Forms.Button btnLast;
      private System.Windows.Forms.Label lblStatus;
      private System.Windows.Forms.ToolTip toolTipPagination;
      private System.Windows.Forms.NumericUpDown numericUpDownPageSize;
   }
}
