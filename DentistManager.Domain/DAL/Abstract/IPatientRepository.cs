using System;
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
        bool addNewPatinetBasicInfo(PatientFullDataViewModel patient);
        bool updatePatinetBasicInfo(Patient patient);
        Patient getPatinetBasicInfo(int patientID);
        PatientMiniData getPatinetMiniInfo(int patientID);
        bool deletepatientBasicInfo(int patientID);
        IEnumerable<PatientMiniData> getPatientList(int pageNumber, int pageSize,int clinectID);
        IEnumerable<PatientMiniData> getPatientListForDoctor(int pageNumber, int pageSize, int clinectID,int doctorID);
        IEnumerable<PatientMiniData> getPatientListForDoctor(int clinectID, int doctorID, DateTime From, DateTime to);
        int getPatientTotalForDoctor(int clinectID, int doctorID);
        int getPatientTotal(int clinectID);
        IEnumerable<PatientMiniData> getPatientListSearchResult(int patientID, string mobileNumber, string phoneNumber, string Name,int clinectID);
        int getPatientIDSearchResultByMobileOrID(int patientID, string mobileNumber);
        // in case user didn't select active patient i set first patint in clinec as the active patinet
        int getFirstPatientInClinec(int clinecID);
        string getPatientNameByID(int patientID);
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
        ImagesPresentViewModel getPatinetImagesDetails(int patinetImagestID);
        IEnumerable<ImagesPresentViewModel> getPatientImagesList(int patientID);
        bool checkIfImagePathExist(string imagePath);
    }
}
