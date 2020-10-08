using SalariesDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace WpfAppGestionUtilisateur.ViewModel
{
    public class SalarieViewModel : ViewModelBase
    {
        private readonly Salarie salarie;

        #region
        public SalarieViewModel(Salarie item)
        {
            this.salarie = item ?? throw new NullReferenceException("Salarie");
        }
        #endregion

        #region assesseur
        public Salarie Salarie
        {
            get 
            {
                return this.Salarie;
            }
        }

        public string  Matricule
        {
            get
            {
                return this.salarie.Matricule;
            }
            set
            {
                this.salarie.Matricule = value;
                RaisePropertyChanged("Matricule");
            }
        }

        public string Nom
        {
            get
            {
                return this.salarie.Nom;
            }
            set
            {
                this.salarie.Prenom = value;
                RaisePropertyChanged("Nom");
            }
        }

        public string Prenom
        {
            get
            {
                return this.salarie.Prenom;
            }
            set
            {
                this.salarie.Prenom = value;
                RaisePropertyChanged("Prenom");
            }
        }

        public decimal SalaireBrut
        {
            get
            {
                return this.salarie.SalaireBrut;
            }
            set
            {
                this.salarie.SalaireBrut = value;
                RaisePropertyChanged("SalaireBrut");
            }
        }

        public decimal SalaireNet
        {
            get
            {
                return this.salarie.SalaireNet;
            }
        }

        public decimal TauxCS
        {
            get
            {
                return this.salarie.TauxCS;
            }
            set
            {
                this.salarie.TauxCS = value;
                RaisePropertyChanged("TauxCS");
            }
        }

        public DateTime DateNaissance
        {
            get
            {
                return this.salarie.DateNaissance;
            }
            set
            {
                this.salarie.DateNaissance = value;
                RaisePropertyChanged("DateNaissance");
            }
        }

        public bool IsCommercial
        {
            get
            {
                return salarie is Commercial;
            }
        }
        #endregion
    }
}
