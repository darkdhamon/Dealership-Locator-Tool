using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using DealershipModel.Entities;
using DealershipMVC.DealershipService;
using DealershipMVC.Models;
using Microsoft.Ajax.Utilities;

namespace DealershipMVC.Controllers
{
   public class LocatorController : Controller
   {
      private static readonly DealershipServiceClient Client = new DealershipServiceClient();

      public ActionResult Locations()
      {
         return View(Client.Dealerships(null, null, null, null, null));
      }

      public ActionResult FilterLocations()
      {
         var data = Client.VehicleFilterData();

         var model = new FilterViewModel
         {
            Years = data["Year"].Select(x => new SelectListItem
            {
               Value = x,
               Text = x,
               Selected = false
            }).ToList(),
            Makes = data["Make"].Select(x => new SelectListItem
            {
               Value = x,
               Selected = false,
               Text = x,
            }).ToList(),
            Models = data["Model"].Select(x => new SelectListItem
            {
               Value = x,
               Selected = false,
               Text = x,
            }).ToList()
         };
         model.Years.Add(new SelectListItem
         {
            Selected = true,
            Text = "Any Year"
         }); model.Makes.Add(new SelectListItem
         {
            Selected = true,
            Text = "Any Make"
         }); model.Models.Add(new SelectListItem
         {
            Selected = true,
            Text = "Any Model"
         });
         return PartialView(model);
      }

      [HttpPost]
      public ActionResult FilterLocations(int miles, string zipCode, string year, string make, string model, string city, string state, double lat, double lng, bool useLoc)
      {
         Address address = null;
         if (!zipCode.IsNullOrWhiteSpace() && Regex.Match(zipCode, @"\d{5}").Success)
         {
            address = new Address()
            {
               ZipCode = zipCode
            };
         }
         if (!city.IsNullOrWhiteSpace() && !state.IsNullOrWhiteSpace())
            address = new Address()
            {
               City = city,
               State = state,
            };
         if (!(lat == 0 || lng == 0) && useLoc)
            address = new Address()
            {
               Latitude = lat,
               Longitude = lng
            };
         if (!(year != null && Regex.Match(year, @"\d{4}").Success))
         {
            year = null;
         }
         return PartialView("Dealerships",
            Client.Dealerships(
               address,
               miles == 0 ? (int?)null : miles,
               make.Equals("Any Make") ? null : make,
               model.Equals("Any Model") ? null : model,
               year
               ));
      }

      public ActionResult Dealership(int id)
      {
         var dealer = Client.Dealership(id);
         return PartialView("Dealership", dealer);
      }
   }
}