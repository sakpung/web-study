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
using Leadtools.Dicom.Common.DataTypes;
using Leadtools.Dicom;
using System.Reflection;
using System.Threading;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Leadtools.Dicom.Common.Editing;
using Leadtools.Demos;

namespace Leadtools.Medical.Winforms
{
   public partial class OrientationConfigDialog : Form
   {
      private static Dictionary<long, string> _Tags = new Dictionary<long, string>();
      private OrientationAxis _OldTopOrientation;
      private OrientationAxis _OldRightOrientation;
      private DicomDataSet _Dataset = new DicomDataSet();
      private long _PreviousCode = -1;

      static OrientationConfigDialog()
      {
         LoadTagConstants();
      }

      public static Dictionary<long, string> Tags
      {
         get 
         {
            if (_Tags.Count == 0)
            {
               LoadTagConstants();
            }
            return OrientationConfigDialog._Tags; 
         }
      }

      private OrientationConfiguration _Configuration ;

      public OrientationConfiguration Configuration
      {
         get { return _Configuration; }
         
         set 
         { 
            if ( value!=null )
            {
               _Configuration = Clone<OrientationConfiguration> ( value ) ; 
            }
            else
            {
               _Configuration = null ;
            }
         }
      }

      public OrientationConfigDialog ( )
      {
         InitializeComponent();

         ExportButton.Click += new EventHandler ( ExportButton_Click ) ;
      }

      private void OrientationConfigDialog_Load ( object sender, EventArgs e )
      {            
         if (_Configuration == null)
         {
            _Configuration = new OrientationConfiguration ( ) ;
         }           
         
         List <Plane> planes = new List<Plane> ( ) ;
         
         planes.Add ( Plane.Axial ) ;
         planes.Add ( Plane.Coronal ) ;
         planes.Add ( Plane.Sagittal ) ;
          
         comboBoxPlane.DataSource = planes ;
         
         comboBoxPlane.SelectedItem = Plane.Axial ;
         
         dicomPropertyGrid.ShowCommands = false ;
      }

      private void SetOrientationAxis ( params OrientationAxis[] axis )
      {
         comboBoxRight.Items.Clear ( ) ;
         comboBoxTop.Items.Clear ( ) ;
         
         
         foreach ( OrientationAxis a in axis )
         {
            comboBoxRight.Items.Add ( a ) ;
            comboBoxTop.Items.Add   ( a ) ;
         }
      }

      private static void LoadTagConstants ( )
      {
         DicomTag tag = DicomTagTable.Instance.GetFirst ( ) ;
         

         do
         {
            if ( tag.Code != DicomTag.DataSetTrailingPadding &&
                 tag.Code != DicomTag.ItemDelimitationItem &&
                 tag.Code != DicomTag.SequenceDelimitationItem &&
                 tag.Code != DicomTag.CommandGroupLength && 
                 !_Tags.ContainsKey ( tag.Code ) )
            {
               _Tags.Add ( tag.Code, tag.Name ) ;
            }
         } while ( ( tag = DicomTagTable.Instance.GetNext ( tag ) ) != null ) ;
      }

      private void ConfigureAxial ( )
      {            
         foreach ( PlaneOrientation plane in _Configuration.Axial )
         {
             comboBoxConfigs.Items.Add ( plane ) ;
         }
         
         SetOrientationAxis ( OrientationAxis.Right, 
                              OrientationAxis.Left, 
                              OrientationAxis.Anterior, 
                              OrientationAxis.Posterior ) ;
                              
         if ( _Configuration.Axial.Count > 0 )
         {
            comboBoxTop.SelectedItem   = _Configuration.Axial[0].Top ;
            comboBoxRight.SelectedItem = _Configuration.Axial[0].Right ;
            
            labelBottom.Text = GetOppositeOrientation ( _Configuration.Axial[0].Top ).ToString ( ) ;
            labelLeft.Text   = GetOppositeOrientation ( _Configuration.Axial[0].Right ).ToString ( ) ;
            
            _OldTopOrientation   = _Configuration.Axial[0].Top ;
            _OldRightOrientation = _Configuration.Axial[0].Right ;
         }
      }

      private void ConfigureCoronal ( )
      {
         foreach ( PlaneOrientation plane in _Configuration.Coronal )
         {
             comboBoxConfigs.Items.Add ( plane ) ;
         }

         SetOrientationAxis ( OrientationAxis.Right, 
                              OrientationAxis.Left, 
                              OrientationAxis.Superior, 
                              OrientationAxis.Inferior ) ;
         
         if ( _Configuration.Coronal.Count > 0 ) 
         {
            comboBoxTop.SelectedItem   = _Configuration.Coronal[0].Top ;
            comboBoxRight.SelectedItem = _Configuration.Coronal[0].Right ;
            
            labelBottom.Text = GetOppositeOrientation ( _Configuration.Coronal[0].Top ).ToString ( ) ;
            labelLeft.Text   = GetOppositeOrientation ( _Configuration.Coronal[0].Right ).ToString ( ) ;
            
            _OldTopOrientation   = _Configuration.Coronal[0].Top ;
            _OldRightOrientation = _Configuration.Coronal[0].Right ;
         }
      }

      private void ConfigureSagittal ( )
      {            
         foreach ( PlaneOrientation plane in _Configuration.Sagittal )
         {
             comboBoxConfigs.Items.Add ( plane ) ;
         }

         SetOrientationAxis ( OrientationAxis.Anterior, 
                              OrientationAxis.Posterior, 
                              OrientationAxis.Superior, 
                              OrientationAxis.Inferior ) ;

         if ( _Configuration.Sagittal.Count > 0 )
         {
            comboBoxTop.SelectedItem   = _Configuration.Sagittal[0].Top ;
            comboBoxRight.SelectedItem = _Configuration.Sagittal[0].Right ;
            
            labelBottom.Text = GetOppositeOrientation ( _Configuration.Sagittal[0].Top ).ToString ( ) ;
            labelLeft.Text   = GetOppositeOrientation ( _Configuration.Sagittal[0].Right ).ToString ( ) ;
            
            _OldTopOrientation   = _Configuration.Sagittal[0].Top ;
            _OldRightOrientation = _Configuration.Sagittal[0].Right ;
         }
      }

      private void comboBoxTop_SelectedIndexChanged ( object sender, EventArgs e )
      {
         try
         {
            if ( comboBoxConfigs.SelectedIndex < 0 || comboBoxTop.SelectedIndex < 0 )
            {
               return ;
            }
            
            OrientationAxis orientation = (OrientationAxis)comboBoxTop.SelectedItem;
            PlaneOrientation po = comboBoxConfigs.SelectedItem as PlaneOrientation;

            labelBottom.Text = GetOppositeOrientation ( orientation ).ToString ( ) ;
            
            po.Top = orientation ;
            
            CheckRight ( orientation ) ;
            
            _OldTopOrientation = orientation ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void comboBoxRight_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if ( comboBoxConfigs.SelectedIndex < 0 || comboBoxRight.SelectedIndex < 0 )
            {
               return ;
            }
            
            OrientationAxis orientation = (OrientationAxis)comboBoxRight.SelectedItem;
            PlaneOrientation po = comboBoxConfigs.SelectedItem as PlaneOrientation;

            labelLeft.Text = GetOppositeOrientation(orientation).ToString();
            po.Right = orientation;
            CheckTop(orientation);
            _OldRightOrientation = orientation;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void CheckRight ( OrientationAxis top )
      {
         if ( comboBoxRight.SelectedItem == null )
         {
            return ;
         }

         if ( ( OrientationAxis ) comboBoxRight.SelectedItem == top )
         {
             comboBoxRight.SelectedItem = _OldTopOrientation;
         }
         else if (GetOppositeOrientation((OrientationAxis)comboBoxRight.SelectedItem) == top)
         {
             comboBoxRight.SelectedItem = _OldTopOrientation;
         }
      }

      private void CheckTop ( OrientationAxis right )
      {
         if ( comboBoxTop.SelectedIndex < 0 )
         {
            return ;
         }

         if ((OrientationAxis)comboBoxTop.SelectedItem == right)
         {
             comboBoxTop.SelectedItem = _OldRightOrientation;
         }
         else if (GetOppositeOrientation((OrientationAxis)comboBoxTop.SelectedItem) == right)
         {
             comboBoxTop.SelectedItem = _OldRightOrientation;
         }
      }

      private void comboBoxPlane_SelectedIndexChanged(object sender, EventArgs e)
      {
         try
         {
            if ( comboBoxPlane.SelectedIndex < 0 )
            {
               return ;
            }
            
            Plane plane = (Plane) comboBoxPlane.SelectedItem ;
            
            comboBoxConfigs.Items.Clear();
            
            switch ( plane )
            {
               case Plane.Axial:
               {
                  ConfigureAxial ( ) ;
               }
               break ;
               
               case Plane.Coronal:
               {
                  ConfigureCoronal ( ) ;
               }
               break ;
               
               case Plane.Sagittal:
               {
                  ConfigureSagittal ( ) ;
               }
               break ;
            }
            
            if ( comboBoxConfigs.Items.Count > 0 )
            {
               comboBoxConfigs.SelectedIndex = 0 ;
            }
            
            UpdateOrientConfigUI ( ) ;
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void comboBoxConfigs_SelectedIndexChanged ( object sender, EventArgs e )
      {
         try
         {
            RefreshOrientationConfig ( ) ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void RefreshOrientationConfig ( )
      {
         if ( comboBoxConfigs.SelectedIndex < 0 )
         {
            if ( comboBoxConfigs.Items.Count > 0 ) 
            {
               comboBoxConfigs.SelectedIndex = 0 ;
            }
            else
            {
               SetOrientationInfo ( null ) ;
            }
         }
         else if ( comboBoxConfigs.SelectedIndex >= 0 )
         {
            PlaneOrientation orientation ;


            orientation = comboBoxConfigs.SelectedItem as PlaneOrientation ;
            
            SetOrientationInfo ( orientation ) ;
         }
      }

      private void SetOrientationInfo ( PlaneOrientation orientation )
      {
         if ( null != orientation ) 
         {
            comboBoxTop.SelectedItem   = orientation.Top;
            comboBoxRight.SelectedItem = orientation.Right;
            
            if ( orientation.Condition == null || 
                 orientation.Condition.GetType ( ) != typeof ( TagValueOrientationCondition ) )
            {
               TagConditionTextBox.Text = string.Empty ;
            }
            else
            {
               TagValueOrientationCondition condition ;
               
               
               condition = ( TagValueOrientationCondition ) orientation.Condition ;
               
               TagConditionTextBox.Text = GetTag ( condition.Tag ) ;
            }
            
            BuildDataSet ( ) ;
         }
         else
         {
            TagConditionTextBox.Text   = string.Empty ;
            dicomPropertyGrid.DataSet  = null ;
         }
         
      }

        private OrientationAxis GetOppositeOrientation(OrientationAxis orientation)
        {
            switch (orientation)
            {
                case OrientationAxis.Anterior:
                    return OrientationAxis.Posterior;
                case OrientationAxis.Inferior:
                    return OrientationAxis.Superior;
                case OrientationAxis.Left:
                    return OrientationAxis.Right;
                case OrientationAxis.Posterior:
                    return OrientationAxis.Anterior;
                case OrientationAxis.Right:
                    return OrientationAxis.Left;
                case OrientationAxis.Invalid:
                    return OrientationAxis.Invalid;
                default:
                    return OrientationAxis.Inferior;
            }            
        }        

      private void buttonAdd_Click ( object sender, EventArgs e )
      {
         try
         {
            ConfigurationEditorDialog dlg ;


            if ( comboBoxPlane.SelectedIndex < 0 )
            {
               return ;
            }
            
            dlg = new ConfigurationEditorDialog ( false ) ;
            
            dlg.ApplyCondition = true ;
            
            if ( dlg.ShowDialog ( this ) == DialogResult.OK )
            {
               Plane                        plane ;
               PlaneOrientation             orientation ;
               TagValueOrientationCondition condition ;
                
               plane       = ( Plane ) comboBoxPlane.SelectedItem ;
               orientation = new PlaneOrientation();
               
               if ( dlg.ApplyCondition )
               {
                  condition = new TagValueOrientationCondition ( GetTag ( dlg.DicomTag ), dlg.TagValue ) ;
               }
               else
               {
                  condition = null ;
               }
               
               orientation.Name      = dlg.ConfigurationName ;
               orientation.Condition = condition ;
               
               switch ( plane )
               {
                  case Plane.Axial:
                  {
                     _Configuration.Axial.Add ( orientation ) ;
                  }
                  break;
                  
                  case Plane.Coronal:
                  {
                     orientation.Top = OrientationAxis.Superior ;
                     orientation.Right = OrientationAxis.Right ;
                     
                     _Configuration.Coronal.Add ( orientation ) ;
                  }
                  break;
                  
                  case Plane.Sagittal:
                  {
                     orientation.Top = OrientationAxis.Superior ;
                     orientation.Right = OrientationAxis.Anterior ;
                     
                     _Configuration.Sagittal.Add ( orientation ) ;
                  }
                  break ;
               }

               comboBoxConfigs.Items.Add ( orientation ) ;
               comboBoxConfigs.SelectedItem = orientation ;
               
               SetOrientationInfo ( orientation ) ;
               
               UpdateOrientConfigUI ( ) ;
            }
         }
         catch ( Exception exception  )
         {
            Messager.ShowError ( this, exception ) ;
         }
         
      }

      private void UpdateOrientConfigUI()
      {
         if ( comboBoxConfigs.SelectedIndex >= 0 )
         {
            buttonDelete.Enabled = true ;
            buttonEdit.Enabled   = true ;
         }
         else
         {
            buttonDelete.Enabled = false ;
            buttonEdit.Enabled   = false ;
         }
      }

        internal static long GetTag(string text)
        {
            var tag = (from kv in _Tags
                       where kv.Value == text
                       select kv.Key).ToList();
           
            return tag.Count > 0?tag[0]:-1;
        }

        private string GetTag(long Tag)
        {
            if (Tag == -1)
                return string.Empty;

            if (_Tags.ContainsKey(Tag))
                return _Tags[Tag];

            return Tag.ToString("X");
        }

      private void buttonEdit_Click ( object sender, EventArgs e )
      {
         try
         {
            ConfigurationEditorDialog    dlg ;
            PlaneOrientation             orientation ;
            TagValueOrientationCondition condition ;

            if ( comboBoxConfigs.SelectedIndex < 0 )
            {
               return ;
            }
            
            dlg         = new ConfigurationEditorDialog ( true ) ;
            orientation = comboBoxConfigs.SelectedItem as PlaneOrientation ;
            
            if ( null != orientation.Condition )
            {
               condition = ( TagValueOrientationCondition ) orientation.Condition ;
            }
            else
            {
               condition = new TagValueOrientationCondition ( ) ;
            }
            
            dlg.ConfigurationName = orientation.Name;
            dlg.DicomTag          = GetTag(condition.Tag);
            dlg.TagValue          = condition.TagValue;
            
            dlg.ApplyCondition = orientation.Condition != null ;
            
            if ( dlg.ShowDialog ( this ) == DialogResult.OK )
            {
                orientation.Name   = dlg.ConfigurationName ;
                condition.Tag      = GetTag ( dlg.DicomTag ) ;
                condition.TagValue = dlg.TagValue ;
                
                if ( dlg.ApplyCondition )
                {
                  orientation.Condition = condition ;
                }
                else
                {
                  orientation.Condition = null ;
                }
                
                SetOrientationInfo ( orientation ) ;
            }
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void buttonDelete_Click(object sender, EventArgs e)
      {
         try
         {
            if ( comboBoxConfigs.SelectedIndex < 0 ) 
            {
               return ;
            }
            
            PlaneOrientation orientation ;
            Plane plane ;
            int   index ;


            orientation = comboBoxConfigs.SelectedItem as PlaneOrientation ;
            plane       = (Plane) comboBoxPlane.SelectedItem ;
            index       = comboBoxConfigs.Items.IndexOf(orientation);
            
            switch ( plane )
            {
               case Plane.Axial:
               {
                  _Configuration.Axial.Remove ( orientation ) ;
               }
               break;
               
               case Plane.Coronal:
               {
                  _Configuration.Coronal.Remove ( orientation ) ;
               }
               break;
               
               case Plane.Sagittal:
               {
                  _Configuration.Sagittal.Remove ( orientation ) ;
               }
               break;
            }
            
            comboBoxConfigs.Items.Remove(orientation);
            
            RefreshOrientationConfig ( ) ;
            
            UpdateOrientConfigUI ( ) ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }        


      public T Clone<T>(T source)
      {
         if (!typeof(T).IsSerializable)
         {
             throw new ArgumentException("The type must be serializable.", "source");
         }

         // Don't serialize a null object, simply return the default for that object
         if (Object.ReferenceEquals(source, null))
         {
             return default(T);
         }

         IFormatter formatter = new BinaryFormatter();
         Stream stream = new MemoryStream();
         using (stream)
         {
             formatter.Serialize(stream, source);
             stream.Seek(0, SeekOrigin.Begin);
             return (T)formatter.Deserialize(stream);
         }
      }

      private void dicomPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
      {
         try
         {
            if ( comboBoxConfigs.SelectedIndex < 0 ) 
            {
               return ;
            }
            
            PlaneOrientation po = comboBoxConfigs.SelectedItem as PlaneOrientation ;

            if ( po.Condition == null || po.Condition.GetType ( ) != typeof ( TagValueOrientationCondition ) )
            {
               return ;
            }
            
            
            ( ( TagValueOrientationCondition ) po.Condition ).TagValue = e.ChangedItem.Value ;
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void dicomPropertyGrid_BeforeAddElement(object sender, BeforeAddElementEventArgs e)
      {
         try
         {
            e.Element.Attributes.Add(new DisplayNameAttribute("Value"));
         }
         catch ( Exception exception ) 
         {
            Messager.ShowError ( this, exception ) ;
         }
      }

      private void BuildDataSet ( )
      {
         if ( comboBoxConfigs.SelectedIndex < 0 ) 
         {
            return ;
         }
         
         PlaneOrientation po = comboBoxConfigs.SelectedItem as PlaneOrientation ;
         TagValueOrientationCondition condition ;
      
         _Dataset.Reset ( ) ;
         
         if ( null == po.Condition || po.Condition.GetType ( ) != typeof ( TagValueOrientationCondition ) )
         {
            dicomPropertyGrid.DataSet = _Dataset ;
            
            return ;
         }
         
         condition = ( TagValueOrientationCondition ) po.Condition ;
         
         if ( condition.Tag != -1)
         {
            _PreviousCode = condition.Tag ;
            
            _Dataset.InsertElementAndSetValue ( condition.Tag, condition.TagValue ) ;
         }
         
         dicomPropertyGrid.DataSet = _Dataset ;
      }
      
      void ExportButton_Click(object sender, EventArgs e)
      {
         try
         {
            SaveFileDialog saveFileDlg ;
            
            
            if ( null == Configuration ) 
            {
               throw new InvalidOperationException ( "No configuration specified." ) ;
            }
            
            using ( saveFileDlg = new SaveFileDialog ( ) )
            {
               saveFileDlg.Filter = "Data Files (*.dat)|*.dat" ;
               
               saveFileDlg.FileName        = Path.ChangeExtension ( typeof ( OrientationConfiguration ).Name, "dat" ) ;
               saveFileDlg.CheckPathExists = true ;
               saveFileDlg.AddExtension    = true ;
               saveFileDlg.OverwritePrompt = true ;
               
               if ( saveFileDlg.ShowDialog ( this ) == DialogResult.OK )
               {
                  if ( File.Exists ( saveFileDlg.FileName ) )
                  {
                     File.Delete ( saveFileDlg.FileName ) ;
                  }
                  
                  using ( MemoryStream ms = new MemoryStream ( ) )
                  {
                     IFormatter formatter = new BinaryFormatter();
                     
                     formatter.Serialize ( ms, Configuration ) ;
                     
                     File.WriteAllBytes ( saveFileDlg.FileName, ms.ToArray ( ) ) ;
                  }
               }
            }
         }
         catch ( Exception exception )
         {
            Messager.ShowError ( this, exception ) ;
         }
      }
    }
}
