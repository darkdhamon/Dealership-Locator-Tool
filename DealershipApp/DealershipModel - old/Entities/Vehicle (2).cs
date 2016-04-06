using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DealershipModel.Entities
{
   [DataContract(IsReference = true)]
   public class Vehicle
   {
      [Key]
      [DataMember]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }

      [DataMember]
      public string Make { get; set; }

      [DataMember]
      public string Model { get; set; }

      [RegularExpression(@"\d{4}")]
      [DataMember]
      public string Year { get; set; }

      [DataMember]
      public Dealership Dealership { get; set; }

      [DataMember]
      [DataType(DataType.ImageUrl)]
      [Required]
      [DefaultValue("http://contentservice.mc.reyrey.net/image_v1.0.0/13363657")]
      public string ImgUrl { get; set; }
   }
}