using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.DAL.Concrete;

namespace DentistManager.Domain.BL.Concrete
{
    public class TreatmentBL :ITreatmentBL
    {
        public bool saveTreatment(IEnumerable<TreatmentPresntViewModel> treatmentList, int AppointmentID, int DoctorID, int PatientID,int clinecID)
        {
            bool check = false;
            IEnumerable<TreatmentPresntViewModel> treatmentListToAdd = treatmentList.Where(x => x.TeratmentID == 0);
            IEnumerable<TreatmentPresntViewModel> treatmentListToupdate = treatmentList.Where(x => x.TeratmentID != 0);

            TreatmentRepository tr = new TreatmentRepository();

            tr.updateTreatmentList(treatmentListToupdate);
            tr.addTreatmentList(treatmentListToAdd, AppointmentID, DoctorID, PatientID, clinecID);

            return check;
        }


        public bool SaveMatrailOfTreatment(IEnumerable<MatrailToSaveViewModel> matrailList, int treatmentID, int clinecID)
        {
            // substract form the warehouse
            StorgeRepository storgeRepository = new StorgeRepository();
            IEnumerable<int> ClinecstorgeIDList = storgeRepository.getClinecStorgesList(clinecID);
            List<StorageMatrailViewModel> storageMatrailViewModelList;
            int? storgeID =0;
            int total = 0;
            foreach (MatrailToSaveViewModel item in matrailList)
            {
                storageMatrailViewModelList = storgeRepository.getStrogesMatrailsQuantity(ClinecstorgeIDList, item.MatrailID);

                if (storageMatrailViewModelList.Count < 1)
                    return false; // there is no stoge for this clinec
                   
                
                // test if it's gonna return null
              //  storgeID = storageMatrailViewModelList.Where(x => x.Quantity > item.Quantity).Select(x => x.StorageID).First();
                var  aa= storageMatrailViewModelList.Where(x => x.Quantity > item.Quantity);
                if (storgeID != null)
                {
                    storgeRepository.withdrawMatrailFromWarehouse(item.MatrailID, storgeID, item.Quantity);
                    break;
                }

                total = storageMatrailViewModelList.Sum(x => x.Quantity);

                if (total >= item.Quantity)
                {
                    foreach (StorageMatrailViewModel storge in storageMatrailViewModelList)
                    {
                        item.Quantity -= storge.Quantity;
                        storgeRepository.withdrawMatrailFromWarehouse(item.MatrailID, storge.StorageID, storge.Quantity);

                        if (item.Quantity < 1)
                            break; // 
                    }

                }

                // if we go this far this mean no enough matrail  retun false in this one
                return false;
            }


            MaterialRepository materialRepository =new MaterialRepository ();
            materialRepository.SaveTreatmentMatrail(matrailList, treatmentID);


            // return
            return false;
        }
    }
}
