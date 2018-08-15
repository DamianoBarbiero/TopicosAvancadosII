<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Carro.aspx.cs" Inherits="ProjEstacionamento.Carro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.0/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.0/jquery-ui.js"></script>
    <script>
        <%--<$(function () {
            $("#<%= txtAnofabric.ClientID %>").datepicker({
                dateFormat: 'dd/mm/yy',
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta',
                    'Sábado', 'Domingo'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho',
                    'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago',
                    'Set', 'Out', 'Nov', 'Dez']
            });
            $("#<%= txtAnomodelo.ClientID %>").datepicker({
                dateFormat: 'dd/mm/yy',
                dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta',
                    'Sábado', 'Domingo'],
                dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'],
                dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'],
                monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho',
                    'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
                monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago',
                    'Set', 'Out', 'Nov', 'Dez']
            });
        });--%>
    </script>
    <form id="form1" runat="server">
        <article class="kanban-entry grab" id="item1" draggable="true">
            <div class="kanban-entry-inner">
                <div class="kanban-label">
                    <h2><a href="#">Carro</a> <span></span></h2>
                    <p></p>
                </div>
            </div>
        </article>
        <div class="form-group">
            <label for="descricao">AnoFabric:</label>
            <asp:TextBox class="form-control" name="txtAnofabric" ID="txtAnofabric"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Data">AnoModelo:</label>
            <asp:TextBox class="form-control" name="txtAnomodelo" ID="txtAnomodelo"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="descricao">Cor:</label>
            <asp:TextBox class="form-control" name="txtCor" ID="txtCor"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="descricao">Marca:</label>
            <asp:TextBox class="form-control" name="txtMarca" ID="txtMarca"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="descricao">Modelo:</label>
            <asp:TextBox class="form-control" name="txtModelo" ID="txtModelo"
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
