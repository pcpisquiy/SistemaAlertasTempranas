using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsNotificacion.DTO;
namespace MsNotificacion.Entidad
{
   public class Celular
    {
        //Candea de conexion
        private SqlConnection sqlcnn = null;
        public Celular(SqlConnection sqlconnection)
        {
            //Inicializacmos la cadena de conexion
            sqlcnn = sqlconnection;
        }
        /// <summary>
        /// Lista de celulares por región
        /// </summary>
        /// <param name="IdRegion">Region de donde listaremos los celulares</param>
        /// <returns>Lista de celulares</returns>
        public List<CelularDTO> ListarCelularRegion(int IdRegion)
        {
            //Procedimiento almacenado de la base de datos
            string sql = "AT_ListarCelularRegion";
            SqlCommand cmd = new SqlCommand(sql, sqlcnn);
            cmd.CommandType = CommandType.StoredProcedure;
            //Añadimos parametros a al procedimiento
            //Añadimos parametros a al procedimiento
            cmd.Parameters.Add(new SqlParameter("@IdRegion", IdRegion));
            //Listamos la información
            return CargarReader(cmd.ExecuteReader());
        }
        /// <summary>
        /// Lista de celulares
        /// </summary>
        /// <param name="reader">Objeto reader encargado de la lectura de datos</param>
        /// <returns>Lista con la informacion de la BD</returns>
        protected List<CelularDTO> CargarReader(SqlDataReader reader)
        {
            try
            {
                List<CelularDTO> ListaCelularRegion = new List<CelularDTO>();
                CelularDTO CelularDTO = null;
                while (reader.Read())
                {
                    CelularDTO = new CelularDTO();
                    CelularDTO.Id_Celular = reader.GetInt32(0);
                    CelularDTO.Celular = reader.GetInt64(1);
                    CelularDTO.Id_Region = reader.GetInt32(2);
                    ListaCelularRegion.Add(CelularDTO);
                }
                return ListaCelularRegion;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
