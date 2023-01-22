<%@ Page Title="" Language="C#" MasterPageFile="~/miMaestra.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Pokemon_web.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>lista de pokemons</h1>
    <asp:GridView ID="dgvPokemon" runat="server"  CssClass="table" AutoGenerateColumns="false">

        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Tipo.Descripcion" />


        </Columns>

    </asp:GridView>



</asp:Content>
