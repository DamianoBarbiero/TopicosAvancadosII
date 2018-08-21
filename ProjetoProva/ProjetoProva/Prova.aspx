<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Prova.aspx.cs" Inherits="ProjetoProva.Prova" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.0/themes/base/jquery-ui.css" />
    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.0/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#<%= txtData.ClientID %>").datepicker({
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
        });
    </script>
    <script>
        function myFunction() {
            var nota1 = document.getElementById("txtNota1");
            var nota2 = document.getElementById("txtNota2");
            //nota1.value = nota1.value.toUpperCase();
        }
</script>
    <form id="form1" runat="server">
        <article class="kanban-entry grab" id="item1" draggable="true">
            <div class="kanban-entry-inner">
                <div class="kanban-label">
                    <h2><a href="#">Controle de Provas</a> <span></span></h2>
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
            <label for="Data">Data:</label>
            <asp:TextBox class="form-control" name="txtData" ID="txtData"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Nota1">Nota1:</label>
            <asp:TextBox class="form-control" name="txtNota1" ID="txtNota1"
                runat="server"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Nota2">Nota2:</label>
            <asp:TextBox class="form-control" name="txtNota2" ID="txtNota2"
                runat="server" ></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="Media">Media:</label>
            <asp:TextBox class="form-control" name="txtMedia" ID="txtMedia"  value="0"
                runat="server" OnTextChanged="txtMedia_TextChanged"></asp:TextBox>
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
