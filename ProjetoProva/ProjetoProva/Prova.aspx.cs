using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoProva
{
    public partial class Prova : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDadosPagina();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string descricaoProva = txtDescricao.Text;
            DateTime data = Convert.ToDateTime(txtData.Text);
            Decimal notaProva1 = Convert.ToDecimal(txtNota1.Text);
            Decimal notaProva2 = Convert.ToDecimal(txtNota2.Text);
            Decimal mediaProva = Convert.ToDecimal(txtMedia.Text);
            TB_PROVA v = new TB_PROVA() { descricao = descricaoProva, data = data, nota1=notaProva1, nota2=notaProva2, media=mediaProva };
            ProvaDBEntities contextProva = new ProvaDBEntities();

            string valor = Request.QueryString["iditem"];

            if (string.IsNullOrEmpty(valor))
            {
                contextProva.TB_PROVA.Add(v);
                lblmsg.Text = "Registro inserido";
                Clear();

            }
            else
            {
                int id = Convert.ToInt32(valor);
                TB_PROVA prova = contextProva.TB_PROVA.First(c => c.id == id);
                prova.descricao = v.descricao;
                prova.data = v.data;
                prova.nota1 = v.nota1;
                prova.nota2 = v.nota2;
                prova.media = v.media;
                lblmsg.Text = "Registro alterado";
            }
            contextProva.SaveChanges();
        }

        private void Clear()
        {
            txtData.Text = "";
            txtNota1.Text = "";
            txtNota2.Text = "";
            txtDescricao.Text = "";
            txtDescricao.Focus();
        }

        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["iditem"];
            int iditem = 0;
            TB_PROVA prova = new TB_PROVA();
            ProvaDBEntities contextProva = new ProvaDBEntities();

            if (!String.IsNullOrEmpty(valor))
            {
                iditem = Convert.ToInt32(valor);
                prova = contextProva.TB_PROVA.First(c => c.id == iditem);

                txtDescricao.Text = prova.descricao;
                txtData.Text = prova.data.ToString();
                txtNota1.Text = prova.nota1.ToString();
                txtNota2.Text = prova.nota2.ToString();
                txtMedia.Text = prova.media.ToString();
            }
        }

        protected void txtMedia_TextChanged(object sender, EventArgs e)
        {
            txtMedia.Text = Convert.ToDouble((Convert.ToInt32(txtNota1.Text) + Convert.ToInt32(txtNota2.Text))/2).ToString();
        }
    }
}