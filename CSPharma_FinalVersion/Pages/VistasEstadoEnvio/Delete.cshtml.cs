using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using CSPharma_FinalVersion.Models.Conversores;
using Models.DTOs;

namespace CSPharma_FinalVersion.Pages.VistasEstadoEnvio
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.Models.CspharmaInformacionalContext _context;

        public DeleteModel(DAL.Models.CspharmaInformacionalContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EnvioDTO TdcCatEstadosEnvioPedido { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }

            var tdccatestadosenviopedido = ToDto.EnvioToDto(await _context.TdcCatEstadosEnvioPedidos.FirstOrDefaultAsync(m => m.Id == id));

            if (tdccatestadosenviopedido == null)
            {
                return NotFound();
            }
            else 
            {
                TdcCatEstadosEnvioPedido = tdccatestadosenviopedido;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.TdcCatEstadosEnvioPedidos == null)
            {
                return NotFound();
            }
            var tdccatestadosenviopedido = await _context.TdcCatEstadosEnvioPedidos.FindAsync(id);

            if (tdccatestadosenviopedido != null)
            {
                TdcCatEstadosEnvioPedido = ToDto.EnvioToDto(tdccatestadosenviopedido);
                _context.TdcCatEstadosEnvioPedidos.Remove(DtoTo.EnvioDtoToDao(TdcCatEstadosEnvioPedido));
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
