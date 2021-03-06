﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCF_DuplexClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IDuplexSvc", CallbackContract=typeof(WCF_DuplexClient.ServiceReference1.IDuplexSvcCallback))]
    public interface IDuplexSvc {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDuplexSvc/ReturnTime")]
        void ReturnTime(int period, int number);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDuplexSvc/ReturnTime")]
        System.Threading.Tasks.Task ReturnTimeAsync(int period, int number);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDuplexSvcCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDuplexSvc/ReceiveTime")]
        void ReceiveTime(string str);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDuplexSvcChannel : WCF_DuplexClient.ServiceReference1.IDuplexSvc, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DuplexSvcClient : System.ServiceModel.DuplexClientBase<WCF_DuplexClient.ServiceReference1.IDuplexSvc>, WCF_DuplexClient.ServiceReference1.IDuplexSvc {
        
        public DuplexSvcClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public DuplexSvcClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public DuplexSvcClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DuplexSvcClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DuplexSvcClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void ReturnTime(int period, int number) {
            base.Channel.ReturnTime(period, number);
        }
        
        public System.Threading.Tasks.Task ReturnTimeAsync(int period, int number) {
            return base.Channel.ReturnTimeAsync(period, number);
        }
    }
}
