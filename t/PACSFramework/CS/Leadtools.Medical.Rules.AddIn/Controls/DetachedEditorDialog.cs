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
using ScintillaNET;
using System.CodeDom.Compiler;
using System.Reflection;
using Leadtools.Medical.Rules.AddIn.Scripting;

namespace Leadtools.Medical.Rules.AddIn.Controls
{
   public partial class DetachedEditorDialog : Form
   {
      private Scintilla _Editor;
      private const int LINE_NUMBERS_MARGIN_WIDTH = 35;      

      public string Code
      {
         get
         {
            return _Editor.Text;
         }
         set
         {
            _Editor.Text = value;
            _Editor.UndoRedo.EmptyUndoBuffer();
         }
      }

      public int CurrentPosition
      {
         get
         {
            return _Editor.CurrentPos;
         }
         set
         {
            _Editor.CurrentPos = value;
         }
      }

      private Dictionary<int, List<string>> _CompileErrors = new Dictionary<int, List<string>>();

      public Dictionary<int, List<string>> CompileErrors
      {
         get
         {
            return _CompileErrors;
         }
      }

      private List<string> _AdditionalReferences = new List<string>();

      public List<string> AdditionalReferences
      {
         get
         {
            return _AdditionalReferences;
         }
      }

      private List<string> _AdditionalNamespaces = new List<string>();

      public List<string> AdditionalNamespaces
      {
         get
         {
            return _AdditionalNamespaces;
         }
      }

      public string Parameters
      {
         set
         {
            labelParameters.Text = value;
         }
      }

      private ServerEvent _ServerEvent;

      public DetachedEditorDialog(Dictionary<int, List<string>> compileErrors, ServerEvent serverEvent)
      {
         InitializeComponent();
         InitializeSyntaxEditor();
         if (compileErrors.Count > 0)
         {
            foreach (var kvp in compileErrors)
               _CompileErrors.Add(kvp.Key, kvp.Value);
         }
         _ServerEvent = serverEvent;
      }

      private void DetachedEditorDialog_Load(object sender, EventArgs e)
      {
         Application.Idle += new EventHandler(Application_Idle);
         _Editor.DisplayErrors(_CompileErrors);         
      }

      void Application_Idle(object sender, EventArgs e)
      {
         toolStripButtonCut.Enabled = _Editor.Selection.Length > 0;
         toolStripButtonCopy.Enabled = _Editor.Selection.Length > 0;
         toolStripButtonPrint.Enabled = _Editor.Text.Length > 0;
         toolStripButtonPaste.Enabled = _Editor.Clipboard.CanPaste;
         toolStripButtonUndo.Enabled = _Editor.NativeInterface.CanUndo();
         toolStripButtonRedo.Enabled = _Editor.NativeInterface.CanRedo();
      }

      private void InitializeSyntaxEditor()
      {         
         _Editor = new Scintilla();
         _Editor.Initialize();
         _Editor.Dock = DockStyle.Fill;         
         panelEditor.Controls.Add(_Editor);

         toolStripTextSearch.Scintilla = _Editor;
      }

      private void toolStripButtonPrint_Click(object sender, EventArgs e)
      {
         _Editor.Printing.Print(true);
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

      private void toolStripButtonClose_Click(object sender, EventArgs e)
      {
         DialogResult = DialogResult.OK;
      }

      private void toolStripButtonCheck_Click(object sender, EventArgs e)
      {
         CompilerErrorCollection errors = new CompilerErrorCollection();
         int lineCount = 0;

         _Editor.ClearAllAnnotations();
         _CompileErrors.Clear();
         if (!_Editor.Compile(_ServerEvent, _AdditionalReferences, _AdditionalNamespaces, errors, out lineCount))
         {
            foreach (CompilerError error in errors)
            {
               int errorLine = (error.Line - 1) - lineCount;
               string typeString = error.IsWarning ? "Warning" : "Error";

               if (!_CompileErrors.ContainsKey(errorLine))
                  _CompileErrors[errorLine] = new List<string>();

               typeString = string.Format("{0} [{1},{2}]: ", typeString, errorLine + 1, error.Column);
               _CompileErrors[errorLine].Add(typeString + error.ErrorText);
            }

            _Editor.DisplayErrors(_CompileErrors);
         }
      }      
   }
}
