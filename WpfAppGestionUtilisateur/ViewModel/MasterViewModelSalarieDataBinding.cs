using SalariesDll;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
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
        private ICommand changeCommand;


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

            this.collectionView = CollectionViewSource.GetDefaultView(this._listSalarie);
            if (this.collectionView == null) { throw new NullReferenceException("collectionView"); };

            this.collectionView.CurrentChanged += new EventHandler(this.OnCollectionViewCurrentChanged);

            InitClasseVue();
        }
        #endregion

        #region assesseur

        public ICommand AddCommand
        {
            get
            {
                if (this.addCommand != null)
                {
                    this.addCommand = new RelayCommand(() => this.AddSalarie());
                }
                return this.addCommand;
            }
        }

        public ICommand ChangeCommand
        {
            get
            {
                if (this.changeCommand != null)
                {
                    this.changeCommand = new RelayCommand(() => this.ChangeSalarie());
                }
                return this.changeCommand;
            }
        }


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

        /// <summary>
        /// assesseur retourne la personne sélectionner de la collections
        /// </summary
        public SalarieViewModel SelectedSalarie
        {
            get { return this.collectionView.CurrentItem as SalarieViewModel; }
        }
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

        /// <summary>
        /// méthode pour event qui appelle un autre event pour le changement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCollectionViewCurrentChanged(object sender, EventArgs e) 
        {
            RaisePropertyChanged("SelectedSalarie");
        }

        private void AddSalarie ()
        {
            Salarie s = new Salarie()
            {
                Matricule = "Matricule",

            };
            this.db.Add(s);
        }

        private void ChangeSalarie()
        {
            Salarie s = new Salarie()
            {
                Matricule = "Matricule",

            };
            this.db.Remove(s);
            this.db.Add(s);
        }

        #endregion

    }
}
