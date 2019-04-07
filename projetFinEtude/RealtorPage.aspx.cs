using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace projetFinEtude
{
    public partial class RealtorPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EffaceMessage_Click(object sender, EventArgs e)
        {
             LblMessage.Text = String.Empty;
            EffaceMessage.Visible = false;
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            // TODO  AjouterPropriete(prop);
            LblMessage.Text = "Ajout réussi";
            EffaceMessage.Visible = true;
        }

        
    }
}