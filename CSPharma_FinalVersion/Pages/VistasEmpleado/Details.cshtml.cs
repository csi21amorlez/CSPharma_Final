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
    public class DetailsModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public DetailsModel(DAL.Models.CspharmaInformationalContext context)
        {
            _context = context;
        }

        public DlkCatAccEmpleado DlkCatAccEmpleado { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            try
            {
                //Comprobamos que el usuario no sea nulo
                if (id == null || _context.DlkCatAccEmpleados == null)
                {
                    return NotFound();
                }
                //Obtenemos los datos del usuario
                var dlkcataccempleado = await _context.DlkCatAccEmpleados.FirstOrDefaultAsync(m => m.Id == id);
                if (dlkcataccempleado == null)
                {
                    return NotFound();
                }
                else
                {
                    //Assignamos los datos a la propiedad enviada a la vista
                    DlkCatAccEmpleado = dlkcataccempleado;
                }
                return Page();
            }
            catch (Exception ex)
            {
                return Redirect("../Error");
            }

        }
    }
}
