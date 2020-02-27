' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class GatewaySettingsView : Inherits UserControl
      Public Sub New()
         MyBase.New()
         InitializeComponent()

         GatewaysItemsGridView.AddText = "Create Gateway"
         GatewaysItemsGridView.ModifyText = "Modify Gateway"
         GatewaysItemsGridView.DeleteText = "Remove Gateway"

         RemoteServersItemsGridView.AddText = "Add Server"
         RemoteServersItemsGridView.ModifyText = "Modify Server"
         RemoteServersItemsGridView.DeleteText = "Delete Server"

         AddHandler NumberOfTimesToUseSecondaryServerNumericUpDown.ValueChanged, AddressOf NumberOfTimesToUseSecondaryServerNumericUpDown_ValueChanged
      End Sub

      Public Property NumberOfTimesToUseSecondaryServer() As Integer
         Get
            Return CInt(NumberOfTimesToUseSecondaryServerNumericUpDown.Value)

         End Get
         Set(ByVal value As Integer)
            NumberOfTimesToUseSecondaryServerNumericUpDown.Value = value
         End Set
      End Property

      Public Event NumberOfTimesToUseSecondaryServerChanged As EventHandler

      Private Sub NumberOfTimesToUseSecondaryServerNumericUpDown_ValueChanged(ByVal sender As Object, ByVal e As EventArgs)
         If Not Nothing Is NumberOfTimesToUseSecondaryServerChangedEvent Then
            RaiseEvent NumberOfTimesToUseSecondaryServerChanged(Me, e)
         End If
      End Sub

        Friend Sub ShowErrorMessage(ByVal errorMessage As String)
            MessageBox.Show(errorMessage, "Gateway", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub

        Friend Function ShowConfirmMessage(ByVal confirmMessage As String) As Boolean
            Dim dr As DialogResult = MessageBox.Show(confirmMessage, "Gateway", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            Return (dr = DialogResult.Yes)
        End Function

        Friend Sub ShowMessage(ByVal message As String)
            MessageBox.Show(message, "Gateway", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Sub
    End Class
End Namespace
