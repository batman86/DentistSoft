using System.Collections.Generic;
using DentistManager.Domain.ViewModel;

namespace DentistManager.Domain.BL.Abstract
{
    public interface ISeassionStateBL
    {
        IEnumerable<SessionValuesViewModel> getSessionValueList(string sessionName ,int userID);
        bool setSessionProbertyValue(string sessionName, int userID,string probertyName ,string probertyValue);
    }
}
