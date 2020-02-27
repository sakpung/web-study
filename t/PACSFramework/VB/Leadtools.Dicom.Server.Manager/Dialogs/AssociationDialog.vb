' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom.AddIn.Common

Namespace Leadtools.Dicom.Server.Manager.Dialogs
    Partial Public Class AssociationDialog
        Inherits Form
        Private Client As ClientInfo

        Public Sub New(ByVal client As ClientInfo)
            InitializeComponent()
            Me.Client = client
        End Sub

        Private Sub AssociationDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            Text = My.Resources.ViewAssociation & " [" & Client.AETitle & "]"
            textBoxAssociation.Text = Client.Association
            textBoxAssociation.Select(0, 0)

            labelAssociation.Text = My.Resources.AssociationLabel
            buttonOK.Text = My.Resources.OkText
            Icon = My.Resources.ApplicationIcon
        End Sub
    End Class
End Namespace
