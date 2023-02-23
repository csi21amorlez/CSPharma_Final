using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    /*
     * EnvioDTO --> Clase DTO para la clase entidad TdcCatEstadosEnvioPedido
     */

    public class EnvioDTO
    {
        public long Id { get; set; }
        public string CodEstadoEnvio { get; set; }

        public string DesEstadoEnvio { get; set; }

    }
}
