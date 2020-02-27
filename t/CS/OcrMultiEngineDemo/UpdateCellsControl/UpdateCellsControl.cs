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

namespace OcrMultiEngineDemo.UpdateCellsControl
{
   public partial class UpdateCellsControl : UserControl
   {
      private IOcrEngine _ocrEngine;
      private IOcrPage _ocrPage;
      private TreeView _tvZonesList;
      private IOcrZoneCollection _zones;
      private IList<OcrZoneCell> _cells;

      public UpdateCellsControl()
      {
         InitializeComponent();
      }

      public void Activate(IOcrEngine ocrEngine, IOcrPage ocrPage, TreeView tvZonesList, IOcrZoneCollection zones, IList<OcrZoneCell> cells)
      {
         _ocrEngine = ocrEngine;
         _ocrPage = ocrPage;
         _tvZonesList = tvZonesList;
         _zones = zones;
         _cells = cells;

         // Fill the cell type combo box.
         _cmbCellType.Items.Clear();
         Array a = ocrPage.TableZoneManager.GetSupportedCellTypes();
         foreach (OcrZoneType i in a)
            _cmbCellType.Items.Add(i);

         // Fill the cell border style combo boxes.
         _cmbLeftBorderStyle.Items.Clear();
         _cmbTopBorderStyle.Items.Clear();
         _cmbRightBorderStyle.Items.Clear();
         _cmbBottomBorderStyle.Items.Clear();

         Array b = Enum.GetValues(typeof(OcrCellBorderLineStyle));
         foreach (OcrCellBorderLineStyle i in b)
         {
            _cmbLeftBorderStyle.Items.Add(i);
            _cmbTopBorderStyle.Items.Add(i);
            _cmbRightBorderStyle.Items.Add(i);
            _cmbBottomBorderStyle.Items.Add(i);
         }

         UpdateUIControls();
      }

      public void CellToControls(OcrZoneCell cell)
      {
         // Cell Type
         _cmbCellType.SelectedItem = cell.CellType;

         // Convert the cell bounds to pixels
         LeadRect bounds = cell.Bounds;
         _tbLeft.Text = bounds.X.ToString();
         _tbTop.Text = bounds.Y.ToString();
         _tbWidth.Text = bounds.Width.ToString();
         _tbHeight.Text = bounds.Height.ToString();

         // Border Width
         _numLeftBorderWidth.Value = (Decimal)cell.LeftBorderWidth;
         _numTopBorderWidth.Value = (Decimal)cell.TopBorderWidth;
         _numRightBorderWidth.Value = (Decimal)cell.RightBorderWidth;
         _numBottomBorderWidth.Value = (Decimal)cell.BottomBorderWidth;

         // Border Style
         _cmbLeftBorderStyle.SelectedItem = cell.LeftBorderStyle;
         _cmbTopBorderStyle.SelectedItem = cell.TopBorderStyle;
         _cmbRightBorderStyle.SelectedItem = cell.RightBorderStyle;
         _cmbBottomBorderStyle.SelectedItem = cell.BottomBorderStyle;

         // Border Colors
         _btnLeftBorderColor.BackColor = MainForm.ConvertColor(cell.LeftBorderColor);
         _btnTopBorderColor.BackColor = MainForm.ConvertColor(cell.TopBorderColor);
         _btnRightBorderColor.BackColor = MainForm.ConvertColor(cell.RightBorderColor);
         _btnBottomBorderColor.BackColor = MainForm.ConvertColor(cell.BottomBorderColor);
      }

      private void _cmbCellType_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_tvZonesList.SelectedNode.Tag.GetType() == typeof(OcrZoneCell))
         {
            OcrZoneCell cell = (OcrZoneCell)_tvZonesList.SelectedNode.Tag;
            int index = _cells.IndexOf(cell);
            if (index >= 0)
               _cells[index].CellType = (OcrZoneType)_cmbCellType.SelectedItem;
         }
      }

      private void ResetBoundsValue(TextBox tb, LeadRect bounds)
      {
         // An error occurred while entering the bounds value
         // Reset to original value
         if (tb == _tbLeft)
            tb.Text = bounds.X.ToString();
         else if (tb == _tbTop)
            tb.Text = bounds.Y.ToString();
         else if (tb == _tbWidth)
            tb.Text = bounds.Width.ToString();
         else if (tb == _tbHeight)
            tb.Text = bounds.Height.ToString();
      }

      private void _widthNumericBox_Leave(object sender, EventArgs e)
      {
         NumericUpDown numCtrl = sender as NumericUpDown;

         if (_tvZonesList.SelectedNode.Tag.GetType() == typeof(OcrZoneCell))
         {
            OcrZoneCell cell = (OcrZoneCell)_tvZonesList.SelectedNode.Tag;
            int index = _cells.IndexOf(cell);
            if (index >= 0)
            {
               if (numCtrl == _numLeftBorderWidth)
                  _cells[index].LeftBorderWidth = (int)numCtrl.Value;
               else if (numCtrl == _numTopBorderWidth)
                  _cells[index].TopBorderWidth = (int)numCtrl.Value;
               else if (numCtrl == _numRightBorderWidth)
                  _cells[index].RightBorderWidth = (int)numCtrl.Value;
               else if (numCtrl == _numBottomBorderWidth)
                  _cells[index].BottomBorderWidth = (int)numCtrl.Value;
            }
         }
      }

      private void _cmbBorderStyle_SelectedIndexChanged(object sender, EventArgs e)
      {
         ComboBox combo = sender as ComboBox;

         if (_tvZonesList.SelectedNode.Tag.GetType() == typeof(OcrZoneCell))
         {
            OcrZoneCell cell = (OcrZoneCell)_tvZonesList.SelectedNode.Tag;
            int index = _cells.IndexOf(cell);
            if (index >= 0)
            {
               if (combo == _cmbLeftBorderStyle)
               {
                  _cells[index].LeftBorderStyle = (OcrCellBorderLineStyle)combo.SelectedItem;
                  if (combo.Text == "None")
                  {
                     _numLeftBorderWidth.Value = 0;
                     cell.LeftBorderWidth = 0;
                  }
                  else
                  {
                     if (_numLeftBorderWidth.Value == 0)
                     {
                        _numLeftBorderWidth.Value = 1;
                        cell.LeftBorderWidth = 1;
                     }
                  }
               }
               else if (combo == _cmbTopBorderStyle)
               {
                  _cells[index].TopBorderStyle = (OcrCellBorderLineStyle)combo.SelectedItem;
                  if (combo.Text == "None")
                  {
                     _numTopBorderWidth.Value = 0;
                     cell.TopBorderWidth = 0;
                  }
                  else
                  {
                     if (_numTopBorderWidth.Value == 0)
                     {
                        _numTopBorderWidth.Value = 1;
                        cell.TopBorderWidth = 1;
                     }
                  }
               }
               else if (combo == _cmbRightBorderStyle)
               {
                  _cells[index].RightBorderStyle = (OcrCellBorderLineStyle)combo.SelectedItem;
                  if (combo.Text == "None")
                  {
                     _numRightBorderWidth.Value = 0;
                     cell.RightBorderWidth = 0;
                  }
                  else
                  {
                     if (_numRightBorderWidth.Value == 0)
                     {
                        _numRightBorderWidth.Value = 1;
                        cell.RightBorderWidth = 1;
                     }
                  }
               }
               else if (combo == _cmbBottomBorderStyle)
               {
                  _cells[index].BottomBorderStyle = (OcrCellBorderLineStyle)combo.SelectedItem;
                  if (combo.Text == "None")
                  {
                     _numBottomBorderWidth.Value = 0;
                     cell.BottomBorderWidth = 0;
                  }
                  else
                  {
                     if (_numBottomBorderWidth.Value == 0)
                     {
                        _numBottomBorderWidth.Value = 1;
                        cell.BottomBorderWidth = 1;
                     }
                  }
               }

               _tvZonesList.SelectedNode.Tag = cell;
            }

            UpdateUIControls();
         }
      }

      private void UpdateUIControls()
      {
         // Disable the border color and border width controls for the border that has the "None" style
         //_lblLeftBorderColor.Enabled = _cmbLeftBorderStyle.Text != "None";
         //_btnLeftBorderColor.Enabled = _cmbLeftBorderStyle.Text != "None";
         //_lblLeftBorderWidth.Enabled = _cmbLeftBorderStyle.Text != "None";
         //_numLeftBorderWidth.Enabled = _cmbLeftBorderStyle.Text != "None";

         //_lblTopBorderColor.Enabled = _cmbTopBorderStyle.Text != "None";
         //_btnTopBorderColor.Enabled = _cmbTopBorderStyle.Text != "None";
         //_lblTopBorderWidth.Enabled = _cmbTopBorderStyle.Text != "None";
         //_numTopBorderWidth.Enabled = _cmbTopBorderStyle.Text != "None";

         //_lblRightBorderColor.Enabled = _cmbRightBorderStyle.Text != "None";
         //_btnRightBorderColor.Enabled = _cmbRightBorderStyle.Text != "None";
         //_lblRightBorderWidth.Enabled = _cmbRightBorderStyle.Text != "None";
         //_numRightBorderWidth.Enabled = _cmbRightBorderStyle.Text != "None";

         //_lblBottomBorderColor.Enabled = _cmbBottomBorderStyle.Text != "None";
         //_btnBottomBorderColor.Enabled = _cmbBottomBorderStyle.Text != "None";
         //_lblBottomBorderWidth.Enabled = _cmbBottomBorderStyle.Text != "None";
         //_numBottomBorderWidth.Enabled = _cmbBottomBorderStyle.Text != "None";
      }

      private void _btnLeftBorderColor_Click(object sender, EventArgs e)
      {
         using (ColorDialog dlg = new ColorDialog())
         {
            dlg.Color = _btnLeftBorderColor.BackColor;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _btnLeftBorderColor.BackColor = dlg.Color;
               if (_tvZonesList.SelectedNode.Tag.GetType() == typeof(OcrZoneCell))
               {
                  OcrZoneCell cell = (OcrZoneCell)_tvZonesList.SelectedNode.Tag;
                  int index = _cells.IndexOf(cell);
                  if (index >= 0)
                     _cells[index].LeftBorderColor = MainForm.ConvertColor(dlg.Color);
               }
            }
         }
      }

      private void _btnTopBorderColor_Click(object sender, EventArgs e)
      {
         using (ColorDialog dlg = new ColorDialog())
         {
            dlg.Color = _btnTopBorderColor.BackColor;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _btnTopBorderColor.BackColor = dlg.Color;
               if (_tvZonesList.SelectedNode.Tag.GetType() == typeof(OcrZoneCell))
               {
                  OcrZoneCell cell = (OcrZoneCell)_tvZonesList.SelectedNode.Tag;
                  int index = _cells.IndexOf(cell);
                  if (index >= 0)
                     _cells[index].TopBorderColor = MainForm.ConvertColor(dlg.Color);
               }
            }
         }
      }

      private void _btnRightBorderColor_Click(object sender, EventArgs e)
      {
         using (ColorDialog dlg = new ColorDialog())
         {
            dlg.Color = _btnRightBorderColor.BackColor;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _btnRightBorderColor.BackColor = dlg.Color;
               if (_tvZonesList.SelectedNode.Tag.GetType() == typeof(OcrZoneCell))
               {
                  OcrZoneCell cell = (OcrZoneCell)_tvZonesList.SelectedNode.Tag;
                  int index = _cells.IndexOf(cell);
                  if (index >= 0)
                     _cells[index].RightBorderColor = MainForm.ConvertColor(dlg.Color);
               }
            }
         }
      }

      private void _btnBottomBorderColor_Click(object sender, EventArgs e)
      {
         using (ColorDialog dlg = new ColorDialog())
         {
            dlg.Color = _btnBottomBorderColor.BackColor;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
               _btnBottomBorderColor.BackColor = dlg.Color;
               if (_tvZonesList.SelectedNode.Tag.GetType() == typeof(OcrZoneCell))
               {
                  OcrZoneCell cell = (OcrZoneCell)_tvZonesList.SelectedNode.Tag;
                  int index = _cells.IndexOf(cell);
                  if (index >= 0)
                     _cells[index].BottomBorderColor = MainForm.ConvertColor(dlg.Color);
               }
            }
         }
      }
   }
}
