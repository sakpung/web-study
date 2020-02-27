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
    public partial class OmrDateFieldDlg : Form
    {
        private MainForm _mainForm;
        private OmrDateField _omrDateField;
        private string _oldName;
        private List<SingleSelectionField> _removedObjects;

        public OmrDateFieldDlg(MainForm mainForm, OmrDateField omrDateField)
        {
            InitializeComponent();

            _mainForm = mainForm;
            _omrDateField = omrDateField;
            _oldName = omrDateField.Name;
            PopulateData();

            _lbSelection.SelectedIndex = 0;
            _removedObjects = new List<SingleSelectionField>();
        }

        private void _btnOK_Click(object sender, EventArgs e)
        {
            _omrDateField.Name = _tbName.Text;
            _mainForm.UpdateOmrDateField(_oldName, _omrDateField);
        }

        private void PopulateData()
        {
            if (_omrDateField != null)
            {
                _tbName.Text = _omrDateField.Name;

                _lbSelection.Items.Add(IndexToField(0).Name);
                _lbSelection.Items.Add("Day Field: " + IndexToField(1).Name);
                _lbSelection.Items.Add("Day Field: " + IndexToField(2).Name);
                _lbSelection.Items.Add("Year Field: " + IndexToField(3).Name);
                _lbSelection.Items.Add("Year Field: " + IndexToField(4).Name);

            }
        }

        private SingleSelectionField IndexToField(int index)
        {
           switch (index)
           {
              case 0:
                 return _omrDateField.MonthField;
              case 1:
                 return _omrDateField.DayField.Fields[0];
              case 2:
                 return _omrDateField.DayField.Fields[1];
              case 3:
                 return _omrDateField.YearField.Fields[0];
              case 4:
                 return _omrDateField.YearField.Fields[1];
           }

           return null;
        }

        private void _btnEdit_Click(object sender, EventArgs e)
        {
            int index = _lbSelection.SelectedIndex;

            if (index != -1)
            {
                SingleSelectionFieldDlg dlg = new SingleSelectionFieldDlg(_mainForm, IndexToField(index));
                dlg.ShowDialog();
            }
        }
    }
}
