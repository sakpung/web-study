// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using Leadtools.Annotations.WinForms;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Rendering;

namespace Leadtools.Annotations
{
   internal partial class RichTextMenu : Form
   {
      ToolStripMenuItem _backColor = null;
      ToolStripMenuItem _forColor = null;
      bool _numbering = false;

      static Color[] Colors = new Color[]{
                              Color.Black,
                              Color.Maroon,
                              Color.Green,
                              Color.Olive,
                              Color.Navy,
                              Color.Purple,
                              Color.Teal,
                              Color.Gray,
                              Color.Silver,
                              Color.Red,
                              Color.Lime,
                              Color.Yellow,
                              Color.Blue,
                              Color.Fuchsia,
                              Color.Aqua,
                              Color.White
                          };

      int [] FontSizes = {
                        8, 9, 10, 11, 12, 13,14, 
                        16, 18, 20, 22, 24,   
                        26, 28, 36, 48, 72    
                          };


      RichTextBox _richTextBox = null;
      private RichTextBox _tempRichTextBox = new RichTextBox();

      public RichTextBox RichTextBox
      {
         get { return _richTextBox; }
         set { _richTextBox = value; UpdateEditMenu(); }
      }

      private void Initialize()
      {
         InitializeComponent();
         LoadMenuResources();

         LoadToolbarResources();

         InitializeControls();

         _richTextBox.SelectionChanged += new EventHandler(_richTextBox_SelectionChanged);

         UpdateEditMenu();

         for (int i = 0; i < Colors.Length; ++i)
         {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Click += new EventHandler(item_Click);
            item.Text = Colors[i].Name;
            item.ForeColor = Colors[i];
            item.CheckOnClick = true;
            item.Tag = "ForeColor";

            _miRtfFormatTextColor.DropDownItems.Add(item);
         }

         for (int i = 0; i < Colors.Length; ++i)
         {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Click += new EventHandler(item_Click);
            item.Text = Colors[i].Name;
            item.ForeColor = Colors[i];
            item.CheckOnClick = true;
            item.Tag = "BackColor";

            _miRtfFormatBackgroundColor.DropDownItems.Add(item);
         }

         for (int i = 0; i < Colors.Length; ++i)
         {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = Colors[i].Name;
            item.Click += new EventHandler(item_Click);
            item.ForeColor = Colors[i];
            item.CheckOnClick = true;
            item.Tag = "BackColor";
            _btnBackgroundColor.DropDownItems.Add(item);
         }

         for (int i = 0; i < Colors.Length; ++i)
         {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = Colors[i].Name;
            item.Click += new EventHandler(item_Click);
            item.ForeColor = Colors[i];
            item.CheckOnClick = true;
            item.Tag = "ForeColor";

            _btnTextColor.DropDownItems.Add(item);
         }
      }

      void item_Click(object sender, EventArgs e)
      {
         ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

         if (menuItem.Tag.ToString() == "BackColor")
         {
            if (_backColor != null)
            {
               _backColor.Checked = false;
            }

            menuItem.Checked = true;
            _richTextBox.SelectionBackColor = menuItem.ForeColor;
            _backColor = menuItem;

         }
         else
         {
            if (_forColor != null)
            {
               _forColor.Checked = false;
            }

            menuItem.Checked = true;
            _richTextBox.SelectionColor = menuItem.ForeColor;
            _forColor = menuItem;
         }
      }

      /*public RichTextMenu()
      {
         Initialize();
      }*/

       public RichTextMenu(RichTextBox richTextBox)
      {
         _richTextBox = richTextBox;
         Initialize();
      }

      Bitmap CreateBitmap(string name)
      {
         string resourceName = string.Format("{0}.png", name);
         return Tools.LoadImageFromResource(typeof(Tools), "Leadtools.Annotations.WinForms.Resources.RichTextMenu", resourceName);
      }

      public void InitializeControls()
      {
         int selectedIndex = 0;
         foreach(FontFamily item in System.Drawing.FontFamily.Families)
         {
            _cmbFont.Items.Add(item.Name);
            if (_richTextBox.SelectionFont != null)
            {
               if (_richTextBox.SelectionFont.Name == item.Name)
               {
                  selectedIndex = _cmbFont.Items.IndexOf(item.Name);
               }
            }
         }

         _cmbFont.SelectedIndex = selectedIndex;

         selectedIndex = 0;
         foreach (int size in FontSizes)
         {
            _cmbFontSize.Items.Add(size);

            if (_richTextBox.SelectionFont != null)
            {
               if (_richTextBox.SelectionFont.Size == size)
               {
                  selectedIndex = _cmbFontSize.Items.IndexOf(size);
               }
            }
         }

         _cmbFontSize.SelectedIndex = selectedIndex;
      }

      public void LoadToolbarResources()
      {
         _btnBold.Image = CreateBitmap("Bold");
         _btnItalic.Image = CreateBitmap("Italic");
         _btnUnderline.Image = CreateBitmap("Underline");

         _btnTextColor.Image = CreateBitmap("TextColor");
         _btnBackgroundColor.Image = CreateBitmap("BackgroundColor");

         _btnNumbers.Image = CreateBitmap("Numbers");
         _btnBullets.Image = CreateBitmap("Bullets");
         _btnIncreaseIdent.Image = CreateBitmap("IndentRight");
         _btnDecreaseIdent.Image = CreateBitmap("IndentLeft");

         _btnRight.Image = CreateBitmap("Right");
         _btnLeft.Image = CreateBitmap("Left");
         _btnCenter.Image = CreateBitmap("Center");

         _btnBold.ToolTipText = StringManager.GetString(StringManager.Id.RtfBoldToolTip);
         _btnItalic.ToolTipText = StringManager.GetString(StringManager.Id.RtfItalicToolTip);
         _btnUnderline.ToolTipText = StringManager.GetString(StringManager.Id.RtfUnderlineToolTip);

         _btnTextColor.ToolTipText = StringManager.GetString(StringManager.Id.RtfTextColorToolTip);
         _btnBackgroundColor.ToolTipText = StringManager.GetString(StringManager.Id.RtfBackgroundColorToolTip);

         _btnNumbers.ToolTipText = StringManager.GetString(StringManager.Id.RtfNumbersToolTip);
         _btnBullets.ToolTipText = StringManager.GetString(StringManager.Id.RtfBulletsToolTip);
         _btnIncreaseIdent.ToolTipText = StringManager.GetString(StringManager.Id.RtfIndentRightToolTip);
         _btnDecreaseIdent.ToolTipText = StringManager.GetString(StringManager.Id.RtfIndentLeftToolTip);

         _btnRight.ToolTipText = StringManager.GetString(StringManager.Id.RtfRightToolTip);
         _btnLeft.ToolTipText = StringManager.GetString(StringManager.Id.RtfLeftToolTip);
         _btnCenter.ToolTipText = StringManager.GetString(StringManager.Id.RtfCenterToolTip);
      }

      public void FreeToolbarResources()
      {
         _btnBold.Image.Dispose();
         _btnItalic.Image.Dispose();
         _btnUnderline.Image.Dispose();

         _btnTextColor.Image.Dispose();
         _btnBackgroundColor.Image.Dispose();

         _btnNumbers.Image.Dispose();
         _btnBullets.Image.Dispose();
         _btnIncreaseIdent.Image.Dispose();
         _btnDecreaseIdent.Image.Dispose();

         _btnRight.Image.Dispose();
         _btnLeft.Image.Dispose();
         _btnCenter.Image.Dispose();
      }


      public void LoadMenuResources()
      {
          this.Text = StringManager.GetString(StringManager.Id.RtfCaption);
         _miRtfFile.Text = StringManager.GetString(StringManager.Id.RtfFile);
         _miRtfFileOpen.Text = StringManager.GetString(StringManager.Id.RtfFileOpen);
         _miRtfFileSave.Text = StringManager.GetString(StringManager.Id.RtfFileSave);
         _miRtfFilePrint.Text = StringManager.GetString(StringManager.Id.RtfFilePrint);
         _miRtfFileExit.Text = StringManager.GetString(StringManager.Id.RtfFileExit);
         _miRtfEdit.Text = StringManager.GetString(StringManager.Id.RtfEdit);
         _miRtfEditUndo.Text = StringManager.GetString(StringManager.Id.RtfEditUndo);
         _miRtfEditCut.Text = StringManager.GetString(StringManager.Id.RtfEditCut);
         _miRtfEditCopy.Text = StringManager.GetString(StringManager.Id.RtfEditCopy);
         _miRtfEditPaste.Text = StringManager.GetString(StringManager.Id.RtfEditPaste);
         _miRtfEditDelete.Text = StringManager.GetString(StringManager.Id.RtfEditDelete);
         _miRtfEditSelectAll.Text = StringManager.GetString(StringManager.Id.RtfEditSelectAll);
         _miRtfFormat.Text = StringManager.GetString(StringManager.Id.RtfFormat);
         _miRtfFormatFont.Text = StringManager.GetString(StringManager.Id.RtfFormatFont);
         _miRtfFormatBackgroundColor.Text = StringManager.GetString(StringManager.Id.RtfFormatBackgroundColor);
         _miRtfFormatTextColor.Text = StringManager.GetString(StringManager.Id.RtfFormatTextColor);
         _miRtfFormatBullets.Text = StringManager.GetString(StringManager.Id.RtfFormatBullets);
         _miRtfFormatNumbering.Text = StringManager.GetString(StringManager.Id.RtfFormatNumbering);
         _miRtfFormatDecreaseIndent.Text = StringManager.GetString(StringManager.Id.RtfFormatDecreaseIndent);
         _miRtfFormatIncreaseIndent.Text = StringManager.GetString(StringManager.Id.RtfFormatIncreaseIndent);
         _miRtfFormatLeft.Text = StringManager.GetString(StringManager.Id.RtfFormatLeft);
         _miRtfFormatCenter.Text = StringManager.GetString(StringManager.Id.RtfFormatCenter);
         _miRtfFormatRight.Text = StringManager.GetString(StringManager.Id.RtfFormatRight);
      }

      private void _btnBold_Click(object sender, EventArgs e)
      {
         BoldCommand();
      }

      public void ChangeFontStyle(FontStyle style, bool add)
      {
         if (style != FontStyle.Bold
            && style != FontStyle.Italic
            && style != FontStyle.Strikeout
            && style != FontStyle.Underline)
            throw new System.InvalidProgramException("Invalid style parameter to ChangeFontStyle");

         int rtb1start = _richTextBox.SelectionStart;
         int len = _richTextBox.SelectionLength;
         int rtbTempStart = 0;

         //if len <= 1 and there is a selection font then just handle and return
         if (len <= 1 && _richTextBox.SelectionFont != null)
         {
            //add or remove style 
            if (add)
               _richTextBox.SelectionFont = new Font(_richTextBox.SelectionFont, _richTextBox.SelectionFont.Style | style);
            else
               _richTextBox.SelectionFont = new Font(_richTextBox.SelectionFont, _richTextBox.SelectionFont.Style & ~style);

            return;
         }

         // Step through the selected text one char at a time	
         _tempRichTextBox.Rtf = _richTextBox.SelectedRtf;
         for (int i = 0; i < len; ++i)
         {
            _tempRichTextBox.Select(rtbTempStart + i, 1);

            //add or remove style 
            if (add)
               _tempRichTextBox.SelectionFont = new Font(_tempRichTextBox.SelectionFont, _tempRichTextBox.SelectionFont.Style | style);
            else
               _tempRichTextBox.SelectionFont = new Font(_tempRichTextBox.SelectionFont, _tempRichTextBox.SelectionFont.Style & ~style);
         }

         // Replace & reselect
         _tempRichTextBox.Select(rtbTempStart, len);
         _richTextBox.SelectedRtf = _tempRichTextBox.SelectedRtf;
         _richTextBox.Select(rtb1start, len);
         return;
      }

      public void ChangeFontNameSize(string fontName, float size)
      {
         int rtb1start = _richTextBox.SelectionStart;
         int len = _richTextBox.SelectionLength;
         int rtbTempStart = 0;

         //if len <= 1 and there is a selection font then just handle and return
         if (len <= 1 && _richTextBox.SelectionFont != null)
         {
            _richTextBox.SelectionFont = new Font(fontName, size, _richTextBox.SelectionFont.Style);

            return;
         }

         // Step through the selected text one char at a time	
         _tempRichTextBox.Rtf = _richTextBox.SelectedRtf;
         for (int i = 0; i < len; ++i)
         {
            _tempRichTextBox.Select(rtbTempStart + i, 1);

            if (_richTextBox.SelectionFont != null)
            {
               _tempRichTextBox.SelectionFont = new Font(fontName, size, _richTextBox.SelectionFont.Style);
            }
            else
            {
               _tempRichTextBox.SelectionFont = new Font(fontName, size);
            }
         }

         // Replace & reselect
         _tempRichTextBox.Select(rtbTempStart, len);
         _richTextBox.SelectedRtf = _tempRichTextBox.SelectedRtf;
         _richTextBox.Select(rtb1start, len);
         return;
      }

      private void _miRtfFileOpen_Click(object sender, EventArgs e)
      {
         using (OpenFileDialog openFileDialog = new OpenFileDialog())
         {
            openFileDialog.Filter = StringManager.GetString(StringManager.Id.RtfFilter);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
               _richTextBox.Rtf = File.ReadAllText(openFileDialog.FileName);
            }
         }
      }

      private void _miRtfFileSave_Click(object sender, EventArgs e)
      {
         using(SaveFileDialog saveFileDialog = new SaveFileDialog())
         {
            saveFileDialog.Filter = StringManager.GetString(StringManager.Id.RtfFilter);

            if(saveFileDialog.ShowDialog()==DialogResult.OK)
            {
               _richTextBox.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
            }
         }
      }

      private void _miRtfFilePrint_Click(object sender, EventArgs e)
      {
         using (PrintDocument docToPrint = new PrintDocument())
         {
            docToPrint.PrintPage += new PrintPageEventHandler(docToPrint_PrintPage);
            using (PrintDialog printDialog = new PrintDialog())
            {
               printDialog.UseEXDialog = true;
               printDialog.Document = docToPrint;

               if (printDialog.ShowDialog() == DialogResult.OK)
               {
                  docToPrint.Print();
               }
            }
         }
      }

      void docToPrint_PrintPage(object sender, PrintPageEventArgs e)
      {
         AnnRichTextObjectRenderer.Print(_richTextBox, e);
      }

      private void _miRtfFileExit_Click(object sender, EventArgs e)
      {
         Close();
      }

      private void _miRtfEdit_Click(object sender, EventArgs e)
      {
         UpdateEditMenu();
      }

      private void _miRtfEditUndo_Click(object sender, EventArgs e)
      {
         UndoCommand();
      }

      private void _miRtfEditCut_Click(object sender, EventArgs e)
      {
         CutCommand();
      }

      private void _miRtfEditCopy_Click(object sender, EventArgs e)
      {
         CopyCommand();
      }

      private void _miRtfEditPaste_Click(object sender, EventArgs e)
      {
         PasteCommand();
      }

      private void _miRtfEditDelete_Click(object sender, EventArgs e)
      {
         DeleteCommand();
      }

      private void _miRtfEditSelectAll_Click(object sender, EventArgs e)
      {
         SelectAllCommand();
      }

      private int _lastFindIndex = -1;
      void _richTextBox_SelectionChanged(object sender, EventArgs e)
      {
         _lastFindIndex = _richTextBox.SelectionStart;
      }

      private void _miRtfFormatFont_Click(object sender, EventArgs e)
      {
         FontDialog dlg = new FontDialog();
         if (dlg.ShowDialog(this) == DialogResult.OK)
         {
            _richTextBox.Font = dlg.Font;
         }
      }

      private void _miRtfFormatBackgroundColor_DropDownOpening(object sender, EventArgs e)
      {
         int index = GetColorIndex(_richTextBox.SelectionBackColor);
         foreach (ToolStripMenuItem item in _miRtfFormatBackgroundColor.DropDownItems)
         {
            item.Checked = false;
         }

         (_miRtfFormatBackgroundColor.DropDownItems[index] as ToolStripMenuItem).Checked = true;
      }

      private void _miRtfFormatTextColor_DropDownOpening(object sender, EventArgs e)
      {
         int index = GetColorIndex(_richTextBox.SelectionColor);

         foreach (ToolStripMenuItem item in _miRtfFormatTextColor.DropDownItems)
         {
            item.Checked = false;
         }

         (_miRtfFormatTextColor.DropDownItems[index] as ToolStripMenuItem).Checked = true;
      }

      private void _miRtfFormatBullets_Click(object sender, EventArgs e)
      {
         BulletsCommand();
      }

      private void _miRtfFormatNumbering_Click(object sender, EventArgs e)
      {
         NumberingCommand();
      }

      private void _miRtfFormatDecreaseIndent_Click(object sender, EventArgs e)
      {
         IndentLeft();
      }

      private void _miRtfFormatIncreaseIndent_Click(object sender, EventArgs e)
      {
         IndentRight();
      }

      private void _miRtfFormatLeft_Click(object sender, EventArgs e)
      {
         LeftCommand();
      }

      private void _miRtfFormatCenter_Click(object sender, EventArgs e)
      {
         CenterCommand();
      }

      private void _miRtfFormatRight_Click(object sender, EventArgs e)
      {
         RightCommand();
      }

      private void _btnLeft_Click(object sender, EventArgs e)
      {
         LeftCommand();
      }

      private void _btnCenter_Click(object sender, EventArgs e)
      {
         CenterCommand();
      }

      private void _btnRight_Click(object sender, EventArgs e)
      {
         RightCommand();
      }

      private void _btnItalic_Click(object sender, EventArgs e)
      {
         ItalicCommand();
      }

      private void _btnUnderline_Click(object sender, EventArgs e)
      {
         UnderlineCommand();
      }

      private void _btnBackgroundColor_DropDownOpening(object sender, EventArgs e)
      {
         int index = GetColorIndex(_richTextBox.SelectionBackColor);
         foreach (ToolStripMenuItem item in _btnBackgroundColor.DropDownItems)
         {
            item.Checked = false;
         }

         (_btnBackgroundColor.DropDownItems[index] as ToolStripMenuItem).Checked = true;
      }

      private void _btnTextColor_DropDownOpening(object sender, EventArgs e)
      {
         int index = GetColorIndex(_richTextBox.SelectionColor);

         foreach (ToolStripMenuItem item in _btnTextColor.DropDownItems)
         {
            item.Checked = false;
         }

         (_btnTextColor.DropDownItems[index] as ToolStripMenuItem).Checked = true;
      }

#region Commands

      private void LeftCommand()
      {
         _richTextBox.SelectionAlignment = HorizontalAlignment.Left;
         _miRtfFormatCenter.Checked = false;
         _miRtfFormatRight.Checked = false;
         _miRtfFormatLeft.Checked = true;

         _btnLeft.Checked = true;
         _btnCenter.Checked = false;
         _btnRight.Checked = false;
      }

      private void RightCommand()
      {
         _richTextBox.SelectionAlignment = HorizontalAlignment.Right;

         _miRtfFormatCenter.Checked = false;
         _miRtfFormatLeft.Checked = false;
         _miRtfFormatRight.Checked = true;

         _btnLeft.Checked = false;
         _btnCenter.Checked = false;
         _btnRight.Checked = true;
      }

      private void CenterCommand()
      {
         _richTextBox.SelectionAlignment = HorizontalAlignment.Center;

         _miRtfFormatLeft.Checked = false;
         _miRtfFormatCenter.Checked = true;
         _miRtfFormatRight.Checked = false;

         _btnLeft.Checked = false;
         _btnCenter.Checked = true;
         _btnRight.Checked = false;
      }

      private void BoldCommand()
      {
         ChangeFontStyle(FontStyle.Bold, _btnBold.Checked);
      }

      private void ItalicCommand()
      {
         ChangeFontStyle(FontStyle.Italic, _btnItalic.Checked);
      }

      private void UnderlineCommand()
      {
         ChangeFontStyle(FontStyle.Underline, _btnUnderline.Checked);
      }

      private void UndoCommand()
      {
         _richTextBox.Undo();
      }

      private void CutCommand()
      {
         _richTextBox.Cut();
      }

      private void CopyCommand()
      {
         _richTextBox.Copy();
      }

      private void PasteCommand()
      {
         _richTextBox.Paste();
      }

      private void DeleteCommand()
      {
         _richTextBox.Clear();
      }

      private void SelectAllCommand()
      {
         _richTextBox.SelectAll();
      }

      private void BulletsCommand()
      {
         _richTextBox.SelectionBullet = !_richTextBox.SelectionBullet;

         _miRtfFormatBullets.Checked = _richTextBox.SelectionBullet;

         _btnBullets.Checked = _richTextBox.SelectionBullet;
      }

      private void NumberingCommand()
      {
         _numbering = !_numbering;
         Win32.ParaFormat2 pf2 = new Win32.ParaFormat2();

         pf2.cbSize = Marshal.SizeOf(pf2);
         pf2.dwMask = Win32.PFM_NUMBERING | Win32.PFM_NUMBERINGSTART;

         if (_numbering)
         {
            pf2.wNumbering = 2;
            pf2.wNumberingStart = 1;
         }

         IntPtr lParam = Marshal.AllocCoTaskMem(Marshal.SizeOf(pf2));
         Marshal.StructureToPtr(pf2, lParam, false);

         SafeNativeMethods.SendMessage(_richTextBox.Handle, Win32.WM_USER + 71, new IntPtr(0),lParam);
      }

      private void IndentRight()
      {
         _richTextBox.SelectionIndent += 3;
      }

      private void IndentLeft()
      {
         _richTextBox.SelectionIndent -= 3;
      }

#endregion //Commands

      bool CanDelete
      {
         get
         {
            return _richTextBox.SelectionLength > 0;
         }
      }

      void UpdateEditMenu()
      {
         if (_richTextBox != null)
         {
            _miRtfEditUndo.Enabled = _richTextBox.CanUndo;
            _miRtfEditCut.Enabled = CanDelete;
            _miRtfEditCopy.Enabled = CanDelete;
            _miRtfEditPaste.Enabled = _richTextBox.CanPaste(DataFormats.GetFormat(DataFormats.Rtf));
            _miRtfEditDelete.Enabled = CanDelete;
         }
      }

      int GetColorIndex(Color color)
      {
         int index = 0;
         for (int i = 0; i < Colors.Length; ++i)
         {
            if (Colors[i].Equals(color))
            {
               index = i;
               break;
            }
         }

         return index;
      }

      private void _btnBullets_Click(object sender, EventArgs e)
      {
         BulletsCommand();
      }

      protected override void OnClosed(EventArgs e)
      {
         base.OnClosed(e);
      }

      private void _cmbFont_SelectedIndexChanged(object sender, EventArgs e)
      {
         float size = (_cmbFontSize.SelectedItem != null) ? (int)_cmbFontSize.SelectedItem : _richTextBox.SelectionFont.Size;
         string name = (_cmbFont.SelectedItem != null) ? (string)_cmbFont.SelectedItem : "Arial";
         ChangeFontNameSize(name, size);
      }

      private void _cmbFontSize_SelectedIndexChanged(object sender, EventArgs e)
      {
         float size = (_cmbFontSize.SelectedItem != null) ? (int)_cmbFontSize.SelectedItem : _richTextBox.SelectionFont.Size;
         string name = (_cmbFont.SelectedItem != null) ? (string)_cmbFont.SelectedItem : "Arial";

         ChangeFontNameSize(name, size);
      }

      private void _btnIncreaseIdent_Click(object sender, EventArgs e)
      {
         IndentRight();
      }

      private void _btnDecreaseIdent_Click(object sender, EventArgs e)
      {
         IndentLeft();
      }

      private void _btnNumbers_Click(object sender, EventArgs e)
      {
         NumberingCommand();
      }
   }

   internal class ToolStripEx: ToolStrip
   {
      private bool clickThrough = true;

      private const uint WM_MOUSEACTIVATE = 0x21;
      private const uint WM_LBUTTONUP = 0x0201;
      private const uint MA_ACTIVATE = 1;
      private const uint MA_ACTIVATEANDEAT = 2;
      private const uint MA_NOACTIVATE = 3;
      private const uint MA_NOACTIVATEANDEAT = 4;

      public bool ClickThrough
      {
         get
         {
            return this.clickThrough;
         }
         set
         {
            this.clickThrough = value;
         }
      }

      protected override void WndProc(ref Message m)
      {
         base.WndProc(ref m);

         if (this.clickThrough && m.Msg == WM_MOUSEACTIVATE && m.Result == (IntPtr)MA_ACTIVATEANDEAT)
         {
            m.Result = (IntPtr)MA_ACTIVATE;
         }
      }

   }
}
