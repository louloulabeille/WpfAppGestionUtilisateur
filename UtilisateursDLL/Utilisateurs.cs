using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Utilitaires;
namespace SalariesDll
{
    /// <summary>
    /// Utilisateurs de l'application
    /// </summary>
    [Serializable]
    public class Utilisateurs : HashSet<Utilisateur>,ICollectionMetier
    {
        /// <summary>
        /// Constructeur par défaut 
        /// </summary>
        public Utilisateurs() : base() { }
        /// <summary>
        /// Extraire un utilisateur par son matricule
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Utilisateur UtilisateurByMatricule(string identifiant)
        {
            foreach (Utilisateur utilisateur in this)
            {
                if (utilisateur.Identifiant == identifiant)
                {
                    return utilisateur;
                }
            }
            return null;
        }
        public IEnumerable<Utilisateur> UtilisateurByDebutNom(string debutNom)
        {
            HashSet<Utilisateur> liste = new HashSet<Utilisateur>();
            foreach (Utilisateur utilisateur in this)
            {
                if (utilisateur.Nom.StartsWith(debutNom))
                {
                    liste.Add(utilisateur);
                }
            }
            return liste;
        }
        /// <summary>
        /// Ajout d'un nouvel utilisateur 
        /// Se substitue à la méthode de base
        /// Pour vérifier unicité de l'identifiant
        /// </summary>
        /// <param name="salarie"></param>
        /// <exception cref="UtilisateurException"> Utilisateur_001 lorsque le salarie existe déjà</exception>
        new public void Add(Utilisateur utilisateur)
        {
            if (this.Contains(utilisateur))
            {
                    throw new ApplicationException(string.Format(CultureInfo.CurrentCulture, "L'utilisateur avec l'identifiant {0} existe déjà", utilisateur.Identifiant));
             }
            base.Add(utilisateur);
        }
        /// <summary>
        /// Sauvegarde
        /// </summary>
        /// <param name="sauvegarde"></param>
        /// <param name="pathRepData"></param>
        public void Save(ISauvegarde sauvegarde, string pathRepData)
        {
            sauvegarde.Save(pathRepData, this);
        }

        public void Load(ISauvegarde sauvegarde, string pathRepData)
        {
            this.SymmetricExceptWith((Utilisateurs)sauvegarde.Load(pathRepData, this.GetType()));
        }
    
    }
}
