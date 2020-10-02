using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalariesDll
{
    /// <summary>
    /// 
    /// </summary>
    public enum ConnectionResult
    {
        /// <summary>
        /// enumerable de gestion de connaction
        /// </summary>
        Connecté=0, 
        /// <summary>
        /// 
        /// </summary>
        MotPasseInvalide = 2,
        /// <summary>
        /// 
        /// </summary>
        CompteBloqué = 3
    }
}
