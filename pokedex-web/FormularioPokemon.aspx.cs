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
        public bool ConfirmaEliminacion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //PokemonNegocio negocio = new PokemonNegocio();
            //List<Pokemon> tipos = negocio.ListarConSP();
            //ddlTipo.DataSource = tipos;
            //ddlTipo.DataBind();
            txtId.Enabled = false;
            ConfirmaEliminacion = false;

            try
            {
                // Configuración inicial de la pantalla

                if (!IsPostBack)
                {
                    NegocioElemento negocio = new NegocioElemento();
                    List<Elemento> elementos = negocio.listar();

                    ddlTipo.DataSource = elementos;
                    ddlTipo.DataValueField = "Id";
                    ddlTipo.DataTextField = "Descripcion";
                    ddlTipo.DataBind();

                    ddlDebilidad.DataSource = elementos;
                    ddlDebilidad.DataValueField = "Id";
                    ddlDebilidad.DataTextField = "Descripcion";
                    ddlDebilidad.DataBind();
                }

                // Configuración si estamos modificando
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    //List<Pokemon> lista = negocio.listar(id);
                    //Pokemon seleccionado = lista[0];
                    Pokemon seleccionado = (negocio.listar(id))[0]; //Se resumen las dos líneas anteriores en una sola.

                    // Guarda a seleccionado en session
                    Session.Add("pokeSeleccionado", seleccionado);

                    // Pre cargar todos los campos
                    txtId.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImagen.Text = seleccionado.UrlImagen;

                    ddlTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    ddlDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();

                    // Carga la imágen
                    imgPokemon.ImageUrl = txtUrlImagen.Text;

                    // Configurar acciones
                    if (!seleccionado.Activo)
                    {
                        btnDesactivar.Text = "Reactivar";
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
                // Redireción a pantalla de error
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevoPoke = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();

                string nombre = txtNombre.Text;
                string descripcion = txtDescripcion.Text;
                string urlImagen = txtUrlImagen.Text;
                int numero = int.Parse(txtNumero.Text);
                
                nuevoPoke.Numero = numero;
                nuevoPoke.Nombre = nombre;
                nuevoPoke.Descripcion = descripcion;
                nuevoPoke.UrlImagen = urlImagen;

                nuevoPoke.Tipo = new Elemento();
                nuevoPoke.Tipo.Id = int.Parse(ddlTipo.SelectedValue);
                nuevoPoke.Debilidad = new Elemento();
                nuevoPoke.Debilidad.Id = int.Parse(ddlDebilidad.SelectedValue);

                if (Request.QueryString["id"] != null)
                {
                    nuevoPoke.Id = int.Parse(txtId.Text);
                    negocio.Modificar(nuevoPoke);
                }
                else
                {
                    negocio.AgregarConSP(nuevoPoke);
                }
                
                Response.Redirect("PokemonLista.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }
        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            imgPokemon.ImageUrl = txtUrlImagen.Text;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;
        }

        protected void ConfirmaElimina_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    PokemonNegocio negocio = new PokemonNegocio();
                    negocio.EliminarFisico(int.Parse(txtId.Text));
                    Response.Redirect("PokemonLista.aspx");
                }              
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                // Recupera al pokemon en session
                Pokemon seleccionado = (Pokemon)Session["pokeSeleccionado"];

                negocio.EliminarLogico(seleccionado.Id, !seleccionado.Activo);
                Response.Redirect("PokemonLista.aspx");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}