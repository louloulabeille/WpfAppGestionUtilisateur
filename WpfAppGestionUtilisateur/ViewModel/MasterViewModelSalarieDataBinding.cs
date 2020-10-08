using SalariesDll;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml.Serialization;
using Utilitaires;
using WpfAppGestionUtilisateur;

namespace WpfAppGestionUtilisateur.ViewModel
{
    /// <summary>
    /// Class pour le data binding
    /// </summary>
    public class MasterViewModelSalarieDataBinding : ViewModelBase
    {
        private DateTime _dateDebut;
        private DateTime _dateFin;
        private readonly Salaries db;
        private ObservableCollection<SalarieViewModel> _listSalarie;
        private readonly ICollectionView collectionView;
        private ICommand addCommand;
        private ICommand removeCommand;
        private ICommand previousCommand;
        private ICommand nextCommand;


        #region constructeur
        /// <summary>
        /// constructeur de la classe de Master
        /// </summary>
        public MasterViewModelSalarieDataBinding (Salaries dataSalarie)
        {
            this.db = dataSalarie;
            this._listSalarie = new ObservableCollection<SalarieViewModel>();
            this.db.Load(new SauvegardeXML(), Paramètres.Default.path);

            foreach ( Salarie item in this.db)
            {
                SalarieViewModel sVM = new SalarieViewModel(item);
                this.ListSalarie.Add(sVM);
            }

            InitClasseVue();
        }
        #endregion

        #region assesseur

        /// <summary>
        /// assesseur date de debut du dateTimepicker
        /// </summary>
        public DateTime DateDebut 
        { 
            get => _dateDebut;
            set
            {
                _dateDebut = value;
                RaisePropertyChanged("DateDebut");
            }
        }

        /// <summary> date de fin de dateTimepicker
        /// assesseur 
        /// </summary>
        public DateTime DateFin
        {
            get => _dateFin;
            set
            {
                _dateFin = value;
                RaisePropertyChanged("DateFin");
            }
        }

        /// <summary>
        /// assesseur
        /// </summary>
        public ObservableCollection<SalarieViewModel> ListSalarie { get => _listSalarie; }
        #endregion

        #region méthode de classe
        /// <summary>
        /// méthode d'intilisation de classe
        /// </summary>
        private void InitClasseVue ()
        {
            DateDebut = new DateTime(1900, 1, 1);
            DateFin = DateTime.Today.AddYears(-15);
        }

        
        #endregion

    }
}
