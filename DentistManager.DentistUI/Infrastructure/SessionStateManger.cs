using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.ViewModel;
using DentistManager.DentistUI.Infrastructure;
using DentistManager.Domain.DAL.Abstract;

namespace DentistManager.DentistUI.Infrastructure
{
    public class SessionStateManger :ISessionStateManger
    {
        ISeassionStateBL sessionStateBL;
        IPatientRepository patientRepository;
        public SessionStateManger(ISeassionStateBL _sessionStateBL, IPatientRepository _patientRepository)
        {
            sessionStateBL = _sessionStateBL;
            patientRepository = _patientRepository;
        }

        public string getSecyrtaryActivePatinet(string userID)
        {
            string probertyValue = getSeassionValue(userID, seassionNamesList.SecurtaryActivePatient.ToString(), seassionProbertyNamesList.ActivePatientID.ToString());

            if (probertyValue == null)
            {
                int patientID = patientRepository.getFirstPatientInClinec(getClinecIDForCurrentSecurtary(userID));
                if (patientID != 0)
                {
                   setSecyrtaryActivePatinet(userID, patientID);
                   probertyValue = patientID.ToString();
                }
            }
            // if probertyValue still == null this mean no patients in the database for this clinec
            return probertyValue;
        }

        public void setSecyrtaryActivePatinet(string userID, int patientID)
        {
            setSeassionValue(userID, seassionNamesList.SecurtaryActivePatient.ToString(), seassionProbertyNamesList.ActivePatientID.ToString(), patientID.ToString());
        }

        public int getClinecIDForCurrentSecurtary(string userID)
        {

            return 1;
        }
        public int getClinecIDForCurrentDoctor(string userID)
        {

            return 1;
        }



        public void setSeassionValue(string userID, string seassionName, string probertyName,string probertyValue)
        {
            sessionStateBL.setSessionProbertyValue(seassionName, userID, probertyName, probertyValue);
            HttpContext.Current.Session[seassionName] = probertyValue;
        }

        public string getSeassionValue(string userID,string seassionName, string probertyName)
        {
            string probertyValue = null;

            var sessionHolder = HttpContext.Current.Session[seassionName];
            if (sessionHolder == null)
            {
                IEnumerable<SessionValuesViewModel> sessionValuesList = sessionStateBL.getSessionValueList(seassionName, userID);
                if (sessionValuesList != null)
                {
                    foreach (var item in sessionValuesList)
                    {
                        if (item.propertyName == probertyName)
                        {
                            probertyValue = item.sessionValue;
                            break;
                        }
                    }
                    HttpContext.Current.Session[seassionName] = probertyValue;
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