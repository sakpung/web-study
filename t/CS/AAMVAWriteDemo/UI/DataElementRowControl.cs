using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using Leadtools.Barcode;
using System.Text.RegularExpressions;

namespace AAMVAWriteDemo
{
   [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
   public partial class DataElementRowControl : UserControl
   {
      private string _elementID;
      private IDictionary<string, AAMVADataElementInfo> _dataElementInfo;
      private DataElementRowControl.Mode _mode;
      private BorderedTextBox _textBoxValue;
      private AAMVASubfileType _subfileType;

      public static HashSet<string> DatePickerDataElements = new HashSet<string>()
      {
         "DBA", "DBD", "DBB", "DDB", "DDC", "DDH", "DDI", "DDJ"
      };

      public static HashSet<string> ComboBoxDataElements = new HashSet<string>()
      {
         "DBC", "DAY", "DAJ", "DCG", "DAZ", "DCL", "DCU"
      };

      public class ComboBoxDatum
      {
         public ComboBoxDatum(string name, string value)
         {
            this.Name = name;
            this.Value = value;
         }
         public string Name { get; set; }
         public string Value { get; set; }
      }

      public DataElementRowControl()
      {
         InitializeComponent();
         _textBoxValue = new BorderedTextBox();
         _textBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Right)));
         _textBoxValue.Location = new System.Drawing.Point(327, 9);
         _textBoxValue.Name = "_textBoxValue";
         _textBoxValue.Size = new System.Drawing.Size(271, 21);
         this.Controls.Add(this._textBoxValue);
         _textBoxValue.MouseHover += _textBoxValue_MouseHover;
         _checkBoxInclude.CheckedChanged += _checkBoxInclude_CheckedChanged;
         _mode = Mode.TextBox;
         
      }

      public Button ActionButton
      {
         get
         {
            return _btnDefinition;
         }
      }

      public AAMVASubfileType SubfileType
      {
         get
         {
            return _subfileType;
         }
         set
         {
            _subfileType = value;
            if(value == AAMVASubfileType.JurisdictionSpecific)
            {
               _btnDefinition.Click -= _btnDefinition_Click;
               _btnDefinition.Text = "X";
            }
            else
            {
               _btnDefinition.Click += _btnDefinition_Click;
            }
         }
      }

      public enum Mode
      {
         TextBox,
         DatePicker,
         ComboBox
      }

      public CheckBox CheckBox
      {
         get
         {
            return _checkBoxInclude;
         }
      }

      public ComboBox ComboBox
      {
         get
         {
            return _comboBox;
         }
      }

      public TextBox TextBox
      {
         get
         {
            return _textBoxValue;
         }
      }

      public DateTimePicker DateTimePicker
      {
         get
         {
            return _dateTimePicker;
         }
      }

      private AAMVAJurisdiction _jurisdiction;
      public AAMVAJurisdiction Jurisdiction
      {
         get
         {
            return _jurisdiction;
         }
         set
         {
            _jurisdiction = value;
         }
      }

      private void _checkBoxInclude_CheckedChanged(object sender, EventArgs e)
      {
         if (!_checkBoxInclude.Checked)
         {
            _labelFriendlyName.ForeColor = SystemColors.GrayText;
            _textBoxValue.Enabled = false;
            _textBoxValue.ForeColor = SystemColors.GrayText;
            _textBoxValue.Text = String.Empty;
            _textBoxElementID.ForeColor = SystemColors.GrayText;

            _dateTimePicker.Enabled = false;
            _dateTimePicker.CalendarForeColor = SystemColors.GrayText;

            _comboBox.Enabled = false;
            _comboBox.ForeColor = SystemColors.GrayText;
         }
         else
         {
            _labelFriendlyName.ForeColor = SystemColors.ControlText;
            _textBoxValue.Enabled = true;
            _textBoxValue.ForeColor = SystemColors.ControlText;
            _btnDefinition.Enabled = true;
            _textBoxElementID.ForeColor = SystemColors.ControlText;

            _dateTimePicker.Enabled = true;
            _dateTimePicker.CalendarForeColor = SystemColors.ControlText;

            _comboBox.Enabled = true;
            _comboBox.ForeColor = SystemColors.ControlText;
         }

         if (_textBoxValue.BorderColor != SystemColors.ActiveBorder)
            _textBoxValue.BorderColor = SystemColors.ActiveBorder;
      }

      private void _textBoxValue_MouseHover(object sender, EventArgs e)
      {
         _toolTip.Show(GetTooltipText(_elementID), _textBoxValue);
      }

      public IDictionary<string, AAMVADataElementInfo> DataElementInfo
      {
         get
         {
            return _dataElementInfo;
         }
         set
         {
            _dataElementInfo = value;
         }
      }
      
      public DataElementRowControl.Mode ViewMode
      {
         get
         {
            return _mode;
         }
         private set
         {
            switch(value)
            {
               case Mode.TextBox:
                  _textBoxValue.Visible = true;
                  _comboBox.Visible = false;
                  _dateTimePicker.Visible = false;
                  _mode = value;
                  break;
               case Mode.DatePicker:
                  _textBoxValue.Visible = false;
                  _comboBox.Visible = false;
                  _dateTimePicker.Visible = true;
                  _mode = value;
                  break;
               case Mode.ComboBox:
                  _textBoxValue.Visible = false;
                  _comboBox.Visible = true;
                  _dateTimePicker.Visible = false;
                  _mode = value;
                  break;
            }
         }
      }

      public string ElementID
      {
         get
         {
            return _elementID;
         }

         set
         {
            _elementID = value;
            _textBoxElementID.Text = _elementID;

            if(DatePickerDataElements.Contains(_elementID))
            {
               ViewMode = Mode.DatePicker;
            }
            else if (ComboBoxDataElements.Contains(_elementID))
            {
               ViewMode = Mode.ComboBox;

               if(_elementID.Equals("DBC")) //Sex
               {
                  //Add D20 lookup to SDK
                  ComboBoxDatum[] sexData =
                  {
                     new ComboBoxDatum(AAMVASex.Male.ToString() + " - \"1\"", Convert.ToString(((int)AAMVASex.Male))),
                     new ComboBoxDatum(AAMVASex.Female.ToString() + " - \"2\"", Convert.ToString(((int)AAMVASex.Female))),
                     new ComboBoxDatum(AAMVASex.Unknown.ToString() + " - \"9\"", Convert.ToString(((int)AAMVASex.Unknown)))
                  };
                  _comboBox.DataSource = sexData;
                  _comboBox.DisplayMember = "Name";
                  _comboBox.ValueMember = "Value";
               }

               if(_elementID.Equals("DAY")) //Eye color  
               {
                  //Add D20 lookup to SDK
                  ComboBoxDatum[] eyeColorData =
                  {
                     new ComboBoxDatum(AAMVAEyeColor.Unknown.ToString() + " - \"UNK\"", "UNK"),
                     new ComboBoxDatum(AAMVAEyeColor.Brown.ToString() + " - \"BRO\"", "BRO"),
                     new ComboBoxDatum(AAMVAEyeColor.Gray.ToString() + " - \"GRY\"", "GRY"),
                     new ComboBoxDatum(AAMVAEyeColor.Hazel.ToString() + " - \"HAZ\"", "HAZ"),
                     new ComboBoxDatum(AAMVAEyeColor.Pink.ToString() + " - \"PNK\"", "PNK"),
                     new ComboBoxDatum(AAMVAEyeColor.Blue.ToString() + " - \"BLU\"", "BLU"),
                     new ComboBoxDatum(AAMVAEyeColor.Dichromatic.ToString() + " - \"DIC\"", "DIC"),
                     new ComboBoxDatum(AAMVAEyeColor.Green.ToString() + " - \"GRN\"", "GRN"),
                     new ComboBoxDatum(AAMVAEyeColor.Maroon.ToString() + " - \"MAR\"", "MAR"),
                     new ComboBoxDatum(AAMVAEyeColor.Black.ToString() + " - \"BLK\"", "BLK")
                  };
                  _comboBox.DataSource = eyeColorData;
                  _comboBox.DisplayMember = "Name";
                  _comboBox.ValueMember = "Value";
               }

               if(_elementID.Equals("DAJ")) //Jurisdiction Code
               {
                  AAMVAJurisdiction[] jurisdictions = (AAMVAJurisdiction[])Enum.GetValues(typeof(AAMVAJurisdiction));
                  ComboBoxDatum[] jurisdictionData = new ComboBoxDatum[jurisdictions.Length];
                  int preselectedIndex = 0;
                  for (int i = 0; i < jurisdictions.Length; i++)
                  {
                     string abbr = AAMVAID.LookupStateAbbreviation(jurisdictions[i]);
                     if (abbr == null) //state dept usa
                        abbr = "  "; // this is an adlib. there is no code for state dept and no instructions on how to handle it
                     string friendlyName = MainForm.JurisdictionToFriendlyString(jurisdictions[i], false);
                     string display = friendlyName + " - \"" + abbr + "\"";
                     jurisdictionData[i] = new ComboBoxDatum(display, abbr);
                     if (_jurisdiction == jurisdictions[i])
                        preselectedIndex = i;
                  }
                  _comboBox.DataSource = jurisdictionData;
                  _comboBox.DisplayMember = "Name";
                  _comboBox.ValueMember = "Value";
                  _comboBox.SelectedIndex = preselectedIndex;
                  if (_jurisdiction != AAMVAJurisdiction.Unknown)
                     _comboBox.Enabled = false;
               }

               if (_elementID.Equals("DCG")) //Country
               {
                  ComboBoxDatum[] eyeColorData =
                  {
                     new ComboBoxDatum(MainForm.InsertSpacesToPascalCaseString(AAMVARegion.UnitedStates.ToString()) +  " - \"USA\"", "USA"),
                     new ComboBoxDatum(AAMVARegion.Canada.ToString() + " - \"CAN\"", "CAN"),
                     new ComboBoxDatum(AAMVARegion.Mexico.ToString() + " - \"MEX\"", "MEX"),
                  };
                  _comboBox.DataSource = eyeColorData;
                  _comboBox.DisplayMember = "Name";
                  _comboBox.ValueMember = "Value";
                  AAMVARegion rgn = AAMVAID.LookupRegion(_jurisdiction);
                  if (rgn == AAMVARegion.UnitedStates)
                     _comboBox.SelectedIndex = 0;
                  if (rgn == AAMVARegion.Canada)
                     _comboBox.SelectedIndex = 1;
                  if (rgn == AAMVARegion.Mexico)
                     _comboBox.SelectedIndex = 2;
                  if (_jurisdiction != AAMVAJurisdiction.Unknown)
                     _comboBox.Enabled = false;

               }

               if (_elementID.Equals("DAZ")) //Hair
               {
                  ComboBoxDatum[] hairColorData =
                  {
                     new ComboBoxDatum(AAMVAHairColor.Unknown.ToString() + " - \"UNK\"", "BRO"),
                     new ComboBoxDatum(AAMVAHairColor.Black.ToString() + " - \"BLK\"", "BLK"),
                     new ComboBoxDatum(AAMVAHairColor.Brown.ToString() + " - \"BRO\"", "BRO"),
                     new ComboBoxDatum(AAMVAHairColor.Red.ToString() + " - \"RED\"", "RED"),
                     new ComboBoxDatum(AAMVAHairColor.White.ToString() + " - \"WHI\"", "WHI"),
                     new ComboBoxDatum(AAMVAHairColor.Bald.ToString() + " - \"BAL\"", "BAL"),
                     new ComboBoxDatum(AAMVAHairColor.Blonde.ToString() + " - \"BLN\"", "BLN"),
                     new ComboBoxDatum(AAMVAHairColor.Gray.ToString() + " - \"GRY\"", "GRY"),
                     new ComboBoxDatum(AAMVAHairColor.Sandy.ToString() + " - \"SDY\"", "SDY")
                  };
                  _comboBox.DataSource = hairColorData;
                  _comboBox.DisplayMember = "Name";
                  _comboBox.ValueMember = "Value";
               }

               if(_elementID.Equals("DCL")) //Race/Ethnicity
               {
                  AAMVARaceEthnicity[] races = (AAMVARaceEthnicity[])Enum.GetValues(typeof(AAMVARaceEthnicity));
                  ComboBoxDatum[] raceData = new ComboBoxDatum[races.Length];
                  for(int i = 0; i < races.Length; i++)
                  {
                     AAMVARaceEthnicity race = races[i];
                     string code = AAMVAID.LookupRaceEthnicityCode(race);
                     string displayString = MainForm.InsertSpacesToPascalCaseString(race.ToString()) + " - \"" + code + "\"";
                     ComboBoxDatum datum = new ComboBoxDatum(displayString, code);
                     raceData[i] = datum;
                  }
                  _comboBox.DataSource = raceData;
                  _comboBox.DisplayMember = "Name";
                  _comboBox.ValueMember = "Value";
               }

               if (_elementID.Equals("DCU")) //Name Suffix
               {
                  AAMVANameSuffix[] enums = (AAMVANameSuffix[])Enum.GetValues(typeof(AAMVANameSuffix));
                  ComboBoxDatum[] data = new ComboBoxDatum[enums.Length - 2]; //Unknown and Esquire are should not be used for write
                  for (int i = 2; i < enums.Length; i++)
                  {
                     AAMVANameSuffix enumValue = enums[i];
                     string code = AAMVAID.LookupNameSuffixCodeArabic(enumValue);
                     string displayString = MainForm.InsertSpacesToPascalCaseString(enumValue.ToString()) + " - \"" + code + "\"";
                     ComboBoxDatum datum = new ComboBoxDatum(displayString, code);
                     data[i - 2] = datum;
                  }
                  _comboBox.DataSource = data;
                  _comboBox.DisplayMember = "Name";
                  _comboBox.ValueMember = "Value";
               }


            }
            else
            {
               ViewMode = Mode.TextBox;
               if (_elementID.Equals("DDE") || _elementID.Equals("DDF") || _elementID.Equals("DDG"))
               {
                  AdditionalValidation += Truncation_AdditionalValidation;
               }

               if (_elementID.Equals("DDD") || _elementID.Equals("DDK") || _elementID.Equals("DDL"))
               {
                  AdditionalValidation += OneOnly_AdditionalValidation;
               }

               if (_elementID.Equals("DDA"))
               {
                  AdditionalValidation += ComplianceType_AdditionalValidation;
               }

               _textBoxValue.KeyPress += _textBoxValue_KeyPress;

               this.BeforeSubmitText += DataElementRowControl_BeforeSubmitText;
               this.ValidateOnSubmitText += DataElementRowControl_ValidateOnSubmitText;
               
            }

            if(_dataElementInfo != null)
            {
               AAMVADataElementInfo info = _dataElementInfo[_elementID];
               if (info != null)
               {

                  if (EditSubfileDialog.DHSDataElements.Contains(_elementID))
                  {
                     _labelFriendlyName.Text = info.FriendlyName + " (DHS Required)";
                  }
                  else if (_elementID.Equals("DDD"))
                  {
                     _labelFriendlyName.Text = info.FriendlyName + " (DHS Required if applicable to cardholder)";
                     _textBoxValue.Text = "1";
                  }
                  else
                  {
                     _labelFriendlyName.Text = info.FriendlyName;
                  }
               }
            }
         }
      }

      private bool DataElementRowControl_ValidateOnSubmitText(object sender, EventArgs e)
      {
         AAMVADataElementInfo info = this.DataElementInfo[this.ElementID];
         if (info.LengthType == AAMVALengthType.Fixed &&
            this.TextBox.Text.Length != info.ValueMaxLength &&
            this.CheckBox.Checked)
         {
            ((BorderedTextBox)this.TextBox).BorderColor = Color.Red;
            return false;
         }

         if(_elementID == "DAU") //height
         {
            string expression = @"^\d{3,} (?:in|cm)$";
            bool match = Regex.IsMatch(_textBoxValue.Text, expression);
            if (!match)
            {
               ((BorderedTextBox)this.TextBox).BorderColor = Color.Red;
               return false;
            }
               
         }

         return true;
      }

      private void DataElementRowControl_BeforeSubmitText(object sender, EventArgs e)
      {
         AAMVADataElementInfo info = this.DataElementInfo[this.ElementID];
         if (info.LengthType == AAMVALengthType.Variable &&
            (info.ValidCharacters & (int)AAMVAValidCharacters.Alpha) == (int)AAMVAValidCharacters.Alpha &&
            info.ValueMaxLength >= 4 &&
            this.TextBox.Text.Length == 0 &&
            this.CheckBox.Checked)
         {
            this.TextBox.Text = "NONE";
         }

         if(_elementID == "DAK") //Postal code
         {
            AAMVARegion rgn = AAMVAID.LookupRegion(_jurisdiction);
            
            if(rgn == AAMVARegion.UnitedStates)
            {
               if(_textBoxValue.Text.Length >= 5 && _textBoxValue.Text.Length < 9)
               {
                  StringBuilder sb = new StringBuilder(_textBoxValue.Text);
                  while(sb.Length < 9)
                  {
                     sb.Append('0');
                  }

                  while (sb.Length < 11)
                  {
                     sb.Append(' ');
                  }
                  _textBoxValue.Text = sb.ToString();
               }
               else if (_textBoxValue.Text.Length >= 9 && _textBoxValue.Text.Length < 11)
               {
                  StringBuilder sb = new StringBuilder(_textBoxValue.Text);
                  while (sb.Length < 11)
                  {
                     sb.Append(' ');
                  }
                  _textBoxValue.Text = sb.ToString();
               }
            }
            else if (rgn == AAMVARegion.Canada)
            {
               if(_textBoxValue.Text.Length > 5)
               {
                  StringBuilder sb = new StringBuilder(_textBoxValue.Text);
                  while (sb.Length < 11)
                  {
                     sb.Append(' ');
                  }
                  _textBoxValue.Text = sb.ToString();
               }
            }
            else if(rgn == AAMVARegion.Mexico)
            {
               if (_textBoxValue.Text.Length > 6)
               {
                  StringBuilder sb = new StringBuilder(_textBoxValue.Text);
                  while (sb.Length < 11)
                  {
                     sb.Append(' ');
                  }
                  _textBoxValue.Text = sb.ToString();
               }
            }
         }
      }

      private bool ComplianceType_AdditionalValidation(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == 'M' || e.KeyChar == 'F' || e.KeyChar == 'N' || char.IsControl(e.KeyChar))
            return true;

         return false;
      }

      private bool OneOnly_AdditionalValidation(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == '1' ||char.IsControl(e.KeyChar))
            return true;

         return false;
      }

      private bool Truncation_AdditionalValidation(object sender, KeyPressEventArgs e)
      {
         e.KeyChar = Char.ToUpper(e.KeyChar);
         if (e.KeyChar == 'T' || e.KeyChar == 'N' || e.KeyChar == 'U' || char.IsControl(e.KeyChar))
            return true;

         return false;
      }

      public event AdditionalValidationEventHandler AdditionalValidation;

      public delegate bool AdditionalValidationEventHandler(object sender, KeyPressEventArgs e);

      protected virtual bool RaiseAdditionalValidationEvent(object sender, KeyPressEventArgs e)
      {
         if (AdditionalValidation != null)
         {
            return AdditionalValidation(sender, e);
         }
         return true;
      }
      
      //Step to be taken before submission 
      public event BeforeSubmitTextEventHandler BeforeSubmitText;

      public delegate void BeforeSubmitTextEventHandler(object sender, EventArgs e);

      internal virtual void RaiseBeforeSubmitTextEvent()
      {
         if(BeforeSubmitText != null)
         {
            BeforeSubmitText(this, new EventArgs());
         }
      }

      //Final validation step to be performed after BeforeSubmitText
      public event ValidateOnSubmitTextEventHandler ValidateOnSubmitText;

      public delegate bool ValidateOnSubmitTextEventHandler(object sender, EventArgs e);

      internal virtual bool RaiseValidateOnSubmitTextEvent()
      {
         if (ValidateOnSubmitText != null)
         {
            return ValidateOnSubmitText(this, new EventArgs());
         }
         return true;
      }

      //Generic validator
      private bool IsInputKeyValid(KeyPressEventArgs e)
      {
         AAMVADataElementInfo info = null;
         try
         {
            info = _dataElementInfo[_elementID];
         }
         catch
         {
            //For jurisdiction-specific 
            info = new AAMVADataElementInfo();
            info.LengthType = AAMVALengthType.Variable;
            info.ValueMaxLength = 99;
            info.ValidCharacters = (int)AAMVAValidCharacters.Alpha | (int)AAMVAValidCharacters.Numeric | (int)AAMVAValidCharacters.Special;
         }
            

         if (_textBoxValue.Text.Length == info.ValueMaxLength && !char.IsControl(e.KeyChar) && _textBoxValue.SelectedText.Length == 0)
         {
            return false;
         }

         bool allowNumeric = (info.ValidCharacters & (int)AAMVAValidCharacters.Numeric) == (int)AAMVAValidCharacters.Numeric;
         bool allowAlpha = (info.ValidCharacters & (int)AAMVAValidCharacters.Alpha) == (int)AAMVAValidCharacters.Alpha;
         bool allowSpecial = (info.ValidCharacters & (int)AAMVAValidCharacters.Special) == (int)AAMVAValidCharacters.Special;

         if (!allowNumeric)
         {
            if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
               return false;
            }
         }

         if (!allowAlpha)
         {
            if (char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)) 
            {
               return false;
            }
         }

         if (!allowSpecial)
         {
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
               if (!(allowAlpha && e.KeyChar == ' '))//allow spaces with alpha fields -- do not consider space a special char
                  return false;
            }
         }

         if (!(e.KeyChar < 128) && !char.IsControl(e.KeyChar)) //ASCII only
            return false;

         return true;
         
      }

      private void _textBoxValue_KeyPress(object sender, KeyPressEventArgs e)
      {
         bool valid = IsInputKeyValid(e);

         valid = valid && RaiseAdditionalValidationEvent(sender, e);

         if (!valid)
         {
            e.Handled = true;
            System.Media.SystemSounds.Beep.Play();
            return;
         }
         if (_textBoxValue.BorderColor != SystemColors.ActiveBorder)
            _textBoxValue.BorderColor = SystemColors.ActiveBorder;
      }

      private void _btnDefinition_Click(object sender, EventArgs e)
      {
         MessageBox.Show(GetTooltipText(_elementID), "Data Element Info");
      }

      private string GetTooltipText(string elementID)
      {
         AAMVADataElementInfo info = null;
         try
         {
            info = _dataElementInfo[elementID];
         }     
         catch
         {
            return "Jurisdiction-specific data element";
         } 
         StringBuilder sb = new StringBuilder();

         if (info != null)
         {
            //alpha?
            bool alpha = (info.ValidCharacters & ((int)AAMVAValidCharacters.Alpha)) == (int)AAMVAValidCharacters.Alpha;

            bool numeric = (info.ValidCharacters & ((int)AAMVAValidCharacters.Numeric)) == (int)AAMVAValidCharacters.Numeric;

            bool special = (info.ValidCharacters & ((int)AAMVAValidCharacters.Special)) == (int)AAMVAValidCharacters.Special;

            sb.Append("Element ID: ")
               .Append(info.ElementID)
               .Append(Environment.NewLine)
               .Append(Environment.NewLine)

               .Append("Friendly Name: ")
               .Append(info.FriendlyName)
               .Append(Environment.NewLine)
               .Append(Environment.NewLine)

               .Append("Definition: ")
               .Append(info.Definition)
               .Append(Environment.NewLine)
               .Append(Environment.NewLine)

               .Append("Value Max Length: ")
               .Append(Convert.ToString(info.ValueMaxLength))
               .Append(Environment.NewLine)
               .Append(Environment.NewLine)

               .Append("Length Type: ")
               .Append(Convert.ToString(info.LengthType))
               .Append(Environment.NewLine)
               .Append(Environment.NewLine)

               .Append("Valid Characters: ");

            if (alpha)
               sb.Append("Alphabetical ");

            if (numeric)
               sb.Append("Numeric ");

            if (special)
               sb.Append("Special");
         }
         return sb.ToString();
      }
   }
}
