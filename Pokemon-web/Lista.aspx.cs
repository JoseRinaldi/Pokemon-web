using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace Pokemon_web
{
    public partial class Lista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio Negocio = new PokemonNegocio();
            dgvPokemon.DataSource = Negocio.listarConSP();
            dgvPokemon.DataBind();
        }
    }
}