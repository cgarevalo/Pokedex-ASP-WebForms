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
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {       
            TraineeNegocio negocio = new TraineeNegocio();

            try
            {
                // Escribir img

                // Obtiene la ruta de la carpeta
                string ruta = Server.MapPath("./Images/");
                Trainee user = (Trainee)Session["trainee"];
                // Guarda la imagen seleccionada por el usuario en la ruta de la carpeta
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");

                user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                negocio.Actualizar(user);

                // Leer img

                // Trae el control imgPerfil de la master para poder usarlo acá
                Image img = (Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/Images/" + user.ImagenPerfil;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }
    }
}