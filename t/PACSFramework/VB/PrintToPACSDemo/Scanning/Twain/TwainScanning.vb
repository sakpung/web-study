' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Twain
Imports System.Collections
Imports System.Windows.Forms
Imports PrintToPACSDemo
Imports Leadtools
Imports System.IO

Namespace PrintToPACSDemo
   Public Partial Class FrmMain
	  Private _twainSession As TwainSession
	  Private Shared _twainerrorList As ArrayList
	  Public _twaintransferMode As TwainTransferMechanism = TwainTransferMechanism.Native
	  Private _twainAvailable As Boolean = False
	  Private twainImageCollection As ListImageBox.ImageCollection

	  Private Sub InitializeTwain()
         ' Determine whether a TWAIN source is installed
#If LEADTOOLS_V19_OR_LATER Then
         _twainAvailable = TwainSession.IsAvailable(Me.Handle)
#Else
		 _twainAvailable = TwainSession.IsAvailable(Me)
#End If
         If _twainAvailable Then
            ' Construct a new TwainSession object with default values
            _twainSession = New TwainSession()
            ' Initialize the TWAIN session 
            ' This method must be called before calling any other methods that require a TWAIN session
#If LEADTOOLS_V19_OR_LATER Then
            _twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
#Else
            _twainSession.Startup(Me, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
#End If

            ' Set the AcquirePage Event handler
            AddHandler _twainSession.AcquirePage, AddressOf _twain_AcquirePage

         Else
            _miTwainSelectSource.Enabled = False
            _miTwainAcquire.Enabled = False
            _miTemplateLEAD.Enabled = False
            _miTemplateShowCaps.Enabled = False
            _miTemplateShowErrors.Enabled = False
         End If

		 _twainerrorList = New ArrayList()

		 If Not _mySettings._settings.TwainSelectedDevice Is Nothing Then
			Try
				_twainSession.SelectSource(_mySettings._settings.TwainSelectedDevice)
			Catch
			End Try
		 End If
	  End Sub

	  Private Sub _miTwainSelectSource_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miTwainSelectSource.Click
		 ' Display the TWAIN dialog box to be used to select a TWAIN source for acquiring images
		 _twainSession.SelectSource(String.Empty)
		 _mySettings._settings.TwainSelectedDevice = _twainSession.SelectedSourceName()
		 _mySettings.Save()
	  End Sub

   Private Sub _twain_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
   ' This event occurs for each page acquired using the Acquire method
   Dim bTopMost As Boolean = logWindow.TopMost
   logWindow.TopMost = False
   Try
   If _twaintransferMode <> TwainTransferMechanism.File Then
      If Not e.Image Is Nothing Then
      Dim page As Page = New Page()
      page.DeleteOnDispose = False
      Dim strTemp As String = Path.GetTempFileName()
      _codec.Save(e.Image, strTemp, Global.Leadtools.RasterImageFormat.Tif, 0)
      page.FilePath = strTemp
      twainImageCollection.Images.Add(New ListImageBox.ImageItem(_codec.Load(strTemp), twainImageCollection, page))
      e.Image.Dispose()
      End If
   Else
      MessageBox.Show(Me, "Acquired page(s) is saved to file(s)", "Acquire to File")
   End If
   Catch ex As Exception
   AddErrorToErrorList(ex.Message)
   End Try
   logWindow.TopMost = bTopMost
   End Sub

	  Private Sub _miTwainAcquire_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miTwainAcquire.Click
		 Dim bTopMost As Boolean = logWindow.TopMost
		 logWindow.TopMost = False
		 Try
			SetTransferMode()
			' Acquire one or more images from a TWAIN source.
			twainImageCollection = New ListImageBox.ImageCollection("Twain Aquire")
			_twainSession.Acquire(TwainUserInterfaceFlags.Show Or TwainUserInterfaceFlags.Modal)
		 Catch ex As Exception
			AddErrorToErrorList(ex.Message)
			MessageBox.Show(Me, ex.Message)
		 End Try
		 If twainImageCollection.Images.Count > 0 Then
			_lstBoxPages.AddImageCollection(twainImageCollection)
		 End If

		 logWindow.TopMost = bTopMost
	  End Sub

	  Shared Public Sub AddErrorToErrorList(ByVal [error] As String)
		 _twainerrorList.Add([error])
	  End Sub

	  Private Sub _miTemplateShowErrors_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miTemplateShowErrors.Click
		 Using errorListDlg As ErrorList = New ErrorList()
			errorListDlg._arrayList = _twainerrorList
			Dim bTopMost As Boolean = logWindow.TopMost
			logWindow.TopLevel = False
			If errorListDlg.ShowDialog(Me) = DialogResult.OK Then
			   If errorListDlg._listCleared Then
				  _twainerrorList.Clear()
			   End If
			End If
			logWindow.TopMost = bTopMost
		 End Using
	  End Sub

	  Private Sub _miTemplateShowCaps_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miTemplateShowCaps.Click
		 Dim bTopMost As Boolean = logWindow.TopMost
		 logWindow.TopMost = False
		 Using supportedCapsDls As SupportedCaps = New SupportedCaps()
			Try
			   ' Get an array of Twain Capabilities supported in the current session
			   supportedCapsDls._caps = _twainSession.QuerySupportedCapabilities()
			   supportedCapsDls.ShowDialog(Me)
			Catch ex As Exception
			   AddErrorToErrorList(ex.Message)
			End Try
		 End Using
		 logWindow.TopMost = bTopMost
	  End Sub

	  Private Sub _miTemplateLEAD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _miTemplateLEAD.Click
		 ' Show the Templates dialog which will allow to Save/Load scanning settings
		 Dim bTopMost As Boolean = logWindow.TopMost
		 logWindow.TopMost = False
		 Using templateDlg As Template = New Template()
			templateDlg._twainSession = _twainSession
			templateDlg.ShowDialog(Me)

			If templateDlg.DialogResult = DialogResult.OK Then
			   _twaintransferMode = templateDlg._transferMode
			End If
		 End Using
		 logWindow.TopMost = bTopMost
	  End Sub

	  Private Sub SetTransferMode()
		 Using twnCap As TwainCapability = New TwainCapability()
			Try
			   twnCap.Information.Type = TwainCapabilityType.ImageTransferMechanism
			   twnCap.Information.ContainerType = TwainContainerType.OneValue

			   twnCap.OneValueCapability.ItemType = TwainItemType.Uint16
			   twnCap.OneValueCapability.Value = CUShort(_twaintransferMode)

			   ' Set the value of ICAP_XFERMECH (Image Transfer Mechanism) capability
			   _twainSession.SetCapability(twnCap, TwainSetCapabilityMode.Set)
			Catch ex As Exception
			   Dim errorMsg As String = String.Format("Error set TwainCapabilityType.ImageTranserMechanism is {0}", ex.Message)
			   AddErrorToErrorList(errorMsg)
			End Try
		 End Using
	  End Sub

	  Private Sub FinilizeTwain()
		 If _twainAvailable Then
			' End TWAIN session
			' For each call to the Startup method there must be a call to the Shutdown method
			Me._twainSession.Shutdown()
		 End If
	  End Sub

   End Class
End Namespace
