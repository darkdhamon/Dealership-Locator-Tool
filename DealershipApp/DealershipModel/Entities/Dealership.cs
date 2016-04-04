using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DealershipModel.Entities
{
   [DataContract(IsReference = true)]
   public class Dealership
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      [DataMember]
      public int Id { get; set; }

      [DataMember]
      public string Manager { get; set; }

      [DataMember]
      [DataType(DataType.PhoneNumber)]
      public string Phone { get; set; }

      [DataMember]
      public Address Address { get; set; }

      [DataMember]
      public List<Vehicle> Vehicles { get; set; }
   }
}