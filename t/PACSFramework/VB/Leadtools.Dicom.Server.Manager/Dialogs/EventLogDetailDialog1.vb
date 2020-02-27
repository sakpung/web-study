' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Windows.Forms
Imports Leadtools.Medical.Winforms
Imports Leadtools.Dicom

Public Class EventLogDetailDialog

   Private Sub buttonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonClose.Click
      Me.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private privateServerAeTitle As String
   Public Property ServerAeTitle() As String
      Get
         Return privateServerAeTitle
      End Get
      Set(ByVal value As String)
         privateServerAeTitle = value
      End Set
   End Property

   Private privateServerIpAddress As String
   Public Property ServerIpAddress() As String
      Get
         Return privateServerIpAddress
      End Get
      Set(ByVal value As String)
         privateServerIpAddress = value
      End Set
   End Property

   Private privateServerPort As String
   Public Property ServerPort() As String
      Get
         Return privateServerPort
      End Get
      Set(ByVal value As String)
         privateServerPort = value
      End Set
   End Property

   Private privateClientAeTitle As String
   Public Property ClientAeTitle() As String
      Get
         Return privateClientAeTitle
      End Get
      Set(ByVal value As String)
         privateClientAeTitle = value
      End Set
   End Property

   Private privateClientIpAddress As String
   Public Property ClientIpAddress() As String
      Get
         Return privateClientIpAddress
      End Get
      Set(ByVal value As String)
         privateClientIpAddress = value
      End Set
   End Property

   Private privateClientPort As String
   Public Property ClientPort() As String
      Get
         Return privateClientPort
      End Get
      Set(ByVal value As String)
         privateClientPort = value
      End Set
   End Property

   Private privateCommand As String
   Public Property Command() As String
      Get
         Return privateCommand
      End Get
      Set(ByVal value As String)
         privateCommand = value
      End Set
   End Property

   Private privateEventDateTime As String
   Public Property EventDateTime() As String
      Get
         Return privateEventDateTime
      End Get
      Set(ByVal value As String)
         privateEventDateTime = value
      End Set
   End Property

   Private privateDescription As String
   Public Property Description() As String
      Get
         Return privateDescription
      End Get
      Set(ByVal value As String)
         privateDescription = value
      End Set
   End Property

   Private privateDatasetPath As String
   Public Property DatasetPath() As String
      Get
         Return privateDatasetPath
      End Get
      Set(ByVal value As String)
         privateDatasetPath = value
      End Set
   End Property


   Private Sub EventLogDetailDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      textBoxServerAeTitle.Text = ServerAeTitle
      textBoxServerIpAddress.Text = ServerIpAddress
      textBoxServerPort.Text = ServerPort
      textBoxClientAeTitle.Text = ClientAeTitle
      textBoxClientHostAddress.Text = ClientIpAddress
      textBoxClientPort.Text = ClientPort
      textBoxCommand.Text = Command
      textBoxEventDateTime.Text = EventDateTime
      textBoxDescription.Text = Description

      buttonViewDataset.Enabled = Not String.IsNullOrEmpty(DatasetPath)
   End Sub

   Private Sub buttonViewDataset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonViewDataset.Click
      Using ds As New DicomDataSet()
         ds.Load(DatasetPath, DicomDataSetLoadFlags.None)
         Dim dlg As New ViewDatasetDialog(ds)
         dlg.StartPosition = FormStartPosition.CenterParent
         dlg.ShowDialog(Me)
      End Using
   End Sub
End Class


