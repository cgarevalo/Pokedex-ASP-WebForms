using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace pokedex_web
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si la página actual es la página de inicio (home), de registroo login
            if (!(Page is Login) && !(Page is Default) && !(Page is Registro))
            {
                // Verificar si no hay una sesión activa
                if (!Seguridad.SesionActiva(Session["trainee"]))
                {
                    // Redirigir a la página de inicio de sesión si no hay sesión activa
                    Response.Redirect("Login.aspx", false);
                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx", false);
        }
    }
}