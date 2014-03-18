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
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PaymentRepository re = new PaymentRepository();
            re.GetAllCostTreatmentByClinic(1);
        }

        protected void gvxPaymentClinics_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "Total Required")
            {
                PaymentRepository paymentRepository = new PaymentRepository();
                e.Value = paymentRepository.GetAllCostTreatmentByClinic(int.Parse(e.GetListSourceFieldValue("ClinicID").ToString()));

            }
            else if (e.Column.FieldName == "Total Payed")
            {
                PaymentRepository paymentRepository = new PaymentRepository();
                e.Value = paymentRepository.GetAllPayedReceitsByClinic(int.Parse(e.GetListSourceFieldValue("ClinicID").ToString()));

            }
            else if (e.Column.FieldName =="Total Deserved")
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
             e.Value = paymentRepository.GetAllTeratmentByDoctor(int.Parse(e.GetListSourceFieldValue("DoctorID").ToString()),clinicID);

         }
        }

        protected void gvxDoctor_BeforePerformDataSelect(object sender, EventArgs e)
        {
            dsDoctors.SelectParameters["ClinicID"].DefaultValue = (sender as ASPxGridView).GetMasterRowKeyValue().ToString();
        }

       
    }
}