using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace pokedex_web
{
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //PokemonNegocio negocio = new PokemonNegocio();
            //List<Pokemon> tipos = negocio.ListarConSP();
            //ddlTipo.DataSource = tipos;
            //ddlTipo.DataBind();
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}