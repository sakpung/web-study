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

Namespace Leadtools.Dicom.Server.Manager.Dialogs
    Partial Public Class HelpDialog
        Inherits Form
        Public Sub New()
            InitializeComponent()
            _showHelpCheckBox = False
        End Sub

        Private _showHelpCheckBox As Boolean

        Public Property ShowHelpCheckBox() As Boolean
            Get
                Return _showHelpCheckBox
            End Get
            Set(ByVal value As Boolean)
                _showHelpCheckBox = value
            End Set
        End Property

        Public Property CheckBoxNoShowAgainResult() As Boolean
            Get
                Return _checkBoxNoShowAgain.Checked
            End Get
            Set(ByVal value As Boolean)
                _checkBoxNoShowAgain.Checked = value
            End Set
        End Property
        Private _serverAE As String = String.Empty

        Private Sub ColorText(ByVal text As String, ByVal color As Color)
            _richTextBoxHelp.SelectionColor = color
            _richTextBoxHelp.SelectedText = text
            _richTextBoxHelp.SelectionColor = color.Black
        End Sub

        Private Sub BoldText(ByVal text As String)
            Dim font As Font = _richTextBoxHelp.SelectionFont
            Dim fontBold As New Font(font.Name, font.Size, FontStyle.Bold)
            _richTextBoxHelp.SelectionFont = fontBold
            _richTextBoxHelp.SelectedText = text
            _richTextBoxHelp.SelectionFont = font
        End Sub

        Private Sub HelpDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            _pictureBox.Image = System.Drawing.SystemIcons.Information.ToBitmap()

            _richTextBoxHelp.Clear()
            _richTextBoxHelp.SelectionColor = Color.Black
            BoldText("This utility allows management of multiple LEADTOOLS PACS Framework Servers from one location." + Environment.NewLine)
            ColorText("It can add, remove, start, stop & pause any of the server services. It also allows client configuration to any server and exposes the configuration settings for all add-ins for all servers from one user interface." + Environment.NewLine + Environment.NewLine + Environment.NewLine, Color.Black)

            ColorText("(Optional but Recommended) ", Color.Blue)
            _richTextBoxHelp.SelectedText = "Run the "
            BoldText("PACS Config Demo")
            Dim sMsg As String = String.Format(" to automatically create and configure a DICOM Server service, to configure the high-level DICOM client demos to communicate with this service, and to configure the logging viewer." & Constants.vbLf + Constants.vbLf)
            _richTextBoxHelp.SelectedText = sMsg

            ColorText("(Optional but Recommended) ", Color.Blue)

            _richTextBoxHelp.SelectedText = "View the "
            BoldText("PACS Framework")
            _richTextBoxHelp.SelectedText = " topic in the LEAD Help file. This gives a detailed explanation of the features of this demo." & Constants.vbLf + Constants.vbLf

            _richTextBoxHelp.SelectedText = "Run the  "
            BoldText("CSDicomHighlevelStoreDemo")
            _richTextBoxHelp.SelectedText = " demo to store DICOM images to the DICOM server." & Constants.vbLf + Constants.vbLf

            _richTextBoxHelp.SelectedText = "Run the  "
            BoldText("CSDicomHighlevelClientDemo")
            _richTextBoxHelp.SelectedText = " demo to retrieve the stored images from the DICOM server." & Constants.vbLf + Constants.vbLf

            _richTextBoxHelp.SelectionBullet = False

            _checkBoxNoShowAgain.Visible = _showHelpCheckBox
            buttonOK.Select()
        End Sub
    End Class
End Namespace
