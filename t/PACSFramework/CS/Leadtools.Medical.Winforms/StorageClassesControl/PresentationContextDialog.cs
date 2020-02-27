// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Leadtools.Dicom;

namespace Leadtools.Medical.Winforms
{
   public partial class PresentationContextDialog : Form
   {
      public PresentationContextDialog()
      {
         InitializeComponent();
         _uidList = new List<string>();

         RegisterEvents();
      }

      private void RegisterEvents()
      {
         checkBoxEnableRoleSelect.CheckedChanged += CheckBoxEnableRoleSelect_CheckedChanged;
      }

      private void EnableRoleSelectItems(bool enable)
      {
         groupBoxUserRole.Enabled = enable;
         groupBoxProviderRole.Enabled = enable;
      }

      private void EnableRoleSelectItems()
      {
         EnableRoleSelectItems(checkBoxEnableRoleSelect.Checked);
      }

      private void CheckBoxEnableRoleSelect_CheckedChanged(object sender, EventArgs e)
      {
         EnableRoleSelectItems(this.checkBoxEnableRoleSelect.Checked);
      }

      private List<string> _uidList;
      private PresentationContextList _pcList;

      public List<string> UidList
      {
         get { return _uidList; }
         set { _uidList = value; }
      }

      public PresentationContextList PcList
      {
         get { return _pcList; }
         set { _pcList = value; }
      }

      private bool GetTransferSyntaxCheckedState(string transferSyntax)
      {
         bool isChecked = false;
         foreach(string uidEntry in _uidList)
         {
            PresentationContextEntry pcEntry;
            if (_pcList._pcList.TryGetValue(uidEntry, out pcEntry))
            {
               isChecked = isChecked || pcEntry._pcList.Contains(transferSyntax);
            }
         }
         return isChecked;
      }

      private void LoadTransferSyntaxes()
      {
        foreach (KeyValuePair<string,TransferSyntaxEntry> kvp in _pcList._masterTransferSyntaxList._tsList)
        {
           if (kvp.Value._supported)
           {
              ListViewItem item = listViewTransferSyntax.Items.Add(kvp.Value._transferSyntax);
              item.SubItems.Add(kvp.Value._name);
              item.Checked = GetTransferSyntaxCheckedState(kvp.Value._transferSyntax);
           }
        }
         StorageClassesControl.SizeColumns(listViewTransferSyntax);
      }

      private void LoadRoleSelectItems()
      {
         this.checkBoxEnableRoleSelect.Checked = false;
         this.radioButtonUserRoleAccept.Checked = false;
         this.radioButtonUserRoleTurnDown.Checked = false;
         this.radioButtonProviderRoleAccept.Checked = false;
         this.radioButtonProviderRoleTurnDown.Checked = false;
         foreach (string uid in _uidList)
         {
            PresentationContextEntry pcEntry;
            if (PcList._pcList.TryGetValue(uid, out pcEntry))
            {
               this.checkBoxEnableRoleSelect.Checked |= pcEntry._roleSelectionItem.Enabled;

               this.radioButtonUserRoleAccept.Checked |= (pcEntry._roleSelectionItem.UserRoleProposal == 1);
               this.radioButtonUserRoleTurnDown.Checked |= !radioButtonUserRoleAccept.Checked;

               this.radioButtonProviderRoleAccept.Checked |= (pcEntry._roleSelectionItem.ProviderRoleProposal == 1);
               this.radioButtonProviderRoleTurnDown.Checked |= !radioButtonProviderRoleAccept.Checked;
            }
         }
         EnableRoleSelectItems();
      }

      private void PresentationContext_Load(object sender, EventArgs e)
      {
         StorageClassesControl.SetDoubleBuffered(listViewTransferSyntax);
         if (_uidList.Count == 1)
         {
            string uid = _uidList[0];
            PresentationContextEntry pcEntry;
            if (PcList._pcList.TryGetValue(uid, out pcEntry))
            {
               textBoxName.Text = pcEntry._name;
               textBoxUid.Text = uid;
            }
         }
         else
         {
            textBoxName.Text = "Multiple";
            textBoxUid.Text = "Multiple";
         }
         LoadTransferSyntaxes();
         LoadRoleSelectItems();
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         foreach (string uidEntry in _uidList)
         {
            PresentationContextEntry pcEntry;
            if (_pcList._pcList.TryGetValue(uidEntry, out pcEntry))
            {
               // Role Selection
               if (pcEntry._roleSelectionItem.Enabled != this.checkBoxEnableRoleSelect.Checked)
               {
                  pcEntry._roleSelectionItem.Enabled = this.checkBoxEnableRoleSelect.Checked;
                  _isDirty = true;
               }

               int userRoleProposal = this.radioButtonUserRoleAccept.Checked ? 1 : 0;
               if (pcEntry._roleSelectionItem.UserRoleProposal != userRoleProposal)
               {
                  pcEntry._roleSelectionItem.UserRoleProposal = userRoleProposal;
                  _isDirty = true;
               }

               int providerRoleProposal = this.radioButtonProviderRoleAccept.Checked ? 1 : 0;
               if (pcEntry._roleSelectionItem.ProviderRoleProposal != providerRoleProposal)
               {
                  pcEntry._roleSelectionItem.ProviderRoleProposal = providerRoleProposal;
                  _isDirty = true;
               }

               // Transfer Syntaxes
               foreach (ListViewItem item  in listViewTransferSyntax.Items)
               {
                  string transferSyntax = item.Text;

                  if (item.Checked)
                  {
                     if (!pcEntry._pcList.Contains(transferSyntax))
                     {
                        pcEntry._pcList.Add(transferSyntax);
                        
                        _isDirty = true ;
                     }
                  }
                  else
                  {
                     if (pcEntry._pcList.Contains(transferSyntax))
                     {
                        pcEntry._pcList.Remove(transferSyntax);
                        
                        _isDirty = true ;
                     }
                  }
               }
            }
         }
         DialogResult = DialogResult.OK;
      }
      
      public bool IsDirty
      {
         get
         {
            return _isDirty ;
         }
      }
      
      private bool _isDirty = false ;
   }
}
