using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SalariesDll;
using GestionSalaraies.Properties;
using Utilitaires;


namespace GestionSalaraies
{
    public partial class FrmUtilisateurs : Form
    {
        Utilisateurs utilisateurs;
        Roles roles;
        Utilisateur utilisateur;
      
        

        enum Contextes
        {
            Initial = 0,
            Consultation = 1,
            ModificationInitiale = 2,
            ModificationAnnuler = 3,
            ModificationValider = 4,
            AjoutInitial = 5,
            AjoutValider = 6

        }
        public FrmUtilisateurs()
        {
            InitializeComponent();
           
        }

        void GestionnaireContextes(Contextes contexte)
            
        {
            
            switch (contexte)
            {
                case Contextes.Initial:
                    cbUtilisateurs.Enabled = (cbUtilisateurs.Items.Count>0);
                    btnNouveau.Enabled = true;
                    gbDetailUtilisateur.Visible = false;
                    break;
                case Contextes.Consultation:
                    btnNouveau.Enabled = true;
                    gbDetailUtilisateur.Visible = true;
                    pnlBoutons.Enabled = true;
                    btnModifier.Enabled = true;
                    btnAnnuler.Enabled = false;
                    btnValider.Enabled = false;
                    txtIdentifiant.ReadOnly = true;
                    txtMotDePasse.ReadOnly = true;
                    txtNom.ReadOnly = true;
                    chkCompteBloque.Enabled = false;
                    cbRoles.Enabled = false;
                    break;
                case Contextes.ModificationInitiale:
                    btnNouveau.Enabled = false;
                    gbDetailUtilisateur.Visible = true;
                    cbUtilisateurs.Enabled = false;
                    pnlBoutons.Enabled = true;
                    btnModifier.Enabled = false;
                    btnAnnuler.Enabled = true;
                    btnValider.Enabled = true;
                    txtIdentifiant.ReadOnly = true;
                    txtMotDePasse.ReadOnly = false;
                    chkCompteBloque.Enabled = true;
                    txtNom.ReadOnly = false;
                    cbRoles.Enabled = true;
                    break;
                case Contextes.ModificationAnnuler:
                    GestionnaireContextes(Contextes.Consultation);
                    break;
                case Contextes.ModificationValider:
                    break;
                case Contextes.AjoutInitial:
                    break;
                case Contextes.AjoutValider:
                    break;
                default:
                    break;
            }

        }

        private void ChargerValeursUtilisateur()
        {
            txtIdentifiant.Text = utilisateur.Identifiant;
            txtMotDePasse.Text = utilisateur.MotDePasse;
            txtNom.Text = utilisateur.Nom;
            chkCompteBloque.Checked = utilisateur.CompteBloque;
            foreach (var item in cbRoles.Items)
            {
                if (item.ToString() == utilisateur.Role.Identifiant)
                {
                    cbRoles.SelectedItem = item;
                    break;
                }
            }
        }
        private void ModifierUtilisateur()
        {

            if (IsValidChamps())
            {
                try
                {
                    utilisateur.Identifiant = txtIdentifiant.Text;
                    utilisateur.MotDePasse = txtMotDePasse.Text;
                    txtNom.Text = utilisateur.Nom;
                    chkCompteBloque.Checked = utilisateur.CompteBloque;
                    utilisateur.Identifiant = txtIdentifiant.Text;
                    utilisateur.MotDePasse = txtMotDePasse.Text;
                    txtNom.Text = utilisateur.Nom;
                    chkCompteBloque.Checked = utilisateur.CompteBloque;
                }
                catch (Exception)
                {

                    // a programmer
                }


            }
        }

        private bool IsValidChamps()
        {
            bool valid = true;

            if (!Utilisateur.IsIdentifiantValide(txtIdentifiant.Text))
            {
                valid = false;
                epUtilisateur.SetError(txtIdentifiant, "L'identifiant n'est pas valide");

            }
            else
            {
                epUtilisateur.SetError(txtIdentifiant, string.Empty);
            }



            return valid;
        }


        private void ChargerRoles()
        {
            roles = new Roles();
            ISauvegarde serialiseur = MonApplication.DispositifSauvegarde;
            roles.Load(serialiseur,Properties.Settings.Default.AppData);

            foreach (Role item in roles)
            {
                cbRoles.Items.Add(item.Identifiant);
            }
        }

        private void ChargerUtilisateurs()
        {
            utilisateurs = new Utilisateurs();
            ISauvegarde serialiseur = MonApplication.DispositifSauvegarde;
            utilisateurs.Load(serialiseur,Properties.Settings.Default.AppData);
            foreach (Utilisateur item in utilisateurs)
            {
                cbUtilisateurs.Items.Add(item.Identifiant);
            }
        }

        private void FrmUtilisateurs_Load(object sender, EventArgs e)
        {
            ChargerUtilisateurs();
            ChargerRoles();
            GestionnaireContextes(Contextes.Initial);
        }

        private void cbUtilisateurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            utilisateur = utilisateurs.UtilisateurByMatricule(cbUtilisateurs.Items[cbUtilisateurs.SelectedIndex].ToString());
            ChargerValeursUtilisateur();
            GestionnaireContextes(Contextes.Consultation);
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            GestionnaireContextes(Contextes.ModificationInitiale);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            GestionnaireContextes(Contextes.ModificationAnnuler);
        }
    }
}
