// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Leadtools.Annotations.Engine;
using Leadtools.Annotations.Automation;

namespace Leadtools.Annotations.WinForms
{
   public partial class CalibrationDialog : Form
   {
      private AnnAutomation _automation;
      private AnnContainerMapper _mapper;
      private AnnPolyRulerObject _polyRulerObject;
      private bool _isPixelUnit = false;

      //when setting this flag to true , additional check box will be viewed in the dilaog 
      //to enable customer choosing between calibrating current ruler only or all the rulers in the container
      private bool _showApplyToAllRulers = false;
      public bool ShowApplyToAllRulers
      {
         get { return _showApplyToAllRulers; }
         set
         {
            _showApplyToAllRulers = value;
            _cboxApplyToAllRulers.Visible = _showApplyToAllRulers;
            _lblApplyToAllRulers.Visible = _showApplyToAllRulers;
         }
      }


      public CalibrationDialog(AnnAutomation automation)
      {
         if (automation == null) throw new ArgumentNullException("automation");
         
         InitializeComponent();
         
         _automation = automation;
         _mapper = automation.ActiveContainer.Mapper;

         _polyRulerObject = automation.CurrentEditObject as AnnPolyRulerObject;
         _isPixelUnit = (_polyRulerObject.MeasurementUnit == AnnUnit.Pixel);

         if (_isPixelUnit)
         {
            _polyRulerObject.MeasurementUnit = AnnUnit.SmartEnglish;
         }

         SetObjectLenghtLabelValue();
         _comboMesurementUnit.SelectedItem = _polyRulerObject.MeasurementUnit.ToString();

         if (_isPixelUnit)
         {
            _polyRulerObject.MeasurementUnit = AnnUnit.Pixel;
         }
      }

      private void _btnOk_Click(object sender, EventArgs e)
      {
         try
         {
            ApplyCalibrate();
            _automation.InvalidateObject(_polyRulerObject);
            this.Close();
         }
         catch (Exception ex)
         {
            MessageBox.Show(ex.Message, "Warrning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
         }
      }

      private void SetObjectLenghtLabelValue()
      {
         string rulerLength = _polyRulerObject.GetRulerLengthAsString(_mapper.CalibrationScale);

         AnnUnit unit = _polyRulerObject.MeasurementUnit;
         if (unit == AnnUnit.SmartEnglish)
            unit = AnnUnit.Inch;

         string unitAbbrev = _polyRulerObject.UnitsAbbreviation[unit];
         if(_polyRulerObject.MeasurementUnit == AnnUnit.SmartMetric)
         {
            //remove unit abbreviation from ruler length string
            rulerLength = rulerLength.TrimEnd(_polyRulerObject.UnitsAbbreviation[AnnUnit.Meter].ToCharArray());
            rulerLength = rulerLength.TrimEnd(_polyRulerObject.UnitsAbbreviation[AnnUnit.Centimeter].ToCharArray());
            rulerLength = rulerLength.TrimEnd(_polyRulerObject.UnitsAbbreviation[AnnUnit.Millimeter].ToCharArray());
            rulerLength = rulerLength.TrimEnd(_polyRulerObject.UnitsAbbreviation[AnnUnit.Micrometer].ToCharArray());
         }

         //remove unit abbreviation from ruler length string
         rulerLength = rulerLength.TrimEnd(unitAbbrev.ToCharArray());

         _txtRulerLength.Text = rulerLength;
      }

      private void ApplyCalibrate()
      {
         if (_isPixelUnit)
            _polyRulerObject.MeasurementUnit = AnnUnit.SmartEnglish;

         // the method _polyRulerObject.GetRulerLength() , gets the ruler length in AnnUnit.Unit so we need to convert it to current _polyRulerObject.MeasurementUnit with no calibration ratio
         LeadLengthD lengthInUnits = _polyRulerObject.GetRulerLength(1);

         double sourceLength = AnnUnitConverter.Convert(lengthInUnits.Value, AnnUnit.Unit, _polyRulerObject.MeasurementUnit);

         double destLength = 1;
         // check if the entered value is Number
         if (!double.TryParse(_txtRulerLength.Text, out destLength))
         {
            throw new Exception("Invalid Ruler Length Value");
         }

         if (sourceLength != 0 && destLength != 0)
         {
            AnnUnit destUnit = (AnnUnit)Enum.Parse(typeof(AnnUnit), _comboMesurementUnit.SelectedItem.ToString());

            if (_cboxApplyToAllRulers.Checked)
            {
               _mapper.Calibrate(LeadLengthD.Create(sourceLength), _polyRulerObject.MeasurementUnit, LeadLengthD.Create(destLength), destUnit);

               AnnAutomationManager manager = _automation.Manager;

               //update all exisiting rulers to have the new calibration measurement unit
               foreach (AnnObject annObject in _automation.Container.Children)
               {
                  AnnPolyRulerObject polyRuler = annObject as AnnPolyRulerObject;
                  if (polyRuler != null)
                  {
                     polyRuler.MeasurementUnit = destUnit;
                  }
               }
            }
            else
            {
               _polyRulerObject.Calibrate(LeadLengthD.Create(sourceLength), _polyRulerObject.MeasurementUnit, LeadLengthD.Create(destLength), destUnit);
            }

            _polyRulerObject.MeasurementUnit = destUnit;
         }

         if (_isPixelUnit)
            _polyRulerObject.MeasurementUnit = AnnUnit.Pixel;
      }
   }
}
