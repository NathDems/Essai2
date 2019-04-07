<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="RealtorPage.aspx.cs" Inherits="projetFinEtude.RealtorPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p><div class="embed-responsive embed-responsive-16by9">
        <iframe class="embed-responsive-item" src="https://www.realtor.ca/" allowfullscreen></iframe>
    </div></p>

        <p><section class="container">
            <div class="col-md-12">
                <form runat="server">
                    <asp:Button ID="Button1" runat="server" Text="Ajouter" class="btn btn-success active" OnClick="Button1_Click1"/>
                    <div>
                        <asp:Label ID="LblMessage" runat="server" Text="" ></asp:Label>
                        <asp:Button ID="EffaceMessage" runat="server" Text="Efface le Message" visible="false" onClick="EffaceMessage_Click" class="btn btn-success active"/>
                    </div>
                </form>
            </div>
        </section></p>
</asp:Content>
