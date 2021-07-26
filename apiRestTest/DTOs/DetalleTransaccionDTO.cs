using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiRestTest.DTOs
{
    public class DetalleTransaccionDTO
    {
        //Venta ó Compra
        public int Transaccionid { get; set; }
        public int Productoid { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    }
}
