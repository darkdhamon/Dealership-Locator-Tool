﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DealershipMVC.DealershipService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="GenericResponse", Namespace="http://schemas.datacontract.org/2004/07/WCFStatusResponse")]
    [System.SerializableAttribute()]
    public partial class GenericResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DealershipService.IDealershipService")]
    public interface IDealershipService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDealershipService/Dealerships", ReplyAction="http://tempuri.org/IDealershipService/DealershipsResponse")]
        DealershipModel.Entities.Dealership[] Dealerships(DealershipModel.Entities.Address address, System.Nullable<int> rangeMiles, string make, string model, string year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDealershipService/Dealerships", ReplyAction="http://tempuri.org/IDealershipService/DealershipsResponse")]
        System.Threading.Tasks.Task<DealershipModel.Entities.Dealership[]> DealershipsAsync(DealershipModel.Entities.Address address, System.Nullable<int> rangeMiles, string make, string model, string year);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDealershipService/AddDealership", ReplyAction="http://tempuri.org/IDealershipService/AddDealershipResponse")]
        DealershipMVC.DealershipService.GenericResponse AddDealership(DealershipModel.Entities.Dealership dealership);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDealershipService/AddDealership", ReplyAction="http://tempuri.org/IDealershipService/AddDealershipResponse")]
        System.Threading.Tasks.Task<DealershipMVC.DealershipService.GenericResponse> AddDealershipAsync(DealershipModel.Entities.Dealership dealership);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDealershipServiceChannel : DealershipMVC.DealershipService.IDealershipService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DealershipServiceClient : System.ServiceModel.ClientBase<DealershipMVC.DealershipService.IDealershipService>, DealershipMVC.DealershipService.IDealershipService {
        
        public DealershipServiceClient() {
        }
        
        public DealershipServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DealershipServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DealershipServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DealershipServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public DealershipModel.Entities.Dealership[] Dealerships(DealershipModel.Entities.Address address, System.Nullable<int> rangeMiles, string make, string model, string year) {
            return base.Channel.Dealerships(address, rangeMiles, make, model, year);
        }
        
        public System.Threading.Tasks.Task<DealershipModel.Entities.Dealership[]> DealershipsAsync(DealershipModel.Entities.Address address, System.Nullable<int> rangeMiles, string make, string model, string year) {
            return base.Channel.DealershipsAsync(address, rangeMiles, make, model, year);
        }
        
        public DealershipMVC.DealershipService.GenericResponse AddDealership(DealershipModel.Entities.Dealership dealership) {
            return base.Channel.AddDealership(dealership);
        }
        
        public System.Threading.Tasks.Task<DealershipMVC.DealershipService.GenericResponse> AddDealershipAsync(DealershipModel.Entities.Dealership dealership) {
            return base.Channel.AddDealershipAsync(dealership);
        }
    }
}
