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
        private SqlConnection sqlcnn = null;
        public Celular(SqlConnection sqlconnection)
        {
            sqlcnn = sqlconnection;
        }
        public List<CelularDTO> ListarCelularRegion(int IdRegion)
        {
            string sql = "AT_ListarCelularRegion";
            SqlCommand cmd = new SqlCommand(sql, sqlcnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@IdRegion", IdRegion));
            return CargarReader(cmd.ExecuteReader());
        }

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
