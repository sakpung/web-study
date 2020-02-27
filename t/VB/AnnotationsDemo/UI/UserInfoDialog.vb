' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Public Class UserInfoDialog
   Public Sub New(description As String)
      InitializeComponent()
      _textboxDescription.Text = description
   End Sub

   Public ReadOnly Property ShowNextTime() As Boolean
      Get
         Return Not checkBox_DontShowAgain.Checked
      End Get
   End Property
End Class

