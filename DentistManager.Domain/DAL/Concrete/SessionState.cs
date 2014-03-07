using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.DAL.Concrete
{
    public class SessionState : ISessionState
    {
        public int getSessionID(string SessionName, string userID)
        {
            int? sessionID;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                sessionID = ctx.SessionsStats.Where(x => x.SessionName == SessionName && x.UserID == userID).Select(x => x.SessionID).FirstOrDefault();
            }
            return sessionID ?? 0;
        }

        public int addSessionAndGetID(string SessionName, string userID)
        {
            int sessionID;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                SessionsStat sessionState = new SessionsStat {  SessionName= SessionName,UserID= userID };
                ctx.SessionsStats.Add(sessionState);
                ctx.SaveChanges();
                sessionID=sessionState.SessionID;
            }
            return sessionID;
        }

        public IEnumerable<SessionValuesViewModel> getValuesBySessionID(int sessionID)
        {
            IEnumerable<SessionValuesViewModel> sessionValues;
            using (Entities.Entities ctx = new Entities.Entities())
            {
               var sessionValuesIQ = ctx.SessionValues;
               sessionValues = (from sv in sessionValuesIQ
                                where sv.SessionID == sessionID
                                select new SessionValuesViewModel { propertyName = sv.PrortyName, sessionValue = sv.SessionValue1 }).ToList();
            }
            return sessionValues;
        }

        public SessionValue getSessionValue(int sessionID,  string probertyName)
        {
          using (Entities.Entities ctx = new Entities.Entities())
          {
              SessionValue sessionValue =  ctx.SessionValues.Where(x=>x.SessionID == sessionID && x.PrortyName == probertyName).FirstOrDefault();
              return sessionValue;
          }
        }

        public bool alterSerssionProbertyValue( SessionValue sessionValue ,string probertyValue)
        {
            int check = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                sessionValue.SessionValue1 = probertyValue;
                ctx.Entry(sessionValue).State = System.Data.Entity.EntityState.Modified;
                check = ctx.SaveChanges();
            }
            return check > 0 ? true : false;
        }

        public bool AddSessionProbertyValue(int sessionID,string probertyName,string probertyValue)
        {
            int check = 0;
            using (Entities.Entities ctx = new Entities.Entities())
            {
                SessionValue sv = new SessionValue { SessionID = sessionID, PrortyName = probertyName, SessionValue1 = probertyValue };
                ctx.SessionValues.Add(sv);
                check = ctx.SaveChanges();
            }
            return check > 0 ? true : false;
        }



    }
}
