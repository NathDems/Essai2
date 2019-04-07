using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace projetFinEtude
{

    public class Proprietes
    {
        // private int NombrePropr;
        public string NomFichier = @"C:\TCHEDK\LaCite\Session 4\Projet de fin d'études\Developpement\CourtierPersonnel\ProjetFinEtude\Proprietes.txt";
        public string Message = string.Empty;

        public int ProprID;     
        public string ProprURL;
        public string Adresse;
        public double PrixVente;
        public double PrixMunicipal;
        public int AnneeConstr;
        public DateTime DateVisite;
        public string AgentImmob;
        public string SiteVente;
        public bool Garage;
        public bool EstAVisiter;
        public int Cotation;        // de 1 a 5, 3 etant la valeur mediane. 0 si aucune valeur donnee
        public string Photo;      // le nom du fichier avec son chemin complet;
        public string Commentaire;

        public Proprietes()
        {

            ProprID = 0;        // NombrePropr;
            ProprURL = "";
            Adresse = "";
            PrixVente = 0;
            PrixMunicipal = 0;
            AnneeConstr = 2019;
            DateVisite = DateTime.Today;
            AgentImmob = "";
            SiteVente = "";
            Garage = false;
            EstAVisiter = false;
            Cotation = 0;
            Photo = "";
            Commentaire = "";
        }

        public Proprietes(  string _ProprURL, string _Adresse, double _PrixVente, double _PrixMunicipal,
                            int _AnneeConstr, DateTime _DateVisite, string _AgentImmob, string _SiteVente,
                            bool _Garage, bool _EstAVisiter, int _Cotation, string _Photo, string _Commentaire)
        {

            // ProprID : Ce champ est introduit par la methode CreerNewPropr qui calcule 
            // le nombre de proprietes du fichier a partir de ce qui y est inscrit a la 1ere ligne
            ProprID = 0;
            ProprURL = _ProprURL;
            Adresse = _Adresse;
            PrixVente = _PrixVente;
            PrixMunicipal = _PrixMunicipal;
            AnneeConstr = _AnneeConstr;
            DateVisite = _DateVisite; // DateTime.Today;
            AgentImmob = _AgentImmob;
            SiteVente = _SiteVente ;
            Garage = _Garage;
            EstAVisiter = _EstAVisiter;
            Cotation = _Cotation;
            Photo = _Photo;
            Commentaire = _Commentaire;
        }

        public override string ToString()
        {
            return ProprID + ProprURL + Adresse + PrixVente + PrixMunicipal + AnneeConstr + DateVisite + AgentImmob +
                SiteVente + Garage + EstAVisiter + Cotation + Photo + Commentaire;
        }
    }
}