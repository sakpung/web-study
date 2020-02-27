// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
//---------------------------------------------------------------------
// 
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Resources;

namespace DicomAnonymizer.UI.Controls
{
   /// <summary>
   /// Summary description for TreeGridView.
   /// </summary>
   [System.ComponentModel.DesignerCategory("code"),
   Designer(typeof(System.Windows.Forms.Design.ControlDesigner)),
  ComplexBindingProperties(),
   Docking(DockingBehavior.Ask)]
   public class TreeGridView : DataGridView
   {      
      private TreeGridNode _root;
      private TreeGridColumn _expandableColumn;      
      internal ImageList _imageList;
      private bool _inExpandCollapse = false;
      internal bool _inExpandCollapseMouseCapture = false;
      private Control hideScrollBarControl;
      private bool _showLines = true;
      private bool _virtualNodes = false;

      internal Bitmap rOpen;
      internal Bitmap rClosed;

      private Timer _autoScrollTimer;
      private int _scrollDirection;
      private static DataGridViewRow _selectedRow;
      private SolidBrush _dividerBrush;
      private Pen _selectionPen;

      public event EventHandler<CancelDropHilightEventArgs> CancelDropRowHilight;

      protected bool OnCancelDropRowHilight(int rowIndex)
      {
         if (CancelDropRowHilight != null)
         {
            CancelDropHilightEventArgs e = new CancelDropHilightEventArgs(rowIndex);

            CancelDropRowHilight(this, e);
            return e.Cancel;
         }
         return false;
      }

      #region Designer properties
      /// <summary>
      /// The color of the divider displayed between rows while dragging
      /// </summary>
      [Browsable(true)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
      [Category("Appearance")]
      [Description("The color of the divider displayed between rows while dragging")]
      public Color DividerColor
      {
         get { return _dividerBrush.Color; }
         set { _dividerBrush = new SolidBrush(value); }
      }

      /// <summary>
      /// The color of the border drawn around the selected row
      /// </summary>
      [Browsable(true)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
      [Category("Appearance")]
      [Description("The color of the border drawn around the selected row")]
      public Color SelectionColor
      {
         get { return _selectionPen.Color; }
         set { _selectionPen = new Pen(value); }
      }

      /// <summary>
      /// Height (in pixels) of the divider to display
      /// </summary>
      [Browsable(true)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
      [Category("Appearance")]
      [Description("Height (in pixels) of the divider to display")]
      [DefaultValue(4)]
      public int DividerHeight { get; set; }

      /// <summary>
      /// Width (in pixels) of the border around the selected row
      /// </summary>
      [Browsable(true)]
      [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
      [Category("Appearance")]
      [Description("Width (in pixels) of the border around the selected row")]
      [DefaultValue(3)]
      public int SelectionWidth { get; set; }

      #endregion

      #region Constructor
      public TreeGridView() : base()
      {
         this.rOpen = (Bitmap)Properties.Resources.Minus;
         this.rClosed = (Bitmap)Properties.Resources.Plus;

         

         // Control when edit occurs because edit mode shouldn't start when expanding/collapsing
         EditMode = DataGridViewEditMode.EditProgrammatically;
         RowTemplate = new TreeGridNode() as DataGridViewRow;
         // This sample does not support adding or deleting rows by the user.
         AllowUserToAddRows = false;
         AllowUserToDeleteRows = false;
         _root = new TreeGridNode(this);
         _root.IsRoot = true;
         AllowDrop = true;

         // Ensures that all rows are added unshared by listening to the CollectionChanged event.
         base.Rows.CollectionChanged += delegate(object sender, System.ComponentModel.CollectionChangeEventArgs e) { };
                  
         _dividerBrush = new SolidBrush(Color.Red);
         _selectionPen = new Pen(Color.Blue);
         DividerHeight = 4;
         SelectionWidth = 3;

         DragOver += new DragEventHandler(dataGridView1_DragOver);
         DragLeave += new EventHandler(dataGridView1_DragLeave);
         if(!DesignMode)
            SetupTimer();
      }

      #region Selection      

      public void SelectRow(int rowIndex)
      {
         _selectedRow = Rows[rowIndex];
         _selectedRow.Selected = true;
         //Invalidate();
      }

      #endregion

      #region Selection highlighting

      private void dataGridView1_Paint_Selection(object sender, PaintEventArgs e)
      {
         if (_selectedRow == null || _selectedRow.DataGridView != this)
            return;

         Rectangle displayRect = GetRowDisplayRectangle(_selectedRow.Index, false);
         if (displayRect.Height == 0)
            return;

         _selectionPen.Width = SelectionWidth;
         int heightAdjust = (int)Math.Ceiling((float)SelectionWidth / 2);
         e.Graphics.DrawRectangle(_selectionPen, displayRect.X - 1, displayRect.Y - heightAdjust,
                                  displayRect.Width, displayRect.Height + SelectionWidth - 1);
      }

      private void dataGridView1_DefaultcellStyleChanged(object sender, EventArgs e)
      {
         DefaultCellStyle.SelectionBackColor = DefaultCellStyle.BackColor;
         DefaultCellStyle.SelectionForeColor = DefaultCellStyle.ForeColor;
      }

      private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
      {
         Invalidate();
      }

      #endregion

      #region Drag-and-drop
      protected override void OnDragDrop(DragEventArgs args)
      {
         if (args.Effect == DragDropEffects.None)
            return;

         if (_autoScrollTimer != null)
            _autoScrollTimer.Enabled = false;

         base.OnDragDrop(args);
      }

      private void dataGridView1_DragLeave(object sender, EventArgs e1)
      {
         _autoScrollTimer.Enabled = false;
      }

      private void dataGridView1_DragOver(object sender, DragEventArgs e)
      {
         if (e.Effect == DragDropEffects.None)
            return;

         Point clientPoint = PointToClient(new Point(e.X, e.Y));

         //Note: For some reason, HitTest is failing when clientPoint.Y = dataGridView1.Height-1.
         // I have no idea why.
         // clientPoint.Y is always 0 <= clientPoint.Y < dataGridView1.Height
         if (clientPoint.Y < Height - 1)
         {
            int newRowIndex = GetNewRowIndex(clientPoint.Y);
            HighlightInsertPosition(newRowIndex);
            StartAutoscrollTimer(e);
         }
      }

      private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left && e.RowIndex >= 0)
         {
            SelectRow(e.RowIndex);
            var dragObject = Rows[e.RowIndex];
            DoDragDrop(dragObject, DragDropEffects.Move);
            //TODO: Any way to make this *not* happen if they only click?
         }
      }

      /// <summary>
      /// Based on the mouse position, determines where the new row would
      /// be inserted if the user were to release the mouse-button right now
      /// </summary>
      /// <param name="clientY">
      /// The y-coordinate of the mouse, given with respectto the control
      /// (not the screen)
      /// </param>
      public int GetNewRowIndex(int clientY)
      {
         int lastRowIndex = Rows.Count - 1;

         //DataGridView has no cells
         if (Rows.Count == 0)
            return 0;

         //Dragged above the DataGridView
         if (clientY < GetRowDisplayRectangle(0, true).Top)
            return 0;

         //Dragged below the DataGridView
         int bottom = GetRowDisplayRectangle(lastRowIndex, true).Bottom;
         if (bottom > 0 && clientY >= bottom)
            return lastRowIndex + 1;

         //Dragged onto one of the cells.  Depending on where in cell,
         // insert before or after row.
         var hittest = HitTest(2, clientY); //Don't care about X coordinate

         return hittest.RowIndex;
      }

      #endregion

      #region Drop-and-drop highlighting

      private void HighlightInsertPosition(int rowIndex)
      {
         ClearSelection();
         if (rowIndex < Rows.Count && !OnCancelDropRowHilight(rowIndex))
            SelectRow(rowIndex);
         //else
            
      }

      #endregion

      #region Autoscroll
      private void SetupTimer()
      {
         _autoScrollTimer = new Timer
         {
            Interval = 250,
            Enabled = false
         };
         _autoScrollTimer.Tick += OnAutoscrollTimerTick;
      }

      private void StartAutoscrollTimer(DragEventArgs args)
      {
         Point position = PointToClient(new Point(args.X, args.Y));

         if (position.Y <= Font.Height / 2 &&
            FirstDisplayedScrollingRowIndex > 0)
         {
            //Near top, scroll up
            _scrollDirection = -1;
            _autoScrollTimer.Enabled = true;
         }
         else if (position.Y >= ClientSize.Height - Font.Height / 2 &&
                 FirstDisplayedScrollingRowIndex < Rows.Count - 1)
         {
            //Near bottom, scroll down
            _scrollDirection = 1;
            _autoScrollTimer.Enabled = true;
         }
         else
         {
            _autoScrollTimer.Enabled = false;
         }
      }

      private void OnAutoscrollTimerTick(object sender, EventArgs e)
      {
         //Scroll up/down
         FirstDisplayedScrollingRowIndex += _scrollDirection;
      }
      #endregion

      #endregion

      #region Keyboard F2 to begin edit support
      protected override void OnKeyDown(KeyEventArgs e)
      {
         // Cause edit mode to begin since edit mode is disabled to support 
         // expanding/collapsing 
         base.OnKeyDown(e);
         if (!e.Handled)
         {
            if (e.KeyCode == Keys.F2 && CurrentCellAddress.X > -1 && CurrentCellAddress.Y > -1)
            {
               if (!CurrentCell.Displayed)
               {
                  FirstDisplayedScrollingRowIndex = CurrentCellAddress.Y;
               }
               else
               {
                  // TODO:calculate if the cell is partially offscreen and if so scroll into view
               }
               SelectionMode = DataGridViewSelectionMode.CellSelect;
               BeginEdit(true);
            }
            else if (e.KeyCode == Keys.Enter && !IsCurrentCellInEditMode)
            {
               SelectionMode = DataGridViewSelectionMode.FullRowSelect;
               CurrentCell.OwningRow.Selected = true;
            }
         }
      }
      #endregion

      #region Shadow and hide DGV properties

      // This sample does not support databinding
      [Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      EditorBrowsable(EditorBrowsableState.Never)]
      public new object DataSource
      {
         get { return null; }
         set { throw new NotSupportedException("The TreeGridView does not support databinding"); }
      }

      [Browsable(false),
       DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      EditorBrowsable(EditorBrowsableState.Never)]
      public new object DataMember
      {
         get { return null; }
         set { throw new NotSupportedException("The TreeGridView does not support databinding"); }
      }

      [Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
    EditorBrowsable(EditorBrowsableState.Never)]
      public new DataGridViewRowCollection Rows
      {
         get { return base.Rows; }
      }

      [Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      EditorBrowsable(EditorBrowsableState.Never)]
      public new bool VirtualMode
      {
         get { return false; }
         set { throw new NotSupportedException("The TreeGridView does not support virtual mode"); }
      }

      // none of the rows/nodes created use the row template, so it is hidden.
      [Browsable(false),
      DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
      EditorBrowsable(EditorBrowsableState.Never)]
      public new DataGridViewRow RowTemplate
      {
         get { return base.RowTemplate; }
         set { base.RowTemplate = value; }
      }

      #endregion

      #region Public methods
      [Description("Returns the TreeGridNode for the given DataGridViewRow")]
      public TreeGridNode GetNodeForRow(DataGridViewRow row)
      {
         return row as TreeGridNode;
      }

      [Description("Returns the TreeGridNode for the given DataGridViewRow")]
      public TreeGridNode GetNodeForRow(int index)
      {
         return GetNodeForRow(base.Rows[index]);
      }

      public void Freeze()
      {
         Win32Helper.SendMessage(Handle, Win32Helper.WM_SETREDRAW, 0, 0);
      }

      public void Unfreeze()
      {
         Win32Helper.SendMessage(Handle, Win32Helper.WM_SETREDRAW, 1, 0);
         Invalidate(true);
      }

      #endregion

      #region Public properties
      [Category("Data"),
    Description("The collection of root nodes in the treelist."),
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
    Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
      public TreeGridNodeCollection Nodes
      {
         get
         {
            return _root.Nodes;
         }
      }

      public new TreeGridNode CurrentRow
      {
         get
         {
            return base.CurrentRow as TreeGridNode;
         }
      }

      [DefaultValue(false),
      Description("Causes nodes to always show as expandable. Use the NodeExpanding event to add nodes.")]
      public bool VirtualNodes
      {
         get { return _virtualNodes; }
         set { _virtualNodes = value; }
      }

      public TreeGridNode CurrentNode
      {
         get
         {
            return CurrentRow;
         }
      }

      [DefaultValue(true)]
      public bool ShowLines
      {
         get { return _showLines; }
         set
         {
            if (value != _showLines)
            {
               _showLines = value;
               Invalidate();
            }
         }
      }

      public ImageList ImageList
      {
         get { return _imageList; }
         set
         {
            _imageList = value;
            //TODO: should we invalidate cell styles when setting the image list?

         }
      }

      public new int RowCount
      {
         get { return Nodes.Count; }
         set
         {
            for (int i = 0; i < value; i++)
               Nodes.Add(new TreeGridNode());

         }
      }
      #endregion

      #region Site nodes and collapse/expand support
      protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
      {
         base.OnRowsAdded(e);
         // Notify the row when it is added to the base grid 
         int count = e.RowCount - 1;
         TreeGridNode row;
         while (count >= 0)
         {
            row = base.Rows[e.RowIndex + count] as TreeGridNode;
            if (row != null)
            {
               row.Sited();
            }
            count--;
         }
      }

      internal protected void UnSiteAll()
      {
         try
         {
            UnSiteNode(_root);
         }
         catch { }
      }

      internal protected virtual void UnSiteNode(TreeGridNode node)
      {
         if (node.IsSited || node.IsRoot)
         {
            // remove child rows first
            foreach (TreeGridNode childNode in node.Nodes)
            {
               UnSiteNode(childNode);
            }

            // now remove this row except for the root
            if (!node.IsRoot)
            {
               base.Rows.Remove(node);
               // Row isn't sited in the grid anymore after remove. Note that we cannot
               // Use the RowRemoved event since we cannot map from the row index to
               // the index of the expandable row/node.
               node.UnSited();
            }
         }
      }

      internal protected virtual bool CollapseNode(TreeGridNode node)
      {
         if (node.IsExpanded)
         {
            CollapsingEventArgs exp = new CollapsingEventArgs(node);
            OnNodeCollapsing(exp);

            if (!exp.Cancel)
            {
               LockVerticalScrollBarUpdate(true);
               SuspendLayout();
               _inExpandCollapse = true;
               node.IsExpanded = false;

               foreach (TreeGridNode childNode in node.Nodes)
               {                  
                  UnSiteNode(childNode);
               }

               CollapsedEventArgs exped = new CollapsedEventArgs(node);
               OnNodeCollapsed(exped);
               //TODO: Convert this to a specific NodeCell property
               _inExpandCollapse = false;
               LockVerticalScrollBarUpdate(false);
               ResumeLayout(true);
               InvalidateCell(node.Cells[0]);

            }

            return !exp.Cancel;
         }
         else
         {
            // row isn't expanded, so we didn't do anything.				
            return false;
         }
      }

      internal protected virtual void SiteNode(TreeGridNode node)
      {
         //TODO: Raise exception if parent node is not the root or is not sited.
         int rowIndex = -1;
         TreeGridNode currentRow;
         node._grid = this;

         if (node.Parent != null && node.Parent.IsRoot == false)
         {
            // row is a child
            Debug.Assert(node.Parent != null && node.Parent.IsExpanded == true);

            if (node.Index > 0)
            {
               currentRow = node.Parent.Nodes[node.Index - 1];
            }
            else
            {
               currentRow = node.Parent;
            }
         }
         else
         {
            // row is being added to the root
            if (node.Index > 0)
            {
               currentRow = node.Parent.Nodes[node.Index - 1];
            }
            else
            {
               currentRow = null;
            }

         }

         if (currentRow != null)
         {
            while (currentRow.Level >= node.Level)
            {
               if (currentRow.RowIndex < base.Rows.Count - 1)
               {
                  currentRow = base.Rows[currentRow.RowIndex + 1] as TreeGridNode;
                  Debug.Assert(currentRow != null);
               }
               else
                  // no more rows, site this node at the end.
                  break;

            }
            if (currentRow == node.Parent)
               rowIndex = currentRow.RowIndex + 1;
            else if (currentRow.Level < node.Level)
               rowIndex = currentRow.RowIndex;
            else
               rowIndex = currentRow.RowIndex + 1;
         }
         else
            rowIndex = 0;


         Debug.Assert(rowIndex != -1);
         SiteNode(node, rowIndex);

         Debug.Assert(node.IsSited);
         if (node.IsExpanded)
         {
            // add all child rows to display
            foreach (TreeGridNode childNode in node.Nodes)
            {
               //TODO: could use the more efficient SiteRow with index.
               SiteNode(childNode);
            }
         }
      }


      internal protected virtual void SiteNode(TreeGridNode node, int index)
      {
         if (index < base.Rows.Count)
         {
            base.Rows.Insert(index, node);
         }
         else
         {
            // for the last item.
            base.Rows.Add(node);
         }
      }

      internal protected virtual bool ExpandNode(TreeGridNode node)
      {
         if (!node.IsExpanded || _virtualNodes)
         {
            ExpandingEventArgs exp = new ExpandingEventArgs(node);
            OnNodeExpanding(exp);

            if (!exp.Cancel)
            {
               LockVerticalScrollBarUpdate(true);
               SuspendLayout();
               _inExpandCollapse = true;
               node.IsExpanded = true;

               //TODO Convert this to a InsertRange
               foreach (TreeGridNode childNode in node.Nodes)
               {
                  Debug.Assert(childNode.RowIndex == -1, "Row is already in the grid.");

                  SiteNode(childNode);
                  //BaseRows.Insert(rowIndex + 1, childRow);
                  //TODO : remove -- just a test.
                  //childNode.Cells[0].Value = "child";
               }

               ExpandedEventArgs exped = new ExpandedEventArgs(node);
               OnNodeExpanded(exped);
               //TODO: Convert this to a specific NodeCell property
               _inExpandCollapse = false;
               LockVerticalScrollBarUpdate(false);
               ResumeLayout(true);
               InvalidateCell(node.Cells[0]);
            }

            return !exp.Cancel;
         }
         else
         {
            // row is already expanded, so we didn't do anything.
            return false;
         }
      }

      protected override void OnMouseUp(MouseEventArgs e)
      {
         // used to keep extra mouse moves from selecting more rows when collapsing
         base.OnMouseUp(e);
         _inExpandCollapseMouseCapture = false;
      }
      protected override void OnMouseMove(MouseEventArgs e)
      {
         // while we are expanding and collapsing a node mouse moves are
         // supressed to keep selections from being messed up.
         if (!_inExpandCollapseMouseCapture)
            base.OnMouseMove(e);

      }
      #endregion

      #region Collapse/Expand events
      public event ExpandingEventHandler NodeExpanding;
      public event ExpandedEventHandler NodeExpanded;
      public event CollapsingEventHandler NodeCollapsing;
      public event CollapsedEventHandler NodeCollapsed;

      protected virtual void OnNodeExpanding(ExpandingEventArgs e)
      {
         if (NodeExpanding != null)
         {
            NodeExpanding(this, e);
         }
      }
      protected virtual void OnNodeExpanded(ExpandedEventArgs e)
      {
         if (NodeExpanded != null)
         {
            NodeExpanded(this, e);
         }
      }
      protected virtual void OnNodeCollapsing(CollapsingEventArgs e)
      {
         if (NodeCollapsing != null)
         {
            NodeCollapsing(this, e);
         }

      }
      protected virtual void OnNodeCollapsed(CollapsedEventArgs e)
      {
         if (NodeCollapsed != null)
         {
            NodeCollapsed(this, e);
         }
      }
      #endregion

      #region Helper methods
      protected override void Dispose(bool disposing)
      {         
         base.Dispose(Disposing);
         UnSiteAll();
      }

      protected override void OnHandleCreated(EventArgs e)
      {
         base.OnHandleCreated(e);

         // this control is used to temporarly hide the vertical scroll bar
         hideScrollBarControl = new Control();
         hideScrollBarControl.Visible = false;
         hideScrollBarControl.Enabled = false;
         hideScrollBarControl.TabStop = false;
         // control is disposed automatically when the grid is disposed
         Controls.Add(hideScrollBarControl);
      }

      protected override void OnRowEnter(DataGridViewCellEventArgs e)
      {
         // ensure full row select
         base.OnRowEnter(e);
         if (SelectionMode == DataGridViewSelectionMode.CellSelect ||
             (SelectionMode == DataGridViewSelectionMode.FullRowSelect &&
             base.Rows[e.RowIndex].Selected == false))
         {
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            base.Rows[e.RowIndex].Selected = true;
         }
      }

      private void LockVerticalScrollBarUpdate(bool lockUpdate/*, bool delayed*/)
      {
         // Temporarly hide/show the vertical scroll bar by changing its parent
         if (!_inExpandCollapse)
         {
            if (lockUpdate)
            {
               VerticalScrollBar.Parent = hideScrollBarControl;
            }
            else
            {
               VerticalScrollBar.Parent = this;
            }
         }
      }

      protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
      {
         if (typeof(TreeGridColumn).IsAssignableFrom(e.Column.GetType()))
         {
            if (_expandableColumn == null)
            {
               // identify the expanding column.			
               _expandableColumn = (TreeGridColumn)e.Column;
            }
            else
            {
               // Columns.Remove(e.Column);
               //throw new InvalidOperationException("Only one TreeGridColumn per TreeGridView is supported.");
            }
         }

         // Expandable Grid doesn't support sorting. This is just a limitation of the sample.
         e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;

         base.OnColumnAdded(e);
      }

      private static class Win32Helper
      {
         public const int WM_SETREDRAW = 0x000B;
                          
         [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
         public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

         [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
         public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);         
      }
      #endregion


   }
}
