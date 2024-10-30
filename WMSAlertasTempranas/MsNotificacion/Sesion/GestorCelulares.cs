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
        //Inicializamos la cadne ade conexion
        private SqlConnection sqlcnn = new SqlConnection(FuncionesVarias.Instancia.DesEncripta(Properties.Resources.ConexionCelular, "SAT_2024"));
        Celular _celular = null;
        //Establecer conexion con el puerto COM5 donde esta conectado el arduino
        static SerialPortStream Mensajes =  new SerialPortStream("COM5", 9600);
        public GestorCelulares() {
            if (!Mensajes.IsOpen) {
                //INiciar conexion
                Mensajes.Open();
            }
        }
        public void ListarCelulares(int IdRegion,string Mensaje) {
            try
            {
                //Inicia la conexion
                sqlcnn.Open();
                if (_celular == null) { _celular = new Celular(sqlcnn); }
                //Listar los celulares por region
                List<CelularDTO> lista = _celular.ListarCelularRegion(IdRegion);
                foreach (CelularDTO cel in lista)
                {
                    //POr cada celular manda un mensjae por serial al arduino
                    //Para que pueda enviar mensajes.
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
                //Cierra la conexion
                if (sqlcnn.State != System.Data.ConnectionState.Closed) {
                    sqlcnn.Close();
                }
            }
        }
    }
}
