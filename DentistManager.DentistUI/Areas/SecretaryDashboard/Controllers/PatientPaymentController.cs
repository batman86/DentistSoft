using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentistManager.DentistUI.Areas.SecretaryDashboard.Controllers
{
    public class PatientPaymentController : Controller
    {
        //
        // GET: /SecretaryDashboard/PatientPayment/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /SecretaryDashboard/PatientPayment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /SecretaryDashboard/PatientPayment/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /SecretaryDashboard/PatientPayment/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
