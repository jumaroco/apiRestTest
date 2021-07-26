using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Producto
    {
        [Key]
        public int id { get; set; }
        public string codigo { get; set; }
        [Required(ErrorMessage =" El campo {0} es requerido")]
        public string descripcion { get; set; }
        [Required(ErrorMessage = " El campo {0} es requerido")]
        public decimal costo { get; set; }
        [Required(ErrorMessage = " El campo {0} es requerido")]
        public decimal precio { get; set; }
        public Int16 activo { get; set; }
        public List<CompraDetalle> CompraDetalles { get; set; }
        public List<VentaDetalle> VentaDetalles { get; set; }
        public List<Inventario> Inventarios { get; set; }
    }
}
