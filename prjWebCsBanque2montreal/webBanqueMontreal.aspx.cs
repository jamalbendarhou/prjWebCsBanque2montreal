using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace prjWebCsBanque2montreal
{
    public partial class webBanqueMontreal : System.Web.UI.Page
    {
        static List<clsClientCompte> listeClients = new List<clsClientCompte>();
        static string numeroCompteSaisi, motDePasseSaisi;
        static decimal soldeClient, montantDeposer, montantRetirer;

        protected void Page_Load(object sender, EventArgs e)
        {
            lectureInfoClient();
            if (Page.IsPostBack == false)
            {
                panIdentificationClient.Visible = true;
                panVerification.Visible = false;
                panTransaction.Visible = false;
                panInformationCompte.Visible = false;
            }
        }

        private void lectureInfoClient()
        {
            StreamReader monFichier = new StreamReader(Server.MapPath("App_Data/infoClients.txt"));
            while (monFichier.EndOfStream == false)
            {
                string numero = monFichier.ReadLine();
                string nom = monFichier.ReadLine();
                string motDePasse = monFichier.ReadLine();
                decimal solde = Convert.ToDecimal(monFichier.ReadLine());

                clsClientCompte client = new clsClientCompte
                {
                    NumeroCompte = numero,
                    Nom = nom,
                    MotDePasse = motDePasse,
                    Solde = solde
                };

                listeClients.Add(client);
            }
            monFichier.Close();
        }

        private void sauvegarderInfoClient()
        {
            StreamWriter monFichier = new StreamWriter(Server.MapPath("App_Data/infoClients.txt"));

            foreach (clsClientCompte client in listeClients)
            {
                monFichier.WriteLine(client.NumeroCompte);
                monFichier.WriteLine(client.Nom);
                monFichier.WriteLine(client.MotDePasse);
                monFichier.WriteLine(client.Solde);
            }

            monFichier.Close();
        }

        protected void btnTerminer_Click(object sender, EventArgs e)
        {
            panIdentificationClient.Visible = true;
            panVerification.Visible = false;
            panTransaction.Visible = false;
            panInformationCompte.Visible = false;
            txtNumCompte.Text = "";
            txtNip.Text = "";
            txtDeposer.Text = "";
            txtRetirer.Text = "";
            txtNumCompte.Focus();
        }

        protected void btnIdentification_Click(object sender, EventArgs e)
        {
            numeroCompteSaisi = txtNumCompte.Text.Trim();

            bool clientexistant = false;
            string nomClient = "";

            foreach (clsClientCompte client in listeClients)
            {
                if (client.NumeroCompte == numeroCompteSaisi)
                {
                    clientexistant = true;
                    nomClient = client.Nom;
                    break;
                }
            }

            if (clientexistant)
            {
                lblInfoIdentification.Visible = true;
                lblInfoIdentification.Text = "Identification reussie";
                panVerification.Visible = true;
                lblBienvenue.Text = "bienvenue " + nomClient;
            }
            else
            {
                lblInfoIdentification.Visible = true;
                lblInfoIdentification.Text = "Identification echouee. Veuillez reessayer.";
                txtNumCompte.Focus();
            }
        }

        protected void btnVerificationNip_Click(object sender, EventArgs e)
        {
            //numeroCompteSaisi = txtNumCompte.Text.Trim();
            motDePasseSaisi = txtNip.Text.Trim();

            bool clientexistant = false;

            foreach (clsClientCompte client in listeClients)
            {
                if (client.MotDePasse == motDePasseSaisi && client.NumeroCompte == numeroCompteSaisi)
                {
                    clientexistant = true;
                    break;
                }
            }

            if (clientexistant)
            {
                lblVerificationNip.Visible = true;
                lblVerificationNip.Text = "Identification reussie";
                panTransaction.Visible = true;
                panInformationCompte.Visible = true;
            }
            else
            {
                lblVerificationNip.Visible = true;
                lblVerificationNip.Text = "Identification échouée. Veuillez réessayer.";
                txtNip.Focus();
            }
        }

        protected void btnTransaction_Click(object sender, EventArgs e)
        {
           // numeroCompteSaisi = txtNumCompte.Text.Trim();
            // motDePasseSaisi = txtNip.Text.Trim();

            foreach (clsClientCompte client in listeClients)
            {
                if (client.MotDePasse == motDePasseSaisi && client.NumeroCompte == numeroCompteSaisi)
                {
                    soldeClient = client.Solde;
                    break;
                }
            }

            if (radTransaction.SelectedValue == "1")
            {
                montantDeposer = Convert.ToDecimal(txtDeposer.Text.Trim());

                if (montantDeposer > 2 && montantDeposer < 2000)
                {
                    soldeClient += montantDeposer;
                    lblTransaction.Text = "Opération effectuée avec succès";

                    foreach (clsClientCompte client in listeClients)
                    {
                        if (client.NumeroCompte == numeroCompteSaisi)
                        {
                            client.Solde = soldeClient;
                            break;
                        }
                    }
                    sauvegarderInfoClient();
                }
                else
                {
                    lblTransaction.Text = "Le montant depose ne correspond pas a la limite autorisee.";
                }
            }
            else if (radTransaction.SelectedValue == "2")
            {
                montantRetirer = Convert.ToDecimal(txtRetirer.Text.Trim());

                if (montantRetirer > 20 && montantRetirer < 500 && montantRetirer < soldeClient)
                {
                    soldeClient -= montantRetirer;
                    lblTransaction.Text = "Operation effectuee avec succes";

                    foreach (clsClientCompte client in listeClients)
                    {
                        if (client.NumeroCompte == numeroCompteSaisi)
                        {
                            client.Solde = soldeClient;
                            break;
                        }
                    }
                    sauvegarderInfoClient();
                }
                else
                {
                    lblTransaction.Text = "Le montant retiré est supérieur à la limite ou dépasse le solde disponible.";
                }
            }
            else if (radTransaction.SelectedValue == "3")
            {
                lblTransaction.Text = "Le solde du compte est : " + Convert.ToString(soldeClient);
            }

            string nomClient = "";
            string numerodecomptre = "";
            string nip = "";
            Decimal soldeajour= 0;
            foreach (clsClientCompte client in listeClients)
            {
                if (client.NumeroCompte == numeroCompteSaisi)
                {
                    nomClient = client.Nom;
                    numerodecomptre = client.NumeroCompte;
                    nip = client.MotDePasse;
                    soldeajour = client.Solde;
                    break;
                }
            }

            string infoCompte;
            infoCompte = "Numero : " + numerodecomptre + ".<br/>";
            infoCompte += "Client : " + nomClient + ".<br/>";
            infoCompte += "Nip : " + nip + ".<br/>";
            infoCompte += "Solde : " + soldeajour + ".";
            lblInfoClt.Text = infoCompte;
        }
    }
}
