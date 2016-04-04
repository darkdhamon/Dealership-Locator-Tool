using System;
using System.Runtime.Serialization;

namespace WCFStatusResponse
{
   [DataContract]
   public class ErrorResponse : GenericResponse
   {
      [DataMember]
      public Exception Exception { get; set; }
   }
}