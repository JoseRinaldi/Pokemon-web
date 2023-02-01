<%@ Page Title="" Language="C#" MasterPageFile="~/miMaestra.Master" AutoEventWireup="true" CodeBehind="Lista.aspx.cs" Inherits="Pokemon_web.Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>lista de pokemons</h1>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <asp:Label Text="Filtrar" runat="server" />
                        <asp:TextBox ID="txtfiltrar" runat="server" CssClass="form-control" OnTextChanged="txtfiltrar_TextChanged"></asp:TextBox>
                    </div>
                </div>
                <div class="col-6">
                    <div class="mb-3">
                        <asp:CheckBox Text="Filtro Avanzado" ID="chkAvanzado" CssClass=""
                            AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" />

                    </div>
                </div>
            </div>

    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updatepanel2" runat="server">
        <ContentTemplate>
            <%if (chkAvanzado.Checked) //(FiltroAvanzado) antes llamaba a la función ahora lo valido acá
                {%>

            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Campo" runat="server" />
                        <asp:DropDownList CssClass="form-control" ID="ddlCampo" AutoPostBack="true" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" runat="server">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Tipo" />
                            <asp:ListItem Text="Número" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" runat="server" />
                        <asp:DropDownList CssClass="form-control" ID="ddlCriterio" runat="server">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" runat="server" />
                        <asp:TextBox ID="txtFiltro" CssClass="form-control" runat="server" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Estado" runat="server" />
                        <asp:DropDownList CssClass="form-control" ID="ddlEstado" runat="server">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activos" />
                            <asp:ListItem Text="Inactivos" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" runat="server" />

                    </div>
                </div>
            </div>
            <% } %>

            <asp:GridView ID="dgvPokemon" runat="server" CssClass="table" AutoGenerateColumns="false" DataKeyNames="Id"
                OnSelectedIndexChanged="dgvPokemon_SelectedIndexChanged" OnPageIndexChanging="dgvPokemon_PageIndexChanging"
                AllowPaging="true" PageSize="5">

                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Numero" DataField="Numero" />
                    <asp:BoundField HeaderText="Descripción" DataField="Tipo.Descripcion" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="👈" />

                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <a href="FormularioPokemon.aspx" cssclass="btn btn-primary">Agregar</a>
</asp:Content>
