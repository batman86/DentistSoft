using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.ViewModel
{
    public class DoctorPatientBillInfoWrap
    {
        public PatientBillInfoWrap TotalPatientPaymentInfo { get; set; }
        public IEnumerable<PatientBillInfoWrap> patientPaymentInfoList { get; set; }
    }
}
