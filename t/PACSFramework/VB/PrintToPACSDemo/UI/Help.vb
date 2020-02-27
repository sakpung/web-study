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

Namespace PrintToPACSDemo
   Public Partial Class HelpDialog : Inherits Form
	  Public Sub New()
		 _serverAE = String.Empty
		 InitializeComponent()
	  End Sub

	  Public Sub New(ByVal serverAE As String, ByVal showHelpCheckBox As Boolean, ByVal bFirstTime As Boolean)
		 _serverAE = serverAE
		 _showHelpCheckBox = showHelpCheckBox
		 _firstrun = bFirstTime
		 InitializeComponent()
	  End Sub

	  Private _showHelpCheckBox As Boolean
	  Private _checkBoxNoShowAgainResult As Boolean

	  Public Property CheckBoxNoShowAgainResult() As Boolean
		 Get
			 Return _checkBoxNoShowAgainResult
		 End Get
		 Set
			 _checkBoxNoShowAgainResult = Value
		 End Set
	  End Property
	  Private _serverAE As String = String.Empty

	  Private _firstrun As Boolean = False

	  Private Sub ColorText(ByVal text As String, ByVal color As Color)
		 _richTextBoxHelp.SelectionColor = color
		 _richTextBoxHelp.SelectedText = text
		 _richTextBoxHelp.SelectionColor = Color.Black
	  End Sub

	  Private Sub BoldText(ByVal text As String)
		 Dim font As Font = _richTextBoxHelp.SelectionFont
		 Dim fontBold As Font = New Font(font.Name, font.Size, FontStyle.Bold)
		 _richTextBoxHelp.SelectionFont = fontBold
		 _richTextBoxHelp.SelectedText = text
		 _richTextBoxHelp.SelectionFont = font
	  End Sub

	  Private Sub _HelpDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
		 If _firstrun Then
			Me.Height = 650
		 Else
			Me.Height = 600
		 End If

		 _pictureBox.Image = System.Drawing.SystemIcons.Information.ToBitmap()

		 _richTextBoxHelp.Clear()
		 _richTextBoxHelp.SelectionColor = Color.Black
		 BoldText("This demo shows how to use the Leadtools.DICOM components with the Leadtools.printer component ." & Constants.vbLf + Constants.vbLf + Constants.vbLf)

		 ColorText("(Optional but Recommended) ", Color.Blue)
		 _richTextBoxHelp.SelectedText = "Run the "
		 BoldText("PACS Config Demo")
		 Dim sMsg As String = String.Format(" to automatically configure this demo and other client demos to communicate with a DICOM server." & Constants.vbLf + Constants.vbLf)
		 _richTextBoxHelp.SelectedText = sMsg

		 ColorText("(Optional) ", Color.Blue)
		 _richTextBoxHelp.SelectedText = "Click the "
		 BoldText("""Options""->""Settings""")
		 sMsg = String.Format(" Menu Item to configure this demo to communicate with the DICOM servers." & Constants.vbLf & " If this is the first time you run this demo PrintToPACS printer will be installed." & Constants.vbLf + Constants.vbLf)
		 _richTextBoxHelp.SelectedText = sMsg

		 ColorText("(Required) ", Color.Red)
		 sMsg = "Insert images to the demo, Use any of the following options:" & Constants.vbLf
		 sMsg &= "   1. Print any document to the "
		 _richTextBoxHelp.SelectedText = sMsg
		 BoldText("PrintToPACS Printer." & Constants.vbLf)
		 sMsg = "   2. Open any support image from the hard disk." & Constants.vbLf
		 _richTextBoxHelp.SelectedText = sMsg
		 sMsg = "   3. Scan images from Wia and Twain supported devices." & Constants.vbLf
		 _richTextBoxHelp.SelectedText = sMsg
		 sMsg = "   4. Capture any part of the screen." & Constants.vbLf + Constants.vbLf
		 _richTextBoxHelp.SelectedText = sMsg

		 ColorText("(Required) ", Color.Red)
   sMsg = String.Format("Start VBLeadtools.DICOM.Server.Manager.exe, select the {0} service, and click the ", _serverAE)
		 _richTextBoxHelp.SelectedText = sMsg
		 BoldText("Start Server")
		 _richTextBoxHelp.SelectedText = " button (blue triangle) to start the DICOM service." & Constants.vbLf + Constants.vbLf

		 ColorText("(Optional) ", Color.Blue)
		 _richTextBoxHelp.SelectedText = "Populate DICOM Information, Use one of the following options:" & Constants.vbLf
		 _richTextBoxHelp.SelectedText = "   1. Opening an existing "
		 BoldText("DICOM dataset." & Constants.vbLf)
		 _richTextBoxHelp.SelectedText = "   2. Query DICOM patients and studies from "
		 BoldText(" SCP server." & Constants.vbLf)
		 _richTextBoxHelp.SelectedText = "   3. Query DICOM "
		 BoldText(" Work Lists")
		 _richTextBoxHelp.SelectedText = "." & Constants.vbLf + Constants.vbLf

		 ColorText("(Optional) ", Color.Blue)
		 _richTextBoxHelp.SelectedText = "Click the "
		 BoldText("""File""->""Save DICOM File""")
		 _richTextBoxHelp.SelectedText = " Menu Item to save the generated DICOM on the hard disk." & Constants.vbLf + Constants.vbLf

		 ColorText("(Optional) ", Color.Blue)
		 _richTextBoxHelp.SelectedText = "Click the "
		 BoldText("""File""->""Remote PACS""")
		 _richTextBoxHelp.SelectedText = " Menu Item to send the generated DICOM to the storage SCP." & Constants.vbLf + Constants.vbLf

		 If _firstrun Then
			ColorText("(IMPORTANT) ", Color.Red)
			_richTextBoxHelp.SelectedText = "This is the "
			BoldText("first time")
			_richTextBoxHelp.SelectedText = " you run the demo" & Constants.vbLf & "the demo is loaded with a default image and default DICOM data" & Constants.vbLf & "just press on "
			BoldText("Push To PACS")
			_richTextBoxHelp.SelectedText = " button to send the DICOM file to the PACS Storage."
		 End If

		 _checkBoxNoShowAgain.Visible = _showHelpCheckBox
		 buttonOK.Select()
	  End Sub

	  Private Sub HelpDialog_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
		 CheckBoxNoShowAgainResult = _checkBoxNoShowAgain.Checked
	  End Sub

   End Class
End Namespace
