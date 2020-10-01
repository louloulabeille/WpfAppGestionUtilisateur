using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace SalariesDll
{
    [Serializable()]
   public class Role
    {
        string _identifiant = string.Empty;
        string _description = string.Empty;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Identifiant
        {
            get { return _identifiant; }
            set { _identifiant = value; }
        }
      
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture,"{0};{1};", this._identifiant, this._description);
        }
        /// <summary>
        /// Compare deux objets pour déterminer l'égalité
        /// Même Identifiant
        /// </summary>
        /// <returns>Vrai si les deux objets sont égaux</returns>
        public override bool Equals(Object role)
        {
            Role roleRef = role as Role;
            if (roleRef == null) return false;
            else if (roleRef.Identifiant == this.Identifiant) return true;
            else return false;
        }
        public override int GetHashCode()
        {
            return string.IsNullOrEmpty(_identifiant) ? 0 : _identifiant.GetHashCode();
        }

    }
}
