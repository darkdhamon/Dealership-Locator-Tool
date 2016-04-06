using System.Data.Entity;
using System.Linq;
using DealershipModel.Abstract;
using DealershipModel.Entities;

namespace DealershipModel.Concrete
{
   public class DealershipRepository : IDealershipRepository
   {
      private static DealershipContext Context => new DealershipContext();

      public IQueryable<Dealership> Dealerships => Context.Dealerships.Include(d => d.Address);


      public IQueryable<Address> Addresses => Context.Addresses;
      public IQueryable<Vehicle> Vehicles => Context.Vehicles.Include(v => v.Dealership.Address);

      public void SaveAddress(Address address)
      {
         var firstOrDefault =
            Context.Addresses.FirstOrDefault(a => a.Latitude == address.Latitude && a.Longitude == address.Longitude);
         if (firstOrDefault != null)
            address.Id = firstOrDefault.Id;
         using (var context = new DealershipContext())
         {
            if (address.Id == 0)
            {
               context.Addresses.Add(address);
            }
            else
            {
               var dbEntry = context.Addresses.SingleOrDefault(a => a.Id == address.Id);
               if (dbEntry != null)
               {
                  dbEntry.StreetAddress = address.StreetAddress;
                  dbEntry.Longitude = address.Longitude;
                  dbEntry.Latitude = address.Latitude;
                  dbEntry.City = address.City;
                  dbEntry.State = address.State;
                  dbEntry.ZipCode = address.ZipCode;
                  context.Addresses.Attach(dbEntry);
                  context.Entry(dbEntry).State = EntityState.Modified;
               }
               //var entry = Context.Entry(address);
               //entry.State = EntityState.Modified;
            }
            //var entry = Context.Entry(address);
            //entry.State = EntityState.Modified;
            //var validation = entry.GetValidationResult();

            var result = context.SaveChanges();

            //if(result==0)throw new Exception();
         }
      }

      /// <summary>
      ///    Save Dealerships
      /// </summary>
      /// <remarks>Geocode New addresses to avoid Unique violations.</remarks>
      /// <param name="dealership"></param>
      public void SaveDealership(Dealership dealership)
      {
         using (var context = new DealershipContext())
         {
            if (dealership.Address.Id == 0)
               dealership.Address =
                  Addresses.FirstOrDefault(a => a.FullAddress.Equals(dealership.Address.FullAddress)) ??
                  dealership.Address;
            if (dealership.Id == 0)
            {
               //todo: If Address does not save come back here
               context.Dealerships.Add(dealership);
            }
            else
            {
               //var dbEntry = Context.Dealerships.Find(dealership.Id);
               //if (dbEntry != null)
               //{
               //   dbEntry.Address = dealership.Address;
               //   dbEntry.Manager = dealership.Manager;
               //   dbEntry.Phone = dealership.Phone;
               //}
               context.Entry(dealership).State = EntityState.Modified;
            }
            context.SaveChanges();
         }
      }
   }
}