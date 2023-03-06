using CSPharma_FinalVersion.Models.Conversores;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models.DTOs;
using System;

namespace CSPharma_FinalVersion.Pages.Home
{
    public class LoginModel : Controller
    {
        private readonly CspharmaInformationalContext _context;

        public LoginModel(CspharmaInformationalContext context)
        {
            _context = context;
        }

        [HttpGet]      
        public IActionResult Login()
        {
            return View();
        }
        [BindProperty]
        public EmpleadoDTO model { get; set; }
        [HttpPost]
        public async Task<IActionResult> LoginPost()
        {
            if (ModelState.IsValid)
            {
                EmpleadoDTO user = ToDto.EmpleadoToDto(await _context.DlkCatAccEmpleados.FirstOrDefaultAsync(u => u.CodEmpleado == model.CodEmpleado && u.ClaveEmpleado == model.ClaveEmpleado));

                if (user != null)
                {
                    // Guardar el rol del usuario en la sesión
                    //HttpContext.Session.SetInt32("UserRole", user.NivelAcceso);

                    return Redirect("Index");
                }

                ModelState.AddModelError(string.Empty, "Credenciales invalidos");
            }

            return View(model);
        }
    }
}
