using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using MsAlertas.DTO;
namespace MsAlertas.Entidad
{
    public class Emergencia
    {
        SqlConnection sqlcnn = null;
        public Emergencia(SqlConnection sqlConnection) {
            sqlcnn = sqlConnection;
        }
        /// <summary>
        /// Insertamos una emergencia
        /// </summary>
        /// <param name="EmergenciaDTO">Objeto que tiene la información de la emegencia</param>
        public void RegistrarEmergencia(EmergenciaDTO EmergenciaDTO) {
            string sql = "AT_RegistrarEmergencia";
            SqlCommand cmd = new SqlCommand(sql, sqlcnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Emergencia", EmergenciaDTO.Emergencia));
            cmd.Parameters.Add(new SqlParameter("@Fecha_Emergencia", EmergenciaDTO.Fecha_Emergencia));
            cmd.Parameters.Add(new SqlParameter("@Id_Region", EmergenciaDTO.Id_Region));
            cmd.Parameters.Add(new SqlParameter("@Id_Tipo_Emergencia", EmergenciaDTO.Id_Tipo_Emergencia));
            cmd.Parameters.Add(new SqlParameter("@Usuario", EmergenciaDTO.Usuario));
            cmd.ExecuteScalar();
        }
    }
}
