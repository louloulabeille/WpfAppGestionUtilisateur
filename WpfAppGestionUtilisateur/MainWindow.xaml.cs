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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utilitaires;

namespace WpfAppGestionUtilisateur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GestionButton();
            //InitApplication();
        }

        #region Event de la fenêtre

        /// <summary>
        /// event d'ouverture de la fenêtre de connexion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventClicButonConnexion(object sender, RoutedEventArgs e)
        {
            //ouverture de la fenetre connexion
            //FormConnexion fC = new FormConnexion();
            FormConnexion fC = new FormConnexion();
            StringBuilder sB = new StringBuilder(Title);
            if ( fC.ShowDialog().Equals(true) )
            {
                sB.Append($" Connecté");
                Title = sB.ToString();
            }
            else
            {
                if (Connexion._utilisateurconnecte != null | Connexion._utilisateurconnecte.CompteBloque)
                {
                    sB.Append($" Compte Bloqué");
                    Title = sB.ToString();
                }
            }
            GestionButton();
        }

        /// <summary>
        /// event d'ouverture de la gestion des utilisateurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventOpenUtilisateur(object sender, RoutedEventArgs e)
        {
            FormSingletonGestionUtilisateur fGU = FormSingletonGestionUtilisateur.Instance;
            fGU.Show();
        }
        #endregion


        #region méthode de la fenêtre

        private void GestionButton ()
        {
            if ( Connexion._utilisateurconnecte == null )
            {
                ButtonSalarie.IsEnabled = false;
                ButtonUtilisateur.IsEnabled = false;

            }
            else
            {
                if (Connexion._utilisateurconnecte.CompteBloque )
                {
                    ButtonSalarie.IsEnabled = false;
                    ButtonUtilisateur.IsEnabled = false;
                }
                else
                {
                    switch (Connexion._utilisateurconnecte.Role.Description.ToString())
                    {
                        case "Admin":
                            ButtonSalarie.IsEnabled = true;
                            ButtonUtilisateur.IsEnabled = true;
                            break;
                        case "Utilisateur":
                            ButtonSalarie.IsEnabled = true;
                            ButtonUtilisateur.IsEnabled = false;
                            break;
                        default:
                            ButtonSalarie.IsEnabled = false;
                            ButtonUtilisateur.IsEnabled = false;
                            break;
                    }
                }
            }
            
        }


        /// <summary>
        /// méthode d'initialisation
        /// </summary>
        private void InitApplication()
        {
            try
            {
                Utilisateurs listeUtil = new Utilisateurs();
                Utilisateur u1 = new Utilisateur("A178APE", "loulou", "azerty");
                Utilisateur u2 = new Utilisateur("B178APE", "Loulette", "azerty");
                u1.CompteBloque = false;
                u2.CompteBloque = false;

                Role r1 = new Role();
                Role r2 = new Role();
                r1.Identifiant = "A178APE";
                r1.Description = "Admin";
                r2.Identifiant = "B178APE";
                r2.Description = "Utilisateur";

                Roles listRole = new Roles();
                listRole.Add(r1);
                listRole.Add(r2);

                u1.Role = r1;
                u2.Role = r2;

                listeUtil.Add(u1);
                listeUtil.Add(u2);

                SauvegardeXML saveXml = new SauvegardeXML();
                listeUtil.Save(saveXml, "Donnee");
                listRole.Save(saveXml, "Donnee");

            }
            catch (ApplicationException aE)
            {
                Debug.WriteLine(aE.Message);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }
        #endregion


        #region singleton

        public class FormSingletonGestionUtilisateur : FormGestionUtilisateur
        {
            private static FormSingletonGestionUtilisateur _instance;

            private FormSingletonGestionUtilisateur() { }

            public static FormSingletonGestionUtilisateur Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = new FormSingletonGestionUtilisateur();
                    }
                    return _instance;
                }
            }

        }

        #endregion

    }
}
