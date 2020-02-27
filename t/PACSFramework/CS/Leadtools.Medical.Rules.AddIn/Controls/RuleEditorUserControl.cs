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
using Leadtools.Medical.Rules.AddIn.Properties;
using ScintillaNET;
using Leadtools.Medical.Rules.AddIn.Common;
using Leadtools.Medical.Rules.AddIn.Controls;
using Leadtools.Medical.Rules.AddIn.Scripting;
using System.CodeDom.Compiler;
using Leadtools.Medical.Rules.AddIn.Dialogs;
using System.IO;

namespace Leadtools.Medical.Rules.AddIn
{
   public partial class RuleEditorUserControl : UserControl
   {
      private Scintilla _Editor;            
      private ScriptProcessor _ScriptProcessor = new ScriptProcessor(Module.ServiceDirectory);
      Dictionary<int, List<string>> _CompileErrors = new Dictionary<int, List<string>>();

      public event EventHandler<SaveRuleEventArgs> SaveRule;
      public event EventHandler SaveOptions;

      protected void OnSaveOptions()
      {
         if (SaveOptions != null)
            SaveOptions(this, EventArgs.Empty);
      }

      public string AETitle
      {
         get
         {
            return toolStripTextBoxAE.Text;
         }
         set
         {
            toolStripTextBoxAE.Text = value;
         }
      }

      public bool OnSaveRule(RuleItem rule)
      {
         if (SaveRule != null)
         {
            SaveRuleEventArgs e = new SaveRuleEventArgs(rule);

            SaveRule(this, e);
            return e.Cancel;
         }
         return false;
      }

      public RuleItem CurrentItem
      {
         get
         {
            if (listViewRules.SelectedItems.Count == 0)
               return null;

            return listViewRules.SelectedItems[0].Tag as RuleItem;
         }
      }
      public RuleEditorUserControl()
      {
         InitializeComponent();
         InitializeSyntaxEditor();
         InitializeEvents();         

         toolStripButtonDeleteRule.Enabled = false;
         toolStripTextBoxSearch.Scintilla = _Editor;
         ParentChanged += new EventHandler(RuleEditorUserControl_ParentChanged);            
         Application.Idle += new EventHandler(Application_Idle);         
      }

      void RuleEditorUserControl_ParentChanged(object sender, EventArgs e)
      {
         if(ParentForm!=null)
            ParentForm.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);
      }

      void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (ParentForm != null && ParentForm.DialogResult == DialogResult.OK)
         {
            Save();
            if (CurrentItem != null)
            {
               CurrentItem.Rule.Reset();
            }
         }
      }

      void Application_Idle(object sender, EventArgs e)
      {
         toolStripButtonCut.Enabled = _Editor.Selection.Length > 0;
         toolStripButtonCopy.Enabled = _Editor.Selection.Length > 0;
         toolStripButtonPrint.Enabled = _Editor.Text.Length > 0;
         toolStripButtonPaste.Enabled = _Editor.Clipboard.CanPaste;
         toolStripButtonUndo.Enabled = _Editor.NativeInterface.CanUndo();
         toolStripButtonRedo.Enabled = _Editor.NativeInterface.CanRedo();
         toolStripButtonCheck.Enabled = _Editor.Text.Length > 0;
      }

      public void SetRules(List<RuleItem> rules)
      {
         foreach (RuleItem item in rules)
         {
            AddRule(item, false);
         }

         if (listViewRules.Items.Count > 0)
            listViewRules.Items[0].Selected = true;
         listViewRules.Update();
      }      

      public bool Save()
      {
         if (CurrentItem != null && CurrentItem.Rule.IsDirty)
         {            
            return OnSaveRule(CurrentItem);            
         }
         return false;
      }

      private void InitializeSyntaxEditor()
      {         
         _Editor = new Scintilla();
         _Editor.Initialize();
         _Editor.Dock = DockStyle.Fill;
         _Editor.Leave += new EventHandler(Editor_Leave);         
         panelEditor.Controls.Add(_Editor);
      }      
      
      void Editor_Leave(object sender, EventArgs e)
      {
         if (CurrentItem != null)
         {
            CurrentItem.Rule.Script = _Editor.Text;
         }
      }

      private void InitializeEvents()
      {
         Array values = Enum.GetValues(typeof(ServerEvent));

         foreach (ServerEvent serverEvent in values)
         {
            comboBoxEvent.Items.Add(new Described<ServerEvent>(serverEvent));
         }                  
      }     

      private void toolStripButtonAddRule_Click(object sender, EventArgs e)
      {
         AddNewRule();
      }

      private void AddNewRule()
      {
         ServerRule rule = new ServerRule() { TrackChanges = true };
         RuleItem ruleItem = new RuleItem(rule, string.Empty);

         rule.Name = GetDefaultRuleName();
         rule.Active = true;
         rule.Priority = 1;
         rule.ServerEvent = ServerEvent.ReceiveCStoreRequest;

         AddRule(ruleItem, true);
         SetupUI(rule);
      }

      private void AddRule(RuleItem ruleItem, bool select)
      {
         ListViewItem item = new ListViewItem();

         item.Text = ruleItem.Rule.Name;
         item.SubItems.Add(ruleItem.Rule.Priority.ToString());
         item.SubItems.Add(new Described<ServerEvent>(ruleItem.Rule.ServerEvent).ToString());
         item.SubItems.Add(ruleItem.Rule.Active?"YES":"NO");
         item.Selected = select;
         item.Tag = ruleItem;

         if (select)
            listViewRules.Items.Insert(0, item);
         else
            listViewRules.Items.Add(item);
      }

      /// <summary>
      /// Gets the default name of the rule.  The names are numbered in consecutive order.
      /// </summary>
      /// <returns>Returns a name like Rule 1.</returns>
      private string GetDefaultRuleName()
      {
         int i = 1;         

         while (i <= listViewRules.Items.Count && listViewRules.Items.Count > 0)
         {
            string name = string.Format("Rule {0}", i).ToLower();            
            ListViewItem item = (from lvi in listViewRules.Items.Cast<ListViewItem>()
                                where lvi.Text.ToLower() == name
                                select lvi).FirstOrDefault();


            if (item == null)
               break;
            i++;            
         }

         return string.Format("Rule {0}", i);
      }

      private void SetupUI(ServerRule rule)
      {
         textBoxName.Text = rule.Name;
         numericUpDownPriority.Value = Convert.ToDecimal(rule.Priority);
         checkBoxActive.Checked = rule.Active;         
         _Editor.Text = rule.Script;
         _Editor.UndoRedo.EmptyUndoBuffer();
         _Editor.Modified = false;
         SetEvent(rule.ServerEvent);
      }     

      private void UpdateItem(ServerRule rule, ListViewItem item)
      {
         item.Text = rule.Name;
         item.SubItems[1].Text = rule.Priority.ToString();
         item.SubItems[2].Text = new Described<ServerEvent>(rule.ServerEvent).ToString();
         item.SubItems[3].Text = rule.Active ? "YES" : "NO";
      }      

      private void SetEvent(ServerEvent serverEvent)
      {
         foreach (Described<ServerEvent> de in comboBoxEvent.Items)
         {
            if (de == serverEvent)
            {
               comboBoxEvent.SelectedItem = de;
               labelParameters.Text = ScriptFunctions.GetScript(serverEvent);
               break;
            }
         }
      }

      private void listViewRules_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
      {
         if (e.Header != Active)
         {
            e.DrawDefault = true;
            return;
         }

         ServerRule rule = e.Item.Tag as ServerRule;

         if (rule != null && rule.Active)
         {
            Rectangle draw = new Rectangle(e.Bounds.Left, e.Bounds.Top, Resources.Check.Width, Resources.Check.Height);

            e.DrawBackground();
            e.Graphics.DrawImage(Resources.Check, draw);
         }
      }

      private void listViewRules_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
      {
         e.DrawDefault = true;
      }

      private void DeleteRule(RuleItem rule)
      {
         if(File.Exists(rule.FileName))
            File.Delete(rule.FileName);
      }

      private void ClearEditor()
      {
         textBoxName.Text = string.Empty;
         numericUpDownPriority.Value = 1;
         checkBoxActive.Checked = false;
         _Editor.Text = string.Empty;
         _Editor.UndoRedo.EmptyUndoBuffer();
         _Editor.Modified = false;
         SetEvent(ServerEvent.None);
      }

      private void toolStripButtonDeleteRule_Click(object sender, EventArgs e)
      {
         RuleItem rule = CurrentItem;

         if (CurrentItem != null)
         {
            int index = listViewRules.SelectedItems[0].Index;

            listViewRules.Items.Remove(listViewRules.SelectedItems[0]);
            DeleteRule(rule);
            if (listViewRules.Items.Count > 0 && index < listViewRules.Items.Count)
               listViewRules.SelectedIndices.Add(index);
            else if (listViewRules.Items.Count > 0 && index == listViewRules.Items.Count)
               listViewRules.SelectedIndices.Add(index - 1);
            else
               ClearEditor();
         }
      }      

      private void listViewRules_KeyDown(object sender, KeyEventArgs e)
      {
         if(e.KeyCode == Keys.Delete)
            toolStripButtonDeleteRule_Click(toolStripButtonDeleteRule, EventArgs.Empty);
      }  

      private void listViewRules_SelectedIndexChanged(object sender, EventArgs e)
      {
         toolStripButtonDeleteRule.Enabled = listViewRules.SelectedItems.Count > 0;
         if (toolStripButtonDeleteRule.Enabled)
         {
            RuleItem ruleItem = listViewRules.SelectedItems[0].Tag as RuleItem;

            SetupUI(ruleItem.Rule);
         }
      }

      private void textBoxName_TextChanged(object sender, EventArgs e)
      {
         if (CurrentItem != null)
         {
            CurrentItem.Rule.Name = textBoxName.Text;
         }
      }

      private void numericUpDownPriority_ValueChanged(object sender, EventArgs e)
      {
         if (CurrentItem != null)
         {
            CurrentItem.Rule.Priority = Convert.ToInt16(numericUpDownPriority.Value);
         }
      }

      private void comboBoxEvent_SelectionChangeCommitted(object sender, EventArgs e)
      {
         Described<ServerEvent> selectedEvent = (Described<ServerEvent>)comboBoxEvent.SelectedItem;

         if (CurrentItem != null)
         {
            CurrentItem.Rule.ServerEvent = selectedEvent;
            UpdateItem(CurrentItem.Rule, listViewRules.SelectedItems[0]);
         }

         labelParameters.Text = ScriptFunctions.GetScript(selectedEvent);
      }

      private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
      {
         if (CurrentItem != null)
         {
            CurrentItem.Rule.Active = checkBoxActive.Checked;
            UpdateItem(CurrentItem.Rule, listViewRules.SelectedItems[0]);
         }
      }

      private void Field_Leave(object sender, EventArgs e)
      {
         if (CurrentItem != null)
         {
            UpdateItem(CurrentItem.Rule, listViewRules.SelectedItems[0]);
         }
      }

      private void listViewRules_ItemDeselecting(object sender, ItemChangingEventArgs e)
      {
         if (CurrentItem != null && CurrentItem.Rule.IsDirty && CurrentItem.Rule.ServerEvent != ServerEvent.None)
         {
            bool cancel = OnSaveRule(CurrentItem);

            e.Cancel = cancel;
         }
      }

      private void syntaxRichTextBox_Leave(object sender, EventArgs e)
      {
         if (CurrentItem != null)
         {
            CurrentItem.Rule.Script = _Editor.Text;
         }
      }

      private void checkBoxRequest_CheckedChanged(object sender, EventArgs e)
      {
         if (CurrentItem != null)
         {            
            UpdateItem(CurrentItem.Rule, listViewRules.SelectedItems[0]);
         }
      }

      private void toolStripButtonPrint_Click(object sender, EventArgs e)
      {
         _Editor.Printing.Print(true);
      }      

      private void toolStripButtonExpand_Click(object sender, EventArgs e)
      {
         DetachedEditorDialog dlgEditor = new DetachedEditorDialog(_CompileErrors, (Described<ServerEvent>)comboBoxEvent.SelectedItem);

         dlgEditor.Code = _Editor.Text;
         dlgEditor.Text = "Editing: " + textBoxName.Text + " [" + comboBoxEvent.SelectedItem.ToString() + "]";
         dlgEditor.CurrentPosition = _Editor.CurrentPos;
         dlgEditor.AdditionalReferences.AddRange(GetReferences());
         dlgEditor.AdditionalNamespaces.AddRange(GetNamespaces());
         dlgEditor.Parameters = labelParameters.Text;
         if (dlgEditor.ShowDialog(this) == DialogResult.OK)
         {
            CurrentItem.Rule.Script = _Editor.Text = dlgEditor.Code;
            _Editor.CurrentPos = dlgEditor.CurrentPosition;
            if (dlgEditor.CompileErrors.Count > 0)
            {
               _CompileErrors.Clear();
               foreach (var kvp in dlgEditor.CompileErrors)
                  _CompileErrors.Add(kvp.Key, kvp.Value);
               _Editor.ClearAllAnnotations();
               _Editor.DisplayErrors(_CompileErrors);
            }
         }
      }

      private void toolStripButtonCut_Click(object sender, EventArgs e)
      {
         _Editor.Clipboard.Cut();
      }

      private void toolStripButtonCopy_Click(object sender, EventArgs e)
      {
         _Editor.Clipboard.Copy();
      }

      private void toolStripButtonPaste_Click(object sender, EventArgs e)
      {
         _Editor.Clipboard.Paste();
      }

      private void toolStripButtonUndo_Click(object sender, EventArgs e)
      {
         _Editor.UndoRedo.Undo();
      }

      private void toolStripButtonRedo_Click(object sender, EventArgs e)
      {
         _Editor.UndoRedo.Redo();
      }
      
      private void toolStripButtonCheck_Click(object sender, EventArgs e)
      {
         CompilerErrorCollection errors = new CompilerErrorCollection();
         int lineCount = 0;
         
         _Editor.ClearAllAnnotations();
         _CompileErrors.Clear();
         if (!_Editor.Compile((Described<ServerEvent>)comboBoxEvent.SelectedItem,GetReferences(), GetNamespaces(), errors, out lineCount))
         {            
            foreach (CompilerError error in errors)
            {
               int errorLine = (error.Line-1) - lineCount;
               string typeString = error.IsWarning ? "Warning" : "Error";

               if (!_CompileErrors.ContainsKey(errorLine))
                  _CompileErrors[errorLine] = new List<string>();

               typeString = string.Format("{0} [{1},{2}]: ", typeString, errorLine+1, error.Column);
               _CompileErrors[errorLine].Add(typeString + error.ErrorText);               
            }

            _Editor.DisplayErrors(_CompileErrors);
         }
      }

      private List<string> GetReferences()
      {
         List<string> references = new List<string>();

         //
         // Add global references
         //
         foreach (AssemblyReference reference in Module._Options.GlobalReferences)
         {
            FileInfo info = new FileInfo(reference.Name);

            if (info.Extension.ToLower() != ".dll")
               references.Add(reference.Name + ".dll");
            else
               references.Add(reference.Name);
         }

         //
         // Add script references
         //
         foreach (AssemblyReference reference in CurrentItem.Rule.References)
         {
            FileInfo info = new FileInfo(reference.Name);

            if (info.Extension.ToLower() != ".dll")
               references.Add(reference.Name + ".dll");
            else
               references.Add(reference.Name);
         }

         return references;
      }

      private List<string> GetNamespaces()
      {
         List<string> namespaces = Module._Options.GlobalNamespaces.Concat(CurrentItem.Rule.Namespaces).ToList();

         return namespaces;
      }

      private List<AssemblyReference> GetDefaultAssemblies()
      {
         List<AssemblyReference> references = new List<AssemblyReference>();
         ScriptEngine scriptEngine = new ScriptProcessor(Module.ServiceDirectory).GetScriptEngine();

         foreach (string reference in scriptEngine.ReferencedAssemblies)
         {
            string assemblyRef = reference.ToLower();

            //
            // If the reference isn't a file we will remove the extension.  This is done because the references
            // from the GAC are provide without the dll extension.
            //
            if (!File.Exists(assemblyRef))
            {
               assemblyRef = assemblyRef.Replace(".dll", string.Empty);
            }
            references.Add(new AssemblyReference() { Name = assemblyRef });
         }

         return references;
      }

      private void toolStripAssemblies_Click(object sender, EventArgs e)
      {
         using (AssemblyChooserDialog chooseDialog = new AssemblyChooserDialog(Module._Options.GlobalReferences, Module._Options.GlobalNamespaces))
         {
            chooseDialog.Text = "Add Global References";
            chooseDialog.SaveOptions += new EventHandler(chooseDialog_SaveOptions);
            chooseDialog.ExcludedReferences.AddRange(GetDefaultAssemblies());
            if (chooseDialog.ShowDialog(this) == DialogResult.OK)
            {
               Module._Options.GlobalReferences = chooseDialog.References;
               Module._Options.GlobalNamespaces = chooseDialog.Namespaces;
               Save();
            }
         }
      }

      void chooseDialog_SaveOptions(object sender, EventArgs e)
      {
         OnSaveOptions();
      }

      private void toolStripButtonScriptAssemblies_Click(object sender, EventArgs e)
      {
         List<AssemblyReference> allReferences = new List<AssemblyReference>();
         
         allReferences.AddRange(Module._Options.GlobalReferences);
         allReferences.AddRange(CurrentItem.Rule.References);         
         using (AssemblyChooserDialog chooseDialog = new AssemblyChooserDialog(allReferences, CurrentItem.Rule.Namespaces))
         {
            chooseDialog.Text = "Add Local References";
            chooseDialog.ExcludedReferences.AddRange(Module._Options.GlobalReferences);
            chooseDialog.ExcludedReferences.AddRange(GetDefaultAssemblies());
            if (chooseDialog.ShowDialog(this) == DialogResult.OK)
            {
               CurrentItem.Rule.References = chooseDialog.References;
               CurrentItem.Rule.Namespaces = chooseDialog.Namespaces;
               Save();
            }
         }
      }          
   }
}
