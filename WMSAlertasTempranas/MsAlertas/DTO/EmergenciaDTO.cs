using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsAlertas.DTO
{
   public class EmergenciaDTO
    {
        public int Id_Emergencia { get; set; }
        public string Emergencia { get; set; }
        public DateTime Fecha_Emergencia { get; set; }
        public int Id_Region { get; set; }
        public int Id_Tipo_Emergencia { get; set; }

        public string Usuario { get; set; }
    }
}
