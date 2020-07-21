using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN
{
    public class DetallePedido
    {
        public string idPedido { get; set; }
        public string idProducto { get; set; }
        public short cantidad { get; set; }
        public float precioUnitario { get; set; }
        public float subTotal { get; set; }
        public string estado { get; set; }

    }
}
