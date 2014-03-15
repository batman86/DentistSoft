﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Concrete
{
    public class PatientRepository : IPatientRepository
    {
        public bool addNewPatinetBasicInfo(PatientFullDataViewModel patientViewModel)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Patient patientEntity = ctx.Patients.Create();
                patientEntity.ClinicID = patientViewModel.ClinicID;
                patientEntity.Name = patientViewModel.Name;
                patientEntity.Mobile = patientViewModel.Mobile;
                patientEntity.Phone = patientViewModel.Phone;
                patientEntity.E_mail = patientViewModel.E_mail;
                patientEntity.gender = patientViewModel.gender;
                patientEntity.Notice = patientViewModel.Notice;
                patientEntity.BrithDate = patientViewModel.BrithDate;
                patientEntity.Age = patientViewModel.Age;

                ctx.Patients.Add(patientEntity);
                count = ctx.SaveChanges();
                int test = patientEntity.PatientID;
            }
            return count > 0 ? true : false;
        }

        public bool updatePatinetBasicInfo(Entities.Patient patient)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                ctx.Entry(patient).State = System.Data.Entity.EntityState.Modified;
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public Patient getPatinetBasicInfo(int patientID)
        {
            Patient patient;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                patient = ctx.Patients.Find(patientID);
            }
            return patient;
        }

        public bool deletepatientBasicInfo(int patientID)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Patient patient = ctx.Patients.Find(patientID);
                if (patient != null)
                {
                    ctx.Patients.Remove(patient);
                    count = ctx.SaveChanges();
                }
            }
            return count > 0 ? true : false;
        }


        public IEnumerable<PatientMiniData> getPatientList(int pageNumber, int pageSize, int clinectID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                IEnumerable<PatientMiniData> patientList;
                var patients = ctx.Patients;
                patientList = (from p in patients
                               where p.ClinicID == clinectID
                               orderby p.Name
                               select new PatientMiniData { PatientID = p.PatientID, Address = p.Address, Mobile = p.Mobile, Name = p.Name, Phone = p.Phone }).Skip(pageNumber * pageSize).Take(pageSize).ToList();
                return patientList;
            }
        }


        public IEnumerable<PatientMiniData> getPatientListSearchResult(int patientID, string mobileNumber, string phoneNumber, string Name, int clinectID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                IEnumerable<PatientMiniData> patientList;
                var patients = ctx.Patients;
                patientList = (from p in patients
                               orderby p.Name
                               where  p.PatientID == patientID || p.Mobile == mobileNumber || p.Phone == phoneNumber && p.ClinicID == clinectID
                               select new PatientMiniData { PatientID = p.PatientID, Address = p.Address, Mobile = p.Mobile, Name = p.Name, Phone = p.Phone }).Take(20).ToList();

                if(patientList.Count()==0 && Name!=string.Empty)
                {
                    patientList = (from p in patients
                                   orderby p.Name
                                   where p.Name.Contains(Name) 
                                   select new PatientMiniData { PatientID = p.PatientID, Address = p.Address, Mobile = p.Mobile, Name = p.Name, Phone = p.Phone }).Take(20).ToList();

                }
                return patientList;
            }
        }

        // if the patient id is not exist return first patient
        public PatientMiniData getPatinetMiniInfo(int patientID)
        {
            PatientMiniData patientMini = null;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Patient patient = ctx.Patients.Find(patientID);
                if (patient == null)
                    patient = ctx.Patients.FirstOrDefault();

                if (patient != null)
                    patientMini = new PatientMiniData { PatientID = patient.PatientID, Name = patient.Name, Phone = patient.Phone, Mobile = patient.Mobile, Address = patient.Address };
                //var patientIQ = ctx.Patients;
                //patient = (from p in patientIQ
                //           where p.PatientID == patientID
                //           select new PatientMiniData { PatientID = p.PatientID, Name = p.Name, Mobile = p.Mobile, Phone = p.Phone, Address = p.Address }).;

            }
            return patientMini;
        }


        public bool addNewPatinetHistory(PatientHistoryViewModel patientHistory)
        {
            int count = 0;

            using (Entities.Entities ctx = new Entities.Entities())
            {
                PatientHistory patientHistoryEntity = ctx.PatientHistories.Create();
                patientHistoryEntity.PatientID = patientHistory.PatientID;
                patientHistoryEntity.Name = patientHistory.Name;
                patientHistoryEntity.Descripation = patientHistory.Descripation;

                ctx.PatientHistories.Add(patientHistoryEntity);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public bool updatePatinetHistory(PatientHistoryViewModel patientHistory)
        {
            int count = 0;


            using (Entities.Entities ctx = new Entities.Entities())
            {
                PatientHistory patientHistoryEntity = ctx.PatientHistories.Find(patientHistory.HistoryID);
                if (patientHistoryEntity == null)
                    return false;

                patientHistoryEntity.Name = patientHistory.Name;
                patientHistoryEntity.Descripation = patientHistory.Descripation;

                ctx.Entry(patientHistoryEntity).State = System.Data.Entity.EntityState.Modified;
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public PatientHistoryViewModel getPatinetHistoryDetails(int patientHistorytID)
        {
            PatientHistoryViewModel patientHistoryViewModel;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                PatientHistory patientHistoryEntity = ctx.PatientHistories.Find(patientHistorytID);
                if (patientHistoryEntity != null)
                {
                    patientHistoryViewModel = new PatientHistoryViewModel
                    {
                        HistoryID = patientHistoryEntity.HistoryID,
                        Name = patientHistoryEntity.Name,
                        Descripation = patientHistoryEntity.Descripation,
                        PatientID = patientHistoryEntity.PatientID
                    };
                }
                else
                    patientHistoryViewModel = null;
            }
            return patientHistoryViewModel;
        }

        public bool deletePatientHistory(int patientHistorytID)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                PatientHistory patientHistory = ctx.PatientHistories.Find(patientHistorytID);
                if (patientHistory != null)
                {
                    ctx.PatientHistories.Remove(patientHistory);
                    count = ctx.SaveChanges();
                }
            }
            return count > 0 ? true : false;
        }

        public IEnumerable<PatientHistoryViewModel> getPatientHistoryList(int patientID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                IEnumerable<PatientHistoryViewModel> patienthistoryList;

                var patienthistoris = ctx.PatientHistories;

                patienthistoryList = (from ph in patienthistoris
                                      where ph.PatientID == patientID
                                      select new PatientHistoryViewModel { PatientID = ph.PatientID, Name = ph.Name, Descripation = ph.Descripation, HistoryID = ph.HistoryID }).ToList();

                return patienthistoryList;
            }
        }

        //****************************************
        public bool addNewPatinetImages(ImagesViewModel patientImages)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Image patientimageEntity = ctx.Images.Create();

                patientimageEntity.Name = patientImages.Name;
                patientimageEntity.Notice = patientImages.Notice;
                patientimageEntity.ImageCategoryID = patientImages.ImageCategoryID;
                patientimageEntity.appointmentID = patientImages.appointmentID;
                patientimageEntity.PatientID = patientImages.PatientID;
                patientimageEntity.MinImageURL = patientImages.MinImageURL;
                patientimageEntity.MediumImageURL = patientImages.MediumImageURL;
                patientimageEntity.FullImageURL = patientImages.FullImageURL;
                patientimageEntity.LocalImageURL = patientImages.LocalImageURL;

                ctx.Images.Add(patientimageEntity);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public ImagesViewModel getPatinetImagesDetails(int patinetImagestID)
        {
            ImagesViewModel imagesViewModel;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Image imageEntity = ctx.Images.Find(patinetImagestID);
                if (imageEntity != null)
                {
                    imagesViewModel = new ImagesViewModel
                    {
                        Name = imageEntity.Name,
                        Notice = imageEntity.Notice,
                        ImageCategoryID = imageEntity.ImageCategoryID,
                        appointmentID = imageEntity.appointmentID,
                        PatientID = imageEntity.PatientID,
                        MinImageURL = imageEntity.MinImageURL,
                        MediumImageURL = imageEntity.MediumImageURL,
                        FullImageURL = imageEntity.FullImageURL,
                        LocalImageURL = imageEntity.LocalImageURL
                    };
                }
                else
                    imagesViewModel = null;
            }
            return imagesViewModel;
        }

        public bool deletePatientImages(int patinetImagestID)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Image image = ctx.Images.Find(patinetImagestID);
                if (image != null)
                {
                    ctx.Images.Remove(image);
                    count = ctx.SaveChanges();
                }
            }
            return count > 0 ? true : false;
        }

        public IEnumerable<ImagesViewModel> getPatientImagesList(int patientID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                IEnumerable<ImagesViewModel> patientImagesList;
                var patientsImages = ctx.Images;
                patientImagesList = (from i in patientsImages
                                     orderby i.PatientID == patientID
                                     select new ImagesViewModel { Name = i.Name, Notice = i.Notice, ImageID = i.ImageID, MinImageURL = i.MinImageURL, MediumImageURL = i.MediumImageURL, FullImageURL = i.FullImageURL, LocalImageURL = i.LocalImageURL, ImageCategoryID = i.ImageCategoryID, appointmentID = i.appointmentID, PatientID = i.PatientID }).ToList();
                return patientImagesList;
            }
        }


        public bool checkIfImagePathExist(string imagePath)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                count = ctx.Images.Where(x => x.FullImageURL == imagePath).Count();
            }
            return count > 0 ? true : false;
        }


        public bool updatePatinetImage(ImagesViewModel patientImagesViewModel)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Image patientImageEntity = ctx.Images.Find(patientImagesViewModel.ImageID);
                if (patientImageEntity == null)
                    return false;

                patientImageEntity.Name = patientImagesViewModel.Name;
                patientImageEntity.Notice = patientImagesViewModel.Notice;
                patientImageEntity.ImageCategoryID = patientImagesViewModel.ImageCategoryID;

                ctx.Entry(patientImageEntity).State = System.Data.Entity.EntityState.Modified;
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }


        public int getFirstPatientInClinec(int clinecID)
        {
            int patientID = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Patient patient = ctx.Patients.Where(x => x.ClinicID == clinecID).FirstOrDefault();
                if (patient != null)
                    patientID = patient.PatientID;
            }
            return patientID;
        }


        public int getPatientIDSearchResultByMobileOrID(int patientID, string mobileNumber)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                PatientMiniData patient;
                var patients = ctx.Patients;
                patient = (from p in patients
                           where p.PatientID == patientID || p.Mobile == mobileNumber
                           orderby p.Name
                           select new PatientMiniData { PatientID = p.PatientID, Address = p.Address, Mobile = p.Mobile, Name = p.Name, Phone = p.Phone }).FirstOrDefault();

                return patient == null ? 0 : patient.PatientID;
            }
        }

        public string getPatientNameByID(int patientID)
        {
            string Name ;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Name=ctx.Patients.Find(patientID).Name;
            }
            return Name;
        }
    }
}
