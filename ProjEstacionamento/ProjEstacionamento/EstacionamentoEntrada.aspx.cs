using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjEstacionamento
{
    public partial class EstacionamentoEntrada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string descr = txtDescricao.Text;
            string dten = txtDataentrada.Text;
            string nomecli = txtNomecliente.Text;
            string telef = txtTelefone.Text;
            string val = txtValor.Text;
            TB_ESTACIONAMENTO v = new TB_ESTACIONAMENTO() { descricao = descr, dataentrada = dten, nomecliente = nomecli, telefone = telef, valor = val };
            EstacionamentoDBEntities contextEstacionamento = new EstacionamentoDBEntities();

            string valor = Request.QueryString["iditem"];

            if (string.IsNullOrEmpty(valor))
            {
                contextEstacionamento.TB_ESTACIONAMENTO.Add(v);
                lblmsg.Text = "Registro inserido";
                Clear();

            }
            else
            {
                int id = Convert.ToInt32(valor);
                TB_ESTACIONAMENTO est = contextEstacionamento.TB_ESTACIONAMENTO.First(c => c.id == id);
                est.descricao = v.descricao;
                est.dataentrada = v.dataentrada;
                est.nomecliente = v.nomecliente;
                est.telefone = v.telefone;
                est.valor = v.valor;
                lblmsg.Text = "Registro alterado";
            }
            contextEstacionamento.SaveChanges();

        }

        private void Clear()
        {

            txtDataentrada.Text = "";
            txtNomecliente.Text = "";
            txtTelefone.Text = "";
            txtValor.Text = "";
            txtDescricao.Text = "";
            txtDescricao.Focus();
        }

        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["iditem"];
            int iditem = 0;
            TB_ESTACIONAMENTO estac = new TB_ESTACIONAMENTO();
            EstacionamentoDBEntities contetEstac = new EstacionamentoDBEntities();

            if (!String.IsNullOrEmpty(valor))
            {
                iditem = Convert.ToInt32(valor);
                estac = contetEstac.TB_ESTACIONAMENTO.First(c => c.id == iditem);

                txtDescricao.Text = estac.descricao;
                txtDataentrada.Text = estac.dataentrada;
                txtNomecliente.Text = estac.nomecliente;
                txtTelefone.Text = estac.telefone;
                txtValor.Text = estac.valor;

            }
        }
    }
}