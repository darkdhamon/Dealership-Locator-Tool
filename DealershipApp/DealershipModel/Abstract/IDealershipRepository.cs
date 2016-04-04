using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealershipModel.Entities;

namespace DealershipModel.Abstract
{
   public interface IDealershipRepository
   {
      IQueryable<Dealership> Dealerships { get; }
      //IQueryable<Dealership> DealershipsCompleteDetails { get; }
      IQueryable<Address> Addresses { get; }
      IQueryable<Vehicle> Vehicles { get; }
      void SaveAddress(Address address);
      void SaveDealership(Dealership dealership);
   }
}
