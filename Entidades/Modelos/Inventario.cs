using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Inventario
    {
        public int Sucursalid { get; set; }
        public int Productoid { get; set; }
        public int stock { get; set; }
        public Sucursal Sucursal { get; set; }
        public Producto Producto { get; set; }
    }
}
