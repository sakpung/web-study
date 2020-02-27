' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Public Class SelectPagesDialog

   Private _firstPageNumber As Integer
   Public Property FirstPageNumber() As Integer
      Get
         Return _firstPageNumber
      End Get
      Set(ByVal value As Integer)
         _firstPageNumber = value
      End Set
   End Property

   Private _lastPageNumber As Integer
   Public Property LastPageNumber() As Integer
      Get
         Return _lastPageNumber
      End Get
      Set(ByVal value As Integer)
         _lastPageNumber = value
      End Set
   End Property

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      If Not DesignMode Then
         _fromPageTextBox.Text = FirstPageNumber.ToString()
         _toPageTextBox.Text = LastPageNumber.ToString()

         If FirstPageNumber = 1 AndAlso LastPageNumber = -1 Then
            _allPagesCheckBox.Checked = True
         ElseIf LastPageNumber = -1 Then
            _lastPageCheckBox.Checked = True
         End If

         UpdateMyControls()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub UpdateMyControls()
      If _allPagesCheckBox.Checked Then
         _fromPageTextBox.Enabled = False
         _toPageTextBox.Enabled = False
         _lastPageCheckBox.Enabled = False
      Else
         _fromPageTextBox.Enabled = True
         _lastPageCheckBox.Enabled = True

         If _lastPageCheckBox.Checked Then
            _toPageTextBox.Enabled = False
         Else
            _toPageTextBox.Enabled = True
         End If
      End If
   End Sub

   Private Sub _allPagesCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _allPagesCheckBox.CheckedChanged
      UpdateMyControls()
   End Sub

   Private Sub _lastPageCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _lastPageCheckBox.CheckedChanged
      UpdateMyControls()
   End Sub

   Private Sub _okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _okButton.Click
      If _allPagesCheckBox.Checked Then
         FirstPageNumber = 1
         LastPageNumber = -1
      Else
         Dim fromPageNumber As Integer
         If Not Integer.TryParse(_fromPageTextBox.Text, fromPageNumber) OrElse fromPageNumber < 1 Then
            MessageBox.Show(Me, "Enter a number greater to or equal to 1 for 'From page'", "Select Pages", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DialogResult = DialogResult.None
            _fromPageTextBox.SelectAll()
            _fromPageTextBox.Focus()
            Return
         End If

         Dim toPageNumber As Integer
         If _lastPageCheckBox.Checked Then
            toPageNumber = -1
         Else
            If Not Integer.TryParse(_toPageTextBox.Text, toPageNumber) OrElse (toPageNumber <> -1 AndAlso toPageNumber < fromPageNumber) Then
               MessageBox.Show(Me, "Enter a number greater to or equal to 'From page' or -1 for 'From page'", "Select Pages", MessageBoxButtons.OK, MessageBoxIcon.Information)
               DialogResult = DialogResult.None
               _toPageTextBox.SelectAll()
               _toPageTextBox.Focus()
               Return
            End If
         End If

         FirstPageNumber = fromPageNumber
         LastPageNumber = toPageNumber
      End If
   End Sub
End Class
