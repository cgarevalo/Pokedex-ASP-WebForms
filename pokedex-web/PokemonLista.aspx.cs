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
    public partial class PokemonLista : System.Web.UI.Page
    {
        public bool FiltroAvanzado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;

            if (!IsPostBack)
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Session.Add("listaPokemons", negocio.ListarConSP());
                dgvPokemons.DataSource = Session["listaPokemons"];
                dgvPokemons.DataBind();
            }
        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id=" + id);
        }

        // Evento para cambiar de pagina del grid view
        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Este fragmento es para que enlace los datos antes de cambiar de página, así no sale el problema de que desaparezcan todos los datos del grid view. No se puede desde el Load porque el enlace inicial esta dentro de un if(!IsPostback)
            dgvPokemons.DataSource = Session["listaPokemons"];
            dgvPokemons.DataBind();

            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> lista = (List<Pokemon>)Session["listaPokemons"];
            List<Pokemon> listaFiltrada = lista.FindAll(poke => poke.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()));
            dgvPokemons.DataSource= listaFiltrada;
            dgvPokemons.DataBind();
        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;

            // Inhabilita el filtro rápido, si se dió en el checked
            txtFiltro.Enabled = !FiltroAvanzado;
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Vacia el contenido de ddlCriterio, antes de cargarlo, para que no se acumulen
            ddlCriterio.Items.Clear();

            // Switch para cargar los items de ddlCriterio
            switch (ddlCampo.SelectedItem.ToString())
            {
                case "Número":
                    ddlCriterio.Items.Add("Igual a");
                    ddlCriterio.Items.Add("Mayor a");
                    ddlCriterio.Items.Add("Menor a");
                    break;

                case "Tipo":
                    ddlCriterio.Items.Add("Contiene");
                    ddlCriterio.Items.Add("Comienza con");
                    ddlCriterio.Items.Add("Termina con");
                    break;
            }

            //if (ddlCampo.SelectedItem.ToString() == "Número")
            //{
            //    ddlCriterio.Items.Add("Igual a");
            //    ddlCriterio.Items.Add("Mayor a");
            //    ddlCriterio.Items.Add("Menor a");
            //}
            //else
            //{
            //    ddlCriterio.Items.Add("Contiene");
            //    ddlCriterio.Items.Add("Comienza con");
            //    ddlCriterio.Items.Add("Termina con");
            //}
        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            string campo = ddlCampo.SelectedItem.ToString();
            string criterio = ddlCriterio.SelectedItem.ToString();
            string filtro = txtFiltroAvanzado.Text;
            string estado = ddlEstado.SelectedItem.ToString();

            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                dgvPokemons.DataSource = negocio.Filtrar(campo, criterio, filtro, estado);
                dgvPokemons.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnVaciarFiltro_Click(object sender, EventArgs e)
        {
            // Deselecciona los filtros
            ddlCampo.ClearSelection();
            ddlCriterio.ClearSelection();
            // Vacía el txtFiltroAvanzado
            txtFiltroAvanzado.Text = "";
            ddlEstado.ClearSelection();

            // Restaurar la lista completa de datos
            dgvPokemons.DataSource = Session["listaPokemons"];
            dgvPokemons.DataBind();

            // Vacía a ddlCriterio
            ddlCriterio.Items.Clear();
        }
    }
}