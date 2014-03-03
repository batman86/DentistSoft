using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;

namespace DentistManager.Domain.DAL.Concrete
{
    public class CustomMatrialRepository : ICustomMatrialRepository 
    {
        public decimal? getPatientCusmotMatrialCostTotal(int patientID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                decimal? total = 0;

                total = ctx.CustomMaterials.Where(x => x.PatientID == patientID).Select(x => x.Cost).Sum();
                return total;
            }
        }
    }
}
