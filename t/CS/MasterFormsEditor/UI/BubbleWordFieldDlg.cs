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
    public partial class BubbleWordFieldDlg : Form
    {
        private MainForm _mainForm;
        private BubbleWordField _bubbleWordField;
        private string _oldName;
        private List<SingleSelectionField> _removedObjects;
        
        public BubbleWordFieldDlg(MainForm mainForm, BubbleWordField bubbleWordField)
        {
            InitializeComponent();

            _mainForm = mainForm;
            _bubbleWordField = bubbleWordField;
            _oldName = bubbleWordField.Name;
            PopulateData();

            _lbSelection.SelectedIndex = 0;
            _removedObjects = new List<SingleSelectionField>();
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            _bubbleWordField.Name = _tbName.Text;
            
            if (_rbCharacters.Checked)
                _bubbleWordField.ValueType = BubbleWordValueType.Character;
            else
                _bubbleWordField.ValueType = BubbleWordValueType.Numerical;

            for (int i = 0; i < _bubbleWordField.Fields.Count; ++i)
            {
                _bubbleWordField.Fields[i].Parent = _bubbleWordField.Name;
            }

            for (int i = 0; i < _removedObjects.Count; ++i)
            {
                _bubbleWordField.Fields.Remove(_removedObjects[i]);
            }
            
            _mainForm.UpdateBubbleWord(_oldName, _bubbleWordField);
        }

        private void PopulateData()
        {
            if (_bubbleWordField != null)
            {
                _tbName.Text = _bubbleWordField.Name;

                foreach (SingleSelectionField field in _bubbleWordField.Fields)
                {
                    _lbSelection.Items.Add(field.Name);
                }

                if (_bubbleWordField.ValueType == BubbleWordValueType.Character)
                    _rbCharacters.Checked = true;
                else
                    _rbNumerical.Checked = true;
            }
        }

        private void _btnEdit_Click(object sender, EventArgs e)
        {
            int index = _lbSelection.SelectedIndex;
            if (index != -1)
            {
                SingleSelectionFieldDlg dlg = new SingleSelectionFieldDlg(_mainForm, _bubbleWordField.Fields[index]);
                dlg.ShowDialog();
            }
        }

        private void _btnRemove_Click(object sender, EventArgs e)
        {
            int index = _lbSelection.SelectedIndex;
            if (index != -1)
            {
                _removedObjects.Add(_bubbleWordField.Fields[index]);
                _lbSelection.Items.RemoveAt(index);
            }
        }

        private static List<string> GetAlphabets(int fieldsCount)
        {
            List<string> list = new List<string>();

            for (char c = 'A'; c <= 'Z'; c++)
            {
                list.Add(c.ToString());
                if (list.Count == fieldsCount)
                    return list;
            }

            for (char c1 = 'A'; c1 <= 'Z'; c1++)
            {
                for (char c2 = 'A'; c2 <= 'Z'; c2++)
                {
                    list.Add(c1.ToString() + c2.ToString());
                    if (list.Count == fieldsCount)
                        return list;
                }
            }

            for (char c1 = 'A'; c1 <= 'Z'; c1++)
            {
                for (char c2 = 'A'; c2 <= 'Z'; c2++)
                {
                    for (char c3 = 'A'; c3 <= 'Z'; c3++)
                    {
                        list.Add(c1.ToString() + c2.ToString() + c3.ToString());
                        if (list.Count == fieldsCount)
                            return list;
                    }
                }
            }

            return list;
        }

        private void FillFieldsValues(SingleSelectionField field, BubbleWordValueType valueType)
        {
            if (valueType == BubbleWordValueType.Character)
            {
                List<string> alphabets = GetAlphabets(field.Fields.Count); 
                
                for (int i = 0; i < field.Fields.Count; ++i)
                {
                    SingleField singleField = field.Fields[i];
                    singleField.FieldValue = alphabets[i];
                    field.Fields[i] = singleField;
                }
            }
            else
            {
                for (int i = 0; i < field.Fields.Count; ++i)
                {
                    SingleField singleField = field.Fields[i];
                    singleField.FieldValue = i.ToString();
                    field.Fields[i] = singleField;
                }
            }
        }

        private void _rbCharacters_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbCharacters.Checked)
            {
                for (int i = 0; i < _bubbleWordField.Fields.Count; ++i)
                {
                    FillFieldsValues(_bubbleWordField.Fields[i], BubbleWordValueType.Character);
                }
            }
        }

        private void _rbNumerical_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbNumerical.Checked)
            {
                for (int i = 0; i < _bubbleWordField.Fields.Count; ++i)
                {
                    FillFieldsValues(_bubbleWordField.Fields[i], BubbleWordValueType.Numerical);
                }
            }
        }
    }
}
