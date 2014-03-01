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
        PatientMiniData getPatinetMiniInfo(int patientID);
        bool deletepatientBasicInfo(int patientID);
        IEnumerable<PatientMiniData> getPatientList(int pageNumber, int pageSize);
        IEnumerable<PatientMiniData> getPatientListSearchResult(int patientID, string mobileNumber, string phoneNumber, string Name);


        //patient History
        bool addNewPatinetHistory(PatientHistoryViewModel patientHistory);
        bool updatePatinetHistory(PatientHistoryViewModel patientHistory);
        PatientHistoryViewModel getPatinetHistoryDetails(int patientHistorytID);
        bool deletePatientHistory(int patientHistorytID);
        IEnumerable<PatientHistoryViewModel> getPatientHistoryList(int patientID);


        //patient Images
        bool addNewPatinetImages(ImagesViewModel patinetImages);
        bool deletePatientImages(int patinetImagestID);
        bool updatePatinetImage(ImagesViewModel patientImagesViewModel);
        ImagesViewModel getPatinetImagesDetails(int patinetImagestID);
        IEnumerable<ImagesViewModel> getPatientImagesList(int patientID);
        bool checkIfImagePathExist(string imagePath);
    }
}
