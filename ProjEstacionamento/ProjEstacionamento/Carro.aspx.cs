using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjEstacionamento
{
    public partial class Carro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string anfa = txtAnofabric.Text;
            string anmo = txtAnomodelo.Text;
            string cor = txtCor.Text;
            string marca = txtMarca.Text;
            string modelo = txtModelo.Text;
            TB_CARRO v = new TB_CARRO() {anofabric = anfa, anomodelo = anmo, cor = cor, marca = marca, modelo = modelo };
            EstacionamentoDBEntities contextEstacionamento = new EstacionamentoDBEntities();

            string valor = Request.QueryString["iditem"];

            if (string.IsNullOrEmpty(valor))
            {
                contextEstacionamento.TB_CARRO.Add(v);
                lblmsg.Text = "Registro inserido";
                Clear();

            }
            else
            {
                int id = Convert.ToInt32(valor);
                TB_CARRO carro = contextEstacionamento.TB_CARRO.First(c => c.id == id);
                carro.anofabric = v.anofabric;
                carro.anomodelo = v.anomodelo;
                carro.cor = v.cor;
                carro.marca = v.marca;
                carro.modelo = v.modelo;
                lblmsg.Text = "Registro alterado";
            }
            contextEstacionamento.SaveChanges();
        }

        private void Clear()
        {
            
            txtAnomodelo.Text =  "";
            txtCor.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtAnofabric.Text = "";
            txtAnofabric.Focus();
        }

        private void CarregarDadosPagina()
        {
            string valor = Request.QueryString["iditem"];
            int iditem = 0;
            TB_CARRO carro = new TB_CARRO();
            EstacionamentoDBEntities contetCarro = new EstacionamentoDBEntities();

            if (!String.IsNullOrEmpty(valor))
            {
                iditem = Convert.ToInt32(valor);
                carro = contetCarro.TB_CARRO.First(c => c.id == iditem);

                txtAnofabric.Text = carro.anofabric;
                txtAnomodelo.Text = carro.anomodelo;
                txtCor.Text = carro.cor;
                txtMarca.Text = carro.marca;
                txtModelo.Text = carro.modelo;
                
            }
        }
    }
}