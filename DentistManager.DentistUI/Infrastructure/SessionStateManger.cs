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
            string probertyValue = null;

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

        public int getClinecIDForCurrentSecurtary(string userID)
        {

            return 1;
        }
        public int getClinecIDForCurrentDoctor(string userID)
        {

            return 1;
        }

        public void setSecyrtaryActivePatinet(string userID,int patientID)
        {
            sessionStateBL.setSessionProbertyValue(seassionNamesList.SecurtaryActivePatient.ToString(), userID, seassionProbertyNamesList.ActivePatientID.ToString(), patientID.ToString());
            HttpContext.Current.Session[seassionNamesList.SecurtaryActivePatient.ToString()] = patientID.ToString();
        }
    }

}