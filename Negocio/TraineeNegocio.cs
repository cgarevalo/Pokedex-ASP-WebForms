using Datos;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class TraineeNegocio
    {
        public int InsertarNuevo(Trainee nuevo)
        {
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.SetearProcedimiento("insertarNuevo");
				datos.SetearParametro("@email", nuevo.Email);
				datos.SetearParametro("@pass", nuevo.Pass);
				return datos.EjecutarAccionScalar();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.CerrarConexion();
			}
        }

		public bool Login(Trainee trainee)
		{
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.SetearConsulta("SELECT id, email, pass, fechaNacimiento, admin, imagenPerfil, nombre, apellido FROM USERS WHERE email = @email AND pass = @pass");

				datos.SetearParametro("@email", trainee.Email);
				datos.SetearParametro("@pass", trainee.Pass);
				datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
					trainee.Id = (int)datos.Lector["id"];
					trainee.Admin = (bool)datos.Lector["admin"];
					// Verifica si es imagenPerfil es null
					if (!(datos.Lector["imagenPerfil"] is DBNull))
						trainee.ImagenPerfil = (string)datos.Lector["imagenPerfil"];
					if (!(datos.Lector["nombre"] is DBNull))
						trainee.Nombre = (string)datos.Lector["nombre"];
					if (!(datos.Lector["apellido"] is DBNull))
						trainee.Apellido = (string)datos.Lector["apellido"];
					if (!(datos.Lector["fechaNacimiento"] is DBNull))
						trainee.FechaNacimiento = (DateTime)datos.Lector["fechaNacimiento"];

					return true;
                }

				return false;
            }
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				datos.CerrarConexion();
			}
		}

        public void Actualizar(Trainee user)
        {
			AccesoDatos datos = new AccesoDatos();

			try
			{
				datos.SetearConsulta("UPDATE USERS SET nombre = @nombre, apellido = @apellido, imagenPerfil = @imagen, fechaNacimiento = @fecha WHERE id = @id");

				datos.SetearParametro("@id", user.Id);
				datos.SetearParametro("@nombre", user.Nombre);
				datos.SetearParametro("@apellido", user.Apellido);
				// Una validación ternaria
				//datos.SetearParametro("@imagen", user.ImagenPerfil != null ? user.ImagenPerfil : "");
				datos.SetearParametro("@imagen", user.ImagenPerfil ?? (object)DBNull.Value);
				datos.SetearParametro("@fecha", user.FechaNacimiento);
				datos.EjecutarAccion();
			}
			catch (Exception ex)
			{
				throw ex; 
			}
			finally
			{
				datos.CerrarConexion();
			}
        }
    }
}
