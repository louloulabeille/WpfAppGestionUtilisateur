using SalariesDll;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        #region assesseur
        /// <summary>
        /// assesseur de validation de la fenêtre
        /// </summary>
        public bool ValidationId { get => _validationId; set => _validationId = value; }
        public bool ValidationPassWorld { get => _ValidationPassWorld; set => _ValidationPassWorld = value; }
        #endregion

        #region event
        /// <summary>
        /// event de test de l'identifant 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventTextBoxIdentifiant(object sender, RoutedEventArgs e)
        {
            ValidationId = false;
            if (!Utilisateur.IsIdentifiantValide(TextBoxIdentifiant.Text))
            {
                ValidationId = false;
                LabelError.Content = "L'identifiant saisie est incorrecte!\n Il doit être supérieur à 4 caractères et commencer par une lettre.";
            }
            else
            {
                ValidationId = true;
                PassworldBoxMotDePasse.Focus();
            }
        }

        /// <summary>
        /// event de test du mot de passe
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                LabelError.Content = "Le mot de passe saisie n'est pas correcte.\n Il doit être supérieur à 5 caractères.";
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

                listUtil.Load(loadUtil, Paramètres.Default.path);

                util = listUtil.UtilisateurByMatricule(TextBoxIdentifiant.Text);
                if ( util == null )
                {
                    LabelError.Content = "Le compte utilisateur n'existe pas \nou le mot de passe est incorrecte.";
                }
                else
                {
                    ConnectionResult connexionResult = util.Connecter(PassworldBoxMotDePasse.Password);
                    Connexion._utilisateurconnecte = util;
                    switch (connexionResult)
                    {
                        case ConnectionResult.Connecté:
                            Roles r = new Roles();
                            Role roleUtil = new Role();
                            r.Load(new SauvegardeXML(), Paramètres.Default.path);
                            roleUtil = r.RechercherRole(util.Identifiant);
                            util.Role = roleUtil;
                            DialogResult = true;
                            break;
                        case ConnectionResult.CompteBloqué:
                            LabelError.Content = "Le compte utilisateur est bloqué. Veuillez contacter l'administrateur.";
                            ButtonAnnuler.Focus();
                            break;
                        case ConnectionResult.MotPasseInvalide:
                            LabelError.Content = $"Le compte utilisateur n'existe pas \nou le mot de passe est incorrecte.\nNombre d'échec{util.NombreEchecsConsecutifs}";
                            TextBoxIdentifiant.Focus();
                            if (util.NombreEchecsConsecutifs == 3)
                            {
                                util.CompteBloque = true;
                            }
                            listUtil.Remove(util);
                            listUtil.Add(util);
                            listUtil.Save(loadUtil, Paramètres.Default.path);
                            PassworldBoxMotDePasse.Focus();
                            break;
                    }
                }
                
            }
            else
            {
                if (!ValidationId) TextBoxIdentifiant.Focus();
                if (!ValidationPassWorld) PassworldBoxMotDePasse.Focus();
            }
        }
        #endregion
    }
}
