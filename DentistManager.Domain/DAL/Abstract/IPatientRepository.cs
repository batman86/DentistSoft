﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Abstract
{
    public interface IPatientRepository
    {
        bool addNewPatinetBasicInfo(Patient patient);
        bool updatePatinetBasicInfo(Patient patient);
        Patient getPatinetBasicInfo(int patientID);
        bool deletepatientBasicInfo(int patientID);
        IEnumerable<PatientMiniData> getPatientList(int pageNumber, int pageSize);
        IEnumerable<PatientMiniData> getPatientListSearchResult(int patientID, string mobileNumber, string phoneNumber, string Name);
    }
}
