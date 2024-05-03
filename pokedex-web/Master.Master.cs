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
            // Primero de todo, carga la imágen por defecto de la imágen de perfíl
            imgPerfil.ImageUrl = "https://static.vecteezy.com/system/resources/previews/005/005/788/original/user-icon-in-trendy-flat-style-isolated-on-grey-background-user-symbol-for-your-web-site-design-logo-app-ui-illustration-eps10-free-vector.jpg";

            // Verificar si la página actual es la página de inicio (home), de registro, login o la de error
            if (!(Page is Login || Page is Default || Page is Registro || Page is Error))
            {
                // Verificar si no hay una sesión activa
                if (!Seguridad.SesionActiva(Session["trainee"]))
                {
                    // Redirigir a la página de inicio de sesión si no hay sesión activa
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    Trainee user = (Trainee)Session["trainee"];
                    lbluser.Text = user.Email;
                    if (!string.IsNullOrEmpty(user.ImagenPerfil))
                        imgPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx", false);
        }
    }
}