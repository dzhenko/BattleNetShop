﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BattleNetShop.Data.Xml {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class XmlSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static XmlSettings defaultInstance = ((XmlSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new XmlSettings())));
        
        public static XmlSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\..\\..\\InitialData\\VendorExpensesInitialData.xml")]
        public string InitialXmlFileLocation {
            get {
                return ((string)(this["InitialXmlFileLocation"]));
            }
            set {
                this["InitialXmlFileLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\..\\..\\Reports\\XmlReports\\")]
        public string ReportDestinationFolderLocation {
            get {
                return ((string)(this["ReportDestinationFolderLocation"]));
            }
            set {
                this["ReportDestinationFolderLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("AllLocationsReport.xml")]
        public string ReportDestionationFileName {
            get {
                return ((string)(this["ReportDestionationFileName"]));
            }
            set {
                this["ReportDestionationFileName"] = value;
            }
        }
    }
}
