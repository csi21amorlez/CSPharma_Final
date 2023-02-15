using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Models;

namespace CSPharma_FinalVersion.Pages.VistasEstadoEnvio
{
    public class EditModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public EditModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TdcCatEstadosEnvioPedido TdcCatEstadosEnvioPedido { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }

            var tdccatestadosenviopedido =  await _context.TdcCatEstadosEnvioPedidos.FirstOrDefaultAsync(m => m.Id == id);
            if (tdccatestadosenviopedido == null)
            {
                return NotFound();
            }
            TdcCatEstadosEnvioPedido = tdccatestadosenviopedido;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TdcCatEstadosEnvioPedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TdcCatEstadosEnvioPedidoExists(TdcCatEstadosEnvioPedido.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TdcCatEstadosEnvioPedidoExists(long id)
        {
          return _context.TdcCatEstadosEnvioPedidos.Any(e => e.Id == id);
        }
    }
}
