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

using Leadtools;
using Leadtools.Ocr;
using OcrDemo.UpdateZonesControl;

namespace OcrDemo
{
   public partial class ZonePropertiesDialog : Form
   {
      private IOcrEngine _ocrEngine;
      private IOcrPage _ocrPage;
      private int _newZoneCount;

      private OcrDemo.UpdateZonesControl.UpdateZonesControl _updateZonesControl;
      private OcrDemo.ViewerControl.ViewerControl _viewerControl;

      public ZonePropertiesDialog(IOcrEngine ocrEngine, IOcrPage ocrPage, OcrDemo.ViewerControl.ViewerControl viewerControl, int selectedZoneIndex)
      {
         InitializeComponent();

         _ocrEngine = ocrEngine;
         _ocrPage = ocrPage;
         _viewerControl = viewerControl;
         _newZoneCount = 0;

         _updateZonesControl = new OcrDemo.UpdateZonesControl.UpdateZonesControl(_viewerControl);
         _updateZonesControl.Action += new EventHandler<ActionEventArgs>(_updateZonesControl_Action);
         _pnlContainer.Controls.Add(_updateZonesControl);

         // Initialize the zones list
         _lbZonesList.SelectedIndexChanged -= new System.EventHandler(this._lbZonesList_SelectedIndexChanged);
         for (int i = 0; i < _ocrPage.Zones.Count; i++)
         {
            _lbZonesList.Items.Add(new ZoneItem("Zone", i));
         }
         _lbZonesList.SelectedIndexChanged += new System.EventHandler(this._lbZonesList_SelectedIndexChanged);

         _updateZonesControl.Activate(ocrEngine, ocrPage, _lbZonesList, _ocrPage.Zones);

         if (_lbZonesList.Items.Count > 0)
            _lbZonesList.SelectedIndex = (selectedZoneIndex >= 0) ? selectedZoneIndex : 0;

         _lbZonesList.Select();
         UpdateUIState();
      }

      void _updateZonesControl_Action(object sender, ActionEventArgs e)
      {
         switch (e.Action)
         {
            case "ZonePropertiesChanged":
               UpdateUIState();
               break;
         }
      }

      private void UpdateUIState()
      {
         // Zones controls
         _btnDeleteZone.Enabled = _lbZonesList.SelectedIndex != -1;
         _btnClearZones.Enabled = _lbZonesList.Items.Count > 0;
         _btnInvertSelection.Enabled = _lbZonesList.Items.Count > 1 && _lbZonesList.SelectedItems.Count > 0;
      }

      private void _lbZonesList_SelectedIndexChanged(object sender, EventArgs e)
      {
         int index = 0;
         if (_lbZonesList.SelectedIndex != -1)
         {
            index = (_lbZonesList.SelectedItem != null) ? _lbZonesList.SelectedIndex : -1;
            if (index >= 0)
               _updateZonesControl.ZoneToControls(index);
         }

         _updateZonesControl.UpdateUIState();
         UpdateUIState();
      }

      private void _btnAddZone_Click(object sender, EventArgs e)
      {
         // Add a new zone
         OcrZone zone = new OcrZone();
         zone.Bounds = new LeadRect(0, 0, 1, 1);
         _ocrPage.Zones.Add(zone);

         _lbZonesList.Items.Add(new ZoneItem("New zone", _newZoneCount));
         _newZoneCount++;

         _lbZonesList.ClearSelected();
         _lbZonesList.SelectedIndex = _lbZonesList.Items.Count - 1;
         _updateZonesControl.UpdateUIState();
         UpdateUIState();
      }

      private void _btnDeleteZone_Click(object sender, EventArgs e)
      {
         _lbZonesList.SelectedIndexChanged -= new System.EventHandler(this._lbZonesList_SelectedIndexChanged);

         int selectedItem = (_lbZonesList.SelectedItems.Count > 0) ? _lbZonesList.SelectedIndices[0] : 0;
         for (int i = _lbZonesList.SelectedItems.Count - 1; i >= 0; i--)
         {
            _ocrPage.Zones.RemoveAt(_lbZonesList.SelectedIndices[i]);
            _lbZonesList.Items.RemoveAt(_lbZonesList.SelectedIndices[i]);
         }

         _lbZonesList.SelectedIndexChanged += new System.EventHandler(this._lbZonesList_SelectedIndexChanged);

         _lbZonesList.SelectedIndex = (selectedItem >= _lbZonesList.Items.Count) ? _lbZonesList.Items.Count - 1 : selectedItem;
         _updateZonesControl.UpdateUIState();
         UpdateUIState();
         _lbZonesList.Focus();
      }

      private void _btnClearZones_Click(object sender, EventArgs e)
      {
         // Delete all the zones
         _lbZonesList.Items.Clear();
         _ocrPage.Zones.Clear();
         _newZoneCount = 0;

         _updateZonesControl.ZoneToControls(-1);
         _updateZonesControl.UpdateUIState();
         UpdateUIState();
      }

      private void _btnInvertSelection_Click(object sender, EventArgs e)
      {
         if(_lbZonesList.SelectedIndices.Count > 0)
         {
            List<int> selectedIndices = new List<int>();
            foreach (int index in _lbZonesList.SelectedIndices)
            {
               selectedIndices.Add(index);
            }

            for (int i = 0; i < _lbZonesList.Items.Count; i++)
            {
                _lbZonesList.SetSelected(i, true);
            }

            foreach (int index in selectedIndices)
            {
               _lbZonesList.SetSelected(index, false);
            }
         }
      }
   }
}
