using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Abstract
{
    interface IstorgeRepository
    {
        IEnumerable<int> getClinecStorgesList(int clinecID);

        List<StorageMatrailViewModel> getStrogesMatrailsQuantity(IEnumerable<int> storagesIDList, int matrailID);


        bool withdrawMatrailFromWarehouse(int matrailID, int? storgeID, int quantity);
    }
}
