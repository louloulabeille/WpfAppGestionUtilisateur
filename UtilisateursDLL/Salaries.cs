using System;
using System.Collections.Generic;
//using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

using System.Globalization;

namespace SalariesDll
{

    /// <summary>
    /// Ensemble des salaries
    /// </summary>
    /// 
    [Serializable]
    [XmlInclude(typeof(Commercial))]
    public class Salaries : HashSet<Salarie>, ICollectionMetier
    {
        /// <summary>
        /// Ajouter un salarié
        /// </summary>
        /// <param name="salarie"></param>
        new public void Add(Salarie salarie)
        {
            if (!this.Contains(salarie))
            { base.Add(salarie); }
        }
        /// <summary>
        /// Ajout une liste de salariés
        /// </summary>
        /// <param name="salaries">Tout type implémentant IEnumerable</param>
        public void AddRange(IEnumerable<Salarie> salaries)
        {
            foreach (Salarie item in salaries)
            {
                this.Add(item);
            }
        }
        ///<summary>
        /// Extrait le salarié ayant le numéro de matricule fourni en argument
        /// </summary>
        /// <param name="Matricule"></param>
        /// <returns>Un salarié ou null si non trouvé</returns>

        public Salarie ExtraireSalarie(string Matricule)
        {
            foreach (Salarie salarie in this)
            {
                if (salarie.Matricule == Matricule)
                {
                    return salarie;
                }
            }
            return null;
        }
        /// <summary>
        /// Extraction d'une liste spécialisée de salariés
        /// </summary>
        /// <param name="DebutNom">Critère de recherche</param>
        /// <returns>Objet Salaries vide si aucun salarié trouvé</returns>
        public Salaries SalariesNomCommencePar(string DebutNom)
        {
            Salaries salaries = new Salaries();
            foreach (Salarie item in this)
            {
                if (item.Nom.StartsWith(DebutNom))
                {
                    salaries.Add(item);

                }
            }

            return salaries;
        }

        /// <summary>
        /// Suppresion d'un salarié
        /// </summary>
        /// <param name="salarie">Objet salarié à supprimer</param>
        new public void Remove(Salarie salarie)
        {
            Salarie salrec = null;

            foreach (Salarie item in this)
            {
                if (item == salarie)
                {
                    salrec = item;
                    break;
                }
            }

            if (salrec != null) base.Remove(salrec);

        }
        /// <summary>
        /// Suppresion d'un salarié 
        /// </summary>
        /// <param name="matricule">Matricule du salarié</param>
        public void Remove(string matricule)
        {
            Salarie salrec = this.ExtraireSalarie(matricule);
            if (salrec != null) base.Remove(salrec);
        }

        public void Save(Utilitaires.ISauvegarde sauvegarde, string pathRepData)
        {
            sauvegarde.Save(pathRepData, this);
        }

        public void Load(Utilitaires.ISauvegarde sauvegarde, string pathRepData)
        {
            this.SymmetricExceptWith((Salaries)sauvegarde.Load(pathRepData, this.GetType()));
        }
    }
}

