using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class CompraEncabezado
    {
        [Key]
        public int id { get; set; }
        public int Sucursalid { get; set; }
        public int Proveedorid { get; set; }
        public DateTime fecha { get; set; }
        public string observaciones { get; set; }
        public Int16 activo { get; set; }
        public Sucursal Sucursal { get; set; }
        public Proveedor Proveedor { get; set; }

        public List<CompraDetalle> CompraDetalles { get; set; }
    }
}
