using System.Web;
using System.Web.Mvc;

namespace BuildingApplicationsWithPluralsite
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
