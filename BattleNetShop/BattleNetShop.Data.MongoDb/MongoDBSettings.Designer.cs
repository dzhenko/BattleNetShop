﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BattleNetShop.Data.MongoDb {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class MongoDBSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static MongoDBSettings defaultInstance = ((MongoDBSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new MongoDBSettings())));
        
        public static MongoDBSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mongodb://admin:qwerty@ds053109.mongolab.com:53109/")]
        public string MongoDBCloudConnection {
            get {
                return ((string)(this["MongoDBCloudConnection"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("BattleNetShop")]
        public string MongoDBName {
            get {
                return ((string)(this["MongoDBName"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mongodb://localhost/battleNetShopDb")]
        public string MongoDBLocalConnection {
            get {
                return ((string)(this["MongoDBLocalConnection"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mongodb://localhost/battleNetShopDb")]
        public string MongoDBConnectionString {
            get {
                return ((string)(this["MongoDBConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("localhost")]
        public string MongoDBAddress {
            get {
                return ((string)(this["MongoDBAddress"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("27017")]
        public int MongoDBPort {
            get {
                return ((int)(this["MongoDBPort"]));
            }
        }
    }
}
