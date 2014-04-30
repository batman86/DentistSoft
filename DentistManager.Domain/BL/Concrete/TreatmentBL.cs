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
            MaterialRepository materialRepository = new MaterialRepository();
            IEnumerable<int> ClinecstorgeIDList = storgeRepository.getClinecStorgesList(clinecID);
            List<StorageMatrailViewModel> storageMatrailViewModelList;

            int storgeID =0;
            int total = 0;
            int oldQuantity = 0;
            int quantityToWisdraw = 0;

            foreach (MatrailToSaveViewModel item in matrailList)
            {
                storageMatrailViewModelList = storgeRepository.getStrogesMatrailsQuantity(ClinecstorgeIDList, item.MatrailID);
                if (storageMatrailViewModelList.Count < 1)
                    return false; // there is no stoge for this clinec

                // substract the old matrail in case he update the same matrail to avoid doblcate the delete form warehouse
                oldQuantity=materialRepository.getQuanityOfMatrailTreatment(item.MatrailID, treatmentID);
                quantityToWisdraw = item.Quantity - oldQuantity;


                // test if it's gonna return null
                storgeID = storageMatrailViewModelList.Where(x => x.Quantity > item.Quantity).Select(x => x.StorageID).FirstOrDefault();
                if (storgeID != 0)
                {
                    storgeRepository.withdrawMatrailFromWarehouse(item.MatrailID, storgeID, quantityToWisdraw);
                    continue;
                }

                total = storageMatrailViewModelList.Sum(x => x.Quantity);

                if (total >= quantityToWisdraw)
                {
                    foreach (StorageMatrailViewModel storge in storageMatrailViewModelList)
                    {
                        if(quantityToWisdraw >= storge.Quantity)
                        {
                            storgeRepository.withdrawMatrailFromWarehouse(item.MatrailID, storge.StorageID, storge.Quantity);
                            quantityToWisdraw -= storge.Quantity;
                        }
                        else
                        {
                            storgeRepository.withdrawMatrailFromWarehouse(item.MatrailID, storge.StorageID, quantityToWisdraw);
                            quantityToWisdraw =0;
                        }
                        if (quantityToWisdraw < 1)
                            break; // 
                    }

                }
                else 
                {
                    // if this run that mean it's will empty every warehouse and still not cover it
                    foreach (StorageMatrailViewModel storge in storageMatrailViewModelList)
                    {
                        storgeRepository.withdrawMatrailFromWarehouse(item.MatrailID, storge.StorageID, storge.Quantity);
                    }

                    // if we go this far this mean no enough matrail  retun false in this one
                    continue;
                }


            
            }

          bool check= materialRepository.SaveTreatmentMatrail(matrailList, treatmentID);

          return check;
        }
    }
}
