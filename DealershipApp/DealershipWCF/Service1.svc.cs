using System;
using System.Collections.Generic;
using System.Linq;
using DealershipModel.Abstract;
using DealershipModel.Concrete;
using DealershipModel.Entities;
using GoogleMapsApi;
using GoogleMapsApi.Entities.DistanceMatrix.Request;
using GoogleMapsApi.Entities.Geocoding.Request;
using WCFStatusResponse;

namespace DealershipWCF
{
   // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DealershipService" in code, svc and config file together.
   // NOTE: In order to launch WCF Test Client for testing this service, please select DealershipService.svc or DealershipService.svc.cs at the Solution Explorer and start debugging.
   public class DealershipService : IDealershipService
   {
      public DealershipService()
      {
         Repo = new DealershipRepository();
      }

      private IDealershipRepository Repo { get; }


      public IEnumerable<Dealership> Dealerships(Address address = null,
         int? rangeMiles = null, string make = null,
         string model = null,
         string year = null)
      {
         foreach (
            var dealership in Repo.Dealerships.Where(d => d.Address.Latitude == null || d.Address.Longitude == null))
         {
            GeocodeAddress(dealership.Address);
            
         }
         make = string.IsNullOrWhiteSpace(make) ? null : make;
         model = string.IsNullOrWhiteSpace(model) ? null : model;
         year = string.IsNullOrWhiteSpace(year) ? null : year;
         //if (string.IsNullOrWhiteSpace(make) && string.IsNullOrWhiteSpace(model) && string.IsNullOrWhiteSpace(year))
            IEnumerable<Dealership> dealerships = Repo.Dealerships.Where(d =>
               d.Vehicles.Any(v =>
                  (make==null || v.Make.Equals(make)) &&
                  (model==null || v.Model.Equals(model)) &&
                  (year==null || v.Year.Equals(year)))
               ); 
         /* CheckRange(address, rangeMiles, d.Address)*/
        // else
         //{
         //   dealerships = Repo.DealershipsCompleteDetails.Where(d =>
         //      d.Vehicles.Any(v =>
         //         (string.IsNullOrWhiteSpace(make) || v.Make.Equals(make)) &&
         //         (string.IsNullOrWhiteSpace(model) || v.Model.Equals(model)) &&
         //         (string.IsNullOrWhiteSpace(year) || v.Year.Equals(year)))
         //      );
         //   foreach (var dealership in dealerships)
         //   {
         //      dealership.Vehicles.Clear();
         //   }
         //}
         dealerships = dealerships
            .ToList()
            .Where(d =>
               rangeMiles == null ||
               CheckRange(address, (int) rangeMiles, d.Address));
         return dealerships.ToList();
      }


      public GenericResponse AddDealership(Dealership dealership)
      {
         GenericResponse response;
         try
         {
            GeocodeAddress(dealership.Address);
            if (Repo.Dealerships.Any(
               d => d.Address.FullAddress.Equals(dealership.Address.FullAddress)))
               throw new Exception("A dealership already exist at this location.");
            Repo.SaveDealership(dealership);
            response = new GenericResponse
            {
               Message = "Dealership has been Saved"
            };
         }
         catch (Exception e)
         {
            response = new ErrorResponse
            {
               Exception = e,
               Message = e.Message
            };
         }

         return response;
      }

      private static bool CheckRange(Address address, int rangeMiles, Address dealerAddress)
      {
         if (address == null) return true;
         var distanceMiles = GoogleMaps.DistanceMatrix.Query(new DistanceMatrixRequest
         {
            Destinations = new[] {dealerAddress.FullAddress},
            Origins = new[] {address.FullAddress}
         }).Rows.First().Elements.First().Distance.Value/1000.0*0.621371;
         return distanceMiles < rangeMiles;
      }

      private void GeocodeAddress(Address address)
      {
         if (string.IsNullOrWhiteSpace(address.StreetAddress) ||
             string.IsNullOrWhiteSpace(address.ZipCode) &&
             (string.IsNullOrWhiteSpace(address.City) || string.IsNullOrWhiteSpace(address.State)))
            throw new NullReferenceException();
         var response = GoogleMaps.Geocode.Query(new GeocodingRequest {Address = address.FullAddress});
         address.ApplyGeocode(response.Results.First());
         Repo.SaveAddress(address);
      }
   }
}