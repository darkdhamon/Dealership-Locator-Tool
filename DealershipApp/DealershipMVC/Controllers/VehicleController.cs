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
      private static DealershipServiceClient client = new DealershipServiceClient();
        // GET: Vehicle
        public ActionResult Index()
        {
            
            return View(client.Vehicles().ToList() as IEnumerable<Vehicle>);
        }
    }
}