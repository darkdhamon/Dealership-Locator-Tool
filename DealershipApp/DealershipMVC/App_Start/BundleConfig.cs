using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace DealershipMVC.App_Start
{
   public class BundleConfig
   {
      public static void RegisterBundle(BundleCollection bundles)
      {
         bundles.Add(new StyleBundle("~/css/Bootstrap")
            .Include("~/Content/bootstrap.min.css")
            .Include("~/Content/bootstrap.min.css.map")
            .Include("~/Content/bootstrap-theme.min.css")
            .Include("~/Content/bootstrap-theme.min.css.map")
            .Include("~/Content/Site.css")
            );
         bundles.Add(new ScriptBundle("~/js/JQuery")
            .Include("~/scripts/jquery-2.2.2.min.js")
            .Include("~/scripts/jquery-2.2.2.min.map"));
         bundles.Add(new ScriptBundle("~/js/Bootstrap")
            .Include("~/scripts/bootstrap.min.js")
            );


      }
   }
}