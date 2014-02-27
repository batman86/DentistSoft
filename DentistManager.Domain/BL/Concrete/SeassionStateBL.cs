using System.Collections.Generic;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.Domain.Entities;

namespace DentistManager.Domain.BL.Concrete
{
    public class SeassionStateBL :ISeassionStateBL
    {
        public IEnumerable<SessionValuesViewModel> getSessionValueList(string sessionName, string userID)
        {
            SessionState sessionStateDAL = new SessionState();
        
            return  sessionStateDAL.getValuesBySessionID( getSessionID(sessionName, userID));
        }

        public int getSessionID(string sessionName, string userID)
        {
            SessionState sessionStateDAL = new SessionState();

            int sessionID = sessionStateDAL.getSessionID(sessionName, userID);
            if (sessionID == 0)
                sessionID = sessionStateDAL.addSessionAndGetID(sessionName, userID);

            return sessionID;
        }


        public bool setSessionProbertyValue(string sessionName, string userID, string probertyName, string probertyValue)
        {
            SessionState sessionStateDAL = new SessionState();
            bool check = false;

            int sessionID = sessionStateDAL.getSessionID(sessionName, userID);

            SessionValue sessionValue = sessionStateDAL.getSessionValue(sessionID, probertyName);

            if (sessionValue == null)
                check = sessionStateDAL.AddSessionProbertyValue(sessionID, probertyName, probertyValue);
            else
                check = sessionStateDAL.alterSerssionProbertyValue(sessionValue, probertyValue);

            return check;
        }
    }
}
