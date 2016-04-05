using System.CodeDom;
using System.Web.Mvc;
using DealershipModel.Entities;
using DealershipMVC.DealershipService;
using WCFStatusResponse;

namespace DealershipMVC.Controllers
{
   public class RegisterController : Controller
   {
      // GET: Register
      public ActionResult Register()
      {
         var dealership = new Dealership();
         return View(dealership);
      }

      [HttpPost]
      public ActionResult Register(Dealership dealership)
      {
         var client = new DealershipServiceClient();
         var response = client.AddDealership(dealership);
         if (typeof (ErrorResponse) != response.GetType()) return RedirectToAction("Locations", "Locator");
         ViewBag.ErrorMessage(response.Message);

         return View(dealership);
      }
   
   }
}