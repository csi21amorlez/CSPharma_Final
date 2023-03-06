using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using CSPharma_FinalVersion.Models.Conversores;
using Models.DTOs;

namespace CSPharma_FinalVersion.Pages.VistasEmpleado
{
    public class IndexModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public IndexModel(DAL.Models.CspharmaInformationalContext context)
        {
            _context = context;
        }

        public IList<EmpleadoDTO> DlkCatAccEmpleado { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DlkCatAccEmpleados != null)
            {
                DlkCatAccEmpleado = ToDto.ListEmpleadoToDto(await _context.DlkCatAccEmpleados.ToListAsync());
            }
        }
    }
}
