using SalariesDll;
using System;

namespace SalariesVueDll
{
    public class SalarieVue : Salarie
    {
        private Salaries _listSalaries;

        public Salaries ListSalaries { get => _listSalaries; set => _listSalaries = value; }
    }
}
