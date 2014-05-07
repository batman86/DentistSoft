using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Concrete
{
    public class DoctorRepository : IDoctorRepository
    {

        public IEnumerable<DoctorMiniInfoViewModel> getDoctorMiniInfoList()
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var DoctorsIQ = ctx.Doctors;
                IEnumerable<DoctorMiniInfoViewModel> DoctorList = (from d in DoctorsIQ
                                                                   select new DoctorMiniInfoViewModel { DoctorID = d.DoctorID, DoctorName = d.Name }).ToList();
                return DoctorList;
            }
        }
        public bool updateDoctorUserID(Entities.Doctor doctor)
        {
            int count;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var doc = ctx.Doctors.FirstOrDefault(d => d.DoctorID == doctor.DoctorID);
                doc.UserID = doctor.UserID;
                count = ctx.SaveChanges();

            }
            return count > 0 ? true : false;
        }


        public string getDoctorNameByID(int doctorID)
        {
            string Name;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Name = ctx.Doctors.Find(doctorID).Name;
            }
            return Name;
        }

        public string GetUserIDByDoctorID(int DoctorID)
        {
            string UserID = string.Empty;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var doc = ctx.Doctors.FirstOrDefault(d => d.DoctorID == DoctorID);
                UserID = doc.UserID;

            }
            return UserID;
        }


        public int getClinecIDByUserID(string UserID)
        {
            int ClinecID;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Doctor doctor = ctx.Doctors.Where(x => x.UserID == UserID).FirstOrDefault();
                if (doctor != null)
                    ClinecID = doctor.ClinicID;
                else
                    ClinecID = 0;
            }
            return ClinecID;
        }


        public int getDoctorIDByUserID(string UserID)
        {
            int DoctorID;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Doctor doctor = ctx.Doctors.Where(x => x.UserID == UserID).FirstOrDefault();
                if (doctor != null)
                    DoctorID = doctor.DoctorID;
                else
                    DoctorID = 0;
            }
            return DoctorID;
        }


        public int getDoctorIDByPatientID(int patientID)
        {
            int DoctorID =0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Patient patient = ctx.Patients.Where(x => x.PatientID == patientID).FirstOrDefault();

                if (patient != null)
                    DoctorID = patient.DoctorID ?? 0;
                else
                    DoctorID = 0;
            }
            return DoctorID;
        }

        public string getUserNameByUserID(string UserID)
        {
            string userName = string.Empty;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                userName = ctx.AspNetUsers.Where(u => u.Id == UserID).FirstOrDefault().UserName;
            }

            return userName;
        }

        
    }
}
