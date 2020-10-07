using SalariesDll;
using SalariesVueDll;
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
    /// Logique d'interaction pour SalariesDataBinding.xaml
    /// </summary>
    public partial class SalariesDataBinding : Window
    {
        public SalariesDataBinding()
        {
            SalarieVue sV = new SalarieVue();
            sV.ListSalaries.Load(new SauvegardeXML(), Paramètres.Default.path);

            InitializeComponent();
            
            DataContext = sV;
        }
    }
}
