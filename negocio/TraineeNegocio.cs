using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TraineeNegocio
    {
        public void actualizar(Trainee user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update USERS set imagenPerfil = @imagen, nombre = @nombre, apellido = @apellido, fechaNacimiento = @fecha where Id = @id");
                //datos.setearParametros("@imagen", user.ImagenPerfil != null? user.ImagenPerfil : (object)DBNull.Value); operador ternario cumple la misma funcion q el operador null coallesing
                datos.setearParametros("@imagen", (object)user.ImagenPerfil ?? DBNull.Value);//operador null coallesing este permite evaluar la condicion y si es verdadera la manda
                                                                                             //y si no manda el otro valor
                datos.setearParametros("@nombre", user.Nombre);
                datos.setearParametros("@apellido", user.Apellido);
                datos.setearParametros("@fecha", user.FechaNacimiento);
                datos.setearParametros("@id", user.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int insertarNuevo(Trainee nuevo)
        {
            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametros("@Email", nuevo.Email);
                datos.setearParametros("@Pass", nuevo.Pass);

                return datos.ejecutarAccionScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            

        }

        public bool Login (Trainee trainee) 
        {
            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Email, Pass, Admin, imagenPerfil, nombre, apellido, fechaNacimiento from USERS where email = @email and pass = @pass ");
                datos.setearParametros("@email", trainee.Email);
                datos.setearParametros("@pass", trainee.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["Id"];
                    trainee.Admin = (bool)datos.Lector["Admin"];
                    if (!(datos.Lector["imagenPerfil"] is DBNull))
                        trainee.ImagenPerfil = (string)datos.Lector["imagenPerfil"];
                    if (!(datos.Lector["nombre"] is DBNull))
                        trainee.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["apellido"] is DBNull))
                        trainee.Apellido = (string)datos.Lector["apellido"];
                    if (!(datos.Lector["fechaNacimiento"] is DBNull))
                        trainee.FechaNacimiento = DateTime.Parse(datos.Lector["fechaNacimiento"].ToString());
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
                datos.cerrarConexion();
            }
        }

    }
}
