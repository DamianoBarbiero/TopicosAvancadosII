<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="EstacionamentoEntrada.aspx.cs" Inherits="ProjEstacionamento.EstacionamentoEntrada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.0/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.0/jquery-ui.js"></script>
    <script>
    </script>
    <form id="form1" runat="server">
        <article class="kanban-entry grab" id="item1" draggable="true">
            <div class="kanban-entry-inner">
                <div class="kanban-label">
                    <h2><a href="#">Estacionamento Entrada</a> <span></span></h2>
                    <p></p>
                </div>
            </div>
        </article>
        <div class="form-group">
            <label for="descricao">Descrição:</label>
            <asp:TextBox class="form-control" name="txtDescricao" ID="txtDescricao"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Data">DataEntrada:</label>
            <asp:TextBox class="form-control" name="txtDataentrada" ID="txtDataentrada"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="descricao">NomeCliente:</label>
            <asp:TextBox class="form-control" name="txtNomecliente" ID="txtNomecliente"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="descricao">Telefone:</label>
            <asp:TextBox class="form-control" name="txtTelefone" ID="txtTelefone"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="descricao">Valor:</label>
            <asp:TextBox class="form-control" name="txtValor" ID="txtValor"
                runat="server"></asp:TextBox>
        </div>
        <asp:Button class="btn btn-primary" ID="btnCadastrar" runat="server" Text="Salvar"
            OnClick="btnCadastrar_Click" />
    </form>
    <br />
    <% if (!String.IsNullOrEmpty(lblmsg.Text))
        {%>
    <div class="alert alert-success">
        <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
        <strong>
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></strong>
    </div>
    <%} %>
</asp:Content>
