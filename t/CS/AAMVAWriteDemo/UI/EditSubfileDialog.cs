using Leadtools.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AAMVAWriteDemo
{
   public partial class EditSubfileDialog : Form
   {

      private IDictionary<string, AAMVADataElementInfo> _dataElementInfo;
      private MainForm.SubfileSkeleton _subfileSkeleton;
      private CheckBox _cbDHS;
      private AAMVAJurisdiction _jurisdiction;

      public static HashSet<string> MandatoryDataElements = new HashSet<string>()
      {
         "DCA", "DCB", "DCD", "DBA", "DCS", "DAC", "DAD", "DBD", "DBB", "DBC", "DAY",
         "DAU", "DAG", "DAI", "DAJ", "DAK", "DAQ", "DCF", "DCG", "DDE", "DDF", "DDG"
      };

      public static HashSet<string> OptionalDataElements = new HashSet<string>()
      {
         "DAH", "DAZ", "DCI", "DCJ", "DCK", "DBN", "DBG", "DBS", "DCU", "DCE", "DCL", 
         "DCM", "DCN", "DCO", "DCP", "DCQ", "DCR", "DDA", "DDB", "DDC", "DDD", "DAW",
         "DAX", "DDH", "DDI", "DDJ", "DDK", "DDL"
      };

      public static HashSet<string> DHSDataElements = new HashSet<string>()
      {
         "DCK", "DDA", "DDB",// "DDD",  <-- only required if applicable to cardholder. if n/a, don't include it.
      };


      public enum EditMode
      {
         NewAddition,
         Edit
      }

      private EditMode _mode;
      private int _subfileIndex;
      private MainForm _parent;

      public EditSubfileDialog(MainForm parent, AAMVAJurisdiction jurisdiction, MainForm.SubfileSkeleton subfileSkeleton, int subfileIndex, EditMode mode)
      {
         InitializeComponent();
         this.Text = "Edit Subfile - " + subfileSkeleton.SubfileType.ToString();
         _subfileSkeleton = subfileSkeleton;
         _mode = mode;
         _parent = parent;
         _subfileIndex = subfileIndex;
         _jurisdiction = jurisdiction;
         _closeAction = CloseAction.Cancel;
         AddDataElementRows(MandatoryDataElements, 0);
         AddDataElementRows(OptionalDataElements, 1);
         if(subfileSkeleton.DataElements.Keys.Count > 0 )
         {
            RepopulateDataElements();
         }
      }

      private void RepopulateDataElements()
      {

         AAMVARegion rgn = AAMVAID.LookupRegion(_jurisdiction);
         string dateFormat = "";
         if (rgn == AAMVARegion.UnitedStates)
            dateFormat = "MMddyyyy";
         else
            dateFormat = "yyyyMMdd";

         foreach (TabPage tabPage in _tabControl.TabPages)
         {
            foreach(Control ctrl in tabPage.Controls)
            {
               if(ctrl is DataElementRowControl)
               {
                  DataElementRowControl row = (DataElementRowControl)ctrl;
                  AAMVADataElement dataElement = null;
                  try
                  {
                     dataElement = _subfileSkeleton.DataElements[row.ElementID];
                  }
                  catch
                  {
                     continue;
                  }
                     
                  if (dataElement != null)
                  {
                     if (!row.CheckBox.Checked)
                        row.CheckBox.Checked = true;

                     switch(row.ViewMode)
                     {
                        case DataElementRowControl.Mode.ComboBox:
                           row.ComboBox.SelectedValue = dataElement.Value;
                           break;
                        case DataElementRowControl.Mode.DatePicker:
                           DateTime dateTime;
                           DateTime.TryParseExact(dataElement.Value, dateFormat, null, System.Globalization.DateTimeStyles.None, out dateTime);
                           row.DateTimePicker.Value = dateTime;
                           break;
                        case DataElementRowControl.Mode.TextBox:
                           row.TextBox.Text = dataElement.Value;
                           break;
                     }
                  }

               }
            }
         }

      }

      private void AddDataElementRows(HashSet<string> values, int tabIndex)
      {
         _dataElementInfo = AAMVADataElementInfo.RetrieveAll(AAMVAVersion.Version2016);

         if (tabIndex == 0)
         {
            Label label = new Label();
            label.Text = "Per AAMVA CDS 2016 §D.12.5, mandatory data elements that call for variable length, alphabetical values will be filled with \"NONE\" if no value is provided.";
            label.Dock = DockStyle.Top;
            _tabControl.TabPages[tabIndex].Controls.Add(label);
            _tabControl.TabPages[tabIndex].Controls.SetChildIndex(label, 0);
         }

         if (tabIndex == 1)
         {
            _cbDHS = new CheckBox();
            _cbDHS.Text = "DHS (REAL ID) Required Data Elements";
            _cbDHS.Dock = DockStyle.Top;
            _cbDHS.CheckedChanged += (s, e) =>
            {
               if(_cbDHS.Checked)
               {
                  foreach(Control ctrl in _tabControl.TabPages[tabIndex].Controls)
                  {
                     if(ctrl is DataElementRowControl)
                     {
                        DataElementRowControl rowInner = (DataElementRowControl)ctrl;
                        if(DHSDataElements.Contains(rowInner.ElementID))
                           rowInner.CheckBox.Checked = true;
                     }
                  }
               }
               else
               {
                  bool shouldUncheckAll = true;
                  foreach (Control ctrl in _tabControl.TabPages[tabIndex].Controls)
                  {
                     if (ctrl is DataElementRowControl)
                     {
                        DataElementRowControl rowInner = (DataElementRowControl)ctrl;
                        if (DHSDataElements.Contains(rowInner.ElementID) && !rowInner.CheckBox.Checked)
                            shouldUncheckAll = false;
                     }
                  }
                  if(shouldUncheckAll)
                  {
                     foreach (Control ctrl in _tabControl.TabPages[tabIndex].Controls)
                     {
                        if (ctrl is DataElementRowControl)
                        {
                           DataElementRowControl rowInner = (DataElementRowControl)ctrl;
                           if (DHSDataElements.Contains(rowInner.ElementID))
                              rowInner.CheckBox.Checked = false;
                        }
                     }
                  }
               }
            };
            _tabControl.TabPages[tabIndex].Controls.Add(_cbDHS);
            _tabControl.TabPages[tabIndex].Controls.SetChildIndex(_cbDHS, 0);  
         }

         foreach (string elementID in values)
         {
            AAMVADataElementInfo info = _dataElementInfo[elementID];
            if ((info.ValidSubfileTypes & (int)_subfileSkeleton.SubfileType) == (int)_subfileSkeleton.SubfileType)
            {
               DataElementRowControl row = new DataElementRowControl();
               row.DataElementInfo = _dataElementInfo;
               row.Jurisdiction = _jurisdiction;
               row.ElementID = elementID;
               row.Dock = DockStyle.Top;
               row.CheckBox.CheckedChanged += (s, e) =>
               {
                  CheckBox cb = (CheckBox)s;
                  if(!cb.Checked && DHSDataElements.Contains(row.ElementID))
                  {
                     _cbDHS.Checked = false;
                  }
               };                  
               if (tabIndex == 1) //optional
               {
                  row.CheckBox.Enabled = true;
                  row.CheckBox.Checked = false;
               }
               _tabControl.TabPages[tabIndex].Controls.Add(row);
               _tabControl.TabPages[tabIndex].Controls.SetChildIndex(row, 0);
            }
         }
      }

      private void _btnSubmit_Click(object sender, EventArgs e)
      {
         //loop over all dataelementrowctrls

         bool allValid = true;
         //Check values
         for(int i = 0; i < 2; i++)
         {
            foreach (Control ctrl in _tabControl.TabPages[i].Controls)
            {
               if (ctrl is DataElementRowControl)
               {
                  DataElementRowControl row = (DataElementRowControl)ctrl;
                  if (row.ViewMode == DataElementRowControl.Mode.TextBox && 
                     row.CheckBox.Checked)
                  {
                     row.RaiseBeforeSubmitTextEvent();
                     bool rowValid = row.RaiseValidateOnSubmitTextEvent();
                     if (!rowValid)
                     {
                        allValid = false;
                     }
                  }
               }
            }
         }

         if (!allValid)
         {
            System.Media.SystemSounds.Beep.Play();
            return;
         }

         IDictionary<string, AAMVADataElement> dataElements = new Dictionary<string, AAMVADataElement>();
         //Get values
         for (int i = 0; i < 2; i++)
         {
            foreach (Control ctrl in _tabControl.TabPages[i].Controls)
            {
               if (ctrl is DataElementRowControl)
               {
                  DataElementRowControl row = (DataElementRowControl)ctrl;
                  if(row.CheckBox.Checked)
                  {
                     if (row.ViewMode == DataElementRowControl.Mode.TextBox)
                     {
                        AAMVADataElement dataElement = new AAMVADataElement();
                        dataElement.ElementID = row.ElementID;
                        dataElement.Value = row.TextBox.Text;
                        dataElements.Add(dataElement.ElementID, dataElement);
                     }
                     if (row.ViewMode == DataElementRowControl.Mode.DatePicker)
                     {
                        AAMVARegion rgn = AAMVAID.LookupRegion(_jurisdiction);
                        string dateFormat = "";
                        if (rgn == AAMVARegion.UnitedStates)
                           dateFormat = "MMddyyyy";
                        else
                           dateFormat = "yyyyMMdd";

                        string dateString = row.DateTimePicker.Value.ToString(dateFormat);
                        AAMVADataElement dataElement = new AAMVADataElement();
                        dataElement.ElementID = row.ElementID;
                        dataElement.Value = dateString;
                        dataElements.Add(dataElement.ElementID, dataElement);
                     }
                     if (row.ViewMode == DataElementRowControl.Mode.ComboBox)
                     {
                        AAMVADataElement dataElement = new AAMVADataElement();
                        dataElement.ElementID = row.ElementID;
                        dataElement.Value = (string)(row.ComboBox.SelectedValue);
                        dataElements.Add(dataElement.ElementID, dataElement);
                     }
                  }
               }
            }
         }
         _parent.SubmitEditSubfile(_subfileIndex, dataElements);
         _closeAction = CloseAction.Submit;
         Close();
      }
      public enum CloseAction
      {
         Submit,
         Cancel
      }
      private CloseAction _closeAction;
      protected override void OnFormClosing(FormClosingEventArgs e)
      {
         switch(_closeAction)
         { 
            case CloseAction.Cancel:
               _parent.CancelEditSubfile(_subfileIndex, _mode);
               break;
         }

         base.OnFormClosing(e);
      }

      private void _btnCancel_Click(object sender, EventArgs e)
      {
         _closeAction = CloseAction.Cancel;
         Close();
      }
   }
}
