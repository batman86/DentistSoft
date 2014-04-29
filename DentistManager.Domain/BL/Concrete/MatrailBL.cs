using DentistManager.Domain.BL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.Domain.Entities;

namespace DentistManager.Domain.BL.Concrete
{
    public class MatrailBL : IMatrailBL
    {



        public bool RemoveMatrailofTreatment(int clinecID,int matrailID = 0, int treatmentID = 0)
        {
            bool check ;

            MaterialRepository materialRepository = new MaterialRepository();
            int quantity = materialRepository.getQuanityOfMatrailTreatment(matrailID, treatmentID);
            int storgeID=0;

            StorgeRepository storgeRepository = new StorgeRepository();
            IEnumerable<int> storgeList= storgeRepository.getClinecStorgesList(clinecID);

            if (storgeList.Count() > 0)
            {
                storgeID = storgeList.First();

                Warehouse warehouse = new Warehouse() { ItemID = matrailID, StorageID = storgeID };
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse Getwarehouse = warehouseRepository.Getwarehouse(warehouse);

                Getwarehouse.Available += quantity;
                warehouseRepository.UpdateWarehouse(Getwarehouse);
            }
            check = materialRepository.removeTreatmentMatrail(matrailID, treatmentID);

            return check;
        }
    }
}
