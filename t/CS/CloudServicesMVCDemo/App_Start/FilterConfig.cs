using System.Web;
using System.Web.Mvc;

namespace Cloud_Services_Api
{
   public class FilterConfig
   {
      public static void RegisterGlobalFilters(GlobalFilterCollection filters)
      {
         filters.Add(new HandleErrorAttribute());
      }
   }
}
