// *************************************************************
// Copyright (c) 1991-2019 LEAD Technologies, Inc.              
// All Rights Reserved.                                         
// *************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Leadtools.Twain;
using System.Collections;
using System.Windows.Forms;
using PrintToPACSDemo.UI;
using Leadtools;
using System.IO;

namespace PrintToPACSDemo
{
   public partial class FrmMain
   {
      TwainSession _twainSession;
      static ArrayList _twainerrorList;
      public TwainTransferMechanism _twaintransferMode = TwainTransferMechanism.Native;
      bool _twainAvailable = false;
      ListImageBox.ImageCollection twainImageCollection;

      private void InitializeTwain()
      {
         // Determine whether a TWAIN source is installed
#if LEADTOOLS_V19_OR_LATER
         _twainAvailable = TwainSession.IsAvailable(this.Handle);
#else
         _twainAvailable = TwainSession.IsAvailable(this);
#endif // #if LEADTOOLS_V19_OR_LATER

         if (_twainAvailable)
         {
            // Construct a new TwainSession object with default values
            _twainSession = new TwainSession();
            // Initialize the TWAIN session 
            // This method must be called before calling any other methods that require a TWAIN session
#if LEADTOOLS_V19_OR_LATER
            _twainSession.Startup(this.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
#else
            _twainSession.Startup(this, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None);
#endif // #if LEADTOOLS_V19_OR_LATER

            // Set the AcquirePage Event handler
            _twainSession.AcquirePage += new EventHandler<TwainAcquirePageEventArgs>(_twain_AcquirePage);
         }
         else
         {
            _miTwainSelectSource.Enabled = false;
            _miTwainAcquire.Enabled = false;
            _miTemplateLEAD.Enabled = false;
            _miTemplateShowCaps.Enabled = false;
            _miTemplateShowErrors.Enabled = false;
         }

         _twainerrorList = new ArrayList();

         if (_mySettings._settings.TwainSelectedDevice !=null)
            try
            {
            	_twainSession.SelectSource(_mySettings._settings.TwainSelectedDevice);
            }
            catch{}
      }

      private void _miTwainSelectSource_Click(object sender, System.EventArgs e)
      {
         // Display the TWAIN dialog box to be used to select a TWAIN source for acquiring images
         _twainSession.SelectSource(String.Empty);
         _mySettings._settings.TwainSelectedDevice = _twainSession.SelectedSourceName();
         _mySettings.Save();
      }

      private void _twain_AcquirePage(object sender, TwainAcquirePageEventArgs e)
      {
         // This event occurs for each page acquired using the Acquire method
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         try
         {
            if (_twaintransferMode != TwainTransferMechanism.File)
            {
               if (e.Image != null)
               {
                  Page page = new Page();
                  page.DeleteOnDispose = false;
                  string strTemp = Path.GetTempFileName();
                  _codec.Save(e.Image, strTemp, Leadtools.RasterImageFormat.Tif, 0);
                  page.FilePath = strTemp;
                  twainImageCollection.Images.Add(new ListImageBox.ImageItem(_codec.Load(strTemp), twainImageCollection, page));
                  e.Image.Dispose();
               }
            }
            else
               MessageBox.Show(this, "Acquired page(s) is saved to file(s)", "Acquire to File");
         }
         catch (Exception ex)
         {
            AddErrorToErrorList(ex.Message);
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miTwainAcquire_Click(object sender, System.EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         try
         {
            SetTransferMode();
            // Acquire one or more images from a TWAIN source.
            twainImageCollection = new ListImageBox.ImageCollection("Twain Aquire");
            _twainSession.Acquire(TwainUserInterfaceFlags.Show | TwainUserInterfaceFlags.Modal);
         }
         catch (Exception ex)
         {
            AddErrorToErrorList(ex.Message);
            MessageBox.Show(this, ex.Message);
         }
         if (twainImageCollection.Images.Count > 0)
            _lstBoxPages.AddImageCollection(twainImageCollection);

         logWindow.TopMost = bTopMost;
      }

      static public void AddErrorToErrorList(string error)
      {
         _twainerrorList.Add(error);
      }

      private void _miTemplateShowErrors_Click(object sender, System.EventArgs e)
      {
         using (ErrorList errorListDlg = new ErrorList())
         {
            errorListDlg._arrayList = _twainerrorList;
            bool bTopMost = logWindow.TopMost;
            logWindow.TopLevel = false;
            if (errorListDlg.ShowDialog(this) == DialogResult.OK)
            {
               if (errorListDlg._listCleared)
                  _twainerrorList.Clear();
            }
            logWindow.TopMost = bTopMost;
         }
      }

      private void _miTemplateShowCaps_Click(object sender, System.EventArgs e)
      {
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         using (SupportedCaps supportedCapsDls = new SupportedCaps())
         {
            try
            {
               // Get an array of Twain Capabilities supported in the current session
               supportedCapsDls._caps = _twainSession.QuerySupportedCapabilities();
               supportedCapsDls.ShowDialog(this);
            }
            catch (Exception ex)
            {
               AddErrorToErrorList(ex.Message);
            }
         }
         logWindow.TopMost = bTopMost;
      }

      private void _miTemplateLEAD_Click(object sender, System.EventArgs e)
      {
         // Show the Templates dialog which will allow to Save/Load scanning settings
         bool bTopMost = logWindow.TopMost;
         logWindow.TopMost = false;
         using (Template templateDlg = new Template())
         {
            templateDlg._twainSession = _twainSession;
            templateDlg.ShowDialog(this);

            if (templateDlg.DialogResult == DialogResult.OK)
               _twaintransferMode = templateDlg._transferMode;
         }
         logWindow.TopMost = bTopMost;
      }

      private void SetTransferMode()
      {
         using (TwainCapability twnCap = new TwainCapability())
         {
            try
            {
               twnCap.Information.Type = TwainCapabilityType.ImageTransferMechanism;
               twnCap.Information.ContainerType = TwainContainerType.OneValue;

               twnCap.OneValueCapability.ItemType = TwainItemType.Uint16;
               twnCap.OneValueCapability.Value = (UInt16)_twaintransferMode;

               // Set the value of ICAP_XFERMECH (Image Transfer Mechanism) capability
               _twainSession.SetCapability(twnCap, TwainSetCapabilityMode.Set);
            }
            catch (Exception ex)
            {
               string errorMsg = string.Format("Error set TwainCapabilityType.ImageTranserMechanism is {0}", ex.Message);
               AddErrorToErrorList(errorMsg);
            }
         }
      }

      private void FinilizeTwain()
      {
         if (_twainAvailable)
            // End TWAIN session
            // For each call to the Startup method there must be a call to the Shutdown method
            this._twainSession.Shutdown();
      }

   }
}
