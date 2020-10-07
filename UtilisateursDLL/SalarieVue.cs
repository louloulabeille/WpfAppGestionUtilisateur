using SalariesDll;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace SalariesVueDll
{
    /// <summary>
    /// Class pour le data binding
    /// </summary>
    public class SalarieVue : Salarie
    {
        private Salaries _listSalaries = new Salaries();

        /// <summary>
        /// assesseur
        /// </summary>
        public Salaries ListSalaries { get => _listSalaries; set => _listSalaries = value; }

    }
}
