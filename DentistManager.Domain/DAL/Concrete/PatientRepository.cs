using System;
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
        public bool addNewPatinetBasicInfo(Entities.Patient patient)
        {
            int count=0;
            using(Entities.Entities ctx=new Entities.Entities ())
            {
                ctx.Patients.Add(patient);
                count=ctx.SaveChanges();
               int test= patient.PatientID;
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
           using(Entities.Entities ctx=new Entities.Entities ())
           {
               patient= ctx.Patients.Find(patientID);
           }
           return patient;
        }

        public bool deletepatientBasicInfo(int patientID)
        {
            int count = 0;
            using(Entities.Entities ctx =new Entities.Entities ())
            {
                Patient patient = ctx.Patients.Find(patientID);
                ctx.Patients.Remove(patient);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }


        public IEnumerable<PatientMiniData> getPatientList(int pageNumber, int pageSize)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                IEnumerable<PatientMiniData> patientList;
                var patients = ctx.Patients;
                patientList = (from p in patients
                               orderby p.Name 
                               select new PatientMiniData { PatientID = p.PatientID, Address = p.Address, Mobile = p.Mobile, Name = p.Name, Phone = p.Phone }).Skip(pageNumber * pageSize).Take(pageSize).ToList();
                return patientList;       
            }
        }


        public IEnumerable<PatientMiniData> getPatientListSearchResult(int patientID, string mobileNumber, string phoneNumber, string Name)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                IEnumerable<PatientMiniData> patientList;
                var patients = ctx.Patients;
                patientList = (from p in patients
                              where p.PatientID == patientID || p.Mobile == mobileNumber || p.Phone == phoneNumber || p.Name.Contains(Name)
                              orderby p.Name
                              select new PatientMiniData { PatientID = p.PatientID, Address = p.Address, Mobile = p.Mobile, Name = p.Name, Phone = p.Phone }).Take(20).ToList();

                return patientList;   
            }
        }
    }
}
