<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="pokedex_web.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-6">
        <div class="mb-3">
            <label for="txtId" class="form-label">ID</label>
            <asp:TextBox ID="txtId" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtNumero" class="form-label">Número</label>
            <asp:TextBox ID="txtNumero" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="txtDescripcion" class="form-label">Descripción</label>
            <asp:TextBox ID="txtDescripcion" CssClass="form-control" TextMode="MultiLine" runat="server"></asp:TextBox>
        </div>
        <div class="mb-3">
            <label for="ddlTipo" class="form-label">Tipo</label>
            <asp:DropDownList ID="ddlTipo" runat="server"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <label for="ddlDebilidad" class="form-label">Debilidad</label>
            <asp:DropDownList ID="ddlDebilidad" runat="server"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <asp:Button ID="btnAceptar" CssClass="btn btn-primary" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
            <a href="PokemonLista.aspx" class="btn btn-secondary" >Cancelar</a>
        </div>
    </div>
</asp:Content>
