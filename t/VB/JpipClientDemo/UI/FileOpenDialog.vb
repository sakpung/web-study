' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Net
Imports System.Net.Sockets


   Partial Public Class FileOpenDialog : Inherits Form
      Private _fileName As String
      Private _serviceIPAddress As String
      Private _servicePortNumber As Integer


      Public Sub New()
         InitializeComponent()

      End Sub

      Public Property FileName() As String
         Get
            Return _fileName
         End Get
         Set(ByVal value As String)
            _fileName = value
         End Set
      End Property

      Public Property ServiceIpAddress() As String
         Set(ByVal value As String)
            _serviceIPAddress = value
         End Set
         Get
            Return _serviceIPAddress
         End Get
      End Property

      Public Property ServicePort() As Integer
         Get
            Return _servicePortNumber
         End Get
         Set(ByVal value As Integer)
            _servicePortNumber = value
         End Set
      End Property

      Private Sub rbtnFileName_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rbtnFileName.CheckedChanged
         If rbtnFileName.Checked Then
            Me.txtFileName.Enabled = True
            Me.pnlEnumerateService.Enabled = False
            Me.btnGetFiles.Enabled = False
         Else
            Me.txtFileName.Enabled = False
            Me.pnlEnumerateService.Enabled = True
            Me.btnGetFiles.Enabled = True
         End If
      End Sub

      Private Sub btnGetFiles_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnGetFiles.Click
         Try
            Dim request As HttpWebRequest = CType(HttpWebRequest.Create(String.Format("http://{0}:{1}/", ServiceIpAddress, ServicePort)), HttpWebRequest)


            If Not Nothing Is request.Proxy Then
               request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials
            End If

            request.UseDefaultCredentials = True


            Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

            Dim receivedStream As System.IO.Stream = response.GetResponseStream()
            Dim reader As System.IO.StreamReader = New System.IO.StreamReader(receivedStream)

            Dim read As Char() = New Char(255) {}
            ' Reads 256 characters at a time.    
            Dim count As Integer = reader.Read(read, 0, 256)
            Dim imageNames As String = ""

            Do While count > 0
               ' Dumps the 256 characters on a string and displays the string to the console.
               Dim temp As String = New String(read, 0, count)

               imageNames &= temp

               count = reader.Read(read, 0, 256)
            Loop

            ' Releases the resources of the response.
            response.Close()
            ' Releases the resources of the Stream.
            reader.Close()



            Dim serverSideImageNames As String() = imageNames.Split(";"c)
            Me.lstFiles.Items.Clear()
            For Each image As String In serverSideImageNames
               Me.lstFiles.Items.Add(image)
            Next image
         Catch exception As Exception
            ShowErrorMessage(Me, exception)
         End Try
      End Sub


      Private Sub txtFileName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtFileName.TextChanged
         If txtFileName.Text.Length > 0 Then
            Me.btnOK.Enabled = True
         Else
            Me.btnOK.Enabled = False
         End If
      End Sub

      Private Sub lstFiles_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lstFiles.SelectedIndexChanged
         If lstFiles.SelectedIndex <> -1 Then
            Me.btnOK.Enabled = True
         Else
            Me.btnOK.Enabled = False
         End If
      End Sub

      Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
         If rbtnFileName.Checked Then
            FileName = Me.txtFileName.Text
         Else
            If Not Me.lstFiles.SelectedItem Is Nothing Then
               FileName = Me.lstFiles.SelectedItem.ToString()
            Else
               FileName = Nothing
            End If
         End If
      End Sub

      Private Sub ShowErrorMessage(ByVal owner As IWin32Window, ByVal ex As Exception)
         Dim message As String
         message = ex.Message
         If TypeOf ex Is System.Net.WebException Then
            Dim webExc As System.Net.WebException = CType(ex, System.Net.WebException)
            If (Not Nothing Is webExc.Response) AndAlso (TypeOf webExc.Response Is System.Net.HttpWebResponse) Then
               Dim response As System.Net.HttpWebResponse = CType(webExc.Response, System.Net.HttpWebResponse)
               message &= Constants.vbLf & "Server Error:" & Constants.vbLf + response.StatusDescription
            End If
         End If
         Messager.ShowError(owner, message)
      End Sub
   End Class

