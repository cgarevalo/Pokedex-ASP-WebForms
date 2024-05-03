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
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.SesionActiva(Session["trainee"]))
                    {
                        Trainee userConectado = (Trainee)Session["trainee"];

                        txtEmail.Text = userConectado.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = userConectado.Nombre;
                        txtApellido.Text = userConectado.Apellido;
                        txtFechaNacimiento.Text = userConectado.FechaNacimiento.ToString("yyyy-MM-dd");
                        if (!string.IsNullOrEmpty(userConectado.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + userConectado.ImagenPerfil;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {       
            TraineeNegocio negocio = new TraineeNegocio();

            try
            {   
                Trainee user = (Trainee)Session["trainee"];

                // Escribe la imágen si se seleccionó una
                if (txtImagen.PostedFile.FileName != "")
                {
                    // Obtiene la ruta de la carpeta
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                    user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
                }

                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                // Actualiza los datos
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