using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projetFinEtude
{
    public partial class Agenda : System.Web.UI.Page
    {
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
            dt.Columns.Add(dcNum);
            dt.Columns.Add(dcImg);
            dt.Columns.Add(dcPrix);
            dt.Columns.Add(dcEval);
            dt.Columns.Add(dcAnnee);
            dt.Columns.Add(dcAdresse);
            dt.Columns.Add(dcAgence);
            dt.Columns.Add(dcAgent);

            ChargerGrille();
        }
        protected override void OnLoadComplete(EventArgs e)
        {
            base.OnLoadComplete(e);
            GridView1.PageSize = int.Parse(DropDownList1.SelectedValue);
            LblProprietes.Text = dt.Rows.Count + " propriété(s) au total.";

            //  ChargerGrille();
        }

        public void ChargerGrille()
        {
            //if (!this.IsPostBack)
            //{
            DataRow ligne1 = dt.NewRow();
            ligne1["id"] = 1;
            ligne1["image"] = "/img/Prop1.jpg";
            ligne1["prix"] = 400000;
            ligne1["evaluation"] = 405000;
            ligne1["annee"] = 1984;
            ligne1["adresse"] = "110 Montreal st, Ottawa";
            ligne1["agence"] = "Du Proprio";
            ligne1["agent"] = "Levesque C";
            dt.Rows.Add(ligne1);

            DataRow ligne2 = dt.NewRow();
            ligne2["id"] = 2;
            ligne2["image"] = "/img/Prop2.jpg";
            ligne2["prix"] = 450000;
            ligne2["evaluation"] = 425000;
            ligne2["annee"] = 2015;
            ligne2["adresse"] = "404 currie st, Ottawa";
            ligne2["agence"] = "Donkeng";
            ligne2["agent"] = "Gabrielle";
            dt.Rows.Add(ligne2);

            DataRow ligne3 = dt.NewRow();
            ligne3["id"] = 3;
            ligne3["image"] = "/img/Prop3.jpg";
            ligne3["prix"] = 300000;
            ligne3["evaluation"] = 260000;
            ligne3["annee"] = 2000;
            ligne3["adresse"] = "40 labelle st, Ottawa";
            ligne3["agence"] = "REmax";
            ligne3["agent"] = "Tamo";
            dt.Rows.Add(ligne3);

            DataRow ligne4 = dt.NewRow();
            ligne4["id"] = 4;
            ligne4["image"] = "/img/Prop4.jpg";
            ligne4["prix"] = 750000;
            ligne4["evaluation"] = 725000;
            ligne4["annee"] = 2018;
            ligne4["adresse"] = "40 labelle st, Ottawa";
            ligne4["agence"] = "Realtor";
            ligne4["agent"] = "Dupont";
            dt.Rows.Add(ligne4);

            Session["mydata"] = dt;
            Session1();
            //GridView1.DataSource = dt.DefaultView;
            //GridView1.DataBind();
        }

        protected void Session1()
        {
            GridView1.PageSize = int.Parse(DropDownList1.SelectedValue);
            DataTable dt = (DataTable)Session["mydata"];
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


        public void Wait(int x)
        {
            DateTime t = DateTime.Now;
            DateTime tf = DateTime.Now.AddSeconds(x);
            while (t < tf)
            {
                t = DateTime.Now;
            }
        }

        protected void BtnSupprimer_Click(object sender, EventArgs e)
        {
            // Supprimer toutes les proprietes cochees

            LblMessage.Text = "Suppression reussie ...";
            // Wait(3);
            EffaceMessage.Visible = true;
        }

        protected void EffaceMessage_Click(object sender, EventArgs e)
        {
            LblMessage.Text = String.Empty;
            EffaceMessage.Visible = false;
        }

        protected void BtnImprimer_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAjouter_Click(object sender, EventArgs e)
        {

        }

        protected void printButton_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "PrintOperation", "printing()", true);
        }
    }
}