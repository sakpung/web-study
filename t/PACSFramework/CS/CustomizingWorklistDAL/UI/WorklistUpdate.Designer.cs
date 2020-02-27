namespace CSCustomizingWorklistDAL.UI
{
   partial class WorklistUpdate
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
         this.QueryButton = new System.Windows.Forms.Button();
         this.UpdateButton = new System.Windows.Forms.Button();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.label1 = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // QueryButton
         // 
         this.QueryButton.Location = new System.Drawing.Point(3, 23);
         this.QueryButton.Name = "QueryButton";
         this.QueryButton.Size = new System.Drawing.Size(122, 37);
         this.QueryButton.TabIndex = 1;
         this.QueryButton.Text = "Query";
         this.QueryButton.UseVisualStyleBackColor = true;
         // 
         // UpdateButton
         // 
         this.UpdateButton.Location = new System.Drawing.Point(131, 24);
         this.UpdateButton.Name = "UpdateButton";
         this.UpdateButton.Size = new System.Drawing.Size(122, 37);
         this.UpdateButton.TabIndex = 2;
         this.UpdateButton.Text = "Update";
         this.UpdateButton.UseVisualStyleBackColor = true;
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.AutoScroll = true;
         this.tableLayoutPanel1.ColumnCount = 1;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 66);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(946, 184);
         this.tableLayoutPanel1.TabIndex = 3;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(4, 4);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(945, 13);
         this.label1.TabIndex = 4;
         this.label1.Text = "Click \"Query\" to display the database tables where the columns that holds the new" +
             " DICOM Tags values. You can edit the values from the grid view and click \"Update" +
             "\" to store them into the database.";
         // 
         // WorklistUpdate
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.AutoSize = true;
         this.Controls.Add(this.label1);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Controls.Add(this.UpdateButton);
         this.Controls.Add(this.QueryButton);
         this.Name = "WorklistUpdate";
         this.Size = new System.Drawing.Size(952, 253);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button QueryButton;
      private System.Windows.Forms.Button UpdateButton;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Label label1;

   }
}
