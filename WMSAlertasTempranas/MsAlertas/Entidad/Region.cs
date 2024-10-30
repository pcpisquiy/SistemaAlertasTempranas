using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MsAlertas.DTO;
namespace MsAlertas.Entidad
{
    public class Region
    {
        private SqlConnection sqlcnn=null;
        public Region(SqlConnection sqlconnection) {
            sqlcnn = sqlconnection;
        }
        //Listamos regiones
        public List<RegionDTO> ListarRegiones() {
            string sql = "AT_ListarRegiones";
            SqlCommand cmd = new SqlCommand(sql, sqlcnn);
            cmd.CommandType = CommandType.StoredProcedure;
            return CargarReader(cmd.ExecuteReader());
        }

        protected List<RegionDTO> CargarReader(SqlDataReader reader) {
            try
            {
                List<RegionDTO> ListaRegion = new List<RegionDTO>();
                RegionDTO regionDTO = null;
                while (reader.Read()) {
                    regionDTO = new RegionDTO();
                    regionDTO.Id_Region = reader.GetInt32(0);
                    regionDTO.Region = reader.GetString(1);
                    ListaRegion.Add(regionDTO);
                }
                return ListaRegion;
            }
            catch (Exception ex)
            {

                throw(ex);
            }
        }
    }
}
