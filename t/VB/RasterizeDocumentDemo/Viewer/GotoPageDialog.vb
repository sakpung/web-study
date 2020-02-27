' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Public Class GotoPageDialog
   Private _page As Integer
   Private _pageCount As Integer

   Public Sub New(ByVal page As Integer, ByVal pageCount As Integer)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      If Not DesignMode Then
         _page = page
         _pageCount = pageCount

         _pageTextBox.Text = _page.ToString()
         _pagesLabel.Text = String.Format("of {0}", _pageCount)
      End If
   End Sub

   Public ReadOnly Property Page() As Integer
      Get
         Return _page
      End Get
   End Property

   Private Sub _okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _okButton.Click
      Dim valid As Boolean = True
      Dim errorMessage As String = Nothing

      Dim page As Integer = _page

      If String.IsNullOrEmpty(_pageTextBox.Text) Then
         errorMessage = "Please enter a value for the new page"
         valid = False
      End If

      If (valid) AndAlso (Not Integer.TryParse(_pageTextBox.Text, page)) Then
         errorMessage = String.Format("'{0}' is not a valid value for a page number", _pageTextBox.Text)
         valid = False
      End If

      If (valid) AndAlso (page < 1 OrElse page > _pageCount) Then
         errorMessage = String.Format("Page must be a number between {0} and {1}", _page, _pageCount)
         valid = False
      End If

      If (valid) Then
         _page = page
      Else
         MessageBox.Show(Me, errorMessage, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         _pageTextBox.Focus()
         DialogResult = DialogResult.None
      End If
   End Sub
End Class
