using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Sucursal
    {
        [Key]
        public int id { get; set; }
        public int Empresaid { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public Int16 activo { get; set; }
        public Empresa Empresa { get; set; }
        public List<VentaEncabezado> VentaEncabezados { get; set; }
        public List<CompraEncabezado> CompraEncabezados { get; set; }
        public List<Inventario> Inventarios { get; set; }

    }
}
