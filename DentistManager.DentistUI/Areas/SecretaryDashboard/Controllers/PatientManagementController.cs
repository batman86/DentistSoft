using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.Entities;
using DentistManager.Domain.ViewModel;
using DentistManager.Domain.BL.Abstract;

namespace DentistManager.DentistUI.Areas.SecretaryDashboard.Controllers
{
    public class PatientManagementController : Controller
    {
        IPatientRepository patientRepository;

        public PatientManagementController(IPatientRepository _patientRepository)
        {
            patientRepository = _patientRepository;
        }
        //
        // GET: /SecretaryDashboard/PatientManagement/
        public ActionResult Index()
        {
            return View();
        }

        // GET: /SecretaryDashboard/PatientManagement/patientList
        public ActionResult patientList()
        {
            IEnumerable<PatientMiniData> patientList = patientRepository.getPatientList(0, 10);
            if (patientList == null)
                return HttpNotFound();
            return View(patientList);
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientDetails/5
        public ActionResult PatientDetails(int patientID)
        {
            Patient patient = patientRepository.getPatinetBasicInfo(patientID);
            if (patient == null)
                return HttpNotFound();
            return PartialView(patient);
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientCreate
        public ActionResult PatientCreate()
        {
            return View();
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientCreate
        [HttpPost]
        public ActionResult PatientCreate(Patient patient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   bool check= patientRepository.addNewPatinetBasicInfo(patient);
                }
                else
                {
                    return View();
                }

                return RedirectToAction("patientList");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientEdit/5
        public ActionResult PatientEdit(int patientID)
        {
            Patient patient = patientRepository.getPatinetBasicInfo(patientID);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientEdit/5
        [HttpPost]
        public ActionResult PatientEdit(Patient patient)
        {
            try
            {
               if(ModelState.IsValid)
               {
                  bool check = patientRepository.updatePatinetBasicInfo(patient);
               }
               else
               {
                   return View();
               }
               return RedirectToAction("patientList");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SecretaryDashboard/PatientManagement/PatientDelete/5
        public ActionResult PatientDelete(int patientID)
        {
            Patient patient= patientRepository.getPatinetBasicInfo(patientID);
            if (patient == null)
                return HttpNotFound();
            return View(patient);
        }

        //
        // POST: /SecretaryDashboard/PatientManagement/PatientDelete/5
        [HttpPost]
        [ActionName("PatientDelete")]
        public ActionResult ConfirmPatientDelete(int patientID)
        {
            try
            {
                bool check = patientRepository.deletepatientBasicInfo(patientID);
                return RedirectToAction("patientList");
            }
            catch
            {
                return View();
            }
        }
    }
}
