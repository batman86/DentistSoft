using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using DentistManager.Domain.ViewModel;


namespace DentistManager.DentistUI.HtmlHelpers
{
    public static class GenerateDropDownListHelpers
    {
        public static MvcHtmlString generateImageCategoryDropDownList(this HtmlHelper helper, IEnumerable<ImageCategoryViewModel> list)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<select name=ImagesViewModel.ImageCategoryID id=ImageCategoryDropDown>");
            foreach (ImageCategoryViewModel i in list)
            {
                result.Append("<option value=\"" + i.ImageCategoryID + "\">" + i.Name + "</option>");
            }
            result.Append("</select>");
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString generatePatientAppointmentDropDownList(this HtmlHelper helper, IEnumerable<AppointmentViewModel> list)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<select name=ImagesViewModel.appointmentID id=appointmentDropDown>");
            foreach (AppointmentViewModel i in list)
            {
                result.Append("<option value=\"" + i.AppointmentID + "\">" + i.Date + "</option>");
            }
            result.Append("</select>");
            return MvcHtmlString.Create(result.ToString());
        }
    }
}