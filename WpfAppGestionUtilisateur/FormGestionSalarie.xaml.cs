﻿using SalariesDll;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Text.RegularExpressions;
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
            InitCalendar();
            //IsVerifChamp();
            TextBoxMatricule.Focus();

        }

        #region Event

        /// <summary>
        /// enlève les espaces dans les champs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            TrimTexBox(sender);
        }

        /// <summary>
        /// re - initilise la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventButtonAnnulerClick(object sender, RoutedEventArgs e)
        {
            Clear();
        }

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
            IsVerifDecimal(e);
            //IsVerifSaisieDecimal(sender, e);

        }

        /// <summary>
        /// event d'enregistrement ou de modification d'un salarié
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventButtonSauvegarderClick(object sender, RoutedEventArgs e)
        {
            SauvegardeSalarie();
        }

        /// <summary>
        /// event de copie entre la liste box et le reste du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventListBoxSalarieMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChargeSalarie(sender);
        }

        /// <summary>
        /// event de quitter la fenetre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventButtonQuitterClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// recharge la liste Box en prenant en argument le nom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventTextBoxNomRechercheTextChanged(object sender, TextChangedEventArgs e)
        {
            InitListBoxSalarie(TextBoxNomRecherche.Text.Trim());
        }

        /// <summary>
        /// event de verification des décimaux
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventTextBoxDecimalLostFocus(object sender, RoutedEventArgs e)
        {
            IsVerifSaisieDecimal(sender,e);
        }
        #endregion

        #region méthode de classe d'intialisation
        /// <summary>
        /// intialise le calendrier
        /// </summary>
        private void InitCalendar ()
        {
            DatePickerDateDeNaissance.DisplayDateStart = new DateTime(1900, 01, 01);
            DatePickerDateDeNaissance.DisplayDateEnd = DateTime.Now.AddYears(-15);
            DatePickerDateDeNaissance.DisplayDate = DateTime.Now.AddYears(-25);
        }

        /// <summary>
        /// méthode de remplissage de la liste des salaries
        /// </summary>
        /// <param name="nomSalarie">nom ou une partie du salarié / empty ou null charge tous les salariés</param>
        private void InitListBoxSalarie(string nomSalarie)
        {
            Salaries listeSalarie = new Salaries();
            StringBuilder sB = new StringBuilder(Paramètres.Default.path);
            sB.Append($@"\{listeSalarie.GetType().FullName}.Xml");

            if (File.Exists(sB.ToString()))
            {
                listeSalarie.Load(new SauvegardeXML(), Paramètres.Default.path);
                if (string.IsNullOrEmpty(nomSalarie))
                {
                    ListBoxSalarie.ItemsSource = listeSalarie;
                }
                else
                {
                    ListBoxSalarie.ItemsSource = listeSalarie.SalariesNomCommencePar(nomSalarie);
                }
            } 
        }

        #endregion

        #region méthode de classe

        /// <summary>
        ///  enlève les espaces dans les text box
        ///  avant et après
        /// </summary>
        /// <param name="sender"></param>
        private void TrimTexBox(object sender )
        {
            TextBox t = sender as TextBox;
            t.Text = t.Text.Trim();
        }

        /// <summary>
        /// récupère le salarie et l'affiche dans le formulaire
        /// </summary>
        private void ChargeSalarie (object sender) 
        {
            ListBox list = sender as ListBox;
            if (list.SelectedItem != null)
            {
                Salarie s = list.SelectedItem as Salarie;

                if (s is Commercial c)
                {
                    CheckBoxCommercial.IsChecked = true;
                    TextBoxChiffreDAffaire.Text = c.ChiffreAffaire.ToString();
                    TextBoxCommission.Text = c.Commission.ToString();
                }

                TextBoxMatricule.Text = s.Matricule.ToString();
                TextBoxNom.Text = s.Nom.ToString();
                TextBoxPrenom.Text = s.Prenom.ToString();
                TextBoxSalaireBrut.Text = s.SalaireBrut.ToString();
                TextBoxSalaireNet.Text = s.SalaireNet.ToString();
                TextBoxTauxCotisationSociale.Text = s.TauxCS.ToString();
                DatePickerDateDeNaissance.SelectedDate = s.DateNaissance;
            }
            
        }

        /// <summary>
        /// sauvegarde ou modifie le salarié
        /// </summary>
        private void SauvegardeSalarie()
        {

            if (IsVerifChamp())
            {
                Salaries listeSal = new Salaries();

                StringBuilder sB = new StringBuilder(Paramètres.Default.path);
                sB.Append($@"\{listeSal.GetType().FullName}.Xml");

                Salarie s = new Salarie(TextBoxNom.Text.Trim(), TextBoxPrenom.Text.Trim(), TextBoxMatricule.Text.Trim())
                {
                    DateNaissance = (DateTime)(DatePickerDateDeNaissance.SelectedDate),
                    SalaireBrut = decimal.Parse(TextBoxSalaireBrut.Text.Trim()),
                    TauxCS = decimal.Parse(TextBoxTauxCotisationSociale.Text.Trim()),
                };
                s = (bool)CheckBoxCommercial.IsChecked ? new Commercial(s) : s;

                if (s is Commercial c)
                {
                    c.ChiffreAffaire = decimal.Parse(TextBoxChiffreDAffaire.Text.Trim());
                    c.Commission = decimal.Parse(TextBoxCommission.Text.Trim());
                    s = c;
                }

                if (File.Exists(sB.ToString()))
                {
                    listeSal.Load(new SauvegardeXML(), Paramètres.Default.path);
                }

                if (listeSal.Contains(s)) // modification
                {
                    listeSal.Remove(s);
                }
                listeSal.Add(s);

                listeSal.Save(new SauvegardeXML(), Paramètres.Default.path);
                Clear();
                InitListBoxSalarie(string.Empty);
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

        /// <summary>
        /// verifie la saisie des décimaux à la sortie
        /// du textbox
        /// </summary>
        /// <param name="sender"></param>
        private void IsVerifSaisieDecimal (object sender , RoutedEventArgs e)
        {
            string pattern = @"^[0-9]+[,]?[0-9]{0,}$";
            Regex rGX = new Regex(pattern);
            TextBox t = sender as TextBox;
            TrimTexBox(sender);
            
            if ( !rGX.IsMatch(t.Text) )
            {
                t.Text = String.Empty;
            }
        }
        /// <summary>
        /// arrete la saisie quand il rencontre une lettre ou autre
        /// </summary>
        /// <param name="e"></param>
        private void IsVerifDecimal (TextCompositionEventArgs e)
        {
            /*e.Handled = e.Text.Any(x => char.IsLetter(x)) ? true : false;
            e.Handled = e.Text.Any(x => x=='.') ? true : false;*/
            e.Handled = !e.Text.All( (x => char.IsNumber(x)| x == ',') ) ;
        }

        /// <summary>
        /// vérifie les champs et renvoie un bool
        /// </summary>
        /// <returns></returns>
        private bool IsVerifChamp()
        {
            if ( !Salarie.IsMatriculeValide(TextBoxMatricule.Text.Trim()) )
            {
                ErreurSaisie(TextBoxMatricule);
                return false;
            }

            if ( !Salarie.IsNomPrenomValide(TextBoxNom.Text.Trim()) )
            {
                ErreurSaisie(TextBoxNom);
                return false;
            }

            if ( !Salarie.IsNomPrenomValide(TextBoxPrenom.Text.Trim()))
            {
                ErreurSaisie(TextBoxPrenom);
                return false;
            }

            if (!Salarie.IsDateNaissanceValide(DatePickerDateDeNaissance.SelectedDate.Value))
            {
                ErreurSaisie(DatePickerDateDeNaissance);
                return false;
            }
            if ( string.IsNullOrEmpty(TextBoxSalaireBrut.Text.Trim()) | string.IsNullOrEmpty(TextBoxTauxCotisationSociale.Text.Trim()))
            {
                return false;
            }
            if ( (bool)CheckBoxCommercial.IsChecked & (string.IsNullOrEmpty(TextBoxCommission.Text.Trim()) | string.IsNullOrEmpty(TextBoxChiffreDAffaire.Text.Trim() ) ))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// efface la fenêtre
        /// </summary>
        private void Clear()
        {
            TextBoxMatricule.Clear();
            TextBoxNom.Clear();
            TextBoxPrenom.Clear();
            TextBoxSalaireBrut.Clear();
            TextBoxSalaireNet.Clear();
            TextBoxTauxCotisationSociale.Clear();
            DatePickerDateDeNaissance.Text=string.Empty;
            CheckBoxCommercial.IsChecked = false;
            TextBoxCommission.Clear();
            TextBoxChiffreDAffaire.Clear();

            TextBoxMatricule.Focus();
        }
        #endregion

        
    }
}
