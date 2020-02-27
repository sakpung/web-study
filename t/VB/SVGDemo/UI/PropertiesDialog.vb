' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Windows.Forms
Imports Leadtools.Codecs
Imports System

Namespace SvgDemo
   Partial Public Class PropertiesDialog
      Inherits Form
      Public Properties As LoadSvgProperties
      Public Message As String

      Public Sub New()
         InitializeComponent()
      End Sub

      Protected Overrides Sub OnLoad(e As EventArgs)
         If Not DesignMode Then
            _messageLabel.Text = String.Format("Set the options to use when loading files as SVG.{0}These options will be used when loading a new document.", Environment.NewLine)
            _propertyGrid.SelectedObject = Me.Properties
         End If

         MyBase.OnLoad(e)
      End Sub
   End Class

   Public Class LoadSvgProperties
      Public Property DropImages() As Boolean
         Get
            Return m_DropImages
         End Get
         Set(value As Boolean)
            m_DropImages = value
         End Set
      End Property
      Private m_DropImages As Boolean
      Public Property DropShapes() As Boolean
         Get
            Return m_DropShapes
         End Get
         Set(value As Boolean)
            m_DropShapes = value
         End Set
      End Property
      Private m_DropShapes As Boolean
      Public Property DropText() As Boolean
         Get
            Return m_DropText
         End Get
         Set(value As Boolean)
            m_DropText = value
         End Set
      End Property
      Private m_DropText As Boolean

      Public Sub New(options As CodecsLoadSvgOptions)
         DropImages = options.DropImages
         DropShapes = options.DropShapes
         DropText = options.DropText
      End Sub

      Public Sub UpdateCodecsLoadSvgOptions(options As CodecsLoadSvgOptions)
         options.DropImages = DropImages
         options.DropShapes = DropShapes
         options.DropText = DropText
      End Sub
   End Class
End Namespace
