' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.Extensions
Imports System.Collections.Generic
Imports System.Threading

Namespace DicomAnonymizer
   ''' <summary>
   ''' Summary description for InsertElementDlg.
   ''' </summary>
   Public Class InsertElementDlg : Inherits Form
      Private label1 As System.Windows.Forms.Label
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing
      Private WithEvents checkBoxChild As System.Windows.Forms.CheckBox
      Private WithEvents checkBoxFolder As System.Windows.Forms.CheckBox

      Private _Sequence As Boolean = False
      Private _Child As Boolean = True
      Private buttonCancel As System.Windows.Forms.Button
      Private WithEvents buttonOK As System.Windows.Forms.Button
      Private WithEvents listViewTags As TagListView
      Private columnHeaderTag As ColumnHeader
      Private columnHeaderName As ColumnHeader
      Private columnHeaderVr As ColumnHeader

      Private WithEvents textBoxSearch As TextBox

      Private _Sorter As ListViewColumnSorter = New ListViewColumnSorter()
      Private _Excludes As List(Of Long) = New List(Of Long)()
      Private _SearchWorker As BackgroundWorker = New BackgroundWorker()
      Private _TagThread As Thread = Nothing
      Private WithEvents buttonSearch As Button
      Private label2 As Label

      Public ReadOnly Property Sequence() As Boolean
         Get
            Return _Sequence
         End Get
      End Property

      Public ReadOnly Property Child() As Boolean
         Get
            Return _Child
         End Get
      End Property

      Private _Tags As List(Of Long) = New List(Of Long)()

      Public ReadOnly Property Tags() As List(Of Long)
         Get
            Return _Tags
         End Get
      End Property

      Public Sub New(ByVal excludedTags As List(Of Long))
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()
         If Not excludedTags Is Nothing AndAlso excludedTags.Count > 0 Then
            _Excludes.AddRange(excludedTags)
         End If
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"
      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me.label1 = New System.Windows.Forms.Label()
         Me.buttonCancel = New System.Windows.Forms.Button()
         Me.buttonOK = New System.Windows.Forms.Button()
         Me.checkBoxChild = New System.Windows.Forms.CheckBox()
         Me.checkBoxFolder = New System.Windows.Forms.CheckBox()
         Me.textBoxSearch = New System.Windows.Forms.TextBox()
         Me.buttonSearch = New System.Windows.Forms.Button()
         Me.listViewTags = New DicomAnonymizer.TagListView()
         Me.columnHeaderTag = New System.Windows.Forms.ColumnHeader()
         Me.columnHeaderName = New System.Windows.Forms.ColumnHeader()
         Me.columnHeaderVr = New System.Windows.Forms.ColumnHeader()
         Me.label2 = New System.Windows.Forms.Label()
         Me.SuspendLayout()
         ' 
         ' label1
         ' 
         Me.label1.Location = New System.Drawing.Point(10, 8)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(100, 16)
         Me.label1.TabIndex = 0
         Me.label1.Text = "Tag:"
         ' 
         ' buttonCancel
         ' 
         Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me.buttonCancel.Location = New System.Drawing.Point(539, 428)
         Me.buttonCancel.Name = "buttonCancel"
         Me.buttonCancel.Size = New System.Drawing.Size(75, 23)
         Me.buttonCancel.TabIndex = 2
         Me.buttonCancel.Text = "&Cancel"
         ' 
         ' buttonOK
         ' 
         Me.buttonOK.Location = New System.Drawing.Point(458, 428)
         Me.buttonOK.Name = "buttonOK"
         Me.buttonOK.Size = New System.Drawing.Size(75, 23)
         Me.buttonOK.TabIndex = 3
         Me.buttonOK.Text = "&OK"
         ' 
         ' checkBoxChild
         ' 
         Me.checkBoxChild.Checked = True
         Me.checkBoxChild.CheckState = System.Windows.Forms.CheckState.Checked
         Me.checkBoxChild.Location = New System.Drawing.Point(324, 415)
         Me.checkBoxChild.Name = "checkBoxChild"
         Me.checkBoxChild.Size = New System.Drawing.Size(104, 24)
         Me.checkBoxChild.TabIndex = 4
         Me.checkBoxChild.Text = "Insert as child"
         Me.checkBoxChild.Visible = False
         ' 
         ' checkBoxFolder
         ' 
         Me.checkBoxFolder.Location = New System.Drawing.Point(324, 438)
         Me.checkBoxFolder.Name = "checkBoxFolder"
         Me.checkBoxFolder.Size = New System.Drawing.Size(128, 24)
         Me.checkBoxFolder.TabIndex = 5
         Me.checkBoxFolder.Text = "Element is a folder"
         Me.checkBoxFolder.Visible = False
         ' 
         ' textBoxSearch
         ' 
         Me.textBoxSearch.AcceptsReturn = True
         Me.textBoxSearch.Location = New System.Drawing.Point(313, 7)
         Me.textBoxSearch.Name = "textBoxSearch"
         Me.textBoxSearch.Size = New System.Drawing.Size(227, 20)
         Me.textBoxSearch.TabIndex = 7
         ' 
         ' buttonSearch
         ' 
         Me.buttonSearch.Location = New System.Drawing.Point(540, 4)
         Me.buttonSearch.Name = "buttonSearch"
         Me.buttonSearch.Size = New System.Drawing.Size(75, 23)
         Me.buttonSearch.TabIndex = 8
         Me.buttonSearch.Text = "Search"
         Me.buttonSearch.UseVisualStyleBackColor = True
         ' 
         ' listViewTags
         ' 
         Me.listViewTags.CheckBoxes = True
         Me.listViewTags.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeaderTag, Me.columnHeaderName, Me.columnHeaderVr})
         Me.listViewTags.FullRowSelect = True
         Me.listViewTags.HideSelection = False
         Me.listViewTags.Location = New System.Drawing.Point(13, 28)
         Me.listViewTags.Name = "listViewTags"
         Me.listViewTags.Size = New System.Drawing.Size(601, 381)
         Me.listViewTags.TabIndex = 6
         Me.listViewTags.UseCompatibleStateImageBehavior = False
         Me.listViewTags.View = System.Windows.Forms.View.Details
         ' 
         ' columnHeaderTag
         ' 
         Me.columnHeaderTag.Text = "Tag"
         Me.columnHeaderTag.Width = 119
         ' 
         ' columnHeaderName
         ' 
         Me.columnHeaderName.Text = "Name"
         Me.columnHeaderName.Width = 328
         ' 
         ' columnHeaderVr
         ' 
         Me.columnHeaderVr.Text = "VR"
         Me.columnHeaderVr.Width = 150
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(263, 14)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(44, 13)
         Me.label2.TabIndex = 9
         Me.label2.Text = "Search:"
         ' 
         ' InsertElementDlg
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me.buttonCancel
         Me.ClientSize = New System.Drawing.Size(626, 463)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.buttonSearch)
         Me.Controls.Add(Me.textBoxSearch)
         Me.Controls.Add(Me.listViewTags)
         Me.Controls.Add(Me.checkBoxFolder)
         Me.Controls.Add(Me.checkBoxChild)
         Me.Controls.Add(Me.buttonOK)
         Me.Controls.Add(Me.buttonCancel)
         Me.Controls.Add(Me.label1)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "InsertElementDlg"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Insert Element"
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub
#End Region

      Private Sub InsertElementDlg_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         listViewTags.ListViewItemSorter = _Sorter
         AddHandler _SearchWorker.DoWork, AddressOf SearchWorker_DoWork
         _SearchWorker.WorkerSupportsCancellation = True
         LoadTags()
      End Sub

      Private Sub checkBoxChild_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkBoxChild.CheckedChanged
         _Child = checkBoxChild.Checked
      End Sub

      Private Sub checkBoxFolder_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles checkBoxFolder.CheckedChanged
         _Sequence = checkBoxFolder.Checked
      End Sub

      Private Sub LoadTags()
         _TagThread = New Thread(AddressOf LoadTagsThread)
         _TagThread.Start()
      End Sub

      Public Sub LoadTagsThread()
         Dim tag As DicomTag

         Try
            tag = DicomTagTable.Instance.GetFirst()
            Do While Not tag Is Nothing
               If tag.Code <> DicomTag.DataSetTrailingPadding AndAlso tag.Code <> DicomTag.ItemDelimitationItem AndAlso tag.Code <> DicomTag.SequenceDelimitationItem AndAlso tag.Code <> DicomTag.CommandGroupLength AndAlso tag.Code.GetElement() <> 0 Then
                  Dim item As ListViewItem = New ListViewItem()

                  item.Text = String.Format("({0:X4},{1:X4})", tag.Code.GetGroup(), tag.Code.GetElement())
                  item.SubItems.Add(tag.Name)
                  item.SubItems.Add(tag.VR.ToString())
                  item.Tag = tag.Code
                  If _Excludes.Contains(tag.Code) Then
                     item.ForeColor = SystemColors.InactiveCaptionText
                     item.Font = New Font(item.Font, FontStyle.Strikeout)
                  End If
                  Invoke(New AddListItemDelegate(AddressOf AddListItem), item)
               End If
               Thread.Sleep(1)
               tag = DicomTagTable.Instance.GetNext(tag)
            Loop
         Catch
         End Try
      End Sub

      Private Delegate Sub AddListItemDelegate(ByVal item As ListViewItem)

      Public Sub AddListItem(ByVal item As ListViewItem)
         listViewTags.Items.Add(item)
         Application.DoEvents()
      End Sub

      Public Sub SynchronizedInvoke(ByVal del As MethodInvoker)
         If InvokeRequired Then
            Invoke(del, Nothing)
         Else
            del()
         End If
      End Sub

      Private Sub buttonSearch_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonSearch.Click
         _Sorter.ShowHeaderIcon(listViewTags, _Sorter.SortColumn, SortOrder.None)
         _Sorter.Order = SortOrder.None
         listViewTags.Sort()
         SearchListView(listViewTags, textBoxSearch.Text)
      End Sub

      Private Sub SearchListView(ByVal listView As ListView, ByVal txtFind As String)
         Dim lastIndex As Integer = 0
         Dim foundItem As ListViewItem = Nothing

         listView.SelectedItems.Clear()
         foundItem = listView.FindItemWithText(txtFind, True, lastIndex)
         Do While Not foundItem Is Nothing
            lastIndex = foundItem.Index + 1
            listView.Items.Remove(foundItem)
            listView.Items.Insert(0, foundItem)
            If lastIndex >= listView.Items.Count Then
               foundItem = Nothing
            Else
               foundItem = listView.FindItemWithText(txtFind, True, lastIndex)
            End If
         Loop
      End Sub

      Private Sub listViewTags_ItemChecked(ByVal sender As Object, ByVal e As ItemCheckedEventArgs) Handles listViewTags.ItemChecked
         Dim tag As Long = CLng(e.Item.Tag)

         If e.Item.Checked = True Then
            If (Not _Tags.Contains(tag)) Then
               _Tags.Add(tag)
            End If
         Else
            If _Tags.Contains(tag) Then
               _Tags.Remove(tag)
            End If
         End If
      End Sub

      Private Sub listViewTags_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles listViewTags.ColumnClick
         _Sorter.ShowHeaderIcon(listViewTags, _Sorter.SortColumn, SortOrder.None)
         If e.Column = _Sorter.SortColumn Then
            ' Reverse the current sort direction for this column.
            If _Sorter.Order = SortOrder.Ascending Then
               _Sorter.Order = SortOrder.Descending
            Else
               _Sorter.Order = SortOrder.Ascending
            End If
         Else
            ' Set the column number that is to be sorted; default to ascending.
            _Sorter.SortColumn = e.Column
            _Sorter.Order = SortOrder.Ascending
         End If
         listViewTags.Sort()
         _Sorter.ShowHeaderIcon(listViewTags, e.Column, _Sorter.Order)
      End Sub

      Private Sub listViewTags_ItemCheck(ByVal sender As Object, ByVal e As ItemCheckEventArgs) Handles listViewTags.ItemCheck
         Dim tag As Long = CLng(listViewTags.Items(e.Index).Tag)

         If e.NewValue = CheckState.Checked AndAlso _Excludes.Contains(tag) Then
            e.NewValue = CheckState.Unchecked
         End If
      End Sub

      Private Sub SearchWorker_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
         Dim lastIndex As Integer = 0
         Dim foundItem As ListViewItem = Nothing
         Dim txtFind As String = TryCast(e.Argument, String)
         Dim bg As BackgroundWorker = TryCast(sender, BackgroundWorker)

         foundItem = CType(Invoke(New InsertItemDelegate(AddressOf FindFirst), txtFind, lastIndex), ListViewItem)

         Do While Not foundItem Is Nothing
            If bg.CancellationPending Then
               Exit Do
            End If
            lastIndex = foundItem.Index + 1
            foundItem = CType(Invoke(New InsertItemDelegate(AddressOf InsertItem), txtFind, lastIndex), ListViewItem)
         Loop
      End Sub

      Delegate Function InsertItemDelegate(ByVal foundItem As ListViewItem, ByVal txtFind As String, ByVal lastIndex As Integer) As ListViewItem

      Private Function FindFirst(ByVal foundItem As ListViewItem, ByVal txtFind As String, ByVal lastIndex As Integer) As ListViewItem
         listViewTags.SelectedItems.Clear()
         Return listViewTags.FindItemWithText(txtFind, True, lastIndex)
      End Function

      Private Function InsertItem(ByVal foundItem As ListViewItem, ByVal txtFind As String, ByVal lastIndex As Integer) As ListViewItem
         listViewTags.Items(foundItem.Index).Selected = True
         listViewTags.Items.Remove(foundItem)
         listViewTags.Items.Insert(0, foundItem)
         Return listViewTags.FindItemWithText(txtFind, True, lastIndex)
      End Function

      Private Sub textBoxSearch_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles textBoxSearch.KeyPress
      End Sub

      Private Sub textBoxSearch_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles textBoxSearch.KeyDown
         If e.KeyCode = Keys.Enter Then
            _Sorter.ShowHeaderIcon(listViewTags, _Sorter.SortColumn, SortOrder.None)
            _Sorter.Order = SortOrder.None
            listViewTags.Sort()
            SearchListView(listViewTags, textBoxSearch.Text)
            e.Handled = True
         End If
      End Sub

      Private Sub buttonOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonOK.Click
         DialogResult = System.Windows.Forms.DialogResult.OK
         Close()
      End Sub

      Private Sub InsertElementDlg_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
         If Not _TagThread Is Nothing AndAlso _TagThread.IsAlive Then
            _TagThread.Abort()
            _TagThread.Join()
         End If
      End Sub

      Private Sub textBoxSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles textBoxSearch.TextChanged
         buttonSearch.Enabled = textBoxSearch.Text.Length > 0
      End Sub
   End Class

   Friend Class TagListView : Inherits ListView
      Public Sub New()
         'Activate double buffering
         SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)

         'Enable the OnNotifyMessage event so we get a chance to filter out 
         ' Windows messages before they get to the form's WndProc
         SetStyle(ControlStyles.EnableNotifyMessage, True)
      End Sub

      Protected Overrides Sub OnNotifyMessage(ByVal m As Message)
         'Filter out the WM_ERASEBKGND message
         If m.Msg <> &H14 Then
            MyBase.OnNotifyMessage(m)
         End If
      End Sub
   End Class
End Namespace
