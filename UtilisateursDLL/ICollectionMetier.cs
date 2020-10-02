using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitaires;

namespace SalariesDll
{ 
    interface ICollectionMetier
    {
        /// <summary>
        /// Sauvegarde des entités
        /// </summary>
        /// <param name="pathRepData">Chemin complet du dossier</param>
        /// <param name="sauvegarde">Mécanisme de sauvegarde</param>
        void Save(ISauvegarde sauvegarde, string pathRepData);
        /// <summary>
        /// Extraction des entités 
        /// </summary>
        /// <param name="pathRepData">Chemin complet du dossier</param>
        /// <param name="sauvegarde">Mécanisme de chargement</param>
        void Load(ISauvegarde sauvegarde, string pathRepData);
    }
}
