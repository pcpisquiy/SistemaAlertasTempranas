using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using MsAlertas.DTO;
using MsAlertas.Sesion;
namespace MsAlertas.Entidad
{
   public class TipoEmergencia
    {
        SqlConnection sqlcnn= null;
        public TipoEmergencia(SqlConnection _sqlcnn) {
            sqlcnn = _sqlcnn;
        }
        public List<TipoEmergenciaDTO> ListarTEmergencia() {
            string sql = "AT_ListarTipoEmergencia";
            SqlCommand cmd = new SqlCommand(sql, sqlcnn);
            cmd.CommandType = CommandType.StoredProcedure;
            return CargarReader(cmd.ExecuteReader());
        }
        protected List<TipoEmergenciaDTO> CargarReader(SqlDataReader reader)
        {
            try
            {
                List<TipoEmergenciaDTO> ListaTEmergencia = new List<TipoEmergenciaDTO>();
                TipoEmergenciaDTO tipoEmergenciaDTO = null;
                while (reader.Read())
                {
                    tipoEmergenciaDTO = new TipoEmergenciaDTO();
                    tipoEmergenciaDTO.Id_Tipo_Emergencia = reader.GetInt32(0);
                    tipoEmergenciaDTO.Tipo_Emergencia = reader.GetString(1);
                    ListaTEmergencia.Add(tipoEmergenciaDTO);
                }
                return ListaTEmergencia;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
    }
}
