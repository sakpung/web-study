// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Annotations.Engine;
using System.Windows.Forms;
using Leadtools.Annotations.Automation;
using Leadtools.Annotations.WinForms;
using Leadtools;

namespace AnnotationsLayersDemo
{
   public class CheckBoxTreeView : TreeView
   {
      public CheckBoxTreeView()
      {
         this.CheckBoxes = true;
      }

      protected override void WndProc(ref Message m)
      {
         // Ignore WM_LBUTTONDBLCLK
         const int WM_LBUTTONDBLCLK = 0x203;
         if (m.Msg == WM_LBUTTONDBLCLK)
            m.Result = IntPtr.Zero;
         else
            base.WndProc(ref m);
      }
   }

   internal class LayerMenuItem : MenuItem
   {
      private int _id;

      internal LayerMenuItem(int id, string text) :
         base(text)
      {
         _id = id;
         RadioCheck = true;
      }

      public int Id
      {
         get { return _id; }
      }
   }

   public class LayerContextMenu : ContextMenu
   {
      public const int AddLayer = -1;
      public const int DeleteLayer = -2;
      public const int Separator1Id = -3;
      public const int BringToFrontId = -4;
      public const int SendToBackId = -5;
      public const int BringToFirstId = -6;
      public const int SendToLastId = -7;

      public const string SeparatorMenuItem = "-";


      public const int LastId = -15;
      //const int UseId = 0;

      private LayerNode _layerNode;
      AnnAutomation _automation = null;


      public void Attach(LayerNode layerNode, AnnAutomation automation)
      {
         _layerNode = layerNode;
         _automation = automation;
      }

      public void Detach()
      {
         _layerNode = null;
         _automation = null;
      }

      public LayerContextMenu()
      {
         MenuItems.Add(new LayerMenuItem(AddLayer, "Add Layer"));
         MenuItems.Add(new LayerMenuItem(DeleteLayer, "Delete Layer"));
         MenuItems.Add(new LayerMenuItem(Separator1Id, SeparatorMenuItem));
         MenuItems.Add(new LayerMenuItem(SendToBackId, StringManager.GetString(StringManager.Id.SendToBackContextMenu)));
         MenuItems.Add(new LayerMenuItem(BringToFirstId, StringManager.GetString(StringManager.Id.BringToFirstContextMenu)));
         MenuItems.Add(new LayerMenuItem(SendToLastId, StringManager.GetString(StringManager.Id.SendToLastContextMenu)));
         MenuItems.Add(new LayerMenuItem(BringToFrontId, StringManager.GetString(StringManager.Id.BringToFrontContextMenu)));

         foreach (MenuItem i in MenuItems)
         {
            if (string.Compare(i.Text, SeparatorMenuItem) != 0)
               i.Click += new EventHandler(menuItem_Click);
         }
      }

      public virtual LayerNode Layer
      {
         get { return _layerNode; }
      }

      internal LayerMenuItem GetMenuItem(int id)
      {
         foreach (MenuItem i in MenuItems)
         {
            if (i is LayerMenuItem)
            {
               LayerMenuItem mi = i as LayerMenuItem;
               if (mi.Id == id)
                  return mi;
            }
         }

         return null;
      }

      protected override void OnPopup(EventArgs e)
      {
         AnnLayer parentLayer = _layerNode.Layer.Parent;
         bool isContainer = _layerNode.Tag != null && string.Compare((string)_layerNode.Tag, "Container") == 0;

         LayerMenuItem mi = GetMenuItem(DeleteLayer);
         if (mi != null) mi.Enabled = !isContainer;

         mi = GetMenuItem(BringToFrontId);
         if (mi != null) mi.Enabled = _automation.CanBringLayerToFront;

         mi = GetMenuItem(SendToBackId);
         if (mi != null) mi.Enabled = _automation.CanSendLayerToBack;

         mi = GetMenuItem(BringToFirstId);
         if (mi != null) mi.Enabled = _automation.CanBringLayerToFirst;

         mi = GetMenuItem(SendToLastId);
         if (mi != null) mi.Enabled = _automation.CanSendLayerToLast;

         base.OnPopup(e);
      }

      private void menuItem_Click(object sender, EventArgs e)
      {
         if (_layerNode == null)
            return;

         LayerMenuItem mi = sender as LayerMenuItem;
         if (mi != null)
         {
            if (mi.Id == AddLayer)
            {
               if (mi.Parent != null)
               {
                  AnnLayer newLayer = AnnLayer.Create("Layer");
                  _layerNode.Nodes.Add(new LayerNode(newLayer, this));
                  if (_layerNode.Tag != null && string.Compare((string)_layerNode.Tag, "Container") == 0)
                  {
                     _automation.AddLayer(null, newLayer);
                  }
                  else
                  {
                     _automation.AddLayer(_layerNode.Layer, newLayer);
                  }
               }
            }
            else if (mi.Id == DeleteLayer)
            {
               _automation.DeleteLayer(_layerNode.Layer, false);
               _layerNode.Parent.Nodes.Remove(_layerNode);
            }
            else if (mi.Id == BringToFirstId)
            {
               _automation.BringLayerToFront(true);
            }
            else if (mi.Id == BringToFrontId)
            {
               _automation.BringLayerToFront(false);
            }
            else if (mi.Id == SendToBackId)
            {
               _automation.SendLayerToBack(false);
            }
            else if (mi.Id == SendToLastId)
            {
               _automation.SendLayerToBack(true);
            }
         }

         if (_automation != null)
            _automation.Invalidate(LeadRectD.Empty);
      }
   }

   public class LayerNode : TreeNode
   {
      static int _count = 1;

      void Init(AnnLayer layer, ContextMenu menu)
      {
         _layer = layer;
         ContextMenu = null;
         Checked = layer.IsVisible;
      }

      public LayerNode(AnnLayer layer, ContextMenu menu, bool increment)
         : base(increment ? string.Format("{0} #{1}", layer.Name, (_count++).ToString()) : layer.Name)
      {
         Init(layer ,menu);
      }

      public LayerNode(AnnLayer layer, ContextMenu menu)
         : base(string.Format("{0} #{1}", layer.Name, (_count++).ToString()))
      {
         Init(layer, menu);
      }

      AnnLayer _layer;

      public AnnLayer Layer
      {
         get { return _layer; }
      }
   }
}
