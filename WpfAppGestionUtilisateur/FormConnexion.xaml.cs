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
        public FormConnexion()
        {
            InitializeComponent();
            TextBoxIdentifiant.Focus();
        }

        /// <summary>
        /// methode de connexion
        /// verifie si l'utilisateur et le mot de passe sont valide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EventButtonConnexion(object sender, RoutedEventArgs e)
        {
           
        }

    }
}
