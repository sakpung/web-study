// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Leadtools.Annotations.Engine;

namespace Leadtools.Annotations.WinForms
{
   internal class TextPointerContextMenu : ObjectContextMenu
   {
      private const int _mySep = ObjectContextMenu.LastId - 1;
      public const int FixedPointerId = ObjectContextMenu.LastId - 2;

      public TextPointerContextMenu() :
         base()
      {
         ObjectMenuItem objectMenu;

         var index = -1;
         for (var i = 0; i < this.MenuItems.Count && index == -1; i++)
         {
            objectMenu = this.MenuItems[i] as ObjectMenuItem;
            if (objectMenu != null && objectMenu.Id == ObjectContextMenu.Separator4Id)
                  index = i;
         }

         if (index == -1)
            index = MenuItems.Count;

         objectMenu = new ObjectMenuItem(_mySep, Tools.SeparatorMenuItem);
         objectMenu.Click += new EventHandler(menuItem_Click);
         this.MenuItems.Add(index++, objectMenu);

         objectMenu = new ObjectMenuItem(FixedPointerId, StringManager.GetString(StringManager.Id.FixedPointerContextMenu));
         objectMenu.Click += new EventHandler(menuItem_Click);
         this.MenuItems.Add(index++, objectMenu);
      }

      protected override void OnPopup(EventArgs e)
      {
         var automation = this.Automation;
         if (automation != null)
         {
            var objectMenu = GetMenuItem(FixedPointerId);
            if (objectMenu != null)
            {
               var textPointer = automation.CurrentEditObject as AnnTextPointerObject;
               if (textPointer != null)
               {
                  objectMenu.Enabled = true;
                  objectMenu.Checked = textPointer.FixedPointer;
               }
               else
               {
                  objectMenu.Checked = false;
                  objectMenu.Enabled = false;
               }
            }
         }

         base.OnPopup(e);
      }

      private void menuItem_Click(object sender, EventArgs e)
      {
         var automation = this.Automation;
         if (automation == null)
            return;

         var objectMenu = sender as ObjectMenuItem;
         if (objectMenu != null && objectMenu.Id == FixedPointerId)
         {
            var textPointer = automation.CurrentEditObject as AnnTextPointerObject;
            if (textPointer != null)
            {
               automation.BeginUndo();
               textPointer.FixedPointer = !textPointer.FixedPointer;
               automation.EndUndo();
            }
         }
      }
   }
}
