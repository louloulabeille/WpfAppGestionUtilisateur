using SalariesDll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
    /// Logique d'interaction pour FormGestionSalarie.xaml
    /// </summary>
    public partial class FormGestionSalarie : Window
    {
        public FormGestionSalarie()
        {
            InitializeComponent();
            InitListBoxSalarie(string.Empty);

        }

        #region Event
        /// <summary>
        /// event de de verification de textBox 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventTextBoxVerificationTextChanged(object sender, TextChangedEventArgs e)
        {
            IsVerifChampSaisie(sender);

        }
        /// <summary>
        /// event d'interdiction de la saisie de lettres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventTextBoxDecimalPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text.Any(x => char.IsLetter(x)) ? true : false;
        }
        #endregion

        #region méthode de classe
        /// <summary>
        /// méthode de remplissage de la liste des salaries
        /// pas top
        /// </summary>
        /// <param name="nomSalarie">nom ou une partie du salarié</param>
        private void InitListBoxSalarie(string nomSalarie)
        {
            Salaries listeSalarie = new Salaries();
            StringBuilder sB = new StringBuilder(Paramètres.Default.path);
            sB.Append($"{listeSalarie.GetType().FullName}.Xml");

            if (File.Exists(sB.ToString()))
            {
                listeSalarie.Load(new SauvegardeXML(), Paramètres.Default.path);
                if (string.IsNullOrEmpty(nomSalarie))
                {
                    ListBoxSalarie.ItemsSource = listeSalarie;
                }
                else
                {
                    listeSalarie.SalariesNomCommencePar(nomSalarie);
                    ListBoxSalarie.ItemsSource = listeSalarie;
                }
            } 
            
        }

        /// <summary>
        /// méthode de vérification de certains champ saisie
        /// </summary>
        /// <param name="sender">object appelant</param>
        private void IsVerifChampSaisie(object sender)
        {
            TextBox t = sender as TextBox;
            t.BorderBrush = Brushes.Gray;
            t.SelectionBrush = Brushes.Gray;

            switch (t.Name)
            {
                case "TextBoxMatricule":
                    if ( !Salarie.IsMatriculeValide(t.Text.Trim()) ) ErreurSaisie(sender);
                    break;
                case "TextBoxNom":
                case "TextBoxPrenom":
                    if ( !Salarie.IsNomPrenomValide(t.Text.Trim()) ) ErreurSaisie(sender);
                    break;
                case "TextBoxSalaireBrut":

                    break;
            }
            
        }

        /// <summary>
        /// change la couleur de la bordure en cas erreur
        /// ne marche pas très bien
        /// </summary>
        /// <param name="sender"></param>
        private void ErreurSaisie( object sender )
        {
            TextBox t = sender as TextBox;
            t.BorderBrush = Brushes.Red;
            t.SelectionBrush = Brushes.Red;
        }


        private void IsVerifDecimal ( object sender )
        {
            TextBox t = sender as TextBox;

        }



        #endregion


    }
}
