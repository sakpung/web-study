' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for Logger.
   ''' </summary>
   Public NotInheritable Class Logger
      Private Shared lv As ListView
      Private Shared _ActionColor As Color = Color.Blue
      Private Shared _disableLogging As Boolean = False

      Private Sub New()
      End Sub
      Public Shared Property ActionColor() As Color
         Get
            Return _ActionColor
         End Get
         Set(ByVal value As Color)
            _ActionColor = value
         End Set
      End Property

      Public Shared Property DisableLogging() As Boolean
         Get
            Return _disableLogging
         End Get
         Set(ByVal value As Boolean)
            _disableLogging = value
         End Set
      End Property

      Public Shared Sub Initialize(ByVal logger As ListView)
         lv = logger
      End Sub

      Public Shared Sub Log(ByVal action As String, ByVal text As String)
         If _disableLogging = False Then
            Dim item As ListViewItem
            Dim subItem As ListViewItem.ListViewSubItem

            item = lv.Items.Add(action)
            item.ForeColor = _ActionColor
            item.UseItemStyleForSubItems = False

            subItem = item.SubItems.Add(text)
            subItem.ForeColor = Color.Black

            lv.EnsureVisible(item.Index)
         End If
      End Sub

      Public Shared Sub Log(ByVal action As String, ByVal text As String, ByVal tag As Object)
         If _disableLogging = False Then
            Dim item As ListViewItem
            Dim subItem As ListViewItem.ListViewSubItem

            item = lv.Items.Add(action)
            item.ForeColor = _ActionColor
            item.UseItemStyleForSubItems = False

            If tag.ToString().Length > 0 Then
               item.Tag = tag
               item.ImageIndex = 0
            End If

            subItem = item.SubItems.Add(text)
            subItem.ForeColor = Color.Black

            lv.EnsureVisible(item.Index)
         End If
      End Sub
   End Class
End Namespace
