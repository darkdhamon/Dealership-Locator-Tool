using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DealershipModel.Entities;
using DealershipMVC.DealershipService;

namespace DealershipMVC.Controllers
{
    public class VehicleController : Controller
    {
      private static readonly DealershipServiceClient Client = new DealershipServiceClient();
        // GET: Vehicle
        public ActionResult Index()
        {
            
            return View(Client.Vehicles().ToList());
        }

       public ActionResult Vehicle(int id)
       {
          return View(Client.Vehicle(id));
       }

       public ActionResult DealerVehicles(int dealerId)
       {
          return PartialView(Client.DealerVehicles(dealerId));
       }
    }
}