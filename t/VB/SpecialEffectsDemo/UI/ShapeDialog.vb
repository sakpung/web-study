' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools.SpecialEffects

Namespace SpecialEffectsDemo
   Partial Public Class ShapeDialog : Inherits Form
      Public Sub New(ByVal options As ShapeOptions)
         _options = options

         InitializeComponent()
      End Sub

      Private _options As ShapeOptions

      Private Sub ShapeDialog_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         Dim s As ArrayList = New ArrayList()

         s.Add(New ComboBoxItem("Squares: Normal", CInt(SpecialEffectsShape.Square)))
         s.Add(New ComboBoxItem("Rectangles: Normal", CInt(SpecialEffectsShape.Rectangle)))
         s.Add(New ComboBoxItem("Parallelograms: Left", CInt(SpecialEffectsShape.ParallelogramL)))
         s.Add(New ComboBoxItem("Trapezoids: Left", CInt(SpecialEffectsShape.TrapezoidL)))
         s.Add(New ComboBoxItem("Triangles: Equilateral Left", CInt(SpecialEffectsShape.TriangleEquilateralL)))
         s.Add(New ComboBoxItem("Other: Octagon", CInt(SpecialEffectsShape.Octagon)))
         s.Add(New ComboBoxItem("Circles: Normal", CInt(SpecialEffectsShape.Circle)))
         s.Add(New ComboBoxItem("Ellipses: Normal", CInt(SpecialEffectsShape.Ellipse)))
         s.Add(New ComboBoxItem("Stars: 8-Point", CInt(SpecialEffectsShape.Star8)))
         s.Add(New ComboBoxItem("Crosses: Small", CInt(SpecialEffectsShape.CrossSMALL)))
         s.Add(New ComboBoxItem("Arrows: Left", CInt(SpecialEffectsShape.ArrowL)))

         _cmbShapeStyle.Items.Clear()
         _cmbShapeStyle.DataSource = s
         _cmbShapeStyle.DisplayMember = "Display"
         _cmbShapeStyle.ValueMember = "Value"

         Dim i As Integer = 0
         Do While i < _cmbShapeStyle.Items.Count
            Dim item As ComboBoxItem = CType(_cmbShapeStyle.Items(i), ComboBoxItem)
            If _options.ShapeStyle = CType(item.Value, SpecialEffectsShape) Then
               _cmbShapeStyle.SelectedIndex = i
            End If
            i += 1
         Loop

         Dim ss As ArrayList = New ArrayList()

         ss.Add(New ComboBoxItem("Solid", CInt(SpecialEffectsFillStyle.Solid)))
         ss.Add(New ComboBoxItem("Transparent", CInt(SpecialEffectsFillStyle.Transparent)))
         ss.Add(New ComboBoxItem("Horizontal", CInt(SpecialEffectsFillStyle.Horizontal)))
         ss.Add(New ComboBoxItem("Vertical", CInt(SpecialEffectsFillStyle.Vertical)))
         ss.Add(New ComboBoxItem("Forward Diagonal", CInt(SpecialEffectsFillStyle.ForwardDiagonal)))
         ss.Add(New ComboBoxItem("Backward Diagonal", CInt(SpecialEffectsFillStyle.BackwardDiagonal)))
         ss.Add(New ComboBoxItem("Cross", CInt(SpecialEffectsFillStyle.Cross)))
         ss.Add(New ComboBoxItem("Diagonal Cross", CInt(SpecialEffectsFillStyle.DiagonalCross)))

         _cmbFillStyle.Items.Clear()
         _cmbFillStyle.DataSource = ss
         _cmbFillStyle.DisplayMember = "Display"
         _cmbFillStyle.ValueMember = "Value"

         i = 0
         Do While i < _cmbFillStyle.Items.Count
            Dim item As ComboBoxItem = CType(_cmbFillStyle.Items(i), ComboBoxItem)
            If _options.FillStyle = CType(item.Value, SpecialEffectsFillStyle) Then
               _cmbFillStyle.SelectedIndex = i
            End If
            i += 1
         Loop

         _btnForeColor.BackColor = _options.ForeColor
         _btnBackColor.BackColor = _options.BackColor

      End Sub

      Private Sub _btnForeColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnForeColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _btnForeColor.BackColor = dlg.Color
         End If
      End Sub

      Private Sub _btnBackColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnBackColor.Click
         Dim dlg As ColorDialog = New ColorDialog()
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _btnBackColor.BackColor = dlg.Color
         End If
      End Sub


      Public ReadOnly Property ShapeOptions() As ShapeOptions
         Get
            Return _options
         End Get
      End Property

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         Dim ss As ComboBoxItem = CType(_cmbShapeStyle.SelectedItem, ComboBoxItem)
         _options.ShapeStyle = CType(ss.Value, SpecialEffectsShape)

         Dim fs As ComboBoxItem = CType(_cmbFillStyle.SelectedItem, ComboBoxItem)
         _options.FillStyle = CType(fs.Value, SpecialEffectsFillStyle)

         _options.ForeColor = _btnForeColor.BackColor
         _options.BackColor = _btnBackColor.BackColor
      End Sub
   End Class
End Namespace
