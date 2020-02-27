// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
// Uncomment this to use the pre v19 Leadtools.Annotations.WinForms.AutomationImageViewer.AutomationImageViewer
// which derives from ImageViewer
// Leave this commented out to use the new Leadtools.Annotations.WinForms.AutomationImageViewer.ImageViewerAutomationControl which
// contain an ImageViewer instance (doesn't derive from it)
//#define USE_ImageViewerAutomationControl

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Leadtools.Annotations.Engine;
using Leadtools.Annotations.BatesStamp;
using Leadtools.Annotations.Rendering;
using Leadtools.Annotations.Automation;
using Leadtools.Controls;

namespace Leadtools.Annotations.WinForms
{
   public partial class BatesStampDialog : Form
   {
      private AnnBatesStamp _currentBatesStamp = null;
      private AnnBatesStampComposer _composer = null;
      //the input composer that we want to update
      private AnnBatesStampComposer _targetComposer = null;
#if !USE_ImageViewerAutomationControl
      private ImageViewer _viewer;
#else
      private AutomationImageViewer _viewer;
#endif
      private AnnAutomationManager _manager = new AnnAutomationManager();
      private AnnAutomation _automation = null;
      private BindingList<AnnBatesStamp> _stampsList = new BindingList<AnnBatesStamp>();
      private AnnBatesStampTranslator _translator = new AnnBatesStampTranslator();

      private BatesStampDialog()
      {
         InitializeComponent();
      }

      public BatesStampDialog(RasterImage image, AnnBatesStampComposer targetComposer)
      {
         if (targetComposer == null)
            throw new ArgumentNullException("targetComposer");

         _targetComposer = targetComposer;

         _composer = new AnnBatesStampComposer();
         //if target container already have stamp then add it to dialog composer
         foreach (AnnBatesStamp stamp in _targetComposer.Stamps)
            _composer.Stamps.Add(stamp.Clone());

         InitializeComponent();

#if !USE_ImageViewerAutomationControl
         _viewer = new ImageViewer();
         var automationControl = new ImageViewerAutomationControl();
         automationControl.ImageViewer = _viewer;
#else
         _viewer = new AutomationImageViewer();
         IAnnAutomationControl automationControl = _viewer;
#endif
         _groupBoxViewer.Controls.Add(_viewer);
         _viewer.Dock = DockStyle.Fill;
         _viewer.Image = image;
         automationControl.AutomationDataProvider = new RasterImageAutomationDataProvider(image);

         _manager.RenderingEngine = new AnnWinFormsRenderingEngine();
         AnnBatesStampComposer.RenderingEngine = _manager.RenderingEngine;
         _manager.CreateDefaultObjects();
         _automation = new AnnAutomation(_manager, automationControl);

         // Update the container size
          _automation.Container.Size = _automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(_viewer.Image.ImageWidth, _viewer.Image.ImageHeight));
          _automation.Active = true;

         //Attach automation active container to _composer to start editing it
         _composer.TargetContainers.Add(_automation.Container);

         _listBoxContainerStamps.DataSource = _stampsList;
         _stampsList.ListChanged += new ListChangedEventHandler(_stampsList_ListChanged);

         if (_composer.Stamps.Count > 0)
         {
            _currentBatesStamp = _composer.Stamps[0];

            UpdateControls();

            for (int i = 0; i < _composer.Stamps.Count; i++)
            {
               AnnBatesStamp stamp = _composer.Stamps[i];
               stamp.FriendlyName = string.Concat(stamp.FriendlyName, i);
               _stampsList.Add(stamp);
            }
         }
      }

      private void CleanUp()
      {
         if (_composer != null)
            _composer.Dispose();
      }

      private void _btnChangeFont_Click(object sender, EventArgs e)
      {
         using (FontDialog fontDialog = new FontDialog())
         {
            fontDialog.ShowColor = true;
            fontDialog.Font = _lblBatesText.Font;
            fontDialog.Color = _lblBatesText.ForeColor;

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
               _lblBatesText.Font = fontDialog.Font;
               _lblBatesText.ForeColor = fontDialog.Color;

               Font font = _lblBatesText.Font;
               _currentBatesStamp.Font = AnnWinFormsRenderingEngine.FromFont(font);
               _currentBatesStamp.Logo.Font = AnnWinFormsRenderingEngine.FromFont(font);
               _currentBatesStamp.Foreground = AnnSolidColorBrush.Create(_lblBatesText.ForeColor.Name);
            }

            UpdateControls();
         }
      }

      private void _comboHorizontalAlignment_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_currentBatesStamp != null)
         {
            _currentBatesStamp.HorizontalAlignment = (AnnHorizontalAlignment)_comboHorizontalAlignment.SelectedIndex;
            UpdateControls();
         }
      }

      private void _comboVerticalAlignment_SelectedIndexChanged(object sender, EventArgs e)
      {
         if (_currentBatesStamp != null)
         {
            _currentBatesStamp.VerticalAlignment = (AnnVerticalAlignment)_comboVerticalAlignment.SelectedIndex;
            UpdateControls();
         }
      }

      private void UpdateControls()
      {
         if (_listBoxContainerStamps.SelectedIndex != -1)
         {
            _btnRemoveStamp.Enabled = true;
            _groupBoxStampText.Enabled = true;
            _groupBoxStampAlignment.Enabled = true;
            _groupBoxStampLogo.Enabled = true;
            _groupBoxStampElements.Enabled = true;
         }
         else
         {
            _btnRemoveStamp.Enabled = false;
            _groupBoxStampText.Enabled = false;
            _groupBoxStampAlignment.Enabled = false;
            _groupBoxStampLogo.Enabled = false;
            _groupBoxStampElements.Enabled = false;
            _txtElements.Text = string.Empty;
            _checkBoxStretchLogo.Checked = false;
         }

         if (_checkBoxStretchLogo.Checked)
            _groupBoxLogoPosition.Enabled = false;
         else
            _groupBoxLogoPosition.Enabled = true;
                  
         _currentBatesStamp = _listBoxContainerStamps.SelectedItem as AnnBatesStamp;

         if (_currentBatesStamp != null)
         {
            AnnBatesStampLogo logo = _currentBatesStamp.Logo;

            _lblBatesText.Font = AnnWinFormsRenderingEngine.ToFont(_currentBatesStamp.Font);
            AnnSolidColorBrush solidBrush = _currentBatesStamp.Foreground as AnnSolidColorBrush;
            _lblBatesText.ForeColor = ColorTranslator.FromHtml(solidBrush.Color);
            _lblBatesText.Text = _currentBatesStamp.AsString(_automation.Container);
            _comboHorizontalAlignment.SelectedIndex = (int)_currentBatesStamp.HorizontalAlignment;
            _comboVerticalAlignment.SelectedIndex = (int)_currentBatesStamp.VerticalAlignment;

            AnnPicture logoPicture = logo.Picture;
            if (_logoPictureBox.Image != null)
               _logoPictureBox.Image.Dispose();

            if (logoPicture != null && logoPicture.PictureData != null)
            {
               using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(logoPicture.PictureData)))
               {
                  _logoPictureBox.Image = Image.FromStream(memoryStream);
               }
            }
            else
            {
               _logoPictureBox.Image = null;
            }

            LeadRectD logoPosition = _automation.Container.Mapper.RectFromContainerCoordinates(logo.LogoRect, AnnFixedStateOperations.None);
            _txtLogoPositionX.Text = Math.Max(0, logoPosition.X).ToString();
            _txtLogoPositionY.Text = Math.Max(0, logoPosition.Y).ToString();
            _txtLogoPositionWidth.Text = Math.Round(logoPosition.Width, 1).ToString();
            _txtLogoPositionHeight.Text = Math.Round(logoPosition.Height, 1).ToString();

            _txtLogoOpacity.Text = logo.Opacity.ToString();
            _txtLogoText.Text = logo.Text;
            _txtLogoRotationAngle.Text = logo.Angle.ToString();

            _checkBoxStretchLogo.Checked = logo.StretchLogo;

            _txtElements.Text = _translator.WriteElementsToString(_currentBatesStamp.Elements.ToArray());
         }
         else //set default values
         {
            _lblBatesText.Font = new Font(new FontFamily("Microsoft Sans Serif"), 8);
            _lblBatesText.ForeColor = Color.Black;
            _lblBatesText.Text = string.Empty;
            _comboHorizontalAlignment.SelectedIndex = -1;
            _comboVerticalAlignment.SelectedIndex = -1;
            _logoPictureBox.Image = null;
            _txtLogoPositionX.Text = "0";
            _txtLogoPositionY.Text = "0";
            _txtLogoPositionWidth.Text = "0";
            _txtLogoPositionHeight.Text = "0";
            _txtLogoOpacity.Text = "1";
            _txtLogoText.Text = string.Empty;
            _txtLogoRotationAngle.Text = "0";
         }

         _btnDeleteLogoPicture.Enabled = (_logoPictureBox.Image != null);
         _automation.Invalidate(LeadRectD.Empty);
      }

      private void _btnLoadImage_Click(object sender, EventArgs e)
      {
         if (_currentBatesStamp != null)
         {
            AnnBatesStampLogo logo = _currentBatesStamp.Logo;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
               openFileDialog.Title = "Load Image";
               openFileDialog.Filter = "Png files (*.png)|*.png";
               if (openFileDialog.ShowDialog() == DialogResult.OK)
               {
                  Image image = Image.FromFile(openFileDialog.FileName);
                  _logoPictureBox.Image = image;

                  using (MemoryStream memoryStream = new MemoryStream())
                  {
                     image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                     logo.Picture = new AnnPicture(memoryStream.ToArray());
                  }
               }
            }

            UpdateControls();
         }
      }

      private void _txtLogoPosition_TextChanged(object sender, EventArgs e)
      {
         try
         {
            if (_currentBatesStamp != null)
            {
               AnnBatesStampLogo logo = _currentBatesStamp.Logo;
               AnnContainerMapper mapper = _automation.Container.Mapper;
               LeadRectD logoPosition = mapper.RectFromContainerCoordinates(logo.LogoRect, AnnFixedStateOperations.None);
               logoPosition.X = double.Parse(_txtLogoPositionX.Text);
               logoPosition.Y = double.Parse(_txtLogoPositionY.Text);
               logoPosition.Width = double.Parse(_txtLogoPositionWidth.Text);
               logoPosition.Height = double.Parse(_txtLogoPositionHeight.Text);
               logo.LogoRect = mapper.RectToContainerCoordinates(logoPosition);
               UpdateControls();
            }
         }
         catch
         {
         }
      }

      private void AddNewElement_Click(object sender, EventArgs e)
      {
         IAnnBatesElement newElement = null;
         if (sender == _btnAddBatesNumber)
         {
            using (BatesNumberDialog dlg = new BatesNumberDialog())
            {
               if (dlg.ShowDialog() == DialogResult.OK)
               {
                  newElement = dlg.BatesNumber;
                  _txtElements.Text = string.Concat(_txtElements.Text, _translator.WriteElementToString(newElement));
               }
            }
         }
         else if (sender == _btnAddDate)
         {
            using (BatesDateDialog dlg = new BatesDateDialog())
            {
               if (dlg.ShowDialog() == DialogResult.OK)
               {
                  newElement = dlg.BatesDateTime;
                  _txtElements.Text = string.Concat(_txtElements.Text, _translator.WriteElementToString(newElement));
               }
            }
         }

         UpdateControls();
      }

      private void _btnAddStamp_Click(object sender, EventArgs e)
      {
         AnnBatesStamp stamp = new AnnBatesStamp();
         stamp.FriendlyName = string.Concat(stamp.FriendlyName, _listBoxContainerStamps.Items.Count);
         _currentBatesStamp = stamp;
         _composer.Stamps.Add(stamp);
         _stampsList.Add(stamp);
      }

      private void _btnRemoveStamp_Click(object sender, EventArgs e)
      {
         _composer.Stamps.Remove(_currentBatesStamp);
         _stampsList.Remove(_currentBatesStamp);
      }

      void _stampsList_ListChanged(object sender, ListChangedEventArgs e)
      {
         _listBoxContainerStamps.SelectedIndex = _stampsList.Count - 1;
         UpdateControls();
      }

      private void _listBoxContainerStamps_SelectedIndexChanged(object sender, EventArgs e)
      {
         UpdateControls();
      }

      private void _txtLogoOpacity_TextChanged(object sender, EventArgs e)
      {
         try
         {
            double opacity = double.Parse(_txtLogoOpacity.Text);

            if (opacity > 1 || opacity < 0)
               opacity = 1;

            _currentBatesStamp.Logo.Opacity = opacity;
            _txtLogoOpacity.Select(0, _txtLogoOpacity.Text.Length);
            UpdateControls();
         }
         catch 
         {
         }
      }

      private void _txtLogoText_TextChanged(object sender, EventArgs e)
      {
         _currentBatesStamp.Logo.Text = _txtLogoText.Text;
         UpdateControls();
      }

      private void _txtLogoRotationAngle_TextChanged(object sender, EventArgs e)
      {
         if (_currentBatesStamp == null)
            return;

         string angleText = _txtLogoRotationAngle.Text;
         if (angleText == "-")
         {
            return;
         }

         try
         {
            if (_txtLogoRotationAngle.Text == string.Empty)
            {
               _currentBatesStamp.Logo.Angle = 0;
            }
            else
            {
               double rotationAngle = double.Parse(angleText);
               if (rotationAngle < -360 || rotationAngle > 360)
                  throw new InvalidOperationException();

               _currentBatesStamp.Logo.Angle = rotationAngle;
            }
         }
         catch (Exception)
         {
            _currentBatesStamp.Logo.Angle = 0;
            MessageBox.Show("Wrong value for rotate angle , the value should be from -360 to 360", "Wrong Value", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         }
         finally
         {
            UpdateControls();
         }
      }

      private void _checkBoxStretchLogo_CheckedChanged(object sender, EventArgs e)
      {
         _currentBatesStamp.Logo.StretchLogo = _checkBoxStretchLogo.Checked;
         UpdateControls();
      }

      private void _radioButtonFit_CheckedChanged(object sender, EventArgs e)
      {
         _viewer.Zoom(ControlSizeMode.Fit, 1, new LeadPoint());
      }

      private void radioButtonNormal_CheckedChanged(object sender, EventArgs e)
      {
         _viewer.Zoom(ControlSizeMode.ActualSize, 1, new LeadPoint());
      }

      private void _txtElements_TextChanged(object sender, EventArgs e)
      {
         IAnnBatesElement[] elements = _translator.ReadFromString(_txtElements.Text);

         _currentBatesStamp.Elements.Clear();

         if (elements != null)
         {
            foreach (IAnnBatesElement element in elements)
            {
               _currentBatesStamp.Elements.Add(element);
            }
         }

         UpdateControls();
      }

      private void _btnOK_Click(object sender, EventArgs e)
      {
         _targetComposer.Stamps.Clear();

         foreach (AnnBatesStamp stamp in _composer.Stamps)
         {
            _targetComposer.Stamps.Add(stamp);
         }
         
      }

      private void _btnDeleteLogoPicture_Click(object sender, EventArgs e)
      {
         _currentBatesStamp.Logo.Picture = null;
         UpdateControls();
      }
   }
}
