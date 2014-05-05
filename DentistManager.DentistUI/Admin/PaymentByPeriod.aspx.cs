using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DentistManager.Domain.DAL.Concrete;
using DevExpress.Web.ASPxGridView;

namespace DentistManager.DentistUI.Admin
{
    public partial class PaymentByPeriod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvxPaymentClinics_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Total Required")
            {
                PaymentRepository paymentRepository = new PaymentRepository();
                e.Value = paymentRepository.GetAllCostTreatmentByClinicByPeriod(int.Parse(e.GetListSourceFieldValue("ClinicID").ToString()),txtDateFrom.Date,txtDateTo.Date);

            }
            else if (e.Column.FieldName == "Total Payed")
            {
                PaymentRepository paymentRepository = new PaymentRepository();
                e.Value = paymentRepository.GetAllPayedReceitsByClinicByPeriod(int.Parse(e.GetListSourceFieldValue("ClinicID").ToString()),txtDateFrom.Date,txtDateTo.Date);

            }
            else if (e.Column.FieldName == "Total Deserved")
            {
                e.Value = decimal.Parse(e.GetListSourceFieldValue("Total Required").ToString()) - decimal.Parse(e.GetListSourceFieldValue("Total Payed").ToString());

            }
        }

        protected void gvxDoctor_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDataEventArgs e)
        {
            ASPxGridView gvDoctor = (ASPxGridView)sender;
            int clinicID = int.Parse(gvDoctor.GetMasterRowKeyValue().ToString());
            if (e.Column.FieldName == "Total Required")
            {
                PaymentRepository paymentRepository = new PaymentRepository();
                e.Value = paymentRepository.GetAllTeratmentByDoctorByPeriod(int.Parse(e.GetListSourceFieldValue("DoctorID").ToString()), clinicID,txtDateFrom.Date ,txtDateTo.Date);

            }
            else if (e.Column.FieldName == "Total Payed")
            {
                PaymentRepository paymentRepository = new PaymentRepository();
                e.Value = paymentRepository.GetAllPaymentReceitByDoctorByPeriod(int.Parse(e.GetListSourceFieldValue("DoctorID").ToString()), clinicID,txtDateFrom.Date,txtDateTo.Date);
            }
            else if (e.Column.FieldName == "Total Deserved")
            {
                e.Value = decimal.Parse(e.GetListSourceFieldValue("Total Required").ToString()) - decimal.Parse(e.GetListSourceFieldValue("Total Payed").ToString());
            }

        }

        protected void gvxDoctor_BeforePerformDataSelect(object sender, EventArgs e)
        {
            dsDoctors.SelectParameters["ClinicID"].DefaultValue = (sender as ASPxGridView).GetMasterRowKeyValue().ToString();
            //((sender as ASPxGridView).Parent.Parent as ASPxGridView).GetMasterRowKeyValue();
        }

        protected void gvxPatients_CustomUnboundColumnData(object sender, ASPxGridViewColumnDataEventArgs e)
        {
            ASPxGridView gvpatients = (ASPxGridView)sender;
            int DoctorID = int.Parse(gvpatients.GetMasterRowKeyValue().ToString());
            int ClinicID = int.Parse(((sender as ASPxGridView).NamingContainer as GridViewDetailRowTemplateContainer).Grid.GetMasterRowKeyValue().ToString());
            if (e.Column.FieldName == "Total Required")
            {
                PaymentRepository paymentRepository = new PaymentRepository();
                e.Value = paymentRepository.GetAllTeratmentByPatient(DoctorID, ClinicID, int.Parse(e.GetListSourceFieldValue("PatientID").ToString()));

            }
            else if (e.Column.FieldName == "Total Payed")
            {
                PaymentRepository paymentRepository = new PaymentRepository();
                e.Value = paymentRepository.GetAllPaymentReceitByPatient(DoctorID, ClinicID, int.Parse(e.GetListSourceFieldValue("PatientID").ToString()));
            }
            else if (e.Column.FieldName == "Total Deserved")
            {
                e.Value = decimal.Parse(e.GetListSourceFieldValue("Total Required").ToString()) - decimal.Parse(e.GetListSourceFieldValue("Total Payed").ToString());
            }
        }

        protected void gvxPatients_BeforePerformDataSelect(object sender, EventArgs e)
        {
            dsPatients.SelectParameters["DoctorID"].DefaultValue = (sender as ASPxGridView).GetMasterRowKeyValue().ToString();
            string clinicID = ((sender as ASPxGridView).NamingContainer as GridViewDetailRowTemplateContainer).Grid.GetMasterRowKeyValue().ToString();
            dsPatients.SelectParameters["ClinicID"].DefaultValue = clinicID;
        }

        protected void gvxPaymentClinics_DataBound(object sender, EventArgs e)
        {
            gvxPaymentClinics.TotalSummary.Clear();
            gvxPaymentClinics.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Required").DisplayFormat = "Total : {0:C3}";
            gvxPaymentClinics.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Payed").DisplayFormat = "Total : {0:C3}";
            gvxPaymentClinics.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Deserved").DisplayFormat = "Total : {0:C3}";

        }

        protected void gvxDoctor_DataBound(object sender, EventArgs e)
        {
            ASPxGridView gvxDoctor = sender as ASPxGridView;
            gvxDoctor.TotalSummary.Clear();
            gvxDoctor.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Required").DisplayFormat = "Total : {0:C3}";
            gvxDoctor.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Payed").DisplayFormat = "Total : {0:C3}";
            gvxDoctor.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Deserved").DisplayFormat = "Total : {0:C3}";

        }

        protected void gvxPatients_DataBound(object sender, EventArgs e)
        {
            ASPxGridView gvxPatient = sender as ASPxGridView;
            gvxPatient.TotalSummary.Clear();
            gvxPatient.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Required").DisplayFormat = "Total : {0:C3}";
            gvxPatient.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Payed").DisplayFormat = "Total : {0:C3}";
            gvxPatient.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total Deserved").DisplayFormat = "Total : {0:C3}";
        }

        protected void btnReceipts_Click(object sender, EventArgs e)
        {
            string PatientID = ASPxGridView.GetDetailRowKeyValue(sender as Control).ToString();
            ASPxGridView gvPatient = ASPxGridView.FindParentGridTemplateContainer(sender as Control).Grid;
            string DoctorID = gvPatient.GetMasterRowKeyValue().ToString();
            string ClinicID = ASPxGridView.FindParentGridTemplateContainer(gvPatient).Grid.GetMasterRowKeyValue().ToString();
            dsReceipts.SelectParameters["PatientID"].DefaultValue = PatientID;
            dsReceipts.SelectParameters["DoctorID"].DefaultValue = DoctorID;
            dsReceipts.SelectParameters["ClinicID"].DefaultValue = ClinicID;
            dsReceipts.SelectParameters["From"].DefaultValue = txtDateFrom.Date.ToString();
            dsReceipts.SelectParameters["To"].DefaultValue = txtDateTo.Date.ToString();
            popupReceipts.AllowDragging = true;
            popupReceipts.AllowResize = true;
            popupReceipts.ResizingMode = DevExpress.Web.ASPxClasses.ResizingMode.Live;
            popupReceipts.ShowOnPageLoad = true;
        }

        protected void btnGet_Click(object sender, EventArgs e)
        {
            DataBind();
        }


     
    }
}