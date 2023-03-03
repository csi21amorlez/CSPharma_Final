using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using Models.DTOs;
using CSPharma_FinalVersion.Models.Conversores;

namespace CSPharma_FinalVersion.Pages.VistasEstadoDevolucion
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public DeleteModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public DevolucionDTO TdcCatEstadosDevolucionPedido { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.TdcCatEstadosDevolucionPedidos == null)
            {
                return NotFound();
            }

            var tdccatestadosdevolucionpedido = ToDto.DevolucionToDto(await _context.TdcCatEstadosDevolucionPedidos.FirstOrDefaultAsync(m => m.Id == id));

            if (tdccatestadosdevolucionpedido == null)
            {
                return NotFound();
            }
            else 
            {
                TdcCatEstadosDevolucionPedido = tdccatestadosdevolucionpedido;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.TdcCatEstadosDevolucionPedidos == null)
            {
                return NotFound();
            }
            var tdccatestadosdevolucionpedido = await _context.TdcCatEstadosDevolucionPedidos.FindAsync(id);

            if (tdccatestadosdevolucionpedido != null)
            {
                TdcCatEstadosDevolucionPedido = ToDto.DevolucionToDto(tdccatestadosdevolucionpedido);
                _context.TdcCatEstadosDevolucionPedidos.Remove(DtoTo.DevolucionDtoToDao(TdcCatEstadosDevolucionPedido));
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
