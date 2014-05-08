using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using DentistManager.DentistUI.Infrastructure;
using DentistManager.Domain.DAL.Abstract;
using DentistManager.Domain.ViewModel;

namespace DentistManager.DentistUI.Areas.DoctorDashboard.Controllers
{
    //[Authorize(Roles = "Doctor")]
    public class PatientPaymentReceiptController : Controller
    {
        //
        // GET: /DoctorDashboard/PatientPaymentReceipt/

        ISessionStateManger sessionStateManger;
        IPaymentReceiptRerpository paymentReceiptRerpository;
        IDoctorRepository doctorRepository;
        public PatientPaymentReceiptController(ISessionStateManger _sessionStateManger, IPaymentReceiptRerpository _paymentReceiptRerpository, IDoctorRepository _doctorRepository)
        {
            sessionStateManger = _sessionStateManger;
            paymentReceiptRerpository = _paymentReceiptRerpository;
            doctorRepository = _doctorRepository;
        }


        [NonAction]
        public int getDoctorIDbyPatientID(int patientID=0)
        {
            return doctorRepository.getDoctorIDByPatientID(patientID);
        }


        [NonAction]
        public int getCurrentPatientID()
        {
            return int.Parse(sessionStateManger.getDoctorActivePatinet(User.Identity.GetUserId()));
        }

        [NonAction]
        public int getClinecIDForCurrentUser()
        {
            return sessionStateManger.getClinecIDForCurrentDoctor(User.Identity.GetUserId());
        }

        public ActionResult patientReceiptList(int patientID = 0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            int clinecID = getClinecIDForCurrentUser();

            IEnumerable<PaymentReceiptPresentViewModel> patientReceiptList = paymentReceiptRerpository.getPatientReceiptList(patientID, clinecID);
            if (patientReceiptList == null)
                return HttpNotFound();

            return View(patientReceiptList);
        }

        public ActionResult patientReceiptDetails(int receiptID=0)
        {
            if(receiptID ==0)
                return HttpNotFound();

            PaymentReceiptPresentViewModel receipt = paymentReceiptRerpository.getPaymentReceiptDetails(receiptID);
            if (receipt == null)
                return HttpNotFound();
            return View(receipt);
        }


        public ActionResult patientReceiptCreate(int patientID = 0)
        {
            if (patientID == 0)
                patientID = getCurrentPatientID();

            ViewBag.patientID = patientID;
            return View();
        }


        [HttpPost]
        public ActionResult patientReceiptCreate(PaymentReceiptViewModel paymentReceiptViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int patientID = getCurrentPatientID();
                    
                    paymentReceiptViewModel.ClinicID = getClinecIDForCurrentUser();
                    paymentReceiptViewModel.Date = DateTime.Now;
                    paymentReceiptViewModel.UserID = User.Identity.GetUserId();
                    paymentReceiptViewModel.PatientID = patientID;
                    paymentReceiptViewModel.doctorID = getDoctorIDbyPatientID(patientID);

                    bool check = paymentReceiptRerpository.addNewPatientReceipt(paymentReceiptViewModel);
                }
                else
                {
                    return View();
                }

                return RedirectToAction("patientReceiptList");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult patientReceiptDelete(int receiptID=0)
        {
            PaymentReceiptPresentViewModel receipt = paymentReceiptRerpository.getPaymentReceiptDetails(receiptID);
            if (receipt == null)
                return HttpNotFound();
            return View(receipt);
        }

        [HttpPost]
        [ActionName("patientReceiptDelete")]
        public ActionResult ConfirmpatientReceiptDelete(int receiptID)
        {
            try
            {
                bool check = paymentReceiptRerpository.deletePatientReceipt(receiptID);
                return RedirectToAction("patientReceiptList");
            }
            catch
            {
                return View();
            }
        }
	}
}