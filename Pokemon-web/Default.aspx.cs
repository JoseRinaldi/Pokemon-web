using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pokemon_web
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Pokemon> listaPokemon { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio Negocio = new PokemonNegocio();
            listaPokemon = Negocio.listarConSP();

            if (!IsPostBack)
            {
                rptRepetidor.DataSource = listaPokemon;
                rptRepetidor.DataBind();
            }
        }

        protected void btnEjemplo_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
        }
    }
}