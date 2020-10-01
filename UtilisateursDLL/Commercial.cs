using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SalariesDll
{
    /// <summary>
    /// Type Commercial 
    /// </summary>
    public class Commercial : Salarie
    {
        private decimal _chiffreAffaire;
        private decimal _commission;
        /// <summary>
        /// Chiffre d'affaire pour calcul de la rémunération
        /// </summary>
        public decimal ChiffreAffaire
        {
            get { return (this._chiffreAffaire); }
            set { this._chiffreAffaire = value; }
        }
        /// <summary>
        /// Commpission pour calcul de la rémunération
        /// </summary>
        public decimal Commission
        {
            get { return (this._commission); }
            set { this._commission = value; }
        }

        /// <summary>
        /// Salaire net après déduction des charges sociales
        /// </summary>
        override public decimal SalaireNet
        {
            get
            {
                return base.SalaireNet + (this._chiffreAffaire * this._commission);
            }
        }
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Commercial()
            : base()
        {

        }

        /// <summary>
        /// Constructeur d'initialisation
        /// </summary>
        public Commercial(string nom, string prenom, string matricule, decimal chiffreAffaire, decimal commission)
            : base(nom, prenom, matricule)
        {
            this.ChiffreAffaire = chiffreAffaire;
            this.Commission = commission;
        }
        /// <summary>
        /// Constructeur de recopie 
        /// </summary>
        /// <param name="commercial"></param>
        public Commercial(Commercial commercial)
            : base(commercial)
        {

            this.ChiffreAffaire = commercial.ChiffreAffaire;
            this.Commission = commercial.Commission;
        }


        /// <summary>
        /// Renvoie une chaine avec la liste des valeurs des propriétés
        /// </summary>
        public override string ToString()
        {
            return (base.ToString() + string.Format(CultureInfo.CurrentCulture, @";{0};{1}", this._chiffreAffaire, this._commission));
        }


    }
}
