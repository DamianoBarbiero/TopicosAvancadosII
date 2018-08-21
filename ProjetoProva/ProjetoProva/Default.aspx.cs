using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoProva
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarLista();
        }

        private void CarregarLista()
        {
            ProvaDBEntities context = new ProvaDBEntities();
            List<TB_PROVA> lstProva = context.TB_PROVA.ToList<TB_PROVA>();

            GVProva.DataSource = lstProva;
            GVProva.DataBind();
        }


        protected void GVProva_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int iditem = Convert.ToInt32(e.CommandArgument.ToString());
            ProvaDBEntities contextProva = new ProvaDBEntities();
            TB_PROVA prova = new TB_PROVA();

            prova = contextProva.TB_PROVA.First(c => c.id == iditem);
            if (e.CommandName == "ALTERAR")
            {
                Response.Redirect("Prova.aspx?iditem=" + iditem);

            }
            else if (e.CommandName == "EXCLUIR")
            {
                contextProva.TB_PROVA.Remove(prova);
                contextProva.SaveChanges();
                string msg = "Prova excluida";
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

        protected void GVProva_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}