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
   // A context menu to provide operations shared by all annotation objects
   public class ObjectContextMenu : ContextMenu
   {
      public const int CutId = -1;
      public const int CopyId = -2;
      public const int DeleteId = -3;
      public const int Separator1Id = -4;
      public const int BringToFrontId = -5;
      public const int SendToBackId = -6;
      public const int BringToFirstId = -7;
      public const int SendToLastId = -8;
      public const int Separator2Id = -9;
      public const int FlipId = -10;
      public const int ReverseId = -11;
      public const int Separator3Id = -12;
      public const int LockId = -13;
      public const int UnlockId = -14;
      public const int Separator4Id = -15;
      public const int ResetRotatePointsId = -16;
      public const int Separator5Id = -17;
      public const int SnapToGridId = -18;
      public const int Separator6Id = -19;
      public const int PropertiesId = -20;
      public const int ObjectsAlignmentId = -21;
      public const int ObjectsAlignmentLeftsId = -22;
      public const int ObjectsAlignmentCentersId = -23;
      public const int ObjectsAlignmentRightsId = -24;
      public const int Separator7Id = -25;
      public const int ObjectsAlignmentTopsId = -26;
      public const int ObjectsAlignmentMiddlesId = -27;
      public const int ObjectsAlignmentBottomsId = -28;
      public const int Separator8Id = -29;
      public const int ObjectsAlignmentSameWidthId = -30;
      public const int ObjectsAlignmentSameHeightId = -31;
      public const int ObjectsAlignmentSameSizeId = -32;

      public const int LastId = -33;

      public ObjectContextMenu()
      {
         // Add Cut/Copy and delete menu items
         this.MenuItems.Add(new ObjectMenuItem(CutId, StringManager.GetString(StringManager.Id.CutContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(CopyId, StringManager.GetString(StringManager.Id.CopyContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(DeleteId, StringManager.GetString(StringManager.Id.DeleteContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(Separator1Id, Tools.SeparatorMenuItem));

         // add Z-order menu items(BringToFront, SendToBack, BringToFirst, SendToLast)
         this.MenuItems.Add(new ObjectMenuItem(BringToFrontId, StringManager.GetString(StringManager.Id.BringToFrontContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(SendToBackId, StringManager.GetString(StringManager.Id.SendToBackContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(BringToFirstId, StringManager.GetString(StringManager.Id.BringToFirstContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(SendToLastId, StringManager.GetString(StringManager.Id.SendToLastContextMenu)));

         // add Objects Alignmen menu items
         ObjectMenuItem ObjectsAlignmenMenuItem = new ObjectMenuItem(ObjectsAlignmentId, StringManager.GetString(StringManager.Id.ObjectsAlignmentContextMenu));
         ObjectsAlignmenMenuItem.MenuItems.Add(new ObjectMenuItem(ObjectsAlignmentLeftsId, StringManager.GetString(StringManager.Id.ObjectsAlignmentLeftsContextMenu)));
         ObjectsAlignmenMenuItem.MenuItems.Add(new ObjectMenuItem(ObjectsAlignmentCentersId, StringManager.GetString(StringManager.Id.ObjectsAlignmentCentersContextMenu)));
         ObjectsAlignmenMenuItem.MenuItems.Add(new ObjectMenuItem(ObjectsAlignmentRightsId, StringManager.GetString(StringManager.Id.ObjectsAlignmentRightsContextMenu)));
         ObjectsAlignmenMenuItem.MenuItems.Add(new ObjectMenuItem(Separator7Id, Tools.SeparatorMenuItem));
         ObjectsAlignmenMenuItem.MenuItems.Add(new ObjectMenuItem(ObjectsAlignmentTopsId, StringManager.GetString(StringManager.Id.ObjectsAlignmentTopsContextMenu)));
         ObjectsAlignmenMenuItem.MenuItems.Add(new ObjectMenuItem(ObjectsAlignmentMiddlesId, StringManager.GetString(StringManager.Id.ObjectsAlignmentMiddlesContextMenu)));
         ObjectsAlignmenMenuItem.MenuItems.Add(new ObjectMenuItem(ObjectsAlignmentBottomsId, StringManager.GetString(StringManager.Id.ObjectsAlignmentBottomsContextMenu)));
         ObjectsAlignmenMenuItem.MenuItems.Add(new ObjectMenuItem(Separator8Id, Tools.SeparatorMenuItem));
         ObjectsAlignmenMenuItem.MenuItems.Add(new ObjectMenuItem(ObjectsAlignmentSameWidthId, StringManager.GetString(StringManager.Id.ObjectsAlignmentSameWidthContextMenu)));
         ObjectsAlignmenMenuItem.MenuItems.Add(new ObjectMenuItem(ObjectsAlignmentSameHeightId, StringManager.GetString(StringManager.Id.ObjectsAlignmentSameHeightContextMenu)));
         ObjectsAlignmenMenuItem.MenuItems.Add(new ObjectMenuItem(ObjectsAlignmentSameSizeId, StringManager.GetString(StringManager.Id.ObjectsAlignmentSameSizeContextMenu)));
         this.MenuItems.Add(ObjectsAlignmenMenuItem);
         this.MenuItems.Add(new ObjectMenuItem(Separator2Id, Tools.SeparatorMenuItem));

         // Add flip and reverse menu items
         this.MenuItems.Add(new ObjectMenuItem(FlipId, StringManager.GetString(StringManager.Id.FlipContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(ReverseId, StringManager.GetString(StringManager.Id.ReverseContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(Separator3Id, Tools.SeparatorMenuItem));

         // Add lock and unlock menu items
         this.MenuItems.Add(new ObjectMenuItem(LockId, StringManager.GetString(StringManager.Id.LockContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(UnlockId, StringManager.GetString(StringManager.Id.UnlockContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(Separator4Id, Tools.SeparatorMenuItem));

         // Add reset rotate points menu item
         this.MenuItems.Add(new ObjectMenuItem(ResetRotatePointsId, StringManager.GetString(StringManager.Id.ResetRotatePointsContextMenu)));
         this.MenuItems.Add(new ObjectMenuItem(Separator5Id, Tools.SeparatorMenuItem));

         // Add properties menu item
         this.MenuItems.Add(new ObjectMenuItem(PropertiesId, StringManager.GetString(StringManager.Id.PropertiesContextMenu)));

         // Add click event handler to each menu item except the seperators
         foreach (MenuItem item in MenuItems)
         {
            if (string.Compare(item.Text, Tools.SeparatorMenuItem) != 0)
               item.Click += new EventHandler(menuItem_Click);
         }

         foreach (MenuItem item in ObjectsAlignmenMenuItem.MenuItems)
         {
            if (string.Compare(item.Text, Tools.SeparatorMenuItem) != 0)
               item.Click += new EventHandler(menuItem_Click);
         }
      }

      // The automation used for the current context menu
      private AnnAutomation _automation;
      public AnnAutomation Automation
      {
         get { return _automation; }
         set { _automation = value; }
      }

      // Gets the menu item associated with this id
      internal ObjectMenuItem GetMenuItem(int id)
      {
         foreach (MenuItem item in MenuItems)
         {
            ObjectMenuItem objectMenu = item as ObjectMenuItem;
            if (objectMenu != null && objectMenu.Id == id)
               return objectMenu;
         }

         return null;
      }

      private bool SelectionContainsTextReviewObject(AnnSelectionObject selectionObject)
      {
         if (selectionObject != null)
         {
            foreach (var annObject in selectionObject.SelectedObjects)
            {
               if (annObject is AnnTextReviewObject)
                  return true;
            }
         }

         return false;
      }

      // Disable or enable the menu items when the context menu is about to pop up
      protected override void OnPopup(EventArgs e)
      {
         var automation = this.Automation;
         if (automation != null)
         {
            EnableMenuItem(GetMenuItem(CutId), automation.CanCopy, false);
            EnableMenuItem(GetMenuItem(CopyId), automation.CanCopy, false);
            EnableMenuItem(GetMenuItem(DeleteId), automation.CanDeleteObjects, false);
            EnableMenuItem(GetMenuItem(BringToFrontId), automation.CanBringToFront, false);
            EnableMenuItem(GetMenuItem(SendToBackId), automation.CanSendToBack, false);
            EnableMenuItem(GetMenuItem(BringToFirstId), automation.CanBringToFirst, false);
            EnableMenuItem(GetMenuItem(SendToLastId), automation.CanSendToLast, false);
            EnableMenuItem(GetMenuItem(FlipId), automation.CanFlip && (automation.CurrentEditObject.Id != AnnObject.RichTextObjectId), false);
            EnableMenuItem(GetMenuItem(ReverseId), automation.CanFlip && (automation.CurrentEditObject.Id != AnnObject.RichTextObjectId), false);
            EnableMenuItem(GetMenuItem(FlipId), automation.CanFlip && (automation.CurrentEditObject.Id != AnnObject.StickyNoteObjectId), false);
            EnableMenuItem(GetMenuItem(ReverseId), automation.CanFlip && (automation.CurrentEditObject.Id != AnnObject.StickyNoteObjectId), false);
            EnableMenuItem(GetMenuItem(ObjectsAlignmentId), automation.CanAlign, true);

            if (automation.CurrentEditObject is AnnTextReviewObject || SelectionContainsTextReviewObject(automation.CurrentEditObject as AnnSelectionObject))
            {
               EnableMenuItem(GetMenuItem(FlipId), false, false);
               EnableMenuItem(GetMenuItem(ReverseId), false, false);
               EnableMenuItem(GetMenuItem(CutId), false, false);
               EnableMenuItem(GetMenuItem(CopyId), false, false);
            }

            EnableMenuItem(GetMenuItem(LockId), automation.CanLock, false);
            EnableMenuItem(GetMenuItem(UnlockId), automation.CanUnlock, false);
            EnableMenuItem(GetMenuItem(Separator4Id), automation.CanResetRotatePoints, false);
            EnableMenuItem(GetMenuItem(ResetRotatePointsId), automation.CanResetRotatePoints, false);

            // Change the text from "PolyLine Properties" or "PolyRuler Properties" to "Line Properties" or "Ruler Properties"
            // depending on how many points it has
            var objectMenu = GetMenuItem(PropertiesId);
            if (objectMenu != null)
            {
               var props = StringManager.GetString(StringManager.Id.PropertiesContextMenu);

               if (automation.CurrentEditObject != null)
               {
                  var automationObject = automation.Manager.FindObject(automation.CurrentEditObject);
                  var name = automationObject.Name;
                  var currentObject = automation.CurrentEditObject;
                  if (currentObject.Points.Count == 2)
                  {
                     if (currentObject.Id == AnnObject.PolyRulerObjectId)
                        name = "&Ruler";
                     else if (currentObject.Id == AnnObject.PolylineObjectId)
                        name = "&Line";
                  }

                  objectMenu.Text = string.Format("{0} {1}", name, props);
               }
               else
               {
                  objectMenu.Text = props;
               }

               objectMenu.Enabled = automation.CanShowObjectProperties;
            }
         }

         base.OnPopup(e);
      }

      internal static void EnableMenuItem(ObjectMenuItem item, bool value, bool updateVisilibity)
      {
         if (item != null)
         {
            item.Enabled = value;
            if (updateVisilibity)
               item.Visible = value;
         }
      }

      // Perform action depndeing on which menu item has been clicked.
      private void menuItem_Click(object sender, EventArgs e)
      {
         ObjectMenuItem objectMenu = sender as ObjectMenuItem;
         if (objectMenu == null)
            return;

         var automation = this.Automation;
         if (automation == null)
            return;

         switch (objectMenu.Id)
         {
            case CutId:
               automation.Copy();
               automation.DeleteSelectedObjects();
               break;

            case CopyId: automation.Copy(); break;
            case DeleteId: automation.DeleteSelectedObjects(); break;
            case BringToFrontId: automation.BringToFront(false); break;
            case SendToBackId: automation.SendToBack(false); break;
            case BringToFirstId: automation.BringToFront(true); break;
            case SendToLastId: automation.SendToBack(true); break;
            case FlipId: automation.Flip(false); break;
            case ReverseId: automation.Flip(true); break;
            case LockId: automation.Lock(); break;
            case UnlockId: automation.Unlock(); break;
            case ResetRotatePointsId: automation.ResetRotatePoints(); break;
            case PropertiesId: automation.ShowObjectProperties(); break;
            case ObjectsAlignmentLeftsId: automation.AlignLefts(); break;
            case ObjectsAlignmentCentersId: automation.AlignCenters(); break;
            case ObjectsAlignmentRightsId: automation.AlignRights(); break;
            case ObjectsAlignmentTopsId: automation.AlignTops(); break;
            case ObjectsAlignmentMiddlesId: automation.AlignMiddles(); break;
            case ObjectsAlignmentBottomsId: automation.AlignBottoms(); break;
            case ObjectsAlignmentSameWidthId: automation.MakeSameWidth(); break;
            case ObjectsAlignmentSameHeightId: automation.MakeSameHeight(); break;
            case ObjectsAlignmentSameSizeId: automation.MakeSameSize(); break;
            default:
               break;
         }
      }
   }
}
