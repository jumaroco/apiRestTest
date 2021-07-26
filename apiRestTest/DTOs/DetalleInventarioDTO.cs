using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestTest.DTOs
{
    public class DetalleInventarioDTO
    {
        public string Sucursal { get; set; }
        public string Producto { get; set; }
        public int Existencia { get; set; }
    }
}
