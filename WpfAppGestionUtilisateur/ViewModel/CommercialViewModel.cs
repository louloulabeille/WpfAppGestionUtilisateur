using SalariesDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppGestionUtilisateur.ViewModel
{
    class CommercialViewModel : SalarieViewModel
    {
        private readonly Commercial commercial;

        #region Constructeur
        public CommercialViewModel (Salarie s)
            :base(s)
        {
            
        } 
        #endregion

        #region Assesseur
        public Commercial Commercial
        {
            get
            {
                return this.commercial;
            }
        }

        public bool IsCommercial
        {
            get
            {
                return this.commercial is Commercial;
            }
        }

        public decimal Commission
        {
            get
            {
                return this.commercial.Commission;
            }
            set
            {
                this.commercial.Commission = value;
                RaisePropertyChanged("Commission");
            }
        }

        public decimal ChiffreAffaire
        {
            get
            {
                return this.commercial.Commission;
            }
            set
            {
                this.commercial.ChiffreAffaire = value;
                RaisePropertyChanged("ChiffreAffaire");
            }
        }
        #endregion

    }
}
