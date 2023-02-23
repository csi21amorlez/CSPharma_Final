using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using Models.DTOs;
using CSPharma_FinalVersion.Models.Conversores;

namespace CSPharma_FinalVersion.Pages.VistasEmpleado
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public DeleteModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmpleadoDTO DlkCatAccEmpleado { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.DlkCatAccEmpleados == null)
            {
                return NotFound();
            }

            var dlkcataccempleado = ToDto.EmpleadoToDto(await _context.DlkCatAccEmpleados.FirstOrDefaultAsync(m => m.Id == id));


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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.DlkCatAccEmpleados == null)
            {
                return NotFound();
            }
            var dlkcataccempleado = await _context.DlkCatAccEmpleados.FindAsync(id);

            if (dlkcataccempleado != null)
            {

                _context.DlkCatAccEmpleados.Remove(dlkcataccempleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
