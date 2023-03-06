using CSPharma_FinalVersion.Models.Conversores;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;

namespace CSPharma_FinalVersion.Pages.Auth
{
    public class SignUpModel : Controller
    {
        private readonly CspharmaInformationalContext _context;

        public SignUpModel(CspharmaInformationalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [BindProperty]
        public EmpleadoDTO model { get; set; }
       


        [HttpPost]
        public async Task<IActionResult> Register(EmpleadoDTO model)
        {
            if (ModelState.IsValid)
            {
                // Verificar si ya existe un empleado con ese código
                bool codigoEmpleadoExists = await _context.DlkCatAccEmpleados.AnyAsync(e => e.CodEmpleado == model.CodEmpleado);

                if (codigoEmpleadoExists)
                {
                    ModelState.AddModelError(string.Empty, "Clave de empleado utilizada anteriormente");
                    return View(model);
                }

                // Verificar si las contraseñas coinciden
                if (model.ClaveEmpleado != model.ConfirmPassword)
                {
                    ModelState.AddModelError(string.Empty, "Las contraseñas no coinciden");
                    return View(model);
                }

                // Agregar el empleado a la base de datos
                var empleado = DtoTo.EmpleadoDtoToDao(model);
                _context.Add(empleado);
                await _context.SaveChangesAsync();              
               

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}

