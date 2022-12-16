using System;
using System.Collections.Generic;
using System.Text;

namespace App4_2.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int IdMarca { get; set; }

        public bool Activo { get; set; }
        public string Marca { get; set; }
    }
}
