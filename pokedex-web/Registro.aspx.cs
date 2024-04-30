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
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Trainee user = new Trainee();
            TraineeNegocio traineeNegocio = new TraineeNegocio();
            EmailService emailService = new EmailService();

            string email = txtEmail.Text;
            string pass = txtPassword.Text;

            try
            {
                user.Email = email;
                user.Pass = pass;
                int id = traineeNegocio.InsertarNuevo(user);

                emailService.ArmarCorreo(user.Email, "Bienvenido entrenador", "Hola te damos la bienvenida a la aplicación.");
                emailService.EnviarEmail();

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error: ", ex.ToString());
            }
        }
    }
}