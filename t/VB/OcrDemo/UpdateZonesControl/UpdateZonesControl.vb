' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Drawing
Imports System

Namespace OcrDemo.UpdateZonesControl
   Partial Public Class UpdateZonesControl
      Inherits UserControl
      Private _ocrEngine As IOcrEngine
      Private _ocrPage As IOcrPage
      Private _lbZonesList As ListBox
      Private _zones As IOcrZoneCollection
      Private _oldValue As Integer = 0
      Private _viewerControl As OcrDemo.ViewerControl.ViewerControl

      Public Sub New(viewerControl As OcrDemo.ViewerControl.ViewerControl)
         InitializeComponent()
         _viewerControl = viewerControl
      End Sub

      ''' <summary>
      ''' Any action that happens in this control that must be handled by the owner
      ''' For example, selection change of the combo boxes.
      ''' </summary>
      Public Event Action As EventHandler(Of ActionEventArgs)

      Public Sub Activate(ocrEngine As IOcrEngine, ocrPage As IOcrPage, tvZonesList As ListBox, zones As IOcrZoneCollection)
         _ocrEngine = ocrEngine
         _ocrPage = ocrPage
         _lbZonesList = tvZonesList
         _zones = zones

         ' Initialize the combo boxes
         Dim zoneTypes As OcrZoneType() = ocrEngine.ZoneManager.GetSupportedZoneTypes()
         For Each zoneType As OcrZoneType In zoneTypes
            _typeComboBox.Items.Add(zoneType)
         Next

         ' Get the languages supported by this engine and fill the list box
         Dim languages As String() = ocrEngine.LanguageManager.GetSupportedLanguages()
         Dim additionalLanguages As String() = ocrEngine.LanguageManager.GetAdditionalLanguages()
         Dim languagesDictionary As New Dictionary(Of String, String)()
         Dim friendlyNames As String() = New String(languages.Length + (additionalLanguages.Length - 1)) {}
         Dim i As Integer = 0
         For Each language As String In languages
            friendlyNames(i) = MyLanguage.GetLanguageFriendlyName(language)
            languagesDictionary.Add(friendlyNames(i), language)
            i += 1
         Next
         For Each language As String In additionalLanguages
            friendlyNames(i) = MyLanguage.GetLanguageFriendlyName(language)
            languagesDictionary.Add(friendlyNames(i), language)
            i += 1
         Next

         Array.Sort(friendlyNames, 1, friendlyNames.Length - 1)

         Dim ml As New MyLanguage(String.Empty, "None", -1)
         _languageComboBox.Items.Add(ml)
         For Each friendlyName As String In friendlyNames
            ml = New MyLanguage(languagesDictionary(friendlyName), friendlyName, -1)
            _languageComboBox.Items.Add(ml)
         Next

         Dim zoneViewPerspectiveValues As New List(Of ViewPerspectiveItem)()
         zoneViewPerspectiveValues.AddRange(New ViewPerspectiveItem() {New ViewPerspectiveItem(RasterViewPerspective.TopLeft, "TopLeft"), New ViewPerspectiveItem(RasterViewPerspective.TopLeft90, "TopLeft90"), New ViewPerspectiveItem(RasterViewPerspective.TopLeft180, "TopLeft180"), New ViewPerspectiveItem(RasterViewPerspective.TopLeft270, "TopLeft270")})
         _zoneViewPerspectiveComboBox.Items.AddRange(zoneViewPerspectiveValues.ToArray())

         Dim zoneTextDirectionValues As New List(Of TextDirectionItem)()
         zoneTextDirectionValues.AddRange(New TextDirectionItem() {New TextDirectionItem(OcrTextDirection.LeftToRight, "LeftToRight"), New TextDirectionItem(OcrTextDirection.TopToBottom, "TopToBottom")})
         _zoneTextDirectionComboBox.Items.AddRange(zoneTextDirectionValues.ToArray())

         ' These events cannot be hooked into from the designer,
         ' so we will do them in here
         AddHandler _leftTextBox.GotFocus, AddressOf _areaTextBox_GotFocus
         AddHandler _topTextBox.GotFocus, AddressOf _areaTextBox_GotFocus
         AddHandler _widthTextBox.GotFocus, AddressOf _areaTextBox_GotFocus
         AddHandler _heightTextBox.GotFocus, AddressOf _areaTextBox_GotFocus

         AddHandler _leftTextBox.LostFocus, AddressOf _areaTextBox_LostFocus
         AddHandler _topTextBox.LostFocus, AddressOf _areaTextBox_LostFocus
         AddHandler _widthTextBox.LostFocus, AddressOf _areaTextBox_LostFocus
         AddHandler _heightTextBox.LostFocus, AddressOf _areaTextBox_LostFocus

         AddHandler _nameTextBox.LostFocus, AddressOf _textTextBox_LostFocus

         UpdateUIState()
      End Sub

      Private Sub _textTextBox_LostFocus(sender As Object, e As EventArgs)
         If _lbZonesList.SelectedItems.Count = 0 OrElse _lbZonesList.SelectedItems.Count > 1 Then
            Return
         End If

         ' Get the new zone name or section name
         Dim zone As OcrZone = CurrentZone

         Dim str As String = TryCast(sender, TextBox).Text

         If sender Is _nameTextBox Then
            zone.Name = str
         End If

         CurrentZone = zone
      End Sub

      Private Sub _areaTextBox_GotFocus(sender As Object, e As EventArgs)
         Dim tb As TextBox = TryCast(sender, TextBox)
         Integer.TryParse(tb.Text, _oldValue)
      End Sub

      Private Sub _areaTextBox_LostFocus(sender As Object, e As EventArgs)
         If _lbZonesList.SelectedItems.Count = 0 OrElse _lbZonesList.SelectedItems.Count > 1 Then
            Return
         End If

         ' Make sure it is an integer and in valid range
         Dim zone As OcrZone = CurrentZone
         Dim bounds As LeadRect = zone.Bounds

         Dim tb As TextBox = TryCast(sender, TextBox)
         Dim val As Integer
         If Not Integer.TryParse(tb.Text, val) OrElse val < 0 Then
            ResetBoundsValue(tb, bounds)
            Return
         End If

         Dim newBounds As LeadRect = bounds

         ' Calculate the new bounds
         If tb Is _leftTextBox Then
            newBounds.X = val
         ElseIf tb Is _topTextBox Then
            newBounds.Y = val
         ElseIf tb Is _widthTextBox Then
            If val = 0 Then
               ResetBoundsValue(tb, bounds)
               Return
            End If
            newBounds.Width = val
         ElseIf tb Is _heightTextBox Then
            If val = 0 Then
               ResetBoundsValue(tb, bounds)
               Return
            End If
            newBounds.Height = val
         End If

         ' Make sure the new bounds does not go outside the page
         Dim pageBounds As New LeadRect(0, 0, _ocrPage.Width, _ocrPage.Height)

         If Not pageBounds.Contains(newBounds) Then
            ResetBoundsValue(tb, bounds)
            Return
         End If

         ' Valid value, update the bounds
         zone.Bounds = newBounds
         CurrentZone = zone
      End Sub

      Private Sub ResetBoundsValue(tb As TextBox, bounds As LeadRect)
         ' An error occurred while entering the bounds value
         ' Reset to original value
         If tb Is _leftTextBox Then
            tb.Text = bounds.X.ToString()
         ElseIf tb Is _topTextBox Then
            tb.Text = bounds.Y.ToString()
         ElseIf tb Is _widthTextBox Then
            tb.Text = bounds.Width.ToString()
         ElseIf tb Is _heightTextBox Then
            tb.Text = bounds.Height.ToString()
         End If
      End Sub

      Private Property CurrentZone() As OcrZone
         Get
            Return _zones(_lbZonesList.SelectedIndex)
         End Get
         Set(value As OcrZone)
            _zones(_lbZonesList.SelectedIndex) = value
         End Set
      End Property

      Public Sub UpdateUIState()
         Dim enabled As Boolean = _lbZonesList.SelectedIndex <> -1
         Dim enableOmr As Boolean = (_typeComboBox.SelectedItem IsNot Nothing AndAlso (CType(_typeComboBox.SelectedItem, OcrZoneType) = OcrZoneType.Omr))
         Dim enableCharacterFilters As Boolean = enabled AndAlso (_typeComboBox.SelectedItem IsNot Nothing AndAlso (CType(_typeComboBox.SelectedItem, OcrZoneType) <> OcrZoneType.Graphic)) AndAlso (_typeComboBox.SelectedItem IsNot Nothing AndAlso (CType(_typeComboBox.SelectedItem, OcrZoneType) <> OcrZoneType.Omr) AndAlso (CType(_typeComboBox.SelectedItem, OcrZoneType) <> OcrZoneType.Micr))

         _typeLabel.Enabled = enabled
         _typeComboBox.Enabled = _typeComboBox.Items.Count > 1 AndAlso enabled
         _languageComboBox.Enabled = _ocrEngine.EngineType = OcrEngineType.LEAD AndAlso _languageComboBox.Items.Count > 1 AndAlso enabled AndAlso (_typeComboBox.SelectedItem IsNot Nothing AndAlso (CType(_typeComboBox.SelectedItem, OcrZoneType) = OcrZoneType.Text OrElse CType(_typeComboBox.SelectedItem, OcrZoneType) = OcrZoneType.Table))
         _languageLabel.Enabled = _languageComboBox.Enabled
         _omrLabel.Enabled = enabled AndAlso enableOmr
         _omrStatusLabel.Enabled = enabled AndAlso enableOmr

         _propertiesGroupBox.Enabled = enabled
         _nameGroupBox.Enabled = enabled
         _areaGroupBox.Enabled = enabled
         _characterFiltersGroupBox.Enabled = enableCharacterFilters
      End Sub

      Public Sub ZoneToControls(index As Integer)
         ' Fill the controls from the current zone
         If index <> -1 Then
            Dim zone As OcrZone = _zones(index)
            _nameTextBox.Text = zone.Name

            ' Convert the bounds to pixels
            Dim bounds As LeadRect = zone.Bounds
            _leftTextBox.Text = bounds.X.ToString()
            _topTextBox.Text = bounds.Y.ToString()
            _widthTextBox.Text = bounds.Width.ToString()
            _heightTextBox.Text = bounds.Height.ToString()

            ' Disable these events when changing the combo boxes selected items once the "UpdateZonesControl" gets activated
            RemoveHandler Me._typeComboBox.SelectedIndexChanged, AddressOf Me._propertiesComboBox_SelectedIndexChanged
            RemoveHandler Me._languageComboBox.SelectedIndexChanged, AddressOf Me._propertiesComboBox_SelectedIndexChanged
            RemoveHandler Me._zoneViewPerspectiveComboBox.SelectedIndexChanged, AddressOf Me._propertiesComboBox_SelectedIndexChanged
            RemoveHandler Me._zoneTextDirectionComboBox.SelectedIndexChanged, AddressOf Me._propertiesComboBox_SelectedIndexChanged

            _typeComboBox.SelectedItem = zone.ZoneType

            For i As Integer = 0 To _languageComboBox.Items.Count - 1
               Dim ml As MyLanguage = CType(_languageComboBox.Items(i), MyLanguage)
               If zone.Language Is Nothing OrElse zone.Language = String.Empty Then
                  If ml.Language = String.Empty Then
                     _languageComboBox.SelectedItem = ml
                     Exit For
                  End If
               Else
                  If ml.Language = zone.Language Then
                     _languageComboBox.SelectedItem = ml
                     Exit For
                  End If
               End If
            Next

            _zoneViewPerspectiveComboBox.SelectedIndex = 0
            For Each item As ViewPerspectiveItem In _zoneViewPerspectiveComboBox.Items
               If item.ViewPerspective = zone.ViewPerspective Then
                  _zoneViewPerspectiveComboBox.SelectedItem = item
                  Exit For
               End If
            Next

            _zoneTextDirectionComboBox.SelectedIndex = 0
            For Each item As TextDirectionItem In _zoneTextDirectionComboBox.Items
               If item.TextDirection = zone.TextDirection Then
                  _zoneTextDirectionComboBox.SelectedItem = item
                  Exit For
               End If
            Next

            AddHandler Me._typeComboBox.SelectedIndexChanged, AddressOf Me._propertiesComboBox_SelectedIndexChanged
            AddHandler Me._languageComboBox.SelectedIndexChanged, AddressOf Me._propertiesComboBox_SelectedIndexChanged
            AddHandler Me._zoneViewPerspectiveComboBox.SelectedIndexChanged, AddressOf Me._propertiesComboBox_SelectedIndexChanged
            AddHandler Me._zoneTextDirectionComboBox.SelectedIndexChanged, AddressOf Me._propertiesComboBox_SelectedIndexChanged

            If zone.ZoneType = OcrZoneType.Omr Then
               Dim sb As New StringBuilder()

               If Not _ocrPage.IsRecognized Then
                  sb.Append("Unfilled (0% certain)")
               Else
                  Dim pageCharacters As IOcrPageCharacters = _ocrPage.GetRecognizedCharacters()
                  If pageCharacters Is Nothing Or pageCharacters.Count = 0 Or zone.Id >= pageCharacters.Count Then
                     sb.Append("Unfilled (0% certain)")
                  Else
                     Dim zoneCharacters As IOcrZoneCharacters = pageCharacters(zone.Id)
                     If zoneCharacters.Count > 0 Then
                        Dim omrCharacter As OcrCharacter = zoneCharacters(0)
                        Dim filledChar As Char = _ocrEngine.ZoneManager.OmrOptions.GetStateRecognitionCharacter(OcrOmrZoneState.Filled)
                        Dim unfilledChar As Char = _ocrEngine.ZoneManager.OmrOptions.GetStateRecognitionCharacter(OcrOmrZoneState.Unfilled)
                        If omrCharacter.Code = filledChar Then
                           sb.Append("Filled")
                        Else
                           sb.Append("Unfilled")
                        End If

                        sb.AppendFormat(" ({0}% certain)", omrCharacter.Confidence)
                     Else
                        sb.AppendFormat("Unfilled (0% certain)")
                     End If
                  End If
               End If

               _omrStatusLabel.Text = sb.ToString()
            Else
               _omrStatusLabel.Text = String.Empty
            End If

            If (zone.CharacterFilters And OcrZoneCharacterFilters.Digit) = OcrZoneCharacterFilters.Digit Then
               _digitCheckBox.Checked = True
            Else
               _digitCheckBox.Checked = False
            End If

            If (zone.CharacterFilters And OcrZoneCharacterFilters.Plus) = OcrZoneCharacterFilters.Plus Then
               _plusCheckBox.Checked = True
            Else
               _plusCheckBox.Checked = False
            End If
         Else
            _nameTextBox.Text = String.Empty

            _leftTextBox.Text = String.Empty
            _topTextBox.Text = String.Empty
            _widthTextBox.Text = String.Empty
            _heightTextBox.Text = String.Empty

            _typeComboBox.SelectedIndex = 0
            _languageComboBox.SelectedIndex = 0
            _zoneViewPerspectiveComboBox.SelectedIndex = 0
            _zoneTextDirectionComboBox.SelectedIndex = 0
            _omrStatusLabel.Text = String.Empty

            _digitCheckBox.Checked = False
            _plusCheckBox.Checked = False
         End If
      End Sub

      Private Sub _propertiesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _typeComboBox.SelectedIndexChanged, _languageComboBox.SelectedIndexChanged
         If _lbZonesList.SelectedItems.Count = 0 OrElse _lbZonesList.SelectedItems.Count > 1 Then
            Return
         End If

         Dim zone As OcrZone = CurrentZone

         If sender Is _typeComboBox Then
            zone.ZoneType = CType(_typeComboBox.SelectedItem, OcrZoneType)
         ElseIf sender Is _languageComboBox Then
            zone.Language = CType(_languageComboBox.SelectedItem, MyLanguage).Language
         ElseIf sender Is _zoneViewPerspectiveComboBox Then
            zone.ViewPerspective = CType(_zoneViewPerspectiveComboBox.SelectedItem, ViewPerspectiveItem).ViewPerspective
         ElseIf sender Is _zoneTextDirectionComboBox Then
            zone.TextDirection = CType(_zoneTextDirectionComboBox.SelectedItem, TextDirectionItem).TextDirection
         End If

         CurrentZone = zone

         ' Immediately update the zone if the user changed the zone type to "Table".
         If _ocrPage.Zones IsNot Nothing AndAlso _ocrPage.Zones.Count > CInt(_lbZonesList.SelectedIndex) Then
            _ocrPage.Zones(CInt(_lbZonesList.SelectedIndex)) = zone
         End If

         ZoneToControls(If((_lbZonesList.SelectedItem IsNot Nothing), CInt(_lbZonesList.SelectedIndex), -1))
         UpdateUIState()

         DoAction("ZonePropertiesChanged", Nothing)
      End Sub

      Private Sub _characterFiltersCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles _plusCheckBox.CheckedChanged, _digitCheckBox.CheckedChanged
         Dim filters As OcrZoneCharacterFilters = OcrZoneCharacterFilters.None

         If _digitCheckBox.Checked Then
            filters = filters Or OcrZoneCharacterFilters.Digit
         End If

         If _plusCheckBox.Checked Then
            filters = filters Or OcrZoneCharacterFilters.Plus
         End If

         Dim zone As OcrZone = CurrentZone
         zone.CharacterFilters = filters
         CurrentZone = zone
      End Sub

      Private Sub DoAction(action As String, data As Object)
         ' Raise the action event so the parent form can handle it

         RaiseEvent Action(Me, New ActionEventArgs(action, data))
      End Sub
   End Class

   Class ViewPerspectiveItem
      Public ViewPerspective As RasterViewPerspective
      Public FriendlyName As String

      Public Sub New(viewPerspective__1 As RasterViewPerspective, friendlyName__2 As String)
         ViewPerspective = viewPerspective__1
         FriendlyName = friendlyName__2
      End Sub

      Public Overrides Function ToString() As String
         Return FriendlyName
      End Function
   End Class

   Class TextDirectionItem
      Public TextDirection As OcrTextDirection
      Public FriendlyName As String

      Public Sub New(textDirection__1 As OcrTextDirection, friendlyName__2 As String)
         TextDirection = textDirection__1
         FriendlyName = friendlyName__2
      End Sub

      Public Overrides Function ToString() As String
         Return FriendlyName
      End Function
   End Class

   Class ZoneItem
      Public ZoneName As String
      Private Index As Integer

      Public Sub New(name As String, index__1 As Integer)
         ZoneName = name
         Index = index__1
      End Sub

      Public Overrides Function ToString() As String
         Return (ZoneName & Convert.ToString(" ")) + (Index + 1).ToString()
      End Function
   End Class
End Namespace
