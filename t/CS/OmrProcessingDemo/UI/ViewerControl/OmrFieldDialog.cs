using Leadtools;
using Leadtools.Controls;
using Leadtools.Forms.Processing.Omr.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OmrProcessingDemo.ViewerControl
{
   public partial class OmrFieldDialog : Form
   {
      private OmrField omrField;
      private List<List<string>> _values;
      private RasterImage fieldImage;
      private OmrFieldOptions localOptions;

      private int indexRows;
      private int indexCols;

      private ImageViewer imageViewer;
      private List<OmrBubbleLabel> labels;

      private const string CUSTOM = " [CUSTOM]";

      private class OmrBubbleLabel
      {
         public string Label { get; set; }
         public string Value { get; set; }
         public LeadRect Bounds { get; set; }

         public OmrBubbleLabel(string label, string value, LeadRect bounds)
         {
            this.Label = label;
            this.Bounds = bounds;
            this.Value = value;
         }
      }

      public OmrFieldDialog(OmrField omrField, RasterImage fieldImage)
      {
         InitializeComponent();
         this.fieldImage = fieldImage;

         imageViewer = new ImageViewer();
         imageViewer.Dock = DockStyle.Fill;
         imageViewer.ItemChanged += ImageViewer_ItemChanged;

         pnlImg.Controls.Add(imageViewer);

         this.omrField = omrField;
         this.localOptions = this.omrField.Options;

         DataToControls();
      }

      private void ImageViewer_ItemChanged(object sender, ImageViewerItemChangedEventArgs e)
      {
         if (e.Reason == ImageViewerItemChangedReason.Image)
         {
            imageViewer.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty);
         }
      }

      private void DataToControls()
      {
         _values = new List<List<string>>();
         rdbtnOrRows.Text = "Rows: " + omrField.RowsCount;
         rdbtnOrCols.Text = "Columns: " + omrField.ColumnsCount;

         labels = new List<OmrBubbleLabel>();

         if (omrField.FieldBubbleLayoutType == OmrFieldBubbleLayoutType.BubbleWithLabel)
         {
            grpLabelOptions.Enabled = true;
            grpLabelOptions.Visible = true;
            grpGrid.Enabled = false;
            grpGrid.Visible = false;

            for (int i = 0; i < omrField.Fields.Count; i++)
            {
               for (int j = 0; j < omrField.Fields[i].Fields.Count; j++)
               {
                  OmrBubble bub = omrField.Fields[i].Fields[j];
                  OmrBubbleLabel label = new OmrBubbleLabel(bub.Label, bub.Value, bub.LabelBounds);

                  labels.Add(label);
               }
            }

            cboxValues.Items.AddRange(labels.ToArray());
            cboxValues.DisplayMember = "Label";
            if (labels.Count > 0)
            {
               cboxValues.SelectedIndex = 0;
            }
         }

         else
         {
            grpGrid.Enabled = true;
            grpGrid.Visible = true;

            grpLabelOptions.Enabled = false;
            grpLabelOptions.Visible = false;

            rdbtnOrFreeflow.Enabled = false;
            rdbtnOrFreeflow.Visible = false;
         }

         _txtFieldName.Text = omrField.Name;

         switch (omrField.Options.OmrSensitivity)
         {
            case Leadtools.Ocr.OcrOmrSensitivity.Highest:
               rdbtnSensHighest.Checked = true;
               break;
            case Leadtools.Ocr.OcrOmrSensitivity.High:
               rdbtnSensHigh.Checked = true;
               break;
            case Leadtools.Ocr.OcrOmrSensitivity.Low:
               rdbtnSensLow.Checked = true;
               break;
            case Leadtools.Ocr.OcrOmrSensitivity.Lowest:
               rdbtnSensLowest.Checked = true;
               break;
            default:
               break;
         }

         switch (omrField.Options.FieldOrientation)
         {
            case OmrFieldOrientation.RowWise:
               rdbtnOrRows.Checked = true;
               break;
            case OmrFieldOrientation.ColumnWise:
               rdbtnOrCols.Checked = true;
               break;
            case OmrFieldOrientation.FreeFlow:
               rdbtnOrFreeflow.Checked = true;
               rdbtnOrRows.Enabled = false;
               rdbtnOrCols.Enabled = false;
               break;
            default:
               break;
         }

         switch (omrField.Options.TextFormat)
         {
            case OmrTextFormat.CSV:
               rdbtnFormatCSV.Checked = true;
               break;
            case OmrTextFormat.Aggregated:
               rdbtnFormatAggregated.Checked = true;
               break;
            default:
               break;
         }

         _cbGrade.Checked = omrField.Options.GradeThisField;
         _numCorrect.Value = Convert.ToDecimal(omrField.Options.CorrectGrade);
         _numIncorrect.Value = Convert.ToDecimal(omrField.Options.IncorrectGrade);
         _numNoResponse.Value = Convert.ToDecimal(omrField.Options.NoResponseGrade);

         _cbRightToLeft.Checked = omrField.Options.ColumnsReportOrder == ColumnsReportOrder.RightToLeft;
      }

      private void PopulateValues()
      {
         lstValues.Items.Clear();
         foreach (List<string> value in _values)
         {
            if (value.Count > 0)
            {
               string text = ValuesString(value);
               lstValues.Items.Add(text);
            }
         }

         List<string> fieldValues = omrField.GetValues();

         if (fieldValues != null)
         {
            int x = fieldValues.Count(delegate (string input) { return input == ""; });

            // if there are populated values that aren't empty, it's a custom range, handle as expected
            if (!lstValues.Items.Contains(ValuesString(fieldValues)) && x == 0 && _values[0].Count == fieldValues.Count)
            {
               _values.Add(fieldValues);
               int index =  lstValues.Items.Add(ValuesString(fieldValues) + CUSTOM);
               lstValues.SelectedIndex = index;
            }
            else if (x == 0) // otherwise it's a standard range
            {
               lstValues.SelectedItem = ValuesString(fieldValues);
            }
         }
      }

      private string ValuesString(List<string> values)
      {
         return values[0] + " To " + values[values.Count - 1];
      }

      private void rdbtnOrientation_CheckChanged(object sender, EventArgs e)
      {
         if (omrField.FieldBubbleLayoutType == OmrFieldBubbleLayoutType.BubbleWithLabel)
         {
            return;
         }

         if (rdbtnOrRows.Checked)
         {
            imageViewer.Image = null;

            _values = GenerateOmrFieldValues.Generate(omrField.RowsCount, omrField.ColumnsCount, OmrFieldOrientation.RowWise);
            PopulateValues();

            lstValues.SelectedIndex = indexRows < lstValues.Items.Count ? indexRows : 0 ;
         }
         else if (rdbtnOrCols.Checked)
         {
            imageViewer.Image = null;

            _values = GenerateOmrFieldValues.Generate(omrField.RowsCount, omrField.ColumnsCount, OmrFieldOrientation.ColumnWise);
            PopulateValues();

            lstValues.SelectedIndex = indexCols < lstValues.Items.Count ? indexCols : 0;
         }

      }

      private void lstValues_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (rdbtnOrRows.Checked)
         {
            indexRows = lstValues.SelectedIndex;
         }
         if (rdbtnOrCols.Checked)
         {
            indexCols = lstValues.SelectedIndex;
         }
      }

      private void cboxValues_SelectedIndexChanged(object sender, EventArgs e)
      {
         OmrBubbleLabel label = (OmrBubbleLabel)cboxValues.SelectedItem;

         txtValue.Text = label.Value;
         if(!label.Bounds.IsEmpty)
            imageViewer.Image = fieldImage.Clone(label.Bounds);
      }

      private void txtValue_Leave(object sender, EventArgs e)
      {
         OmrBubbleLabel label = (OmrBubbleLabel)cboxValues.SelectedItem;

         label.Value = txtValue.Text;
      }

      private void btnOK_Click(object sender, EventArgs e)
      {
      }

      private void _cbGrade_CheckedChanged(object sender, EventArgs e)
      {
         _numCorrect.Enabled = _cbGrade.Checked;
         _numIncorrect.Enabled = _cbGrade.Checked;
         _numNoResponse.Enabled = _cbGrade.Checked;
      }

      private bool ControlsToData()
      {

         omrField.Name = _txtFieldName.Text;
         OmrFieldOptions options = omrField.Options;

         // orientation
         if (rdbtnOrRows.Checked)
         {
            options.FieldOrientation = OmrFieldOrientation.RowWise;
         }
         else if (rdbtnOrCols.Checked)
         {
            options.FieldOrientation = OmrFieldOrientation.ColumnWise;
         }
         else if (rdbtnOrFreeflow.Checked)
         {
            options.FieldOrientation = OmrFieldOrientation.FreeFlow;
         }

         // grading
         options.GradeThisField = _cbGrade.Checked;
         options.CorrectGrade = Convert.ToDouble(_numCorrect.Value);
         options.IncorrectGrade = Convert.ToDouble(_numIncorrect.Value);
         options.NoResponseGrade = Convert.ToDouble(_numNoResponse.Value);

         // formatting
         options.TextFormat = rdbtnFormatCSV.Checked ? OmrTextFormat.CSV : OmrTextFormat.Aggregated;

         // rtl
         options.ColumnsReportOrder = _cbRightToLeft.Checked ? ColumnsReportOrder.RightToLeft : ColumnsReportOrder.LeftToRight;

         // sensitivity (advanced tab)
         if (rdbtnSensLowest.Checked)
         {
            options.OmrSensitivity = Leadtools.Ocr.OcrOmrSensitivity.Lowest;
         }
         else if (rdbtnSensLow.Checked)
         {
            options.OmrSensitivity = Leadtools.Ocr.OcrOmrSensitivity.Low;
         }
         else if (rdbtnSensHigh.Checked)
         {
            options.OmrSensitivity = Leadtools.Ocr.OcrOmrSensitivity.High;
         }
         else if (rdbtnSensHighest.Checked)
         {
            options.OmrSensitivity = Leadtools.Ocr.OcrOmrSensitivity.Highest;
         }

         try
         {
            omrField.Options = options;
         }
         catch (Exception)
         {
            MessageBox.Show("The options for this field are invalid.");
            return false;
         }

         if (omrField.Options.FieldOrientation == OmrFieldOrientation.FreeFlow)
         {
            for (int i = 0; i < omrField.Fields.Count; i++)
            {
               string name = omrField.Fields[i].Name;
               omrField.Fields[i].Name = string.IsNullOrEmpty(name) ? string.Format("Freeflow {0}", i + 1) : name;
            }
         }

         // values
         if (omrField.FieldBubbleLayoutType == OmrFieldBubbleLayoutType.BubbleWithLabel)
         {
            try
            {
               omrField.SetValues(labels.ConvertAll<string>(delegate (OmrBubbleLabel bub) { return bub.Value; }));
            }
            catch (Exception)
            {
               MessageBox.Show("The field count does not match the label count.");
               return false;
            }
         }
         else
         {
            omrField.SetValues(_values[lstValues.SelectedIndex]);
         }

         return true;
      }

      private void rdbtnFormatValue_CheckChanged(object sender, EventArgs e)
      {
         if (rdbtnFormatAggregated.Checked)
         {
            lblFormatExample.Text = "ABCD";
         }
         else if (rdbtnFormatCSV.Checked)
         {
            lblFormatExample.Text = "A, B, C, D";
         }
      }

      private void btnCreateCustom_Click(object sender, EventArgs e)
      {
         int range = _values[0].Count;
         MessageBox.Show(string.Format("To create a custom range, enter {0} values separated by commas.", range));

         Func<string, string> isValid = new Func<string, string>(
            delegate (string input) {
               string[] values = input.Split(new char[] { ',' });

               if (values.Length != range)
               {
                  return "Exactly " + range.ToString() + " values must be specified.";
               }

               List<string> filteredValues = new List<string>(values.Distinct());

               if (filteredValues.Count != range)
               {
                  return "Values must be unique.";
               }

               if (filteredValues.Any(delegate(string str) { return string.IsNullOrWhiteSpace(str); }))
               {
                  return "Blank values cannot be used";
               }

               return string.Empty;
            }
         );


         TextInputDialog tid = new TextInputDialog(isValid);
         if (tid.ShowDialog(this) == DialogResult.OK)
         {
            string text = tid.Value;

            List<string> newSource = new List<string>(text.Split(new char[] { ',' }));
            _values.Add(newSource);
            lstValues.Items.Add(ValuesString(newSource) + CUSTOM);

            if (rdbtnOrCols.Checked)
            {
               indexCols = lstValues.Items.Count - 1;
            }
            else if (rdbtnOrRows.Checked)
            {
               indexRows = lstValues.Items.Count - 1;
            }

            lstValues.SelectedIndex = lstValues.Items.Count - 1;
         }
      }

      private void lstValues_DoubleClick(object sender, EventArgs e)
      {
         int index = lstValues.SelectedIndex;

         List<string> values = _values[index];

         string text = "";
         for (int i = 0; i < values.Count; i++)
         {
            text += values[i];

            if (i < values.Count - 1)
            {
               text += ", ";
            }
         }

         MessageBox.Show(text);
      }

      private void OmrFieldDialog_FormClosing(object sender, FormClosingEventArgs e)
      {
         if (this.DialogResult == DialogResult.OK)
         {
            e.Cancel = !ControlsToData();
         }
      }
   }
}
