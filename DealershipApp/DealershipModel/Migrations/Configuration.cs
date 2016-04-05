using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using DealershipModel.Concrete;
using DealershipModel.Entities;

namespace DealershipModel.Migrations
{
   internal sealed class Configuration : DbMigrationsConfiguration<DealershipContext>
   {
      public Configuration()
      {
         AutomaticMigrationsEnabled = false;
      }

      protected override void Seed(DealershipContext context)
      {
         using (context = new DealershipContext())
         {
            var dealership = new Dealership
            {
               Address = new Address
               {
                  StreetAddress = "2796 Hord Rd",
                  City = "York",
                  State = "SC",
                  ZipCode = "29745"
               },
               Manager = "Harold Brown",
               Vehicles = new List<Vehicle>
            {
               new Vehicle
               {
                  Make = "Ford",
                  Model = "Econovan",
                  Year = "1971",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               },
               new Vehicle
               {
                  Make = "Ford",
                  Model = "F-150",
                  Year = "1971",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               },
               new Vehicle
               {
                  Make = "Nissan",
                  Model = "Pathfinder",
                  Year = "1999",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               },
               new Vehicle
               {
                  Make = "Mazda",
                  Model = "B-2800",
                  Year = "1999",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               },
               new Vehicle
               {
                  Make = "Ford",
                  Model = "Tempo",
                  Year = "1989",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               },
               new Vehicle
               {
                  Make = "Triumph",
                  Model = "TR8",
                  Year = "1980",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               },
               new Vehicle
               {
                  Make = "Ford",
                  Model = "Festiva",
                  Year = "1991",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               },
               new Vehicle
               {
                  Make = "Buick",
                  Model = "LeSabre",
                  Year = "2001",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               }
            }
            };
            context.Dealerships.Add(dealership);
            dealership = new Dealership
            {
               Address = new Address
               {
                  StreetAddress = "2330 Dulles station Blvd",
                  ZipCode = "20171"
               },
               Manager = "Bronze Brown",
               Vehicles = new List<Vehicle>
            {
               new Vehicle
               {
                  Make = "Ford",
                  Model = "Ranger",
                  Year = "1999",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               },
               new Vehicle
               {
                  Make = "Nissan",
                  Model = "Altima",
                  Year = "2012",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               },
               new Vehicle
               {
                  Make = "Dodge",
                  Model = "Avenger",
                  Year = "2015",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               },
               new Vehicle
               {
                  Make = "Ford",
                  Model = "Escape",
                  Year = "2001",
                  ImgURL = "http://contentservice.mc.reyrey.net/image_v1.0.0/13363657"
               }
            }
            };

            context.Dealerships.Add(dealership);
            dealership = new Dealership
            {
               Address = new Address
               {
                  StreetAddress = "1600 pennsylvania ave",
                  City = "Washinton",
                  State = "DC"
               }
            };
            context.Dealerships.Add(dealership);
            context.SaveChanges();
         }
         
      }
   }
}