using System.Data.Entity;
using DealershipModel.Entities;

namespace DealershipModel.Concrete
{
   public class DealershipContext :DbContext
   {
      public DbSet<Dealership> Dealerships { get; set; }
      public DbSet<Address> Addresses { get; set; }
      public DbSet<Vehicle> Vehicles { get; set; }
   }
}
