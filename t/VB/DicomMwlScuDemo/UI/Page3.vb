' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.Codecs
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.DicomDemos.Scu
Imports Leadtools.DicomDemos.Scu.CFind
Imports Leadtools.WinForms.CommonDialogs.File

Namespace DicomDemo
   Partial Public Class Page3 : Inherits UserControl
      Private _globals As Globals

      Private cfind As CFind = New CFind()
      Private dcmQuery As CFindQuery
      Private m_bQuerySucceeded As Boolean

      Public Delegate Sub AddLog(ByVal action As String, ByVal logText As String)

      Public Sub New(ByRef pGlobals As Globals)
         InitializeComponent()

         _globals = pGlobals
      End Sub

      Private Sub Page3_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         m_bQuerySucceeded = False

         ' Assign events for the CFind query
         AddHandler cfind.Status, AddressOf cfind_Status
         AddHandler cfind.FindComplete, AddressOf cfind_FindComplete

      End Sub

      '
      '* When an element tree node is selected, update the text box with the element data
      '
      Private Sub m_TreeResult_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)
         Try
            If (CType(e.Node, MyTreeNode)).Parent Is Nothing Then ' root parent node
               btnSaveDS.Enabled = True
            Else ' child element node
               btnSaveDS.Enabled = False

               If Not (CType(e.Node, MyTreeNode)).m_Element Is Nothing Then
                  txtEditValue.Text = (CType(e.Node, MyTreeNode)).m_DS.GetConvertValue((CType(e.Node, MyTreeNode)).m_Element)
               Else
                  txtEditValue.Text = ""
               End If
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* When this page is made active, add the global MWL tree view and add or remove the AfterSelect
      '*   event
      '
      Private Sub Page3_VisibleChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.VisibleChanged
         Try
            If Visible Then
               EnableControls(True)

               ' Display the global results tree view
               panelTreeView.Controls.Add(_globals.m_TreeResult)

               ' Add needed events from the tree
               AddHandler _globals.m_TreeResult.AfterSelect, AddressOf m_TreeResult_AfterSelect

               ' Build the query based on user data from Page 2
               txtQuery.Text = ""
               dcmQuery = New CFindQuery()
               If _globals.m_nQueryType = 1 Then ' Broad
                  txtQuery.Text &= "Broad Modality Work List Query" & Constants.vbCrLf
                  If _globals.m_bCheckScheduledDate Then
                     dcmQuery.ScheduledDate = _globals.m_ScheduledDate
                     txtQuery.Text += Constants.vbTab & "Scheduled Procedure Step Start Date: " & _globals.m_ScheduledDate & Constants.vbCrLf
                  Else
                     txtQuery.Text += Constants.vbTab & "Scheduled Procedure Step Start Date:" & Constants.vbCrLf
                  End If

                  If _globals.m_bCheckModality Then
                     dcmQuery.Modality = _globals.m_strModality
                     txtQuery.Text += Constants.vbTab & "Modality: " & _globals.m_strModality
                  Else
                     txtQuery.Text += Constants.vbTab & "Modality:"
                  End If
               Else ' Patient
                  txtQuery.Text &= "Patient Based Query" & Constants.vbCrLf
                  txtQuery.Text += Constants.vbTab & "Patient Name: " & _globals.m_strPatientName & Constants.vbCrLf
                  dcmQuery.PatientName = _globals.m_strPatientName
                  txtQuery.Text += Constants.vbTab & "Patient ID: " & _globals.m_strPatientID & Constants.vbCrLf
                  dcmQuery.PatientID = _globals.m_strPatientID
                  txtQuery.Text += Constants.vbTab & "Accession Number: " & _globals.m_strAccessionNumber & Constants.vbCrLf
                  dcmQuery.AccessionNo = _globals.m_strAccessionNumber
                  txtQuery.Text += Constants.vbTab & "Requested Procedure ID: " & _globals.m_strRequestedProcedureID
                  dcmQuery.RequestedProcedureID = _globals.m_strRequestedProcedureID
               End If
            Else
               ' Remove events from the tree since we're not using this page anymore
               RemoveHandler _globals.m_TreeResult.AfterSelect, AddressOf m_TreeResult_AfterSelect
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Save the MWL ds to disk
      '
      Private Sub btnSaveDS_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSaveDS.Click
         Dim sfd As SaveFileDialog = New SaveFileDialog()
            sfd.Filter = "DCM (*.dcm)|*.dcm|DICOM (*.dic)|*.dic|All Files (*.*)|*.*||"
         sfd.FilterIndex = 0
            sfd.FileName = "mwl.dcm"
         If sfd.ShowDialog(Me) = DialogResult.OK Then
            Try
               CType(_globals.m_TreeResult.SelectedNode, MyTreeNode).m_DS.Save(sfd.FileName, DicomDataSetSaveFlags.MetaHeaderPresent Or DicomDataSetSaveFlags.LittleEndian Or DicomDataSetSaveFlags.ExplicitVR Or DicomDataSetSaveFlags.GroupLengths)
            Catch ex As Exception
               MessageBox.Show("Error saving file: " & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
            End Try
         End If
      End Sub

      '
      '* Send a CFind query to the MWL server
      '
      Private Sub btnQueryServer_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnQueryServer.Click
         Try
            System.GC.Collect()
            m_bQuerySucceeded = False
            StartUpdate(_globals.m_TreeResult)
            txtLog.Text = ""

            If _globals.m_nQueryType = 1 Then ' broad
               cfind.Find(_globals.m_MWLServer, FindType.MWLBroad, dcmQuery, _globals.m_strMWLClientAE)
            Else ' patient
               cfind.Find(_globals.m_MWLServer, FindType.MWLPatient, dcmQuery, _globals.m_strMWLClientAE)
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

Public Sub LogText(ByVal action As String, ByVal logTextRenamed As String)
		   If Globals._closing = True OrElse Me.Disposing OrElse Me.IsDisposed Then
			  Return
		   End If
			If Me.InvokeRequired Then
				Me.Invoke(New AddLog(AddressOf Me.LogText), New Object() { action, logTextRenamed })
			Else
				Try
					AddAction(action)
					txtLog.AppendText(logTextRenamed)
					txtLog.AppendText(Constants.vbCrLf)
				Catch ex As Exception
				   If Globals._closing = False Then
					  MessageBox.Show(ex.ToString())
				   End If
				End Try
			End If
End Sub

      '
      '* Adds the action (CFind, CStore, etc.) to the beginning of the log text
      '
      Private Sub AddAction(ByVal action As String)
         Try
            txtLog.SelectionLength = 0
            txtLog.SelectionStart = txtLog.Text.Length
            txtLog.AppendText(action & ": ")
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Provides feedback regarding the CFind query.
      '
      Private Sub cfind_Status(ByVal sender As Object, ByVal e As StatusEventArgs)
         Try
            Dim message As String = "Unknown Error"
            Dim action As String = ""
            Dim done As Boolean = False

            If e.Type = StatusType.Error Then
               action = "Error"
               message = "Error occurred." & Constants.vbCrLf
               message &= Constants.vbTab & "Error code is:" & Constants.vbTab + e.Error.ToString()
            Else
               Select Case e.Type
                  Case StatusType.ConnectFailed
                     action = "Connect"
                     message = "Operation failed."
                     done = True
                  Case StatusType.ConnectSucceeded
                     action = "Connect"
                     message = "Operation succeeded." & Constants.vbCrLf
                     message &= Constants.vbTab & "Peer Address:" & Constants.vbTab + e.PeerIP.ToString() & Constants.vbCrLf
                     message &= Constants.vbTab & "Peer Port:" & Constants.vbTab + Constants.vbTab + e.PeerPort.ToString()
                  Case StatusType.SendAssociateRequest
                     action = "Associate Request"
                     message = "Request sent."
                  Case StatusType.ReceiveAssociateAccept
                     action = "Associcated Accept"
                     message = "Received." & Constants.vbCrLf
                     message &= Constants.vbTab & "Calling AE:" & Constants.vbTab + e.CallingAE & Constants.vbCrLf
                     message &= Constants.vbTab & "Called AE:" & Constants.vbTab + e.CalledAE
                  Case StatusType.ReceiveAssociateRequest
                     action = "Associcated Request"
                     message = "Received." & Constants.vbCrLf
                     message &= Constants.vbTab & "Calling AE:" & Constants.vbTab + e.CallingAE & Constants.vbCrLf
                     message &= Constants.vbTab & "Called AE:" & Constants.vbTab + e.CalledAE
                  Case StatusType.ReceiveAssociateReject
                     action = "Associate Reject"
                     message = "Received Associate Reject!"
                     done = True
                  Case StatusType.AbstractSyntaxNotSupported
                     action = "Error"
                     message = "Abstract Syntax NOT supported!"
                     done = True
                  Case StatusType.SendCFindRequest
                     action = "C-FIND"
                     message = "Sending request"
                  Case StatusType.ReceiveCFindResponse
                     action = "C-FIND Response"
                     If e.Error = DicomExceptionCode.Success Then
                        message = "Operation completed successfully."
                     Else
                        If (e.Status = DicomCommandStatusType.Pending Or e.Status = DicomCommandStatusType.PendingWarning) Then
                           message = String.Format("Status: {0}", e.Status)
                        Else
                           message = "Error in response Status code is: " & e.Status.ToString()
                        End If

                     End If
                  Case StatusType.ConnectionClosed
                     action = "Connect"
                     message = "Network Connection closed!"
                     done = True
                  Case StatusType.ProcessTerminated
                     action = ""
                     message = "Process has been terminated!"
                     done = True
                  Case StatusType.SendReleaseRequest
                     action = "Release Request"
                     message = "Request sent."
                  Case StatusType.ReceiveReleaseResponse
                     action = "Release Response"
                     message = "Response received."
                     done = True
                  Case StatusType.SendCMoveRequest
                     action = "C-MOVE"
                     message = "Sending request"
                  Case StatusType.ReceiveCMoveResponse
                     action = "C-MOVE"
                     message = "Received response" & Constants.vbCrLf
                     message &= Constants.vbTab & "Status: " & e.Status.ToString() & Constants.vbCrLf
                     message &= Constants.vbTab & "Number Completed: " & e.NumberCompleted.ToString() & Constants.vbCrLf
                     message &= Constants.vbTab & "Number Remaining: " & e.NumberRemaining.ToString()
                  Case StatusType.SendCStoreResponse
                     action = "C-STORE"
                     message = "Sending response"
                  Case StatusType.ReceiveCStoreRequest
                     action = "C-STORE"
                     message = "Received request"
                  Case StatusType.Timeout
                     message = "Communication timeout. Process will be terminated."
                     done = True
               End Select

               LogText(action, message)
               If done AndAlso (e.Type <> StatusType.ReceiveReleaseResponse) Then
                  ' an error occured so we should end the update to the tree control,
                  ' otherwise FindComplete will take care of calling EndUpdate
                  EndUpdate(_globals.m_TreeResult)
               End If
            End If
            Catch ex As Exception
                If Globals._closing = False Then
                    MessageBox.Show(ex.ToString())
                End If
            End Try
        End Sub

      '
      '* Fired when all matching datasets are found and will add each dataset into the tree
        '
        Private Sub cfind_FindComplete(ByVal sender As Object, ByVal e As FindCompleteEventArgs)
            Try
                If e.Datasets.Count > 0 Then
                    LogText("C-FIND Complete", "Parsing " & e.Datasets.Count & " datasets and building TreeView...")
                    Dim count As Integer = 0
                    For Each ds As DicomDataSet In e.Datasets
                        Application.DoEvents()
                        _globals.m_TreeResult.BuildTreeFromDataset(ds, True)
                        count += 1
                        Dim s As String = String.Format("...processing dataset {0} of {1}", count, e.Datasets.Count)
                        LogText(s, "Building TreeView")
                    Next ds
                    LogText("C-FIND Complete", "Done building TreeView")
                    m_bQuerySucceeded = True
                Else
                    MessageBox.Show("No items match the query.  Press the " & ChrW(34) & "Back" & ChrW(34) & " button to change your query.")
                    m_bQuerySucceeded = False
                End If
                EndUpdate(_globals.m_TreeResult)
            Catch ex As Exception
                MessageBox.Show(ex.ToString())
            End Try
        End Sub

        '
        '* Begins updating the tree and disables other controls during the process.
        '
        Public Delegate Sub StartUpdateDelegate(ByVal tv As TreeView)
        Private Sub StartUpdate(ByVal tv As TreeView)
            If Globals._closing = True OrElse Me.Disposing OrElse Me.IsDisposed Then
                Return
            End If
            If InvokeRequired Then
                Invoke(New StartUpdateDelegate(AddressOf StartUpdate), tv)
            Else
                Try
                    btnSaveDS.Enabled = False
               EnableControls(False)
               tv.Nodes.Clear()
               tv.Refresh()
               tv.BeginUpdate()
            Catch ex As Exception
               MessageBox.Show(ex.ToString())
            End Try
         End If
      End Sub

      '
      '* Ends the updating of the tree and re-enables controls
      '
        Public Delegate Sub EndUpdateDelegate(ByVal tv As TreeView)
        Private Sub EndUpdate(ByVal tv As TreeView)
            If Globals._closing = True OrElse Me.Disposing OrElse Me.IsDisposed Then
                Return
            End If
            If InvokeRequired Then
                Invoke(New EndUpdateDelegate(AddressOf EndUpdate), tv)
            Else
                Try
                    EnableControls(True)
                    tv.EndUpdate()
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                End Try
            End If
        End Sub

      '
      '* Enables or disables controls
        '
        Private Delegate Sub EnableControlsDelegate(ByVal enable As Boolean)
        Private Sub EnableControls(ByVal enable As Boolean)
            If Globals._closing = True OrElse Me.Disposing OrElse Me.IsDisposed Then
                Return
            End If
            If Me.InvokeRequired Then
                Invoke(New EnableControlsDelegate(AddressOf EnableControls), New Object() {enable})
            Else
                Try
                    btnQueryServer.Enabled = enable
                    CType(Parent.Parent, MainForm).btnNext.Enabled = m_bQuerySucceeded
                    CType(Parent.Parent, MainForm).btnBack.Enabled = enable
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                End Try
            End If
      End Sub
   End Class
End Namespace
