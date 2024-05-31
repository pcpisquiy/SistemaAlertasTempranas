using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Ports;
using MsNotificacion.DTO;
using MsNotificacion.Sesion;
namespace WMSAlertasTempranas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnvioAlertaController : ControllerBase
    {


        [HttpPost("EnviarAlerta")]
        public void EnviarAlerta(int IdRegion,string Mensaje) {
            try
            {

                GestorCelulares gestorCelular = new GestorCelulares();
                gestorCelular.ListarCelulares(IdRegion,Mensaje);
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

    }
}
