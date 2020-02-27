' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
'---------------------------------------------------------------------
' 
'  Copyright (c) Microsoft Corporation.  All rights reserved.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Diagnostics
Imports System.Windows.Forms.VisualStyles
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Drawing.Design
Imports System.Runtime.InteropServices

Namespace DicomAnonymizer.UI.Controls
    ''' <summary>
    ''' Summary description for TreeGridView.
    ''' </summary>
    <System.ComponentModel.DesignerCategory("code"), Designer(GetType(System.Windows.Forms.Design.ControlDesigner)), ComplexBindingProperties(), Docking(DockingBehavior.Ask)> _
    Public Class TreeGridView : Inherits DataGridView
        Private _root As TreeGridNode
        Private _expandableColumn As TreeGridColumn
        Friend _imageList As ImageList
        Private _inExpandCollapse As Boolean = False
        Friend _inExpandCollapseMouseCapture As Boolean = False
        Private hideScrollBarControl As Control
        Private _showLines As Boolean = True
        Private _virtualNodes As Boolean = False

        Friend rOpen As Bitmap
        Friend rClosed As Bitmap

        Private _autoScrollTimer As Timer
        Private _scrollDirection As Integer
        Private Shared _selectedRow As DataGridViewRow
        Private _dividerBrush As SolidBrush
        Private _selectionPen As Pen

        Public Event CancelDropRowHilight As EventHandler(Of CancelDropHilightEventArgs)

        Protected Function OnCancelDropRowHilight(ByVal rowIndex As Integer) As Boolean
            If Not CancelDropRowHilightEvent Is Nothing Then
                Dim e As CancelDropHilightEventArgs = New CancelDropHilightEventArgs(rowIndex)

                RaiseEvent CancelDropRowHilight(Me, e)
                Return e.Cancel
            End If
            Return False
        End Function

#Region "Designer properties"
        ''' <summary>
        ''' The color of the divider displayed between rows while dragging
        ''' </summary>
        <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Appearance"), Description("The color of the divider displayed between rows while dragging")> _
        Public Property DividerColor() As Color
            Get
                Return _dividerBrush.Color
            End Get
            Set(ByVal value As Color)
                _dividerBrush = New SolidBrush(value)
            End Set
        End Property

        ''' <summary>
        ''' The color of the border drawn around the selected row
        ''' </summary>
        <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Appearance"), Description("The color of the border drawn around the selected row")> _
        Public Property SelectionColor() As Color
            Get
                Return _selectionPen.Color
            End Get
            Set(ByVal value As Color)
                _selectionPen = New Pen(value)
            End Set
        End Property

        ''' <summary>
        ''' Height (in pixels) of the divider to display
        ''' </summary>
        <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Appearance"), Description("Height (in pixels) of the divider to display"), DefaultValue(4)> _
        Public Property DividerHeight() As Integer
            Get
                Return _dividerHeight
            End Get
            Set(ByVal value As Integer)
                _dividerHeight = value
            End Set
        End Property
        Private _dividerHeight As Integer

        ''' <summary>
        ''' Width (in pixels) of the border around the selected row
        ''' </summary>
        <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Category("Appearance"), Description("Width (in pixels) of the border around the selected row"), DefaultValue(3)> _
        Public Property SelectionWidth() As Integer
            Get
                Return _selectionWidth
            End Get
            Set(ByVal value As Integer)
                _selectionWidth = value
            End Set
        End Property

        Private _selectionWidth As Integer
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()

            rOpen = Resources.Minus
            rClosed = Resources.Plus

            ' Control when edit occurs because edit mode shouldn't start when expanding/collapsing
            EditMode = DataGridViewEditMode.EditProgrammatically
            RowTemplate = CType(New TreeGridNode(), DataGridViewRow)
            ' This sample does not support adding or deleting rows by the user.
            AllowUserToAddRows = False
            AllowUserToDeleteRows = False
            _root = New TreeGridNode(Me)
            _root.IsRoot = True
            AllowDrop = True

            ' Ensures that all rows are added unshared by listening to the CollectionChanged event.
            AddHandler MyBase.Rows.CollectionChanged, AddressOf Rows_CollectionChanged

            _dividerBrush = New SolidBrush(Color.Red)
            _selectionPen = New Pen(Color.Blue)
            DividerHeight = 4
            SelectionWidth = 3

            AddHandler DragOver, AddressOf dataGridView1_DragOver
            AddHandler DragLeave, AddressOf dataGridView1_DragLeave
            If (Not DesignMode) Then
                SetupTimer()
            End If
        End Sub

        Private Sub Rows_CollectionChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)

        End Sub

#Region "Selection      "

        Public Sub SelectRow(ByVal rowIndex As Integer)
            _selectedRow = Rows(rowIndex)
            _selectedRow.Selected = True
        End Sub

#End Region

#Region "Selection highlighting"
        Private Sub dataGridView1_Paint_Selection(ByVal sender As Object, ByVal e As PaintEventArgs)
            If _selectedRow Is Nothing OrElse Not _selectedRow.DataGridView Is Me Then
                Return
            End If

            Dim displayRect As Rectangle = GetRowDisplayRectangle(_selectedRow.Index, False)
            If displayRect.Height = 0 Then
                Return
            End If

            _selectionPen.Width = SelectionWidth
            Dim heightAdjust As Integer = CInt(Math.Ceiling(CSng(SelectionWidth) / 2))
            e.Graphics.DrawRectangle(_selectionPen, displayRect.X - 1, displayRect.Y - heightAdjust, displayRect.Width, displayRect.Height + SelectionWidth - 1)
        End Sub

        Private Sub dataGridView1_DefaultcellStyleChanged(ByVal sender As Object, ByVal e As EventArgs)
            DefaultCellStyle.SelectionBackColor = DefaultCellStyle.BackColor
            DefaultCellStyle.SelectionForeColor = DefaultCellStyle.ForeColor
        End Sub

        Private Sub dataGridView1_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs)
            Invalidate()
        End Sub
#End Region

#Region "Drag-and-drop"
        Protected Overrides Sub OnDragDrop(ByVal args As DragEventArgs)
            If args.Effect = DragDropEffects.None Then
                Return
            End If

            If Not _autoScrollTimer Is Nothing Then
                _autoScrollTimer.Enabled = False
            End If

            MyBase.OnDragDrop(args)
        End Sub

        Private Sub dataGridView1_DragLeave(ByVal sender As Object, ByVal e1 As EventArgs)
            _autoScrollTimer.Enabled = False
        End Sub

        Private Sub dataGridView1_DragOver(ByVal sender As Object, ByVal e As DragEventArgs)
            If e.Effect = DragDropEffects.None Then
                Return
            End If

            Dim clientPoint As Point = PointToClient(New Point(e.X, e.Y))

            'Note: For some reason, HitTest is failing when clientPoint.Y = dataGridView1.Height-1.
            ' I have no idea why.
            ' clientPoint.Y is always 0 <= clientPoint.Y < dataGridView1.Height
            If clientPoint.Y < Height - 1 Then
                Dim newRowIndex As Integer = GetNewRowIndex(clientPoint.Y)
                HighlightInsertPosition(newRowIndex)
                StartAutoscrollTimer(e)
            End If
        End Sub

        Private Sub dataGridView1_CellMouseDown(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
            If e.Button = MouseButtons.Left AndAlso e.RowIndex >= 0 Then
                SelectRow(e.RowIndex)
                Dim dragObject As DataGridViewRow = Rows(e.RowIndex)
                DoDragDrop(dragObject, DragDropEffects.Move)
                'TODO: Any way to make this *not* happen if they only click?
            End If
        End Sub

        ''' <summary>
        ''' Based on the mouse position, determines where the new row would
        ''' be inserted if the user were to release the mouse-button right now
        ''' </summary>
        ''' <param name="clientY">
        ''' The y-coordinate of the mouse, given with respectto the control
        ''' (not the screen)
        ''' </param>
        Public Function GetNewRowIndex(ByVal clientY As Integer) As Integer
            Dim lastRowIndex As Integer = Rows.Count - 1

            'DataGridView has no cells
            If Rows.Count = 0 Then
                Return 0
            End If

            'Dragged above the DataGridView
            If clientY < GetRowDisplayRectangle(0, True).Top Then
                Return 0
            End If

            'Dragged below the DataGridView
            Dim bottom As Integer = GetRowDisplayRectangle(lastRowIndex, True).Bottom
            If bottom > 0 AndAlso clientY >= bottom Then
                Return lastRowIndex + 1
            End If

            'Dragged onto one of the cells.  Depending on where in cell,
            ' insert before or after row.
            Dim vhittest As HitTestInfo = HitTest(2, clientY) 'Don't care about X coordinate

            Return vhittest.RowIndex
        End Function
#End Region

#Region "Drop-and-drop highlighting"

        Private Sub HighlightInsertPosition(ByVal rowIndex As Integer)
            ClearSelection()
            If rowIndex < Rows.Count AndAlso (Not OnCancelDropRowHilight(rowIndex)) Then
                SelectRow(rowIndex)
            End If
        End Sub

#End Region

#Region "Autoscroll"
        Private Sub SetupTimer()
            _autoScrollTimer = New Timer
            _autoScrollTimer.Interval = 250
            _autoScrollTimer.Enabled = False
            AddHandler _autoScrollTimer.Tick, AddressOf OnAutoscrollTimerTick
        End Sub

        Private Sub StartAutoscrollTimer(ByVal args As DragEventArgs)
            Dim position As Point = PointToClient(New Point(args.X, args.Y))

            If position.Y <= Font.Height / 2 AndAlso FirstDisplayedScrollingRowIndex > 0 Then
                'Near top, scroll up
                _scrollDirection = -1
                _autoScrollTimer.Enabled = True
            ElseIf position.Y >= ClientSize.Height - Font.Height / 2 AndAlso FirstDisplayedScrollingRowIndex < Rows.Count - 1 Then
                'Near bottom, scroll down
                _scrollDirection = 1
                _autoScrollTimer.Enabled = True
            Else
                _autoScrollTimer.Enabled = False
            End If
        End Sub

        Private Sub OnAutoscrollTimerTick(ByVal sender As Object, ByVal e As EventArgs)
            'Scroll up/down
            FirstDisplayedScrollingRowIndex += _scrollDirection
        End Sub
#End Region

#End Region

#Region "Keyboard F2 to begin edit support"
        Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
            ' Cause edit mode to begin since edit mode is disabled to support 
            ' expanding/collapsing 
            MyBase.OnKeyDown(e)
            If (Not e.Handled) Then
                If e.KeyCode = Keys.F2 AndAlso CurrentCellAddress.X > -1 AndAlso CurrentCellAddress.Y > -1 Then
                    If (Not CurrentCell.Displayed) Then
                        FirstDisplayedScrollingRowIndex = CurrentCellAddress.Y
                    Else
                        ' TODO:calculate if the cell is partially offscreen and if so scroll into view
                    End If
                    SelectionMode = DataGridViewSelectionMode.CellSelect
                    BeginEdit(True)
                ElseIf e.KeyCode = Keys.Enter AndAlso (Not IsCurrentCellInEditMode) Then
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    CurrentCell.OwningRow.Selected = True
                End If
            End If
        End Sub

#End Region

#Region "Shadow and hide DGV properties"
        ' This sample does not support databinding
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property DataSource() As Object
            Get
                Return Nothing
            End Get
            Set(ByVal value As Object)
                Throw New NotSupportedException("The TreeGridView does not support databinding")
            End Set
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property DataMember() As Object
            Get
                Return Nothing
            End Get
            Set(ByVal value As Object)
                Throw New NotSupportedException("The TreeGridView does not support databinding")
            End Set
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows ReadOnly Property Rows() As DataGridViewRowCollection
            Get
                Return MyBase.Rows
            End Get
        End Property

        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property VirtualMode() As Boolean
            Get
                Return False
            End Get
            Set(ByVal value As Boolean)
                Throw New NotSupportedException("The TreeGridView does not support virtual mode")
            End Set
        End Property

        ' none of the rows/nodes created use the row template, so it is hidden.
        <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), EditorBrowsable(EditorBrowsableState.Never)> _
        Public Shadows Property RowTemplate() As DataGridViewRow
            Get
                Return MyBase.RowTemplate
            End Get
            Set(ByVal value As DataGridViewRow)
                MyBase.RowTemplate = value
            End Set
        End Property

#End Region

#Region "Public methods"
        <Description("Returns the TreeGridNode for the given DataGridViewRow")> _
        Public Function GetNodeForRow(ByVal row As DataGridViewRow) As TreeGridNode
            Return TryCast(row, TreeGridNode)
        End Function

        <Description("Returns the TreeGridNode for the given DataGridViewRow")> _
        Public Function GetNodeForRow(ByVal index As Integer) As TreeGridNode
            Return GetNodeForRow(MyBase.Rows(index))
        End Function

        Public Sub Freeze()
            Win32Helper.SendMessage(Handle, Win32Helper.WM_SETREDRAW, 0, 0)
        End Sub

        Public Sub Unfreeze()
            Win32Helper.SendMessage(Handle, Win32Helper.WM_SETREDRAW, 1, 0)
            Invalidate(True)
        End Sub

#End Region

#Region "Public properties"
        <Category("Data"), Description("The collection of root nodes in the treelist."), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), Editor(GetType(CollectionEditor), GetType(UITypeEditor))> _
        Public ReadOnly Property Nodes() As TreeGridNodeCollection
            Get
                Return _root.Nodes
            End Get
        End Property

        Public Shadows ReadOnly Property CurrentRow() As TreeGridNode
            Get
                Return TryCast(MyBase.CurrentRow, TreeGridNode)
            End Get
        End Property

        <DefaultValue(False), Description("Causes nodes to always show as expandable. Use the NodeExpanding event to add nodes.")> _
        Public Property VirtualNodes() As Boolean
            Get
                Return _virtualNodes
            End Get
            Set(ByVal value As Boolean)
                _virtualNodes = value
            End Set
        End Property

        Public ReadOnly Property CurrentNode() As TreeGridNode
            Get
                Return CurrentRow
            End Get
        End Property

        <DefaultValue(True)> _
        Public Property ShowLines() As Boolean
            Get
                Return _showLines
            End Get
            Set(ByVal value As Boolean)
                If value <> _showLines Then
                    _showLines = value
                    Invalidate()
                End If
            End Set
        End Property

        Public Property ImageList() As ImageList
            Get
                Return _imageList
            End Get
            Set(ByVal value As ImageList)
                _imageList = value
                'TODO: should we invalidate cell styles when setting the image list?
            End Set
        End Property

        Public Shadows Property RowCount() As Integer
            Get
                Return Nodes.Count
            End Get
            Set(ByVal value As Integer)
                Dim i As Integer = 0
                Do While i < value
                    Nodes.Add(New TreeGridNode())
                    i += 1
                Loop
            End Set
        End Property

#End Region

#Region "Site nodes and collapse/expand support"
        Protected Overrides Sub OnRowsAdded(ByVal e As DataGridViewRowsAddedEventArgs)
            MyBase.OnRowsAdded(e)
            ' Notify the row when it is added to the base grid 
            Dim count As Integer = e.RowCount - 1
            Dim row As TreeGridNode
            Do While count >= 0
                row = TryCast(MyBase.Rows(e.RowIndex + count), TreeGridNode)
                If Not row Is Nothing Then
                    row.Sited()
                End If
                count -= 1
            Loop
        End Sub

        Protected Sub UnSiteAll()
            Try
                UnSiteNode(_root)
            Catch
            End Try
        End Sub

        Overridable Sub UnSiteNode(ByVal node As TreeGridNode)
            If node.IsSited OrElse node.IsRoot Then
                ' remove child rows first
                For Each childNode As TreeGridNode In node.Nodes
                    UnSiteNode(childNode)
                Next childNode

                ' now remove this row except for the root
                If (Not node.IsRoot) Then
                    MyBase.Rows.Remove(node)
                    ' Row isn't sited in the grid anymore after remove. Note that we cannot
                    ' Use the RowRemoved event since we cannot map from the row index to
                    ' the index of the expandable row/node.
                    node.UnSited()
                End If
            End If
        End Sub

        Overridable Function CollapseNode(ByVal node As TreeGridNode) As Boolean
            If node.IsExpanded Then
                Dim exp As CollapsingEventArgs = New CollapsingEventArgs(node)
                OnNodeCollapsing(exp)

                If (Not exp.Cancel) Then
                    LockVerticalScrollBarUpdate(True)
                    SuspendLayout()
                    _inExpandCollapse = True
                    node.IsExpanded = False

                    For Each childNode As TreeGridNode In node.Nodes
                        UnSiteNode(childNode)
                    Next childNode

                    Dim exped As CollapsedEventArgs = New CollapsedEventArgs(node)
                    OnNodeCollapsed(exped)
                    'TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = False
                    LockVerticalScrollBarUpdate(False)
                    ResumeLayout(True)
                    InvalidateCell(node.Cells(0))

                End If

                Return Not exp.Cancel
            Else
                ' row isn't expanded, so we didn't do anything.				
                Return False
            End If
        End Function

        Overridable Sub SiteNode(ByVal node As TreeGridNode)
            'TODO: Raise exception if parent node is not the root or is not sited.
            Dim rowIndex As Integer = -1

            Dim currentRowP As TreeGridNode
            node._grid = Me

            If Not node.Parent Is Nothing AndAlso node.Parent.IsRoot = False Then
                ' row is a child
                Debug.Assert(Not node.Parent Is Nothing AndAlso node.Parent.IsExpanded = True)

                If node.Index > 0 Then
                    currentRowP = CType(node.Parent.Nodes(node.Index - 1), TreeGridNode)
                Else
                    currentRowP = node.Parent
                End If
            Else
                ' row is being added to the root
                If node.Index > 0 Then
                    currentRowP = CType(node.Parent.Nodes(node.Index - 1), TreeGridNode)
                Else
                    currentRowP = Nothing
                End If

            End If

            If Not currentRowP Is Nothing Then
                Do While currentRowP.Level >= node.Level
                    If currentRowP.RowIndex < MyBase.Rows.Count - 1 Then
                        currentRowP = TryCast(MyBase.Rows(currentRowP.RowIndex + 1), TreeGridNode)
                        Debug.Assert(Not currentRowP Is Nothing)
                    Else
                        ' no more rows, site this node at the end.
                        Exit Do
                    End If

                Loop
                If currentRowP Is node.Parent Then
                    rowIndex = currentRowP.RowIndex + 1
                ElseIf currentRowP.Level < node.Level Then
                    rowIndex = currentRowP.RowIndex
                Else
                    rowIndex = currentRowP.RowIndex + 1
                End If
            Else
                rowIndex = 0
            End If


            Debug.Assert(rowIndex <> -1)
            SiteNode(node, rowIndex)

            Debug.Assert(node.IsSited)
            If node.IsExpanded Then
                ' add all child rows to display
                For Each childNode As TreeGridNode In node.Nodes
                    'TODO: could use the more efficient SiteRow with index.
                    SiteNode(childNode)
                Next childNode
            End If
        End Sub

        Protected Overridable Sub SiteNode(ByVal node As TreeGridNode, ByVal index As Integer)
            If index < MyBase.Rows.Count Then
                MyBase.Rows.Insert(index, node)
            Else
                ' for the last item.
                MyBase.Rows.Add(node)
            End If
        End Sub

        Overridable Function ExpandNode(ByVal node As TreeGridNode) As Boolean
            If (Not node.IsExpanded) OrElse _virtualNodes Then
                Dim exp As ExpandingEventArgs = New ExpandingEventArgs(node)
                OnNodeExpanding(exp)

                If (Not exp.Cancel) Then
                    LockVerticalScrollBarUpdate(True)
                    SuspendLayout()
                    _inExpandCollapse = True
                    node.IsExpanded = True

                    'TODO Convert this to a InsertRange
                    For Each childNode As TreeGridNode In node.Nodes
                        Debug.Assert(childNode.RowIndex = -1, "Row is already in the grid.")

                        SiteNode(childNode)
                    Next childNode

                    Dim exped As ExpandedEventArgs = New ExpandedEventArgs(node)
                    OnNodeExpanded(exped)
                    'TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = False
                    LockVerticalScrollBarUpdate(False)
                    ResumeLayout(True)
                    InvalidateCell(node.Cells(0))
                End If

                Return Not exp.Cancel
            Else
                ' row is already expanded, so we didn't do anything.
                Return False
            End If
        End Function

        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            ' used to keep extra mouse moves from selecting more rows when collapsing
            MyBase.OnMouseUp(e)
            _inExpandCollapseMouseCapture = False
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            ' while we are expanding and collapsing a node mouse moves are
            ' supressed to keep selections from being messed up.
            If (Not _inExpandCollapseMouseCapture) Then
                MyBase.OnMouseMove(e)
            End If
        End Sub
#End Region

#Region "Collapse/Expand events"

        Public Event NodeExpanding As ExpandingEventHandler
        Public Event NodeExpanded As ExpandedEventHandler
        Public Event NodeCollapsing As CollapsingEventHandler
        Public Event NodeCollapsed As CollapsedEventHandler

        Protected Overridable Sub OnNodeExpanding(ByVal e As ExpandingEventArgs)
            If Not NodeExpandingEvent Is Nothing Then
                RaiseEvent NodeExpanding(Me, e)
            End If
        End Sub

        Protected Overridable Sub OnNodeExpanded(ByVal e As ExpandedEventArgs)
            If Not NodeExpandedEvent Is Nothing Then
                RaiseEvent NodeExpanded(Me, e)
            End If
        End Sub

        Protected Overridable Sub OnNodeCollapsing(ByVal e As CollapsingEventArgs)
            If Not NodeCollapsingEvent Is Nothing Then
                RaiseEvent NodeCollapsing(Me, e)
            End If
        End Sub

        Protected Overridable Sub OnNodeCollapsed(ByVal e As CollapsedEventArgs)
            If Not NodeCollapsedEvent Is Nothing Then
                RaiseEvent NodeCollapsed(Me, e)
            End If
        End Sub

#End Region

#Region "Helper methods"
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            MyBase.Dispose(disposing)
            UnSiteAll()
        End Sub

        Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
            MyBase.OnHandleCreated(e)

            ' this control is used to temporarly hide the vertical scroll bar
            hideScrollBarControl = New Control()
            hideScrollBarControl.Visible = False
            hideScrollBarControl.Enabled = False
            hideScrollBarControl.TabStop = False
            ' control is disposed automatically when the grid is disposed
            Controls.Add(hideScrollBarControl)
        End Sub

        Protected Overrides Sub OnRowEnter(ByVal e As DataGridViewCellEventArgs)
            ' ensure full row select
            MyBase.OnRowEnter(e)
            If SelectionMode = DataGridViewSelectionMode.CellSelect OrElse (SelectionMode = DataGridViewSelectionMode.FullRowSelect AndAlso MyBase.Rows(e.RowIndex).Selected = False) Then
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
                MyBase.Rows(e.RowIndex).Selected = True
            End If
        End Sub

        Private Sub LockVerticalScrollBarUpdate(ByVal lockUpdate As Boolean)
            ' Temporarly hide/show the vertical scroll bar by changing its parent
            If (Not _inExpandCollapse) Then
                If lockUpdate Then
                    VerticalScrollBar.Parent = hideScrollBarControl
                Else
                    VerticalScrollBar.Parent = Me
                End If
            End If
        End Sub

        Protected Overrides Sub OnColumnAdded(ByVal e As DataGridViewColumnEventArgs)
            If GetType(TreeGridColumn).IsAssignableFrom(e.Column.GetType()) Then
                If _expandableColumn Is Nothing Then
                    ' identify the expanding column.			
                    _expandableColumn = CType(e.Column, TreeGridColumn)
                End If
            End If

            ' Expandable Grid doesn't support sorting. This is just a limitation of the sample.
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable

            MyBase.OnColumnAdded(e)
        End Sub

        Private NotInheritable Class Win32Helper
            Private Sub New()
            End Sub
            Public Const WM_SETREDRAW As Integer = &HB

            <System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
            Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
            End Function

            <System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet:=System.Runtime.InteropServices.CharSet.Auto)> _
            Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr
            End Function
        End Class
#End Region
    End Class
End Namespace
