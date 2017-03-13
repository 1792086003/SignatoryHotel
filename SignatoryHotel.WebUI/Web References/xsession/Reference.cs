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
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Lanxess.CN.SignatoryHotel.WebUI.xsession {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="xSessionSoap", Namespace="http://tempuri.org/")]
    public partial class xSession : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback HelloWorldOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsAthenticatedOperationCompleted;
        
        private System.Threading.SendOrPostCallback IsAthenticatedExOperationCompleted;
        
        private System.Threading.SendOrPostCallback newSessionOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetModelOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetSysCodeOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public xSession() {
            this.Url = global::Lanxess.CN.SignatoryHotel.WebUI.Properties.Settings.Default.SignatoryHotel_WebUI_xsession_xSession;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event HelloWorldCompletedEventHandler HelloWorldCompleted;
        
        /// <remarks/>
        public event IsAthenticatedCompletedEventHandler IsAthenticatedCompleted;
        
        /// <remarks/>
        public event IsAthenticatedExCompletedEventHandler IsAthenticatedExCompleted;
        
        /// <remarks/>
        public event newSessionCompletedEventHandler newSessionCompleted;
        
        /// <remarks/>
        public event GetModelCompletedEventHandler GetModelCompleted;
        
        /// <remarks/>
        public event GetSysCodeCompletedEventHandler GetSysCodeCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/HelloWorld", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string HelloWorld() {
            object[] results = this.Invoke("HelloWorld", new object[0]);
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void HelloWorldAsync() {
            this.HelloWorldAsync(null);
        }
        
        /// <remarks/>
        public void HelloWorldAsync(object userState) {
            if ((this.HelloWorldOperationCompleted == null)) {
                this.HelloWorldOperationCompleted = new System.Threading.SendOrPostCallback(this.OnHelloWorldOperationCompleted);
            }
            this.InvokeAsync("HelloWorld", new object[0], this.HelloWorldOperationCompleted, userState);
        }
        
        private void OnHelloWorldOperationCompleted(object arg) {
            if ((this.HelloWorldCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.HelloWorldCompleted(this, new HelloWorldCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IsAthenticated", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool IsAthenticated(string sessionTick, string cwid) {
            object[] results = this.Invoke("IsAthenticated", new object[] {
                        sessionTick,
                        cwid});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void IsAthenticatedAsync(string sessionTick, string cwid) {
            this.IsAthenticatedAsync(sessionTick, cwid, null);
        }
        
        /// <remarks/>
        public void IsAthenticatedAsync(string sessionTick, string cwid, object userState) {
            if ((this.IsAthenticatedOperationCompleted == null)) {
                this.IsAthenticatedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsAthenticatedOperationCompleted);
            }
            this.InvokeAsync("IsAthenticated", new object[] {
                        sessionTick,
                        cwid}, this.IsAthenticatedOperationCompleted, userState);
        }
        
        private void OnIsAthenticatedOperationCompleted(object arg) {
            if ((this.IsAthenticatedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsAthenticatedCompleted(this, new IsAthenticatedCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/IsAthenticatedEx", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public validateResult IsAthenticatedEx(string sessionTick, string cwid) {
            object[] results = this.Invoke("IsAthenticatedEx", new object[] {
                        sessionTick,
                        cwid});
            return ((validateResult)(results[0]));
        }
        
        /// <remarks/>
        public void IsAthenticatedExAsync(string sessionTick, string cwid) {
            this.IsAthenticatedExAsync(sessionTick, cwid, null);
        }
        
        /// <remarks/>
        public void IsAthenticatedExAsync(string sessionTick, string cwid, object userState) {
            if ((this.IsAthenticatedExOperationCompleted == null)) {
                this.IsAthenticatedExOperationCompleted = new System.Threading.SendOrPostCallback(this.OnIsAthenticatedExOperationCompleted);
            }
            this.InvokeAsync("IsAthenticatedEx", new object[] {
                        sessionTick,
                        cwid}, this.IsAthenticatedExOperationCompleted, userState);
        }
        
        private void OnIsAthenticatedExOperationCompleted(object arg) {
            if ((this.IsAthenticatedExCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.IsAthenticatedExCompleted(this, new IsAthenticatedExCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/newSession", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string newSession(string cwid, int sysCode) {
            object[] results = this.Invoke("newSession", new object[] {
                        cwid,
                        sysCode});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void newSessionAsync(string cwid, int sysCode) {
            this.newSessionAsync(cwid, sysCode, null);
        }
        
        /// <remarks/>
        public void newSessionAsync(string cwid, int sysCode, object userState) {
            if ((this.newSessionOperationCompleted == null)) {
                this.newSessionOperationCompleted = new System.Threading.SendOrPostCallback(this.OnnewSessionOperationCompleted);
            }
            this.InvokeAsync("newSession", new object[] {
                        cwid,
                        sysCode}, this.newSessionOperationCompleted, userState);
        }
        
        private void OnnewSessionOperationCompleted(object arg) {
            if ((this.newSessionCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.newSessionCompleted(this, new newSessionCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetModel", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public xSession1 GetModel(string sessionTick) {
            object[] results = this.Invoke("GetModel", new object[] {
                        sessionTick});
            return ((xSession1)(results[0]));
        }
        
        /// <remarks/>
        public void GetModelAsync(string sessionTick) {
            this.GetModelAsync(sessionTick, null);
        }
        
        /// <remarks/>
        public void GetModelAsync(string sessionTick, object userState) {
            if ((this.GetModelOperationCompleted == null)) {
                this.GetModelOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetModelOperationCompleted);
            }
            this.InvokeAsync("GetModel", new object[] {
                        sessionTick}, this.GetModelOperationCompleted, userState);
        }
        
        private void OnGetModelOperationCompleted(object arg) {
            if ((this.GetModelCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetModelCompleted(this, new GetModelCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetSysCode", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int GetSysCode(string sessionTick) {
            object[] results = this.Invoke("GetSysCode", new object[] {
                        sessionTick});
            return ((int)(results[0]));
        }
        
        /// <remarks/>
        public void GetSysCodeAsync(string sessionTick) {
            this.GetSysCodeAsync(sessionTick, null);
        }
        
        /// <remarks/>
        public void GetSysCodeAsync(string sessionTick, object userState) {
            if ((this.GetSysCodeOperationCompleted == null)) {
                this.GetSysCodeOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetSysCodeOperationCompleted);
            }
            this.InvokeAsync("GetSysCode", new object[] {
                        sessionTick}, this.GetSysCodeOperationCompleted, userState);
        }
        
        private void OnGetSysCodeOperationCompleted(object arg) {
            if ((this.GetSysCodeCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetSysCodeCompleted(this, new GetSysCodeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public enum validateResult {
        
        /// <remarks/>
        LOGIN_USER_OK,
        
        /// <remarks/>
        LOGIN_USER_DOESNT_EXIST,
        
        /// <remarks/>
        LOGIN_USER_CWID_INCORRECT,
        
        /// <remarks/>
        LOGIN_USER_SESSION_EXPIRED,
        
        /// <remarks/>
        LOGIN_USER_DELFLAG_TRUE,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1087.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(TypeName="xSession", Namespace="http://tempuri.org/")]
    public partial class xSession1 {
        
        private int idField;
        
        private string cWIDField;
        
        private System.Guid sessionGUIDField;
        
        private System.DateTime createDateField;
        
        private System.DateTime expiredDateField;
        
        private string sessionIPField;
        
        private int sessionSysCodeField;
        
        private bool flagDeleteField;
        
        /// <remarks/>
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string CWID {
            get {
                return this.cWIDField;
            }
            set {
                this.cWIDField = value;
            }
        }
        
        /// <remarks/>
        public System.Guid SessionGUID {
            get {
                return this.sessionGUIDField;
            }
            set {
                this.sessionGUIDField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime CreateDate {
            get {
                return this.createDateField;
            }
            set {
                this.createDateField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime ExpiredDate {
            get {
                return this.expiredDateField;
            }
            set {
                this.expiredDateField = value;
            }
        }
        
        /// <remarks/>
        public string SessionIP {
            get {
                return this.sessionIPField;
            }
            set {
                this.sessionIPField = value;
            }
        }
        
        /// <remarks/>
        public int SessionSysCode {
            get {
                return this.sessionSysCodeField;
            }
            set {
                this.sessionSysCodeField = value;
            }
        }
        
        /// <remarks/>
        public bool flagDelete {
            get {
                return this.flagDeleteField;
            }
            set {
                this.flagDeleteField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    public delegate void HelloWorldCompletedEventHandler(object sender, HelloWorldCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class HelloWorldCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal HelloWorldCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    public delegate void IsAthenticatedCompletedEventHandler(object sender, IsAthenticatedCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsAthenticatedCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsAthenticatedCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    public delegate void IsAthenticatedExCompletedEventHandler(object sender, IsAthenticatedExCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IsAthenticatedExCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal IsAthenticatedExCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public validateResult Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((validateResult)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    public delegate void newSessionCompletedEventHandler(object sender, newSessionCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class newSessionCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal newSessionCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    public delegate void GetModelCompletedEventHandler(object sender, GetModelCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetModelCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetModelCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public xSession1 Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((xSession1)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    public delegate void GetSysCodeCompletedEventHandler(object sender, GetSysCodeCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1087.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetSysCodeCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetSysCodeCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public int Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591