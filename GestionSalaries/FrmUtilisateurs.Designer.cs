namespace GestionSalaraies
{
    partial class FrmUtilisateurs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnNouveau = new System.Windows.Forms.Button();
            this.cbUtilisateurs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDetailUtilisateur = new System.Windows.Forms.GroupBox();
            this.chkCompteBloque = new System.Windows.Forms.CheckBox();
            this.pnlBoutons = new System.Windows.Forms.Panel();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.cbRoles = new System.Windows.Forms.ComboBox();
            this.txtNom = new System.Windows.Forms.TextBox();
            this.txtMotDePasse = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdentifiant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.epUtilisateur = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gbDetailUtilisateur.SuspendLayout();
            this.pnlBoutons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epUtilisateur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNouveau
            // 
            this.btnNouveau.Location = new System.Drawing.Point(423, 60);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(75, 24);
            this.btnNouveau.TabIndex = 0;
            this.btnNouveau.Text = "Nouveau";
            this.btnNouveau.UseVisualStyleBackColor = true;
            // 
            // cbUtilisateurs
            // 
            this.cbUtilisateurs.FormattingEnabled = true;
            this.cbUtilisateurs.Location = new System.Drawing.Point(188, 60);
            this.cbUtilisateurs.Name = "cbUtilisateurs";
            this.cbUtilisateurs.Size = new System.Drawing.Size(220, 24);
            this.cbUtilisateurs.TabIndex = 1;
            this.cbUtilisateurs.SelectedIndexChanged += new System.EventHandler(this.cbUtilisateurs_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choisir un utilisateur :";
            // 
            // gbDetailUtilisateur
            // 
            this.gbDetailUtilisateur.Controls.Add(this.chkCompteBloque);
            this.gbDetailUtilisateur.Controls.Add(this.pnlBoutons);
            this.gbDetailUtilisateur.Controls.Add(this.cbRoles);
            this.gbDetailUtilisateur.Controls.Add(this.txtNom);
            this.gbDetailUtilisateur.Controls.Add(this.txtMotDePasse);
            this.gbDetailUtilisateur.Controls.Add(this.label5);
            this.gbDetailUtilisateur.Controls.Add(this.label4);
            this.gbDetailUtilisateur.Controls.Add(this.label3);
            this.gbDetailUtilisateur.Controls.Add(this.txtIdentifiant);
            this.gbDetailUtilisateur.Controls.Add(this.label2);
            this.gbDetailUtilisateur.Location = new System.Drawing.Point(43, 146);
            this.gbDetailUtilisateur.Name = "gbDetailUtilisateur";
            this.gbDetailUtilisateur.Size = new System.Drawing.Size(479, 384);
            this.gbDetailUtilisateur.TabIndex = 3;
            this.gbDetailUtilisateur.TabStop = false;
            this.gbDetailUtilisateur.Text = "Détails Utilisateur";
            // 
            // chkCompteBloque
            // 
            this.chkCompteBloque.AutoSize = true;
            this.chkCompteBloque.Location = new System.Drawing.Point(119, 162);
            this.chkCompteBloque.Name = "chkCompteBloque";
            this.chkCompteBloque.Size = new System.Drawing.Size(125, 21);
            this.chkCompteBloque.TabIndex = 4;
            this.chkCompteBloque.Text = "Compte bloqué";
            this.chkCompteBloque.UseVisualStyleBackColor = true;
            // 
            // pnlBoutons
            // 
            this.pnlBoutons.Controls.Add(this.btnValider);
            this.pnlBoutons.Controls.Add(this.btnAnnuler);
            this.pnlBoutons.Controls.Add(this.btnModifier);
            this.pnlBoutons.Location = new System.Drawing.Point(22, 286);
            this.pnlBoutons.Name = "pnlBoutons";
            this.pnlBoutons.Size = new System.Drawing.Size(433, 74);
            this.pnlBoutons.TabIndex = 3;
            // 
            // btnValider
            // 
            this.btnValider.Location = new System.Drawing.Point(217, 21);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(75, 28);
            this.btnValider.TabIndex = 0;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = true;
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(123, 21);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(75, 28);
            this.btnAnnuler.TabIndex = 0;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(23, 21);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(75, 28);
            this.btnModifier.TabIndex = 0;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // cbRoles
            // 
            this.cbRoles.FormattingEnabled = true;
            this.cbRoles.Location = new System.Drawing.Point(121, 220);
            this.cbRoles.Name = "cbRoles";
            this.cbRoles.Size = new System.Drawing.Size(172, 24);
            this.cbRoles.TabIndex = 2;
            // 
            // txtNom
            // 
            this.txtNom.Location = new System.Drawing.Point(117, 120);
            this.txtNom.Name = "txtNom";
            this.txtNom.Size = new System.Drawing.Size(174, 22);
            this.txtNom.TabIndex = 1;
            // 
            // txtMotDePasse
            // 
            this.txtMotDePasse.Location = new System.Drawing.Point(117, 70);
            this.txtMotDePasse.Name = "txtMotDePasse";
            this.txtMotDePasse.PasswordChar = '*';
            this.txtMotDePasse.Size = new System.Drawing.Size(174, 22);
            this.txtMotDePasse.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Role :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nom :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mot de passe :";
            // 
            // txtIdentifiant
            // 
            this.txtIdentifiant.Location = new System.Drawing.Point(119, 24);
            this.txtIdentifiant.Name = "txtIdentifiant";
            this.txtIdentifiant.Size = new System.Drawing.Size(174, 22);
            this.txtIdentifiant.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Identifiant :";
            // 
            // epUtilisateur
            // 
            this.epUtilisateur.ContainerControl = this;
            // 
            // FrmUtilisateurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 563);
            this.Controls.Add(this.gbDetailUtilisateur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUtilisateurs);
            this.Controls.Add(this.btnNouveau);
            this.Name = "FrmUtilisateurs";
            this.Text = "Gestion des utilisateurs";
            this.Load += new System.EventHandler(this.FrmUtilisateurs_Load);
            this.gbDetailUtilisateur.ResumeLayout(false);
            this.gbDetailUtilisateur.PerformLayout();
            this.pnlBoutons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.epUtilisateur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNouveau;
        private System.Windows.Forms.ComboBox cbUtilisateurs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDetailUtilisateur;
        private System.Windows.Forms.Panel pnlBoutons;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.ComboBox cbRoles;
        private System.Windows.Forms.TextBox txtNom;
        private System.Windows.Forms.TextBox txtMotDePasse;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdentifiant;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkCompteBloque;
        private System.Windows.Forms.ErrorProvider epUtilisateur;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}