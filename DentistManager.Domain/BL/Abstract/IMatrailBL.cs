using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.BL.Abstract
{
    public interface IMatrailBL
    {

        bool RemoveMatrailofTreatment(int clinecID ,int matrailID = 0, int treatmentID = 0);


    }
}
