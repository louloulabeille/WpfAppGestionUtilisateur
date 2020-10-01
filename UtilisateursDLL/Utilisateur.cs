using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.IO;
using System.Collections;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;

namespace SalariesDll
{
 
    [Serializable()]
    public class Utilisateur
    {
        #region Champs
        private string _identifiant;
        private string _nom;
        private string _motDePasse;
        private bool _compteBloque=false;
        private int _nombreEchecsConsecutifs;
        private DateTime _dateDerniereConnexion;
        private Role _role;


        public int NombreEchecsConsecutifs
        {
            get { return _nombreEchecsConsecutifs; }
            set { _nombreEchecsConsecutifs = value; }
        }
        
      
        internal DateTime DateDerniereConnexion
        {
            get { return _dateDerniereConnexion; }
            set { _dateDerniereConnexion = value; }
        }
        
        #endregion

        #region Propriétés
        public bool CompteBloque
        {
            get { return _compteBloque; }
            set { _compteBloque = value; }
        }

      

        public string Identifiant
        {
            get { return this._identifiant; }
            set
            {
                if (IsIdentifiantValide(value)) _identifiant = value; 
                else 
                    throw(new ApplicationException("Identifiant non valide"));
            }
        }

        public string Nom
        {
            get { return this._nom; }
            set { _nom = value; }
        }

        public string MotDePasse
        {
            get { return this._motDePasse; }
            set 
            {
              if(IsMotPasseValide(value)) _motDePasse = value;
              else throw (new ApplicationException("Mot de passe non valide"));
            }
        }
        public Role Role
        {
            get { return _role; }
            set { _role = value; }
        }
        #endregion
        /// <summary>
        ///
        /// Vérification validité du mot de passe
        /// </summary>
        /// <param name="motPasse"></param>
        /// <returns></returns>
        public static bool IsMotPasseValide(string motPasse)
        {
           
            if (motPasse == null || motPasse.Length < 5) return false;
            return true;
        }

        /// <summary>
        /// Vérification validité de l'identifiant
        /// </summary>
        /// <param name="motPasse"></param>
        /// <returns></returns>
        public static bool IsIdentifiantValide(string identifiant)
        {
            if (identifiant == null || identifiant.Length < 4 || !char.IsLetter(identifiant[0])) return false;
            return true;
        }
        /// <summary>
        /// Chaine representant l'objet instancié.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, @"{0};{1);{2};{3};{4};{5}", this._identifiant, this._nom, this._motDePasse,this._compteBloque,this._dateDerniereConnexion,this._nombreEchecsConsecutifs);
        }
        /// <summary>
        /// Compare deux objets pour déterminer l'égalité
        /// Même Identifiant
        /// </summary>
        /// <returns>Vrai si les deux objets sont égaux</returns>
        public override bool Equals(Object utilisateur)
        {
            Utilisateur utilisateurRef = utilisateur as Utilisateur;
            if (utilisateurRef == null) return false;
            else return (utilisateurRef.Identifiant == this.Identifiant);
           
        }
        /// <summary>
        /// Attribution d'un code de hachage
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (!string.IsNullOrEmpty(_identifiant)) ? _identifiant.GetHashCode() :0;
        }
        /// <summary>
        /// opérateur relationnel ==
        /// </summary>
        /// <param name="utilisateurA">Première Instance salarié</param>
        /// <param name="utilisateurB">Deuxième Instance salarié</param>
        /// <returns>Vrai si égaux</returns>
        public static bool operator ==(Utilisateur utilisateurA, Utilisateur utilisateurB)
        {
            if ((object)utilisateurA == null) return (object)utilisateurB == null;
            return utilisateurA.Equals(utilisateurB);
        }
        /// <summary>
        ///  opérateur relationnel !=
        /// </summary>
        /// <param name="utilisateurA">Première Instance salarié</param>
        /// <param name="utilisateurB">Deuxième Instance salarié</param>
        /// <returns>Vrai si différents</returns>
        public static bool operator !=(Utilisateur utilisateurA, Utilisateur utilisateurB)
        {
            if ((object)utilisateurA == null) return (object)utilisateurB != null;
            return !utilisateurA.Equals(utilisateurB);
        }
        /// <summary>
        /// Une des règles de conception veut que l'on modifie la méthode GetHashCode
        /// Si la méthode Equals est modifiée
        /// </summary>
        /// <returns></returns>
       
        #region Constructeurs
        public Utilisateur()
        { 
        }
        /// <summary>
        /// Création d'un utilisateur dans un rôle
        /// </summary>
        /// <param name="role">Rôle applicatif</param>
        public Utilisateur(Role role):this()
        {
            this.Role = role;
        }
        /// <summary>
        /// Création d'initialisation d'un uutilisateur 
        /// </summary>
        /// <param name="identifiant">Identifiant</param>
        /// <param name="nom">Nom</param>
        /// <param name="motDePasse">Mot de passe</param>
        public Utilisateur(string identifiant, string nom, string motDePasse):this()
        {
            this.Identifiant = identifiant;
            this.Nom = nom;
            this.MotDePasse = motDePasse;
      
        }
        /// <summary>
        /// Constructeur de recopie d'un utiliasteur
        /// </summary>
        /// <param name="utilisateur"></param>
        public Utilisateur(Utilisateur utilisateur)
            : this()
        {
            this.Identifiant = utilisateur.Identifiant;
            this.Nom = utilisateur.Nom;
            this.MotDePasse = utilisateur.MotDePasse;
            

        }

        public ConnectionResult Connecter(string motDePasse)
        {
           
            if (this.MotDePasse == motDePasse)
            {
                this.NombreEchecsConsecutifs = 0;
                this._dateDerniereConnexion = DateTime.Now;
                return ConnectionResult.Connecté;
            }
            this._nombreEchecsConsecutifs++;
            return (this.NombreEchecsConsecutifs > 3) ? ConnectionResult.CompteBloqué : ConnectionResult.MotPasseInvalide;

        }
        #endregion

    }

   

}
