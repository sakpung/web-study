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
using Leadtools.Forms.Processing;

namespace CSMasterFormsEditor.UI
{
   public partial class TableRulesForm : Form
   {
      TableFormField _tableFormField;
      TableRules _oldTableRules;
      public bool RulesChanged
      {
         get;
         set;
      }
      public TableRulesForm(TableFormField tableFormField)
      {
         InitializeComponent();
         _tableFormField = tableFormField;
         _oldTableRules = tableFormField.Rules;
         RulesChanged = false;
         UpdateUI();
      }

      private void _ch_CheckedChanged(object sender, EventArgs e)
      {
         TableRules rules = TableRules.NoRules;
         if(_ch_RowsLineSeparator.Checked)
            rules |= TableRules.RowsLineSeparator;
         if(_ch_EqualFixedLineHeight.Checked)
            rules |= TableRules.EqualFixedLineHeight;
         if (_ch_EqualFixedRowHeight.Checked)
            rules |= TableRules.EqualFixedRowHeight;
         if(_ch_MultiPageTableHeaderRepeted.Checked)
            rules |= TableRules.MultiPageTableHeaderRepeted;
         _tableFormField.Rules = rules;
      }

      private void UpdateUI()
      {
         TableRules rules = _tableFormField.Rules;

         _ch_RowsLineSeparator.Checked = (rules & TableRules.RowsLineSeparator) == TableRules.RowsLineSeparator;
         _ch_EqualFixedLineHeight.Checked = (rules & TableRules.EqualFixedLineHeight) == TableRules.EqualFixedLineHeight;
         _ch_EqualFixedRowHeight.Checked = (rules & TableRules.EqualFixedRowHeight) == TableRules.EqualFixedRowHeight;
         _ch_MultiPageTableHeaderRepeted.Checked = (rules & TableRules.MultiPageTableHeaderRepeted) == TableRules.MultiPageTableHeaderRepeted;
      }

      private void TableRulesForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (_oldTableRules != _tableFormField.Rules)
            RulesChanged = true;
      }
   }
}
