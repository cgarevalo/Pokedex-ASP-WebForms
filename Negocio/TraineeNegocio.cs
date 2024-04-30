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
    }
}
