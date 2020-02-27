// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Leadtools;

namespace AnimationDemo
{
   public partial class CreateAnimationDialog : Form
   {
      RasterImage _image = null;

      public CreateAnimationDialog()
      {
         InitializeComponent();
      }

      private void CreateAnimationDialog_Load(object sender, EventArgs e)
      {
         _btnRemove.Enabled = false;
         _lstSourceImages.Items.Clear();
         _lstAnimationImages.Items.Clear();

         foreach (ViewerForm i in (Owner as Form).MdiChildren)
            _lstSourceImages.Items.Add(new Item(i.Image, i.Title));
      }

      private void _btnAdd_Click(object sender, EventArgs e)
      {
         Item item = _lstSourceImages.SelectedItem as Item;

         if (item != null)
            _lstAnimationImages.Items.Add(item);

         if (_lstAnimationImages.Items.Count > 0)
         {
            _btnOk.Enabled = true;
         }
         else
         {
            _btnOk.Enabled = false;
         }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         _image = (_lstAnimationImages.Items[0] as Item).Image.Clone();

         if(_image!= null)
         {
            for(int i = 1; i<_lstAnimationImages.Items.Count; ++i)
               _image.InsertPage(i+1, (_lstAnimationImages.Items[i] as Item).Image.Clone());
         }
      }

      public RasterImage Image
      {
         get
         {
            return _image;
         }
      }

      private void _btnRemove_Click(object sender, EventArgs e)
      {
         Item item = _lstAnimationImages.SelectedItem as Item;

         if (item != null)
            _lstAnimationImages.Items.Remove(item);

         if (_lstAnimationImages.Items.Count > 0)
         {
            _btnOk.Enabled = true;
         }
         else
         {
            _btnOk.Enabled = false;
         }
      }

      private void _lstAnimationImages_SelectedIndexChanged(object sender, EventArgs e)
      {
         Item item = _lstAnimationImages.SelectedItem as Item;
         if (item != null)
            _btnRemove.Enabled = true;
      }
   }

   class Item
   {
      RasterImage _image = null;
      string _title = null;

      public Item(RasterImage image, string title)
      {
         _title = title;
         _image = image;
      }

      public override string ToString()
      {
         return Title;
      }

      public string Title
      {
         get
         {
            return _title;
         }
      }

      public RasterImage Image
      {
         get
         {
            return _image;
         }
      }
   }

}
