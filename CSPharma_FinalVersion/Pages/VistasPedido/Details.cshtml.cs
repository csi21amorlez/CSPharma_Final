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
    public class DetailsModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public DetailsModel(DAL.Models.CspharmaInformationalContext context)
        {
            _context = context;
        }

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
                    //Asignamos los datos a la propiedad que mostramos
                    TdcTchEstadoPedido = tdctchestadopedido;
                }
                return Page();
            }catch (Exception ex)
            {
                return Redirect("../Error");
            }
            }
           
    }
}
