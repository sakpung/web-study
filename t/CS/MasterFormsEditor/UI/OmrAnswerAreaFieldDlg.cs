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
   public partial class OmrAnswerAreaFieldDlg : Form
    {
        private MainForm _mainForm;
        private OmrAnswerAreaField _omrAnswerAreaField;
        private string _oldName;
        private List<SingleSelectionField> _removedObjects;
        
        public OmrAnswerAreaFieldDlg(MainForm mainForm, OmrAnswerAreaField omrAnswerAreaField)
        {
            InitializeComponent();

            _mainForm = mainForm;
            _omrAnswerAreaField = omrAnswerAreaField;
            _oldName = omrAnswerAreaField.Name;
            PopulateData();

            _lbSelection.SelectedIndex = 0;
            _removedObjects = new List<SingleSelectionField>();
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            _omrAnswerAreaField.Name = _tbName.Text;
            
            for (int i = 0; i < _omrAnswerAreaField.Answers.Count; ++i)
            {
               _omrAnswerAreaField.Answers[i].Parent = _omrAnswerAreaField.Name;
            }

            for (int i = 0; i < _removedObjects.Count; ++i)
            {
               _omrAnswerAreaField.Answers.Remove(_removedObjects[i]);
            }

            if(!_oldName.Equals(_omrAnswerAreaField.Name))
               _mainForm.UpdateOmrAnswerArea(_oldName, _omrAnswerAreaField);
        }

        private void PopulateData()
        {
            if (_omrAnswerAreaField != null)
            {
                _tbName.Text = _omrAnswerAreaField.Name;

                foreach (SingleSelectionField field in _omrAnswerAreaField.Answers)
                {
                    _lbSelection.Items.Add(field.Name);
                }
            }
        }

        private void _btnEdit_Click(object sender, EventArgs e)
        {
            int index = _lbSelection.SelectedIndex;
            if (index != -1)
            {
                SingleSelectionFieldDlg dlg = new SingleSelectionFieldDlg(_mainForm, _omrAnswerAreaField.Answers[index]);
                dlg.ShowDialog();
            }
        }

        private void _btnRemove_Click(object sender, EventArgs e)
        {
            int index = _lbSelection.SelectedIndex;
            if (index != -1)
            {
                _removedObjects.Add(_omrAnswerAreaField.Answers[index]);
                _lbSelection.Items.RemoveAt(index);
            }
        }        
    }
}
