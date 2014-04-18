using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Abstract
{
    interface ISecertaryRepository
    {
        bool updateSecertaryUserID(Entities.Secretary secretary);
        int getClinecIDByUserID(string UserID);
      
    }
}
