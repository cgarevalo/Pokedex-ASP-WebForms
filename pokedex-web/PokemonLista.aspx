﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="PokemonLista.aspx.cs" Inherits="pokedex_web.PokemonLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--El AllowPaging="true" es para permitir las páginas en el grid view, PageSize="5" es para definir el tamaño de la página (5 pokemons en este caso) y OnPageIndexChanging es para crear el evento que haga que el grid pueda cambiar de páginas--%>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-6">
                    <div class="mb-3">
                        <label for="txtFiltro" class="form-label">Filtrar</label>
                        <asp:TextBox ID="txtFiltro" AutoPostBack="true" CssClass="form-control" OnTextChanged="txtFiltro_TextChanged" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-6">
                <div class="mb-3">
                    <label for="chkAvanzado" class="form-label" >Filtro avanzado</label>
                    <asp:CheckBox ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" runat="server" />
                </div>
            </div>

            <%if (FiltroAvanzado)
                {%>
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <label for="ddlcampo" class="form-label" >Campo</label>
                        <asp:DropDownList ID="ddlCampo" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Tipo" />
                            <asp:ListItem Text="Número" />
                        </asp:DropDownList>
                        <div class="row">
                            <div class="mb-3 mt-3">
                                <asp:Button ID="btnVaciarFiltro" runat="server" CssClass="btn btn-secondary" Text="Vaciar filtros" OnClick="btnVaciarFiltro_Click" />
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <label for="ddlCriterio" class="form-label" >Criterio</label>
                        <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <label for="txtFiltroAvanzado" class="form-label" >Filtro</label>
                        <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-3">
                    <div class="mb-3">
                        <label for="ddlEstado" class="form-label" >Estado</label>
                        <asp:DropDownList ID="ddlEstado" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Button ID="Buscar" CssClass="btn btn-primary" runat="server" OnClick="Buscar_Click" Text="Buscar" />
                    </div>
                </div>
            </div>
            <%  }%>

            <h1>Lista de pokemons</h1>
            <asp:GridView ID="dgvPokemons" CssClass="table" runat="server"
                AutoGenerateColumns="false" DataKeyNames="Id"
                OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
                OnPageIndexChanging="dgvPokemons_PageIndexChanging"
                AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Número" DataField="Numero" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField ShowSelectButton="true" SelectText="✍" HeaderText="Acción" />
                </Columns>
            </asp:GridView>

        </ContentTemplate>
    </asp:UpdatePanel>

    <a href="FormularioPokemon.aspx" class="btn btn-primary">Agregar</a>
</asp:Content>
