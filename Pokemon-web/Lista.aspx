<%@ Page Title="" Language="C#" MasterPageFile="~/miMaestra.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Pokemon_web.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>lista de pokemons</h1>
    <asp:GridView ID="dgvPokemon" runat="server"  CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id"
        OnSelectedIndexChanged="dgvPokemon_SelectedIndexChanged" OnPageIndexChanging="dgvPokemon_PageIndexChanging"
        AllowPaging="true" PageSize="5">

        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Numero" DataField="Numero" />
            <asp:BoundField HeaderText="Descripción" DataField="Tipo.Descripcion" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="👈" />

        </Columns>
    </asp:GridView>
    <a href="FormularioPokemon.aspx" CssClass="btn btn-primary" >Agregar</a>
</asp:Content>
