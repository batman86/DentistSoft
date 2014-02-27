using System.Collections.Generic;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.Entities;

namespace DentistManager.Domain.DAL.Abstract
{
    public interface ISessionState
    {
        int getSessionID(string SessionName, int userID);
        int addSessionAndGetID(string SessionName,int userID);
        IEnumerable<SessionValuesViewModel> getValuesBySessionID(int sessionID);
        SessionValue getSessionValue(int sessionID, string probertyName);
        bool alterSerssionProbertyValue(SessionValue sessionValue, string probertyValue);
        bool AddSessionProbertyValue(int sessionID, string probertyName, string probertyValue);
    }
}
