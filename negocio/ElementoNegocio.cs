﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ElementoNegocio
    {

        public List<Elemento> listar() 
        {
            List<Elemento> lista = new List<Elemento>(); 
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion from ELEMENTOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Elemento aux =new Elemento();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;

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
