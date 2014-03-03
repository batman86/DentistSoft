using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using DHTMLX.Scheduler;
using DHTMLX.Common;
using DHTMLX.Scheduler.Data;
using DHTMLX.Scheduler.Controls;

using DentistManager.DentistUI.Models;
namespace DentistManager.DentistUI.Controllers
{
    public class CalendarController : Controller
    {
        public ActionResult Index()
        {
            var scheduler = new DHXScheduler();
            scheduler.DataAction = Url.Action("Data");
            scheduler.SaveAction = Url.Action("Save");
            
 
          //  scheduler.InitialDate = new DateTime(2012, 09, 03);

            scheduler.LoadData = true;
            scheduler.EnableDataprocessor = true;
            return View(scheduler);
        }

        public ContentResult Data()
        {
            List<CalendarEvent> eventList = new List<CalendarEvent>{ 
                        new CalendarEvent{
                            id = 1, 
                            text = "Sample Event", 
                            start_date = new DateTime(2014, 03, 03, 6, 00, 00), 
                            end_date = new DateTime(2014, 03, 03, 8, 00, 00)
                        },
                        new CalendarEvent{
                            id = 2, 
                            text = "New Event", 
                            start_date = new DateTime(2014, 04, 05, 9, 00, 00), 
                            end_date = new DateTime(2012, 04, 05, 12, 00, 00)
                        },
                        new CalendarEvent{
                            id = 3, 
                            text = "Multiday Event", 
                            start_date = new DateTime(2014, 03, 03, 10, 00, 00), 
                            end_date = new DateTime(2012, 03, 10, 12, 00, 00)
                        }
                    };

            return Content(new SchedulerAjaxData(eventList), "text/json");
        }

        public ContentResult Save(int? id, FormCollection actionValues)
        {
            var action = new DataAction(actionValues);
            
            try
            {
                var changedEvent = (CalendarEvent)DHXEventsHelper.Bind(typeof(CalendarEvent), actionValues);

     

                switch (action.Type)
                {
                    case DataActionTypes.Insert:
                        //do insert
                        action.TargetId = changedEvent.id;//assign postoperational id
                        break;
                    case DataActionTypes.Delete:
                        //do delete
                        break;
                    default:// "update"                          
                        //do update
                        break;
                }
            }
            catch
            {
                action.Type = DataActionTypes.Error;
            }
            return (ContentResult)new AjaxSaveResponse(action);
        }
    }
}

