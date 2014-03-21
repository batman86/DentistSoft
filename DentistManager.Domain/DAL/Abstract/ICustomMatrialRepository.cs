using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Abstract
{
    public interface ICustomMatrialRepository
    {
        decimal? getPatientCusmotMatrialCostTotal(int patientID, int clinecID);



        bool addNewCustomMaterial(CustomMaterialViewModel customMaterialViewModel);
        bool updateCustomMaterial(CustomMaterialViewModel customMaterialViewModel);
        CustomMaterialPresentViewModel getCustomMaterialDetails(int customMaterialtID);
        bool deleteCustomMaterial(int customMaterialtID);

        IEnumerable<CustomMaterialPresentViewModel> getCustomMaterialList(int DoctorID);
        IEnumerable<CustomMaterialPresentViewModel> getCustomMaterialList(int DoctorID, int patientID);
    }
}
