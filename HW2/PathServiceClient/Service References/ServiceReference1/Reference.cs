﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PathServiceClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IMyPathService")]
    public interface IMyPathService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyPathService/GetFolderСontents", ReplyAction="http://tempuri.org/IMyPathService/GetFolderСontentsResponse")]
        string GetFolderСontents(string path);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyPathService/GetFolderСontents", ReplyAction="http://tempuri.org/IMyPathService/GetFolderСontentsResponse")]
        System.Threading.Tasks.Task<string> GetFolderСontentsAsync(string path);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyPathServiceChannel : PathServiceClient.ServiceReference1.IMyPathService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyPathServiceClient : System.ServiceModel.ClientBase<PathServiceClient.ServiceReference1.IMyPathService>, PathServiceClient.ServiceReference1.IMyPathService {
        
        public MyPathServiceClient() {
        }
        
        public MyPathServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyPathServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyPathServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyPathServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetFolderСontents(string path) {
            return base.Channel.GetFolderСontents(path);
        }
        
        public System.Threading.Tasks.Task<string> GetFolderСontentsAsync(string path) {
            return base.Channel.GetFolderСontentsAsync(path);
        }
    }
}