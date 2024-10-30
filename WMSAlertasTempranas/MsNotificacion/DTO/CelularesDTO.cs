using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsNotificacion.DTO
{
    /// <summary>
    /// Modelo Usado para almacenar la informacion de un celular
    /// </summary>
   public class CelularDTO
    {
        public int Id_Celular { get; set; }
        public long Celular { get; set; }
        public int Id_Region { get; set; }
    }
}
