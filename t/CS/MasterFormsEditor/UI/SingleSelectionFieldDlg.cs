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
    public partial class SingleSelectionFieldDlg : Form
    {
        private MainForm _mainForm;
        private SingleSelectionField _singleSelection;
        private TextBox _currentTextBox;
        private bool _firstTb;
        private string _oldName;
        private bool _nameChanged;
        
        public SingleSelectionFieldDlg(MainForm mainForm, SingleSelectionField singleSelection)
        {
            this.HorizontalScroll.Enabled = false;
            this.HorizontalScroll.Visible = false;

            _mainForm = mainForm;
            _singleSelection = singleSelection;
            this.AutoScrollPosition = new Point(0, 0);
            _oldName = singleSelection.Name;
            _nameChanged = false;

            InitializeComponent();
        }

        private void SingleSelectionDlg_Load(object sender, EventArgs e)
        {
            _tbName.Text = _singleSelection.Name;
            _firstTb = true;
            this.SuspendLayout();
            for (int i = 0; i < _singleSelection.Fields.Count; ++i)
            {
                CreateNewField(_singleSelection.Fields[i].OmrField.Name);
                _currentTextBox.Text = _singleSelection.Fields[i].FieldValue;
            }
            this.ResumeLayout();

            if (_gbFields.Bottom >= _btnOK.Top)
            {
                _btnOK.Location = new Point(_btnOK.Location.X, _gbFields.Bottom + 20);
                _btnCancel.Location = new Point(_btnCancel.Location.X, _gbFields.Bottom + 20);
            }
        }

        private void CreateNewField(string fieldName)
        {
            int newFieldTop = -1;
            int tabIndex = -1;

            if (_firstTb)
            {
                newFieldTop = 20;
                tabIndex = 1;
                _firstTb = false;
            }
            
            if (_currentTextBox != null)
            {
                newFieldTop = _currentTextBox.Location.Y + _currentTextBox.Size.Height + 5;
                tabIndex = _currentTextBox.TabIndex + 1;
            }
            
            _currentTextBox = new TextBox();
            _currentTextBox.Location = new System.Drawing.Point(110, newFieldTop);
            _currentTextBox.Name = "tb" + fieldName.Replace(" ", "");
            _currentTextBox.Size = new System.Drawing.Size(211, 20);
            _currentTextBox.TabIndex = tabIndex;

            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(19, newFieldTop);
            lbl.Name = "lbl" + fieldName.Replace(" ", "");
            lbl.Size = new System.Drawing.Size(60, 13);
            lbl.Text = fieldName;

            _gbFields.Controls.Add(_currentTextBox);
            _gbFields.Controls.Add(lbl);
        }

        private void UpdateFields()
        {
            if (_tbName.Text != _singleSelection.Name)
            {
                _singleSelection.Name = _tbName.Text;
                _nameChanged = true;
            }
            
            foreach (Control control in _gbFields.Controls)
            {
                if (control is TextBox)
                {
                    TextBox tb = control as TextBox;
                    for (int i = 0; i < _singleSelection.Fields.Count; ++i)
                    {
                        if (control.Name.Equals("tb" + _singleSelection.Fields[i].OmrField.Name.Replace(" ", "")))
                        {
                            SingleField field = _singleSelection.Fields[i];
                            field.FieldValue = tb.Text;
                            _singleSelection.Fields[i] = field;
                            break;
                        }
                    }
                }
            }
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            UpdateFields();
            if(_nameChanged) 
                _mainForm.UpdateSingleSelection(_oldName, _singleSelection);
            this.Close();
        }
    }
}
