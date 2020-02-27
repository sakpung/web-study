// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Drawing;
using System.Windows.Forms;

using Leadtools.Medical3D;
using Leadtools.MedicalViewer;

namespace Main3DDemo
{
    public partial class SaveItemialog : Form
   {
      private Histogram3DDialog _dialog;
      private ComboBox _combobox;

      public SaveItemialog()
      {
         InitializeComponent();
      }

      public SaveItemialog(Histogram3DDialog dialog, int count, ComboBox combobox)
      {
         InitializeComponent();

         _dialog = dialog;

         _combobox = combobox;


         GetNextName(count);

      }

      private void GetNextName(int count)
      {
          _txtItemName.Text = String.Format("Item {0}", count + 1);
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
          _dialog.ItemName = "";
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {

          foreach (object item in _combobox.Items)
          {
              if (_txtItemName.Text == item.ToString())
              {
                  MessageBox.Show("The name is already used", "Duplicated Name", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  return;
              }
          }

          _dialog.ItemName = _txtItemName.Text;



          this.Close();
      }
   }
}
