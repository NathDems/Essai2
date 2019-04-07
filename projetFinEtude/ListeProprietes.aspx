<%@ Page Title="" Language="C#" MasterPageFile="~/PageMaitre.Master" AutoEventWireup="true" CodeBehind="ListeProprietes.aspx.cs" Inherits="projetFinEtude.ListeProprietes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <form id="form1"  runat="server">
        
        <p><div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Button ID="printButton" runat="server" Text="Imprimer" OnClientClick="javascript:window.print();" OnClick="printButton_Click" />
            <asp:Label ID="LblTri" runat="server" Text="Tri : "></asp:Label>
            <span class="custom-dropdown custom-dropdown--white">
                <asp:DropDownList ID="DdlTri" runat="server" AutoPostBack ="True" Width="150">
                    <asp:ListItem>Date </asp:ListItem>
                    <asp:ListItem>Prix </asp:ListItem>
                </asp:DropDownList>
            </span>
            <h6 class="display-4 text-center  d-md-block">Liste Des Proprietés</h6>
        </div></p>
        <div>
           <p><asp:GridView   
               ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="3" 
               OnPageIndexChanging="GridView1_PageIndexChanging" >
                <Columns>
                    <asp:BoundField DataField ="id" HeaderText ="Rang" SortExpression ="Numero"/>
                    <asp:TemplateField HeaderText="Image">
                        <ItemTemplate>
                                <asp:Image  ID="photo" ImageUrl='<%# Eval("image") %>' runat="server" 
                                 Border-radius ="10px" border ="4px"  width = "150" height = "100" display ="grid"  />
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField ="prix" HeaderText ="Prix" SortExpression ="Prix"/>
                    <asp:BoundField DataField ="evaluation" HeaderText ="Evaluation" SortExpression ="evaluation"/>
                    <asp:BoundField DataField ="annee" HeaderText ="Annee" SortExpression ="annee"/>
                    <asp:BoundField HeaderText="Adresse" DataField="Adresse">
                        <ItemStyle Width="50px"></ItemStyle>
                    </asp:BoundField>

                    <asp:BoundField DataField ="agence" HeaderText ="Agence" SortExpression ="agence"/>
                    <asp:BoundField DataField ="agent" HeaderText ="Agent" SortExpression ="agent"/>
    
                    <asp:TemplateField HeaderText="Supprimer">                    
                        <ItemTemplate>
                             <asp:DropDownList 
                                 ID="CmbSelection" runat="server" AutoPostBack="True" >
                             </asp:DropDownList>
                             </br>
                             </br>
                         </ItemTemplate>
 

                        <ItemTemplate>                        
                            <asp:Button  id="BtnSupprimer" runat="server" Text="Supprimer" 
                            enableEventValidation="true"
                            Onclick="BtnSupprimer_Click"/>                        
                         </ItemTemplate>
                    </asp:TemplateField >

                    <asp:TemplateField HeaderText="Agenda">                    
                         <ItemTemplate>
                                <asp:Button  id="BtnAgenda" runat="server" Text="Agenda" OnClick="BtnAgenda_Click"/>
                         </ItemTemplate>
                    </asp:TemplateField >

                    <asp:TemplateField HeaderText="Description">
                        <ItemTemplate>
                            <div>
                                 <asp:Label ID="LblDescription" runat="server" Text="Description"></asp:Label>
                            </div> 
                            <div>
                                 <asp:TextBox ID="TbxDescription" runat="server" TextMode="MultiLine" ></asp:TextBox>
                            </div>
                         </ItemTemplate>

                    </asp:TemplateField>

                </Columns>
            </asp:GridView></p>

            <div>
                <asp:Label ID="LblProprietes" runat="server" Text=""></asp:Label>
            </div>
            <div>
                
                <asp:Label ID="LblPage" runat="server" Text="Nombre par page "></asp:Label>
                <span class="custom-dropdown custom-dropdown--white">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack ="True" Width="50"
                    OnSelectedIndexChanged ="DropDownList1_Changed">
                    <asp:ListItem Value ="3">  3 </asp:ListItem>
                    <asp:ListItem Value ="5"> 5 </asp:ListItem>
                    <asp:ListItem Value ="10"> 10 </asp:ListItem>
                </asp:DropDownList>
                </span>

            </div>
        </div>
        <div>
            <asp:Label ID="LblMessage" runat="server" Text="" ></asp:Label>
            <asp:Button ID="EffaceMessage" runat="server" Text="Efface le Message" visible="false" OnClick="EffaceMessage_Click" class="btn btn-success active"/>
        </div>
    </form>
</asp:Content>
