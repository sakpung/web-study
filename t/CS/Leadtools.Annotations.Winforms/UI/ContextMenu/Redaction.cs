// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

namespace Leadtools.Annotations.WinForms
{
   internal class RedactionContextMenu : ObjectContextMenu
   {
      private const int _mySep = ObjectContextMenu.LastId - 1;
      public const int RealizeId = ObjectContextMenu.LastId - 2;
      public const int RestoreId = ObjectContextMenu.LastId - 3;

      public RedactionContextMenu() :
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
            index = this.MenuItems.Count;

         objectMenu = new ObjectMenuItem(_mySep, Tools.SeparatorMenuItem);
         objectMenu.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, objectMenu);

         objectMenu = new ObjectMenuItem(RealizeId, StringManager.GetString(StringManager.Id.RealizeContextMenu));
         objectMenu.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, objectMenu);

         objectMenu = new ObjectMenuItem(RestoreId, StringManager.GetString(StringManager.Id.RestoreContextMenu));
         objectMenu.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, objectMenu);
      }

      protected override void OnPopup(EventArgs e)
      {
         var automation = this.Automation;
         if (automation != null)
         {
            EnableMenuItem(GetMenuItem(RealizeId), automation.CanRealizeRedaction, false);
            EnableMenuItem(GetMenuItem(RestoreId), automation.CanRestoreRedaction, false);
         }

         base.OnPopup(e);
      }

      private void menuItem_Click(object sender, EventArgs e)
      {
         var automation = this.Automation;
         if (automation == null)
            return;

         var objectMenu = sender as ObjectMenuItem;

         if (objectMenu.Id == RealizeId)
            automation.RealizeRedaction();
         else if (objectMenu.Id == RestoreId)
            automation.RestoreRedaction();
      }
   }
}
