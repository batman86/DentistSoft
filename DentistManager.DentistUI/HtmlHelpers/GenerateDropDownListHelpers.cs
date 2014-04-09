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

            result.Append("<select name=imagesViewModel.ImageCategoryID id=ImageCategoryDropDown>");
            foreach (ImageCategoryViewModel i in list)
            {
                result.Append("<option value=\"" + i.ImageCategoryID + "\">" + i.Name + "</option>");
            }
            result.Append("</select>");
            return MvcHtmlString.Create(result.ToString());
        }
        //public static MvcHtmlString generateImageCategoryDropDownList2(this HtmlHelper helper, IEnumerable<ImageCategoryViewModel> list)
        //{
        //    StringBuilder result = new StringBuilder();

        //    result.Append("<select name=ImagesViewModel.ImageCategoryID id=ImageCategoryDropDown>");
        //    result.Append("<option value=0 \">All Images Categories</option>");
        //    foreach (ImageCategoryViewModel i in list)
        //    {
        //        result.Append("<option value=\"" + i.ImageCategoryID + "\">" + i.Name + "</option>");
        //    }
        //    result.Append("</select>");
        //    return MvcHtmlString.Create(result.ToString());
        //}

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
        // enhance later
        public static MvcHtmlString generatePatientAppointmentDropDownList2(this HtmlHelper helper, IEnumerable<AppointmentViewModel> list)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<select name=prescriptionViewModel.AppointmentID id=appointmentDropDown>");
            foreach (AppointmentViewModel i in list)
            {
                result.Append("<option value=\"" + i.AppointmentID + "\">" + i.Date + "</option>");
            }
            result.Append("</select>");
            return MvcHtmlString.Create(result.ToString());
        }
        //// enhance later
        //public static MvcHtmlString generatePatientAppointmentDropDownList3(this HtmlHelper helper, IEnumerable<AppointmentViewModel> list)
        //{
        //    StringBuilder result = new StringBuilder();

        //    result.Append("<select name=AppointmentID id=appointmentDropDown>");
        //    result.Append("<option value=0 \">All Appointment</option>");
        //    foreach (AppointmentViewModel i in list)
        //    {
        //        result.Append("<option value=\"" + i.AppointmentID + "\">" + i.Date + "</option>");
        //    }
        //    result.Append("</select>");
        //    return MvcHtmlString.Create(result.ToString());
        //}

        public static MvcHtmlString generatePatientMedicineDropDownList(this HtmlHelper helper, IEnumerable<MedicineMiniViewModel> list)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<select name=prescriptionViewModel.MedicineID id=MedicineDropDown>");
            foreach (MedicineMiniViewModel i in list)
            {
                result.Append("<option value=\"" + i.MedicineID + "\">" + i.Name + "</option>");
            }
            result.Append("</select>");
            return MvcHtmlString.Create(result.ToString());
        }

        //public static MvcHtmlString generateCustomMatrialFilterDropDown(this HtmlHelper helper,string FilterType)
        //{
        //    StringBuilder result = new StringBuilder();

        //    result.Append("<select name=FilterType");

        //    if (FilterType == "1")
        //        result.Append("<option value="+1+" selected>All Doctor Custom Matrials</option> <option value="+2+">All Patient Custom Matrials</option>");
        //    else
        //        result.Append("<option value=" + 1 + ">All Doctor Custom Matrials</option> <option value=" + 2 + " selected>All Patient Custom Matrials</option>");

        //    result.Append("</select>");

        //    return MvcHtmlString.Create(result.ToString());
        //}
        public static MvcHtmlString generateDoctorsDropDownList(this HtmlHelper helper, IEnumerable<DoctorMiniInfoViewModel> list)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<select name=PatientInfo.DoctorID id=DoctorsDropDown>");
            foreach (DoctorMiniInfoViewModel i in list)
            {
                result.Append("<option value=\"" + i.DoctorID + "\">" + i.DoctorName + "</option>");
            }
            result.Append("</select>");
            return MvcHtmlString.Create(result.ToString());
        }
    }
}