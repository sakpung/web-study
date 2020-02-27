' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools.Medical3D
Imports Leadtools.MedicalViewer

Namespace Main3DDemo

   ' A class that is derived from System.Windows.Forms.Label control
   Partial Public Class ColorBox : Inherits System.Windows.Forms.Label
      Private _color As Color

      Public Sub New()
         _color = Color.Transparent
      End Sub

      Public Property BoxColor() As Color
         Set(value As Color)
            _color = Color.FromArgb(255, Value)
            If Me.Enabled Then
               BackColor = _color
            End If
         End Set
         Get
            Return Color.FromArgb(0, _color.R, _color.G, _color.B)
         End Get
      End Property

      Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
         MyBase.OnBackColorChanged(e)
         If BackColor <> Color.Transparent Then
            _color = BackColor
         End If
      End Sub

      Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
         MyBase.OnEnabledChanged(e)
         If Me.Enabled Then
            BackColor = _color
         Else
            BackColor = Color.Transparent
         End If
      End Sub

      Protected Overrides Sub OnDoubleClick(ByVal e As EventArgs)
         ContainerProperties.ShowColorDialog(Me)
         _color = BackColor
         MyBase.OnDoubleClick(e)
      End Sub
   End Class

   Partial Public Class NumericUpDownDraggable : Inherits System.Windows.Forms.NumericUpDown
      Private previousYValue As Integer
      Private draged As Boolean

      Public Sub New()
         AddHandler MouseDown, AddressOf NumericUpDownDraggable_MouseDown
         AddHandler MouseUp, AddressOf NumericUpDownDraggable_MouseUp
         AddHandler MouseMove, AddressOf NumericUpDownDraggable_MouseMove
      End Sub

      Private Sub NumericUpDownDraggable_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
         If draged Then
            Me.Value = Math.Max(Me.Minimum, Math.Min(Me.Maximum, Me.Value + (previousYValue - e.Y) * 42))
            Cursor.Current = Cursors.SizeNS
            previousYValue = e.Y
         End If
      End Sub

      Private Sub NumericUpDownDraggable_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
         draged = False
      End Sub

      Private Sub NumericUpDownDraggable_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
         previousYValue = e.Y
         draged = True
      End Sub
   End Class

   ' A class that is derived from TextBox control, that allows only
   ' 1) The numeric values.
   ' 2) The values that fall within the given range.
   Partial Public Class FNumericTextBox : Inherits System.Windows.Forms.TextBox
      Private _maximumAllowed As Single
      Private _minimumAllowed As Single
      Private _oldText As String

      Private Function GetFormattedText(ByVal orginalText As String) As String
         Dim text As String

         If orginalText.Trim() = "" Then
            Return "0"
         End If

         Dim charArray As Char() = orginalText.ToCharArray()

         If charArray(0) = "-"c Then
            text = orginalText.Remove(0, 1)
            If text.Trim() = "" Then
               text = "0"
            Else
               text = orginalText
            End If
         Else
            text = orginalText
         End If
         Return text
      End Function

      Public Sub New()
         _maximumAllowed = 1000.0F
         _minimumAllowed = -1000.0F
         _oldText = ""
      End Sub

      <Description("The minimum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MinimumAllowed() As Single
         Set(value As Single)
            _minimumAllowed = Value
         End Set
         Get
            Return _minimumAllowed
         End Get
      End Property

      <Description("The maximum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MaximumAllowed() As Single
         Set(value As Single)
            _maximumAllowed = Value
         End Set
         Get
            Return _maximumAllowed
         End Get
      End Property

      <Description("The numeric value of the Text box"), Category("Current Value")> _
      Public Property Value() As Single
         Set(value As Single)
            Dim text As String = Value.ToString()
            Dim dotIndex As Integer = text.IndexOf("."c)
            If dotIndex <> -1 Then
               If text.Length > dotIndex + 4 Then
                  text = text.Remove(dotIndex + 4)
               End If
            End If
            Me.Text = text
         End Set
         Get
            If Me.Text.Trim() = "" Then
               Return Math.Max(_minimumAllowed, 0)
            Else
               Return Convert.ToSingle(GetFormattedText(Me.Text))
            End If
         End Get
      End Property

      ' Is the entered number within the specified valid range
      Private Function IsAllowed(ByVal orginalText As String) As Boolean
         Dim maximumAllowed_Renamed As Single = _maximumAllowed
         Dim text As String

         If orginalText.Trim() = "" Then
            Return True
         End If

         Dim charArray As Char() = orginalText.ToCharArray()

         If (charArray(0) = "-"c) AndAlso (_minimumAllowed > 0) Then
            Return False
         End If

         If charArray(0) = "-"c Then
            text = orginalText.Remove(0, 1)
            If _minimumAllowed < 0 Then
               maximumAllowed_Renamed = _minimumAllowed * -1
            End If
            If text.Trim() = "" Then
               text = "0"
            End If
         Else
            text = orginalText
         End If

         Dim isAllowed_Renamed As Boolean = True

         Try
            Dim newNumber As Double = Convert.ToDouble(text)
            If (newNumber > maximumAllowed_Renamed) OrElse (newNumber < _minimumAllowed) Then
               isAllowed_Renamed = False
            End If
            Dim dotIndex As Integer = text.IndexOf("."c)
            If dotIndex <> -1 Then
               If (text.Length - dotIndex - 1) > 3 Then
                  isAllowed_Renamed = False
               End If
            End If
         Catch
            ' This happen if the entered value is not a numeric.
            isAllowed_Renamed = False
         End Try

         Return isAllowed_Renamed
      End Function

      Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
         If (Not IsAllowed(Me.Text)) Then
            ' If this condition doesn't exist, the user will be bugged. (trust me).
            If _minimumAllowed <= 0 Then
               Me.Text = _oldText
            End If
         Else
            _oldText = Me.Text
         End If

         MyBase.OnTextChanged(e)
      End Sub

      Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
         ' Increase or decrease the current value by 1 if the user presses the UP or DOWN
         ' and test if the new value is allowed
         If (e.KeyCode = Keys.Up) OrElse (e.KeyCode = Keys.Down) Then
            Dim value_Renamed As Double = Convert.ToDouble(GetFormattedText(Me.Text))

            If (e.KeyCode = Keys.Up) Then
               value_Renamed = value_Renamed + 0.1009
            Else
               value_Renamed = value_Renamed - 0.1009
            End If

            Dim text As String = value_Renamed.ToString()
            Dim dotIndex As Integer = text.IndexOf("."c)
            If dotIndex <> -1 Then
               text = text.Remove(dotIndex + 4)
            End If

            If IsAllowed(text) Then
               Me.Text = text
            End If
         End If

         If e.KeyCode = Keys.Back Then
            Dim text As String = Me.Text
            Dim selectionStart As Integer = Me.SelectionStart

            If selectionStart = 0 Then
               Return
            End If

            If text.Length = 0 Then
               Return
            End If

            text = text.Remove(selectionStart - 1, 1)

            If IsAllowed(text) Then
               MyBase.OnKeyDown(e)
            Else
               Return
            End If

         End If

         MyBase.OnKeyDown(e)
      End Sub

      Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
         Dim text As String = GetFormattedText(Me.Text)

         Dim value_Renamed As Double
         If (text.Trim() = "") Then
            value_Renamed = _minimumAllowed
         Else
            value_Renamed = Convert.ToDouble(text)
         End If
         If value_Renamed < _minimumAllowed Then
            Me.Text = _minimumAllowed.ToString()
         End If

         MyBase.OnLostFocus(e)
      End Sub

      Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
         ' if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
         ' since the user is not entering a new character...
         If ((Control.ModifierKeys And Keys.Control) = 0) AndAlso ((Control.ModifierKeys And Keys.Alt) = 0) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Enter)) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Escape)) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Back)) Then
            ' Validate the entered character
            If (Not Char.IsNumber(e.KeyChar)) Then

               Dim previousMinusWillBeDeleted As Boolean = False
               Dim indexofMinus As Integer = Me.Text.IndexOf("-"c)
               If indexofMinus <> -1 Then
                  If (indexofMinus >= Me.SelectionStart) AndAlso (indexofMinus < Me.SelectionStart + Me.SelectionLength) Then
                     previousMinusWillBeDeleted = True
                  End If
               End If

               ' Here we check if the user wants to enter the "-" character.
               If (Not previousMinusWillBeDeleted) Then
                  ' Here we check if the user wants to enter the "-" character.
                  If Not ((Me.Text.IndexOf("-"c) = -1) AndAlso (Me.SelectionStart = 0) AndAlso (_minimumAllowed < 0) AndAlso (e.KeyChar = "-"c)) Then ' the character entered was a Minus character
                     If Not ((e.KeyChar = "."c) AndAlso (Me.Text.IndexOf("."c) = -1)) Then
                        e.KeyChar = Char.MinValue
                     End If
                  End If
               End If
            End If

            If _minimumAllowed <= 0 Then
               If e.KeyChar <> Char.MinValue Then
                  ' Create the string that will be displayed, and check whether it's valid or not.

                  ' Remove the selected character(s).
                  Dim newString As String = Me.Text.Remove(Me.SelectionStart, Me.SelectionLength)
                  ' Insert the new character.
                  newString = newString.Insert(Me.SelectionStart, e.KeyChar.ToString())
                  If (Not IsAllowed(newString)) Then
                     ' the new string is not valid, cancel the whole operation.
                     e.KeyChar = Char.MinValue
                  End If
               End If
            End If
         End If
         MyBase.OnKeyPress(e)
      End Sub
   End Class

   Partial Public Class CursorButton : Inherits System.Windows.Forms.Button
      Private _buttonCursor As Cursor

      Public Sub New()
         _buttonCursor = Nothing
      End Sub

      <Description("The Cursor"), Category("Cursor")> _
      Public Property ButtonCursor() As Cursor
         Set(value As Cursor)
            _buttonCursor = Value
         End Set
         Get
            Return _buttonCursor
         End Get
      End Property

      Protected Overrides Sub OnClick(ByVal e As EventArgs)
         MyBase.OnClick(e)
         Dim openDialog As OpenFileDialog = New OpenFileDialog()
         openDialog.Filter = "Cursor files (*.cur) | *.cur"
         openDialog.RestoreDirectory = True

         If openDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _buttonCursor = New System.Windows.Forms.Cursor(openDialog.FileName)
         End If
      End Sub

      Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
         MyBase.OnPaint(pevent)
         If Not _buttonCursor Is Nothing Then
            Dim averageWidth As Integer = CInt((pevent.ClipRectangle.Width - _buttonCursor.Size.Width) / 2)
            Dim averageHeight As Integer = CInt((pevent.ClipRectangle.Height - _buttonCursor.Size.Height) / 2)

            _buttonCursor.Draw(pevent.Graphics, New Rectangle(averageWidth, averageHeight, _buttonCursor.Size.Width, _buttonCursor.Size.Height))
         End If
      End Sub
   End Class

   ' A class that is derieved from TextBox control, that allows only
   ' 1) The numeric values.
   ' 2) The values that fall within the given range.
   Partial Public Class NumericTextBox : Inherits System.Windows.Forms.TextBox
      Private _maximumAllowed As Integer
      Private _minimumAllowed As Integer
      Private _oldText As String

      Private Function GetFormattedText(ByVal orginalText As String) As String
         Dim text As String

         If orginalText.Trim() = "" Then
            Return "0"
         End If

         Dim charArray As Char() = orginalText.ToCharArray()

         If charArray(0) = "-"c Then
            text = orginalText.Remove(0, 1)
            If text.Trim() = "" Then
               text = "0"
            Else
               text = orginalText
            End If
         Else
            text = orginalText
         End If

         Return text
      End Function


      Public Sub New()
         _maximumAllowed = 1000
         _minimumAllowed = -1000
         _oldText = ""
      End Sub

      <Description("The minimum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MinimumAllowed() As Integer
         Set(value As Integer)
            _minimumAllowed = Value
         End Set
         Get
            Return _minimumAllowed
         End Get
      End Property

      <Description("The maximum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MaximumAllowed() As Integer
         Set(value As Integer)
            _maximumAllowed = Value
         End Set
         Get
            Return _maximumAllowed
         End Get
      End Property

      <Description("The maximum allowed value to be entered"), Category("Current Value")> _
      Public Property Value() As Integer
         Set(value As Integer)
            Me.Text = Value.ToString()
         End Set
         Get
            If Me.Text.Trim() = "" Then
               Return Math.Max(_minimumAllowed, 0)
            Else
               Return Math.Max(_minimumAllowed, Convert.ToInt32(GetFormattedText(Me.Text)))
            End If
         End Get
      End Property

      ' Is the entered number within the specified valid range
      Private Function IsAllowed(ByVal orginalText As String) As Boolean

         Dim maximumAllowed_Renamed As Integer = _maximumAllowed
         Dim text As String

         If orginalText.Trim() = "" Then
            Return True
         End If

         Dim charArray As Char() = orginalText.ToCharArray()

         ' if a Minus is entered and the minimum allowed is not negative return false immeditally
         If (charArray(0) = "-"c) AndAlso (_minimumAllowed > 0) Then
            Return False
         End If

         ' if the first character is Minus, remove it and compare the rest with the new maximum
         If charArray(0) = "-"c Then
            text = orginalText.Remove(0, 1)
            If _minimumAllowed < 0 Then
               maximumAllowed_Renamed = _minimumAllowed * -1
            End If
            If text.Trim() = "" Then
               text = "0"
            End If
         Else
            text = orginalText
         End If

         Dim isAllowed_Renamed As Boolean = True

         Try
            Dim newNumber As Integer = Convert.ToInt32(text)
            If (newNumber > maximumAllowed_Renamed) OrElse (newNumber < _minimumAllowed) Then
               isAllowed_Renamed = False
            End If
         Catch
            ' This happen if the entered value is not a numeric.
            isAllowed_Renamed = False
         End Try

         Return isAllowed_Renamed
      End Function

      Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
         If (Not IsAllowed(Me.Text)) Then
            If _minimumAllowed <= 1 Then
               Me.Text = _oldText
            End If
         Else
            _oldText = Me.Text
         End If

         MyBase.OnTextChanged(e)
      End Sub

      Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
         ' Increase or decrease the current value by 1 if the user presses the UP or DOWN
         ' and test if the new value is allowed
         If (e.KeyCode = Keys.Up) OrElse (e.KeyCode = Keys.Down) Then

            Dim value_Renamed As Integer = Convert.ToInt32(GetFormattedText(Me.Text))

            If (e.KeyCode = Keys.Up) Then
               value_Renamed = value_Renamed + 1
            Else
               value_Renamed = value_Renamed - 1
            End If

            If IsAllowed(value_Renamed.ToString()) Then
               Me.Text = value_Renamed.ToString()
            End If
         End If

         If e.KeyCode = Keys.Back Then
            Dim text As String = Me.Text
            Dim selectionStart As Integer = Me.SelectionStart

            If selectionStart = 0 Then
               Return
            End If

            If text.Length = 0 Then
               Return
            End If

            text = text.Remove(selectionStart - 1, 1)

            If IsAllowed(text) Then
               MyBase.OnKeyDown(e)
            Else
               Return
            End If

         End If

         MyBase.OnKeyDown(e)
      End Sub

      Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
         Dim text As String = GetFormattedText(Me.Text)
         Dim value_Renamed As Integer
         If text.Trim() = "" Then
            value_Renamed = 0
         Else
            value_Renamed = Convert.ToInt32(text)
         End If

         If value_Renamed < _minimumAllowed Then
            Me.Text = _minimumAllowed.ToString()
         End If

         MyBase.OnLostFocus(e)
      End Sub

      Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
         ' if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
         ' since the user is not entering a new character...
         If ((Control.ModifierKeys And Keys.Control) = 0) AndAlso ((Control.ModifierKeys And Keys.Alt) = 0) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Enter)) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Escape)) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Back)) Then
            ' Validate the entered character
            If (Not Char.IsNumber(e.KeyChar)) Then

               Dim previousMinusWillBeDeleted As Boolean = False
               Dim indexofMinus As Integer = Me.Text.IndexOf("-"c)
               If indexofMinus <> -1 Then
                  If (indexofMinus >= Me.SelectionStart) AndAlso (indexofMinus < Me.SelectionStart + Me.SelectionLength) Then
                     previousMinusWillBeDeleted = True
                  End If
               End If

               ' Here we check if the user wants to enter the "-" character.
               If (Not previousMinusWillBeDeleted) Then
                  If Not ((Me.Text.IndexOf("-"c) = -1) AndAlso (Me.SelectionStart = 0) AndAlso (_minimumAllowed < 0) AndAlso (e.KeyChar = "-"c)) Then ' the character entered was a Minus character
                     e.KeyChar = Char.MinValue
                  End If
               End If
            End If

            If _minimumAllowed <= 1 Then
               If e.KeyChar <> Char.MinValue Then
                  ' Create the string that will be displayed, and check whether it's valid or not.

                  ' Remove the selected character(s).
                  Dim newString As String = Me.Text.Remove(Me.SelectionStart, Me.SelectionLength)
                  ' Insert the new character.
                  newString = newString.Insert(Me.SelectionStart, e.KeyChar.ToString())
                  If (Not IsAllowed(newString)) Then
                     ' the new string is not valid, cancel the whole operation.
                     e.KeyChar = Char.MinValue
                  End If
               End If
            End If
         End If
         MyBase.OnKeyPress(e)
      End Sub
   End Class
End Namespace
