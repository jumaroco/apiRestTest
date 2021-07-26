using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Modelos
{
    public class Cliente
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido")]
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public int telefono { get; set; }
        public Int16 activo { get; set; }

        public List<VentaEncabezado> VentaEncabezados { get; set; }
    }
}
