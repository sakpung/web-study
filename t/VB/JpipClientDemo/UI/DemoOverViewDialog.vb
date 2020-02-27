' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms
Imports system.Configuration

Public Class DemoOverViewDialog



Private Sub DemoOverViewDialog_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

      Try
         Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

         If Nothing Is config Then
            Return
         End If

         AddConfigurationValue(config, "ShowOverView", chkShowDlg.Checked.ToString().ToLower())

         config.Save(ConfigurationSaveMode.Modified)

         ConfigurationManager.RefreshSection("appSettings")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
      End Try

End Sub

Private Sub AddConfigurationValue(ByVal config As System.Configuration.Configuration, ByVal key As String, ByVal value As String)
   If Nothing Is config.AppSettings.Settings(key) Then
      config.AppSettings.Settings.Add(key, value)
   Else
      config.AppSettings.Settings(key).Value = value
   End If
End Sub

Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
      Me.Close()
End Sub
End Class
