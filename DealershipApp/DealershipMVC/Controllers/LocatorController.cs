using System.Web.Mvc;
using DealershipMVC.DealershipService;

namespace DealershipMVC.Controllers
{
   public class LocatorController : Controller
   {
      public ActionResult Locations()
      {
         DealershipServiceClient client = new DealershipServiceClient();
         return View(client.Dealerships(null,null,null,null,null));
      }
   }
}