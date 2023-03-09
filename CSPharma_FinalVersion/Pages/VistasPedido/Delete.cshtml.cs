using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasPedido
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public DeleteModel(DAL.Models.CspharmaInformationalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public TdcTchEstadoPedido TdcTchEstadoPedido { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            try
            {
                //Comprobamos que el pedido exista
                if (id == null || _context.TdcTchEstadoPedidos == null)
                {
                    return NotFound();
                }
                //Obtenemos sus datos
                var tdctchestadopedido = await _context.TdcTchEstadoPedidos.FirstOrDefaultAsync(m => m.Id == id);

                if (tdctchestadopedido == null)
                {
                    return NotFound();
                }
                else
                {
                    //Asignamos sus datos a la propiedad que mandamos a la vista
                    TdcTchEstadoPedido = tdctchestadopedido;
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
                //Comrpobramos que hayan registros en bbdd
                if (id == null || _context.TdcTchEstadoPedidos == null)
                {
                    return NotFound();
                }
                //Obtenemos los datos del pedido concreto
                var tdctchestadopedido = await _context.TdcTchEstadoPedidos.FindAsync(id);

                if (tdctchestadopedido != null)
                {
                    //Asignamos a la propiedad
                    TdcTchEstadoPedido = tdctchestadopedido;
                    //Eliminamos el pedido
                    _context.TdcTchEstadoPedidos.Remove(TdcTchEstadoPedido);
                    //Guardamos cambios
                    await _context.SaveChangesAsync();
                }

                return RedirectToPage("./Index");
            }catch(Exception ex)
            {
                return Redirect("../Error");
            }
            }

            
    }
}
