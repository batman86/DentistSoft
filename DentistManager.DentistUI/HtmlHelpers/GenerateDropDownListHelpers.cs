using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using DentistManager.Domain.ViewModel;
using DentistManager.DentistUI.Infrastructure;

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

        public static MvcHtmlString generatePatientMedicineDropDownList(this HtmlHelper helper, IEnumerable<MedicineMiniViewModel> list)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<select name=prescriptionViewModel.MedicineID id=MedicineDropDown>");
            foreach (MedicineMiniViewModel i in list)
            {
                result.Append("<option value=\"" + i.MedicineID + "\"  data-dose=" + i.Dose + " data-scaletype=" + i.ScaleType + " data-concentration=" + i.Concentration + " data-sideeffectdecsription=" + i.SideEffectDecsription + " >" + i.Name + "</option>");
            }
            result.Append("</select>");
            return MvcHtmlString.Create(result.ToString());
        }
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

        public static MvcHtmlString generateAppStatusDropDownList(this HtmlHelper helper, string ActiveStatus)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<select name=statusFilter id=StatusDropDown>");

            result.Append(ActiveStatus == "All" ? "<option value='All' selected>All Status</option>" : "<option value='All'>All Status</option>");
            result.Append(ActiveStatus == PatientSchduelStatus.waiting.ToString() ? "<option value='waiting' selected>waiting</option>" : "<option value='waiting'>waiting</option>");
            result.Append(ActiveStatus == PatientSchduelStatus.InProgress.ToString() ? "<option value='InProgress' selected>In Progress</option>" : "<option value='InProgress'>In Progress</option>");
            result.Append(ActiveStatus == PatientSchduelStatus.Postponed.ToString() ? "<option value='Postponed' selected>Postponed</option>" : "<option value='Postponed'>Postponed</option>");
            result.Append(ActiveStatus == PatientSchduelStatus.Reserved.ToString() ? "<option value='Reserved' selected>Reserved</option>" : "<option value='Reserved'>Reserved</option>");
            result.Append(ActiveStatus == PatientSchduelStatus.Finished.ToString() ? "<option value='Finished' selected>Finished</option>" : "<option value='Finished'>Finished</option>"); 

            result.Append("</select>");
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString generateAppStatusEditDropDownList(this HtmlHelper helper, string ActiveStatus)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<select name=Status id=StatusDropDown>");

            result.Append(ActiveStatus == PatientSchduelStatus.waiting.ToString() ? "<option value='waiting' selected>waiting</option>" : "<option value='waiting'>waiting</option>");
            result.Append(ActiveStatus == PatientSchduelStatus.InProgress.ToString() ? "<option value='InProgress' selected>In Progress</option>" : "<option value='InProgress'>In Progress</option>");
            result.Append(ActiveStatus == PatientSchduelStatus.Postponed.ToString() ? "<option value='Postponed' selected>Postponed</option>" : "<option value='Postponed'>Postponed</option>");
            result.Append(ActiveStatus == PatientSchduelStatus.Reserved.ToString() ? "<option value='Reserved' selected>Reserved</option>" : "<option value='Reserved'>Reserved</option>");
            result.Append(ActiveStatus == PatientSchduelStatus.Finished.ToString() ? "<option value='Finished' selected>Finished</option>" : "<option value='Finished'>Finished</option>");

            result.Append("</select>");
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString generateAppDateFilterDropDownList(this HtmlHelper helper, string timeFilter)
        {
            StringBuilder result = new StringBuilder();

            result.Append("<select name=timeFilter id=timeFilterDropDown>");

            result.Append(timeFilter == SchduelStatusTimeFilter.Daily.ToString() ? "<option value='Daily' selected>Daily</option>" : "<option value='Daily'>Daily</option>");
            result.Append(timeFilter == SchduelStatusTimeFilter.Weekly.ToString() ? "<option value='Weekly' selected>Weekly</option>" : "<option value='Weekly'>Weekly</option>");
            result.Append(timeFilter == SchduelStatusTimeFilter.Monthly.ToString() ? "<option value='Monthly' selected>Monthly</option>" : "<option value='Monthly'>Monthly</option>");

            result.Append("</select>");
            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString generatePagingDropDownList(this HtmlHelper helper, PagingInfoHolder pagingInfoHolder)
        {
            StringBuilder result = new StringBuilder();
            //string pageNumber = "";

            int offdev = pagingInfoHolder.ItemTotal % pagingInfoHolder.pageSize;
            int itemTotal = pagingInfoHolder.ItemTotal - offdev;
            int pagesTotal = itemTotal / pagingInfoHolder.pageSize;
            int startpage=0;
            int endPage = 0;

            if (offdev != 0)
                pagesTotal++;

            if( pagingInfoHolder.pageNumber >= 2)
                startpage = pagingInfoHolder.pageNumber - 2;

            if (pagesTotal >= pagingInfoHolder.pageNumber+2)
                endPage = pagingInfoHolder.pageNumber + 2;
            else
                endPage = pagesTotal;
            result.Append("<div class=PagerHolder>");
            for (int i = startpage; i < endPage; i++)
            {
               // result.Append("<a href="+"~/" + pagingInfoHolder.areaName + "/" + pagingInfoHolder.controllerName + "/" + pagingInfoHolder.ActionName + "/" + "?pageNumber=" + i.ToString() + ">" + (i+1).ToString()+ "</a>");
                if (pagingInfoHolder.pageNumber ==i)
                    result.Append("<a class=selected href=?pageNumber=" + i.ToString() + ">" + (i + 1).ToString() + "</a>");
                else
                    result.Append("<a href=?pageNumber=" + i.ToString() + ">" + (i + 1).ToString() + "</a>");
            }
            result.Append("</div>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString generatePayedDropDownList(this HtmlHelper helper, bool? payed)
        {
            if (payed == null)
                payed = false;

            StringBuilder result = new StringBuilder();

            result.Append("<select name=payed id=payedDropDown>");

            result.Append(payed == true ? "<option value='1' selected>Payed</option>" : "<option value='1'>Payed</option>");
            result.Append(payed == false ? "<option value='0' selected>not Payed</option>" : "<option value='0'>not Payed</option>");

            result.Append("</select>");
            return MvcHtmlString.Create(result.ToString());
        }
    }
}