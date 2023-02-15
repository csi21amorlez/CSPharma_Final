using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs
{
    /*
     *DevolucionDTO --> Clase DTO para la clase entidad TdcCatEstadosDevolucionPedido
    */
    public class DevolucionDTO
    {
        public long Id { get; set; }
        public string CodEstadoDevolucion { get; set; }

        public String DesEstadoDevolucion { get; set; }

    }
}