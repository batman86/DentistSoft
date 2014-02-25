using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.Entities;
namespace DentistManager.Domain.DAL.Abstract
{
    public interface IPatientRepository
    {
        bool addNewPatinetBasicInfo(Patient patient);
        bool updatePatinetBasicInfo(Patient patient);
        Patient getPatinetBasicInfo(int patientID);
        bool deletepatientBasicInfo(int patientID);


    }
}
