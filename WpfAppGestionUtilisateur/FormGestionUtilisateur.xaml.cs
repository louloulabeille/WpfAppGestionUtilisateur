using Microsoft.SqlServer.Server;
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
    /// Logique d'interaction pour GestionUtilisateur.xaml
    /// </summary>
    public partial class FormGestionUtilisateur : Window
    {

        public FormGestionUtilisateur()
        {
            InitializeComponent();
            DataBindingListBoxUtilisateurs();
            InitComboBoxRole();
        }

        #region Event
        private void EventButtonQuitterClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonAnnulerClick(object sender, RoutedEventArgs e)
        {
            Clear();
            TextBoxIdentifiant.Focus();
        }

        private void EventTextBoxIdentifiantLostFocus(object sender, RoutedEventArgs e)
        {
            VerifIdentifiant();
        }

        private void EventTextBoxIdentifiantLostFocus(object sender, TextChangedEventArgs e)
        {
            VerifIdentifiant();
        }

        private void EventPassWordBox(object sender, RoutedEventArgs e)
        {
            LabelError.Content = Utilisateur.IsMotPasseValide(PassWordBox1.Password) ? string.Empty : "Le mot de passe saisie est invalide." +
                "\nIl doit être supérieur à 5 caractères.";
        }

        private void EventCheckBoxCompteBloque(object sender, RoutedEventArgs e)
        {
            CheckBoxCompteBloque.Content = (bool)CheckBoxCompteBloque.IsChecked ? "Bloqué" : "Non bloqué";
        }

        /// <summary>
        /// charge dans la liste box l'utilisateur pour sa modification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventListBoxUtilisateursDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Utilisateurs listeUtil = new Utilisateurs();
            listeUtil.Load(new SauvegardeXML(), Paramètres.Default.path);
            Utilisateur u = new Utilisateur(ListBoxUtilisateurs.SelectedItem as Utilisateur);

            u = listeUtil.UtilisateurByMatricule(u.Identifiant);
            TextBoxIdentifiant.Text = u.Identifiant;
            TextBoxNom.Text = u.Nom;
            PassWordBox1.Password = u.MotDePasse;
            CheckBoxCompteBloque.IsChecked = u.CompteBloque;
            ComboBoxRole.SelectedItem = u.Role.Description;
        }
        /// <summary>
        /// event sauvegarde ou modification d'un utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventButtonSaveClick(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region methode de la fenêtre
        /// <summary>
        /// remplie la liste Box
        /// </summary>
        private void DataBindingListBoxUtilisateurs()
        {
            Utilisateurs listeUtil = new Utilisateurs();
            listeUtil.Load(new SauvegardeXML(), Paramètres.Default.path);
            ListBoxUtilisateurs.ItemsSource = listeUtil;
        }

        /// <summary>
        /// Efface toutes les données du formulaires
        /// </summary>
        private void Clear()
        {
            TextBoxIdentifiant.Clear();
            TextBoxNom.Clear();
            PassWordBox1.Clear();
            CheckBoxCompteBloque.IsChecked = false;
            ComboBoxRole.SelectedIndex = 0;
        }

        /// <summary>
        /// initialisation de la ComboBoxRole
        /// </summary>
        private void InitComboBoxRole ()
        {
            ComboBoxRole.Items.Add("Utilisateur");
            ComboBoxRole.Items.Add("Admin");
        }

        /// <summary>
        /// Verifie si identifiant est valide
        /// </summary>
        private void VerifIdentifiant ()
        {
            if (!Utilisateur.IsIdentifiantValide(TextBoxIdentifiant.Text))
            {
                TextBoxIdentifiant.BorderBrush = Brushes.Red;
                TextBoxIdentifiant.SelectionBrush = Brushes.Red;
            }
            else
            {
                TextBoxIdentifiant.BorderBrush = Brushes.Gray;
                TextBoxIdentifiant.SelectionBrush = Brushes.Blue;

            }
            /*LabelError.Content = Utilisateur.IsIdentifiantValide(TextBoxIdentifiant.Text) ? string.Empty : "L'idenfitiant saisie est invalide." +
                "\nIl doit être supérieur à 4 caractères et doit commencer par une lettre.";*/
        }

        private bool VerifFormulaire ()
        {
            if ( Utilisateur.IsIdentifiantValide(TextBoxIdentifiant.Text) && Utilisateur.IsMotPasseValide(PassWordBox1.Password) )
            {
                
            }
            return false;
        }

        #endregion

        private void EventTextBoxIdentifiantGotFocus(object sender, RoutedEventArgs e)
        {
            VerifIdentifiant();
        }
    }
}
