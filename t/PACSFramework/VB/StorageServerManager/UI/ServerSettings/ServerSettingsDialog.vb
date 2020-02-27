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
Imports Leadtools.Demos.StorageServer.DataTypes

Namespace Leadtools.Demos.StorageServer.UI
   Partial Public Class ServerSettingsDialog : Inherits Form
#Region "Public"

#Region "Methods"

      Public Sub New()
         InitializeComponent()

         _featurePages = New Dictionary(Of FeatureNames, Control)()

         AddHandler treeView1.AfterSelect, AddressOf treeView1_AfterSelect
         AddHandler treeView1.BeforeSelect, AddressOf treeView1_BeforeSelect

         AddHandler OKButton.Click, AddressOf OKButton_Click
         AddHandler CancelChangesButton.Click, AddressOf CancelChangesButton_Click
         AddHandler ApplyChangesButton.Click, AddressOf ApplyChangesButton_Click
      End Sub

      Public Function IsFeatureAdded(ByVal feature As FeatureNames) As Boolean
         Return (_featurePages.ContainsKey(feature))
      End Function

      Public Sub SelectFeature(ByVal feature As FeatureNames)
         If _featurePages.ContainsKey(feature) Then
            If Not Nothing Is treeView1.SelectedNode AndAlso TypeOf treeView1.SelectedNode.Tag Is Control Then
               HideNodeControl(treeView1.SelectedNode)
            End If

            treeView1.SelectedNode = treeView1.Nodes.Find(feature.Name, True)(0)

            SelectNodeControl(treeView1.SelectedNode)
         End If
      End Sub

      Public Sub EnsureActive()
         If (Not Visible) Then
            ShowDialog()
         End If
      End Sub

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

      'public event EventHandler <DataEventArgs<FeatureNames>> FeatureSelected ;
      Public Event FeatureSelected As EventHandler(Of DataEventArgs(Of FeatureNames))
      Public Event ConfirmChanges As EventHandler
      Public Event CancelChanges As EventHandler
      Public Event ApplyChanges As EventHandler

#End Region

#End Region

#Region "Protected"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "Private"

#Region "Methods"

      Private Sub OnFeatureSelected(ByVal feature As FeatureNames)
         If Not FeatureSelectedEvent Is Nothing Then
            RaiseEvent FeatureSelected(Me, New DataEventArgs(Of FeatureNames)(feature))
         End If
      End Sub

      Public Sub AddFeatureControl(ByVal feature As FeatureNames, ByVal page As Control, ByVal parentFeature As FeatureNames)
         If _featurePages.ContainsKey(feature) Then
            Throw New InvalidOperationException("Feature is already added")
         End If

         If Not parentFeature Is Nothing AndAlso (Not _featurePages.ContainsKey(parentFeature)) Then
            Throw New InvalidOperationException("Parent feature is not added")
         End If

         Dim featureNode As TreeNode = CreateFeatureNode(feature, parentFeature)

         featureNode.Tag = page

         'page.Visible = _featurePages.Count == 0  ;

         page.Visible = False
         PagesContainerPanel.Controls.Add(page)
         page.Dock = DockStyle.Fill
         _featurePages.Add(feature, page)
      End Sub

      Private Function CreateFeatureNode(ByVal feature As FeatureNames, ByVal parentFeature As FeatureNames) As TreeNode
         Dim parent As TreeNode() = Nothing
         Dim featureNode As TreeNode

         If Not Nothing Is parentFeature Then
            parent = treeView1.Nodes.Find(parentFeature.Name, True)
         End If

         featureNode = New TreeNode(feature.DisplayName)
         featureNode.Name = feature.Name

         If Not Nothing Is parent AndAlso parent.Length > 0 Then
            parent(0).Nodes.Add(featureNode)
         Else
            treeView1.Nodes.Add(featureNode)
         End If

         Return featureNode
      End Function

      Private Sub HideNodeControl(ByVal node As TreeNode)
         CType(node.Tag, Control).Visible = False
      End Sub

      Private Sub SelectNodeControl(ByVal node As TreeNode)
         CType(node.Tag, Control).Visible = True
         OnFeatureSelected(_featurePages.First(Function(n) n.Key.Name = node.Name).Key)
      End Sub

#End Region

#Region "Properties"

#End Region

#Region "Events"

      Private Sub treeView1_BeforeSelect(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
         Try
            If Not treeView1.SelectedNode Is Nothing AndAlso TypeOf treeView1.SelectedNode.Tag Is Control Then
               HideNodeControl(treeView1.SelectedNode)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub treeView1_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs)
         Try
            If TypeOf e.Node.Tag Is Control Then
               SelectNodeControl(e.Node)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub OKButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is ConfirmChangesEvent Then
               RaiseEvent ConfirmChanges(Me, e)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub CancelChangesButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is CancelChangesEvent Then
               RaiseEvent CancelChanges(Me, e)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub ApplyChangesButton_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is ApplyChangesEvent Then
               RaiseEvent ApplyChanges(Me, e)
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Public Property CanCancel() As Boolean
         Get
            Return CancelChangesButton.Enabled
         End Get

         Set(ByVal value As Boolean)
            CancelChangesButton.Enabled = value
         End Set
      End Property

      Public Property CanApply() As Boolean
         Get
            Return ApplyChangesButton.Enabled
         End Get

         Set(ByVal value As Boolean)
            ApplyChangesButton.Enabled = value
         End Set
      End Property

#End Region

#Region "Data Members"

      Private _featurePages As Dictionary(Of FeatureNames, Control)

#End Region

#Region "Data Types Definition"

#End Region

#End Region

#Region "internal"

#Region "Methods"

#End Region

#Region "Properties"

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

#End Region

#End Region
   End Class
End Namespace
