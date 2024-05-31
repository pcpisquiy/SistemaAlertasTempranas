using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsAlertas.DTO;
using MsAlertas.Entidad;
using Microsoft.Data.SqlClient;
using LogicaComun;
using System.Data;
namespace MsAlertas.Sesion
{
   public class GestorEmergencias
    {
        private SqlConnection sqlcnn = new SqlConnection(FuncionesVarias.Instancia.DesEncripta(Properties.Resources.ConexionEmergencias, "SAT_2024"));
        private Emergencia emergencia = null;
        private Region region = null;
        private TipoEmergencia T_Emergencia = null;
        public void RegistrarEmergencia(EmergenciaDTO emergenciaDTO) {
            try
            {
                sqlcnn.Open();
                if (emergencia == null) { emergencia = new Emergencia(sqlcnn); }
                emergencia.RegistrarEmergencia(emergenciaDTO);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally {
                if (sqlcnn.State != ConnectionState.Closed) {
                    sqlcnn.Close();
                }
            }
        }
        public List<RegionDTO> ListarRegiones()
        {
            try
            {
                sqlcnn.Open();
                if (region == null) { region = new Region(sqlcnn); }
                return region.ListarRegiones();
            }
            catch (Exception ex)
            {

                throw (ex);
            }
            finally
            {
                if (sqlcnn.State != ConnectionState.Closed)
                {
                    sqlcnn.Close();
                }
            }
        }
        public List<TipoEmergenciaDTO> ListarTEmergencia() {
            try
            {
                sqlcnn.Open();
                if (T_Emergencia == null) { T_Emergencia = new TipoEmergencia(sqlcnn); }
                return T_Emergencia.ListarTEmergencia();
            }
            catch (Exception ex)
            {

                throw(ex);
            }
            finally
            {
                if (sqlcnn.State != ConnectionState.Closed)
                {
                    sqlcnn.Close();
                }
            }
        }  
       
    }
}
