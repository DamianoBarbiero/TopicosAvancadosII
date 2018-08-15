using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjEstacionamento
{
    public partial class DefaultEstaSaida : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarLista();
        }

        private void CarregarLista()
        {
            EstacionamentoDBEntities context = new EstacionamentoDBEntities();
            List<TB_ESTACIONAMENTO> lstViagem = context.TB_ESTACIONAMENTO.ToList<TB_ESTACIONAMENTO>();

            GVESTASAIDA.DataSource = lstViagem;
            GVESTASAIDA.DataBind();
        }


        protected void GVESTASAIDA_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int iditem = Convert.ToInt32(e.CommandArgument.ToString());
            EstacionamentoDBEntities contextEsta = new EstacionamentoDBEntities();
            TB_ESTACIONAMENTO carro = new TB_ESTACIONAMENTO();

            carro = contextEsta.TB_ESTACIONAMENTO.First(c => c.id == iditem);
            if (e.CommandName == "Alterar")
            {
                Response.Redirect("EstacionamentoEntrada.aspx?iditem=" + iditem);

            }
            else if (e.CommandName == "Exluir")
            {
                contextEsta.TB_ESTACIONAMENTO.Remove(carro);
                contextEsta.SaveChanges();
                string msg = "Viagem excluida";
                string titulo = "informação";
                CarregarLista();
                DisplayAlert(titulo, msg, this);
            }
        }

        public void DisplayAlert(string titulo, string mensagem, System.Web.UI.Page page)
        {
            h1.InnerText = titulo;
            lblMsgPopup.InnerText = mensagem;
            ClientScript.RegisterStartupScript(typeof(Page), Guid.NewGuid().ToString(), "MostrarPopupMensagem();", true);
        }
    }
}