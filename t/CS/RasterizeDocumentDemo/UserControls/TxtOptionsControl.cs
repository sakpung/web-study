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

using Leadtools.Demos;
using Leadtools;
using Leadtools.Codecs;

namespace RasterizeDocumentDemo.UserControls
{
   public partial class TxtOptionsControl : UserControl, IOptionsUserControl
   {
      public TxtOptionsControl()
      {
         InitializeComponent();
      }

      private int _fontSize;

      /// <summary>
      /// Called by the owner to initialize
      /// </summary>
      public void SetData(RasterCodecs rasterCodecsInstance)
      {
         _fontSizeComboBox.PreviewKeyDown += new PreviewKeyDownEventHandler(_textBox_PreviewKeyDown);
         _fontSizeComboBox.LostFocus += new EventHandler(_fontSizeComboBox_LostFocus);

         FontFamily[] fontFamilies = FontFamily.Families;

         foreach(FontFamily ff in fontFamilies)
         {
            _fontNameComboBox.Items.Add(ff.Name);
         }

         // Set the state of the controls

         CodecsTxtLoadOptions txtLoadOptions = rasterCodecsInstance.Options.Txt.Load;

         _enabledCheckBox.Checked = txtLoadOptions.Enabled;
         _useSystenLocaleCheckBox.Checked = txtLoadOptions.UseSystemLocale;

         _fontSize = txtLoadOptions.FontSize;
         _fontNameComboBox.Text = txtLoadOptions.FaceName;
         _fontSizeComboBox.Text = _fontSize.ToString();
         _fontBoldCheckBox.Checked = txtLoadOptions.Bold;
         _fontItalicCheckBox.Checked = txtLoadOptions.Italic;
         _fontUnderlineCheckBox.Checked = txtLoadOptions.Underline;
         _fontStrikethroughCheckBox.Checked = txtLoadOptions.Strikethrough;

         _fontColorPanel.BackColor = Converters.ToGdiPlusColor(txtLoadOptions.FontColor);
         _backColorPanel.BackColor = Converters.ToGdiPlusColor(txtLoadOptions.BackColor);
         _highlightColorPanel.BackColor = Converters.ToGdiPlusColor(txtLoadOptions.Highlight);
      }

      /// <summary>
      /// Called by the owner to get the data
      /// </summary>
      public bool GetData(RasterCodecs rasterCodecsInstance)
      {
         if(!GetFontSize())
         {
            return false;
         }

         CodecsTxtLoadOptions txtLoadOptions = rasterCodecsInstance.Options.Txt.Load;

         // Get the TXT load settings

         txtLoadOptions.Enabled = _enabledCheckBox.Checked;
         txtLoadOptions.UseSystemLocale = _useSystenLocaleCheckBox.Checked;

         txtLoadOptions.FaceName = _fontNameComboBox.Text;
         txtLoadOptions.FontSize = _fontSize;

         txtLoadOptions.Bold = _fontBoldCheckBox.Checked;
         txtLoadOptions.Italic = _fontItalicCheckBox.Checked;
         txtLoadOptions.Underline = _fontUnderlineCheckBox.Checked;
         txtLoadOptions.Strikethrough = _fontStrikethroughCheckBox.Checked;

         txtLoadOptions.FontColor = Converters.FromGdiPlusColor(_fontColorPanel.BackColor);
         txtLoadOptions.BackColor = Converters.FromGdiPlusColor(_backColorPanel.BackColor);
         txtLoadOptions.Highlight = Converters.FromGdiPlusColor(_highlightColorPanel.BackColor);

         return true;
      }

      private void _textBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
      {
         if(e.KeyCode == Keys.Enter && e.Modifiers == Keys.None)
         {
            e.IsInputKey = true;
         }
      }

      private void _fontSizeComboBox_LostFocus(object sender, EventArgs e)
      {
         _fontSizeComboBox.Text = _fontSize.ToString();
      }

      private void _fontSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
      {
         GetFontSize();
      }

      private void _fontSizeComboBox_KeyPress(object sender, KeyPressEventArgs e)
      {
         if(e.KeyChar == (char)Keys.Return)
         {
            // User has pressed enter, get the new resolution

            if(GetFontSize())
            {
               GetNextControl(sender as Control, true).Focus();
            }
         }
      }

      private bool GetFontSize()
      {
         // Check the new value
         int fontSize;

         const int minFontSize = 1;
         const int maxFontSize = 200;

         string errorMessage = string.Format("Font size must be a value between {0} and {1}", minFontSize, maxFontSize);

         if(!int.TryParse(_fontSizeComboBox.Text, out fontSize))
         {
            Messager.ShowWarning(this, errorMessage);
            _fontSizeComboBox.Focus();
            return false;
         }

         if(fontSize < minFontSize || fontSize > maxFontSize)
         {
            Messager.ShowWarning(this, errorMessage);
            _fontSizeComboBox.Focus();
            return false;
         }

         _fontSize = fontSize;
         return true;
      }

      private void _fontColorButton_Click(object sender, EventArgs e)
      {
         using(ColorDialog dlg = new ColorDialog())
         {
            dlg.Color = _fontColorPanel.BackColor;
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _fontColorPanel.BackColor = dlg.Color;
            }
         }
      }

      private void _backColorButton_Click(object sender, EventArgs e)
      {
         using(ColorDialog dlg = new ColorDialog())
         {
            dlg.Color = _backColorPanel.BackColor;
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _backColorPanel.BackColor = dlg.Color;
            }
         }
      }

      private void _highlightColorButton_Click(object sender, EventArgs e)
      {
         using(ColorDialog dlg = new ColorDialog())
         {
            dlg.Color = _highlightColorPanel.BackColor;
            if(dlg.ShowDialog(this) == DialogResult.OK)
            {
               _highlightColorPanel.BackColor = dlg.Color;
            }
         }
      }

      private void _resetToDefaultsButton_Click(object sender, EventArgs e)
      {
         _enabledCheckBox.Checked = false;
         _useSystenLocaleCheckBox.Checked = false;

         _fontSize = 12;
         _fontNameComboBox.Text = "Courier New";
         _fontSizeComboBox.Text = _fontSize.ToString();
         _fontBoldCheckBox.Checked = false;
         _fontItalicCheckBox.Checked = false;
         _fontUnderlineCheckBox.Checked = false;
         _fontStrikethroughCheckBox.Checked = false;

         _fontColorPanel.BackColor = Color.Black;
         _backColorPanel.BackColor = Color.White;
         _highlightColorPanel.BackColor = Color.White;
      }
   }
}
