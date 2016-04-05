using System;
using System.Collections.Generic;
using System.ServiceModel;
using DealershipModel.Entities;
using WCFStatusResponse;

namespace DealershipWCF
{
   [ServiceContract]
   public interface IDealershipService
   {
      /// <summary>
      /// Return All Dealerships
      /// </summary>
      /// <returns></returns>
      [OperationContract]
      IEnumerable<Dealership> Dealerships(Address address = null, int? rangeMiles=null, string make = null, string model = null, string year = null);

      [OperationContract]
      GenericResponse AddDealership(Dealership dealership);

      [OperationContract]
      IEnumerable<Vehicle> Vehicles();
      [OperationContract]
      Vehicle Vehicle(int id);
      [OperationContract]
      IEnumerable<Vehicle> DealerVehicles(int id);

      [OperationContract]
      Dictionary<string, string[]> VehicleFilterData();

      [OperationContract]
      Dealership Dealership(int id);
   }
}
