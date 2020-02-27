' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.IO
Imports Leadtools.DicomDemos
Imports Leadtools.Dicom

Namespace DicomDemo
    Partial Public Class OptionsDialog : Inherits Form
        Private _compression As Leadtools.Dicom.Scu.Common.Compression
      Private _clientAE As String
      Private _clientPort As Integer

        Public Property ServerList() As List(Of DicomAE)
            Get
                Dim items As New List(Of DicomAE)(dataGridViewServers.Rows.Count)
                For i As Integer = 0 To dataGridViewServers.Rows.Count - 1
                    Dim server As New DicomAE()
                    server.AE = dataGridViewServers.Rows(i).Cells("ColumnAE").Value.ToString().Trim()
                    server.IPAddress = dataGridViewServers.Rows(i).Cells("ColumnIP").Value.ToString().Trim()
                    server.Timeout = Convert.ToInt32(dataGridViewServers.Rows(i).Cells("ColumnTimeout").Value)
                    server.Port = Convert.ToInt32(dataGridViewServers.Rows(i).Cells("ColumnPort").Value)
                    server.UseTls = Convert.ToBoolean(dataGridViewServers.Rows(i).Cells("ColumnTls").Value)

                    items.Add(server)
                Next i
                Return items
            End Get

            Set(ByVal value As List(Of DicomAE))
                For Each s As DicomAE In value
                    Dim n As Integer = dataGridViewServers.Rows.Add()
                    dataGridViewServers.Rows(n).Cells("ColumnAE").Value = s.AE.Trim()
                    dataGridViewServers.Rows(n).Cells("ColumnIP").Value = s.IPAddress.Trim()
                    dataGridViewServers.Rows(n).Cells("ColumnTimeout").Value = s.Timeout.ToString().Trim()
                    dataGridViewServers.Rows(n).Cells("ColumnPort").Value = s.Port.ToString().Trim()
                    dataGridViewServers.Rows(n).Cells("ColumnTls").Value = s.UseTls.ToString().Trim()
                Next s
            End Set
        End Property

        Private _clientCertificate As String
        Private _privateKey As String
        Private _privateKeyPassword As String
      Private _logLowLevel As Boolean
      Private _groupLengthDataElements As Boolean
      Private _storageCommitResultsOnSameAssociation As Boolean

      Public Property PrivateKeyPassword() As String
            Get
                Return _privateKeyPassword
            End Get
            Set(ByVal value As String)
                _privateKeyPassword = value
            End Set
        End Property

        Public Property PrivateKey() As String
            Get
                Return _privateKey
            End Get
            Set(ByVal value As String)
                _privateKey = value
            End Set
        End Property

        Public Property ClientCertificate() As String
            Get
                Return _clientCertificate
            End Get
            Set(ByVal value As String)
                _clientCertificate = value
            End Set
        End Property

        Public Property LogLowLevel() As Boolean
            Get
                Return _logLowLevel
            End Get
            Set(ByVal value As Boolean)
                _logLowLevel = value
            End Set
      End Property

      Public Property GroupLengthDataElements() As Boolean
         Get
            Return _groupLengthDataElements
         End Get
         Set(ByVal value As Boolean)
            _groupLengthDataElements = value
         End Set
      End Property

      Public Property StorageCommitResultsOnSameAssociation() As Boolean
         Get
            Return _storageCommitResultsOnSameAssociation
         End Get
         Set(ByVal value As Boolean)
            _storageCommitResultsOnSameAssociation = value
         End Set
      End Property

      Public Property DisableLogging() As Boolean
         Get
            Return _checkBoxDisableLogging.Checked
         End Get
         Set(ByVal value As Boolean)
            _checkBoxDisableLogging.Checked = value
         End Set
      End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Public Property ClientAE() As String
            Get
                Return _clientAE
            End Get
            Set(ByVal value As String)
                _clientAE = value
            End Set
      End Property

      Public Property ClientPort() As Integer
         Get
            Return _clientPort
         End Get
         Set(ByVal value As Integer)
            _clientPort = value
         End Set
      End Property

        Public Property Compression() As Leadtools.Dicom.Scu.Common.Compression
            Get
                Return _compression
            End Get
            Set(ByVal value As Leadtools.Dicom.Scu.Common.Compression)
                _compression = value
            End Set
        End Property

        ' Return true if any of the servers are using tls
        ' Return false if all of the servers do not use tls
        Private Function IsAnyServerUseTls() As Boolean
            For i As Integer = 0 To dataGridViewServers.Rows.Count - 1
                If Convert.ToBoolean(dataGridViewServers.Rows(i).Cells("ColumnTls").Value) Then
                    Return True
                End If
            Next i
            Return False
        End Function

        Private Sub EnableDialogItems()
            Dim enable As Boolean = IsAnyServerUseTls()
            _labelCertificate.Enabled = enable
            _buttonClientCertificate.Enabled = enable
            _textBoxClientCertificate.Enabled = enable

            _labelPrivateKey.Enabled = enable
            _buttonClientCertificate.Enabled = enable
            _textBoxClientCertificate.Enabled = enable

            _labelPrivateKey.Enabled = enable
            _buttonPrivateKey.Enabled = enable
            _textBoxPrivateKey.Enabled = enable

            _labelPrivateKeyPassword.Enabled = enable
            _textBoxKeyPassword.Enabled = enable
            _labelHint.Enabled = enable

         ' Cipher Suites
            _buttonMoveUp.Enabled = enable
            _buttonMoveDown.Enabled = enable
            _listViewCipherSuites.Enabled = enable
            _checkBoxTlsOld.Enabled = enable
      End Sub

      Private _initializing As Boolean = True

      Private Sub OptionsDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         _initializing = True
         _textBoxClientAE.Text = ClientAE
         _textBoxClientPort.Text = ClientPort.ToString()
         _textBoxClientCertificate.Text = ClientCertificate
         _textBoxPrivateKey.Text = PrivateKey
         _textBoxKeyPassword.Text = PrivateKeyPassword
         _checkBoxLogLowLevel.Checked = LogLowLevel
         _checkBoxGroupLengthDataElements.Checked = GroupLengthDataElements
         _radioButtonWaitForResults.Checked = StorageCommitResultsOnSameAssociation
         _radioButtonNoWaitForResults.Checked = Not StorageCommitResultsOnSameAssociation
         Select Case _compression
            Case Leadtools.Dicom.Scu.Common.Compression.Native
               _radioButtonCompressionNative.Checked = True
            Case Leadtools.Dicom.Scu.Common.Compression.Lossy
               _radioButtonCompressionLossy.Checked = True
            Case Leadtools.Dicom.Scu.Common.Compression.Lossless
               _radioButtonCompressionLossless.Checked = True
         End Select
#If (Not LEADTOOLS_V19_OR_LATER) Then
         _GroupBoxStorageCommit.Visible = False
         _groupMiscellaneous.Visible = False
#End If

         _listViewCipherSuites.InitializeCipherListView(CipherSuites, imageListCiphers)
         _checkBoxTlsOld.Checked = CipherSuites.ContainsOldCipherSuites()

         _initializing = False
         EnableDialogItems()
      End Sub


      Private Function CheckInteger(ByVal tb As TextBox, ByVal lb As Label) As Boolean
            Try
                Convert.ToInt32(tb.Text)
                Return True
            Catch e1 As Exception
                If tb.Text.Trim() = String.Empty Then
                    MessageBox.Show("Invalid " & lb.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                tb.SelectAll()
                tb.Focus()
                DialogResult = System.Windows.Forms.DialogResult.None
                Return False
            End Try
        End Function

        Private Function CheckFileExists(ByVal tb As TextBox, ByVal showMessageBox As Boolean) As Boolean
            Dim ret As Boolean = True
            Dim sMsg As String = String.Empty
            Dim sFile As String = tb.Text.Trim()
            If sFile.Length = 0 Then
                sMsg = "File can not be empty if 'Use Secure TLS Communication' is checked."
                ret = False
            ElseIf (Not File.Exists(sFile)) Then
                sMsg = "File does not exist: " & sFile
                ret = False
            End If
            If (ret = False) AndAlso showMessageBox Then
                MessageBox.Show(sMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                tb.SelectAll()
                tb.Focus()
                DialogResult = System.Windows.Forms.DialogResult.None
            End If
            Return ret
        End Function

        Private Sub _buttonOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonOK.Click
         If IsAnyServerUseTls() Then
            If (Not CheckFileExists(_textBoxClientCertificate, True)) Then
               Return
            End If
            If (Not CheckFileExists(_textBoxPrivateKey, True)) Then
               Return
            End If
         End If

         If (Not CheckInteger(_textBoxClientPort, _labelClientPort)) Then
            Return
         End If

         _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing)

         ClientAE = _textBoxClientAE.Text
         ClientPort = Convert.ToInt32(_textBoxClientPort.Text)

         ClientCertificate = _textBoxClientCertificate.Text
         PrivateKey = _textBoxPrivateKey.Text
         PrivateKeyPassword = _textBoxKeyPassword.Text
         LogLowLevel = _checkBoxLogLowLevel.Checked
         GroupLengthDataElements = _checkBoxGroupLengthDataElements.Checked
         StorageCommitResultsOnSameAssociation = _radioButtonWaitForResults.Checked

         If Me._radioButtonCompressionNative.Checked Then
            _compression = Leadtools.Dicom.Scu.Common.Compression.Native
         ElseIf Me._radioButtonCompressionLossy.Checked Then
            _compression = Leadtools.Dicom.Scu.Common.Compression.Lossy
         ElseIf Me._radioButtonCompressionLossless.Checked Then
            _compression = Leadtools.Dicom.Scu.Common.Compression.Lossless
         End If

         DialogResult = DialogResult.OK
        End Sub

        Private Sub _buttonClientCertificate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonClientCertificate.Click
            Dim openDialog As New OpenFileDialog()
            openDialog.Title = "Select Client Certificate"
            openDialog.FileName = _textBoxClientCertificate.Text
            openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*"
            Dim result As DialogResult = openDialog.ShowDialog(Me)
            If result = System.Windows.Forms.DialogResult.OK Then
                _textBoxClientCertificate.Text = openDialog.FileName
            End If
        End Sub

        Private Sub _buttonPrivateKey_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _buttonPrivateKey.Click
            Dim openDialog As New OpenFileDialog()
            openDialog.Title = "Select Private Key File"
            openDialog.FileName = _textBoxClientCertificate.Text
            openDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*"
            Dim result As DialogResult = openDialog.ShowDialog(Me)
            If result = System.Windows.Forms.DialogResult.OK Then
                _textBoxPrivateKey.Text = openDialog.FileName
            End If
        End Sub

        Private Sub buttonAddServer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonAddServer.Click
            Try
                Dim rowIndex As Integer = dataGridViewServers.Rows.Add()
                Dim row As DataGridViewRow = dataGridViewServers.Rows(rowIndex)
                row.ReadOnly = False
                row.Selected = True
                dataGridViewServers.CurrentCell = row.Cells(0)
                dataGridViewServers.ShowEditingIcon = True
                dataGridViewServers.BeginEdit(False)
            Catch ex As Exception
                System.Diagnostics.Debug.Assert(False, ex.Message)
            End Try
        End Sub

        Private Sub buttonDeleteServer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDeleteServer.Click
            Try
                For Each row As DataGridViewRow In dataGridViewServers.SelectedRows
                    dataGridViewServers.Rows.Remove(row)
                Next row
            Catch ex As Exception
                System.Diagnostics.Debug.Assert(False, ex.Message)
            End Try

        End Sub

        Private Sub dataGridViewServers_CurrentCellDirtyStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dataGridViewServers.CurrentCellDirtyStateChanged
            Dim d As DataGridView = TryCast(sender, DataGridView)
            If d IsNot Nothing Then
                Dim cb As DataGridViewCheckBoxCell = TryCast(d.CurrentCell, DataGridViewCheckBoxCell)
                If cb IsNot Nothing Then
                    If TypeOf cb.Value Is Boolean Then
                        Dim bValue As Boolean = CBool(cb.Value)
                        If bValue Then
                            If Utils.VerifyOpensslVersion(Me) = False Then
                                cb.Value = False
                                dataGridViewServers.RefreshEdit()
                            End If
                        End If
                    End If
                    d.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange)
                    EnableDialogItems()
                End If
            End If
        End Sub

        Private Sub dataGridViewServers_RowValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dataGridViewServers.RowValidating
            Try
                Dim validatingRow As DataGridViewRow = dataGridViewServers.Rows(e.RowIndex)
                If (Nothing Is validatingRow.Cells(ColumnAE.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty(validatingRow.Cells(ColumnAE.Name).EditedFormattedValue.ToString())) Then
                    validatingRow.ErrorText = ColumnAE.HeaderText & " cannot be empty"
                    e.Cancel = True
                    Return
                End If

                If (Nothing IsNot validatingRow.Cells(ColumnAE.Name).EditedFormattedValue AndAlso validatingRow.Cells(ColumnAE.Name).EditedFormattedValue.ToString().Length > 16) Then
                    validatingRow.ErrorText = ColumnAE.HeaderText & " must be less than 16 characters"
                    e.Cancel = True
                    Return
                End If

                If (Nothing Is validatingRow.Cells(ColumnIP.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty(validatingRow.Cells(ColumnIP.Name).EditedFormattedValue.ToString())) Then
                    validatingRow.ErrorText = ColumnIP.HeaderText & " cannot be empty."
                    e.Cancel = True
                    Return
                End If

                Try
                    Dim ip As String = validatingRow.Cells(ColumnIP.Name).EditedFormattedValue.ToString()
                    Utils.ResolveIPAddress(ip)
                Catch exception As Exception
                    validatingRow.ErrorText = exception.Message
                    e.Cancel = True
                    Return
                End Try

                Dim number As Integer
                If (Nothing Is validatingRow.Cells(ColumnPort.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty(validatingRow.Cells(ColumnPort.Name).EditedFormattedValue.ToString())) OrElse ((Not Integer.TryParse(validatingRow.Cells(ColumnPort.Name).EditedFormattedValue.ToString(), number))) Then
                    validatingRow.ErrorText = String.Format("Invalid {0}.", ColumnPort.HeaderText)
                    e.Cancel = True
                    Return
                End If

                If (Nothing Is validatingRow.Cells(ColumnTimeout.Name).EditedFormattedValue) OrElse (String.IsNullOrEmpty(validatingRow.Cells(ColumnTimeout.Name).EditedFormattedValue.ToString())) OrElse ((Not Integer.TryParse(validatingRow.Cells(ColumnTimeout.Name).EditedFormattedValue.ToString(), number))) Then
                    validatingRow.ErrorText = String.Format("Invalid {0}.", ColumnTimeout.HeaderText)
                    e.Cancel = True
                    Return
                End If

                validatingRow.ErrorText = ""

            Catch ex As Exception
                System.Diagnostics.Debug.Assert(False, ex.Message)
                Throw
            End Try
        End Sub

      Private Sub _checkBoxDisableLogging_CheckedChanged(sender As Object, e As EventArgs)
         _checkBoxLogLowLevel.Enabled = Not DisableLogging
      End Sub

      Private Sub _buttonMoveUp_Click(sender As Object, e As EventArgs) Handles _buttonMoveUp.Click
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Up)
      End Sub

      Private Sub _buttonMoveDown_Click(sender As Object, e As EventArgs) Handles _buttonMoveDown.Click
         _listViewCipherSuites.MoveListViewItems(SecurityExtensions.MoveDirection.Down)
      End Sub

      Private Sub _checkBoxTlsOld_CheckedChanged(sender As Object, e As EventArgs) Handles _checkBoxTlsOld.CheckedChanged
         _listViewCipherSuites.ListViewToCipherSuites(CipherSuites, _initializing)
         If _checkBoxTlsOld.Checked Then
            CipherSuites.AddOldCipherSuites()
         Else
            CipherSuites.RemoveOldCipherSuites()
         End If
         _listViewCipherSuites.UpdateCipherSuitesListView(CipherSuites)
         _listViewCipherSuites.Focus()
      End Sub

      Public CipherSuites As New CipherSuiteItems()
   End Class
End Namespace
