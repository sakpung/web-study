// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

using Leadtools.Medical3D;
using Leadtools.MedicalViewer;

namespace FusionDemo
{

    // A class that is derived from System.Windows.Forms.Label control
    public partial class ColorBox : System.Windows.Forms.Label
    {
        private Color _color;

        public ColorBox()
        {
            _color = Color.Transparent;
        }

        public Color BoxColor
        {
            set
            {
                _color = Color.FromArgb(255, value);
                if (this.Enabled)
                    BackColor = _color;
            }
            get
            {
                return Color.FromArgb(0, _color.R, _color.G, _color.B);
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            if (BackColor != Color.Transparent)
                _color = BackColor;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (this.Enabled)
                BackColor = _color;
            else
                BackColor = Color.Transparent;
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            _color = BackColor;
            base.OnDoubleClick(e);
        }
    }

    public partial class NumericUpDownDraggable : System.Windows.Forms.NumericUpDown
    {
        int  previousYValue;
        bool draged;

        public NumericUpDownDraggable()
        {
            this.MouseDown += new MouseEventHandler(NumericUpDownDraggable_MouseDown);
            this.MouseUp += new MouseEventHandler(NumericUpDownDraggable_MouseUp);
            this.MouseMove += new MouseEventHandler(NumericUpDownDraggable_MouseMove);
        }

        void NumericUpDownDraggable_MouseMove(object sender, MouseEventArgs e)
        {
            if (draged)
            {
                this.Value = Math.Max(this.Minimum, Math.Min(this.Maximum, this.Value + (previousYValue - e.Y) * 42));
                Cursor.Current = Cursors.SizeNS;
                previousYValue = e.Y;
            }
        }

        void NumericUpDownDraggable_MouseUp(object sender, MouseEventArgs e)
        {
            draged = false;
        }

        void NumericUpDownDraggable_MouseDown(object sender, MouseEventArgs e)
        {
            previousYValue = e.Y;
            draged = true;
        }
    }

    // A class that is derived from TextBox control, that allows only
    // 1) The numeric values.
    // 2) The values that fall within the given range.
    public partial class FNumericTextBox : System.Windows.Forms.TextBox
    {
        private float _maximumAllowed;
        private float _minimumAllowed;
        private string _oldText;

        string GetFormattedText(string orginalText)
        {
            string text;

            if (orginalText.Trim() == "")
                return "0";

            char[] charArray = orginalText.ToCharArray();

            if (charArray[0] == '-')
            {
                text = orginalText.Remove(0, 1);
                if (text.Trim() == "")
                    text = "0";
                else
                    text = orginalText;
            }
            else
            {
                text = orginalText;
            }
            return text;
        }

        public FNumericTextBox()
        {
            _maximumAllowed = 1000.0F;
            _minimumAllowed = -1000.0F;
            _oldText = "";
        }

        [Description("The minimum allowed value to be entered"),
        Category("Allowed Values")]
        public float MinimumAllowed
        {
            set
            {
                _minimumAllowed = value;
            }
            get
            {
                return _minimumAllowed;
            }
        }

        [Description("The maximum allowed value to be entered"),
        Category("Allowed Values")]
        public float MaximumAllowed
        {
            set
            {
                _maximumAllowed = value;
            }
            get
            {
                return _maximumAllowed;
            }
        }

        [Description("The numeric value of the Text box"),
        Category("Current Value")]
        public float Value
        {
            set
            {
                String text = value.ToString();
                int dotIndex = text.IndexOf('.');
                if (dotIndex != -1)
                {
                   if (text.Length > dotIndex + 4)
                      text = text.Remove(dotIndex + 4);
                }
                this.Text = text;
            }
            get
            {
                if (this.Text.Trim() == "")
                    return Math.Max(_minimumAllowed, 0);
                else
                    return Convert.ToSingle(GetFormattedText(this.Text));
            }
        }

        // Is the entered number within the specified valid range
        private bool IsAllowed(string orginalText)
        {
            float maximumAllowed = _maximumAllowed;
            string text;

            if (orginalText.Trim() == "")
                return true;

            char[] charArray = orginalText.ToCharArray();

            if ((charArray[0] == '-') && (_minimumAllowed > 0))
                return false;

            if (charArray[0] == '-')
            {
                text = orginalText.Remove(0, 1);
                if (_minimumAllowed < 0)
                    maximumAllowed = _minimumAllowed * -1;
                if (text.Trim() == "")
                    text = "0";
            }
            else
            {
                text = orginalText;
            }

            bool isAllowed = true;

            try
            {
                double newNumber = Convert.ToDouble(text);
                if ((newNumber > maximumAllowed) || (newNumber < _minimumAllowed))
                    isAllowed = false;
                int dotIndex = text.IndexOf('.');
                if (dotIndex != -1)
                {
                    if ((text.Length - dotIndex - 1) > 3)
                        isAllowed = false;
                }
            }
            catch
            {
                // This happen if the entered value is not a numeric.
                isAllowed = false;
            }

            return isAllowed;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (!IsAllowed(this.Text))
            {
                // If this condition doesn't exist, the user will be bugged. (trust me).
                if (_minimumAllowed <= 0)
                    this.Text = _oldText;
            }
            else
                _oldText = this.Text;

            base.OnTextChanged(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Increase or decrease the current value by 1 if the user presses the UP or DOWN
            // and test if the new value is allowed
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {
                double value = Convert.ToDouble(GetFormattedText(this.Text));

                value = (e.KeyCode == Keys.Up) ? value + 0.1009 : value - 0.1009;

                string text = value.ToString();
                int dotIndex = text.IndexOf('.');
                if (dotIndex != -1)
                {
                    text = text.Remove(dotIndex + 4);
                }

                if (IsAllowed(text))
                    this.Text = text;
            }

            if (e.KeyCode == Keys.Back)
            {
                string text = this.Text;
                int selectionStart = this.SelectionStart;

                if (selectionStart == 0)
                    return;

                if (text.Length == 0)
                    return;

                text = text.Remove(selectionStart - 1, 1);

                if (IsAllowed(text))
                {
                    base.OnKeyDown(e);
                }
                else
                    return;

            }

            base.OnKeyDown(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            string text = GetFormattedText(this.Text);

            double value = (text.Trim() == "") ? _minimumAllowed : Convert.ToDouble(text);
            if (value < _minimumAllowed)
                this.Text = _minimumAllowed.ToString();

            base.OnLostFocus(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
            // since the user is not entering a new character...
            if (((Control.ModifierKeys & Keys.Control) == 0) &&
                ((Control.ModifierKeys & Keys.Alt) == 0) &&
                 (e.KeyChar != Convert.ToChar(Keys.Enter)) &&
                 (e.KeyChar != Convert.ToChar(Keys.Escape)) &&
                 (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                #region Check if the entered character is valid for Numeric format
                // Validate the entered character
                if (!Char.IsNumber(e.KeyChar))
                {

                    bool previousMinusWillBeDeleted = false;
                    int indexofMinus = this.Text.IndexOf('-');
                    if (indexofMinus != -1)
                    {
                        if ((indexofMinus >= this.SelectionStart) && (indexofMinus < this.SelectionStart + this.SelectionLength))
                            previousMinusWillBeDeleted = true;
                    }

                    #region Check If the user has entered Minus character
                    // Here we check if the user wants to enter the "-" character.
                    if (!previousMinusWillBeDeleted)
                    {
                        // Here we check if the user wants to enter the "-" character.
                        if (!((this.Text.IndexOf('-') == -1) && // there is no Minus character
                              (this.SelectionStart == 0) && // the cursor at the begining
                              (_minimumAllowed < 0) && // the minimum allowed accept negative values
                              (e.KeyChar == '-')))  // the character entered was a Minus character
                        {
                            if (!((e.KeyChar == '.') &&
                               (this.Text.IndexOf('.') == -1)))
                                e.KeyChar = Char.MinValue;
                        }
                    }
                    #endregion
                }
                #endregion

                if (_minimumAllowed <= 0)
                    #region Checkinng if the value falles within the given range
                    if (e.KeyChar != Char.MinValue)
                    {
                        // Create the string that will be displayed, and check whether it's valid or not.

                        // Remove the selected character(s).
                        string newString = this.Text.Remove(this.SelectionStart, this.SelectionLength);
                        // Insert the new character.
                        newString = newString.Insert(this.SelectionStart, e.KeyChar.ToString());
                        if (!IsAllowed(newString))
                            // the new string is not valid, cancel the whole operation.
                            e.KeyChar = Char.MinValue;
                    }
                    #endregion
            }
            base.OnKeyPress(e);
        }
    }

    public partial class CursorButton : System.Windows.Forms.Button
    {
        private Cursor _buttonCursor;

        public CursorButton()
        {
            _buttonCursor = null;
        }

        [Description("The Cursor"),
        Category("Cursor")]
        public Cursor ButtonCursor
        {
            set
            {
                _buttonCursor = value;
            }
            get
            {
                return _buttonCursor;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = @"Cursor files (*.cur) | *.cur";
            openDialog.RestoreDirectory = true;

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _buttonCursor = new System.Windows.Forms.Cursor(openDialog.FileName);
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (_buttonCursor != null)
            {
                int averageWidth = (pevent.ClipRectangle.Width - _buttonCursor.Size.Width) / 2;
                int averageHeight = (pevent.ClipRectangle.Height - _buttonCursor.Size.Height) / 2;

                _buttonCursor.Draw(pevent.Graphics, new Rectangle(averageWidth, averageHeight, _buttonCursor.Size.Width, _buttonCursor.Size.Height));
            }
        }
    }

    // A class that is derieved from TextBox control, that allows only
    // 1) The numeric values.
    // 2) The values that fall within the given range.
    public partial class NumericTextBox : System.Windows.Forms.TextBox
    {
        private int _maximumAllowed;
        private int _minimumAllowed;
        private string _oldText;

        string GetFormattedText(string orginalText)
        {
            string text;

            if (orginalText.Trim() == "")
                return "0";

            char[] charArray = orginalText.ToCharArray();

            if (charArray[0] == '-')
            {
                text = orginalText.Remove(0, 1);
                if (text.Trim() == "")
                    text = "0";
                else
                    text = orginalText;
            }
            else
            {
                text = orginalText;
            }

            return text;
        }


        public NumericTextBox()
        {
            _maximumAllowed = 1000;
            _minimumAllowed = -1000;
            _oldText = "";
        }

        [Description("The minimum allowed value to be entered"),
        Category("Allowed Values")]
        public int MinimumAllowed
        {
            set
            {
                _minimumAllowed = value;
            }
            get
            {
                return _minimumAllowed;
            }
        }

        [Description("The maximum allowed value to be entered"),
        Category("Allowed Values")]
        public int MaximumAllowed
        {
            set
            {
                _maximumAllowed = value;
            }
            get
            {
                return _maximumAllowed;
            }
        }

        [Description("The maximum allowed value to be entered"),
        Category("Current Value")]
        public int Value
        {
            set
            {
                this.Text = value.ToString();
            }
            get
            {
                if (this.Text.Trim() == "")
                    return Math.Max(_minimumAllowed, 0);
                else
                {
                    return Math.Max(_minimumAllowed, Convert.ToInt32(GetFormattedText(this.Text)));
                }
            }
        }

        // Is the entered number within the specified valid range
        private bool IsAllowed(string orginalText)
        {
            int maximumAllowed = _maximumAllowed;
            string text;

            if (orginalText.Trim() == "")
                return true;

            char[] charArray = orginalText.ToCharArray();

            // if a Minus is entered and the minimum allowed is not negative return false immeditally
            if ((charArray[0] == '-') && (_minimumAllowed > 0))
                return false;

            // if the first character is Minus, remove it and compare the rest with the new maximum
            if (charArray[0] == '-')
            {
                text = orginalText.Remove(0, 1);
                if (_minimumAllowed < 0)
                    maximumAllowed = _minimumAllowed * -1;
                if (text.Trim() == "")
                    text = "0";
            }
            else
            {
                text = orginalText;
            }

            bool isAllowed = true;

            try
            {
                int newNumber = Convert.ToInt32(text);
                if ((newNumber > maximumAllowed) || (newNumber < _minimumAllowed))
                    isAllowed = false;
            }
            catch
            {
                // This happen if the entered value is not a numeric.
                isAllowed = false;
            }

            return isAllowed;
        }

        protected override void OnTextChanged(EventArgs e)
        {
            if (!IsAllowed(this.Text))
            {
                if (_minimumAllowed <= 1)
                    this.Text = _oldText;
            }
            else
                _oldText = this.Text;

            base.OnTextChanged(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Increase or decrease the current value by 1 if the user presses the UP or DOWN
            // and test if the new value is allowed
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
            {

                int value = Convert.ToInt32(GetFormattedText(this.Text));

                value = (e.KeyCode == Keys.Up) ? value + 1 : value - 1;

                if (IsAllowed(value.ToString()))
                    this.Text = value.ToString();
            }

            if (e.KeyCode == Keys.Back)
            {
                string text = this.Text;
                int selectionStart = this.SelectionStart;

                if (selectionStart == 0)
                    return;

                if (text.Length == 0)
                    return;

                text = text.Remove(selectionStart - 1, 1);

                if (IsAllowed(text))
                {
                    base.OnKeyDown(e);
                }
                else
                    return;

            }

            base.OnKeyDown(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            string text = GetFormattedText(this.Text);
            int value;
            if (text.Trim() == "")
                value = 0;
            else
                value = Convert.ToInt32(text);

            if (value < _minimumAllowed)
                this.Text = _minimumAllowed.ToString();

            base.OnLostFocus(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            // if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
            // since the user is not entering a new character...
            if (((Control.ModifierKeys & Keys.Control) == 0) &&
                ((Control.ModifierKeys & Keys.Alt) == 0) &&
                 (e.KeyChar != Convert.ToChar(Keys.Enter)) &&
                 (e.KeyChar != Convert.ToChar(Keys.Escape)) &&
                 (e.KeyChar != Convert.ToChar(Keys.Back)))
            {
                #region Check if the entered character is valid for Numeric format
                // Validate the entered character
                if (!Char.IsNumber(e.KeyChar))
                {

                    bool previousMinusWillBeDeleted = false;
                    int indexofMinus = this.Text.IndexOf('-');
                    if (indexofMinus != -1)
                    {
                        if ((indexofMinus >= this.SelectionStart) && (indexofMinus < this.SelectionStart + this.SelectionLength))
                            previousMinusWillBeDeleted = true;
                    }

                    #region Check If the user has entered Minus character
                    // Here we check if the user wants to enter the "-" character.
                    if (!previousMinusWillBeDeleted)
                    {
                        if (!((this.Text.IndexOf('-') == -1) && // there is no Minus character
                          (this.SelectionStart == 0) && // the cursor at the begining
                          (_minimumAllowed < 0) && // the minimum allowed accept negative values
                          (e.KeyChar == '-')))  // the character entered was a Minus character
                            e.KeyChar = Char.MinValue;
                    }
                    #endregion
                }
                #endregion

                if (_minimumAllowed <= 1)
                    #region Checkinng if the value falles within the given range
                    if (e.KeyChar != Char.MinValue)
                    {
                        // Create the string that will be displayed, and check whether it's valid or not.

                        // Remove the selected character(s).
                        string newString = this.Text.Remove(this.SelectionStart, this.SelectionLength);
                        // Insert the new character.
                        newString = newString.Insert(this.SelectionStart, e.KeyChar.ToString());
                        if (!IsAllowed(newString))
                            // the new string is not valid, cancel the whole operation.
                            e.KeyChar = Char.MinValue;
                    }
                    #endregion
            }
            base.OnKeyPress(e);
        }
    }
}
