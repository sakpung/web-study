' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing
Imports System.Windows.Forms

Namespace Leadtools.Demos.StorageServer.UI
   Public Class PageData
      Public Sub New(ByVal _page As Control)
         Me.New(_page, String.Empty)
      End Sub

      Public Sub New(ByVal _page As Control, ByVal _text As String)
         Me.New(_page, _text, Nothing)
      End Sub

      Public Sub New(ByVal _page As Control, ByVal _text As String, ByVal _image As Image)
         Page = _page
         Text = _text
         Image = _image
      End Sub

      Private _text As String
      Public Property Text() As String
         Get
            Return _text
         End Get
         Set(ByVal value As String)
            _text = value
         End Set
      End Property

      Private _image As Image
      Public Property Image() As Image
         Get
            Return _image
         End Get
         Set(ByVal value As Image)
            _image = value
         End Set
      End Property

      Private _page As Control
      Public Property Page() As Control
         Get
            Return _page
         End Get
         Set(ByVal value As Control)
            _page = value
         End Set
      End Property
   End Class
End Namespace
