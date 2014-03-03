using DentistManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Abstract
{
    public interface ITreatmentRepository 
    {
          IEnumerable<Treatment> getPatientTreatmentList(int patientID);
    }
}
