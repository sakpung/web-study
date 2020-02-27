' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Drawing

Partial Public Class UpdateZonesControl : Inherits UserControl
   Private _ocrEngine As IOcrEngine
   Private _ocrPage As IOcrPage
   Private _tvZonesList As TreeView
   Private _zones As IOcrZoneCollection
   Private _oldValue As Integer = 0
   Private _viewerControl As ViewerControl

   Public Sub New(ByVal viewerControl As ViewerControl)
      InitializeComponent()
      _viewerControl = viewerControl
   End Sub

   ''' <summary>
   ''' Any action that happens in this control that must be handled by the owner
   ''' For example, selection change of the combo boxes.
   ''' </summary>
   Public Event Action(ByVal sender As Object, ByVal e As ActionEventArgs)

   Public Sub Activate(ByVal ocrEngine As IOcrEngine, ByVal ocrPage As IOcrPage, ByVal tvZonesList As TreeView, ByVal zones As IOcrZoneCollection)
      _ocrEngine = ocrEngine
      _ocrPage = ocrPage
      _tvZonesList = tvZonesList
      _zones = zones

      ' Initialize the combo boxes
      Dim zoneTypes As OcrZoneType() = ocrEngine.ZoneManager.GetSupportedZoneTypes()
      For Each zoneType As OcrZoneType In zoneTypes
         _typeComboBox.Items.Add(zoneType)
      Next zoneType

      ' Get the languages supported by this engine and fill the list box
      Dim languages As String() = ocrEngine.LanguageManager.GetSupportedLanguages()
      Dim additionalLanguages As String() = ocrEngine.LanguageManager.GetAdditionalLanguages()
      Dim languagesDictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)()
      Dim friendlyNames As String() = New String(languages.Length + additionalLanguages.Length - 1) {}
      Dim i As Integer = 0
      For Each language As String In languages
         friendlyNames(i) = MyLanguage.GetLanguageFriendlyName(language)
         languagesDictionary.Add(friendlyNames(i), language)
         i += 1
      Next language
      For Each language As String In additionalLanguages
         friendlyNames(i) = MyLanguage.GetLanguageFriendlyName(language)
         languagesDictionary.Add(friendlyNames(i), language)
         i += 1
      Next language

      Array.Sort(friendlyNames, 1, friendlyNames.Length - 1)

      Dim ml As MyLanguage = New MyLanguage(String.Empty, "None", -1)
      _languageComboBox.Items.Add(ml)
      For Each friendlyName As String In friendlyNames
         ml = New MyLanguage(languagesDictionary(friendlyName), friendlyName, -1)
         _languageComboBox.Items.Add(ml)
      Next friendlyName

      Dim zoneViewPerspectiveValues As New List(Of ViewPerspectiveItem)()
      If _ocrEngine.EngineType = OcrEngineType.OmniPageArabic Then
         zoneViewPerspectiveValues.AddRange(New ViewPerspectiveItem() {New ViewPerspectiveItem(RasterViewPerspective.TopLeft, "Top Left")})
      ElseIf _ocrEngine.EngineType = OcrEngineType.OmniPage Then
         zoneViewPerspectiveValues.AddRange(New ViewPerspectiveItem() {New ViewPerspectiveItem(RasterViewPerspective.TopLeft, "TopLeft"), New ViewPerspectiveItem(RasterViewPerspective.TopLeft90, "TopLeft90"), New ViewPerspectiveItem(RasterViewPerspective.TopLeft270, "TopLeft270")})
      Else
         ' Advantage
         zoneViewPerspectiveValues.AddRange(New ViewPerspectiveItem() {New ViewPerspectiveItem(RasterViewPerspective.TopLeft, "TopLeft"), New ViewPerspectiveItem(RasterViewPerspective.TopLeft90, "TopLeft90"), New ViewPerspectiveItem(RasterViewPerspective.TopLeft180, "TopLeft180"), New ViewPerspectiveItem(RasterViewPerspective.TopLeft270, "TopLeft270")})
      End If
      _zoneViewPerspectiveComboBox.Items.AddRange(zoneViewPerspectiveValues.ToArray())

      Dim zoneTextDirectionValues As New List(Of TextDirectionItem)()
      If _ocrEngine.EngineType = OcrEngineType.OmniPageArabic Then
         zoneTextDirectionValues.AddRange(New TextDirectionItem() {New TextDirectionItem(OcrTextDirection.RightToLeft, "RightToLeft")})
      Else
         zoneTextDirectionValues.AddRange(New TextDirectionItem() {New TextDirectionItem(OcrTextDirection.LeftToRight, "LeftToRight"), New TextDirectionItem(OcrTextDirection.TopToBottom, "TopToBottom")})
      End If
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

   Private Sub _textTextBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      If _tvZonesList.SelectedNode Is Nothing Then
         Return
      End If

      ' Get the new zone name or section name
      Dim zone As OcrZone = CurrentZone

      Dim str As String = (TryCast(sender, TextBox)).Text

      If sender Is _nameTextBox Then
         zone.Name = str
      End If

      CurrentZone = zone
   End Sub

   Private Sub _areaTextBox_GotFocus(ByVal sender As Object, ByVal e As EventArgs)
      Dim tb As TextBox = TryCast(sender, TextBox)
      Integer.TryParse(tb.Text, _oldValue)
   End Sub

   Private Sub _areaTextBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      If _tvZonesList.SelectedNode Is Nothing Then
         Return
      End If

      ' Make sure it is an integer and in valid range
      Dim zone As OcrZone = CurrentZone
      Dim bounds As LeadRect = zone.Bounds

      Dim tb As TextBox = TryCast(sender, TextBox)
      Dim val As Integer
      If (Not Integer.TryParse(tb.Text, val)) OrElse val < 0 Then
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
      Dim pageBounds As LeadRect = New LeadRect(0, 0, _ocrPage.Width, _ocrPage.Height)

      If (Not pageBounds.Contains(newBounds)) Then
         ResetBoundsValue(tb, bounds)
         Return
      End If

      ' Valid value, update the bounds
      zone.Bounds = newBounds
      CurrentZone = zone
      Dim cells As OcrZoneCell() = Nothing
      cells = _zones.GetZoneCells(_zones(CInt(_tvZonesList.SelectedNode.Tag)))
      If _zones(CInt(_tvZonesList.SelectedNode.Tag)).ZoneType = OcrZoneType.Table AndAlso Not cells Is Nothing AndAlso _oldValue <> val Then
         _tvZonesList.SelectedNode.Nodes.Clear()
         _viewerControl.ClearZoneCells(CInt(_tvZonesList.SelectedNode.Tag))
      End If
   End Sub

   Private Sub ResetBoundsValue(ByVal tb As TextBox, ByVal bounds As LeadRect)
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
         Return _zones(CInt(_tvZonesList.SelectedNode.Tag))
      End Get
      Set(ByVal value As OcrZone)
         _zones(CInt(_tvZonesList.SelectedNode.Tag)) = value
      End Set
   End Property

   Public Sub UpdateUIState()
      Dim enabled As Boolean = Not _tvZonesList.SelectedNode Is Nothing

      Dim enableOmr As Boolean = (_typeComboBox.SelectedItem IsNot Nothing AndAlso (CType(_typeComboBox.SelectedItem, OcrZoneType) = OcrZoneType.Omr))
      Dim enableCharacterFilters As Boolean = enabled AndAlso (_typeComboBox.SelectedItem IsNot Nothing AndAlso CType(_typeComboBox.SelectedItem, OcrZoneType) <> OcrZoneType.Graphic AndAlso CType(_typeComboBox.SelectedItem, OcrZoneType) <> OcrZoneType.Micr AndAlso CType(_typeComboBox.SelectedItem, OcrZoneType) <> OcrZoneType.Omr)

      _typeLabel.Enabled = enabled
      _typeComboBox.Enabled = _typeComboBox.Items.Count > 1 AndAlso enabled
      _languageComboBox.Enabled = _ocrEngine.EngineType = OcrEngineType.LEAD AndAlso _languageComboBox.Items.Count > 1 AndAlso enabled AndAlso (Not _typeComboBox.SelectedItem Is Nothing AndAlso (CType(_typeComboBox.SelectedItem, OcrZoneType) = OcrZoneType.Text Or CType(_typeComboBox.SelectedItem, OcrZoneType) = OcrZoneType.Table))
      _languageLabel.Enabled = _languageComboBox.Enabled

      _omrLabel.Enabled = enabled AndAlso enableOmr
      _omrStatusLabel.Enabled = enabled AndAlso enableOmr

      _propertiesGroupBox.Enabled = enabled
      _nameGroupBox.Enabled = enabled
      _areaGroupBox.Enabled = enabled
      _characterFiltersGroupBox.Enabled = enableCharacterFilters

      ' Disable all of the "Character Filters"
      ' controls if the Advantage engine is selected since they are not supported for this engine.
      If _ocrEngine.EngineType = OcrEngineType.OmniPageArabic Then
         _characterFiltersGroupBox.Enabled = False
         _zoneViewPerspectiveLabel.Enabled = False
         _zoneViewPerspectiveComboBox.Enabled = False

         _zoneTextDirectionLabel.Enabled = False
         _zoneTextDirectionComboBox.Enabled = False
      End If
   End Sub

   Public Sub ZoneToControls(ByVal index As Integer)
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
         ' cause it will clear the table zone cells (if there is any)
         RemoveHandler _typeComboBox.SelectedIndexChanged, AddressOf _propertiesComboBox_SelectedIndexChanged
         RemoveHandler _languageComboBox.SelectedIndexChanged, AddressOf _propertiesComboBox_SelectedIndexChanged
         RemoveHandler _zoneViewPerspectiveComboBox.SelectedIndexChanged, AddressOf _propertiesComboBox_SelectedIndexChanged
         RemoveHandler _zoneTextDirectionComboBox.SelectedIndexChanged, AddressOf _propertiesComboBox_SelectedIndexChanged

         _typeComboBox.SelectedItem = zone.ZoneType

         Dim i As Integer = 0
         Do While i < _languageComboBox.Items.Count
            Dim ml As MyLanguage = CType(_languageComboBox.Items(i), MyLanguage)
            If zone.Language Is Nothing OrElse zone.Language = String.Empty Then
               If ml.Language = String.Empty Then
                  _languageComboBox.SelectedItem = ml
                  Exit Do
               End If
            Else
               If ml.Language = zone.Language Then
                  _languageComboBox.SelectedItem = ml
                  Exit Do
               End If
            End If
            i += 1
         Loop

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

         AddHandler _typeComboBox.SelectedIndexChanged, AddressOf _propertiesComboBox_SelectedIndexChanged
         AddHandler _languageComboBox.SelectedIndexChanged, AddressOf _propertiesComboBox_SelectedIndexChanged
         AddHandler _zoneViewPerspectiveComboBox.SelectedIndexChanged, AddressOf _propertiesComboBox_SelectedIndexChanged
         AddHandler _zoneTextDirectionComboBox.SelectedIndexChanged, AddressOf _propertiesComboBox_SelectedIndexChanged

         If zone.ZoneType = OcrZoneType.Omr Then
            Dim sb As New StringBuilder()

            If Not _ocrPage.IsRecognized Then
               sb.Append("Unfilled (0% certain)")
            Else
               Dim pageCharacters As IOcrPageCharacters = _ocrPage.GetRecognizedCharacters()
               If pageCharacters Is Nothing Then
                  sb.Append("Unfilled (0% certain)")
               Else
                  Dim zoneCharacters As IOcrZoneCharacters = pageCharacters(zone.Id)
                  If (zoneCharacters.Count > 0) Then
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

         If (zone.CharacterFilters And OcrZoneCharacterFilters.Uppercase) = OcrZoneCharacterFilters.Uppercase Then
            _uppercaseCheckBox.Checked = True
         Else
            _uppercaseCheckBox.Checked = False
         End If

         If (zone.CharacterFilters And OcrZoneCharacterFilters.Lowercase) = OcrZoneCharacterFilters.Lowercase Then
            _lowercaseCheckBox.Checked = True
         Else
            _lowercaseCheckBox.Checked = False
         End If

         If (zone.CharacterFilters And OcrZoneCharacterFilters.Punctuation) = OcrZoneCharacterFilters.Punctuation Then
            _punctuationCheckBox.Checked = True
         Else
            _punctuationCheckBox.Checked = False
         End If

         If (zone.CharacterFilters And OcrZoneCharacterFilters.Miscellaneous) = OcrZoneCharacterFilters.Miscellaneous Then
            _miscellaneousCheckBox.Checked = True
         Else
            _miscellaneousCheckBox.Checked = False
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
         _uppercaseCheckBox.Checked = False
         _lowercaseCheckBox.Checked = False
         _punctuationCheckBox.Checked = False
         _miscellaneousCheckBox.Checked = False
         _plusCheckBox.Checked = False
      End If
   End Sub

   Private Sub _propertiesComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _typeComboBox.SelectedIndexChanged, _languageComboBox.SelectedIndexChanged, _zoneViewPerspectiveComboBox.SelectedIndexChanged, _zoneTextDirectionComboBox.SelectedIndexChanged, _languageComboBox.SelectedIndexChanged
      If _tvZonesList.SelectedNode Is Nothing Then
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

      Dim cells As OcrZoneCell() = Nothing
      cells = _zones.GetZoneCells(_zones(CInt(_tvZonesList.SelectedNode.Tag)))
      If Not cells Is Nothing AndAlso cells.Length > 0 Then
         _tvZonesList.SelectedNode.Nodes.Clear()
         _viewerControl.ClearZoneCells(CInt(_tvZonesList.SelectedNode.Tag))
      End If

      CurrentZone = zone

      ' Immediately update the zone if the user changed the zone type to "Table" and wanted to detect the zone cells.
      If Not _ocrPage.Zones Is Nothing AndAlso _ocrPage.Zones.Count > CInt(_tvZonesList.SelectedNode.Tag) Then
         _ocrPage.Zones(CInt(_tvZonesList.SelectedNode.Tag)) = zone
      End If

      If (Not _tvZonesList.SelectedNode Is Nothing) Then
         ZoneToControls(CInt(_tvZonesList.SelectedNode.Tag))
      Else
         ZoneToControls(-1)
      End If
      UpdateUIState()

      DoAction("ZonePropertiesChanged", Nothing)
   End Sub

   Private Sub _characterFiltersCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _plusCheckBox.CheckedChanged, _miscellaneousCheckBox.CheckedChanged, _punctuationCheckBox.CheckedChanged, _lowercaseCheckBox.CheckedChanged, _uppercaseCheckBox.CheckedChanged, _digitCheckBox.CheckedChanged
      Dim filters As OcrZoneCharacterFilters = OcrZoneCharacterFilters.None

      If _digitCheckBox.Checked Then
         filters = filters Or OcrZoneCharacterFilters.Digit
      End If

      If _uppercaseCheckBox.Checked Then
         filters = filters Or OcrZoneCharacterFilters.Uppercase
      End If

      If _lowercaseCheckBox.Checked Then
         filters = filters Or OcrZoneCharacterFilters.Lowercase
      End If

      If _punctuationCheckBox.Checked Then
         filters = filters Or OcrZoneCharacterFilters.Punctuation
      End If

      If _miscellaneousCheckBox.Checked Then
         filters = filters Or OcrZoneCharacterFilters.Miscellaneous
      End If

      If _plusCheckBox.Checked Then
         filters = filters Or OcrZoneCharacterFilters.Plus
      End If

      Dim zone As OcrZone = CurrentZone
      zone.CharacterFilters = filters
      CurrentZone = zone
   End Sub

   Private Sub DoAction(ByVal action As String, ByVal data As Object)
      ' Raise the action event so the parent form can handle it

      If Not action Is Nothing Then
         RaiseEvent Action(Me, New ActionEventArgs(action, data))
      End If
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
