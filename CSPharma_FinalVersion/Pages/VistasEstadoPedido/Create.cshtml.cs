using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL.Models;
using CSPharma_FinalVersion.Models.Conversores;
using Models.DTOs;

namespace CSPharma_FinalVersion.Pages.VistasEstadoPedido
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
            ViewData["CodEstadoEnvio"] = new SelectList(_context.TdcCatEstadosEnvioPedidos, "CodEstadoEnvio", "DesEstadoEnvio");
            ViewData["CodEstadoPago"] = new SelectList(_context.TdcCatEstadosPagoPedidos, "CodEstadoPago", "DesEstadoPago");
            ViewData["CodLinea"] = new SelectList(_context.TdcCatLineasDistribucions, "CodLinea", "CodLinea");
            return Page();
        }

        [BindProperty]
        public TdcTchEstadoPedido TdcTchEstadoPedido { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }
          

            TdcTchEstadoPedido.MdDate = DateTime.Now;
            TdcTchEstadoPedido.MdUuid = Guid.NewGuid().ToString();
            _context.TdcTchEstadoPedidos.Add(TdcTchEstadoPedido);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
