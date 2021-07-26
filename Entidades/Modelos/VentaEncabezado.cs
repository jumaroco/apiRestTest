using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class VentaEncabezado
    {
        [Key]
        public int id { get; set; }
        public int Sucursalid { get; set; }
        public int Clienteid { get; set; }
        public DateTime fecha { get; set; }
        public string observaciones { get; set; }
        public Int16 activo { get; set; }
        public Sucursal Sucursal { get; set; }
        public Cliente Cliente { get; set; }
        public List<VentaDetalle> VentaDetalles { get; set; }

    }
}
