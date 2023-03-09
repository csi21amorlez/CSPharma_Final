using System;
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
            try
            {
                //Comprobamos que el empleado exista
                if (id == null || _context.DlkCatAccEmpleados == null)
                {
                    return NotFound();
                }
                //Guardamos sus datos
                var dlkcataccempleado = await _context.DlkCatAccEmpleados.FirstOrDefaultAsync(m => m.Id == id);
                if (dlkcataccempleado == null)
                {
                    return NotFound();
                }
                //Asignamos sus valores a la propiedad que mostramos en la vista
                DlkCatAccEmpleado = dlkcataccempleado;
                //Enviamos la lista de roles, el valor asignado sera el id pero el mostrado sera la descripcion
                ViewData["NivelAcceso"] = new SelectList(_context.DlkCatAccRoles, "Id", "DescRol");
                return Page();
            }
            catch (Exception ex)
            {
                return Redirect("../Error");
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                //Obtenemos los datos del usuario
                var entidadAuxiliar = await _context.DlkCatAccEmpleados.FindAsync(DlkCatAccEmpleado.Id);
                //Comprobamos que el empleado no sea nulo
                if (entidadAuxiliar != null)
                {
                    //Asignamos el nuevo valor de rol
                    entidadAuxiliar.NivelAcceso = DlkCatAccEmpleado.NivelAcceso;

                    try
                    {
                        //Guardamos los cambios
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!DlkCatAccEmpleadoExists(DlkCatAccEmpleado.Id))
                        {
                            return NotFound();
                        }                        
                    }                   
                }
                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                return Redirect("../Error");
            }
        }

        private bool DlkCatAccEmpleadoExists(long id)
        {
            return _context.DlkCatAccEmpleados.Any(e => e.Id == id);
        }
    }
}
