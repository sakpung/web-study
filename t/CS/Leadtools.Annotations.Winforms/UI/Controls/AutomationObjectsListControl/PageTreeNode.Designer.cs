namespace Leadtools.Annotations.WinForms
{
   partial class PageTreeNode
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
         this._lblBottomSeparetor = new System.Windows.Forms.Label();
         this._lblPageNumber = new System.Windows.Forms.Label();
         this._btnCollapseExpand = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lblBottomSeparetor
         // 
         this._lblBottomSeparetor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
         this._lblBottomSeparetor.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._lblBottomSeparetor.Location = new System.Drawing.Point(0, 34);
         this._lblBottomSeparetor.Name = "_lblBottomSeparetor";
         this._lblBottomSeparetor.Size = new System.Drawing.Size(235, 1);
         this._lblBottomSeparetor.TabIndex = 10;
         this._lblBottomSeparetor.Click += new System.EventHandler(this.PageTreeNode_Click);
         // 
         // _lblPageNumber
         // 
         this._lblPageNumber.AutoSize = true;
         this._lblPageNumber.Location = new System.Drawing.Point(28, 13);
         this._lblPageNumber.Name = "_lblPageNumber";
         this._lblPageNumber.Size = new System.Drawing.Size(47, 13);
         this._lblPageNumber.TabIndex = 2;
         this._lblPageNumber.Text = "[Page 0]";
         this._lblPageNumber.Click += new System.EventHandler(this.PageTreeNode_Click);
         // 
         // _btnCollapseExpand
         // 
         this._btnCollapseExpand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._btnCollapseExpand.Location = new System.Drawing.Point(2, 10);
         this._btnCollapseExpand.Name = "_btnCollapseExpand";
         this._btnCollapseExpand.Size = new System.Drawing.Size(20, 20);
         this._btnCollapseExpand.TabIndex = 1;
         this._btnCollapseExpand.Text = "+";
         this._btnCollapseExpand.UseVisualStyleBackColor = true;
         this._btnCollapseExpand.Click += new System.EventHandler(this._btnCollapseExpand_Click);
         // 
         // PageTreeNode
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.Controls.Add(this._lblBottomSeparetor);
         this.Controls.Add(this._lblPageNumber);
         this.Controls.Add(this._btnCollapseExpand);
         this.MinimumSize = new System.Drawing.Size(235, 40);
         this.Name = "PageTreeNode";
         this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
         this.Size = new System.Drawing.Size(235, 40);
         this.Click += new System.EventHandler(this.PageTreeNode_Click);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnCollapseExpand;
      private System.Windows.Forms.Label _lblPageNumber;
      private System.Windows.Forms.Label _lblBottomSeparetor;
   }
}
