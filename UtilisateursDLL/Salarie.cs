using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
[assembly: CLSCompliant(true)]
namespace SalariesDll
{
   
    /// <summary>
    /// Type Salarie
    /// </summary>
    [Serializable]
    public class Salarie
    {

        #region Champs privés

       
       
        private string _matricule;
        private string _nom = string.Empty;
        private string _prenom = string.Empty;
        private decimal _salaireBrut;
        private decimal _tauxCS;
        private DateTime _dateNaissance;
        #endregion

        #region Evenements
        /// <summary>
        /// Evenement sur changement de salaire brut
        /// </summary>
        public event EventHandler<ChangementSalaireEventArgs> ChangementSalaire;
        #endregion
        #region Propriétés
        
        /// <summary>
        /// 
        /// </summary>
        public string Matricule
        {
            get { return (this._matricule); }
            set
            {
                if (!IsMatriculeValide(value)) throw new ApplicationException(string.Format(CultureInfo.CurrentCulture, "Le matricule {0} n'est pas valide.", value));
                this._matricule = value;
            }
        }
        /// <summary>
        /// Nom du salarié
        /// Longueur comprise entre 3 et 30 caractères. Ni caractères spéciaux ni chiffres 
        /// </summary>
        public string Nom
        {
            get { return (this._nom); }
            set
            {
                if (!IsNomPrenomValide(value)) throw new ApplicationException(string.Format(CultureInfo.CurrentCulture, "Le nom {0} n'est pas valide.", value)); ;
                this._nom = string.Format(CultureInfo.CurrentCulture, "{0}{1}", value.Trim().Substring(0, 1).ToUpper(CultureInfo.CurrentCulture), value.Trim().Substring(1, value.Trim().Length - 1).ToLower(CultureInfo.CurrentCulture));
            }
        }
        /// <summary>
        /// Prenom 
        /// </summary>
        public string Prenom
        {
            get { return (this._prenom); }
            set
            {
                if (!IsNomPrenomValide(value)) throw new ApplicationException(string.Format(CultureInfo.CurrentCulture, "Le prénom {0} n'est pas valide.", value)); ;
                this._prenom = string.Format(CultureInfo.CurrentCulture, "{0}{1}", value.Trim().Substring(0, 1).ToUpper(CultureInfo.CurrentCulture), value.Trim().Substring(1, value.Trim().Length - 1).ToLower(CultureInfo.CurrentCulture));
            }
        }
        /// <summary>
        /// Salaire brut
        /// </summary>
        public decimal SalaireBrut
        {
            get { return (this._salaireBrut); }
            set
            {
                decimal ancienSalaire = _salaireBrut;
                this._salaireBrut = value;
                if (ancienSalaire != 0M && ancienSalaire != value)
                {
                  OnChangementSalaire(new ChangementSalaireEventArgs(ancienSalaire, 1M - ancienSalaire / value));
                }
                
               

            }

        }

        protected virtual void OnChangementSalaire(ChangementSalaireEventArgs changementSalaireEventArgs)
        {
            EventHandler<ChangementSalaireEventArgs> handleLocal = ChangementSalaire;
            if (handleLocal != null)
            { 
                ChangementSalaire(this, changementSalaireEventArgs); 
            }
           
        }
        /// <summary>
        /// Taux de charges sociales affecté
        /// Ne peut excéder 0.6
        /// </summary>
        public decimal TauxCS
        {
            get { return (this._tauxCS); }
            set
            {
                if ((value < 0) || (value > 0.6m))
                {
                    throw new Exception(string.Format(CultureInfo.CurrentCulture, "Le taux {0} n'est pas acceptable.", value));

                }

                else
                {
                    this._tauxCS = value;
                }
            }
        }
        /// <summary>
        /// Date de naissance
        /// Ne peut être antérieure au 1er janvier 1900 et postérieure à J -15 ans
        /// </summary>
        public DateTime DateNaissance
        {
            get { return (this._dateNaissance); }
            set
            {
                if(!IsDateNaissanceValide(value))
                {
                throw new Exception(String.Format(CultureInfo.CurrentCulture, "La Date de naissance {0:d} doit être comprise entre le {1:d} et {2:d}",
                   value,new DateTime(1900,01,01),DateTime.Today.AddYears(-15)));
                }
                else this._dateNaissance = value;
            }
        }

        /// <summary>
        /// Salaire touché par le salarie apres déduction des charges sociales
        /// </summary>
        public virtual decimal SalaireNet
        {
            get { return this._salaireBrut * (1 - this._tauxCS); }
        }

        #endregion

        #region Méthodes 

        /// <summary>
        /// Verification de la conformite de la saisie pour les noms et prenoms.
        /// Longueur comprise entre 3 et 30 caractères
        /// Uniquement composé de lettres
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ///
        public static bool IsNomPrenomValide(string value)
        {
            if (value == null || value.Trim().Length < 3 || value.Trim().Length > 30 ) return false;

            foreach (char caractere in value)
            {
                if (!char.IsLetter(caractere)) return false;
            }
            return true;

        }
        /// <summary>
        /// Vérifie que le matricule respecte les règles suivantes
        /// Longueur 7 structure nnXXXnnn ou n est un digit et X une lettre
        /// </summary>
        /// <param name="value">La valeur du matricule</param>
        /// <returns></returns>
        public static bool IsMatriculeValide(string value)
        {
            if (value== null || value.Length != 7) return false;
            for (int i = 0; i < value.Length; i++)
            {
                if ((i < 2 || i > 4) && !char.IsNumber(value[i])) return false;
                if ((i > 2 & i < 5) && !char.IsLetter(value[i])) return false;
            }
            return true;
        }
        public static bool IsDateNaissanceValide(DateTime value)
        {
            if (value.CompareTo(new DateTime(1900, 01, 01)) < 0) return false; 
            if (value.CompareTo(DateTime.Today.AddYears(-15)) > 0) return false;
            return true;
        }
        #endregion
        #region Constructeurs
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Salarie()
        {
          
            
        }

        /// <summary>
        /// Constructeur de recopie
        /// </summary>
        /// <param name="salarie"></param>
        public Salarie(Salarie salarie)
            : this(salarie.Nom,salarie.Prenom,salarie.Matricule)
        {
            if (salarie != null)
            {
                this.SalaireBrut = salarie.SalaireBrut;
                this.TauxCS = salarie.TauxCS;
                this.DateNaissance = salarie.DateNaissance;
            }
        }
        /// <summary>
        /// Constructeur d'initialisation partielle
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="matricule"></param>
        public Salarie(string nom, string prenom, string matricule)
            : this()
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Matricule = matricule;

        }

        #endregion
       
        #region Méthodes Surchargées ou Sustituées de la classe Object
        /// <summary>
        /// Chaine representant l'objet instancié.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            return string.Format(CultureInfo.CurrentCulture, @"{0};{1};{2};{3:# ###.##};{4};{5:d}", this._matricule, this._nom, this._prenom, this._salaireBrut, this._tauxCS, this._dateNaissance.Date);
        }
        /// <summary>
        /// Compare deux objets pour déterminer l'égalité
        /// De type Salarie et même matricule
        /// </summary>
        /// <returns>Vrai si les deux objets sont égaux</returns>
        public override bool Equals(Object obj)
        {
            Salarie salarieConverti = obj as Salarie;
            if (salarieConverti == null) return false;
            return (salarieConverti._matricule == this._matricule);
        }
        
        /// <summary>
        /// Compare deux salariés pour déterminer l'égalité
        /// Même matricule
        /// </summary>
        /// <param name="salarie"></param>
        /// <returns></returns>
        public  bool Equals(Salarie salarie)
        {
            if (salarie == null) return false;
            return (salarie._matricule == this._matricule) ;
            
        }
        /// <summary>
        /// opérateur relationnel ==
        /// </summary>
        /// <param name="salA">Instance salarié</param>
        /// <param name="salB">Instance salarié</param>
        /// <returns>Vrai si égaux</returns>
        public static bool operator ==(Salarie salA, Salarie salB)
        {            
            if ((object)salA == null) return (object)salB == null;
            return salA.Equals(salB);
        }
        /// <summary>
        ///  opérateur relationnel !=
        /// </summary>
        /// <param name="salA">Instance salarié</param>
        /// <param name="salB">Instance salarié</param>
        /// <returns>Vrai si différents</returns>
        public static bool operator !=(Salarie salA, Salarie salB)
        {
            if ((object)salA == null) return (object)salB != null;
            return !salA.Equals(salB);
        }
        /// <summary>
        /// Une des règles de conception veut que l'on modifie la méthode GetHashCode
        /// Si la méthode Equals est modifiée
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            // Uniquement si non nul
            return  (_matricule != null) ?_matricule.GetHashCode() : 0;
        }
        #endregion
    }

}

