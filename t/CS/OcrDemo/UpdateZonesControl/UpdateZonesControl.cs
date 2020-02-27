// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Leadtools;
using Leadtools.Ocr;
using Leadtools.Demos;
using Leadtools.Drawing;

namespace OcrDemo.UpdateZonesControl
{
   public partial class UpdateZonesControl : UserControl
   {
      private IOcrEngine _ocrEngine;
      private IOcrPage _ocrPage;
      private ListBox _lbZonesList;
      private IOcrZoneCollection _zones;
      private int _oldValue = 0;
      private OcrDemo.ViewerControl.ViewerControl _viewerControl;

      public UpdateZonesControl(OcrDemo.ViewerControl.ViewerControl viewerControl)
      {
         InitializeComponent();
         _viewerControl = viewerControl;
      }

      /// <summary>
      /// Any action that happens in this control that must be handled by the owner
      /// For example, selection change of the combo boxes.
      /// </summary>
      public event EventHandler<ActionEventArgs> Action;

      public void Activate(IOcrEngine ocrEngine, IOcrPage ocrPage, ListBox tvZonesList, IOcrZoneCollection zones)
      {
         _ocrEngine = ocrEngine;
         _ocrPage = ocrPage;
         _lbZonesList = tvZonesList;
         _zones = zones;

         // Initialize the combo boxes
         OcrZoneType[] zoneTypes = ocrEngine.ZoneManager.GetSupportedZoneTypes();
         foreach (OcrZoneType zoneType in zoneTypes)
            _typeComboBox.Items.Add(zoneType);

         // Get the languages supported by this engine and fill the list box
         string[] languages = ocrEngine.LanguageManager.GetSupportedLanguages();
         string[] additionalLanguages = ocrEngine.LanguageManager.GetAdditionalLanguages();
         Dictionary<string, string> languagesDictionary = new Dictionary<string, string>();
         string[] friendlyNames = new string[languages.Length + additionalLanguages.Length];
         int i = 0;
         foreach (string language in languages)
         {
            friendlyNames[i] = MyLanguage.GetLanguageFriendlyName(language);
            languagesDictionary.Add(friendlyNames[i], language);
            i++;
         }
         foreach (string language in additionalLanguages)
         {
            friendlyNames[i] = MyLanguage.GetLanguageFriendlyName(language);
            languagesDictionary.Add(friendlyNames[i], language);
            i++;
         }

         Array.Sort(friendlyNames, 1, friendlyNames.Length - 1);

         MyLanguage ml = new MyLanguage(String.Empty, "None", -1);
         _languageComboBox.Items.Add(ml);
         foreach (string friendlyName in friendlyNames)
         {
            ml = new MyLanguage(languagesDictionary[friendlyName], friendlyName, -1);
            _languageComboBox.Items.Add(ml);
         }

         List<ViewPerspectiveItem> zoneViewPerspectiveValues = new List<ViewPerspectiveItem>();
         zoneViewPerspectiveValues.AddRange(new ViewPerspectiveItem[] { 
            new ViewPerspectiveItem(RasterViewPerspective.TopLeft, "TopLeft"),
            new ViewPerspectiveItem(RasterViewPerspective.TopLeft90, "TopLeft90"),
            new ViewPerspectiveItem(RasterViewPerspective.TopLeft180, "TopLeft180"),
            new ViewPerspectiveItem(RasterViewPerspective.TopLeft270, "TopLeft270")});
         _zoneViewPerspectiveComboBox.Items.AddRange(zoneViewPerspectiveValues.ToArray());

         List<TextDirectionItem> zoneTextDirectionValues = new List<TextDirectionItem>();
         zoneTextDirectionValues.AddRange(new TextDirectionItem[] { 
            new TextDirectionItem(OcrTextDirection.LeftToRight, "LeftToRight"),
            new TextDirectionItem(OcrTextDirection.TopToBottom, "TopToBottom")});
         _zoneTextDirectionComboBox.Items.AddRange(zoneTextDirectionValues.ToArray());

         // These events cannot be hooked into from the designer,
         // so we will do them in here
         _leftTextBox.GotFocus += new EventHandler(_areaTextBox_GotFocus);
         _topTextBox.GotFocus += new EventHandler(_areaTextBox_GotFocus);
         _widthTextBox.GotFocus += new EventHandler(_areaTextBox_GotFocus);
         _heightTextBox.GotFocus += new EventHandler(_areaTextBox_GotFocus);

         _leftTextBox.LostFocus += new EventHandler(_areaTextBox_LostFocus);
         _topTextBox.LostFocus += new EventHandler(_areaTextBox_LostFocus);
         _widthTextBox.LostFocus += new EventHandler(_areaTextBox_LostFocus);
         _heightTextBox.LostFocus += new EventHandler(_areaTextBox_LostFocus);

         _nameTextBox.LostFocus += new EventHandler(_textTextBox_LostFocus);

         UpdateUIState();
      }

      private void _textTextBox_LostFocus(object sender, EventArgs e)
      {
         if (_lbZonesList.SelectedItems.Count == 0 || _lbZonesList.SelectedItems.Count > 1)
            return;

         // Get the new zone name or section name
         OcrZone zone = CurrentZone;

         string str = (sender as TextBox).Text;

         if (sender == _nameTextBox)
            zone.Name = str;

         CurrentZone = zone;
      }

      private void _areaTextBox_GotFocus(object sender, EventArgs e)
      {
         TextBox tb = sender as TextBox;
         int.TryParse(tb.Text, out _oldValue);
      }

      private void _areaTextBox_LostFocus(object sender, EventArgs e)
      {
         if (_lbZonesList.SelectedItems.Count == 0 || _lbZonesList.SelectedItems.Count > 1)
            return;

         // Make sure it is an integer and in valid range
         OcrZone zone = CurrentZone;
         LeadRect bounds = zone.Bounds;

         TextBox tb = sender as TextBox;
         int val;
         if (!int.TryParse(tb.Text, out val) || val < 0)
         {
            ResetBoundsValue(tb, bounds);
            return;
         }

         LeadRect newBounds = bounds;

         // Calculate the new bounds
         if (tb == _leftTextBox)
            newBounds.X = val;
         else if (tb == _topTextBox)
            newBounds.Y = val;
         else if (tb == _widthTextBox)
         {
            if (val == 0)
            {
               ResetBoundsValue(tb, bounds);
               return;
            }
            newBounds.Width = val;
         }
         else if (tb == _heightTextBox)
         {
            if (val == 0)
            {
               ResetBoundsValue(tb, bounds);
               return;
            }
            newBounds.Height = val;
         }

         // Make sure the new bounds does not go outside the page
         LeadRect pageBounds = new LeadRect(0, 0, _ocrPage.Width, _ocrPage.Height);

         if (!pageBounds.Contains(newBounds))
         {
            ResetBoundsValue(tb, bounds);
            return;
         }

         // Valid value, update the bounds
         zone.Bounds = newBounds;
         CurrentZone = zone;
      }

      private void ResetBoundsValue(TextBox tb, LeadRect bounds)
      {
         // An error occurred while entering the bounds value
         // Reset to original value
         if (tb == _leftTextBox)
            tb.Text = bounds.X.ToString();
         else if (tb == _topTextBox)
            tb.Text = bounds.Y.ToString();
         else if (tb == _widthTextBox)
            tb.Text = bounds.Width.ToString();
         else if (tb == _heightTextBox)
            tb.Text = bounds.Height.ToString();
      }

      private OcrZone CurrentZone
      {
         get
         {
            return _zones[_lbZonesList.SelectedIndex];
         }
         set
         {
            _zones[_lbZonesList.SelectedIndex] = value;
         }
      }

      public void UpdateUIState()
      {
         bool enabled = _lbZonesList.SelectedIndex != -1;
         bool enableOmr = (_typeComboBox.SelectedItem != null && ((OcrZoneType)_typeComboBox.SelectedItem == OcrZoneType.Omr));
         bool enableCharacterFilters = enabled && (_typeComboBox.SelectedItem != null && ((OcrZoneType)_typeComboBox.SelectedItem != OcrZoneType.Graphic)) && (_typeComboBox.SelectedItem != null && ((OcrZoneType)_typeComboBox.SelectedItem != OcrZoneType.Omr) && ((OcrZoneType)_typeComboBox.SelectedItem != OcrZoneType.Micr));

         _typeLabel.Enabled = enabled;
         _typeComboBox.Enabled = _typeComboBox.Items.Count > 1 && enabled;
         _languageComboBox.Enabled = _ocrEngine.EngineType == OcrEngineType.LEAD && _languageComboBox.Items.Count > 1 && enabled && (_typeComboBox.SelectedItem != null && ((OcrZoneType)_typeComboBox.SelectedItem == OcrZoneType.Text||(OcrZoneType)_typeComboBox.SelectedItem == OcrZoneType.Table));
         _languageLabel.Enabled = _languageComboBox.Enabled;
         _omrLabel.Enabled = enabled && enableOmr;
         _omrStatusLabel.Enabled = enabled && enableOmr;

         _propertiesGroupBox.Enabled = enabled;
         _nameGroupBox.Enabled = enabled;
         _areaGroupBox.Enabled = enabled;
         _characterFiltersGroupBox.Enabled = enableCharacterFilters;
      }

      public void ZoneToControls(int index)
      {
         // Fill the controls from the current zone
         if (index != -1)
         {
            OcrZone zone = _zones[index];
            _nameTextBox.Text = zone.Name;

            // Convert the bounds to pixels
            LeadRect bounds = zone.Bounds;
            _leftTextBox.Text = bounds.X.ToString();
            _topTextBox.Text = bounds.Y.ToString();
            _widthTextBox.Text = bounds.Width.ToString();
            _heightTextBox.Text = bounds.Height.ToString();

            // Disable these events when changing the combo boxes selected items once the "UpdateZonesControl" gets activated
            this._typeComboBox.SelectedIndexChanged -= new System.EventHandler(this._propertiesComboBox_SelectedIndexChanged);
            this._languageComboBox.SelectedIndexChanged -= new System.EventHandler(this._propertiesComboBox_SelectedIndexChanged);
            this._zoneViewPerspectiveComboBox.SelectedIndexChanged -= new System.EventHandler(this._propertiesComboBox_SelectedIndexChanged);
            this._zoneTextDirectionComboBox.SelectedIndexChanged -= new System.EventHandler(this._propertiesComboBox_SelectedIndexChanged);

            _typeComboBox.SelectedItem = zone.ZoneType;

            for(int i = 0; i < _languageComboBox.Items.Count; i++)
            {
               MyLanguage ml = (MyLanguage)_languageComboBox.Items[i];
               if (zone.Language == null || zone.Language == String.Empty)
               {
                  if(ml.Language == String.Empty)
                  {
                      _languageComboBox.SelectedItem =ml;
                     break;
                  }
               }
               else
               {
                  if(ml.Language == zone.Language)
                  {
                      _languageComboBox.SelectedItem =ml;
                     break;
                  }
               }
            }

            _zoneViewPerspectiveComboBox.SelectedIndex = 0;
            foreach (ViewPerspectiveItem item in _zoneViewPerspectiveComboBox.Items)
            {
               if (item.ViewPerspective == zone.ViewPerspective)
               {
                  _zoneViewPerspectiveComboBox.SelectedItem = item;
                  break;
               }
            }

            _zoneTextDirectionComboBox.SelectedIndex = 0;
            foreach (TextDirectionItem item in _zoneTextDirectionComboBox.Items)
            {
               if (item.TextDirection == zone.TextDirection)
               {
                  _zoneTextDirectionComboBox.SelectedItem = item;
                  break;
               }
            }

            this._typeComboBox.SelectedIndexChanged += new System.EventHandler(this._propertiesComboBox_SelectedIndexChanged);
            this._languageComboBox.SelectedIndexChanged += new System.EventHandler(this._propertiesComboBox_SelectedIndexChanged);
            this._zoneViewPerspectiveComboBox.SelectedIndexChanged += new System.EventHandler(this._propertiesComboBox_SelectedIndexChanged);
            this._zoneTextDirectionComboBox.SelectedIndexChanged += new System.EventHandler(this._propertiesComboBox_SelectedIndexChanged);

            if (zone.ZoneType == OcrZoneType.Omr)
            {
               StringBuilder sb = new StringBuilder();

               if (!_ocrPage.IsRecognized)
               {
                  sb.Append("Unfilled (0% certain)");
               }
               else
               {
                  IOcrPageCharacters pageCharacters = _ocrPage.GetRecognizedCharacters();
                  if (pageCharacters == null || pageCharacters.Count == 0 || zone.Id >= pageCharacters.Count)
                     sb.Append("Unfilled (0% certain)");
                  else
                  {
                     IOcrZoneCharacters zoneCharacters = pageCharacters[zone.Id];
                     if (zoneCharacters.Count > 0)
                     {
                        OcrCharacter omrCharacter = zoneCharacters[0];
                        char filledChar = _ocrEngine.ZoneManager.OmrOptions.GetStateRecognitionCharacter(OcrOmrZoneState.Filled);
                        char unfilledChar = _ocrEngine.ZoneManager.OmrOptions.GetStateRecognitionCharacter(OcrOmrZoneState.Unfilled);
                        if (omrCharacter.Code == filledChar)
                           sb.Append("Filled");
                        else
                           sb.Append("Unfilled");

                        sb.AppendFormat(" ({0}% certain)", omrCharacter.Confidence);
                     }
                     else
                        sb.AppendFormat("Unfilled (0% certain)");
                  }
               }

               _omrStatusLabel.Text = sb.ToString();
            }
            else
               _omrStatusLabel.Text = string.Empty;

            if ((zone.CharacterFilters & OcrZoneCharacterFilters.Digit) == OcrZoneCharacterFilters.Digit)
               _digitCheckBox.Checked = true;
            else
               _digitCheckBox.Checked = false;

            if ((zone.CharacterFilters & OcrZoneCharacterFilters.Plus) == OcrZoneCharacterFilters.Plus)
               _plusCheckBox.Checked = true;
            else
               _plusCheckBox.Checked = false;
         }
         else
         {
            _nameTextBox.Text = string.Empty;

            _leftTextBox.Text = string.Empty;
            _topTextBox.Text = string.Empty;
            _widthTextBox.Text = string.Empty;
            _heightTextBox.Text = string.Empty;

            _typeComboBox.SelectedIndex = 0;
            _languageComboBox.SelectedIndex = 0;
            _zoneViewPerspectiveComboBox.SelectedIndex = 0;
            _zoneTextDirectionComboBox.SelectedIndex = 0;
            _omrStatusLabel.Text = string.Empty;

            _digitCheckBox.Checked = false;
            _plusCheckBox.Checked = false;
         }
      }

      private void _propertiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_lbZonesList.SelectedItems.Count == 0 || _lbZonesList.SelectedItems.Count > 1)
            return;

         OcrZone zone = CurrentZone;

         if (sender == _typeComboBox)
            zone.ZoneType = (OcrZoneType)_typeComboBox.SelectedItem;
         else if (sender == _languageComboBox)
            zone.Language = ((MyLanguage)(_languageComboBox.SelectedItem)).Language;
         else if (sender == _zoneViewPerspectiveComboBox)
            zone.ViewPerspective = ((ViewPerspectiveItem)_zoneViewPerspectiveComboBox.SelectedItem).ViewPerspective;
         else if (sender == _zoneTextDirectionComboBox)
            zone.TextDirection = ((TextDirectionItem)_zoneTextDirectionComboBox.SelectedItem).TextDirection;

         CurrentZone = zone;

         // Immediately update the zone if the user changed the zone type to "Table".
         if (_ocrPage.Zones != null && _ocrPage.Zones.Count > _lbZonesList.SelectedIndex)
            _ocrPage.Zones[_lbZonesList.SelectedIndex] = zone;

         ZoneToControls((_lbZonesList.SelectedItem != null) ? _lbZonesList.SelectedIndex : -1);
         UpdateUIState();

         DoAction("ZonePropertiesChanged", null);
      }

      private void _characterFiltersCheckBox_CheckedChanged(object sender, EventArgs e)
      {
         OcrZoneCharacterFilters filters = OcrZoneCharacterFilters.None;

         if (_digitCheckBox.Checked)
            filters |= OcrZoneCharacterFilters.Digit;

         if (_plusCheckBox.Checked)
            filters |= OcrZoneCharacterFilters.Plus;

         OcrZone zone = CurrentZone;
         zone.CharacterFilters = filters;
         CurrentZone = zone;
      }

      private void DoAction(string action, object data)
      {
         // Raise the action event so the parent form can handle it

         if (Action != null)
            Action(this, new ActionEventArgs(action, data));
      }
   }

   class ViewPerspectiveItem
   {
      public RasterViewPerspective ViewPerspective;
      public string FriendlyName;

      public ViewPerspectiveItem(RasterViewPerspective viewPerspective, string friendlyName)
      {
         ViewPerspective = viewPerspective;
         FriendlyName = friendlyName;
      }

      public override string ToString()
      {
         return FriendlyName;
      }
   }

   class TextDirectionItem
   {
      public OcrTextDirection TextDirection;
      public string FriendlyName;

      public TextDirectionItem(OcrTextDirection textDirection, string friendlyName)
      {
         TextDirection = textDirection;
         FriendlyName = friendlyName;
      }

      public override string ToString()
      {
         return FriendlyName;
      }
   }

   class ZoneItem
   {
      public string ZoneName;
      private int Index;

      public ZoneItem(string name, int index)
      {
         ZoneName = name;
         Index = index;
      }

      public override string ToString()
      {
         return ZoneName + " " + (Index + 1).ToString();
      }
   }
}
