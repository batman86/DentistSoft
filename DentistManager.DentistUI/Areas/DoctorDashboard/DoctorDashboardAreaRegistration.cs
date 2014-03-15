using System.Web.Mvc;

namespace DentistManager.DentistUI.Areas.DoctorDashboard
{
    public class DoctorDashboardAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DoctorDashboard";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "DoctorDashboard_default",
                "DoctorDashboard/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}