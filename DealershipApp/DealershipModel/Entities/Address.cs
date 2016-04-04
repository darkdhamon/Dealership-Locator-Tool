using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using GoogleMapsApi.Entities.Geocoding.Response;

namespace DealershipModel.Entities
{
   public class Address
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [DataMember]
      public int Id { get; set; }

      [Required]
      [Index("FullAddress", 1, IsUnique = true)]
      [StringLength(250)]
      [DataMember]
      public string StreetAddress { get; set; }


      [Index("FullAddress", 2, IsUnique = true)]
      [StringLength(50)]
      [DataMember]
      public string City { get; set; }


      [Index("FullAddress", 3, IsUnique = true)]
      [StringLength(2)]
      [DataMember]
      public string State { get; set; }


      [Index("FullAddress", 4, IsUnique = true)]
      [StringLength(10)]
      [DataMember]
      public string ZipCode { get; set; }

      [NotMapped]
      [DataMember]
      public string FullAddress
      {
         get { return $"{StreetAddress}, {City}, {State}, {ZipCode}"; }
         set { }
      }

      [DataMember]
      public double? Latitude { get; set; }
      [DataMember]
      public double? Longitude { get; set; }

      public void ApplyGeocode(Result geocodeResult)
      {
         var components = geocodeResult.AddressComponents.ToList();
         
         StreetAddress = $"{components.Where(c=>c.Types.Any(t=>t.Equals("street_number"))).Select(c=>c.LongName).First()} {components.Where(c=>c.Types.Any(t=>t.Equals("route"))).Select(c=>c.ShortName).First()}";
         City = City ?? components.Where(c => c.Types.Any(t => t.Equals("locality"))).Select(c => c.ShortName).First();
         State = components.Where(c => c.Types.Any(t => t.Equals("administrative_area_level_1"))).Select(c => c.ShortName).First();
         ZipCode = $"{components.Where(c => c.Types.Any(t => t.Equals("postal_code"))).Select(c => c.ShortName).First()}{(components.Any(c => c.Types.Any(t => t.Equals("postal_code_suffix"))) ? $"-{components.Where(c => c.Types.Any(t => t.Equals("postal_code_suffix"))).Select(c => c.ShortName).First()}":"")}";
         Latitude = geocodeResult.Geometry.Location.Latitude;
         Longitude = geocodeResult.Geometry.Location.Longitude;
      }
   }
}