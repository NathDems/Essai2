<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="Remax.aspx.cs" Inherits="projetFinEtude.Remax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <p><div class="embed-responsive embed-responsive-16by9">
        <iframe class="embed-responsive-item" src="https://www.remax.ca/" allowfullscreen></iframe>
    </div></p>

        <p><section class="container">
            <form runat="server">
            <div class="col-md-12">
                <asp:Button ID="Ajouter" runat="server" Text="Ajouter" class="btn btn-success active"  Onclick="Ajouter_Click"/>
            </div>
            <div>
                 <asp:Label ID="LblMessage" runat="server" Text="" ></asp:Label>
                 <asp:Button ID="EffaceMessage" runat="server" Text="Efface le Message" visible="false" onclick="EffaceMessage_Click" class="btn btn-success active"/>
            </div>
            </form>
        </section></p>
</asp:Content>
