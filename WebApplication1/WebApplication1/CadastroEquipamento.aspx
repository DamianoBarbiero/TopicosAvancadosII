<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroEquipamento.aspx.cs" Inherits="ProjWebWCF1.CadastroEquipamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <br />
            Nome<br />
            <asp:TextBox ID="TxtNome" runat="server"></asp:TextBox>
            <br />
            <br />
            Valor<br />
            <asp:TextBox ID="TxtValor" runat="server"></asp:TextBox>
            <br />
            <br />
            Data Cadastro<br />
            <asp:TextBox ID="TxtDataCadastro" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="BtnSalvar" runat="server" OnClick="BtnSalvar_Click" Text="Salvar" />
            <br />

        </div>
    </form>
</body>
</html>
