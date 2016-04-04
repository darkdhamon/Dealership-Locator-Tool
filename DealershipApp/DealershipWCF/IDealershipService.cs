using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DealershipModel.Entities;
using GoogleMapsApi.Entities.Directions.Response;
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
 
      
      
   }
}
