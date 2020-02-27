// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Leadtools.Medical.Rules.AddIn.Controls
{
   public partial class AssemblyChooserDialog : Form
   {
      private List<AssemblyReference> _ExistingReferences;
      private List<string> _ExistingNamespaces;

      public event EventHandler SaveOptions;

      public List<AssemblyReference> References
      {
         get
         {
            List<AssemblyReference> references = new List<AssemblyReference>();

            foreach (ListViewItem item in listViewReferences.Items)
            {
               AssemblyReference reference = item.Tag as AssemblyReference;

               if(!ShouldExclude(reference.Name))
                  references.Add(item.Tag as AssemblyReference);
            }
            return references;
         }
      }

      public List<string> Namespaces
      {
         get
         {
            List<string> namespaces = new List<string>();

            foreach (string line in textBoxNamespaces.Lines)
            {
               if(!string.IsNullOrEmpty(line))
                  namespaces.Add(line);
            }
            return namespaces;
         }
      }

      private List<AssemblyReference> _ExcludedReferences = new List<AssemblyReference>();

      public List<AssemblyReference> ExcludedReferences
      {
         get
         {
            return _ExcludedReferences;
         }
      }

      protected void OnSaveOptions()
      {
         if (SaveOptions != null)
            SaveOptions(this, EventArgs.Empty);
      }

      public AssemblyChooserDialog(List<AssemblyReference> existingReferences,List<string> existingNamespaces)
      {        
         InitializeComponent();
         _ExistingReferences = existingReferences;
         _ExistingNamespaces = existingNamespaces;
      }

      private bool ShouldExclude(string name)
      {
         AssemblyReference reference = (from r in _ExcludedReferences
                                        where name.ToLower() == r.Name.ToLower()
                                        select r).FirstOrDefault();

         return reference != null;
      }

      private void toolStripButtonAdd_Click(object sender, EventArgs e)
      {         
         using (ReferenceDialog referenceDialog = new ReferenceDialog(_ExistingReferences))
         {
            referenceDialog.SetSavedReferences(Module._Options.References);
            referenceDialog.ExcludedReferences.AddRange(_ExcludedReferences);
            if (referenceDialog.ShowDialog(this) == DialogResult.OK)
            {               
               foreach (AssemblyReference reference in referenceDialog.GetAllReferences())
               {
                  ListViewItem r = (from i in listViewReferences.Items.OfType<ListViewItem>()
                                        where (i.Tag as AssemblyReference).Name == reference.Name
                                        select i).FirstOrDefault();

                  if (r == null)
                  {
                     ListViewItem item = listViewReferences.Items.Add(reference.Name);

                     item.SubItems.Add(reference.Version);
                     item.Tag = reference;
                  }
               }
            }

            if (referenceDialog.SaveReferences)
            {
               Module._Options.References = referenceDialog.GetSavedReferences();
               OnSaveOptions();
            }
         }
      }

      private void AssemblyChooserDialog_Load(object sender, EventArgs e)
      {
         LoadExisting();         
      }     

      private void LoadExisting()
      {
         if (_ExistingReferences != null)
         {
            foreach (AssemblyReference reference in _ExistingReferences)
            {
               ListViewItem item = listViewReferences.Items.Add(reference.Name);

               item.SubItems.Add(reference.Version);
               item.Tag = reference;
               if (ShouldExclude(reference.Name))
               {
                  item.BackColor = SystemColors.InactiveCaption;                  
               }
            }
         }

         textBoxNamespaces.Lines = _ExistingNamespaces.ToArray();
      }

      private void listViewReferences_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (listViewReferences.SelectedItems.Count > 0)
         {
            AssemblyReference reference = listViewReferences.SelectedItems[0].Tag as AssemblyReference;

            toolStripButtonDelete.Enabled = listViewReferences.SelectedItems.Count > 0 && !ShouldExclude(reference.Name);
         }
      }

      private void toolStripButtonDelete_Click(object sender, EventArgs e)
      {
         listViewReferences.Items.Remove(listViewReferences.SelectedItems[0]);
      }
   }
}
