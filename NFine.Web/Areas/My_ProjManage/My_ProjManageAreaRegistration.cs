using System.Web.Mvc;

namespace NFine.Web.Areas.My_ProjManage
{
    public class My_ProjManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "My_ProjManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "My_ProjManage_default",
                "My_ProjManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}