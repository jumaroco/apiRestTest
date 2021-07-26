using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestTest.DTOs
{
    public class TransaccionDTO
    {
        public int Sucursalid { get; set; }
        //Proveedor ó Cliente
        public int Clienteid { get; set; }
        public DateTime fecha { get; set; }
        public string observaciones { get; set; }
        public Int16 activo { get; set; }
        public List<DetalleTransaccionDTO> Detalles { get; set; }

    }
}
