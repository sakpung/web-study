' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Rendering
Imports System

Partial Friend Class RichTextMenu
   Inherits Form
   Private _backColor As ToolStripMenuItem = Nothing
   Private _forColor As ToolStripMenuItem = Nothing
   Private _numbering As Boolean = False

   Shared Colors As Color() = New Color() {Color.Black, Color.Maroon, Color.Green, Color.Olive, Color.Navy, Color.Purple, _
    Color.Teal, Color.Gray, Color.Silver, Color.Red, Color.Lime, Color.Yellow, _
    Color.Blue, Color.Fuchsia, Color.Aqua, Color.White}

   Private FontSizes As Integer() = {8, 9, 10, 11, 12, 13, _
    14, 16, 18, 20, 22, 24, _
    26, 28, 36, 48, 72}


   Private _richTextBox As RichTextBox = Nothing
   Private _tempRichTextBox As New RichTextBox()

   Public Property RichTextBox() As RichTextBox
      Get
         Return _richTextBox
      End Get
      Set(value As RichTextBox)
         _richTextBox = value
         UpdateEditMenu()
      End Set
   End Property

   Private Sub Initialize()
      InitializeComponent()
      LoadMenuResources()

      LoadToolbarResources()

      InitializeControls()

      AddHandler _richTextBox.SelectionChanged, New EventHandler(AddressOf _richTextBox_SelectionChanged)

      UpdateEditMenu()

      For i As Integer = 0 To Colors.Length - 1
         Dim item As New ToolStripMenuItem()
         AddHandler item.Click, New EventHandler(AddressOf item_Click)
         item.Text = Colors(i).Name
         item.ForeColor = Colors(i)
         item.CheckOnClick = True
         item.Tag = "ForeColor"

         _miRtfFormatTextColor.DropDownItems.Add(item)
      Next

      For i As Integer = 0 To Colors.Length - 1
         Dim item As New ToolStripMenuItem()
         AddHandler item.Click, New EventHandler(AddressOf item_Click)
         item.Text = Colors(i).Name
         item.ForeColor = Colors(i)
         item.CheckOnClick = True
         item.Tag = "BackColor"

         _miRtfFormatBackgroundColor.DropDownItems.Add(item)
      Next

      For i As Integer = 0 To Colors.Length - 1
         Dim item As New ToolStripMenuItem()
         item.Text = Colors(i).Name
         AddHandler item.Click, New EventHandler(AddressOf item_Click)
         item.ForeColor = Colors(i)
         item.CheckOnClick = True
         item.Tag = "BackColor"
         _btnBackgroundColor.DropDownItems.Add(item)
      Next

      For i As Integer = 0 To Colors.Length - 1
         Dim item As New ToolStripMenuItem()
         item.Text = Colors(i).Name
         AddHandler item.Click, New EventHandler(AddressOf item_Click)
         item.ForeColor = Colors(i)
         item.CheckOnClick = True
         item.Tag = "ForeColor"

         _btnTextColor.DropDownItems.Add(item)
      Next
   End Sub

   Private Sub item_Click(sender As Object, e As EventArgs)
      Dim menuItem As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

      If menuItem.Tag.ToString() = "BackColor" Then
         If _backColor IsNot Nothing Then
            _backColor.Checked = False
         End If

         menuItem.Checked = True
         _richTextBox.SelectionBackColor = menuItem.ForeColor

         _backColor = menuItem
      Else
         If _forColor IsNot Nothing Then
            _forColor.Checked = False
         End If

         menuItem.Checked = True
         _richTextBox.SelectionColor = menuItem.ForeColor
         _forColor = menuItem
      End If
   End Sub

   'public RichTextMenu()
   '      {
   '         Initialize();
   '      }


   Public Sub New(richTextBox As RichTextBox)
      _richTextBox = richTextBox
      Initialize()
   End Sub

   Private Function CreateBitmap(name As String) As Bitmap
      Dim resourceName As String = String.Format("{0}.png", name)
      Return Tools.LoadImageFromResource(GetType(Tools), "Leadtools.Annotations.WinForms.Resources.RichTextMenu", resourceName)
   End Function

   Public Sub InitializeControls()
      Dim selectedIndex As Integer = 0
      For Each item As FontFamily In System.Drawing.FontFamily.Families
         _cmbFont.Items.Add(item.Name)
         If _richTextBox.SelectionFont IsNot Nothing Then
            If _richTextBox.SelectionFont.Name = item.Name Then
               selectedIndex = _cmbFont.Items.IndexOf(item.Name)
            End If
         End If
      Next

      _cmbFont.SelectedIndex = selectedIndex

      selectedIndex = 0
      For Each size As Integer In FontSizes
         _cmbFontSize.Items.Add(size)

         If _richTextBox.SelectionFont IsNot Nothing Then
            If _richTextBox.SelectionFont.Size = size Then
               selectedIndex = _cmbFontSize.Items.IndexOf(size)
            End If
         End If
      Next

      _cmbFontSize.SelectedIndex = selectedIndex
   End Sub

   Public Sub LoadToolbarResources()
      _btnBold.Image = CreateBitmap("Bold")
      _btnItalic.Image = CreateBitmap("Italic")
      _btnUnderline.Image = CreateBitmap("Underline")

      _btnTextColor.Image = CreateBitmap("TextColor")
      _btnBackgroundColor.Image = CreateBitmap("BackgroundColor")

      _btnNumbers.Image = CreateBitmap("Numbers")
      _btnBullets.Image = CreateBitmap("Bullets")
      _btnIncreaseIdent.Image = CreateBitmap("IndentRight")
      _btnDecreaseIdent.Image = CreateBitmap("IndentLeft")

      _btnRight.Image = CreateBitmap("Right")
      _btnLeft.Image = CreateBitmap("Left")
      _btnCenter.Image = CreateBitmap("Center")

      _btnBold.ToolTipText = StringManager.GetString(StringManager.Id.RtfBoldToolTip)
      _btnItalic.ToolTipText = StringManager.GetString(StringManager.Id.RtfItalicToolTip)
      _btnUnderline.ToolTipText = StringManager.GetString(StringManager.Id.RtfUnderlineToolTip)

      _btnTextColor.ToolTipText = StringManager.GetString(StringManager.Id.RtfTextColorToolTip)
      _btnBackgroundColor.ToolTipText = StringManager.GetString(StringManager.Id.RtfBackgroundColorToolTip)

      _btnNumbers.ToolTipText = StringManager.GetString(StringManager.Id.RtfNumbersToolTip)
      _btnBullets.ToolTipText = StringManager.GetString(StringManager.Id.RtfBulletsToolTip)
      _btnIncreaseIdent.ToolTipText = StringManager.GetString(StringManager.Id.RtfIndentRightToolTip)
      _btnDecreaseIdent.ToolTipText = StringManager.GetString(StringManager.Id.RtfIndentLeftToolTip)

      _btnRight.ToolTipText = StringManager.GetString(StringManager.Id.RtfRightToolTip)
      _btnLeft.ToolTipText = StringManager.GetString(StringManager.Id.RtfLeftToolTip)
      _btnCenter.ToolTipText = StringManager.GetString(StringManager.Id.RtfCenterToolTip)
   End Sub

   Public Sub FreeToolbarResources()
      _btnBold.Image.Dispose()
      _btnItalic.Image.Dispose()
      _btnUnderline.Image.Dispose()

      _btnTextColor.Image.Dispose()
      _btnBackgroundColor.Image.Dispose()

      _btnNumbers.Image.Dispose()
      _btnBullets.Image.Dispose()
      _btnIncreaseIdent.Image.Dispose()
      _btnDecreaseIdent.Image.Dispose()

      _btnRight.Image.Dispose()
      _btnLeft.Image.Dispose()
      _btnCenter.Image.Dispose()
   End Sub


   Public Sub LoadMenuResources()
      Me.Text = StringManager.GetString(StringManager.Id.RtfCaption)
      _miRtfFile.Text = StringManager.GetString(StringManager.Id.RtfFile)
      _miRtfFileOpen.Text = StringManager.GetString(StringManager.Id.RtfFileOpen)
      _miRtfFileSave.Text = StringManager.GetString(StringManager.Id.RtfFileSave)
      _miRtfFilePrint.Text = StringManager.GetString(StringManager.Id.RtfFilePrint)
      _miRtfFileExit.Text = StringManager.GetString(StringManager.Id.RtfFileExit)
      _miRtfEdit.Text = StringManager.GetString(StringManager.Id.RtfEdit)
      _miRtfEditUndo.Text = StringManager.GetString(StringManager.Id.RtfEditUndo)
      _miRtfEditCut.Text = StringManager.GetString(StringManager.Id.RtfEditCut)
      _miRtfEditCopy.Text = StringManager.GetString(StringManager.Id.RtfEditCopy)
      _miRtfEditPaste.Text = StringManager.GetString(StringManager.Id.RtfEditPaste)
      _miRtfEditDelete.Text = StringManager.GetString(StringManager.Id.RtfEditDelete)
      _miRtfEditSelectAll.Text = StringManager.GetString(StringManager.Id.RtfEditSelectAll)
      _miRtfFormat.Text = StringManager.GetString(StringManager.Id.RtfFormat)
      _miRtfFormatFont.Text = StringManager.GetString(StringManager.Id.RtfFormatFont)
      _miRtfFormatBackgroundColor.Text = StringManager.GetString(StringManager.Id.RtfFormatBackgroundColor)
      _miRtfFormatTextColor.Text = StringManager.GetString(StringManager.Id.RtfFormatTextColor)
      _miRtfFormatBullets.Text = StringManager.GetString(StringManager.Id.RtfFormatBullets)
      _miRtfFormatNumbering.Text = StringManager.GetString(StringManager.Id.RtfFormatNumbering)
      _miRtfFormatDecreaseIndent.Text = StringManager.GetString(StringManager.Id.RtfFormatDecreaseIndent)
      _miRtfFormatIncreaseIndent.Text = StringManager.GetString(StringManager.Id.RtfFormatIncreaseIndent)
      _miRtfFormatLeft.Text = StringManager.GetString(StringManager.Id.RtfFormatLeft)
      _miRtfFormatCenter.Text = StringManager.GetString(StringManager.Id.RtfFormatCenter)
      _miRtfFormatRight.Text = StringManager.GetString(StringManager.Id.RtfFormatRight)
   End Sub

   Private Sub _btnBold_Click(sender As Object, e As EventArgs) Handles _btnBold.Click
      BoldCommand()
   End Sub

   Public Sub ChangeFontStyle(style As FontStyle, add As Boolean)
      If style <> FontStyle.Bold AndAlso style <> FontStyle.Italic AndAlso style <> FontStyle.Strikeout AndAlso style <> FontStyle.Underline Then
         Throw New System.InvalidProgramException("Invalid style parameter to ChangeFontStyle")
      End If

      Dim rtb1start As Integer = _richTextBox.SelectionStart
      Dim len As Integer = _richTextBox.SelectionLength
      Dim rtbTempStart As Integer = 0

      'if len <= 1 and there is a selection font then just handle and return
      If len <= 1 AndAlso _richTextBox.SelectionFont IsNot Nothing Then
         'add or remove style 
         If add Then
            _richTextBox.SelectionFont = New Font(_richTextBox.SelectionFont, _richTextBox.SelectionFont.Style Or style)
         Else
            _richTextBox.SelectionFont = New Font(_richTextBox.SelectionFont, _richTextBox.SelectionFont.Style And Not style)
         End If

         Return
      End If

      ' Step through the selected text one char at a time	
      _tempRichTextBox.Rtf = _richTextBox.SelectedRtf
      For i As Integer = 0 To len - 1
         _tempRichTextBox.Select(rtbTempStart + i, 1)

         'add or remove style 
         If add Then
            _tempRichTextBox.SelectionFont = New Font(_tempRichTextBox.SelectionFont, _tempRichTextBox.SelectionFont.Style Or style)
         Else
            _tempRichTextBox.SelectionFont = New Font(_tempRichTextBox.SelectionFont, _tempRichTextBox.SelectionFont.Style And Not style)
         End If
      Next

      ' Replace & reselect
      _tempRichTextBox.Select(rtbTempStart, len)
      _richTextBox.SelectedRtf = _tempRichTextBox.SelectedRtf
      _richTextBox.Select(rtb1start, len)
      Return
   End Sub

   Public Sub ChangeFontNameSize(fontName As String, size As Single)
      Dim rtb1start As Integer = _richTextBox.SelectionStart
      Dim len As Integer = _richTextBox.SelectionLength
      Dim rtbTempStart As Integer = 0

      'if len <= 1 and there is a selection font then just handle and return
      If len <= 1 AndAlso _richTextBox.SelectionFont IsNot Nothing Then
         _richTextBox.SelectionFont = New Font(fontName, size, _richTextBox.SelectionFont.Style)

         Return
      End If

      ' Step through the selected text one char at a time	
      _tempRichTextBox.Rtf = _richTextBox.SelectedRtf
      For i As Integer = 0 To len - 1
         _tempRichTextBox.Select(rtbTempStart + i, 1)

         If _richTextBox.SelectionFont IsNot Nothing Then
            _tempRichTextBox.SelectionFont = New Font(fontName, size, _richTextBox.SelectionFont.Style)
         Else
            _tempRichTextBox.SelectionFont = New Font(fontName, size)
         End If
      Next

      ' Replace & reselect
      _tempRichTextBox.Select(rtbTempStart, len)
      _richTextBox.SelectedRtf = _tempRichTextBox.SelectedRtf
      _richTextBox.Select(rtb1start, len)
      Return
   End Sub

   Private Sub _miRtfFileOpen_Click(sender As Object, e As EventArgs) Handles _miRtfFileOpen.Click
      Using openFileDialog As New OpenFileDialog()
         openFileDialog.Filter = StringManager.GetString(StringManager.Id.RtfFilter)

         If openFileDialog.ShowDialog() = DialogResult.OK Then
            _richTextBox.Rtf = File.ReadAllText(openFileDialog.FileName)
         End If
      End Using
   End Sub

   Private Sub _miRtfFileSave_Click(sender As Object, e As EventArgs) Handles _miRtfFileSave.Click
      Using saveFileDialog As New SaveFileDialog()
         saveFileDialog.Filter = StringManager.GetString(StringManager.Id.RtfFilter)

         If saveFileDialog.ShowDialog() = DialogResult.OK Then
            _richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText)
         End If
      End Using
   End Sub

   Private Sub _miRtfFilePrint_Click(sender As Object, e As EventArgs) Handles _miRtfFilePrint.Click
      Using docToPrint As New PrintDocument()
         AddHandler docToPrint.PrintPage, New PrintPageEventHandler(AddressOf docToPrint_PrintPage)
         Using printDialog As New PrintDialog()
            printDialog.UseEXDialog = True
            printDialog.Document = docToPrint

            If printDialog.ShowDialog() = DialogResult.OK Then
               docToPrint.Print()
            End If
         End Using
      End Using
   End Sub

   Private Sub docToPrint_PrintPage(sender As Object, e As PrintPageEventArgs)
      AnnRichTextObjectRenderer.Print(_richTextBox, e)
   End Sub

   Private Sub _miRtfFileExit_Click(sender As Object, e As EventArgs) Handles _miRtfFileExit.Click
      Close()
   End Sub

   Private Sub _miRtfEdit_Click(sender As Object, e As EventArgs) Handles _miRtfEdit.Click
      UpdateEditMenu()
   End Sub

   Private Sub _miRtfEditUndo_Click(sender As Object, e As EventArgs) Handles _miRtfEditUndo.Click
      UndoCommand()
   End Sub

   Private Sub _miRtfEditCut_Click(sender As Object, e As EventArgs) Handles _miRtfEditCut.Click
      CutCommand()
   End Sub

   Private Sub _miRtfEditCopy_Click(sender As Object, e As EventArgs) Handles _miRtfEditCopy.Click
      CopyCommand()
   End Sub

   Private Sub _miRtfEditPaste_Click(sender As Object, e As EventArgs) Handles _miRtfEditPaste.Click
      PasteCommand()
   End Sub

   Private Sub _miRtfEditDelete_Click(sender As Object, e As EventArgs) Handles _miRtfEditDelete.Click
      DeleteCommand()
   End Sub

   Private Sub _miRtfEditSelectAll_Click(sender As Object, e As EventArgs) Handles _miRtfEditSelectAll.Click
      SelectAllCommand()
   End Sub

   Private _lastFindIndex As Integer = -1
   Private Sub _richTextBox_SelectionChanged(sender As Object, e As EventArgs)
      _lastFindIndex = _richTextBox.SelectionStart
   End Sub

   Private Sub _miRtfFormatFont_Click(sender As Object, e As EventArgs) Handles _miRtfFormatFont.Click
      Dim dlg As New FontDialog()
      If dlg.ShowDialog(Me) = DialogResult.OK Then
         _richTextBox.Font = dlg.Font
      End If
   End Sub

   Private Sub _miRtfFormatBackgroundColor_DropDownOpening(sender As Object, e As EventArgs) Handles _miRtfFormatBackgroundColor.DropDownOpening
      Dim index As Integer = GetColorIndex(_richTextBox.SelectionBackColor)
      For Each item As ToolStripMenuItem In _miRtfFormatBackgroundColor.DropDownItems
         item.Checked = False
      Next

      TryCast(_miRtfFormatBackgroundColor.DropDownItems(index), ToolStripMenuItem).Checked = True
   End Sub

   Private Sub _miRtfFormatTextColor_DropDownOpening(sender As Object, e As EventArgs) Handles _miRtfFormatTextColor.DropDownOpening
      Dim index As Integer = GetColorIndex(_richTextBox.SelectionColor)

      For Each item As ToolStripMenuItem In _miRtfFormatTextColor.DropDownItems
         item.Checked = False
      Next

      TryCast(_miRtfFormatTextColor.DropDownItems(index), ToolStripMenuItem).Checked = True
   End Sub

   Private Sub _miRtfFormatBullets_Click(sender As Object, e As EventArgs) Handles _miRtfFormatBullets.Click
      BulletsCommand()
   End Sub

   Private Sub _miRtfFormatNumbering_Click(sender As Object, e As EventArgs) Handles _miRtfFormatNumbering.Click
      NumberingCommand()
   End Sub

   Private Sub _miRtfFormatDecreaseIndent_Click(sender As Object, e As EventArgs) Handles _miRtfFormatDecreaseIndent.Click
      IndentLeft()
   End Sub

   Private Sub _miRtfFormatIncreaseIndent_Click(sender As Object, e As EventArgs) Handles _miRtfFormatIncreaseIndent.Click
      IndentRight()
   End Sub

   Private Sub _miRtfFormatLeft_Click(sender As Object, e As EventArgs) Handles _miRtfFormatLeft.Click
      LeftCommand()
   End Sub

   Private Sub _miRtfFormatCenter_Click(sender As Object, e As EventArgs) Handles _miRtfFormatCenter.Click
      CenterCommand()
   End Sub

   Private Sub _miRtfFormatRight_Click(sender As Object, e As EventArgs) Handles _miRtfFormatRight.Click
      RightCommand()
   End Sub

   Private Sub _btnLeft_Click(sender As Object, e As EventArgs) Handles _btnLeft.Click
      LeftCommand()
   End Sub

   Private Sub _btnCenter_Click(sender As Object, e As EventArgs) Handles _btnCenter.Click
      CenterCommand()
   End Sub

   Private Sub _btnRight_Click(sender As Object, e As EventArgs) Handles _btnRight.Click
      RightCommand()
   End Sub

   Private Sub _btnItalic_Click(sender As Object, e As EventArgs) Handles _btnItalic.Click
      ItalicCommand()
   End Sub

   Private Sub _btnUnderline_Click(sender As Object, e As EventArgs) Handles _btnUnderline.Click
      UnderlineCommand()
   End Sub

   Private Sub _btnBackgroundColor_DropDownOpening(sender As Object, e As EventArgs) Handles _btnBackgroundColor.DropDownOpening
      Dim index As Integer = GetColorIndex(_richTextBox.SelectionBackColor)
      For Each item As ToolStripMenuItem In _btnBackgroundColor.DropDownItems
         item.Checked = False
      Next

      TryCast(_btnBackgroundColor.DropDownItems(index), ToolStripMenuItem).Checked = True
   End Sub

   Private Sub _btnTextColor_DropDownOpening(sender As Object, e As EventArgs) Handles _btnTextColor.DropDownOpening
      Dim index As Integer = GetColorIndex(_richTextBox.SelectionColor)

      For Each item As ToolStripMenuItem In _btnTextColor.DropDownItems
         item.Checked = False
      Next

      TryCast(_btnTextColor.DropDownItems(index), ToolStripMenuItem).Checked = True
   End Sub

#Region "Commands"

   Private Sub LeftCommand()
      _richTextBox.SelectionAlignment = HorizontalAlignment.Left
      _miRtfFormatCenter.Checked = False
      _miRtfFormatRight.Checked = False
      _miRtfFormatLeft.Checked = True

      _btnLeft.Checked = True
      _btnCenter.Checked = False
      _btnRight.Checked = False
   End Sub

   Private Sub RightCommand()
      _richTextBox.SelectionAlignment = HorizontalAlignment.Right

      _miRtfFormatCenter.Checked = False
      _miRtfFormatLeft.Checked = False
      _miRtfFormatRight.Checked = True

      _btnLeft.Checked = False
      _btnCenter.Checked = False
      _btnRight.Checked = True
   End Sub

   Private Sub CenterCommand()
      _richTextBox.SelectionAlignment = HorizontalAlignment.Center

      _miRtfFormatLeft.Checked = False
      _miRtfFormatCenter.Checked = True
      _miRtfFormatRight.Checked = False

      _btnLeft.Checked = False
      _btnCenter.Checked = True
      _btnRight.Checked = False
   End Sub

   Private Sub BoldCommand()
      ChangeFontStyle(FontStyle.Bold, _btnBold.Checked)
   End Sub

   Private Sub ItalicCommand()
      ChangeFontStyle(FontStyle.Italic, _btnItalic.Checked)
   End Sub

   Private Sub UnderlineCommand()
      ChangeFontStyle(FontStyle.Underline, _btnUnderline.Checked)
   End Sub

   Private Sub UndoCommand()
      _richTextBox.Undo()
   End Sub

   Private Sub CutCommand()
      _richTextBox.Cut()
   End Sub

   Private Sub CopyCommand()
      _richTextBox.Copy()
   End Sub

   Private Sub PasteCommand()
      _richTextBox.Paste()
   End Sub

   Private Sub DeleteCommand()
      _richTextBox.Clear()
   End Sub

   Private Sub SelectAllCommand()
      _richTextBox.SelectAll()
   End Sub

   Private Sub BulletsCommand()
      _richTextBox.SelectionBullet = Not _richTextBox.SelectionBullet

      _miRtfFormatBullets.Checked = _richTextBox.SelectionBullet

      _btnBullets.Checked = _richTextBox.SelectionBullet
   End Sub

   Private Sub NumberingCommand()
      _numbering = Not _numbering
      Dim pf2 As New Win32.ParaFormat2()

      pf2.cbSize = Marshal.SizeOf(pf2)
      pf2.dwMask = Win32.PFM_NUMBERING Or Win32.PFM_NUMBERINGSTART

      If _numbering Then
         pf2.wNumbering = 2
         pf2.wNumberingStart = 1
      End If

      Dim lParam As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(pf2))
      Marshal.StructureToPtr(pf2, lParam, False)

      SafeNativeMethods.SendMessage(_richTextBox.Handle, Win32.WM_USER + 71, New IntPtr(0), lParam)
   End Sub

   Private Sub IndentRight()
      _richTextBox.SelectionIndent += 3
   End Sub

   Private Sub IndentLeft()
      _richTextBox.SelectionIndent -= 3
   End Sub

#End Region

   Private ReadOnly Property CanDelete() As Boolean
      Get
         Return _richTextBox.SelectionLength > 0
      End Get
   End Property

   Private Sub UpdateEditMenu()
      If _richTextBox IsNot Nothing Then
         _miRtfEditUndo.Enabled = _richTextBox.CanUndo
         _miRtfEditCut.Enabled = CanDelete
         _miRtfEditCopy.Enabled = CanDelete
         _miRtfEditPaste.Enabled = _richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Rtf))
         _miRtfEditDelete.Enabled = CanDelete
      End If
   End Sub

   Private Function GetColorIndex(color As Color) As Integer
      Dim index As Integer = 0
      For i As Integer = 0 To Colors.Length - 1
         If Colors(i).Equals(color) Then
            index = i
            Exit For
         End If
      Next

      Return index
   End Function

   Private Sub _btnBullets_Click(sender As Object, e As EventArgs) Handles _btnBullets.Click
      BulletsCommand()
   End Sub

   Protected Overrides Sub OnClosed(e As EventArgs)
      MyBase.OnClosed(e)
   End Sub

   Private Sub _cmbFont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbFont.SelectedIndexChanged
      Dim size As Single = If((_cmbFontSize.SelectedItem IsNot Nothing), CInt(_cmbFontSize.SelectedItem), _richTextBox.SelectionFont.Size)
      Dim name As String = If((_cmbFont.SelectedItem IsNot Nothing), CType(_cmbFont.SelectedItem, String), "Arial")
      ChangeFontNameSize(name, size)
   End Sub

   Private Sub _cmbFontSize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbFontSize.SelectedIndexChanged
      Dim size As Single = If((_cmbFontSize.SelectedItem IsNot Nothing), CInt(_cmbFontSize.SelectedItem), _richTextBox.SelectionFont.Size)
      Dim name As String = If((_cmbFont.SelectedItem IsNot Nothing), CType(_cmbFont.SelectedItem, String), "Arial")

      ChangeFontNameSize(name, size)
   End Sub

   Private Sub _btnIncreaseIdent_Click(sender As Object, e As EventArgs) Handles _btnIncreaseIdent.Click
      IndentRight()
   End Sub

   Private Sub _btnDecreaseIdent_Click(sender As Object, e As EventArgs) Handles _btnDecreaseIdent.Click
      IndentLeft()
   End Sub

   Private Sub _btnNumbers_Click(sender As Object, e As EventArgs) Handles _btnNumbers.Click
      NumberingCommand()
   End Sub
End Class

Friend Class ToolStripEx
   Inherits ToolStrip

   Public Sub New()
      MyBase.New()
   End Sub
   Private m_clickThrough As Boolean = True

   Private Const WM_MOUSEACTIVATE As UInteger = &H21
   Private Const WM_LBUTTONUP As UInteger = &H201
   Private Const MA_ACTIVATE As UInteger = 1
   Private Const MA_ACTIVATEANDEAT As UInteger = 2
   Private Const MA_NOACTIVATE As UInteger = 3
   Private Const MA_NOACTIVATEANDEAT As UInteger = 4

   Public Property ClickThrough() As Boolean
      Get
         Return Me.m_clickThrough
      End Get
      Set(value As Boolean)
         Me.m_clickThrough = value
      End Set
   End Property

   Protected Overrides Sub WndProc(ByRef m As Message)
      MyBase.WndProc(m)

      If Me.m_clickThrough AndAlso m.Msg = WM_MOUSEACTIVATE AndAlso m.Result = CType(MA_ACTIVATEANDEAT, IntPtr) Then
         m.Result = CType(MA_ACTIVATE, IntPtr)
      End If
   End Sub

End Class
