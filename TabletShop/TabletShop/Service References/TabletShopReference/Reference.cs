﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TabletShop.TabletShopReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TabletShopReference.ITabletService")]
    public interface ITabletService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITabletService/CheckService", ReplyAction="http://tempuri.org/ITabletService/CheckServiceResponse")]
        string CheckService();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITabletServiceChannel : TabletShop.TabletShopReference.ITabletService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TabletServiceClient : System.ServiceModel.ClientBase<TabletShop.TabletShopReference.ITabletService>, TabletShop.TabletShopReference.ITabletService {
        
        public TabletServiceClient() {
        }
        
        public TabletServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TabletServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TabletServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TabletServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string CheckService() {
            return base.Channel.CheckService();
        }
    }
}
