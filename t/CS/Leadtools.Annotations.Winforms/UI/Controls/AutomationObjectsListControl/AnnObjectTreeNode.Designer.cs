namespace Leadtools.Annotations.WinForms
{
   partial class AnnObjectTreeNode
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
         this._btnCollapseExpand = new System.Windows.Forms.Button();
         this._pbObjetIcon = new System.Windows.Forms.PictureBox();
         this._annNodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._miExpandCollapse = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
         this._miReply = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
         this._miDelete = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
         this._miProperties = new System.Windows.Forms.ToolStripMenuItem();
         this._lblAuthor = new System.Windows.Forms.Label();
         this._lblObjectName = new System.Windows.Forms.Label();
         this._lblDate = new System.Windows.Forms.Label();
         this._tbComment = new System.Windows.Forms.TextBox();
         this._lblBottomSeparetor = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this._pbObjetIcon)).BeginInit();
         this._annNodeContextMenu.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnCollapseExpand
         // 
         this._btnCollapseExpand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this._btnCollapseExpand.Location = new System.Drawing.Point(2, 16);
         this._btnCollapseExpand.Name = "_btnCollapseExpand";
         this._btnCollapseExpand.Size = new System.Drawing.Size(20, 20);
         this._btnCollapseExpand.TabIndex = 0;
         this._btnCollapseExpand.Text = "+";
         this._btnCollapseExpand.UseVisualStyleBackColor = true;
         this._btnCollapseExpand.Click += new System.EventHandler(this._btnCollapseExpand_Click);
         // 
         // _pbObjetIcon
         // 
         this._pbObjetIcon.ContextMenuStrip = this._annNodeContextMenu;
         this._pbObjetIcon.Location = new System.Drawing.Point(41, 17);
         this._pbObjetIcon.Name = "_pbObjetIcon";
         this._pbObjetIcon.Size = new System.Drawing.Size(20, 20);
         this._pbObjetIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this._pbObjetIcon.TabIndex = 2;
         this._pbObjetIcon.TabStop = false;
         this._pbObjetIcon.DoubleClick += new System.EventHandler(this.AnnObjectTreeNode_DoubleClick);
         this._pbObjetIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnnObjectTreeNode_MouseDown);
         // 
         // _annNodeContextMenu
         // 
         this._annNodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miExpandCollapse,
            this.toolStripMenuItem1,
            this._miReply,
            this.toolStripMenuItem2,
            this._miDelete,
            this.toolStripMenuItem3,
            this._miProperties});
         this._annNodeContextMenu.Name = "_reviewNodeContextMenu";
         this._annNodeContextMenu.Size = new System.Drawing.Size(137, 110);
         this._annNodeContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this._annNodeContextMenu_Opening);
         // 
         // _miExpandCollapse
         // 
         this._miExpandCollapse.Name = "_miExpandCollapse";
         this._miExpandCollapse.Size = new System.Drawing.Size(136, 22);
         this._miExpandCollapse.Text = "Expand";
         this._miExpandCollapse.Click += new System.EventHandler(this._miExpandCollapse_Click);
         // 
         // toolStripMenuItem1
         // 
         this.toolStripMenuItem1.Name = "toolStripMenuItem1";
         this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
         // 
         // _miReply
         // 
         this._miReply.Name = "_miReply";
         this._miReply.Size = new System.Drawing.Size(136, 22);
         this._miReply.Text = "Reply";
         this._miReply.Click += new System.EventHandler(this._replyReview_Click);
         // 
         // toolStripMenuItem2
         // 
         this.toolStripMenuItem2.Name = "toolStripMenuItem2";
         this.toolStripMenuItem2.Size = new System.Drawing.Size(133, 6);
         // 
         // _miDelete
         // 
         this._miDelete.Name = "_miDelete";
         this._miDelete.Size = new System.Drawing.Size(136, 22);
         this._miDelete.Text = "Delete";
         this._miDelete.Click += new System.EventHandler(this._miDelete_Click);
         // 
         // toolStripMenuItem3
         // 
         this.toolStripMenuItem3.Name = "toolStripMenuItem3";
         this.toolStripMenuItem3.Size = new System.Drawing.Size(133, 6);
         // 
         // _miProperties
         // 
         this._miProperties.Name = "_miProperties";
         this._miProperties.Size = new System.Drawing.Size(136, 22);
         this._miProperties.Text = "Properties...";
         this._miProperties.Click += new System.EventHandler(this._miProperties_Click);
         // 
         // _lblAuthor
         // 
         this._lblAuthor.AutoEllipsis = true;
         this._lblAuthor.ContextMenuStrip = this._annNodeContextMenu;
         this._lblAuthor.Location = new System.Drawing.Point(63, 3);
         this._lblAuthor.Name = "_lblAuthor";
         this._lblAuthor.Size = new System.Drawing.Size(91, 13);
         this._lblAuthor.TabIndex = 3;
         this._lblAuthor.Text = "[Author]";
         this._lblAuthor.DoubleClick += new System.EventHandler(this.AnnObjectTreeNode_DoubleClick);
         this._lblAuthor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnnObjectTreeNode_MouseDown);
         // 
         // _lblObjectName
         // 
         this._lblObjectName.AutoSize = true;
         this._lblObjectName.ContextMenuStrip = this._annNodeContextMenu;
         this._lblObjectName.Location = new System.Drawing.Point(63, 18);
         this._lblObjectName.Name = "_lblObjectName";
         this._lblObjectName.Size = new System.Drawing.Size(72, 13);
         this._lblObjectName.TabIndex = 4;
         this._lblObjectName.Text = "[ObjectName]";
         this._lblObjectName.Visible = false;
         this._lblObjectName.DoubleClick += new System.EventHandler(this.AnnObjectTreeNode_DoubleClick);
         this._lblObjectName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnnObjectTreeNode_MouseDown);
         // 
         // _lblDate
         // 
         this._lblDate.AutoSize = true;
         this._lblDate.ContextMenuStrip = this._annNodeContextMenu;
         this._lblDate.Location = new System.Drawing.Point(63, 34);
         this._lblDate.Name = "_lblDate";
         this._lblDate.Size = new System.Drawing.Size(36, 13);
         this._lblDate.TabIndex = 5;
         this._lblDate.Text = "[Date]";
         this._lblDate.Visible = false;
         this._lblDate.DoubleClick += new System.EventHandler(this.AnnObjectTreeNode_DoubleClick);
         this._lblDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnnObjectTreeNode_MouseDown);
         // 
         // _tbComment
         // 
         this._tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this._tbComment.Location = new System.Drawing.Point(160, 5);
         this._tbComment.Name = "_tbComment";
         this._tbComment.Size = new System.Drawing.Size(72, 20);
         this._tbComment.TabIndex = 6;
         this._tbComment.TextChanged += new System.EventHandler(this._tbComment_TextChanged);
         // 
         // _lblBottomSeparetor
         // 
         this._lblBottomSeparetor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
         this._lblBottomSeparetor.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._lblBottomSeparetor.Location = new System.Drawing.Point(0, 48);
         this._lblBottomSeparetor.Name = "_lblBottomSeparetor";
         this._lblBottomSeparetor.Size = new System.Drawing.Size(235, 1);
         this._lblBottomSeparetor.TabIndex = 7;
         // 
         // AnnObjectTreeNode
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.ContextMenuStrip = this._annNodeContextMenu;
         this.Controls.Add(this._lblBottomSeparetor);
         this.Controls.Add(this._tbComment);
         this.Controls.Add(this._lblDate);
         this.Controls.Add(this._lblObjectName);
         this.Controls.Add(this._lblAuthor);
         this.Controls.Add(this._pbObjetIcon);
         this.Controls.Add(this._btnCollapseExpand);
         this.MinimumSize = new System.Drawing.Size(235, 54);
         this.Name = "AnnObjectTreeNode";
         this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
         this.Size = new System.Drawing.Size(235, 54);
         this.Click += new System.EventHandler(this.AnnObjectTreeNode_Click);
         this.DoubleClick += new System.EventHandler(this.AnnObjectTreeNode_DoubleClick);
         this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnnObjectTreeNode_MouseDown);
         ((System.ComponentModel.ISupportInitialize)(this._pbObjetIcon)).EndInit();
         this._annNodeContextMenu.ResumeLayout(false);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnCollapseExpand;
      private System.Windows.Forms.PictureBox _pbObjetIcon;
      private System.Windows.Forms.Label _lblAuthor;
      private System.Windows.Forms.Label _lblObjectName;
      private System.Windows.Forms.Label _lblDate;
      private System.Windows.Forms.TextBox _tbComment;
      private System.Windows.Forms.Label _lblBottomSeparetor;
      private System.Windows.Forms.ContextMenuStrip _annNodeContextMenu;
      private System.Windows.Forms.ToolStripMenuItem _miReply;
      private System.Windows.Forms.ToolStripMenuItem _miExpandCollapse;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem _miDelete;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
      private System.Windows.Forms.ToolStripMenuItem _miProperties;
   }
}
