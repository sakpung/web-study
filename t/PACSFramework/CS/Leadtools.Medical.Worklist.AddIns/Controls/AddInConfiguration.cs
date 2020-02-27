// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml ;
using System.Xml.Schema ;
using System.Windows.Forms;
using System.Configuration ;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration ;
using Leadtools.Medical.Worklist.AddIns.Configuration ;
using Leadtools.Dicom.Scp.Command ;
using Leadtools.Demos;


namespace Leadtools.Medical.Worklist.AddIns.Controls
{
   public partial class AddInConfiguration : UserControl
   {
      WorklistAddInsConfiguration _settings ;
      
      public AddInConfiguration()
      {
         InitializeComponent();
      }
      
      public WorklistAddInsConfiguration AddInsSettings 
      {
         get
         {
            return _settings ;
         }
         
         set
         {
            if ( value != _settings ) 
            {
               _settings = value ;
               
               BindUI ( ) ;
            }
         }
      }
      
      private void BindUI ( ) 
      {
         chkClientLimitMWLResponsesToClientAE.DataBindings.Add ( "Checked", _settings, "UseStationAETitleForMatching" ) ;
         chkStatusInProgress.DataBindings.Add ( "Checked", _settings, "EliminateInProgressMWL" ) ;
         chkStatusCompleted.DataBindings.Add ( "Checked", _settings, "EliminateCompletedMWL" ) ;
         chkStatusDiscontinued.DataBindings.Add ( "Checked", _settings, "EliminateDiscontinuedMWL" ) ;
         
         LimitResponsesCheckBox.DataBindings.Add ( "Checked", _settings, "LimitNumberOfResponses" ) ;
         NumberOfResponsesNumericUpDown.DataBindings.Add ( "Value", _settings, "NumberOfMatchingResponses" ) ;
         
         chkServerRequestDatasetValidationZero.DataBindings.Add ( "Checked", _settings.ModalityWorklistValidation, "AllowZeroItemsSequence" ) ;
         chkServerRequestDatasetValidationMultiple.DataBindings.Add ( "Checked", _settings.ModalityWorklistValidation, "AllowMultipleItemsSequence" ) ;
         chkServerRequestDatasetValidationPrivateElements.DataBindings.Add ( "Checked", _settings.ModalityWorklistValidation, "AllowPrivateElements" ) ;
         chkServerRequestDatasetValidationExtraElements.DataBindings.Add ( "Checked", _settings.ModalityWorklistValidation, "AllowExtraElements" ) ;
         
         chkNCreatevalidateRelational.DataBindings.Add ( "Checked", _settings.ModalityPerformedProcedureCreateValidation, "ValidateRelationalToIHERules" ) ;
         chkNCreateAllowPrivate.DataBindings.Add ( "Checked", _settings.ModalityPerformedProcedureCreateValidation, "AllowPrivateElements" ) ;
         chkNCreateAllowExtra.DataBindings.Add ( "Checked", _settings.ModalityPerformedProcedureCreateValidation, "AllowExtraElements" ) ;
         
         chkNSetAllowPrivate.DataBindings.Add ( "Checked", _settings.ModalityPerformedProcedureSetValidation, "AllowPrivateElements" ) ;
         chkNSetAllowExtra.DataBindings.Add ( "Checked", _settings.ModalityPerformedProcedureSetValidation, "AllowExtraElements" ) ;         
         
         if ( !string.IsNullOrEmpty ( _settings.ModaliyWorklistIODPath ) )
         {
            XmlSchema schema ;
            Exception result ;
            
            schema   =  MWLCFindCommand.IODSchema ;
            
            result = ValidateIOD ( schema, _settings.ModaliyWorklistIODPath ) ;
            
            if ( null != result ) 
            {
               MessageBox.Show ( "Invalid Modality Worklist IOD file.\n" + result.Message ) ;
            }
            else
            {
               txtMWLIODPath.Text = _settings.ModaliyWorklistIODPath ;
            }
         }
         
         
         if ( !string.IsNullOrEmpty ( _settings.ModaliyPerformedProcedureCreateIODPath ) )
         {
            XmlSchema schema ;
            Exception result ;
            
            schema   =  MppsNCreateCommand.IODSchema ;
            
            result = ValidateIOD ( schema, _settings.ModaliyPerformedProcedureCreateIODPath ) ;
            
            if ( null != result ) 
            {
               MessageBox.Show ( "Invalid Modality Perofrmed Procedure Create service IOD file.\n" + result.Message ) ;
            }
            else
            {
               txtNCreateIODPath.Text = _settings.ModaliyWorklistIODPath ;
            }
         }
         
         if ( !string.IsNullOrEmpty ( _settings.ModaliyPerformedProcedureSetIODPath ) )
         {
            XmlSchema schema ;
            Exception result ;
            
            schema   =  MppsNSetCommand.IODSchema ;
            
            result = ValidateIOD ( schema, _settings.ModaliyPerformedProcedureSetIODPath ) ;
            
            if ( null != result ) 
            {
               MessageBox.Show ( "Invalid Modality Perofrmed Procedure Set service IOD file.\n" + result.Message ) ;
            }
            else
            {
               txtNSetIODPath.Text = _settings.ModaliyWorklistIODPath ;
            }
         }
      }
      
      public Exception ValidateIOD ( XmlSchema schema, string iodPath )
      {
         Exception error ;
         XmlDocument iodDocument ;
         
         
         try
         {
            iodDocument = new XmlDocument ( ) ;
            
            iodDocument.Load ( iodPath ) ;
            
            iodDocument.Schemas.Add ( schema ) ;
            
            _validationException = null ;
            
            iodDocument.Validate ( iodSchemaValidationEventHandler ) ;
            
            error = _validationException ;
            
            _validationException = null ;
            
            return error ;
         }
         catch ( Exception exception )
         {
            return exception ;
         }
      }
      
      private void iodSchemaValidationEventHandler ( object sender, ValidationEventArgs e )
      {
         _validationException = e.Exception ;
      }
      
      private void btnBrowseMWLIODPath_Click(object sender, EventArgs e)
      {
         if ( iodOpenFileDialog.ShowDialog ( ) == DialogResult.OK ) 
         {
            Exception validationResult ;
            
            validationResult = ValidateIOD ( MWLCFindCommand.IODSchema, iodOpenFileDialog.FileName ) ;
            
            if ( null != validationResult ) 
            {
               Messager.ShowError ( this, "Invalid Modality Worklist IOD file.\n" + validationResult.Message ) ;
            }
            else
            {
               txtMWLIODPath.Text = iodOpenFileDialog.FileName ;
               
               _settings.ModaliyWorklistIODPath = iodOpenFileDialog.FileName ;
            }
         }
      }
      
      
      private Exception _validationException ;
      
      private void btnBrowseNCreateIODPath_Click(object sender, EventArgs e)
      {
         if ( iodOpenFileDialog.ShowDialog ( ) == DialogResult.OK ) 
         {
            Exception validationResult ;
            
            validationResult = ValidateIOD ( MppsNCreateCommand.IODSchema, iodOpenFileDialog.FileName ) ;
            
            if ( null != validationResult ) 
            {
               MessageBox.Show ( "Invalid Modality Perofrmed Procedure Create service IOD file.\n" + validationResult.Message ) ;
            }
            else
            {
               txtNCreateIODPath.Text = iodOpenFileDialog.FileName ;
               
               _settings.ModaliyPerformedProcedureCreateIODPath = iodOpenFileDialog.FileName ;
            }
         }
      }

      private void btnBrowseNSetIODPath_Click(object sender, EventArgs e)
      {
         if ( iodOpenFileDialog.ShowDialog ( ) == DialogResult.OK ) 
         {
            Exception validationResult ;
            
            validationResult = ValidateIOD ( MppsNSetCommand.IODSchema, iodOpenFileDialog.FileName ) ;
            
            if ( null != validationResult ) 
            {
               MessageBox.Show ( "Invalid Modality Perofrmed Procedure Set service IOD file.\n" + validationResult.Message ) ;
            }
            else
            {
               txtNSetIODPath.Text = iodOpenFileDialog.FileName ;
               
               _settings.ModaliyPerformedProcedureSetIODPath = iodOpenFileDialog.FileName ;
            }
         }
      }

   }
}
