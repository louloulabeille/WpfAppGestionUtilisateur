﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfAppGestionUtilisateur {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.7.0.0")]
    internal sealed partial class Paramètres : global::System.Configuration.ApplicationSettingsBase {
        
        private static Paramètres defaultInstance = ((Paramètres)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Paramètres())));
        
        public static Paramètres Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Donnee")]
        public string path {
            get {
                return ((string)(this["path"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Le mot de passe ou l\'identifiant du compte n\'est pas valide.")]
        public string messageConnexion {
            get {
                return ((string)(this["messageConnexion"]));
            }
            set {
                this["messageConnexion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Gestion Salarié Connecté")]
        public string titreMdiConnecte {
            get {
                return ((string)(this["titreMdiConnecte"]));
            }
            set {
                this["titreMdiConnecte"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Gestion Salarié Compte Bloqué")]
        public string titreMdiBloque {
            get {
                return ((string)(this["titreMdiBloque"]));
            }
            set {
                this["titreMdiBloque"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Gestion Salarié Aucun compte Connecté")]
        public string titreMdiNonConnecte {
            get {
                return ((string)(this["titreMdiNonConnecte"]));
            }
            set {
                this["titreMdiNonConnecte"] = value;
            }
        }
    }
}
