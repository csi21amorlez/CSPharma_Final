using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    /*
     * EmpleadoDTO--> Clase DTO para la clase entidad DlkCatAccEmpleado
     */
    public class EmpleadoDTO
    {
        public long Id { get; set; }
        public string MdUuid { get; set; }
        public DateTime MdDate { get; set; }
        public string CodEmpleado { get; set; }
        public string ClaveEmpleado { get; set; }
        public short NivelAcceso { get; set; }
    }
}
