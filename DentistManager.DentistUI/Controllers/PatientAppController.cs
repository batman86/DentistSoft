using DentistManager.Domain.DAL.Concrete;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DentistManager.DentistUI.Controllers
{
    public class PatientAppController : ApiController
    {

        // GET /api/PatientApp/Get
        public IEnumerable<patientAppoInfo> Get(string patientid, string mobile)
        {
            try
            {
                if (patientid == null)
                    return null;
                if (mobile == null)
                    return null;
                int id = 0;
                if (!int.TryParse(patientid, out id))
                    return null;

                AppointmentRepository app = new AppointmentRepository();
                IEnumerable<patientAppoInfo> patientAppoInfoList = app.getPatientAppountmenInfo(id, mobile);

                return patientAppoInfoList;
            }
            catch
            {
                
                return null;
            }

        }
   
    }
}