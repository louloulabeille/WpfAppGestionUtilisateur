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
            //InitApplication();
        }

        private void EventClicButonConnexion(object sender, RoutedEventArgs e)
        {
            //ouverture de la fenetre connexion
            FormConnexion fC = new FormConnexion();
            Nullable<Boolean> result = fC.ShowDialog();

        }

        private void InitApplication()
        {
            try
            {
                Utilisateurs listeUtil = new Utilisateurs();
                Utilisateur u1 = new Utilisateur("A178APE", "loulou", "azerty");
                u1.CompteBloque = false;

                Role r1 = new Role();
                r1.Identifiant = "A178APE";
                r1.Description = "Admin";

                Roles listRole = new Roles();
                listRole.Add(r1);
                u1.Role = r1;

                listeUtil.Add(u1);

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
    }
}
