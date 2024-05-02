using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace pokedex_web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si la página actual es la página de inicio (home), de registro, login o la de error
            if (!(Page is Login || Page is Default || Page is Registro || Page is Error))
            {
                // Verificar si no hay una sesión activa
                if (!Seguridad.SesionActiva(Session["trainee"]))
                {
                    // Redirigir a la página de inicio de sesión si no hay sesión activa
                    Response.Redirect("Login.aspx", false);
                }
            }

            // Verifica si hay una sesión activa y si imagenPerfil es diferente de null, para cargar la imágen de perfíl
            if (Seguridad.SesionActiva(Session["trainee"]) && ((Trainee)Session["trainee"]).ImagenPerfil != null)
            {
                imgPerfil.ImageUrl = "~/Images/" + ((Trainee)Session["trainee"]).ImagenPerfil;
            }
            // Si no hay una sesión activa o imagenPerfil es null, se carga la imágen por defecto
            else
            {
                imgPerfil.ImageUrl = "https://static.vecteezy.com/system/resources/previews/005/005/788/original/user-icon-in-trendy-flat-style-isolated-on-grey-background-user-symbol-for-your-web-site-design-logo-app-ui-illustration-eps10-free-vector.jpg";
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}