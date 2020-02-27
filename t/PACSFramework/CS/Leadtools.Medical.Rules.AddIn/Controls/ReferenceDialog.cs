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
using System.Diagnostics;
using System.Reflection;
using Leadtools.Dicom.AddIn;
using System.Runtime.InteropServices;
using System.IO;
using Leadtools.Medical.Rules.AddIn.Common;

namespace Leadtools.Medical.Rules.AddIn.Controls
{
   public partial class ReferenceDialog : Form
   {
      private List<AssemblyReference> _SavedReferences = new List<AssemblyReference>();
      private List<AssemblyReference> _ExistingReferences = new List<AssemblyReference>();
      private List<string> _SelectedReferences = new List<string>();

      private enum Exit
      {
         None,
         Ok,
         Cancel
      };

      private Exit _ExitType = Exit.None;

      private bool Is64Bit
      {
         get { return Marshal.SizeOf(typeof(IntPtr)) == 8; }
      }      
      
      private bool _SaveReferences;

      public bool SaveReferences
      {
         get
         {
            return _SaveReferences;
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

      public ReferenceDialog(List<AssemblyReference> existingReferences)
      {
         InitializeComponent();
         _ExistingReferences = existingReferences;
      }

      private void ReferenceDialog_Load(object sender, EventArgs e)
      {
         AdjustColumns(listViewAssembly);
         AdjustColumns(listViewFiles);
         LoadExistingFileReferences();         
      }

      private void AdjustColumns(ListView listview)
      {
         int width = listview.ClientRectangle.Width / listview.Columns.Count;

         foreach (ColumnHeader column in listview.Columns)
            column.Width = width;
      }

      private void LoadExistingFileReferences()
      {
         var references = from r in _ExistingReferences
                          where File.Exists(r.Name)
                          select r;

         foreach (var reference in references)
         {
            AddAssembly(listViewFiles, reference);
         }
      }

      private void LoadAssemblies()
      {
         using (ProgressDialog progress = new ProgressDialog())
         {
            AssemblyCacheEnum asmEnum;

            progress.Title = "Load .NET Assemblies";
            progress.Line1 = "Please wait...";
            progress.ShowDialog(this, DialogFlags.Modal | DialogFlags.NoMinimize | DialogFlags.AutoTime | DialogFlags.MarqueeProgress | DialogFlags.NoCancel);
            Application.DoEvents();
            asmEnum = new AssemblyCacheEnum(null);
            while (true)
            {
               string nextAsm = asmEnum.GetNextAssembly();

               if (_ExitType != Exit.None)
                  break;
               if (nextAsm != null)
               {
                  string info = AssemblyCache.QueryAssemblyInfo(nextAsm);
                  AssemblyName assemblyName = AssemblyName.GetAssemblyName(info);

                  if (assemblyName.ProcessorArchitecture == ProcessorArchitecture.Amd64 && Is64Bit ||
                     assemblyName.ProcessorArchitecture == ProcessorArchitecture.IA64 && Is64Bit ||
                     assemblyName.ProcessorArchitecture == ProcessorArchitecture.X86 && !Is64Bit ||
                     assemblyName.ProcessorArchitecture == ProcessorArchitecture.MSIL)
                  {
                     ListViewItem item;

                     progress.Line2 = "Loading " + assemblyName.Name;
                     item = AddAssembly(assemblyName);
                     if (ShouldExclude(assemblyName.Name))
                     {
                        item.BackColor = SystemColors.InactiveCaption;
                        item.Checked = true;
                     }
                     Application.DoEvents();
                  }
               }
               else
                  break;
            }
         }
         _SaveReferences = true;
      }

      private ListViewItem AddAssembly(AssemblyName assemblyName)
      {
         ListViewItem item = listViewAssembly.Items.Add(assemblyName.Name);

         item.SubItems.Add(assemblyName.Version.ToString());
         item.Tag = new AssemblyReference() { Name = assemblyName.Name, Version = assemblyName.Version.ToString() };
         return item;
      }

      private ListViewItem AddAssembly(ListView listview, AssemblyReference reference)
      {
         ListViewItem item = listview.Items.Add(reference.Name);
         
         item.SubItems.Add(reference.Version);
         item.Tag = reference;
         if (ShouldExclude(reference.Name))
            item.BackColor = SystemColors.InactiveCaption;
         return item;
      }

      private bool ShouldExclude(string name)
      {
         AssemblyReference reference = (from r in _ExcludedReferences
                                        where name.ToLower() == r.Name.ToLower()
                                        select r).FirstOrDefault();

         return reference != null;
      }

      private void ReferenceDialog_Shown(object sender, EventArgs e)
      {
         //
         // If we don't have the list of assemblies we need to load the assemblies from the gac.
         //
         if (_SavedReferences.Count == 0)
         {
            LoadAssemblies();
         }
         else
         {
            foreach (AssemblyReference reference in _SavedReferences)
            {
               ListViewItem item = AddAssembly(listViewAssembly, reference);

               if (ReferenceExist(reference.Name))
               {
                  item.ForeColor = Color.Red;
                  item.Checked = true;
               }

               if (ShouldExclude(reference.Name))
                  item.Checked = true;

               Application.DoEvents();
               if (_ExitType != Exit.None)
                  break;
            }
         }
      }

      public void SetSavedReferences(List<AssemblyReference> references)
      {
         _SavedReferences = references;
      }

      public List<AssemblyReference> GetSavedReferences()
      {
         List<AssemblyReference> references = new List<AssemblyReference>();

         foreach (ListViewItem item in listViewAssembly.Items)
         {
            AssemblyReference reference = item.Tag as AssemblyReference;

            references.Add(reference);
         }

         return references;
      }

      public List<AssemblyReference> GetAllReferences()
      {
         List<AssemblyReference> references = new List<AssemblyReference>();

         foreach (ListViewItem item in listViewAssembly.Items.Cast<ListViewItem>().Where( i => i.Checked))
         {
            AssemblyReference reference = item.Tag as AssemblyReference;

            if(!ShouldExclude(reference.Name))
               references.Add(reference);
         }

         foreach (ListViewItem item in listViewFiles.Items)
         {
            AssemblyReference reference = item.Tag as AssemblyReference;

            references.Add(reference);
         }

         return references;
      }

      private bool ReferenceExist(string name)
      {         
         AssemblyReference reference = (from r in _ExistingReferences
                                        where r.Name.ToLower() == name.ToLower()
                                        select r).FirstOrDefault();

         return reference != null;
      }

      private void toolStripButtonAdd_Click(object sender, EventArgs e)
      {
         if (openFileDialog.ShowDialog(this) == DialogResult.OK)
         {
            foreach (string file in openFileDialog.FileNames)
            {
               if (Utils.IsDotNetAssembly(file) && !ReferenceExist(file))
               {
                  AssemblyReference reference = new AssemblyReference();
                  FileVersionInfo version = FileVersionInfo.GetVersionInfo(file);

                  reference.Name = file;
                  reference.Version = version.FileVersion;

                  AddAssembly(listViewFiles, reference);
               }
               else
               {
               }
            }
         }
      }      

      private void toolStripButtonDelete_Click(object sender, EventArgs e)
      {
         listViewFiles.Items.Remove(listViewFiles.SelectedItems[0]);
      }

      private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (listViewFiles.SelectedItems.Count > 0)
         {
            AssemblyReference reference = listViewFiles.SelectedItems[0].Tag as AssemblyReference;

            toolStripButtonDelete.Enabled = listViewFiles.SelectedItems.Count > 0 && !ShouldExclude(reference.Name);
         }
      }

      private void listViewAssembly_ItemCheck(object sender, ItemCheckEventArgs e)
      {
         ListViewItem item = listViewAssembly.Items[e.Index];
         AssemblyReference reference = item.Tag as AssemblyReference;

         if (reference != null)
         {
            e.NewValue = ShouldExclude(reference.Name)?CheckState.Checked:e.NewValue;
         }
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         _ExitType = Exit.Ok;
      }

      private void buttonCancel_Click(object sender, EventArgs e)
      {
         _ExitType = Exit.Cancel;
      }
   }
}
