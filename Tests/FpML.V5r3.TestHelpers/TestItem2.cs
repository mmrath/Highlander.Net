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
namespace Orion.TestHelpers {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/TestItem2.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/TestItem2.xsd", IsNullable=false)]
    public partial class TestItem2 {
        
        private int idField;
        
        private string valueField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/TestItem2.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/TestItem2.xsd", IsNullable=false)]
    public partial class TestItem3 {
        
        private int idField;
        
        private string valueField;
        
        /// <remarks/>
        public int Id {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
            }
        }
        
        /// <remarks/>
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://tempuri.org/TestItem2.xsd")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://tempuri.org/TestItem2.xsd", IsNullable=false)]
    public partial class TestData {
        
        private string field1Field;
        
        private int field2Field;
        
        private string[] array1Field;
        
        private int[] array2Field;
        
        /// <remarks/>
        public string field1 {
            get {
                return this.field1Field;
            }
            set {
                this.field1Field = value;
            }
        }
        
        /// <remarks/>
        public int field2 {
            get {
                return this.field2Field;
            }
            set {
                this.field2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("array1")]
        public string[] array1 {
            get {
                return this.array1Field;
            }
            set {
                this.array1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("array2")]
        public int[] array2 {
            get {
                return this.array2Field;
            }
            set {
                this.array2Field = value;
            }
        }
    }
}
