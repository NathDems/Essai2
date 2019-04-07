using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace projetFinEtude
{
    public partial class ListeProprietes : System.Web.UI.Page
    {
        string Message = string.Empty;
        string Separateur = "|";
        public int[] ListeProprietes2 = new int[0];
        public string NomFichier = @"C:\Temp\Projet Fin Etude 4 Avril\Proprietes.txt";

        DataTable dt = new DataTable("MaTable");

        DataColumn dcNum = new DataColumn("id", typeof(int));
        DataColumn dcImg = new DataColumn("image", typeof(string));
        DataColumn dcPrix = new DataColumn("prix", typeof(int));
        DataColumn dcEval = new DataColumn("evaluation", typeof(int));
        DataColumn dcAnnee = new DataColumn("annee", typeof(int));
        DataColumn dcAdresse = new DataColumn("adresse", typeof(string));
        DataColumn dcAgence = new DataColumn("agence", typeof(String));
        DataColumn dcAgent = new DataColumn("agent", typeof(String));

        protected void Page_Load(object sender, EventArgs e)
        {
            // Charger le tableau ListeProprietes2
            ChargerListeProprietes();
            
            // Creer la grille
            GenererColonneDeLaGrille();

            // charger la grille avec les proprietes contenues dans ListeProprietes2
            ChargerGrille();

        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            GenererColonneDeLaGrille();
            GridView1.PageSize = int.Parse(DropDownList1.SelectedValue);
            LblProprietes.Text = dt.Rows.Count + " propriété(s) au total.";
            //ListeProprietes2
        }

        public void GenererColonneDeLaGrille()
        {
            if (dt.Columns.Count <= 0)
            {
                dt.Columns.Add(dcNum);
                dt.Columns.Add(dcImg);
                dt.Columns.Add(dcPrix);
                dt.Columns.Add(dcEval);
                dt.Columns.Add(dcAnnee);
                dt.Columns.Add(dcAdresse);
                dt.Columns.Add(dcAgence);
                dt.Columns.Add(dcAgent);
            }
        }

        public int ObtientIDDepuisLeFormatTexte2(string texte)
        {
            // retourne le ID depuis le format texte de la sauvegarde d<une propriete dans le fichier
            // 0 si aucune information

            int rang = 0;
            string s = texte.Substring(0, texte.IndexOf(Separateur));
            // bool result = int.TryParse(s, out rang);
            if (int.TryParse(s, out rang))
                return rang;
            return rang;

        }

        public void ChargerListeProprietes()
        {
            //Charger le tableau des ID dans ListeProprietes depuis le fichier   List<int> ListProprietes = new List<int>;
            try
            {
                StreamReader sr = new StreamReader(NomFichier);
                string[] lignes = System.IO.File.ReadAllLines(NomFichier);
                sr.Close();
                // creer un tableau de int
                int[] Liste = new int[lignes.Length];
                Liste[0] = int.Parse(lignes[0]);        // le nombre de proprietes
                Message += Liste[0] + "  ";
                if (lignes.Length > 0)
                {
                    for (int i = 1; i < lignes.Length; i++)
                    {
                        string s = lignes[i];
                        
                        int.TryParse(s.Substring(0, s.IndexOf(Separateur)), out Liste[i]);
                        //= ObtientIDDepuisLeFormatTexte2(lignes[i]);
                        //Liste[i] = int.TryParse(s, out rang);
                        Message += "Pr " + Liste[i] + ",  ";
                    }
                }
                // modifier ListeProprietes
                ListeProprietes2 = Liste;
            }
            catch (Exception e)
            {
                Message = "Erreur : " + e.Message;
            }
        }

        public DataRow CreerLignePrDataRow(Proprietes prop)
        {
            DataRow ligne = dt.NewRow();
            //int NbChamp = 7;
           // string ligne[] = new string[NbChamp];
            ligne["id"] = prop.ProprID;
            ligne["image"] = "/img/" + prop.Photo;
            ligne["prix"] =  prop.PrixVente;
            ligne["evaluation"] =  prop.PrixMunicipal;
            ligne["annee"] = prop.AnneeConstr;
            ligne["adresse"] = prop.Adresse; 
            ligne["agence"] =prop.SiteVente;
            ligne["agent"] = prop.AgentImmob;
            return ligne;
        }

        //public int ObtientIDDepuisLeFormatTexte2(string texte)
        //{
        //    // retourne le ID depuis le format texte de la sauvegarde d<une propriete dans le fichier
        //    // 0 si aucune information

        //    int rang = 0;
        //    string s = texte.Substring(0, texte.IndexOf(Separateur));
        //    // bool result = int.TryParse(s, out rang);
        //    if (int.TryParse(s, out rang))
        //        return rang;
        //    return rang;

        //}

        public Proprietes LireDansFichier(int rang)
        {
            // Retourne la propriete telel que son ID = rang - Null par defaut
            string ligne = string.Empty;
            string NomFichier = @"C:\Temp\Projet Fin Etude 4 Avril\Proprietes.txt";

            try
            {
                StreamReader sr = new StreamReader(NomFichier);
                string[] lignes = System.IO.File.ReadAllLines(NomFichier);
                sr.Close();
                // chercher la bonne ligne à partir du ID de la propriété
                if (lignes.Length > 0)      // s<assurer qu<il y a au moins une propriete
                {
                    // parcourir les lignes et chercher le ID = rang
                    int i = 0;
                    bool sortir = false;
                    do
                    {
                        i += 1;
                        // extraire le ID de la ligne
                        int j = ObtientIDDepuisLeFormatTexte2(lignes[i]);    // obtenir le ID contenu dans la ligne 
                        if (j > 0)
                        //if (result == true)
                        {
                            if (rang == j)
                            {      // la premiere propriete est dans la ligne 1
                                ligne = lignes[rang];
                                sortir = true;
                            }
                        }
                    } while ((i < lignes.Length - 1) && (sortir == false));
                }
            }
            catch (Exception e)
            {
                Message = "Erreur : " + e.Message;
            }
            // creer la proprirte qui sera retrournee
            Proprietes prop = new Proprietes();

            // pour charger propr, convertir la ligne en champs
            if (ligne != string.Empty)
            {
                int nbChamp = 14;
                string[] champs = new string[nbChamp];
                string mot = string.Empty;
                int rangMot = 0; int i = 0;
                do
                {
                    if ((i == ligne.Length) || (ligne.ElementAt(i) == Separateur.ElementAt(0)))
                    {
                        champs[rangMot] = mot;
                        if (i < ligne.Length)
                            rangMot += 1;
                        mot = string.Empty;
                    }
                    else
                    {
                        mot += ligne.ElementAt(i);
                    }
                    i += 1;
                } while (i <= ligne.Length);

                // attribuer les champs aux valeurs de propr
                prop.ProprID = int.Parse(champs[0]);
                prop.ProprURL = champs[1];    // _ProprURL;
                prop.Adresse = champs[2];      //_Adresse;
                prop.PrixVente = double.Parse(champs[3]);      //_PrixVente;
                prop.PrixMunicipal = double.Parse(champs[4]);      //_PrixMunicipal;
                prop.AnneeConstr = int.Parse(champs[5]);      //AnneeConstr;
                prop.DateVisite = DateTime.Parse(champs[6]);      //_DateVisite; // DateTime.Today;
                prop.AgentImmob = champs[7];      //_AgentImmob;
                prop.SiteVente = champs[8];      //_SiteVente;
                string s = champs[9];
                if ((champs[9].ToUpper() == "FALSE") || (champs[9] == "0"))
                {
                    prop.Garage = false;
                }
                else
                {
                    prop.Garage = true;
                }
                s = champs[10];
                if ((champs[10].ToUpper() == "FALSE") || (champs[10] == "0"))
                {
                    prop.EstAVisiter = false;
                }
                else
                {
                    prop.EstAVisiter = true;
                }
                s = champs[11];
                prop.Cotation = int.Parse(champs[11]);      //_Cotation;
                s = champs[12];
                prop.Photo = champs[12];      //_Photo;
                prop.Commentaire = champs[13];      // _Commentaire;
            }
            return prop;
        }

        public void ChargerGrille()
        {
            if  (!this.IsPostBack) 
            {
                if (ListeProprietes2.Length > 0)
                {
                    for (int k = 1; k < ListeProprietes2.Length; k++)
                    {
                        Proprietes p = LireDansFichier(ListeProprietes2[k]);
                        dt.Rows.Add(CreerLignePrDataRow(p));
                    }
                }
            }
            else
            {
                if (dt.Rows.Count == 0) 
                {
                    if (ListeProprietes2.Length > 0)
                    {
                        for (int k = 1; k < ListeProprietes2.Length; k++)
                        {
                            Proprietes p = LireDansFichier(ListeProprietes2[k]);
                            dt.Rows.Add(CreerLignePrDataRow(p));
                        }
                    }
                }
            }

            int i = dt.Rows.Count;

            Session["mydata"] = dt;
            Session1();
        }

        protected void Session1()
        {
            GridView1.PageSize = int.Parse(DropDownList1.SelectedValue);
            dt = (DataTable)Session["mydata"];
 
            int i = dt.Rows.Count;
            int nbRow = dt.DefaultView.Count;   // nbre de lignes
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }

        protected void DropDownList1_Changed(object sender, EventArgs e)
        {
            Session1();
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Session1();
        }

        //protected void BtnSupprimer_Click(object sender, EventArgs e)
        //{
        //    // Supprimer la proprieté cochée

        //    LblMessage.Text = "Voulez-vous vraiment supprimer la propriété ? ";
        //    // Wait(3);
        //    EffaceMessage.Visible = true;

        //}

        protected void EffaceMessage_Click(object sender, EventArgs e)
        {
            LblMessage.Text = String.Empty;
            EffaceMessage.Visible = false;
        }

        protected void BtnImprimer_Click(object sender, EventArgs e)
        {

        }

        protected void printButton_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "PrintOperation", "printing()", true);
        }

        //private void dataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        //{ // Evènement lors de la sélèction d'une cellule            ligne e.RowIndex; // ligne la ligne selectionné
        //    colonne = e.ColumnIndex;
        //}

        protected void BtnAgenda_Click(object sender, EventArgs e)
        {
            // Ajouter le Id de la propriete au bas du fichier
            // si deja existant, alors supprimer

            

        }

        protected void BtnSupprimer_Click(object sender, EventArgs e)
        {
            //    // Supprimer la proprieté cochée
            GridViewRow row = (GridViewRow)((Button)sender).NamingContainer;
            int monID = int.Parse(GridView1.DataKeys[row.RowIndex]["id"].ToString());
           // FindControl("BtnSupprimer").


        }
    }
}