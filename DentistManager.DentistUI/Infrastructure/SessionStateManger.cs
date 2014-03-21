using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DentistManager.Domain.BL.Abstract;
using DentistManager.Domain.ViewModel;
using DentistManager.DentistUI.Infrastructure;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.DAL.Concrete;
using DentistManager.Domain.BL.Concrete;

namespace DentistManager.DentistUI.Infrastructure
{
    public class SessionStateManger :ISessionStateManger
    {
        //ISeassionStateBL sessionStateBL;
        //IPatientRepository patientRepository;
        //IDoctorRepository doctorRepository;
        //ISecertaryRepository secertaryRepository;
        //public SessionStateManger(ISeassionStateBL _sessionStateBL, IPatientRepository _patientRepository, IDoctorRepository _doctorRepository, ISecertaryRepository _secertaryRepository)
        //{
        //    sessionStateBL = _sessionStateBL;
        //    patientRepository = _patientRepository;
        //    doctorRepository = _doctorRepository;
        //    secertaryRepository = _secertaryRepository;
        //}

        public string getSecyrtaryActivePatinet(string userID)
        {
            string probertyValue = getSeassionValue(userID, seassionNamesList.SecurtaryActivePatient.ToString(), seassionProbertyNamesList.ActivePatientID.ToString());

            if (probertyValue == null)
            {
                PatientRepository patientRepository = new PatientRepository();
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


        public string getDoctorActivePatinet(string userID)
        {
            string probertyValue = getSeassionValue(userID, seassionNamesList.DoctorActivePatient.ToString(), seassionProbertyNamesList.ActivePatientID.ToString());

            if (probertyValue == null)
            {
                PatientRepository patientRepository = new PatientRepository();
                int patientID = patientRepository.getFirstPatientInClinec(getClinecIDForCurrentDoctor(userID));
                if (patientID != 0)
                {
                    setDoctorActivePatinet(userID, patientID);
                    probertyValue = patientID.ToString();
                }
            }
            // if probertyValue still == null this mean no patients in the database for this clinec
            return probertyValue;
        }
        public void setDoctorActivePatinet(string userID, int patientID)
        {
            setSeassionValue(userID, seassionNamesList.DoctorActivePatient.ToString(), seassionProbertyNamesList.ActivePatientID.ToString(), patientID.ToString());
        }




        public int getClinecIDForCurrentSecurtary(string userID)
        {
            string clinecID = getSeassionValue(userID, seassionNamesList.SecurtaryActiveClinec.ToString(), seassionProbertyNamesList.ActiveClinecID.ToString());
            if (clinecID == null)
            {
                SecertaryRepository secertaryRepository = new SecertaryRepository();
                int clinecIDholder = secertaryRepository.getClinecIDByUserID(userID);
                clinecID = clinecIDholder.ToString();
                setSeassionValue(userID, seassionNamesList.SecurtaryActiveClinec.ToString(), seassionProbertyNamesList.ActiveClinecID.ToString(), clinecID);
            }
            return int.Parse(clinecID);

        }

        public int getClinecIDForCurrentDoctor(string userID)
        {

            string clinecID = getSeassionValue(userID, seassionNamesList.DoctorActiveClinec.ToString(), seassionProbertyNamesList.ActiveClinecID.ToString());
            if (clinecID == null)
            {
                DoctorRepository doctorRepository = new DoctorRepository();
                int clinecIDholder = doctorRepository.getClinecIDByUserID(userID);
                clinecID = clinecIDholder.ToString();
                setSeassionValue(userID, seassionNamesList.DoctorActiveClinec.ToString(), seassionProbertyNamesList.ActiveClinecID.ToString(), clinecID);
            }
            return int.Parse(clinecID);
        }



        public void setSeassionValue(string userID, string seassionName, string probertyName, string probertyValue)
        {
            SeassionStateBL sessionStateBL = new SeassionStateBL();
            sessionStateBL.setSessionProbertyValue(seassionName, userID, probertyName, probertyValue);
            HttpContext.Current.Session[seassionName] = probertyValue;
        }

        public string getSeassionValue(string userID, string seassionName, string probertyName)
        {
            string probertyValue = null;

            var sessionHolder = HttpContext.Current.Session[seassionName];
            if (sessionHolder == null)
            {
                SeassionStateBL sessionStateBL = new SeassionStateBL();
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


        public string getDoctorCustomMatrailFilter(string userID)
        {
            string FilterType = getSeassionValue(userID, seassionNamesList.DoctorCustomMatrailFilterParamter.ToString(), seassionProbertyNamesList.FilterType.ToString());
            if (FilterType == null)
            {
                FilterType = "1";
                setSeassionValue(userID, seassionNamesList.DoctorCustomMatrailFilterParamter.ToString(), seassionProbertyNamesList.FilterType.ToString(), FilterType);
            }
            return FilterType;
        }

        public void setDoctorCustomMatrailFilter(string userID, string FilterType)
        {
            setSeassionValue(userID, seassionNamesList.DoctorCustomMatrailFilterParamter.ToString(), seassionProbertyNamesList.FilterType.ToString(), FilterType);
        }
    }

}