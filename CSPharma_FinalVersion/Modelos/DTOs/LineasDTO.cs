using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    /*
     * LineasDTO --> Clase DTO para la clase entidad TdcCatLineasDistribucion
     *  
     */
    public class LineasDTO
    {
        public long Id { get; set; }
        public string CodLinea { get; set; }

        public string CodProvincia { get; set; }
    

        public string CodMunicipio { get; set; }

        public string CodBarrio { get; set; }

    }
}
