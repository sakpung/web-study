' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Windows.Forms
Imports Leadtools.Document

Partial Public Class DocumentRedactionOptionsDialog
   Inherits Form

   Private _options As DocumentRedactionOptions = New DocumentRedactionOptions()

   Public Property Options As DocumentRedactionOptions
      Get
         Return Me._options
      End Get
      Set(ByVal value As DocumentRedactionOptions)
         Me._options = value
         Me.UpdateOptions()
      End Set
   End Property

   Public Sub New()
      InitializeComponent()
      UpdateOptions()
   End Sub

   Private Sub UpdateOptions()
      Me._viewRedactionOptionsControl.Options = Me._options.ViewOptions
      Me._convertRedactionOptionsControl.Options = Me._options.ConvertOptions
   End Sub
End Class
