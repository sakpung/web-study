' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports Leadtools.WinForms
Imports Leadtools
Imports System.Runtime.InteropServices
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Serialization

Namespace PrintToPACSDemo
   Public Enum ThumbMode
   Expanded
   Condensed
   End Enum

   Public Enum SelectionDirection
   Left
   Right
   None
   End Enum

   Friend Class ListImageBox : Inherits System.Windows.Forms.ScrollableControl
   Public Event SelectedIndexChanged As EventHandler
   Public Event ItemAdded As EventHandler
   Public Event ItemChecked As EventHandler
   Public Event ListStateChanged As EventHandler
   Public Event ItemDeSlect As EventHandler

   Private imgPlus As Image
   Private imgMinus As Image
   Private selDirection As SelectionDirection = SelectionDirection.None
   Private StartSelection As Integer = -1

   Public Sub New()
   AutoScroll = True
   Dim thisExe As System.Reflection.Assembly
   thisExe = System.Reflection.Assembly.GetExecutingAssembly()
   imgPlus = Global.Resources.Plus
   imgMinus = Global.Resources.Minus
   _selectedIndex = -1
   AddHandler Click, AddressOf ListImageBox_Click
   AddHandler KeyDown, AddressOf ListImageBox_KeyDown
   _ItemHeight = 120
   _ExpansionButtonLocation = AnchorStyles.Left
   AddHandler Resize, AddressOf ListImageBox_Resize
   End Sub

   Private Sub ListImageBox_Resize(ByVal sender As Object, ByVal e As EventArgs)
   ItemHeight = Me.Height - 33
   End Sub

#Region "Properties"

   Private _lstItems As List(Of ListItem) = New List(Of ListItem)()
   Public ReadOnly Property Items() As List(Of ListItem)
   Get
    Return _lstItems
   End Get
   End Property

   Public ReadOnly Property CheckedItems() As List(Of ListItem)
   Get
   Dim lst As List(Of ListItem) = New List(Of ListItem)()
   For Each item As ListItem In Items
      If item.ImageItem.Checked = True Then
      lst.Add(item)
      End If
   Next item

   Return lst
   End Get
   End Property

   Public ReadOnly Property SelectedItems() As List(Of ListItem)
   Get
   Dim lst As List(Of ListItem) = New List(Of ListItem)()
   For Each item As ListItem In Items
      If item.Selected = True Then
      lst.Add(item)
      End If
   Next item

   Return lst
   End Get
   End Property

   Private _lstImageCollection As List(Of ImageCollection) = New List(Of ImageCollection)()
   Public ReadOnly Property ImageCollections() As List(Of ImageCollection)
   Get
    Return _lstImageCollection
   End Get
   End Property

   Private _ExpansionButtonLocation As AnchorStyles

   Public Property ExpansionButtonLocation() As AnchorStyles
   Get
    Return _ExpansionButtonLocation
   End Get
   Set(ByVal value As AnchorStyles)
   If mode = ThumbMode.Expanded OrElse Value = AnchorStyles.Top OrElse Value = AnchorStyles.Bottom OrElse Value = AnchorStyles.None OrElse Value = _ExpansionButtonLocation Then
      Return
   End If
   _ExpansionButtonLocation = Value
   UpdateList()
   End Set
   End Property

   Public Property SelectedGroupIndex() As Integer
   Get
   If mode = ThumbMode.Expanded OrElse _selectedItem Is Nothing Then
      Return -1
   End If

   Dim parent As Control = _selectedItem._Controls.Parent
   Return Me.Controls.IndexOf(parent)
   End Get
   Set(ByVal value As Integer)
   If mode = ThumbMode.Expanded OrElse Value = -1 Then
      Return
   End If

   Try
      Dim parent As Control = Controls(Value)
      Dim index As Integer = CInt(parent.Controls(1).Controls(0).Controls(1).Tag)

      SelectItem(index, True)
      ScrollControlIntoView(_selectedItem._Controls)
   Catch ex As System.Exception
      Throw ex
   End Try
   End Set
   End Property

   Public Property SelectedItemGroupIndex() As Integer
   Get
   If mode = ThumbMode.Expanded OrElse _selectedItem Is Nothing Then
      Return -1
   End If

   Dim parent As Control = _selectedItem._Controls.Parent
   Return parent.Controls.IndexOf(_selectedItem._Controls) - 1
   End Get
   Set(ByVal value As Integer)
   Try
      If mode = ThumbMode.Expanded OrElse Value = -1 Then
      Return
      End If

      Dim parent As Control = _selectedItem._Controls.Parent
      Dim child As Control = parent.Controls(Value + 1)
      Dim index As Integer = CInt(child.Controls(0).Controls(0).Tag)

      SelectItem(index, True)
      ScrollControlIntoView(_selectedItem._Controls)
   Catch ex As System.Exception
      Throw ex
   End Try
   End Set
   End Property

   Private _selectedIndex As Integer
   Public Property SelectedIndex() As Integer
   Get
    Return _selectedIndex
   End Get
   Set(ByVal value As Integer)
   Try
      If Value = -1 Then
      Return
      End If

      _selectedItem = Items(Value)
      _selectedIndex = Value
      SelectItem(Value, True)
      ScrollControlIntoView(_selectedItem._Controls)
   Catch ex As System.Exception
      Throw ex
   End Try
   End Set
   End Property

   Private _ItemHeight As Integer
   Public Property ItemHeight() As Integer
   Get
    Return _ItemHeight
   End Get
   Set(ByVal value As Integer)
   If Value = _ItemHeight OrElse Value < 100 OrElse Value > 300 Then
      Return
   End If

   _ItemHeight = Value
   UpdateList()
   End Set
   End Property

   Private _selectedItem As ListItem
   Public Property SelectedItem() As ListItem
   Get
    Return _selectedItem
   End Get
   Set(ByVal value As ListItem)
    _selectedItem = Value
   End Set
   End Property

   Private mode As ThumbMode = ThumbMode.Condensed
   Public Property ViewMode() As ThumbMode
   Get
    Return mode
   End Get
   Set(ByVal value As ThumbMode)
   If mode = Value Then
      Return
   End If

   mode = Value
   Me.Items.Clear()
   Me.Controls.Clear()
   For Each collection As ImageCollection In _lstImageCollection
      If mode = ThumbMode.Condensed Then
      AddItemCondensed(collection)
      Else
      AddItemExpanded(collection)
      End If
   Next collection
   If SelectedIndex >= 0 AndAlso SelectedIndex < Items.Count Then
      Me.SelectItem(SelectedIndex, True)
   End If
   End Set
   End Property

#End Region

#Region "Selection"

   Private Sub SelectItem(ByVal index As Integer, ByVal bModfier As Boolean)
   If Items.Count = 0 Then
   Return
   End If

   If bModfier Then
   UnSelectItems()
   End If

   _selectedItem = Items(index)
   _selectedIndex = index

   If mode = ThumbMode.Condensed AndAlso Not (Items(index)._Controls).Visible Then
   Expand(TryCast((Items(index)._Controls).Parent, GroupBox))
   End If

   Items(index).Selected = (Not Items(index).Selected) OrElse bModfier

   If SelectedItems.Count = 0 Then
   _selectedIndex = -1
   _selectedItem = Nothing
   If Not ItemDeSlectEvent Is Nothing Then
      ItemDeSlectEvent.Invoke(Nothing, Nothing)
   End If
   Else
   If Not SelectedIndexChangedEvent Is Nothing Then
      SelectedIndexChangedEvent.Invoke(Nothing, Nothing)
   End If
   End If
   End Sub

   Private Sub UnSelectItems()
   For Each item As ListItem In Items
   item.Selected = False
   Next item
   _selectedIndex = -1
   _selectedItem = Nothing
   End Sub

#End Region

#Region "Delete Methods"

   Public Sub RemoveGroup(ByVal index As Integer)
   If mode = ThumbMode.Expanded Then
   Return
   End If

   Dim grpBox As GroupBox = TryCast(Me.Controls(index), GroupBox)
   Dim collection As ImageCollection = _lstImageCollection(index)

   'Store Collapsed
   Dim bExpansionStatus As List(Of Boolean) = New List(Of Boolean)()
   For Each cntrl As Control In Me.Controls
   bExpansionStatus.Add(CBool(cntrl.Controls(0).Tag))
   Next cntrl

   'GroupCheck status
   Dim bGroupCheck As List(Of CheckState) = New List(Of CheckState)()
   For Each cntrl As Control In Me.Controls
   bGroupCheck.Add(CType(cntrl.Tag, CheckState))
   Next cntrl

   For Each listItem As ListItem In Items
   If listItem.ImageItem.Parent Is collection Then
      listItem.Dispose()
   End If
   Next listItem

   collection.Images.Clear()

   _lstImageCollection.RemoveAt(index)
   bExpansionStatus.RemoveAt(index)
   bGroupCheck.RemoveAt(index)
   collection = Nothing

   UpdateGroups()

   'Restore Collapsed
   For ii As Integer = 0 To bExpansionStatus.Count - 1
   If bExpansionStatus(ii) Then
      Expand(TryCast(Me.Controls(ii), GroupBox))
   Else
      Collapse(TryCast(Me.Controls(ii), GroupBox))
   End If
   Next ii

   Dim i As Integer = 0
   Do While i < bGroupCheck.Count
   Me.Controls(i).Tag = bGroupCheck(i)
    i += 1
   Loop

   If Not ListStateChangedEvent Is Nothing Then
   ListStateChangedEvent.Invoke(Me, Nothing)
   End If
   End Sub

   Public Sub RemoveItem(ByVal index As Integer)
   If index = _selectedIndex Then
   _selectedIndex = -1
   _selectedItem = Nothing
   End If
   If mode = ThumbMode.Expanded Then
   DeleteItemExpanded(index)
   Else
   DeleteItemCondensed(index)
   End If

   If Not ListStateChangedEvent Is Nothing Then
   ListStateChangedEvent.Invoke(Me, Nothing)
   End If
   End Sub

   Private Sub DeleteItemExpanded(ByVal index As Integer)
   Dim itemtodelete As ListItem = Items(index)
   Dim collection As ImageCollection = Nothing

   For Each col As ImageCollection In _lstImageCollection
   If col.Images.Contains(itemtodelete.ImageItem) Then
      collection = col
      Exit For
   End If
   Next col

   itemtodelete.Dispose()
   collection.Images.Remove(itemtodelete.ImageItem)

   If collection.Images.Count = 0 Then
   _lstImageCollection.Remove(collection)
   collection = Nothing
   End If

   UpdateItems()

   End Sub

   Private Sub DeleteItemCondensed(ByVal index As Integer)
   Dim itemtodelete As ListItem = Items(index)
   Dim grpBox As GroupBox = TryCast((itemtodelete._Controls).Parent, GroupBox)
   Dim bExpanded As Boolean = CBool(grpBox.Controls(0).Tag)

   Dim iGroup As Integer = Controls.IndexOf(grpBox)
   Dim collection As ImageCollection = _lstImageCollection(iGroup)

   'Store Collapsed
   Dim bExpansionStatus As List(Of Boolean) = New List(Of Boolean)()
   For Each cntrl As Control In Me.Controls
   bExpansionStatus.Add(CBool(cntrl.Controls(0).Tag))
   Next cntrl

   'GroupCheck status
   Dim bGroupCheck As List(Of CheckState) = New List(Of CheckState)()
   For Each cntrl As Control In Me.Controls
   bGroupCheck.Add(CType(cntrl.Tag, CheckState))
   Next cntrl

   itemtodelete.Selected = False
   If (Not bExpanded) Then
   'RemoveGroup
   For Each listItem As ListItem In Items
      If listItem.ImageItem.Parent Is collection Then
      listItem.Dispose()
      End If
   Next listItem
   collection.Images.Clear()
   Else
   'RemoveItem
   itemtodelete.Dispose()
   collection.Images.Remove(itemtodelete.ImageItem)
   End If

   If collection.Images.Count = 0 Then
   _lstImageCollection.RemoveAt(iGroup)
   bExpansionStatus.RemoveAt(iGroup)
   bGroupCheck.RemoveAt(iGroup)
   collection = Nothing
   End If

   'Store Selected
   Dim bSelectionStatus As List(Of Boolean) = New List(Of Boolean)()
   For Each lstItem As ListItem In Me.Items
   bSelectionStatus.Add(lstItem.Selected)
   Next lstItem


   UpdateGroups()

   'Restore Collapsed
   For iExpCount As Integer = 0 To bExpansionStatus.Count - 1
   If bExpansionStatus(iExpCount) Then
      Expand(TryCast(Me.Controls(iExpCount), GroupBox))
   Else
      Collapse(TryCast(Me.Controls(iExpCount), GroupBox))
   End If
   Next iExpCount

   Dim iGroupCount As Integer = 0
   Do While iGroupCount < bGroupCheck.Count
   Me.Controls(iGroupCount).Tag = bGroupCheck(iGroupCount)
    iGroupCount += 1
   Loop

   'Restore Selected
   Dim i As Integer = 0
   Do While i < Items.Count
   Items(i).Selected = bSelectionStatus(i)
    i += 1
   Loop

   End Sub

   Public Sub ClearList()
   For Each imgCol As ImageCollection In _lstImageCollection
   For Each imgItem As ImageItem In imgCol.Images
      imgItem.Image.Dispose()
   Next imgItem
   Next imgCol
   Items.Clear()
   _lstImageCollection.Clear()
   _selectedIndex = -1
   _selectedItem = Nothing
   Controls.Clear()
   End Sub

#End Region

#Region "Methods"

   Public Sub UpdateList()
   If mode = ThumbMode.Expanded Then
   UpdateItems()
   Else
   UpdateGroups()
   End If
   End Sub

   Private Sub UpdateItems()
   Items.Clear()
   Me.Controls.Clear()

   For Each imgCol As ImageCollection In _lstImageCollection
   AddItemExpanded(imgCol)
   Next imgCol
   End Sub

   Private Sub UpdateGroups()
   Items.Clear()
   Me.Controls.Clear()

   For Each imgCol As ImageCollection In _lstImageCollection
   AddItemCondensed(imgCol)
   Next imgCol
   End Sub

   Friend Function GetGroupItems(ByVal GroupBoxImageCollection As GroupBox) As List(Of ListItem)
   Dim itemsParam As List(Of ListItem) = New List(Of ListItem)()
   If ViewMode = ThumbMode.Condensed Then
   For Each item As ListItem In Items
      If (CType(item._Controls, Control)).Parent Is GroupBoxImageCollection Then
      itemsParam.Add(item)
      End If
   Next item
   End If

   Return itemsParam
   End Function

   Public Function GetGroupImageItems() As List(Of ImageItem)
   Dim itemsParam As List(Of ImageItem) = New List(Of ImageItem)()
   If ViewMode <> ThumbMode.Condensed Then
   For Each imgCol As ImageCollection In _lstImageCollection
      itemsParam.AddRange(imgCol.Images.ToArray())
   Next imgCol
   Else

   If Not _selectedItem Is Nothing Then
      Dim index As Integer = Me.Controls.IndexOf((_selectedItem._Controls).Parent)
      itemsParam.AddRange(_lstImageCollection(index).Images.ToArray())
   End If
   End If

   Return itemsParam
   End Function

   Public Function GetSelectedImageCollection() As ImageCollection
   Try
   Dim collection As ImageCollection = Nothing
   If ViewMode = ThumbMode.Condensed Then
      collection = ImageCollections(SelectedGroupIndex)
   Else
      For Each col As ImageCollection In ImageCollections
      If col.Images.Contains(_selectedItem.ImageItem) Then
      collection = col
      Exit For
      End If
      Next col
   End If
   Return collection
   Catch
    Return New ImageCollection("")
   End Try
   End Function

#End Region

#Region "Item Addition"

   Public Sub AddImageCollection(ByVal imagecollection As ImageCollection)
   _lstImageCollection.Add(imagecollection)
   If mode = ThumbMode.Condensed Then
   AddItemCondensed(imagecollection)
   Else
   AddItemExpanded(imagecollection)
   End If
   If Not ListStateChangedEvent Is Nothing Then
   ListStateChangedEvent.Invoke(Me, Nothing)
   End If
   End Sub

   Private Sub AddItemCondensed(ByVal imagecollection As ImageCollection)
   Dim GroupBoxImageCollection As GroupBox
   GroupBoxImageCollection = New GroupBox()
   FillGroupBox(imagecollection, GroupBoxImageCollection)
   If Me.Controls.Count = 0 Then
   GroupBoxImageCollection.Location = New Point(5, 0)
   End If

   Me.Controls.Add(GroupBoxImageCollection)
   Collapse(GroupBoxImageCollection)
   If Not ItemAddedEvent Is Nothing Then
   ItemAddedEvent.Invoke(Nothing, Nothing)
   End If
   End Sub

   Private Sub AddItemExpanded(ByVal imagecollection As ImageCollection)
   Dim PanelItem As Panel = Nothing
   Dim index As Integer

   For Each img As ImageItem In imagecollection.Images
   index = Me.Controls.Count
   CreateItemPanel(img, imagecollection.Name, index, PanelItem)
   PanelItem.Location = New Point(index * PanelItem.Width, 0)
   AddHandler PanelItem.Controls(0).Controls(0).Click, AddressOf ExpandedCheck_Click
   Me.Controls.Add(PanelItem)
   If img.Checked Then
      Items.Add(New ListItem(CheckState.Checked, img, PanelItem, Me))
   Else
      Items.Add(New ListItem(CheckState.Unchecked, img, PanelItem, Me))
   End If

   If Not ItemAddedEvent Is Nothing Then
      ItemAddedEvent.Invoke(Nothing, Nothing)
   End If
   Next img
   End Sub

   Private Sub Expand(ByVal GroupBoxImageCollection As GroupBox)
   Dim index As Integer = 0
   Dim imagecollection As ImageCollection = _lstImageCollection(Me.Controls.IndexOf(GroupBoxImageCollection))
   For Each control As Control In GroupBoxImageCollection.Controls
   control.Visible = True
   index += 1
   Next control
   GroupBoxImageCollection.Size = New Size(GroupBoxImageCollection.Controls(GroupBoxImageCollection.Controls.Count - 1).Right + 10, ItemHeight + 15)
   GroupBoxImageCollection.Controls(0).Visible = imagecollection.Images.Count <> 1

   Dim check As CheckBox = (TryCast(GroupBoxImageCollection.Controls(1).Controls(0).Controls(0), CheckBox))
   If check.CheckState = CheckState.Indeterminate Then
   check.Checked = False
   check.CheckState = CType(GroupBoxImageCollection.Tag, CheckState)
   End If

       CType(GroupBoxImageCollection.Controls(0), Button).Image = imgMinus
   GroupBoxImageCollection.Controls(0).Tag = True
   ReCalculateSize(index)
   End Sub

   Private Sub Collapse(ByVal GroupBoxImageCollection As GroupBox)
   Dim index As Integer = 0
   Dim imagecollection As ImageCollection = _lstImageCollection(Me.Controls.IndexOf(GroupBoxImageCollection))
   For Each control As Control In GroupBoxImageCollection.Controls
   control.Visible = (index = 0 OrElse index = 1)
   index += 1
   Next control
   GroupBoxImageCollection.Size = New Size(GroupBoxImageCollection.Controls(1).Right + 10, ItemHeight + 15)
   GroupBoxImageCollection.Controls(0).Visible = imagecollection.Images.Count <> 1

   Dim bAllChecked As Boolean = True
   Dim bOneChecked As Boolean = False

   For Each control As Control In GroupBoxImageCollection.Controls
   If control.GetType() Is GetType(Panel) Then
      Dim item As ListItem = Items(CInt(control.Tag))

      If item.CheckState = CheckState.Checked Then
      bOneChecked = True
      Else
      bAllChecked = False
      End If
   End If
   index += 1
   Next control
   Dim FirstItem As ListItem = Items(CInt(GroupBoxImageCollection.Controls(1).Tag))
   GroupBoxImageCollection.Tag = FirstItem.CheckState

   If bOneChecked AndAlso (Not bAllChecked) Then
   FirstItem.CheckState = CheckState.Indeterminate
   End If

   If bAllChecked Then
   FirstItem.CheckState = CheckState.Checked
   End If

   If SelectedIndex < Items.Count AndAlso SelectedIndex >= 0 Then
   If GetGroupItems(GroupBoxImageCollection).Contains(Items(SelectedIndex)) Then
      SelectItem(CInt(GroupBoxImageCollection.Controls(1).Tag), True)
   End If
   End If

   CType(GroupBoxImageCollection.Controls(0), Button).Image = imgPlus
   GroupBoxImageCollection.Controls(0).Tag = False
   ReCalculateSize(index)
   End Sub

   Private Sub ReCalculateSize(ByVal start As Integer)
   Me.ScrollControlIntoView(Me.Controls(0))
   Dim lastRight As Integer = Me.Controls(0).Width + 10

   Dim i As Integer = 1
   Do While i < Me.Controls.Count
   Dim grpBox As GroupBox = CType(Me.Controls(i), GroupBox)

   grpBox.Location = New Point(lastRight, 0)
   lastRight += grpBox.Width + 5
    i += 1
   Loop
   End Sub

   Private Sub FillGroupBox(ByVal imagecollection As ImageCollection, ByVal GroupBoxImageCollection As GroupBox)
   Dim ButtonExpansion As Button = New Button()
   Dim PanelItem As System.Windows.Forms.Panel = Nothing
   GroupBoxImageCollection.BackColor = Me.BackColor
   GroupBoxImageCollection.Controls.Add(ButtonExpansion)

   'Button
   ButtonExpansion.Anchor = (CType((AnchorStyles.Top Or ExpansionButtonLocation), AnchorStyles))
   ButtonExpansion.FlatStyle = FlatStyle.Popup
   ButtonExpansion.Image = imgPlus
   ButtonExpansion.BackColor = SystemColors.AppWorkspace
   ButtonExpansion.Size = New Size(15, 16)

   If ExpansionButtonLocation = AnchorStyles.Left Then
   ButtonExpansion.Location = New Point(5, 14)
   Else
   ButtonExpansion.Location = New Point(GroupBoxImageCollection.Width - 18, 8)
   End If

   ButtonExpansion.Tag = False
   GroupBoxImageCollection.Controls.Add(ButtonExpansion)

   AddHandler ButtonExpansion.KeyDown, AddressOf ListImageBoxControls_KeyDown
   AddHandler GroupBoxImageCollection.KeyDown, AddressOf ListImageBoxControls_KeyDown
   AddHandler ButtonExpansion.GotFocus, AddressOf ItemGotFocus
   AddHandler GroupBoxImageCollection.GotFocus, AddressOf ItemGotFocus

   GroupBoxImageCollection.Tag = False
   GroupBoxImageCollection.Text = imagecollection.Name
   AddHandler ButtonExpansion.Click, AddressOf ButtonExpansion_Click

   'Add All Items
   Dim index As Integer = 0
   Dim iExpansionDisplacment As Integer = 15
   If ExpansionButtonLocation = AnchorStyles.Right Then
   iExpansionDisplacment = 3
   End If

   For Each img As ImageItem In imagecollection.Images
   CreateItemPanel(img, "", index, PanelItem)
   PanelItem.Location = New Point(index * PanelItem.Width + iExpansionDisplacment, 14)

   AddHandler PanelItem.Controls(0).Controls(0).Click, AddressOf CondensedCheck_Click
   index += 1
   GroupBoxImageCollection.Controls.Add(PanelItem)
   If img.Checked Then
      Items.Add(New ListItem(CheckState.Checked, img, PanelItem, Me))
   Else
      Items.Add(New ListItem(CheckState.Unchecked, img, PanelItem, Me))
   End If
   Next img
   End Sub

   Private Sub CreateItemPanel(ByVal item As ImageItem, ByVal itemName As String, ByVal index As Integer, <System.Runtime.InteropServices.Out()> ByRef PanelItem As System.Windows.Forms.Panel)

   Dim CheckBoxItem As System.Windows.Forms.CheckBox
   Dim PanelBackGround As System.Windows.Forms.Panel
   Dim PanelTextBackColor As System.Windows.Forms.Panel
   Dim LabelText As System.Windows.Forms.Label
   Dim Picturebox As RasterImageViewer

   PanelItem = New System.Windows.Forms.Panel()
   CheckBoxItem = New System.Windows.Forms.CheckBox()
   PanelBackGround = New System.Windows.Forms.Panel()
   PanelTextBackColor = New System.Windows.Forms.Panel()
   LabelText = New System.Windows.Forms.Label()
   Picturebox = New RasterImageViewer()

   ' 
   ' PanelItem
   ' 
   PanelItem.Controls.Add(PanelBackGround)
   PanelItem.BackColor = Me.BackColor
   PanelItem.Location = New Point(73, 46)
   PanelItem.Size = New Size(CInt(CDbl(ItemHeight) * 0.86), ItemHeight)
   ' 
   ' CheckBoxItem
   ' 
   CheckBoxItem.AutoSize = True
   CheckBoxItem.Location = New Point(4, 5)
   CheckBoxItem.Size = New Size(12, 11)
   CheckBoxItem.FlatStyle = FlatStyle.Standard
   CheckBoxItem.UseVisualStyleBackColor = True
   ' 
   ' PanelBackGround
   ' 
   PanelBackGround.BackColor = Me.BackColor
   PanelBackGround.Controls.Add(CheckBoxItem)
   PanelBackGround.Controls.Add(PanelTextBackColor)
   PanelBackGround.Controls.Add(Picturebox)
   PanelBackGround.Location = New Point(6, 7)
   PanelBackGround.Size = New Size(PanelItem.Width - 12, PanelItem.Height - 15) ' 120
   ' 
   ' PanelTextBackColor
   ' 
   PanelTextBackColor.BackColor = Color.LightCoral
   PanelTextBackColor.Controls.Add(LabelText)
   PanelTextBackColor.Location = New Point(3, PanelBackGround.Height - 25)
   PanelTextBackColor.Size = New Size(PanelBackGround.Width - 7, 21)
   ' 
   ' LabelText
   ' 
   LabelText.AutoSize = True
   LabelText.Location = New Point(3, 3)
   LabelText.Size = New Size(97, 13)
   ' 
   ' Picturebox
   ' 
   Picturebox.BorderStyle = BorderStyle.None
   Picturebox.Location = New Point(3, 4)
   Picturebox.Size = New Size(PanelBackGround.Width - 7, PanelBackGround.Height - 30)
   Picturebox.SizeMode = RasterPaintSizeMode.FitAlways
   Picturebox.HorizontalAlignMode = RasterPaintAlignMode.Center
   Picturebox.VerticalAlignMode = RasterPaintAlignMode.Center
   Picturebox.TabStop = False
   Picturebox.BackColor = Me.BackColor
   AddHandler Picturebox.Click, AddressOf ItemClick
   AddHandler LabelText.Click, AddressOf ItemClick
   AddHandler PanelItem.Click, AddressOf ItemClick
   AddHandler PanelTextBackColor.Click, AddressOf ItemClick
   AddHandler PanelBackGround.Click, AddressOf ItemClick
   AddHandler CheckBoxItem.Click, AddressOf ItemClick

   AddHandler CheckBoxItem.GotFocus, AddressOf ItemGotFocus
   AddHandler Picturebox.GotFocus, AddressOf ItemGotFocus
   AddHandler LabelText.GotFocus, AddressOf ItemGotFocus
   AddHandler PanelItem.GotFocus, AddressOf ItemGotFocus
   AddHandler PanelTextBackColor.GotFocus, AddressOf ItemGotFocus
   AddHandler PanelBackGround.GotFocus, AddressOf ItemGotFocus

   AddHandler Picturebox.KeyDown, AddressOf ListImageBoxControls_KeyDown
   AddHandler LabelText.KeyDown, AddressOf ListImageBoxControls_KeyDown
   AddHandler PanelItem.KeyDown, AddressOf ListImageBoxControls_KeyDown
   AddHandler PanelTextBackColor.KeyDown, AddressOf ListImageBoxControls_KeyDown
   AddHandler PanelBackGround.KeyDown, AddressOf ListImageBoxControls_KeyDown
   AddHandler CheckBoxItem.KeyDown, AddressOf ListImageBoxControls_KeyDown

   Dim cd As Leadtools.Codecs.RasterCodecs = New Leadtools.Codecs.RasterCodecs()
   Picturebox.Image = item.Image
   LabelText.Text = itemName & " Page #" & (index + 1)

   PanelItem.Tag = Me._lstItems.Count
   Picturebox.Tag = Me._lstItems.Count
   PanelBackGround.Tag = Me._lstItems.Count
   PanelTextBackColor.Tag = Me._lstItems.Count
   LabelText.Tag = Me._lstItems.Count
   CheckBoxItem.Tag = Me._lstItems.Count
   End Sub

#End Region

#Region "Events"

   Private Sub ItemClick(ByVal sender As Object, ByVal e As EventArgs)
   Try
   Dim index As Integer = CInt((CType(sender, Control)).Tag)

   selDirection = SelectionDirection.None

   SelectItem(index, Control.ModifierKeys <> Keys.Control)
   StartSelection = SelectedIndex
   Catch
   End Try
   End Sub

   Private Sub ItemGotFocus(ByVal sender As Object, ByVal e As EventArgs)
   If sender.GetType() Is GetType(CheckBox) Then
   CType(sender, Control).Parent.Focus()
   End If
   End Sub

   Private Sub ListImageBox_Click(ByVal sender As Object, ByVal e As EventArgs)
   StartSelection = -1
   UnSelectItems()
   If Not ItemDeSlectEvent Is Nothing Then
   ItemDeSlectEvent.Invoke(Nothing, Nothing)
   End If
   End Sub

   Private Sub CondensedCheck_Click(ByVal sender As Object, ByVal e As EventArgs)
   Dim ck As CheckBox = CType(sender, CheckBox)
   Dim button As Button = TryCast(ck.Parent.Parent.Parent.Controls(0), Button)
   _lstItems(CInt(ck.Tag)).ImageItem.Checked = ck.Checked
   If CBool(button.Tag) Then
   If Not ListStateChangedEvent Is Nothing Then
      ListStateChangedEvent.Invoke(Me, Nothing)
   End If
   Return
   End If

   Dim index As Integer = 0
   For Each control As Control In ck.Parent.Parent.Parent.Controls
   If control.GetType() Is GetType(Panel) Then
      Dim item As ListItem = Items(CInt(control.Tag))
      item.CheckState = ck.CheckState
      item.ImageItem.Checked = ck.CheckState = CheckState.Checked
   End If
   index += 1
   Next control
   ck.Parent.Parent.Parent.Tag = ck.CheckState

   If Not ListStateChangedEvent Is Nothing Then
   ListStateChangedEvent.Invoke(Me, Nothing)
   End If
   End Sub

   Private Sub ExpandedCheck_Click(ByVal sender As Object, ByVal e As EventArgs)
   Dim ck As CheckBox = CType(sender, CheckBox)
   _lstItems(CInt(ck.Tag)).ImageItem.Checked = ck.Checked

   If Not ListStateChangedEvent Is Nothing Then
   ListStateChangedEvent.Invoke(Me, Nothing)
   End If
   End Sub

   Private Sub ButtonExpansion_Click(ByVal sender As Object, ByVal e As EventArgs)
   Dim button As Button = (TryCast(sender, Button))
   Dim GroupBoxImageCollection As GroupBox = TryCast(button.Parent, GroupBox)
   Dim imgIndex As Integer = Me.Controls.IndexOf(GroupBoxImageCollection)
   Dim isExpanded As Boolean = CBool(button.Tag)
   If isExpanded Then
   button.Image = imgPlus
   Collapse(GroupBoxImageCollection)
   button.Tag = Not isExpanded
   Else
   button.Image = imgMinus
   Expand(GroupBoxImageCollection)
   button.Tag = Not isExpanded
   End If
   Me.ScrollControlIntoView(GroupBoxImageCollection)
   End Sub

   Private Sub ListImageBoxControls_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)

   MyBase.OnKeyDown(e)
   End Sub

   Private Sub ListImageBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)

   End Sub

Public Sub RaiseCheckChanged()
RaiseEvent ItemChecked(Me, Nothing)
End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
   If (keyData = (Keys.Shift Or Keys.Up)) OrElse (keyData = (Keys.Shift Or Keys.Left)) Then
   If StartSelection = -1 Then
      Return MyBase.ProcessCmdKey(msg, keyData)
   End If

   If SelectedIndex = StartSelection Then
      selDirection = SelectionDirection.None
   End If

   If selDirection = SelectionDirection.None Then
      selDirection = SelectionDirection.Left
      StartSelection = SelectedIndex
   End If

   If selDirection = SelectionDirection.Left AndAlso SelectedIndex - 1 >= 0 Then
      Items(SelectedIndex - 1).Selected = True
      _selectedIndex = SelectedIndex - 1
   End If
   If selDirection = SelectionDirection.Right AndAlso SelectedIndex - 1 >= 0 Then
      Items(SelectedIndex).Selected = False
      _selectedIndex = SelectedIndex - 1
   End If
   ElseIf (keyData = (Keys.Shift Or Keys.Down)) OrElse (keyData = (Keys.Shift Or Keys.Right)) Then
   If StartSelection = -1 Then
      Return MyBase.ProcessCmdKey(msg, keyData)
   End If

   If SelectedIndex = StartSelection Then
      selDirection = SelectionDirection.None
   End If

   If selDirection = SelectionDirection.None Then
      selDirection = SelectionDirection.Right
      StartSelection = SelectedIndex
   End If

   If selDirection = SelectionDirection.Left AndAlso SelectedIndex + 1 <= Items.Count - 1 Then
      Items(SelectedIndex).Selected = False
      _selectedIndex = SelectedIndex + 1
   End If
   If selDirection = SelectionDirection.Right AndAlso SelectedIndex + 1 <= Items.Count - 1 Then
      Items(SelectedIndex + 1).Selected = True
      _selectedIndex = SelectedIndex + 1
   End If
   End If

   If (keyData = (Keys.Up)) OrElse (keyData = (Keys.Left)) Then
   If SelectedIndex > 0 Then
      SelectedIndex = SelectedIndex - 1
   End If
   StartSelection = SelectedIndex
   selDirection = SelectionDirection.None
   ElseIf (keyData = (Keys.Down)) OrElse (keyData = (Keys.Right)) Then
   If SelectedIndex < Items.Count - 1 Then
      SelectedIndex = SelectedIndex + 1
   End If
   StartSelection = SelectedIndex
   selDirection = SelectionDirection.None
   End If
   Return MyBase.ProcessCmdKey(msg, keyData)
   End Function

#End Region

   <Serializable()> _
   Public Class ImageCollection
   Private _images As List(Of ImageItem) = New List(Of ImageItem)()

   Public Property Images() As List(Of ImageItem)
   Get
      Return _images
   End Get
   Set(ByVal value As List(Of ImageItem))
      _images = value
   End Set
   End Property

   Private _name As String

   Public Property Name() As String
   Get
    Return _name
   End Get
   Set(ByVal value As String)
    _name = value
   End Set
   End Property

   Public Sub New(ByVal nameParam As String)
   _name = nameParam
   End Sub
   End Class

   <Serializable()> _
   Public Class ImageItem
   Private _rasterImage As Leadtools.RasterImage
   Public Property Image() As Leadtools.RasterImage
   Get
    Return _rasterImage
   End Get
   Set(ByVal value As Leadtools.RasterImage)
    _rasterImage = value
   End Set
   End Property

   Private _checked As Boolean = False
   Public Property Checked() As Boolean
   Get
    Return _checked
   End Get
   Set(ByVal value As Boolean)
    _checked = value
   End Set
   End Property

   Private _tag As Object
   Public Property Tag() As Object
   Get
    Return _tag
   End Get
   Set(ByVal value As Object)
    _tag = value
   End Set
   End Property

   Private _parent As ImageCollection
   Public Property Parent() As ImageCollection
   Get
    Return _parent
   End Get
   Set(ByVal value As ImageCollection)
    _parent = value
   End Set
   End Property

   Public Sub New(ByVal rasterImage As Leadtools.RasterImage, ByVal parentParam As ImageCollection, ByVal tagParam As Object)
   _rasterImage = rasterImage
   _tag = tagParam
   _parent = parentParam
   End Sub

   Public Sub New(ByVal rasterImage As Leadtools.RasterImage, ByVal parentParam As ImageCollection)
   _rasterImage = rasterImage
   _tag = Nothing
   _parent = parentParam
   End Sub

   End Class

   Public Class ListItem

   Private _listBox As ListImageBox
   Friend Property CheckState() As CheckState
   Get
      Dim control As Control = (_Controls)
      control = control.Controls(0).Controls(0)
      Return (TryCast(control, CheckBox)).CheckState
   End Get
   Set(ByVal value As CheckState)
      Dim control As Control = (_Controls)
      control = control.Controls(0).Controls(0)
      CType(control, CheckBox).CheckState = value
      If Not _listBox Is Nothing Then
      _listBox.RaiseCheckChanged()
      End If
   End Set
   End Property

   Friend Property Selected() As Boolean
   Get

      Dim control As Control = _Controls
      control = control.Controls(0)
      Return (control.BackColor = Color.Blue)
   End Get
   Set(ByVal value As Boolean)
      Dim control As Control = _Controls
      control = control.Controls(0)
      If value = True Then
      control.BackColor = Color.Blue
      Else
      control.BackColor = _listBox.BackColor
      End If
   End Set
   End Property

   Friend Property RasterImage() As RasterImage
   Get
      Dim control As Control = _Controls
      control = control.Controls(0).Controls(2)
      Dim ri As RasterImage = (TryCast(control, RasterImageViewer)).Image
      Return ri
   End Get
   Set(ByVal value As RasterImage)
      Dim control As Control = _Controls
      control = control.Controls(0).Controls(2)
      Dim ri As RasterImage = value
   End Set
   End Property

   Private _imageItem As ImageItem
   Public Property ImageItem() As ImageItem
   Get
    Return _imageItem
   End Get
   Set(ByVal value As ImageItem)
    _imageItem = value
   End Set
   End Property

   Friend _Controls As Control

   Public Sub New(ByVal bchecked As CheckState, ByVal imageItemParam As ImageItem, ByVal controls As Control, ByVal box As ListImageBox)
   _listBox = box
   _imageItem = imageItemParam
   _Controls = controls
   CheckState = bchecked
   End Sub


   Public Sub Dispose()
   Try
      RasterImage.Dispose()
      RasterImage = Nothing
      CType(ImageItem.Tag, IDisposable).Dispose()
   Catch
   End Try
   End Sub
   End Class
   End Class
End Namespace
