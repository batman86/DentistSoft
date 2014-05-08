using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.Entities;

namespace DentistManager.Domain.DAL.Concrete
{
    public class CustomMatrialRepository : ICustomMatrialRepository 
    {
        public decimal? getPatientCusmotMatrialCostTotal(int patientID, int clinecID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                decimal? total = 0;

                total = ctx.CustomMaterials.Where(x => x.PatientID == patientID && x.ClinicID == clinecID).Select(x => x.Cost).Sum();
                return total;
            }
        }

        public decimal? getPatientCusmotMatrialCostTotal(int patientID, int clinecID, DateTime from, DateTime to)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                decimal? total = 0;

                total = ctx.CustomMaterials.Where(x => x.PatientID == patientID && x.ClinicID == clinecID && x.RequestDate >= from && x.RequestDate <= to).Select(x => x.Cost).Sum();
                return total;
            }
        }



        public bool addNewCustomMaterial(CustomMaterialViewModel customMaterialViewModel)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                CustomMaterial customMatrailEntity = ctx.CustomMaterials.Create();

                customMatrailEntity.DoctorID = customMaterialViewModel.DoctorID;
                customMatrailEntity.PatientID = customMaterialViewModel.PatientID;
                customMatrailEntity.RequestDate = customMaterialViewModel.RequestDate;
                customMatrailEntity.Name = customMaterialViewModel.Name;
                customMatrailEntity.Description = customMaterialViewModel.Description;
                customMatrailEntity.Cost = customMaterialViewModel.Cost;
                customMatrailEntity.ClinicID = customMaterialViewModel.clinecid;
                customMatrailEntity.Payed = false;

                ctx.CustomMaterials.Add(customMatrailEntity);
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public bool updateCustomMaterial(CustomMaterialViewModel customMaterialViewModel)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                CustomMaterial customMatrailEntity = ctx.CustomMaterials.Find(customMaterialViewModel.CustomMaterialID);

                customMatrailEntity.ReciveDate = customMaterialViewModel.ReciveDate;
                customMatrailEntity.Name = customMaterialViewModel.Name;
                customMatrailEntity.Description = customMaterialViewModel.Description;
                customMatrailEntity.Cost = customMaterialViewModel.Cost;
                customMatrailEntity.Payed = customMaterialViewModel.payed == 1 ? true : false;
                ctx.Entry(customMatrailEntity).State = System.Data.Entity.EntityState.Modified;
                count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public CustomMaterialPresentViewModel getCustomMaterialDetails(int customMaterialtID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var customMatrailIQ = ctx.CustomMaterials;
                var patientIQ= ctx.Patients;

                CustomMaterialPresentViewModel customMatrailViewModel = (from cm in customMatrailIQ
                                                                         join p in patientIQ on cm.PatientID equals p.PatientID
                                                                         where cm.CustomMaterialID == customMaterialtID
                                                                         select new CustomMaterialPresentViewModel { Cost = cm.Cost, CustomMaterialID = cm.CustomMaterialID, Description = cm.Description, Name = cm.Name, ReciveDate = cm.RequestDate, RequestDate = cm.RequestDate, patienName = p.Name , payed=cm.Payed}).FirstOrDefault();
                return customMatrailViewModel;
            }
        }

        public bool deleteCustomMaterial(int customMaterialtID)
        {
            int count = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
               CustomMaterial customMatrial= ctx.CustomMaterials.Find(customMaterialtID);
               if (customMatrial == null)
                   return false;

               ctx.CustomMaterials.Remove(customMatrial);
               count = ctx.SaveChanges();
            }
            return count > 0 ? true : false;
        }

        public IEnumerable<CustomMaterialPresentViewModel> getCustomMaterialList(int DoctorID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var customMatrailIQ = ctx.CustomMaterials;
                var patientIQ = ctx.Patients;

                IEnumerable<CustomMaterialPresentViewModel> customMatrailViewModel = (from cm in customMatrailIQ
                                                                         join p in patientIQ on cm.PatientID equals p.PatientID
                                                                         where cm.DoctorID == DoctorID && cm.Payed == false
                                                                         orderby cm.RequestDate descending
                                                                         select new CustomMaterialPresentViewModel { Cost = cm.Cost, CustomMaterialID = cm.CustomMaterialID, Description = cm.Description, Name = cm.Name, ReciveDate = cm.RequestDate, RequestDate = cm.RequestDate, patienName = p.Name }).ToList();
                return customMatrailViewModel;
            }
        }

        public IEnumerable<CustomMaterialPresentViewModel> getOldCustomMaterialList(int DoctorID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var customMatrailIQ = ctx.CustomMaterials;
                var patientIQ = ctx.Patients;

                IEnumerable<CustomMaterialPresentViewModel> customMatrailViewModel = (from cm in customMatrailIQ
                                                                                      join p in patientIQ on cm.PatientID equals p.PatientID
                                                                                      where cm.DoctorID == DoctorID && cm.Payed == true
                                                                                      orderby cm.RequestDate descending
                                                                                      select new CustomMaterialPresentViewModel { Cost = cm.Cost, CustomMaterialID = cm.CustomMaterialID, Description = cm.Description, Name = cm.Name, ReciveDate = cm.RequestDate, RequestDate = cm.RequestDate, patienName = p.Name }).ToList();
                return customMatrailViewModel;
            }
        }

        public IEnumerable<CustomMaterialPresentViewModel> getCustomMaterialList(int DoctorID, int patientID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var customMatrailIQ = ctx.CustomMaterials;
                var patientIQ = ctx.Patients;

                IEnumerable<CustomMaterialPresentViewModel> customMatrailViewModel = (from cm in customMatrailIQ
                                                                                      join p in patientIQ on cm.PatientID equals p.PatientID
                                                                                      where cm.DoctorID == DoctorID && cm.PatientID == patientID && cm.Payed == false
                                                                                      select new CustomMaterialPresentViewModel { Cost = cm.Cost, CustomMaterialID = cm.CustomMaterialID, Description = cm.Description, Name = cm.Name, ReciveDate = cm.RequestDate, RequestDate = cm.RequestDate, patienName = p.Name }).ToList();
                return customMatrailViewModel;
            }
        }

        public IEnumerable<CustomMaterialPresentViewModel> getOldCustomMaterialList(int DoctorID, int patientID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var customMatrailIQ = ctx.CustomMaterials;
                var patientIQ = ctx.Patients;

                IEnumerable<CustomMaterialPresentViewModel> customMatrailViewModel = (from cm in customMatrailIQ
                                                                                      join p in patientIQ on cm.PatientID equals p.PatientID
                                                                                      where cm.DoctorID == DoctorID && cm.PatientID == patientID && cm.Payed == true
                                                                                      select new CustomMaterialPresentViewModel { Cost = cm.Cost, CustomMaterialID = cm.CustomMaterialID, Description = cm.Description, Name = cm.Name, ReciveDate = cm.RequestDate, RequestDate = cm.RequestDate, patienName = p.Name }).ToList();
                return customMatrailViewModel;
            }
        }


        public decimal? getDoctorCustomMatrailCostTotalPayed(int clinecID, int doctorID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                decimal? total = 0;

                total = ctx.CustomMaterials.Where(x => x.DoctorID == doctorID && x.ClinicID == clinecID && x.Payed == true).Select(x => x.Cost).Sum();

                return total;
            }
        }

        public decimal? getDoctorCustomMatrailCostTotalUnPayed(int clinecID, int doctorID)
        {
            using (Entities.Entities ctx = new Entities.Entities())
            {
                decimal? total = 0;

                total = ctx.CustomMaterials.Where(x => x.DoctorID == doctorID && x.ClinicID == clinecID && x.Payed == false).Select(x => x.Cost).Sum();

                return total;
            }
        }
    }
}
