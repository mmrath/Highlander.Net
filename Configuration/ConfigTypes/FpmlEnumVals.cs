﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 
namespace Orion.Configuration {
    using System.Xml.Serialization;


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("schemeDefinitions", Namespace = "", IsNullable = false)]
    public partial class FpmlSchemeDefinitions
    {

        private FpmlScheme[] schemeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("scheme", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public FpmlScheme[] scheme
        {
            get
            {
                return this.schemeField;
            }
            set
            {
                this.schemeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FpmlScheme {
        
        private FpmlSchemeValue[] schemeValuesField;
        
        private string nameField;
        
        private string uriField;
        
        private string canUriField;
        
        private string versionField;
        
        private string urlField;
        
        private string fileNameField;
        
        private string typeField;
        
        private string sourceField;
        
        private string externalField;
        
        private string futureuriField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        [System.Xml.Serialization.XmlArrayItemAttribute("schemeValue", Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
        public FpmlSchemeValue[] schemeValues {
            get {
                return this.schemeValuesField;
            }
            set {
                this.schemeValuesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string uri {
            get {
                return this.uriField;
            }
            set {
                this.uriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string canUri {
            get {
                return this.canUriField;
            }
            set {
                this.canUriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string url {
            get {
                return this.urlField;
            }
            set {
                this.urlField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string fileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string source {
            get {
                return this.sourceField;
            }
            set {
                this.sourceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string external {
            get {
                return this.externalField;
            }
            set {
                this.externalField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string futureuri {
            get {
                return this.futureuriField;
            }
            set {
                this.futureuriField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FpmlSchemeValue {
        
        private string paragraphField;
        
        private string nameField;
        
        private string captionField;
        
        private string descriptionField;
        
        private string dcbField;
        
        private string schemeValueSourceField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string paragraph {
            get {
                return this.paragraphField;
            }
            set {
                this.paragraphField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string caption {
            get {
                return this.captionField;
            }
            set {
                this.captionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string dcb {
            get {
                return this.dcbField;
            }
            set {
                this.dcbField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string schemeValueSource {
            get {
                return this.schemeValueSourceField;
            }
            set {
                this.schemeValueSourceField = value;
            }
        }
    }
}
