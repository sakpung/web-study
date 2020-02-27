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
using Leadtools.Demos;
using Leadtools.Dicom;

namespace Leadtools.Medical.Media.AddIns.UI
{
   public partial class LabelingView : Form
   {
      #region Public
         
         #region Methods
         
            public LabelingView()
            {
               InitializeComponent ( ) ;
            }
         
            public void SetLabel ( LabelPrinting label, long[] supportedTags )
            {
               Init ( label, supportedTags ) ;
               
               RegisterEvents ( ) ;
            }

         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
      
      #region Protected
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Members
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
      #endregion
      
      #region Private
         
         #region Methods
            
            private void Init ( LabelPrinting label, long[] supportedTags )
            {
               __Label = label ;
               __Tags  = supportedTags ;
               
               __IsExpanded = false ;
               
               ImageTextBox.Text  = string.Empty ;
               CustomTextBox.Text = string.Empty ;
               
               ClientRequestedTextRadioButton.Checked = false ;
               ImageRadioButton.Checked               = false ;
               CustomRadioButton.Checked              = false ;
               
               switch ( label.PrintLabelType )
               {
                  case LabelType.ClientText:
                  {
                     ClientRequestedTextRadioButton.Checked = true ;
                  }
                  break ;
                  
                  case LabelType.Image:
                  {
                     ImageRadioButton.Checked = true ;
                     ImageTextBox.Text        = label.PrintLabelData ;
                  }
                  break ;
                  
                  case LabelType.CustomData:
                  {
                     CustomRadioButton.Checked = true ;
                     CustomTextBox.Text        = label.PrintLabelData ;
                  }
                  break ;
               }
               
               FillListBox ( supportedTags ) ;
               
               InsertDicomTagButton.Enabled = DicomTagsListBox.SelectedIndex != -1 ;
               
               Collapse ( ) ;
            }

            private void FillListBox ( long[] supportedTags )
            {
               foreach ( long dicomTag in supportedTags ) 
               {
                  DicomTagsListBox.Items.Add ( new DicomListBoxTag ( DicomTagTable.Instance.Find ( dicomTag ) ) ) ;
               }
            }
            
            private void RegisterEvents ( )
            {
               BrowseImageButton.Click    += new EventHandler ( BrowseImageButton_Click ) ;
               DicomTagsButton.Click      += new EventHandler ( DicomTagsButton_Click ) ;
               OKButton.Click             += new EventHandler ( OKButton_Click ) ;
               InsertDicomTagButton.Click += new EventHandler ( InsertDicomTagButton_Click ) ;
               
               DicomTagsListBox.SelectedIndexChanged += new EventHandler ( DicomTagsListBox_SelectedIndexChanged ) ;
               DicomTagsListBox.DoubleClick          += new EventHandler ( DicomTagsListBox_DoubleClick ) ;
               CustomTextBox.Enter                   += new EventHandler ( CustomTextBox_Enter ) ;
            }

            private void Expand ( )
            {
               __IsExpanded = true ;
               
               DicomTagsListBox.Visible     = __IsExpanded ;
               InsertDicomTagButton.Visible = __IsExpanded ;
               
               this.Height += _listBoxHeight ;
               
               DicomTagsButton.Text = "DICOM Tags<<" ;
            }

            private void Collapse ( )
            {
               __IsExpanded = false ;
               
               DicomTagsListBox.Visible     = __IsExpanded ;
               InsertDicomTagButton.Visible = __IsExpanded ;
               
               this.Height -= _listBoxHeight ;
               
               DicomTagsButton.Text = "DICOM Tags>>" ;
            }
            
            private void FillLabelData ( )
            {
               if ( ClientRequestedTextRadioButton.Checked )
               {
                  __Label.PrintLabelType = LabelType.ClientText ;
                  __Label.PrintLabelData = string.Empty ;
               }
               else if ( ImageRadioButton.Checked ) 
               {
                  __Label.PrintLabelType = LabelType.Image ;
                  __Label.PrintLabelData = ImageTextBox.Text ;
               }
               else if ( CustomRadioButton.Checked ) 
               {
                  __Label.PrintLabelType = LabelType.CustomData ;
                  __Label.PrintLabelData = CustomTextBox.Text ;
               }
            }

            private bool ValidateControls ( )
            {
               if ( ImageRadioButton.Checked && ImageTextBox.Text.Length == 0 ) 
               {
                  ValidationErrorProvider.SetError ( ImageRadioButton, "No image is selected." ) ;
                  
                  return false ;
               }
               else
               {
                  ValidationErrorProvider.SetError ( ImageRadioButton, string.Empty ) ;
               }
               
               if ( CustomRadioButton.Checked && CustomTextBox.Text.Length == 0 ) 
               {
                  ValidationErrorProvider.SetError ( CustomRadioButton, "Enter label text" ) ;
                  
                  return false ;
               }
               else
               {
                  ValidationErrorProvider.SetError ( CustomRadioButton, string.Empty ) ;
               }
               
               return true ;
            }
            
         #endregion
         
         #region Properties
            
            private LabelPrinting __Label
            {
               get ;
               set ;
            }
            
            private long [] __Tags
            {
               get ;
               set ;
            }
            
            private bool __IsExpanded
            {
               get ;
               set ;
            }
            
         #endregion
         
         #region Events
         
            void DicomTagsButton_Click(object sender, EventArgs e)
            {
               try
               {
                  if ( __IsExpanded ) 
                  {
                     Collapse ( ) ;
                  }
                  else 
                  {
                     Expand ( ) ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception.Message ) ;
               }
            }

            void BrowseImageButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  OpenFileDialog openFileDlg ;
                  
                  
                  ImageRadioButton.Checked = true ;
                  
                  openFileDlg = new OpenFileDialog ( ) ;
                  
                  openFileDlg.FileName = ImageTextBox.Text ;
                  openFileDlg.Filter   = "Image Files(*.BMP;*.JPG;*.PNG;*.TIF)|*.BMP;*.JPG;*.PNG;*.TIF" ;
                  
                  if ( openFileDlg.ShowDialog ( ) == DialogResult.OK ) 
                  {
                     ImageTextBox.Text = openFileDlg.FileName ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception.Message ) ;
               }
            }
            
            void OKButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  if ( ValidateControls ( ) )
                  {
                     FillLabelData ( ) ;
                     
                     DialogResult = DialogResult.OK ;
                  }
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception.Message ) ;
               }
            }
            
            void InsertDicomTagButton_Click ( object sender, EventArgs e )
            {
               try
               {
                  InsertSelectedDicomTag ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception.Message ) ;
               }
            }

            private void InsertSelectedDicomTag ( )
            {
               if ( DicomTagsListBox.SelectedIndex != -1 ) 
               {
                  DicomTag dicomTag ;
                  
                  
                  dicomTag = ( (DicomListBoxTag) DicomTagsListBox.SelectedItem ).Tag ;
                  
                  CustomTextBox.Text = CustomTextBox.Text.Insert ( CustomTextBox.SelectionStart, string.Format ( "${0};{1}$", dicomTag.Name, dicomTag.ToHexString ( ) ) );
                  
                  CustomRadioButton.Checked = true ;
               }
            }
            
            void DicomTagsListBox_SelectedIndexChanged ( object sender, EventArgs e )
            {
               try
               {
                  InsertDicomTagButton.Enabled = DicomTagsListBox.SelectedIndex != -1 ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void CustomTextBox_Enter(object sender, EventArgs e)
            {
               try
               {
                  CustomRadioButton.Checked = true ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }
            
            void DicomTagsListBox_DoubleClick(object sender, EventArgs e)
            {
               try
               {
                  InsertSelectedDicomTag ( ) ;
               }
               catch ( Exception exception ) 
               {
                  Messager.ShowError ( this, exception ) ;
               }
            }

         #endregion
         
         #region Data Members
         
            private const int _listBoxHeight = 121; 
            
         #endregion
         
         #region Data Types Definition
         
            struct DicomListBoxTag
            {
               public DicomListBoxTag ( DicomTag tag )
               {
                  _tag = tag ;
               }

               public override string ToString ( )
               {
                  return Tag.Name ;
               }
               
               public DicomTag Tag
               {
                  get 
                  {
                     return _tag ;
                  }
               }
               
               private DicomTag _tag ;
            }
            
         #endregion
         
      #endregion
      
      #region internal
         
         #region Methods
            
         #endregion
         
         #region Properties
            
         #endregion
         
         #region Events
            
         #endregion
         
         #region Data Types Definition
            
         #endregion
         
         #region Callbacks
            
         #endregion
         
      #endregion
   }
}
