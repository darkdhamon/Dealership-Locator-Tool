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

   public class DealershipService : IDealershipService
   {
      public DealershipService()
      {
         Repo = new DealershipRepository();
      }

      private IDealershipRepository Repo { get; }


      public IEnumerable<Dealership> Dealerships(Address address = null, int? rangeMiles = null, string make = null, string model = null, string year = null)
      {
         foreach (
            var dealership in Repo.Dealerships.Where(d => d.Address.Latitude == null || d.Address.Longitude == null))
         {
            GeocodeAddress(dealership.Address);
            
         }
         make = string.IsNullOrWhiteSpace(make) ? null : make;
         model = string.IsNullOrWhiteSpace(model) ? null : model;
         year = string.IsNullOrWhiteSpace(year) ? null : year;
            IEnumerable<Dealership> dealerships = Repo.Dealerships.Where(d =>
               d.Vehicles.Any(v =>
                  (make==null || v.Make.Equals(make)) &&
                  (model==null || v.Model.Equals(model)) &&
                  (year==null || v.Year.Equals(year)))
               ); 

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

      public IEnumerable<Vehicle> Vehicles()
      {
         var cars = Repo.Vehicles.ToList();
         return cars;
      }

      public Vehicle Vehicle(int id)
      {
         return Repo.Vehicles.FirstOrDefault(v => v.Id == id);
      }

      public IEnumerable<Vehicle> DealerVehicles(int id)
      {
         return Vehicles()
      }

      public Dictionary<string, string[]> VehicleFilterData()
      {
         var filterData = new Dictionary<string, string[]>();
         filterData["Year"] = Repo.Vehicles.Select(v => v.Year).Distinct().ToArray();
         filterData["Make"] = Repo.Vehicles.Select(v => v.Make).Distinct().ToArray();
         filterData["Model"] = Repo.Vehicles.Select(v => v.Model).Distinct().ToArray();
         return filterData;
      }

      public Dealership Dealership(int id)
      {
         return Repo.Dealerships.FirstOrDefault(d => d.Id == id);
      }

      private static bool CheckRange(Address address, int rangeMiles, Address dealerAddress)
      {
         var tryGeo = false;
         if (address == null) return true;
         if (address.ZipCode==null&&address.City==null)
         {
            tryGeo = true;
         }
         var distanceMiles = GoogleMaps.DistanceMatrix.Query(new DistanceMatrixRequest
         {
            Destinations = new[] {dealerAddress.FullAddress},
            Origins = new[] {tryGeo?$"{address.Latitude},{address.Longitude}":address.FullAddress}
         }).Rows.First().Elements.First().Distance.Value/1000.0*0.621371;
         return distanceMiles < rangeMiles;
      }

      private void GeocodeAddress(Address address)
      {
         if (string.IsNullOrWhiteSpace(address?.StreetAddress) ||
             string.IsNullOrWhiteSpace(address.ZipCode) &&
             (string.IsNullOrWhiteSpace(address.City) || string.IsNullOrWhiteSpace(address.State)))
            return;
         var response = GoogleMaps.Geocode.Query(new GeocodingRequest {Address = address.FullAddress});
         address.ApplyGeocode(response.Results.First());
         Repo.SaveAddress(address);
      }
   }
}