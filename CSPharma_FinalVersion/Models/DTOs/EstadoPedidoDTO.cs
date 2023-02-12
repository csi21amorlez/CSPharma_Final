using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    /*
     * PedidoDTO --> Clase DTO para la clase entidad TdcTchEstadoPedido
     */
    public class EstadoPedidoDTO
    {
        public string CodEstadoEnvio { get; set; }
        
        public string CodEstadoPago { get; set; }

        public string CodEstadoDevolucion { get; set; }

        public string CodPedido {get; set; }

        public string CodLinea { get; set; }


    }
}
