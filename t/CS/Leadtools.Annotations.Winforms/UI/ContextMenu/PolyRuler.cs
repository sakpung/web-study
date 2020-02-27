// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

using Leadtools.Annotations.Automation;
using Leadtools.Annotations.Engine;

namespace Leadtools.Annotations.WinForms
{
   internal class CalibrateContextMenu : ObjectContextMenu
   {
      private const int _mySep = ObjectContextMenu.LastId - 1;
      public const int CalibrateId = ObjectContextMenu.LastId - 2;

      public CalibrateContextMenu() :
         base()
      {
         ObjectMenuItem objectMenu;

         var index = -1;
         for (var i = 0; i < this.MenuItems.Count && index == -1; i++)
         {
            objectMenu = MenuItems[i] as ObjectMenuItem;
            if (objectMenu != null && objectMenu.Id == ObjectContextMenu.Separator4Id)
               index = i;
         }

         if (index == -1)
            index = MenuItems.Count;

         objectMenu = new ObjectMenuItem(_mySep, Tools.SeparatorMenuItem);
         objectMenu.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, objectMenu);

         objectMenu = new ObjectMenuItem(CalibrateId, StringManager.GetString(StringManager.Id.CalibrateContextMenu));
         objectMenu.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, objectMenu);
      }

      protected override void OnPopup(EventArgs e)
      {
         var automation = this.Automation;
         if (automation != null)
         {
            bool isPolyRulerObject = automation.CurrentEditObject is AnnPolyRulerObject;

            EnableMenuItem(GetMenuItem(CalibrateId), isPolyRulerObject && !automation.CurrentEditObject.IsLocked, false);
         }

         base.OnPopup(e);
      }

      private void menuItem_Click(object sender, EventArgs e)
      {
         var automation = this.Automation;
         if (automation == null)
            return;

         var objectMenu = sender as ObjectMenuItem;
         if (objectMenu != null)
         {
            if (objectMenu.Id == CalibrateId)
            {
               using (CalibrationDialog calibrationDialog = new CalibrationDialog(automation))
               {
                  calibrationDialog.ShowDialog();
               }
            }
         }
      }
   }
}
