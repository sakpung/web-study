' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools.ImageProcessing
'using Leadtools.ImageProcessing.Color;
'using Leadtools.ImageProcessing.Effects;

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for ValueDialog.
   ''' </summary>
   Public Class ValueDialog : Inherits System.Windows.Forms.Form
      Private WithEvents _btnOk As System.Windows.Forms.Button
      Private _btnCancel As System.Windows.Forms.Button
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
         Me._btnOk = New System.Windows.Forms.Button()
         Me._btnCancel = New System.Windows.Forms.Button()
         Me._gbOptions = New System.Windows.Forms.GroupBox()
         Me._numericValue = New System.Windows.Forms.NumericUpDown()
         Me._gbOptions.SuspendLayout()
         CType(Me._numericValue, System.ComponentModel.ISupportInitialize).BeginInit()
         Me.SuspendLayout()
         ' 
         ' _btnOk
         ' 
         Me._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnOk.Location = New System.Drawing.Point(192, 16)
         Me._btnOk.Name = "_btnOk"
         Me._btnOk.TabIndex = 2
         Me._btnOk.Text = "OK"
         '         Me._btnOk.Click += New System.EventHandler(Me._btnOk_Click);
         ' 
         ' _btnCancel
         ' 
         Me._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
         Me._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
         Me._btnCancel.Location = New System.Drawing.Point(192, 48)
         Me._btnCancel.Name = "_btnCancel"
         Me._btnCancel.TabIndex = 3
         Me._btnCancel.Text = "Cancel"
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
         Me._numericValue.TabIndex = 1
         '         Me._numericValue.Leave += New System.EventHandler(Me._num_Leave);
         ' 
         ' ValueDialog
         ' 
         Me.AcceptButton = Me._btnOk
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.CancelButton = Me._btnCancel
         Me.ClientSize = New System.Drawing.Size(274, 79)
         Me.Controls.Add(Me._gbOptions)
         Me.Controls.Add(Me._btnCancel)
         Me.Controls.Add(Me._btnOk)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "ValueDialog"
         Me.ShowInTaskbar = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "ValueDialog"
         '         Me.Load += New System.EventHandler(Me.ValueDialog_Load);
         Me._gbOptions.ResumeLayout(False)
         CType(Me._numericValue, System.ComponentModel.ISupportInitialize).EndInit()
         Me.ResumeLayout(False)

      End Sub
#End Region

      Public Enum TypeConstants
         ScaleFactor
         PaintIntensity
         PaintContrast
         PaintGamma
         AutoCrop
         Average
         Gaussian
         Median
         Mosaic
         Oilify
         Posterize
         Sharpen
         Min
         Max
         Contrast
         GammaCorrect
         HistoContrast
         Hue
         Intensity
         Saturation
         Solarize
      End Enum

      Private Structure TypeProp
         Public Type As TypeConstants
         Public CaptionName As String
         Public ValueName As String
         Public InitialValue As Integer
         Public ReadInitialValue As Boolean
         Public Min As Integer
         Public Max As Integer
         Public MultiplyBy As Integer

         Public Sub New(ByVal type_Renamed As TypeConstants, ByVal captionName_Renamed As String, ByVal valueName_Renamed As String, ByVal initialValue_Renamed As Integer, ByVal readInitialValue_Renamed As Boolean, ByVal min_Renamed As Integer, ByVal max_Renamed As Integer, ByVal multiplyBy_Renamed As Integer)
            Type = type_Renamed
            CaptionName = captionName_Renamed
            ValueName = valueName_Renamed
            InitialValue = initialValue_Renamed
            ReadInitialValue = readInitialValue_Renamed
            Min = min_Renamed
            Max = max_Renamed
            MultiplyBy = multiplyBy_Renamed
         End Sub
      End Structure

      Private Shared _typeProp As TypeProp() = New TypeProp() {New TypeProp(TypeConstants.ScaleFactor, "Scale Factor (%)", "Scale Factor", 0, True, 1, 1000, 1), New TypeProp(TypeConstants.PaintIntensity, "Paint Intensity", "Paint Intensity", 0, True, -100, 100, 10), New TypeProp(TypeConstants.PaintContrast, "Paint Contrast", "Paint Contrast", 0, True, -100, 100, 10), New TypeProp(TypeConstants.PaintGamma, "Paint Gamma", "Paint Gamma", 0, True, 10, 500, 1), New TypeProp(TypeConstants.AutoCrop, "Auto Crop (Trim)", "Threshold", 0, True, 0, 244, 1), New TypeProp(TypeConstants.Average, "Average", "Dimension", 3, False, 3, 255, 1), New TypeProp(TypeConstants.Gaussian, "Gaussian", "Radius", 0, False, 1, 1000, 1), New TypeProp(TypeConstants.Median, "Median", "Dimension", 2, False, 2, 64, 1), New TypeProp(TypeConstants.Mosaic, "Mosaic", "Dimension", 2, False, 2, 64, 1), New TypeProp(TypeConstants.Oilify, "Oilify", "Dimension", 2, False, 2, 255, 1), New TypeProp(TypeConstants.Posterize, "Posterize", "Levels", 2, False, 2, 64, 1), New TypeProp(TypeConstants.Sharpen, "Sharpen", "Sharpness", 0, False, -100, 100, 10), New TypeProp(TypeConstants.Min, "Min Filter", "Sample Size", 1, False, 1, 32, 1), New TypeProp(TypeConstants.Max, "Max Filter", "Sample Size", 1, False, 1, 32, 1), New TypeProp(TypeConstants.Contrast, "Contrast", "Contrast", 0, False, -100, 100, 10), New TypeProp(TypeConstants.GammaCorrect, "Gamma Correct", "Gamma", 10, False, 10, 500, 1), New TypeProp(TypeConstants.HistoContrast, "Histo Contrast", "Contrast", 0, False, -100, 100, 10), New TypeProp(TypeConstants.Hue, "Hue", "Angle", 0, False, -360, 360, 1), New TypeProp(TypeConstants.Intensity, "Intensity (Brightness)", "Brightness", 0, False, -100, 100, 10), New TypeProp(TypeConstants.Saturation, "Saturation", "Change", 0, False, -100, 100, 10), New TypeProp(TypeConstants.Solarize, "Solarize", "Threshold", 0, False, 0, 255, 1)}

      Public Value As Integer

      Private _type As TypeConstants

      Private Sub ValueDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Dim prop As TypeProp = _typeProp(CInt(_type))
         Text = prop.CaptionName
         _gbOptions.Text = prop.ValueName
         _numericValue.Minimum = prop.Min
         _numericValue.Maximum = prop.Max
         If prop.ReadInitialValue Then
            prop.InitialValue = Value
         Else
            Value = prop.InitialValue
         End If

         DialogUtilities.SetNumericValue(_numericValue, CInt(Value / prop.MultiplyBy))
      End Sub

      Private Sub _num_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles _numericValue.Leave
         DialogUtilities.NumericOnLeave(sender)
      End Sub

      Private Sub _btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _btnOk.Click
         Dim index As Integer = CInt(_type)
         Value = CInt(_numericValue.Value) * _typeProp(index).MultiplyBy
         _typeProp(index).InitialValue = Value
      End Sub
   End Class
End Namespace
