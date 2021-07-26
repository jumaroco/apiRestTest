using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class CompraDetalle
    {
        [Key]
        public int id { get; set; }
        public int CompraEncabezadoid { get; set; }
        public int Productoid { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public CompraEncabezado CompraEncabezado { get; set; }
        public Producto Producto { get; set; }
    }
}
