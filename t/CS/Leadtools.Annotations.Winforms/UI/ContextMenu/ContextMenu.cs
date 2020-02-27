// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

using Leadtools.Annotations.Automation;

namespace Leadtools.Annotations.WinForms
{
   // A manger context menu to provide the undo/redo/paste and select all operation. this menu will be shown only
   // when there is no object selected
   public class ManagerContextMenu : ContextMenu
   {
      public const int UndoId = -1;
      public const int RedoId = -2;
      public const int Separator1Id = -3;
      public const int PasteId = -4;
      public const int Separator2Id = -5;
      public const int SelectAllId = -6;
      public const int Separator3Id = -7;
      public const int UseRotateControlPointsId = -8;
      public const int Separator4Id = -9;
      public const int SnapToGridId = -10;
      public const int ShowGridId = -11;
      public const int SnapToGridPropertiesId = -12;
      public const int Separator5Id = -13;
      public const int EnableObjectsAlignmentId = -14;
      public const int DefaultPropertiesId = -15;

      public const int LastId = -16;

      public ManagerContextMenu()
      {
         // Add Undo, Redo, Paste and select all menu items
         this.MenuItems.Add(new ObjectMenuItem(UndoId, StringManager.GetString(StringManager.Id.UndoContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(RedoId, StringManager.GetString(StringManager.Id.RedoContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(Separator1Id, Tools.SeparatorMenuItem));
         this.MenuItems.Add(new ObjectMenuItem(PasteId, StringManager.GetString(StringManager.Id.PasteContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(Separator2Id, Tools.SeparatorMenuItem));
         this.MenuItems.Add(new ObjectMenuItem(SelectAllId, StringManager.GetString(StringManager.Id.SelectAllContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(Separator3Id, Tools.SeparatorMenuItem));
         this.MenuItems.Add(new ObjectMenuItem(ShowGridId, StringManager.GetString(StringManager.Id.ShowGridContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(SnapToGridId, StringManager.GetString(StringManager.Id.SnapToGridContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(SnapToGridPropertiesId, StringManager.GetString(StringManager.Id.SnapToGridPropertiesContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(Separator4Id, Tools.SeparatorMenuItem));
         this.MenuItems.Add(new ObjectMenuItem(EnableObjectsAlignmentId, StringManager.GetString(StringManager.Id.EnableObjectsAlignmentContextMenu)));

         // Add click event handler to each menu item except the seperators
         foreach (MenuItem item in MenuItems)
         {
            if (string.Compare(item.Text, Tools.SeparatorMenuItem) != 0)
               item.Click += new EventHandler(menuItem_Click);
         }
      }

      // Gets and sets the automation used for the current context menu
      private AnnAutomation _automation;
      public AnnAutomation Automation
      {
         get { return _automation; }
         set { _automation = value; }
      }

      // return the menu item associated with this id
      private ObjectMenuItem GetMenuItem(int id)
      {
         foreach (MenuItem item in this.MenuItems)
         {
            var objectMenu = item as ObjectMenuItem;
            if (objectMenu != null && objectMenu.Id == id)
               return objectMenu;
         }

         return null;
      }

      // Disable or enable the menu items when the context menu is about to pop up
      protected override void OnPopup(EventArgs e)
      {
         var automation = this.Automation;
         if (automation != null)
         {
            var manager = automation.Manager;
            var objectMenu = GetMenuItem(UndoId);
            if (objectMenu != null) objectMenu.Enabled = automation.CanUndo;

            objectMenu = GetMenuItem(RedoId);
            if (objectMenu != null) objectMenu.Enabled = automation.CanRedo;

            objectMenu = GetMenuItem(PasteId);
            if (objectMenu != null) objectMenu.Enabled = automation.CanPaste;

            objectMenu = GetMenuItem(SelectAllId);
            if (objectMenu != null) objectMenu.Enabled = automation.CanSelectObjects;

            objectMenu = GetMenuItem(UseRotateControlPointsId);
            if (objectMenu != null) objectMenu.Checked = manager.Objects.Count > 0 && manager.Objects[0].UseRotateThumbs;

            objectMenu = GetMenuItem(ShowGridId);
            if (objectMenu != null) objectMenu.Checked = manager.SnapToGridOptions.ShowGrid;

            objectMenu = GetMenuItem(SnapToGridId);
            if (objectMenu != null) objectMenu.Checked = manager.SnapToGridOptions.EnableSnap;

            objectMenu = GetMenuItem(EnableObjectsAlignmentId);
            if (objectMenu != null) objectMenu.Checked = manager.EnableObjectsAlignment;
         }

         base.OnPopup(e);
      }

      // Perform the action depending on which menu item has been clicked
      private void menuItem_Click(object sender, EventArgs e)
      {
         var automation = this.Automation;
         if (automation == null)
            return;

         var objectMenu = sender as ObjectMenuItem;
         if (objectMenu != null)
         {
            switch (objectMenu.Id)
            {
               case UndoId: automation.Undo(); break;
               case RedoId: automation.Redo(); break;
               case PasteId: automation.Paste(); break;
               case SelectAllId: automation.SelectObjects(automation.Container.Children); break;
               case UseRotateControlPointsId:
                  var useRotateControlPoints = !objectMenu.Checked;
                  foreach (var obj in automation.Manager.Objects)
                     obj.UseRotateThumbs = useRotateControlPoints;

                  automation.SelectObjects(null);
                  break;

               case ShowGridId:
                  automation.Manager.SnapToGridOptions.ShowGrid = !automation.Manager.SnapToGridOptions.ShowGrid;
                  automation.AutomationControl.AutomationInvalidate(LeadRectD.Empty);
                  break;

               case SnapToGridId:
                  automation.Manager.SnapToGridOptions.EnableSnap = !automation.Manager.SnapToGridOptions.EnableSnap;
                  automation.AutomationControl.AutomationInvalidate(LeadRectD.Empty);
                  break;

               case SnapToGridPropertiesId:
                  using (SnapToGridPropertiesDialog dlg = new SnapToGridPropertiesDialog())
                  {
                     dlg.Automation = automation;

                     dlg.ShowDialog();
                  }
                  break;
               case EnableObjectsAlignmentId:
                  automation.Manager.EnableObjectsAlignment = !automation.Manager.EnableObjectsAlignment;
                  automation.AutomationControl.AutomationInvalidate(LeadRectD.Empty);
                  break;

               default:
                  break;
            }

            // Raises the ManagerContextMenu.Collapse event.
            this.OnCollapse(e);
         }
      }
   }
}
