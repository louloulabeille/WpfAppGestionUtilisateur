using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Globalization;
using Utilitaires;

namespace SalariesDll
{
    /// <summary>
    /// 
    /// </summary>
     [Serializable()]
    public class Roles : HashSet<Role>,ICollectionMetier
    {
         /// <summary>
        /// Constructeur par défaut uniquement à usage du Sérialiseur 
        /// </summary>
        public Roles() : base() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected Roles(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// Extraire un utilisateur par son ID
        /// </summary>
        /// <param name="identifiant"></param>
        /// <returns></returns>
        public Role RechercherRole(string identifiant)
        {
            foreach (Role utilisateur in this)
            {
                if (utilisateur.Identifiant == identifiant)
                {
                    return utilisateur;
                }
            }
            return null;
        }
        /// <summary>
        /// Ajout d'un nouvel utilisateur 
        /// Se substitue à la méthode de base
        /// Pour vérifier unicité de l'identifiant
        /// </summary>
        /// <param name="role"></param>
        /// <exception cref="ApplicationException"> Utilisateur_001 lorsque le salarie existe déjà</exception>
        /// 
        new public void Add(Role role)
        {
            foreach (Role item in this)
            {
                if (role.Equals(item))
                {
                    throw new ApplicationException(string.Format(CultureInfo.CurrentCulture, "Ce rôle {0} existe déjà",role.Identifiant));

                }
            }
            base.Add(role);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sauvegarde"></param>
        /// <param name="pathRepData"></param>
        public void Save(ISauvegarde sauvegarde, string pathRepData)
        {
            sauvegarde.Save(pathRepData, this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sauvegarde"></param>
        /// <param name="pathRepData"></param>
        public void Load(ISauvegarde sauvegarde, string pathRepData)
        {
            this.SymmetricExceptWith((Roles)sauvegarde.Load(pathRepData, this.GetType()));
        }
    }
}
