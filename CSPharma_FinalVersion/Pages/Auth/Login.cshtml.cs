using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Models;
using Models.DTOs;
using CSPharma_FinalVersion.Models.Lógica;
using CSPharma_FinalVersion.Modelos.Lógica;

namespace CSPharma_FinalVersion.Pages.Auth
{
    public class LoginModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public LoginModel(DAL.Models.CspharmaInformationalContext context)
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

            var user = _context.DlkCatAccEmpleados.Where(e => e.ClaveEmpleado == EncriptadorAbstraccion.Encriptar(DlkCatAccEmpleado.ClaveEmpleado) && e.CodEmpleado == DlkCatAccEmpleado.CodEmpleado).FirstOrDefault();
          
            
            if(user == null)
            {
                ModelState.AddModelError(string.Empty, "El nombre de usuario o contraseña es incorrecto.");
                return Page();

            }
            HttpContext.Session.SetInt32("UserRole", (Int32)user.NivelAcceso);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
