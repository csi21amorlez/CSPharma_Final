using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTOs { 

    /*
     * PagoDTO--> 
     */

    public class PagoDTO
    {
        public long Id { get; set; }
        public string CodEstadoPago { get; set; }

        public string DesEstadoPago { get; set; }
    }
}
