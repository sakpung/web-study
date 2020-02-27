' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace MagnifyGlassDemo
   ''' <summary>
   ''' Summary description for ValueDialog.
   ''' </summary>
   Public Class ValueDialog : Inherits System.Windows.Forms.Form
      Private _btnCancel As System.Windows.Forms.Button
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _gbOptions As System.Windows.Forms.GroupBox
      Private WithEvents _numericValue As System.Windows.Forms.NumericUpDown

      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.Container = Nothing

      Public Sub New(ByVal type As TypeConstants)
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         '
         ' TODO: Add any constructor code after InitializeComponent call
         '
         _type = type
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
            End If
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"
      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._btnOk = New System.Windows.Forms.Button()
         Me._gbOptions = New System.Windows.Forms.GroupBox()
         Me._numericValue = New System.Windows.Forms.NumericUpDown()
         Me._gbOptions.SuspendLayout()
         CType(Me._numericValue, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(192, 48)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.TabIndex = 2
         Me._btnCancel.Text = "Cancel"
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(192, 16)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.TabIndex = 1
         Me._btnOk.Text = "OK"
         ' 
         ' _gbOptions
         ' 
         Me._gbOptions.Controls.Add(Me._numericValue)
         Me._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._gbOptions.Location = New System.Drawing.Point(8, 8)
         Me._gbOptions.Name = "_gbOptions"
         Me._gbOptions.Size = New System.Drawing.Size(160, 64)
         Me._gbOptions.TabIndex = 0
         Me._gbOptions.TabStop = False
         Me._gbOptions.Text = "Value"
         ' 
         ' _numericValue
         ' 
         Me._numericValue.Location = New System.Drawing.Point(16, 32)
         Me._numericValue.Name = "_numericValue"
         Me._numericValue.Size = New System.Drawing.Size(128, 20)
         Me._numericValue.TabIndex = 0
         ' 
         ' ValueDialog
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(274, 80)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.Controls.Add(Me._gbOptions)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ValueDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "ValueDialog"
         Me._gbOptions.ResumeLayout(False)
         CType(Me._numericValue, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Public Enum TypeConstants
         Width
         Height
         Border
         ScaleFactor
      End Enum

      Private Structure TypeProp
         Public Type As TypeConstants
         Public CaptionName As String
         Public ValueName As String
         Public Min As Integer
         Public Max As Integer

         Public Sub New(ByVal type_Renamed As TypeConstants, ByVal captionName_Renamed As String, ByVal valueName_Renamed As String, ByVal min_Renamed As Integer, ByVal max_Renamed As Integer)
            Type = type_Renamed
            CaptionName = captionName_Renamed
            ValueName = valueName_Renamed
            Min = min_Renamed
            Max = max_Renamed
         End Sub
      End Structure

      Private Shared _typeProp As TypeProp() = New TypeProp() {New TypeProp(TypeConstants.Width, "MagnifyGlass Width", "Width", 100, 500), New TypeProp(TypeConstants.Height, "MagnifyGlass Height", "Height", 100, 500), New TypeProp(TypeConstants.Border, "MagnifyGlass Border", "Border Width", 1, 11), New TypeProp(TypeConstants.ScaleFactor, "Magnifying Scale Factor", "Scale Factor", 1, 10)}

      Private _type As TypeConstants

      Public Value As Integer

      Private Sub ValueDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim prop As TypeProp = _typeProp(CInt(_type))
         Text = prop.CaptionName
         _gbOptions.Text = String.Format("{0} ({1}..{2})", prop.ValueName, prop.Min, prop.Max)
         _numericValue.Minimum = prop.Min
         _numericValue.Maximum = prop.Max

         DialogUtilities.SetNumericValue(_numericValue, Value)
      End Sub

      Private Sub _numericValue_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numericValue.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Dim index As Integer = CInt(_type)
         Value = CInt(_numericValue.Value)
      End Sub
   End Class
End Namespace
