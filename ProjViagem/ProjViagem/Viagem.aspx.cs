using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjViagem
{
    public partial class Viagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                CarregarDadosPagina();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string descricaoViagem = txtDescricao.Text;
            DateTime data = Convert.ToDateTime(txtdata.Text);
            TB_VIAGEM v = new TB_VIAGEM() { descricao = descricaoViagem, data = data };
            ViagemDBEntities contextViagem = new ViagemDBEntities();

            string valor = Request.QueryString["iditem"];

            if (string.IsNullOrEmpty(valor))
            {
                contextViagem.TB_VIAGEM.Add(v);
                lblmsg.Text = "Registro inserido";
                Clear();

            }
            else {
                int id = Convert.ToInt32(valor);
                TB_VIAGEM viagem = contextViagem.TB_VIAGEM.First(c => c.id == id);
                viagem.descricao = v.descricao;
                viagem.data = v.data;
                lblmsg.Text = "Registro alterado";                
            }
            contextViagem.SaveChanges();
        }

        private void Clear() {
            txtdata.Text = "";
            txtDescricao.Text = "";
            txtDescricao.Focus();
        }

        private void CarregarDadosPagina() {
            string valor = Request.QueryString["iditem"];
            int iditem = 0;
            TB_VIAGEM viagem = new TB_VIAGEM();
            ViagemDBEntities contetViagem = new ViagemDBEntities();

            if (!String.IsNullOrEmpty(valor)) {
                iditem = Convert.ToInt32(valor);
                viagem = contetViagem.TB_VIAGEM.First(c => c.id == iditem);

                txtDescricao.Text = viagem.descricao;
                txtdata.Text = viagem.data.ToString();
            }
        }
    }
}