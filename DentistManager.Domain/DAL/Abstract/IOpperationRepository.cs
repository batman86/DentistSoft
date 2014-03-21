using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Abstract
{
    public interface IOpperationRepository
    {
        IEnumerable<opperationMiniDataViewModel> getOpperationList();

        IEnumerable<MaterialMiniPresentViewModel> getOpperationMatrailList(int opperationID);
    }
}
