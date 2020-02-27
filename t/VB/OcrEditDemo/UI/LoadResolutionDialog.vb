' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Codecs

Public Class LoadResolutionDialog

   Private _rasterCodecs As RasterCodecs

   Public Sub New(ByVal codecs As RasterCodecs)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      _rasterCodecs = codecs

      _resolutionTextBox.Text = _rasterCodecs.Options.RasterizeDocument.Load.XResolution.ToString()

   End Sub

   Private Sub _resolutionTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _resolutionTextBox.KeyPress
      If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsNumber(e.KeyChar) Then
         e.Handled = True
      End If
   End Sub

   Private Sub _resolutionTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _resolutionTextBox.TextChanged
      If _resolutionTextBox.Text.Trim().Length > 0 Then
         _okButton.Enabled = True
      Else
         _okButton.Enabled = False
      End If
   End Sub

   Private Sub _okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _okButton.Click
      ' Check the values
      Dim resolution As Integer = 0

      If Not GetResolutionValue(_resolutionTextBox, resolution) Then
         DialogResult = DialogResult.None
         Return
      End If

      ' Use the same value for X and Y resolution
      _rasterCodecs.Options.RasterizeDocument.Load.XResolution = resolution
      _rasterCodecs.Options.RasterizeDocument.Load.YResolution = resolution
   End Sub

   Private Function GetResolutionValue(ByVal tb As TextBox, ByRef resolution As Integer) As Boolean
      Dim ok As Boolean = False

      ' First try to parse it
      If Integer.TryParse(tb.Text, resolution) Then
         ' Success, make sure it is between 10 and 10000
         If resolution >= 10 AndAlso resolution <= 10000 Then
            ok = True
         End If
      End If

      If Not ok Then
         MessageBox.Show(Me, "Resolution must be a value between 10 and 10000", "PDF Resolution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         tb.SelectAll()
         tb.Focus()
      End If

      Return ok
   End Function
End Class
