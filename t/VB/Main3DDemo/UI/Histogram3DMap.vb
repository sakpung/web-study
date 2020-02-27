' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.IO
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Resources
Imports Leadtools
Imports Leadtools.Medical3D
Imports Leadtools.MedicalViewer
Imports Leadtools.ImageProcessing.Effects
Imports Leadtools.ImageProcessing.Color
Imports Leadtools.ImageProcessing

Imports Leadtools.Codecs
Imports System

Namespace Main3DDemo
   Partial Public Class Histogram3DDialog
      Inherits Form
#If (LEADTOOLS_V18_OR_LATER) Then
      Private _obj3DHist As Medical3DHistogram = Nothing
      Private _currentSelectedIndex As Integer
#End If

      Private lookupTable As Integer()

      Private channelHistogram As ChannelHistogram() = Nothing

      Private _histogramList As List(Of ChannelHistogram()) = Nothing

      Private _customIndex As Integer


      Private _cell As Medical3DControl
      Private _cellData As CellData
      Private _mainForm As MainForm
      Private _lookUpScale As Integer = 8192
      Private _from As Integer = 0
      Private _to As Integer = -1
      Private _zoomInCursor As Cursor
      Private _zoomOutCursor As Cursor
      Private _mouseDown As Boolean
      Private _currentPoint As HistogramPoint
      Private _beforePoint As HistogramPoint
      Private _afterPoint As HistogramPoint

      Private _moveDiffX As Integer
      Private _moveDiffY As Integer


      Private _onCurve As Boolean
      Private _custom As Boolean
      Private _currentSelectedPage As Integer = 0
      Private _object As Medical3DObject

      Private Sub SortHistogram()
         Dim currentHistogram As ChannelHistogram() = _histogramList(_cmbPalette.SelectedIndex)

         Dim points As List(Of HistogramPoint) = currentHistogram(_currentSelectedPage).Points

         points.Sort(Function(p1 As HistogramPoint, p2 As HistogramPoint)
                        If p1.X < p2.X Then
                           Return -1
                        ElseIf p1.X > p2.X Then
                           Return 1
                        Else
                           Return 0
                        End If
                     End Function
           )
      End Sub


      Private Sub MapTo1024(dstLookupTable As Integer(), originalLookupTable As Integer())
         Dim index As Integer = 0

         While index < 1024
            Dim mappedIndex As Integer = index * _lookUpScale \ 1024

            dstLookupTable(index) = originalLookupTable(mappedIndex)
            index += 1
         End While

      End Sub

      Private Sub UpdateChannel(currentSelectedPage As Integer)
         Dim currentHistogram As ChannelHistogram() = _histogramList(_currentSelectedIndex)

         Dim points As List(Of HistogramPoint) = currentHistogram(currentSelectedPage).Points

         If points Is Nothing Then
            currentHistogram(currentSelectedPage).Points = New List(Of HistogramPoint)()
            points = currentHistogram(currentSelectedPage).Points
         End If

         Dim userPointsCount As Integer = points.Count
         lookupTable = channelHistogram(currentSelectedPage).LookupTable

         Dim userPoints As LeadPoint() = New LeadPoint(2 + (points.Count - 1)) {}
         userPoints(0) = New LeadPoint(0, 0)

         For index As Integer = 0 To userPointsCount - 1
            userPoints(index + 1) = New LeadPoint(Math.Min(_lookUpScale - 1, Math.Max(1, points(index).X)), points(index).Y)
         Next

         userPoints(userPoints.Length - 1) = New LeadPoint(_lookUpScale, &HFFFF)

         Effects.EffectsUtilities.GetUserLookupTable(channelHistogram(currentSelectedPage).LookupTable, userPoints)

         'MapTo1024(channelHistogram[currentSelectedPage].LookupTable, lookupTable);

      End Sub


      Private Sub UpdateHistogram()
         UpdateChannel(_currentSelectedPage)

#If (LEADTOOLS_V19_OR_LATER) Then
         Dim Colorsvalue As New Medical3DColorMapping()


         Dim r As Integer() = New Integer(_lookUpScale - 1) {}
         Dim g As Integer() = New Integer(_lookUpScale - 1) {}
         Dim b As Integer() = New Integer(_lookUpScale - 1) {}
         Dim o As Integer() = New Integer(_lookUpScale - 1) {}

         Dim index As Integer = 0
         For index = 0 To _lookUpScale - 1
            r(index) = channelHistogram(0).LookupTable(index)
         Next


         For index = 0 To _lookUpScale - 1
            g(index) = channelHistogram(2).LookupTable(index)
         Next
         For index = 0 To _lookUpScale - 1
            b(index) = channelHistogram(1).LookupTable(index)
         Next
         For index = 0 To _lookUpScale - 1
            o(index) = channelHistogram(3).LookupTable(index)
         Next


         Colorsvalue.RedChannel = r
         Colorsvalue.GreenChannel = g
         Colorsvalue.BlueChannel = b
         Colorsvalue.OpacChannel = o
         _object.ColorMap = Colorsvalue


         _cellData.ColorMap = Colorsvalue


         _histogramMap.Invalidate()
         _histogramMap.Update()
#End If
      End Sub


      Private Function FindMaximumHistogramValue() As Integer
         If _obj3DHist Is Nothing Then
            Return 0
         End If

         Dim max As Integer = -1
#If (LEADTOOLS_V18_OR_LATER) Then
         For index As Integer = 1 To _obj3DHist.BinsNumber - 1
            If max < _obj3DHist.HistogramData(index) Then
               max = CInt(_obj3DHist.HistogramData(index))
            End If
         Next

#End If
         Return max \ 2

      End Function

      Private Sub initComboBox()
         Dim Values As Array = [Enum].GetValues(GetType(MedicalViewerPaletteType))
         For Each value As Object In Values
            _cmbPalette.Items.Add(value.ToString())
         Next

         _cmbPalette.Items.Add("Custom")
         _customIndex = _cmbPalette.Items.Count - 1
      End Sub

      Private Sub initHistogramList()
         _histogramList = New List(Of ChannelHistogram())()

         For i As Integer = 0 To _cmbPalette.Items.Count - 1
            _histogramList.Add(New ChannelHistogram(3) {New ChannelHistogram(), New ChannelHistogram(), New ChannelHistogram(), New ChannelHistogram()})
         Next

         If _cellData.ColorMapList IsNot Nothing Then
            For i As Integer = _cmbPalette.Items.Count To _cellData.ColorMapList.Count - 1
               _histogramList.Add(New ChannelHistogram(3) {New ChannelHistogram(), New ChannelHistogram(), New ChannelHistogram(), New ChannelHistogram()})
            Next
         End If
      End Sub

      Private Sub initializeData()
         If _cellData.ColorMapIndex = -1 Then
            Return
         End If

         Dim currentHistogram As ChannelHistogram()
         Dim colorMapHistogram As ChannelHistogram()
         Dim length As Integer = _cellData.ColorMapList.Count
         For i As Integer = 0 To _cellData.ColorMapList.Count - 1
            currentHistogram = _histogramList(i)
            colorMapHistogram = _cellData.ColorMapList(i)

            For index As Integer = 0 To 3
               currentHistogram(index).Points = colorMapHistogram(index).Points
            Next

            If i >= _cmbPalette.Items.Count Then
               _cmbPalette.Items.Add(colorMapHistogram(0).Name)
               currentHistogram(0).PaletteType = colorMapHistogram(0).PaletteType
            End If
         Next

      End Sub

      Private Sub updateData()
         If _obj3DHist Is Nothing Then
            Return
         End If

         channelHistogram = New ChannelHistogram(3) {}

         Dim pens__1 As Pen() = {Pens.Red, Pens.Green, Pens.Blue, Pens.Gray}

         For index As Integer = 0 To 3
            channelHistogram(index) = New ChannelHistogram()
            channelHistogram(index).HistogramMaxValue = FindMaximumHistogramValue()
            channelHistogram(index).HistogramPen = pens__1(index)

            channelHistogram(index).HistogramMin = _obj3DHist.Minimumval
            channelHistogram(index).HistogramMax = _obj3DHist.Minimumval + _obj3DHist.BinsNumber
            channelHistogram(index).LookupTable = New Integer(65535) {}
            UpdateChannel(index)
         Next

         _minValue.Text = "0"
         _maxValue.Text = (&H10000).ToString()
         ' channelHistogram[_currentSelectedPage].HistogramMaxValue.ToString();
         _minHistogram.Text = channelHistogram(_currentSelectedPage).HistogramMin.ToString()
         _maxHistogram.Text = channelHistogram(_currentSelectedPage).HistogramMax.ToString()
      End Sub

      Private Sub InitClass()
#If (LEADTOOLS_V19_OR_LATER) Then
         _obj3DHist = _object.Histogram
         If _obj3DHist Is Nothing Then
            Return
         End If

         _lookUpScale = _obj3DHist.BinsNumber

         _from = 0
         _to = _lookUpScale
         _zoomInCursor = New Cursor(New System.IO.MemoryStream(My.Resources.Zoom))
         _zoomOutCursor = New Cursor(New System.IO.MemoryStream(My.Resources.ZoomOut))


         initComboBox()

         initHistogramList()


         initializeData()

         _currentSelectedIndex = If((_cellData.ColorMapIndex = -1), _cmbPalette.Items.Count - 1, _cellData.ColorMapIndex)

         updateData()

         _cmbPalette.SelectedIndex = _currentSelectedIndex
         _radMove.Checked = True

         UpdateButton()

#End If

      End Sub

      Public Sub New(cell As Medical3DControl, myObject As Medical3DObject, mainForm As MainForm)
         _object = myObject
         _cell = cell
         _cellData = CType(cell.Tag, CellData)
         _mainForm = mainForm

         InitializeComponent()

         InitClass()

         UpdateHistogram()
      End Sub

      Private Function FindFirstMPRCell(viewer As MedicalViewer) As MedicalViewerMPRCell
         For Each control As Control In viewer.Cells
            If TypeOf control Is MedicalViewerMPRCell Then
               Return CType(control, MedicalViewerMPRCell)
            End If
         Next

         Return Nothing
      End Function

      Private Function FindFirstMultiCell(viewer As MedicalViewer) As MedicalViewerMultiCell
         For Each control As Control In viewer.Cells
            If TypeOf control Is MedicalViewerMultiCell Then
               Return CType(control, MedicalViewerMultiCell)
            End If
         Next

         Return Nothing
      End Function

      Private Sub _btnOK_Click(sender As Object, e As EventArgs) Handles _btnOK.Click

      End Sub

      Private Sub _btnReset_Click(sender As Object, e As EventArgs) Handles _btnReset.Click
         Dim removeCount As Integer = _histogramList.Count - (_customIndex + 1)
         _histogramList.RemoveRange(_customIndex + 1, removeCount)

         _cmbPalette.SelectedIndex = Math.Min(_cmbPalette.SelectedIndex, _customIndex)

         For index As Integer = 0 To removeCount - 1
            _cmbPalette.Items.RemoveAt(_customIndex + 1)
         Next

         Dim channelHistogram As ChannelHistogram()
         Dim histogramIndex As Integer = 0

         For histogramIndex = 0 To _histogramList.Count - 1
            channelHistogram = _histogramList(histogramIndex)

            For index As Integer = 0 To 3
               If channelHistogram(index).Points IsNot Nothing Then
                  channelHistogram(index).Points.Clear()
               End If
            Next
         Next

         channelHistogram = _histogramList(_cmbPalette.SelectedIndex)

         For index As Integer = 0 To 3
            UpdateChannel(index)
         Next

         UpdateButton()

         UpdateHistogram()
      End Sub

      Private Sub _btnApply_Click(sender As Object, e As EventArgs)
         _btnOK_Click(sender, e)
      End Sub

      Private Sub DrawHistogram(graphics As Graphics)

      End Sub


      Private Function GetLutPoints(lookupTable As Integer()) As Point()
         Dim index As Integer = 0
         Dim length As Integer = _histogramMap.Width
         Dim mappedIndex As Integer
         Dim height As Integer = _histogramMap.Height

         Dim realValue As Integer
         Dim lutPoints As Point() = New Point(length - 1) {}

         For index = 0 To length - 1
            mappedIndex = (index * (_to - _from) \ length) + _from
            realValue = Math.Max(3, Math.Min((height - 1) - (lookupTable(mappedIndex) * height \ &HFFFF), _histogramMap.Height - 3))

            lutPoints(index) = New Point(index + 1, realValue - 1)
         Next

         Return lutPoints
      End Function

      Private Sub _histogramMap_Paint(sender As Object, e As PaintEventArgs) Handles _histogramMap.Paint
#If (LEADTOOLS_V18_OR_LATER) Then

         If _obj3DHist Is Nothing Then
            Return
         End If

         Dim currentHistogram As ChannelHistogram() = _histogramList(_cmbPalette.SelectedIndex)

         If lookupTable Is Nothing Then
            Return
         End If

         Dim points As List(Of HistogramPoint) = currentHistogram(_currentSelectedPage).Points
         Dim histogramMaxValue As Integer = &H10000
         ' channelHistogram[_currentSelectedPage].HistogramMaxValue;
         Dim index As Integer = 0
         Dim length As Integer = _histogramMap.Width
         Dim mappedIndex As Integer
         Dim height As Integer = _histogramMap.Height

         Dim realValue As Integer
         Dim lutPoints As Point() = Nothing
         ' new Point[length];
         ' replace the commented
         ' you must first set the lookup table value.
         Dim histogram As Integer() = _obj3DHist.HistogramData
         Dim histogramWidth As Integer = Math.Min((_to - _from), _obj3DHist.BinsNumber)

         For index = 0 To _histogramMap.Width - 1
            mappedIndex = CInt(index * histogramWidth / _histogramMap.Width) + _from
            realValue = CInt(histogram(mappedIndex) * _histogramMap.Height \ (histogramMaxValue))
            e.Graphics.DrawLine(channelHistogram(_currentSelectedPage).HistogramPen, New Point(index + 1, _histogramMap.Height), New Point(index + 1, _histogramMap.Height - realValue))
         Next

         If _cmbPalette.SelectedIndex = 0 Then
            Return
         End If


         lutPoints = GetLutPoints(lookupTable)



         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

         e.Graphics.DrawLines(New Pen(Color.Black, 2), lutPoints)


         If points IsNot Nothing Then
            For index = 0 To points.Count - 1
               Dim X As Integer = (points(index).X - _from) * _histogramMap.Width \ (_to - _from)
               Dim Y As Integer = (&HFFFF - points(index).Y) * _histogramMap.Height \ &HFFFF

               Dim rect As New Rectangle(X - 1, Y - 1, 1, 1)
               rect.Inflate(New Size(4, 4))

               e.Graphics.FillEllipse(Brushes.White, rect)
               e.Graphics.DrawEllipse(New Pen(Color.Black, 2), rect)
            Next
         End If

#End If
      End Sub


      Private Sub UpdatePositionText(e As MouseEventArgs)
         Dim minimumHistogram As Integer = channelHistogram(_currentSelectedPage).HistogramMin

         _txtXPos.Text = (e.X * (_to - _from) / _histogramMap.Width + (_from + minimumHistogram)).ToString()
         _txtYPos.Text = (((_histogramMap.Height - 1) - (e.Y + 1)) * 65556 \ _histogramMap.Height).ToString()

      End Sub

      Private Sub _histogramMap_MouseMove(sender As Object, e As MouseEventArgs) Handles _histogramMap.MouseMove

         UpdatePositionText(e)
         If Not _mouseDown Then
            Return
         End If

         If _radMoveHist.Checked Then
            Dim min As Integer = 0
            Dim max As Integer = _obj3DHist.BinsNumber

            _from = Math.Min(max, Math.Max(min, _oldFrom - (e.X - _oldX)))
            _to = Math.Min(max, Math.Max(min, _from + _oldWidth))
            _from = _to - _oldWidth

            UpdateMinMaxHistogramText()


            _histogramMap.Invalidate()
            _histogramMap.Update()
            Return
         End If

         If (Not _onCurve) AndAlso (_currentPoint Is Nothing) Then
            Return
         End If


         Dim currentHistogram As ChannelHistogram() = _histogramList(_cmbPalette.SelectedIndex)
         Dim points As List(Of HistogramPoint) = currentHistogram(_currentSelectedPage).Points

         Dim minValue As Integer = 3
         If _previousIndex > -1 Then
            'points[_previousIndex].X + 3;
            minValue = (points(_previousIndex).X - _from) * _histogramMap.Width \ (_to - _from) + 3 - _moveDiffX
         End If

         Dim maxValue As Integer = _histogramMap.Width - 3
         If (_nextIndex < points.Count) AndAlso (_nextIndex > -1) Then
            'points[_nextIndex].X - 3;
            maxValue = (points(_nextIndex).X - _from) * _histogramMap.Width \ (_to - _from) - 3 - _moveDiffX
         End If


         'int X = (points[index].X - _from) * _histogramMap.Width / (_to - _from);

         '           int histogramWidth = Math.Min((_to - _from), _obj3DHist.BinsNumber);
         'mappedIndex = index * histogramWidth / _histogramMap.Width + _from;




         Dim x As Integer = Math.Max(minValue, Math.Min(e.X, maxValue))
         Dim y As Integer = Math.Max(3, Math.Min(e.Y, _histogramMap.Height - 3))

         If _onCurve Then
            If (_beforePoint Is Nothing) OrElse (_afterPoint Is Nothing) Then
               Return
            End If

            If x - _minimumBefore < 3 Then
               x -= (x - _minimumBefore - 3)
            End If


            If _beforePoint IsNot Nothing Then
               x = Math.Max(minValue + _minimumBefore, Math.Min(e.X, maxValue - _minimumBefore))
               _beforePoint.X = CInt(((x - _minimumBefore) * (_to - _from) / _histogramMap.Width)) + _from
            End If

            If _afterPoint IsNot Nothing Then
               x = Math.Max(minValue - _minimumAfter, Math.Min(e.X, maxValue + _minimumAfter))
               _afterPoint.X = CInt(((x - _minimumAfter) * (_to - _from) / _histogramMap.Width)) + _from
            End If
         ElseIf _currentPoint IsNot Nothing Then
            _currentPoint.X = CInt(((x + _moveDiffX) * (_to - _from) / _histogramMap.Width)) + _from
            _currentPoint.Y = CInt((_histogramMap.Height - (y + _moveDiffY)) * &HFFFF / _histogramMap.Height)
         End If

         SortHistogram()

         UpdateHistogram()
      End Sub

      Private Sub _histogramMap_MouseUp(sender As Object, e As MouseEventArgs) Handles _histogramMap.MouseUp
         _mouseDown = False
         _onCurve = False
      End Sub

      Private _minimumBefore As Integer
      Private _minimumAfter As Integer
      Private Function CloserPoint(x As Integer, pointX As Integer, point As HistogramPoint, before As Boolean) As HistogramPoint
         If before Then
            Dim distance As Integer = (x - pointX)
            If (distance > 0) AndAlso (distance < _minimumBefore) Then
               _minimumBefore = distance
               Return point
            End If

            Return _beforePoint
         Else
            Dim distance As Integer = (x - pointX)
            If (distance < 0) AndAlso (distance > _minimumAfter) Then
               _minimumAfter = distance
               Return point
            End If
            Return _afterPoint
         End If
      End Function

      Private _oldFrom As Integer
      Private _oldWidth As Integer
      Private _oldX As Integer
      Private _previousIndex As Integer
      Private _nextIndex As Integer

      Private Sub _histogramMap_MouseDown(sender As Object, e As MouseEventArgs) Handles _histogramMap.MouseDown
         _previousIndex = -2
         _nextIndex = -2

         If _radZoom.Checked Then
            If (Control.ModifierKeys And Keys.Control) <> 0 Then
               ZoomOut(e.X, e.Y)
            Else
               ZoomIn(e.X, e.Y)
            End If
            Return
         ElseIf _radMoveHist.Checked Then
            _oldFrom = _from
            _oldWidth = _to - _from
            _oldX = e.X
            _mouseDown = True
            Return
         End If

         If _cmbPalette.SelectedIndex = 0 Then
            Return
         End If

         Dim currentHistogram As ChannelHistogram() = _histogramList(_cmbPalette.SelectedIndex)

         If currentHistogram(_currentSelectedPage).Points Is Nothing Then
            currentHistogram(_currentSelectedPage).Points = New List(Of HistogramPoint)()
         End If

         Dim points As List(Of HistogramPoint) = currentHistogram(_currentSelectedPage).Points

         _mouseDown = True

         Dim point As New HistogramPoint(0, 0)
         Dim rect As New Rectangle()

         Dim left As Integer
         Dim top As Integer

         Dim x As Integer = Math.Max(3, Math.Min(e.X, _histogramMap.Width - 3))
         Dim y As Integer = Math.Max(3, Math.Min(e.Y, _histogramMap.Height - 3))

         point.X = CInt(x * (_to - _from) / _histogramMap.Width) + _from
         point.Y = CInt((_histogramMap.Height - y) * &HFFFF / _histogramMap.Height)


         _minimumAfter = -_histogramMap.Width
         _minimumBefore = _histogramMap.Width
         _beforePoint = Nothing
         _afterPoint = Nothing

         _currentPoint = Nothing
         For index As Integer = 0 To points.Count - 1
            left = (points(index).X - _from) * _histogramMap.Width \ (_to - _from)
            top = (&HFFFF - points(index).Y) * _histogramMap.Height \ &HFFFF

            rect = New Rectangle(left, top, 1, 1)
            rect.Inflate(New Size(7, 7))

            _beforePoint = CloserPoint(e.X, left, points(index), True)
            _afterPoint = CloserPoint(e.X, left, points(index), False)


            If rect.Contains(New Point(e.X, e.Y)) Then
               _currentPoint = points(index)
               _previousIndex = index - 1
               _nextIndex = index + 1

               _moveDiffX = left - e.X
               _moveDiffY = top - e.Y

               Exit For
            End If
         Next

         If e.Button = MouseButtons.Right Then
            If _beforePoint IsNot Nothing Then
               _previousIndex = points.IndexOf(_beforePoint) - 1
            End If
            If _afterPoint IsNot Nothing Then
               _nextIndex = points.IndexOf(_afterPoint) + 1
            End If
            If _currentPoint IsNot Nothing Then
               points.Remove(_currentPoint)
               _currentPoint = Nothing
               UpdateHistogram()
            Else
               Dim lutPoints As Point() = GetLutPoints(lookupTable)
               Dim distance As Integer
               _onCurve = False
               For index As Integer = 0 To lutPoints.Length - 1
                  distance = e.X - lutPoints(index).X
                  If (distance >= 3) OrElse (distance < 3) Then
                     _onCurve = True
                     Exit For
                  End If

                  'if (!_onCurve)
               Next
            End If
         Else
            If _currentPoint Is Nothing Then
               points.Add(point)

               _currentPoint = point

               SortHistogram()
               UpdateHistogram()

               Dim index As Integer = points.IndexOf(_currentPoint)
               _previousIndex = index - 1

               _nextIndex = index + 1
            End If
         End If
      End Sub

      Private Sub _cmbPalette_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbPalette.SelectedIndexChanged
         If _cmbPalette.SelectedIndex = 0 Then
            _histogramMap.Cursor = Cursors.Arrow
         Else
            _histogramMap.Cursor = Cursors.SizeAll
         End If

         _custom = (_cmbPalette.SelectedIndex >= _customIndex)

         _currentSelectedIndex = _cmbPalette.SelectedIndex

#If (LEADTOOLS_V18_OR_LATER) Then
         If Not _custom Then
            '_object.VRTColoringMode = _cmbPalette.SelectedIndex == 0 ? VRTColoringModeFlages.Gray : VRTColoringModeFlages.Predefined;

            If _cmbPalette.SelectedIndex <> 0 Then
               _object.Palette = MedicalViewerCell.GetPalette(CType(_cmbPalette.SelectedIndex, MedicalViewerPaletteType))
            Else
               _object.Palette = Nothing

            End If
         Else
            If _histogramList(_cmbPalette.SelectedIndex)(0).PaletteType <> MedicalViewerPaletteType.None Then
               _object.Palette = MedicalViewerCell.GetPalette(_histogramList(_cmbPalette.SelectedIndex)(0).PaletteType)
            Else
               _object.Palette = Nothing
            End If
         End If


         _cellData.Palette = _object.Palette


         For index As Integer = 0 To 3
            UpdateChannel(index)
         Next

         UpdateHistogram()


         _save.Enabled = (_cmbPalette.SelectedIndex <> 0) AndAlso (_cmbPalette.SelectedIndex <= _customIndex)

#End If

         _histogramMap.Invalidate()
      End Sub

      Private Sub _tabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _tabControl.SelectedIndexChanged
         _currentSelectedPage = _tabControl.SelectedIndex

         _minValue.Text = "0"
         _maxValue.Text = (&H10000).ToString()
         ' channelHistogram[_currentSelectedPage].HistogramMaxValue.ToString();
         UpdateHistogram()
      End Sub

      Private Sub Histogram3DDialog_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
         _zoomInCursor.Dispose()
         _zoomOutCursor.Dispose()


         'if (_cellData.ColorMapList == null)
         If True Then
            Dim currentHistogram As ChannelHistogram()

            _cellData.ColorMapList = New List(Of ChannelHistogram())()

            For i As Integer = 0 To _cmbPalette.Items.Count - 1
               currentHistogram = _histogramList(i)
               _cellData.ColorMapList.Add(New ChannelHistogram(3) {New ChannelHistogram(), New ChannelHistogram(), New ChannelHistogram(), New ChannelHistogram()})

               For index As Integer = 0 To 3
                  _cellData.ColorMapList(i)(index).Points = currentHistogram(index).Points
               Next

               _cellData.ColorMapList(i)(0).Name = _cmbPalette.Items(i).ToString()
               _cellData.ColorMapList(i)(0).PaletteType = currentHistogram(0).PaletteType
            Next
         End If


         'int index = 0;
         '            int length = channelHistogram.Length;
         '
         '            for ( index = 0; index < length; index++)
         '            {
         '                _cellData.ColorMapPoint[index] = channelHistogram[index].Points;
         '            }


         _cellData.ColorMapIndex = _cmbPalette.SelectedIndex
      End Sub

      Private Sub _radZoom_CheckedChanged(sender As Object, e As EventArgs) Handles _radZoom.CheckedChanged
         UpdateHistogramCursor()
      End Sub

      Private Sub UpdateHistogramCursor()
         If _radZoom.Checked Then
            If _zoomOut Then
               _histogramMap.Cursor = _zoomOutCursor
            Else
               _histogramMap.Cursor = _zoomInCursor
            End If
         End If
      End Sub

      Private _zoomOut As Boolean = False

      Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
         MyBase.OnKeyDown(e)
         _zoomOut = e.Control
         UpdateHistogramCursor()
      End Sub

      Protected Overrides Sub OnKeyUp(e As KeyEventArgs)
         MyBase.OnKeyUp(e)
         _zoomOut = e.Control
         UpdateHistogramCursor()
      End Sub


      Private Sub UpdateMinMaxHistogramText()
         Dim minimumHistogram As Integer = channelHistogram(_currentSelectedPage).HistogramMin

         _minHistogram.Text = (_from + minimumHistogram).ToString()
         _maxHistogram.Text = (_to + minimumHistogram).ToString()
      End Sub

      Private Sub ZoomIn(x As Integer, y As Integer)
         If (_to - _from) <= (_histogramMap.Width / 2) Then
            Return
         End If

         Dim currentWidth As Integer = (_to - _from)
         Dim ratio As Double = (_to - _from) * 0.9 / _lookUpScale

         Dim newWidth As Integer = CInt(Math.Truncate(_lookUpScale * ratio + 0.5))

         _from = _from + CInt(Math.Truncate((currentWidth - newWidth) * (x * 1.0 / _histogramMap.Width) + 0.5))
         _to = newWidth + _from

         UpdateMinMaxHistogramText()

         _histogramMap.Invalidate()
         _histogramMap.Update()
      End Sub

      Private Sub ZoomOut(x As Integer, y As Integer)
         Dim currentWidth As Integer = (_to - _from)
         Dim ratio As Double = (_to - _from) * 1.1 / _lookUpScale

         Dim newWidth As Integer = CInt(Math.Truncate(_lookUpScale * ratio + 0.5))

         _from = Math.Max(0, _from + CInt(Math.Truncate((currentWidth - newWidth) * (x * 1.0 / _histogramMap.Width) + 0.5)))
         _to = Math.Min(_lookUpScale, newWidth + _from)

         UpdateMinMaxHistogramText()

         _histogramMap.Invalidate()
         _histogramMap.Update()
      End Sub


      Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
         _from = 0
         _to = _lookUpScale


         _minHistogram.Text = channelHistogram(_currentSelectedPage).HistogramMin.ToString()
         _maxHistogram.Text = channelHistogram(_currentSelectedPage).HistogramMax.ToString()

         _histogramMap.Invalidate()
      End Sub

      Private Sub _radMove_CheckedChanged(sender As Object, e As EventArgs) Handles _radMove.CheckedChanged
         If _radMove.Checked Then
            _histogramMap.Cursor = Cursors.SizeAll
         End If
      End Sub

      Private Sub _save_Click(sender As Object, e As EventArgs) Handles _save.Click
         'if (_cmbPalette.SelectedIndex > (_customIndex))
         If True Then
            Dim dialog As New SaveItemialog(Me, _cmbPalette.Items.Count - (_customIndex + 1), _cmbPalette)
            dialog.ShowDialog()
            Dim selectedIndex As Integer = 0
            If ItemName <> "" Then
               'if (_cmbPalette.SelectedIndex <= _customIndex)
               '{
               '   selectedIndex = _cmbPalette.SelectedIndex;
               '}
               'else
               If True Then
                  _cmbPalette.Items.Add(ItemName)
                  selectedIndex = _cmbPalette.Items.Count - 1
                  _histogramList.Add(New ChannelHistogram(3) {New ChannelHistogram(), New ChannelHistogram(), New ChannelHistogram(), New ChannelHistogram()})
               End If

               Dim currentHistogram As ChannelHistogram() = _histogramList(_cmbPalette.SelectedIndex)

               Dim newHistogram As ChannelHistogram() = _histogramList(selectedIndex)
               Dim points As List(Of HistogramPoint)

               For index As Integer = 0 To 3
                  newHistogram(index).Points = New List(Of HistogramPoint)()
                  points = currentHistogram(index).Points
                  For pointCount As Integer = 0 To points.Count - 1
                     newHistogram(index).Points.Add(New HistogramPoint(points(pointCount).X, points(pointCount).Y))
                  Next
                  points.Clear()
               Next

               newHistogram(0).PaletteType = If((_cmbPalette.SelectedIndex < _customIndex), CType(_cmbPalette.SelectedIndex, MedicalViewerPaletteType), MedicalViewerPaletteType.None)



               _cmbPalette.SelectedIndex = selectedIndex
            End If

            UpdateButton()
         End If

      End Sub

      Private Sub UpdateButton()
         _btnExport.Enabled = (_cmbPalette.Items.Count <> _customIndex + 1)
      End Sub


      Private _itemName As String


      Public Property ItemName() As [String]

         Get
            Return _itemName
         End Get

         Set(value As [String])
            _itemName = value
         End Set
      End Property

      Private Sub _btnExport_Click(sender As Object, e As EventArgs) Handles _btnExport.Click
         Dim dialog As New SaveFileDialog()
         dialog.DefaultExt = "*.hcm"
         dialog.Filter = "Histogram Color Map (*.hcm)|*.hcm"

         If dialog.ShowDialog() = DialogResult.OK Then
            WriteToFile(dialog.FileName)
         End If
      End Sub

      Private Sub _btnImport_Click(sender As Object, e As EventArgs) Handles _btnImport.Click
         Dim dialog As New OpenFileDialog()

         dialog.DefaultExt = "*.hcm"
         dialog.Filter = "Histogram Color Map (*.hcm)|*.hcm"

         If dialog.ShowDialog() = DialogResult.OK Then
            ReadFromFile(dialog.FileName)
         End If

         UpdateButton()
      End Sub


      Private Sub WriteToFile(fileName As String)
         Dim file__1 As StreamWriter = File.CreateText(fileName)

         Dim length As Integer = _cmbPalette.Items.Count
         Dim pointCount As Integer
         Dim stringBuilder As StringBuilder

         For index As Integer = _customIndex + 1 To length - 1
            Dim histogram As ChannelHistogram() = _histogramList(index)

            file__1.WriteLine(_cmbPalette.Items(index).ToString())

            file__1.WriteLine(histogram(0).PaletteType.ToString())

            For channelIndex As Integer = 0 To 3
               stringBuilder = New StringBuilder()
               pointCount = histogram(channelIndex).Points.Count
               For pointIndex As Integer = 0 To pointCount - 1
                  stringBuilder.Append([String].Format("{0},{1}", histogram(channelIndex).Points(pointIndex).X, histogram(channelIndex).Points(pointIndex).Y))

                  If pointIndex <> pointCount - 1 Then
                     stringBuilder.Append(",")
                  End If
               Next

               file__1.WriteLine(stringBuilder)
            Next
         Next

         file__1.Close()
      End Sub

      Private Function GetPaletteType(value As String) As MedicalViewerPaletteType
         Dim output As MedicalViewerPaletteType = MedicalViewerPaletteType.None
         Select Case value
            Case "None"
               output = MedicalViewerPaletteType.None
               Exit Select
            Case "Cool"
               output = MedicalViewerPaletteType.Cool
               Exit Select
            Case "CyanHot"
               output = MedicalViewerPaletteType.CyanHot
               Exit Select
            Case "Fire"
               output = MedicalViewerPaletteType.Fire
               Exit Select
            Case "ICA2"
               output = MedicalViewerPaletteType.ICA2
               Exit Select
            Case "Ice"
               output = MedicalViewerPaletteType.Ice
               Exit Select
            Case "OrangeHot"
               output = MedicalViewerPaletteType.OrangeHot
               Exit Select
            Case "RainbowRGB"
               output = MedicalViewerPaletteType.RainbowRGB
               Exit Select
            Case "RedHot"
               output = MedicalViewerPaletteType.RedHot
               Exit Select
            Case "Spectrum"
               output = MedicalViewerPaletteType.Spectrum
               Exit Select
         End Select

         Return output
      End Function

      Private Sub ReadFromFile(fileName As String)
         Dim file__1 As StreamReader = File.OpenText(fileName)

         Dim length As Integer = _cmbPalette.Items.Count
         Dim line As String
         Dim values As String()
         Dim paletteType As MedicalViewerPaletteType


         _btnReset_Click(Me, EventArgs.Empty)

         While Not file__1.EndOfStream
            _cmbPalette.Items.Add(file__1.ReadLine())

            Dim histogram As ChannelHistogram() = New ChannelHistogram(3) {New ChannelHistogram(), New ChannelHistogram(), New ChannelHistogram(), New ChannelHistogram()}
            _histogramList.Add(histogram)

            paletteType = GetPaletteType(file__1.ReadLine())
            histogram(0).PaletteType = paletteType

            For channelIndex As Integer = 0 To 3
               line = file__1.ReadLine()
               values = line.Split(","c)

               If values.Length < 2 Then
                  Continue For
               End If

               histogram(channelIndex).Points = New List(Of HistogramPoint)()
               For stringValues As Integer = 0 To values.Length - 1 Step 2
                  histogram(channelIndex).Points.Add(New HistogramPoint(Convert.ToInt32(values(stringValues)), Convert.ToInt32(values(stringValues + 1))))
               Next
            Next
         End While

         Dim str As [String] = file__1.ReadLine()
         file__1.Close()

      End Sub

      Private Sub radioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles _radMoveHist.CheckedChanged
         If _radMoveHist.Checked Then
            _histogramMap.Cursor = Cursors.SizeWE
         End If
      End Sub

      Private Sub Histogram3DDialog_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
         _txtXPos.Text = ""
         _txtYPos.Text = ""
      End Sub

      Private Sub panel1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles panel1.MouseMove
         _txtXPos.Text = ""
         _txtYPos.Text = ""
      End Sub
   End Class

   Public Class HistogramPoint
      Public Sub New(x__1 As Integer, y__2 As Integer)
         X = x__1
         Y = y__2
      End Sub
      Public X As Integer
      Public Y As Integer
   End Class


   Public Class ColorMapItem
      Public Name As String
      Public PaletteType As MedicalViewerPaletteType
      Public HistogramMaxValue As Integer = 0
      Public HistogramMin As Integer = 0
      Public HistogramMax As Integer = 0
      Public Channels As ChannelHistogram()

      Public Sub New()
         Channels = New ChannelHistogram(3) {}
         For index As Integer = 0 To 3
            Channels(index) = New ChannelHistogram()
            Channels(index).Points = New List(Of HistogramPoint)()
         Next
      End Sub

   End Class

   Public Class ChannelHistogram
      Public Name As String
      Public PaletteType As MedicalViewerPaletteType
      Public Points As List(Of HistogramPoint) = Nothing
      Public HistogramMaxValue As Integer = 0
      Public HistogramPen As Pen = Nothing
      Public LookupTable As Integer() = Nothing
      Public HistogramMin As Integer = 0
      Public HistogramMax As Integer = 0

   End Class


End Namespace
