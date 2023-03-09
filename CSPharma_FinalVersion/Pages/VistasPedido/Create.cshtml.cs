using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasPedido
{
    public class CreateModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public CreateModel(DAL.Models.CspharmaInformationalContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            try
            {
                //Obtenemos los datos de los campos referenciados
                ViewData["CodEstadoDevolucion"] = new SelectList(_context.TdcCatEstadosDevolucionPedidos, "CodEstadoDevolucion", "DesEstadoDevolucion");
                ViewData["CodEstadoEnvio"] = new SelectList(_context.TdcCatEstadosEnvioPedidos, "CodEstadoEnvio", "DesEstadoEnvio");
                ViewData["CodEstadoPago"] = new SelectList(_context.TdcCatEstadosPagoPedidos, "CodEstadoPago", "DesEstadoPago");
                ViewData["CodLinea"] = new SelectList(_context.TdcCatLineasDistribucions, "CodLinea", "CodLinea");
                return Page();
            }catch (Exception ex)
            {
                return Redirect("../Error");
            }

           
        }


        [BindProperty]
        public TdcTchEstadoPedido TdcTchEstadoPedido { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                //Asignamos mdUuid y mdDate
                TdcTchEstadoPedido.MdUuid = Guid.NewGuid().ToString();
                TdcTchEstadoPedido.MdDate = DateTime.Now;
                //A;adimos el pedido
                _context.TdcTchEstadoPedidos.Add(TdcTchEstadoPedido);
                //Guardamos cambios
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");

            }catch (Exception ex)
            {
                return Redirect("../Error");
            }
         
        }
    }
}
