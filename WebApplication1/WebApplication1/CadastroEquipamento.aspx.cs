using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1
{
    public partial class CadastroEquipamento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            EquipamentoVO equipamento = new EquipamentoVO();
            equipamento.Nome = TxtNome.Text;
            equipamento.Valor = Convert.ToDecimal(TxtValor.Text);
            equipamento.DataCadastro = 
            Convert.ToDateTime(TxtDataCadastro.Text);


            MeuServicoWCF.ServicoClient servico = new MeuServicoWCF.ServicoClient();

            servico.Inserir(equipamento);

        }
    }
}