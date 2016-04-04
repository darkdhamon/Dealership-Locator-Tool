using System.Runtime.Serialization;

namespace WCFStatusResponse
{
   [DataContract]
   public class GenericResponse
   {
      [DataMember]
      public string Message { get; set; }

   }
}