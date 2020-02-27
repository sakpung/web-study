namespace CSCustomizingWorklistDAL.UI
{
   partial class DicomTags
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
         this.label1 = new System.Windows.Forms.Label();
         this.ColumnTagsListView = new System.Windows.Forms.ListView();
         this.TableColumnHeader = new System.Windows.Forms.ColumnHeader();
         this.TableColumnColumnHeader = new System.Windows.Forms.ColumnHeader();
         this.TagColumnHeader = new System.Windows.Forms.ColumnHeader();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(3, 6);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(445, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "The following columns will be added to the database to map the corresponding DICO" +
             "M Tags:";
         // 
         // ColumnTagsListView
         // 
         this.ColumnTagsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this.ColumnTagsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TableColumnHeader,
            this.TableColumnColumnHeader,
            this.TagColumnHeader});
         this.ColumnTagsListView.Location = new System.Drawing.Point(6, 25);
         this.ColumnTagsListView.Name = "ColumnTagsListView";
         this.ColumnTagsListView.Size = new System.Drawing.Size(439, 125);
         this.ColumnTagsListView.TabIndex = 1;
         this.ColumnTagsListView.UseCompatibleStateImageBehavior = false;
         this.ColumnTagsListView.View = System.Windows.Forms.View.Details;
         // 
         // TableColumnHeader
         // 
         this.TableColumnHeader.Text = "Table Name";
         this.TableColumnHeader.Width = 156;
         // 
         // TableColumnColumnHeader
         // 
         this.TableColumnColumnHeader.Text = "Column";
         this.TableColumnColumnHeader.Width = 151;
         // 
         // TagColumnHeader
         // 
         this.TagColumnHeader.Text = "DICOM Tag";
         this.TagColumnHeader.Width = 121;
         // 
         // DicomTags
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.ColumnTagsListView);
         this.Controls.Add(this.label1);
         this.Name = "DicomTags";
         this.Size = new System.Drawing.Size(455, 159);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ListView ColumnTagsListView;
      private System.Windows.Forms.ColumnHeader TableColumnHeader;
      private System.Windows.Forms.ColumnHeader TableColumnColumnHeader;
      private System.Windows.Forms.ColumnHeader TagColumnHeader;
   }
}
