using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Models;
using DAL.DTOs;
using CSPharma_FinalVersion.Models.Consultas;
using CSPharma_FinalVersion.Models.Conversores;

namespace CSPharma_FinalVersion.Pages.VistasEmpleado
{
    public class CreateModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;


        public CreateModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public EmpleadoDTO DlkCatAccEmpleado { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DlkCatAccEmpleados.Add(DtoTo.EmpleadoDtoToDao(DlkCatAccEmpleado));
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
