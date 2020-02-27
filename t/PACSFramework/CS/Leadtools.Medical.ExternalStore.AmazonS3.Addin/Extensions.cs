using Amazon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadtools.Medical.ExternalStore.AmazonS3.Addin
{
   public static class Extensions
   {

      public static RegionEndpoint ToRegionEndpoint(this RegionEndpointEnum region)
      {
         RegionEndpoint regionEndpoint = RegionEndpoint.USEast1;
         switch (region)
         {
            // [Description("Asia Pacific (Mumbai)")]
            case RegionEndpointEnum.AsiaPacificMumbai:
               regionEndpoint = RegionEndpoint.APSouth1;
               break;

            // [Description("Asia Pacific (Seoul")]
            case RegionEndpointEnum.AsiaPacificSeoul:
               regionEndpoint = RegionEndpoint.APNortheast2;
               break;

            // [Description("Asia Pacific (Singapore)")]
            case RegionEndpointEnum.AsiaPacificSingapore:
               regionEndpoint = RegionEndpoint.APSoutheast1;
               break;

            // [Description("Asia Pacific (Sydney)")]
            case RegionEndpointEnum.AsiaPacificSydney:
               regionEndpoint = RegionEndpoint.APSoutheast2;
               break;

            // [Description("Asia Pacific (Tokyo)")]
            case RegionEndpointEnum.AsiaPacificTokyo:
               regionEndpoint = RegionEndpoint.APNortheast1;
               break;

            // [Description("Canada (Central)")]
            case RegionEndpointEnum.CanadaCentral:
               regionEndpoint = RegionEndpoint.CACentral1;
               break;

            // [Description("EU (Frankfurt)")]
            case RegionEndpointEnum.EUFrankfurt:
               regionEndpoint = RegionEndpoint.EUCentral1;
               break;

            // [Description("EU (Ireland)")]
            case RegionEndpointEnum.EUIreland:
               regionEndpoint = RegionEndpoint.EUWest1;
               break;

            // [Description("EU (London)")]
            case RegionEndpointEnum.EULondon:
               regionEndpoint = RegionEndpoint.EUWest2;
               break;

            // [Description("EU (Paris)")]
            case RegionEndpointEnum.EUParis:
               regionEndpoint = RegionEndpoint.EUWest3;
               break;

            // [Description("EU (Stockholm)")]
            case RegionEndpointEnum.EUStockholm:
               regionEndpoint = RegionEndpoint.EUNorth1;
               break;

            // [Description("South America (São Paulo)")]
            case RegionEndpointEnum.SouthAmericaSaoPaulo:
               regionEndpoint = RegionEndpoint.SAEast1;
               break;

            // [Description("US East (N. Virginia)")]
            case RegionEndpointEnum.USEastNVirginia:
               regionEndpoint = RegionEndpoint.USEast1;
               break;

            // [Description("US East (Ohio)")]
            case RegionEndpointEnum.USEastOhio:
               regionEndpoint = RegionEndpoint.USEast2;
               break;

            // [Description("US West (N. California)")]
            case RegionEndpointEnum.USWestNCalifornia:
               regionEndpoint = RegionEndpoint.USWest1;
               break;

            // [Description("US West (Oregon)")]
            case RegionEndpointEnum.USWestOregon:
               regionEndpoint = RegionEndpoint.USWest2;
               break;
         }
         return regionEndpoint;
      }

      public static string FileNameToToken(this string fileName)
      {
         string root = Path.GetPathRoot(fileName);
         string key = fileName.Substring(root.Length);
         key = key.Replace('\\', '/');

         return key;
      }
   }
}
