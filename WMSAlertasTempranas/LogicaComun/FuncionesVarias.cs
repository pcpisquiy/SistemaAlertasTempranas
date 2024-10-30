using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LogicaComun
{
    public class FuncionesVarias
    {
        private static FuncionesVarias _Instancia = null;
        public static FuncionesVarias Instancia
        {
            get
            {
                if (_Instancia == null)
                {
                    _Instancia = new FuncionesVarias();
                }
                return _Instancia;
            }
        }
        /// <summary>
        /// Función para encriptar informacion
        /// </summary>
        /// <param name="Pass">Valor a encriptar</param>
        /// <param name="Clave">Clave para encriptar y desencriptar</param>
        /// <returns>Valor encriptado</returns>
        public string Encripta(string Pass, string Clave)
        {
            try
            {
                int i;
                string Pass2;
                string CAR, Codigo;
                Pass2 = "";
                for (i = 0; i < Pass.Length; i++)
                {
                    CAR = Pass[i].ToString();
                    Codigo = Clave[(i % Clave.Length)].ToString();
                    Pass2 += (Convert.ToInt32(Codigo[0]) ^ Convert.ToInt32(CAR[0])).ToString("X2");
                }
                return Pass2;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }
        /// <summary>
        /// Función para desencriptar informacion
        /// </summary>
        /// <param name="Pass">Valor a desencriptar</param>
        /// <param name="Clave">Clave para desencriptar</param>
        /// <returns>Valor desencriptado</returns>
        public string DesEncripta(string Pass, string Clave)
        {
            try
            {
                int i;
                string Pass2;
                string CAR, Codigo;
                int j = 0;
                Pass2 = "";
                for (i = 0; i < Pass.Length; i += 2)
                {
                    CAR = Pass.Substring(i, 2);
                    Codigo = Clave[(j % Clave.Length)].ToString();
                    Pass2 += (char)(Convert.ToInt32(Codigo[0]) ^ Convert.ToInt32(CAR, 16));
                    j++;
                }
                return Pass2;
            }
            catch (Exception ex)
            {

                throw (ex);
            }
        }


    }
}
