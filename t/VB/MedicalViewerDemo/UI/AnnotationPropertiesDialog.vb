' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms


Imports Leadtools
Imports Leadtools.MedicalViewer
Imports Leadtools.Annotations.Engine
Imports System.Drawing.Drawing2D

Namespace MedicalViewerDemo
   Partial Public Class AnnotationPropertiesDialog : Inherits Form
      Private _cell As MedicalViewerMultiCell = Nothing
      Private _annObj As AnnObject = Nothing
      Private _annFont As AnnFont = Nothing
      Private _fontColor As Color = Color.Empty

      Public Sub New(ByVal cell As MedicalViewerMultiCell)
         InitializeComponent()
         _cell = cell

         _annObj = _cell.Automation.CurrentEditObject

         If (Not _annObj.SupportsStroke) Then
            _tabAnnProperties.TabPages.Remove(_penTab)
         End If
         If (Not _annObj.SupportsFill) AndAlso Not (TypeOf _annObj Is AnnHiliteObject) Then
            _tabAnnProperties.TabPages.Remove(_brushTab)
         End If
         If (Not _annObj.SupportsFont) Then
            _tabAnnProperties.TabPages.Remove(_fontTab)
         End If

         _chkUsePen.Checked = _annObj.SupportsStroke

         _chkUseBrush.Checked = _annObj.SupportsFill Or (TypeOf _annObj Is AnnHiliteObject)

         If TypeOf _annObj Is AnnHiliteObject Then
            _chkUseBrush.Visible = False
            _brushTab.Text = "Hilite"
         End If

         'if (_annObj.SupportsStroke)
         '{
         '   foreach (AnnStrokeLineCap dash in (AnnStrokeLineCap[])Enum.GetValues(typeof(AnnStrokeLineCap)))
         '   {
         '      _cmbDashStyle.Items.Add(dash.ToString());
         '   }
         '}
         'else
         '   _cmbDashStyle.Enabled = false;

         If _annObj.SupportsFont Then
            Dim AnnTempText As AnnTextObject = CType(IIf(TypeOf _annObj Is AnnTextObject, _annObj, Nothing), AnnTextObject)
            Dim objFont As AnnFont = _annObj.Font
            _annFont = New AnnFont(objFont.FontFamilyName.ToString(), objFont.FontSize)
            _annFont.FontStyle = objFont.FontStyle
            Dim CurrentBrush As AnnSolidColorBrush = CType(IIf(TypeOf AnnTempText.TextForeground Is AnnSolidColorBrush, AnnTempText.TextForeground, Nothing), AnnSolidColorBrush)
            _fontColor = Color.FromName(CurrentBrush.Color)
         End If

         UpdateFont()
         UpdateBrush()
         UpdatePen()
      End Sub

      Private Sub _btnColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnColor.Click, button1.Click
         Select Case _tabAnnProperties.SelectedTab.Name
            Case "_penTab"
               MainForm.ShowColorDialog(_lblPenColor)
            Case "_brushTab"
               MainForm.ShowColorDialog(_lblBrushColor)
         End Select
      End Sub


      Private Sub _chkUsePen_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkUsePen.CheckedChanged
         If _chkUsePen.Checked Then
            _penGroup.Enabled = True
         Else
            _penGroup.Enabled = False
         End If
      End Sub

      Private Sub UpdatePen()
         If (Not _annObj.SupportsStroke) Then
            _penWidth.Value = 1

            _lblPenColor.BackColor = Color.Red
            '_cmbDashStyle.SelectedIndex = (int)AnnStrokeLineCap.Flat;
         Else
            If Not _annObj.Stroke Is Nothing Then
               _penWidth.Value = CInt(_annObj.Stroke.StrokeThickness.Value)
               Dim CurrentBrush As AnnSolidColorBrush = CType(IIf(TypeOf _annObj.Stroke.Stroke Is AnnSolidColorBrush, _annObj.Stroke.Stroke, Nothing), AnnSolidColorBrush)
               _lblPenColor.BackColor = Color.FromName(CurrentBrush.Color)
            Else
               _penWidth.Value = 1
               _lblPenColor.BackColor = Color.Red
               _chkUsePen.Checked = False
            End If
            '_cmbDashStyle.SelectedIndex = (int)_annObj.Stroke.StrokeDashCap; 
         End If
      End Sub

      Private Sub UpdateBrush()
         If _annObj IsNot Nothing Then
            If (Not _annObj.SupportsFill) Then
               If TypeOf _annObj Is AnnHiliteObject Then
                  _lblBrushColor.BackColor = Color.FromName((CType(_annObj, AnnHiliteObject)).HiliteColor)
               Else
                  _lblBrushColor.BackColor = Color.Red
               End If
            Else
               If (CType(_annObj.Fill, AnnSolidColorBrush) Is Nothing) Then
                  _annObj.Fill = AnnSolidColorBrush.Create("Transparent")
                  _lblBrushColor.BackColor = Color.FromName((CType(_annObj.Fill, AnnSolidColorBrush)).Color.ToString())
                  _chkUseBrush.Checked = False
               Else
                  _lblBrushColor.BackColor = Color.FromName((CType(_annObj.Fill, AnnSolidColorBrush)).Color.ToString())
               End If
            End If
         End If
      End Sub

      Private Sub UpdateFont()
         If _annObj.SupportsFont Then
            Dim style As FontStyle = 0
            If (_annFont.TextDecoration And AnnTextDecorations.Strikethrough) <> 0 Then
               style = style Or FontStyle.Strikeout
            End If
            If (_annFont.TextDecoration And AnnTextDecorations.Underline) <> 0 Then
               style = style Or FontStyle.Underline
            End If

            Dim font As Font = New System.Drawing.Font(New FontFamily(_annFont.FontFamilyName), CSng(_annFont.FontSize), style, GraphicsUnit.Point)
            _lblSample.Font = font
            _lblSample.ForeColor = _fontColor
         End If
      End Sub

      Private Sub _chkUseBrush_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _chkUseBrush.CheckedChanged
         If _chkUseBrush.Checked Then
            _brushGroup.Enabled = True

            UpdateBrush()
         Else
            _brushGroup.Enabled = False
         End If
      End Sub

      Private Sub _btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnOK.Click
         _btnApply_Click(sender, e)
         Me.Close()
      End Sub

      Private Function GetColor(ByVal color As Color) As String
         If color.IsKnownColor Then
            Return color.Name
         Else
            If (color.Name.IndexOf("#") <> -1) Then
               Return color.Name
            Else
               Return "#" & color.Name
            End If
         End If
      End Function



      Private Sub _btnApply_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnApply.Click
         If _chkUsePen.Checked Then

            GetColor(_lblPenColor.BackColor)
            _annObj.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create(GetColor(_lblPenColor.BackColor)), LeadLengthD.Create(CDbl(_penWidth.Value))) ', AnnUnit.Pixel));
            If TypeOf _annObj Is AnnPolyRulerObject Then
               Dim polyRulerObject As AnnPolyRulerObject = CType(_annObj, AnnPolyRulerObject)

               polyRulerObject.TickMarksStroke = _annObj.Stroke
            End If
         Else
            _annObj.Stroke = Nothing
         End If

         If _chkUseBrush.Checked Then
            If TypeOf _annObj Is AnnHiliteObject Then
               CType(_annObj, AnnHiliteObject).HiliteColor = GetColor(_lblBrushColor.BackColor)
            Else
               _annObj.Fill = AnnSolidColorBrush.Create(GetColor(_lblBrushColor.BackColor))
            End If
         Else
            _annObj.Fill = Nothing
         End If

         If Not _annFont Is Nothing Then
            If (Not _annFont.Equals(_annObj.Font)) Then
               _annObj.Font = _annFont
            End If

            Dim textObject As AnnTextObject = CType(_annObj, AnnTextObject)

            textObject.TextForeground = AnnSolidColorBrush.Create(GetColor(_fontColor))
         End If

         _cell.RefreshAnnotation()
      End Sub

      Private Sub _btnChange_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _btnChange.Click
         Dim fontDialog1 As FontDialog = New FontDialog()
         fontDialog1.ShowColor = True

         fontDialog1.Font = New System.Drawing.Font(_annFont.FontFamilyName, CSng(_annFont.FontSize), FontStyle.Regular, GraphicsUnit.Point)
         fontDialog1.Color = _fontColor

         _lblSample.Font = fontDialog1.Font

         _lblSample.ForeColor = fontDialog1.Color

         If fontDialog1.ShowDialog() <> DialogResult.Cancel Then
            _annFont.FontFamilyName = fontDialog1.Font.FontFamily.Name
            _annFont.FontSize = fontDialog1.Font.Size

            If fontDialog1.Font.Bold Then
               _annFont.FontWeight = AnnFontWeight.Bold ' FontStyle.Bold;
            End If
            If fontDialog1.Font.Italic Then
               _annFont.FontStyle = AnnFontStyle.Oblique
            End If

            Dim textDecoration As AnnTextDecorations = 0

            If fontDialog1.Font.Strikeout Then
               textDecoration = textDecoration Or AnnTextDecorations.Strikethrough
            End If
            If fontDialog1.Font.Underline Then
               textDecoration = textDecoration Or AnnTextDecorations.Underline
            End If

            _annFont.TextDecoration = textDecoration

            _fontColor = fontDialog1.Color
         End If

         UpdateFont()
      End Sub

      Private Sub _lblPenColor_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles _lblPenColor.Paint
         e.Graphics.FillRectangle(New SolidBrush(_lblPenColor.BackColor), New Rectangle(0, 0, _lblPenColor.Width, _lblPenColor.Height))
      End Sub
   End Class
End Namespace
