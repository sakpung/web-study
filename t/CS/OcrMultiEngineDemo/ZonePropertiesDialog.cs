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
using Leadtools.Demos;
using Leadtools.Ocr;

namespace OcrMultiEngineDemo
{
   public partial class ZonePropertiesDialog : Form
   {
      private IOcrEngine _ocrEngine;
      private IOcrPage _ocrPage;
      private int _newZoneCount;

      private OcrMultiEngineDemo.UpdateZonesControl.UpdateZonesControl _updateZonesControl;

      private OcrMultiEngineDemo.UpdateCellsControl.UpdateCellsControl _updateCellsControl;

      private OcrMultiEngineDemo.ViewerControl.ViewerControl _viewerControl;

      public ZonePropertiesDialog(IOcrEngine ocrEngine, IOcrPage ocrPage, OcrMultiEngineDemo.ViewerControl.ViewerControl viewerControl, int selectedZoneIndex)
      {
         InitializeComponent();

         _ocrEngine = ocrEngine;
         _ocrPage = ocrPage;
         _viewerControl = viewerControl;

         // Initialize the zones list
         for (int i = 0; i < _ocrPage.Zones.Count; i++)
         {
            TreeNode addedZone = _tvZonesList.Nodes.Add(DemosGlobalization.GetResxString(GetType(), "Resx_Zone") + (i + 1).ToString());
            addedZone.Tag = i;

            OcrZoneCell[] cells = null;

            cells = _ocrPage.Zones.GetZoneCells(_ocrPage.Zones[i]);

            if (_ocrPage.TableZoneManager != null && cells != null && cells.Length > 0)
            {
               for (int j = 0; j < cells.Length; j++)
               {
                  TreeNode addedCell = addedZone.Nodes.Add(DemosGlobalization.GetResxString(GetType(), "Resx_Cell") + (j + 1).ToString());
                  addedCell.Tag = cells[j];
               }
            }
         }

         if (_tvZonesList.Nodes.Count > 0)
            _tvZonesList.SelectedNode = (selectedZoneIndex >= 0) ? _tvZonesList.Nodes[selectedZoneIndex] : _tvZonesList.Nodes[0];

         _updateZonesControl = new OcrMultiEngineDemo.UpdateZonesControl.UpdateZonesControl(_viewerControl);
         _updateZonesControl.Action += new EventHandler<ActionEventArgs>(_updateZonesControl_Action);
         _pnlContainer.Controls.Add(_updateZonesControl);

         _updateCellsControl = new OcrMultiEngineDemo.UpdateCellsControl.UpdateCellsControl();
         _pnlContainer.Controls.Add(_updateCellsControl);

         _pnlContainer.Controls["UpdateCellsControl"].Visible = false;

         _updateZonesControl.Activate(ocrEngine, ocrPage, _tvZonesList, _ocrPage.Zones);
         _tvZonesList.Select();
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
         _btnDeleteZone.Enabled = (_tvZonesList.SelectedNode != null) && (_tvZonesList.SelectedNode.Tag.GetType() == typeof(int));
         _btnClearZones.Enabled = _tvZonesList.Nodes.Count > 0;

         // Cells Controls
         _btnDetectCells.Enabled = false;
         if (_ocrPage.Zones.Count > 0)
         {
            int zoneIndex = -1;
            if (_tvZonesList.SelectedNode != null)
            {
               if (_tvZonesList.SelectedNode.Parent == null)
                  zoneIndex = (int)_tvZonesList.SelectedNode.Tag;
               else
                  zoneIndex = (int)_tvZonesList.SelectedNode.Parent.Tag;

               if (zoneIndex >= 0)
               {
                  OcrZone zone = _ocrPage.Zones[zoneIndex];
                  _btnDetectCells.Enabled = (zone.ZoneType == OcrZoneType.Table) && (_tvZonesList.SelectedNode.Tag.GetType() == typeof(int));
               }
            }
         }

         _btnClearCells.Enabled = (_tvZonesList.SelectedNode != null) && (_tvZonesList.SelectedNode.Tag.GetType() == typeof(int)) && (_tvZonesList.SelectedNode.Nodes.Count > 0);

         // Only show the cells manipulation controls in case of OmniPage engines only (Professional and Arabic engines)
         _cellsGroupBox.Visible = (_ocrEngine.EngineType == OcrEngineType.OmniPage || _ocrEngine.EngineType == OcrEngineType.OmniPageArabic);

      }

      private void _tvZonesList_AfterSelect(object sender, TreeViewEventArgs e)
      {
         int index = 0;
         if (_tvZonesList.SelectedNode.Tag.GetType() == typeof(int))
         {
            if (_pnlContainer.Controls["UpdateZonesControl"].Visible == false)
            {
               _pnlContainer.Controls["UpdateCellsControl"].Visible = false;
               _pnlContainer.Controls["UpdateZonesControl"].Visible = true;

               _updateZonesControl.Activate(_ocrEngine, _ocrPage, _tvZonesList, _ocrPage.Zones);
            }

            index = (_tvZonesList.SelectedNode != null) ? (int)_tvZonesList.SelectedNode.Tag : -1;
            if (index >= 0)
               _updateZonesControl.ZoneToControls(index);
         }
         else
         {
            OcrZoneCell[] cells = null;

            cells = _ocrPage.Zones.GetZoneCells(_ocrPage.Zones[(int)_tvZonesList.SelectedNode.Parent.Tag]);

            if (_pnlContainer.Controls["UpdateCellsControl"].Visible == false)
            {
               _pnlContainer.Controls["UpdateZonesControl"].Visible = false;
               _pnlContainer.Controls["UpdateCellsControl"].Visible = true;

               _updateCellsControl.Activate(_ocrEngine, _ocrPage, _tvZonesList, _ocrPage.Zones, cells);
            }

            OcrZoneCell cell = (OcrZoneCell)_tvZonesList.SelectedNode.Tag;
            _updateCellsControl.CellToControls(cell);
         }

         _updateZonesControl.UpdateUIState();
         UpdateUIState();
      }

      private void _btnAddZone_Click(object sender, EventArgs e)
      {
         // Add a new zone
         OcrZone zone = OcrTypeManager.CreateDefaultOcrZone();
         zone.Bounds = new LeadRect(0, 0, 1, 1);
         _ocrPage.Zones.Add(zone);

         TreeNode addedZone = _tvZonesList.Nodes.Add(DemosGlobalization.GetResxString(GetType(), "Resx_NewZone") + (_newZoneCount + 1).ToString());
         addedZone.Tag = _ocrPage.Zones.Count - 1;
         _tvZonesList.SelectedNode = addedZone;

         _newZoneCount++;

         _updateZonesControl.UpdateUIState();
         UpdateUIState();
      }

      private void UpdateZonesIndices()
      {
         int index = 0;
         foreach (TreeNode parentNode in _tvZonesList.Nodes)
         {
            EnumerateChildNodes(parentNode, ref index);
         }
      }

      private void EnumerateChildNodes(TreeNode parentNode, ref int index)
      {
         if (parentNode.Tag.GetType() == typeof(int))
         {
            parentNode.Tag = index;
            index++;
         }

         foreach (TreeNode node in parentNode.Nodes)
         {
            EnumerateChildNodes(node, ref index);
         }
      }

      private void _btnDeleteZone_Click(object sender, EventArgs e)
      {
         int selectedZoneIndex = (int)_tvZonesList.SelectedNode.Tag;
         _ocrPage.Zones.RemoveAt(selectedZoneIndex);

         _tvZonesList.AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(this._tvZonesList_AfterSelect);
         _tvZonesList.Nodes.Remove(_tvZonesList.SelectedNode);
         _tvZonesList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this._tvZonesList_AfterSelect);

         _updateZonesControl.UpdateUIState();
         UpdateZonesIndices();
         UpdateUIState();
         _tvZonesList.Focus();

         TreeNode selectedNode = _tvZonesList.SelectedNode;
         _tvZonesList.SelectedNode = null;
         _tvZonesList.SelectedNode = selectedNode;
      }

      private void _btnClearZones_Click(object sender, EventArgs e)
      {
         // Delete all the zones
         _tvZonesList.Nodes.Clear();
         _ocrPage.Zones.Clear();

         _updateZonesControl.Activate(_ocrEngine, _ocrPage, _tvZonesList, _ocrPage.Zones);

         _updateZonesControl.ZoneToControls(-1);
         _updateZonesControl.UpdateUIState();
         UpdateUIState();
      }

      private void _btnDetectCells_Click(object sender, EventArgs e)
      {
         int selectedZoneIndex = (int)_tvZonesList.SelectedNode.Tag;

         try
         {
            _ocrPage.TableZoneManager.AutoDetectCells(selectedZoneIndex);
         }
         catch (Exception /*ex*/)
         {
         }

         OcrZoneCell[] cells = null;

         cells = _ocrPage.Zones.GetZoneCells(_ocrPage.Zones[selectedZoneIndex]);

         if (cells != null && cells.Length > 0)
         {
            _tvZonesList.SelectedNode.Nodes.Clear();
            for (int i = 0; i < cells.Length; i++)
            {
               TreeNode addedNode = _tvZonesList.SelectedNode.Nodes.Add(DemosGlobalization.GetResxString(GetType(), "Resx_Cell") + (i + 1).ToString());
               addedNode.Tag = cells[i];
            }

            _tvZonesList.SelectedNode.Expand();
            _viewerControl.ZonesUpdated();
            UpdateUIState();
         }

         _tvZonesList.Focus();
      }

      private void _btnClearCells_Click(object sender, EventArgs e)
      {
         _tvZonesList.SelectedNode.Nodes.Clear();
         _viewerControl.ClearZoneCells((int)_tvZonesList.SelectedNode.Tag);

         _tvZonesList.Focus();
         UpdateUIState();
      }

      private void _okButton_Click(object sender, EventArgs e)
      {
         _okButton.Focus();

         // Force checking the LostFocus events before proceed with this code in order to accept the user 
         // Input when he/she press enter in any of the edit boxes.
         Application.DoEvents();

         // The ITableManager.UpdateCells is not available in v19 or later since calling IOcrZoneCollection.SetZoneCells will do this.
      }
   }
}
