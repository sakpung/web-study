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
Imports System.Net
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.Win32

Imports Leadtools
Imports DialogUtilities
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports System.Collections


Namespace DicomDemo
   Partial Public Class MainForm : Inherits Form
      Private _currentPage As Integer
      Private _globals As Globals
      Private _pageTitles As String() = New String() {"Step 1: Set the maximum timeout", "Step 2: Configure Modality Work List Server", "Step 3: Choose Query Type", "Step 4: Query the Modality Work List Server", "Step 5: Construct the Data Set", "Step 6: Specify Values for Required Elements", "Step 7: Store the Data Set", "Thank You!"}

      Public Sub New()
         InitializeComponent()

         '
         _globals = New Globals()
      End Sub

      Public Dim _pages As ArrayList = New ArrayList()

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            ' Try to get settings from registry
            LoadSettings()

            _pages.Add(New Page0(_globals))
            _pages.Add(New Page1(_globals))
            _pages.Add(New Page2(_globals))
            _pages.Add(New Page3(_globals))
            _pages.Add(New Page4(_globals))
            _pages.Add(New Page5(_globals))
            _pages.Add(New Page6(_globals))
            _pages.Add(New Page7())

            For Each page As UserControl In _pages
                panel1.Controls.Add(page)
            Next page


            For i As Integer = 0 To panel1.Controls.Count - 1
                panel1.Controls(i).Visible = False
                panel1.Controls(i).Dock = DockStyle.Fill
            Next i

            _currentPage = 0
            SetTitleAndButtons()
            panel1.Visible = True
        End Sub

        Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
            Try
                Globals._closing = True

                For Each page As UserControl In _pages
                    page.Dispose()
                Next page

                DicomNet.Shutdown()
                SaveSettings()
            Catch e1 As Exception
            End Try
        End Sub

      ''' The main entry point for the application.
      <STAThread()> _
      Shared Sub Main()
#If LEADTOOLS_V175_OR_LATER Then
         If Not Support.SetLicense() Then
            Return
         End If
#Else
         Support.Unlock(False)
#End If
         

#If LEADTOOLS_V175_OR_LATER Then
         If (RasterSupport.IsLocked(RasterSupportType.DicomCommunication)) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.DicomCommunication.ToString()), "Warning")
            Return
         End If
#Else
         If (RasterSupport.IsLocked(RasterSupportType.MedicalNet)) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.MedicalNet.ToString()), "Warning")
            Return
         End If
#End If

         Utils.EngineStartup()
         Utils.DicomNetStartup()

         Application.Run(New MainForm())
      End Sub

      Private Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNext.Click
         HandleNext()
         SetTitleAndButtons()
      End Sub

      Private Sub btnBack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBack.Click
         _currentPage -= 1
         SetTitleAndButtons()
      End Sub

      Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
         Me.Close()
      End Sub

      '
      '* This function handles the next button and executes the necessary code for the
      '*   current page
      '
      Private Sub HandleNext()
         Try
            Select Case _currentPage
               Case 0
                  ' Set necessary global properties and save registry settings
                  _globals.m_nTimerMax = Convert.ToInt32((CType(panel1.Controls(_currentPage), Page0)).txtTimeout.Text)
                  SaveSettings()
               Case 1
                  ' Save registry settings
                  ' We don't set any globals here because it is done in the Verify button
                  SaveSettings()
               Case 2
                  ' Set necessary global properties
                  If (CType(panel1.Controls(_currentPage), Page2)).radBroad.Checked Then
                     _globals.m_nQueryType = 1
                  Else
                     _globals.m_nQueryType = 2
                  End If

                  _globals.m_bCheckScheduledDate = (CType(panel1.Controls(_currentPage), Page2)).chkScheduledDate.Checked
                  _globals.m_bCheckModality = (CType(panel1.Controls(_currentPage), Page2)).chkModality.Checked
                  _globals.m_strModality = _globals.m_ModalityTable((CType(panel1.Controls(_currentPage), Page2)).cboModality.SelectedIndex).m_strValue
                  _globals.m_ScheduledDate = (CType(panel1.Controls(_currentPage), Page2)).dtpScheduledDate.Value

                  _globals.m_strAccessionNumber = (CType(panel1.Controls(_currentPage), Page2)).txtAccessionNumber.Text
                  _globals.m_strPatientID = (CType(panel1.Controls(_currentPage), Page2)).txtPatientID.Text
                  _globals.m_strPatientName = (CType(panel1.Controls(_currentPage), Page2)).txtPatientName.Text
                  _globals.m_strRequestedProcedureID = (CType(panel1.Controls(_currentPage), Page2)).txtRequestedProcedureID.Text

                  ' Save settings to registry
                  SaveSettings()
               Case 3
                  ' nothing to do
               Case 4
                  Select Case (CType(panel1.Controls(_currentPage), Page4)).CreateDataset()
                     Case Page4.CreateDatasetReturn.Success
                     Case Page4.CreateDatasetReturn.ModalityNotFound
                        MessageBox.Show("Modality not supported, creating dataset using modality SC", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                     Case Page4.CreateDatasetReturn.GeneralError
                        MessageBox.Show("Could not create dataset", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        btnBack.PerformClick()
                     Case Page4.CreateDatasetReturn.NoItemSelected
                        MessageBox.Show("Please select a modality worklist item", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        btnBack.PerformClick()
                  End Select
               Case 5
                  ' nothing to do
                  If (Not _globals.m_bMandatoryElementsFilled) Then
                     If MessageBox.Show("You have not filled out all of the empty mandatory elements.  " & "If you attempt to store this dataset onto a server in the next step, " & "the server might reject it.  If this occurs, press the Back button and fill all elements." & Constants.vbCrLf & Constants.vbCrLf & "Do you want to proceed?", "Warning", MessageBoxButtons.YesNo) = DialogResult.No Then
                        btnBack.PerformClick()
                     End If
                  End If
               Case 6
                  ' Update settings
                  _globals.m_StorageServer.AETitle = (CType(panel1.Controls(_currentPage), Page6)).txtServerAE.Text
                  _globals.m_StorageServer.Address = IPAddress.Parse((CType(panel1.Controls(_currentPage), Page6)).txtServerIP.Text)
                  _globals.m_StorageServer.Port = Convert.ToInt32((CType(panel1.Controls(_currentPage), Page6)).txtServerPort.Text)
                  _globals.m_strStorageClientAE = (CType(panel1.Controls(_currentPage), Page6)).txtClientAE.Text

                  ' Save settings to registry
                  SaveSettings()
               Case 7
                  ' Finish button
                  Close()
            End Select

            _currentPage += 1

         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Correctly set the title and the Next and Back buttons based on the current page.
      '
      Private Sub SetTitleAndButtons()
         Try
            Select Case _currentPage
               Case 0
                  btnBack.Enabled = False
                  btnNext.Enabled = True
                  panel1.Controls(_currentPage + 1).Visible = False
               Case 1, 2, 3, 4, 5, 6
                  btnBack.Enabled = True
                  btnNext.Enabled = _globals.m_bMWLServerValid
                  panel1.Controls(_currentPage - 1).Visible = False
                  panel1.Controls(_currentPage + 1).Visible = False
               Case 7
                  panel1.Controls(_currentPage - 1).Visible = False
                  btnBack.Enabled = False
                  btnNext.Text = "Finished"
               Case 8
                  Return
            End Select
            Me.Text = _pageTitles(_currentPage)
            panel1.Controls(_currentPage).Visible = True
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Loads settings from the registry.
      '
      Private Sub LoadSettings()
         Try
            Dim user As RegistryKey = Registry.CurrentUser
#If LTV20_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\20\VB_DicomMwlScu20", True)
#ElseIf LTV19_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\19\VB_DicomMwlScu19", True)
#ElseIf LTV18_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\18\VB_DicomMwlScu18", True)
#ElseIf LTV175_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\17.5\VB_DicomMwlScu17.5", True)
#ElseIf LTV17_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\17\VB_DicomMwlScu17", True)
#ElseIf LTV16_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\16\VB_DicomMwlScu16", True)
#Else
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\15\VB_DicomMwlScu15", True)
#End If
            If settings Is Nothing Then
               ' We haven't saved any setting yet.  Use defaultsp

               Return
            End If

            ' PAGE 0
            _globals.m_nTimerMax = Convert.ToInt32(settings.GetValue("ServerTimeout"))

            ' PAGE 1
            _globals.m_MWLServer.AETitle = Convert.ToString(settings.GetValue("MWLServerAE"))
            _globals.m_MWLServer.Port = Convert.ToInt32(settings.GetValue("MWLServerPort"))
            _globals.m_MWLServer.Address = IPAddress.Parse(Convert.ToString(settings.GetValue("MWLServerAddress")))
            _globals.m_strMWLClientAE = Convert.ToString(settings.GetValue("MWLClientAE"))


            ' PAGE 2
            _globals.m_nQueryType = Convert.ToInt32(settings.GetValue("nQueryType"))
            _globals.m_strAccessionNumber = Convert.ToString(settings.GetValue("strAccessionNumber"))
            _globals.m_strModality = Convert.ToString(settings.GetValue("strModality"))
            _globals.m_strPatientID = Convert.ToString(settings.GetValue("strPatientID"))
            _globals.m_strPatientName = Convert.ToString(settings.GetValue("strPatientName"))
            _globals.m_strRequestedProcedureID = Convert.ToString(settings.GetValue("strRequestedProcedureID"))
            _globals.m_ScheduledDate = DateTime.Parse(Convert.ToString(settings.GetValue("ScheduledDate")))
            _globals.m_bCheckModality = Convert.ToBoolean(settings.GetValue("bCheckModality"))
            _globals.m_bCheckScheduledDate = Convert.ToBoolean(settings.GetValue("bCheckScheduledDate"))

            ' PAGE 6
            _globals.m_StorageServer.AETitle = Convert.ToString(settings.GetValue("StorageServerAE"))
            _globals.m_StorageServer.Port = Convert.ToInt32(settings.GetValue("StorageServerPort"))
            _globals.m_StorageServer.Address = IPAddress.Parse(Convert.ToString(settings.GetValue("StorageServerAddress")))
            _globals.m_strStorageClientAE = Convert.ToString(settings.GetValue("StorageClientAE"))
            _globals.m_bStoreOnServer = Convert.ToBoolean(settings.GetValue("bStoreOnServer"))

            settings.Close()
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Saves settings to the registry
      '
      Private Sub SaveSettings()
         Try
            Dim user As RegistryKey = Registry.CurrentUser
#If LTV20_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\20\VB_DicomMwlScu20", True)
#ElseIf LTV19_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\19\VB_DicomMwlScu19", True)
#ElseIf LTV18_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\18\VB_DicomMwlScu18", True)
#ElseIf LTV175_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\17.5\VB_DicomMwlScu17.5", True)
#ElseIf LTV17_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\17\VB_DicomMwlScu17", True)
#ElseIf LTV16_CONFIG Then
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\16\VB_DicomMwlScu16", True)
#Else
            Dim settings As RegistryKey = user.OpenSubKey("SOFTWARE\LEAD Technologies, Inc.\15\VB_DicomMwlScu15", True)
#End If
            If settings Is Nothing Then
#If LTV20_CONFIG Then
               settings = user.CreateSubKey("SOFTWARE\LEAD Technologies, Inc.\20\VB_DicomMwlScu20")
#ElseIf LTV19_CONFIG Then
               settings = user.CreateSubKey("SOFTWARE\LEAD Technologies, Inc.\19\VB_DicomMwlScu19")
#ElseIf LTV18_CONFIG Then
               settings = user.CreateSubKey("SOFTWARE\LEAD Technologies, Inc.\18\VB_DicomMwlScu18")
#ElseIf LTV175_CONFIG Then
               settings = user.CreateSubKey("SOFTWARE\LEAD Technologies, Inc.\17.5\VB_DicomMwlScu17.5")
#ElseIf LTV17_CONFIG Then
               settings = user.CreateSubKey("SOFTWARE\LEAD Technologies, Inc.\17\VB_DicomMwlScu17")
#ElseIf LTV16_CONFIG Then
               settings = user.CreateSubKey("SOFTWARE\LEAD Technologies, Inc.\16\VB_DicomMwlScu16")
#Else
               settings = user.CreateSubKey("SOFTWARE\LEAD Technologies, Inc.\15\VB_DicomMwlScu15")
#End If
            End If

            ' PAGE 0
            settings.SetValue("ServerTimeout", _globals.m_nTimerMax.ToString(), RegistryValueKind.DWord)

            ' PAGE 1
            settings.SetValue("MWLServerAE", _globals.m_MWLServer.AETitle.ToString())
            settings.SetValue("MWLServerPort", _globals.m_MWLServer.Port.ToString(), RegistryValueKind.DWord)
            settings.SetValue("MWLServerAddress", _globals.m_MWLServer.Address.ToString())
            settings.SetValue("MWLClientAE", _globals.m_strMWLClientAE.ToString())

            ' PAGE 2
            settings.SetValue("nQueryType", _globals.m_nQueryType, RegistryValueKind.DWord)
            settings.SetValue("strAccessionNumber", _globals.m_strAccessionNumber)
            settings.SetValue("strModality", _globals.m_strModality)
            settings.SetValue("strPatientID", _globals.m_strPatientID)
            settings.SetValue("strPatientName", _globals.m_strPatientName)
            settings.SetValue("strRequestedProcedureID", _globals.m_strRequestedProcedureID)
            settings.SetValue("ScheduledDate", _globals.m_ScheduledDate)
            settings.SetValue("bCheckModality", _globals.m_bCheckModality, RegistryValueKind.DWord)
            settings.SetValue("bCheckScheduledDate", _globals.m_bCheckScheduledDate, RegistryValueKind.DWord)

            ' PAGE 6
            settings.SetValue("StorageServerAE", _globals.m_StorageServer.AETitle.ToString())
            settings.SetValue("StorageServerPort", _globals.m_StorageServer.Port.ToString(), RegistryValueKind.DWord)
            settings.SetValue("StorageServerAddress", _globals.m_StorageServer.Address.ToString())
            settings.SetValue("StorageClientAE", _globals.m_strStorageClientAE.ToString())
            settings.SetValue("bStoreOnServer", _globals.m_bStoreOnServer, RegistryValueKind.DWord)

            settings.Close()
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub
   End Class
End Namespace
