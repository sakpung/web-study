// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;
using Leadtools.Annotations.Core;
using Leadtools.Annotations.Designers;

namespace Leadtools.Annotations.Automation.Winforms
{
   internal class PolylineContextMenu : ObjectContextMenu
   {
      private const int _mySep = ObjectContextMenu.LastId - 1;
      public const int DeleteControlPointId = ObjectContextMenu.LastId - 2;
      public const int AddControlPointId = ObjectContextMenu.LastId - 3;

      private int _deleteIndex;
      private int _addIndex;
      private Point _addPoint;

      public PolylineContextMenu() :
         base()
      {
         ObjectMenuItem mi;

         int index = -1;
         for(int i = 0; i < MenuItems.Count && index == -1; i++)
         {
            if(MenuItems[i] is ObjectMenuItem)
            {
               mi = MenuItems[i] as ObjectMenuItem;
               if(mi.Id == ObjectContextMenu.Separator4Id)
                  index = i;
            }
         }

         if(index == -1)
            index = MenuItems.Count;

         mi = new ObjectMenuItem(_mySep, Tools.SeparatorMenuItem);
         mi.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, mi);

         mi = new ObjectMenuItem(DeleteControlPointId, StringManager.GetString(StringManager.Id.DeleteControlPointContextMenu));
         mi.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, mi);

         mi = new ObjectMenuItem(AddControlPointId, StringManager.GetString(StringManager.Id.AddControlPointContextMenu));
         mi.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, mi);

         _deleteIndex = -1;
         _addIndex = -1;
      }

      protected override void OnPopup(EventArgs e)
      {
         if(Automation != null)
         {
            /*Point pos = Automation.AutomationControl.PointToClient(Cursor.Position);

            _deleteIndex = Automation.GetDeleteControlPointIndex(pos);

            ObjectMenuItem mi = GetMenuItem(DeleteControlPointId);
            if(mi != null) mi.Enabled = _deleteIndex != -1;

            _addIndex = Automation.GetAddControlPointIndex(pos);
            if(_addIndex != -1)
               _addPoint = pos;

            mi = GetMenuItem(AddControlPointId);
            if(mi != null) mi.Enabled = _addIndex != -1;
         }

         base.OnPopup(e);
      }

      internal int GetDeleteControlPointIndex(Point pt)
      {
         AnnPolylineEditDesigner annPolylineEditDesigner = Automation.CurrentDesigner as AnnPolylineEditDesigner;
         AnnPolylineObject polyline = annPolylineEditDesigner.TargetObject as AnnPolylineObject;
         if (polyline != null)
         {
            LeadPointD[] pts = annPolylineEditDesigner.GetThumbLocations();
            if (pts != null && pts.Length > 0)
            {
               //LeadPointD transformedTestPoint;

               if (polyline.Points.Count > 2)
               {
                  /*using (Matrix matrix = polyline.PhysicalTransform)
                  {
                     AnnTransformer transformer = new AnnTransformer(Container.UnitConverter, matrix);
                     transformedTestPoint = transformer.PointToLogical(new AnnPoint(pt, AnnUnit.Pixel));
                  }*/

                  for (int i = 0; i < pts.Length; i++)
                  {
                     if (annPolylineEditDesigner.HitTestThumbs(pts[i]))
                        return i;
                  }
               }
            }
         }

         return -1;
      }

      private void menuItem_Click(object sender, EventArgs e)
      {
         if(sender is ObjectMenuItem)
         {
            ObjectMenuItem mi = sender as ObjectMenuItem;
            if(mi.Id == DeleteControlPointId)
            {
               if(_deleteIndex != -1)
                  Automation.DeleteControlPointIndex(_deleteIndex);
            }
            else if(mi.Id == AddControlPointId)
            {
               if(_addIndex != -1)
                  Automation.AddControlPoint(_addPoint, _addIndex);
            }
         }
      }
   }
}
