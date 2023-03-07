﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasEmpleado
{
    public class EditModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public EditModel(DAL.Models.CspharmaInformationalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DlkCatAccEmpleado DlkCatAccEmpleado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.DlkCatAccEmpleados == null)
            {
                return NotFound();
            }

            var dlkcataccempleado =  await _context.DlkCatAccEmpleados.FirstOrDefaultAsync(m => m.Id == id);
            if (dlkcataccempleado == null)
            {
                return NotFound();
            }
            DlkCatAccEmpleado = dlkcataccempleado;
           ViewData["NivelAcceso"] = new SelectList(_context.DlkCatAccRoles, "Id", "DescRol");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DlkCatAccEmpleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DlkCatAccEmpleadoExists(DlkCatAccEmpleado.Id))
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
