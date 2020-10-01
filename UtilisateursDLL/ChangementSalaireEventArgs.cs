using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalariesDll
{
    /// <summary>
    /// Evénement survient sur changement de salaire
    /// </summary>
    public class ChangementSalaireEventArgs
    {
        private decimal _ancienSalaire;
        /// <summary>
        /// Ancien salaire
        /// </summary>
        public decimal AncienSalaire
        {
            get { return _ancienSalaire; }
            set { _ancienSalaire = value; }
        }
        private decimal _tauxAugmentation;
        /// <summary>
        /// Taux d'augmentation
        /// </summary>
        public decimal TauxAugmentation
        {
            get { return _tauxAugmentation; }
            set { _tauxAugmentation = value; }
        }
        /// <summary>
        /// Création d'un nouvel événement d'augmentation de salaire
        /// </summary>
        public ChangementSalaireEventArgs()
        { }
        /// <summary>
        /// Création d'un nouvel événement d'augmentation de salaire
        /// </summary>
        /// <param name="ancienSalaire">Ancien salaire</param>
        /// <param name="tauxAugmentation">Taux d'augmentation</param>
        public ChangementSalaireEventArgs(decimal ancienSalaire,decimal tauxAugmentation):this()
        {
            this.AncienSalaire = ancienSalaire;
            this.TauxAugmentation = tauxAugmentation;
        }
    }
}
