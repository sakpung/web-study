// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;

namespace Leadtools.Annotations.WinForms
{
   internal class RubberStampContextMenu : ContextMenu
   {
      public RubberStampContextMenu()
      {
         foreach (AnnRubberStampType rubberStampType in Enum.GetValues(typeof(AnnRubberStampType)))
            this.MenuItems.Add(new RubberStampMenuItem(AutomationManagerHelper.GetRubberStampName(rubberStampType), rubberStampType));

         foreach (MenuItem item in this.MenuItems)
         {
            if (string.Compare(item.Text, Tools.SeparatorMenuItem) != 0)
               item.Click += new EventHandler(menuItem_Click);
         }
      }

      private AnnAutomationManager _automationManager;
      public AnnAutomationManager AutomationManager
      {
         get { return _automationManager; }
         set { _automationManager = value; }
      }

      public void Update()
      {
         var automationManager = this.AutomationManager;
         if (automationManager == null)
            return;

         if (automationManager != null)
         {
            foreach (MenuItem item in this.MenuItems)
            {
               var check = false;

               var rubberStampItem = item as RubberStampMenuItem;
               if (rubberStampItem != null)
               {
                  if (automationManager.CurrentRubberStampType == rubberStampItem.Type)
                     check = true;
               }

               item.Checked = check;
            }
         }
      }

      private void menuItem_Click(object sender, EventArgs e)
      {
         var automationManager = this.AutomationManager;
         if (automationManager == null)
            return;

         var rubberStampItem = sender as RubberStampMenuItem;
         if (rubberStampItem != null)
         {
            automationManager.CurrentRubberStampType = rubberStampItem.Type;
            Update();

            if (automationManager.CurrentObjectId != AnnObject.RubberStampObjectId)
               automationManager.CurrentObjectId = AnnObject.RubberStampObjectId;
         }
      }
   }
}
