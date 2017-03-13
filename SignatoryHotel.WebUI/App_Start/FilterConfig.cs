using System.Web;
using System.Web.Mvc;
using Lanxess.CN.SignatoryHotel.WebUI.Classes;

namespace SignatoryHotel.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new lanxessSSOAuthFilterAttribute());
        }
    }
}
