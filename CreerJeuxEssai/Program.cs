using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalariesDll;
using Utilitaires;


namespace CreerJeuxEssai
{
    class Program
    {
        static void Main(string[] args)
        {
            Salaries salaries = new Salaries();
            salaries.Add(new Salarie()
            {
                Matricule = "23ABC56",
                Nom = "Bost",
                Prenom = "Vincent",
                DateNaissance = new DateTime(1962, 01, 13),
                SalaireBrut = 3500,
                TauxCS = 0.25M
            });
            salaries.Add(new Salarie()
            {
                Matricule = "23ABC50",
                Nom = "Morillon",
                Prenom = "Jean",
                DateNaissance = new DateTime(1959, 10, 13),
                SalaireBrut = 3500,
                TauxCS = 0.25M
            });
            salaries.Add(new Commercial()
            {
                Matricule = "23ABC50",
                Nom = "Goddaert",
                Prenom = "Elisbeth",
                DateNaissance = new DateTime(1963, 6, 05),
                SalaireBrut = 3500,
                TauxCS = 0.25M,
                ChiffreAffaire = 1500,
                Commission = 10
            });
            ISauvegarde sauvegarde = new SauvegardeXML();
            salaries.Save(sauvegarde,Settings.Default.AppData);

            Roles roles = new Roles();
            roles.Add(new Role() { Identifiant = "Utilisateur", Description = "Utilisateur Application" });
            roles.Add(new Role() { Identifiant = "Administrateur", Description = "Administrateur Application" });
            Utilisateur utilisateur = new Utilisateur() { Identifiant = "C6GB011", MotDePasse = "Vince1962", Nom = "Bost", CompteBloque = false, Role = roles.ElementAt(1) };
            
            Utilisateurs utilisateurs = new Utilisateurs();
            utilisateurs.Add(utilisateur);
            utilisateur = new Utilisateur() { Identifiant = "A7DC011", MotDePasse = "Jean1959", Nom = "Morillon", CompteBloque = false, Role = roles.ElementAt(0) };
            utilisateurs.Add(utilisateur);
            utilisateurs.Save(sauvegarde,Settings.Default.AppData);
            Console.WriteLine(roles.RechercherRole("Administrateur").ToString());
            Console.ReadLine();
            roles.Save(sauvegarde,Settings.Default.AppData);
        }
    }
}
