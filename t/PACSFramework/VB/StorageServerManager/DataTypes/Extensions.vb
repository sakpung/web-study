' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Security
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices

Namespace Leadtools.Demos.StorageServer
   Public Class Extensions
      Private Sub New()
      End Sub

      Public Shared Function Clone(Of T)(ByVal obj As T) As T
         Using ms As MemoryStream = New MemoryStream()
            Dim formatter As BinaryFormatter = New BinaryFormatter()
            formatter.Serialize(ms, obj)
            ms.Position = 0

            Return CType(formatter.Deserialize(ms), T)
         End Using
      End Function

      Public Shared Function ToSecureString(ByVal password As String) As SecureString
         Dim passwordChars As Char()
         Dim secure As SecureString


         passwordChars = password.ToCharArray()
         secure = New SecureString()

         For Each c As Char In passwordChars
            secure.AppendChar(c)
         Next

         secure.MakeReadOnly()

         Return secure
      End Function

      Public Shared Function [Implements](Of T)(ByVal assembly As Assembly) As IEnumerable(Of Type)
         Dim itype As Type = GetType(T)

         Return assembly.GetTypes().Where(Function(type) itype.IsAssignableFrom(type))
      End Function

      Public Shared Sub UncheckAll(ByVal listview As ListView)
         For Each item As ListViewItem In listview.CheckedItems
            item.Checked = False
         Next item
      End Sub

      Public Shared Sub CheckAll(ByVal listview As ListView)
         For Each item As ListViewItem In listview.Items
            item.Checked = True
         Next item
      End Sub

      Public Shared Sub SetForeColor(ByVal listview As ListView, ByVal color As Color)
         For Each item As ListViewItem In listview.Items
            item.ForeColor = color
         Next item
      End Sub

      'Public Shared Sub Freeze(ByVal control As Control)
      '   Try
      '      SendMessage(control.Handle, WM_SETREDRAW, 0, IntPtr.Zero)
      '   Catch exception As Exception
      '      System.Diagnostics.Debug.Assert(False)

      '      Throw exception
      '   End Try
      'End Sub

      'Public Shared Sub UnFreeze(ByVal control As Control)
      '   Try
      '      SendMessage(control.Handle, WM_SETREDRAW, 1, IntPtr.Zero)
      '   Catch exception As Exception
      '      System.Diagnostics.Debug.Assert(False)

      '      Throw exception
      '   End Try
      'End Sub
   End Class
End Namespace
