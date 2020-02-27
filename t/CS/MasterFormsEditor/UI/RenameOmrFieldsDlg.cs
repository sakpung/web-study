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

namespace CSMasterFormsEditor.UI
{
    public partial class RenameOmrFieldsDlg : Form
    {
        private string _sampleName;
        private MainForm _mainForm;
        private int _omrFieldsCount;
        private List<string> _generatedNewNames;
        private List<string> _alphabets;
        
        public RenameOmrFieldsDlg(MainForm mainForm, int omrFieldsCount)
        {
            InitializeComponent();

            _omrFieldsCount = omrFieldsCount;
            _mainForm = mainForm;
            _generatedNewNames = new List<string>();
            _alphabets = GetAlphabets(omrFieldsCount);

            UpdateNames();

            this.ActiveControl = _txtPrefix;
        }

        public static List<string> GetAlphabets(int fieldsCount)
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

        private void UpdateNames()
        {
            _generatedNewNames.Clear();
            _sampleName = _txtPrefix.Text;
                        
            if (_rbNum1.Checked)
            {
                _numStartsWith.Enabled = false;
                _sampleName += "1";
                
                for (int i = 1; i <= _omrFieldsCount; ++i)
                {
                    string fieldName = _txtPrefix.Text + i.ToString();
                    _generatedNewNames.Add(fieldName);
                }
            }
            else if (_rbAlpha.Checked)
            {
                _numStartsWith.Enabled = false;
                _sampleName += "A";

                for (int i = 0; i < _omrFieldsCount; ++i )
                {
                    string fieldName = _txtPrefix.Text + _alphabets[i];

                    _generatedNewNames.Add(fieldName);
                }
            }
            else
            {
                _numStartsWith.Enabled = true;
                _sampleName += _numStartsWith.Value.ToString();
                for (int i = decimal.ToInt32(_numStartsWith.Value); i <= decimal.ToInt32(_numStartsWith.Value) + _omrFieldsCount; ++i)
                {
                    string fieldName = _txtPrefix.Text + i.ToString();
                    _generatedNewNames.Add(fieldName);
                }
            }

            _lblName.Text = _sampleName;
        }

        private void _txtPrefix_TextChanged(object sender, EventArgs e)
        {
            UpdateNames();
        }

        private void _rb_CheckedChanged(object sender, EventArgs e)
        {
            UpdateNames();
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            _mainForm.ApplyRenameMultipleFields(_generatedNewNames);
            this.Close();
        }

        private void _btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _numStartsWith_ValueChanged(object sender, EventArgs e)
        {
            UpdateNames();
        }
    }
}
