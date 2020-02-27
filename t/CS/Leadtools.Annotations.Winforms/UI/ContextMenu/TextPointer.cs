// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Leadtools.Annotations.Engine;

namespace Leadtools.Annotations.WinForms
{
   internal class TextRollupContextMenu : ObjectContextMenu
   {
      private const int _mySep = ObjectContextMenu.LastId - 1;
      public const int ExpandedId = ObjectContextMenu.LastId - 2;

      public TextRollupContextMenu() :
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

         if(index == -1)
            index = this.MenuItems.Count;

         objectMenu = new ObjectMenuItem(_mySep, Tools.SeparatorMenuItem);
         objectMenu.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, objectMenu);

         objectMenu = new ObjectMenuItem(ExpandedId, StringManager.GetString(StringManager.Id.ExpandedContextMenu));
         objectMenu.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, objectMenu);
      }

      protected override void OnPopup(EventArgs e)
      {
         var automation = this.Automation;
         if (automation != null)
         {
            var objectMenu = GetMenuItem(ExpandedId);
            if (objectMenu != null)
            {
               var textRollup = automation.CurrentEditObject as AnnTextRollupObject;
               if (textRollup != null)
               {
                  objectMenu.Enabled = true;
                  objectMenu.Checked = textRollup.Expanded;
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
         if(objectMenu.Id == ExpandedId)
         {
            var textRollup = automation.CurrentEditObject as AnnTextRollupObject;
            if (textRollup != null)
            {
               automation.BeginUndo();
               textRollup.Expanded = !textRollup.Expanded;
               automation.EndUndo();
               automation.AutomationControl.AutomationInvalidate(LeadRectD.Empty);
            }
         }
      }
   }
}
