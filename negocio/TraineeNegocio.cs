﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class TraineeNegocio
    {
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
                datos.setearConsulta("select Id, Email, Pass, Admin from USERS where email = @email and pass = @pass ");
                datos.setearParametros("@email", trainee.Email);
                datos.setearParametros("@pass", trainee.Pass);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    trainee.Id = (int)datos.Lector["Id"];
                    trainee.Admin = (bool)datos.Lector["Admin"];
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
