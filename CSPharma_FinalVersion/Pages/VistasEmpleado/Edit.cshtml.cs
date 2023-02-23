using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using Models.DTOs;
using CSPharma_FinalVersion.Models.Conversores;

namespace CSPharma_FinalVersion.Pages.VistasEmpleado
{
    public class EditModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;
        private DlkCatAccEmpleado dao;

        public EditModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmpleadoDTO DlkCatAccEmpleado { get; set; } = new EmpleadoDTO();

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.DlkCatAccEmpleados == null)
            {
                return NotFound();
            }

            var dlkcataccempleado = await _context.DlkCatAccEmpleados.FirstOrDefaultAsync(m => m.Id == id);
            
            if (dlkcataccempleado == null)
            {
                return NotFound();
            }
            dao = dlkcataccempleado;
            DlkCatAccEmpleado = ToDto.EmpleadoToDto(dlkcataccempleado);         
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
             dao = DtoTo.EmpleadoDtoToDao(DlkCatAccEmpleado);
            _context.Attach(dao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DlkCatAccEmpleadoExists(dao.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DlkCatAccEmpleadoExists(long id)
        {
            return _context.DlkCatAccEmpleados.Any(e => e.Id == id);
        }
    }
}
