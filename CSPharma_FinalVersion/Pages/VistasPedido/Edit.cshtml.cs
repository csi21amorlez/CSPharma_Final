using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasPedido
{
    public class EditModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformationalContext _context;

        public EditModel(DAL.Models.CspharmaInformationalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TdcTchEstadoPedido TdcTchEstadoPedido { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            try { 
                //Comprobamos que el pedido exista
            if (id == null || _context.TdcTchEstadoPedidos == null)
            {
                return NotFound();
            }
            //Obtenemos los datos del pedido
            var tdctchestadopedido =  await _context.TdcTchEstadoPedidos.FirstOrDefaultAsync(m => m.Id == id);
            if (tdctchestadopedido == null)
            {
                return NotFound();
            }
            //Asignamos los datos a la propiedad que mandamos a la vista
            TdcTchEstadoPedido = tdctchestadopedido;
            //Enviamos los datos de los campos referenciados
            ViewData["CodEstadoDevolucion"] = new SelectList(_context.TdcCatEstadosDevolucionPedidos, "CodEstadoDevolucion", "DesEstadoDevolucion");
            ViewData["CodEstadoEnvio"] = new SelectList(_context.TdcCatEstadosEnvioPedidos, "CodEstadoEnvio", "DesEstadoEnvio");
            ViewData["CodEstadoPago"] = new SelectList(_context.TdcCatEstadosPagoPedidos, "CodEstadoPago", "DesEstadoPago");
            ViewData["CodLinea"] = new SelectList(_context.TdcCatLineasDistribucions, "CodLinea", "CodLinea");
            return Page();
            } catch
            { return Redirect("../Error"); }
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
                //Actualizamos la entidad con los datos obtenidos
                _context.Attach(TdcTchEstadoPedido).State = EntityState.Modified;

                try
                {
                    //Guardamos los cambios
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TdcTchEstadoPedidoExists(TdcTchEstadoPedido.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToPage("./Index");

               
            }catch(Exception ex)
            {
                return Redirect("../Error");
            }
            }
        private bool TdcTchEstadoPedidoExists(long id)
        {
            return _context.TdcTchEstadoPedidos.Any(e => e.Id == id);
        }



    }
}
