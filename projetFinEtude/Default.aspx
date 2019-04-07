<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="projetFinEtude.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section class="container">
        <p>
            <div class="row">
            <form runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="custom-dropdown custom-dropdown--white">
                <asp:Button ID="BtnNvlleAction" runat="server" Text="Lancer nouvelle Action" onClick="BtnNvlleAction_Click"  />

                <asp:DropDownList ID="DdlTri" runat="server" AutoPostBack ="True" Width="150"
                        OnSelectedIndexChanged="DdlTri_SelectedIndexChanged">
                    <asp:ListItem >Choisir un site </asp:ListItem>
                    <asp:ListItem Value ="Remax.aspx">Remax </asp:ListItem>
                    <asp:ListItem Value ="RealtorPage.aspx"> Realtor </asp:ListItem>
                    <asp:ListItem>DuProprio </asp:ListItem>
                </asp:DropDownList> 
                
                <asp:Label ID="LblMessage" runat="server" Text="Message de verification issu des codes"></asp:Label>                
            </span>
            </form>               
            </div>
        </p>
            <div class="row">
                <div class="col">
                    <h6 class="display-4 text-center  d-md-block">Proprietés En Vedettes</h6>
                </div>
            </div>
        </section>
        <section class="container">
            <div class="row">
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m1.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m2.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m3.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m4.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m5.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m6.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m7.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m8.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m9.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m10.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m11.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m12.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m13.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m14.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m15.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m16.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m17.jpg" alt="maison"></div>
                <div class="col-6 col-sm-4 col-md-3 col-lg-2 mb-3"><img class="img-fluid" src="Content/images/m18.jpg" alt="maison"></div>

            </div>
        </section>
</asp:Content>
