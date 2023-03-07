using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Models;
using Models.DTOs;
using CSPharma_FinalVersion.Models.Conversores;
using CSPharma_FinalVersion.Modelos.Lógica;

namespace CSPharma_FinalVersion.Pages.Auth
{
    public class RegisterModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public RegisterModel(DAL.Models.CspharmaInformationalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DlkCatAccEmpleado DlkCatAccEmpleado { get; set; }
        
        [BindProperty]
        public String confirmPassword { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {         
            if (DlkCatAccEmpleado.CodEmpleado.Equals(confirmPassword)) 
            {
                ModelState.AddModelError(string.Empty, "Las contraseñas no coinciden");
                return Page();
            }

            DlkCatAccEmpleado.MdUuid = Guid.NewGuid().ToString();
            DlkCatAccEmpleado.MdDate = DateTime.Now;
            DlkCatAccEmpleado.ClaveEmpleado = EncriptadorAbstraccion.Encriptar(DlkCatAccEmpleado.ClaveEmpleado);
            DlkCatAccEmpleado.NivelAcceso = 2;
            _context.DlkCatAccEmpleados.Add(DlkCatAccEmpleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Login");
        }
    }
}
