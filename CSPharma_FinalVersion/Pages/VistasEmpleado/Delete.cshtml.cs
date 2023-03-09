using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasEmpleado
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public DeleteModel(DAL.Models.CspharmaInformationalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DlkCatAccEmpleado DlkCatAccEmpleado { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            try
            {
                //Comprobamos si existe el usuario
                if (id == null || _context.DlkCatAccEmpleados == null)
                {
                    return NotFound();
                }
                //Almacenamos los datos del usuario
                var dlkcataccempleado = await _context.DlkCatAccEmpleados.FirstOrDefaultAsync(m => m.Id == id);

                if (dlkcataccempleado == null)
                {
                    return NotFound();
                }
                else
                {
                    //Asignamos los datos a la propiedad que mandaremos a la vista
                    DlkCatAccEmpleado = dlkcataccempleado;
                }
                return Page();
            } catch (Exception ex) 
            {
                return Redirect("../Error");
            }
           
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            try
            {
                //Comprobamos si existe el usuario
                if (id == null || _context.DlkCatAccEmpleados == null)
                {
                    return NotFound();
                } //Almacenamos los datos del usuario
                var dlkcataccempleado = await _context.DlkCatAccEmpleados.FindAsync(id);

                if (dlkcataccempleado != null)
                {
                    DlkCatAccEmpleado = dlkcataccempleado;
                    //Eliminamos el usuario y guardamos los cambios
                    _context.DlkCatAccEmpleados.Remove(DlkCatAccEmpleado);
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./Index");
            }catch (Exception ex)
            {
                return Redirect("../Error");
            }
        }
    }
}
