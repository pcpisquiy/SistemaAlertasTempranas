using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MsAlertas.DTO;
using MsAlertas.Sesion;
using System.IO.Ports;
namespace WMSAlertasTempranas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //API EMERGENCIAS
    public class EmergenciasController : ControllerBase
    {
        private readonly ILogger<EmergenciasController> _logger;

        public EmergenciasController(ILogger<EmergenciasController> logger)
        {
            _logger = logger;
        }
        [HttpPost("RegistrarAlerta")]
        public void RegistrarAlerta(EmergenciaDTO _EmergenciaDTO) {
            try
            {
                GestorEmergencias gestorEmergencias = new GestorEmergencias();
                gestorEmergencias.RegistrarEmergencia(_EmergenciaDTO);
            }
            catch (Exception ex)
            {
                throw(ex);
            }
        }
        [HttpGet("ListarRegiones")]
        public List<RegionDTO> ListarRegiones()
        {
            try
            {
                GestorEmergencias gestorEmergencias = new GestorEmergencias();
                return gestorEmergencias.ListarRegiones();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        [HttpGet("ListarTipoEmergencia")]
        public List<TipoEmergenciaDTO> ListarTipoEmergencia()
        {
            try
            {
                GestorEmergencias gestorEmergencias = new GestorEmergencias();
                return gestorEmergencias.ListarTEmergencia();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}
