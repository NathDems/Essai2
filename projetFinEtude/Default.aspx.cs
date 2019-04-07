using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace projetFinEtude

{
    public partial class Default : System.Web.UI.Page
    {
        public string NomFichier = @"C:\TCHEDK\LaCite\Session 4\Projet de fin d'études\Developpement\CourtierPersonnel\ProjetFinEtude\Proprietes.txt";
        private string Separateur = "|";
        public string Message = string.Empty;

        public int[] ListeProprietes;

        protected void Page_Load(object sender, EventArgs e)
        {
            Initialiser();
        }

        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);

        }

        protected void DdlTri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(DdlTri.SelectedValue);
        }
       
        public void Initialiser()
        {
            // initialiser la variable tableau de int nommée ListeProprietes
            ChargerListeProprietes();   // OBLIGATOIRE AU DEMARRAGE
        }
        public void ActionsDeProgrammationAVerifier()
        {
            
            
            //// VERIFICATION
            //    string mess = string.Empty; 
            //    for (int j = 0; j < ListeProprietes.Length; j++)
            //    {
            //        mess += ListeProprietes[j] + " - ";
            //    }
            // RetirerDansFichier(0);

            //  int Id = ObtientIDDepuisLeFormatTexte("t5|autres");

            // creer une nouvelle propriete
            //Proprietes p1 = new Proprietes(
            //   "https://www.realtor.ca/immobilier/20433709/1-2-chambre-unifamiliale-unifamilial-173-castlefrank-road-ottawa",
            //   "173 CASTLEFRANK ROAD, Ottawa ", 329000, 335000, 1974, DateTime.Today,
            //   "Jennifer Chamberlain", "Realtor", false, false, 0, "Prop2.jpg", "unifamilial, 3 chambres, 2 salles de bain");
            //p1.ProprID = 1;
            // AjouterDansFichier(p1);
            // int b = AugmenterNombreProprDsFichier();
            //Proprietes p3 = CreerNewPropr(AugmenterNombreProprDsFichier(),
            //     "https://www.realtor.ca/immobilier/20433709/1-2-chambre-unifamiliale-unifamilial-173-castlefrank-road-ottawa",
            //     "20 DUNVEGAN RD, OTTAWA, ON, K1K 3E9", 1350000, 1335000, 1999, DateTime.Today,
            //    "NATALIE BELOVIC", "Remax", false, false, 0, "Prop3.jpg", "Bungalow, 4 chambres, 4 salles de bain"
            ////    );
            //Proprietes p4 = CreerNewPropr(3, "https://www.remax.ca/on/ottawa-real-estate/218-duntroon-circle-wp_id234748869-lst",
            //     "218 Duntroon Cir, Ottawa, ON, K1T 4C9", 419900, 415000, 1999, DateTime.Today,
            //    "NATALIE BELOVIC", "Remax", false, false, 0, "Prop3.jpg", "Bungalow, 4 chambres, 4 salles de bain"
            //    );
            //RetirerDansFichier(5);
            //int rangPropriete = 3;  // indiquer le rang de la propriete a afficher...
            //Proprietes p1 = LireDansFichier(rangPropriete);

            //Message = p3.ToString();


                
                // afficher les resultats ou liste des proprietes
                LblMessage.Text = Message;
                for (int i = 0; i < ListeProprietes.Length-1; i++)
                {
                    LblMessage.Text +=  "Prop  " + ListeProprietes[i] ;
                }

            //AjouterUnIdDeProprDsListeProprietes();

            //    // afficher les resultats ou liste des proprietes
            //    for (int i = 0; i < ListeProprietes.Length; i++)
            //    {
            //        LblMessage.Text += ListeProprietes[i] + "  ";
            //    }

            //Message = p1.ToString();
            //LblMessage.Text = Message;

            //Proprietes p2 = LireDansFichier(2);
            //Message = p2.ToString();
            //LblMessage.Text = Message;
        }

        public int ObtNombreProprFichier()
        {
            // Retourne le nombre de proprietes stockees dans le fichier de sauvegarde
            int nb = 0;
            StreamReader sr = new StreamReader(NomFichier);
            string s = sr.ReadLine();
            sr.Close();
            return nb = Int32.Parse(s); // = s.;
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
                        Liste[i] = ObtientIDDepuisLeFormatTexte(lignes[i]);
                        Message += "Prop " + Liste[i] + ",  ";
                    }
                }
                LblMessage.Text = Message;
                // modifier ListeProprietes
                ListeProprietes = Liste;
            }
            catch (Exception e)
            {
                Message = "Erreur : " + e.Message;
            }    
        }

        public void EcrireTexteFinFichier(string texte)
        {
            try
            {
                //Write a line of text at the en of file
                File.AppendAllText(NomFichier,texte + "\r\n");
            }
            catch (Exception e)
            {
                Message = "Erreur " + e.Message;
            }
            finally
            {
                Message = "Ajout reussi à la fin du fichier...";
            }
        }

        public void AjouterDansFichier(Proprietes p)
        {

            string ligne = p.ProprID.ToString() + Separateur + p.ProprURL + Separateur + p.Adresse + Separateur +
                    p.PrixVente.ToString() + Separateur + p.PrixMunicipal + Separateur + p.AnneeConstr.ToString() +
                    Separateur + p.DateVisite.ToString() + Separateur + p.AgentImmob + Separateur + p.SiteVente + 
                    Separateur + p.Garage + Separateur +  p.EstAVisiter.ToString() +  Separateur + 
                    p.Cotation.ToString() + Separateur + p.Photo + Separateur + p.Commentaire;

            EcrireTexteFinFichier(ligne);
        }

        public void RetirerDansFichier(int rang)
        {
            // retirer la propriete de ID rang du fichier
            try
            {
                StreamReader sr = new StreamReader(NomFichier);
                string[] lignes = System.IO.File.ReadAllLines(NomFichier);
                sr.Close();

                // Verifier que le ID existe avant de refaire le fichier
                bool existe = false;
                int positionLigneASupprimer = 0;
                if ( (lignes.Length > 0) && (rang != 0 ) )
                {
                    int i = 1;
                    do
                    {
                        if (rang == ObtientIDDepuisLeFormatTexte(lignes[i]))
                        {
                            existe = true;
                            positionLigneASupprimer = i;
                        }
                        i += 1;
                    } while ((existe == false) && (i < lignes.Length));
                }

                // Ecrire dans le fichier en incrementant la 1ere ligne
                if (existe)
                {
                    StreamWriter sw = new StreamWriter(NomFichier);
                    // parcourir toutes les lignes et elliminer positionLigne
                    sw.WriteLine(lignes.Length-2);  // nombre de proprietes

                    string mess = string.Empty;
                    for (int j = 1; j < lignes.Length; j++)
                    {
                         if (j != positionLigneASupprimer)
                        {
                            sw.WriteLine(lignes[j]);
                            mess += lignes[j] + "   ";
                        }
                    }
                    mess = mess + "\n\r Fin";
                    sw.Close();
                    
                }
            }
            catch (Exception e)
            {
                Message = "Erreur : " + e.Message;
            }
        }

        public int ObtientIDDepuisLeFormatTexte(string texte)
        {
            // retourne le ID depuis le format texte de la sauvegarde d<une propriete dans le fichier
            // 0 si aucune information

            int rang = 0;
            string s = texte.Substring(0, texte.IndexOf(Separateur) );
            // bool result = int.TryParse(s, out rang);
            if ( int.TryParse(s, out rang))
                return rang;
            return rang;

        }

        public Proprietes LireDansFichier(int rang)
        {
            // Retourne la propriete telel que son ID = rang - Null par defaut
            string ligne = string.Empty;
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
                        int j = ObtientIDDepuisLeFormatTexte(lignes[i]);    // obtenir le ID contenu dans la ligne 
                        if (j > 0)
                        //if (result == true)
                        {
                            if (rang == j)
                            {      // la premiere propriete est dans la ligne 1
                                ligne = lignes[rang];
                                sortir = true;
                            }
                        }
                    } while ( (i < lignes.Length-1) && (sortir == false) );
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
                    if ( ( i == ligne.Length) || (ligne.ElementAt(i) == Separateur.ElementAt(0)) )
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
                if ( (champs[10].ToUpper() == "FALSE") || (champs[10] == "0") )
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

        public Proprietes CreerNewPropr(int rangDeLaProprieteDansFichier,
                string _ProprURL, string _Adresse, double _PrixVente, double _PrixMunicipal,
                int _AnneeConstr, DateTime _DateVisite, string _AgentImmob, string _SiteVente,
                bool _Garage, bool _EstAVisiter, int _Cotation, string _Photo, string _Commentaire
            )
        {
            // si rangDeLaProprieteDansFichier est zero, on en ajoutera pas dans le fichier
            // si rangDeLaProprieteDansFichier est non nul, la valeur entree est celle du nombre de proprietes
            Proprietes propr = new Proprietes(
                _ProprURL, _Adresse,  _PrixVente,  _PrixMunicipal,
                _AnneeConstr, _DateVisite, _AgentImmob, _SiteVente,
                _Garage, _EstAVisiter, _Cotation, _Photo,  _Commentaire
                );
            if (rangDeLaProprieteDansFichier != 0) // nouvelle propriete
            {
                propr.ProprID = rangDeLaProprieteDansFichier;       // AugmenterNombreProprDsFichier();
                AjouterDansFichier(propr);
            }
            return propr;
        }

        public int AugmenterNombreProprDsFichier()
        {
            int nb = 0;
            try
            {
                StreamReader sr = new StreamReader(NomFichier);
                string[] lignes = System.IO.File.ReadAllLines(NomFichier);
                sr.Close();
                // ecrire dans le fichier en incrementant la 1ere ligne
                StreamWriter sw = new StreamWriter(NomFichier);
                for (int j = 0; j < lignes.Length; j++)
                {
                    if (j == 0)
                    {
                        // le nombre de lignes ajouté 
                        nb = lignes.Length;
                        sw.WriteLine(lignes.Length);
                    }
                    else
                    {
                        sw.WriteLine(lignes[j]);
                    }
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Message = "Erreur : " + e.Message;
            }

            return nb;
        }

        public void AjouterUnIdDeProprDsListeProprietes()
        {
            // methode qui ajoute un ID de propriete dans ListeProprietes et y met 0
            // ListProprietes = new List<int>;
            int nbProp = ListeProprietes.Length;
            //     ObtNombreProprFichier();
            int[] Liste = new int[nbProp + 1];
            // renseigner la 1ere valeur
            Liste[0] = nbProp;
            // charger le contenu avant modification
            string Mess = Liste[0].ToString() + "  ";     // string.Empty;
            for (int j = 1; j < nbProp; j++)
            {
                Liste[j] = ListeProprietes[j];
                Mess += Liste[j].ToString() + "  "; 
            }
            // augmenter le nombre de propr
            // ListeProprietes = new int[nbProp];
            ListeProprietes = Liste;
            for (int j = 0; j < nbProp + 1; j++)
            {
               Message += ListeProprietes[j].ToString() + "  "; 
            }

            // Message = ListeProprietes[nbProp].ToString();
            // Message = ListeProprietes[nbProp-1].ToString();
        }


        protected void BtnNvlleAction_Click(object sender, EventArgs e)
        {
            ActionsDeProgrammationAVerifier();

        }


    }
}