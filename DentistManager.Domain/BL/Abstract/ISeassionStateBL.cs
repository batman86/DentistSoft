using System.Collections.Generic;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.BL.Abstract
{
    public interface ISeassionStateBL
    {
        IEnumerable<SessionValuesViewModel> getSessionValueList(string sessionName, string userID);
        bool setSessionProbertyValue(string sessionName, string userID, string probertyName, string probertyValue);
    }
}
