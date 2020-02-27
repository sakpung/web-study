' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.IO
Imports System.Net

Imports Leadtools
Imports Leadtools.Codecs

Namespace FeedLoadDemo
   ''' <summary>
   ''' Summary description for FeedLoadDialog.
   ''' </summary>
   Public Class FeedLoadDialog : Inherits System.Windows.Forms.Form
      Private WithEvents _btnCancel As System.Windows.Forms.Button
      Private _lblProgress As System.Windows.Forms.Label
      Private _pbProgress As System.Windows.Forms.ProgressBar
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New(ByVal codecs As RasterCodecs, ByVal url As String, ByVal fileName As String)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         _codecs = codecs
         _url = url
         _fileName = fileName
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"
      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._lblProgress = New System.Windows.Forms.Label()
         Me._pbProgress = New System.Windows.Forms.ProgressBar()
         Me.SuspendLayout()
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(109, 80)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         ' 
         ' _lblProgress
         ' 
         Me._lblProgress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
         Me._lblProgress.Location = New System.Drawing.Point(10, 8)
         Me._lblProgress.Name = "_lblProgress"
         Me._lblProgress.Size = New System.Drawing.Size(272, 23)
         Me._lblProgress.TabIndex = 0
         Me._lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
         ' 
         ' _pbProgress
         ' 
         Me._pbProgress.Location = New System.Drawing.Point(10, 40)
         Me._pbProgress.Name = "_pbProgress"
         Me._pbProgress.Size = New System.Drawing.Size(272, 23)
         Me._pbProgress.TabIndex = 1
         ' 
         ' FeedLoadDialog
         ' 
         Me.AcceptButton = Me._btnCancel
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(292, 109)
         Me.Controls.Add(Me._pbProgress)
         Me.Controls.Add(Me._lblProgress)
         Me.Controls.Add(Me._btnCancel)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "FeedLoadDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "Loading..."
         Me.ResumeLayout(False)

      End Sub
#End Region

      Private _codecs As RasterCodecs
      Private _url As String
      Private _fileName As String
      Private _ar As IAsyncResult
      Private _canceled As Boolean
      Private Delegate Sub StartupCallback()

      Public Image As RasterImage

      Private Sub FeedLoadDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         _ar = BeginInvoke(New StartupCallback(AddressOf Startup))
      End Sub

      Private Sub Startup()
         EndInvoke(_ar)

         _pbProgress.Visible = Not _fileName Is Nothing

         Application.DoEvents()
         _canceled = False

         Dim response As WebResponse = Nothing
         Dim fs As FileStream = Nothing
         Dim strm As Stream = Nothing

         Try
            Dim request As WebRequest

            Dim length As Integer

            If Not _url Is Nothing Then
               request = WebRequest.Create(_url)
               If Not request.Proxy Is Nothing Then
                  request.Proxy.Credentials = CredentialCache.DefaultCredentials
               End If

               ' reduce the timeout to 20sec
               request.Timeout = 20000
               ' you cannot cancel during GetResponse()
               _btnCancel.Enabled = False
               response = request.GetResponse()
               _btnCancel.Enabled = True
               strm = response.GetResponseStream()
               length = -1
            Else
               fs = File.OpenRead(_fileName)
               length = CInt(fs.Length)
               strm = fs
               _pbProgress.Maximum = length
            End If

            Const bufferSize As Integer = 1024
            Dim buffer As Byte() = New Byte(bufferSize - 1) {}

            Dim read As Integer
            Dim count As Integer = 0

            _codecs.StartFeedLoad(0, CodecsLoadByteOrder.BgrOrGray)

            Do
               Application.DoEvents()

               If (Not _canceled) Then
                  read = strm.Read(buffer, 0, bufferSize)
                  If read > 0 Then
                     Application.DoEvents()

                     If (Not _canceled) Then
                        _codecs.FeedLoad(buffer, 0, read)
                     End If

                     count += read
                  End If
               Else
                  read = 0
               End If

               If (Not _canceled) Then
                  If Not _url Is Nothing Then
                     _lblProgress.Text = String.Format("Downloading {0} bytes", count)
                  Else
                     _lblProgress.Text = String.Format("Loading {0} of {1} bytes", count, length)
                     _pbProgress.Value = count
                  End If
               End If
            Loop While read > 0 AndAlso Not _canceled


            If (Not _canceled) Then
               Image = _codecs.StopFeedLoad()
               Close(System.Windows.Forms.DialogResult.OK)
            Else
               _codecs.CancelFeedLoad()
               Image = Nothing
               Close(DialogResult.Cancel)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
            Close(DialogResult.Cancel)
         Finally
            If Not strm Is Nothing Then
               strm.Close()
            End If
            If Not response Is Nothing Then
               response.Close()
            End If
            If Not fs Is Nothing Then
               fs.Close()
            End If
         End Try
      End Sub

      Private Overloads Sub Close(ByVal res As DialogResult)
         DialogResult = res
         Close()
      End Sub

      Private Sub _btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnCancel.Click
         _canceled = True
         DialogResult = DialogResult.None
         Close()
      End Sub
   End Class
End Namespace
