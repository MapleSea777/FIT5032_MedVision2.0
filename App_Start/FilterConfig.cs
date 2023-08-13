using System.Web;
using System.Web.Mvc;

namespace AssignmentPorfolio_MedVision
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
