using System.Web;
using System.Web.Mvc;

namespace Cua_Hang_Thu_Cung
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
