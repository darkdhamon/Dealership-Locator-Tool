using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DealershipMVC.Models
{
   public class FilterViewModel
   {
      public FilterViewModel()
      {
         Years = new List<SelectListItem>();
         Makes  = new List<SelectListItem>();
         Models = new List<SelectListItem>();
      }

      public int Miles { get; set; }

      [RegularExpression(@"\d{4}")]
      public string Year { get; set; }

      public string Make { get; set; }
      public string Model { get; set; }

      [RegularExpression(@"\d{5}")]
      public string ZipCode { get; set; }

      public List<SelectListItem> Years { get; set; } 
      public List<SelectListItem> Makes { get; set; } 
      public List<SelectListItem> Models { get; set; }
   }
}