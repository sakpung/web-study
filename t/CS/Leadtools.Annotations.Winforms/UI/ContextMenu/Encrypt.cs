// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;

namespace Leadtools.Annotations.WinForms
{
   internal class EncryptContextMenu : ObjectContextMenu
   {
      private const int _mySep = ObjectContextMenu.LastId - 1;
      public const int ApplyEncryptorId = ObjectContextMenu.LastId - 2;
      public const int ApplyDecryptorId = ObjectContextMenu.LastId - 3;

      public EncryptContextMenu() :
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

         objectMenu = new ObjectMenuItem(ApplyEncryptorId, StringManager.GetString(StringManager.Id.ApplyEncryptorContextMenu));
         objectMenu.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, objectMenu);

         objectMenu = new ObjectMenuItem(ApplyDecryptorId, StringManager.GetString(StringManager.Id.ApplyDecryptorContextMenu));
         objectMenu.Click += new EventHandler(menuItem_Click);
         MenuItems.Add(index++, objectMenu);
      }

      protected override void OnPopup(EventArgs e)
      {
         var automation = this.Automation;
         if (automation != null)
         {
            EnableMenuItem(GetMenuItem(ApplyEncryptorId), automation.CanApplyEncryptor, false);
            EnableMenuItem(GetMenuItem(ApplyDecryptorId), automation.CanApplyDecryptor, false);
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
            if (objectMenu.Id == ApplyEncryptorId)
               automation.ApplyEncryptor();
            else if (objectMenu.Id == ApplyDecryptorId)
               automation.ApplyDecryptor();
         }
      }
   }
}
