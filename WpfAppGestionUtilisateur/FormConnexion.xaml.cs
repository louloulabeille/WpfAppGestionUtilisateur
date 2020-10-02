using SalariesDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Utilitaires;

namespace WpfAppGestionUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour FormConnexion.xaml
    /// </summary>
    public partial class FormConnexion : Window
    {
        private bool _validationId = false;
        private bool _ValidationPassWorld = false;

        /// <summary>
        /// constructeur du formulaire modal
        /// </summary>
        public FormConnexion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// assesseur de validation de la fenêtre
        /// </summary>
        public bool ValidationId { get => _validationId; set => _validationId = value; }
        public bool ValidationPassWorld { get => _ValidationPassWorld; set => _ValidationPassWorld = value; }

        private void EventTextBoxIdentifiant(object sender, RoutedEventArgs e)
        {
            ValidationId = false;
            if (!Utilisateur.IsIdentifiantValide(TextBoxIdentifiant.Text))
            {
                ValidationId = false;
            }
            else
            {
                ValidationId = true;
                PassworldBoxMotDePasse.Focus();
            }
        }

        private void EventVerifPassWorld(object sender, RoutedEventArgs e)
        {
            ValidationPassWorld = false;
            if ( Utilisateur.IsMotPasseValide(PassworldBoxMotDePasse.Password) )
            {
                ValidationPassWorld = true;
                ButtonValider.Focus();
            }
            else
            {
                ValidationPassWorld = false;
            }
        }

        /// <summary>
        ///méthode de test de connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventValidationConnexion(object sender, RoutedEventArgs e)
        {
            if  ( ValidationPassWorld && ValidationId )
            {
                Utilisateurs listUtil = new Utilisateurs();
                SauvegardeXML loadUtil = new SauvegardeXML();
                Utilisateur util = new Utilisateur();

                listUtil.Load(loadUtil, "Donnee");

                util = listUtil.UtilisateurByMatricule(TextBoxIdentifiant.Text);
                ConnectionResult connexionResult = util.Connecter(PassworldBoxMotDePasse.Password);
                switch (connexionResult)
                {
                    case ConnectionResult.Connecté:
                        Roles r = new Roles();
                        Role roleUtil = new Role();
                        r.Load(new SauvegardeXML(), "Donnee");
                        roleUtil = r.RechercherRole(util.Identifiant);
                        util.Role = roleUtil;

                        Connexion._utilisateurconnecte = util;
                        break;
                    case ConnectionResult.CompteBloqué:
                        break;
                    case ConnectionResult.MotPasseInvalide:
                        break;
                }
            }
            else
            {
                if (!ValidationId) TextBoxIdentifiant.Focus();
                if (!ValidationPassWorld) PassworldBoxMotDePasse.Focus();
            }
        }
    }
}
