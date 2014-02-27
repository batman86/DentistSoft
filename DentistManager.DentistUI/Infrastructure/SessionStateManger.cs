using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.ViewModel;
using DentistManager.DentistUI.Infrastructure;
namespace DentistManager.DentistUI.Infrastructure
{
    public class SessionStateManger
    {
        ISeassionStateBL sessionStateBL;
        public SessionStateManger(ISeassionStateBL _sessionStateBL)
        {
            sessionStateBL = _sessionStateBL;

        }

        public string getSecyrtaryActivePatinet(string userID)
       {
            string probertyValue=string.Empty;

            var sessionHolder = HttpContext.Current.Session[seassionNamesList.SecurtaryActivePatient.ToString()];
            if (sessionHolder == null)
            {
                IEnumerable<SessionValuesViewModel> sessionValuesList = sessionStateBL.getSessionValueList(seassionNamesList.SecurtaryActivePatient.ToString(), userID);
                if (sessionValuesList != null)
                {
                    foreach (var item in sessionValuesList)
                    {
                        if (item.propertyName == seassionProbertyNamesList.ActivePatientID.ToString())
                        {
                            probertyValue = item.sessionValue;
                            break;
                        }
                    }
                    HttpContext.Current.Session[seassionNamesList.SecurtaryActivePatient.ToString()] = probertyValue;
                }
            }
            else
            {
                probertyValue = sessionHolder.ToString();
            }
            return probertyValue;
        }

    }
}