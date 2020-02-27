' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Partial Public Class ObjectPropertiesDialog : Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public ReadOnly Property PropertyGrid() As PropertyGrid
      Get
         Return _propertyGrid
      End Get
   End Property
End Class
