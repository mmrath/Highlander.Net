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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/StressRuleFormat.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/StressRuleFormat.xsd", IsNullable=false)]
    public partial class StressRuleSet {
        
        private StressRule[] stressRulesField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("StressRules")]
        public StressRule[] StressRules {
            get {
                return this.stressRulesField;
            }
            set {
                this.stressRulesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/StressRuleFormat.xsd")]
    public partial class StressRule {
        
        private string stressIdField;
        
        private string ruleIdField;
        
        private bool disabledField;
        
        private int priorityField;
        
        private string filterExprField;
        
        private string updateExprField;
        
        /// <remarks/>
        public string StressId {
            get {
                return this.stressIdField;
            }
            set {
                this.stressIdField = value;
            }
        }
        
        /// <remarks/>
        public string RuleId {
            get {
                return this.ruleIdField;
            }
            set {
                this.ruleIdField = value;
            }
        }
        
        /// <remarks/>
        public bool Disabled {
            get {
                return this.disabledField;
            }
            set {
                this.disabledField = value;
            }
        }
        
        /// <remarks/>
        public int Priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }
        
        /// <remarks/>
        public string FilterExpr {
            get {
                return this.filterExprField;
            }
            set {
                this.filterExprField = value;
            }
        }
        
        /// <remarks/>
        public string UpdateExpr {
            get {
                return this.updateExprField;
            }
            set {
                this.updateExprField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/StressRuleFormat.xsd")]
    public partial class ScenarioRule {
        
        private string scenarioIdField;
        
        private string categoryField;
        
        private string ruleIdField;
        
        private string ruleDescField;
        
        private bool disabledField;
        
        private int priorityField;
        
        private string filterExprField;
        
        private string stressIdField;
        
        /// <remarks/>
        public string ScenarioId {
            get {
                return this.scenarioIdField;
            }
            set {
                this.scenarioIdField = value;
            }
        }
        
        /// <remarks/>
        public string Category {
            get {
                return this.categoryField;
            }
            set {
                this.categoryField = value;
            }
        }
        
        /// <remarks/>
        public string RuleId {
            get {
                return this.ruleIdField;
            }
            set {
                this.ruleIdField = value;
            }
        }
        
        /// <remarks/>
        public string RuleDesc {
            get {
                return this.ruleDescField;
            }
            set {
                this.ruleDescField = value;
            }
        }
        
        /// <remarks/>
        public bool Disabled {
            get {
                return this.disabledField;
            }
            set {
                this.disabledField = value;
            }
        }
        
        /// <remarks/>
        public int Priority {
            get {
                return this.priorityField;
            }
            set {
                this.priorityField = value;
            }
        }
        
        /// <remarks/>
        public string FilterExpr {
            get {
                return this.filterExprField;
            }
            set {
                this.filterExprField = value;
            }
        }
        
        /// <remarks/>
        public string StressId {
            get {
                return this.stressIdField;
            }
            set {
                this.stressIdField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.17929")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/StressRuleFormat.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/StressRuleFormat.xsd", IsNullable=false)]
    public partial class ScenarioRuleSet {
        
        private ScenarioRule[] scenarioRulesField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ScenarioRules")]
        public ScenarioRule[] ScenarioRules {
            get {
                return this.scenarioRulesField;
            }
            set {
                this.scenarioRulesField = value;
            }
        }
    }
}