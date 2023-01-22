<%@ Page Title="" Language="C#" MasterPageFile="~/miMaestra.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokemon_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>hola</h1>

    <h4>Bienvenido a Pokedex, tu mejor lugar de pokemons</h4>
    <div class="row row-cols-1 row-cols-md-3 g-4">

     <%--   <%foreach (dominio.Pokemon poke in listaPokemon)

            {%>

        <div class="col">
            <div class="card">
                <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: poke.Nombre %></h5>
                    <p class="card-text"><%: poke.Descripcion %></p>
                    <a href="Detalle.aspx?id=" <%:+ poke.Id %>>Ver Detalle</a>
                </div>
            </div>
        </div>

        <%  } %>--%>

        <asp:Repeater ID="rptRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <p class="card-text"><%#Eval("Descripcion") %></p>
                            <a href="Detalle.aspx?id=" <%#Eval("Id") %>>Ver Detalle</a>
                            <asp:Button Text="Ejemplo" ID="btnEjemplo" CssClass="btn btn-primary" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="pokemonId" OnClick="btnEjemplo_Click"/>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
