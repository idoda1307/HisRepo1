﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 15.0.27130.2010
// 
namespace Client.OptimalPackageServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OptimalPackageServiceReference.IOptimalPackageService")]
    public interface IOptimalPackageService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOptimalPackageService/CalaculateTotalMinutes", ReplyAction="http://tempuri.org/IOptimalPackageService/CalaculateTotalMinutesResponse")]
        System.Threading.Tasks.Task<double> CalaculateTotalMinutesAsync(int lineId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOptimalPackageService/CalculateTotalSMS", ReplyAction="http://tempuri.org/IOptimalPackageService/CalculateTotalSMSResponse")]
        System.Threading.Tasks.Task<int> CalculateTotalSMSAsync(int lineId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOptimalPackageService/CalculateTotalMinutesOfTopNumber", ReplyAction="http://tempuri.org/IOptimalPackageService/CalculateTotalMinutesOfTopNumberRespons" +
            "e")]
        System.Threading.Tasks.Task<double> CalculateTotalMinutesOfTopNumberAsync(int lineId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOptimalPackageService/CalculateTotalMinutesOf3TopNumbers", ReplyAction="http://tempuri.org/IOptimalPackageService/CalculateTotalMinutesOf3TopNumbersRespo" +
            "nse")]
        System.Threading.Tasks.Task<double> CalculateTotalMinutesOf3TopNumbersAsync(int lineId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOptimalPackageService/CalculateTotalMinutesWithFamily", ReplyAction="http://tempuri.org/IOptimalPackageService/CalculateTotalMinutesWithFamilyResponse" +
            "")]
        System.Threading.Tasks.Task<double> CalculateTotalMinutesWithFamilyAsync(int lineId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOptimalPackageService/CalculateClientValue", ReplyAction="http://tempuri.org/IOptimalPackageService/CalculateClientValueResponse")]
        System.Threading.Tasks.Task<double> CalculateClientValueAsync(string clientId);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOptimalPackageServiceChannel : Client.OptimalPackageServiceReference.IOptimalPackageService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OptimalPackageServiceClient : System.ServiceModel.ClientBase<Client.OptimalPackageServiceReference.IOptimalPackageService>, Client.OptimalPackageServiceReference.IOptimalPackageService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public OptimalPackageServiceClient() : 
                base(OptimalPackageServiceClient.GetDefaultBinding(), OptimalPackageServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IOptimalPackageService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OptimalPackageServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(OptimalPackageServiceClient.GetBindingForEndpoint(endpointConfiguration), OptimalPackageServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OptimalPackageServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(OptimalPackageServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OptimalPackageServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(OptimalPackageServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public OptimalPackageServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<double> CalaculateTotalMinutesAsync(int lineId) {
            return base.Channel.CalaculateTotalMinutesAsync(lineId);
        }
        
        public System.Threading.Tasks.Task<int> CalculateTotalSMSAsync(int lineId) {
            return base.Channel.CalculateTotalSMSAsync(lineId);
        }
        
        public System.Threading.Tasks.Task<double> CalculateTotalMinutesOfTopNumberAsync(int lineId) {
            return base.Channel.CalculateTotalMinutesOfTopNumberAsync(lineId);
        }
        
        public System.Threading.Tasks.Task<double> CalculateTotalMinutesOf3TopNumbersAsync(int lineId) {
            return base.Channel.CalculateTotalMinutesOf3TopNumbersAsync(lineId);
        }
        
        public System.Threading.Tasks.Task<double> CalculateTotalMinutesWithFamilyAsync(int lineId) {
            return base.Channel.CalculateTotalMinutesWithFamilyAsync(lineId);
        }
        
        public System.Threading.Tasks.Task<double> CalculateClientValueAsync(string clientId) {
            return base.Channel.CalculateClientValueAsync(clientId);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IOptimalPackageService)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IOptimalPackageService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:61783/Services/OptimalPackageService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return OptimalPackageServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IOptimalPackageService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return OptimalPackageServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IOptimalPackageService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IOptimalPackageService,
        }
    }
}
