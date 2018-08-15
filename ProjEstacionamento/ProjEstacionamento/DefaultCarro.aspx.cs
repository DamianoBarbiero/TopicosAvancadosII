using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjEstacionamento
{
    public partial class DefaultCarro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarLista();

        }

        private void CarregarLista() {
            EstacionamentoDBEntities context = new EstacionamentoDBEntities();
            List<TB_CARRO> lstViagem = context.TB_CARRO.ToList<TB_CARRO>();

            GVCARRO.DataSource = lstViagem;
            GVCARRO.DataBind();
        }

        protected void GVCARRO_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int iditem = Convert.ToInt32(e.CommandArgument.ToString());
            EstacionamentoDBEntities contextCarro = new EstacionamentoDBEntities();
            TB_CARRO carro = new TB_CARRO();

            carro = contextCarro.TB_CARRO.First(c => c.id == iditem);
            if (e.CommandName == "Alterar")
            {
                Response.Redirect("Carro.aspx?iditem=" + iditem);

            }
            else if (e.CommandName == "Exluir")
            {
                contextCarro.TB_CARRO.Remove(carro);
                contextCarro.SaveChanges();
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