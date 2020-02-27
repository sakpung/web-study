' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Drawing


   Public NotInheritable Class DialogUtilities
      Private Shared _strNotLessThan As String
      Private Shared _strNotGreaterThan As String
      Private Shared _strOK As String
      Private Shared _strCancel As String

      Private Sub New()
      End Sub
      Shared Sub New()
      _strNotLessThan = "should not be less than"
      _strNotGreaterThan = "should not be greater than"
      _strOK = "OK"
      _strCancel = "Cancel"
      End Sub

   Public Shared Function ParseInteger(ByVal textBox As TextBox, ByVal name As String, ByVal min As Integer, ByVal useMin As Boolean, ByVal max As Integer, ByVal useMax As Boolean, ByVal cancelDialog As Boolean, ByRef value As Integer) As Boolean
         Try
            value = Integer.Parse(textBox.Text)

         If (useMin AndAlso value < min) Then
            Return Fail(textBox.FindForm(), cancelDialog, String.Format("'{0}' should not be less than {1}", name, min))
            End If

         If (useMax AndAlso value > max) Then
            Return Fail(textBox.FindForm(), cancelDialog, String.Format("'{0}' should not be greater than {1}", name, max))
            End If

            Return True
         Catch ex As Exception
            value = 0
            Return Fail(textBox.FindForm(), cancelDialog, ex.Message)
         End Try
      End Function

      Private Shared Function Fail(ByVal form As Form, ByVal cancelDialog As Boolean, ByVal message As String) As Boolean
         Messager.ShowWarning(form, message)

      If (cancelDialog) Then
            form.DialogResult = DialogResult.None
         End If

         Return False
      End Function

      Public Shared Sub NumericOnLeave(ByVal sender As Object)
      Dim num As NumericUpDown = CType(sender, NumericUpDown)
      If (num.Value < num.Minimum) Then
            num.Value = num.Minimum
      ElseIf (num.Value > num.Maximum) Then
            num.Value = num.Maximum
         End If
      End Sub

      Public Shared Sub SetNumericValue(ByVal num As NumericUpDown, ByVal value As Integer)
         num.Value = Math.Max(num.Minimum, Math.Min(num.Maximum, value))
      End Sub

      ' Fix for the font issue in Windows 98 (Q326219)
   <DllImport("msvcrt.dll", EntryPoint:="_controlfp", CharSet:=CharSet.Auto, CallingConvention:=CallingConvention.Cdecl)> _
      Private Shared Function _controlfp(ByVal IN_New As Integer, ByVal IN_Mask As Integer) As Integer
      End Function

      Private Const _MCW_EW As Integer = &H8001F
      Private Const _EM_INVALID As Integer = &H10

      Public Shared Sub RunFPU()
         Try
            _controlfp(_MCW_EW, _EM_INVALID)
         Catch
         End Try
      End Sub

      ' System.Windows.Forms.PrintPreviewDialog has a bug on Windows 98 that causes a crash.  Search groups.google.com for an explination and a potentional fix
      Public Shared ReadOnly Property CanRunPrintPreview() As Boolean
         Get
            Dim os As OperatingSystem = Environment.OSVersion
            Return (os.Platform <> PlatformID.Win32Windows)
         End Get
      End Property

      Public Shared Function InputBox(ByVal title As String, ByVal promptText As String, ByRef value As String) As DialogResult
         Dim form As New Form()
         Dim label As New Label()
         Dim textBox As New TextBox()
         Dim buttonOk As New Button()
         Dim buttonCancel As New Button()

         form.Text = title
         label.Text = promptText
         textBox.Text = value

         buttonOk.Text = _strOK
         buttonCancel.Text = _strCancel
         buttonOk.DialogResult = Windows.Forms.DialogResult.OK
         buttonCancel.DialogResult = Windows.Forms.DialogResult.Cancel

         label.SetBounds(9, 20, 372, 13)
         textBox.SetBounds(12, 36, 372, 20)
         buttonOk.SetBounds(228, 72, 75, 23)
         buttonCancel.SetBounds(309, 72, 75, 23)

         label.AutoSize = True
         textBox.Anchor = textBox.Anchor Or AnchorStyles.Right
         buttonOk.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
         buttonCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right

         form.ClientSize = New Size(396, 107)
         form.Controls.AddRange(New Control() {label, textBox, buttonOk, buttonCancel})
         form.ClientSize = New Size(Math.Max(300, label.Right + 10), form.ClientSize.Height)
         form.FormBorderStyle = FormBorderStyle.FixedDialog
         form.StartPosition = FormStartPosition.CenterScreen
         form.MinimizeBox = False
         form.MaximizeBox = False
         form.AcceptButton = buttonOk
         form.CancelButton = buttonCancel

         Dim dialogResult As DialogResult = form.ShowDialog()
         value = textBox.Text
         Return dialogResult
      End Function
   End Class
