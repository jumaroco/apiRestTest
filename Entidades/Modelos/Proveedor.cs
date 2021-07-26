using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Proveedor
    {
        [Key]
        public int id { get; set; }
        public string razon_social { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public Int16 activo { get; set; }
        public List<CompraEncabezado> CompraEncabezados { get; set; }


    }
}
