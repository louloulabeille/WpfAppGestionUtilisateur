using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UtilisateursDLL
{

    /// <summary>
    /// Class de validation des décimaux
    /// </summary>
    public class DecimalValidation : ValidationRule
    {

        /// <summary>
        /// méthode surcharger pour la validation des décimaux
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal deValue;

            if ( value is string v && string.IsNullOrEmpty(v) )
            {
                return new ValidationResult(false,"Le champ ne doit pas être vide. La saisie est obligatoire.");
            }

            if ( !decimal.TryParse(value as string,out deValue) )
            {
                return new ValidationResult(false, "La valeur saisie n'est pas un décimal.");
            } 

            if ( deValue < 0 )
            {
                return new ValidationResult(false, "La valeur saisie doit être supérieur à 0.");
            }

            return new ValidationResult(true, null);

            throw new NotImplementedException();
        }


    }
}
