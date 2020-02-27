' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Jpip
Imports Leadtools.Jpip.Server
Imports Leadtools.Codecs

Partial Public Class Configuration : Inherits Form
   Private _server As JpipServer = Nothing

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal server As JpipServer)
      Me.New()
      _server = server

      Init()
   End Sub

   Private Sub Init()
      InitServerSettings()
      InitClientsSettings()
      InitCommunicationSettings()
      InitImagesSettings()
      InitLoggingSettings()

      FillDelegatedServers()
   End Sub

   Private Sub InitServerSettings()
      txtServerName.Text = _server.Configuration.ServerName
      txtIpAddress.Text = _server.Configuration.IPAddress
      mtxtPort.Text = _server.Configuration.Port.ToString()
      txtImagesFolder.Text = _server.Configuration.ImagesFolder
      txtCacheFolder.Text = _server.Configuration.CacheFolder
      mtxtCacheSize.Text = _server.Configuration.CacheSize.ToString()

      mtxtServerBandwidth.Text = (_server.Configuration.MaxServerBandwidth).ToString()

      If _server.Configuration.MaxServerBandwidth = -1 Then
         chkServerUnlimitedBandWidth.Checked = True
         mtxtServerBandwidth.Enabled = False
      Else
         mtxtServerBandwidth.Enabled = True
         chkServerUnlimitedBandWidth.Checked = False
      End If

      FillAliasFolders()

      btnReset.Enabled = Not _server.IsRunning
      txtServerName.Enabled = Not _server.IsRunning
      txtIpAddress.Enabled = Not _server.IsRunning
      mtxtPort.Enabled = Not _server.IsRunning
      btnAddDelegatedServer.Enabled = Not _server.IsRunning
      btnRemoveDelegatedServer.Enabled = Not _server.IsRunning
   End Sub

   Private Sub InitClientsSettings()
      mtxtMaxClients.Text = _server.Configuration.MaxClientCount.ToString()
      mtxtConnectionIdleTimeout.Text = _server.Configuration.ConnectionIdleTimeout.TotalSeconds.ToString()
      mtxtMaxSessionLife.Text = _server.Configuration.MaxSessionLifetime.TotalSeconds.ToString()

      mtxtConnectionBW.Text = (_server.Configuration.MaxConnectionBandwidth).ToString()

      If _server.Configuration.MaxConnectionBandwidth = -1 Then
         mtxtConnectionBW.Enabled = False
         chkClientUnlimitedBandWidth.Checked = True
      Else
         mtxtConnectionBW.Enabled = True
         chkClientUnlimitedBandWidth.Checked = False
      End If
   End Sub

   Private Sub InitCommunicationSettings()
      mtxtMaxTransport.Text = _server.Configuration.MaxTransportConnections.ToString()
      mtxtHandshakeTimeout.Text = _server.Configuration.HandshakeTimeout.TotalSeconds.ToString()
      mtxtChunkSize.Text = _server.Configuration.ChunkSize.ToString()

      mtxtRequestTimeout.Text = _server.Configuration.RequestTimeout.TotalSeconds.ToString()
      If (_server.Configuration.RequestTimeout = TimeSpan.MaxValue) Then
         chkCommunicationUnlimitedRequest.Checked = True
         mtxtRequestTimeout.Enabled = False
      Else
         chkCommunicationUnlimitedRequest.Checked = False
         mtxtRequestTimeout.Enabled = True
      End If
   End Sub

   Private Sub InitImagesSettings()
      mtxtParsingTimeout.Text = _server.Configuration.ImageParsingTimeout.TotalSeconds.ToString()


      If (_server.Configuration.ImageParsingTimeout = TimeSpan.MaxValue) Then
         chkImageParsingTimeout.Checked = True
         mtxtParsingTimeout.Enabled = False
      Else
         chkImageParsingTimeout.Checked = False
         mtxtParsingTimeout.Enabled = True
      End If

      mtxtPartitionSize.Text = _server.Configuration.PartitionBoxSize.ToString()
      chkDivideSuperBoxes.Checked = _server.Configuration.DivideSuperBoxes

   End Sub

   Private Sub InitLoggingSettings()
      chkEnableLog.Checked = _server.Configuration.EnableLogging
      txtLogFile.Text = _server.Configuration.LoggingFile
      chkLogInformation.Checked = _server.Configuration.LogInformation
      chkLogWarnings.Checked = _server.Configuration.LogWarnings
      chkLogDebug.Checked = _server.Configuration.LogDebug
      chkLogErrors.Checked = _server.Configuration.LogErrors

      grpFileLog.Enabled = Not _server.IsRunning
   End Sub

   Private Sub SetServerSttings()
      _server.Configuration.ServerName = txtServerName.Text
      _server.Configuration.IPAddress = txtIpAddress.Text
      _server.Configuration.Port = Integer.Parse(mtxtPort.Text)
      _server.Configuration.ImagesFolder = txtImagesFolder.Text
      _server.Configuration.CacheFolder = txtCacheFolder.Text
      _server.Configuration.CacheSize = Integer.Parse(mtxtCacheSize.Text)

      Dim maxServerBandwidth As Integer
      If (chkServerUnlimitedBandWidth.Checked) Then
         maxServerBandwidth = -1
      Else
         maxServerBandwidth = Integer.Parse(mtxtServerBandwidth.Text)
      End If

      If (maxServerBandwidth <> -1) AndAlso (maxServerBandwidth < _server.Configuration.MaxConnectionBandwidth) Then
         _server.Configuration.MaxConnectionBandwidth = Integer.Parse(mtxtConnectionBW.Text)
      End If

      _server.Configuration.MaxServerBandwidth = maxServerBandwidth

      SetAliasFolders()
   End Sub

   Private Sub SetClientsSettings()
      _server.Configuration.MaxClientCount = Integer.Parse(mtxtMaxClients.Text)
      _server.Configuration.ConnectionIdleTimeout = TimeSpan.FromSeconds(Double.Parse(mtxtConnectionIdleTimeout.Text))
      _server.Configuration.MaxSessionLifetime = TimeSpan.FromSeconds(Double.Parse(mtxtMaxSessionLife.Text))

      If chkClientUnlimitedBandWidth.Checked Then
         _server.Configuration.MaxConnectionBandwidth = -1
      Else
         _server.Configuration.MaxConnectionBandwidth = Integer.Parse(mtxtConnectionBW.Text)
      End If
   End Sub

   Private Sub SetCommunicationSettings()
      _server.Configuration.MaxTransportConnections = Integer.Parse(mtxtMaxTransport.Text)
      _server.Configuration.HandshakeTimeout = TimeSpan.FromSeconds(Double.Parse(mtxtHandshakeTimeout.Text))
      _server.Configuration.ChunkSize = Integer.Parse(mtxtChunkSize.Text)

      If (chkCommunicationUnlimitedRequest.Checked) Then
         _server.Configuration.RequestTimeout = TimeSpan.MaxValue
      Else
         _server.Configuration.RequestTimeout = TimeSpan.FromSeconds(Double.Parse(mtxtRequestTimeout.Text))
      End If

   End Sub

   Private Sub SetImagesSettings()
      If (chkImageParsingTimeout.Checked) Then
         _server.Configuration.ImageParsingTimeout = TimeSpan.MaxValue
      Else
         _server.Configuration.ImageParsingTimeout = TimeSpan.FromSeconds(Double.Parse(mtxtParsingTimeout.Text))
      End If

      _server.Configuration.PartitionBoxSize = Integer.Parse(mtxtPartitionSize.Text)
      _server.Configuration.DivideSuperBoxes = chkDivideSuperBoxes.Checked
   End Sub

   Private Sub SetLoggingSettings()
      _server.Configuration.EnableLogging = chkEnableLog.Checked
      _server.Configuration.LoggingFile = txtLogFile.Text
      _server.Configuration.LogInformation = chkLogInformation.Checked
      _server.Configuration.LogWarnings = chkLogWarnings.Checked
      _server.Configuration.LogDebug = chkLogDebug.Checked
      _server.Configuration.LogErrors = chkLogErrors.Checked
   End Sub

   Private Sub FillAliasFolders()
      For Each aliasToPath As KeyValuePair(Of String, String) In _server.Configuration.AliasFolders
         lsvAliases.Items.Add(New ListViewItem(New String() {aliasToPath.Key, aliasToPath.Value}))
      Next aliasToPath
   End Sub

   Private Sub SetAliasFolders()
      _server.Configuration.ClearAliases()

      For Each lstvItem As ListViewItem In lsvAliases.Items
         _server.Configuration.AddAliasFolder(lstvItem.Text, lstvItem.SubItems(1).Text)
      Next lstvItem
   End Sub

   Private Sub FillDelegatedServers()
      For Each server As DelegatedServer In _server.Configuration.DelegateServers
         lsvServers.Items.Add(New ListViewItem(New String() {server.IpAddress, server.Port.ToString(), server.HostLoad.ToString()}))
      Next server
   End Sub

   Private Sub SetDelegatedServers()
      _server.Configuration.DelegateServers.Clear()

      For Each lstvItem As ListViewItem In lsvServers.Items
         _server.Configuration.DelegateServers.Add(New DelegatedServer(lstvItem.Text, Integer.Parse(lstvItem.SubItems(1).Text), Integer.Parse(lstvItem.SubItems(2).Text)))
      Next lstvItem
   End Sub

   Private Sub SetConfiguration()
      Try
         If _server Is Nothing Then
            Throw New ApplicationException("Server not initialized")
         End If

         SetServerSttings()
         SetClientsSettings()
         SetCommunicationSettings()
         SetImagesSettings()
         SetLoggingSettings()
         SetDelegatedServers()

         Try
            _server.Configuration.Save()
         Catch ex As Exception
            Messager.ShowError(Me, String.Format("Unable to save configuration values into configuration file, exact error is: {0}", ex.Message))
         End Try
      Catch exception As Exception
         Messager.ShowError(Me, exception)
      End Try
   End Sub

   Private Sub btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApply.Click
      SetConfiguration()
   End Sub

   Private Sub btnBrowseImages_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowseImages.Click
      folderBrowserDialog1.SelectedPath = txtImagesFolder.Text

      If folderBrowserDialog1.ShowDialog() = DialogResult.OK Then
         txtImagesFolder.Text = folderBrowserDialog1.SelectedPath
      End If
   End Sub

   Private Sub btnBrowseCache_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowseCache.Click
      folderBrowserDialog1.SelectedPath = txtCacheFolder.Text

      If folderBrowserDialog1.ShowDialog() = DialogResult.OK Then
         txtCacheFolder.Text = folderBrowserDialog1.SelectedPath
      End If
   End Sub

   Private Sub btnBrowsePath_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowsePath.Click
      folderBrowserDialog1.SelectedPath = txtAliasPath.Text
      If folderBrowserDialog1.ShowDialog() = DialogResult.OK Then
         txtAliasPath.Text = folderBrowserDialog1.SelectedPath
      End If
   End Sub

   Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
      If (txtAlias.Text.Length <> 0) AndAlso (txtAliasPath.Text.Length <> 0) Then
         If Directory.Exists(txtAliasPath.Text) Then
            lsvAliases.Items.Add(New ListViewItem(New String() {txtAlias.Text, txtAliasPath.Text}))

            txtAlias.Text = String.Empty
            txtAliasPath.Text = String.Empty
         Else
            Messager.ShowWarning(Me, "Alias path doesn't exist.")
         End If
      Else
         Messager.ShowError(Me, "Please insert an alias and path information.")
      End If
   End Sub

   Private Sub btnRemove_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemove.Click
      For Each selectedItem As ListViewItem In lsvAliases.SelectedItems
         lsvAliases.Items.Remove(selectedItem)
      Next selectedItem
   End Sub

   Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
      SetConfiguration()
   End Sub

   Private Sub txtIpAddress_Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
      Dim textBox As TextBox
      Dim ipAddress As System.Net.IPAddress = Nothing


      textBox = CType(sender, TextBox)

      If textBox Is txtDelegatedServerIP Then
         If String.IsNullOrEmpty(textBox.Text) Then
            e.Cancel = False

            Return
         End If
      End If

      If ((Not System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, "^[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}$"))) OrElse ((Not System.Net.IPAddress.TryParse(textBox.Text, ipAddress))) Then
         Messager.ShowError(Me, "Invalid IP Address.")

         e.Cancel = True
      Else
         e.Cancel = False
      End If
   End Sub

   Private Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReset.Click
      txtServerName.Text = ConfigurationDefaults.ServerName
      txtIpAddress.Text = ConfigurationDefaults.IPAddress
      mtxtPort.Text = ConfigurationDefaults.Port.ToString()
      txtImagesFolder.Text = ConfigurationDefaults.ImagesFolder
      txtCacheFolder.Text = ConfigurationDefaults.CacheFolder
      mtxtServerBandwidth.Text = ConfigurationDefaults.MaxServerBandwidth.ToString()
      mtxtCacheSize.Text = ConfigurationDefaults.CacheSize.ToString()
      mtxtMaxClients.Text = ConfigurationDefaults.MaxClientCount.ToString()
      mtxtConnectionIdleTimeout.Text = ConfigurationDefaults.ConnectionIdleTimeout.ToString()
      mtxtMaxSessionLife.Text = ConfigurationDefaults.MaxSessionLifetime.ToString()
      mtxtConnectionBW.Text = ConfigurationDefaults.MaxConnectionBandwidth.ToString()
      mtxtMaxTransport.Text = ConfigurationDefaults.MaxTransportConnections.ToString()
      mtxtHandshakeTimeout.Text = ConfigurationDefaults.HandshakeTimeout.ToString()
      mtxtRequestTimeout.Text = ConfigurationDefaults.RequestTimeout.ToString()
      mtxtChunkSize.Text = ConfigurationDefaults.ChunkSize.ToString()
      mtxtParsingTimeout.Text = ConfigurationDefaults.ImageParsingTimeout.ToString()
      mtxtPartitionSize.Text = ConfigurationDefaults.PartitionBoxSize.ToString()
      chkDivideSuperBoxes.Checked = ConfigurationDefaults.DivideSuperBoxes
      chkEnableLog.Checked = ConfigurationDefaults.EnableLogging
      txtLogFile.Text = ConfigurationDefaults.LoggingFile
      chkLogInformation.Checked = ConfigurationDefaults.LogInformation
      chkLogWarnings.Checked = ConfigurationDefaults.LogWarnings
      chkLogDebug.Checked = ConfigurationDefaults.LogDebug
      chkLogErrors.Checked = ConfigurationDefaults.LogErrors

      lsvAliases.Items.Clear()
      lsvServers.Items.Clear()
   End Sub

   Private Sub btnAddDelegatedServer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAddDelegatedServer.Click
      If (txtDelegatedServerIP.Text.Length <> 0) AndAlso (mtxtDelegatedServerPort.Text.Length <> 0) AndAlso (mtxtDelegatedServerLoad.Text.Length <> 0) Then
         lsvServers.Items.Add(New ListViewItem(New String() {txtDelegatedServerIP.Text, mtxtDelegatedServerPort.Text, mtxtDelegatedServerLoad.Text}))

         txtDelegatedServerIP.Text = String.Empty
         mtxtDelegatedServerPort.Text = String.Empty
         mtxtDelegatedServerLoad.Text = String.Empty
      Else
         Messager.ShowError(Me, "Please insert a valid IP address, port and server load values.")
      End If
   End Sub

   Private Sub btnRemoveDelegatedServer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRemoveDelegatedServer.Click
      For Each selectedItem As ListViewItem In lsvServers.SelectedItems
         lsvServers.Items.Remove(selectedItem)
      Next selectedItem
   End Sub

   Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
      If openFileDialog1.ShowDialog() = DialogResult.OK Then
         txtLogFile.Text = openFileDialog1.FileName
      End If
   End Sub

   Private Sub chkClientUnlimitedBandWidth_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkClientUnlimitedBandWidth.CheckedChanged
      mtxtConnectionBW.Enabled = Not chkClientUnlimitedBandWidth.Checked
   End Sub

   Private Sub chkServerUnlimitedBandWidth_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chkServerUnlimitedBandWidth.CheckedChanged
      mtxtServerBandwidth.Enabled = Not chkServerUnlimitedBandWidth.Checked
   End Sub

   Private Sub chkCommunicationUnlimitedRequest_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCommunicationUnlimitedRequest.CheckedChanged
      mtxtRequestTimeout.Enabled = Not chkCommunicationUnlimitedRequest.Checked
   End Sub

   Private Sub chkImageParsingTimeout_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkImageParsingTimeout.CheckedChanged
      mtxtParsingTimeout.Enabled = Not chkImageParsingTimeout.Checked
   End Sub

   Private Sub btnImportImage_Click(sender As System.Object, e As System.EventArgs) Handles btnImportImage.Click
      Dim dlg As New OpenFileDialog()
      If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            Using codecs As New RasterCodecs()
               Dim outfile As String = Path.GetFileNameWithoutExtension(dlg.FileName)
               outfile += ".jp2"
               outfile = Path.Combine(_server.Configuration.ImagesFolder, outfile)
               If File.Exists(outfile) Then
                  MessageBox.Show("Target file already exists.", "Cannot import", MessageBoxButtons.OK, MessageBoxIcon.Information)
               Else
                  Me.Cursor = Cursors.WaitCursor
                  codecs.Convert(dlg.FileName, outfile, RasterImageFormat.Jp2, 0, 0, 0, _
                   Nothing)
                  Me.Cursor = Cursors.[Default]
                  MessageBox.Show([String].Format("{0} has been imported to {1}.", dlg.FileName, outfile), "Imported", MessageBoxButtons.OK, MessageBoxIcon.Information)
               End If
            End Using
         Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
         End Try
      End If
   End Sub
End Class
