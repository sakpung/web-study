// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Windows.Forms;
using Leadtools.Dicom.Common.Anonymization;
using Leadtools.Dicom;
using Leadtools.Dicom.Common.Extensions;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Drawing;
using System.Reflection;
using Leadtools.Medical.Winforms.Anonymize;
using Leadtools.Medical.Winforms.DatabaseManager.Export;
using System.Diagnostics;

namespace Leadtools.Medical.Winforms.Anonymize
{
   public partial class AnonymizeOptionsView : UserControl
   {
      //private const int TAG_COLUMN = 0;
      //private const int DESCRIPTION_COLUMN = 1;
      private const int TAGS_VALUE_COLUMN = 2;

      // private Anonymizer _anonymizer;

      private bool _scriptsModified;
      private bool _isDirty;
      private string _oldValue;
      private bool _changeNameMode;

      public AnonymizeOptionsView()
      {
         InitializeComponent();
         RegisterEvents();

         _isDirty = false;
         _changeNameMode = false;
         _scriptsModified = false;
      }

      public bool SaveButtonVisible
      {
         get
         {
            return toolStripButtonSave.Visible;
         }
         set
         {
            toolStripButtonSave.Visible = value;
         }
      }

      private void RegisterEvents()
      {
         // Scripts Toolstrip buttons
         toolStripButtonAddEmpty.Click +=toolStripButtonAddEmpty_Click;
         toolStripButtonAddDefault.Click += toolStripButtonAddDefault_Click;
         toolStripButtonClone.Click +=toolStripButtonCloneScript_Click;
         toolStripButtonDelete.Click += toolStripButtonDeleteScript_Click;
         toolStripButtonActivate.Click +=toolStripButtonActivate_Click;
         toolStripButtonSave.Click += toolStripButtonSave_Click;

         // Script Definition Toolstrip buttons
         toolStripButtonInsertTag.Click +=toolStripButtonInsertTag_Click;
         toolStripButtonDeleteTag.Click +=toolStripButtonDeleteTag_Click;

         // Listview events
         listViewAnonymizeScripts.ItemSelectionChanged += listViewAnonymizeScripts_SelectedIndexChanged;
         listViewAnonymizeScripts.AfterLabelEdit += listViewAnonymizeScripts_AfterLabelEdit;
         listViewAnonymizeScripts.MouseClick += listViewAnonymizeScripts_MouseClick;
         listViewAnonymizeScripts.ItemSelectionChanged += listViewAnonymizeScripts_ItemSelectionChanged;
         listViewAnonymizeScripts.BeforeLabelEdit += listViewAnonymizeScripts_BeforeLabelEdit;
         listViewAnonymizeScripts.KeyDown += listViewAnonymizeScripts_KeyDown;

         // DataGrid events
         treeGridViewTags.EditingControlShowing += treeGridViewTags_EditingControlShowing;
         treeGridViewTags.CellValidating += treeGridViewTags_CellValidating;

         treeGridViewTags.CellBeginEdit += treeGridViewTags_CellBeginEdit;
         // treeGridViewTags.CellFormatting += treeGridViewTags_CellFormatting;
         treeGridViewTags.CellEndEdit += treeGridViewTags_CellEndEdit;
         treeGridViewTags.DataError += treeGridViewTags_DataError;

         // IsDirty Handlers
      }

      void listViewAnonymizeScripts_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyData == Keys.F2 && listViewAnonymizeScripts.SelectedItems.Count > 0)
         {
            ListViewItem lvi = listViewAnonymizeScripts.SelectedItems[0];
            EnterChangeNameMode(lvi);
         }
      }

      void listViewAnonymizeScripts_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
      {
         UpdateUI();
      }

      void listViewAnonymizeScripts_MouseClick(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Right)
         {
            if (listViewAnonymizeScripts.FocusedItem.Bounds.Contains(e.Location))
            {
               contextMenuStrip.Show(Cursor.Position);
            }
         } 
}

      private void UpdateUI()
      {
         bool itemsSelected = listViewAnonymizeScripts.SelectedItems.Count > 0;
         toolStripButtonSave.Enabled = _isDirty;

         toolStripButtonClone.Enabled = itemsSelected;
         toolStripButtonDelete.Enabled = itemsSelected;
         toolStripButtonActivate.Enabled = itemsSelected;

         // Script Definition Toolstrip buttons
         toolStripButtonInsertTag.Enabled = itemsSelected;
         toolStripButtonDeleteTag.Enabled = itemsSelected;

         //
         foreach(ListViewItem lvi in listViewAnonymizeScripts.Items)
         {
            if (lvi == null)
            {
               break;
            }

            if (lvi.Tag == null)
            {
               break;
            }

            AnonymizeScript script = lvi.Tag as AnonymizeScript;
            if (script != null)
            {
               if (string.Equals(_scripts.ActiveScriptName, script.FriendlyName, StringComparison.OrdinalIgnoreCase))
               {
                  lvi.ImageIndex = 0;
               }
               else
               {
                  lvi.ImageIndex = -1;
               }
            }

         }
      }

      public event EventHandler SettingsChanged;
      // public event EventHandler SaveClicked;
      public event EventHandler<SaveAnonymizeSettingsEventArgs>SaveAnonymizeSettings;

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

       private void OnSetIsDirty(object sender, EventArgs e)
      {
         try
         {
            _isDirty = true;
            OnSettingsChanged(sender, e);
            //if (sender == checkBoxLowercase)
            //{
            //   if (ComplexityLowerCaseChanged != null)
            //      ComplexityLowerCaseChanged(sender, e);
            //}
            //else if (sender == checkBoxUppercase)
            //{
            //   if (ComplexityUpperCaseChanged != null)
            //      ComplexityUpperCaseChanged(sender, e);
            //}
           
         }
         catch (Exception)
         {
            System.Diagnostics.Debug.Assert(false);
         }
      }

      private void SetDirty()
      {
         _scriptsModified = true;
         _isDirty = true;
         OnSetIsDirty(null, null);
         UpdateUI();
      }

      private void ClearDirty()
      {
         _isDirty = false;
         UpdateUI();
      }

      public bool IsDirty
      {
         get
         {
            return _isDirty;
         }
      }

      public void ChangesCommited()
      {
         _isDirty = false;
      }

      private void EnterChangeNameMode(ListViewItem lvi)
      {
         listViewAnonymizeScripts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
         listViewAnonymizeScripts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

         if (lvi != null)
         {
            _changeNameMode = true;
            lvi.BeginEdit();
         }
      }

      static void treeGridViewTags_DataError(object sender, DataGridViewDataErrorEventArgs e)
      {        
      }

      void treeGridViewTags_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
      {
         if (e.RowIndex <= treeGridViewTags.Rows.Count)
         {
            if (treeGridViewTags != null)
            {
               TagMacro macro = treeGridViewTags.Rows[e.RowIndex].Tag as TagMacro;
            }

            e.Cancel = e.ColumnIndex != TAGS_VALUE_COLUMN;
         }
      }

      void treeGridViewTags_CellEndEdit(object sender, DataGridViewCellEventArgs e)
      {
         TagMacro macro = treeGridViewTags.Rows[e.RowIndex].Tag as TagMacro;
         DataGridViewComboBoxCell cell = treeGridViewTags.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;

         if (cell != null && macro != null)
         {
            macro.Macro = cell.Value != null ? cell.Value.ToString() : string.Empty;
            if (_oldValue != macro.Macro)
            {
               SetDirty();
            }
         }
      }

      void treeGridViewTags_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
      {
         if (e.ColumnIndex == TAGS_VALUE_COLUMN)
         {
            object efv = e.FormattedValue;
            DataGridViewComboBoxCell cell = treeGridViewTags.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)treeGridViewTags.Columns[TAGS_VALUE_COLUMN];

            if (!column.Items.Contains(efv))
               column.Items.Add(efv);

            if(cell != null)
            {
               cell.Value = efv;
            }
         }
      }

      void treeGridViewTags_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
      {
         DataGridViewComboBoxEditingControl column = e.Control as DataGridViewComboBoxEditingControl;

         if (column != null)
         {
            column.DropDownStyle = ComboBoxStyle.DropDown;
            _oldValue = column.Text;
         }
      }

      private void AddToList(string macro)
      {
         DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)treeGridViewTags.Columns[TAGS_VALUE_COLUMN];

         if (!column.Items.Contains(macro))
         {
            column.Items.Add(macro);
         }
      }

       private DicomTagNode AddAnonymizationTag(AnonymizeScript selectedScript, long tag, string name, string macro)
      {
         DicomTag dicomTag = DicomTagTable.Instance.Find(tag);
         DicomTagNode node = new DicomTagNode();

          node.CreateCells(treeGridViewTags);
         node.SetValues(string.Format("({0:X4},{1:X4})", tag.GetGroup(), tag.GetElement()), name, macro);
            treeGridViewTags.Rows.Add(node);

         // treeGridViewTags.Rows.Add(node);
         node.DicomTag = dicomTag;
         // node.Image = Resources.Tag_16x16;

         //if (dicomTag != null && dicomTag.VR == DicomVRType.SQ)
         //   node.Image = Resources.Tags_16x16;
          Anonymizer selectedAnonymizer = null;
          if (selectedScript != null)
          {
             selectedAnonymizer = selectedScript.Anonymizer;
          }
         if (selectedAnonymizer != null)
         {
            selectedAnonymizer[tag] = macro;
            node.Tag = selectedAnonymizer.FindTag(tag);
            return node;
         }
         return null;
      }

      private void InitializeMacroCombo(AnonymizeScript selectedScript)
       {
          DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)treeGridViewTags.Columns[TAGS_VALUE_COLUMN];

          column.Items.Clear();
          if (selectedScript == null)
             return;

          column.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
          Anonymizer selectedAnonymizer = selectedScript.Anonymizer;
          if (selectedAnonymizer != null)
          {
             foreach (string key in selectedAnonymizer.MacroProcessor.Macros.Keys)
             {
                column.Items.Add(string.Format("${{{0}}}", key));
             }

             column.Items.Add("${random_string(5)}");
             column.Items.Add("${add_days(7)}");
             column.Items.Add("${add_days(5)}");
             column.Items.Add("${random_time(05:00:00)}");
             column.Items.Add("${replace}");
          }
       }

      private void LoadMacros(AnonymizeScript selectedScript)
      {
         treeGridViewTags.Rows.Clear();

         ObservableCollection<TagMacro> macros = new ObservableCollection<TagMacro>();

         if (selectedScript != null)
         {
            macros = selectedScript.Anonymizer.TagMacros;
         }

         foreach (TagMacro macro in macros)
         {
            DicomTag dicomTag = DicomTagTable.Instance.Find(macro.Tag);
            string name = dicomTag != null ? dicomTag.Name : string.Empty;
            DicomTagNode node = new DicomTagNode();

            string sValue = string.Format("{0:X4},{1:X4}", macro.Tag.GetGroup(), macro.Tag.GetElement());
            // bool bRet = node.SetValues(sValue, name, macro.Macro);

            // DataGridViewRow row = new DataGridViewRow();
            node.CreateCells(treeGridViewTags);
            node.SetValues(sValue, name, macro.Macro);
            treeGridViewTags.Rows.Add(node);

            node.DicomTag = dicomTag;
            node.Tag = macro;
            AddToList(macro.Macro);

            //if (dicomTag != null)
            //{
            //   if (dicomTag.VR == DicomVRType.SQ)
            //      node.Image = Resources.Tags_16x16;
            //   else
            //      node.Image = Resources.Tag_16x16;
            //}
         }
         // treeGridViewTags.Refresh();
      }

      //public Anonymizer Anonymizer
      //{
      //   get
      //   {
      //      if (_anonymizer == null)
      //      {
      //         _anonymizer = new Anonymizer(true);
      //      }
      //      return _anonymizer;
      //   }
      //   set { _anonymizer = value; }
      //}

      // string _filename = @"d:\erase2\bbb";

      private AnonymizeScripts _scripts;
      public AnonymizeScripts AnonymizeScripts
      {
         get
         {
            return _scripts;
         }

         set
         {
            _scripts = value;
         }
      }

      public bool ScriptsModified
      {
         get { return _scriptsModified; }
      }

      //public void LoadScriptList()
      //{
      //   try
      //   {
      //      _scripts = Extensions.DeserializeFromXml<AnonymizeScripts>(_filename);
      //   }
      //   catch (Exception)
      //   {
      //   }

      //   if (_scripts == null)
      //   {
      //      _scripts = new AnonymizeScripts(true);
      //   }
      //}

      private void UpdateScriptDataGrid(AnonymizeScript selectedScript)
      {
         InitializeMacroCombo(selectedScript);
         LoadMacros(selectedScript);
      }

      private void SelectActiveScript()
      {
         if (_scripts != null)
         {
            foreach (AnonymizeScript script in _scripts.Scripts)
            {
               ListViewItem lvi = listViewAnonymizeScripts.Items.Add(script.FriendlyName);
               lvi.Tag = script;
               if (string.Equals(_scripts.ActiveScriptName, script.FriendlyName, StringComparison.OrdinalIgnoreCase))
               {
                  listViewAnonymizeScripts.Items[lvi.Index].Selected = true;
                  listViewAnonymizeScripts.Select();
               }
            }
         }
      }

      public void Initialize()
      {
           DicomEngine.Startup();

         // LoadScriptList();
         listViewAnonymizeScripts.Items.Clear();

         // Select
         SelectActiveScript();

         AnonymizeScript selectedScript = listViewAnonymizeScripts.GetSelectedScript();
         UpdateScriptDataGrid(selectedScript);

         listViewAnonymizeScripts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
         listViewAnonymizeScripts.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

         _isDirty = false;
      }

      protected override void OnLoad(EventArgs e)
      {
         if (DesignMode)
            return;

         Initialize();

         // Call the base class OnLoad to ensure any delegate event handlers are still callled
         base.OnLoad(e);
      }


      private void toolStripButtonAddEmpty_Click(object sender, EventArgs e)
      {
         string newScriptName = _scripts.GetNewScriptName(AnonymizeScripts.ScriptNameEnum.New);
         AnonymizeScript newScript = new AnonymizeScript(newScriptName, false);

         _scripts.Add(newScript);
         ListViewItem lvi = listViewAnonymizeScripts.Items.Add(newScriptName);
         lvi.Tag = newScript;
         EnterChangeNameMode(lvi);
         SetDirty();
      }

      private void toolStripButtonAddDefault_Click(object sender, EventArgs e)
      {
         string newScriptName = _scripts.GetNewScriptName(AnonymizeScripts.ScriptNameEnum.Default);
         AnonymizeScript newScript = new AnonymizeScript(newScriptName, true);
         _scripts.Add(newScript);
         ListViewItem lvi = listViewAnonymizeScripts.Items.Add(newScriptName);
         lvi.Tag = newScript;
         EnterChangeNameMode(lvi);
         SetDirty();
      }

      private void DeleteScript()
      {
         if (listViewAnonymizeScripts.SelectedItems.Count > 0)
         {
            ListViewItem item = listViewAnonymizeScripts.SelectedItems[0];
            _scripts.Delete(item.Text);
            listViewAnonymizeScripts.Items.Remove(item);

            if (listViewAnonymizeScripts.Items.Count > 0)
            {
               listViewAnonymizeScripts.Items[0].Selected = true;
               listViewAnonymizeScripts.Select();
            }
         }
         SetDirty();
      }

      private void toolStripButtonDeleteScript_Click(object sender, EventArgs e)
      {
         DeleteScript();
      }

      private void CloneScript()
      {
         AnonymizeScript selectedScript = listViewAnonymizeScripts.GetSelectedScript();
         if (selectedScript != null)
         {
            string newScriptName = string.Format("{0} Copy", selectedScript.FriendlyName);
            if (_scripts.ScriptExists(newScriptName))
            {
               newScriptName = _scripts.GetNewScriptName(AnonymizeScripts.ScriptNameEnum.Copy);
            }
            AnonymizeScript newScript = new AnonymizeScript(newScriptName, selectedScript);
            _scripts.Add(newScript);
            ListViewItem lviNew = listViewAnonymizeScripts.Items.Add(newScriptName);
            lviNew.Tag = newScript;
            EnterChangeNameMode(lviNew);
            SetDirty();
         }
      }

      private void toolStripButtonCloneScript_Click(object sender, EventArgs e)
      {
         CloneScript();
      }

      private void ActivateScript()
      {
         AnonymizeScript selectedScript = listViewAnonymizeScripts.GetSelectedScript();
         _scripts.SetActive(selectedScript);
         UpdateUI();
         SetDirty();
      }

      private void toolStripButtonActivate_Click(object sender, EventArgs e)
      {
         ActivateScript();
      }

      void toolStripButtonSave_Click(object sender, EventArgs e)
      {
         if (SaveAnonymizeSettings != null)
         {
            SaveAnonymizeSettingsEventArgs args = new SaveAnonymizeSettingsEventArgs(_scripts);
            SaveAnonymizeSettings(sender, args);
            if (args.Handled)
            {
               ClearDirty();
            }
         }

         //if (SaveClicked != null)
         //{
         //   SaveClicked(sender, e);
         //}
         ////_scripts.SerializeToXml(_filename);
         ////ClearDirty();
         
      }

      private void listViewAnonymizeScripts_SelectedIndexChanged(object sender, EventArgs e)
      {
         AnonymizeScript selectedScript = listViewAnonymizeScripts.GetSelectedScript();
         UpdateScriptDataGrid(selectedScript);
      }

       private List<long> GetTags()
      {
         List<long> tags = new List<long>();

         foreach (DataGridViewRow node in treeGridViewTags.Rows)
         {
            DicomTagNode dicomTagNode = node as DicomTagNode;
            if (dicomTagNode != null)
            {
               tags.Add(dicomTagNode.DicomTag.Code);
            }
         }
         return tags;
      }

       private string GetDefaultMacro(DicomTag tag)
      {
         string macro;

         if (tag == null || tag.VR == DicomVRType.UN)
            return "${empty}";

         switch (tag.VR)
         {
            case DicomVRType.UI:
               macro = "${uid}";
               break;
            case DicomVRType.DA:
            case DicomVRType.DT:
               macro = "${random_date}";
               break;
            case DicomVRType.TM:
               macro = "${random_time}";
               break;
            case DicomVRType.PN:
               macro = "${name}";
               break;
            case DicomVRType.CS:
            case DicomVRType.LO:
            case DicomVRType.LT:
            case DicomVRType.UT:
               macro = "${random_string}";
               break;
            case DicomVRType.SH:
               macro = "${random_string(16)}";
               break;
            default:
               macro = "${empty}";
               break;
         }

         AddToList(macro);
         return macro;
      }


      // Modifying Script
      private void toolStripButtonInsertTag_Click(object sender, EventArgs e)
      {
         List<long> tags = GetTags();
         using (InsertElementDlg dlgInsert = new InsertElementDlg(tags))
         {
            if (dlgInsert.ShowDialog(this) == DialogResult.OK)
            {
               AnonymizeScript selectedScript = listViewAnonymizeScripts.GetSelectedScript();
               DicomTagNode node = null;

               foreach (long tag in dlgInsert.Tags)
               {
                  DicomTag dicomTag = DicomTagTable.Instance.Find(tag);
                  DicomTagNode tagNode = AddAnonymizationTag(selectedScript, tag, dicomTag != null ? dicomTag.Name : string.Empty, GetDefaultMacro(dicomTag));
                  if (node == null)
                     node = tagNode;
               }
               if (dlgInsert.Tags.Count > 0)
               {
                  SetDirty();
               }
               if (node != null)
               {
                  treeGridViewTags.ClearSelection();

                  Console.WriteLine("Need to SelectRow");
                  //treeGridViewTags.SelectRow(node.Index);
                  treeGridViewTags.FirstDisplayedScrollingRowIndex = node.Index;
               }
            }
         }
      }

      private void toolStripButtonDeleteTag_Click(object sender, EventArgs e)
      {
         AnonymizeScript selectedScript = listViewAnonymizeScripts.GetSelectedScript();
         if (selectedScript == null)
            return;

         Anonymizer currentAnonymizer = selectedScript.Anonymizer;
         if (currentAnonymizer == null)
            return;

         List<DicomTagNode> nodes = (from n in treeGridViewTags.Rows.Cast<DataGridViewRow>()
                                     where n.Selected
                                     select n as DicomTagNode).ToList();

         foreach (DicomTagNode node in nodes)
         {
            // treeGridViewTags.Nodes.Remove(node);
            treeGridViewTags.Rows.Remove(node);
            currentAnonymizer.DeleteMacro(node.DicomTag.Code);
         }

         if (nodes.Count > 0)
            SetDirty();
      }

      void listViewAnonymizeScripts_BeforeLabelEdit(object sender, LabelEditEventArgs e)
      {
         if (_changeNameMode == false)
         {
            e.CancelEdit = true;
         }
      }

      private void listViewAnonymizeScripts_AfterLabelEdit(object sender, LabelEditEventArgs e)
      {
         _changeNameMode = false;
         if (e.Label == null)
         {
            return;
         }
         string labelTrimmed = e.Label.Trim();
         e.CancelEdit = true;
         
         //do something with variable trimmed
         ListViewItem lvi = listViewAnonymizeScripts.Items[e.Item];
         if (lvi != null)
         {
            AnonymizeScript script = lvi.Tag as AnonymizeScript;
            if (script != null)
            {
               if (_scripts.ScriptExists(labelTrimmed))
               {
                  // Check to see if name is just a case change (i.e.  'Script 1' --> 'SCRIPT 1')
                  if (string.Equals(script.FriendlyName, e.Label,StringComparison.OrdinalIgnoreCase))
                  {
                     listViewAnonymizeScripts.SelectedItems[0].Text = labelTrimmed;
                     script.FriendlyName = labelTrimmed;
                     if (string.Equals(_scripts.ActiveScriptName, labelTrimmed, StringComparison.Ordinal))
                     {
                        _scripts.ActiveScriptName = labelTrimmed;
                     }
                     SetDirty();
                  }

                  // Otherwise cancel edit if label already exists
                  e.CancelEdit = true;
               }
               else
               {
                  // Still cancel the edit, but replace with trimmed text
                  listViewAnonymizeScripts.SelectedItems[0].Text = labelTrimmed;
                  script.FriendlyName = labelTrimmed;
                  if (string.Equals(_scripts.ActiveScriptName, labelTrimmed, StringComparison.Ordinal))
                  {
                     _scripts.ActiveScriptName = labelTrimmed;
                  }
                  SetDirty();
               }
            }
         }
      }

      private void AnonymizeEditorControl_Load(object sender, EventArgs e)
      {
         UpdateUI();
      }

      // Context Menu events
      private void toolStripMenuItemRename_Click(object sender, EventArgs e)
      {
         if (listViewAnonymizeScripts.SelectedItems.Count > 0)
         {
            ListViewItem lvi = listViewAnonymizeScripts.SelectedItems[0];
            if (lvi != null)
            {
               EnterChangeNameMode(lvi);
            }
         }
      }

      private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
      {
         CloneScript();
      }

      private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
      {
         DeleteScript();
      }

      private void activateToolStripMenuItem_Click(object sender, EventArgs e)
      {
         ActivateScript();
      }

   }
}
