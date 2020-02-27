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

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.SpecialEffects

#If (Not LEADTOOLS_V17_OR_LATER) Then
Imports LeadPoint = System.Drawing.Point
Imports LeadSize = System.Drawing.Size
Imports LeadRect = System.Drawing.Rectangle
#End If ' #if !LEADTOOLS_V17_OR_LATER

#If LEADTOOLS_V17_OR_LATER Then
Imports Leadtools.Drawing
#End If ' #if LEADTOOLS_V17_OR_LATER

Namespace SpecialEffectsDemo
   Partial Public Class MainForm : Inherits Form
      Public Sub New()
         InitializeComponent()
      End Sub

      Private _codecs As RasterCodecs

      Private _fileNameArray As String() = {"Sample1.cmp", "Sample2.cmp", "Sample3.cmp", "Sample4.cmp", "Sample5.cmp"}
      Private ImagePath As String = DemosGlobal.ImagesFolder & "\"

      ' Special Effects processor object.
      Private _processor As SpecialEffectsProcessor

      ' Special Effects private members
      Private _effectOptions As EffectOptions
      Private _transitionOptions As TransitionOptions
      Private _shapeOptions As ShapeOptions
      Private _textOptions As TextOptions

      ' Some Special Effects const options values.
      Private Const Speed As Integer = 0
      Private Const Cycles As Integer = 0
      Private Const Steps As Integer = 255
      Private Const Transparency As Boolean = False
      Private WandColor As Color = Color.Red

      ' Index of the current active image.
      Private _index As Integer
      Private _image As RasterImage
      ''' <summary>
      ''' Initializes the application
      ''' </summary>
      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         Try
            ' setup our caption
            Messager.Caption = "LEADTOOLS for .NET VB Special Effects Demo"
            Text = Messager.Caption

            ' intitialize the codecs object
            _codecs = New RasterCodecs()

            ' Initialize the private memebers

            _effectOptions = New EffectOptions(SpecialEffectsType.ZoomToC, 10, 10, 1, 0)

            _transitionOptions = New TransitionOptions(SpecialEffectsTransitionStyle.ConeFromB, Color.Red, Color.Blue, New EffectOptions(SpecialEffectsType.WipeLToR, 10, 10, 1, 0))

            _shapeOptions = New ShapeOptions(SpecialEffectsShape.CrossSMALL, SpecialEffectsFillStyle.Solid, Color.Red, Color.Blue)

            _textOptions = New TextOptions("LEADTOOLS", SpecialEffectsTextStyle.InsetLight, Color.Red, Color.Blue)

            _processor = New SpecialEffectsProcessor()

            _index = 0
            PaintSpecialEffects()
         Catch ex As Exception
            MessageBox.Show(ex.Message)
         End Try
      End Sub

      ''' <summary>
      ''' Shutdown the RasterCodecs before we go.
      ''' </summary>
      Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
      End Sub

      Private Sub _btnEffect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnEffect.Click
         Dim dlg As EffectsDialog = New EffectsDialog(_effectOptions)
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _effectOptions = dlg.EffectOptions
            Invalidate()
         End If
      End Sub

      Private Sub _btnTransition_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnTransition.Click
         Dim dlg As TransitionDialog = New TransitionDialog(_transitionOptions)
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _transitionOptions = dlg.TransitionOptions

            _ckShowTransition.Checked = True

            Invalidate()
         End If
      End Sub

      Private Sub _btnShape_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnShape.Click
         Dim dlg As ShapeDialog = New ShapeDialog(_shapeOptions)
         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _shapeOptions = dlg.ShapeOptions
            _ckShowShape.Checked = True
            Invalidate()
         End If
      End Sub

      Private Sub _btnText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnText.Click
         Dim dlg As TextDialog = New TextDialog(_textOptions)

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _textOptions = dlg.TextOptions
            _ckShowText.Checked = True
            Invalidate()
         End If
      End Sub

      Private Sub _btnShow_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnShow.Click
         PaintSpecialEffects()
      End Sub

      Private Sub PaintSpecialEffects()
         If Not _image Is Nothing Then
            _image.Dispose()
         End If

         _image = _codecs.Load(ImagePath & _fileNameArray(_index))

         _index = (_index + 1) Mod _fileNameArray.Length

         Dim g As Graphics = _pnlViewer.CreateGraphics()

         Dim rc As Rectangle = _pnlViewer.ClientRectangle

         rc = _processor.DrawFrame(g, rc, SpecialEffectsFrameStyleFlags.AdjustRectangle Or SpecialEffectsFrameStyleFlags.OuterRaised, 2, Color.Silver, 2, Color.DarkGray, Color.White, 2, Color.DarkGray, Color.White)

         Dim i As Integer = 0
         If _ckShowTransition.Checked Then
            Do While i < _transitionOptions.EffectOptions.Passes
               _processor.PaintTransition(g, _transitionOptions.Style, _transitionOptions.BackColor, _transitionOptions.ForeColor, Steps, rc, _transitionOptions.EffectOptions.Type, _transitionOptions.EffectOptions.Grain, _transitionOptions.EffectOptions.Delay, Speed, Cycles, i + 1, _transitionOptions.EffectOptions.Passes, Transparency, Color.Empty, _transitionOptions.EffectOptions.Wand, WandColor, RasterPaintProperties.SourceCopy, Nothing)
               i += 1
            Loop
         End If

         i = 0
         Do While i < _effectOptions.Passes
            Dim paintProp As RasterPaintProperties = New RasterPaintProperties()
            paintProp.RasterOperation = RasterPaintProperties.SourceCopy

            _processor.PaintImage(g, _image, Rectangle.Empty, Rectangle.Empty, rc, rc, _effectOptions.Type, _effectOptions.Grain, _effectOptions.Delay, 0, 0, i + 1, _effectOptions.Passes, False, Color.Empty, _effectOptions.Wand, WandColor, paintProp, Nothing)
            i += 1
         Loop

         If _ckShowShape.Checked Then
            _processor.Draw3dShape(g, _shapeOptions.ShapeStyle, rc, _shapeOptions.BackColor, Nothing, rc, SpecialEffectsBackStyle.Translucent, _shapeOptions.ForeColor, _shapeOptions.FillStyle, Color.Red, SpecialEffectsBorderStyle.Solid, 2, Color.Green, Color.Yellow, SpecialEffectsInnerStyle.Raised, 2, Color.Turquoise, Color.Snow, SpecialEffectsOuterStyle.Inset, 2, 5, 5, Color.Black, Nothing)
         End If

         If _ckShowText.Checked Then
            Dim ff As FontFamily = New FontFamily("Arial")

            Dim f As Font = New Font(ff, 48)

            _processor.Draw3dText(g, _textOptions.Text, rc, _textOptions.Style, SpecialEffectsTextAlignmentFlags.HorizontalCenter Or SpecialEffectsTextAlignmentFlags.VerticalCenter, 5, 5, _textOptions.TextColor, _textOptions.BorderColor, Color.White, f, Nothing)
         End If

         g.Dispose()
      End Sub

      Private Sub _pnlViewer_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles _pnlViewer.Paint
         If Not _image Is Nothing Then
            PaintSpecialEffects()
         End If
      End Sub
   End Class
End Namespace
