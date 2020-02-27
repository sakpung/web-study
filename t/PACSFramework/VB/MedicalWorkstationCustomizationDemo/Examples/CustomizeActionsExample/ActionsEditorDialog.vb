' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.MedicalViewer
Imports Leadtools.Medical.Workstation.UI

Namespace Leadtools.Demos.Workstation.Customized
   Partial Public Class ActionsEditorDialog : Inherits WorkstationModalViewBase : Implements IActionsEditorView
#Region "Public"

#Region "Methods"

      Public Sub New()
         InitializeComponent()

         RegisterEvents()
      End Sub

      Public Sub SetActions(ByVal actions As MedicalViewerActionType()) Implements IActionsEditorView.SetActions
         ActionComboBox.DataSource = actions
      End Sub

      Public Sub SetActionMouseButtons(ByVal mouseButtons As MedicalViewerMouseButtons()) Implements IActionsEditorView.SetActionMouseButtons
         MouseButtonsComboBox.DataSource = mouseButtons
      End Sub

      Public Sub SetValidationErrorText(ByVal message As String) Implements IActionsEditorView.SetValidationErrorText
         errorProvider1.SetError(FeautreIdTextBox, message)
      End Sub

#End Region

#Region "Properties"

      Public Property SelectedAction() As MedicalViewerActionType Implements IActionsEditorView.SelectedAction
         Get
            Return CType(ActionComboBox.SelectedItem, MedicalViewerActionType)
         End Get

         Set(ByVal value As MedicalViewerActionType)
            ActionComboBox.SelectedItem = value
         End Set
      End Property

      Public Property ActionDisplayName() As String Implements IActionsEditorView.ActionDisplayName
         Get
            Return ActionDisplayNameTextBox.Text
         End Get

         Set(ByVal value As String)
            ActionDisplayNameTextBox.Text = value
         End Set
      End Property

      Public Property SelectedMouseButton() As MedicalViewerMouseButtons Implements IActionsEditorView.SelectedMouseButton
         Get
            Return CType(MouseButtonsComboBox.SelectedItem, MedicalViewerMouseButtons)
         End Get

         Set(ByVal value As MedicalViewerMouseButtons)
            MouseButtonsComboBox.SelectedItem = value
         End Set
      End Property

      Public Property CanEditToolstripButtons() As Boolean Implements IActionsEditorView.CanEditToolstripButtons
         Get
            Return ToolStripButtonsGroupBox.Enabled
         End Get

         Set(ByVal value As Boolean)
            ToolStripButtonsGroupBox.Enabled = value
         End Set
      End Property

      Public Property FeatureId() As String Implements IActionsEditorView.FeatureId
         Get
            Return FeautreIdTextBox.Text
         End Get

         Set(ByVal value As String)
            FeautreIdTextBox.Text = value
         End Set
      End Property

      Public Property ToolStipItemImage() As Image Implements IActionsEditorView.ToolStipItemImage
         Get
            Return ImagePictureBox.Image
         End Get

         Set(ByVal value As Image)
            ImagePictureBox.Image = value
         End Set
      End Property

      Public Property ToolStipItemAlternativeImage() As Image Implements IActionsEditorView.ToolStipItemAlternativeImage
         Get
            Return AltImagePictureBox.Image
         End Get

         Set(ByVal value As Image)
            AltImagePictureBox.Image = value
         End Set
      End Property

      Public Property CanAddAction() As Boolean Implements IActionsEditorView.CanAddAction
         Get
            Return AddActionButton.Enabled
         End Get

         Set(ByVal value As Boolean)
            AddActionButton.Enabled = value
         End Set
      End Property

      Public Property CanRemoveAction() As Boolean Implements IActionsEditorView.CanRemoveAction
         Get
            Return RemoveActionButton.Enabled
         End Get

         Set(ByVal value As Boolean)
            RemoveActionButton.Enabled = value
         End Set
      End Property

      Public Property CanChangeDisplayName() As Boolean Implements IActionsEditorView.CanChangeDisplayName
         Get
            Return ActionDisplayNameTextBox.Enabled
         End Get
         Set(ByVal value As Boolean)
            ActionDisplayNameTextBox.Enabled = value
         End Set
      End Property

      Public Property CanChangeMouseButton() As Boolean Implements IActionsEditorView.CanChangeMouseButton
         Get
            Return MouseButtonsComboBox.Enabled
         End Get
         Set(ByVal value As Boolean)
            MouseButtonsComboBox.Enabled = value
         End Set
      End Property

      Public Property CanChangeFeatureId() As Boolean Implements IActionsEditorView.CanChangeFeatureId
         Get
            Return FeautreIdTextBox.Enabled
         End Get
         Set(ByVal value As Boolean)
            FeautreIdTextBox.Enabled = value
         End Set
      End Property

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

      Public Event SelectedActionChanged As EventHandler Implements IActionsEditorView.SelectedActionChanged
      Public Event SelectedActionMouseButtonChanged As EventHandler Implements IActionsEditorView.SelectedActionMouseButtonChanged
      Public Event AddSelectedAction As EventHandler Implements IActionsEditorView.AddSelectedAction
      Public Event RemoveSelectedAction As EventHandler Implements IActionsEditorView.RemoveSelectedAction
      Public Event ValidateFeatureId As CancelEventHandler Implements IActionsEditorView.ValidateFeatureId

#End Region

#End Region

#Region "Protected"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

      Private Sub RegisterEvents()
         AddHandler ActionComboBox.SelectionChangeCommitted, AddressOf ActionComboBox_SelectionChangeCommitted
         AddHandler MouseButtonsComboBox.SelectionChangeCommitted, AddressOf MouseButtonsComboBox_SelectionChangeCommitted
         AddHandler FeautreIdTextBox.Validating, AddressOf FeautreIdTextBox_Validating
         AddHandler AddActionButton.Click, AddressOf AddActionButton_Click
         AddHandler RemoveActionButton.Click, AddressOf RemoveActionButton_Click
         AddHandler BrowseButton.Click, AddressOf BrowseButton_Click
         AddHandler AlternativeImageButton.Click, AddressOf AlternativeImageButton_Click
      End Sub

#End Region

#Region "Properties"

#End Region

#Region "Events"

      Private Sub ActionComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is SelectedActionChangedEvent Then
               RaiseEvent SelectedActionChanged(Me, e)
            End If
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub MouseButtonsComboBox_SelectionChangeCommitted(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is SelectedActionMouseButtonChangedEvent Then
               RaiseEvent SelectedActionMouseButtonChanged(Me, e)
            End If
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub FeautreIdTextBox_Validating(ByVal sender As Object, ByVal e As CancelEventArgs)
         Try
            If Not Nothing Is ValidateFeatureIdEvent Then
               RaiseEvent ValidateFeatureId(Me, e)
            End If
         Catch exception As Exception
            e.Cancel = True

            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub AddActionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is AddSelectedActionEvent Then
               RaiseEvent AddSelectedAction(Me, e)
            End If
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub RemoveActionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is RemoveSelectedActionEvent Then
               RaiseEvent RemoveSelectedAction(Me, e)
            End If
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub BrowseButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            Using openFileDlg As OpenFileDialog = New OpenFileDialog()
               openFileDlg.Filter = "Image Formats (*.jpg, *.bmp, *.ico)|*.jpg;*.bmp;*.ico"

               If openFileDlg.ShowDialog() = DialogResult.OK Then
                  ImagePictureBox.Image = Image.FromFile(openFileDlg.FileName)
               End If
            End Using
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub AlternativeImageButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            Using openFileDlg As OpenFileDialog = New OpenFileDialog()
               openFileDlg.Filter = "Image Formats (*.jpg, *.bmp, *.ico)|*.jpg;*.bmp;*.ico"

               If openFileDlg.ShowDialog() = DialogResult.OK Then
                  AltImagePictureBox.Image = Image.FromFile(openFileDlg.FileName)
               End If
            End Using
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

#End Region

#Region "Data Members"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Events"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region
   End Class
End Namespace
