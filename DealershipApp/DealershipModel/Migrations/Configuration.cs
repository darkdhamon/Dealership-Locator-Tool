using System.Data.Entity.Migrations;
using DealershipModel.Concrete;

namespace DealershipModel.Migrations
{
   internal sealed class Configuration : DbMigrationsConfiguration<DealershipContext>
   {
      public Configuration()
      {
         AutomaticMigrationsEnabled = true;
      }

      protected override void Seed(DealershipContext context)
      {
      }
   }
}