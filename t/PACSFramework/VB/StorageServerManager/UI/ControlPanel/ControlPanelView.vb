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
Imports Leadtools.Dicom.AddIn.Interfaces
Imports Leadtools.Demos.StorageServer.DataTypes
Imports Leadtools.Medical.Winforms

Namespace Leadtools.Demos.StorageServer.UI
   Partial Friend Class ControlPanelView : Inherits UserControl
#Region "Public"

#Region "Methods"

      Public Sub New()
         InitializeComponent()

         _itemFeature.ToolTipIcon = ToolTipIcon.Info
         _itemFeature.UseAnimation = True
         _itemFeature.UseFading = True
         _itemFeature.IsBalloon = True
         _itemFeature.InitialDelay = 0
         _itemFeature.AutoPopDelay = 90000
         _itemFeature.ShowAlways = True

      End Sub

      Public Sub SetItem(ByVal item As PanelItem)
         Dim label As Button = New Button()


         SetLabelItem(label, item)

         AddHandler label.Click, AddressOf label1_Click

         AddinsTableLayoutPanel.Controls.Add(label)
      End Sub

      'Private Function MyFunc(ByRef n As Button, ByVal item As PanelItem) As Boolean
      '   n.Tag = item
      'End Function

      Public Sub RefreshItem(ByVal item As PanelItem)
         Dim label As Button = AddinsTableLayoutPanel.Controls.OfType(Of Button)().Where(Function(y) y.Tag Is item).FirstOrDefault()

         If label IsNot Nothing Then
            SetLabelItem(label, item)
         End If
      End Sub

      Public Sub ClearItems()
         AddinsTableLayoutPanel.Controls.Clear()
      End Sub

#End Region

#Region "Properties"

      Public Property Notes() As String
         Get
            Return _notes
         End Get

         Set(ByVal value As String)
            _notes = value

            NotesRichTextBox.Text = value
         End Set
      End Property
      Private _notes As String = String.Empty

#End Region

#Region "Data Types Definition"

#End Region

#Region "Callbacks"

      Public Event ItemClicked As EventHandler(Of DisplayFeatureEventArgs)

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

      Private Sub SetLabelItem(ByVal label As Button, ByVal item As PanelItem)
         If Not Nothing Is item.Image Then
            label.Image = item.Image
         End If

         label.Text = item.Text
         label.Tag = item
         label.TextImageRelation = TextImageRelation.ImageBeforeText
         label.ImageAlign = ContentAlignment.MiddleLeft
         label.TextAlign = ContentAlignment.MiddleCenter
         label.Cursor = Cursors.Hand
         label.AutoSize = True
         label.Size = New Size(170, 60)
         label.Margin = New Padding(10)
         label.Enabled = item.Enabled

         _itemFeature.SetToolTip(label, item.ToolTip)

         'label.MouseHover += new EventHandler ( label_MouseHover ) ;
         'label.MouseLeave += new EventHandler ( label_MouseLeave ) ;
      End Sub

      Public Sub EnableItem(ByVal enabled As Boolean, ByVal item As PanelItem)
         For Each control As Control In AddinsTableLayoutPanel.Controls
            Dim panelItem As PanelItem = TryCast(control.Tag, PanelItem)

            If panelItem IsNot Nothing AndAlso panelItem Is item Then
               control.Enabled = enabled
               Exit For
            End If
         Next control
      End Sub

      Private Sub label_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
         NotesRichTextBox.Text = _notes
      End Sub

      Private Sub label_MouseHover(ByVal sender As Object, ByVal e As EventArgs)
         If TypeOf (CType(sender, Control)).Tag Is PanelItem Then
            Dim item As PanelItem = CType((CType(sender, Control)).Tag, PanelItem)

            If (Not String.IsNullOrEmpty(item.ToolTip)) Then
               NotesRichTextBox.Text = item.ToolTip
            End If
         End If
      End Sub

#End Region

#Region "Properties"

#End Region

#Region "Events"

      Private Sub label1_Click(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not Nothing Is ItemClickedEvent Then
               RaiseEvent ItemClicked(Me, New DisplayFeatureEventArgs((CType((CType(sender, Control)).Tag, PanelItem)).Feature))
            End If
         Catch exception As Exception
            MessageBox.Show(exception.Message)
         End Try
      End Sub

#End Region

#Region "Data Members"

      Private _itemFeature As ToolTip = New ToolTip()

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

   Public Class PanelItem
      Private _toolTip As String
      Public Property ToolTip() As String
         Get
            Return _toolTip
         End Get
         Set(ByVal value As String)
            _toolTip = value
         End Set
      End Property

      Private _text As String
      Public Property Text() As String
         Get
            Return _text
         End Get
         Set(ByVal value As String)
            _text = value
         End Set
      End Property

      Private _image As Image
      Public Property Image() As Image
         Get
            Return _image
         End Get
         Set(ByVal value As Image)
            _image = value
         End Set
      End Property

      Private _enabled As Boolean
      Public Property Enabled() As Boolean
         Get
            Return _enabled
         End Get
         Set(ByVal value As Boolean)
            _enabled = value
         End Set
      End Property

      Private _feature As FeatureNames
      Public Property Feature() As FeatureNames
         Get
            Return _feature
         End Get
         Set(ByVal value As FeatureNames)
            _feature = value
         End Set
      End Property
   End Class
End Namespace
