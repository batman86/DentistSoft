using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
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
        public string GetUserIDBySecertaryID(int SecrtaryID)
        {
            string UserID = string.Empty;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                var sec = ctx.Secretaries.FirstOrDefault(s => s.SecretaryID == SecrtaryID);
                UserID = sec.UserID;

            }
            return UserID;
        }
        public int getClinecIDByUserID(string UserID)
        {
            // get the clinec id insted of secertyry id same for doctor
            int securtaryID;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                Secretary securtary = ctx.Secretaries.Where(x => x.UserID == UserID).FirstOrDefault();
                if (securtary != null)
                    securtaryID = securtary.SecretaryID;
                else
                    securtaryID = 0;
            }
            return securtaryID;
        }
    }
}
