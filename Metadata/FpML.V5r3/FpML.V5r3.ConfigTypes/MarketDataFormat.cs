﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.0.30319.1.
// 
namespace Orion.V5r3.Configuration {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/MarketDataFormat.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/MarketDataFormat.xsd", IsNullable=false)]
    public partial class QRMarketDataMap {
        
        private MDSDictionaryType dictTypeField;
        
        private MDSRequestType requestTypeField;
        
        private bool disabledField;
        
        private int priorityField;
        
        private MDSProviderId sourceProviderField;
        
        private MDSProviderId targetProviderField;
        
        private string sourcePatternField;
        
        private string outputValueField;
        
        /// <remarks/>
        public MDSDictionaryType dictType {
            get {
                return this.dictTypeField;
            }
            set {
                this.dictTypeField = value;
            }
        }
        
        /// <remarks/>
        public MDSRequestType requestType {
            get {
                return this.requestTypeField;
            }
            set {
                this.requestTypeField = value;
            }
        }
        
        /// <remarks/>
        public bool disabled {
            get {
                return this.disabledField;
            }
            set {
                this.disabledField = value;
            }
        }
        
        /// <remarks/>
        public int priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }
        
        /// <remarks/>
        public MDSProviderId sourceProvider {
            get {
                return this.sourceProviderField;
            }
            set {
                this.sourceProviderField = value;
            }
        }
        
        /// <remarks/>
        public MDSProviderId targetProvider {
            get {
                return this.targetProviderField;
            }
            set {
                this.targetProviderField = value;
            }
        }
        
        /// <remarks/>
        public string sourcePattern {
            get {
                return this.sourcePatternField;
            }
            set {
                this.sourcePatternField = value;
            }
        }
        
        /// <remarks/>
        public string outputValue {
            get {
                return this.outputValueField;
            }
            set {
                this.outputValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/MarketDataFormat.xsd")]
    public enum MDSDictionaryType {
        
        /// <remarks/>
        Undefined,
        
        /// <remarks/>
        FieldName,
        
        /// <remarks/>
        Instrument,
        
        /// <remarks/>
        QuoteUnits,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/MarketDataFormat.xsd")]
    public enum MDSRequestType {
        
        /// <remarks/>
        Undefined,
        
        /// <remarks/>
        Current,
        
        /// <remarks/>
        History,
        
        /// <remarks/>
        Realtime,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/MarketDataFormat.xsd")]
    public enum MDSProviderId {
        
        /// <remarks/>
        Undefined,
        
        /// <remarks/>
        GlobalIB,
        
        /// <remarks/>
        Bloomberg,
        
        /// <remarks/>
        ReutersIDN,
        
        /// <remarks/>
        Simulator,
        
        /// <remarks/>
        nabCurveDb,
        
        /// <remarks/>
        ReutersDTS,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/MarketDataFormat.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/MarketDataFormat.xsd", IsNullable=false)]
    public partial class ProviderRuleSet {
        
        private MDSProviderId providerField;
        
        private QRMarketDataMap[] rulesField;
        
        /// <remarks/>
        public MDSProviderId provider {
            get {
                return this.providerField;
            }
            set {
                this.providerField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("rules")]
        public QRMarketDataMap[] rules {
            get {
                return this.rulesField;
            }
            set {
                this.rulesField = value;
            }
        }
    }
}
