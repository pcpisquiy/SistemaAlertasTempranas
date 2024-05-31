using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using RJCP.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaComun;
using MsNotificacion.DTO;
using MsNotificacion.Entidad;
namespace MsNotificacion.Sesion
{
    public class GestorCelulares
    {
        private SqlConnection sqlcnn = new SqlConnection(FuncionesVarias.Instancia.DesEncripta(Properties.Resources.ConexionCelular, "SAT_2024"));
        Celular _celular = null;
        static SerialPortStream Mensajes =  new SerialPortStream("COM5", 9600);
        public GestorCelulares() {
            if (!Mensajes.IsOpen) {
                Mensajes.Open();
            }
        }
        public void ListarCelulares(int IdRegion,string Mensaje) {
            try
            {
                sqlcnn.Open();
                if (_celular == null) { _celular = new Celular(sqlcnn); }
                List<CelularDTO> lista = _celular.ListarCelularRegion(IdRegion);
                foreach (CelularDTO cel in lista)
                {
                    Mensajes.WriteLine($"{cel.Celular}:{Mensaje}");
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine(Mensajes.ReadLine());

                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                if (sqlcnn.State != System.Data.ConnectionState.Closed) {
                    sqlcnn.Close();
                }
            }
        }
    }
}
