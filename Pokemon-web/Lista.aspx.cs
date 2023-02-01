using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace Pokemon_web
{
    public partial class Lista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Seguridad.esAdmin(Session["Trainee"]))
            {
                Session.Add("Error", "No se puede ingresar a esta pantalla sin perfil admin");
                Response.Redirect("Error.aspx");
            }
            //FiltroAvanzado = chkAvanzado.Checked; * se puede validar el check aqui o en lista.aspx
            //* como lo hago en este ejemplo
            
            if (!IsPostBack)
            {
                //FiltroAvanzado = false; * se cambio y se llevo arriba por no mantener la informacion del checkbox
                PokemonNegocio Negocio = new PokemonNegocio();
                Session.Add("listapoke", Negocio.listarConSP());
                dgvPokemon.DataSource = Session["listapoke"];
                dgvPokemon.DataBind();
            }
        }

        protected void dgvPokemon_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemon.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id=" + id);

        }

        protected void dgvPokemon_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemon.PageIndex = e.NewPageIndex;
            dgvPokemon.DataBind();
        }

        protected void txtfiltrar_TextChanged(object sender, EventArgs e)
        {

            List<Pokemon> lista = (List<Pokemon>)Session["listapoke"];
            List<Pokemon> listafiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtfiltrar.Text.ToUpper()));
            dgvPokemon.DataSource= listafiltrada;
            dgvPokemon.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtfiltrar.Enabled = !FiltroAvanzado;

        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            
            if (ddlCampo.SelectedItem.ToString() == "Número")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");

            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvPokemon.DataSource= negocio.filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltro.Text,
                    ddlEstado.SelectedItem.ToString());
                dgvPokemon.DataBind();


            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
            }
        }
    }
}