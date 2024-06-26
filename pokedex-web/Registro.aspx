﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="pokedex_web.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4">
            <h1>Creá tu perfil trainee</h1>
            <div class="mb-3">
                <label class="form-label" for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label class="form-label" for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <asp:Button ID="btnRegistrarse" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" runat="server" Text="Registrarse" />
            <a href="Default.aspx" class="btn btn-secondary">Cancelar</a>
        </div>
    </div>
</asp:Content>
