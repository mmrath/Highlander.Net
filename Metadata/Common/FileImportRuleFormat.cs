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
// This source code was auto-generated by xsd, Version=4.0.30319.17929.
// 
namespace Metadata.Common {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ImportRuleFormat.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ImportRuleFormat.xsd", IsNullable=false)]
    public partial class ImportRuleResult {
        
        private string hostEnvNameField;
        
        private string hostComputerField;
        
        private string hostInstanceField;
        
        private string hostUserNameField;
        
        private string ruleNameField;
        
        private string[] fileNamesField;
        
        private string importResultField;
        
        private string importExceptionField;
        
        private string importDateTimeField;
        
        private string sourceSystemField;
        
        private string sourceLocationField;
        
        private string targetLocationField;
        
        /// <remarks/>
        public string hostEnvName {
            get {
                return this.hostEnvNameField;
            }
            set {
                this.hostEnvNameField = value;
            }
        }
        
        /// <remarks/>
        public string hostComputer {
            get {
                return this.hostComputerField;
            }
            set {
                this.hostComputerField = value;
            }
        }
        
        /// <remarks/>
        public string hostInstance {
            get {
                return this.hostInstanceField;
            }
            set {
                this.hostInstanceField = value;
            }
        }
        
        /// <remarks/>
        public string hostUserName {
            get {
                return this.hostUserNameField;
            }
            set {
                this.hostUserNameField = value;
            }
        }
        
        /// <remarks/>
        public string RuleName {
            get {
                return this.ruleNameField;
            }
            set {
                this.ruleNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FileNames")]
        public string[] FileNames {
            get {
                return this.fileNamesField;
            }
            set {
                this.fileNamesField = value;
            }
        }
        
        /// <remarks/>
        public string ImportResult {
            get {
                return this.importResultField;
            }
            set {
                this.importResultField = value;
            }
        }
        
        /// <remarks/>
        public string ImportException {
            get {
                return this.importExceptionField;
            }
            set {
                this.importExceptionField = value;
            }
        }
        
        /// <remarks/>
        public string ImportDateTime {
            get {
                return this.importDateTimeField;
            }
            set {
                this.importDateTimeField = value;
            }
        }
        
        /// <remarks/>
        public string SourceSystem {
            get {
                return this.sourceSystemField;
            }
            set {
                this.sourceSystemField = value;
            }
        }
        
        /// <remarks/>
        public string SourceLocation {
            get {
                return this.sourceLocationField;
            }
            set {
                this.sourceLocationField = value;
            }
        }
        
        /// <remarks/>
        public string TargetLocation {
            get {
                return this.targetLocationField;
            }
            set {
                this.targetLocationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ImportRuleFormat.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ImportRuleFormat.xsd", IsNullable=false)]
    public partial class ImportFileResult {
        
        private string hostEnvNameField;
        
        private string hostComputerField;
        
        private string hostInstanceField;
        
        private string hostUserNameField;
        
        private string ruleNameField;
        
        private string fileNameField;
        
        private string fileContentTypeField;
        
        private bool debugEnabledField;
        
        private string debugPropertiesField;
        
        private string importResultField;
        
        private string importExceptionField;
        
        private string importDateTimeField;
        
        private string sourceSystemField;
        
        private string sourceLocationField;
        
        private string targetLocationField;
        
        /// <remarks/>
        public string hostEnvName {
            get {
                return this.hostEnvNameField;
            }
            set {
                this.hostEnvNameField = value;
            }
        }
        
        /// <remarks/>
        public string hostComputer {
            get {
                return this.hostComputerField;
            }
            set {
                this.hostComputerField = value;
            }
        }
        
        /// <remarks/>
        public string hostInstance {
            get {
                return this.hostInstanceField;
            }
            set {
                this.hostInstanceField = value;
            }
        }
        
        /// <remarks/>
        public string hostUserName {
            get {
                return this.hostUserNameField;
            }
            set {
                this.hostUserNameField = value;
            }
        }
        
        /// <remarks/>
        public string RuleName {
            get {
                return this.ruleNameField;
            }
            set {
                this.ruleNameField = value;
            }
        }
        
        /// <remarks/>
        public string FileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
            }
        }
        
        /// <remarks/>
        public string FileContentType {
            get {
                return this.fileContentTypeField;
            }
            set {
                this.fileContentTypeField = value;
            }
        }
        
        /// <remarks/>
        public bool DebugEnabled {
            get {
                return this.debugEnabledField;
            }
            set {
                this.debugEnabledField = value;
            }
        }
        
        /// <remarks/>
        public string DebugProperties {
            get {
                return this.debugPropertiesField;
            }
            set {
                this.debugPropertiesField = value;
            }
        }
        
        /// <remarks/>
        public string ImportResult {
            get {
                return this.importResultField;
            }
            set {
                this.importResultField = value;
            }
        }
        
        /// <remarks/>
        public string ImportException {
            get {
                return this.importExceptionField;
            }
            set {
                this.importExceptionField = value;
            }
        }
        
        /// <remarks/>
        public string ImportDateTime {
            get {
                return this.importDateTimeField;
            }
            set {
                this.importDateTimeField = value;
            }
        }
        
        /// <remarks/>
        public string SourceSystem {
            get {
                return this.sourceSystemField;
            }
            set {
                this.sourceSystemField = value;
            }
        }
        
        /// <remarks/>
        public string SourceLocation {
            get {
                return this.sourceLocationField;
            }
            set {
                this.sourceLocationField = value;
            }
        }
        
        /// <remarks/>
        public string TargetLocation {
            get {
                return this.targetLocationField;
            }
            set {
                this.targetLocationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/ImportRuleFormat.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/ImportRuleFormat.xsd", IsNullable=false)]
    public partial class ProcessFileResult {
        
        private string hostEnvNameField;
        
        private string hostComputerField;
        
        private string hostInstanceField;
        
        private string hostUserNameField;
        
        private string locationField;
        
        private string fileNameField;
        
        private string processResultField;
        
        private string processExceptionField;
        
        private string processDateTimeField;
        
        /// <remarks/>
        public string hostEnvName {
            get {
                return this.hostEnvNameField;
            }
            set {
                this.hostEnvNameField = value;
            }
        }
        
        /// <remarks/>
        public string hostComputer {
            get {
                return this.hostComputerField;
            }
            set {
                this.hostComputerField = value;
            }
        }
        
        /// <remarks/>
        public string hostInstance {
            get {
                return this.hostInstanceField;
            }
            set {
                this.hostInstanceField = value;
            }
        }
        
        /// <remarks/>
        public string hostUserName {
            get {
                return this.hostUserNameField;
            }
            set {
                this.hostUserNameField = value;
            }
        }
        
        /// <remarks/>
        public string Location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
            }
        }
        
        /// <remarks/>
        public string FileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
            }
        }
        
        /// <remarks/>
        public string ProcessResult {
            get {
                return this.processResultField;
            }
            set {
                this.processResultField = value;
            }
        }
        
        /// <remarks/>
        public string ProcessException {
            get {
                return this.processExceptionField;
            }
            set {
                this.processExceptionField = value;
            }
        }
        
        /// <remarks/>
        public string ProcessDateTime {
            get {
                return this.processDateTimeField;
            }
            set {
                this.processDateTimeField = value;
            }
        }
    }
}
