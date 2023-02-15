using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using CSPharma_FinalVersion.Models.Conversores;
using DAL.DTOs;

namespace CSPharma_FinalVersion.Pages.VistasEmpleado
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public DetailsModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

      public EmpleadoDTO DlkCatAccEmpleado { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.DlkCatAccEmpleados == null)
            {
                return NotFound();
            }

            var dlkcataccempleado = ToDto.EmpleadoToDto(await(_context.DlkCatAccEmpleados.FirstOrDefaultAsync(m => m.Id == id)));
            if (dlkcataccempleado == null)
            {
                return NotFound();
            }
            else 
            {
                DlkCatAccEmpleado = dlkcataccempleado;
            }
            return Page();
        }
    }
}
