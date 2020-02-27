namespace Leadtools.Annotations.WinForms
{
   partial class ReviewTreeNode
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
         this._reviewNodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
         this._miExpandCollapse = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
         this._replyReview = new System.Windows.Forms.ToolStripMenuItem();
         this._miSetStatus = new System.Windows.Forms.ToolStripMenuItem();
         this._miStatusAccepted = new System.Windows.Forms.ToolStripMenuItem();
         this._miStatusCancelled = new System.Windows.Forms.ToolStripMenuItem();
         this._miStatusCompleted = new System.Windows.Forms.ToolStripMenuItem();
         this._miStatusCreated = new System.Windows.Forms.ToolStripMenuItem();
         this._miStatusModified = new System.Windows.Forms.ToolStripMenuItem();
         this._miStatusNone = new System.Windows.Forms.ToolStripMenuItem();
         this._miStatusRejected = new System.Windows.Forms.ToolStripMenuItem();
         this._miStatusReply = new System.Windows.Forms.ToolStripMenuItem();
         this._checkReview = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
         this._addReview = new System.Windows.Forms.ToolStripMenuItem();
         this._deleteReview = new System.Windows.Forms.ToolStripMenuItem();
         this._lblBottomSeparetor = new System.Windows.Forms.Label();
         this._tbComment = new System.Windows.Forms.TextBox();
         this._lblDate = new System.Windows.Forms.Label();
         this._lblObjectName = new System.Windows.Forms.Label();
         this._lblAuthor = new System.Windows.Forms.Label();
         this._pbObjetIcon = new System.Windows.Forms.PictureBox();
         this._cbChecked = new System.Windows.Forms.CheckBox();
         this._btnCollapseExpand = new System.Windows.Forms.Button();
         this._reviewNodeContextMenu.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._pbObjetIcon)).BeginInit();
         this.SuspendLayout();
         // 
         // _reviewNodeContextMenu
         // 
         this._reviewNodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miExpandCollapse,
            this.toolStripMenuItem1,
            this._replyReview,
            this._miSetStatus,
            this._checkReview,
            this.toolStripMenuItem2,
            this._addReview,
            this._deleteReview});
         this._reviewNodeContextMenu.Name = "_reviewNodeContextMenu";
         this._reviewNodeContextMenu.Size = new System.Drawing.Size(126, 148);
         this._reviewNodeContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this._reviewNodeContextMenu_Opening);
         // 
         // _miExpandCollapse
         // 
         this._miExpandCollapse.Name = "_miExpandCollapse";
         this._miExpandCollapse.Size = new System.Drawing.Size(125, 22);
         this._miExpandCollapse.Text = "Expand";
         this._miExpandCollapse.Click += new System.EventHandler(this._btnCollapseExpand_Click);
         // 
         // toolStripMenuItem1
         // 
         this.toolStripMenuItem1.Name = "toolStripMenuItem1";
         this.toolStripMenuItem1.Size = new System.Drawing.Size(122, 6);
         // 
         // _replyReview
         // 
         this._replyReview.Name = "_replyReview";
         this._replyReview.Size = new System.Drawing.Size(125, 22);
         this._replyReview.Text = "Reply";
         this._replyReview.Click += new System.EventHandler(this._replyReview_Click);
         // 
         // _miSetStatus
         // 
         this._miSetStatus.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miStatusAccepted,
            this._miStatusCancelled,
            this._miStatusCompleted,
            this._miStatusCreated,
            this._miStatusModified,
            this._miStatusNone,
            this._miStatusRejected,
            this._miStatusReply});
         this._miSetStatus.Name = "_miSetStatus";
         this._miSetStatus.Size = new System.Drawing.Size(125, 22);
         this._miSetStatus.Text = "Set Status";
         // 
         // _miStatusAccepted
         // 
         this._miStatusAccepted.Name = "_miStatusAccepted";
         this._miStatusAccepted.Size = new System.Drawing.Size(133, 22);
         this._miStatusAccepted.Text = "Accepted";
         this._miStatusAccepted.Click += new System.EventHandler(this._miStatus_Click);
         // 
         // _miStatusCancelled
         // 
         this._miStatusCancelled.Name = "_miStatusCancelled";
         this._miStatusCancelled.Size = new System.Drawing.Size(133, 22);
         this._miStatusCancelled.Text = "Cancelled";
         this._miStatusCancelled.Click += new System.EventHandler(this._miStatus_Click);
         // 
         // _miStatusCompleted
         // 
         this._miStatusCompleted.Name = "_miStatusCompleted";
         this._miStatusCompleted.Size = new System.Drawing.Size(133, 22);
         this._miStatusCompleted.Text = "Completed";
         this._miStatusCompleted.Click += new System.EventHandler(this._miStatus_Click);
         // 
         // _miStatusCreated
         // 
         this._miStatusCreated.Name = "_miStatusCreated";
         this._miStatusCreated.Size = new System.Drawing.Size(133, 22);
         this._miStatusCreated.Text = "Created";
         this._miStatusCreated.Click += new System.EventHandler(this._miStatus_Click);
         // 
         // _miStatusModified
         // 
         this._miStatusModified.Name = "_miStatusModified";
         this._miStatusModified.Size = new System.Drawing.Size(133, 22);
         this._miStatusModified.Text = "Modified";
         this._miStatusModified.Click += new System.EventHandler(this._miStatus_Click);
         // 
         // _miStatusNone
         // 
         this._miStatusNone.Name = "_miStatusNone";
         this._miStatusNone.Size = new System.Drawing.Size(133, 22);
         this._miStatusNone.Text = "None";
         this._miStatusNone.Click += new System.EventHandler(this._miStatus_Click);
         // 
         // _miStatusRejected
         // 
         this._miStatusRejected.Name = "_miStatusRejected";
         this._miStatusRejected.Size = new System.Drawing.Size(133, 22);
         this._miStatusRejected.Text = "Rejected";
         this._miStatusRejected.Click += new System.EventHandler(this._miStatus_Click);
         // 
         // _miStatusReply
         // 
         this._miStatusReply.Name = "_miStatusReply";
         this._miStatusReply.Size = new System.Drawing.Size(133, 22);
         this._miStatusReply.Text = "Reply";
         this._miStatusReply.Click += new System.EventHandler(this._miStatus_Click);
         // 
         // _checkReview
         // 
         this._checkReview.Name = "_checkReview";
         this._checkReview.Size = new System.Drawing.Size(125, 22);
         this._checkReview.Text = "Check";
         this._checkReview.Click += new System.EventHandler(this._checkReview_Click);
         // 
         // toolStripMenuItem2
         // 
         this.toolStripMenuItem2.Name = "toolStripMenuItem2";
         this.toolStripMenuItem2.Size = new System.Drawing.Size(122, 6);
         // 
         // _addReview
         // 
         this._addReview.Name = "_addReview";
         this._addReview.Size = new System.Drawing.Size(125, 22);
         this._addReview.Text = "Add";
         this._addReview.Click += new System.EventHandler(this._addReview_Click);
         // 
         // _deleteReview
         // 
         this._deleteReview.Name = "_deleteReview";
         this._deleteReview.Size = new System.Drawing.Size(125, 22);
         this._deleteReview.Text = "Delete";
         this._deleteReview.Click += new System.EventHandler(this._deleteReview_Click);
         // 
         // _lblBottomSeparetor
         // 
         this._lblBottomSeparetor.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
         this._lblBottomSeparetor.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._lblBottomSeparetor.Location = new System.Drawing.Point(0, 53);
         this._lblBottomSeparetor.Name = "_lblBottomSeparetor";
         this._lblBottomSeparetor.Size = new System.Drawing.Size(235, 1);
         this._lblBottomSeparetor.TabIndex = 7;
         // 
         // _tbComment
         // 
         this._tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
         this._tbComment.Location = new System.Drawing.Point(160, 3);
         this._tbComment.Name = "_tbComment";
         this._tbComment.Size = new System.Drawing.Size(72, 20);
         this._tbComment.TabIndex = 6;
         this._tbComment.TextChanged += new System.EventHandler(this._tbComment_TextChanged);
         // 
         // _lblDate
         // 
         this._lblDate.AutoSize = true;
         this._lblDate.ContextMenuStrip = this._reviewNodeContextMenu;
         this._lblDate.Location = new System.Drawing.Point(63, 36);
         this._lblDate.Name = "_lblDate";
         this._lblDate.Size = new System.Drawing.Size(36, 13);
         this._lblDate.TabIndex = 5;
         this._lblDate.Text = "[Date]";
         this._lblDate.Visible = false;
         // 
         // _lblObjectName
         // 
         this._lblObjectName.AutoSize = true;
         this._lblObjectName.ContextMenuStrip = this._reviewNodeContextMenu;
         this._lblObjectName.Location = new System.Drawing.Point(63, 20);
         this._lblObjectName.Name = "_lblObjectName";
         this._lblObjectName.Size = new System.Drawing.Size(72, 13);
         this._lblObjectName.TabIndex = 4;
         this._lblObjectName.Text = "[ObjectName]";
         this._lblObjectName.Visible = false;
         // 
         // _lblAuthor
         // 
         this._lblAuthor.AutoEllipsis = true;
         this._lblAuthor.ContextMenuStrip = this._reviewNodeContextMenu;
         this._lblAuthor.Location = new System.Drawing.Point(63, 4);
         this._lblAuthor.Name = "_lblAuthor";
         this._lblAuthor.Size = new System.Drawing.Size(91, 13);
         this._lblAuthor.TabIndex = 3;
         this._lblAuthor.Text = "[Author]";
         // 
         // _pbObjetIcon
         // 
         this._pbObjetIcon.ContextMenuStrip = this._reviewNodeContextMenu;
         this._pbObjetIcon.Location = new System.Drawing.Point(41, 17);
         this._pbObjetIcon.Name = "_pbObjetIcon";
         this._pbObjetIcon.Size = new System.Drawing.Size(20, 20);
         this._pbObjetIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
         this._pbObjetIcon.TabIndex = 2;
         this._pbObjetIcon.TabStop = false;
         // 
         // _cbChecked
         // 
         this._cbChecked.AutoSize = true;
         this._cbChecked.Location = new System.Drawing.Point(24, 20);
         this._cbChecked.Name = "_cbChecked";
         this._cbChecked.Size = new System.Drawing.Size(15, 14);
         this._cbChecked.TabIndex = 1;
         this._cbChecked.UseVisualStyleBackColor = true;
         this._cbChecked.CheckedChanged += new System.EventHandler(this._cbChecked_CheckedChanged);
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
         // ReviewTreeNode
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.SystemColors.Control;
         this.ContextMenuStrip = this._reviewNodeContextMenu;
         this.Controls.Add(this._lblBottomSeparetor);
         this.Controls.Add(this._tbComment);
         this.Controls.Add(this._lblDate);
         this.Controls.Add(this._lblObjectName);
         this.Controls.Add(this._lblAuthor);
         this.Controls.Add(this._pbObjetIcon);
         this.Controls.Add(this._cbChecked);
         this.Controls.Add(this._btnCollapseExpand);
         this.MinimumSize = new System.Drawing.Size(235, 54);
         this.Name = "ReviewTreeNode";
         this.Size = new System.Drawing.Size(235, 54);
         this._reviewNodeContextMenu.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._pbObjetIcon)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnCollapseExpand;
      private System.Windows.Forms.CheckBox _cbChecked;
      private System.Windows.Forms.PictureBox _pbObjetIcon;
      private System.Windows.Forms.Label _lblAuthor;
      private System.Windows.Forms.Label _lblObjectName;
      private System.Windows.Forms.Label _lblDate;
      private System.Windows.Forms.TextBox _tbComment;
      private System.Windows.Forms.Label _lblBottomSeparetor;
      private System.Windows.Forms.ContextMenuStrip _reviewNodeContextMenu;
      private System.Windows.Forms.ToolStripMenuItem _replyReview;
      private System.Windows.Forms.ToolStripMenuItem _addReview;
      private System.Windows.Forms.ToolStripMenuItem _checkReview;
      private System.Windows.Forms.ToolStripMenuItem _miExpandCollapse;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem _miSetStatus;
      private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
      private System.Windows.Forms.ToolStripMenuItem _miStatusAccepted;
      private System.Windows.Forms.ToolStripMenuItem _miStatusCancelled;
      private System.Windows.Forms.ToolStripMenuItem _miStatusCompleted;
      private System.Windows.Forms.ToolStripMenuItem _miStatusCreated;
      private System.Windows.Forms.ToolStripMenuItem _miStatusModified;
      private System.Windows.Forms.ToolStripMenuItem _miStatusNone;
      private System.Windows.Forms.ToolStripMenuItem _miStatusRejected;
      private System.Windows.Forms.ToolStripMenuItem _miStatusReply;
      private System.Windows.Forms.ToolStripMenuItem _deleteReview;
   }
}
