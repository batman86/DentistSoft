using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentistManager.Domain.DAL.Concrete
{
    public class SecertaryRepository
    {
        public bool updateSecertaryUserID(Entities.Secretary secretary)
        {
            int count;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var sec = ctx.Secretaries.FirstOrDefault(d => d.SecretaryID == secretary.SecretaryID);
                sec.UserID = secretary.UserID;
                count = ctx.SaveChanges();

            }
            return count > 0 ? true : false;
        }
    }
}
