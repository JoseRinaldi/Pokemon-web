<%@ Page Title="" Language="C#" MasterPageFile="~/miMaestra.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pokemon_web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Login</h1>

       <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <h3>Crea tu perfil trainee</h3>
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox ID="txtEmail" runat="server" REQUIRED="" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtPass" class="form-label">Password</label>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="mb-3">
            <asp:Button Text="Login" ID="btnLogueado" CssClass="btn btn-primary" OnClick="btnLogueado_Click"  runat="server" />
            <a href="Default.aspx">Cancelar</a>
        </div>
    </div>
</asp:Content>
