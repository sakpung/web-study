// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Leadtools.Medical.Winforms.Control;

namespace Leadtools.Medical.Winforms.DatabaseManager.Controls
{
   public partial class ModalitiesControl : UserControl
   {
      public ModalitiesControl()
      {
         InitializeComponent();
      }

      public void Initialize()
      {
         InitModalities();
      }

      private void InitModalities()
      {
         CheckedComboBox.FillModalities(comboBoxModalities);
      }

      public void RegisterEvents()
      {

         checkBoxSelectAllModalities.CheckStateChanged += new EventHandler(checkBoxSelectAllModalities_CheckStateChanged);
         comboBoxModalities.CheckChanged += new EventHandler(comboBoxModalities_CheckChanged);
      }

      void checkBoxSelectAllModalities_CheckStateChanged(object sender, EventArgs e)
      {
         try
         {
            comboBoxModalities.CheckChanged -= new EventHandler(comboBoxModalities_CheckChanged);

            if ((checkBoxSelectAllModalities.Checked) && (checkBoxSelectAllModalities.CheckState == CheckState.Checked))
            {
               comboBoxModalities.CheckAllItems();
            }
            else if ((!checkBoxSelectAllModalities.Checked) && (checkBoxSelectAllModalities.CheckState == CheckState.Unchecked))
            {
               comboBoxModalities.ClearCheckedItems();
            }

            comboBoxModalities.CheckChanged += new EventHandler(comboBoxModalities_CheckChanged);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);
         }
      }


      void comboBoxModalities_CheckChanged(object sender, EventArgs e)
      {
         try
         {
            checkBoxSelectAllModalities.CheckStateChanged -= new EventHandler(checkBoxSelectAllModalities_CheckStateChanged);

            int checkedItemCount = comboBoxModalities.GetCheckedItemsCount();

            if (checkedItemCount == comboBoxModalities.Items.Count)
            {
               checkBoxSelectAllModalities.Checked = true;
               checkBoxSelectAllModalities.CheckState = CheckState.Checked;
            }
            else if (checkedItemCount == 0)
            {
               checkBoxSelectAllModalities.Checked = false;
               checkBoxSelectAllModalities.CheckState = CheckState.Unchecked;
            }
            else
            {
               checkBoxSelectAllModalities.Checked = true;
               checkBoxSelectAllModalities.CheckState = CheckState.Indeterminate;
            }

            checkBoxSelectAllModalities.CheckStateChanged += new EventHandler(checkBoxSelectAllModalities_CheckStateChanged);
         }
         catch (Exception exception)
         {
            System.Diagnostics.Debug.Assert(false, exception.Message);
         }
      }

      public string Modalities
      {
         get
         {
            return comboBoxModalities.Text;
         }
      }

      public void Clear()
      {
         checkBoxSelectAllModalities.Checked = false;
         comboBoxModalities.ClearCheckedItems();
      }
   }
}
