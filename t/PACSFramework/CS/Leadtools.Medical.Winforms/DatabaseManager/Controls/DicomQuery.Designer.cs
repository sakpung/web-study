namespace Leadtools.Medical.Winforms
{
   partial class DicomQuery
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DicomQuery));
         this.btnSearch = new System.Windows.Forms.Button();
         this.btnClear = new System.Windows.Forms.Button();
         this.btnCancel = new System.Windows.Forms.Button();
         this.searchStandard = new Leadtools.Medical.Winforms.DatabaseManager.Controls.SearchStandard();
         this.searchHangingProtocol = new Leadtools.Medical.Winforms.DatabaseManager.Controls.SearchHangingProtocol();
         this.SuspendLayout();
         // 
         // btnSearch
         // 
         this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnSearch.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
         this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
         this.btnSearch.Location = new System.Drawing.Point(935, 9);
         this.btnSearch.Name = "btnSearch";
         this.btnSearch.Size = new System.Drawing.Size(65, 65);
         this.btnSearch.TabIndex = 6;
         this.btnSearch.UseVisualStyleBackColor = false;
         // 
         // btnClear
         // 
         this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnClear.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
         this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
         this.btnClear.Location = new System.Drawing.Point(935, 163);
         this.btnClear.Name = "btnClear";
         this.btnClear.Size = new System.Drawing.Size(65, 65);
         this.btnClear.TabIndex = 8;
         this.btnClear.UseVisualStyleBackColor = false;
         // 
         // btnCancel
         // 
         this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.btnCancel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
         this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
         this.btnCancel.Location = new System.Drawing.Point(935, 86);
         this.btnCancel.Name = "btnCancel";
         this.btnCancel.Size = new System.Drawing.Size(65, 65);
         this.btnCancel.TabIndex = 7;
         this.btnCancel.UseVisualStyleBackColor = false;
         // 
         // searchStandard
         // 
         this.searchStandard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.searchStandard.Location = new System.Drawing.Point(0, 1);
         this.searchStandard.Name = "searchStandard";
         this.searchStandard.Size = new System.Drawing.Size(929, 232);
         this.searchStandard.TabIndex = 9;
         // 
         // searchHangingProtocol
         // 
         this.searchHangingProtocol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.searchHangingProtocol.Location = new System.Drawing.Point(0, 1);
         this.searchHangingProtocol.Name = "searchHangingProtocol";
         this.searchHangingProtocol.Size = new System.Drawing.Size(929, 232);
         this.searchHangingProtocol.TabIndex = 10;
         this.searchHangingProtocol.Visible = false;
         // 
         // DicomQuery
         // 
         this.Controls.Add(this.searchHangingProtocol);
         this.Controls.Add(this.searchStandard);
         this.Controls.Add(this.btnSearch);
         this.Controls.Add(this.btnCancel);
         this.Controls.Add(this.btnClear);
         this.ForeColor = System.Drawing.Color.White;
         this.Name = "DicomQuery";
         this.Size = new System.Drawing.Size(1018, 236);
         this.State = Leadtools.Medical.Workstation.UI.AutoHidePanelState.Expanded;
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button btnSearch;
      private System.Windows.Forms.Button btnClear;
      private System.Windows.Forms.Button btnCancel;
      private DatabaseManager.Controls.SearchStandard searchStandard;
      private DatabaseManager.Controls.SearchHangingProtocol searchHangingProtocol;
   }
}
