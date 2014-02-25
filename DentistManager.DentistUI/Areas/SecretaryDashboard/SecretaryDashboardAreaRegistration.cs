using System.Web.Mvc;

namespace DentistManager.DentistUI.Areas.SecretaryDashboard
{
    public class SecretaryDashboardAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SecretaryDashboard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SecretaryDashboard_default",
                "SecretaryDashboard/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}