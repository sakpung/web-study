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
using Leadtools.Dicom.AddIn.Common;
using Leadtools.Medical.AeManagement.DataAccessLayer;

namespace Leadtools.Medical.Winforms
{
   public partial class AutoCopyView : UserControl
   {
      public AutoCopyView()
      {
         InitializeComponent();
         
         this.Load                                    += new System.EventHandler(this.ConfigureDialog_Load);
         
         this.checkBoxAutoCopy.CheckedChanged         += new System.EventHandler(this.checkBoxAutoUpdate_CheckedChanged);
         this.comboBoxSource.SelectionChangeCommitted += new System.EventHandler(this.comboBoxSource_SelectionChangeCommitted);
         this.listViewAutoCopy.ItemChecked            += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewAutoUpdate_ItemChecked);
         this.checkBoxCustomAE.CheckedChanged         += new System.EventHandler(this.checkBoxCustomAE_CheckedChanged);

         this.textBoxCustomAE.TextChanged += new EventHandler(OnSetIsDirty);
         this.numericUpDownThreads.ValueChanged += new EventHandler(OnSetIsDirty);
      }

      public void Initialize ( AutoCopyOptions options, int autocopyRelation, IAeManagementDataAccessAgent accessAgent  )
      {         
         AutocopyRelation = autocopyRelation ;
         _Options         = options ;
         
         if (_Options != null)
         {
            checkBoxAutoCopy.Checked = _Options.EnableAutoCopy;
            checkBoxCustomAE.Checked = _Options.UseCustomAE;
            textBoxCustomAE.Text = _Options.AutoCopyAE;
            numericUpDownThreads.Value = _Options.AutoCopyThreads;
         }
         _AccessAgent = accessAgent;
         EnableAutoCopy();
      }

      public void UpdateOptions  ( )
      {
         if (_Options != null)
         {
            _Options.EnableAutoCopy = checkBoxAutoCopy.Checked;
            _Options.AutoCopyAE = textBoxCustomAE.Text;
            _Options.UseCustomAE = checkBoxCustomAE.Checked;
            _Options.AutoCopyThreads = Convert.ToInt32(numericUpDownThreads.Value);
         }
      }
      
      public int AutocopyRelation { get ; private set ; }
      public AutoCopyOptions Options
      {
         get { return _Options; }
      }
      
      private void ConfigureDialog_Load ( object sender, EventArgs e )
      {
         //
         // Resize the columns evenly
         //
         foreach(ColumnHeader column in listViewAutoCopy.Columns)
         {
            column.Width = listViewAutoCopy.ClientRectangle.Width / 3;
         }         
      }
      
      private void EnableAutoCopy()
      {
         comboBoxSource.Enabled = checkBoxAutoCopy.Checked;
         checkBoxCustomAE.Enabled = checkBoxAutoCopy.Checked;
         textBoxCustomAE.Enabled = checkBoxCustomAE.Checked && checkBoxCustomAE.Enabled;
         numericUpDownThreads.Enabled = checkBoxAutoCopy.Checked;
         if (checkBoxAutoCopy.Checked)
         {
            LoadAeTitles();
         }
         else
         {
            comboBoxSource.Items.Clear();
            listViewAutoCopy.Items.Clear();
         }
      }

      private void LoadAeTitles()
      {
         AeInfo[] aetitles = _AccessAgent.GetAeTitles();

         comboBoxSource.Items.Clear();
         listViewAutoCopy.Items.Clear();
         _SelectedItem = null;
         _SelectedIndex = -1;
         try
         {
            listViewAutoCopy.ItemChecked -= listViewAutoUpdate_ItemChecked;
            foreach (AeInfo info in aetitles)
            {
               comboBoxSource.Items.Add(info);
               AddToList(info);
            }
         }
         finally
         {
            listViewAutoCopy.ItemChecked += listViewAutoUpdate_ItemChecked;
         }
      }

      public void AddAeTitle(AeInfo aetitle)
      {
         listViewAutoCopy.ItemChecked -= listViewAutoUpdate_ItemChecked;
         comboBoxSource.Items.Add(aetitle);
         AddToList(aetitle);
         listViewAutoCopy.ItemChecked += listViewAutoUpdate_ItemChecked;
      }

      public void RemoveAeTitle(string aetitle)
      {
         int index = -1;

         foreach (AeInfo info in comboBoxSource.Items)
         {
            if (info.AETitle == aetitle)
            {
               index = comboBoxSource.Items.IndexOf(info);
               break;
            }
         }

         if (index != -1)
         {            
            listViewAutoCopy.ItemChecked -= listViewAutoUpdate_ItemChecked;
            comboBoxSource.Items.RemoveAt(index);
            index = -1;
            foreach (ListViewItem item in listViewAutoCopy.Items)
            {
               AeInfo i = item.Tag as AeInfo;

               if (i.AETitle == aetitle)
               {
                  index = item.Index;
                  break;
               }
            }

            if (index != -1)
            {
               listViewAutoCopy.Items.RemoveAt(index);
            }
            listViewAutoCopy.ItemChecked += listViewAutoUpdate_ItemChecked;

            if (_SelectedItem != null)
            {
               if ((_SelectedItem.Tag as AeInfo).AETitle == aetitle)
               {
                  _SelectedItem = null;
                  _SelectedIndex = 0;
               }
            }
         }         
      }            

      private void GetRelatedAes(AeInfo info)
      {
         AeInfo[] aes = _AccessAgent.GetRelatedAeTitles(info.AETitle, AutocopyRelation);
        
         foreach(AeInfo ae in aes)
         {
            ListViewItem item = listViewAutoCopy.Items.Cast<ListViewItem>().Where(i => i.Text == ae.AETitle).FirstOrDefault();

            if (item != null)
               item.Checked = true;
         }
      }
      
      private void AddToList(AeInfo info)
      {
         ListViewItem item = new ListViewItem(info.AETitle);

         item.SubItems.Add(info.Address);
         item.SubItems.Add(info.Port.ToString());
         item.Tag = info;
         listViewAutoCopy.Items.Add(item);         
      }
      
      private void checkBoxAutoUpdate_CheckedChanged(object sender, EventArgs e)
      {
         if (_AccessAgent == null)
            return;

         EnableAutoCopy();
         OnSetIsDirty(sender, e);
      }
      
      private void comboBoxSource_SelectionChangeCommitted(object sender, EventArgs e)
      {
         AeInfo info;

         if (comboBoxSource.SelectedItem == null)
            return;

         info = comboBoxSource.SelectedItem as AeInfo;

         listViewAutoCopy.ItemChecked -= listViewAutoUpdate_ItemChecked;
         listViewAutoCopy.Check(false);
         try
         {
            listViewAutoCopy.Enabled = checkBoxAutoCopy.Checked;            
            if (_SelectedItem != null)
            {
               listViewAutoCopy.Items.Insert(_SelectedIndex, _SelectedItem);
            }

            foreach (ListViewItem item in listViewAutoCopy.Items)
            {
               AeInfo i = item.Tag as AeInfo;

               if (i.Address == info.Address && i.AETitle == info.AETitle)
               {
                  _SelectedItem = item;
                  _SelectedIndex = listViewAutoCopy.Items.IndexOf(item);
                  break;
               }
            }

            if (_SelectedItem != null)
            {
               listViewAutoCopy.Items.Remove(_SelectedItem);
            }
            GetRelatedAes(info);
         }
         finally
         {
            listViewAutoCopy.ItemChecked += listViewAutoUpdate_ItemChecked;            
         }
      }
      
      private void listViewAutoUpdate_ItemChecked(object sender, ItemCheckedEventArgs e)
      {
         AeInfo info = comboBoxSource.SelectedItem as AeInfo;

         if ( null == info ) 
         {
            return ;
         }
         
         if(e.Item.Checked)
         {
            _AccessAgent.AddReleation(info.AETitle, e.Item.Text, AutocopyRelation);
         }
         else
         {
            _AccessAgent.RemoveRelation(info.AETitle, e.Item.Text, AutocopyRelation);
         }
         OnSetIsDirty(sender, e);
      }
      
      private void checkBoxCustomAE_CheckedChanged(object sender, EventArgs e)
      {
         textBoxCustomAE.Enabled = checkBoxCustomAE.Checked;
         OnSetIsDirty(sender, e);
      }
      
      private AutoCopyOptions _Options;
      private IAeManagementDataAccessAgent _AccessAgent;
      private ListViewItem _SelectedItem = null;
      private int _SelectedIndex = -1;

      private void OnSetIsDirty(object sender, EventArgs e)
      {
         try
         {
            IsDirty = true;
            OnSettingsChanged(sender, e);
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      private bool _isDirty = false;

      public bool IsDirty
      {
         get
         {
            return _isDirty;
         }
         private set
         {
            _isDirty = value;
         }
      }

      public event EventHandler SettingsChanged;


      private void OnSettingsChanged(object sender, EventArgs e)
      {
         try
         {
            if (SettingsChanged != null)
            {
               SettingsChanged(sender, e);
            }
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

   }
}
