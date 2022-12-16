using System;
using System.Collections.Generic;
using System.Text;

namespace App4_2.Models
{
    public class TiendaModel
    {
        public int IdTienda { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
    }
}
