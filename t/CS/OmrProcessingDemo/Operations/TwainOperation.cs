using Leadtools;
using Leadtools.Codecs;
using Leadtools.Twain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OmrProcessingDemo.Operations
{
   class TwainOperation : BusyOperation
   {
      private TwainSession twainSession;
      private string saveLocation;
      private RasterImageFormat format;

      public TwainOperation(TwainSession twnSession, string saveLocation, RasterImageFormat format)
      {
         this.twainSession = twnSession;
         this.saveLocation = saveLocation;
         this.format = format;
      }

      protected override void Run()
      {
         Progress(101, "Acquiring from scanner...");

         RasterImage image = null;// = twainSession.AcquireToImage(TwainUserInterfaceFlags.Show | TwainUserInterfaceFlags.Modal);

         SetTransferMode();

         twainSession.Acquire(TwainUserInterfaceFlags.Show | TwainUserInterfaceFlags.Modal);

         using (RasterCodecs codecs = MainForm.GetRasterCodecs())
         {
            codecs.Save(image, saveLocation, format, 0);
         }

         image.Dispose();

         base.Run();
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
               twnCap.OneValueCapability.Value = (UInt16)TwainTransferMode.File;

               // Set the value of ICAP_XFERMECH (Image Transfer Mechanism) capability
               twainSession.SetCapability(twnCap, TwainSetCapabilityMode.Set);
            }
            catch (Exception ex)
            {
               throw ex;
            }
         }
      }


   }
}
